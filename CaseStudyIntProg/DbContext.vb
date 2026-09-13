Imports MySql.Data.MySqlClient
Module DbContext

    Public cn As New MySqlConnection
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public sql As String

    Public Sub connection()

        cn.Close()
        cn.ConnectionString = "server=localhost;user id=root;password=;database=registrar_db"
        cn.Open()

        'MsgBox("Database Connected Successfully!", MsgBoxStyle.Information, "Database Connection")

    End Sub

End Module
