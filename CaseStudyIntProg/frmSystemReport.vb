Imports System.IO
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class frmSystemReport

    Private ReadOnly Peso As String = ChrW(8369)
    Private totalDocs As Integer = 0
    Private totalRevenue As Decimal = 0D

    Private Sub frmSystemReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboSelectReport.Items.Clear()
        cboSelectReport.Items.Add("Pending Request")
        cboSelectReport.Items.Add("Request by Document Type")
        cboSelectReport.Items.Add("Payment Report")
        cboSelectReport.Items.Add("Transaction History")

        ListViewReport.View = View.Details
        ListViewReport.GridLines = True
        ListViewReport.FullRowSelect = True

        btnPrintReport.Enabled = False
        btnExportCsv.Enabled = False
        ResetStats()
    End Sub

    Private Sub ResetStats()
        totalDocs = 0
        totalRevenue = 0D
        lblRecords.Text = "0"
        lblTotalDocumentsProcessed.Text = "0"
        lblTotalRevenue.Text = Peso & "0.00"
    End Sub

    Private Sub cboSelectReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectReport.SelectedIndexChanged
        ListViewReport.Clear()
        btnPrintReport.Enabled = False
        btnExportCsv.Enabled = False
        ResetStats()

        If cboSelectReport.Text = "Pending Request" Then
            ListViewReport.Columns.Add("Request No.", 220)
            ListViewReport.Columns.Add("Last Name", 150)
            ListViewReport.Columns.Add("First Name", 150)
            ListViewReport.Columns.Add("Request Date", 200)
            ListViewReport.Columns.Add("Total Amount", 130, HorizontalAlignment.Right)
        ElseIf cboSelectReport.Text = "Request by Document Type" Then
            ListViewReport.Columns.Add("Document Name", 300)
            ListViewReport.Columns.Add("Request No.", 320)
            ListViewReport.Columns.Add("Request Date", 200)
            ListViewReport.Columns.Add("Quantity", 130, HorizontalAlignment.Right)
            ListViewReport.Columns.Add("Subtotal", 150, HorizontalAlignment.Right)
        ElseIf cboSelectReport.Text = "Payment Report" Then
            ListViewReport.Columns.Add("OR No.", 200)
            ListViewReport.Columns.Add("OR Date", 200)
            ListViewReport.Columns.Add("Request No.", 320)
            ListViewReport.Columns.Add("Total Amount", 160, HorizontalAlignment.Right)
            ListViewReport.Columns.Add("Payment Status", 190)
        ElseIf cboSelectReport.Text = "Transaction History" Then
            ListViewReport.Columns.Add("Request No.", 220)
            ListViewReport.Columns.Add("Last Name", 150)
            ListViewReport.Columns.Add("First Name", 150)
            ListViewReport.Columns.Add("Request Date", 200)
            ListViewReport.Columns.Add("Amount", 130, HorizontalAlignment.Right)
            ListViewReport.Columns.Add("Payment Status", 160)
            ListViewReport.Columns.Add("Status", 180)
        End If
    End Sub

    ' ------------------------------------------- SHARED QUERY PARAMETERS
    ' Dates use .Value.Date (not .Text) so the query never depends on the date display format.
    ' The search box accepts a Last Name OR a Student ID (partial matches allowed).
    Private Sub AddFilterParams(c As MySqlCommand)
        c.Parameters.AddWithValue("@dateFrom", DateTimePickerDateFrom.Value.Date)
        c.Parameters.AddWithValue("@dateTo", DateTimePickerDateTo.Value.Date)
        c.Parameters.AddWithValue("@search", "%" & txtLastName.Text.Trim() & "%")
    End Sub

    ' Pressing Enter in the search box generates the report
    Private Sub txtLastName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLastName.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnGenerateResult.PerformClick()
        End If
    End Sub

    ' ------------------------------------------------------------- GENERATE
    Private Sub btnGenerateResult_Click(sender As Object, e As EventArgs) Handles btnGenerateResult.Click
        ' validate first, then confirm
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
        ResetStats()

        Try
            Call connection()

            If cboSelectReport.Text = "Pending Request" Then
                sql = "SELECT r.RequestNo, s.LastName, s.FirstName, r.RequestDate, r.TotalAmount " &
                      "FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                      "WHERE r.Status = 'Pending' AND r.RequestDate BETWEEN @dateFrom AND @dateTo " &
                      "AND (s.LastName LIKE @search OR s.StudentID LIKE @search) ORDER BY r.RequestDate, r.RequestNo"
            ElseIf cboSelectReport.Text = "Request by Document Type" Then
                sql = "SELECT d.DocumentName, r.RequestNo, r.RequestDate, rd.Quantity, rd.Subtotal " &
                      "FROM tblrequestdetails rd " &
                      "INNER JOIN tbldocuments d ON rd.DocumentID = d.DocumentID " &
                      "INNER JOIN tblrequest r ON rd.RequestID = r.RequestID " &
                      "INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                      "WHERE r.RequestDate BETWEEN @dateFrom AND @dateTo " &
                      "AND (s.LastName LIKE @search OR s.StudentID LIKE @search) " &
                      "ORDER BY d.DocumentName, r.RequestDate"
            ElseIf cboSelectReport.Text = "Payment Report" Then
                sql = "SELECT r.ORNo, r.ORDate, r.RequestNo, r.TotalAmount, r.PaymentStatus " &
                      "FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                      "WHERE r.PaymentStatus = 'Paid' AND r.ORDate BETWEEN @dateFrom AND @dateTo " &
                      "AND (s.LastName LIKE @search OR s.StudentID LIKE @search) ORDER BY r.ORDate, r.ORNo"
            ElseIf cboSelectReport.Text = "Transaction History" Then
                sql = "SELECT r.RequestNo, s.LastName, s.FirstName, r.RequestDate, r.TotalAmount, r.PaymentStatus, r.Status " &
                      "FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                      "WHERE r.RequestDate BETWEEN @dateFrom AND @dateTo " &
                      "AND (s.LastName LIKE @search OR s.StudentID LIKE @search) " &
                      "ORDER BY r.RequestDate DESC, r.RequestNo DESC"
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
                ElseIf cboSelectReport.Text = "Transaction History" Then
                    lv.SubItems.Add(dr(1).ToString())
                    lv.SubItems.Add(dr(2).ToString())
                    lv.SubItems.Add(Convert.ToDateTime(dr(3)).ToString("yyyy-MM-dd"))
                    lv.SubItems.Add(Convert.ToDecimal(dr(4)).ToString("N2"))
                    lv.SubItems.Add(dr(5).ToString())
                    lv.SubItems.Add(dr(6).ToString())
                End If

                ListViewReport.Items.Add(lv)
            End While
            dr.Close()

            ' ---------------- the three stats ----------------
            ' Records = rows in the list
            lblRecords.Text = ListViewReport.Items.Count.ToString("N0")

            ' Total documents processed = quantity in requests that are Processing / Ready for Release / Released
            ' (same date range + search filter). Use just 'Released' if you only want completed ones.
            Dim docSql As String =
                "SELECT IFNULL(SUM(rd.Quantity), 0) FROM tblrequestdetails rd " &
                "INNER JOIN tblrequest r ON rd.RequestID = r.RequestID " &
                "INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                "WHERE r.Status IN ('Processing','Ready for Release','Released') " &
                "AND r.RequestDate BETWEEN @dateFrom AND @dateTo " &
                "AND (s.LastName LIKE @search OR s.StudentID LIKE @search)"
            Using c As New MySqlCommand(docSql, cn)
                AddFilterParams(c)
                totalDocs = Convert.ToInt32(c.ExecuteScalar())
            End Using

            ' Total revenue generated = PAID requests, counted by OR Date (payment date)
            Dim revSql As String =
                "SELECT IFNULL(SUM(r.TotalAmount), 0) FROM tblrequest r " &
                "INNER JOIN tblstudents s ON r.StudentID = s.StudentID " &
                "WHERE r.PaymentStatus = 'Paid' " &
                "AND r.ORDate BETWEEN @dateFrom AND @dateTo " &
                "AND (s.LastName LIKE @search OR s.StudentID LIKE @search)"
            Using c As New MySqlCommand(revSql, cn)
                AddFilterParams(c)
                totalRevenue = Convert.ToDecimal(c.ExecuteScalar())
            End Using

            lblTotalDocumentsProcessed.Text = totalDocs.ToString("N0")
            lblTotalRevenue.Text = Peso & totalRevenue.ToString("N2")

            If ListViewReport.Items.Count > 0 Then
                btnPrintReport.Enabled = True
                btnExportCsv.Enabled = True
                MsgBox("Report generated successfully.", MsgBoxStyle.Information, "System Info")
            Else
                btnPrintReport.Enabled = False
                btnExportCsv.Enabled = False
                MsgBox("No records found for the selected parameters.", MsgBoxStyle.Information, "No Data")
            End If

        Catch ex As Exception
            MsgBox("Error generating report: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBox("Are you sure you want to clear the system report form?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Clear") = MsgBoxResult.Yes Then
            txtLastName.Clear()
            cboSelectReport.SelectedIndex = -1
            ListViewReport.Clear()
            DateTimePickerDateFrom.Value = DateTime.Now
            DateTimePickerDateTo.Value = DateTime.Now
            btnPrintReport.Enabled = False
            btnExportCsv.Enabled = False
            ResetStats()
        End If
    End Sub
    Private Function IsNumericColumn(headerText As String) As Boolean
        Return headerText.Contains("Amount") OrElse headerText.Contains("Subtotal") OrElse headerText.Contains("Quantity")
    End Function

    Private Sub AddTotalRow(tbl As PdfPTable, label As String, value As String, fLabel As iTextSharp.text.Font, fValue As iTextSharp.text.Font)
        Dim c1 As New PdfPCell(New Phrase(label, fLabel))
        c1.Border = iTextSharp.text.Rectangle.NO_BORDER
        c1.Padding = 3.0F
        Dim c2 As New PdfPCell(New Phrase(value, fValue))
        c2.Border = iTextSharp.text.Rectangle.NO_BORDER
        c2.Padding = 3.0F
        c2.HorizontalAlignment = Element.ALIGN_RIGHT
        tbl.AddCell(c1)
        tbl.AddCell(c2)
    End Sub
    Private Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        If ListViewReport.Items.Count = 0 Then
            MessageBox.Show("No data to export. Please generate a report first.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "PDF Files (*.pdf)|*.pdf"
        sfd.Title = "Save Report as PDF"

        Dim reportTitle As String = "System_Report"
        If Not String.IsNullOrWhiteSpace(cboSelectReport.Text) Then
            reportTitle = cboSelectReport.Text.Replace(" ", "_")
        End If
        sfd.FileName = reportTitle & "_" & DateTime.Now.ToString("yyyyMMdd") & ".pdf"

        If sfd.ShowDialog() = DialogResult.OK Then
            Try
                Dim navy As New BaseColor(11, 31, 92)
                Dim fSchool As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, navy)
                Dim fSub As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10)
                Dim fTitle As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, navy)
                Dim fHead As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, navy)
                Dim fBody As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA, 9)
                Dim fTot As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)

                Dim pdfDoc As New Document(PageSize.A4.Rotate(), 30.0F, 30.0F, 30.0F, 30.0F)
                Using fs As New FileStream(sfd.FileName, FileMode.Create)
                    PdfWriter.GetInstance(pdfDoc, fs)
                    pdfDoc.Open()

                    ' ---- letterhead ----
                    Dim pSchool As New Paragraph("LYCEUM OF ALABANG", fSchool)
                    pSchool.Alignment = Element.ALIGN_CENTER
                    pdfDoc.Add(pSchool)
                    Dim pSub As New Paragraph("Office of the Registrar - Document Request System", fSub)
                    pSub.Alignment = Element.ALIGN_CENTER
                    pSub.SpacingAfter = 10.0F
                    pdfDoc.Add(pSub)
                    Dim pTitle As New Paragraph(cboSelectReport.Text.ToUpper() & " REPORT", fTitle)
                    pTitle.Alignment = Element.ALIGN_CENTER
                    pTitle.SpacingAfter = 6.0F
                    pdfDoc.Add(pTitle)

                    Dim info As String = "Period: " & DateTimePickerDateFrom.Value.ToString("MMM dd, yyyy") & " to " & DateTimePickerDateTo.Value.ToString("MMM dd, yyyy") &
                                         "     Printed: " & DateTime.Now.ToString("MMM dd, yyyy hh:mm tt")
                    If txtLastName.Text.Trim() <> "" Then info &= "     Last Name / Student ID: " & txtLastName.Text.Trim()
                    Dim pInfo As New Paragraph(info, fBody)
                    pInfo.Alignment = Element.ALIGN_CENTER
                    pInfo.SpacingAfter = 10.0F
                    pdfDoc.Add(pInfo)

                    ' ---- table ----
                    Dim pdfTable As New PdfPTable(ListViewReport.Columns.Count)
                    pdfTable.WidthPercentage = 100
                    pdfTable.HeaderRows = 1

                    For Each col As ColumnHeader In ListViewReport.Columns
                        Dim cell As New PdfPCell(New Phrase(col.Text, fHead))
                        cell.BackgroundColor = New BaseColor(227, 235, 255)
                        cell.HorizontalAlignment = If(IsNumericColumn(col.Text), Element.ALIGN_RIGHT, Element.ALIGN_LEFT)
                        cell.Padding = 6.0F
                        pdfTable.AddCell(cell)
                    Next

                    For Each item As ListViewItem In ListViewReport.Items
                        For i As Integer = 0 To ListViewReport.Columns.Count - 1
                            Dim txt As String = If(i < item.SubItems.Count, item.SubItems(i).Text, "")
                            Dim dataCell As New PdfPCell(New Phrase(txt, fBody))
                            dataCell.Padding = 4.0F
                            dataCell.HorizontalAlignment = If(IsNumericColumn(ListViewReport.Columns(i).Text), Element.ALIGN_RIGHT, Element.ALIGN_LEFT)
                            pdfTable.AddCell(dataCell)
                        Next
                    Next
                    pdfDoc.Add(pdfTable)

                    ' ---- summary ----
                    Dim tot As New PdfPTable(2)
                    tot.WidthPercentage = 40
                    tot.HorizontalAlignment = Element.ALIGN_RIGHT
                    tot.SpacingBefore = 12.0F
                    AddTotalRow(tot, "Records:", ListViewReport.Items.Count.ToString("N0"), fBody, fTot)
                    AddTotalRow(tot, "Total Documents Processed:", totalDocs.ToString("N0"), fTot, fTot)
                    AddTotalRow(tot, "Total Revenue Generated:", "PHP " & totalRevenue.ToString("N2"), fTot, fTot)
                    pdfDoc.Add(tot)

                    ' ---- signatures ----
                    Dim sig As New Paragraph("Prepared by: ______________________          Verified by: ______________________", fBody)
                    sig.SpacingBefore = 36.0F
                    pdfDoc.Add(sig)

                    pdfDoc.Close()
                End Using

                MessageBox.Show("PDF exported successfully to:" & vbCrLf & sfd.FileName, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error generating PDF. Ensure the file is not open in another program." & vbCrLf & "Details: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function CsvField(text As String) As String
        Return """" & text.Replace("""", """""") & """"      ' keeps commas inside values intact
    End Function

    Private Sub btnExportCsv_Click(sender As Object, e As EventArgs) Handles btnExportCsv.Click
        If ListViewReport.Items.Count = 0 Then
            MessageBox.Show("No data to export. Please generate a report first.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MsgBox("Are you sure you want to export this data to CSV?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Export") = MsgBoxResult.Yes Then
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv"
            saveFileDialog1.Title = "Save System Report Export"

            Dim reportTitle As String = "System_Report"
            If Not String.IsNullOrWhiteSpace(cboSelectReport.Text) Then
                reportTitle = cboSelectReport.Text.Replace(" ", "_")
            End If
            saveFileDialog1.FileName = reportTitle & "_" & DateTime.Now.ToString("yyyyMMdd") & ".csv"

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Try
                    Dim sb As New System.Text.StringBuilder()
                    Dim totalCols As Integer = ListViewReport.Columns.Count

                    sb.AppendLine(CsvField(cboSelectReport.Text & " Report"))
                    sb.AppendLine(CsvField("Period: " & DateTimePickerDateFrom.Value.ToString("yyyy-MM-dd") & " to " & DateTimePickerDateTo.Value.ToString("yyyy-MM-dd")))
                    If txtLastName.Text.Trim() <> "" Then sb.AppendLine(CsvField("Last Name / Student ID: " & txtLastName.Text.Trim()))
                    sb.AppendLine()

                    Dim headers As New List(Of String)
                    For Each col As ColumnHeader In ListViewReport.Columns
                        headers.Add(CsvField(col.Text))
                    Next
                    sb.AppendLine(String.Join(",", headers))

                    For Each item As ListViewItem In ListViewReport.Items
                        Dim cells As New List(Of String)
                        For i As Integer = 0 To totalCols - 1
                            cells.Add(CsvField(If(i < item.SubItems.Count, item.SubItems(i).Text, "")))
                        Next
                        sb.AppendLine(String.Join(",", cells))
                    Next

                    sb.AppendLine()
                    sb.AppendLine(CsvField("Records") & "," & ListViewReport.Items.Count)
                    sb.AppendLine(CsvField("Total Documents Processed") & "," & totalDocs)
                    sb.AppendLine(CsvField("Total Revenue Generated") & "," & totalRevenue.ToString("F2"))

                    File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), New System.Text.UTF8Encoding(True))
                    MsgBox("Successfully exported file to: " & vbCrLf & saveFileDialog1.FileName, MsgBoxStyle.Information, "Export Success")
                Catch ex As Exception
                    MsgBox("Failed to export report: " & ex.Message, MsgBoxStyle.Critical, "Export Error")
                End Try
            End If
        End If
    End Sub
End Class