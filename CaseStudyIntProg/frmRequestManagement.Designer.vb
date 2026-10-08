<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequestManagement
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
        Me.Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel4 = New Guna.UI2.WinForms.Guna2Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblRequestNo = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCancelRequest = New Guna.UI2.WinForms.Guna2Button()
        Me.btnUpdateRequest = New Guna.UI2.WinForms.Guna2Button()
        Me.cboNewCurrentStatus = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel8 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDisplayStudentNo = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDisplayCurrentStatus = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDisplayRequestHandled = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDisplayRequestCreated = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDisplayRecordedBy = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDisplayStudentName = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDisplayORNo = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDisplayORDate = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel7 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel10 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel4.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2HtmlLabel6
        '
        Me.Guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel6.Font = New System.Drawing.Font("Segoe UI Black", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel6.ForeColor = System.Drawing.Color.Navy
        Me.Guna2HtmlLabel6.Location = New System.Drawing.Point(25, 33)
        Me.Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Me.Guna2HtmlLabel6.Size = New System.Drawing.Size(396, 67)
        Me.Guna2HtmlLabel6.TabIndex = 24
        Me.Guna2HtmlLabel6.Text = "Manage Request"
        '
        'Guna2Panel4
        '
        Me.Guna2Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel4.BorderRadius = 12
        Me.Guna2Panel4.Controls.Add(Me.ListView1)
        Me.Guna2Panel4.FillColor = System.Drawing.Color.White
        Me.Guna2Panel4.Location = New System.Drawing.Point(25, 122)
        Me.Guna2Panel4.Name = "Guna2Panel4"
        Me.Guna2Panel4.Size = New System.Drawing.Size(757, 858)
        Me.Guna2Panel4.TabIndex = 59
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.Lavender
        Me.ListView1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(25, 26)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(707, 806)
        Me.ListView1.TabIndex = 21
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.BorderRadius = 12
        Me.Guna2Panel1.Controls.Add(Me.lblRequestNo)
        Me.Guna2Panel1.Controls.Add(Me.btnClear)
        Me.Guna2Panel1.Controls.Add(Me.btnCancelRequest)
        Me.Guna2Panel1.Controls.Add(Me.btnUpdateRequest)
        Me.Guna2Panel1.Controls.Add(Me.cboNewCurrentStatus)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel8)
        Me.Guna2Panel1.Controls.Add(Me.lblDisplayStudentNo)
        Me.Guna2Panel1.Controls.Add(Me.lblDisplayCurrentStatus)
        Me.Guna2Panel1.Controls.Add(Me.lblDisplayRequestHandled)
        Me.Guna2Panel1.Controls.Add(Me.lblDisplayRequestCreated)
        Me.Guna2Panel1.Controls.Add(Me.lblDisplayRecordedBy)
        Me.Guna2Panel1.Controls.Add(Me.lblDisplayStudentName)
        Me.Guna2Panel1.Controls.Add(Me.lblDisplayORNo)
        Me.Guna2Panel1.Controls.Add(Me.lblDisplayORDate)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel7)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel5)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel4)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel10)
        Me.Guna2Panel1.FillColor = System.Drawing.Color.White
        Me.Guna2Panel1.Location = New System.Drawing.Point(827, 122)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(757, 858)
        Me.Guna2Panel1.TabIndex = 60
        '
        'lblRequestNo
        '
        Me.lblRequestNo.BackColor = System.Drawing.Color.Transparent
        Me.lblRequestNo.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestNo.Location = New System.Drawing.Point(58, 49)
        Me.lblRequestNo.Name = "lblRequestNo"
        Me.lblRequestNo.Size = New System.Drawing.Size(27, 42)
        Me.lblRequestNo.TabIndex = 73
        Me.lblRequestNo.Text = "--"
        Me.lblRequestNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.BorderRadius = 12
        Me.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.FillColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(577, 676)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(121, 35)
        Me.btnClear.TabIndex = 72
        Me.btnClear.Text = "CLEAR"
        '
        'btnCancelRequest
        '
        Me.btnCancelRequest.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelRequest.BorderColor = System.Drawing.Color.Red
        Me.btnCancelRequest.BorderRadius = 12
        Me.btnCancelRequest.BorderThickness = 1
        Me.btnCancelRequest.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelRequest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelRequest.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCancelRequest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCancelRequest.FillColor = System.Drawing.Color.White
        Me.btnCancelRequest.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelRequest.ForeColor = System.Drawing.Color.Red
        Me.btnCancelRequest.Location = New System.Drawing.Point(406, 762)
        Me.btnCancelRequest.Name = "btnCancelRequest"
        Me.btnCancelRequest.Size = New System.Drawing.Size(262, 51)
        Me.btnCancelRequest.TabIndex = 71
        Me.btnCancelRequest.Text = "CANCEL REQUEST"
        '
        'btnUpdateRequest
        '
        Me.btnUpdateRequest.BackColor = System.Drawing.Color.Transparent
        Me.btnUpdateRequest.BorderRadius = 12
        Me.btnUpdateRequest.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdateRequest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdateRequest.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnUpdateRequest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnUpdateRequest.FillColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnUpdateRequest.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateRequest.ForeColor = System.Drawing.Color.White
        Me.btnUpdateRequest.Location = New System.Drawing.Point(117, 762)
        Me.btnUpdateRequest.Name = "btnUpdateRequest"
        Me.btnUpdateRequest.Size = New System.Drawing.Size(262, 51)
        Me.btnUpdateRequest.TabIndex = 70
        Me.btnUpdateRequest.Text = "UPDATE REQUEST"
        '
        'cboNewCurrentStatus
        '
        Me.cboNewCurrentStatus.BackColor = System.Drawing.Color.Transparent
        Me.cboNewCurrentStatus.BorderRadius = 12
        Me.cboNewCurrentStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboNewCurrentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewCurrentStatus.FillColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboNewCurrentStatus.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboNewCurrentStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboNewCurrentStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboNewCurrentStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cboNewCurrentStatus.ItemHeight = 30
        Me.cboNewCurrentStatus.Location = New System.Drawing.Point(57, 676)
        Me.cboNewCurrentStatus.Name = "cboNewCurrentStatus"
        Me.cboNewCurrentStatus.Size = New System.Drawing.Size(468, 36)
        Me.cboNewCurrentStatus.TabIndex = 69
        '
        'Guna2HtmlLabel8
        '
        Me.Guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel8.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel8.Location = New System.Drawing.Point(58, 618)
        Me.Guna2HtmlLabel8.Name = "Guna2HtmlLabel8"
        Me.Guna2HtmlLabel8.Size = New System.Drawing.Size(286, 42)
        Me.Guna2HtmlLabel8.TabIndex = 68
        Me.Guna2HtmlLabel8.Text = "Update Current Status"
        '
        'lblDisplayStudentNo
        '
        Me.lblDisplayStudentNo.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayStudentNo.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayStudentNo.Location = New System.Drawing.Point(589, 249)
        Me.lblDisplayStudentNo.Name = "lblDisplayStudentNo"
        Me.lblDisplayStudentNo.Size = New System.Drawing.Size(27, 42)
        Me.lblDisplayStudentNo.TabIndex = 67
        Me.lblDisplayStudentNo.Text = "--"
        Me.lblDisplayStudentNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDisplayCurrentStatus
        '
        Me.lblDisplayCurrentStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayCurrentStatus.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayCurrentStatus.Location = New System.Drawing.Point(352, 536)
        Me.lblDisplayCurrentStatus.Name = "lblDisplayCurrentStatus"
        Me.lblDisplayCurrentStatus.Size = New System.Drawing.Size(27, 42)
        Me.lblDisplayCurrentStatus.TabIndex = 65
        Me.lblDisplayCurrentStatus.Text = "--"
        Me.lblDisplayCurrentStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDisplayRequestHandled
        '
        Me.lblDisplayRequestHandled.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayRequestHandled.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayRequestHandled.Location = New System.Drawing.Point(352, 462)
        Me.lblDisplayRequestHandled.Name = "lblDisplayRequestHandled"
        Me.lblDisplayRequestHandled.Size = New System.Drawing.Size(27, 42)
        Me.lblDisplayRequestHandled.TabIndex = 64
        Me.lblDisplayRequestHandled.Text = "--"
        Me.lblDisplayRequestHandled.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDisplayRequestCreated
        '
        Me.lblDisplayRequestCreated.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayRequestCreated.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayRequestCreated.Location = New System.Drawing.Point(352, 386)
        Me.lblDisplayRequestCreated.Name = "lblDisplayRequestCreated"
        Me.lblDisplayRequestCreated.Size = New System.Drawing.Size(27, 42)
        Me.lblDisplayRequestCreated.TabIndex = 63
        Me.lblDisplayRequestCreated.Text = "--"
        Me.lblDisplayRequestCreated.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDisplayRecordedBy
        '
        Me.lblDisplayRecordedBy.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayRecordedBy.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayRecordedBy.Location = New System.Drawing.Point(352, 318)
        Me.lblDisplayRecordedBy.Name = "lblDisplayRecordedBy"
        Me.lblDisplayRecordedBy.Size = New System.Drawing.Size(27, 42)
        Me.lblDisplayRecordedBy.TabIndex = 62
        Me.lblDisplayRecordedBy.Text = "--"
        Me.lblDisplayRecordedBy.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDisplayStudentName
        '
        Me.lblDisplayStudentName.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayStudentName.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayStudentName.Location = New System.Drawing.Point(352, 249)
        Me.lblDisplayStudentName.Name = "lblDisplayStudentName"
        Me.lblDisplayStudentName.Size = New System.Drawing.Size(27, 42)
        Me.lblDisplayStudentName.TabIndex = 61
        Me.lblDisplayStudentName.Text = "--"
        Me.lblDisplayStudentName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDisplayORNo
        '
        Me.lblDisplayORNo.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayORNo.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayORNo.Location = New System.Drawing.Point(352, 116)
        Me.lblDisplayORNo.Name = "lblDisplayORNo"
        Me.lblDisplayORNo.Size = New System.Drawing.Size(27, 42)
        Me.lblDisplayORNo.TabIndex = 60
        Me.lblDisplayORNo.Text = "--"
        Me.lblDisplayORNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDisplayORDate
        '
        Me.lblDisplayORDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayORDate.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayORDate.Location = New System.Drawing.Point(352, 180)
        Me.lblDisplayORDate.Name = "lblDisplayORDate"
        Me.lblDisplayORDate.Size = New System.Drawing.Size(27, 42)
        Me.lblDisplayORDate.TabIndex = 59
        Me.lblDisplayORDate.Text = "--"
        Me.lblDisplayORDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Guna2HtmlLabel7
        '
        Me.Guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel7.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel7.Location = New System.Drawing.Point(57, 536)
        Me.Guna2HtmlLabel7.Name = "Guna2HtmlLabel7"
        Me.Guna2HtmlLabel7.Size = New System.Drawing.Size(184, 42)
        Me.Guna2HtmlLabel7.TabIndex = 58
        Me.Guna2HtmlLabel7.Text = "Current Status"
        '
        'Guna2HtmlLabel5
        '
        Me.Guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel5.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel5.Location = New System.Drawing.Point(57, 462)
        Me.Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Me.Guna2HtmlLabel5.Size = New System.Drawing.Size(185, 42)
        Me.Guna2HtmlLabel5.TabIndex = 57
        Me.Guna2HtmlLabel5.Text = "Handled Since"
        '
        'Guna2HtmlLabel4
        '
        Me.Guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel4.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel4.Location = New System.Drawing.Point(57, 386)
        Me.Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Me.Guna2HtmlLabel4.Size = New System.Drawing.Size(221, 42)
        Me.Guna2HtmlLabel4.TabIndex = 56
        Me.Guna2HtmlLabel4.Text = "Request Handled"
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(57, 318)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(169, 42)
        Me.Guna2HtmlLabel3.TabIndex = 55
        Me.Guna2HtmlLabel3.Text = "Processed By"
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(57, 249)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(102, 42)
        Me.Guna2HtmlLabel2.TabIndex = 54
        Me.Guna2HtmlLabel2.Text = "Student"
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(57, 180)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(110, 42)
        Me.Guna2HtmlLabel1.TabIndex = 53
        Me.Guna2HtmlLabel1.Text = "OR Date"
        '
        'Guna2HtmlLabel10
        '
        Me.Guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel10.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel10.Location = New System.Drawing.Point(57, 116)
        Me.Guna2HtmlLabel10.Name = "Guna2HtmlLabel10"
        Me.Guna2HtmlLabel10.Size = New System.Drawing.Size(95, 42)
        Me.Guna2HtmlLabel10.TabIndex = 52
        Me.Guna2HtmlLabel10.Text = "OR No."
        '
        'frmRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1628, 1011)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Guna2Panel4)
        Me.Controls.Add(Me.Guna2HtmlLabel6)
        Me.Name = "frmRequestManagement"
        Me.Text = "frmRequestManagement"
        Me.Guna2Panel4.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Panel4 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2HtmlLabel7 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel10 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDisplayCurrentStatus As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDisplayRequestHandled As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDisplayRequestCreated As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDisplayRecordedBy As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDisplayStudentName As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDisplayORNo As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDisplayORDate As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblDisplayStudentNo As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel8 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents cboNewCurrentStatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnUpdateRequest As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancelRequest As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents lblRequestNo As Guna.UI2.WinForms.Guna2HtmlLabel
End Class
