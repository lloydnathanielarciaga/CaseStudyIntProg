Public Class frmAdmin
    Private Sub frmAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboSemester.Items.Clear()
        cboSemester.Items.AddRange({"1st Semester", "2nd Semester"})
        cboSemester.SelectedIndex = 0
    End Sub

    Private Sub cboSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSemester.SelectedIndexChanged
        If cboSemester.SelectedIndex = -1 Then Exit Sub
        CurrentSemester = cboSemester.SelectedIndex + 1        ' 1st = 1, 2nd = 2

        ' If Student Management is open, update its section preview right away
        If TypeOf SplitContainerMain.Panel2.Tag Is frmStudentManagement Then
            DirectCast(SplitContainerMain.Panel2.Tag, frmStudentManagement).RefreshSemester()
        End If
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

    Private Sub btnUserManagement_Click(sender As Object, e As EventArgs) Handles btnUserManagement.Click

        LoadFormInPanel(New frmUserManagement())

    End Sub

    Private Sub btnStudentManagement_Click(sender As Object, e As EventArgs) Handles btnStudentManagement.Click
        LoadFormInPanel(New frmStudentManagement())
    End Sub
End Class