Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports FOODERPWEB.Class
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports DevExpress.Web

Partial Class JobEntrySearch
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

    Private Property CurrentPage() As Integer
        Get
            If ViewState("CurrentPage") Is Nothing Then
                Return 1
            End If
            Return CInt(ViewState("CurrentPage"))
        End Get
        Set(value As Integer)
            ViewState("CurrentPage") = value
        End Set
    End Property

    Private Property TotalRecords() As Integer
        Get
            If ViewState("TotalRecords") Is Nothing Then
                Return 0
            End If
            Return CInt(ViewState("TotalRecords"))
        End Get
        Set(value As Integer)
            ViewState("TotalRecords") = value
        End Set
    End Property



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



            sSQL = "select ltrim(rtrim(u_id))as u_id,ltrim(rtrim(u_name))as u_name from users order by u_name"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlassignedto.DataSource = dt3
            ddlassignedto.DataTextField = "u_name"
            ddlassignedto.DataValueField = "u_id"
            ddlassignedto.DataBind()

            sSQL = "select ltrim(rtrim(cuscode))as cuscode,ltrim(rtrim(cusname))as cusname from customer order by cusname"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlcuscode.DataSource = dt3
            ddlcuscode.DataTextField = "cusname"
            ddlcuscode.DataValueField = "cuscode"
            ddlcuscode.DataBind()

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
            'FillData()
            CreateGridView()
        End If
        GridChkbox()
    End Sub

    Private Sub CreateGridView()
        GridViewLST.SettingsBehavior.AllowFocusedRow = True
        
        Dim pageSize As Integer = GridViewLST.SettingsPager.PageSize
        Dim dt As DataTable = CreateData(CurrentPage, pageSize)
        
        GridViewLST.DataSource = dt
        GridViewLST.DataBind()

        ASPxWebControl.GlobalThemeBaseColor = "#4796CE"
    End Sub

    Private Function CreateData(Optional pageNumber As Integer = 1, Optional pageSize As Integer = 15) As DataTable
        Dim objDas As New DBAccess
        Dim dt As DataTable = Nothing
        
        Try
            Dim params As New List(Of SqlParameter)()
            params.Add(New SqlParameter("@jobid", If(String.IsNullOrEmpty(txtJobId.Text), "", txtJobId.Text)))
            params.Add(New SqlParameter("@jobname", If(String.IsNullOrEmpty(txtJobName.Text), "", txtJobName.Text)))
            params.Add(New SqlParameter("@intcode", If(String.IsNullOrEmpty(txtInternalCode.Text), "", txtInternalCode.Text)))
            params.Add(New SqlParameter("@prioirty", If(String.IsNullOrEmpty(ddlprioirty.SelectedValue), "", ddlprioirty.SelectedValue)))
            params.Add(New SqlParameter("@assignedto", If(String.IsNullOrEmpty(ddlassignedto.SelectedValue), "", ddlassignedto.SelectedValue)))
            params.Add(New SqlParameter("@cuscode", If(String.IsNullOrEmpty(ddlcuscode.SelectedValue), "", ddlcuscode.SelectedValue)))
            params.Add(New SqlParameter("@jobcreatedt", If(String.IsNullOrEmpty(txtjobcreatedt.Text), "", txtjobcreatedt.Text)))
            params.Add(New SqlParameter("@ticketno", If(String.IsNullOrEmpty(txtticketno.Text), "", txtticketno.Text)))
            params.Add(New SqlParameter("@Flag", "A"))
            params.Add(New SqlParameter("@empcd", If(Session.Item("UserID") Is Nothing, "", Trim(Session.Item("UserID").ToString()))))
            params.Add(New SqlParameter("@status", ""))
            params.Add(New SqlParameter("@PageNumber", pageNumber))
            params.Add(New SqlParameter("@PageSize", pageSize))
            
            Dim totalRecordsParam As New SqlParameter("@TotalRecords", SqlDbType.Int)
            totalRecordsParam.Direction = ParameterDirection.Output
            params.Add(totalRecordsParam)
            
            dt = objDas.GetDataTableWithParams("Sp_jobentry_GetData", params.ToArray())
            
            If totalRecordsParam.Value IsNot Nothing AndAlso Not IsDBNull(totalRecordsParam.Value) Then
                TotalRecords = CInt(totalRecordsParam.Value)
            Else
                TotalRecords = 0
            End If
            
            CurrentPage = pageNumber
            
        Catch ex As Exception
            ErrorMsg.Visible = True
            ErrorMsg.Text = "Error loading data: " & ex.Message
            dt = New DataTable()
        End Try
        
        Return dt
    End Function

    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
        'GridViewLST.Columns.Clear()
        'GridViewLST.AutoGenerateColumns = False
        'GridViewLST.DataBind()
    End Sub

    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        Dim pageSize As Integer = GridViewLST.SettingsPager.PageSize
        Dim pageIndex As Integer = GridViewLST.PageIndex
        
        Dim dt As DataTable = CreateData(pageIndex + 1, pageSize)
        TryCast(sender, ASPxGridView).DataSource = dt
    End Sub

    Protected Sub ASPxGridView1_PageIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
        If grid IsNot Nothing Then
            CurrentPage = grid.PageIndex + 1
            CreateGridView()
        End If
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
            Response.Redirect("JobEntry.aspx?docno=" & Trim(roomName) & "&MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
        End If
    End Sub



    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        CreateGridView()
    End Sub

    Protected Sub btnAddGP_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Response.Redirect("JobEntry.aspx")
    End Sub


    Private Sub GridChkbox()
        Dim filter As String = True
        Dim headerFilterMode As GridHeaderFilterMode = If(filter, GridHeaderFilterMode.CheckedList, GridHeaderFilterMode.List)
        For Each column As GridViewDataColumn In GridViewLST.Columns
            column.SettingsHeaderFilter.Mode = headerFilterMode
        Next column
    End Sub

End Class
