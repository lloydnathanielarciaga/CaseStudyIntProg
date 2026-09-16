<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblRecordPaymentInformation = New System.Windows.Forms.Label()
        Me.lblSelectReport = New System.Windows.Forms.Label()
        Me.cboSelectReport = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.DateTimePickerDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerDateTo = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerateResult = New System.Windows.Forms.Button()
        Me.ListViewReport = New System.Windows.Forms.ListView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPrintReport = New System.Windows.Forms.Button()
        Me.btnExportCSV = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblSelectReport, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRecordPaymentInformation, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboSelectReport, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 2, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(419, 173)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblRecordPaymentInformation
        '
        Me.lblRecordPaymentInformation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRecordPaymentInformation.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblRecordPaymentInformation, 2)
        Me.lblRecordPaymentInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordPaymentInformation.Location = New System.Drawing.Point(3, 22)
        Me.lblRecordPaymentInformation.Name = "lblRecordPaymentInformation"
        Me.lblRecordPaymentInformation.Size = New System.Drawing.Size(167, 13)
        Me.lblRecordPaymentInformation.TabIndex = 1
        Me.lblRecordPaymentInformation.Text = "Record Payment Information"
        Me.lblRecordPaymentInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSelectReport
        '
        Me.lblSelectReport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSelectReport.AutoSize = True
        Me.lblSelectReport.Location = New System.Drawing.Point(3, 79)
        Me.lblSelectReport.Name = "lblSelectReport"
        Me.lblSelectReport.Size = New System.Drawing.Size(75, 13)
        Me.lblSelectReport.TabIndex = 2
        Me.lblSelectReport.Text = "Select Report:"
        '
        'cboSelectReport
        '
        Me.cboSelectReport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboSelectReport.FormattingEnabled = True
        Me.cboSelectReport.Location = New System.Drawing.Point(84, 75)
        Me.cboSelectReport.Name = "cboSelectReport"
        Me.cboSelectReport.Size = New System.Drawing.Size(202, 21)
        Me.cboSelectReport.TabIndex = 3
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.DateTimePickerDateTo, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDateTo, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDateFrom, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DateTimePickerDateFrom, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 117)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(283, 53)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'lblDateFrom
        '
        Me.lblDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(3, 13)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(59, 13)
        Me.lblDateFrom.TabIndex = 3
        Me.lblDateFrom.Text = "Date From:"
        '
        'lblDateTo
        '
        Me.lblDateTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(117, 13)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(49, 13)
        Me.lblDateTo.TabIndex = 4
        Me.lblDateTo.Text = "Date To:"
        '
        'DateTimePickerDateFrom
        '
        Me.DateTimePickerDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DateTimePickerDateFrom.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerDateFrom.Location = New System.Drawing.Point(3, 29)
        Me.DateTimePickerDateFrom.Name = "DateTimePickerDateFrom"
        Me.DateTimePickerDateFrom.Size = New System.Drawing.Size(108, 20)
        Me.DateTimePickerDateFrom.TabIndex = 5
        '
        'DateTimePickerDateTo
        '
        Me.DateTimePickerDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DateTimePickerDateTo.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerDateTo.Location = New System.Drawing.Point(117, 29)
        Me.DateTimePickerDateTo.Name = "DateTimePickerDateTo"
        Me.DateTimePickerDateTo.Size = New System.Drawing.Size(108, 20)
        Me.DateTimePickerDateTo.TabIndex = 6
        '
        'btnGenerateResult
        '
        Me.btnGenerateResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateResult.Location = New System.Drawing.Point(3, 29)
        Me.btnGenerateResult.Name = "btnGenerateResult"
        Me.btnGenerateResult.Size = New System.Drawing.Size(107, 21)
        Me.btnGenerateResult.TabIndex = 5
        Me.btnGenerateResult.Text = "Generate Result"
        Me.btnGenerateResult.UseVisualStyleBackColor = True
        '
        'ListViewReport
        '
        Me.ListViewReport.HideSelection = False
        Me.ListViewReport.Location = New System.Drawing.Point(12, 204)
        Me.ListViewReport.Name = "ListViewReport"
        Me.ListViewReport.Size = New System.Drawing.Size(776, 179)
        Me.ListViewReport.TabIndex = 1
        Me.ListViewReport.UseCompatibleStateImageBehavior = False
        Me.ListViewReport.View = System.Windows.Forms.View.Details
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnPrintReport, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnExportCSV, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(252, 389)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(278, 40)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'btnPrintReport
        '
        Me.btnPrintReport.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnPrintReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintReport.Location = New System.Drawing.Point(26, 8)
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(87, 23)
        Me.btnPrintReport.TabIndex = 0
        Me.btnPrintReport.Text = "Print Report"
        Me.btnPrintReport.UseVisualStyleBackColor = True
        '
        'btnExportCSV
        '
        Me.btnExportCSV.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnExportCSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportCSV.Location = New System.Drawing.Point(165, 8)
        Me.btnExportCSV.Name = "btnExportCSV"
        Me.btnExportCSV.Size = New System.Drawing.Size(87, 23)
        Me.btnExportCSV.TabIndex = 1
        Me.btnExportCSV.Text = "Export CSV"
        Me.btnExportCSV.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnClear, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnGenerateResult, 0, 1)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(292, 117)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(124, 53)
        Me.TableLayoutPanel4.TabIndex = 6
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(3, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(107, 20)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'frmSystemReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.ListViewReport)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmSystemReport"
        Me.Text = "frmSystemReport"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblRecordPaymentInformation As Label
    Friend WithEvents lblSelectReport As Label
    Friend WithEvents cboSelectReport As ComboBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents DateTimePickerDateTo As DateTimePicker
    Friend WithEvents lblDateTo As Label
    Friend WithEvents lblDateFrom As Label
    Friend WithEvents DateTimePickerDateFrom As DateTimePicker
    Friend WithEvents btnGenerateResult As Button
    Friend WithEvents ListViewReport As ListView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btnPrintReport As Button
    Friend WithEvents btnExportCSV As Button
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents btnClear As Button
End Class
