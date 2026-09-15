Imports MySql.Data.MySqlClient

Public Class frmDocumentRequestList

    Private Sub frmDocumentRequestList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtMode.Text = "View Mode"
        btnEditSelectedRequest.Text = "Edit Request"

        CreateListViewHeaders()
        PopulateComboBoxes()
        LoadListViewData()

        ' Disable buttons initially until a sequence is selected
        btnViewRequestDetails.Enabled = False
        btnEditSelectedRequest.Enabled = False
        btnProcessPayment.Enabled = False

    End Sub

    Private Sub CreateListViewHeaders()
        ListViewRequestList.View = View.Details
        ListViewRequestList.GridLines = True
        ListViewRequestList.FullRowSelect = True

        ListViewRequestList.Columns.Clear()
        ListViewRequestList.Columns.Add("RequestDetailID", 0) ' Hidden ID
        ListViewRequestList.Columns.Add("Request No", 120)
        ListViewRequestList.Columns.Add("Student Name", 180)
        ListViewRequestList.Columns.Add("Document", 150)
        ListViewRequestList.Columns.Add("Quantity", 70)
        ListViewRequestList.Columns.Add("Fee/Amount", 100)
        ListViewRequestList.Columns.Add("Subtotal", 100)
        ListViewRequestList.Columns.Add("Status", 120)
    End Sub

    Private Sub PopulateComboBoxes()
        Try
            Call connection()

            ' Populate Status Filter
            cboStatusFilter.Items.Clear()
            cboStatusFilter.Items.Add("All")
            cboStatusFilter.Items.Add("Pending")
            cboStatusFilter.Items.Add("Processing")
            cboStatusFilter.Items.Add("Ready for Release")
            cboStatusFilter.Items.Add("Released")
            cboStatusFilter.Items.Add("Cancelled")

            ' Populate Request No
            cboSearchRequest.Items.Clear()
            cboSearchRequest.Items.Add("All")
            sql = "SELECT RequestNo FROM tblrequest"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cboSearchRequest.Items.Add(dr("RequestNo").ToString())
            End While
            dr.Close()

            ' Populate Student Full Name
            cboSearchStudent.Items.Clear()
            cboSearchStudent.Items.Add("All")
            sql = "SELECT CONCAT(LastName, ', ', FirstName, ' ', MiddleName) AS FullName FROM tblstudents"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cboSearchStudent.Items.Add(dr("FullName").ToString())
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading filters: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub LoadListViewData()
        Try
            Call connection()
            ListViewRequestList.Items.Clear()

            sql = "SELECT rd.RequestDetailID, r.RequestNo, CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) AS FullName, " &
                  "d.DocumentName, rd.Quantity, rd.Amount, rd.Subtotal, r.Status " &
                  "FROM tblrequestdetails rd " &
                  "INNER JOIN tblrequest r ON rd.RequestID = r.RequestID " &
                  "INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                  "INNER JOIN tbldocuments d ON rd.DocumentID = d.DocumentID WHERE 1=1"

            ' Apply Filters
            If cboSearchRequest.Text <> "" And cboSearchRequest.Text <> "All" Then
                sql &= " AND r.RequestNo = @reqNo"
            End If
            If cboSearchStudent.Text <> "" And cboSearchStudent.Text <> "All" Then
                sql &= " AND CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) = @studentName"
            End If
            If cboStatusFilter.Text <> "" And cboStatusFilter.Text <> "All" Then
                sql &= " AND r.Status = @status"
            End If

            cmd = New MySqlCommand(sql, cn)

            If cboSearchRequest.Text <> "" And cboSearchRequest.Text <> "All" Then
                cmd.Parameters.AddWithValue("@reqNo", cboSearchRequest.Text)
            End If
            If cboSearchStudent.Text <> "" And cboSearchStudent.Text <> "All" Then
                cmd.Parameters.AddWithValue("@studentName", cboSearchStudent.Text)
            End If
            If cboStatusFilter.Text <> "" And cboStatusFilter.Text <> "All" Then
                cmd.Parameters.AddWithValue("@status", cboStatusFilter.Text)
            End If

            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim lv As New ListViewItem(dr("RequestDetailID").ToString())
                lv.SubItems.Add(dr("RequestNo").ToString())
                lv.SubItems.Add(dr("FullName").ToString())
                lv.SubItems.Add(dr("DocumentName").ToString())
                lv.SubItems.Add(dr("Quantity").ToString())
                lv.SubItems.Add(dr("Amount").ToString())
                lv.SubItems.Add(dr("Subtotal").ToString())
                lv.SubItems.Add(dr("Status").ToString())
                ListViewRequestList.Items.Add(lv)
            End While

        Catch ex As Exception
            MessageBox.Show("Error loading list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub cboSearchRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearchRequest.SelectedIndexChanged

        If cboSearchRequest.Text <> "All" And cboSearchRequest.Text <> "" Then
            Try
                Call connection()
                sql = "SELECT CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) AS FullName FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID WHERE r.RequestNo = @reqNo"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@reqNo", cboSearchRequest.Text)
                dr = cmd.ExecuteReader()
                While dr.Read()
                    RemoveHandler cboSearchStudent.SelectedIndexChanged, AddressOf cboSearchStudent_SelectedIndexChanged
                    cboSearchStudent.Text = dr("FullName").ToString()
                    AddHandler cboSearchStudent.SelectedIndexChanged, AddressOf cboSearchStudent_SelectedIndexChanged
                End While
            Catch ex As Exception
            Finally
                cn.Close()
            End Try
        End If
        LoadListViewData()

    End Sub

    Private Sub cboSearchStudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearchStudent.SelectedIndexChanged

        If cboSearchStudent.Text <> "All" And cboSearchStudent.Text <> "" Then
            Try
                Call connection()
                sql = "SELECT r.RequestNo FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID WHERE CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) = @studentName LIMIT 1"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@studentName", cboSearchStudent.Text)
                dr = cmd.ExecuteReader()
                While dr.Read()
                    RemoveHandler cboSearchRequest.SelectedIndexChanged, AddressOf cboSearchRequest_SelectedIndexChanged
                    cboSearchRequest.Text = dr("RequestNo").ToString()
                    AddHandler cboSearchRequest.SelectedIndexChanged, AddressOf cboSearchRequest_SelectedIndexChanged
                End While
            Catch ex As Exception
            Finally
                cn.Close()
            End Try
        End If
        LoadListViewData()

    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged

        LoadListViewData()

    End Sub

    Private Sub btnClearAllSearch_Click(sender As Object, e As EventArgs) Handles btnClearAllSearch.Click

        cboSearchRequest.SelectedIndex = -1
        cboSearchStudent.SelectedIndex = -1
        cboStatusFilter.SelectedIndex = -1
        cboSearchRequest.Text = ""
        cboSearchStudent.Text = ""
        cboStatusFilter.Text = ""
        txtMode.Text = "View Mode"
        btnEditSelectedRequest.Text = "Edit Request"
        LoadListViewData()

    End Sub

    Private Sub ListViewRequestList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewRequestList.SelectedIndexChanged

        If ListViewRequestList.SelectedItems.Count > 0 Then
            btnViewRequestDetails.Enabled = True
            btnEditSelectedRequest.Enabled = True

            ' Only enable payment processing if status is Pending
            If ListViewRequestList.SelectedItems(0).SubItems(7).Text = "Pending" Then
                btnProcessPayment.Enabled = True
            Else
                btnProcessPayment.Enabled = False
            End If
        Else
            btnViewRequestDetails.Enabled = False
            btnEditSelectedRequest.Enabled = False
            btnProcessPayment.Enabled = False
        End If

    End Sub

    Private Sub ListViewRequestList_DoubleClick(sender As Object, e As EventArgs) Handles ListViewRequestList.DoubleClick
        ' Clickable editing of quantity when in edit mode
        If txtMode.Text = "Edit Mode" And ListViewRequestList.SelectedItems.Count > 0 Then
            Dim currentQty As String = ListViewRequestList.SelectedItems(0).SubItems(4).Text
            Dim newQtyStr As String = InputBox("Enter new quantity:", "Edit Quantity", currentQty)

            If newQtyStr <> "" AndAlso IsNumeric(newQtyStr) Then
                Dim newQty As Integer = Convert.ToInt32(newQtyStr)
                If newQty > 0 Then
                    Dim fee As Decimal = Convert.ToDecimal(ListViewRequestList.SelectedItems(0).SubItems(5).Text)
                    Dim newSubtotal As Decimal = newQty * fee

                    ' Update UI
                    ListViewRequestList.SelectedItems(0).SubItems(4).Text = newQty.ToString()
                    ListViewRequestList.SelectedItems(0).SubItems(6).Text = newSubtotal.ToString("F2")
                Else
                    MessageBox.Show("Quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub btnViewRequestDetails_Click(sender As Object, e As EventArgs) Handles btnViewRequestDetails.Click

        If ListViewRequestList.SelectedItems.Count > 0 Then
            Dim details As String = "Request No: " & ListViewRequestList.SelectedItems(0).SubItems(1).Text & vbCrLf &
                                    "Student: " & ListViewRequestList.SelectedItems(0).SubItems(2).Text & vbCrLf &
                                    "Document: " & ListViewRequestList.SelectedItems(0).SubItems(3).Text & vbCrLf &
                                    "Quantity: " & ListViewRequestList.SelectedItems(0).SubItems(4).Text & vbCrLf &
                                    "Amount: PHP " & ListViewRequestList.SelectedItems(0).SubItems(5).Text & vbCrLf &
                                    "Subtotal: PHP " & ListViewRequestList.SelectedItems(0).SubItems(6).Text & vbCrLf &
                                    "Status: " & ListViewRequestList.SelectedItems(0).SubItems(7).Text
            MessageBox.Show(details, "Request Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnEditSelectedRequest_Click(sender As Object, e As EventArgs) Handles btnEditSelectedRequest.Click

        If btnEditSelectedRequest.Text = "Edit Request" Then
            txtMode.Text = "Edit Mode"
            btnEditSelectedRequest.Text = "Save Request"
            MessageBox.Show("Double-click a record in the list to edit its quantity.", "Edit Mode Activated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf btnEditSelectedRequest.Text = "Save Request" Then
            Dim confirm As DialogResult = MessageBox.Show("Save changes to the database?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirm = DialogResult.Yes Then
                Try
                    Call connection()
                    ' Using transaction for safe rollback
                    Dim trans As MySqlTransaction = cn.BeginTransaction()
                    Try
                        cmd = New MySqlCommand()
                        cmd.Connection = cn
                        cmd.Transaction = trans

                        ' Save changes for selected item (or loop through all items if multi-edit is supported)
                        If ListViewRequestList.SelectedItems.Count > 0 Then
                            sql = "UPDATE tblrequestdetails SET Quantity = @qty, Subtotal = @sub WHERE RequestDetailID = @id"
                            cmd.CommandText = sql
                            cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(ListViewRequestList.SelectedItems(0).SubItems(4).Text))
                            cmd.Parameters.AddWithValue("@sub", Convert.ToDecimal(ListViewRequestList.SelectedItems(0).SubItems(6).Text))
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(ListViewRequestList.SelectedItems(0).Text))
                            cmd.ExecuteNonQuery()
                        End If

                        trans.Commit()
                        MessageBox.Show("Request updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch exTrans As Exception
                        trans.Rollback()
                        MessageBox.Show("Transaction failed and was rolled back: " & exTrans.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    cn.Close()
                End Try
            End If

            txtMode.Text = "View Mode"
            btnEditSelectedRequest.Text = "Edit Request"
            LoadListViewData()
        End If

    End Sub

    Private Sub btnProcessPayment_Click(sender As Object, e As EventArgs) Handles btnProcessPayment.Click

        If ListViewRequestList.SelectedItems.Count > 0 Then
            Dim reqNo As String = ListViewRequestList.SelectedItems(0).SubItems(1).Text
            Dim confirm As DialogResult = MessageBox.Show("Process payment for Request " & reqNo & "? This will change status to Processing.", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirm = DialogResult.Yes Then
                Try
                    Call connection()
                    sql = "UPDATE tblrequest SET Status = 'Processing', PaymentStatus = 'Paid' WHERE RequestNo = @reqNo"
                    cmd = New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@reqNo", reqNo)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Payment processed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadListViewData()
                Catch ex As Exception
                    MessageBox.Show("Error processing payment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    cn.Close()
                End Try
            End If
        End If

    End Sub
End Class