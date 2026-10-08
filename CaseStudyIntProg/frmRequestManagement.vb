Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class frmRequestManagement

    Private Sub frmRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboNewCurrentStatus.Items.Clear()
        cboNewCurrentStatus.Items.AddRange(New String() {"Pending", "Processing", "Ready for Release", "Released", "Cancelled"})

        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.MultiSelect = False
        ListView1.Columns.Clear()
        ListView1.Columns.Add("RequestID", 0)
        ListView1.Columns.Add("Request No", 120)
        ListView1.Columns.Add("Student ID", 100)
        ListView1.Columns.Add("Status", 120)
        ListView1.Columns.Add("Student Name", 150)
        ListView1.Columns.Add("Request Date", 100)
        ListView1.Columns.Add("Handled Since", 130)

        LoadProcessingRequests()
    End Sub

    Private Sub LoadProcessingRequests()
        Try
            Call connection()
            ListView1.Items.Clear()

            sql = "SELECT r.RequestID, r.RequestNo, r.StudentID, r.Status, " &
              "CONCAT(s.LastName, ', ', s.FirstName) AS StudentFullName, " &
              "u.FullName AS StaffName, r.RequestDate, r.ORDate, r.ORNo " &
              "FROM tblrequest r " &
              "INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
              "INNER JOIN tblusers u ON r.CreatedBy = u.UserID " &
              "ORDER BY CASE WHEN r.Status = 'Processing' THEN 1 ELSE 2 END, r.Status ASC, r.RequestDate DESC"

            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim item As New ListViewItem(dr("RequestID").ToString())
                item.SubItems.Add(dr("RequestNo").ToString())
                item.SubItems.Add(dr("StudentID").ToString())
                item.SubItems.Add(dr("Status").ToString())
                item.SubItems.Add(dr("StudentFullName").ToString())

                Dim reqDate As Date = Convert.ToDateTime(dr("RequestDate"))
                item.SubItems.Add(reqDate.ToString("yyyy-MM-dd"))

                If IsDBNull(dr("ORDate")) Then
                    item.SubItems.Add("N/A")
                Else
                    Dim handledDate As Date = Convert.ToDateTime(dr("ORDate"))
                    item.SubItems.Add(handledDate.ToString("yyyy-MM-dd"))
                End If

                item.Tag = dr("StaffName").ToString()

                If IsDBNull(dr("ORNo")) Then
                    item.SubItems.Add("N/A")
                Else
                    item.SubItems.Add(dr("ORNo").ToString())
                End If

                ListView1.Items.Add(item)
            End While
        Catch ex As Exception
            MsgBox("Error loading requests: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If dr IsNot Nothing Then dr.Close()
            cn.Close()
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Dim selected As ListViewItem = ListView1.SelectedItems(0)

            lblRequestNo.Text = selected.SubItems(1).Text
            lblDisplayCurrentStatus.Text = selected.SubItems(3).Text
            lblDisplayRecordedBy.Text = If(selected.Tag IsNot Nothing, selected.Tag.ToString(), "-")
            lblDisplayRequestCreated.Text = selected.SubItems(5).Text
            lblDisplayRequestHandled.Text = selected.SubItems(6).Text

            lblDisplayStudentNo.Text = selected.SubItems(2).Text
            lblDisplayStudentName.Text = selected.SubItems(4).Text
            lblDisplayORDate.Text = selected.SubItems(6).Text
            lblDisplayORNo.Text = selected.SubItems(7).Text

            cboNewCurrentStatus.SelectedItem = selected.SubItems(3).Text
        Else
            ClearControls()
        End If
    End Sub

    Private Sub ClearControls()
        lblRequestNo.Text = "-"
        lblDisplayCurrentStatus.Text = "-"
        lblDisplayRecordedBy.Text = "-"
        lblDisplayRequestCreated.Text = "-"
        lblDisplayRequestHandled.Text = "-"
        cboNewCurrentStatus.SelectedIndex = -1

        lblDisplayStudentNo.Text = "-"
        lblDisplayStudentName.Text = "-"
        lblDisplayORDate.Text = "-"
        lblDisplayORNo.Text = "-"
    End Sub

    Private Function PromptAndVerifyPassword() As Boolean
        Dim isAuthenticated As Boolean = False
        Dim prompt As New frmPasswordPrompt()

        If prompt.ShowDialog() = DialogResult.OK Then
            Dim inputPass As String = prompt.Password
            Try
                Call connection()
                sql = "SELECT Password FROM tblusers WHERE UserID = @UserID"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@UserID", CurrentUserID)
                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    If inputPass = dr("Password").ToString() Then
                        isAuthenticated = True
                    Else
                        MsgBox("Invalid password. Authorization denied.", MsgBoxStyle.Exclamation)
                    End If
                End If
            Catch ex As Exception
                MsgBox("Database error during authentication: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                If dr IsNot Nothing Then dr.Close()
                cn.Close()
            End Try
        End If

        Return isAuthenticated
    End Function

    Private Sub btnUpdateRequest_Click(sender As Object, e As EventArgs) Handles btnUpdateRequest.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Please select a request from the list.", MsgBoxStyle.Exclamation)
            Return
        End If

        If cboNewCurrentStatus.SelectedIndex = -1 Then
            MsgBox("Please select an updated status from the dropdown.", MsgBoxStyle.Exclamation)
            Return
        End If

        If cboNewCurrentStatus.Text = lblDisplayCurrentStatus.Text Then
            MsgBox("The selected status matches the current status.", MsgBoxStyle.Information)
            Return
        End If

        If PromptAndVerifyPassword() Then
            Dim reqID As Integer = CInt(ListView1.SelectedItems(0).Text)
            ExecuteStatusUpdate(reqID, cboNewCurrentStatus.Text)
        End If
    End Sub

    Private Sub btnCancelRequest_Click(sender As Object, e As EventArgs) Handles btnCancelRequest.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Please select a request from the list.", MsgBoxStyle.Exclamation)
            Return
        End If

        If PromptAndVerifyPassword() Then
            Dim reqID As Integer = CInt(ListView1.SelectedItems(0).Text)
            ExecuteStatusUpdate(reqID, "Cancelled")
        End If
    End Sub

    Private Sub ExecuteStatusUpdate(requestID As Integer, newStatus As String)
        Dim tr As MySqlTransaction = Nothing
        Try
            Call connection()
            tr = cn.BeginTransaction()

            sql = "UPDATE tblrequest SET Status = @Status WHERE RequestID = @RequestID"
            cmd = New MySqlCommand(sql, cn)
            cmd.Transaction = tr
            cmd.Parameters.AddWithValue("@Status", newStatus)
            cmd.Parameters.AddWithValue("@RequestID", requestID)

            cmd.ExecuteNonQuery()
            tr.Commit()

            LogAudit("Status Change", "Changed Request ID " & requestID & " status to " & newStatus, CurrentFullName, requestID)

            MsgBox("Request successfully updated to " & newStatus & ".", MsgBoxStyle.Information)

            LoadProcessingRequests()
            ClearControls()

        Catch ex As Exception
            If tr IsNot Nothing Then tr.Rollback()
            MsgBox("An error occurred. Changes have been rolled back. " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearControls()
    End Sub
End Class