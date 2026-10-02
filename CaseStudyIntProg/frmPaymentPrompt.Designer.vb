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
        Me.lblORNo = New System.Windows.Forms.Label()
        Me.lblDisplayORNo = New System.Windows.Forms.Label()
        Me.lblORDate = New System.Windows.Forms.Label()
        Me.DateTimePickerOR = New System.Windows.Forms.DateTimePicker()
        Me.lblStudentNo = New System.Windows.Forms.Label()
        Me.lblDisplayStudentNo = New System.Windows.Forms.Label()
        Me.lblStudentName = New System.Windows.Forms.Label()
        Me.lblDisplayStudentName = New System.Windows.Forms.Label()
        Me.lblRequestNo = New System.Windows.Forms.Label()
        Me.lblDisplayRequestNo = New System.Windows.Forms.Label()
        Me.btnSavePayment = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblORNo
        '
        Me.lblORNo.AutoSize = True
        Me.lblORNo.Location = New System.Drawing.Point(55, 74)
        Me.lblORNo.Name = "lblORNo"
        Me.lblORNo.Size = New System.Drawing.Size(43, 13)
        Me.lblORNo.TabIndex = 0
        Me.lblORNo.Text = "OR No:"
        '
        'lblDisplayORNo
        '
        Me.lblDisplayORNo.AutoSize = True
        Me.lblDisplayORNo.Location = New System.Drawing.Point(139, 73)
        Me.lblDisplayORNo.Name = "lblDisplayORNo"
        Me.lblDisplayORNo.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayORNo.TabIndex = 1
        Me.lblDisplayORNo.Text = "-"
        '
        'lblORDate
        '
        Me.lblORDate.AutoSize = True
        Me.lblORDate.Location = New System.Drawing.Point(55, 161)
        Me.lblORDate.Name = "lblORDate"
        Me.lblORDate.Size = New System.Drawing.Size(52, 13)
        Me.lblORDate.TabIndex = 2
        Me.lblORDate.Text = "OR Date:"
        '
        'DateTimePickerOR
        '
        Me.DateTimePickerOR.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerOR.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerOR.Location = New System.Drawing.Point(142, 154)
        Me.DateTimePickerOR.Name = "DateTimePickerOR"
        Me.DateTimePickerOR.Size = New System.Drawing.Size(94, 20)
        Me.DateTimePickerOR.TabIndex = 3
        '
        'lblStudentNo
        '
        Me.lblStudentNo.AutoSize = True
        Me.lblStudentNo.Location = New System.Drawing.Point(55, 102)
        Me.lblStudentNo.Name = "lblStudentNo"
        Me.lblStudentNo.Size = New System.Drawing.Size(64, 13)
        Me.lblStudentNo.TabIndex = 4
        Me.lblStudentNo.Text = "Student No:"
        '
        'lblDisplayStudentNo
        '
        Me.lblDisplayStudentNo.AutoSize = True
        Me.lblDisplayStudentNo.Location = New System.Drawing.Point(139, 101)
        Me.lblDisplayStudentNo.Name = "lblDisplayStudentNo"
        Me.lblDisplayStudentNo.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayStudentNo.TabIndex = 5
        Me.lblDisplayStudentNo.Text = "-"
        '
        'lblStudentName
        '
        Me.lblStudentName.AutoSize = True
        Me.lblStudentName.Location = New System.Drawing.Point(55, 129)
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(78, 13)
        Me.lblStudentName.TabIndex = 6
        Me.lblStudentName.Text = "Student Name:"
        '
        'lblDisplayStudentName
        '
        Me.lblDisplayStudentName.AutoSize = True
        Me.lblDisplayStudentName.Location = New System.Drawing.Point(139, 129)
        Me.lblDisplayStudentName.Name = "lblDisplayStudentName"
        Me.lblDisplayStudentName.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayStudentName.TabIndex = 7
        Me.lblDisplayStudentName.Text = "-"
        '
        'lblRequestNo
        '
        Me.lblRequestNo.AutoSize = True
        Me.lblRequestNo.Location = New System.Drawing.Point(55, 52)
        Me.lblRequestNo.Name = "lblRequestNo"
        Me.lblRequestNo.Size = New System.Drawing.Size(67, 13)
        Me.lblRequestNo.TabIndex = 8
        Me.lblRequestNo.Text = "Request No:"
        '
        'lblDisplayRequestNo
        '
        Me.lblDisplayRequestNo.AutoSize = True
        Me.lblDisplayRequestNo.Location = New System.Drawing.Point(139, 52)
        Me.lblDisplayRequestNo.Name = "lblDisplayRequestNo"
        Me.lblDisplayRequestNo.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayRequestNo.TabIndex = 9
        Me.lblDisplayRequestNo.Text = "-"
        '
        'btnSavePayment
        '
        Me.btnSavePayment.Location = New System.Drawing.Point(142, 199)
        Me.btnSavePayment.Name = "btnSavePayment"
        Me.btnSavePayment.Size = New System.Drawing.Size(94, 35)
        Me.btnSavePayment.TabIndex = 10
        Me.btnSavePayment.Text = "Save Payment"
        Me.btnSavePayment.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(242, 199)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 35)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmPaymentPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 303)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSavePayment)
        Me.Controls.Add(Me.lblDisplayRequestNo)
        Me.Controls.Add(Me.lblRequestNo)
        Me.Controls.Add(Me.lblDisplayStudentName)
        Me.Controls.Add(Me.lblStudentName)
        Me.Controls.Add(Me.lblDisplayStudentNo)
        Me.Controls.Add(Me.lblStudentNo)
        Me.Controls.Add(Me.DateTimePickerOR)
        Me.Controls.Add(Me.lblORDate)
        Me.Controls.Add(Me.lblDisplayORNo)
        Me.Controls.Add(Me.lblORNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPaymentPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPaymentPrompt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblORNo As Label
    Friend WithEvents lblDisplayORNo As Label
    Friend WithEvents lblORDate As Label
    Friend WithEvents DateTimePickerOR As DateTimePicker
    Friend WithEvents lblStudentNo As Label
    Friend WithEvents lblDisplayStudentNo As Label
    Friend WithEvents lblStudentName As Label
    Friend WithEvents lblDisplayStudentName As Label
    Friend WithEvents lblRequestNo As Label
    Friend WithEvents lblDisplayRequestNo As Label
    Friend WithEvents btnSavePayment As Button
    Friend WithEvents btnCancel As Button
End Class
