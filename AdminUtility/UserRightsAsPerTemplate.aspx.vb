Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class UserRightsAsPerTemplate
    Inherits System.Web.UI.Page
    Dim iPage As Integer = 0
    Dim sSortExp As String = ""
    Dim strcode As String
    Dim j As Integer
    Dim NewDocCode As String
    Public Shared mode As String
    Public i As Integer
    Dim Duplicate, DuplicatePONO As String
    Dim ValideDate As String
    Public Shared TempTable As New DataTable
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
        'Add CSS class on footer row.
        If (e.Row.RowType = DataControlRowType.Footer) Then
            e.Row.CssClass = "footer"
        End If
    End Sub

    Private Sub Refresh()
        ErrorMSG.Text = ""
        ErrorMSG.Visible = False
        ddlTemplate.Text = ""
        ddlUID.Text = ""
        ddlDepartment.Text = ""
        ddlModuleType.Text = ""

        TempTable = Nothing
        ddlTemplate.Focus()
    End Sub

    Private Sub Fillcombo()
        Try
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            sSQL = "Select Ltrim(Rtrim(u_id)) As u_id, Ltrim(Rtrim(U_name)) As U_name From users Where ISNULL(Template,0) = '1' Order By u_name "
            dt1 = objDas.GetDataTable(sSQL)
            dt1.Rows.InsertAt(dt1.NewRow, 0)
            ddlTemplate.DataSource = dt1
            ddlTemplate.DataTextField = "U_name"
            ddlTemplate.DataValueField = "u_id"
            ddlTemplate.DataBind()

            sSQL = "Select Ltrim(Rtrim(u_id)) As u_id, Ltrim(Rtrim(U_name)) As U_name From users Where ISNULL(Template,0) = '0' Order By u_name "
            dt2 = objDas.GetDataTable(sSQL)
            dt2.Rows.InsertAt(dt2.NewRow, 0)
            ddlUID.DataSource = dt2
            ddlUID.DataTextField = "U_name"
            ddlUID.DataValueField = "u_id"
            ddlUID.DataBind()

            sSQL = "Select Distinct Department From TreeviewRights Where ISNULL(Department,'') <> '' Order By Department Desc "
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlDepartment.DataSource = dt3
            ddlDepartment.DataTextField = "Department"
            ddlDepartment.DataValueField = "Department"
            ddlDepartment.DataBind()

            sSQL = "Select Distinct ModuleType From TreeviewRights Where ISNULL(ModuleType,'') <> '' Order By ModuleType Desc "
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlModuleType.DataSource = dt3
            ddlModuleType.DataTextField = "ModuleType"
            ddlModuleType.DataValueField = "ModuleType"
            ddlModuleType.DataBind()
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Private Sub Set_UserAccessRights()
        'Dim c As New DBAccess.Accessbuttons
        'c = DBAccess.Accessright(Trim(Session.Item("UserID")), "ITM")

        'If mode = "Add" Then
        '    btnDelete.Enabled = False
        '    'btnDelete0.Enabled = False
        'Else
        '    If c.allow_del = True Then
        '        btnDelete.Enabled = True
        '        'btnDelete0.Enabled = True
        '    Else
        '        btnDelete.Enabled = False
        '        'btnDelete0.Enabled = False
        '    End If
        'End If

        'If mode = "Add" Then
        '    If c.allow_add = True Then
        '        btnSave.Enabled = True
        '        'btnSave0.Enabled = True
        '    Else
        '        btnSave.Enabled = False
        '        'btnSave0.Enabled = False
        '    End If
        'End If

        'If mode <> "Add" Then
        '    If c.allow_mod = True Then
        '        btnSave.Enabled = True
        '        'btnSave0.Enabled = True
        '    Else
        '        btnSave.Enabled = False
        '        'btnSave0.Enabled = False
        '    End If
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Session("UserName") Is Nothing) Then
                Response.Redirect("~/SessionExpired.aspx")
            End If
            If Not IsPostBack Then
                ErrorMSG.Text = ""
                Fillcombo()

                'ddlTemplate.SelectedItem.Selected = False
                'ddlTemplate.Items.FindByValue("admin").Selected = True

                EmptyGrid()
            End If
            Set_UserAccessRights()
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        Call EmptyGrid()
        If GridView1.Rows.Count > 0 Then
            PanelNoRecordFound.Visible = False
            PanelRecordFound.Visible = True
        Else
            PanelNoRecordFound.Visible = True
            PanelRecordFound.Visible = False
        End If
    End Sub

    Protected Sub ddlUID_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlUID.SelectedIndexChanged
        'Call EmptyGrid(Trim(ddlUID.SelectedValue.ToString))
        'If GridView1.Rows.Count <= 0 Then
        '    Call EmptyGrid(Trim(ddlTemplate.SelectedValue.ToString))
        'End If
    End Sub

    Private Sub CreateGridView()
        GridView1.DataSource = CreateData()
        GridView1.DataBind()
    End Sub

    Private Function CreateData() As SqlDataSource
        Dim selectCmnd As String = "Exec Sp_UserRights_GetData '" & Trim(ddlTemplate.SelectedValue.ToString) & "', '" & Trim(ddlUID.SelectedValue.ToString) & "', '" & Trim(ddlDepartment.SelectedValue.ToString) & "', '" & Trim(ddlModuleType.SelectedValue.ToString) & "' "
        Return New SqlDataSource(thisConnectionString, selectCmnd)
    End Function

    Public Sub EmptyGrid()
        TempTable = Nothing
        CreateGridView()

        Dim sSQL As String, objDas As New DBAccess
        sSQL = "SELECT * from TreeviewRights where u_id = '' "
        TempTable = objDas.GetDataTable(sSQL)
        'Dim i As Integer
        'If TempTable.Rows.Count > 0 Then
        '    i = 1
        '    ViewState("CurrentTable1") = TempTable
        '    GridView1.DataSource = TempTable
        '    GridView1.DataBind()
        'Else
        '    TempTable = BindEmptyRows(0, TempTable)
        '    ViewState("CurrentTable1") = TempTable
        '    GridView1.DataSource = TempTable
        '    GridView1.DataBind()
        'End If
    End Sub

    Private Function BindEmptyRows(ByVal nofoRows As Integer, ByVal dt As DataTable) As DataTable
        Dim i As Integer = 0
        Do While (i < nofoRows)
            Dim dr As DataRow = dt.NewRow
            If mode = "Add" Then
                dr("srno") = (dt.Rows.Count + 1)
            End If
            dt.Rows.Add(dr)
            i = (i + 1)
        Loop
        Return dt
    End Function

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Response.Write(e.CommandName)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex)
            e.Row.Attributes("style") = "cursor:pointer"
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(1).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(2).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(3).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(5).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(6).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(14).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(15).Style.Add(HtmlTextWriterStyle.Display, "none")
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(1).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(2).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(3).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(5).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(6).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(14).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(15).Style.Add(HtmlTextWriterStyle.Display, "none")
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(1).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(2).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(3).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(5).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(6).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(14).Style.Add(HtmlTextWriterStyle.Display, "none")
            e.Row.Cells(15).Style.Add(HtmlTextWriterStyle.Display, "none")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        Try
            'If Check_User(Trim(ddlTemplate.SelectedValue.ToString)) = "New" Then
            Call save_add()
            'End If
        Catch ex As Exception
            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
            Exit Sub
        End Try
    End Sub

    Private Function Check_User(ByVal KeyCode As String) As String
        Check_User = ""
        Dim sSQL1 As String, dt1 As DataTable, objDas As New DBAccess
        sSQL1 = "Select u_id From TreeviewRights Where u_id = '" & Trim(KeyCode) & "'"
        dt1 = objDas.GetDataTable(sSQL1)
        If dt1.Rows.Count > 0 Then
            If Trim(dt1.Rows(0)("Authorize").ToString) = "1" Then
                Check_User = "Already Their"
            Else
                Check_User = "New"
            End If
        Else
            Check_User = ""
        End If
    End Function

    Private Sub save_add()
        Call Save_Data_Add()
    End Sub

    Private Sub Save_Data_Add()
        Try
            Dim obj As New ClsUserRights, objDas As New DBAccess
            Dim dtdet As New DataTable
            dtdet = TempTable

            For Each gvRow As GridViewRow In GridView1.Rows
                Dim drTemp As DataRow = dtdet.NewRow()
                'drTemp("srno") = Integer.Parse(GV1.DataKeys(gvRow.RowIndex)("srno").ToString)
                obj.Ssrno = CType(gvRow.FindControl("txtSsrno"), TextBox).Text.Trim
                obj.u_id = CType(gvRow.FindControl("txtu_id"), TextBox).Text.Trim
                obj.module_id = CType(gvRow.FindControl("txtmodule_id"), TextBox).Text.Trim
                obj.module_name = CType(gvRow.FindControl("txtmodule_name"), TextBox).Text.Trim
                obj.parent_module = CType(gvRow.FindControl("txtparent_module"), TextBox).Text.Trim
                obj.NavigateUrl = CType(gvRow.FindControl("txtNavigateUrl"), TextBox).Text.Trim
                If CType(gvRow.FindControl("CBAllow"), CheckBox).Checked = True Then
                    obj.Allow = "1"
                Else
                    obj.Allow = "0"
                End If
                If CType(gvRow.FindControl("CBallow_add"), CheckBox).Checked = True Then
                    obj.allow_add = "1"
                Else
                    obj.allow_add = "0"
                End If
                If CType(gvRow.FindControl("CBallow_mod"), CheckBox).Checked = True Then
                    obj.allow_mod = "1"
                Else
                    obj.allow_mod = "0"
                End If
                If CType(gvRow.FindControl("CBallow_del"), CheckBox).Checked = True Then
                    obj.allow_del = "1"
                Else
                    obj.allow_del = "0"
                End If
                If CType(gvRow.FindControl("CBallow_view"), CheckBox).Checked = True Then
                    obj.allow_view = "1"
                Else
                    obj.allow_view = "0"
                End If
                If CType(gvRow.FindControl("CBallow_san"), CheckBox).Checked = True Then
                    obj.allow_san = "1"
                Else
                    obj.allow_san = "0"
                End If
                If CType(gvRow.FindControl("CBallow_prev"), CheckBox).Checked = True Then
                    obj.allow_prev = "1"
                Else
                    obj.allow_prev = "0"
                End If
                obj.Department = CType(gvRow.FindControl("txtDepartment"), TextBox).Text.Trim
                obj.ModuleType = CType(gvRow.FindControl("txtModuleType"), TextBox).Text.Trim
                ClsUserRights.Update_Data(obj)
                dtdet.Rows.Add(drTemp)
            Next

            If ErrorMSG.Text = "" Then
                HFsave_value.Value = ""
                Dim myscript As String = "alert('Details Saved Succesfully');"
                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscript", myscript, True)
            End If
            'Call Refresh()
            Call EmptyGrid()
        Catch ex As Exception
            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    'Private Sub Save_Data_Add()
    '    Dim ds As DataSet
    '    Dim dtdet As New DataTable
    '    Dim dr As DataRow

    '    ds = ClsUserRights.GetDataForGride(ddlUID.SelectedValue.ToString)
    '    dtdet = ds.Tables("TreeviewRights")
    '    Try
    '        Dim obj As New ClsUserRights, objDas As New DBAccess
    '        Dim a As Integer = 1
    '        For Each gvRow As GridViewRow In GridView1.Rows
    '            Dim drTemp As DataRow = dtdet.NewRow()
    '            'drTemp("srno") = Integer.Parse(GridView1.DataKeys(gvRow.RowIndex)("srno").ToString)
    '            drTemp("srno") = a
    '            drTemp("Ssrno") = CType(gvRow.FindControl("txtSsrno"), TextBox).Text.Trim
    '            drTemp("u_id") = Trim(ddlUID.SelectedValue.ToString)
    '            drTemp("module_id") = CType(gvRow.FindControl("txtmodule_id"), TextBox).Text.Trim
    '            drTemp("module_name") = Trim(CType(gvRow.FindControl("txtmodule_name"), TextBox).Text.Trim)
    '            'If IsDBNull(CType(gvRow.FindControl("txtparent_module"), TextBox).Text.Trim) = True Then
    '            '    drTemp("parent_module") = System.DBNull.Value
    '            'Else
    '            '    drTemp("parent_module") = CType(gvRow.FindControl("txtparent_module"), TextBox).Text.Trim
    '            'End If
    '            If Trim(CType(gvRow.FindControl("txtparent_module"), TextBox).Text.Trim) = "" Then
    '                drTemp("parent_module") = System.DBNull.Value
    '            Else
    '                drTemp("parent_module") = CType(gvRow.FindControl("txtparent_module"), TextBox).Text.Trim
    '            End If
    '            drTemp("NavigateUrl") = CType(gvRow.FindControl("txtNavigateUrl"), TextBox).Text.Trim
    '            If CType(gvRow.FindControl("CBAllow"), CheckBox).Checked = True Then
    '                drTemp("Allow") = "1"
    '            Else
    '                drTemp("Allow") = "0"
    '            End If
    '            If CType(gvRow.FindControl("CBAllow"), CheckBox).Checked = True Then
    '                drTemp("Allow") = "1"
    '            Else
    '                drTemp("Allow") = "0"
    '            End If
    '            If CType(gvRow.FindControl("CBallow_add"), CheckBox).Checked = True Then
    '                drTemp("allow_add") = "1"
    '            Else
    '                drTemp("allow_add") = "0"
    '            End If
    '            If CType(gvRow.FindControl("CBallow_mod"), CheckBox).Checked = True Then
    '                drTemp("allow_mod") = "1"
    '            Else
    '                drTemp("allow_mod") = "0"
    '            End If
    '            If CType(gvRow.FindControl("CBallow_del"), CheckBox).Checked = True Then
    '                drTemp("allow_del") = "1"
    '            Else
    '                drTemp("allow_del") = "0"
    '            End If
    '            If CType(gvRow.FindControl("CBallow_view"), CheckBox).Checked = True Then
    '                drTemp("allow_view") = "1"
    '            Else
    '                drTemp("allow_view") = "0"
    '            End If
    '            If CType(gvRow.FindControl("CBallow_san"), CheckBox).Checked = True Then
    '                drTemp("allow_san") = "1"
    '            Else
    '                drTemp("allow_san") = "0"
    '            End If
    '            If CType(gvRow.FindControl("CBallow_prev"), CheckBox).Checked = True Then
    '                drTemp("allow_prev") = "1"
    '            Else
    '                drTemp("allow_prev") = "0"
    '            End If
    '            drTemp("Department") = CType(gvRow.FindControl("txtDepartment"), TextBox).Text.Trim
    '            drTemp("ModuleType") = CType(gvRow.FindControl("txtModuleType"), TextBox).Text.Trim
    '            dtdet.Rows.Add(drTemp)
    '            a = a + 1
    '        Next

    '        For i = dtdet.Rows.Count - 1 To 0 Step -1
    '            dr = dtdet.Rows(i)
    '            If (IsDBNull(dr("u_id")) Or dr("u_id") = "") Then
    '                dr.Delete()
    '            End If
    '        Next

    '        If dtdet.Rows.Count <= 0 Then
    '            Dim myscript As String = "alert('Nothing to Save');"
    '            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
    '            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscript", myscript, True)
    '            HFsave_value.Value = ""
    '            Exit Sub
    '        End If

    '        ds.GetChanges()
    '        ClsUserRights.Update_Data(ds, Trim(ddlUID.SelectedValue.ToString))

    '        If ErrorMSG.Text = "" Then
    '            HFsave_value.Value = ""
    '            Dim myscript As String = "alert('Details Saved Succesfully');"
    '            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
    '            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscript", myscript, True)
    '        End If

    '        'Call Refresh()
    '        Call EmptyGrid()
    '    Catch ex As Exception
    '        HFsave_value.Value = ""
    '        ErrorMSG.Visible = True
    '        ErrorMSG.Text = ""
    '        ErrorMSG.Text = ex.Message
    '    Finally

    '    End Try
    'End Sub

    Protected Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("~/Home.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
    End Sub

    Protected Sub cbAllowAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call SelectAllowAll()
    End Sub

    Protected Sub SelectAllowAll()
        Dim ChkBoxHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("CBAllowAll"), CheckBox)
        For Each row As GridViewRow In GridView1.Rows
            Dim ChkBoxRows As CheckBox = CType(row.FindControl("CBAllow"), CheckBox)
            If (ChkBoxHeader.Checked = True) Then
                ChkBoxRows.Checked = True
            Else
                ChkBoxRows.Checked = False
            End If
        Next
    End Sub

    Protected Sub CBAllowAddAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call SelectCBAllowAddAll()
    End Sub

    Protected Sub SelectCBAllowAddAll()
        Dim ChkBoxHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("CBAllowAddAll"), CheckBox)
        For Each row As GridViewRow In GridView1.Rows
            Dim ChkBoxRows As CheckBox = CType(row.FindControl("CBallow_add"), CheckBox)
            If (ChkBoxHeader.Checked = True) Then
                ChkBoxRows.Checked = True
            Else
                ChkBoxRows.Checked = False
            End If
        Next
    End Sub

    Protected Sub CBAllowModifyAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call SelectAllowModifyAll()
    End Sub

    Protected Sub SelectAllowModifyAll()
        Dim ChkBoxHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("CBAllowModifyAll"), CheckBox)
        For Each row As GridViewRow In GridView1.Rows
            Dim ChkBoxRows As CheckBox = CType(row.FindControl("CBallow_mod"), CheckBox)
            If (ChkBoxHeader.Checked = True) Then
                ChkBoxRows.Checked = True
            Else
                ChkBoxRows.Checked = False
            End If
        Next
    End Sub

    Protected Sub CBAllowDeleteAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call Selectallow_del()
    End Sub

    Protected Sub Selectallow_del()
        Dim ChkBoxHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("CBAllowDeleteAll"), CheckBox)
        For Each row As GridViewRow In GridView1.Rows
            Dim ChkBoxRows As CheckBox = CType(row.FindControl("CBallow_del"), CheckBox)
            If (ChkBoxHeader.Checked = True) Then
                ChkBoxRows.Checked = True
            Else
                ChkBoxRows.Checked = False
            End If
        Next
    End Sub

    Protected Sub CBAllowViewAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call Selectallow_view()
    End Sub

    Protected Sub Selectallow_view()
        Dim ChkBoxHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("CBAllowViewAll"), CheckBox)
        For Each row As GridViewRow In GridView1.Rows
            Dim ChkBoxRows As CheckBox = CType(row.FindControl("CBallow_view"), CheckBox)
            If (ChkBoxHeader.Checked = True) Then
                ChkBoxRows.Checked = True
            Else
                ChkBoxRows.Checked = False
            End If
        Next
    End Sub

    Protected Sub CBAllowAuthoAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call Selectallow_san()
    End Sub

    Protected Sub Selectallow_san()
        Dim ChkBoxHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("CBAllowAuthoAll"), CheckBox)
        For Each row As GridViewRow In GridView1.Rows
            Dim ChkBoxRows As CheckBox = CType(row.FindControl("CBallow_san"), CheckBox)
            If (ChkBoxHeader.Checked = True) Then
                ChkBoxRows.Checked = True
            Else
                ChkBoxRows.Checked = False
            End If
        Next
    End Sub

    Protected Sub CBAllowPreviewAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call Selectallow_prev()
    End Sub

    Protected Sub Selectallow_prev()
        Dim ChkBoxHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("CBAllowPreviewAll"), CheckBox)
        For Each row As GridViewRow In GridView1.Rows
            Dim ChkBoxRows As CheckBox = CType(row.FindControl("CBallow_prev"), CheckBox)
            If (ChkBoxHeader.Checked = True) Then
                ChkBoxRows.Checked = True
            Else
                ChkBoxRows.Checked = False
            End If
        Next
    End Sub

    Protected Sub CBTerminate_CheckedChanged(sender As Object, e As System.EventArgs)
        'Try
        '    Dim DelrowIndex As Integer = CType(CType(sender, CheckBox).Parent.Parent, GridViewRow).RowIndex
        '    Dim TextBoxtxtSrno As TextBox = CType(GridView1.Rows(DelrowIndex).Cells(1).FindControl("txtsrno"), TextBox)
        '    Dim TextBoxProductName As TextBox = CType(GridView1.Rows(DelrowIndex).Cells(1).FindControl("txtproductName"), TextBox)
        '    Dim CheckBoxTermi As CheckBox = CType(GridView1.Rows(DelrowIndex).Cells(1).FindControl("CBTerminate"), CheckBox)

        '    If CheckBoxTermi.Checked = True Then
        '        If Trim(txtprno.Text) <> "" And Trim(TextBoxtxtSrno.Text) <> "" And Trim(TextBoxProductName.Text) <> "" Then
        '            Termination(Trim(txtprno.Text), Trim(TextBoxtxtSrno.Text), Trim(Trim(ClsUserRights.Find_itemcd(TextBoxProductName.Text))), "Terminate")
        '            Dim myscript As String = "alert('Selected Item is Terminate');"
        '            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
        '            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscript", myscript, True)
        '        End If
        '    ElseIf CheckBoxTermi.Checked = False Then
        '        If Trim(txtprno.Text) <> "" And Trim(TextBoxtxtSrno.Text) <> "" And Trim(TextBoxProductName.Text) <> "" Then
        '            Termination(Trim(txtprno.Text), Trim(TextBoxtxtSrno.Text), Trim(Trim(ClsUserRights.Find_itemcd(TextBoxProductName.Text))), "UnTerminate")
        '            Dim myscript As String = "alert('Selected Item is UnTerminate');"
        '            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
        '            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscript", myscript, True)
        '        End If
        '    End If
        'Catch ex As Exception
        '    ErrorMSG.Visible = True
        '    ErrorMSG.Text = ""
        '    ErrorMSG.Text = ex.Message
        '    Exit Sub
        'End Try
    End Sub

    Private Sub Termination(ByVal DocNo As String, ByVal Srno As String, ByVal ItemCode As String, ByVal flag As String)
        Try
            Dim objDas As New DBAccess
            Dim sSQL As String
            If flag = "Terminate" Then
                sSQL = "Update purreqdet Set Terminate = '1', Termiuserid = '" & Trim(Session.Item("UserID")) & "', Termiuserdt = GetDate() Where prno ='" & Trim(DocNo) & "' And srno='" & Trim(Srno) & "' And itemcd='" & Trim(ItemCode) & "'"
                objDas.GetDataTable(sSQL)
            ElseIf flag = "UnTerminate" Then
                sSQL = "Update purreqdet Set Terminate = '0', Termiuserid = '" & Trim(Session.Item("UserID")) & "', Termiuserdt = GetDate() Where prno ='" & Trim(DocNo) & "' And srno='" & Trim(Srno) & "' And itemcd='" & Trim(ItemCode) & "'"
                objDas.GetDataTable(sSQL)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function Check_Termination(ByVal DocNo As String, ByVal Srno As String, ByVal ItemCode As String) As String
        Check_Termination = ""
        Dim sSQL1 As String, dt1 As DataTable, objDas As New DBAccess
        sSQL1 = "Select ISNULL(Terminate, 0) as Terminate, Termiuserid, Termiuserdt From purreqdet Where prno = '" & Trim(DocNo) & "' And srno='" & Trim(Srno) & "' And itemcd='" & Trim(ItemCode) & "'"
        dt1 = objDas.GetDataTable(sSQL1)
        If dt1.Rows.Count > 0 Then
            If Trim(dt1.Rows(0)("Terminate").ToString) = "1" Then
                Check_Termination = "Yes"
            Else
                Check_Termination = ""
            End If
        Else
            Check_Termination = ""
        End If
    End Function

End Class