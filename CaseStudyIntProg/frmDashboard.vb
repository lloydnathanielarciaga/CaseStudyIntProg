Imports MySql.Data.MySqlClient

Public Class frmDashboard

    Private ReadOnly Peso As String = ChrW(8369)
    Private WithEvents tmrRefresh As Timer

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureColumns()
        dtpDate.Value = Date.Today
        LoadStatistics()

        tmrRefresh = New Timer() With {.Interval = 60000}    ' auto-refresh every 60 seconds
        tmrRefresh.Start()
    End Sub

    Private Sub frmDashboard_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
        If tmrRefresh IsNot Nothing Then
            tmrRefresh.Stop()
            tmrRefresh.Dispose()
        End If
    End Sub

    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        LoadStatistics()
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        LoadStatistics()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStatistics()
    End Sub

    ' Sets up the ListViews; adds columns only if you haven't added them in the designer
    Private Sub EnsureColumns()
        lsvRequests.View = View.Details
        lsvRequests.FullRowSelect = True
        lsvRequests.HideSelection = False
        If lsvRequests.Columns.Count = 0 Then
            lsvRequests.Columns.Add("Request No.", 200)
            lsvRequests.Columns.Add("Student", 210)
            lsvRequests.Columns.Add("Status", 130)
            lsvRequests.Columns.Add("Amount", 100, HorizontalAlignment.Right)
        End If

        lsvTopDocs.View = View.Details
        lsvTopDocs.FullRowSelect = True
        lsvTopDocs.HideSelection = False
        If lsvTopDocs.Columns.Count = 0 Then
            lsvTopDocs.Columns.Add("Document", 230)
            lsvTopDocs.Columns.Add("Qty", 60, HorizontalAlignment.Right)
        End If
    End Sub

    ' Status text colors in the requests list (3rd column = Status)
    Private Function StatusColor(status As String) As Color
        Select Case status
            Case "Pending" : Return Color.FromArgb(122, 74, 5)
            Case "Processing" : Return Color.FromArgb(27, 63, 153)
            Case "Ready for Release" : Return Color.FromArgb(15, 110, 86)
            Case "Released" : Return Color.FromArgb(46, 95, 14)
            Case "Cancelled" : Return Color.FromArgb(142, 31, 26)
            Case Else : Return Color.FromArgb(11, 31, 92)
        End Select
    End Function

    Private Function CountOf(counts As Dictionary(Of String, Integer), key As String) As Integer
        Dim v As Integer = 0
        counts.TryGetValue(key, v)
        Return v
    End Function

    ' ================================================================ DATA
    Private Sub LoadStatistics()
        Dim d As Date = dtpDate.Value.Date

        Try
            Using conn As New MySqlConnection(ConnString)
                conn.Open()

                ' ---- 1) requests filed that day, grouped by status ----
                Dim counts As New Dictionary(Of String, Integer)
                Using c As New MySqlCommand("SELECT Status, COUNT(*) FROM tblrequest WHERE RequestDate = @d GROUP BY Status", conn)
                    c.Parameters.AddWithValue("@d", d)
                    Using r As MySqlDataReader = c.ExecuteReader()
                        While r.Read()
                            counts(r.GetString(0)) = Convert.ToInt32(r(1))
                        End While
                    End Using
                End Using

                lblRequests.Text = counts.Values.Sum().ToString("N0")
                lblPending.Text = CountOf(counts, "Pending").ToString("N0")
                lblProcessing.Text = CountOf(counts, "Processing").ToString("N0")
                lblReady.Text = CountOf(counts, "Ready for Release").ToString("N0")
                lblReleased.Text = CountOf(counts, "Released").ToString("N0")
                lblCancelled.Text = CountOf(counts, "Cancelled").ToString("N0")

                ' ---- 2) documents requested that day (cancelled excluded) ----
                Using c As New MySqlCommand(
                    "SELECT IFNULL(SUM(rd.Quantity), 0) FROM tblrequestdetails rd " &
                    "INNER JOIN tblrequest r ON rd.RequestID = r.RequestID " &
                    "WHERE r.RequestDate = @d AND r.Status <> 'Cancelled'", conn)
                    c.Parameters.AddWithValue("@d", d)
                    lblDocs.Text = Convert.ToInt32(c.ExecuteScalar()).ToString("N0")
                End Using

                ' ---- 3) revenue collected that day (paid requests by OR Date) ----
                Using c As New MySqlCommand(
                    "SELECT IFNULL(SUM(TotalAmount), 0) FROM tblrequest WHERE PaymentStatus = 'Paid' AND ORDate = @d", conn)
                    c.Parameters.AddWithValue("@d", d)
                    lblRevenue.Text = Peso & Convert.ToDecimal(c.ExecuteScalar()).ToString("N2")
                End Using

                ' ---- 4) requests filed that day ----
                lsvRequests.Items.Clear()
                Using c As New MySqlCommand(
                    "SELECT r.RequestNo, CONCAT(s.LastName, ', ', s.FirstName), r.Status, r.TotalAmount " &
                    "FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                    "WHERE r.RequestDate = @d ORDER BY r.RequestID DESC", conn)
                    c.Parameters.AddWithValue("@d", d)
                    Using r As MySqlDataReader = c.ExecuteReader()
                        While r.Read()
                            Dim lvi As New ListViewItem(r(0).ToString())
                            lvi.UseItemStyleForSubItems = False          ' lets the Status cell have its own color
                            lvi.SubItems.Add(r(1).ToString())
                            Dim st As String = r(2).ToString()
                            Dim stItem As ListViewItem.ListViewSubItem = lvi.SubItems.Add(st)
                            stItem.ForeColor = StatusColor(st)
                            stItem.Font = New Font(lsvRequests.Font, FontStyle.Bold)
                            lvi.SubItems.Add(Convert.ToDecimal(r(3)).ToString("N2"))
                            lsvRequests.Items.Add(lvi)
                        End While
                    End Using
                End Using
                If lsvRequests.Items.Count = 0 Then lsvRequests.Items.Add(New ListViewItem("No requests on this date."))

                ' ---- 5) top requested documents that day ----
                lsvTopDocs.Items.Clear()
                Using c As New MySqlCommand(
                    "SELECT d.DocumentName, SUM(rd.Quantity) AS Qty FROM tblrequestdetails rd " &
                    "INNER JOIN tbldocuments d ON rd.DocumentID = d.DocumentID " &
                    "INNER JOIN tblrequest r ON rd.RequestID = r.RequestID " &
                    "WHERE r.RequestDate = @d AND r.Status <> 'Cancelled' " &
                    "GROUP BY d.DocumentName ORDER BY Qty DESC, d.DocumentName LIMIT 5", conn)
                    c.Parameters.AddWithValue("@d", d)
                    Using r As MySqlDataReader = c.ExecuteReader()
                        While r.Read()
                            Dim lvi As New ListViewItem(r(0).ToString())
                            lvi.SubItems.Add(Convert.ToInt32(r(1)).ToString("N0"))
                            lsvTopDocs.Items.Add(lvi)
                        End While
                    End Using
                End Using
                If lsvTopDocs.Items.Count = 0 Then lsvTopDocs.Items.Add(New ListViewItem("No documents requested."))
            End Using

            lblSubtitle.Text = "Daily statistics for " & d.ToString("dddd, MMMM dd, yyyy") & "   |   Last refreshed " & DateTime.Now.ToString("hh:mm:ss tt")

        Catch ex As Exception
            lblSubtitle.Text = "Could not load statistics: " & ex.Message
        End Try
    End Sub

End Class