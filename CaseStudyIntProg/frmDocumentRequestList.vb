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
        ListViewRequestList.Columns.Add("RequestDetailID", 0) ' Hidden Column for database updates
        ListViewRequestList.Columns.Add("RequestID", 0) ' Hidden Column for database updates

        txtMode.Text = "Normal Mode"
        btnEditSelectedRequest.Text = "Edit Request"

        LoadComboBoxes()
        LoadListViewData()

    End Sub

    Private Sub LoadComboBoxes()
        Try
            Call connection()

            ' Load all Request Numbers
            cboSearchRequest.Items.Clear()
            sql = "SELECT RequestNo FROM tblrequest"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cboSearchRequest.Items.Add(dr("RequestNo").ToString())
            End While
            dr.Close()

            ' Load all Student Full Names
            cboSearchStudent.Items.Clear()
            sql = "SELECT CONCAT(LastName, ', ', FirstName, ' ', MiddleName) AS FullName FROM tblstudents"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cboSearchStudent.Items.Add(dr("FullName").ToString())
            End While
            dr.Close()

            ' Load Neutral Status Filters
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

            ' Build Dynamic Query based on active combobox filters
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

            ' Parameter assignment
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

            ' Populate Data
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

            ' 1. Temporarily detach the Student event to prevent cascade
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

            ' 2. Reattach the Student event handler
            AddHandler cboSearchStudent.SelectedIndexChanged, AddressOf cboSearchStudent_SelectedIndexChanged
        End If

        LoadListViewData()

    End Sub

    Private Sub cboSearchStudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearchStudent.SelectedIndexChanged

        If cboSearchStudent.Text <> "" Then

            ' 1. Temporarily detach the other ComboBox's event to prevent an event cascade 
            ' that prematurely closes our shared database connection.
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
                ' Ensure the DataReader is properly closed before closing the connection
                If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
                cn.Close()
            End Try

            ' 2. Reattach the event handler now that the database operations are safely done
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
            Dim selectedItem As ListViewItem = ListViewRequestList.SelectedItems(0)
            Dim details As String = "Request No: " & selectedItem.SubItems(0).Text & vbCrLf &
                                    "Student Name: " & selectedItem.SubItems(1).Text & vbCrLf &
                                    "Document: " & selectedItem.SubItems(2).Text & vbCrLf &
                                    "Quantity: " & selectedItem.SubItems(3).Text & vbCrLf &
                                    "Amount: ₱" & selectedItem.SubItems(4).Text & vbCrLf &
                                    "Subtotal: ₱" & selectedItem.SubItems(5).Text & vbCrLf &
                                    "Status: " & selectedItem.SubItems(6).Text

            MsgBox(details, MsgBoxStyle.Information, "Detailed Request Information")
        Else
            MsgBox("Please select a record from the list to view.", MsgBoxStyle.Exclamation, "No Selection")
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

        If btnEditSelectedRequest.Text = "Edit Request" Then
            If ListViewRequestList.SelectedItems.Count > 0 Then
                txtMode.Text = "Edit Mode"
                btnEditSelectedRequest.Text = "Save Request"
                MsgBox("Edit mode activated. Double-click on the 'Quantity' or 'Status' column of the selected record to edit it.", MsgBoxStyle.Information, "Edit Mode")
            Else
                MsgBox("Please select a record from the list to edit.", MsgBoxStyle.Exclamation, "No Selection")
            End If

        ElseIf btnEditSelectedRequest.Text = "Save Request" Then
            Dim confirmation As MsgBoxResult = MsgBox("Are you sure you want to save the modified changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Changes")

            If confirmation = MsgBoxResult.Yes Then
                Call connection()
                Dim transaction As MySqlTransaction = cn.BeginTransaction() ' Step 10: Ensures Rollback is active 

                Try
                    Dim selectedItem As ListViewItem = ListViewRequestList.SelectedItems(0)

                    ' Extract hidden IDs and updated values
                    Dim reqNo As String = selectedItem.SubItems(0).Text
                    Dim qty As String = selectedItem.SubItems(3).Text
                    Dim subtotal As String = selectedItem.SubItems(5).Text
                    Dim status As String = selectedItem.SubItems(6).Text
                    Dim detailID As String = selectedItem.SubItems(7).Text

                    ' 1. Update tblrequestdetails
                    sql = "UPDATE tblrequestdetails SET Quantity = @qty, Subtotal = @sub WHERE RequestDetailID = @id"
                    cmd = New MySqlCommand(sql, cn, transaction)
                    cmd.Parameters.AddWithValue("@qty", qty)
                    cmd.Parameters.AddWithValue("@sub", subtotal)
                    cmd.Parameters.AddWithValue("@id", detailID)
                    cmd.ExecuteNonQuery()

                    ' 2. Update tblrequest
                    sql = "UPDATE tblrequest SET Status = @status WHERE RequestNo = @reqNo"
                    cmd = New MySqlCommand(sql, cn, transaction)
                    cmd.Parameters.AddWithValue("@status", status)
                    cmd.Parameters.AddWithValue("@reqNo", reqNo)
                    cmd.ExecuteNonQuery()

                    ' Commit changes
                    transaction.Commit()
                    MsgBox("Changes successfully saved to the database.", MsgBoxStyle.Information, "Update Success")

                Catch ex As Exception
                    transaction.Rollback() ' Rollback on Failure
                    MsgBox("An error occurred. Changes have been rolled back. Details: " & ex.Message, MsgBoxStyle.Critical, "Transaction Failed")
                Finally
                    cn.Close()
                End Try

                ' Reset UI
                txtMode.Text = "Normal Mode"
                btnEditSelectedRequest.Text = "Edit Request"
                LoadListViewData()
            End If
        End If

    End Sub

    Private Sub ListViewRequestList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewRequestList.MouseDoubleClick

        If txtMode.Text = "Edit Mode" Then
            If ListViewRequestList.SelectedItems.Count > 0 Then
                ' Identify precisely what the user clicked
                Dim info As ListViewHitTestInfo = ListViewRequestList.HitTest(e.X, e.Y)

                If info.Item IsNot Nothing AndAlso info.SubItem IsNot Nothing Then
                    ' Find the exact column index that was clicked
                    Dim colIndex As Integer = info.Item.SubItems.IndexOf(info.SubItem)

                    ' Column 3 = Quantity
                    If colIndex = 3 Then
                        Dim userInput As String = InputBox("Enter the new Quantity:", "Edit Quantity", info.SubItem.Text)

                        If IsNumeric(userInput) Then
                            If CInt(userInput) > 0 Then
                                info.SubItem.Text = userInput ' Update listview UI quantity

                                ' Dynamically compute and update the Subtotal
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

                        ' Column 6 = Status (BUG FIXED)
                    ElseIf colIndex = 6 Then
                        ' Fetch current status and remove any hidden spaces
                        Dim currentStatus As String = info.SubItem.Text.Trim()

                        Dim userInput As String = InputBox("Enter new Status:" & vbCrLf & "(Pending, Processing, Ready for Release, Released, Cancelled)", "Edit Status", currentStatus)

                        ' Convert user input to uppercase to make it perfectly case-insensitive
                        Dim formattedInput As String = userInput.Trim().ToUpper()

                        ' Validate and apply the correct casing for the UI/Database
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
                                ' If the user clicks cancel or leaves it blank, just do nothing
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

    End Sub
End Class