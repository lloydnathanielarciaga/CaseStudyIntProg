Imports MySql.Data.MySqlClient
Module DbContext

    Public cn As New MySqlConnection
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public sql As String

    Public Const ConnString As String = "server=localhost;user id=root;password=;database=registrar_db"
    Public Sub connection()

        cn.Close()
        cn.ConnectionString = ConnString
        cn.Open()

        'MsgBox("Database Connected Successfully!", MsgBoxStyle.Information, "Database Connection")

    End Sub

    Public CurrentUserID As Integer
    Public CurrentFullName As String
    Public CurrentSemester As Integer = 1
    Public CurrentUsername As String

    Public Sub LogAudit(action As String, details As String, performedBy As String, Optional requestID As Object = Nothing)
        Try
            connection()
            Dim sql As String = "INSERT INTO tblauditlog (Action, Details, PerformedBy, RequestID) VALUES (@action, @details, @performedBy, @reqID)"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@action", action)
            cmd.Parameters.AddWithValue("@details", details)
            cmd.Parameters.AddWithValue("@performedBy", performedBy)

            If requestID Is Nothing OrElse String.IsNullOrWhiteSpace(requestID.ToString()) Then
                cmd.Parameters.AddWithValue("@reqID", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@reqID", requestID)
            End If

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Console.WriteLine("Audit Log Error: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

End Module
