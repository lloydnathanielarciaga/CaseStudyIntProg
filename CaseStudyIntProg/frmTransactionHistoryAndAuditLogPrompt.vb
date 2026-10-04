Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frmTransactionHistoryAndAuditLogPrompt
    ' Properties to hold the passed user details from frmUserManagement
    Public Property SelectedUserID As Integer
    Public Property SelectedUsername As String
    Public Property SelectedStaffName As String

    Private Sub frmTransactionHistoryAndAuditLogPrompt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupListViews()
        LoadTransactionHistory()
        LoadAuditLogs()
    End Sub

    Private Sub SetupListViews()
        ' Setup ListViewTransactionHistory
        ListViewTransactionHistory.View = View.Details
        ListViewTransactionHistory.FullRowSelect = True
        ListViewTransactionHistory.GridLines = True
        ListViewTransactionHistory.Columns.Clear()
        ListViewTransactionHistory.Columns.Add("Request No.", 180)
        ListViewTransactionHistory.Columns.Add("Student ID", 130)
        ListViewTransactionHistory.Columns.Add("Request Date", 150)
        ListViewTransactionHistory.Columns.Add("Total Amount", 150)
        ListViewTransactionHistory.Columns.Add("Status", 180)

        ' Setup ListViewAuditLog
        ListViewAuditLog.View = View.Details
        ListViewAuditLog.FullRowSelect = True
        ListViewAuditLog.GridLines = True
        ListViewAuditLog.Columns.Clear()
        ListViewAuditLog.Columns.Add("Log ID", 80)
        ListViewAuditLog.Columns.Add("Action", 150)
        ListViewAuditLog.Columns.Add("Details", 460)
        ListViewAuditLog.Columns.Add("Action Date", 180)
    End Sub

    Private Sub LoadTransactionHistory()
        If SelectedUserID = 0 Then Exit Sub

        ListViewTransactionHistory.Items.Clear()
        Try
            connection()
            ' Filter tblrequest by the UserID (CreatedBy)
            sql = "SELECT RequestNo, StudentID, RequestDate, TotalAmount, Status FROM tblrequest WHERE CreatedBy = @userid ORDER BY RequestDate DESC"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@userid", SelectedUserID)
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim item As New ListViewItem(dr("RequestNo").ToString())
                item.SubItems.Add(dr("StudentID").ToString())

                ' Validate and format date
                Dim reqDate As Date
                If Date.TryParse(dr("RequestDate").ToString(), reqDate) Then
                    item.SubItems.Add(reqDate.ToString("yyyy-MM-dd"))
                Else
                    item.SubItems.Add(dr("RequestDate").ToString())
                End If

                item.SubItems.Add(Convert.ToDecimal(dr("TotalAmount")).ToString("C2"))
                item.SubItems.Add(dr("Status").ToString())
                ListViewTransactionHistory.Items.Add(item)
            End While
        Catch ex As Exception
            MessageBox.Show("Error loading transaction history: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            cn.Close()
        End Try
    End Sub

    Private Sub LoadAuditLogs()
        If String.IsNullOrWhiteSpace(SelectedStaffName) Then Exit Sub

        ListViewAuditLog.Items.Clear()
        Try
            connection()
            ' Corrected column name to 'PerformedBy' based on your database schema
            sql = "SELECT LogID, Action, Details, ActionDate FROM tblauditlog WHERE PerformedBy = @fullname ORDER BY ActionDate DESC"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@fullname", SelectedStaffName)
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim item As New ListViewItem(dr("LogID").ToString())
                item.SubItems.Add(dr("Action").ToString())
                item.SubItems.Add(dr("Details").ToString())
                item.SubItems.Add(dr("ActionDate").ToString())
                ListViewAuditLog.Items.Add(item)
            End While
        Catch ex As Exception
            MessageBox.Show("Error loading audit logs: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            cn.Close()
        End Try
    End Sub

    ' Handles the Close button on the Transaction History Tab
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Handles the Close button on the Audit Log Tab
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class