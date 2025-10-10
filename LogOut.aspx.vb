
Partial Class LogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (Session("UserID") Is Nothing) Then
        '    Response.Redirect("~/SessionExpired.aspx")
        '    Exit Sub
        'End If
        Session("UserID") = Nothing
        Session("UserID") = ""
        Session.Abandon()
        Session.Clear()
        ''
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim RedirectUrl As String
        RedirectUrl = FormsAuthentication.LoginUrl + "?ReturnUrl=Login.aspx"
        FormsAuthentication.SignOut()
        Response.Redirect(RedirectUrl)
    End Sub
End Class
