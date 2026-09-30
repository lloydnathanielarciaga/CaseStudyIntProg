Public Class frmPasswordPrompt
    Public ReadOnly Property Password As String
        Get
            Return txtPassword.Text
        End Get
    End Property

    Private Sub frmPasswordPrompt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.Clear()
        txtPassword.Focus()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class