Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.Devices
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmStudentManagement
    Private Sub frmStudentManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()

        SetupListView()
        LoadDocumentData()
    End Sub

    Private Sub SetupListView()
        lsvStudents.View = View.Details
        lsvStudents.FullRowSelect = True
        lsvStudents.GridLines = True

        lsvStudents.Columns.Clear()
        lsvStudents.Columns.Add("Student ID", 115)
        lsvStudents.Columns.Add("LRN", 135)
        lsvStudents.Columns.Add("Last Name", 115)
        lsvStudents.Columns.Add("First Name", 115)
        lsvStudents.Columns.Add("Middle Name", 135)
        lsvStudents.Columns.Add("Course", 215)
        lsvStudents.Columns.Add("Year Level", 110)
        lsvStudents.Columns.Add("Section", 85)
        lsvStudents.Columns.Add("Contact No", 125)
        lsvStudents.Columns.Add("Status", 85)
    End Sub

    Private Sub LoadDocumentData()
        lsvStudents.Items.Clear()

        sql = "SELECT StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, Status FROM tblstudents"

        Try
            connection()
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
                item.SubItems.Add(dr("Status").ToString())

                lsvStudents.Items.Add(item)
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox("Error loading students: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub lsvStudents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvStudents.SelectedIndexChanged
        If lsvStudents.SelectedItems.Count > 0 Then
            Dim selectedRow As ListViewItem = lsvStudents.SelectedItems(0)

            txtStudentID.Text = selectedRow.Text
            txtLRN.Text = selectedRow.SubItems(1).Text
            txtLastName.Text = selectedRow.SubItems(2).Text
            txtFirstName.Text = selectedRow.SubItems(3).Text
            txtMiddleName.Text = selectedRow.SubItems(4).Text
            txtCourse.Text = selectedRow.SubItems(5).Text
            txtYearLevel.Text = selectedRow.SubItems(6).Text
            txtSection.Text = selectedRow.SubItems(7).Text
            txtContactNo.Text = selectedRow.SubItems(8).Text

            If selectedRow.SubItems(9).Text = "Active" Then
                rdoActive.Checked = True
            Else
                rdoInactive.Checked = True
            End If
        End If
    End Sub

    Private Function ValidateStudentInput(ByRef errorMessage As String) As Boolean
        If String.IsNullOrWhiteSpace(txtLRN.Text) OrElse Not Regex.IsMatch(txtLRN.Text.Trim(), "^\d{12}$") Then
            errorMessage = "LRN must be exactly 12 digits (numbers only)."
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLastName.Text) OrElse Not Regex.IsMatch(txtLastName.Text.Trim(), "^[A-Za-z\s'\-\.]+$") Then
            errorMessage = "Last Name is required and must contain letters only."
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse Not Regex.IsMatch(txtFirstName.Text.Trim(), "^[A-Za-z\s'\-\.]+$") Then
            errorMessage = "First Name is required and must contain letters only."
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(txtMiddleName.Text) AndAlso Not Regex.IsMatch(txtMiddleName.Text.Trim(), "^[A-Za-z\s'\-\.]+$") Then
            errorMessage = "Middle Name must contain letters only."
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtCourse.Text) Then
            errorMessage = "Course is required."
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtYearLevel.Text) Then
            errorMessage = "Year Level is required."
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtSection.Text) OrElse Not Regex.IsMatch(txtSection.Text.Trim(), "^[A-Za-z0-9]{1,5}$") Then
            errorMessage = "Section must be 1-5 letters/numbers (e.g. A, B1)."
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtContactNo.Text) OrElse Not Regex.IsMatch(txtContactNo.Text.Trim(), "^09\d{9}$") Then
            errorMessage = "Contact No must be an 11-digit PH mobile number starting with 09 (e.g. 09171234567)."
            Return False
        End If

        errorMessage = String.Empty
        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim errorMessage As String = String.Empty
        If Not ValidateStudentInput(errorMessage) Then
            MsgBox(errorMessage, MsgBoxStyle.Critical, "Validation Error")
            Return
        End If

        Dim statusValue As String = If(rdoActive.Checked, "Active", "Inactive")
        Dim newStudentID As String = GenerateNewStudentID()
        Dim query As String = "INSERT INTO tblstudents (StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, Status) " &
                               "VALUES (@studentid, @lrn, @lastname, @firstname, @middlename, @course, @yearlevel, @section, @contactno, @status);"

        Try
            connection()
            Using cmd As New MySqlCommand(query, cn)
                cmd.Parameters.AddWithValue("@studentid", newStudentID)
                cmd.Parameters.AddWithValue("@lrn", txtLRN.Text)
                cmd.Parameters.AddWithValue("@lastname", txtLastName.Text)
                cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@middlename", txtMiddleName.Text)
                cmd.Parameters.AddWithValue("@course", txtCourse.Text)
                cmd.Parameters.AddWithValue("@yearlevel", txtYearLevel.Text)
                cmd.Parameters.AddWithValue("@section", txtSection.Text)
                cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text)
                cmd.Parameters.AddWithValue("@status", statusValue)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Student added successfully!", MsgBoxStyle.Information)
            ClearFields()
            LoadDocumentData()
        Catch ex As Exception
            MsgBox("Error adding student: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try

    End Sub

    ' Added: generates the next StudentID in the format YYYY0001, resetting
    ' the 4-digit sequence back to 0001 at the start of each new year.
    Private Function GenerateNewStudentID() As String
        Dim currentYear As String = DateTime.Now.Year.ToString()
        Dim nextID As String = currentYear & "0001"

        Dim query As String = "SELECT StudentID FROM tblstudents WHERE StudentID LIKE @yearPrefix ORDER BY StudentID DESC LIMIT 1"

        Try
            connection()
            Using cmd As New MySqlCommand(query, cn)
                cmd.Parameters.AddWithValue("@yearPrefix", currentYear & "%")
                Dim result = cmd.ExecuteScalar()

                If result IsNot Nothing Then
                    Dim lastID As String = result.ToString()
                    Dim lastSequence As Integer = Integer.Parse(lastID.Substring(4)) ' last 4 digits after the year
                    Dim newSequence As Integer = lastSequence + 1
                    nextID = currentYear & newSequence.ToString("D4")
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error generating Student ID: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try

        Return nextID
    End Function

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Check that a student is actually selected before editing,
        ' otherwise txtStudentID is empty and the UPDATE matches no rows.
        If String.IsNullOrWhiteSpace(txtStudentID.Text) Then
            MsgBox("Please select a student from the list to edit.", MsgBoxStyle.Critical)
            Return
        End If

        Dim errorMessage As String = String.Empty
        If Not ValidateStudentInput(errorMessage) Then
            MsgBox(errorMessage, MsgBoxStyle.Critical, "Validation Error")
            Return
        End If

        Dim statusValue As String = If(rdoActive.Checked, "Active", "Inactive")
        Dim query As String = "UPDATE tblstudents SET LRN = @lrn, LastName = @lastname, FirstName = @firstname, MiddleName = @middlename, Course = @course, " &
                               "YearLevel = @yearlevel, Section = @section, ContactNo = @contactno, Status = @status WHERE StudentID = @id;"

        Try
            connection()
            Using cmd As New MySqlCommand(query, cn)
                cmd.Parameters.AddWithValue("@lrn", txtLRN.Text)
                cmd.Parameters.AddWithValue("@lastname", txtLastName.Text)
                cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@middlename", txtMiddleName.Text)
                cmd.Parameters.AddWithValue("@course", txtCourse.Text)
                cmd.Parameters.AddWithValue("@yearlevel", txtYearLevel.Text)
                cmd.Parameters.AddWithValue("@section", txtSection.Text)
                cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text)
                cmd.Parameters.AddWithValue("@status", statusValue)
                cmd.Parameters.AddWithValue("@id", txtStudentID.Text)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Student updated successfully!", MsgBoxStyle.Information)
            ClearFields()
            LoadDocumentData()
        Catch ex As Exception
            MsgBox("Error updating student: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub btnDeactivate_Click(sender As Object, e As EventArgs) Handles btnDeactivate.Click
        If String.IsNullOrWhiteSpace(txtStudentID.Text) Then
            MsgBox("Please select a Student ID from the list first.", MsgBoxStyle.Critical)
            Return
        End If

        Dim newStatus As String = If(rdoActive.Checked, "Inactive", "Active")

        sql = "UPDATE tblstudents SET Status = @status WHERE StudentID = @id"

        Try
            connection()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@status", newStatus)
                cmd.Parameters.AddWithValue("@id", txtStudentID.Text)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Student updated successfully!", MsgBoxStyle.Information)
            ClearFields()
            LoadDocumentData()
        Catch ex As Exception
            MsgBox("Error updating status: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearFields()
        LoadDocumentData()

    End Sub

    Private Sub ClearFields()
        txtStudentID.Clear()
        txtLRN.Clear()
        txtLastName.Clear()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        txtCourse.Clear()
        txtYearLevel.Clear()
        txtSection.Clear()
        txtContactNo.Clear()
        txtSearch.Text = "Search a Student"
        rdoActive.Checked = True

        If lsvStudents.SelectedItems.Count > 0 Then
            lsvStudents.SelectedItems(0).Selected = False
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim search As String = txtSearch.Text

        If String.IsNullOrEmpty(search) OrElse search = "Search a Student" Then
            MsgBox("Please enter a Student ID, LRN, or Last Name to search.", MsgBoxStyle.Critical)
            LoadDocumentData()
            Return
        End If

        lsvStudents.Items.Clear()

        sql = "SELECT StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, Status FROM tblstudents " &
              "WHERE StudentID LIKE @search OR LRN LIKE @search OR LastName LIKE @search"

        Try
            connection()
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
                item.SubItems.Add(dr("Status").ToString())

                lsvStudents.Items.Add(item)
            End While
            dr.Close()

            If lsvStudents.Items.Count = 0 Then
                MsgBox("No students found matching your search.", MsgBoxStyle.Information, "No Results")
            End If

        Catch ex As Exception
            MsgBox("Search error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub
End Class