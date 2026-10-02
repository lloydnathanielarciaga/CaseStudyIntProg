Imports MySql.Data.MySqlClient

Public Class frmLogin


    Private Sub ValidateInputs()
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            btnLogin.Enabled = False
        Else
            btnLogin.Enabled = True
        End If
    End Sub


    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs)

        ValidateInputs()

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs)

        ValidateInputs()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please enter username and password.", "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            Call connection()

            sql = "SELECT UserID, FullName, Password, Role, Status FROM tblusers WHERE Username = @Username"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text)

            dr = cmd.ExecuteReader()

            Dim userCount As Integer = 0

            While dr.Read()
                userCount = userCount + 1

                If dr("Password").ToString() = txtPassword.Text Then

                    If dr("Status").ToString() = "Active" Then
                        DbContext.CurrentUserID = Convert.ToInt32(dr("UserID"))
                        DbContext.CurrentFullName = dr("FullName").ToString()

                        MessageBox.Show("Login Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        If dr("Role").ToString() = "Administrator" Then
                            If dr.Read() Then
                                CurrentUserID = CInt(dr("UserID"))
                                CurrentFullName = dr("FullName").ToString()
                            End If
                            frmAdmin.Show()
                            Me.Hide()
                        ElseIf dr("Role").ToString() = "Registrar Staff" Then
                            If dr.Read() Then
                                CurrentUserID = CInt(dr("UserID"))
                                CurrentFullName = dr("FullName").ToString()
                            End If
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtUsername.Focus()
    End Sub
End Class