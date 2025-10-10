Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports FOODERPWEB.Class
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports DevExpress.Web

Partial Class DispatchLandingSearch
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
        Try
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            sSQL = "select ltrim(rtrim(compcd))as compcd,ltrim(rtrim(compname))as compname from Company_PPC order by compname"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlcompcd.DataSource = dt3
            ddlcompcd.DataTextField = "compname"
            ddlcompcd.DataValueField = "compcd"
            ddlcompcd.DataBind()

            sSQL = "select ltrim(rtrim(transcd))as transcd,ltrim(rtrim(transname))as transname from transport order by transname"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddltranscd.DataSource = dt3
            ddltranscd.DataTextField = "transname"
            ddltranscd.DataValueField = "transcd"
            ddltranscd.DataBind()

            sSQL = "select ltrim(rtrim(cuscode))as cuscode,ltrim(rtrim(cusname))as cusname from customer order by cusname"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlcuscode.DataSource = dt3
            ddlcuscode.DataTextField = "cusname"
            ddlcuscode.DataValueField = "cuscode"
            ddlcuscode.DataBind()

            sSQL = "select ltrim(rtrim(cuscode))as cuscode,ltrim(rtrim(cusname))as cusname from customer order by cusname"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlshipto.DataSource = dt3
            ddlshipto.DataTextField = "cusname"
            ddlshipto.DataValueField = "cuscode"
            ddlshipto.DataBind()
        Catch ex As Exception
            ErrorMsg.Visible = True
            ErrorMsg.Text = ""
            ErrorMsg.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("UserName") Is Nothing) Then
            Response.Redirect("~/SessionExpired.aspx")
        End If

        Me.Form.DefaultButton = Me.btnSubmit.UniqueID

        If Not IsPostBack Then
            Refresh()
            Fillcombo()
            txtplate_processed_date.Text = Date.Now
            'FillData()
            CreateGridView()
        End If
        GridChkbox()
    End Sub

    Private Sub CreateGridView()
        GridViewLST.SettingsBehavior.AllowFocusedRow = True
        GridViewLST.DataSource = CreateData()
        GridViewLST.DataBind()


        ASPxWebControl.GlobalThemeBaseColor = "#4796CE"
    End Sub

    Private Function CreateData() As SqlDataSource
        Dim selectCmnd As String = "Exec Sp_jobdispatchLanding_GetData '','" & Trim(txtplate_processed_date.Text) & "','','','','','','" & Trim(ddlcompcd.SelectedValue) & "','" & ddlcuscode.SelectedValue & "','" & Trim(ddlshipto.SelectedValue) & "','" & Trim(ddltranscd.SelectedValue) & "','','A','" & Trim(Session.Item("UserID")) & "','C' "
        Return New SqlDataSource(thisConnectionString, selectCmnd)
    End Function

    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
        'GridViewLST.Columns.Clear()
        'GridViewLST.AutoGenerateColumns = False
        'GridViewLST.DataBind()
    End Sub

    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        TryCast(sender, ASPxGridView).DataSource = CreateData()
        'Set_UserAccessRights()
        'If ViewEntry = True Then
        '    GridViewLST.Columns(0).Visible = True
        'Else
        '    GridViewLST.Columns(0).Visible = False
        'End If
    End Sub

    ''Protected Sub Application_PreRequestHandlerExecute(ByVal sender As Object, ByVal e As EventArgs)
    ''    DevExpress.Web.ASPxWebControl.GlobalThemeBaseColor = "Red"
    ''    DevExpress.Web.ASPxWebControl.GlobalThemeFont = "30px 'Calibri'"
    ''End Sub

    Protected Sub btnEditEntry_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As ASPxButton = TryCast(sender, ASPxButton)
        Dim container As GridViewDataRowTemplateContainer = TryCast(button.NamingContainer, GridViewDataRowTemplateContainer)
        Dim visibleIndex As Integer = container.VisibleIndex
        Dim keyValue As Object = container.KeyValue
        Dim roomName As String = DataBinder.Eval(container.DataItem, "jobid").ToString()
        If Trim(roomName) <> "" Then
            ' Response.Redirect("ChallanForm.aspx?docno=" & Trim(roomName) & "&MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('DispatchLanding.aspx?docno=" & roomName & "&MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "');", True)

        End If
    End Sub



    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        CreateGridView()
    End Sub

    Private Sub GridChkbox()
        Dim filter As String = True
        Dim headerFilterMode As GridHeaderFilterMode = If(filter, GridHeaderFilterMode.CheckedList, GridHeaderFilterMode.List)
        For Each column As GridViewDataColumn In GridViewLST.Columns
            column.SettingsHeaderFilter.Mode = headerFilterMode
        Next column
    End Sub

End Class
