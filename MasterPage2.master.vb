
Imports System.Data
Imports FOODERPWEB.DAL
Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.IO
Imports System.Configuration

Partial Class MasterPage2
    Inherits System.Web.UI.MasterPage

    Dim StrBuilderMenu As StringBuilder


    Private Sub MasterPageForAll_Init(sender As Object, e As EventArgs) Handles Me.Init
        If (Session("UserName") Is Nothing) Then
            Response.Redirect("~/SessionExpired.aspx")
        End If

        StrBuilderMenu = New StringBuilder()
        StrBuilderMenu.Append("<ul id='sidebarnav'>")

        GetMenu()
        StrBuilderMenu.Append("</ul>")
        menubar.InnerHtml = StrBuilderMenu.ToString()

        lblLoginDtls.Text = Session.Item("UserName").ToString
        lblLoginInternal.Text = Session.Item("UserName").ToString


    End Sub



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub



    Protected Sub btnLogout_Click(sender As Object, e As EventArgs)
        Response.Redirect("Login.aspx")
    End Sub



    Private Sub GetMenu()



        Dim strIframName As String = ""
        strIframName = "iframeView"
        Dim dt As DataTable = GetDataAll(0)
        For i As Integer = 0 To dt.Rows.Count - 1
            ' StrBuilderMenu.Append("<li class='treeview menu' style='height: auto;'>")
            StrBuilderMenu.Append(" <li>")
            Dim MenuIcon As String
            If String.IsNullOrWhiteSpace(dt.Rows(i)("MenuIcon").ToString) Then
                MenuIcon = "fa fa-share"
            Else
                MenuIcon = dt.Rows(i)("MenuIcon").ToString

            End If

            Dim SideIcon As String
            If String.IsNullOrWhiteSpace(dt.Rows(i)("NavigateUrl").ToString) Then

                SideIcon = "has-arrow"
            Else
                SideIcon = ""

            End If
            '<%= ResolveUrl(""++"") %>

            Dim urlDomain As String = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/")

            Dim urlPath As String = Trim(dt.Rows(i)("NavigateUrl").ToString.Replace("~", ""))
            Dim url As String = urlDomain + urlPath
            If urlPath = "" Then
                url = "#"
            End If


            StrBuilderMenu.Append("<a class='" + SideIcon + " waves-effect waves-dark' href='" + url + "' aria-expanded='False'> <i class='" + MenuIcon + "'></i><span class='hide-menu'>" + Trim(dt.Rows(i)("module_name").ToString) + "</span></a>")

            'StrBuilderMenu.Append("<a href='" + url + "' ><i class='" + MenuIcon + "'></i> <span>" + Trim(dt.Rows(i)("module_name").ToString) + "</span>" + SideIcon + "</a>")

            Dim dt1 As DataTable = GetDataAll(Convert.ToInt16(dt.Rows(i)("module_id").ToString))

            If dt1.Rows.Count > 0 Then
                StrBuilderMenu.Append("<ul aria-expanded='False' class='collapse'>")
                For j As Integer = 0 To dt1.Rows.Count - 1

                    Dim MenuIcon1 As String
                    If String.IsNullOrWhiteSpace(dt1.Rows(j)("MenuIcon").ToString) Then
                        MenuIcon1 = "fa fa-circle-o"
                    Else
                        MenuIcon1 = dt1.Rows(j)("MenuIcon").ToString

                    End If

                    If (Trim(dt1.Rows(j)("NavigateUrl")).ToString = "") Then


                        Dim dt2 As DataTable = GetDataAll(Convert.ToInt16(dt1.Rows(j)("module_id").ToString))
                        If dt2.Rows.Count > 0 Then
                            StrBuilderMenu.Append("<li>")
                            StrBuilderMenu.Append("<a class='has-arrow waves-effect waves-dark' href='#' ><i class='" + MenuIcon1 + "'></i> " + Trim(dt1.Rows(j)("module_name").ToString) + " </a>")
                            StrBuilderMenu.Append("<ul aria-expanded='False' class='collapse In'>")

                            For K As Integer = 0 To dt2.Rows.Count - 1
                                Dim urlPath2 As String = Trim(dt2.Rows(K)("NavigateUrl").ToString.Replace("~", ""))
                                url = urlDomain + Trim(dt2.Rows(K)("NavigateUrl").ToString.Replace("~", ""))
                                If urlPath2 = "" Then
                                    url = "#"
                                End If

                                StrBuilderMenu.Append(" <li><a href='" + url + "' ><i class='fa fa-circle-o' ></i> " + Trim(dt2.Rows(K)("module_name").ToString) + "</a></li>")

                            Next
                            StrBuilderMenu.Append("</ul>")
                            StrBuilderMenu.Append("</li>")

                        Else

                            Dim urlPath1 As String = Trim(dt1.Rows(j)("NavigateUrl").ToString.Replace("~", ""))
                            url = urlDomain + Trim(dt1.Rows(j)("NavigateUrl").ToString.Replace("~", ""))
                            If urlPath1 = "" Then
                                url = "#"
                            End If

                            StrBuilderMenu.Append("<li><a href='" + url + "' ><i class='" + MenuIcon1 + "'></i> " + Trim(dt1.Rows(j)("module_name").ToString) + "</a></li>")
                        End If
                    Else
                        Dim urlPath1 As String = Trim(dt1.Rows(j)("NavigateUrl").ToString.Replace("~", ""))
                        url = urlDomain + Trim(dt1.Rows(j)("NavigateUrl").ToString.Replace("~", ""))
                        If urlPath1 = "" Then
                            url = "#"
                        End If

                        StrBuilderMenu.Append("<li><a href='" + url + "' ><i class='" + MenuIcon1 + "'></i> " + Trim(dt1.Rows(j)("module_name").ToString) + "</a></li>")
                    End If
                Next
                StrBuilderMenu.Append("</ul>")
            End If
            StrBuilderMenu.Append("</li>")

        Next


    End Sub

    Public Function GetDataAll(ByVal module_id As String) As DataTable
        Try
            Dim dt1 As DataTable, objDas As New DBAccess, sSQL As String


            sSQL = "SELECT isnull(NavigateUrl,'')as NavigateUrl,* FROM TreeviewRights where ISNULL(u_id,'') = '" & Trim(Session.Item("UserID")) & "' And isnull(Allow,'0')='1' and parent_module='" & module_id & "' order by ssrno "
            dt1 = objDas.GetDataTable(sSQL)


            Return dt1

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

