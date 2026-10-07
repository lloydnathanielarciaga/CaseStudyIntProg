Imports MySql.Data.MySqlClient

Public Class frmPaymentPrompt

    Public Property SelectedRequestNo As String
    Public Property SelectedStudentID As String
    Public Property SelectedStudentName As String
    Public Property SelectedRequestDate As DateTime

    Private Sub frmPaymentPrompt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDisplayRequestNo.Text = SelectedRequestNo
        lblDisplayStudentNo.Text = SelectedStudentID
        lblDisplayStudentName.Text = SelectedStudentName

        DateTimePickerOR.MinDate = SelectedRequestDate

        If DateTime.Now >= SelectedRequestDate Then
            DateTimePickerOR.Value = DateTime.Now
        Else
            DateTimePickerOR.Value = SelectedRequestDate
        End If

        GenerateORNumber()
    End Sub

    Private Sub GenerateORNumber()
        Try
            Call connection()
            sql = "SELECT ORNo FROM tblrequest WHERE ORNo IS NOT NULL ORDER BY RequestID DESC LIMIT 1"
            cmd = New MySqlCommand(sql, cn)
            Dim lastOR As Object = cmd.ExecuteScalar()

            If lastOR IsNot Nothing AndAlso Not IsDBNull(lastOR) Then
                Dim lastNum As Integer = 0
                Integer.TryParse(lastOR.ToString().Replace("OR-", ""), lastNum)
                lblDisplayORNo.Text = "OR-" & (lastNum + 1).ToString("D4")
            Else
                lblDisplayORNo.Text = "OR-1001"
            End If
        Catch ex As Exception
            lblDisplayORNo.Text = "OR-" & DateTime.Now.ToString("yyyyMMddHHmmss")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub btnSavePayment_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(lblDisplayRequestNo.Text) OrElse lblDisplayRequestNo.Text = "-" Then
            MessageBox.Show("No valid request selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Call connection()

            sql = "UPDATE tblrequest " &
                  "SET PaymentStatus = 'Paid', " &
                  "    ORNo = @ORNo, " &
                  "    ORDate = @ORDate, " &
                  "    Status = 'Processing' " &
                  "WHERE RequestNo = @RequestNo"

            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@ORNo", lblDisplayORNo.Text)
            cmd.Parameters.AddWithValue("@ORDate", DateTimePickerOR.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@RequestNo", lblDisplayRequestNo.Text)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Payment recorded successfully! Status updated to 'Processing'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to update payment details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving payment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class