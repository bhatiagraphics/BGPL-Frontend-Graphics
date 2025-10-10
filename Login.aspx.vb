Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports System.IO
Imports System.Data.OleDb
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports AGPLCRM.Class

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        'Session.Item("UserName") = ""
        txtUserName.Focus()
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            Dim dt As DataTable, objDas As New DBAccess, sSQL As String
            'sSQL = "SELECT us.u_id, us.u_name, us.pass, ISNULL(us.dist_id,'') as dist_id, us.unitcode, ut.unitname FROM users us, unit ut WHERE us.unitcode=ut.unitcode And u_name = '" & objDas.FilteredString(txtUserName.Text) & "'"
            sSQL = "select u_id,pass,u_name from users where isnull(active,'0')='1'  And u_id = '" & objDas.FilteredString(txtUserName.Text) & "'"
            'sSQL = "Select u_id, u_name, pass, ISNULL(dist_id,'') as dist_id From Users Where u_name = '" & objDas.FilteredString(txtUserName.Text) & "'"
            dt = objDas.GetDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                If Trim(txtPassword.Text.ToUpper) = LTrim(RTrim(dt.Rows(0)("pass").ToString.ToUpper)) Then
                    Session.Item("UserID") = dt.Rows(0)("u_id").ToString
                    Session.Item("UserName") = Trim(dt.Rows(0)("u_name").ToString)
                    Session.Item("UnitCode") = ""
                    Session.Item("UnitName") = ""
                    Session.Item("DistID") = ""
                    Response.Cookies("RAUTENGINEERING").Expires = DateTime.Now.AddDays(14)
                    If ChkRemember.Checked = True Then
                        Response.Cookies("RAUTENGINEERING").Item("UserName") = Me.txtUserName.Text
                    Else
                        Response.Cookies("RAUTENGINEERING")("UserName") = ""
                    End If
                    'Response.Redirect("Home.aspx?UserName=" & dt.Rows(0)("u_name").ToString)
                    Response.Redirect("Home.aspx?UserName=" & "Admin")
                Else
                    lblMsg.Text = "Invalid Login"
                    txtPassword.Text = ""
                    txtUserName.Text = ""
                    txtUserName.Focus()
                End If
            Else
                lblMsg.Text = "Invalid Login"
                txtPassword.Text = ""
                txtUserName.Text = ""
                txtUserName.Focus()
            End If

            '' Offline
            'Session.Item("UserName") = Trim(txtUserName.Text)
            'Response.Redirect("HomeAccounts.aspx?UserName=" & Trim(txtUserName.Text))
        Catch ex As Exception
            lblMsg.Text = ex.Message.ToString
        End Try
    End Sub




End Class