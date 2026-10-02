<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransactionHistoryAndAuditLogPrompt
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageTransactionHistory = New System.Windows.Forms.TabPage()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ListViewTransactionHistory = New System.Windows.Forms.ListView()
        Me.TabPageAuditLog = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListViewAuditLog = New System.Windows.Forms.ListView()
        Me.TabControl1.SuspendLayout()
        Me.TabPageTransactionHistory.SuspendLayout()
        Me.TabPageAuditLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageTransactionHistory)
        Me.TabControl1.Controls.Add(Me.TabPageAuditLog)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(800, 450)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageTransactionHistory
        '
        Me.TabPageTransactionHistory.Controls.Add(Me.btnClose)
        Me.TabPageTransactionHistory.Controls.Add(Me.ListViewTransactionHistory)
        Me.TabPageTransactionHistory.Location = New System.Drawing.Point(4, 22)
        Me.TabPageTransactionHistory.Name = "TabPageTransactionHistory"
        Me.TabPageTransactionHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTransactionHistory.Size = New System.Drawing.Size(792, 424)
        Me.TabPageTransactionHistory.TabIndex = 0
        Me.TabPageTransactionHistory.Text = "Transaction History"
        Me.TabPageTransactionHistory.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(686, 389)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 27)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ListViewTransactionHistory
        '
        Me.ListViewTransactionHistory.HideSelection = False
        Me.ListViewTransactionHistory.Location = New System.Drawing.Point(8, 6)
        Me.ListViewTransactionHistory.Name = "ListViewTransactionHistory"
        Me.ListViewTransactionHistory.Size = New System.Drawing.Size(776, 377)
        Me.ListViewTransactionHistory.TabIndex = 0
        Me.ListViewTransactionHistory.UseCompatibleStateImageBehavior = False
        '
        'TabPageAuditLog
        '
        Me.TabPageAuditLog.Controls.Add(Me.Button1)
        Me.TabPageAuditLog.Controls.Add(Me.ListViewAuditLog)
        Me.TabPageAuditLog.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAuditLog.Name = "TabPageAuditLog"
        Me.TabPageAuditLog.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAuditLog.Size = New System.Drawing.Size(792, 424)
        Me.TabPageAuditLog.TabIndex = 1
        Me.TabPageAuditLog.Text = "Audit Logs"
        Me.TabPageAuditLog.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(686, 390)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 27)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListViewAuditLog
        '
        Me.ListViewAuditLog.HideSelection = False
        Me.ListViewAuditLog.Location = New System.Drawing.Point(8, 7)
        Me.ListViewAuditLog.Name = "ListViewAuditLog"
        Me.ListViewAuditLog.Size = New System.Drawing.Size(776, 377)
        Me.ListViewAuditLog.TabIndex = 2
        Me.ListViewAuditLog.UseCompatibleStateImageBehavior = False
        '
        'frmTransactionHistoryAndAuditLogPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmTransactionHistoryAndAuditLogPrompt"
        Me.Text = "frmTransactionHistoryAndAuditLog"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageTransactionHistory.ResumeLayout(False)
        Me.TabPageAuditLog.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageTransactionHistory As TabPage
    Friend WithEvents TabPageAuditLog As TabPage
    Friend WithEvents btnClose As Button
    Friend WithEvents ListViewTransactionHistory As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents ListViewAuditLog As ListView
End Class
