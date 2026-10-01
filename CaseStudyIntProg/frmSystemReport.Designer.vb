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
        Me.lblSelectReport = New System.Windows.Forms.Label()
        Me.lblRecordPaymentInformation = New System.Windows.Forms.Label()
        Me.cboSelectReport = New System.Windows.Forms.ComboBox()
        Me.DateTimePickerDateTo = New System.Windows.Forms.DateTimePicker()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.DateTimePickerDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnGenerateResult = New System.Windows.Forms.Button()
        Me.ListViewReport = New System.Windows.Forms.ListView()
        Me.btnPrintReport = New System.Windows.Forms.Button()
        Me.btnExportCSV = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblTotalDocs = New System.Windows.Forms.Label()
        Me.lblTotalRevenue = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblSelectReport
        '
        Me.lblSelectReport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSelectReport.AutoSize = True
        Me.lblSelectReport.Location = New System.Drawing.Point(19, 95)
        Me.lblSelectReport.Name = "lblSelectReport"
        Me.lblSelectReport.Size = New System.Drawing.Size(75, 13)
        Me.lblSelectReport.TabIndex = 2
        Me.lblSelectReport.Text = "Select Report:"
        '
        'lblRecordPaymentInformation
        '
        Me.lblRecordPaymentInformation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRecordPaymentInformation.AutoSize = True
        Me.lblRecordPaymentInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordPaymentInformation.Location = New System.Drawing.Point(19, 26)
        Me.lblRecordPaymentInformation.Name = "lblRecordPaymentInformation"
        Me.lblRecordPaymentInformation.Size = New System.Drawing.Size(89, 13)
        Me.lblRecordPaymentInformation.TabIndex = 1
        Me.lblRecordPaymentInformation.Text = "System Report"
        Me.lblRecordPaymentInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboSelectReport
        '
        Me.cboSelectReport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboSelectReport.FormattingEnabled = True
        Me.cboSelectReport.Location = New System.Drawing.Point(22, 111)
        Me.cboSelectReport.Name = "cboSelectReport"
        Me.cboSelectReport.Size = New System.Drawing.Size(202, 21)
        Me.cboSelectReport.TabIndex = 3
        '
        'DateTimePickerDateTo
        '
        Me.DateTimePickerDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DateTimePickerDateTo.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerDateTo.Location = New System.Drawing.Point(136, 167)
        Me.DateTimePickerDateTo.Name = "DateTimePickerDateTo"
        Me.DateTimePickerDateTo.Size = New System.Drawing.Size(108, 20)
        Me.DateTimePickerDateTo.TabIndex = 6
        '
        'lblDateTo
        '
        Me.lblDateTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(136, 151)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(49, 13)
        Me.lblDateTo.TabIndex = 4
        Me.lblDateTo.Text = "Date To:"
        '
        'lblDateFrom
        '
        Me.lblDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(19, 151)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(59, 13)
        Me.lblDateFrom.TabIndex = 3
        Me.lblDateFrom.Text = "Date From:"
        '
        'DateTimePickerDateFrom
        '
        Me.DateTimePickerDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DateTimePickerDateFrom.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerDateFrom.Location = New System.Drawing.Point(22, 167)
        Me.DateTimePickerDateFrom.Name = "DateTimePickerDateFrom"
        Me.DateTimePickerDateFrom.Size = New System.Drawing.Size(108, 20)
        Me.DateTimePickerDateFrom.TabIndex = 5
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(266, 167)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(107, 20)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnGenerateResult
        '
        Me.btnGenerateResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateResult.Location = New System.Drawing.Point(379, 166)
        Me.btnGenerateResult.Name = "btnGenerateResult"
        Me.btnGenerateResult.Size = New System.Drawing.Size(107, 21)
        Me.btnGenerateResult.TabIndex = 5
        Me.btnGenerateResult.Text = "Generate Result"
        Me.btnGenerateResult.UseVisualStyleBackColor = True
        '
        'ListViewReport
        '
        Me.ListViewReport.HideSelection = False
        Me.ListViewReport.Location = New System.Drawing.Point(22, 212)
        Me.ListViewReport.Name = "ListViewReport"
        Me.ListViewReport.Size = New System.Drawing.Size(776, 179)
        Me.ListViewReport.TabIndex = 1
        Me.ListViewReport.UseCompatibleStateImageBehavior = False
        Me.ListViewReport.View = System.Windows.Forms.View.Details
        '
        'btnPrintReport
        '
        Me.btnPrintReport.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnPrintReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintReport.Location = New System.Drawing.Point(570, 167)
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
        Me.btnExportCSV.Location = New System.Drawing.Point(663, 168)
        Me.btnExportCSV.Name = "btnExportCSV"
        Me.btnExportCSV.Size = New System.Drawing.Size(87, 23)
        Me.btnExportCSV.TabIndex = 1
        Me.btnExportCSV.Text = "Export CSV"
        Me.btnExportCSV.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Student Last Name:"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(22, 65)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(202, 20)
        Me.txtLastName.TabIndex = 8
        '
        'lblTotalDocs
        '
        Me.lblTotalDocs.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTotalDocs.AutoSize = True
        Me.lblTotalDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDocs.Location = New System.Drawing.Point(65, 403)
        Me.lblTotalDocs.Name = "lblTotalDocs"
        Me.lblTotalDocs.Size = New System.Drawing.Size(142, 24)
        Me.lblTotalDocs.TabIndex = 9
        Me.lblTotalDocs.Text = "Select Report:"
        '
        'lblTotalRevenue
        '
        Me.lblTotalRevenue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTotalRevenue.AutoSize = True
        Me.lblTotalRevenue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRevenue.Location = New System.Drawing.Point(458, 403)
        Me.lblTotalRevenue.Name = "lblTotalRevenue"
        Me.lblTotalRevenue.Size = New System.Drawing.Size(142, 24)
        Me.lblTotalRevenue.TabIndex = 10
        Me.lblTotalRevenue.Text = "Select Report:"
        '
        'frmSystemReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1628, 1011)
        Me.Controls.Add(Me.lblTotalRevenue)
        Me.Controls.Add(Me.lblTotalDocs)
        Me.Controls.Add(Me.btnPrintReport)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.btnExportCSV)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePickerDateFrom)
        Me.Controls.Add(Me.lblDateFrom)
        Me.Controls.Add(Me.DateTimePickerDateTo)
        Me.Controls.Add(Me.btnGenerateResult)
        Me.Controls.Add(Me.lblDateTo)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.lblRecordPaymentInformation)
        Me.Controls.Add(Me.lblSelectReport)
        Me.Controls.Add(Me.ListViewReport)
        Me.Controls.Add(Me.cboSelectReport)
        Me.Name = "frmSystemReport"
        Me.Text = "frmSystemReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRecordPaymentInformation As Label
    Friend WithEvents lblSelectReport As Label
    Friend WithEvents cboSelectReport As ComboBox
    Friend WithEvents DateTimePickerDateTo As DateTimePicker
    Friend WithEvents lblDateTo As Label
    Friend WithEvents lblDateFrom As Label
    Friend WithEvents DateTimePickerDateFrom As DateTimePicker
    Friend WithEvents btnGenerateResult As Button
    Friend WithEvents ListViewReport As ListView
    Friend WithEvents btnPrintReport As Button
    Friend WithEvents btnExportCSV As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents lblTotalDocs As Label
    Friend WithEvents lblTotalRevenue As Label
End Class
