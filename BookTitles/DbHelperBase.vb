Imports System.Data
Imports System.Data.Common
Imports System.Configuration

Public MustInherit Class DbHelperBase
    Implements IDisposable

    Sub New(connectionStringName As String)
        Me.ConnectionStringSettings = ConfigurationManager.ConnectionStrings(connectionStringName)
        Me.DbProviderFactory = DbProviderFactories.GetFactory(Me.ConnectionStringSettings.ProviderName)
        Me.Connection = Me.DbProviderFactory.CreateConnection()
        Me.Connection.ConnectionString = Me.ConnectionStringSettings.ConnectionString
        Me.Connection.Open()
    End Sub

    Private Property DbProviderFactory() As DbProviderFactory
    Private Property ConnectionStringSettings() As ConnectionStringSettings
    Private Property Connection() As DbConnection


    Function Execute(Of T)(sql As String, func As Func(Of DbDataReader, T)) As List(Of T)
        Dim rows As New List(Of T)
        Using cmd = Me.DbProviderFactory.CreateCommand()
            cmd.Connection = Me.Connection
            cmd.CommandText = sql
            Dim rdr = cmd.ExecuteReader
            While rdr.Read()
                rows.Add(func.Invoke(rdr))
            End While
        End Using
        Return rows
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                Connection.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region





End Class
