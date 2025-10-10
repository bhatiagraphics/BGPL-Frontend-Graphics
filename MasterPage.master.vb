
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.Page.Title = "ERP"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (Session("Unit") Is Nothing) Then
        '    Response.Redirect("~/SessionExpired.aspx")
        'End If


        ''If (Session("Clientname") Is Nothing) Or Session("Clientname") = "" Then
        ''    lblWelcome.Visible = False
        ''    lblLoginDtls.Visible = False
        ''    lblWelcome.Text = ""
        ''    lblLoginDtls.Text = ""
        ''Else
        ''    lblWelcome.Visible = True
        ''    lblLoginDtls.Visible = True
        ''    lblWelcome.Text = "Welcome : "
        ''    lblLoginDtls.Text = Session.Item("Clientname").ToString
        ''End If

    End Sub

    'Protected Sub btnChangePass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePass.Click
    '    Response.Redirect("ChangePassword.aspx")
    'End Sub

    'Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
    '    'Session.Abandon()
    '    'Session.Clear()
    '    Response.Redirect("Logout.aspx")
    'End Sub
End Class

