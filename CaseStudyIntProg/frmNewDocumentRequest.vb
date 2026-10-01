Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Printing

Public Class frmNewDocumentRequest
    Public LoggedInUserID As Integer
    Public LoggedInFullName As String

    Private CurrentTotalAmount As Decimal = 0.00D
    Private SelectedStudentID As String = ""

    Private Sub frmNewDocumentRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtRecordedBy.Text = LoggedInFullName
        DateTimePickerDate.Value = DateTime.Now

        NumericUpDownQuantity.Minimum = 1
        NumericUpDownQuantity.Value = 1

        SetupListView()
        LoadDocuments()
        SetupPredictiveSearch()
        GenerateNextRequestNo()
    End Sub

    Private Sub SetupListView()
        ListViewNewRequest.View = View.Details
        ListViewNewRequest.GridLines = True
        ListViewNewRequest.FullRowSelect = True
        ListViewNewRequest.Columns.Add("Doc ID", 0)
        ListViewNewRequest.Columns.Add("Document Name", 250)
        ListViewNewRequest.Columns.Add("Quantity", 80)
        ListViewNewRequest.Columns.Add("Fee", 100)
        ListViewNewRequest.Columns.Add("Subtotal", 100)
    End Sub

    Private Sub LoadDocuments()
        Try
            connection()
            sql = "SELECT DocumentID, DocumentName, Fee FROM tbldocuments WHERE Status = 'Active'"
            cmd = New MySqlCommand(sql, cn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            cboDocumentName.DataSource = dt
            cboDocumentName.DisplayMember = "DocumentName"
            cboDocumentName.ValueMember = "DocumentID"
            cboDocumentName.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading documents: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub SetupPredictiveSearch()
        Try
            connection()
            sql = "SELECT StudentID, LastName FROM tblstudents WHERE Status = 'Active'"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            Dim autoCompleteCollection As New AutoCompleteStringCollection()
            While dr.Read()
                autoCompleteCollection.Add(dr("StudentID").ToString())
                autoCompleteCollection.Add(dr("LastName").ToString())
            End While
            dr.Close()

            txtSearchStudentIdOrStudentLastName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSearchStudentIdOrStudentLastName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSearchStudentIdOrStudentLastName.AutoCompleteCustomSource = autoCompleteCollection
        Catch ex As Exception
            MessageBox.Show("Error loading predictive search: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub GenerateNextRequestNo()
        Try
            connection()
            sql = "SELECT RequestNo FROM tblrequest ORDER BY RequestID DESC LIMIT 1"
            cmd = New MySqlCommand(sql, cn)
            Dim lastRequestNo As Object = cmd.ExecuteScalar()

            If lastRequestNo IsNot Nothing AndAlso lastRequestNo IsNot DBNull.Value Then
                Dim lastNum As Integer = Convert.ToInt32(lastRequestNo.ToString().Split("-"c)(2))
                txtRequestNo.Text = $"REQ-{DateTime.Now.Year}-{ (lastNum + 1).ToString("D5") }"
            Else
                txtRequestNo.Text = $"REQ-{DateTime.Now.Year}-00001"
            End If
        Catch ex As Exception
            txtRequestNo.Text = $"REQ-{DateTime.Now.Year}-ERROR"
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub GenerateReceipt()
        Dim pd As New PrintDocument()
        ' Bind the PrintPage event to our custom drawing method
        AddHandler pd.PrintPage, AddressOf PrintReceiptPage

        Dim preview As New PrintPreviewDialog()
        preview.Document = pd
        preview.Width = 600
        preview.Height = 800
        preview.Text = "Receipt Preview"
        preview.ShowDialog()
    End Sub

    Private Sub PrintReceiptPage(sender As Object, e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim fontTitle As New Font("Courier New", 16, FontStyle.Bold)
        Dim fontHeader As New Font("Courier New", 12, FontStyle.Bold)
        Dim fontRegular As New Font("Courier New", 10)

        Dim startX As Integer = 50
        Dim startY As Integer = 50
        Dim offset As Integer = 25

        ' Header
        g.DrawString("OFFICIAL RECEIPT", fontTitle, Brushes.Black, startX + 100, startY)
        g.DrawString("Request No : " & txtRequestNo.Text, fontRegular, Brushes.Black, startX, startY + offset * 2)
        g.DrawString("Student ID : " & SelectedStudentID, fontRegular, Brushes.Black, startX, startY + offset * 3)
        g.DrawString("Name       : " & txtStudentName.Text, fontRegular, Brushes.Black, startX, startY + offset * 4)
        g.DrawString("Date       : " & DateTimePickerDate.Value.ToString("yyyy-MM-dd"), fontRegular, Brushes.Black, startX, startY + offset * 5)
        g.DrawString("Served By  : " & LoggedInFullName, fontRegular, Brushes.Black, startX, startY + offset * 6)

        ' Table Headers
        Dim yPos As Integer = startY + offset * 8
        g.DrawString("-------------------------------------------------------", fontRegular, Brushes.Black, startX, yPos)
        yPos += offset
        g.DrawString("DOCUMENT", fontHeader, Brushes.Black, startX, yPos)
        g.DrawString("QTY", fontHeader, Brushes.Black, startX + 250, yPos)
        g.DrawString("SUBTOTAL", fontHeader, Brushes.Black, startX + 350, yPos)
        yPos += offset
        g.DrawString("-------------------------------------------------------", fontRegular, Brushes.Black, startX, yPos)
        yPos += offset

        ' Items from ListView
        For Each item As ListViewItem In ListViewNewRequest.Items
            Dim docName As String = item.SubItems(1).Text
            ' Truncate long document names to fit the receipt
            If docName.Length > 25 Then docName = docName.Substring(0, 25) & "..."

            g.DrawString(docName, fontRegular, Brushes.Black, startX, yPos)
            g.DrawString(item.SubItems(2).Text, fontRegular, Brushes.Black, startX + 250, yPos)
            g.DrawString(item.SubItems(4).Text, fontRegular, Brushes.Black, startX + 350, yPos)
            yPos += offset
        Next

        ' Footer & Totals
        g.DrawString("-------------------------------------------------------", fontRegular, Brushes.Black, startX, yPos)
        yPos += offset
        g.DrawString("TOTAL AMOUNT: P " & txtTotalAmount.Text, fontHeader, Brushes.Black, startX + 180, yPos)

        yPos += offset * 3
        g.DrawString("Thank you for your request!", fontRegular, Brushes.Black, startX + 100, yPos)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrWhiteSpace(txtSearchStudentIdOrStudentLastName.Text) Then
            MessageBox.Show("Please enter a Student ID or Last Name.", "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            connection()
            sql = "SELECT StudentID, FirstName, MiddleName, LastName, Course, YearLevel FROM tblstudents WHERE (StudentID = @search OR LastName = @search) AND Status = 'Active' LIMIT 1"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@search", txtSearchStudentIdOrStudentLastName.Text.Trim())
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                SelectedStudentID = dr("StudentID").ToString()
                txtStudentName.Text = $"{dr("FirstName")} {dr("MiddleName")} {dr("LastName")}"
                txtCourse.Text = dr("Course").ToString()
                txtYear.Text = dr("YearLevel").ToString()
            Else
                MessageBox.Show("Student not found or inactive.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SelectedStudentID = ""
                txtStudentName.Text = "-"
                txtCourse.Text = "-"
                txtYear.Text = "-"
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching student: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing Then dr.Close()
            cn.Close()
        End Try
    End Sub

    Private Sub cboDocumentName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDocumentName.SelectedIndexChanged
        If cboDocumentName.SelectedIndex <> -1 AndAlso TypeOf cboDocumentName.SelectedItem Is DataRowView Then
            Dim row As DataRowView = DirectCast(cboDocumentName.SelectedItem, DataRowView)
            txtFee.Text = Convert.ToDecimal(row("Fee")).ToString("F2")
        Else
            txtFee.Text = "0.00"
        End If
    End Sub

    Private Sub btnAddRequest_Click(sender As Object, e As EventArgs) Handles btnAddRequest.Click

        If cboDocumentName.SelectedIndex = -1 Then
            MessageBox.Show("Please select a document.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If NumericUpDownQuantity.Value <= 0 Then
            MessageBox.Show("Quantity must be at least 1.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NumericUpDownQuantity.Value = 1
            Return
        End If

        Dim docId As Integer = Convert.ToInt32(cboDocumentName.SelectedValue)

        For Each existingItem As ListViewItem In ListViewNewRequest.Items
            If existingItem.Text = docId.ToString() Then
                MessageBox.Show($"{cboDocumentName.Text} is already in the list. Please remove it first if you want to change the quantity.", "Duplicate Document", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        Dim docName As String = cboDocumentName.Text
        Dim qty As Integer = Convert.ToInt32(NumericUpDownQuantity.Value)
        Dim fee As Decimal = Convert.ToDecimal(txtFee.Text)
        Dim subtotal As Decimal = qty * fee

        Dim item As New ListViewItem(docId.ToString())
        item.SubItems.Add(docName)
        item.SubItems.Add(qty.ToString())
        item.SubItems.Add(fee.ToString("F2"))
        item.SubItems.Add(subtotal.ToString("F2"))
        ListViewNewRequest.Items.Add(item)

        UpdateTotalAmount()

        cboDocumentName.SelectedIndex = -1
        NumericUpDownQuantity.Value = 1
    End Sub

    Private Sub UpdateTotalAmount()
        CurrentTotalAmount = 0
        For Each item As ListViewItem In ListViewNewRequest.Items
            CurrentTotalAmount += Convert.ToDecimal(item.SubItems(4).Text)
        Next
        txtTotalAmount.Text = CurrentTotalAmount.ToString("F2")
    End Sub

    Private Function AuthenticateAction(actionName As String) As Boolean
        Dim authForm As New Form() With {
            .Width = 350,
            .Height = 160,
            .Text = $"Confirm Action: {actionName}",
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .StartPosition = FormStartPosition.CenterParent,
            .MaximizeBox = False,
            .MinimizeBox = False
        }

        Dim lblPrompt As New Label() With {.Text = "Please enter your password to confirm this transaction:", .Left = 20, .Top = 20, .Width = 300}
        Dim txtPwd As New TextBox() With {.Left = 20, .Top = 50, .Width = 290, .UseSystemPasswordChar = True}
        Dim btnConfirm As New Button() With {.Text = "Confirm", .Left = 130, .Top = 80, .Width = 80, .DialogResult = DialogResult.OK}

        authForm.Controls.AddRange(New Control() {lblPrompt, txtPwd, btnConfirm})
        authForm.AcceptButton = btnConfirm

        If authForm.ShowDialog() = DialogResult.OK Then
            Dim isValid As Boolean = False
            Try
                connection()
                sql = "SELECT UserID FROM tblusers WHERE UserID = @uid AND Password = @pwd AND Status = 'Active'"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@uid", LoggedInUserID)
                cmd.Parameters.AddWithValue("@pwd", txtPwd.Text)
                dr = cmd.ExecuteReader()
                isValid = dr.Read()
            Catch ex As Exception
                MessageBox.Show("Authentication Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dr IsNot Nothing Then dr.Close()
                cn.Close()
            End Try

            If Not isValid Then MessageBox.Show("Invalid password. Action aborted.", "Security", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return isValid
        End If

        Return False
    End Function

    Private Sub WriteAuditLog(action As String, requestNo As String)
        Try
            Dim logEntry As String = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ACTION: {action} | REQUEST NO: {requestNo} | USER: {LoggedInFullName} (ID: {LoggedInUserID}){Environment.NewLine}"
            File.AppendAllText("audit_log.txt", logEntry)
        Catch ex As Exception
            MessageBox.Show("Failed to write to audit log: " & ex.Message, "Audit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnSaveRequest_Click(sender As Object, e As EventArgs) Handles btnSaveRequest.Click
        ' 1. Validate Student Selection
        If String.IsNullOrEmpty(SelectedStudentID) Then
            MessageBox.Show("Please search and select a valid student first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Validate Document List
        If ListViewNewRequest.Items.Count = 0 Then
            MessageBox.Show("Please add at least one document to the request.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 3. Validate Purpose 
        If String.IsNullOrWhiteSpace(txtPurpose.Text) Then
            MessageBox.Show("Please enter the purpose of the request.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPurpose.Focus()
            Return
        End If

        ' 4. Authenticate Action
        If Not AuthenticateAction("Save Request") Then Return

        Dim trans As MySqlTransaction = Nothing
        Try
            connection()
            trans = cn.BeginTransaction()

            ' Insert Parent Record (tblrequest)
            sql = "INSERT INTO tblrequest (RequestNo, StudentID, RequestDate, TotalAmount, PaymentStatus, Status, CreatedBy) " &
                  "VALUES (@reqNo, @studId, @reqDate, @total, 'Unpaid', 'Pending', @createdBy)"
            cmd = New MySqlCommand(sql, cn, trans)
            cmd.Parameters.AddWithValue("@reqNo", txtRequestNo.Text)
            cmd.Parameters.AddWithValue("@studId", SelectedStudentID)
            cmd.Parameters.AddWithValue("@reqDate", DateTimePickerDate.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@total", CurrentTotalAmount)
            cmd.Parameters.AddWithValue("@createdBy", LoggedInUserID)
            cmd.ExecuteNonQuery()

            Dim newRequestID As Integer = Convert.ToInt32(cmd.LastInsertedId)

            ' Insert Child Records (tblrequestdetails)
            For Each item As ListViewItem In ListViewNewRequest.Items
                sql = "INSERT INTO tblrequestdetails (RequestID, DocumentID, Quantity, Amount, Subtotal) " &
                      "VALUES (@reqID, @docID, @qty, @amt, @sub)"
                cmd = New MySqlCommand(sql, cn, trans)
                cmd.Parameters.AddWithValue("@reqID", newRequestID)
                cmd.Parameters.AddWithValue("@docID", Convert.ToInt32(item.SubItems(0).Text))
                cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(item.SubItems(2).Text))
                cmd.Parameters.AddWithValue("@amt", Convert.ToDecimal(item.SubItems(3).Text))
                cmd.Parameters.AddWithValue("@sub", Convert.ToDecimal(item.SubItems(4).Text))
                cmd.ExecuteNonQuery()
            Next

            trans.Commit()
            WriteAuditLog("SAVE_REQUEST", txtRequestNo.Text)

            MessageBox.Show("Request saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            GenerateReceipt()

            ' Reset Form for next request
            ListViewNewRequest.Items.Clear()
            txtTotalAmount.Text = "-"
            SelectedStudentID = ""
            txtStudentName.Text = "-"
            txtCourse.Text = "-"
            txtYear.Text = "-"
            txtSearchStudentIdOrStudentLastName.Clear()
            txtPurpose.Clear()
            GenerateNextRequestNo()

        Catch ex As Exception
            If trans IsNot Nothing Then trans.Rollback()
            MessageBox.Show("Transaction Failed. Changes rolled back. Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub btnCancelRequest_Click(sender As Object, e As EventArgs) Handles btnCancelRequest.Click
        If ListViewNewRequest.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select an item from the list to remove.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to remove the selected document(s) from this request?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            For Each item As ListViewItem In ListViewNewRequest.SelectedItems
                ListViewNewRequest.Items.Remove(item)
            Next

            UpdateTotalAmount()
        End If
    End Sub

End Class