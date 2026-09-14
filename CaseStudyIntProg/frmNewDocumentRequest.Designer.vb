<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewDocumentRequest
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
        Me.lblCreateNewDocumentRequest = New System.Windows.Forms.Label()
        Me.lblRequestNo = New System.Windows.Forms.Label()
        Me.txtRequestNo = New System.Windows.Forms.Label()
        Me.lblProcessedBy = New System.Windows.Forms.Label()
        Me.cboProcessedBy = New System.Windows.Forms.ComboBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.DateTimePickerDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStudentInformation = New System.Windows.Forms.Label()
        Me.lblStudentId = New System.Windows.Forms.Label()
        Me.lblStudentName = New System.Windows.Forms.Label()
        Me.cboStudentId = New System.Windows.Forms.ComboBox()
        Me.cboStudentName = New System.Windows.Forms.ComboBox()
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.txtCourse = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.Label()
        Me.lblAddRequestItem = New System.Windows.Forms.Label()
        Me.lblDocumentName = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.cboDocumentName = New System.Windows.Forms.ComboBox()
        Me.NumericUpDownQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblFee = New System.Windows.Forms.Label()
        Me.txtFee = New System.Windows.Forms.Label()
        Me.lblRequestedDocument = New System.Windows.Forms.Label()
        Me.btnAddRequest = New System.Windows.Forms.Button()
        Me.ListViewNewRequest = New System.Windows.Forms.ListView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtTotalAmount = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCancelRequest = New System.Windows.Forms.Button()
        Me.btnSaveRequest = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NumericUpDownQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblCreateNewDocumentRequest, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRequestNo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRequestNo, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProcessedBy, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboProcessedBy, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDate, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerDate, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStudentInformation, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStudentId, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStudentName, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cboStudentId, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cboStudentName, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCourse, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblYear, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCourse, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtYear, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAddRequestItem, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDocumentName, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblQuantity, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDocumentName, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownQuantity, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFee, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFee, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRequestedDocument, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddRequest, 5, 7)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49948!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49949!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49949!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49824!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49917!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49917!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50167!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50328!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(776, 198)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblCreateNewDocumentRequest
        '
        Me.lblCreateNewDocumentRequest.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCreateNewDocumentRequest.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblCreateNewDocumentRequest, 2)
        Me.lblCreateNewDocumentRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreateNewDocumentRequest.Location = New System.Drawing.Point(3, 5)
        Me.lblCreateNewDocumentRequest.Name = "lblCreateNewDocumentRequest"
        Me.lblCreateNewDocumentRequest.Size = New System.Drawing.Size(185, 13)
        Me.lblCreateNewDocumentRequest.TabIndex = 0
        Me.lblCreateNewDocumentRequest.Text = "Create New Document Request"
        '
        'lblRequestNo
        '
        Me.lblRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRequestNo.AutoSize = True
        Me.lblRequestNo.Location = New System.Drawing.Point(3, 29)
        Me.lblRequestNo.Name = "lblRequestNo"
        Me.lblRequestNo.Size = New System.Drawing.Size(67, 13)
        Me.lblRequestNo.TabIndex = 1
        Me.lblRequestNo.Text = "Request No:"
        '
        'txtRequestNo
        '
        Me.txtRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRequestNo.AutoSize = True
        Me.txtRequestNo.Location = New System.Drawing.Point(87, 29)
        Me.txtRequestNo.Name = "txtRequestNo"
        Me.txtRequestNo.Size = New System.Drawing.Size(10, 13)
        Me.txtRequestNo.TabIndex = 2
        Me.txtRequestNo.Text = "-"
        '
        'lblProcessedBy
        '
        Me.lblProcessedBy.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProcessedBy.AutoSize = True
        Me.lblProcessedBy.Location = New System.Drawing.Point(3, 53)
        Me.lblProcessedBy.Name = "lblProcessedBy"
        Me.lblProcessedBy.Size = New System.Drawing.Size(75, 13)
        Me.lblProcessedBy.TabIndex = 3
        Me.lblProcessedBy.Text = "Processed By:"
        '
        'cboProcessedBy
        '
        Me.cboProcessedBy.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboProcessedBy.FormattingEnabled = True
        Me.cboProcessedBy.Location = New System.Drawing.Point(87, 51)
        Me.cboProcessedBy.Name = "cboProcessedBy"
        Me.cboProcessedBy.Size = New System.Drawing.Size(150, 21)
        Me.cboProcessedBy.TabIndex = 4
        '
        'lblDate
        '
        Me.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(243, 29)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(33, 13)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "Date:"
        '
        'DateTimePickerDate
        '
        Me.DateTimePickerDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DateTimePickerDate.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerDate.Location = New System.Drawing.Point(292, 27)
        Me.DateTimePickerDate.Name = "DateTimePickerDate"
        Me.DateTimePickerDate.Size = New System.Drawing.Size(112, 20)
        Me.DateTimePickerDate.TabIndex = 6
        '
        'lblStudentInformation
        '
        Me.lblStudentInformation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStudentInformation.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblStudentInformation, 2)
        Me.lblStudentInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudentInformation.Location = New System.Drawing.Point(3, 77)
        Me.lblStudentInformation.Name = "lblStudentInformation"
        Me.lblStudentInformation.Size = New System.Drawing.Size(118, 13)
        Me.lblStudentInformation.TabIndex = 7
        Me.lblStudentInformation.Text = "Student Information"
        '
        'lblStudentId
        '
        Me.lblStudentId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStudentId.AutoSize = True
        Me.lblStudentId.Location = New System.Drawing.Point(3, 101)
        Me.lblStudentId.Name = "lblStudentId"
        Me.lblStudentId.Size = New System.Drawing.Size(61, 13)
        Me.lblStudentId.TabIndex = 8
        Me.lblStudentId.Text = "Student ID:"
        '
        'lblStudentName
        '
        Me.lblStudentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStudentName.AutoSize = True
        Me.lblStudentName.Location = New System.Drawing.Point(3, 125)
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(78, 13)
        Me.lblStudentName.TabIndex = 9
        Me.lblStudentName.Text = "Student Name:"
        '
        'cboStudentId
        '
        Me.cboStudentId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboStudentId.FormattingEnabled = True
        Me.cboStudentId.Location = New System.Drawing.Point(87, 99)
        Me.cboStudentId.Name = "cboStudentId"
        Me.cboStudentId.Size = New System.Drawing.Size(150, 21)
        Me.cboStudentId.TabIndex = 10
        '
        'cboStudentName
        '
        Me.cboStudentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboStudentName.FormattingEnabled = True
        Me.cboStudentName.Location = New System.Drawing.Point(87, 123)
        Me.cboStudentName.Name = "cboStudentName"
        Me.cboStudentName.Size = New System.Drawing.Size(150, 21)
        Me.cboStudentName.TabIndex = 11
        '
        'lblCourse
        '
        Me.lblCourse.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCourse.AutoSize = True
        Me.lblCourse.Location = New System.Drawing.Point(243, 101)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(43, 13)
        Me.lblCourse.TabIndex = 12
        Me.lblCourse.Text = "Course:"
        '
        'lblYear
        '
        Me.lblYear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(243, 125)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 13
        Me.lblYear.Text = "Year:"
        '
        'txtCourse
        '
        Me.txtCourse.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCourse.AutoSize = True
        Me.txtCourse.Location = New System.Drawing.Point(292, 101)
        Me.txtCourse.Name = "txtCourse"
        Me.txtCourse.Size = New System.Drawing.Size(10, 13)
        Me.txtCourse.TabIndex = 14
        Me.txtCourse.Text = "-"
        '
        'txtYear
        '
        Me.txtYear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtYear.AutoSize = True
        Me.txtYear.Location = New System.Drawing.Point(292, 125)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(10, 13)
        Me.txtYear.TabIndex = 15
        Me.txtYear.Text = "-"
        '
        'lblAddRequestItem
        '
        Me.lblAddRequestItem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAddRequestItem.AutoSize = True
        Me.lblAddRequestItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddRequestItem.Location = New System.Drawing.Point(410, 77)
        Me.lblAddRequestItem.Name = "lblAddRequestItem"
        Me.lblAddRequestItem.Size = New System.Drawing.Size(108, 13)
        Me.lblAddRequestItem.TabIndex = 16
        Me.lblAddRequestItem.Text = "Add Request Item"
        '
        'lblDocumentName
        '
        Me.lblDocumentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDocumentName.AutoSize = True
        Me.lblDocumentName.Location = New System.Drawing.Point(410, 101)
        Me.lblDocumentName.Name = "lblDocumentName"
        Me.lblDocumentName.Size = New System.Drawing.Size(90, 13)
        Me.lblDocumentName.TabIndex = 17
        Me.lblDocumentName.Text = "Document Name:"
        '
        'lblQuantity
        '
        Me.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(410, 125)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(49, 13)
        Me.lblQuantity.TabIndex = 18
        Me.lblQuantity.Text = "Quantity:"
        '
        'cboDocumentName
        '
        Me.cboDocumentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboDocumentName.FormattingEnabled = True
        Me.cboDocumentName.Location = New System.Drawing.Point(524, 99)
        Me.cboDocumentName.Name = "cboDocumentName"
        Me.cboDocumentName.Size = New System.Drawing.Size(156, 21)
        Me.cboDocumentName.TabIndex = 19
        '
        'NumericUpDownQuantity
        '
        Me.NumericUpDownQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.NumericUpDownQuantity.Location = New System.Drawing.Point(524, 123)
        Me.NumericUpDownQuantity.Name = "NumericUpDownQuantity"
        Me.NumericUpDownQuantity.Size = New System.Drawing.Size(53, 20)
        Me.NumericUpDownQuantity.TabIndex = 20
        '
        'lblFee
        '
        Me.lblFee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFee.AutoSize = True
        Me.lblFee.Location = New System.Drawing.Point(410, 149)
        Me.lblFee.Name = "lblFee"
        Me.lblFee.Size = New System.Drawing.Size(28, 13)
        Me.lblFee.TabIndex = 22
        Me.lblFee.Text = "Fee:"
        '
        'txtFee
        '
        Me.txtFee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFee.AutoSize = True
        Me.txtFee.Location = New System.Drawing.Point(524, 149)
        Me.txtFee.Name = "txtFee"
        Me.txtFee.Size = New System.Drawing.Size(10, 13)
        Me.txtFee.TabIndex = 23
        Me.txtFee.Text = "-"
        '
        'lblRequestedDocument
        '
        Me.lblRequestedDocument.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRequestedDocument.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblRequestedDocument, 2)
        Me.lblRequestedDocument.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestedDocument.Location = New System.Drawing.Point(3, 176)
        Me.lblRequestedDocument.Name = "lblRequestedDocument"
        Me.lblRequestedDocument.Size = New System.Drawing.Size(135, 13)
        Me.lblRequestedDocument.TabIndex = 21
        Me.lblRequestedDocument.Text = "Requested Documents"
        '
        'btnAddRequest
        '
        Me.btnAddRequest.Location = New System.Drawing.Point(524, 171)
        Me.btnAddRequest.Name = "btnAddRequest"
        Me.btnAddRequest.Size = New System.Drawing.Size(105, 23)
        Me.btnAddRequest.TabIndex = 24
        Me.btnAddRequest.Text = "Add Request"
        Me.btnAddRequest.UseVisualStyleBackColor = True
        '
        'ListViewNewRequest
        '
        Me.ListViewNewRequest.HideSelection = False
        Me.ListViewNewRequest.Location = New System.Drawing.Point(12, 216)
        Me.ListViewNewRequest.Name = "ListViewNewRequest"
        Me.ListViewNewRequest.Size = New System.Drawing.Size(776, 154)
        Me.ListViewNewRequest.TabIndex = 1
        Me.ListViewNewRequest.UseCompatibleStateImageBehavior = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtTotalAmount, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTotalAmount, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(588, 376)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 32)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTotalAmount.AutoSize = True
        Me.txtTotalAmount.Location = New System.Drawing.Point(103, 9)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(10, 13)
        Me.txtTotalAmount.TabIndex = 24
        Me.txtTotalAmount.Text = "-"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Location = New System.Drawing.Point(3, 9)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(73, 13)
        Me.lblTotalAmount.TabIndex = 23
        Me.lblTotalAmount.Text = "Total Amount:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnCancelRequest, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnSaveRequest, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(307, 376)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(200, 32)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'btnCancelRequest
        '
        Me.btnCancelRequest.Location = New System.Drawing.Point(103, 3)
        Me.btnCancelRequest.Name = "btnCancelRequest"
        Me.btnCancelRequest.Size = New System.Drawing.Size(94, 23)
        Me.btnCancelRequest.TabIndex = 26
        Me.btnCancelRequest.Text = "Cancel Request"
        Me.btnCancelRequest.UseVisualStyleBackColor = True
        '
        'btnSaveRequest
        '
        Me.btnSaveRequest.Location = New System.Drawing.Point(3, 3)
        Me.btnSaveRequest.Name = "btnSaveRequest"
        Me.btnSaveRequest.Size = New System.Drawing.Size(94, 23)
        Me.btnSaveRequest.TabIndex = 25
        Me.btnSaveRequest.Text = "Save Request"
        Me.btnSaveRequest.UseVisualStyleBackColor = True
        '
        'frmNewDocumentRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.ListViewNewRequest)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmNewDocumentRequest"
        Me.Text = "frmNewDocumentRequest"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.NumericUpDownQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblCreateNewDocumentRequest As Label
    Friend WithEvents lblRequestNo As Label
    Friend WithEvents txtRequestNo As Label
    Friend WithEvents lblProcessedBy As Label
    Friend WithEvents cboProcessedBy As ComboBox
    Friend WithEvents lblDate As Label
    Friend WithEvents DateTimePickerDate As DateTimePicker
    Friend WithEvents lblStudentInformation As Label
    Friend WithEvents lblStudentId As Label
    Friend WithEvents lblStudentName As Label
    Friend WithEvents cboStudentId As ComboBox
    Friend WithEvents cboStudentName As ComboBox
    Friend WithEvents lblCourse As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents txtCourse As Label
    Friend WithEvents txtYear As Label
    Friend WithEvents lblAddRequestItem As Label
    Friend WithEvents lblDocumentName As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents cboDocumentName As ComboBox
    Friend WithEvents NumericUpDownQuantity As NumericUpDown
    Friend WithEvents lblRequestedDocument As Label
    Friend WithEvents ListViewNewRequest As ListView
    Friend WithEvents lblFee As Label
    Friend WithEvents txtFee As Label
    Friend WithEvents btnAddRequest As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents txtTotalAmount As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btnCancelRequest As Button
    Friend WithEvents btnSaveRequest As Button
End Class
