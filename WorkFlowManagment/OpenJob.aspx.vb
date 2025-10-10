Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Partial Class OpenJob
    Inherits System.Web.UI.Page
    Dim iPage As Integer = 0
    Dim sSortExp As String = ""
    Dim strcode As String
    Dim j As Integer
    Dim NewDocCode As String
    Public Shared mode As String
    Public i, cc As Integer
    Dim Duplicate, DuplicatePONO As String
    Dim ValideDate As String
    Public Shared TempTable, TempTable1 As New DataTable
    Dim sFileShortName As String, sFileName As String, sUrl As String
    Public Shared AllowOrNotAuth As String

    Protected Sub gvHover_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        'Add CSS class on header row.
        If (e.Row.RowType = DataControlRowType.Header) Then
            e.Row.CssClass = "header"
        End If
        'Add CSS class on normal row.
        If ((e.Row.RowType = DataControlRowType.DataRow) _
                    AndAlso (e.Row.RowState = DataControlRowState.Normal)) Then
            e.Row.CssClass = "normal"
        End If
        'Add CSS class on alternate row.
        If ((e.Row.RowType = DataControlRowType.DataRow) _
                    AndAlso (e.Row.RowState = DataControlRowState.Alternate)) Then
            e.Row.CssClass = "alternate"
        End If
        'Add CSS class on footer row.
        If (e.Row.RowType = DataControlRowType.Footer) Then
            e.Row.CssClass = "footer"
        End If
    End Sub

    Private Sub Fillcombo()
        Try
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess


        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Private Sub Refresh()
        ErrorMSG.Text = ""
        ErrorMSG.Visible = False
        'txtinvoiceno.Text = ""
        txtinvoicedt.Text = Date.Now()



        txtinvoicedt.Focus()
    End Sub

    Protected Sub New_Docno()
        Try

        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Private Sub Disable()

    End Sub

    Private Sub Set_UserAccessRights()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Session("UserName") Is Nothing) Then
                Response.Redirect("~/SessionExpired.aspx")
            End If
            If Not IsPostBack Then
                Fillcombo()
                ErrorMSG.Text = ""
                If Trim(Request.QueryString("docno")) = "" Then
                    mode = "Add"
                    Refresh()

                    btnDelete.Enabled = False
                    txtinvoicedt.Focus()
                Else
                    mode = "Modify"
                    txtinvoiceno.Text = Trim(Request.QueryString("docno"))
                    txtinvoicedt.Focus()


                End If
                Set_UserAccessRights()

            End If
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub






    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click

    End Sub

    Protected Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("OpenJobSearch.aspx")
    End Sub


End Class