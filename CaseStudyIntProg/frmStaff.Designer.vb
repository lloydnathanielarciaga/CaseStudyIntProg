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
        Me.btnRequestManagement = New System.Windows.Forms.Button()
        Me.btnDocumentManagement = New System.Windows.Forms.Button()
        Me.btnDocumentRequest = New System.Windows.Forms.Button()
        Me.btnDocumentRequestList = New System.Windows.Forms.Button()
        Me.btnSystemReport = New System.Windows.Forms.Button()
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
        Me.SplitContainerMain.Panel1.BackColor = System.Drawing.Color.Black
        Me.SplitContainerMain.Panel1.Controls.Add(Me.TableLayoutPanelButtons)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.BackgroundImage = Global.CaseStudyIntProg.My.Resources.Resources.registrar_bg
        Me.SplitContainerMain.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.SplitContainerMain.Size = New System.Drawing.Size(1443, 862)
        Me.SplitContainerMain.SplitterDistance = 216
        Me.SplitContainerMain.TabIndex = 0
        '
        'TableLayoutPanelButtons
        '
        Me.TableLayoutPanelButtons.ColumnCount = 1
        Me.TableLayoutPanelButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnRequestManagement, 0, 4)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentManagement, 0, 0)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentRequest, 0, 1)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentRequestList, 0, 2)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnSystemReport, 0, 3)
        Me.TableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanelButtons.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelButtons.Name = "TableLayoutPanelButtons"
        Me.TableLayoutPanelButtons.RowCount = 5
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9994!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9994!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9994!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.99891!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0029!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelButtons.Size = New System.Drawing.Size(216, 366)
        Me.TableLayoutPanelButtons.TabIndex = 0
        '
        'btnRequestManagement
        '
        Me.btnRequestManagement.BackColor = System.Drawing.Color.Black
        Me.btnRequestManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRequestManagement.ForeColor = System.Drawing.Color.White
        Me.btnRequestManagement.Location = New System.Drawing.Point(3, 295)
        Me.btnRequestManagement.Name = "btnRequestManagement"
        Me.btnRequestManagement.Size = New System.Drawing.Size(210, 68)
        Me.btnRequestManagement.TabIndex = 6
        Me.btnRequestManagement.Text = "Manage Request"
        Me.btnRequestManagement.UseVisualStyleBackColor = False
        '
        'btnDocumentManagement
        '
        Me.btnDocumentManagement.BackColor = System.Drawing.Color.Black
        Me.btnDocumentManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentManagement.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDocumentManagement.Location = New System.Drawing.Point(3, 3)
        Me.btnDocumentManagement.Name = "btnDocumentManagement"
        Me.btnDocumentManagement.Size = New System.Drawing.Size(210, 67)
        Me.btnDocumentManagement.TabIndex = 0
        Me.btnDocumentManagement.Text = "Document Management"
        Me.btnDocumentManagement.UseVisualStyleBackColor = False
        '
        'btnDocumentRequest
        '
        Me.btnDocumentRequest.BackColor = System.Drawing.Color.Black
        Me.btnDocumentRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentRequest.ForeColor = System.Drawing.Color.White
        Me.btnDocumentRequest.Location = New System.Drawing.Point(3, 76)
        Me.btnDocumentRequest.Name = "btnDocumentRequest"
        Me.btnDocumentRequest.Size = New System.Drawing.Size(210, 67)
        Me.btnDocumentRequest.TabIndex = 1
        Me.btnDocumentRequest.Text = "Document Request"
        Me.btnDocumentRequest.UseVisualStyleBackColor = False
        '
        'btnDocumentRequestList
        '
        Me.btnDocumentRequestList.BackColor = System.Drawing.Color.Black
        Me.btnDocumentRequestList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentRequestList.ForeColor = System.Drawing.Color.White
        Me.btnDocumentRequestList.Location = New System.Drawing.Point(3, 149)
        Me.btnDocumentRequestList.Name = "btnDocumentRequestList"
        Me.btnDocumentRequestList.Size = New System.Drawing.Size(210, 67)
        Me.btnDocumentRequestList.TabIndex = 2
        Me.btnDocumentRequestList.Text = "Request List"
        Me.btnDocumentRequestList.UseVisualStyleBackColor = False
        '
        'btnSystemReport
        '
        Me.btnSystemReport.BackColor = System.Drawing.Color.Black
        Me.btnSystemReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSystemReport.ForeColor = System.Drawing.Color.White
        Me.btnSystemReport.Location = New System.Drawing.Point(3, 222)
        Me.btnSystemReport.Name = "btnSystemReport"
        Me.btnSystemReport.Size = New System.Drawing.Size(210, 67)
        Me.btnSystemReport.TabIndex = 4
        Me.btnSystemReport.Text = "System Report"
        Me.btnSystemReport.UseVisualStyleBackColor = False
        '
        'frmStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1443, 862)
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
    Friend WithEvents btnDocumentRequestList As Button
    Friend WithEvents btnSystemReport As Button
    Friend WithEvents btnRequestManagement As Button
End Class
