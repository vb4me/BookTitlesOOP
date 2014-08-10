Imports System.Data.Common
Imports System.Runtime.CompilerServices

Module DbDataReaderExtension

    <Extension()>
    Public Function GetInt16(rdr As DbDataReader, ordinal As Integer, value As Int16) As Int16
        If rdr.IsDBNull(ordinal) Then
            Return value
        Else
            Return rdr.GetInt16(ordinal)
        End If
    End Function


End Module
