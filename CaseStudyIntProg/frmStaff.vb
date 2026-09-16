Public Class frmStaff
    Private Sub frmStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadFormInPanel(ByVal childForm As Form)
        ' Clear existing forms/controls from the right panel
        SplitContainerMain.Panel2.Controls.Clear()

        ' Embed the child form as a control
        With childForm
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .Dock = DockStyle.Fill
        End With

        ' Add and render the child form inside Panel2
        SplitContainerMain.Panel2.Controls.Add(childForm)
        SplitContainerMain.Panel2.Tag = childForm
        childForm.Show()
    End Sub

    Private Sub btnDocumentManagement_Click(sender As Object, e As EventArgs) Handles btnDocumentManagement.Click

        LoadFormInPanel(New frmDocumentManagement())

    End Sub

    Private Sub btnDocumentRequest_Click(sender As Object, e As EventArgs) Handles btnDocumentRequest.Click

        LoadFormInPanel(New frmNewDocumentRequest())

    End Sub

    Private Sub btnDocumentRequestList_Click(sender As Object, e As EventArgs) Handles btnDocumentRequestList.Click

        LoadFormInPanel(New frmDocumentRequestList())

    End Sub

    Private Sub btnPaymentInformation_Click(sender As Object, e As EventArgs) Handles btnPaymentInformation.Click

        LoadFormInPanel(New frmRecordPaymentInformation())

    End Sub

    Private Sub btnSystemReport_Click(sender As Object, e As EventArgs) Handles btnSystemReport.Click

        LoadFormInPanel(New frmSystemReport())

    End Sub
End Class