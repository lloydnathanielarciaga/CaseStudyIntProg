Imports MySql.Data.MySqlClient

Public Class frmRequestDetails
    Private _requestDetailID As String
    Private _requestID As String
    Private _isEditMode As Boolean

    Private ReadOnly validStatuses() As String = {"Pending", "Processing", "Ready for Release", "Released", "Cancelled"}

    Public Sub New(selectedItem As ListViewItem, isEditMode As Boolean)
        InitializeComponent()

        _isEditMode = isEditMode

        lblRequestNo.Text = selectedItem.SubItems(0).Text
        lblStudentName.Text = selectedItem.SubItems(1).Text
        lblDocument.Text = selectedItem.SubItems(2).Text
        numQuantity.Value = CDec(selectedItem.SubItems(3).Text)
        lblAmount.Text = selectedItem.SubItems(4).Text
        lblSubtotal.Text = selectedItem.SubItems(5).Text
        btnStatus.Text = selectedItem.SubItems(6).Text

        _requestDetailID = selectedItem.SubItems(7).Text
        _requestID = selectedItem.SubItems(8).Text

        ConfigureFormState()
    End Sub

    Private Sub ConfigureFormState()
        If _isEditMode Then
            Me.Text = "Edit Request Details"
            numQuantity.Enabled = True
            btnStatus.Enabled = True
            btnSave.Visible = True
            btnCancel.Text = "Cancel"
        Else
            Me.Text = "View Request Details"
            numQuantity.Enabled = False
            btnStatus.Enabled = False
            btnSave.Visible = False
            btnCancel.Text = "Close"
        End If
    End Sub

    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnStatus.Click
        Dim currentIndex As Integer = Array.IndexOf(validStatuses, btnStatus.Text)
        If currentIndex >= 0 Then
            Dim nextIndex As Integer = (currentIndex + 1) Mod validStatuses.Length
            btnStatus.Text = validStatuses(nextIndex)
        End If
    End Sub

    Private Sub numQuantity_ValueChanged(sender As Object, e As EventArgs) Handles numQuantity.ValueChanged
        Dim amount As Decimal
        If Decimal.TryParse(lblAmount.Text, amount) Then
            Dim newSubtotal As Decimal = amount * numQuantity.Value
            lblSubtotal.Text = newSubtotal.ToString("0.00")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim confirm As MsgBoxResult = MsgBox("Are you sure you want to save these changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Update")

        If confirm = MsgBoxResult.Yes Then
            Call connection()

            Dim transaction As MySqlTransaction = cn.BeginTransaction()

            Try
                sql = "UPDATE tblrequestdetails SET Quantity = @qty, Subtotal = @sub WHERE RequestDetailID = @detailId"
                cmd = New MySqlCommand(sql, cn, transaction)
                cmd.Parameters.AddWithValue("@qty", numQuantity.Value)
                cmd.Parameters.AddWithValue("@sub", CDec(lblSubtotal.Text))
                cmd.Parameters.AddWithValue("@detailId", _requestDetailID)
                cmd.ExecuteNonQuery()

                sql = "UPDATE tblrequest SET Status = @status WHERE RequestID = @reqId"
                cmd = New MySqlCommand(sql, cn, transaction)
                cmd.Parameters.AddWithValue("@status", btnStatus.Text)
                cmd.Parameters.AddWithValue("@reqId", _requestID)
                cmd.ExecuteNonQuery()

                transaction.Commit()
                MsgBox("Record updated successfully.", MsgBoxStyle.Information, "Success")

                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                transaction.Rollback()
                MsgBox("An error occurred. No changes were saved. Details: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class