Imports System.Data.Common

Public Class BookDbHelper
    Inherits DbHelperBase

    Sub New()
        MyBase.New("BookTitles.My.MySettings.SQLBooksConnectionString")
    End Sub

    Function GetBooks() As List(Of Book)
        Dim func = Function(rdr As DbDataReader)
                       Dim book As New Book
                       book.Title = rdr.GetString(0)
                       book.Isbn = rdr.GetString(1)
                       Return book
                   End Function
        Return MyBase.Execute("Select Title,ISBN from Titles", func)
    End Function

    Function GetAuthors() As List(Of Author)
        Dim func = Function(rdr As DbDataReader)
                       Dim obj As New Author
                       obj.Name = rdr.GetString(0)
                       obj.YearBorn = rdr.GetInt16(1, 99)
                       Return obj
                   End Function
        Return MyBase.Execute("Select Author,Year_Born from Authors", func)
    End Function


End Class
