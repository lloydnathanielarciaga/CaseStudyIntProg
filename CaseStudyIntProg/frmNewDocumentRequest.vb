Imports MySql.Data.MySqlClient

Public Class frmNewDocumentRequest
    Private Sub frmNewDocumentRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call SetupListView()
        Call LoadProcessedBy()
        Call LoadStudents()
        Call LoadDocuments()
        Call GenerateRequestNo()
        Call ResetInputFields()

    End Sub

    ' Step 4: Setup ListView Columns
    Private Sub SetupListView()
        ListViewNewRequest.View = View.Details
        ListViewNewRequest.FullRowSelect = True
        ListViewNewRequest.GridLines = True
        ListViewNewRequest.Columns.Clear()

        ListViewNewRequest.Columns.Add("Document ID", 90)
        ListViewNewRequest.Columns.Add("Document Name", 180)
        ListViewNewRequest.Columns.Add("Quantity", 70)
        ListViewNewRequest.Columns.Add("Fee", 80)
        ListViewNewRequest.Columns.Add("Subtotal", 90)
        ListViewNewRequest.Columns.Add("Student ID", 100)
        ListViewNewRequest.Columns.Add("Student Full Name", 180)
        ListViewNewRequest.Columns.Add("Payment Status", 110)
        ListViewNewRequest.Columns.Add("OR No", 90)
        ListViewNewRequest.Columns.Add("OR Date", 90)
        ListViewNewRequest.Columns.Add("Status", 100)
    End Sub

    ' Step 3: Automatically generate Request No (Format: REQ-YYYY-XXXXX)
    Private Sub GenerateRequestNo()
        Try
            Call connection()
            sql = "SELECT RequestID FROM tblrequest ORDER BY RequestID DESC LIMIT 1"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            Dim nextId As Integer = 1
            While dr.Read()
                nextId = Convert.ToInt32(dr("RequestID")) + 1
            End While
            dr.Close()

            txtRequestNo.Text = "REQ-" & DateTimePickerDate.Value.Year.ToString() & "-" & nextId.ToString("D5")
        Catch ex As Exception
            MessageBox.Show("Error generating Request Number: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    ' Step 2: Load Registrar Staff into cboProcessedBy
    Private Sub LoadProcessedBy()
        Try
            cboProcessedBy.Items.Clear()
            Call connection()
            sql = "SELECT FullName FROM tblusers WHERE Role = 'Registrar Staff' AND Status = 'Active'"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                cboProcessedBy.Items.Add(dr("FullName").ToString())
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading staff: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    ' Step 2: Load Student IDs and Full Names
    Private Sub LoadStudents()
        Try
            cboStudentId.Items.Clear()
            cboStudentName.Items.Clear()
            Call connection()
            sql = "SELECT StudentID, LastName, FirstName, MiddleName FROM tblstudents WHERE Status = 'Active'"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                cboStudentId.Items.Add(dr("StudentID").ToString())
                Dim fullName As String = dr("LastName").ToString() & ", " & dr("FirstName").ToString() & " " & dr("MiddleName").ToString()
                cboStudentName.Items.Add(fullName)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading students: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    ' Step 2: Load Active Documents
    Private Sub LoadDocuments()
        Try
            cboDocumentName.Items.Clear()
            Call connection()
            sql = "SELECT DocumentName FROM tbldocuments WHERE Status = 'Active'"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                cboDocumentName.Items.Add(dr("DocumentName").ToString())
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading documents: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub cboStudentId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStudentId.SelectedIndexChanged

        If cboStudentId.SelectedIndex = -1 Then Exit Sub

        Try
            Call connection()
            sql = "SELECT LastName, FirstName, MiddleName, Course, YearLevel FROM tblstudents WHERE StudentID = @StudentID"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@StudentID", cboStudentId.Text)
            dr = cmd.ExecuteReader()

            While dr.Read()
                cboStudentName.Text = dr("LastName").ToString() & ", " & dr("FirstName").ToString() & " " & dr("MiddleName").ToString()
                txtCourse.Text = dr("Course").ToString()
                txtYear.Text = dr("YearLevel").ToString()
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error retrieving student details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub cboStudentName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStudentName.SelectedIndexChanged

        If cboStudentName.SelectedIndex = -1 Then Exit Sub
        cboStudentId.SelectedIndex = cboStudentName.SelectedIndex

    End Sub

    Private Sub UpdateFeeCalculation()
        If cboDocumentName.SelectedIndex = -1 Then
            txtFee.Text = "0.00"
            Exit Sub
        End If

        Try
            Call connection()
            sql = "SELECT Fee FROM tbldocuments WHERE DocumentName = @DocName"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@DocName", cboDocumentName.Text)
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim originalFee As Decimal = Convert.ToDecimal(dr("Fee"))
                Dim totalFee As Decimal = originalFee * NumericUpDownQuantity.Value
                txtFee.Text = totalFee.ToString("0.00")
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error calculating fee: " & ex.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub cboDocumentName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDocumentName.SelectedIndexChanged

        Call UpdateFeeCalculation()

    End Sub

    Private Sub NumericUpDownQuantity_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownQuantity.ValueChanged

        Call UpdateFeeCalculation()

    End Sub

    Private Sub btnAddRequest_Click(sender As Object, e As EventArgs) Handles btnAddRequest.Click

        ' Validations
        If cboStudentId.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Student ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboStudentId.Focus()
            Exit Sub
        End If

        If cboDocumentName.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Document.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDocumentName.Focus()
            Exit Sub
        End If

        If NumericUpDownQuantity.Value <= 0 Then
            MessageBox.Show("Quantity must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NumericUpDownQuantity.Focus()
            Exit Sub
        End If

        ' Prevent duplicate items in ListView
        For Each item As ListViewItem In ListViewNewRequest.Items
            If item.SubItems(1).Text = cboDocumentName.Text Then
                MessageBox.Show("This document is already added to the request list.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next

        ' Fetch Document ID and Base Fee for entry
        Dim docID As String = ""
        Dim baseFee As Decimal = 0.00

        Try
            Call connection()
            sql = "SELECT DocumentID, Fee FROM tbldocuments WHERE DocumentName = @DocName"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@DocName", cboDocumentName.Text)
            dr = cmd.ExecuteReader()

            While dr.Read()
                docID = dr("DocumentID").ToString()
                baseFee = Convert.ToDecimal(dr("Fee"))
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error fetching document info: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try

        ' Step 6: Create Item with hardcoded initial values (Unpaid, N/A, N/A, Pending)
        Dim subtotal As Decimal = Convert.ToDecimal(txtFee.Text)
        Dim newItem As New ListViewItem(docID)
        newItem.SubItems.Add(cboDocumentName.Text)
        newItem.SubItems.Add(NumericUpDownQuantity.Value.ToString())
        newItem.SubItems.Add(baseFee.ToString("0.00"))
        newItem.SubItems.Add(subtotal.ToString("0.00"))
        newItem.SubItems.Add(cboStudentId.Text)
        newItem.SubItems.Add(cboStudentName.Text)
        newItem.SubItems.Add("Unpaid")
        newItem.SubItems.Add("N/A")
        newItem.SubItems.Add("N/A")
        newItem.SubItems.Add("Pending")

        ListViewNewRequest.Items.Add(newItem)

        ' Lock Student selection once request items are added
        cboStudentId.Enabled = False
        cboStudentName.Enabled = False

        ' Step 7: Update Total Amount & Enable Save Button
        Call CalculateTotalAmount()
        btnSaveRequest.Enabled = True

        ' Reset item input controls
        cboDocumentName.SelectedIndex = -1
        NumericUpDownQuantity.Value = 1
        txtFee.Text = "0.00"

    End Sub

    ' Step 7: Calculate Total Amount from ListView
    Private Sub CalculateTotalAmount()
        Dim total As Decimal = 0.00
        For Each item As ListViewItem In ListViewNewRequest.Items
            total = total + Convert.ToDecimal(item.SubItems(4).Text)
        Next
        txtTotalAmount.Text = total.ToString("0.00")
    End Sub

    ' Helper to fetch UserID of selected Registrar Staff
    Private Function GetProcessedByUserID() As Integer
        Dim userID As Integer = 0
        Try
            Call connection()
            sql = "SELECT UserID FROM tblusers WHERE FullName = @FullName AND Role = 'Registrar Staff'"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@FullName", cboProcessedBy.Text)
            dr = cmd.ExecuteReader()

            While dr.Read()
                userID = Convert.ToInt32(dr("UserID"))
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error resolving staff ID: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
        Return userID
    End Function

    ' Step 8: Save Request to Database with Validations & Transaction Rollback
    Private Sub btnSaveRequest_Click(sender As Object, e As EventArgs) Handles btnSaveRequest.Click

        ' Validation checks
        If cboProcessedBy.SelectedIndex = -1 Then
            MessageBox.Show("Please select the Registrar Staff processing this request.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProcessedBy.Focus()
            Exit Sub
        End If

        If ListViewNewRequest.Items.Count = 0 Then
            MessageBox.Show("No request items added to the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to save this document request?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.No Then Exit Sub

        Dim staffID As Integer = GetProcessedByUserID()
        If staffID = 0 Then
            MessageBox.Show("Invalid staff processing selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Call connection()
        Dim transaction As MySqlTransaction = cn.BeginTransaction()

        Try
            ' Insert into tblrequest
            sql = "INSERT INTO tblrequest (RequestNo, StudentID, RequestDate, TotalAmount, PaymentStatus, ORNo, ORDate, Status, CreatedBy) " &
                  "VALUES (@RequestNo, @StudentID, @RequestDate, @TotalAmount, 'Unpaid', NULL, NULL, 'Pending', @CreatedBy)"

            cmd = New MySqlCommand(sql, cn, transaction)
            cmd.Parameters.AddWithValue("@RequestNo", txtRequestNo.Text)
            cmd.Parameters.AddWithValue("@StudentID", cboStudentId.Text)
            cmd.Parameters.AddWithValue("@RequestDate", DateTimePickerDate.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(txtTotalAmount.Text))
            cmd.Parameters.AddWithValue("@CreatedBy", staffID)
            cmd.ExecuteNonQuery()

            ' Fetch auto-generated RequestID
            sql = "SELECT LAST_INSERT_ID()"
            cmd = New MySqlCommand(sql, cn, transaction)
            Dim insertedRequestID As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            ' Insert details into tblrequestdetails
            For Each item As ListViewItem In ListViewNewRequest.Items
                sql = "INSERT INTO tblrequestdetails (RequestID, DocumentID, Quantity, Amount, Subtotal) " &
                      "VALUES (@RequestID, @DocumentID, @Quantity, @Amount, @Subtotal)"

                cmd = New MySqlCommand(sql, cn, transaction)
                cmd.Parameters.AddWithValue("@RequestID", insertedRequestID)
                cmd.Parameters.AddWithValue("@DocumentID", Convert.ToInt32(item.Text))
                cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(item.SubItems(2).Text))
                cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(item.SubItems(3).Text))
                cmd.Parameters.AddWithValue("@Subtotal", Convert.ToDecimal(item.SubItems(4).Text))
                cmd.ExecuteNonQuery()
            Next

            ' Commit transaction on success
            transaction.Commit()
            MessageBox.Show("Document Request " & txtRequestNo.Text & " saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reset Form State
            Call btnCancelRequest_Click(sender, e)

        Catch ex As Exception
            ' Step 8: Rollback transaction if error occurs
            transaction.Rollback()
            MessageBox.Show("Failed to save request. All changes have been rolled back." & vbCrLf & "Error: " & ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try

    End Sub

    ' Step 9: Reset all user inputs and clear data
    Private Sub btnCancelRequest_Click(sender As Object, e As EventArgs) Handles btnCancelRequest.Click

        Call ResetInputFields()
        Call GenerateRequestNo()

    End Sub

    Private Sub ResetInputFields()
        cboProcessedBy.SelectedIndex = -1
        cboStudentId.Enabled = True
        cboStudentName.Enabled = True
        cboStudentId.SelectedIndex = -1
        cboStudentName.SelectedIndex = -1
        txtCourse.Text = ""
        txtYear.Text = ""
        cboDocumentName.SelectedIndex = -1
        NumericUpDownQuantity.Value = 1
        txtFee.Text = "0.00"
        txtTotalAmount.Text = "0.00"
        ListViewNewRequest.Items.Clear()
        btnSaveRequest.Enabled = False
        DateTimePickerDate.Value = DateTime.Now
    End Sub

End Class