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
        Me.ListViewRequestList = New System.Windows.Forms.ListView()
        Me.Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSearch = New Guna.UI2.WinForms.Guna2Button()
        Me.cboOrder = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel10 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.DateTimePickerTo = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.DateTimePickerFrom = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.txtSearchStudentIdOrName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel8 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.cboStatusFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewRequestList
        '
        Me.ListViewRequestList.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewRequestList.HideSelection = False
        Me.ListViewRequestList.Location = New System.Drawing.Point(41, 373)
        Me.ListViewRequestList.Name = "ListViewRequestList"
        Me.ListViewRequestList.Size = New System.Drawing.Size(1539, 596)
        Me.ListViewRequestList.TabIndex = 12
        Me.ListViewRequestList.UseCompatibleStateImageBehavior = False
        '
        'Guna2HtmlLabel6
        '
        Me.Guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel6.Font = New System.Drawing.Font("Segoe UI Black", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel6.ForeColor = System.Drawing.Color.Navy
        Me.Guna2HtmlLabel6.Location = New System.Drawing.Point(41, 39)
        Me.Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Me.Guna2HtmlLabel6.Size = New System.Drawing.Size(291, 67)
        Me.Guna2HtmlLabel6.TabIndex = 19
        Me.Guna2HtmlLabel6.Text = "Request List"
        '
        'Guna2Panel3
        '
        Me.Guna2Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel3.BorderRadius = 12
        Me.Guna2Panel3.Controls.Add(Me.cboStatusFilter)
        Me.Guna2Panel3.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Guna2Panel3.Controls.Add(Me.btnReset)
        Me.Guna2Panel3.Controls.Add(Me.btnSearch)
        Me.Guna2Panel3.Controls.Add(Me.cboOrder)
        Me.Guna2Panel3.Controls.Add(Me.Guna2HtmlLabel10)
        Me.Guna2Panel3.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Guna2Panel3.Controls.Add(Me.DateTimePickerTo)
        Me.Guna2Panel3.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Guna2Panel3.Controls.Add(Me.DateTimePickerFrom)
        Me.Guna2Panel3.Controls.Add(Me.txtSearchStudentIdOrName)
        Me.Guna2Panel3.Controls.Add(Me.Guna2HtmlLabel8)
        Me.Guna2Panel3.FillColor = System.Drawing.Color.White
        Me.Guna2Panel3.Location = New System.Drawing.Point(41, 124)
        Me.Guna2Panel3.Name = "Guna2Panel3"
        Me.Guna2Panel3.Size = New System.Drawing.Size(1539, 211)
        Me.Guna2Panel3.TabIndex = 58
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.Transparent
        Me.btnReset.BorderColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnReset.BorderRadius = 12
        Me.btnReset.BorderThickness = 1
        Me.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnReset.FillColor = System.Drawing.Color.White
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnReset.Location = New System.Drawing.Point(181, 129)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(121, 51)
        Me.btnReset.TabIndex = 55
        Me.btnReset.Text = "RESET"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.BorderRadius = 12
        Me.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSearch.FillColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(30, 129)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 51)
        Me.btnSearch.TabIndex = 54
        Me.btnSearch.Text = "SEARCH"
        '
        'cboOrder
        '
        Me.cboOrder.BackColor = System.Drawing.Color.Transparent
        Me.cboOrder.BorderRadius = 12
        Me.cboOrder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrder.FillColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboOrder.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboOrder.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboOrder.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cboOrder.ItemHeight = 30
        Me.cboOrder.Location = New System.Drawing.Point(1082, 68)
        Me.cboOrder.Name = "cboOrder"
        Me.cboOrder.Size = New System.Drawing.Size(193, 36)
        Me.cboOrder.TabIndex = 52
        '
        'Guna2HtmlLabel10
        '
        Me.Guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel10.Location = New System.Drawing.Point(1080, 40)
        Me.Guna2HtmlLabel10.Name = "Guna2HtmlLabel10"
        Me.Guna2HtmlLabel10.Size = New System.Drawing.Size(54, 23)
        Me.Guna2HtmlLabel10.TabIndex = 53
        Me.Guna2HtmlLabel10.Text = "ORDER"
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(785, 40)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(64, 23)
        Me.Guna2HtmlLabel2.TabIndex = 45
        Me.Guna2HtmlLabel2.Text = "DATE TO"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.BorderRadius = 12
        Me.DateTimePickerTo.Checked = True
        Me.DateTimePickerTo.FillColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.DateTimePickerTo.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.DateTimePickerTo.Location = New System.Drawing.Point(785, 69)
        Me.DateTimePickerTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateTimePickerTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.Size = New System.Drawing.Size(251, 35)
        Me.DateTimePickerTo.TabIndex = 44
        Me.DateTimePickerTo.Value = New Date(2026, 10, 2, 17, 55, 32, 764)
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(489, 40)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(88, 23)
        Me.Guna2HtmlLabel1.TabIndex = 43
        Me.Guna2HtmlLabel1.Text = "DATE FROM"
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.BorderRadius = 12
        Me.DateTimePickerFrom.Checked = True
        Me.DateTimePickerFrom.FillColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.DateTimePickerFrom.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(489, 69)
        Me.DateTimePickerFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateTimePickerFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(251, 35)
        Me.DateTimePickerFrom.TabIndex = 42
        Me.DateTimePickerFrom.Value = New Date(2026, 10, 2, 17, 55, 32, 764)
        '
        'txtSearchStudentIdOrName
        '
        Me.txtSearchStudentIdOrName.BackColor = System.Drawing.Color.Transparent
        Me.txtSearchStudentIdOrName.BorderRadius = 12
        Me.txtSearchStudentIdOrName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearchStudentIdOrName.DefaultText = ""
        Me.txtSearchStudentIdOrName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearchStudentIdOrName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearchStudentIdOrName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearchStudentIdOrName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearchStudentIdOrName.FillColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearchStudentIdOrName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearchStudentIdOrName.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchStudentIdOrName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearchStudentIdOrName.Location = New System.Drawing.Point(30, 69)
        Me.txtSearchStudentIdOrName.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtSearchStudentIdOrName.Name = "txtSearchStudentIdOrName"
        Me.txtSearchStudentIdOrName.PlaceholderText = ""
        Me.txtSearchStudentIdOrName.SelectedText = ""
        Me.txtSearchStudentIdOrName.Size = New System.Drawing.Size(410, 35)
        Me.txtSearchStudentIdOrName.TabIndex = 38
        '
        'Guna2HtmlLabel8
        '
        Me.Guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel8.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel8.Location = New System.Drawing.Point(30, 38)
        Me.Guna2HtmlLabel8.Name = "Guna2HtmlLabel8"
        Me.Guna2HtmlLabel8.Size = New System.Drawing.Size(147, 23)
        Me.Guna2HtmlLabel8.TabIndex = 37
        Me.Guna2HtmlLabel8.Text = "STUDENT ID / NAME"
        '
        'cboStatusFilter
        '
        Me.cboStatusFilter.BackColor = System.Drawing.Color.Transparent
        Me.cboStatusFilter.BorderRadius = 12
        Me.cboStatusFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusFilter.FillColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboStatusFilter.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboStatusFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboStatusFilter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboStatusFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cboStatusFilter.ItemHeight = 30
        Me.cboStatusFilter.Location = New System.Drawing.Point(1313, 68)
        Me.cboStatusFilter.Name = "cboStatusFilter"
        Me.cboStatusFilter.Size = New System.Drawing.Size(193, 36)
        Me.cboStatusFilter.TabIndex = 56
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(1311, 40)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(58, 23)
        Me.Guna2HtmlLabel3.TabIndex = 57
        Me.Guna2HtmlLabel3.Text = "STATUS"
        '
        'frmDocumentRequestList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1628, 1011)
        Me.Controls.Add(Me.Guna2Panel3)
        Me.Controls.Add(Me.Guna2HtmlLabel6)
        Me.Controls.Add(Me.ListViewRequestList)
        Me.Name = "frmDocumentRequestList"
        Me.Text = "frmDocumentRequestList"
        Me.Guna2Panel3.ResumeLayout(False)
        Me.Guna2Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListViewRequestList As ListView
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtSearchStudentIdOrName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel8 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents DateTimePickerTo As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents DateTimePickerFrom As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents cboOrder As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel10 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSearch As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cboStatusFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
End Class
