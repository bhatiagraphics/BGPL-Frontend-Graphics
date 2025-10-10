Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports FOODERPWEB.Class
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports DevExpress.Web

Partial Class UserMasterSearch
    Inherits System.Web.UI.Page
    Dim iPage As Integer = 0
    Dim sSortExp As String = ""
    Dim ds As DataSet
    Dim strcode As String
    Public Shared dv1 As DataView
    Public Shared dt As DataTable
    Dim ViewEntry As String
    Dim sFileShortName As String, sFileName As String, sUrl As String
    Public thisConnectionString As String = ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString

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
    End Sub

    Private Sub Refresh()
        ErrorMsg.Text = ""
        ErrorMsg.Visible = False
    End Sub

    Private Sub Fillcombo()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("UserName") Is Nothing) Then
            Response.Redirect("~/SessionExpired.aspx")
        End If

        Me.Form.DefaultButton = Me.btnSubmit.UniqueID
        ' Set_UserAccessRights()
        If Not IsPostBack Then
            Fillcombo()
            Refresh()
            CreateGridView()
        End If
        GridChkbox()
        ' Set_UserAccessRights()
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        CreateGridView()
    End Sub

    Private Sub CreateGridView()
        GridViewLST.SettingsBehavior.AllowFocusedRow = True
        GridViewLST.DataSource = CreateData()
        GridViewLST.DataBind()
        'CType(GridViewLST.Columns("grpname"), GridViewDataColumn).GroupBy()
        'GridViewLST.ExpandAll()
    End Sub

    Private Function CreateData() As SqlDataSource
        Dim selectCmnd As String = "Exec Sp_users_GetData '','A' "
        Return New SqlDataSource(thisConnectionString, selectCmnd)
    End Function

    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs) Handles GridViewLST.CustomCallback
        GridViewLST.Columns.Clear()
        GridViewLST.AutoGenerateColumns = False
        GridViewLST.DataBind()
    End Sub

    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs) Handles GridViewLST.DataBinding
        TryCast(sender, ASPxGridView).DataSource = CreateData()
        ' Set_UserAccessRights()
        'If ViewEntry = True Then
        GridViewLST.Columns(0).Visible = True
        'Else
        'GridViewLST.Columns(0).Visible = False
        'End If
    End Sub

    'Protected Sub Application_PreRequestHandlerExecute(ByVal sender As Object, ByVal e As EventArgs)
    '    'DevExpress.Web.ASPxWebControl.GlobalThemeBaseColor = "Red"
    '    ASPxWebControl.GlobalThemeBaseColor = "#00FF00"
    'End Sub

    Protected Sub btnEditEntry_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As ASPxButton = TryCast(sender, ASPxButton)
        Dim container As GridViewDataRowTemplateContainer = TryCast(button.NamingContainer, GridViewDataRowTemplateContainer)
        Dim visibleIndex As Integer = container.VisibleIndex
        Dim keyValue As Object = container.KeyValue
        Dim roomName As String = DataBinder.Eval(container.DataItem, "u_id").ToString()
        If Trim(roomName) <> "" Then
            Response.Redirect("UserMaster.aspx?docno=" & Trim(roomName) & "&MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("UserMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
    End Sub

    Private Sub GridChkbox()
        Try
            Dim filter As String = True
            Dim headerFilterMode As GridHeaderFilterMode = If(filter, GridHeaderFilterMode.CheckedList, GridHeaderFilterMode.List)
            For Each column As GridViewDataColumn In GridViewLST.Columns
                column.SettingsHeaderFilter.Mode = headerFilterMode
            Next column
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub Set_UserAccessRights()
    '    Dim c As New DBAccess.Accessbuttons
    '    c = DBAccess.Accessright(Trim(Session.Item("UserID")), Trim(Request.QueryString("")))

    '    If c.allow_add = True Then
    '        btnAdd.Visible = True
    '    Else
    '        btnAdd.Visible = False
    '    End If

    '    If c.allow_view = True Then
    '        ViewEntry = "True"
    '    Else
    '        ViewEntry = "False"
    '    End If
    'End Sub

End Class
