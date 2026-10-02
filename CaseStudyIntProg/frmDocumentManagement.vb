Imports MySql.Data.MySqlClient

Public Class frmDocumentManagement

    Private Sub frmDocumentManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewDocument.View = View.Details
        ListViewDocument.GridLines = True
        ListViewDocument.FullRowSelect = True

        ListViewDocument.Columns.Add("Document ID", 180)
        ListViewDocument.Columns.Add("Document Name", 400)
        ListViewDocument.Columns.Add("Description", 550)
        ListViewDocument.Columns.Add("Fee", 130)
        ListViewDocument.Columns.Add("Status", 120)

        btnClear.PerformClick()

        LoadDocuments()
    End Sub

    Private Sub LoadDocuments()
        Try
            Call connection()
            ListViewDocument.Items.Clear()

            sql = "SELECT DocumentID, DocumentName, Description, Fee, Status FROM tbldocuments"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim lvItem As New ListViewItem(dr("DocumentID").ToString())
                lvItem.SubItems.Add(dr("DocumentName").ToString())
                lvItem.SubItems.Add(dr("Description").ToString())
                lvItem.SubItems.Add(dr("Fee").ToString())
                lvItem.SubItems.Add(dr("Status").ToString())
                ListViewDocument.Items.Add(lvItem)
            End While
        Catch ex As Exception
            MsgBox("Error loading records: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not txtDocumentName.Enabled Then
            txtDocumentID.Clear()
            txtDocumentName.Clear()
            txtDescription.Clear()
            txtFee.Clear()

            txtDocumentName.Enabled = True
            txtDescription.Enabled = True
            txtFee.Enabled = True
            rdoActive.Enabled = True
            rdoInactive.Enabled = True

            rdoActive.Checked = True
            txtDocumentName.Focus()
            Exit Sub
        End If

        If txtDocumentName.Text.Trim() = "" Then
            MsgBox("Please enter a Document Name.", MsgBoxStyle.Exclamation)
            txtDocumentName.Focus()
            Exit Sub
        End If

        Dim feeAmount As Decimal
        If Not Decimal.TryParse(txtFee.Text, feeAmount) Then
            MsgBox("Please enter a valid numeric amount for the Fee.", MsgBoxStyle.Exclamation)
            txtFee.Focus()
            Exit Sub
        End If

        Dim docStatus As String = If(rdoActive.Checked, "Active", "Inactive")

        If MsgBox("Are you sure you want to add this document?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Try
                Call connection()
                sql = "INSERT INTO tbldocuments (DocumentName, Description, Fee, Status) VALUES (@name, @desc, @fee, @status)"
                cmd = New MySqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@name", txtDocumentName.Text.Trim())
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@fee", feeAmount)
                cmd.Parameters.AddWithValue("@status", docStatus)

                cmd.ExecuteNonQuery()

                LogAudit("Add Document", "Added new document: " & txtDocumentName.Text.Trim(), CurrentFullName)
                MsgBox("Document successfully added!", MsgBoxStyle.Information)

                LoadDocuments()
                btnClear.PerformClick()
            Catch ex As Exception
                MsgBox("Error adding document: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtDocumentID.Text = "" Then
            MsgBox("Please select a document from the list to edit.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If txtDocumentName.Text.Trim() = "" Then
            MsgBox("Please enter a Document Name.", MsgBoxStyle.Exclamation)
            txtDocumentName.Focus()
            Exit Sub
        End If

        Dim feeAmount As Decimal
        If Not Decimal.TryParse(txtFee.Text, feeAmount) Then
            MsgBox("Please enter a valid numeric amount for the Fee.", MsgBoxStyle.Exclamation)
            txtFee.Focus()
            Exit Sub
        End If

        Dim inputPass As String = ""
        Using prompt As New frmPasswordPrompt()
            If prompt.ShowDialog() = DialogResult.OK Then
                inputPass = prompt.Password
            Else
                Exit Sub
            End If
        End Using

        If String.IsNullOrWhiteSpace(inputPass) Then
            MsgBox("Password cannot be blank.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim isAuthorized As Boolean = False
        Try
            Call connection()
            sql = "SELECT UserID FROM tblusers WHERE UserID = @uid AND Password = @pass"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@uid", CurrentUserID)
            cmd.Parameters.AddWithValue("@pass", inputPass)
            dr = cmd.ExecuteReader()
            If dr.Read() Then isAuthorized = True
        Catch ex As Exception
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally
            cn.Close()
        End Try

        If Not isAuthorized Then
            MsgBox("Incorrect password. Edit cancelled.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim docStatus As String = If(rdoActive.Checked, "Active", "Inactive")

        If MsgBox("Are you sure you want to update this document?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Try
                Call connection()
                sql = "UPDATE tbldocuments SET DocumentName = @name, Description = @desc, Fee = @fee, Status = @status WHERE DocumentID = @id"
                cmd = New MySqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@name", txtDocumentName.Text.Trim())
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@fee", feeAmount)
                cmd.Parameters.AddWithValue("@status", docStatus)
                cmd.Parameters.AddWithValue("@id", txtDocumentID.Text)

                cmd.ExecuteNonQuery()

                LogAudit("Edit Document", "Updated document ID: " & txtDocumentID.Text, CurrentFullName)
                MsgBox("Document successfully updated!", MsgBoxStyle.Information)

                LoadDocuments()
                btnClear.PerformClick()
            Catch ex As Exception
                MsgBox("Error updating document: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtDocumentID.Text = "" Then
            MsgBox("Please select a document from the list to delete.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim inputPass As String = ""
        Using prompt As New frmPasswordPrompt()
            If prompt.ShowDialog() = DialogResult.OK Then
                inputPass = prompt.Password
            Else
                Exit Sub
            End If
        End Using

        If String.IsNullOrWhiteSpace(inputPass) Then
            MsgBox("Password cannot be blank.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim isAuthorized As Boolean = False
        Try
            Call connection()
            sql = "SELECT UserID FROM tblusers WHERE UserID = @uid AND Password = @pass"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@uid", CurrentUserID)
            cmd.Parameters.AddWithValue("@pass", inputPass)
            dr = cmd.ExecuteReader()
            If dr.Read() Then isAuthorized = True
        Catch ex As Exception
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally
            cn.Close()
        End Try

        If Not isAuthorized Then
            MsgBox("Incorrect password. Action cancelled.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Are you sure you want to deactivate this document?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Try
                Call connection()
                sql = "UPDATE tbldocuments SET Status = 'Inactive' WHERE DocumentID = @id"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", txtDocumentID.Text)

                cmd.ExecuteNonQuery()

                LogAudit("Deactivate Document", "Deactivated document ID: " & txtDocumentID.Text, CurrentFullName)
                MsgBox("Document status successfully changed to Inactive!", MsgBoxStyle.Information)

                LoadDocuments()
                btnClear.PerformClick()
            Catch ex As Exception
                MsgBox("Error deactivating document: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDocumentID.Clear()
        txtDocumentName.Clear()
        txtDescription.Clear()
        txtFee.Clear()
        rdoActive.Checked = False
        rdoInactive.Checked = False

        txtDocumentID.Enabled = False
        txtDocumentName.Enabled = False
        txtDescription.Enabled = False
        txtFee.Enabled = False
        rdoActive.Enabled = False
        rdoInactive.Enabled = False

        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnAdd.Enabled = True
    End Sub

    Private Sub ListViewDocument_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewDocument.SelectedIndexChanged
        If ListViewDocument.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListViewDocument.SelectedItems(0)

            txtDocumentID.Text = selectedItem.Text
            txtDocumentName.Text = selectedItem.SubItems(1).Text
            txtDescription.Text = selectedItem.SubItems(2).Text
            txtFee.Text = selectedItem.SubItems(3).Text

            If selectedItem.SubItems(4).Text = "Active" Then
                rdoActive.Checked = True
            Else
                rdoInactive.Checked = True
            End If

            txtDocumentName.Enabled = True
            txtDescription.Enabled = True
            txtFee.Enabled = True
            rdoActive.Enabled = True
            rdoInactive.Enabled = True

            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnAdd.Enabled = False
        End If
    End Sub

End Class