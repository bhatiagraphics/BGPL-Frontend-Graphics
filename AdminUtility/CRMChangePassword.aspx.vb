Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL

Partial Class CRMChangePassword
    Inherits System.Web.UI.Page
    Dim Pass As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HFUserID.Value = Session.Item("UserID")
            txtCurrentPassword.Focus()
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        lblError.Text = ""
        Dim newPass, confirmPass, currentPass As String
        currentPass = Trim(txtCurrentPassword.Text)
        newPass = Trim(txtPassword.Text)
        confirmPass = Trim(txtConfrimPassword.Text)
        Dim dt As DataTable, objDas As New DBAccess, sSQL, sSQL1, sSQL2 As String
        sSQL = "SELECT u_id, pass FROM USERS WHERE u_id = '" & Trim(HFUserID.Value) & "'"
        dt = objDas.GetDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            Pass = Trim(dt.Rows(0).Item("pass").ToString)
            If Pass = currentPass Then
                If Pass <> newPass Then
                    Dim objDas1 As New DBAccess
                    sSQL1 = " Update USERS Set pass='" & Trim(txtPassword.Text) & "',lastpasschangedt=convert(smalldatetime,convert(char(10),GETDATE(),103),103) Where u_id='" & HFUserID.Value & "'"
                    objDas.ExecuteSQL(sSQL1)
                    'sSQL2 = " Update HREmployee Set pass='" & Trim(txtPassword.Text) & "' Where u_id='" & HFUserID.Value & "'"
                    'objDas.ExecuteSQL(sSQL2)

                    Dim strConnString As String = ConfigurationManager.ConnectionStrings("ConStrCRM").ConnectionString
                    Dim con As SqlConnection = New SqlConnection(strConnString)
                    con.Open()
                    Dim cmd As SqlCommand
                    cmd = New SqlCommand(sSQL1, con)
                    cmd.ExecuteNonQuery()
                    'cmd = New SqlCommand(sSQL2, con)
                    'cmd.ExecuteNonQuery()
                    con.Close()

                    ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", "alert('Password Successfully Updated...');window.location ='/Login.aspx';", True)
                    'lblError.Text = "Password Successfully Update"
                Else
                    lblError.Text = "New password must be different"
                End If
            Else
                lblError.Text = "Invalid current password"
            End If
        Else
            lblError.Text = "Invalid User Name or Password"
        End If
    End Sub

    Protected Sub btnLogout_Click1(sender As Object, e As System.EventArgs) Handles btnLogout.Click
        Session("UserID") = Nothing
        Session("UserID") = ""
        Session.Abandon()
        Session.Clear()
        ''
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
        Response.Redirect("~/Login.aspx")
    End Sub
End Class
