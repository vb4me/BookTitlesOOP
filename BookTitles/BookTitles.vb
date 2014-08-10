Option Explicit On
Option Strict On



Public Class frmTitles

    'Dim BooksConnection As SqlConnection
    'Dim TitlesCommand As SqlCommand 'SqlCommand Constructor (String, SqlConnection)

    Private Sub frmTitles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Step 1: connect to books database.
        Dim connectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\SQLBooks.mdf;Integrated Security=True;Connect Timeout=30"
        'BooksConnection = New SqlConnection(
        '    "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\SQLBooks.mdf;Integrated Security=True;Connect Timeout=30")

        'Step 2: open the connection.
        'BooksConnection.Open()

        'Step 3: examine/display the state of the connection; open or closed.
        'lblState.Text = BooksConnection.State.ToString

        ''Step 4: this command object executes a query: "Select * from Titles"
        ''against the database using the current connection: BooksConnection.
        'TitlesCommand = New SqlCommand("Select * from Titles", BooksConnection)

        ''Step 5: close the current connection.
        'BooksConnection.Close()

        ''Step 6: Concatenates the new or closed state with the previous open state and displays in a label.
        'lblState.Text += BooksConnection.State.ToString


        ''Step 7: dispose of the objects; remove objects from memory.
        'BooksConnection.Dispose()
        'TitlesCommand.Dispose()

        Using db = New BookDbHelper()
            'lblState.Text = String.Join(", ", db.GetBooks().Take(10).Select(Function(x) x.Isbn))
            'lblState.Text = String.Join(", ", db.GetAuthors().Take(100).Select(Function(x) x.YearBorn))
            dgData.DataSource = db.GetAuthors
            'dgData.DataSource = db.GetBooks
        End Using

    End Sub
End Class
