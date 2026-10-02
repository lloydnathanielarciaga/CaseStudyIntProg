Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frmSystemReport

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
        btnExportCSV.Enabled = False
    End Sub

    Private Sub cboSelectReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectReport.SelectedIndexChanged
        ListViewReport.Clear()
        btnPrintReport.Enabled = False
        btnExportCSV.Enabled = False

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
        ElseIf cboSelectReport.Text = "Transaction History" Then ' Add this block
            ListViewReport.Columns.Add("Request No.", 120)
            ListViewReport.Columns.Add("Last Name", 120)
            ListViewReport.Columns.Add("First Name", 120)
            ListViewReport.Columns.Add("Request Date", 100)
            ListViewReport.Columns.Add("Amount", 100)
            ListViewReport.Columns.Add("Payment Status", 100)
            ListViewReport.Columns.Add("Status", 120)
        End If
    End Sub

    Private Sub btnGenerateResult_Click(sender As Object, e As EventArgs) Handles btnGenerateResult.Click
        If MsgBox("Are you sure you want to generate this report?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Generation") = MsgBoxResult.No Then
            Exit Sub
        End If

        If cboSelectReport.SelectedIndex = -1 Then
            MsgBox("Please select a report type.", MsgBoxStyle.Exclamation, "Validation Error")
            cboSelectReport.Focus()
            Exit Sub
        End If

        If DateTimePickerDateFrom.Value > DateTimePickerDateTo.Value Then
            MsgBox("Date From cannot be greater than Date To.", MsgBoxStyle.Exclamation, "Validation Error")
            DateTimePickerDateFrom.Focus()
            Exit Sub
        End If

        ListViewReport.Items.Clear()

        Try
            Call connection()

            If cboSelectReport.Text = "Pending Request" Then
                sql = "SELECT r.RequestNo, s.LastName, s.FirstName, r.RequestDate, r.TotalAmount FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID WHERE r.Status = 'Pending' AND r.RequestDate BETWEEN @dateFrom AND @dateTo"
            ElseIf cboSelectReport.Text = "Request by Document Type" Then
                sql = "SELECT d.DocumentName, r.RequestNo, r.RequestDate, rd.Quantity, rd.Subtotal FROM tblrequestdetails rd INNER JOIN tbldocuments d ON rd.DocumentID = d.DocumentID INNER JOIN tblrequest r ON rd.RequestID = r.RequestID WHERE r.RequestDate BETWEEN @dateFrom AND @dateTo ORDER BY d.DocumentName"
            ElseIf cboSelectReport.Text = "Payment Report" Then
                sql = "SELECT ORNo, ORDate, RequestNo, TotalAmount, PaymentStatus FROM tblrequest WHERE PaymentStatus = 'Paid' AND ORDate BETWEEN @dateFrom AND @dateTo"
            ElseIf cboSelectReport.Text = "Transaction History" Then
                sql = "SELECT r.RequestNo, s.LastName, s.FirstName, r.RequestDate, r.TotalAmount, r.PaymentStatus, r.Status FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID WHERE r.RequestDate BETWEEN @dateFrom AND @dateTo ORDER BY r.RequestDate DESC"
            End If

            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@dateFrom", DateTimePickerDateFrom.Text)
            cmd.Parameters.AddWithValue("@dateTo", DateTimePickerDateTo.Text)

            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim lv As New ListViewItem(dr(0).ToString())

                If cboSelectReport.Text = "Pending Request" Then
                    lv.SubItems.Add(dr(1).ToString())
                    lv.SubItems.Add(dr(2).ToString())
                    lv.SubItems.Add(Convert.ToDateTime(dr(3)).ToString("yyyy-MM-dd"))
                    lv.SubItems.Add(dr(4).ToString())
                ElseIf cboSelectReport.Text = "Request by Document Type" Then
                    lv.SubItems.Add(dr(1).ToString())
                    lv.SubItems.Add(Convert.ToDateTime(dr(2)).ToString("yyyy-MM-dd"))
                    lv.SubItems.Add(dr(3).ToString())
                    lv.SubItems.Add(dr(4).ToString())
                ElseIf cboSelectReport.Text = "Payment Report" Then
                    If IsDBNull(dr(1)) Then
                        lv.SubItems.Add("N/A")
                    Else
                        lv.SubItems.Add(Convert.ToDateTime(dr(1)).ToString("yyyy-MM-dd"))
                    End If
                    lv.SubItems.Add(dr(2).ToString())
                    lv.SubItems.Add(dr(3).ToString())
                    lv.SubItems.Add(dr(4).ToString())
                ElseIf cboSelectReport.Text = "Transaction History" Then
                    lv.SubItems.Add(dr(1).ToString())
                    lv.SubItems.Add(dr(2).ToString())
                    lv.SubItems.Add(Convert.ToDateTime(dr(3)).ToString("yyyy-MM-dd"))
                    lv.SubItems.Add(dr(4).ToString())
                    lv.SubItems.Add(dr(5).ToString())
                    lv.SubItems.Add(dr(6).ToString())
                End If

                ListViewReport.Items.Add(lv)
            End While

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
            cn.Close()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBox("Are you sure you want to clear the system report form?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Clear") = MsgBoxResult.Yes Then
            cboSelectReport.SelectedIndex = -1
            ListViewReport.Clear()
            DateTimePickerDateFrom.Value = DateTime.Now
            DateTimePickerDateTo.Value = DateTime.Now
            btnPrintReport.Enabled = False
            btnExportCSV.Enabled = False
        End If
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
        Dim currentDate As String = DateTime.Now.ToString("yyyyMMdd")

        sfd.FileName = reportTitle & "_" & currentDate & ".pdf"

        If sfd.ShowDialog() = DialogResult.OK Then
            Try
                Dim pdfDoc As New Document(PageSize.A4.Rotate(), 10.0F, 10.0F, 10.0F, 0.0F)
                Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create))

                pdfDoc.Open()

                Dim titleFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)
                Dim pdfTitle As New Paragraph(cboSelectReport.Text & " - Generated: " & DateTime.Now.ToString("yyyy-MM-dd"), titleFont)
                pdfTitle.Alignment = Element.ALIGN_CENTER
                pdfTitle.SpacingAfter = 15.0F
                pdfDoc.Add(pdfTitle)

                Dim pdfTable As New PdfPTable(ListViewReport.Columns.Count)
                pdfTable.WidthPercentage = 100

                For Each col As ColumnHeader In ListViewReport.Columns
                    Dim cell As New PdfPCell(New Phrase(col.Text))
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    cell.Padding = 5.0F
                    pdfTable.AddCell(cell)
                Next

                For Each item As ListViewItem In ListViewReport.Items
                    For i As Integer = 0 To ListViewReport.Columns.Count - 1
                        If i < item.SubItems.Count Then
                            Dim dataCell As New PdfPCell(New Phrase(item.SubItems(i).Text))
                            dataCell.Padding = 3.0F
                            pdfTable.AddCell(dataCell)
                        Else
                            pdfTable.AddCell(New PdfPCell(New Phrase("")))
                        End If
                    Next
                Next

                pdfDoc.Add(pdfTable)
                pdfDoc.Close()

                MessageBox.Show("PDF exported successfully to:" & vbCrLf & sfd.FileName, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error generating PDF. Ensure the file is not open in another program." & vbCrLf & "Details: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub PrintPageHandler(sender As Object, e As Printing.PrintPageEventArgs)
        Dim boldFont As New System.Drawing.Font("Arial", 10, FontStyle.Bold)
        Dim normalFont As New System.Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim brush As New SolidBrush(Color.Black)

        Dim startX As Integer = 50
        Dim startY As Integer = 50
        Dim currentX As Integer = startX

        For Each col As ColumnHeader In ListViewReport.Columns
            e.Graphics.DrawString(col.Text, boldFont, brush, currentX, startY)
            currentX += col.Width
        Next

        startY += 25
        e.Graphics.DrawLine(New Pen(Color.Black, 2), startX, startY, currentX, startY)
        startY += 10

        For Each item As ListViewItem In ListViewReport.Items
            currentX = startX

            For i As Integer = 0 To item.SubItems.Count - 1
                e.Graphics.DrawString(item.SubItems(i).Text, normalFont, brush, currentX, startY)

                If i < ListViewReport.Columns.Count Then
                    currentX += ListViewReport.Columns(i).Width
                End If
            Next
            startY += 25
        Next
    End Sub

    Private Sub btnExportCSV_Click(sender As Object, e As EventArgs) Handles btnExportCSV.Click
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
            Dim currentDate As String = DateTime.Now.ToString("yyyyMMdd")

            saveFileDialog1.FileName = reportTitle & "_" & currentDate & ".csv"

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Try
                    Dim exportData As String = ""
                    Dim totalCols As Integer = ListViewReport.Columns.Count

                    For colIndex As Integer = 0 To totalCols - 1
                        exportData &= ListViewReport.Columns(colIndex).Text
                        If colIndex < totalCols - 1 Then exportData &= ","
                    Next
                    exportData &= vbCrLf

                    For rowIndex As Integer = 0 To ListViewReport.Items.Count - 1
                        For subColIndex As Integer = 0 To totalCols - 1
                            exportData &= ListViewReport.Items(rowIndex).SubItems(subColIndex).Text.Replace(",", "")
                            If subColIndex < totalCols - 1 Then exportData &= ","
                        Next
                        exportData &= vbCrLf
                    Next

                    My.Computer.FileSystem.WriteAllText(saveFileDialog1.FileName, exportData, False)
                    MsgBox("Successfully exported file to: " & vbCrLf & saveFileDialog1.FileName, MsgBoxStyle.Information, "Export Success")
                Catch ex As Exception
                    MsgBox("Failed to export report: " & ex.Message, MsgBoxStyle.Critical, "Export Error")
                End Try
            End If
        End If
    End Sub

End Class