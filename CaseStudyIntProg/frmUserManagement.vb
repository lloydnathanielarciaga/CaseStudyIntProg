Imports MySql.Data.MySqlClient

Public Class frmUserManagement
    Private Sub frmUserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ListViewUser.View = View.Details
        ListViewUser.FullRowSelect = True
        ListViewUser.GridLines = True

        ListViewUser.Columns.Clear()
        ListViewUser.Columns.Add("User ID", 80)
        ListViewUser.Columns.Add("Username", 150)
        ListViewUser.Columns.Add("Full Name", 200)
        ListViewUser.Columns.Add("Role", 150)
        ListViewUser.Columns.Add("Status", 100)

        LoadUsers()
        LoadComboBoxes()
        ClearAllFields()

    End Sub

    Private Sub LoadUsers()
        Try
            connection()
            sql = "SELECT UserID, Username, FullName, Role, Status FROM tblusers"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            ListViewUser.Items.Clear()

            While dr.Read()
                Dim item As New ListViewItem(dr("UserID").ToString())
                item.SubItems.Add(dr("Username").ToString())
                item.SubItems.Add(dr("FullName").ToString())
                item.SubItems.Add(dr("Role").ToString())
                item.SubItems.Add(dr("Status").ToString())
                ListViewUser.Items.Add(item)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub LoadComboBoxes()
        cboRole.Items.Clear()
        cboRole.Items.Add("Administrator")
        cboRole.Items.Add("Registrar Staff")

        Try
            connection()
            sql = "SELECT UserID FROM tblusers"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            cboUserId.Items.Clear()
            cboUserId.Items.Add("NEW")

            While dr.Read()
                cboUserId.Items.Add(dr("UserID").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub cboUserId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUserId.SelectedIndexChanged

        If cboUserId.Text = "NEW" Then
            txtFullName.Clear()
            txtUsername.Clear()
            txtPassword.Clear()
            cboRole.SelectedIndex = -1
            rdoActive.Checked = False
            rdoInactive.Checked = False

            txtFullName.Enabled = True
            txtUsername.Enabled = True
            txtPassword.Enabled = True
            cboRole.Enabled = True
            rdoActive.Enabled = True
            rdoInactive.Enabled = True

            btnAddUser.Enabled = True
            btnEditUser.Enabled = False
            btnDeleteUser.Enabled = False

        ElseIf cboUserId.Text <> "" Then
            Try
                connection()
                sql = "SELECT * FROM tblusers WHERE UserID = @UserID"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@UserID", cboUserId.Text)
                dr = cmd.ExecuteReader()

                While dr.Read()
                    txtUsername.Text = dr("Username").ToString()
                    txtPassword.Text = dr("Password").ToString()
                    txtFullName.Text = dr("FullName").ToString()
                    cboRole.Text = dr("Role").ToString()

                    If dr("Status").ToString() = "Active" Then
                        rdoActive.Checked = True
                    Else
                        rdoInactive.Checked = True
                    End If
                End While
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cn.Close()
            End Try

            txtFullName.Enabled = True
            txtUsername.Enabled = True
            txtPassword.Enabled = True
            cboRole.Enabled = True
            rdoActive.Enabled = True
            rdoInactive.Enabled = True

            btnAddUser.Enabled = False
            btnEditUser.Enabled = True
            btnDeleteUser.Enabled = True
        End If

    End Sub

    Private Sub ListViewUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewUser.SelectedIndexChanged

        If ListViewUser.SelectedItems.Count > 0 Then
            cboUserId.Text = ListViewUser.SelectedItems(0).Text
        End If

    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click

        If txtFullName.Text.Trim() = "" Then
            MessageBox.Show("Please enter the full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Exit Sub
        End If
        If txtUsername.Text.Trim() = "" Then
            MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Exit Sub
        End If
        If txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        End If
        If cboRole.Text.Trim() = "" Then
            MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRole.Focus()
            Exit Sub
        End If
        If rdoActive.Checked = False And rdoInactive.Checked = False Then
            MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim userStatus As String = ""
        If rdoActive.Checked Then
            userStatus = "Active"
        ElseIf rdoInactive.Checked Then
            userStatus = "Inactive"
        End If

        Try
            connection()

            sql = "SELECT Username FROM tblusers WHERE Username = @Username"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
            dr = cmd.ExecuteReader()

            While dr.Read()
                MessageBox.Show("Username already exists. Please enter a different one.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dr.Close()
                cn.Close()
                Exit Sub
            End While
            dr.Close()

            sql = "INSERT INTO tblusers (Username, Password, FullName, Role, Status) VALUES (@Username, @Password, @FullName, @Role, @Status)"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim())
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
            cmd.Parameters.AddWithValue("@Role", cboRole.Text)
            cmd.Parameters.AddWithValue("@Status", userStatus)
            cmd.ExecuteNonQuery()

            MessageBox.Show("User successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try

        LoadUsers()
        LoadComboBoxes()
        ClearAllFields()

    End Sub

    Private Sub btnEditUser_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click

        If cboUserId.Text.Trim() = "" Or cboUserId.Text = "NEW" Then
            MessageBox.Show("Please select a valid User ID to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If txtFullName.Text.Trim() = "" Or txtUsername.Text.Trim() = "" Or txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Fields cannot be empty during update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim userStatus As String = ""
        If rdoActive.Checked Then
            userStatus = "Active"
        ElseIf rdoInactive.Checked Then
            userStatus = "Inactive"
        End If

        Try
            connection()
            sql = "UPDATE tblusers SET Username=@Username, Password=@Password, FullName=@FullName, Role=@Role, Status=@Status WHERE UserID=@UserID"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim())
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
            cmd.Parameters.AddWithValue("@Role", cboRole.Text)
            cmd.Parameters.AddWithValue("@Status", userStatus)
            cmd.Parameters.AddWithValue("@UserID", cboUserId.Text)
            cmd.ExecuteNonQuery()

            MessageBox.Show("User successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try

        LoadUsers()
        ClearAllFields()

    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click

        If cboUserId.Text.Trim() = "" Or cboUserId.Text = "NEW" Then
            MessageBox.Show("Please select a valid User ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirmDelete = MessageBox.Show("Are you sure you want to completely delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmDelete = DialogResult.Yes Then
            Try
                connection()
                sql = "DELETE FROM tblusers WHERE UserID = @UserID"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@UserID", cboUserId.Text)
                cmd.ExecuteNonQuery()

                MessageBox.Show("User successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cn.Close()
            End Try

            LoadUsers()
            LoadComboBoxes()
            ClearAllFields()
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearAllFields()

    End Sub

    Private Sub ClearAllFields()
        cboUserId.SelectedIndex = -1
        cboUserId.Text = ""
        txtFullName.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        cboRole.SelectedIndex = -1
        rdoActive.Checked = False
        rdoInactive.Checked = False

        txtFullName.Enabled = False
        txtUsername.Enabled = False
        txtPassword.Enabled = False
        cboRole.Enabled = False
        rdoActive.Enabled = False
        rdoInactive.Enabled = False

        btnAddUser.Enabled = False
        btnEditUser.Enabled = False
        btnDeleteUser.Enabled = False
    End Sub

End Class