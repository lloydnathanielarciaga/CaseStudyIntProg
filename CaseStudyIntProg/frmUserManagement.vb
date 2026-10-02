Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmUserManagement

    Private Sub frmUserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewUser.View = View.Details
        ListViewUser.FullRowSelect = True
        ListViewUser.GridLines = True
        ListViewUser.MultiSelect = False

        ListViewUser.Columns.Add("User ID", 70)
        ListViewUser.Columns.Add("Username", 120)
        ListViewUser.Columns.Add("Full Name", 180)
        ListViewUser.Columns.Add("Role", 120)
        ListViewUser.Columns.Add("Status", 80)

        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.Items.Clear()
        cboRole.Items.Add("Administrator")
        cboRole.Items.Add("Registrar Staff")

        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        ListViewUser.Items.Clear()
        cboUserId.Items.Clear()

        Try
            connection()
            sql = "SELECT UserID, Username, FullName, Role, Status FROM tblusers"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim item As New ListViewItem(dr("UserID").ToString())
                item.SubItems.Add(dr("Username").ToString())
                item.SubItems.Add(dr("FullName").ToString())
                item.SubItems.Add(dr("Role").ToString())
                item.SubItems.Add(dr("Status").ToString())
                ListViewUser.Items.Add(item)

                cboUserId.Items.Add(dr("UserID").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show("Failed to load user records. Connection error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            cn.Close()
        End Try
    End Sub

    Private Function ValidateInputs(requirePassword As Boolean) As Boolean
        If txtFullName.Text.Trim() = "" Then
            MessageBox.Show("Full Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return False
        End If
        If txtUsername.Text.Trim() = "" Then
            MessageBox.Show("Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If
        If requirePassword AndAlso txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Password cannot be empty for new accounts.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If
        If cboRole.SelectedIndex = -1 Then
            MessageBox.Show("Please select a valid Role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRole.Focus()
            Return False
        End If
        If Not rdoActive.Checked AndAlso Not rdoInactive.Checked Then
            MessageBox.Show("Please select an account Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        If Not ValidateInputs(True) Then Exit Sub

        Try
            connection()
            sql = "INSERT INTO tblusers (Username, Password, FullName, Role, Status) VALUES (@username, @password, @fullname, @role, @status)"
            cmd = New MySqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
            cmd.Parameters.AddWithValue("@fullname", txtFullName.Text.Trim())
            cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@status", If(rdoActive.Checked, "Active", "Inactive"))

            cmd.ExecuteNonQuery()
            LogAudit("Add User", "Created user account for: " & txtUsername.Text.Trim(), CurrentFullName)
            MessageBox.Show("User account successfully created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to create user. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
            LoadUsers()
            btnClear.PerformClick()
        End Try
    End Sub

    Private Sub btnEditUser_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click
        If cboUserId.Text.Trim() = "" Then
            MessageBox.Show("Please select a User ID to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateInputs(False) Then Exit Sub

        Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to save changes to this user?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialogResult = DialogResult.Yes Then
            Try
                connection()
                If txtPassword.Text.Trim() <> "" Then
                    sql = "UPDATE tblusers SET Username = @username, Password = @password, FullName = @fullname, Role = @role, Status = @status WHERE UserID = @userid"
                Else
                    sql = "UPDATE tblusers SET Username = @username, FullName = @fullname, Role = @role, Status = @status WHERE UserID = @userid"
                End If

                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@userid", cboUserId.Text)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@fullname", txtFullName.Text.Trim())
                cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@status", If(rdoActive.Checked, "Active", "Inactive"))

                If txtPassword.Text.Trim() <> "" Then
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
                End If

                cmd.ExecuteNonQuery()
                LogAudit("Edit User", "Updated user account ID: " & cboUserId.Text, CurrentFullName)
                MessageBox.Show("User account successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Failed to update user. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cn.Close()
                LoadUsers()
                btnClear.PerformClick()
            End Try
        End If
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If cboUserId.Text.Trim() = "" Then
            MessageBox.Show("Please select a User ID to deactivate.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to deactivate this user? This will revoke system access.", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If dialogResult = DialogResult.Yes Then
            Try
                connection()
                sql = "UPDATE tblusers SET Status = 'Inactive' WHERE UserID = @userid"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@userid", cboUserId.Text)

                cmd.ExecuteNonQuery()
                LogAudit("Deactivate User", "Deactivated user account ID: " & cboUserId.Text, CurrentFullName)
                MessageBox.Show("User has been securely deactivated.", "Deactivation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Failed to deactivate user. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cn.Close()
                LoadUsers()
                btnClear.PerformClick()
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cboUserId.SelectedIndex = -1
        cboUserId.Text = ""
        txtFullName.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        cboRole.SelectedIndex = -1
        rdoActive.Checked = False
        rdoInactive.Checked = False
        txtFullName.Focus()
    End Sub

    Private Sub ListViewUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewUser.SelectedIndexChanged
        If ListViewUser.SelectedItems.Count > 0 Then
            Dim selectedItem = ListViewUser.SelectedItems(0)
            cboUserId.Text = selectedItem.SubItems(0).Text
            txtUsername.Text = selectedItem.SubItems(1).Text
            txtFullName.Text = selectedItem.SubItems(2).Text
            cboRole.Text = selectedItem.SubItems(3).Text

            If selectedItem.SubItems(4).Text = "Active" Then
                rdoActive.Checked = True
            Else
                rdoInactive.Checked = True
            End If
            txtPassword.Clear()
        End If
    End Sub

    Private Sub ListViewUser_DoubleClick(sender As Object, e As EventArgs) Handles ListViewUser.DoubleClick

        If ListViewUser.SelectedItems.Count > 0 Then
            Dim selectedUserId As Integer = Convert.ToInt32(ListViewUser.SelectedItems(0).Text)
            Dim selectedUsername As String = ListViewUser.SelectedItems(0).SubItems(1).Text
            Dim staffName As String = ListViewUser.SelectedItems(0).SubItems(2).Text

            Dim frmPrompt As New frmTransactionHistoryAndAuditLogPrompt()
            frmPrompt.SelectedUserID = selectedUserId
            frmPrompt.SelectedUsername = selectedUsername
            frmPrompt.SelectedStaffName = staffName
            frmPrompt.Text = "History & Audit Logs: " & staffName

            frmPrompt.ShowDialog()
        End If
    End Sub
End Class