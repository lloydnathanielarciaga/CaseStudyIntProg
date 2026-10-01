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
        Me.lblStudentInformation = New System.Windows.Forms.Label()
        Me.lblStudentId = New System.Windows.Forms.Label()
        Me.lblStudentName = New System.Windows.Forms.Label()
        Me.lblAddRequestItem = New System.Windows.Forms.Label()
        Me.lblDocumentName = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.cboDocumentName = New System.Windows.Forms.ComboBox()
        Me.NumericUpDownQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblFee = New System.Windows.Forms.Label()
        Me.txtFee = New System.Windows.Forms.Label()
        Me.lblRequestedDocument = New System.Windows.Forms.Label()
        Me.btnAddRequest = New System.Windows.Forms.Button()
        Me.lblPurpose = New System.Windows.Forms.Label()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.DateTimePickerDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSearchStudentIdOrStudentLastName = New System.Windows.Forms.TextBox()
        Me.txtStudentName = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.Label()
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.txtCourse = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblRecordedBy = New System.Windows.Forms.Label()
        Me.txtRecordedBy = New System.Windows.Forms.Label()
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
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
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
        Me.TableLayoutPanel1.Controls.Add(Me.lblStudentInformation, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStudentId, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStudentName, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAddRequestItem, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDocumentName, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblQuantity, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDocumentName, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownQuantity, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFee, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFee, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRequestedDocument, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddRequest, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPurpose, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPurpose, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDate, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerDate, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSearchStudentIdOrStudentLastName, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtStudentName, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblYear, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtYear, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCourse, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCourse, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSearch, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRecordedBy, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRecordedBy, 3, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.White
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(776, 208)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblCreateNewDocumentRequest
        '
        Me.lblCreateNewDocumentRequest.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCreateNewDocumentRequest.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblCreateNewDocumentRequest, 2)
        Me.lblCreateNewDocumentRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreateNewDocumentRequest.ForeColor = System.Drawing.Color.White
        Me.lblCreateNewDocumentRequest.Location = New System.Drawing.Point(3, 6)
        Me.lblCreateNewDocumentRequest.Name = "lblCreateNewDocumentRequest"
        Me.lblCreateNewDocumentRequest.Size = New System.Drawing.Size(185, 13)
        Me.lblCreateNewDocumentRequest.TabIndex = 0
        Me.lblCreateNewDocumentRequest.Text = "Create New Document Request"
        '
        'lblRequestNo
        '
        Me.lblRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRequestNo.AutoSize = True
        Me.lblRequestNo.ForeColor = System.Drawing.Color.White
        Me.lblRequestNo.Location = New System.Drawing.Point(3, 31)
        Me.lblRequestNo.Name = "lblRequestNo"
        Me.lblRequestNo.Size = New System.Drawing.Size(67, 13)
        Me.lblRequestNo.TabIndex = 1
        Me.lblRequestNo.Text = "Request No:"
        '
        'txtRequestNo
        '
        Me.txtRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRequestNo.AutoSize = True
        Me.txtRequestNo.Location = New System.Drawing.Point(87, 31)
        Me.txtRequestNo.Name = "txtRequestNo"
        Me.txtRequestNo.Size = New System.Drawing.Size(10, 13)
        Me.txtRequestNo.TabIndex = 2
        Me.txtRequestNo.Text = "-"
        '
        'lblStudentInformation
        '
        Me.lblStudentInformation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStudentInformation.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblStudentInformation, 2)
        Me.lblStudentInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudentInformation.ForeColor = System.Drawing.Color.White
        Me.lblStudentInformation.Location = New System.Drawing.Point(3, 81)
        Me.lblStudentInformation.Name = "lblStudentInformation"
        Me.lblStudentInformation.Size = New System.Drawing.Size(118, 13)
        Me.lblStudentInformation.TabIndex = 7
        Me.lblStudentInformation.Text = "Student Information"
        '
        'lblStudentId
        '
        Me.lblStudentId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStudentId.AutoSize = True
        Me.lblStudentId.ForeColor = System.Drawing.Color.White
        Me.lblStudentId.Location = New System.Drawing.Point(3, 106)
        Me.lblStudentId.Name = "lblStudentId"
        Me.lblStudentId.Size = New System.Drawing.Size(61, 13)
        Me.lblStudentId.TabIndex = 8
        Me.lblStudentId.Text = "Student ID:"
        '
        'lblStudentName
        '
        Me.lblStudentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStudentName.AutoSize = True
        Me.lblStudentName.ForeColor = System.Drawing.Color.White
        Me.lblStudentName.Location = New System.Drawing.Point(3, 131)
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(78, 13)
        Me.lblStudentName.TabIndex = 9
        Me.lblStudentName.Text = "Student Name:"
        '
        'lblAddRequestItem
        '
        Me.lblAddRequestItem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAddRequestItem.AutoSize = True
        Me.lblAddRequestItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddRequestItem.ForeColor = System.Drawing.Color.White
        Me.lblAddRequestItem.Location = New System.Drawing.Point(340, 81)
        Me.lblAddRequestItem.Name = "lblAddRequestItem"
        Me.lblAddRequestItem.Size = New System.Drawing.Size(108, 13)
        Me.lblAddRequestItem.TabIndex = 16
        Me.lblAddRequestItem.Text = "Add Request Item"
        '
        'lblDocumentName
        '
        Me.lblDocumentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDocumentName.AutoSize = True
        Me.lblDocumentName.ForeColor = System.Drawing.Color.White
        Me.lblDocumentName.Location = New System.Drawing.Point(340, 106)
        Me.lblDocumentName.Name = "lblDocumentName"
        Me.lblDocumentName.Size = New System.Drawing.Size(90, 13)
        Me.lblDocumentName.TabIndex = 17
        Me.lblDocumentName.Text = "Document Name:"
        '
        'lblQuantity
        '
        Me.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.ForeColor = System.Drawing.Color.White
        Me.lblQuantity.Location = New System.Drawing.Point(340, 131)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(49, 13)
        Me.lblQuantity.TabIndex = 18
        Me.lblQuantity.Text = "Quantity:"
        '
        'cboDocumentName
        '
        Me.cboDocumentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboDocumentName.FormattingEnabled = True
        Me.cboDocumentName.Location = New System.Drawing.Point(454, 103)
        Me.cboDocumentName.Name = "cboDocumentName"
        Me.cboDocumentName.Size = New System.Drawing.Size(156, 21)
        Me.cboDocumentName.TabIndex = 19
        '
        'NumericUpDownQuantity
        '
        Me.NumericUpDownQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.NumericUpDownQuantity.Location = New System.Drawing.Point(454, 128)
        Me.NumericUpDownQuantity.Name = "NumericUpDownQuantity"
        Me.NumericUpDownQuantity.Size = New System.Drawing.Size(53, 20)
        Me.NumericUpDownQuantity.TabIndex = 20
        Me.NumericUpDownQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblFee
        '
        Me.lblFee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFee.AutoSize = True
        Me.lblFee.ForeColor = System.Drawing.Color.White
        Me.lblFee.Location = New System.Drawing.Point(340, 156)
        Me.lblFee.Name = "lblFee"
        Me.lblFee.Size = New System.Drawing.Size(28, 13)
        Me.lblFee.TabIndex = 22
        Me.lblFee.Text = "Fee:"
        '
        'txtFee
        '
        Me.txtFee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFee.AutoSize = True
        Me.txtFee.Location = New System.Drawing.Point(454, 156)
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
        Me.lblRequestedDocument.Location = New System.Drawing.Point(3, 185)
        Me.lblRequestedDocument.Name = "lblRequestedDocument"
        Me.lblRequestedDocument.Size = New System.Drawing.Size(135, 13)
        Me.lblRequestedDocument.TabIndex = 21
        Me.lblRequestedDocument.Text = "Requested Documents"
        '
        'btnAddRequest
        '
        Me.btnAddRequest.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAddRequest.ForeColor = System.Drawing.Color.White
        Me.btnAddRequest.Location = New System.Drawing.Point(454, 179)
        Me.btnAddRequest.Name = "btnAddRequest"
        Me.btnAddRequest.Size = New System.Drawing.Size(105, 23)
        Me.btnAddRequest.TabIndex = 24
        Me.btnAddRequest.Text = "Add Request"
        Me.btnAddRequest.UseVisualStyleBackColor = False
        '
        'lblPurpose
        '
        Me.lblPurpose.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPurpose.AutoSize = True
        Me.lblPurpose.ForeColor = System.Drawing.Color.White
        Me.lblPurpose.Location = New System.Drawing.Point(3, 156)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(49, 13)
        Me.lblPurpose.TabIndex = 25
        Me.lblPurpose.Text = "Purpose:"
        '
        'txtPurpose
        '
        Me.txtPurpose.Location = New System.Drawing.Point(87, 153)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(150, 20)
        Me.txtPurpose.TabIndex = 26
        '
        'lblDate
        '
        Me.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDate.AutoSize = True
        Me.lblDate.ForeColor = System.Drawing.Color.White
        Me.lblDate.Location = New System.Drawing.Point(3, 56)
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
        Me.DateTimePickerDate.Location = New System.Drawing.Point(87, 53)
        Me.DateTimePickerDate.Name = "DateTimePickerDate"
        Me.DateTimePickerDate.Size = New System.Drawing.Size(112, 20)
        Me.DateTimePickerDate.TabIndex = 6
        '
        'txtSearchStudentIdOrStudentLastName
        '
        Me.txtSearchStudentIdOrStudentLastName.Location = New System.Drawing.Point(87, 103)
        Me.txtSearchStudentIdOrStudentLastName.Name = "txtSearchStudentIdOrStudentLastName"
        Me.txtSearchStudentIdOrStudentLastName.Size = New System.Drawing.Size(150, 20)
        Me.txtSearchStudentIdOrStudentLastName.TabIndex = 27
        '
        'txtStudentName
        '
        Me.txtStudentName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtStudentName.AutoSize = True
        Me.txtStudentName.Location = New System.Drawing.Point(87, 131)
        Me.txtStudentName.Name = "txtStudentName"
        Me.txtStudentName.Size = New System.Drawing.Size(10, 13)
        Me.txtStudentName.TabIndex = 28
        Me.txtStudentName.Text = "-"
        '
        'lblYear
        '
        Me.lblYear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblYear.AutoSize = True
        Me.lblYear.ForeColor = System.Drawing.Color.White
        Me.lblYear.Location = New System.Drawing.Point(243, 156)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 13
        Me.lblYear.Text = "Year:"
        '
        'txtYear
        '
        Me.txtYear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtYear.AutoSize = True
        Me.txtYear.Location = New System.Drawing.Point(324, 156)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(10, 13)
        Me.txtYear.TabIndex = 15
        Me.txtYear.Text = "-"
        '
        'lblCourse
        '
        Me.lblCourse.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCourse.AutoSize = True
        Me.lblCourse.ForeColor = System.Drawing.Color.White
        Me.lblCourse.Location = New System.Drawing.Point(243, 131)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(43, 13)
        Me.lblCourse.TabIndex = 12
        Me.lblCourse.Text = "Course:"
        '
        'txtCourse
        '
        Me.txtCourse.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCourse.AutoSize = True
        Me.txtCourse.Location = New System.Drawing.Point(324, 131)
        Me.txtCourse.Name = "txtCourse"
        Me.txtCourse.Size = New System.Drawing.Size(10, 13)
        Me.txtCourse.TabIndex = 14
        Me.txtCourse.Text = "-"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(243, 103)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 19)
        Me.btnSearch.TabIndex = 29
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblRecordedBy
        '
        Me.lblRecordedBy.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRecordedBy.AutoSize = True
        Me.lblRecordedBy.ForeColor = System.Drawing.Color.White
        Me.lblRecordedBy.Location = New System.Drawing.Point(243, 31)
        Me.lblRecordedBy.Name = "lblRecordedBy"
        Me.lblRecordedBy.Size = New System.Drawing.Size(72, 13)
        Me.lblRecordedBy.TabIndex = 30
        Me.lblRecordedBy.Text = "Recorded By:"
        '
        'txtRecordedBy
        '
        Me.txtRecordedBy.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRecordedBy.AutoSize = True
        Me.txtRecordedBy.Location = New System.Drawing.Point(324, 31)
        Me.txtRecordedBy.Name = "txtRecordedBy"
        Me.txtRecordedBy.Size = New System.Drawing.Size(10, 13)
        Me.txtRecordedBy.TabIndex = 31
        Me.txtRecordedBy.Text = "-"
        '
        'ListViewNewRequest
        '
        Me.ListViewNewRequest.BackColor = System.Drawing.Color.Lavender
        Me.ListViewNewRequest.HideSelection = False
        Me.ListViewNewRequest.Location = New System.Drawing.Point(12, 235)
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(588, 395)
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
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnCancelRequest, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnSaveRequest, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(307, 395)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(200, 32)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'btnCancelRequest
        '
        Me.btnCancelRequest.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCancelRequest.ForeColor = System.Drawing.Color.White
        Me.btnCancelRequest.Location = New System.Drawing.Point(103, 3)
        Me.btnCancelRequest.Name = "btnCancelRequest"
        Me.btnCancelRequest.Size = New System.Drawing.Size(94, 23)
        Me.btnCancelRequest.TabIndex = 26
        Me.btnCancelRequest.Text = "Cancel Request"
        Me.btnCancelRequest.UseVisualStyleBackColor = False
        '
        'btnSaveRequest
        '
        Me.btnSaveRequest.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnSaveRequest.ForeColor = System.Drawing.Color.White
        Me.btnSaveRequest.Location = New System.Drawing.Point(3, 3)
        Me.btnSaveRequest.Name = "btnSaveRequest"
        Me.btnSaveRequest.Size = New System.Drawing.Size(94, 23)
        Me.btnSaveRequest.TabIndex = 25
        Me.btnSaveRequest.Text = "Save Request"
        Me.btnSaveRequest.UseVisualStyleBackColor = False
        '
        'frmNewDocumentRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CaseStudyIntProg.My.Resources.Resources.registrarbg2
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
    Friend WithEvents lblDate As Label
    Friend WithEvents DateTimePickerDate As DateTimePicker
    Friend WithEvents lblStudentInformation As Label
    Friend WithEvents lblStudentId As Label
    Friend WithEvents lblStudentName As Label
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
    Friend WithEvents lblPurpose As Label
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents txtSearchStudentIdOrStudentLastName As TextBox
    Friend WithEvents txtStudentName As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblRecordedBy As Label
    Friend WithEvents txtRecordedBy As Label
End Class
