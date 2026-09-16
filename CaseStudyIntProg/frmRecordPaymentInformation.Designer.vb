<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecordPaymentInformation
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
        Me.lblRecordPaymentInformation = New System.Windows.Forms.Label()
        Me.lblRequestNo = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.cboRequestNo = New System.Windows.Forms.ComboBox()
        Me.txtTotalAmount = New System.Windows.Forms.Label()
        Me.lblORNo = New System.Windows.Forms.Label()
        Me.lblORDate = New System.Windows.Forms.Label()
        Me.DateTimePickerORDate = New System.Windows.Forms.DateTimePicker()
        Me.txtORNo = New System.Windows.Forms.Label()
        Me.lblAmountPaid = New System.Windows.Forms.Label()
        Me.txtAmountPaid = New System.Windows.Forms.TextBox()
        Me.lblPaymentStatus = New System.Windows.Forms.Label()
        Me.txtPaymentStatus = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSavePayment = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblRecordPaymentInformation, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRequestNo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalAmount, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboRequestNo, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTotalAmount, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblORNo, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblORDate, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerORDate, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtORNo, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAmountPaid, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAmountPaid, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPaymentStatus, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPaymentStatus, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 5)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66708!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66709!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66709!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66542!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(437, 238)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblRecordPaymentInformation
        '
        Me.lblRecordPaymentInformation.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecordPaymentInformation.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblRecordPaymentInformation, 2)
        Me.lblRecordPaymentInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordPaymentInformation.Location = New System.Drawing.Point(3, 13)
        Me.lblRecordPaymentInformation.Name = "lblRecordPaymentInformation"
        Me.lblRecordPaymentInformation.Size = New System.Drawing.Size(231, 13)
        Me.lblRecordPaymentInformation.TabIndex = 0
        Me.lblRecordPaymentInformation.Text = "Record Payment Information"
        Me.lblRecordPaymentInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRequestNo
        '
        Me.lblRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRequestNo.AutoSize = True
        Me.lblRequestNo.Location = New System.Drawing.Point(3, 52)
        Me.lblRequestNo.Name = "lblRequestNo"
        Me.lblRequestNo.Size = New System.Drawing.Size(67, 13)
        Me.lblRequestNo.TabIndex = 1
        Me.lblRequestNo.Text = "Request No:"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Location = New System.Drawing.Point(3, 91)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(73, 13)
        Me.lblTotalAmount.TabIndex = 2
        Me.lblTotalAmount.Text = "Total Amount:"
        '
        'cboRequestNo
        '
        Me.cboRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboRequestNo.FormattingEnabled = True
        Me.cboRequestNo.Location = New System.Drawing.Point(93, 48)
        Me.cboRequestNo.Name = "cboRequestNo"
        Me.cboRequestNo.Size = New System.Drawing.Size(141, 21)
        Me.cboRequestNo.TabIndex = 3
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTotalAmount.AutoSize = True
        Me.txtTotalAmount.Location = New System.Drawing.Point(93, 91)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(10, 13)
        Me.txtTotalAmount.TabIndex = 4
        Me.txtTotalAmount.Text = "-"
        '
        'lblORNo
        '
        Me.lblORNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblORNo.AutoSize = True
        Me.lblORNo.Location = New System.Drawing.Point(240, 52)
        Me.lblORNo.Name = "lblORNo"
        Me.lblORNo.Size = New System.Drawing.Size(43, 13)
        Me.lblORNo.TabIndex = 5
        Me.lblORNo.Text = "OR No:"
        '
        'lblORDate
        '
        Me.lblORDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblORDate.AutoSize = True
        Me.lblORDate.Location = New System.Drawing.Point(240, 91)
        Me.lblORDate.Name = "lblORDate"
        Me.lblORDate.Size = New System.Drawing.Size(52, 13)
        Me.lblORDate.TabIndex = 6
        Me.lblORDate.Text = "OR Date:"
        '
        'DateTimePickerORDate
        '
        Me.DateTimePickerORDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DateTimePickerORDate.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePickerORDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerORDate.Location = New System.Drawing.Point(330, 87)
        Me.DateTimePickerORDate.Name = "DateTimePickerORDate"
        Me.DateTimePickerORDate.Size = New System.Drawing.Size(104, 20)
        Me.DateTimePickerORDate.TabIndex = 7
        '
        'txtORNo
        '
        Me.txtORNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtORNo.AutoSize = True
        Me.txtORNo.Location = New System.Drawing.Point(330, 52)
        Me.txtORNo.Name = "txtORNo"
        Me.txtORNo.Size = New System.Drawing.Size(10, 13)
        Me.txtORNo.TabIndex = 8
        Me.txtORNo.Text = "-"
        '
        'lblAmountPaid
        '
        Me.lblAmountPaid.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAmountPaid.AutoSize = True
        Me.lblAmountPaid.Location = New System.Drawing.Point(240, 130)
        Me.lblAmountPaid.Name = "lblAmountPaid"
        Me.lblAmountPaid.Size = New System.Drawing.Size(70, 13)
        Me.lblAmountPaid.TabIndex = 9
        Me.lblAmountPaid.Text = "Amount Paid:"
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtAmountPaid.Location = New System.Drawing.Point(330, 126)
        Me.txtAmountPaid.Name = "txtAmountPaid"
        Me.txtAmountPaid.Size = New System.Drawing.Size(100, 20)
        Me.txtAmountPaid.TabIndex = 10
        '
        'lblPaymentStatus
        '
        Me.lblPaymentStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPaymentStatus.AutoSize = True
        Me.lblPaymentStatus.Location = New System.Drawing.Point(240, 169)
        Me.lblPaymentStatus.Name = "lblPaymentStatus"
        Me.lblPaymentStatus.Size = New System.Drawing.Size(84, 13)
        Me.lblPaymentStatus.TabIndex = 11
        Me.lblPaymentStatus.Text = "Payment Status:"
        '
        'txtPaymentStatus
        '
        Me.txtPaymentStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPaymentStatus.AutoSize = True
        Me.txtPaymentStatus.Location = New System.Drawing.Point(330, 169)
        Me.txtPaymentStatus.Name = "txtPaymentStatus"
        Me.txtPaymentStatus.Size = New System.Drawing.Size(10, 13)
        Me.txtPaymentStatus.TabIndex = 12
        Me.txtPaymentStatus.Text = "-"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 4)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnSavePayment, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnClear, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 198)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(431, 37)
        Me.TableLayoutPanel2.TabIndex = 13
        '
        'btnSavePayment
        '
        Me.btnSavePayment.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSavePayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavePayment.Location = New System.Drawing.Point(114, 7)
        Me.btnSavePayment.Name = "btnSavePayment"
        Me.btnSavePayment.Size = New System.Drawing.Size(98, 23)
        Me.btnSavePayment.TabIndex = 0
        Me.btnSavePayment.Text = "Save Payment"
        Me.btnSavePayment.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(218, 7)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'frmRecordPaymentInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmRecordPaymentInformation"
        Me.Text = "frmRecordPaymentInformation"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblRecordPaymentInformation As Label
    Friend WithEvents lblRequestNo As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents cboRequestNo As ComboBox
    Friend WithEvents txtTotalAmount As Label
    Friend WithEvents lblORNo As Label
    Friend WithEvents lblORDate As Label
    Friend WithEvents DateTimePickerORDate As DateTimePicker
    Friend WithEvents txtORNo As Label
    Friend WithEvents lblAmountPaid As Label
    Friend WithEvents txtAmountPaid As TextBox
    Friend WithEvents lblPaymentStatus As Label
    Friend WithEvents txtPaymentStatus As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnSavePayment As Button
    Friend WithEvents btnClear As Button
End Class
