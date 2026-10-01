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
        Me.lblRecordedBy = New System.Windows.Forms.Label()
        Me.lblDisplayRecordedBy = New System.Windows.Forms.Label()
        Me.lblCurrentStatus = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnUpdateRequest = New System.Windows.Forms.Button()
        Me.btnCancelRequest = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblDisplayCurrentStatus = New System.Windows.Forms.Label()
        Me.lblNewCurrentStatus = New System.Windows.Forms.Label()
        Me.cboNewCurrentStatus = New System.Windows.Forms.ComboBox()
        Me.lblRequestCreated = New System.Windows.Forms.Label()
        Me.lblDisplayRequestCreated = New System.Windows.Forms.Label()
        Me.lblRequestHandledSince = New System.Windows.Forms.Label()
        Me.lblDisplayRequestHandled = New System.Windows.Forms.Label()
        Me.lblStudentNo = New System.Windows.Forms.Label()
        Me.lblStudentName = New System.Windows.Forms.Label()
        Me.lblORNo = New System.Windows.Forms.Label()
        Me.lblORDate = New System.Windows.Forms.Label()
        Me.lblDisplayStudentName = New System.Windows.Forms.Label()
        Me.lblDisplayStudentNo = New System.Windows.Forms.Label()
        Me.lblDisplayORNo = New System.Windows.Forms.Label()
        Me.lblDisplayORDate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblRecordedBy
        '
        Me.lblRecordedBy.AutoSize = True
        Me.lblRecordedBy.Location = New System.Drawing.Point(843, 318)
        Me.lblRecordedBy.Name = "lblRecordedBy"
        Me.lblRecordedBy.Size = New System.Drawing.Size(72, 13)
        Me.lblRecordedBy.TabIndex = 0
        Me.lblRecordedBy.Text = "Recorded By:"
        '
        'lblDisplayRecordedBy
        '
        Me.lblDisplayRecordedBy.AutoSize = True
        Me.lblDisplayRecordedBy.Location = New System.Drawing.Point(947, 318)
        Me.lblDisplayRecordedBy.Name = "lblDisplayRecordedBy"
        Me.lblDisplayRecordedBy.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayRecordedBy.TabIndex = 1
        Me.lblDisplayRecordedBy.Text = "-"
        '
        'lblCurrentStatus
        '
        Me.lblCurrentStatus.AutoSize = True
        Me.lblCurrentStatus.Location = New System.Drawing.Point(843, 354)
        Me.lblCurrentStatus.Name = "lblCurrentStatus"
        Me.lblCurrentStatus.Size = New System.Drawing.Size(77, 13)
        Me.lblCurrentStatus.TabIndex = 2
        Me.lblCurrentStatus.Text = "Current Status:"
        '
        'ListView1
        '
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 12)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(794, 741)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'btnUpdateRequest
        '
        Me.btnUpdateRequest.Location = New System.Drawing.Point(934, 454)
        Me.btnUpdateRequest.Name = "btnUpdateRequest"
        Me.btnUpdateRequest.Size = New System.Drawing.Size(94, 23)
        Me.btnUpdateRequest.TabIndex = 5
        Me.btnUpdateRequest.Text = "Update Request"
        Me.btnUpdateRequest.UseVisualStyleBackColor = True
        '
        'btnCancelRequest
        '
        Me.btnCancelRequest.Location = New System.Drawing.Point(1034, 454)
        Me.btnCancelRequest.Name = "btnCancelRequest"
        Me.btnCancelRequest.Size = New System.Drawing.Size(94, 23)
        Me.btnCancelRequest.TabIndex = 6
        Me.btnCancelRequest.Text = "Cancel Request"
        Me.btnCancelRequest.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(1115, 395)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblDisplayCurrentStatus
        '
        Me.lblDisplayCurrentStatus.AutoSize = True
        Me.lblDisplayCurrentStatus.Location = New System.Drawing.Point(947, 354)
        Me.lblDisplayCurrentStatus.Name = "lblDisplayCurrentStatus"
        Me.lblDisplayCurrentStatus.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayCurrentStatus.TabIndex = 8
        Me.lblDisplayCurrentStatus.Text = "-"
        '
        'lblNewCurrentStatus
        '
        Me.lblNewCurrentStatus.AutoSize = True
        Me.lblNewCurrentStatus.Location = New System.Drawing.Point(852, 405)
        Me.lblNewCurrentStatus.Name = "lblNewCurrentStatus"
        Me.lblNewCurrentStatus.Size = New System.Drawing.Size(115, 13)
        Me.lblNewCurrentStatus.TabIndex = 10
        Me.lblNewCurrentStatus.Text = "Update Current Status:"
        '
        'cboNewCurrentStatus
        '
        Me.cboNewCurrentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewCurrentStatus.FormattingEnabled = True
        Me.cboNewCurrentStatus.Location = New System.Drawing.Point(987, 397)
        Me.cboNewCurrentStatus.Name = "cboNewCurrentStatus"
        Me.cboNewCurrentStatus.Size = New System.Drawing.Size(121, 21)
        Me.cboNewCurrentStatus.TabIndex = 11
        '
        'lblRequestCreated
        '
        Me.lblRequestCreated.AutoSize = True
        Me.lblRequestCreated.Location = New System.Drawing.Point(1084, 318)
        Me.lblRequestCreated.Name = "lblRequestCreated"
        Me.lblRequestCreated.Size = New System.Drawing.Size(90, 13)
        Me.lblRequestCreated.TabIndex = 12
        Me.lblRequestCreated.Text = "Request Created:"
        '
        'lblDisplayRequestCreated
        '
        Me.lblDisplayRequestCreated.AutoSize = True
        Me.lblDisplayRequestCreated.Location = New System.Drawing.Point(1180, 318)
        Me.lblDisplayRequestCreated.Name = "lblDisplayRequestCreated"
        Me.lblDisplayRequestCreated.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayRequestCreated.TabIndex = 13
        Me.lblDisplayRequestCreated.Text = "-"
        '
        'lblRequestHandledSince
        '
        Me.lblRequestHandledSince.AutoSize = True
        Me.lblRequestHandledSince.Location = New System.Drawing.Point(1051, 354)
        Me.lblRequestHandledSince.Name = "lblRequestHandledSince"
        Me.lblRequestHandledSince.Size = New System.Drawing.Size(123, 13)
        Me.lblRequestHandledSince.TabIndex = 14
        Me.lblRequestHandledSince.Text = "Request Handled Since:"
        '
        'lblDisplayRequestHandled
        '
        Me.lblDisplayRequestHandled.AutoSize = True
        Me.lblDisplayRequestHandled.Location = New System.Drawing.Point(1180, 354)
        Me.lblDisplayRequestHandled.Name = "lblDisplayRequestHandled"
        Me.lblDisplayRequestHandled.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayRequestHandled.TabIndex = 15
        Me.lblDisplayRequestHandled.Text = "-"
        '
        'lblStudentNo
        '
        Me.lblStudentNo.AutoSize = True
        Me.lblStudentNo.Location = New System.Drawing.Point(846, 243)
        Me.lblStudentNo.Name = "lblStudentNo"
        Me.lblStudentNo.Size = New System.Drawing.Size(64, 13)
        Me.lblStudentNo.TabIndex = 16
        Me.lblStudentNo.Text = "Student No:"
        '
        'lblStudentName
        '
        Me.lblStudentName.AutoSize = True
        Me.lblStudentName.Location = New System.Drawing.Point(846, 274)
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(78, 13)
        Me.lblStudentName.TabIndex = 17
        Me.lblStudentName.Text = "Student Name:"
        '
        'lblORNo
        '
        Me.lblORNo.AutoSize = True
        Me.lblORNo.Location = New System.Drawing.Point(846, 213)
        Me.lblORNo.Name = "lblORNo"
        Me.lblORNo.Size = New System.Drawing.Size(43, 13)
        Me.lblORNo.TabIndex = 18
        Me.lblORNo.Text = "OR No:"
        '
        'lblORDate
        '
        Me.lblORDate.AutoSize = True
        Me.lblORDate.Location = New System.Drawing.Point(1068, 213)
        Me.lblORDate.Name = "lblORDate"
        Me.lblORDate.Size = New System.Drawing.Size(49, 13)
        Me.lblORDate.TabIndex = 19
        Me.lblORDate.Text = "ORDate:"
        '
        'lblDisplayStudentName
        '
        Me.lblDisplayStudentName.AutoSize = True
        Me.lblDisplayStudentName.Location = New System.Drawing.Point(930, 274)
        Me.lblDisplayStudentName.Name = "lblDisplayStudentName"
        Me.lblDisplayStudentName.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayStudentName.TabIndex = 20
        Me.lblDisplayStudentName.Text = "-"
        '
        'lblDisplayStudentNo
        '
        Me.lblDisplayStudentNo.AutoSize = True
        Me.lblDisplayStudentNo.Location = New System.Drawing.Point(930, 243)
        Me.lblDisplayStudentNo.Name = "lblDisplayStudentNo"
        Me.lblDisplayStudentNo.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayStudentNo.TabIndex = 21
        Me.lblDisplayStudentNo.Text = "-"
        '
        'lblDisplayORNo
        '
        Me.lblDisplayORNo.AutoSize = True
        Me.lblDisplayORNo.Location = New System.Drawing.Point(930, 213)
        Me.lblDisplayORNo.Name = "lblDisplayORNo"
        Me.lblDisplayORNo.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayORNo.TabIndex = 22
        Me.lblDisplayORNo.Text = "-"
        '
        'lblDisplayORDate
        '
        Me.lblDisplayORDate.AutoSize = True
        Me.lblDisplayORDate.Location = New System.Drawing.Point(1123, 213)
        Me.lblDisplayORDate.Name = "lblDisplayORDate"
        Me.lblDisplayORDate.Size = New System.Drawing.Size(10, 13)
        Me.lblDisplayORDate.TabIndex = 23
        Me.lblDisplayORDate.Text = "-"
        '
        'frmRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 765)
        Me.Controls.Add(Me.lblDisplayORDate)
        Me.Controls.Add(Me.lblDisplayORNo)
        Me.Controls.Add(Me.lblDisplayStudentNo)
        Me.Controls.Add(Me.lblDisplayStudentName)
        Me.Controls.Add(Me.lblORDate)
        Me.Controls.Add(Me.lblORNo)
        Me.Controls.Add(Me.lblStudentName)
        Me.Controls.Add(Me.lblStudentNo)
        Me.Controls.Add(Me.lblDisplayRequestHandled)
        Me.Controls.Add(Me.lblRequestHandledSince)
        Me.Controls.Add(Me.lblDisplayRequestCreated)
        Me.Controls.Add(Me.lblRequestCreated)
        Me.Controls.Add(Me.cboNewCurrentStatus)
        Me.Controls.Add(Me.lblNewCurrentStatus)
        Me.Controls.Add(Me.lblDisplayCurrentStatus)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCancelRequest)
        Me.Controls.Add(Me.btnUpdateRequest)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.lblCurrentStatus)
        Me.Controls.Add(Me.lblDisplayRecordedBy)
        Me.Controls.Add(Me.lblRecordedBy)
        Me.Name = "frmRequestManagement"
        Me.Text = "frmRequestManagement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRecordedBy As Label
    Friend WithEvents lblDisplayRecordedBy As Label
    Friend WithEvents lblCurrentStatus As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents btnUpdateRequest As Button
    Friend WithEvents btnCancelRequest As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents lblDisplayCurrentStatus As Label
    Friend WithEvents lblNewCurrentStatus As Label
    Friend WithEvents cboNewCurrentStatus As ComboBox
    Friend WithEvents lblRequestCreated As Label
    Friend WithEvents lblDisplayRequestCreated As Label
    Friend WithEvents lblRequestHandledSince As Label
    Friend WithEvents lblDisplayRequestHandled As Label
    Friend WithEvents lblStudentNo As Label
    Friend WithEvents lblStudentName As Label
    Friend WithEvents lblORNo As Label
    Friend WithEvents lblORDate As Label
    Friend WithEvents lblDisplayStudentName As Label
    Friend WithEvents lblDisplayStudentNo As Label
    Friend WithEvents lblDisplayORNo As Label
    Friend WithEvents lblDisplayORDate As Label
End Class
