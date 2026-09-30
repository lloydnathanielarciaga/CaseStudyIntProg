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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboStatusFilter = New System.Windows.Forms.ComboBox()
        Me.lblDocumentRequestList = New System.Windows.Forms.Label()
        Me.lblSearchStudentIdOrName = New System.Windows.Forms.Label()
        Me.lblSelectStatus = New System.Windows.Forms.Label()
        Me.ListViewRequestList = New System.Windows.Forms.ListView()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtSearchStudentIdOrName = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblOrder = New System.Windows.Forms.Label()
        Me.cboOrder = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblDocumentRequestList, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSearchStudentIdOrName, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSearchStudentIdOrName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSelectStatus, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboStatusFilter, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(521, 192)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cboStatusFilter
        '
        Me.cboStatusFilter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboStatusFilter.FormattingEnabled = True
        Me.cboStatusFilter.Location = New System.Drawing.Point(150, 115)
        Me.cboStatusFilter.Name = "cboStatusFilter"
        Me.cboStatusFilter.Size = New System.Drawing.Size(149, 21)
        Me.cboStatusFilter.TabIndex = 6
        '
        'lblDocumentRequestList
        '
        Me.lblDocumentRequestList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDocumentRequestList.AutoSize = True
        Me.lblDocumentRequestList.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblDocumentRequestList, 2)
        Me.lblDocumentRequestList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentRequestList.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDocumentRequestList.Location = New System.Drawing.Point(3, 15)
        Me.lblDocumentRequestList.Name = "lblDocumentRequestList"
        Me.lblDocumentRequestList.Size = New System.Drawing.Size(139, 13)
        Me.lblDocumentRequestList.TabIndex = 0
        Me.lblDocumentRequestList.Text = "Document Request List"
        '
        'lblSearchStudentIdOrName
        '
        Me.lblSearchStudentIdOrName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSearchStudentIdOrName.AutoSize = True
        Me.lblSearchStudentIdOrName.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchStudentIdOrName.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSearchStudentIdOrName.Location = New System.Drawing.Point(3, 68)
        Me.lblSearchStudentIdOrName.Name = "lblSearchStudentIdOrName"
        Me.lblSearchStudentIdOrName.Size = New System.Drawing.Size(141, 13)
        Me.lblSearchStudentIdOrName.TabIndex = 1
        Me.lblSearchStudentIdOrName.Text = "Search Student ID or Name:"
        '
        'lblSelectStatus
        '
        Me.lblSelectStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSelectStatus.AutoSize = True
        Me.lblSelectStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSelectStatus.Location = New System.Drawing.Point(3, 119)
        Me.lblSelectStatus.Name = "lblSelectStatus"
        Me.lblSelectStatus.Size = New System.Drawing.Size(70, 13)
        Me.lblSelectStatus.TabIndex = 3
        Me.lblSelectStatus.Text = "Select Status"
        '
        'ListViewRequestList
        '
        Me.ListViewRequestList.BackColor = System.Drawing.Color.Lavender
        Me.ListViewRequestList.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ListViewRequestList.HideSelection = False
        Me.ListViewRequestList.Location = New System.Drawing.Point(12, 244)
        Me.ListViewRequestList.Name = "ListViewRequestList"
        Me.ListViewRequestList.Size = New System.Drawing.Size(776, 327)
        Me.ListViewRequestList.TabIndex = 1
        Me.ListViewRequestList.UseCompatibleStateImageBehavior = False
        Me.ListViewRequestList.View = System.Windows.Forms.View.Details
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSearch.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(3, 8)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(83, 23)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnReset.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(103, 8)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(83, 23)
        Me.btnReset.TabIndex = 8
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'txtSearchStudentIdOrName
        '
        Me.txtSearchStudentIdOrName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSearchStudentIdOrName.Location = New System.Drawing.Point(150, 65)
        Me.txtSearchStudentIdOrName.Name = "txtSearchStudentIdOrName"
        Me.txtSearchStudentIdOrName.Size = New System.Drawing.Size(149, 20)
        Me.txtSearchStudentIdOrName.TabIndex = 9
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnSearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnReset, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(305, 149)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 40)
        Me.TableLayoutPanel2.TabIndex = 11
        '
        'lblDateFrom
        '
        Me.lblDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.BackColor = System.Drawing.Color.Transparent
        Me.lblDateFrom.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDateFrom.Location = New System.Drawing.Point(3, 7)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(59, 13)
        Me.lblDateFrom.TabIndex = 12
        Me.lblDateFrom.Text = "Date From:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.DateTimePickerTo, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDateTo, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDateFrom, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.DateTimePickerFrom, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(305, 47)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(213, 56)
        Me.TableLayoutPanel3.TabIndex = 13
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(3, 31)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePickerFrom.TabIndex = 13
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(109, 31)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.Size = New System.Drawing.Size(101, 20)
        Me.DateTimePickerTo.TabIndex = 13
        '
        'lblDateTo
        '
        Me.lblDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.BackColor = System.Drawing.Color.Transparent
        Me.lblDateTo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDateTo.Location = New System.Drawing.Point(109, 7)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(49, 13)
        Me.lblDateTo.TabIndex = 12
        Me.lblDateTo.Text = "Date To:"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.cboOrder, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblOrder, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(305, 109)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(213, 34)
        Me.TableLayoutPanel4.TabIndex = 14
        '
        'lblOrder
        '
        Me.lblOrder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOrder.AutoSize = True
        Me.lblOrder.BackColor = System.Drawing.Color.Transparent
        Me.lblOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblOrder.Location = New System.Drawing.Point(3, 10)
        Me.lblOrder.Name = "lblOrder"
        Me.lblOrder.Size = New System.Drawing.Size(55, 13)
        Me.lblOrder.TabIndex = 3
        Me.lblOrder.Text = "List Order:"
        '
        'cboOrder
        '
        Me.cboOrder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrder.FormattingEnabled = True
        Me.cboOrder.Location = New System.Drawing.Point(64, 6)
        Me.cboOrder.Name = "cboOrder"
        Me.cboOrder.Size = New System.Drawing.Size(146, 21)
        Me.cboOrder.TabIndex = 7
        '
        'frmDocumentRequestList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CaseStudyIntProg.My.Resources.Resources.registrarbg2
        Me.ClientSize = New System.Drawing.Size(800, 583)
        Me.Controls.Add(Me.ListViewRequestList)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmDocumentRequestList"
        Me.Text = "frmDocumentRequestList"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblDocumentRequestList As Label
    Friend WithEvents cboStatusFilter As ComboBox
    Friend WithEvents lblSearchStudentIdOrName As Label
    Friend WithEvents lblSelectStatus As Label
    Friend WithEvents ListViewRequestList As ListView
    Friend WithEvents btnSearch As Button

    Private Sub btnClearAllSearch_Click(sender As Object, e As EventArgs) Handles btnClearAllSearch.Click, btnSearch.Click

    End Sub

    Friend WithEvents btnReset As Button
    Friend WithEvents txtSearchStudentIdOrName As TextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents lblDateFrom As Label
    Friend WithEvents DateTimePickerFrom As DateTimePicker
    Friend WithEvents lblDateTo As Label
    Friend WithEvents DateTimePickerTo As DateTimePicker
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents cboOrder As ComboBox
    Friend WithEvents lblOrder As Label

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged

    End Sub

    Private Sub frmDocumentRequestList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
