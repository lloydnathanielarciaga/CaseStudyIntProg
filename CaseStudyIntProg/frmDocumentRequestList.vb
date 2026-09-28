Imports MySql.Data.MySqlClient

Public Class frmDocumentRequestList

    Private Sub frmDocumentRequestList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewRequestList.View = View.Details
        ListViewRequestList.FullRowSelect = True
        ListViewRequestList.GridLines = True
        ListViewRequestList.MultiSelect = False

        ListViewRequestList.Columns.Add("Request No.", 120)
        ListViewRequestList.Columns.Add("Student Name", 180)
        ListViewRequestList.Columns.Add("Document", 150)
        ListViewRequestList.Columns.Add("Quantity", 80)
        ListViewRequestList.Columns.Add("Amount", 80)
        ListViewRequestList.Columns.Add("Subtotal", 100)
        ListViewRequestList.Columns.Add("Status", 120)
        ListViewRequestList.Columns.Add("RequestDetailID", 0)
        ListViewRequestList.Columns.Add("RequestID", 0)

        btnViewRequestDetails.Enabled = False
        btnEditSelectedRequest.Enabled = False
        btnProcessPayment.Enabled = False

        LoadComboBoxes()
        LoadListViewData()
    End Sub

    Private Sub LoadComboBoxes()
        Try
            Call connection()

            cboSearchRequest.Items.Clear()
            sql = "SELECT RequestNo FROM tblrequest"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cboSearchRequest.Items.Add(dr("RequestNo").ToString())
            End While
            dr.Close()

            cboSearchStudent.Items.Clear()
            sql = "SELECT CONCAT(LastName, ', ', FirstName, ' ', MiddleName) AS FullName FROM tblstudents"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cboSearchStudent.Items.Add(dr("FullName").ToString())
            End While
            dr.Close()

            cboStatusFilter.Items.Clear()
            cboStatusFilter.Items.Add("Pending")
            cboStatusFilter.Items.Add("Processing")
            cboStatusFilter.Items.Add("Ready for Release")
            cboStatusFilter.Items.Add("Released")
            cboStatusFilter.Items.Add("Cancelled")

        Catch ex As Exception
            MsgBox("Error loading dropdown data: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub LoadListViewData()
        ListViewRequestList.Items.Clear()
        Try
            Call connection()

            sql = "SELECT r.RequestNo, CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) AS StudentName, d.DocumentName, rd.Quantity, rd.Amount, rd.Subtotal, r.Status, rd.RequestDetailID, r.RequestID " &
                  "FROM tblrequest r " &
                  "JOIN tblstudents s ON r.StudentID = s.StudentID " &
                  "JOIN tblrequestdetails rd ON r.RequestID = rd.RequestID " &
                  "JOIN tbldocuments d ON rd.DocumentID = d.DocumentID " &
                  "WHERE 1=1 "

            If cboSearchRequest.Text <> "" Then
                sql = sql & " AND r.RequestNo = @reqNo"
            End If

            If cboSearchStudent.Text <> "" Then
                sql = sql & " AND CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) = @student"
            End If

            If cboStatusFilter.Text <> "" Then
                sql = sql & " AND r.Status = @status"
            End If

            cmd = New MySqlCommand(sql, cn)

            If cboSearchRequest.Text <> "" Then
                cmd.Parameters.AddWithValue("@reqNo", cboSearchRequest.Text)
            End If

            If cboSearchStudent.Text <> "" Then
                cmd.Parameters.AddWithValue("@student", cboSearchStudent.Text)
            End If

            If cboStatusFilter.Text <> "" Then
                cmd.Parameters.AddWithValue("@status", cboStatusFilter.Text)
            End If

            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim item As New ListViewItem(dr("RequestNo").ToString())
                item.SubItems.Add(dr("StudentName").ToString())
                item.SubItems.Add(dr("DocumentName").ToString())
                item.SubItems.Add(dr("Quantity").ToString())
                item.SubItems.Add(dr("Amount").ToString())
                item.SubItems.Add(dr("Subtotal").ToString())
                item.SubItems.Add(dr("Status").ToString())
                item.SubItems.Add(dr("RequestDetailID").ToString())
                item.SubItems.Add(dr("RequestID").ToString())
                ListViewRequestList.Items.Add(item)
            End While

        Catch ex As Exception
            MsgBox("Error loading list: " & ex.Message, MsgBoxStyle.Critical, "System Error")
        Finally
            If dr IsNot Nothing Then dr.Close()
            cn.Close()
        End Try
    End Sub

    Private Sub cboSearchRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearchRequest.SelectedIndexChanged

        If cboSearchRequest.Text <> "" Then

            RemoveHandler cboSearchStudent.SelectedIndexChanged, AddressOf cboSearchStudent_SelectedIndexChanged

            Try
                Call connection()

                sql = "SELECT CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) AS StudentName FROM tblrequest r JOIN tblstudents s ON r.StudentID = s.StudentID WHERE r.RequestNo = @req"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@req", cboSearchRequest.Text)
                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    cboSearchStudent.Text = dr("StudentName").ToString()
                End If

            Catch ex As Exception
                MsgBox("Filter error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Finally
                If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
                cn.Close()
            End Try

            AddHandler cboSearchStudent.SelectedIndexChanged, AddressOf cboSearchStudent_SelectedIndexChanged
        End If

        LoadListViewData()

    End Sub

    Private Sub cboSearchStudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearchStudent.SelectedIndexChanged

        If cboSearchStudent.Text <> "" Then

            RemoveHandler cboSearchRequest.SelectedIndexChanged, AddressOf cboSearchRequest_SelectedIndexChanged

            cboSearchRequest.SelectedIndex = -1
            cboSearchRequest.Text = ""

            Try
                Call connection()

                sql = "SELECT r.RequestNo FROM tblrequest r JOIN tblstudents s ON r.StudentID = s.StudentID WHERE CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) = @student"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@student", cboSearchStudent.Text)
                dr = cmd.ExecuteReader()

                cboSearchRequest.Items.Clear()
                While dr.Read()
                    cboSearchRequest.Items.Add(dr("RequestNo").ToString())
                End While

            Catch ex As Exception
                MsgBox("Filter error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Finally
                If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
                cn.Close()
            End Try

            AddHandler cboSearchRequest.SelectedIndexChanged, AddressOf cboSearchRequest_SelectedIndexChanged
        End If

        LoadListViewData()

    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged

        LoadListViewData()

    End Sub

    Private Sub btnClearAllSearch_Click(sender As Object, e As EventArgs) Handles btnClearAllSearch.Click

        cboSearchRequest.SelectedIndex = -1
        cboSearchRequest.Text = ""
        cboSearchStudent.SelectedIndex = -1
        cboSearchStudent.Text = ""
        cboStatusFilter.SelectedIndex = -1
        cboStatusFilter.Text = ""
        txtMode.Text = "Normal Mode"
        btnEditSelectedRequest.Text = "Edit Request"

        LoadComboBoxes()

        LoadListViewData()

    End Sub

    Private Sub btnViewRequestDetails_Click(sender As Object, e As EventArgs) Handles btnViewRequestDetails.Click
        If ListViewRequestList.SelectedItems.Count > 0 Then
            Dim detailsForm As New frmRequestDetails(ListViewRequestList.SelectedItems(0), False)
            detailsForm.ShowDialog()
        End If
    End Sub

    Private Sub btnProcessPayment_Click(sender As Object, e As EventArgs) Handles btnProcessPayment.Click

        If ListViewRequestList.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListViewRequestList.SelectedItems(0)
            Dim currentStatus As String = selectedItem.SubItems(6).Text

            If currentStatus = "Pending" Then
                Dim confirmation As MsgBoxResult = MsgBox("Are you sure you want to process payment for this request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Payment")

                If confirmation = MsgBoxResult.Yes Then
                    Try
                        Call connection()
                        sql = "UPDATE tblrequest SET Status = 'Processing' WHERE RequestNo = @reqNo"
                        cmd = New MySqlCommand(sql, cn)
                        cmd.Parameters.AddWithValue("@reqNo", selectedItem.SubItems(0).Text)
                        cmd.ExecuteNonQuery()

                        MsgBox("Payment successfully processed. Status is now Processing.", MsgBoxStyle.Information, "Success")
                    Catch ex As Exception
                        MsgBox("Database error during payment: " & ex.Message, MsgBoxStyle.Critical, "Failed")
                    Finally
                        cn.Close()
                    End Try

                    LoadListViewData()
                End If
            Else
                MsgBox("Only 'Pending' requests can be processed for payment.", MsgBoxStyle.Exclamation, "Invalid Operation")
            End If
        Else
            MsgBox("Please select a record from the list first.", MsgBoxStyle.Exclamation, "No Selection")
        End If

    End Sub

    Private Sub btnEditSelectedRequest_Click(sender As Object, e As EventArgs) Handles btnEditSelectedRequest.Click
        If ListViewRequestList.SelectedItems.Count > 0 Then
            Dim detailsForm As New frmRequestDetails(ListViewRequestList.SelectedItems(0), True)
            If detailsForm.ShowDialog() = DialogResult.OK Then
                LoadListViewData()
            End If
        End If
    End Sub

    Private Sub ListViewRequestList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewRequestList.MouseDoubleClick

        If txtMode.Text = "Edit Mode" Then
            If ListViewRequestList.SelectedItems.Count > 0 Then
                Dim info As ListViewHitTestInfo = ListViewRequestList.HitTest(e.X, e.Y)

                If info.Item IsNot Nothing AndAlso info.SubItem IsNot Nothing Then
                    Dim colIndex As Integer = info.Item.SubItems.IndexOf(info.SubItem)

                    If colIndex = 3 Then
                        Dim userInput As String = InputBox("Enter the new Quantity:", "Edit Quantity", info.SubItem.Text)

                        If IsNumeric(userInput) Then
                            If CInt(userInput) > 0 Then
                                info.SubItem.Text = userInput

                                Dim amount As Decimal = CDec(info.Item.SubItems(4).Text)
                                Dim quantity As Integer = CInt(userInput)
                                Dim newSubtotal As Decimal = amount * quantity
                                info.Item.SubItems(5).Text = newSubtotal.ToString("0.00")
                            Else
                                MsgBox("Quantity must be 1 or higher.", MsgBoxStyle.Exclamation, "Validation Error")
                            End If
                        ElseIf userInput <> "" Then
                            MsgBox("Please enter valid numbers only.", MsgBoxStyle.Exclamation, "Validation Error")
                        End If

                    ElseIf colIndex = 6 Then
                        Dim currentStatus As String = info.SubItem.Text.Trim()

                        Dim userInput As String = InputBox("Enter new Status:" & vbCrLf & "(Pending, Processing, Ready for Release, Released, Cancelled)", "Edit Status", currentStatus)

                        Dim formattedInput As String = userInput.Trim().ToUpper()

                        Select Case formattedInput
                            Case "PENDING"
                                info.SubItem.Text = "Pending"
                            Case "PROCESSING"
                                info.SubItem.Text = "Processing"
                            Case "READY FOR RELEASE"
                                info.SubItem.Text = "Ready for Release"
                            Case "RELEASED"
                                info.SubItem.Text = "Released"
                            Case "CANCELLED"
                                info.SubItem.Text = "Cancelled"
                            Case ""
                            Case Else
                                MsgBox("Invalid entry. Please type exactly one of the permitted options.", MsgBoxStyle.Exclamation, "Validation Error")
                        End Select
                    Else
                        MsgBox("You are only permitted to edit the Quantity or Status columns.", MsgBoxStyle.Exclamation, "Restricted")
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub ListViewRequestList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewRequestList.SelectedIndexChanged
        Dim hasSelection As Boolean = (ListViewRequestList.SelectedItems.Count > 0)
        btnViewRequestDetails.Enabled = hasSelection
        btnEditSelectedRequest.Enabled = hasSelection
        btnProcessPayment.Enabled = hasSelection
    End Sub



End Class