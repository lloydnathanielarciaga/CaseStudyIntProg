Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmStudentManagement

    ' ============================================================================
    ' AUTOMATIC SECTIONING   Format:  <COURSE> <YEAR><SEMESTER><TIME><NUMBER>
    '   BSIT 31E2  = 3rd Year, 1st Sem, Evening,   Section 2
    '   BSCS 11M1  = 1st Year, 1st Sem, Morning,   Section 1
    '   BSA  22A3  = 2nd Year, 2nd Sem, Afternoon, Section 3
    ' Year comes from cboYearLevel, Semester from the sidebar (CurrentSemester in DbContext),
    ' Time of Day from cboTimeOfDay, Number from cboSectionNo.  the result is shown in lblGeneratedSection.
    ' ============================================================================
    Private _loading As Boolean = False
    Private _sectionCode As String = ""       ' the generated section, e.g. "BSIT 31E2" (this is what gets saved)

    Private ReadOnly CourseCodes As New Dictionary(Of String, String) From {
        {"BS Information Technology", "BSIT"},
        {"BS Computer Science", "BSCS"},
        {"BS Business Administration", "BSBA"},
        {"BS Accountancy", "BSA"},
        {"BS Criminology", "BSCRIM"},
        {"BS Customs Administration", "BSCA"},
        {"BS Hospitality Management", "BSHM"},
        {"BS Industrial Engineering", "BSIE"},
        {"BS Psychology", "BSPSY"},
        {"BS Real Estate Management", "BSREM"},
        {"BS Tourism Management", "BSTM"}}

    Private Function SemesterText() As String
        Return If(CurrentSemester = 2, "2nd Semester", "1st Semester")
    End Function

    ' Year digit read from the combobox TEXT ("3rd Year" -> "3"), so it works even if SelectedIndex isn't set
    Private Function YearDigit() As String
        Dim m As Match = Regex.Match(cboYearLevel.Text, "\d")
        Return If(m.Success, m.Value, "")
    End Function

    Private Function BuildSection() As String
        If cboCourse.SelectedIndex = -1 OrElse YearDigit() = "" OrElse
           cboTimeOfDay.SelectedIndex = -1 OrElse cboSectionNo.SelectedIndex = -1 Then Return ""

        Dim code As String = ""
        If Not CourseCodes.TryGetValue(cboCourse.Text, code) Then Return ""

        Dim yr As String = YearDigit()                              ' "3rd Year"  -> 3
        Dim tod As String = cboTimeOfDay.Text.Substring(0, 1)      ' "Evening"   -> E
        Return code & " " & yr & CurrentSemester.ToString() & tod & cboSectionNo.Text
    End Function

    ' Stores the generated section and refreshes the big label + the 5 boxes (BSIT | 3 | 1 | E | 2)
    Private Sub SetSection(code As String)
        _sectionCode = code
        lblGeneratedSection.Text = If(code = "", "SECTION", code)
        UpdateChips()
    End Sub

    Private Sub UpdateChips()
        Dim m As Match = Regex.Match(_sectionCode, "^([A-Za-z]+)\s(\d)(\d)([MAE])(\d{1,2})$")
        If m.Success Then
            ' complete (or saved) section: show exactly what is stored
            lblCourseCode.Text = m.Groups(1).Value
            lblYearCode.Text = m.Groups(2).Value
            lblSemCode.Text = m.Groups(3).Value
            lblTimeCode.Text = m.Groups(4).Value
            lblNoCode.Text = m.Groups(5).Value
        Else
            ' still choosing: show what has been picked so far
            Dim code As String = ""
            lblCourseCode.Text = If(cboCourse.SelectedIndex <> -1 AndAlso CourseCodes.TryGetValue(cboCourse.Text, code), code, "-")
            lblYearCode.Text = If(YearDigit() <> "", YearDigit(), "-")
            lblSemCode.Text = CurrentSemester.ToString()
            lblTimeCode.Text = If(cboTimeOfDay.SelectedIndex <> -1, cboTimeOfDay.Text.Substring(0, 1), "-")
            lblNoCode.Text = If(cboSectionNo.SelectedIndex <> -1, cboSectionNo.Text, "-")
        End If
    End Sub

    ' Re-builds the section whenever one of the four inputs changes
    Private Sub SectionInputsChanged(sender As Object, e As EventArgs) Handles cboCourse.SelectedIndexChanged,
        cboYearLevel.SelectedIndexChanged, cboYearLevel.TextChanged, cboTimeOfDay.SelectedIndexChanged, cboSectionNo.SelectedIndexChanged
        If _loading Then Exit Sub
        SetSection(BuildSection())
    End Sub

    ' Called by frmAdmin when the sidebar semester combobox changes
    Public Sub RefreshSemester()
        txtSemester.Text = SemesterText()
        If lsvStudents.SelectedItems.Count = 0 Then SetSection(BuildSection())
    End Sub

    ' Fills Time of Day / Section No. from a saved section like "BSIT 31E2" (old data like "A" is left as-is)
    Private Sub ParseSection(section As String)
        _loading = True
        cboTimeOfDay.SelectedIndex = -1
        cboSectionNo.SelectedIndex = -1
        Dim m As Match = Regex.Match(section.Trim(), "^[A-Za-z]+\s\d(\d)([MAE])(\d{1,2})$")
        If m.Success Then
            cboTimeOfDay.SelectedIndex = "MAE".IndexOf(m.Groups(2).Value)
            cboSectionNo.SelectedIndex = cboSectionNo.FindStringExact(m.Groups(3).Value)
        End If
        SetSection(section)
        _loading = False
    End Sub

    ' Finds the section in tblsections by its code (e.g. "BSIT 31E2"); creates it the first time it is used.
    ' Must be called while cn is already open (inside the Try after connection()).
    Private Function GetOrCreateSectionID() As Integer
        Dim code As String = _sectionCode.Trim()

        Using q As New MySqlCommand("SELECT SectionID FROM tblsections WHERE SectionCode = @code", cn)
            q.Parameters.AddWithValue("@code", code)
            Dim found As Object = q.ExecuteScalar()
            If found IsNot Nothing Then Return Convert.ToInt32(found)
        End Using

        ' New section: read year / semester / time / number from the code itself
        Dim m As Match = Regex.Match(code, "^[A-Za-z]+\s(\d)(\d)([MAE])(\d{1,2})$")
        If Not m.Success Then Throw New Exception("Invalid section code: " & code)

        Using ins As New MySqlCommand(
            "INSERT INTO tblsections (SectionCode, Course, YearLevel, Semester, TimeOfDay, SectionNo) " &
            "VALUES (@code, @course, @year, @sem, @tod, @no)", cn)
            ins.Parameters.AddWithValue("@code", code)
            ins.Parameters.AddWithValue("@course", cboCourse.Text)
            ins.Parameters.AddWithValue("@year", Convert.ToInt32(m.Groups(1).Value))
            ins.Parameters.AddWithValue("@sem", Convert.ToInt32(m.Groups(2).Value))
            ins.Parameters.AddWithValue("@tod", If(m.Groups(3).Value = "M", "Morning", If(m.Groups(3).Value = "A", "Afternoon", "Evening")))
            ins.Parameters.AddWithValue("@no", Convert.ToInt32(m.Groups(4).Value))
            ins.ExecuteNonQuery()
            Return Convert.ToInt32(ins.LastInsertedId)
        End Using
    End Function

    Private Sub frmStudentManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtStudentID.ReadOnly = False
        txtSemester.ReadOnly = True
        txtSemester.Text = SemesterText()
        SetSection("")
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

        cboTimeOfDay.Items.Clear()
        cboTimeOfDay.Items.AddRange({"Morning", "Afternoon", "Evening"})

        cboSectionNo.Items.Clear()
        cboSectionNo.Items.AddRange({"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
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

            sql = "SELECT s.StudentID, s.LRN, s.LastName, s.FirstName, s.MiddleName, s.Course, s.YearLevel, IFNULL(sec.SectionCode, '') AS Section, s.ContactNo, s.StudentType, s.Status FROM tblstudents s LEFT JOIN tblsections sec ON s.SectionID = sec.SectionID"
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
        _loading = True
        cboCourse.SelectedIndex = -1
        cboYearLevel.SelectedIndex = -1
        cboTimeOfDay.SelectedIndex = -1
        cboSectionNo.SelectedIndex = -1
        SetSection("")
        _loading = False
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

        If cboTimeOfDay.SelectedIndex = -1 Then
            MsgBox("Please select a Time of Day (Morning, Afternoon or Evening).", MsgBoxStyle.Exclamation)
            cboTimeOfDay.Focus()
            Return False
        End If

        If cboSectionNo.SelectedIndex = -1 Then
            MsgBox("Please select a Section Number.", MsgBoxStyle.Exclamation)
            cboSectionNo.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(_sectionCode) Then
            MsgBox("The section could not be generated. Please check the Course, Year Level, Time of Day and Section Number.", MsgBoxStyle.Exclamation)
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
            _loading = True      ' don't rebuild the section while fields are being filled

            txtStudentID.ReadOnly = True
            txtStudentID.Text = selectedRow.Text
            txtLRN.Text = selectedRow.SubItems(1).Text
            txtLastName.Text = selectedRow.SubItems(2).Text
            txtFirstName.Text = selectedRow.SubItems(3).Text
            txtMiddleName.Text = selectedRow.SubItems(4).Text
            cboCourse.SelectedIndex = cboCourse.FindStringExact(selectedRow.SubItems(5).Text)
            cboYearLevel.SelectedIndex = cboYearLevel.FindStringExact(selectedRow.SubItems(6).Text)
            ParseSection(selectedRow.SubItems(7).Text)      ' shows the saved section, fills Time of Day / No.
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
                Dim sectionId As Integer = GetOrCreateSectionID()      ' finds (or creates) the row in tblsections

                sql = "INSERT INTO tblstudents (StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, SectionID, ContactNo, StudentType, Status) " &
                      "VALUES (@studentid, @lrn, @lastname, @firstname, @middlename, @course, @yearlevel, @sectionid, @contactno, @studenttype, 'Active')"

                cmd = New MySqlCommand(sql, cn)
                With cmd.Parameters
                    .AddWithValue("@studentid", txtStudentID.Text.Trim())
                    .AddWithValue("@lrn", txtLRN.Text)
                    .AddWithValue("@lastname", txtLastName.Text)
                    .AddWithValue("@firstname", txtFirstName.Text)
                    .AddWithValue("@middlename", txtMiddleName.Text)
                    .AddWithValue("@course", cboCourse.Text)
                    .AddWithValue("@yearlevel", cboYearLevel.Text)
                    .AddWithValue("@sectionid", sectionId)
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
        Dim prevSection As String = lsvStudents.SelectedItems(0).SubItems(7).Text

        Dim infoMessage = $"PREVIOUS INFO:{vbCrLf}" &
                          $"Name: {prevName}{vbCrLf}Course: {prevCourse}{vbCrLf}Year Level: {prevYear}{vbCrLf}Section: {prevSection}{vbCrLf}{vbCrLf}" &
                          $"NEW INFO:{vbCrLf}" &
                          $"Name: {txtFirstName.Text} {txtLastName.Text}{vbCrLf}Course: {cboCourse.Text}{vbCrLf}Year Level: {cboYearLevel.Text}{vbCrLf}Section: {_sectionCode}{vbCrLf}{vbCrLf}" &
                          $"Do you want to save these changes?"

        If MsgBox(infoMessage, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Try
                Call connection()
                Dim sectionId As Integer = GetOrCreateSectionID()      ' finds (or creates) the row in tblsections

                sql = "UPDATE tblstudents SET LRN = @lrn, LastName = @lastname, FirstName = @firstname, MiddleName = @middlename, Course = @course, " &
                      "YearLevel = @yearlevel, SectionID = @sectionid, ContactNo = @contactno, StudentType = @studenttype WHERE StudentID = @id"

                cmd = New MySqlCommand(sql, cn)
                With cmd.Parameters
                    .AddWithValue("@lrn", txtLRN.Text)
                    .AddWithValue("@lastname", txtLastName.Text)
                    .AddWithValue("@firstname", txtFirstName.Text)
                    .AddWithValue("@middlename", txtMiddleName.Text)
                    .AddWithValue("@course", cboCourse.Text)
                    .AddWithValue("@yearlevel", cboYearLevel.Text)
                    .AddWithValue("@sectionid", sectionId)
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

            sql = "SELECT s.StudentID, s.LRN, s.LastName, s.FirstName, s.MiddleName, s.Course, s.YearLevel, IFNULL(sec.SectionCode, '') AS Section, s.ContactNo, s.StudentType, s.Status FROM tblstudents s LEFT JOIN tblsections sec ON s.SectionID = sec.SectionID " &
                  "WHERE s.StudentID LIKE @search OR s.LRN LIKE @search OR s.LastName LIKE @search OR sec.SectionCode LIKE @search"

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