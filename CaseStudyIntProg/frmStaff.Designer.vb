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
        Me.btnDocumentRequestList = New System.Windows.Forms.Button()
        Me.btnPaymentInformation = New System.Windows.Forms.Button()
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
        Me.SplitContainerMain.Panel1.Controls.Add(Me.TableLayoutPanelButtons)
        Me.SplitContainerMain.Size = New System.Drawing.Size(800, 450)
        Me.SplitContainerMain.SplitterDistance = 120
        Me.SplitContainerMain.TabIndex = 0
        '
        'TableLayoutPanelButtons
        '
        Me.TableLayoutPanelButtons.ColumnCount = 1
        Me.TableLayoutPanelButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentManagement, 0, 0)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentRequest, 0, 1)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentRequestList, 0, 2)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnPaymentInformation, 0, 3)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnSystemReport, 0, 4)
        Me.TableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanelButtons.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelButtons.Name = "TableLayoutPanelButtons"
        Me.TableLayoutPanelButtons.RowCount = 5
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0005!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0005!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0005!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9985!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanelButtons.Size = New System.Drawing.Size(120, 248)
        Me.TableLayoutPanelButtons.TabIndex = 0
        '
        'btnDocumentManagement
        '
        Me.btnDocumentManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentManagement.Location = New System.Drawing.Point(3, 3)
        Me.btnDocumentManagement.Name = "btnDocumentManagement"
        Me.btnDocumentManagement.Size = New System.Drawing.Size(114, 43)
        Me.btnDocumentManagement.TabIndex = 0
        Me.btnDocumentManagement.Text = "Document Management"
        Me.btnDocumentManagement.UseVisualStyleBackColor = True
        '
        'btnDocumentRequest
        '
        Me.btnDocumentRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentRequest.Location = New System.Drawing.Point(3, 52)
        Me.btnDocumentRequest.Name = "btnDocumentRequest"
        Me.btnDocumentRequest.Size = New System.Drawing.Size(114, 43)
        Me.btnDocumentRequest.TabIndex = 1
        Me.btnDocumentRequest.Text = "Document Request"
        Me.btnDocumentRequest.UseVisualStyleBackColor = True
        '
        'btnDocumentRequestList
        '
        Me.btnDocumentRequestList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentRequestList.Location = New System.Drawing.Point(3, 101)
        Me.btnDocumentRequestList.Name = "btnDocumentRequestList"
        Me.btnDocumentRequestList.Size = New System.Drawing.Size(114, 43)
        Me.btnDocumentRequestList.TabIndex = 2
        Me.btnDocumentRequestList.Text = "Request List"
        Me.btnDocumentRequestList.UseVisualStyleBackColor = True
        '
        'btnPaymentInformation
        '
        Me.btnPaymentInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPaymentInformation.Location = New System.Drawing.Point(3, 150)
        Me.btnPaymentInformation.Name = "btnPaymentInformation"
        Me.btnPaymentInformation.Size = New System.Drawing.Size(114, 43)
        Me.btnPaymentInformation.TabIndex = 3
        Me.btnPaymentInformation.Text = "Payment Information"
        Me.btnPaymentInformation.UseVisualStyleBackColor = True
        '
        'btnSystemReport
        '
        Me.btnSystemReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSystemReport.Location = New System.Drawing.Point(3, 199)
        Me.btnSystemReport.Name = "btnSystemReport"
        Me.btnSystemReport.Size = New System.Drawing.Size(114, 46)
        Me.btnSystemReport.TabIndex = 4
        Me.btnSystemReport.Text = "System Report"
        Me.btnSystemReport.UseVisualStyleBackColor = True
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
    Friend WithEvents btnDocumentRequestList As Button
    Friend WithEvents btnPaymentInformation As Button
    Friend WithEvents btnSystemReport As Button
End Class
