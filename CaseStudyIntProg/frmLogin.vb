Imports MySql.Data.MySqlClient

Public Class frmLogin

    Private Sub ValidateInputs()
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            btnLogin.Enabled = False
        Else
            btnLogin.Enabled = True
        End If
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

        ValidateInputs()

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

        ValidateInputs()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        txtUsername.Text = ""
        txtPassword.Text = ""
        txtUsername.Focus()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please enter username and password.", "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            Call connection()

            sql = "SELECT Password, Role, Status FROM tblusers WHERE Username = @Username"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text)

            dr = cmd.ExecuteReader()

            Dim userCount As Integer = 0

            While dr.Read()
                userCount = userCount + 1

                If dr("Password").ToString() = txtPassword.Text Then

                    If dr("Status").ToString() = "Active" Then
                        MessageBox.Show("Login Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        If dr("Role").ToString() = "Administrator" Then
                            frmAdmin.Show()
                            Me.Hide()
                        ElseIf dr("Role").ToString() = "Registrar Staff" Then
                            frmStaff.Show()
                            Me.Hide()
                        End If
                    Else
                        MessageBox.Show("Your account is Inactive. Please contact the administrator.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("Login Failed! Incorrect password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End While

            If userCount = 0 Then
                MessageBox.Show("User does not exist!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            dr.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try

    End Sub
End Class