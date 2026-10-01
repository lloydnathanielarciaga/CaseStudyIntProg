<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
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
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.btnStudentManagement = New System.Windows.Forms.Button()
        Me.btnDocumentManagement = New System.Windows.Forms.Button()
        Me.btnDocumentRequestList = New System.Windows.Forms.Button()
        Me.btnSystemReport = New System.Windows.Forms.Button()
        Me.btnUserManagement = New System.Windows.Forms.Button()
        Me.cboSemester = New Guna.UI2.WinForms.Guna2ComboBox()
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
        Me.SplitContainerMain.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SplitContainerMain.Panel1.Controls.Add(Me.cboSemester)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.TableLayoutPanelButtons)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.BackgroundImage = Global.CaseStudyIntProg.My.Resources.Resources.registrarbg2
        Me.SplitContainerMain.Size = New System.Drawing.Size(1707, 813)
        Me.SplitContainerMain.SplitterDistance = 256
        Me.SplitContainerMain.TabIndex = 1
        '
        'TableLayoutPanelButtons
        '
        Me.TableLayoutPanelButtons.ColumnCount = 1
        Me.TableLayoutPanelButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDashboard, 0, 5)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnStudentManagement, 0, 3)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentManagement, 0, 0)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnDocumentRequestList, 0, 1)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnSystemReport, 0, 2)
        Me.TableLayoutPanelButtons.Controls.Add(Me.btnUserManagement, 0, 4)
        Me.TableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanelButtons.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelButtons.Name = "TableLayoutPanelButtons"
        Me.TableLayoutPanelButtons.RowCount = 6
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66547!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66547!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66507!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66507!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.6684!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67053!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelButtons.Size = New System.Drawing.Size(256, 362)
        Me.TableLayoutPanelButtons.TabIndex = 0
        '
        'btnDashboard
        '
        Me.btnDashboard.BackColor = System.Drawing.Color.Black
        Me.btnDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDashboard.ForeColor = System.Drawing.Color.White
        Me.btnDashboard.Location = New System.Drawing.Point(3, 303)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(250, 56)
        Me.btnDashboard.TabIndex = 7
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.UseVisualStyleBackColor = False
        '
        'btnStudentManagement
        '
        Me.btnStudentManagement.BackColor = System.Drawing.Color.Black
        Me.btnStudentManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStudentManagement.ForeColor = System.Drawing.Color.White
        Me.btnStudentManagement.Location = New System.Drawing.Point(3, 183)
        Me.btnStudentManagement.Name = "btnStudentManagement"
        Me.btnStudentManagement.Size = New System.Drawing.Size(250, 54)
        Me.btnStudentManagement.TabIndex = 6
        Me.btnStudentManagement.Text = "Student Management"
        Me.btnStudentManagement.UseVisualStyleBackColor = False
        '
        'btnDocumentManagement
        '
        Me.btnDocumentManagement.BackColor = System.Drawing.Color.Black
        Me.btnDocumentManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentManagement.ForeColor = System.Drawing.Color.White
        Me.btnDocumentManagement.Location = New System.Drawing.Point(3, 3)
        Me.btnDocumentManagement.Name = "btnDocumentManagement"
        Me.btnDocumentManagement.Size = New System.Drawing.Size(250, 54)
        Me.btnDocumentManagement.TabIndex = 0
        Me.btnDocumentManagement.Text = "Document Management"
        Me.btnDocumentManagement.UseVisualStyleBackColor = False
        '
        'btnDocumentRequestList
        '
        Me.btnDocumentRequestList.BackColor = System.Drawing.Color.Black
        Me.btnDocumentRequestList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDocumentRequestList.ForeColor = System.Drawing.Color.White
        Me.btnDocumentRequestList.Location = New System.Drawing.Point(3, 63)
        Me.btnDocumentRequestList.Name = "btnDocumentRequestList"
        Me.btnDocumentRequestList.Size = New System.Drawing.Size(250, 54)
        Me.btnDocumentRequestList.TabIndex = 2
        Me.btnDocumentRequestList.Text = "Request List"
        Me.btnDocumentRequestList.UseVisualStyleBackColor = False
        '
        'btnSystemReport
        '
        Me.btnSystemReport.BackColor = System.Drawing.Color.Black
        Me.btnSystemReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSystemReport.ForeColor = System.Drawing.Color.White
        Me.btnSystemReport.Location = New System.Drawing.Point(3, 123)
        Me.btnSystemReport.Name = "btnSystemReport"
        Me.btnSystemReport.Size = New System.Drawing.Size(250, 54)
        Me.btnSystemReport.TabIndex = 4
        Me.btnSystemReport.Text = "System Report"
        Me.btnSystemReport.UseVisualStyleBackColor = False
        '
        'btnUserManagement
        '
        Me.btnUserManagement.BackColor = System.Drawing.Color.Black
        Me.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnUserManagement.ForeColor = System.Drawing.Color.White
        Me.btnUserManagement.Location = New System.Drawing.Point(3, 243)
        Me.btnUserManagement.Name = "btnUserManagement"
        Me.btnUserManagement.Size = New System.Drawing.Size(250, 54)
        Me.btnUserManagement.TabIndex = 5
        Me.btnUserManagement.Text = "User Management"
        Me.btnUserManagement.UseVisualStyleBackColor = False
        '
        'cboSemester
        '
        Me.cboSemester.BackColor = System.Drawing.Color.Transparent
        Me.cboSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSemester.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboSemester.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboSemester.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboSemester.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cboSemester.ItemHeight = 30
        Me.cboSemester.Location = New System.Drawing.Point(12, 692)
        Me.cboSemester.Name = "cboSemester"
        Me.cboSemester.Size = New System.Drawing.Size(228, 36)
        Me.cboSemester.TabIndex = 1
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1707, 813)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Name = "frmAdmin"
        Me.Text = "Admin Dashboard"
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
    Friend WithEvents btnDocumentRequestList As Button
    Friend WithEvents btnSystemReport As Button
    Friend WithEvents btnUserManagement As Button
    Friend WithEvents btnStudentManagement As Button
    Friend WithEvents cboSemester As Guna.UI2.WinForms.Guna2ComboBox
End Class
