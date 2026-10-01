Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Drawing.Printing

Public Class frmSystemReport

    Private ReadOnly Peso As String = ChrW(8369)   ' peso sign
    Private totalDocs As Integer = 0
    Private totalRevenue As Decimal = 0D
    Private printRow As Integer = 0
    Private pageNo As Integer = 1

    ' ------------------------------------------------------------------ LOAD
    Private Sub frmSystemReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboSelectReport.Items.Clear()
        cboSelectReport.Items.Add("Pending Request")
        cboSelectReport.Items.Add("Request by Document Type")
        cboSelectReport.Items.Add("Payment Report")

        ListViewReport.View = View.Details
        ListViewReport.GridLines = True
        ListViewReport.FullRowSelect = True

        btnPrintReport.Enabled = False
        btnExportCSV.Enabled = False
        ResetTotals()
    End Sub

    Private Sub ResetTotals()
        totalDocs = 0
        totalRevenue = 0D
        lblTotalDocs.Text = "Total Documents Processed: 0"
        lblTotalRevenue.Text = "Total Revenue Generated: " & Peso & "0.00"
    End Sub

    ' -------------------------------------------------------- REPORT COLUMNS
    Private Sub cboSelectReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectReport.SelectedIndexChanged
        ListViewReport.Clear()
        btnPrintReport.Enabled = False
        btnExportCSV.Enabled = False
        ResetTotals()

        If cboSelectReport.Text = "Pending Request" Then
            ListViewReport.Columns.Add("Request No.", 120)
            ListViewReport.Columns.Add("Last Name", 120)
            ListViewReport.Columns.Add("First Name", 120)
            ListViewReport.Columns.Add("Request Date", 100)
            ListViewReport.Columns.Add("Total Amount", 100)
        ElseIf cboSelectReport.Text = "Request by Document Type" Then
            ListViewReport.Columns.Add("Document Name", 200)
            ListViewReport.Columns.Add("Request No.", 120)
            ListViewReport.Columns.Add("Request Date", 100)
            ListViewReport.Columns.Add("Quantity", 80)
            ListViewReport.Columns.Add("Subtotal", 100)
        ElseIf cboSelectReport.Text = "Payment Report" Then
            ListViewReport.Columns.Add("OR No.", 120)
            ListViewReport.Columns.Add("OR Date", 100)
            ListViewReport.Columns.Add("Request No.", 120)
            ListViewReport.Columns.Add("Total Amount", 100)
            ListViewReport.Columns.Add("Payment Status", 120)
        End If
    End Sub

    ' ------------------------------------------------- SHARED PARAMETER HELPER
    ' Dates use .Value.Date (NOT .Text) so the query never depends on the PC's date format.
    Private Sub AddFilterParams(c As MySqlCommand)
        c.Parameters.AddWithValue("@dateFrom", DateTimePickerDateFrom.Value.Date)
        c.Parameters.AddWithValue("@dateTo", DateTimePickerDateTo.Value.Date)
        c.Parameters.AddWithValue("@lastName", "%" & txtLastName.Text.Trim() & "%")
    End Sub

    ' ------------------------------------------------------------- GENERATE
    Private Sub btnGenerateResult_Click(sender As Object, e As EventArgs) Handles btnGenerateResult.Click
        ' Validate FIRST, then confirm
        If cboSelectReport.SelectedIndex = -1 Then
            MsgBox("Please select a report type.", MsgBoxStyle.Exclamation, "Validation Error")
            cboSelectReport.Focus()
            Exit Sub
        End If

        If DateTimePickerDateFrom.Value.Date > DateTimePickerDateTo.Value.Date Then
            MsgBox("Date From cannot be greater than Date To.", MsgBoxStyle.Exclamation, "Validation Error")
            DateTimePickerDateFrom.Focus()
            Exit Sub
        End If

        If MsgBox("Are you sure you want to generate this report?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Generation") = MsgBoxResult.No Then
            Exit Sub
        End If

        ListViewReport.Items.Clear()
        ResetTotals()

        Try
            Call connection()

            If cboSelectReport.Text = "Pending Request" Then
                sql = "SELECT r.RequestNo, s.LastName, s.FirstName, r.RequestDate, r.TotalAmount " &
                      "FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                      "WHERE r.Status = 'Pending' AND r.RequestDate BETWEEN @dateFrom AND @dateTo " &
                      "AND s.LastName LIKE @lastName ORDER BY r.RequestDate, r.RequestNo"
            ElseIf cboSelectReport.Text = "Request by Document Type" Then
                sql = "SELECT d.DocumentName, r.RequestNo, r.RequestDate, rd.Quantity, rd.Subtotal " &
                      "FROM tblrequestdetails rd " &
                      "INNER JOIN tbldocuments d ON rd.DocumentID = d.DocumentID " &
                      "INNER JOIN tblrequest r ON rd.RequestID = r.RequestID " &
                      "INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                      "WHERE r.RequestDate BETWEEN @dateFrom AND @dateTo AND s.LastName LIKE @lastName " &
                      "ORDER BY d.DocumentName, r.RequestDate"
            ElseIf cboSelectReport.Text = "Payment Report" Then
                sql = "SELECT r.ORNo, r.ORDate, r.RequestNo, r.TotalAmount, r.PaymentStatus " &
                      "FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                      "WHERE r.PaymentStatus = 'Paid' AND r.ORDate BETWEEN @dateFrom AND @dateTo " &
                      "AND s.LastName LIKE @lastName ORDER BY r.ORDate, r.ORNo"
            End If

            cmd = New MySqlCommand(sql, cn)
            AddFilterParams(cmd)
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim lv As New ListViewItem(dr(0).ToString())

                If cboSelectReport.Text = "Pending Request" Then
                    lv.SubItems.Add(dr(1).ToString())
                    lv.SubItems.Add(dr(2).ToString())
                    lv.SubItems.Add(Convert.ToDateTime(dr(3)).ToString("yyyy-MM-dd"))
                    lv.SubItems.Add(Convert.ToDecimal(dr(4)).ToString("N2"))
                ElseIf cboSelectReport.Text = "Request by Document Type" Then
                    lv.SubItems.Add(dr(1).ToString())
                    lv.SubItems.Add(Convert.ToDateTime(dr(2)).ToString("yyyy-MM-dd"))
                    lv.SubItems.Add(dr(3).ToString())
                    lv.SubItems.Add(Convert.ToDecimal(dr(4)).ToString("N2"))
                ElseIf cboSelectReport.Text = "Payment Report" Then
                    If IsDBNull(dr(1)) Then
                        lv.SubItems.Add("N/A")
                    Else
                        lv.SubItems.Add(Convert.ToDateTime(dr(1)).ToString("yyyy-MM-dd"))
                    End If
                    lv.SubItems.Add(dr(2).ToString())
                    lv.SubItems.Add(Convert.ToDecimal(dr(3)).ToString("N2"))
                    lv.SubItems.Add(dr(4).ToString())
                End If

                ListViewReport.Items.Add(lv)
            End While
            dr.Close()

            ' ---- Summary totals (same date range + last name filter) ----
            ' Documents Processed = quantity of documents in requests already
            ' Processing / Ready for Release / Released (not Pending, not Cancelled).
            ' Change the IN (...) list to just 'Released' if you only count completed ones.
            Dim docSql As String =
                "SELECT IFNULL(SUM(rd.Quantity), 0) FROM tblrequestdetails rd " &
                "INNER JOIN tblrequest r ON rd.RequestID = r.RequestID " &
                "INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                "WHERE r.Status IN ('Processing','Ready for Release','Released') " &
                "AND r.RequestDate BETWEEN @dateFrom AND @dateTo AND s.LastName LIKE @lastName"
            Using c As New MySqlCommand(docSql, cn)
                AddFilterParams(c)
                totalDocs = Convert.ToInt32(c.ExecuteScalar())
            End Using

            ' Revenue Generated = total of PAID requests, by OR Date (payment date).
            Dim revSql As String =
                "SELECT IFNULL(SUM(r.TotalAmount), 0) FROM tblrequest r " &
                "INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                "WHERE r.PaymentStatus = 'Paid' " &
                "AND r.ORDate BETWEEN @dateFrom AND @dateTo AND s.LastName LIKE @lastName"
            Using c As New MySqlCommand(revSql, cn)
                AddFilterParams(c)
                totalRevenue = Convert.ToDecimal(c.ExecuteScalar())
            End Using

            lblTotalDocs.Text = "Total Documents Processed: " & totalDocs.ToString("N0")
            lblTotalRevenue.Text = "Total Revenue Generated: " & Peso & totalRevenue.ToString("N2")

            If ListViewReport.Items.Count > 0 Then
                btnPrintReport.Enabled = True
                btnExportCSV.Enabled = True
                MsgBox("Report generated successfully.", MsgBoxStyle.Information, "System Info")
            Else
                btnPrintReport.Enabled = False
                btnExportCSV.Enabled = False
                MsgBox("No records found for the selected parameters.", MsgBoxStyle.Information, "No Data")
            End If

        Catch ex As Exception
            MsgBox("Error generating report: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    ' ---------------------------------------------------------------- CLEAR
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBox("Are you sure you want to clear the system report form?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Clear") = MsgBoxResult.Yes Then
            txtLastName.Clear()
            cboSelectReport.SelectedIndex = -1
            ListViewReport.Clear()
            DateTimePickerDateFrom.Value = DateTime.Now
            DateTimePickerDateTo.Value = DateTime.Now
            btnPrintReport.Enabled = False
            btnExportCSV.Enabled = False
            ResetTotals()
        End If
    End Sub

    ' --------------------------------------------------------------- PRINT
    ' Opens a print preview; the user can print or choose "Microsoft Print to PDF".
    Private Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        printRow = 0
        pageNo = 1

        Dim pd As New PrintDocument()
        pd.DefaultPageSettings.Margins = New Margins(60, 60, 50, 60)
        AddHandler pd.PrintPage, AddressOf PrintPageHandler

        Using pv As New PrintPreviewDialog()
            pv.Document = pd
            pv.WindowState = FormWindowState.Maximized
            pv.ShowDialog()
        End Using
        RemoveHandler pd.PrintPage, AddressOf PrintPageHandler
    End Sub

    Private Function IsNumericColumn(headerText As String) As Boolean
        Return headerText.Contains("Amount") OrElse headerText.Contains("Subtotal") OrElse headerText.Contains("Quantity")
    End Function

    Private Sub PrintPageHandler(sender As Object, e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim left As Single = e.MarginBounds.Left
        Dim right As Single = e.MarginBounds.Right
        Dim w As Single = e.MarginBounds.Width
        Dim y As Single = e.MarginBounds.Top

        Dim navy As Color = Color.FromArgb(11, 31, 92)
        Dim ctr As New StringFormat() With {.Alignment = StringAlignment.Center}
        Dim rgt As New StringFormat() With {.Alignment = StringAlignment.Far}
        Dim lft As New StringFormat() With {.Trimming = StringTrimming.EllipsisCharacter, .FormatFlags = StringFormatFlags.NoWrap}

        Using fSchool As New Font("Georgia", 17, FontStyle.Bold),
              fSub As New Font("Arial", 10),
              fTitle As New Font("Arial", 13, FontStyle.Bold),
              fHead As New Font("Arial", 9, FontStyle.Bold),
              fBody As New Font("Arial", 9),
              fTot As New Font("Arial", 11, FontStyle.Bold),
              bNavy As New SolidBrush(navy),
              bShade As New SolidBrush(Color.FromArgb(227, 235, 255)),
              bAlt As New SolidBrush(Color.FromArgb(246, 248, 255)),
              pLine As New Pen(navy, 1.6F),
              pThin As New Pen(Color.LightGray, 0.6F)

            ' ---------- letterhead (page 1 only) ----------
            If pageNo = 1 Then
                g.DrawString("LYCEUM OF ALABANG", fSchool, bNavy, New RectangleF(left, y, w, 28), ctr) : y += 28
                g.DrawString("Office of the Registrar - Document Request System", fSub, Brushes.Black, New RectangleF(left, y, w, 18), ctr) : y += 24
                g.DrawLine(pLine, left, y, right, y) : y += 10
                g.DrawString(cboSelectReport.Text.ToUpper() & " REPORT", fTitle, bNavy, New RectangleF(left, y, w, 22), ctr) : y += 30

                g.DrawString("Period: " & DateTimePickerDateFrom.Value.ToString("MMM dd, yyyy") & " to " & DateTimePickerDateTo.Value.ToString("MMM dd, yyyy"), fBody, Brushes.Black, left, y)
                g.DrawString("Date Printed: " & DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), fBody, Brushes.Black, New RectangleF(left, y, w, 16), rgt) : y += 16
                If txtLastName.Text.Trim() <> "" Then
                    g.DrawString("Student Last Name: " & txtLastName.Text.Trim(), fBody, Brushes.Black, left, y) : y += 16
                End If
                y += 8
            Else
                g.DrawString(cboSelectReport.Text.ToUpper() & " REPORT (continued)", fHead, bNavy, left, y) : y += 24
            End If

            ' ---------- column layout scaled to page width ----------
            Dim totalW As Single = 0
            For Each c As ColumnHeader In ListViewReport.Columns : totalW += c.Width : Next
            Dim colX(ListViewReport.Columns.Count) As Single
            Dim colW(ListViewReport.Columns.Count - 1) As Single
            colX(0) = left
            For i As Integer = 0 To ListViewReport.Columns.Count - 1
                colW(i) = ListViewReport.Columns(i).Width / totalW * w
                colX(i + 1) = colX(i) + colW(i)
            Next

            ' ---------- header row ----------
            g.FillRectangle(bShade, left, y, w, 24)
            For i As Integer = 0 To ListViewReport.Columns.Count - 1
                Dim fmt As StringFormat = If(IsNumericColumn(ListViewReport.Columns(i).Text), rgt, lft)
                g.DrawString(ListViewReport.Columns(i).Text, fHead, bNavy, New RectangleF(colX(i) + 4, y + 5, colW(i) - 8, 16), fmt)
            Next
            y += 24
            g.DrawLine(pLine, left, y, right, y)

            ' ---------- rows ----------
            Dim rowH As Single = 22
            Dim reserve As Single = 130   ' room kept for totals + signatures on last page

            While printRow < ListViewReport.Items.Count
                If y + rowH > e.MarginBounds.Bottom - reserve Then
                    DrawFooter(g, e, fBody, ctr)
                    pageNo += 1
                    e.HasMorePages = True
                    Return
                End If

                If printRow Mod 2 = 1 Then g.FillRectangle(bAlt, left, y, w, rowH)
                Dim item As ListViewItem = ListViewReport.Items(printRow)
                For i As Integer = 0 To ListViewReport.Columns.Count - 1
                    Dim fmt As StringFormat = If(IsNumericColumn(ListViewReport.Columns(i).Text), rgt, lft)
                    g.DrawString(item.SubItems(i).Text, fBody, Brushes.Black, New RectangleF(colX(i) + 4, y + 4, colW(i) - 8, 16), fmt)
                Next
                y += rowH
                g.DrawLine(pThin, left, y, right, y)
                printRow += 1
            End While

            ' ---------- totals ----------
            y += 12
            g.DrawLine(pLine, left, y, right, y) : y += 8
            g.DrawString("Total Records:", fBody, Brushes.Black, left, y)
            g.DrawString(ListViewReport.Items.Count.ToString(), fBody, Brushes.Black, New RectangleF(left, y, w, 16), rgt) : y += 20
            g.DrawString("Total Documents Processed:", fTot, Brushes.Black, left, y)
            g.DrawString(totalDocs.ToString("N0"), fTot, bNavy, New RectangleF(left, y, w, 20), rgt) : y += 24
            g.DrawString("Total Revenue Generated:", fTot, Brushes.Black, left, y)
            g.DrawString("PHP " & totalRevenue.ToString("N2"), fTot, bNavy, New RectangleF(left, y, w, 20), rgt) : y += 26
            g.DrawLine(pLine, left, y, right, y) : y += 40

            ' ---------- signatures ----------
            g.DrawLine(Pens.Black, left, y, left + 190, y)
            g.DrawString("Prepared by (Registrar Staff)", fBody, Brushes.Black, left, y + 3)
            g.DrawLine(Pens.Black, right - 190, y, right, y)
            g.DrawString("Verified by", fBody, Brushes.Black, right - 190, y + 3)

            DrawFooter(g, e, fBody, ctr)
            e.HasMorePages = False
            printRow = 0
            pageNo = 1
        End Using
    End Sub

    Private Sub DrawFooter(g As Graphics, e As PrintPageEventArgs, f As Font, ctr As StringFormat)
        g.DrawString("Page " & pageNo.ToString(), f, Brushes.Gray,
                     New RectangleF(e.MarginBounds.Left, e.MarginBounds.Bottom + 15, e.MarginBounds.Width, 16), ctr)
    End Sub

    ' ------------------------------------------------------------ EXPORT CSV
    Private Function CsvField(text As String) As String
        Return """" & text.Replace("""", """""") & """"      ' keeps commas inside values intact
    End Function

    Private Sub btnExportCSV_Click(sender As Object, e As EventArgs) Handles btnExportCSV.Click
        If MsgBox("Are you sure you want to export this data to CSV?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Export") = MsgBoxResult.Yes Then
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv"
            saveFileDialog1.Title = "Save System Report Export"
            saveFileDialog1.FileName = cboSelectReport.Text.Replace(" ", "") & "Export.csv"

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Try
                    Dim sb As New StringBuilder()
                    Dim totalCols As Integer = ListViewReport.Columns.Count

                    sb.AppendLine(CsvField(cboSelectReport.Text & " Report"))
                    sb.AppendLine(CsvField("Period: " & DateTimePickerDateFrom.Value.ToString("yyyy-MM-dd") & " to " & DateTimePickerDateTo.Value.ToString("yyyy-MM-dd")))
                    If txtLastName.Text.Trim() <> "" Then sb.AppendLine(CsvField("Student Last Name: " & txtLastName.Text.Trim()))
                    sb.AppendLine()

                    sb.AppendLine(String.Join(",", ListViewReport.Columns.Cast(Of ColumnHeader)().Select(Function(c) CsvField(c.Text))))

                    For Each item As ListViewItem In ListViewReport.Items
                        Dim cells As New List(Of String)
                        For i As Integer = 0 To totalCols - 1
                            cells.Add(CsvField(item.SubItems(i).Text))
                        Next
                        sb.AppendLine(String.Join(",", cells))
                    Next

                    sb.AppendLine()
                    sb.AppendLine(CsvField("Total Documents Processed") & "," & totalDocs)
                    sb.AppendLine(CsvField("Total Revenue Generated") & "," & totalRevenue.ToString("F2"))

                    File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), New UTF8Encoding(True))
                    MsgBox("Successfully exported file to: " & saveFileDialog1.FileName, MsgBoxStyle.Information, "Export Success")
                Catch ex As Exception
                    MsgBox("Failed to export report: " & ex.Message, MsgBoxStyle.Critical, "Export Error")
                End Try
            End If
        End If
    End Sub
End Class