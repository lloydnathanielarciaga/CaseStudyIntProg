<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentManagement
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtFee = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtDocumentName = New System.Windows.Forms.TextBox()
        Me.lblDocumentId = New System.Windows.Forms.Label()
        Me.lblDocuManage = New System.Windows.Forms.Label()
        Me.lblDocumentName = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblFee = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtDocumentId = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rdoActive = New System.Windows.Forms.RadioButton()
        Me.rdoInactive = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.ListViewDocument = New System.Windows.Forms.ListView()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtFee, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDescription, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDocumentName, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDocumentId, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDocuManage, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDocumentName, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDescription, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFee, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDocumentId, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnClear, 2, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28566!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28567!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28567!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28424!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(574, 220)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtFee
        '
        Me.txtFee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFee.Location = New System.Drawing.Point(99, 129)
        Me.txtFee.Name = "txtFee"
        Me.txtFee.Size = New System.Drawing.Size(63, 20)
        Me.txtFee.TabIndex = 9
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDescription.Location = New System.Drawing.Point(99, 98)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(172, 20)
        Me.txtDescription.TabIndex = 8
        '
        'txtDocumentName
        '
        Me.txtDocumentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDocumentName.Location = New System.Drawing.Point(99, 67)
        Me.txtDocumentName.Name = "txtDocumentName"
        Me.txtDocumentName.Size = New System.Drawing.Size(172, 20)
        Me.txtDocumentName.TabIndex = 7
        '
        'lblDocumentId
        '
        Me.lblDocumentId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDocumentId.AutoSize = True
        Me.lblDocumentId.Location = New System.Drawing.Point(3, 40)
        Me.lblDocumentId.Name = "lblDocumentId"
        Me.lblDocumentId.Size = New System.Drawing.Size(73, 13)
        Me.lblDocumentId.TabIndex = 1
        Me.lblDocumentId.Text = "Document ID:"
        '
        'lblDocuManage
        '
        Me.lblDocuManage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDocuManage.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblDocuManage, 2)
        Me.lblDocuManage.Location = New System.Drawing.Point(76, 9)
        Me.lblDocuManage.Name = "lblDocuManage"
        Me.lblDocuManage.Size = New System.Drawing.Size(121, 13)
        Me.lblDocuManage.TabIndex = 0
        Me.lblDocuManage.Text = "Document Management"
        '
        'lblDocumentName
        '
        Me.lblDocumentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDocumentName.AutoSize = True
        Me.lblDocumentName.Location = New System.Drawing.Point(3, 71)
        Me.lblDocumentName.Name = "lblDocumentName"
        Me.lblDocumentName.Size = New System.Drawing.Size(90, 13)
        Me.lblDocumentName.TabIndex = 2
        Me.lblDocumentName.Text = "Document Name:"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(3, 102)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(63, 13)
        Me.lblDescription.TabIndex = 3
        Me.lblDescription.Text = "Description:"
        '
        'lblFee
        '
        Me.lblFee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFee.AutoSize = True
        Me.lblFee.Location = New System.Drawing.Point(3, 133)
        Me.lblFee.Name = "lblFee"
        Me.lblFee.Size = New System.Drawing.Size(28, 13)
        Me.lblFee.TabIndex = 4
        Me.lblFee.Text = "Fee:"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(3, 164)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Status:"
        '
        'txtDocumentId
        '
        Me.txtDocumentId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDocumentId.Location = New System.Drawing.Point(99, 36)
        Me.txtDocumentId.Name = "txtDocumentId"
        Me.txtDocumentId.Size = New System.Drawing.Size(63, 20)
        Me.txtDocumentId.TabIndex = 6
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rdoActive, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rdoInactive, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(99, 158)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(172, 25)
        Me.TableLayoutPanel2.TabIndex = 10
        '
        'rdoActive
        '
        Me.rdoActive.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rdoActive.AutoSize = True
        Me.rdoActive.Location = New System.Drawing.Point(3, 4)
        Me.rdoActive.Name = "rdoActive"
        Me.rdoActive.Size = New System.Drawing.Size(55, 17)
        Me.rdoActive.TabIndex = 0
        Me.rdoActive.TabStop = True
        Me.rdoActive.Text = "Active"
        Me.rdoActive.UseVisualStyleBackColor = True
        '
        'rdoInactive
        '
        Me.rdoInactive.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rdoInactive.AutoSize = True
        Me.rdoInactive.Location = New System.Drawing.Point(89, 4)
        Me.rdoInactive.Name = "rdoInactive"
        Me.rdoInactive.Size = New System.Drawing.Size(63, 17)
        Me.rdoInactive.TabIndex = 1
        Me.rdoInactive.TabStop = True
        Me.rdoInactive.Text = "Inactive"
        Me.rdoInactive.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnAdd, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnEdit, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnDelete, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(277, 189)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(294, 28)
        Me.TableLayoutPanel3.TabIndex = 11
        '
        'btnAdd
        '
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAdd.Location = New System.Drawing.Point(3, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(91, 22)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEdit.Location = New System.Drawing.Point(100, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(91, 22)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDelete.Location = New System.Drawing.Point(197, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(94, 22)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'ListViewDocument
        '
        Me.ListViewDocument.HideSelection = False
        Me.ListViewDocument.Location = New System.Drawing.Point(12, 238)
        Me.ListViewDocument.Name = "ListViewDocument"
        Me.ListViewDocument.Size = New System.Drawing.Size(776, 200)
        Me.ListViewDocument.TabIndex = 1
        Me.ListViewDocument.UseCompatibleStateImageBehavior = False
        Me.ListViewDocument.View = System.Windows.Forms.View.Details
        '
        'btnClear
        '
        Me.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnClear.Location = New System.Drawing.Point(277, 35)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'frmDocumentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ListViewDocument)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmDocumentManagement"
        Me.Text = "frmDocumentManagement"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblDocumentId As Label
    Friend WithEvents lblDocuManage As Label
    Friend WithEvents lblDocumentName As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblFee As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtFee As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtDocumentName As TextBox
    Friend WithEvents txtDocumentId As TextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents rdoActive As RadioButton
    Friend WithEvents rdoInactive As RadioButton
    Friend WithEvents ListViewDocument As ListView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
End Class
