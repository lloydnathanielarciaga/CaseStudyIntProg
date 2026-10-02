Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frmDocumentRequestList

    Private Sub frmDocumentRequestList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewRequestList.View = View.Details
        ListViewRequestList.FullRowSelect = True
        ListViewRequestList.GridLines = True
        ListViewRequestList.MultiSelect = False

        ListViewRequestList.Columns.Clear()
        ListViewRequestList.Columns.Add("Request No.", 260)
        ListViewRequestList.Columns.Add("Student ID", 180)
        ListViewRequestList.Columns.Add("Last Name", 220)
        ListViewRequestList.Columns.Add("First Name", 220)
        ListViewRequestList.Columns.Add("Request Date", 200)
        ListViewRequestList.Columns.Add("Total Amount", 200)
        ListViewRequestList.Columns.Add("Status", 260)

        cboStatusFilter.Items.AddRange(New String() {"All", "Pending", "Processing", "Ready for Release", "Released", "Cancelled"})

        cboStatusFilter.SelectedIndex = 1

        cboOrder.Items.AddRange(New String() {"Ascending", "Descending"})
        cboOrder.SelectedIndex = 0

        LoadAutoCompleteData()

        LoadData()
    End Sub

    Private Sub LoadAutoCompleteData()
        Try
            Call connection()
            sql = "SELECT StudentID, LastName, FirstName FROM tblstudents"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            Dim autoCompleteCollection As New AutoCompleteStringCollection()

            While dr.Read()
                Dim studentId As String = dr("StudentID").ToString()
                Dim lastName As String = dr("LastName").ToString()
                Dim firstName As String = dr("FirstName").ToString()

                autoCompleteCollection.Add(studentId)

                autoCompleteCollection.Add($"{lastName}, {firstName}")
                autoCompleteCollection.Add($"{firstName} {lastName}")
            End While

            txtSearchStudentIdOrName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSearchStudentIdOrName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSearchStudentIdOrName.AutoCompleteCustomSource = autoCompleteCollection

        Catch ex As Exception
            MessageBox.Show("Error loading prediction data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            cn.Close()
        End Try
    End Sub

    Private Sub LoadData()
        Try
            Call connection()
            ListViewRequestList.Items.Clear()

            sql = "SELECT r.RequestNo, r.StudentID, s.LastName, s.FirstName, r.RequestDate, r.TotalAmount, r.Status " &
      "FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
      "WHERE (r.StudentID LIKE @search " &
      "   OR s.LastName LIKE @search " &
      "   OR s.FirstName LIKE @search " &
      "   OR CONCAT(s.LastName, ', ', s.FirstName) LIKE @search " &
      "   OR CONCAT(s.FirstName, ' ', s.LastName) LIKE @search) " &
      "AND (r.RequestDate >= @dateFrom AND r.RequestDate <= @dateTo)"

            If cboStatusFilter.Text <> "All" Then
                sql &= " AND r.Status = @status"
            End If

            If cboOrder.Text = "Ascending" Then
                sql &= " ORDER BY r.RequestDate ASC"
            Else
                sql &= " ORDER BY r.RequestDate DESC"
            End If

            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@search", "%" & txtSearchStudentIdOrName.Text.Trim() & "%")
            cmd.Parameters.AddWithValue("@dateFrom", DateTimePickerFrom.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@dateTo", DateTimePickerTo.Value.ToString("yyyy-MM-dd"))

            If cboStatusFilter.Text <> "All" Then
                cmd.Parameters.AddWithValue("@status", cboStatusFilter.Text)
            End If

            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim item As New ListViewItem(dr("RequestNo").ToString())
                item.SubItems.Add(dr("StudentID").ToString())
                item.SubItems.Add(dr("LastName").ToString())
                item.SubItems.Add(dr("FirstName").ToString())
                item.SubItems.Add(Convert.ToDateTime(dr("RequestDate")).ToString("yyyy-MM-dd"))
                item.SubItems.Add("₱" & Convert.ToDecimal(dr("TotalAmount")).ToString("N2"))
                item.SubItems.Add(dr("Status").ToString())
                ListViewRequestList.Items.Add(item)
            End While

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            cn.Close()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If DateTimePickerFrom.Value.Date > DateTimePickerTo.Value.Date Then
            MessageBox.Show("The 'Date From' cannot be later than the 'Date To'.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to clear all search filters?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            txtSearchStudentIdOrName.Clear()
            cboStatusFilter.SelectedIndex = 0
            cboOrder.SelectedIndex = 0
            DateTimePickerFrom.Value = DateTime.Now.AddMonths(-1)
            DateTimePickerTo.Value = DateTime.Now
            LoadData()
        End If
    End Sub

    Private Sub ListViewRequestList_DoubleClick(sender As Object, e As EventArgs) Handles ListViewRequestList.DoubleClick
        If ListViewRequestList.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListViewRequestList.SelectedItems(0)

            Dim reqNo As String = selectedItem.SubItems(0).Text
            Dim studentId As String = selectedItem.SubItems(1).Text
            Dim studentName As String = $"{selectedItem.SubItems(2).Text}, {selectedItem.SubItems(3).Text}"
            Dim reqDate As DateTime = Convert.ToDateTime(selectedItem.SubItems(4).Text)
            Dim currentStatus As String = selectedItem.SubItems(6).Text

            If Not currentStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show($"This request cannot accept payments because its current status is '{currentStatus}'. Only 'Pending' requests can be processed.", "Payment Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Using paymentPrompt As New frmPaymentPrompt()
                paymentPrompt.SelectedRequestNo = reqNo
                paymentPrompt.SelectedStudentID = studentId
                paymentPrompt.SelectedStudentName = studentName
                paymentPrompt.SelectedRequestDate = reqDate

                If paymentPrompt.ShowDialog() = DialogResult.OK Then
                    LoadData()
                End If
            End Using
        End If
    End Sub
End Class