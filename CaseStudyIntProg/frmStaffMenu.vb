Imports Mysqlx.XDevAPI.Common

Public Class frmStaffMenu

    Private Sub frmStaffMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUsername.Text = "Welcome! " & CurrentUsername
        LoadFormInPanel(New frmDashboard())
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

    Private Sub btnStudentInformation_Click(sender As Object, e As EventArgs) Handles btnStudentInformation.Click

        LoadFormInPanel(New frmStudentInformation())

    End Sub

    Private Sub btnDocumentRequest_Click(sender As Object, e As EventArgs) Handles btnNewDocumentRequest.Click

        LoadFormInPanel(New frmNewDocumentRequest())

    End Sub

    Private Sub btnDocumentRequestList_Click(sender As Object, e As EventArgs) Handles btnDocumentRequestList.Click

        LoadFormInPanel(New frmDocumentRequestList())

    End Sub

    Private Sub btnSystemReport_Click(sender As Object, e As EventArgs) Handles btnSystemReport.Click

        LoadFormInPanel(New frmSystemReport())

    End Sub

    Private Sub btnRequestManagement_Click(sender As Object, e As EventArgs) Handles btnRequestManagement.Click

        LoadFormInPanel(New frmRequestManagement())

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        MsgBox("Do you want to logout?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Logout")

        If MsgBoxResult.Yes Then
            frmLogin.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        LoadFormInPanel(New frmDashboard())
    End Sub

    Private Sub btnNewDocumentRequest_Click(sender As Object, e As EventArgs) Handles btnNewDocumentRequest.Click
        LoadFormInPanel(New frmNewDocumentRequest())
    End Sub
End Class