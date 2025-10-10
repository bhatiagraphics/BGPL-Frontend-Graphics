Imports System.Data
Imports FOODERPWEB.DAL
Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.IO
Imports System.Configuration

Partial Class MasterPageForAll
    Inherits System.Web.UI.MasterPage

    Private Sub MasterPageForAll_Init(sender As Object, e As EventArgs) Handles Me.Init
        If (Session("UserName") Is Nothing) Then
            Response.Redirect("~/SessionExpired.aspx")
        End If
    End Sub

    'Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    '    Me.Page.Title = "BHALCON ERP"
    'End Sub

    'Private Function GetData(parentMenuId As Integer) As DataTable
    '    'Dim query As String = "SELECT * FROM TreeviewRights where parent_module = @ParentMenuId"
    '    Dim Query As String = "SELECT isnull(NavigateUrl,'')as NavigateUrl,* FROM TreeviewRights where ISNULL(u_id,'') = '" & Trim(Session.Item("UserID")) & "' And isnull(Allow,'0')='1' and parent_module = @ParentMenuId order by ssrno Asc"
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString
    '    Using con As New SqlConnection(constr)
    '        Dim dt As New DataTable()
    '        Using cmd As New SqlCommand(query)
    '            Using sda As New SqlDataAdapter()
    '                cmd.Parameters.AddWithValue("@ParentMenuId", parentMenuId)
    '                cmd.CommandType = CommandType.Text
    '                cmd.Connection = con
    '                sda.SelectCommand = cmd
    '                sda.Fill(dt)
    '            End Using
    '        End Using
    '        Return dt
    '    End Using
    'End Function

    'Private Sub PopulateMenu(dt As DataTable, parentMenuId As Integer, parentMenuItem As MenuItem)
    '    Dim currentPage As String = Path.GetFileName(Request.Url.AbsolutePath)
    '    For Each row As DataRow In dt.Rows
    '        Dim menuItem As New MenuItem() With { _
    '         .Value = row("module_id").ToString(), _
    '         .Text = row("module_name").ToString(), _
    '         .NavigateUrl = row("NavigateUrl").ToString() & "?MMModuleid=" & Trim(row("module_id").ToString()), _
    '         .Selected = row("NavigateUrl").ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase) _
    '        }
    '        If parentMenuId = 0 Then
    '            Menu1.Items.Add(menuItem)
    '            Dim dtChild As DataTable = Me.GetData(Integer.Parse(menuItem.Value))
    '            PopulateMenu(dtChild, Integer.Parse(menuItem.Value), menuItem)
    '        Else
    '            'parentMenuItem.ChildItems.Add(menuItem)
    '        End If
    '    Next
    'End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If (Session("UserName") Is Nothing) Then
    '        Response.Redirect("~/SessionExpired.aspx")
    '    End If
    '    'lblWelcome.Visible = True
    '    'lblLoginDtls.Visible = True
    '    'lblWelcome.Text = "Welcome : "
    '    'lblLoginDtls.Text = Session.Item("UserName").ToString

    '    'If Not IsPostBack Then
    '    '    Dim dt As DataTable = Me.GetData(0)
    '    '    PopulateMenu(dt, 0, Nothing)

    '    '    Bind_Menu_New_WithHeaderMenu()
    '    'End If
    'End Sub

    'Private Sub Bind_Menu_New_WithHeaderMenu()
    '    Dim dt1, dtSub, dtSub2 As DataTable, sSQL, mod_id As String, objDas As New DBAccess
    '    sSQL = "SELECT isnull(NavigateUrl,'')as NavigateUrl,* FROM TreeviewRights where ISNULL(u_id,'') = '" & Trim(Session.Item("UserID")) & "' And isnull(Allow,'0')='1' and parent_module='0' And module_id = '" & Trim(Request.QueryString("MMModuleid")) & "' order by ssrno desc"
    '    dt1 = objDas.GetDataTable(sSQL)
    '    Dim dr, drSub, drSub2 As DataRow
    '    If dt1.Rows.Count > 0 Then
    '        lt_navMenu.Text = lt_navMenu.Text & "<ul id=""navlist"" class=""list-unstyled components""><p></p>"
    '    End If

    '    For i = dt1.Rows.Count - 1 To 0 Step -1
    '        dr = dt1.Rows(i)
    '        mod_id = Trim(dr("module_id"))
    '        sSQL = "SELECT isnull(NavigateUrl,'')as NavigateUrl,* FROM TreeviewRights where ISNULL(u_id,'') = '" & Trim(Session.Item("UserID")) & "' And isnull(Allow,'0')='1' and parent_module='" & Trim(mod_id) & "' order by ssrno desc "
    '        dtSub = objDas.GetDataTable(sSQL)
    '        If dtSub.Rows.Count > 0 Then
    '            mod_id = Trim(dr("module_id"))
    '            '' Not Expended - Closed
    '            'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""false"">" & Trim(dr("module_name")) & "</a> <ul class=""collapse list-unstyled"" id=""" & Trim(mod_id) & """>"
    '            '' Default Open
    '            lt_navMenu.Text = lt_navMenu.Text & "<li class=""activeHead""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(dr("module_name")) & "</a> <ul class=""list-unstyled components collapse in"" id=""" & Trim(mod_id) & """>"

    '            For iSub = dtSub.Rows.Count - 1 To 0 Step -1
    '                drSub = dtSub.Rows(iSub)
    '                '' For 2 Levels
    '                mod_id = Trim(drSub("module_id"))
    '                sSQL = "SELECT isnull(NavigateUrl,'')as NavigateUrl,* FROM TreeviewRights where ISNULL(u_id,'') = '" & Trim(Session.Item("UserID")) & "' And isnull(Allow,'0')='1' and parent_module='" & Trim(mod_id) & "' and (ModuleType <> 'Masters' and ModuleType <> 'Reports') order by ssrno desc "
    '                dtSub2 = objDas.GetDataTable(sSQL)
    '                If dtSub2.Rows.Count > 0 Then
    '                    '' Not Expended - Closed Running
    '                    'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""false"">" & Trim(drSub("module_name")) & "</a> <ul class=""collapse list-unstyled"" id=""" & Trim(mod_id) & """>"
    '                    '' Default Open
    '                    'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(drSub("module_name")) & "</a> <ul class=""list-unstyled components"" id=""" & Trim(mod_id) & """>"

    '                    If Trim(Request.QueryString("mainid") = Trim(mod_id)) Then
    '                        '' Open
    '                        'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(drSub("module_name")) & "</a> <ul class=""list-unstyled components"" id=""" & Trim(mod_id) & """>"
    '                        lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(drSub("module_name")) & "</a> <ul class=""list-unstyled components collapse in"" id=""" & Trim(mod_id) & """>"
    '                    Else
    '                        '' Default Closed
    '                        'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""false"">" & Trim(drSub("module_name")) & "</a> <ul class=""collapse list-unstyled"" id=""" & Trim(mod_id) & """>"

    '                        '' Default Open (Masters, Transaction)
    '                        'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(drSub("module_name")) & "</a> <ul class=""list-unstyled components"" id=""" & Trim(mod_id) & """>"
    '                        lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(drSub("module_name")) & "</a> <ul class=""list-unstyled components collapse in"" id=""" & Trim(mod_id) & """>"
    '                    End If

    '                    For iSub2 = dtSub2.Rows.Count - 1 To 0 Step -1
    '                        drSub2 = dtSub2.Rows(iSub2)
    '                        lt_navMenu.Text = lt_navMenu.Text & "<li><a href=""" & Trim(drSub2("NavigateUrl")).Replace("~", "") & "?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(drSub2("module_id")) & "&subid=" & Trim(mod_id) & """>" & Trim(drSub2("module_name")) & "</a></li>"
    '                    Next
    '                    lt_navMenu.Text = lt_navMenu.Text & "</ul></li>"
    '                Else
    '                    lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""" & Trim(drSub("NavigateUrl")).Replace("~", "") & "?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(drSub("module_id")) & "&subid=" & Trim(mod_id) & """>" & Trim(drSub("module_name")) & "</a></li>"
    '                End If
    '                '' End
    '            Next
    '            lt_navMenu.Text = lt_navMenu.Text & "</ul></li>"
    '        Else
    '            lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""" & Trim(dr("NavigateUrl")).Replace("~", "") & "?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(dr("module_id")) & "&subid=" & Trim(mod_id) & """>" & Trim(dr("module_name")) & "</a></li>"
    '        End If
    '    Next

    '    If dt1.Rows.Count > 0 Then
    '        lt_navMenu.Text = lt_navMenu.Text & "</ul>"
    '    End If
    'End Sub

    'Private Sub Bind_Menu()
    '    Dim dt1, dtSub, dtSub2 As DataTable, sSQL, mod_id As String, objDas As New DBAccess
    '    sSQL = "SELECT isnull(NavigateUrl,'')as NavigateUrl,* FROM TreeviewRights where ISNULL(u_id,'') = '" & Trim(Session.Item("UserID")) & "' And isnull(Allow,'0')='1' and parent_module='0' order by ssrno desc"
    '    dt1 = objDas.GetDataTable(sSQL)
    '    Dim dr, drSub, drSub2 As DataRow
    '    If dt1.Rows.Count > 0 Then
    '        lt_navMenu.Text = lt_navMenu.Text & "<ul id=""navlist"" class=""list-unstyled components""><p></p>"
    '    End If

    '    For i = dt1.Rows.Count - 1 To 0 Step -1
    '        dr = dt1.Rows(i)
    '        mod_id = Trim(dr("module_id"))
    '        sSQL = "SELECT isnull(NavigateUrl,'')as NavigateUrl,* FROM TreeviewRights where ISNULL(u_id,'') = '" & Trim(Session.Item("UserID")) & "' And isnull(Allow,'0')='1' and parent_module='" & Trim(mod_id) & "' order by ssrno desc "
    '        dtSub = objDas.GetDataTable(sSQL)
    '        If dtSub.Rows.Count > 0 Then
    '            mod_id = Trim(dr("module_id"))
    '            '' Not Expended - Closed
    '            'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""false"">" & Trim(dr("module_name")) & "</a> <ul class=""collapse list-unstyled"" id=""" & Trim(mod_id) & """>"
    '            '' Default Open
    '            lt_navMenu.Text = lt_navMenu.Text & "<li class=""activeHead""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(dr("module_name")) & "</a> <ul class=""list-unstyled components"" id=""" & Trim(mod_id) & """>"

    '            For iSub = dtSub.Rows.Count - 1 To 0 Step -1
    '                drSub = dtSub.Rows(iSub)
    '                '' For 2 Levels
    '                'lt_navMenu.Text = lt_navMenu.Text & "<li><a href=""" & Trim(drSub("NavigateUrl")).Replace("~", "") & """>" & Trim(drSub("module_name")) & "</a></li>"
    '                '' For 3rd Level Start
    '                mod_id = Trim(drSub("module_id"))
    '                sSQL = "SELECT isnull(NavigateUrl,'')as NavigateUrl,* FROM TreeviewRights where ISNULL(u_id,'') = '" & Trim(Session.Item("UserID")) & "' And isnull(Allow,'0')='1' and parent_module='" & Trim(mod_id) & "' order by ssrno desc "
    '                dtSub2 = objDas.GetDataTable(sSQL)
    '                If dtSub2.Rows.Count > 0 Then
    '                    '' Not Expended - Closed Running
    '                    'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""false"">" & Trim(drSub("module_name")) & "</a> <ul class=""collapse list-unstyled"" id=""" & Trim(mod_id) & """>"
    '                    '' Default Open
    '                    'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(drSub("module_name")) & "</a> <ul class=""list-unstyled components"" id=""" & Trim(mod_id) & """>"

    '                    'Dim dt2 As DataTable, sSQLMenu As String
    '                    'sSQLMenu = "SELECT module_id From MenuPosition"
    '                    'dt2 = objDas.GetDataTable(sSQLMenu)
    '                    'If (Trim(dt2.Rows(0)("module_id").ToString) = Trim(mod_id)) Then
    '                    'If (Trim(HFMenu.Value) = Trim(mod_id)) Then
    '                    '    '' Open
    '                    '    lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(drSub("module_name")) & "</a> <ul class=""list-unstyled components"" id=""" & Trim(mod_id) & """>"
    '                    'Else
    '                    '    '' Closed
    '                    '    lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""false"">" & Trim(drSub("module_name")) & "</a> <ul class=""collapse list-unstyled"" id=""" & Trim(mod_id) & """>"
    '                    'End If

    '                    If Trim(Request.QueryString("subid") = Trim(mod_id)) Then
    '                        '' Open
    '                        lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""true"">" & Trim(drSub("module_name")) & "</a> <ul class=""list-unstyled components"" id=""" & Trim(mod_id) & """>"
    '                    Else
    '                        '' Closed
    '                        lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""#" & Trim(mod_id) & """ data-toggle=""collapse"" aria-expanded=""false"">" & Trim(drSub("module_name")) & "</a> <ul class=""collapse list-unstyled"" id=""" & Trim(mod_id) & """>"
    '                    End If

    '                    For iSub2 = dtSub2.Rows.Count - 1 To 0 Step -1
    '                        drSub2 = dtSub2.Rows(iSub2)
    '                        'lt_navMenu.Text = lt_navMenu.Text & "<li><a href=""" & Trim(drSub2("NavigateUrl")).Replace("~", "") & """>" & Trim(drSub2("module_name")) & "</a></li>"
    '                        lt_navMenu.Text = lt_navMenu.Text & "<li><a href=""" & Trim(drSub2("NavigateUrl")).Replace("~", "") & "?mainid=" & Trim(drSub2("module_id")) & "&subid=" & Trim(mod_id) & """>" & Trim(drSub2("module_name")) & "</a></li>"
    '                        'lt_navMenu.Text = lt_navMenu.Text & "<li><a href=""" & Trim(drSub2("NavigateUrl")).Replace("~", "") & "?subid=12" & """>" & Trim(drSub2("module_name")) & "</a></li>"
    '                    Next
    '                    lt_navMenu.Text = lt_navMenu.Text & "</ul></li>"
    '                Else
    '                    'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""" & Trim(drSub("NavigateUrl")).Replace("~", "") & """>" & Trim(drSub("module_name")) & "</a></li>"
    '                    lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""" & Trim(drSub("NavigateUrl")).Replace("~", "") & "?mainid=" & Trim(drSub("module_id")) & "&subid=" & Trim(mod_id) & """>" & Trim(drSub("module_name")) & "</a></li>"
    '                End If
    '                '' End
    '            Next
    '            lt_navMenu.Text = lt_navMenu.Text & "</ul></li>"
    '        Else
    '            'lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""" & Trim(dr("NavigateUrl")).Replace("~", "") & """>" & Trim(dr("module_name")) & "</a></li>"
    '            lt_navMenu.Text = lt_navMenu.Text & "<li class=""active""><a href=""" & Trim(dr("NavigateUrl")).Replace("~", "") & "?mainid=" & Trim(dr("module_id")) & "&subid=" & Trim(mod_id) & """>" & Trim(dr("module_name")) & "</a></li>"
    '        End If
    '    Next

    '    If dt1.Rows.Count > 0 Then
    '        lt_navMenu.Text = lt_navMenu.Text & "</ul>"
    '    End If
    'End Sub

End Class

