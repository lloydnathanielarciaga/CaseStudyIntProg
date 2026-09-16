Imports MySql.Data.MySqlClient

Public Class frmRecordPaymentInformation
    Private Sub frmRecordPaymentInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadProcessingRequests()
        txtPaymentStatus.Text = "Ready for Release"

    End Sub

    Private Sub LoadProcessingRequests()
        cboRequestNo.Items.Clear()
        Try
            connection()
            sql = "SELECT RequestNo FROM tblrequest WHERE Status = 'Processing' AND PaymentStatus = 'Unpaid'"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                cboRequestNo.Items.Add(dr("RequestNo").ToString())
            End While
        Catch ex As Exception
            MsgBox("Error loading requests: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub cboRequestNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRequestNo.SelectedIndexChanged

        Try
            connection()
            sql = "SELECT TotalAmount FROM tblrequest WHERE RequestNo = @RequestNo"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@RequestNo", cboRequestNo.Text)
            dr = cmd.ExecuteReader()

            While dr.Read()
                txtTotalAmount.Text = dr("TotalAmount").ToString()
            End While
        Catch ex As Exception
            MsgBox("Error retrieving total amount: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try

        GenerateORNo()

    End Sub

    Private Sub GenerateORNo()
        Try
            connection()
            sql = "SELECT ORNo FROM tblrequest WHERE ORNo IS NOT NULL ORDER BY ORNo DESC LIMIT 1"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            Dim lastOR As String = "OR-1000"

            While dr.Read()
                lastOR = dr("ORNo").ToString()
            End While

            Dim numPart As Integer = Integer.Parse(lastOR.Substring(3)) + 1
            txtORNo.Text = "OR-" & numPart.ToString("D4")

        Catch ex As Exception
            MsgBox("Error generating OR Number: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub btnSavePayment_Click(sender As Object, e As EventArgs) Handles btnSavePayment.Click

        If cboRequestNo.Text = "" Then
            MsgBox("Please select a Request Number.", MsgBoxStyle.Exclamation)
            cboRequestNo.Focus()
            Exit Sub
        End If

        If txtAmountPaid.Text = "" Then
            MsgBox("Please enter the Amount Paid.", MsgBoxStyle.Exclamation)
            txtAmountPaid.Focus()
            Exit Sub
        End If

        Dim amountPaid As Decimal
        Dim totalAmount As Decimal

        Try
            amountPaid = Convert.ToDecimal(txtAmountPaid.Text)
            totalAmount = Convert.ToDecimal(txtTotalAmount.Text)
        Catch ex As Exception
            MsgBox("Please enter a valid numeric currency amount.", MsgBoxStyle.Exclamation)
            txtAmountPaid.Focus()
            Exit Sub
        End Try

        If amountPaid < 0 Then
            MsgBox("Amount paid cannot be negative.", MsgBoxStyle.Exclamation)
            txtAmountPaid.Focus()
            Exit Sub
        End If

        If amountPaid < totalAmount Then
            MsgBox("Amount paid is insufficient. Total amount is ₱" & totalAmount.ToString("N2"), MsgBoxStyle.Exclamation)
            txtAmountPaid.Focus()
            Exit Sub
        End If

        Dim response As MsgBoxResult = MsgBox("Are you sure you want to save this payment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Payment")

        If response = MsgBoxResult.Yes Then
            Try
                connection()
                sql = "UPDATE tblrequest SET PaymentStatus = 'Paid', ORNo = @ORNo, ORDate = @ORDate, Status = @Status WHERE RequestNo = @RequestNo"
                cmd = New MySqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@ORNo", txtORNo.Text)
                cmd.Parameters.AddWithValue("@ORDate", DateTimePickerORDate.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@Status", txtPaymentStatus.Text)
                cmd.Parameters.AddWithValue("@RequestNo", cboRequestNo.Text)

                cmd.ExecuteNonQuery()

                MsgBox("Payment successfully saved!", MsgBoxStyle.Information)

                ClearFields()
                LoadProcessingRequests()

            Catch ex As Exception
                MsgBox("Error saving payment: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearFields()

    End Sub

    Private Sub ClearFields()
        cboRequestNo.Items.Clear()
        cboRequestNo.Text = ""
        txtTotalAmount.Text = "-"
        txtORNo.Text = "-"
        txtAmountPaid.Clear()
        txtPaymentStatus.Text = "Ready for Release"
        DateTimePickerORDate.Value = Date.Now
        LoadProcessingRequests()
    End Sub

End Class