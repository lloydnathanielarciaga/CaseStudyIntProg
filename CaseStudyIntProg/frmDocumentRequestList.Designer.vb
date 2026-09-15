<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentRequestList
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
        Me.cboStatusFilter = New System.Windows.Forms.ComboBox()
        Me.cboSearchStudent = New System.Windows.Forms.ComboBox()
        Me.lblDocumentRequestList = New System.Windows.Forms.Label()
        Me.lblSearchRequest = New System.Windows.Forms.Label()
        Me.lblSearchStudent = New System.Windows.Forms.Label()
        Me.lblStatusFilter = New System.Windows.Forms.Label()
        Me.cboSearchRequest = New System.Windows.Forms.ComboBox()
        Me.btnClearAllSearch = New System.Windows.Forms.Button()
        Me.ListViewRequestList = New System.Windows.Forms.ListView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnProcessPayment = New System.Windows.Forms.Button()
        Me.btnEditSelectedRequest = New System.Windows.Forms.Button()
        Me.btnViewRequestDetails = New System.Windows.Forms.Button()
        Me.txtMode = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cboStatusFilter, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboSearchStudent, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDocumentRequestList, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSearchRequest, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSearchStudent, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatusFilter, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboSearchRequest, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnClearAllSearch, 2, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(363, 154)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cboStatusFilter
        '
        Me.cboStatusFilter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboStatusFilter.FormattingEnabled = True
        Me.cboStatusFilter.Location = New System.Drawing.Point(96, 123)
        Me.cboStatusFilter.Name = "cboStatusFilter"
        Me.cboStatusFilter.Size = New System.Drawing.Size(149, 21)
        Me.cboStatusFilter.TabIndex = 6
        '
        'cboSearchStudent
        '
        Me.cboSearchStudent.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboSearchStudent.FormattingEnabled = True
        Me.cboSearchStudent.Location = New System.Drawing.Point(96, 84)
        Me.cboSearchStudent.Name = "cboSearchStudent"
        Me.cboSearchStudent.Size = New System.Drawing.Size(149, 21)
        Me.cboSearchStudent.TabIndex = 5
        '
        'lblDocumentRequestList
        '
        Me.lblDocumentRequestList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDocumentRequestList.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblDocumentRequestList, 2)
        Me.lblDocumentRequestList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentRequestList.Location = New System.Drawing.Point(3, 12)
        Me.lblDocumentRequestList.Name = "lblDocumentRequestList"
        Me.lblDocumentRequestList.Size = New System.Drawing.Size(139, 13)
        Me.lblDocumentRequestList.TabIndex = 0
        Me.lblDocumentRequestList.Text = "Document Request List"
        '
        'lblSearchRequest
        '
        Me.lblSearchRequest.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSearchRequest.AutoSize = True
        Me.lblSearchRequest.Location = New System.Drawing.Point(3, 50)
        Me.lblSearchRequest.Name = "lblSearchRequest"
        Me.lblSearchRequest.Size = New System.Drawing.Size(87, 13)
        Me.lblSearchRequest.TabIndex = 1
        Me.lblSearchRequest.Text = "Search Request:"
        '
        'lblSearchStudent
        '
        Me.lblSearchStudent.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSearchStudent.AutoSize = True
        Me.lblSearchStudent.Location = New System.Drawing.Point(3, 88)
        Me.lblSearchStudent.Name = "lblSearchStudent"
        Me.lblSearchStudent.Size = New System.Drawing.Size(84, 13)
        Me.lblSearchStudent.TabIndex = 2
        Me.lblSearchStudent.Text = "Search Student:"
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStatusFilter.AutoSize = True
        Me.lblStatusFilter.Location = New System.Drawing.Point(3, 127)
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(65, 13)
        Me.lblStatusFilter.TabIndex = 3
        Me.lblStatusFilter.Text = "Status Filter:"
        '
        'cboSearchRequest
        '
        Me.cboSearchRequest.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboSearchRequest.FormattingEnabled = True
        Me.cboSearchRequest.Location = New System.Drawing.Point(96, 46)
        Me.cboSearchRequest.Name = "cboSearchRequest"
        Me.cboSearchRequest.Size = New System.Drawing.Size(149, 21)
        Me.cboSearchRequest.TabIndex = 4
        '
        'btnClearAllSearch
        '
        Me.btnClearAllSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnClearAllSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAllSearch.Location = New System.Drawing.Point(251, 45)
        Me.btnClearAllSearch.Name = "btnClearAllSearch"
        Me.btnClearAllSearch.Size = New System.Drawing.Size(107, 23)
        Me.btnClearAllSearch.TabIndex = 7
        Me.btnClearAllSearch.Text = "Clear All Search"
        Me.btnClearAllSearch.UseVisualStyleBackColor = True
        '
        'ListViewRequestList
        '
        Me.ListViewRequestList.HideSelection = False
        Me.ListViewRequestList.Location = New System.Drawing.Point(12, 202)
        Me.ListViewRequestList.Name = "ListViewRequestList"
        Me.ListViewRequestList.Size = New System.Drawing.Size(776, 198)
        Me.ListViewRequestList.TabIndex = 1
        Me.ListViewRequestList.UseCompatibleStateImageBehavior = False
        Me.ListViewRequestList.View = System.Windows.Forms.View.Details
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnProcessPayment, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEditSelectedRequest, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnViewRequestDetails, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(204, 406)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(425, 32)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'btnProcessPayment
        '
        Me.btnProcessPayment.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnProcessPayment.Location = New System.Drawing.Point(293, 4)
        Me.btnProcessPayment.Name = "btnProcessPayment"
        Me.btnProcessPayment.Size = New System.Drawing.Size(120, 23)
        Me.btnProcessPayment.TabIndex = 2
        Me.btnProcessPayment.Text = "Process Payment"
        Me.btnProcessPayment.UseVisualStyleBackColor = True
        '
        'btnEditSelectedRequest
        '
        Me.btnEditSelectedRequest.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnEditSelectedRequest.Location = New System.Drawing.Point(151, 4)
        Me.btnEditSelectedRequest.Name = "btnEditSelectedRequest"
        Me.btnEditSelectedRequest.Size = New System.Drawing.Size(120, 23)
        Me.btnEditSelectedRequest.TabIndex = 1
        Me.btnEditSelectedRequest.Text = "Edit Request"
        Me.btnEditSelectedRequest.UseVisualStyleBackColor = True
        '
        'btnViewRequestDetails
        '
        Me.btnViewRequestDetails.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnViewRequestDetails.Location = New System.Drawing.Point(10, 4)
        Me.btnViewRequestDetails.Name = "btnViewRequestDetails"
        Me.btnViewRequestDetails.Size = New System.Drawing.Size(120, 23)
        Me.btnViewRequestDetails.TabIndex = 0
        Me.btnViewRequestDetails.Text = "View Request Details"
        Me.btnViewRequestDetails.UseVisualStyleBackColor = True
        '
        'txtMode
        '
        Me.txtMode.AutoSize = True
        Me.txtMode.Location = New System.Drawing.Point(9, 186)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.Size = New System.Drawing.Size(60, 13)
        Me.txtMode.TabIndex = 3
        Me.txtMode.Text = "View Mode"
        '
        'frmDocumentRequestList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtMode)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.ListViewRequestList)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmDocumentRequestList"
        Me.Text = "frmDocumentRequestList"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblDocumentRequestList As Label
    Friend WithEvents cboStatusFilter As ComboBox
    Friend WithEvents cboSearchStudent As ComboBox
    Friend WithEvents lblSearchRequest As Label
    Friend WithEvents lblSearchStudent As Label
    Friend WithEvents lblStatusFilter As Label
    Friend WithEvents cboSearchRequest As ComboBox
    Friend WithEvents btnClearAllSearch As Button
    Friend WithEvents ListViewRequestList As ListView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnEditSelectedRequest As Button
    Friend WithEvents btnViewRequestDetails As Button
    Friend WithEvents btnProcessPayment As Button
    Friend WithEvents txtMode As Label
End Class
