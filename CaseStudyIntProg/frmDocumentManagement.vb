Imports MySql.Data.MySqlClient

Public Class frmDocumentManagement
    Private Sub frmDocumentManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set up ListView headers
        ListViewDocument.View = View.Details
        ListViewDocument.GridLines = True
        ListViewDocument.FullRowSelect = True

        ListViewDocument.Columns.Add("Document ID", 100)
        ListViewDocument.Columns.Add("Document Name", 150)
        ListViewDocument.Columns.Add("Description", 200)
        ListViewDocument.Columns.Add("Fee", 100)
        ListViewDocument.Columns.Add("Status", 100)

        ' Disable all fields initially
        DisableAllFields()

        ' Load records from database
        LoadDocumentInformation()

    End Sub

    ' ---------------------------------------------------------
    ' REUSABLE METHODS
    ' ---------------------------------------------------------
    Private Sub DisableAllFields()
        txtDocumentId.Enabled = False
        txtDocumentName.Enabled = False
        txtDescription.Enabled = False
        txtFee.Enabled = False
        rdoActive.Enabled = False
        rdoInactive.Enabled = False

        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnClear.Enabled = False
    End Sub

    Private Sub EnableInputFields()
        txtDocumentName.Enabled = True
        txtDescription.Enabled = True
        txtFee.Enabled = True
        rdoActive.Enabled = True
        rdoInactive.Enabled = True
    End Sub

    Private Sub LoadDocumentInformation()
        Try
            Call connection()
            ListViewDocument.Items.Clear()

            sql = "SELECT DocumentID, DocumentName, Description, Fee, Status FROM tbldocuments"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            ' Reading and populating the ListView
            While dr.Read()
                Dim lst As New ListViewItem(dr("DocumentID").ToString())
                lst.SubItems.Add(dr("DocumentName").ToString())
                lst.SubItems.Add(dr("Description").ToString())
                lst.SubItems.Add(dr("Fee").ToString())
                lst.SubItems.Add(dr("Status").ToString())
                ListViewDocument.Items.Add(lst)
            End While

        Catch ex As Exception
            MsgBox("Error loading records: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    ' ---------------------------------------------------------
    ' STEP 4: ADD BUTTON LOGIC
    ' ---------------------------------------------------------
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        ' We use the .Enabled property to determine the current state instead of a boolean variable.
        If txtDocumentName.Enabled = False Then
            ' Activate fields for new input
            EnableInputFields()
            btnClear.Enabled = True

            ' Clear any existing text
            txtDocumentId.Text = ""
            txtDocumentName.Text = ""
            txtDescription.Text = ""
            txtFee.Text = ""
            rdoActive.Checked = True
        Else
            ' Perform Validations
            If txtDocumentName.Text.Trim() = "" Then
                MsgBox("Please enter a Document Name.", MsgBoxStyle.Exclamation)
                txtDocumentName.Focus()
                Exit Sub
            End If

            Dim feeAmount As Decimal
            If Not Decimal.TryParse(txtFee.Text, feeAmount) Then
                MsgBox("Please enter a valid numeric Fee.", MsgBoxStyle.Exclamation)
                txtFee.Focus()
                Exit Sub
            End If

            ' Ask to save
            Dim response As MsgBoxResult = MsgBox("Do you want to save this document?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

            If response = MsgBoxResult.Yes Then
                Try
                    Call connection()
                    sql = "INSERT INTO tbldocuments (DocumentName, Description, Fee, Status) VALUES (@name, @desc, @fee, @status)"
                    cmd = New MySqlCommand(sql, cn)

                    With cmd.Parameters
                        .AddWithValue("@name", txtDocumentName.Text)
                        .AddWithValue("@desc", txtDescription.Text)
                        .AddWithValue("@fee", feeAmount)

                        If rdoActive.Checked = True Then
                            .AddWithValue("@status", "Active")
                        Else
                            .AddWithValue("@status", "Inactive")
                        End If
                    End With

                    cmd.ExecuteNonQuery()
                    MsgBox("Document successfully saved!", MsgBoxStyle.Information)

                    ' Refresh List and lock fields
                    LoadDocumentInformation()
                    DisableAllFields()

                Catch ex As Exception
                    MsgBox("Error saving document. Action canceled. " & ex.Message, MsgBoxStyle.Critical)
                Finally
                    cn.Close()
                End Try
            End If
        End If

    End Sub

    ' ---------------------------------------------------------
    ' STEP 5: LISTVIEW CLICK LOGIC
    ' ---------------------------------------------------------
    Private Sub ListViewDocument_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewDocument.SelectedIndexChanged

        If ListViewDocument.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListViewDocument.SelectedItems(0)

            ' Populate fields
            txtDocumentId.Text = selectedItem.Text
            txtDocumentName.Text = selectedItem.SubItems(1).Text
            txtDescription.Text = selectedItem.SubItems(2).Text
            txtFee.Text = selectedItem.SubItems(3).Text

            If selectedItem.SubItems(4).Text = "Active" Then
                rdoActive.Checked = True
            Else
                rdoInactive.Checked = True
            End If

            ' Activate Edit/Delete/Clear Buttons & Input Fields
            EnableInputFields()
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnClear.Enabled = True

            ' STEP 8: Disable the Add button to prevent accidental inserts
            btnAdd.Enabled = False
        End If

    End Sub

    ' ---------------------------------------------------------
    ' STEP 6 (Prompt Step 4): EDIT BUTTON LOGIC
    ' ---------------------------------------------------------
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If txtDocumentId.Text = "" Then
            MsgBox("Please select a document from the list to edit.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Validations
        If txtDocumentName.Text.Trim() = "" Then
            MsgBox("Please enter a Document Name.", MsgBoxStyle.Exclamation)
            txtDocumentName.Focus()
            Exit Sub
        End If

        Dim feeAmount As Decimal
        If Not Decimal.TryParse(txtFee.Text, feeAmount) Then
            MsgBox("Please enter a valid numeric Fee.", MsgBoxStyle.Exclamation)
            txtFee.Focus()
            Exit Sub
        End If

        ' Retrieve previous information from the selected ListView item
        Dim prevName As String = ListViewDocument.SelectedItems(0).SubItems(1).Text
        Dim prevFee As String = ListViewDocument.SelectedItems(0).SubItems(3).Text
        Dim prevDesc As String = ListViewDocument.SelectedItems(0).SubItems(2).Text

        ' Show previous and new info
        MsgBox("PREVIOUS INFO:" & vbCrLf &
               "Name: " & prevName & vbCrLf &
               "Fee: " & prevFee & vbCrLf &
               "Description: " & prevDesc & vbCrLf & vbCrLf &
               "NEW INFO:" & vbCrLf &
               "Name: " & txtDocumentName.Text & vbCrLf &
               "Fee: " & txtFee.Text & vbCrLf &
               "Description: " & txtDescription.Text, MsgBoxStyle.Information)

        Try
            Call connection()
            sql = "UPDATE tbldocuments SET DocumentName = @name, Description = @desc, Fee = @fee, Status = @status WHERE DocumentID = @id"
            cmd = New MySqlCommand(sql, cn)

            With cmd.Parameters
                .AddWithValue("@name", txtDocumentName.Text)
                .AddWithValue("@desc", txtDescription.Text)
                .AddWithValue("@fee", feeAmount)

                If rdoActive.Checked = True Then
                    .AddWithValue("@status", "Active")
                Else
                    .AddWithValue("@status", "Inactive")
                End If

                .AddWithValue("@id", txtDocumentId.Text)
            End With

            cmd.ExecuteNonQuery()
            MsgBox("Document updated successfully!", MsgBoxStyle.Information)

            LoadDocumentInformation()
            DisableAllFields()

        Catch ex As Exception
            MsgBox("Error updating document. Action canceled. " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try

    End Sub

    ' ---------------------------------------------------------
    ' STEP 7 (Prompt Step 5): DELETE BUTTON LOGIC
    ' ---------------------------------------------------------
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If txtDocumentId.Text = "" Then
            MsgBox("Please select a document from the list to delete.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim response As MsgBoxResult = MsgBox("Are you sure you want to delete this document?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

        If response = MsgBoxResult.Yes Then
            Try
                Call connection()
                sql = "DELETE FROM tbldocuments WHERE DocumentID = @id"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", txtDocumentId.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Document deleted successfully!", MsgBoxStyle.Information)

                LoadDocumentInformation()
                DisableAllFields()

            Catch ex As Exception
                MsgBox("Error deleting document. Action canceled. " & ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If

    End Sub

    ' ---------------------------------------------------------
    ' CLEAR BUTTON LOGIC
    ' ---------------------------------------------------------
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ' Clear the text and radio buttons
        txtDocumentId.Text = ""
        txtDocumentName.Text = ""
        txtDescription.Text = ""
        txtFee.Text = ""
        rdoActive.Checked = False
        rdoInactive.Checked = False

        ' Reset the rest of the form to its default locked state
        DisableAllFields()

        ' STEP 9: Enable the Add button again
        btnAdd.Enabled = True

    End Sub
End Class