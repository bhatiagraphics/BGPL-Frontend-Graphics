Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports System.IO
Imports System.Data.OleDb
Imports System.Globalization
Imports Microsoft.Reporting.WebForms
Imports System.Drawing

Imports System
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web

Partial Class AccountsLanding
    Inherits System.Web.UI.Page
    Dim sFileShortName As String, sFileName As String, sUrl As String
    Dim Duplicate, DuplicatePONO As String
    Public thisConnectionString As String = ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString
    Public Shared dv1 As DataView
    Public Shared dt As DataTable
    Dim iPage As Integer = 0
    Dim sSortExp As String = ""

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

    Public Property gv1SortDirection() As String
        Get
            Return ViewState("gv1SortDirection")
        End Get
        Set(ByVal value As String)
            ViewState("gv1SortDirection") = value
        End Set
    End Property
    'Protected Sub grid_CustomUnboundColumnData(ByVal sender As Object, ByVal e As ASPxGridViewColumnDataEventArgs)

    '    If e.Column.FieldName = "Number" Then
    '        e.Value = String.Format("{0}", e.ListSourceRowIndex + 1)
    '    End If
    'End Sub
    Private Sub Fillcombo()
        Dim sSQL1 As String, dt1, dt2 As DataTable, objDas As New DBAccess

        sSQL1 = "select compcd,compname from company_PPC order by compname"
        dt2 = objDas.GetDataTable(sSQL1)
        dt2.Rows.InsertAt(dt2.NewRow, 0)
        ddlcompcd.DataSource = dt2
        ddlcompcd.DataTextField = "compname"
        ddlcompcd.DataValueField = "compcd"
        ddlcompcd.DataBind()

        sSQL1 = "select cuscode,cusname from customer order by cusname"
        dt2 = objDas.GetDataTable(sSQL1)
        dt2.Rows.InsertAt(dt2.NewRow, 0)
        ddlshipcuscode.DataSource = dt2
        ddlshipcuscode.DataTextField = "cusname"
        ddlshipcuscode.DataValueField = "cuscode"
        ddlshipcuscode.DataBind()

        sSQL1 = "select transcd,transname from transport order by transname"
        dt2 = objDas.GetDataTable(sSQL1)
        dt2.Rows.InsertAt(dt2.NewRow, 0)
        ddltranscd.DataSource = dt2
        ddltranscd.DataTextField = "transname"
        ddltranscd.DataValueField = "transcd"
        ddltranscd.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'HyperLink3.NavigateUrl = String.Format("~/ReportDashBoardSetup.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
        If Not IsPostBack Then
            Fillcombo()
            DBAccess.Find_company()
            ddlmth.SelectedValue = DateTime.Now.Month
            ddlyr.SelectedValue = DateTime.Now.Year
            txtfromdt.Text = DBAccess.FinStart
            txttodt.Text = Format(Date.Now, "dd/MM/yyyy")
            txtfromdt.Text = DateTime.Now.ToString("01/MM/yyyy")
        End If
        GridChkbox()
    End Sub

    'Private Sub OpenPDF()
    '    Try
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, "key", "('" & PrintInv("Print") & "');", True)
    '        Response.Redirect("~/TempPdf/" & sFileShortName)
    '    Catch ex As Exception
    '        Dim myscript As String = "alert('" & ex.Message & "');"
    '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
    '    End Try
    'End Sub

    'Private Sub OpenExcel()
    '    Try
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, "key", "('" & PrintExcel("Print") & "');", True)
    '        Response.Redirect("~/TempPdf/" & sFileShortName)
    '    Catch ex As Exception
    '        Dim myscript As String = "alert('" & ex.Message & "');"
    '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
    '    End Try
    'End Sub

    Private Function PrintInv(ByVal Type As String) As String
        'Try
        '    Dim objDas As DBAccess = New DBAccess
        '    Dim report As New ReportDocument()
        '    If Not My.Computer.FileSystem.DirectoryExists(System.AppDomain.CurrentDomain.BaseDirectory & "\TempPdf") Then
        '        My.Computer.FileSystem.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory & "\TempPdf")
        '    End If
        '    report.Load(System.AppDomain.CurrentDomain.BaseDirectory & "Stores\ReportsRPT\PR_REGISTER.rpt")
        '    objDas.SetLoginDtls(report)
        '    report.SetParameterValue("@fromdt", Trim(txtfromdt.Text))
        '    report.SetParameterValue("@todt", Trim(txttodt.Text))
        '    report.SetParameterValue("@deptcd", Trim(ddlchannelcode.SelectedValue.ToString))
        '    report.SetParameterValue("@itemcd", Trim(ddloutputcd.SelectedValue.ToString))
        '    report.SetParameterValue("@companycd", Trim(ddlcompanycd.SelectedValue.ToString))
        '    report.SetParameterValue("@branchcd", Trim(ddlLoccd.SelectedValue.ToString))
        '    report.SetParameterValue("@flag", "")

        '    sFileShortName = "PR Register.pdf"
        '    sFileName = System.AppDomain.CurrentDomain.BaseDirectory & "TempPdf\" & sFileShortName
        '    report.ExportToDisk(ExportFormatType.PortableDocFormat, sFileName)
        '    sUrl = GetApplicationPath() & "/TempPdf/" & sFileShortName
        '    report.Close()
        '    If Type = "Print" Then
        '        Return sUrl
        '    Else
        '        Return sFileName
        '    End If
        'Catch ex As Exception
        '    Exit Function
        'End Try
    End Function

    Private Function PrintExcel(ByVal Type As String) As String
        'Try
        '    Dim objDas As DBAccess = New DBAccess
        '    Dim report As New ReportDocument()
        '    If Not My.Computer.FileSystem.DirectoryExists(System.AppDomain.CurrentDomain.BaseDirectory & .rpt")
        '    objDas.SetLoginDtls(report)"\TempPdf") Then
        '        My.Computer.FileSystem.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory & "\TempPdf")
        '    End If
        '    report.Load(System.AppDomain.CurrentDomain.BaseDirectory & "Stores\ReportsRPT\PR_REGISTER_Excel
        '    report.SetParameterValue("@fromdt", Trim(txtfromdt.Text))
        '    report.SetParameterValue("@todt", Trim(txttodt.Text))
        '    report.SetParameterValue("@deptcd", Trim(ddlchannelcode.SelectedValue.ToString))
        '    report.SetParameterValue("@itemcd", Trim(ddloutputcd.SelectedValue.ToString))
        '    report.SetParameterValue("@companycd", Trim(ddlcompanycd.SelectedValue.ToString))
        '    report.SetParameterValue("@branchcd", Trim(ddlLoccd.SelectedValue.ToString))
        '    report.SetParameterValue("@flag", "")

        '    sFileShortName = "PR Register.xls"
        '    sFileName = System.AppDomain.CurrentDomain.BaseDirectory & "TempPdf\" & sFileShortName
        '    report.ExportToDisk(ExportFormatType.Excel, sFileName)
        '    sUrl = GetApplicationPath() & "/TempPdf/" & sFileShortName
        '    report.Close()
        '    If Type = "Print" Then
        '        Return sUrl
        '    Else
        '        Return sFileName
        '    End If
        'Catch ex As Exception
        '    Exit Function
        'End Try
    End Function

    Public Function GetApplicationPath() As String
        Dim applicationPath As String = ""
        If (Not (Me.Page.Request.Url) Is Nothing) Then
            applicationPath = Me.Page.Request.Url.AbsoluteUri.Substring(0, (Me.Request.Url.AbsoluteUri.ToLower.IndexOf(Me.Request.ApplicationPath.ToLower, (Me.Request.Url.AbsoluteUri.ToLower.IndexOf(Me.Page.Request.Url.Authority.ToLower) + Me.Page.Request.Url.Authority.Length)) + Me.Request.ApplicationPath.Length))
        End If
        Return applicationPath
    End Function

    'Protected Sub btnPreview0_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnPreview.Click
    '    OpenPDF()
    'End Sub

    'Protected Sub btnExcel_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnExcel.Click
    '    OpenExcel()
    'End Sub

    ' Protected Sub btnSubmit_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click

    ' End Sub

    Private Sub CreateGridView()
        ASPxGridView1.SettingsBehavior.AllowFocusedRow = True
        ASPxGridView1.DataSource = CreateData()
        ASPxGridView1.DataBind()
        ASPxGridView1.ExpandAll()

    End Sub

    Private Function CreateData() As SqlDataSource
        Dim selectCmnd As String = "Exec Account_landing_sp '" & Trim(txtfromdt.Text) & "', '" & Trim(txttodt.Text) & "','" & Trim(Session.Item("UserID")) & "','" & Trim(ddlcompcd.SelectedValue) & "','" & Trim(ddlshipcuscode.SelectedValue) & "','" & Trim(ddltranscd.SelectedValue) & "'"
        Return New SqlDataSource(thisConnectionString, selectCmnd)
    End Function

    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs) Handles ASPxGridView1.CustomCallback
        ASPxGridView1.Columns.Clear()
        ASPxGridView1.AutoGenerateColumns = False
        ASPxGridView1.DataBind()
    End Sub

    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxGridView1.DataBinding
        TryCast(sender, ASPxGridView).DataSource = CreateData()
    End Sub

    Protected Sub ASPxGridView1_HeaderFilter(sender As Object, e As DevExpress.Web.ASPxGridViewHeaderFilterEventArgs) Handles ASPxGridView1.HeaderFilterFillItems

    End Sub

    Private Sub CreateGridView2()
        ASPxGridView2.SettingsBehavior.AllowFocusedRow = True
        ASPxGridView2.DataSource = CreateData2()
        ASPxGridView2.DataBind()
    End Sub

    Private Function CreateData2() As SqlDataSource
        Dim selectCmnd As String = "Exec Account_landing_Summ_sp '" & Trim(txtfromdt.Text) & "', '" & Trim(txttodt.Text) & "','" & Trim(Session.Item("UserID")) & "','" & Trim(ddlcompcd.SelectedValue) & "','" & Trim(ddlshipcuscode.SelectedValue) & "','" & Trim(ddltranscd.SelectedValue) & "'"
        Return New SqlDataSource(thisConnectionString, selectCmnd)
    End Function

    Protected Sub ASPxGridView2_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs) Handles ASPxGridView2.CustomCallback
        ASPxGridView2.Columns.Clear()
        ASPxGridView2.AutoGenerateColumns = False
        ASPxGridView2.DataBind()
    End Sub

    Protected Sub ASPxGridView2_DataBinding(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxGridView2.DataBinding
        TryCast(sender, ASPxGridView).DataSource = CreateData2()
    End Sub

    Protected Sub ASPxGridView2_HeaderFilter(sender As Object, e As DevExpress.Web.ASPxGridViewHeaderFilterEventArgs) Handles ASPxGridView2.HeaderFilterFillItems

    End Sub


    Private Sub CreateGridView3()
        ASPxGridView3.SettingsBehavior.AllowFocusedRow = True
        ASPxGridView3.DataSource = CreateData3()
        ASPxGridView3.DataBind()
    End Sub

    Private Function CreateData3() As SqlDataSource
        Dim selectCmnd As String = "Exec Account_landing_DatewiseSumm_sp '" & Trim(txtfromdt.Text) & "', '" & Trim(txttodt.Text) & "','" & Trim(Session.Item("UserID")) & "','" & Trim(ddlcompcd.SelectedValue) & "','" & Trim(ddlshipcuscode.SelectedValue) & "','" & Trim(ddltranscd.SelectedValue) & "'"
        Return New SqlDataSource(thisConnectionString, selectCmnd)
    End Function

    Protected Sub ASPxGridView3_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs) Handles ASPxGridView3.CustomCallback
        ASPxGridView3.Columns.Clear()
        ASPxGridView3.AutoGenerateColumns = False
        ASPxGridView3.DataBind()
    End Sub

    Protected Sub ASPxGridView3_DataBinding(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxGridView3.DataBinding
        TryCast(sender, ASPxGridView).DataSource = CreateData3()
    End Sub

    Protected Sub ASPxGridView3_HeaderFilter(sender As Object, e As DevExpress.Web.ASPxGridViewHeaderFilterEventArgs) Handles ASPxGridView3.HeaderFilterFillItems

    End Sub


    Private Sub GridChkbox()
        Dim filter As String = True
        Dim headerFilterMode As GridHeaderFilterMode = If(filter, GridHeaderFilterMode.CheckedList, GridHeaderFilterMode.List)
        For Each column As GridViewDataColumn In ASPxGridView1.Columns
            column.SettingsHeaderFilter.Mode = headerFilterMode
        Next column
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        CreateGridView()
        CreateGridView2()
        CreateGridView3()

    End Sub

    Protected Sub ddlmth_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Check if month and year are selected
        If ddlmth.SelectedValue <> "" AndAlso ddlyr.SelectedValue <> "" Then
            Dim monthNumber As Integer = Convert.ToInt32(ddlmth.SelectedValue)
            Dim yearNumber As Integer = Convert.ToInt32(ddlyr.SelectedValue)

            ' First day of the selected month
            Dim fromDate As New DateTime(yearNumber, monthNumber, 1)

            ' Last day of the selected month
            Dim toDate As DateTime = fromDate.AddMonths(1).AddDays(-1)

            ' Format as dd/MM/yyyy
            txtfromdt.Text = fromDate.ToString("dd/MM/yyyy")
            txttodt.Text = toDate.ToString("dd/MM/yyyy")
        Else
            ' Clear dates if incomplete selection
            txtfromdt.Text = ""
            txttodt.Text = ""
        End If
    End Sub

    Protected Sub ddlyr_SelectedIndexChanged(sender As Object, e As EventArgs)
        ddlmth_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub btnBilling_Click(sender As Object, e As EventArgs)
        Dim button As ASPxButton = TryCast(sender, ASPxButton)
        Dim container As GridViewDataRowTemplateContainer = TryCast(button.NamingContainer, GridViewDataRowTemplateContainer)
        Dim visibleIndex As Integer = container.VisibleIndex
        Dim keyValue As Object = container.KeyValue
        Dim roomName As String = DataBinder.Eval(container.DataItem, "jobid").ToString()
        If Trim(roomName) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('/WorkFlowManagment/BillingForm.aspx?docno=" & roomName & "&MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "');", True)
        End If
    End Sub
End Class
