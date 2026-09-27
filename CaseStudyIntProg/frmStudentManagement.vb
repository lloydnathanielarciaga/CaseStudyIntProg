Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmStudentManagement

    Private Sub frmStudentManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtStudentID.ReadOnly = False
        rdoRegular.Checked = True

        SetupListView()
        SetupComboBoxes()
        LoadStudentData()
    End Sub

    Private Sub SetupComboBoxes()
        cboCourse.Items.Clear()
        cboCourse.Items.AddRange({"BS Information Technology", "BS Computer Science",
                                  "BS Business Administration", "BS Accountancy", "BS Criminology",
                                  "BS Customs Administration", "BS Hospitality Management",
                                  "BS Industrial Engineering", "BS Psychology",
                                  "BS Real Estate Management", "BS Tourism Management"})

        cboYearLevel.Items.Clear()
        cboYearLevel.Items.AddRange({"1st Year", "2nd Year", "3rd Year", "4th Year", "5th Year"})
    End Sub

    Private Sub SetupListView()
        With lsvStudents
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Columns.Clear()
            .Columns.Add("Student ID", 115)
            .Columns.Add("LRN", 135)
            .Columns.Add("Last Name", 115)
            .Columns.Add("First Name", 115)
            .Columns.Add("Middle Name", 135)
            .Columns.Add("Course", 215)
            .Columns.Add("Year Level", 110)
            .Columns.Add("Section", 85)
            .Columns.Add("Contact No", 125)
            .Columns.Add("Type", 90)
            .Columns.Add("Status", 85)
        End With
    End Sub

    Private Sub LoadStudentData()
        Try
            Call connection()
            lsvStudents.Items.Clear()

            sql = "SELECT StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, StudentType, Status FROM tblstudents"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim item As New ListViewItem(dr("StudentID").ToString())
                item.SubItems.Add(dr("LRN").ToString())
                item.SubItems.Add(dr("LastName").ToString())
                item.SubItems.Add(dr("FirstName").ToString())
                item.SubItems.Add(dr("MiddleName").ToString())
                item.SubItems.Add(dr("Course").ToString())
                item.SubItems.Add(dr("YearLevel").ToString())
                item.SubItems.Add(dr("Section").ToString())
                item.SubItems.Add(dr("ContactNo").ToString())
                item.SubItems.Add(dr("StudentType").ToString())
                item.SubItems.Add(dr("Status").ToString())
                lsvStudents.Items.Add(item)
            End While

        Catch ex As Exception
            MsgBox("Error loading students: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        txtStudentID.ReadOnly = False
        txtStudentID.Clear()
        txtLRN.Clear()
        txtLastName.Clear()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        cboCourse.SelectedIndex = -1
        cboYearLevel.SelectedIndex = -1
        txtSection.Clear()
        txtContactNo.Clear()
        txtSearch.Text = "Search a Student"
        rdoRegular.Checked = True

        If lsvStudents.SelectedItems.Count > 0 Then
            lsvStudents.SelectedItems(0).Selected = False
        End If
    End Sub

    Private Function ValidateStudentInput() As Boolean
        If String.IsNullOrWhiteSpace(txtStudentID.Text) OrElse Not Regex.IsMatch(txtStudentID.Text.Trim(), "^\d{4}-\d{2}$") Then
            MsgBox("Student ID must follow the format ####-## (e.g. 1446-24).", MsgBoxStyle.Exclamation)
            txtStudentID.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLRN.Text) OrElse Not Regex.IsMatch(txtLRN.Text.Trim(), "^\d{12}$") Then
            MsgBox("LRN must be exactly 12 digits (numbers only).", MsgBoxStyle.Exclamation)
            txtLRN.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLastName.Text) OrElse Not Regex.IsMatch(txtLastName.Text.Trim(), "^[A-Za-z\s'\-\.]+$") Then
            MsgBox("Last Name is required and must contain letters only.", MsgBoxStyle.Exclamation)
            txtLastName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse Not Regex.IsMatch(txtFirstName.Text.Trim(), "^[A-Za-z\s'\-\.]+$") Then
            MsgBox("First Name is required and must contain letters only.", MsgBoxStyle.Exclamation)
            txtFirstName.Focus()
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(txtMiddleName.Text) AndAlso Not Regex.IsMatch(txtMiddleName.Text.Trim(), "^[A-Za-z\s'\-\.]+$") Then
            MsgBox("Middle Name must contain letters only.", MsgBoxStyle.Exclamation)
            txtMiddleName.Focus()
            Return False
        End If

        If cboCourse.SelectedIndex = -1 Then
            MsgBox("Please select a Course from the list.", MsgBoxStyle.Exclamation)
            cboCourse.Focus()
            Return False
        End If

        If cboYearLevel.SelectedIndex = -1 Then
            MsgBox("Please select a Year Level from the list.", MsgBoxStyle.Exclamation)
            cboYearLevel.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtSection.Text) OrElse Not Regex.IsMatch(txtSection.Text.Trim(), "^[A-Za-z0-9]{1,5}$") Then
            MsgBox("Section must be 1-5 letters/numbers (e.g. A, B1).", MsgBoxStyle.Exclamation)
            txtSection.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtContactNo.Text) OrElse Not Regex.IsMatch(txtContactNo.Text.Trim(), "^09\d{9}$") Then
            MsgBox("Contact No must be an 11-digit PH mobile number starting with 09 (e.g. 09171234567).", MsgBoxStyle.Exclamation)
            txtContactNo.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub lsvStudents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvStudents.SelectedIndexChanged
        If lsvStudents.SelectedItems.Count > 0 Then
            Dim selectedRow As ListViewItem = lsvStudents.SelectedItems(0)

            txtStudentID.ReadOnly = True
            txtStudentID.Text = selectedRow.Text
            txtLRN.Text = selectedRow.SubItems(1).Text
            txtLastName.Text = selectedRow.SubItems(2).Text
            txtFirstName.Text = selectedRow.SubItems(3).Text
            txtMiddleName.Text = selectedRow.SubItems(4).Text
            cboCourse.SelectedIndex = cboCourse.FindStringExact(selectedRow.SubItems(5).Text)
            cboYearLevel.SelectedIndex = cboYearLevel.FindStringExact(selectedRow.SubItems(6).Text)
            txtSection.Text = selectedRow.SubItems(7).Text
            txtContactNo.Text = selectedRow.SubItems(8).Text

            If selectedRow.SubItems(9).Text = "Regular" Then
                rdoRegular.Checked = True
            Else
                rdoIrregular.Checked = True
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateStudentInput() Then Exit Sub

        If MsgBox("Do you want to save this new student?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Try
                Call connection()

                ' Check for Duplicate Student ID
                sql = "SELECT COUNT(*) FROM tblstudents WHERE StudentID = @studentid"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@studentid", txtStudentID.Text.Trim())

                If Convert.ToInt64(cmd.ExecuteScalar()) > 0 Then
                    MsgBox($"Student ID '{txtStudentID.Text.Trim()}' already exists. Please use a different ID.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                ' Insert Student
                sql = "INSERT INTO tblstudents (StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, StudentType, Status) " &
                      "VALUES (@studentid, @lrn, @lastname, @firstname, @middlename, @course, @yearlevel, @section, @contactno, @studenttype, 'Active')"

                cmd = New MySqlCommand(sql, cn)
                With cmd.Parameters
                    .AddWithValue("@studentid", txtStudentID.Text.Trim())
                    .AddWithValue("@lrn", txtLRN.Text)
                    .AddWithValue("@lastname", txtLastName.Text)
                    .AddWithValue("@firstname", txtFirstName.Text)
                    .AddWithValue("@middlename", txtMiddleName.Text)
                    .AddWithValue("@course", cboCourse.Text)
                    .AddWithValue("@yearlevel", cboYearLevel.Text)
                    .AddWithValue("@section", txtSection.Text)
                    .AddWithValue("@contactno", txtContactNo.Text)
                    .AddWithValue("@studenttype", If(rdoRegular.Checked, "Regular", "Irregular"))
                End With

                cmd.ExecuteNonQuery()
                MsgBox("Student added successfully!", MsgBoxStyle.Information)

                ClearFields()
                LoadStudentData()

            Catch ex As Exception
                MsgBox("Error adding student: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If lsvStudents.SelectedItems.Count = 0 Then
            MsgBox("Please select a student from the list to edit.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not ValidateStudentInput() Then Exit Sub

        ' Grab previous info from ListView for interpolation
        Dim prevName As String = $"{lsvStudents.SelectedItems(0).SubItems(3).Text} {lsvStudents.SelectedItems(0).SubItems(2).Text}"
        Dim prevCourse As String = lsvStudents.SelectedItems(0).SubItems(5).Text
        Dim prevYear As String = lsvStudents.SelectedItems(0).SubItems(6).Text

        Dim infoMessage = $"PREVIOUS INFO:{vbCrLf}" &
                          $"Name: {prevName}{vbCrLf}Course: {prevCourse}{vbCrLf}Year Level: {prevYear}{vbCrLf}{vbCrLf}" &
                          $"NEW INFO:{vbCrLf}" &
                          $"Name: {txtFirstName.Text} {txtLastName.Text}{vbCrLf}Course: {cboCourse.Text}{vbCrLf}Year Level: {cboYearLevel.Text}{vbCrLf}{vbCrLf}" &
                          $"Do you want to save these changes?"

        If MsgBox(infoMessage, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Try
                Call connection()
                sql = "UPDATE tblstudents SET LRN = @lrn, LastName = @lastname, FirstName = @firstname, MiddleName = @middlename, Course = @course, " &
                      "YearLevel = @yearlevel, Section = @section, ContactNo = @contactno, StudentType = @studenttype WHERE StudentID = @id"

                cmd = New MySqlCommand(sql, cn)
                With cmd.Parameters
                    .AddWithValue("@lrn", txtLRN.Text)
                    .AddWithValue("@lastname", txtLastName.Text)
                    .AddWithValue("@firstname", txtFirstName.Text)
                    .AddWithValue("@middlename", txtMiddleName.Text)
                    .AddWithValue("@course", cboCourse.Text)
                    .AddWithValue("@yearlevel", cboYearLevel.Text)
                    .AddWithValue("@section", txtSection.Text)
                    .AddWithValue("@contactno", txtContactNo.Text)
                    .AddWithValue("@studenttype", If(rdoRegular.Checked, "Regular", "Irregular"))
                    .AddWithValue("@id", txtStudentID.Text)
                End With

                cmd.ExecuteNonQuery()
                MsgBox("Student updated successfully!", MsgBoxStyle.Information)

                ClearFields()
                LoadStudentData()

            Catch ex As Exception
                MsgBox("Error updating student: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub btnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click
        If String.IsNullOrWhiteSpace(txtStudentID.Text) Then
            MsgBox("Please select a Student ID from the list first.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox($"Are you sure you want to ACTIVATE student {txtStudentID.Text}?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Try
                Call connection()
                sql = "UPDATE tblstudents SET Status = 'Active' WHERE StudentID = @id"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", txtStudentID.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Student activated successfully!", MsgBoxStyle.Information)

                ClearFields()
                LoadStudentData()

            Catch ex As Exception
                MsgBox("Error activating student: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub btnDeactivate_Click(sender As Object, e As EventArgs) Handles btnDeactivate.Click
        If String.IsNullOrWhiteSpace(txtStudentID.Text) Then
            MsgBox("Please select a Student ID from the list first.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox($"Are you sure you want to DEACTIVATE student {txtStudentID.Text}?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Try
                Call connection()
                sql = "UPDATE tblstudents SET Status = 'Inactive' WHERE StudentID = @id"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", txtStudentID.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Student deactivated successfully!", MsgBoxStyle.Information)

                ClearFields()
                LoadStudentData()

            Catch ex As Exception
                MsgBox("Error deactivating student: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim search As String = txtSearch.Text

        If String.IsNullOrEmpty(search) OrElse search = "Search a Student" Then
            MsgBox("Please enter a Student ID, LRN, or Last Name to search.", MsgBoxStyle.Exclamation)
            LoadStudentData()
            Exit Sub
        End If

        Try
            Call connection()
            lsvStudents.Items.Clear()

            sql = "SELECT StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, StudentType, Status FROM tblstudents " &
                  "WHERE StudentID LIKE @search OR LRN LIKE @search OR LastName LIKE @search"

            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@search", "%" & search & "%")
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim item As New ListViewItem(dr("StudentID").ToString())
                item.SubItems.Add(dr("LRN").ToString())
                item.SubItems.Add(dr("LastName").ToString())
                item.SubItems.Add(dr("FirstName").ToString())
                item.SubItems.Add(dr("MiddleName").ToString())
                item.SubItems.Add(dr("Course").ToString())
                item.SubItems.Add(dr("YearLevel").ToString())
                item.SubItems.Add(dr("Section").ToString())
                item.SubItems.Add(dr("ContactNo").ToString())
                item.SubItems.Add(dr("StudentType").ToString())
                item.SubItems.Add(dr("Status").ToString())
                lsvStudents.Items.Add(item)
            End While

            If lsvStudents.Items.Count = 0 Then
                MsgBox("No students found matching your search.", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("Search error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
        LoadStudentData()
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Text = ""
        LoadStudentData()
    End Sub

End Class