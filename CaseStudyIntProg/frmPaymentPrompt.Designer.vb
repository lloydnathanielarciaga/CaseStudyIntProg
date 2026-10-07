<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentPrompt
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
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDisplayRequestNo = New System.Windows.Forms.Label()
        Me.lblDisplayORNo = New System.Windows.Forms.Label()
        Me.lblDisplayStudentNo = New System.Windows.Forms.Label()
        Me.lblDisplayStudentName = New System.Windows.Forms.Label()
        Me.DateTimePickerOR = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.btnCancel = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSavePayment = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(31, 17)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(89, 20)
        Me.lblMessage.TabIndex = 12
        Me.lblMessage.Text = "Request No:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "OR No:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Student Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 20)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Student No:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(52, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "OR Date:"
        '
        'lblDisplayRequestNo
        '
        Me.lblDisplayRequestNo.AutoSize = True
        Me.lblDisplayRequestNo.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayRequestNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayRequestNo.Location = New System.Drawing.Point(126, 20)
        Me.lblDisplayRequestNo.Name = "lblDisplayRequestNo"
        Me.lblDisplayRequestNo.Size = New System.Drawing.Size(13, 17)
        Me.lblDisplayRequestNo.TabIndex = 18
        Me.lblDisplayRequestNo.Text = "-"
        '
        'lblDisplayORNo
        '
        Me.lblDisplayORNo.AutoSize = True
        Me.lblDisplayORNo.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayORNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayORNo.Location = New System.Drawing.Point(126, 64)
        Me.lblDisplayORNo.Name = "lblDisplayORNo"
        Me.lblDisplayORNo.Size = New System.Drawing.Size(13, 17)
        Me.lblDisplayORNo.TabIndex = 19
        Me.lblDisplayORNo.Text = "-"
        '
        'lblDisplayStudentNo
        '
        Me.lblDisplayStudentNo.AutoSize = True
        Me.lblDisplayStudentNo.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayStudentNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayStudentNo.Location = New System.Drawing.Point(126, 109)
        Me.lblDisplayStudentNo.Name = "lblDisplayStudentNo"
        Me.lblDisplayStudentNo.Size = New System.Drawing.Size(13, 17)
        Me.lblDisplayStudentNo.TabIndex = 20
        Me.lblDisplayStudentNo.Text = "-"
        '
        'lblDisplayStudentName
        '
        Me.lblDisplayStudentName.AutoSize = True
        Me.lblDisplayStudentName.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayStudentName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayStudentName.Location = New System.Drawing.Point(126, 153)
        Me.lblDisplayStudentName.Name = "lblDisplayStudentName"
        Me.lblDisplayStudentName.Size = New System.Drawing.Size(13, 17)
        Me.lblDisplayStudentName.TabIndex = 21
        Me.lblDisplayStudentName.Text = "-"
        '
        'DateTimePickerOR
        '
        Me.DateTimePickerOR.BackColor = System.Drawing.Color.Transparent
        Me.DateTimePickerOR.BorderRadius = 12
        Me.DateTimePickerOR.Checked = True
        Me.DateTimePickerOR.FillColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateTimePickerOR.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DateTimePickerOR.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerOR.Location = New System.Drawing.Point(126, 187)
        Me.DateTimePickerOR.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateTimePickerOR.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateTimePickerOR.Name = "DateTimePickerOR"
        Me.DateTimePickerOR.Size = New System.Drawing.Size(125, 32)
        Me.DateTimePickerOR.TabIndex = 54
        Me.DateTimePickerOR.Value = New Date(2026, 10, 2, 15, 41, 46, 199)
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnCancel.BorderRadius = 12
        Me.btnCancel.BorderThickness = 1
        Me.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCancel.FillColor = System.Drawing.Color.White
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnCancel.Location = New System.Drawing.Point(103, 288)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(116, 32)
        Me.btnCancel.TabIndex = 62
        Me.btnCancel.Text = "CANCEL"
        '
        'btnSavePayment
        '
        Me.btnSavePayment.BackColor = System.Drawing.Color.Transparent
        Me.btnSavePayment.BorderRadius = 12
        Me.btnSavePayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSavePayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSavePayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSavePayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSavePayment.FillColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnSavePayment.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavePayment.ForeColor = System.Drawing.Color.White
        Me.btnSavePayment.Location = New System.Drawing.Point(228, 288)
        Me.btnSavePayment.Name = "btnSavePayment"
        Me.btnSavePayment.Size = New System.Drawing.Size(143, 32)
        Me.btnSavePayment.TabIndex = 61
        Me.btnSavePayment.Text = "SAVE PAYMENT"
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.BorderRadius = 12
        Me.Guna2Panel2.Controls.Add(Me.DateTimePickerOR)
        Me.Guna2Panel2.Controls.Add(Me.lblDisplayRequestNo)
        Me.Guna2Panel2.Controls.Add(Me.lblDisplayORNo)
        Me.Guna2Panel2.Controls.Add(Me.Label4)
        Me.Guna2Panel2.Controls.Add(Me.lblDisplayStudentName)
        Me.Guna2Panel2.Controls.Add(Me.Label2)
        Me.Guna2Panel2.Controls.Add(Me.lblDisplayStudentNo)
        Me.Guna2Panel2.Controls.Add(Me.Label3)
        Me.Guna2Panel2.Controls.Add(Me.Label1)
        Me.Guna2Panel2.Controls.Add(Me.lblMessage)
        Me.Guna2Panel2.FillColor = System.Drawing.Color.White
        Me.Guna2Panel2.Location = New System.Drawing.Point(25, 38)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(346, 234)
        Me.Guna2Panel2.TabIndex = 63
        '
        'frmPaymentPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 339)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSavePayment)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPaymentPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Record Payment"
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMessage As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblDisplayRequestNo As Label
    Friend WithEvents lblDisplayORNo As Label
    Friend WithEvents lblDisplayStudentNo As Label
    Friend WithEvents lblDisplayStudentName As Label
    Friend WithEvents DateTimePickerOR As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSavePayment As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
End Class
