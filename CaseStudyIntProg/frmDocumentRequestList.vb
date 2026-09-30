Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frmDocumentRequestList

    Private Sub frmDocumentRequestList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize ListView Properties based on standard presentation guidelines
        ListViewRequestList.View = View.Details
        ListViewRequestList.FullRowSelect = True
        ListViewRequestList.GridLines = True
        ListViewRequestList.MultiSelect = False

        ' Setup ListView Columns
        ListViewRequestList.Columns.Clear()
        ListViewRequestList.Columns.Add("Request No.", 120)
        ListViewRequestList.Columns.Add("Student ID", 100)
        ListViewRequestList.Columns.Add("Last Name", 120)
        ListViewRequestList.Columns.Add("First Name", 120)
        ListViewRequestList.Columns.Add("Request Date", 100)
        ListViewRequestList.Columns.Add("Total Amount", 100)
        ListViewRequestList.Columns.Add("Status", 100)

        ' Initialize ComboBoxes
        cboStatusFilter.Items.AddRange(New String() {"All", "Pending", "Processing", "Ready for Release", "Released", "Cancelled"})
        cboStatusFilter.SelectedIndex = 0

        cboOrder.Items.AddRange(New String() {"Ascending", "Descending"})
        cboOrder.SelectedIndex = 0

        ' Setup Autocomplete for predictive searching
        LoadAutoCompleteData()

        ' Load initial data
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

                ' Keep StudentID so users can still search/autocomplete by ID numbers
                autoCompleteCollection.Add(studentId)

                ' Add ONLY the combined full name formats
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

            ' Expanded WHERE clause checking StudentID, LastName, FirstName, and concatenated Full Names
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

            ' Parameterized queries prevent SQL injection and errors[cite: 2]
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
                ' Format date to remove time portion if necessary
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
        ' Validation to ensure DateFrom is not greater than DateTo
        If DateTimePickerFrom.Value.Date > DateTimePickerTo.Value.Date Then
            MessageBox.Show("The 'Date From' cannot be later than the 'Date To'.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ' Confirmation Prompt
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to clear all search filters?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            txtSearchStudentIdOrName.Clear()
            cboStatusFilter.SelectedIndex = 0
            cboOrder.SelectedIndex = 0
            DateTimePickerFrom.Value = DateTime.Now.AddMonths(-1) ' Default to 1 month ago
            DateTimePickerTo.Value = DateTime.Now
            LoadData()
        End If
    End Sub

    Private Sub ListViewRequestList_DoubleClick(sender As Object, e As EventArgs) Handles ListViewRequestList.DoubleClick
        ' Progressive Disclosure: Double-clicking reveals a confirmation to view deeper details
        If ListViewRequestList.SelectedItems.Count > 0 Then
            Dim reqNo As String = ListViewRequestList.SelectedItems(0).Text
            Dim result As DialogResult = MessageBox.Show($"Would you like to open the full request details for {reqNo}?", "Explicit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If result = DialogResult.Yes Then
                ' Logic to open a detailed view form would go here
                MessageBox.Show("Detailed view module opening...", "Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        End If
    End Sub
End Class