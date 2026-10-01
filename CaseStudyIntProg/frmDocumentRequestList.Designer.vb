<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentRequestList
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
        Me.lblSearchStudentIdOrName = New System.Windows.Forms.Label()
        Me.txtSearchStudentIdOrName = New System.Windows.Forms.TextBox()
        Me.lblStatusFilter = New System.Windows.Forms.Label()
        Me.cboStatusFilter = New System.Windows.Forms.ComboBox()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.lblOrder = New System.Windows.Forms.Label()
        Me.cboOrder = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.ListViewRequestList = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'lblSearchStudentIdOrName
        '
        Me.lblSearchStudentIdOrName.AutoSize = True
        Me.lblSearchStudentIdOrName.Location = New System.Drawing.Point(18, 70)
        Me.lblSearchStudentIdOrName.Name = "lblSearchStudentIdOrName"
        Me.lblSearchStudentIdOrName.Size = New System.Drawing.Size(138, 13)
        Me.lblSearchStudentIdOrName.TabIndex = 0
        Me.lblSearchStudentIdOrName.Text = "Search StudentId Or Name:"
        '
        'txtSearchStudentIdOrName
        '
        Me.txtSearchStudentIdOrName.Location = New System.Drawing.Point(162, 67)
        Me.txtSearchStudentIdOrName.Name = "txtSearchStudentIdOrName"
        Me.txtSearchStudentIdOrName.Size = New System.Drawing.Size(181, 20)
        Me.txtSearchStudentIdOrName.TabIndex = 1
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.AutoSize = True
        Me.lblStatusFilter.Location = New System.Drawing.Point(18, 100)
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(65, 13)
        Me.lblStatusFilter.TabIndex = 2
        Me.lblStatusFilter.Text = "Status Filter:"
        '
        'cboStatusFilter
        '
        Me.cboStatusFilter.FormattingEnabled = True
        Me.cboStatusFilter.Location = New System.Drawing.Point(89, 97)
        Me.cboStatusFilter.Name = "cboStatusFilter"
        Me.cboStatusFilter.Size = New System.Drawing.Size(132, 21)
        Me.cboStatusFilter.TabIndex = 3
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(367, 74)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(59, 13)
        Me.lblDateFrom.TabIndex = 4
        Me.lblDateFrom.Text = "Date From:"
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(432, 72)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePickerFrom.TabIndex = 5
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(547, 74)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(49, 13)
        Me.lblDateTo.TabIndex = 6
        Me.lblDateTo.Text = "Date To:"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(602, 72)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePickerTo.TabIndex = 7
        '
        'lblOrder
        '
        Me.lblOrder.AutoSize = True
        Me.lblOrder.Location = New System.Drawing.Point(254, 105)
        Me.lblOrder.Name = "lblOrder"
        Me.lblOrder.Size = New System.Drawing.Size(36, 13)
        Me.lblOrder.TabIndex = 8
        Me.lblOrder.Text = "Order:"
        '
        'cboOrder
        '
        Me.cboOrder.FormattingEnabled = True
        Me.cboOrder.Location = New System.Drawing.Point(296, 102)
        Me.cboOrder.Name = "cboOrder"
        Me.cboOrder.Size = New System.Drawing.Size(132, 21)
        Me.cboOrder.TabIndex = 9
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(345, 142)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(432, 142)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 11
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'ListViewRequestList
        '
        Me.ListViewRequestList.HideSelection = False
        Me.ListViewRequestList.Location = New System.Drawing.Point(12, 189)
        Me.ListViewRequestList.Name = "ListViewRequestList"
        Me.ListViewRequestList.Size = New System.Drawing.Size(942, 448)
        Me.ListViewRequestList.TabIndex = 12
        Me.ListViewRequestList.UseCompatibleStateImageBehavior = False
        '
        'frmDocumentRequestList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 649)
        Me.Controls.Add(Me.ListViewRequestList)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cboOrder)
        Me.Controls.Add(Me.lblOrder)
        Me.Controls.Add(Me.DateTimePickerTo)
        Me.Controls.Add(Me.lblDateTo)
        Me.Controls.Add(Me.DateTimePickerFrom)
        Me.Controls.Add(Me.lblDateFrom)
        Me.Controls.Add(Me.cboStatusFilter)
        Me.Controls.Add(Me.lblStatusFilter)
        Me.Controls.Add(Me.txtSearchStudentIdOrName)
        Me.Controls.Add(Me.lblSearchStudentIdOrName)
        Me.Name = "frmDocumentRequestList"
        Me.Text = "frmDocumentRequestList"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSearchStudentIdOrName As Label
    Friend WithEvents txtSearchStudentIdOrName As TextBox
    Friend WithEvents lblStatusFilter As Label
    Friend WithEvents cboStatusFilter As ComboBox
    Friend WithEvents lblDateFrom As Label
    Friend WithEvents DateTimePickerFrom As DateTimePicker
    Friend WithEvents lblDateTo As Label
    Friend WithEvents DateTimePickerTo As DateTimePicker
    Friend WithEvents lblOrder As Label
    Friend WithEvents cboOrder As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents ListViewRequestList As ListView
End Class
