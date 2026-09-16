Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmSystemReport
    Private Sub frmSystemReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboSelectReport.Items.Clear()
        cboSelectReport.Items.Add("Student Request Masterlist")
        cboSelectReport.Items.Add("Payment Collection Report")
        cboSelectReport.Items.Add("Document Request Summary")

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

        If cboSelectReport.Text = "Student Request Masterlist" Then
            ListViewReport.Columns.Add("Request No.", 120)
            ListViewReport.Columns.Add("Last Name", 120)
            ListViewReport.Columns.Add("First Name", 120)
            ListViewReport.Columns.Add("Request Date", 100)
            ListViewReport.Columns.Add("Total Amount", 100)
            ListViewReport.Columns.Add("Status", 100)
        ElseIf cboSelectReport.Text = "Payment Collection Report" Then
            ListViewReport.Columns.Add("OR No.", 120)
            ListViewReport.Columns.Add("OR Date", 100)
            ListViewReport.Columns.Add("Request No.", 120)
            ListViewReport.Columns.Add("Amount Paid", 100)
            ListViewReport.Columns.Add("Payment Status", 120)
        ElseIf cboSelectReport.Text = "Document Request Summary" Then
            ListViewReport.Columns.Add("Document Name", 200)
            ListViewReport.Columns.Add("Total Requests", 120)
            ListViewReport.Columns.Add("Total Revenue", 120)
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

            If cboSelectReport.Text = "Student Request Masterlist" Then
                sql = "SELECT r.RequestNo, s.LastName, s.FirstName, r.RequestDate, r.TotalAmount, r.Status FROM tblrequest r INNER JOIN tblstudents s ON r.StudentID = s.StudentID WHERE r.RequestDate BETWEEN @dateFrom AND @dateTo"
            ElseIf cboSelectReport.Text = "Payment Collection Report" Then
                sql = "SELECT ORNo, ORDate, RequestNo, TotalAmount, PaymentStatus FROM tblrequest WHERE PaymentStatus = 'Paid' AND ORDate BETWEEN @dateFrom AND @dateTo"
            ElseIf cboSelectReport.Text = "Document Request Summary" Then
                sql = "SELECT d.DocumentName, SUM(rd.Quantity), SUM(rd.Subtotal) FROM tblrequestdetails rd INNER JOIN tbldocuments d ON rd.DocumentID = d.DocumentID INNER JOIN tblrequest r ON rd.RequestID = r.RequestID WHERE r.RequestDate BETWEEN @dateFrom AND @dateTo GROUP BY d.DocumentName"
            End If

            cmd = New MySqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@dateFrom", DateTimePickerDateFrom.Text)
            cmd.Parameters.AddWithValue("@dateTo", DateTimePickerDateTo.Text)

            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim lv As New ListViewItem(dr(0).ToString())

                If cboSelectReport.Text = "Student Request Masterlist" Then
                    lv.SubItems.Add(dr(1).ToString())
                    lv.SubItems.Add(dr(2).ToString())
                    lv.SubItems.Add(Convert.ToDateTime(dr(3)).ToString("yyyy-MM-dd"))
                    lv.SubItems.Add(dr(4).ToString())
                    lv.SubItems.Add(dr(5).ToString())
                ElseIf cboSelectReport.Text = "Payment Collection Report" Then
                    lv.SubItems.Add(Convert.ToDateTime(dr(1)).ToString("yyyy-MM-dd"))
                    lv.SubItems.Add(dr(2).ToString())
                    lv.SubItems.Add(dr(3).ToString())
                    lv.SubItems.Add(dr(4).ToString())
                ElseIf cboSelectReport.Text = "Document Request Summary" Then
                    lv.SubItems.Add(dr(1).ToString())
                    lv.SubItems.Add(dr(2).ToString())
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

        If MsgBox("Are you sure you want to export this report to PDF?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Export") = MsgBoxResult.Yes Then
            Try
                Dim pd As New System.Drawing.Printing.PrintDocument()

                pd.PrinterSettings.PrinterName = "Microsoft Print to PDF"

                pd.DefaultPageSettings.Landscape = True

                AddHandler pd.PrintPage, AddressOf PrintPageHandler

                pd.Print()

            Catch ex As Exception
                MsgBox("Failed to export to PDF: " & ex.Message, MsgBoxStyle.Critical, "Export Error")
            End Try
        End If

    End Sub

    Private Sub PrintPageHandler(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)
        Dim normalFont As New Font("Arial", 10)
        Dim boldFont As New Font("Arial", 10, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)

        Dim startX As Integer = 50 ' Left
        Dim startY As Integer = 50 ' Top
        Dim currentX As Integer = startX

        ' Column Headers
        For Each col As ColumnHeader In ListViewReport.Columns
            e.Graphics.DrawString(col.Text, boldFont, brush, currentX, startY)
            currentX += col.Width ' Move right by the width of the column
        Next

        ' Draw a separator line beneath headers
        startY += 25
        e.Graphics.DrawLine(New Pen(Color.Black, 2), startX, startY, currentX, startY)
        startY += 10

        ' Draw the Rows and SubItems
        For Each item As ListViewItem In ListViewReport.Items
            currentX = startX

            For i As Integer = 0 To item.SubItems.Count - 1
                e.Graphics.DrawString(item.SubItems(i).Text, normalFont, brush, currentX, startY)

                ' Move X position based on column width to keep things aligned
                If i < ListViewReport.Columns.Count Then
                    currentX += ListViewReport.Columns(i).Width
                End If
            Next

            ' Move down for the next row
            startY += 25
        Next
    End Sub

    Private Sub btnExportCSV_Click(sender As Object, e As EventArgs) Handles btnExportCSV.Click

        If MsgBox("Are you sure you want to export this data to CSV?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Export") = MsgBoxResult.Yes Then

            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv"
            saveFileDialog1.Title = "Save System Report Export"
            saveFileDialog1.FileName = "SystemReportExport.csv"

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Try
                    Dim exportData As String = ""
                    Dim totalCols As Integer = ListViewReport.Columns.Count
                    Dim colIndex As Integer = 0

                    While colIndex < totalCols
                        exportData = exportData & ListViewReport.Columns(colIndex).Text
                        If colIndex < totalCols - 1 Then
                            exportData = exportData & ","
                        End If
                        colIndex = colIndex + 1
                    End While
                    exportData = exportData & vbCrLf

                    Dim rowIndex As Integer = 0
                    While rowIndex < ListViewReport.Items.Count
                        Dim subColIndex As Integer = 0
                        While subColIndex < totalCols
                            exportData = exportData & ListViewReport.Items(rowIndex).SubItems(subColIndex).Text
                            If subColIndex < totalCols - 1 Then
                                exportData = exportData & ","
                            End If
                            subColIndex = subColIndex + 1
                        End While
                        exportData = exportData & vbCrLf
                        rowIndex = rowIndex + 1
                    End While

                    My.Computer.FileSystem.WriteAllText(saveFileDialog1.FileName, exportData, False)
                    MsgBox("Successfully exported file to: " & saveFileDialog1.FileName, MsgBoxStyle.Information, "Export Success")

                Catch ex As Exception
                    MsgBox("Failed to export report: " & ex.Message, MsgBoxStyle.Critical, "Export Error")
                End Try
            End If
        End If

    End Sub


End Class