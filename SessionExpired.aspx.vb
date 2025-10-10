
Partial Class SessionExpired
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Dim RedirectUrl As String
        'RedirectUrl = FormsAuthentication.LoginUrl + "?ReturnUrl=Login.aspx"
        'FormsAuthentication.SignOut()
        'Response.Redirect(RedirectUrl)

        ''''
        Response.Redirect("Login.aspx")
    End Sub
End Class
