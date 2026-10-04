Imports MySql.Data.MySqlClient

Public Class frmStudentInformation

    Private Sub frmStudentInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupListView()
        LoadStudentData()
    End Sub

    Private Sub SetupListView()
        With lsvStudents
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Columns.Clear()
            .Columns.Add("Student ID", 115)
            .Columns.Add("LRN", 145)
            .Columns.Add("Last Name", 130)
            .Columns.Add("First Name", 130)
            .Columns.Add("Middle Name", 150)
            .Columns.Add("Course", 275)
            .Columns.Add("Year Level", 110)
            .Columns.Add("Section", 145)
            .Columns.Add("Contact No", 135)
            .Columns.Add("Type", 100)
            .Columns.Add("Status", 85)
        End With
    End Sub

    ' Read-only view for Registrar Staff — matches the case study's
    ' "Search students" permission, with no Add/Edit/Activate/Deactivate.
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

End Class