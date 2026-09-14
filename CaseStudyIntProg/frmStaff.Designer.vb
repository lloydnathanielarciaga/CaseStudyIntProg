<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaff
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
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanelButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.btnDocumentManagement = New System.Windows.Forms.Button()
        Me.btnDocumentRequest = New System.Windows.Forms.Button()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.TableLayoutPanelButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.TableLayoutPanelButtons)
        Me.SplitContainerMain.Size = New System.Drawing.Size(800, 450)
        Me.SplitContainerMain.SplitterDistance = 120
        Me.SplitContainerMain.TabIndex = 0
        '
        'TableLayoutPanelButtons
        '
        Me.TableLayoutPanelButtons.ColumnCount = 1
        Me.TableLayoutPanelButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentManagement, 0, 0)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentRequest, 0, 1)
        Me.TableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanelButtons.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelButtons.Name = "TableLayoutPanelButtons"
        Me.TableLayoutPanelButtons.RowCount = 2
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelButtons.Size = New System.Drawing.Size(120, 100)
        Me.TableLayoutPanelButtons.TabIndex = 0
        '
        'btnDocumentManagement
        '
        Me.btnDocumentManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentManagement.Location = New System.Drawing.Point(3, 3)
        Me.btnDocumentManagement.Name = "btnDocumentManagement"
        Me.btnDocumentManagement.Size = New System.Drawing.Size(114, 44)
        Me.btnDocumentManagement.TabIndex = 0
        Me.btnDocumentManagement.Text = "Document Management"
        Me.btnDocumentManagement.UseVisualStyleBackColor = True
        '
        'btnDocumentRequest
        '
        Me.btnDocumentRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentRequest.Location = New System.Drawing.Point(3, 53)
        Me.btnDocumentRequest.Name = "btnDocumentRequest"
        Me.btnDocumentRequest.Size = New System.Drawing.Size(114, 44)
        Me.btnDocumentRequest.TabIndex = 1
        Me.btnDocumentRequest.Text = "Document Request"
        Me.btnDocumentRequest.UseVisualStyleBackColor = True
        '
        'frmStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Name = "frmStaff"
        Me.Text = "frmStaff"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.TableLayoutPanelButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerMain As SplitContainer
    Friend WithEvents TableLayoutPanelButtons As TableLayoutPanel
    Friend WithEvents btnDocumentManagement As Button
    Friend WithEvents btnDocumentRequest As Button
End Class
