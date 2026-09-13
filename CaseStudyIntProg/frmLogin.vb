Imports MySql.Data.MySqlClient

Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call connection()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        ' Step 3: Proper validations to all input fields[cite: 1]
        If txtUsername.Text.Trim() = "" Then
            MessageBox.Show("Please enter your username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUsername.Focus()
            Exit Sub
        End If

        If txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPassword.Focus()
            Exit Sub
        End If

        ' Step 3 & 4: Database check, error handling, and role filtering[cite: 1, 3]
        Try
            Call connection()

            sql = "SELECT Role FROM tblusers WHERE Username = @username AND Password = @password"
            cmd = New MySqlCommand(sql, cn)

            ' Use .Parameters for security and readability[cite: 3, 4]
            cmd.Parameters.AddWithValue("@username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@password", txtPassword.Text)

            dr = cmd.ExecuteReader()

            ' Combine While and .Parameters for easy reading
            ' No boolean variables are used; the loop inherently checks for existence
            While dr.Read()
                MessageBox.Show("Log in Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Filter successful login if their role is admin or staff[cite: 3]
                If dr("Role").ToString() = "Administrator" Then
                    'frmAdmin.Show()
                    MsgBox("Welcome Administrator!")
                    Me.Hide()
                ElseIf dr("Role").ToString() = "Registrar Staff" Then
                    'frmStaff.Show()
                    MsgBox("Welcome Registrar Staff!")
                    Me.Hide()
                End If

                ' Clean up and exit immediately upon success
                dr.Close()
                cn.Close()
                Exit Sub
            End While

            ' If the loop finishes without executing Exit Sub, the user does not exist
            dr.Close()
            MessageBox.Show("Log in Failed! Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception
            ' Rollback/Error Handling if an unexpected error occurs[cite: 1]
            MessageBox.Show("An error occurred: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Ensure the connection is always closed[cite: 1]
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub
End Class