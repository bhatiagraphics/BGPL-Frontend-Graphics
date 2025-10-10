Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports DevExpress.Web

Partial Class CityMaster
    Inherits System.Web.UI.Page
    Dim iPage As Integer = 0
    Dim sSortExp As String = ""
    Dim ds As DataSet
    Dim strcode As String
    Public Shared dv1 As DataView
    Public Shared dt As DataTable
    Public Shared mode As String
    Dim ViewEntry As String
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
        ' ''Add CSS class on Selected row.
        'If ((e.Row.RowType = DataControlRowType.DataRow) _
        '            AndAlso (e.Row.RowState = DataControlRowState.Selected)) Then
        '    e.Row.CssClass = "Selected"
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("UserName") Is Nothing) Then
            Response.Redirect("~/SessionExpiredCRM.aspx")
        End If
        GridChkbox()
        If Not IsPostBack Then
            'Me.Form.DefaultButton = Me.btnSearch.UniqueID
            Fillcombo()

            ErrorMsg.Text = ""
            'FillData()
            CreateGridView()
            mode = "Add"
        End If
        'Set_UserAccessRights()
    End Sub

    Private Sub Fillcombo()
        Try
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            'sSQL = "SELECT ltrim(rtrim(countrycd))as countrycd,countryname From country ORDER BY countryname"
            'dt1 = objDas.GetDataTable(sSQL)
            'dt1.Rows.InsertAt(dt1.NewRow, 0)
            'ddlcountrycd.DataSource = dt1
            'ddlcountrycd.DataTextField = "countryname"
            'ddlcountrycd.DataValueField = "countrycd"
            'ddlcountrycd.DataBind()

            sSQL = "SELECT ltrim(rtrim(statecd))as statecd,statename From state ORDER BY statename"
            dt1 = objDas.GetDataTable(sSQL)
            dt1.Rows.InsertAt(dt1.NewRow, 0)
            ddlstatecd.DataSource = dt1
            ddlstatecd.DataTextField = "statename"
            ddlstatecd.DataValueField = "statecd"
            ddlstatecd.DataBind()

        Catch ex As Exception
            ErrorMsg.Visible = True
            ErrorMsg.Text = ""
            ErrorMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub Refresh()
        HFcitycd.Value = ""
        txtcityname.Text = ""
        'ddlcountrycd.Text = ""
        txtCountrycd.Text = ""
        ddlstatecd.Text = ""
        ErrorMsg.Text = ""
        ErrorMsg0.Text = ""
    End Sub

    Private Sub DisplayData(ByVal citycd As String)
        Try
            Dim obj As ClsCityMaster = ClsCityMaster.FillData(citycd, "B")
            If Not IsNothing(obj) Then
                HFcitycd.Value = obj.citycd
                txtcityname.Text = Trim(obj.cityname)

                HFstatecd.Value = Trim(obj.statecd)
                ddlstatecd.SelectedItem.Selected = False
                ddlstatecd.Items.FindByValue(Trim(obj.statecd)).Selected = True

                HFcountrycd.Value = Trim(obj.countrycd)
                txtCountrycd.Text = Trim(ClsCityMaster.Find_countrycdCode(Trim(HFcountrycd.Value)))




            End If
        Catch ex As Exception
            ErrorMsg.Visible = True
            ErrorMsg.Text = ""
            ErrorMsg.Text = ex.Message
        End Try
    End Sub

#Region "Buttons' Events"

    Private Sub cmdClosePopUp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdClosePopUp.Click
        showPopUp(False)
        Refresh()
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        showPopUp(False)
        Refresh()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Refresh()
        btnDelete.Enabled = False
        showPopUp(True)
        mode = "Add"
        'Set_UserAccessRights()
    End Sub

#End Region

#Region "Own Functions"

    Private Sub showPopUp(ByVal b As Boolean)
        panelOverlay.Visible = b
        panelPopUpPanel.Visible = b
    End Sub

#End Region

    Private Sub CreateGridView()
        GridViewLST.SettingsBehavior.AllowFocusedRow = True
        GridViewLST.DataSource = CreateData()
        GridViewLST.DataBind()
        'CType(GridViewLST.Columns("grpname"), GridViewDataColumn).GroupBy()
        'GridViewLST.ExpandAll()
    End Sub

    Private Function CreateData() As SqlDataSource
        Dim selectCmnd As String = "Exec Sp_city_GetData '','A' "
        Return New SqlDataSource(thisConnectionString, selectCmnd)
    End Function

    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs) Handles GridViewLST.CustomCallback
        GridViewLST.Columns.Clear()
        GridViewLST.AutoGenerateColumns = False
        GridViewLST.DataBind()
    End Sub

    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs) Handles GridViewLST.DataBinding
        TryCast(sender, ASPxGridView).DataSource = CreateData()
        'Set_UserAccessRights()
        'If ViewEntry = True Then
        GridViewLST.Columns(0).Visible = True
        'Else
        'GridViewLST.Columns(0).Visible = False
        'End If
    End Sub

    'Private Sub Set_UserAccessRights()
    '    Dim c As New DBAccess.Accessbuttons
    '    c = DBAccess.Accessright(Trim(Session.Item("UserID")), Trim("65"))

    '    If c.allow_view = True Then
    '        ViewEntry = "True"
    '    Else
    '        ViewEntry = "False"
    '    End If

    '    If mode = "Add" Then
    '        btnDelete.Visible = False
    '    Else
    '        If c.allow_del = True Then
    '            btnDelete.Visible = True
    '        Else
    '            btnDelete.Visible = False
    '        End If
    '    End If

    '    If mode = "Add" Then
    '        If c.allow_add = True Then
    '            btnSave.Visible = True
    '            btnAdd.Visible = True
    '        Else
    '            btnSave.Visible = False
    '            btnAdd.Visible = False
    '        End If
    '    End If

    '    If mode <> "Add" Then
    '        If c.allow_mod = True Then
    '            btnSave.Visible = True
    '        Else
    '            btnSave.Visible = False
    '        End If
    '    End If
    'End Sub

    Protected Sub btnEditEntry_Click1(sender As Object, e As System.EventArgs)
        Dim button As ASPxButton = TryCast(sender, ASPxButton)
        Dim container As GridViewDataRowTemplateContainer = TryCast(button.NamingContainer, GridViewDataRowTemplateContainer)
        Dim visibleIndex As Integer = container.VisibleIndex
        Dim keyValue As Object = container.KeyValue
        Dim roomName As String = DataBinder.Eval(container.DataItem, "citycd").ToString()
        If Trim(roomName) <> "" Then
            mode = "Modify"
            'Set_UserAccessRights()
            btnDelete.Enabled = True
            DisplayData(roomName)
            showPopUp(True)
        End If
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

    Public Function Check_Duplicate() As Boolean
        Try
            Check_Duplicate = False
            strcode = ClsCityMaster.CheckDuplicate(txtcityname.Text).ToString
            If Trim(strcode) <> Trim(HFcitycd.Value) And strcode <> "" Then
                Return True
            Else
                Return False
                Exit Function
            End If
        Catch ex As Exception
            ErrorMsg.Visible = True
            ErrorMsg.Text = ""
            ErrorMsg.Text = ex.Message
        End Try
    End Function

    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If txtcityname.Text = "" Then
                ErrorMsg0.Text = ""
                ErrorMsg0.Visible = True
                Exit Sub
            Else
                ErrorMsg0.Text = ""
                ErrorMsg0.Visible = False
            End If

            Dim obj As New ClsCityMaster, objDas As New DBAccess
            obj.citycd = HFcitycd.Value
            obj.cityname = Trim(txtcityname.Text)
            obj.statecd = Trim(ddlstatecd.SelectedItem.Value)

            obj.countrycd = objDas.FilteredString(HFcountrycd.Value)


            If HFcitycd.Value = "" Then
                obj.citycd = ClsCityMaster.GetDocCode
                If Check_Duplicate() = True Then
                    ErrorMsg0.Text = "'" & txtcityname.Text & "' Already Exist"
                    ErrorMsg0.Visible = True
                    Exit Try
                Else
                    ClsCityMaster.Update_Data(obj, "ADD")
                End If
            Else
                If Check_Duplicate() = True Then
                    ErrorMsg0.Text = "'" & txtcityname.Text & "' Already Exist"
                    ErrorMsg0.Visible = True
                    Exit Try
                Else
                    ClsCityMaster.Update_Data(obj, "EDIT")
                End If
            End If
            'FillData()
            CreateGridView()
            showPopUp(False)
        Catch ex As Exception
            ErrorMsg0.Visible = True
            ErrorMsg0.Text = ""
            ErrorMsg0.Text = ex.Message
            Exit Sub
        End Try
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If HFcitycd.Value <> "" Then
                Dim str As String
                str = ClsCityMaster.Check_Integrity(HFcitycd.Value).ToString.Trim
                If str <> "" Then
                    'Dim myscript As String = "alert('Country Being Used In " & Trim(str) & "');"
                    'Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                    'str = ""
                    'Exit Sub

                    Dim myscript As String = "alert('City Being Used In " & Trim(str) & "');"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                    ErrorMsg0.Visible = True
                    ErrorMsg0.Text = ""
                    ErrorMsg0.Text = "City Being Used In " & Trim(str)
                    str = ""
                    Exit Sub
                End If

                Dim obj As New ClsCityMaster
                obj.citycd = HFcitycd.Value
                ClsCityMaster.Delete(obj)
                'FillData()
                CreateGridView()
                showPopUp(False)
            End If
        Catch ex As Exception
            ErrorMsg0.Visible = True
            ErrorMsg0.Text = ""
            ErrorMsg0.Text = ex.Message
        End Try
    End Sub


    Protected Sub txtstatecd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstatecd.SelectedIndexChanged
        If ddlstatecd.Text <> "" Then
            HFstatecd.Value = Trim(ddlstatecd.SelectedItem.Value)
            If HFstatecd.Value = "" Then
                HFstatecd.Value = ""
                ddlstatecd.Text = ""
                HFcountrycd.Value = ""
                txtCountrycd.Text = ""
            Else
                GetCountryDetails()
                'txtPincode.Focus()
            End If
        Else
            HFstatecd.Value = ""
            ddlstatecd.Text = ""
            HFcountrycd.Value = ""
            txtCountrycd.Text = ""
            'txtCitycd.Focus()
            Exit Sub
        End If
    End Sub


    Private Sub GetCountryDetails()
        Try
            ClsCityMaster.FillCountryDetails(HFstatecd.Value)
            HFcountrycd.Value = Trim(ClsCityMaster.countrycd1)
            txtCountrycd.Text = Trim(ClsCityMaster.Find_countrycdCode(Trim(ClsCityMaster.countrycd1)))

            'txtLSTNo.Focus()
        Catch ex As Exception
            ErrorMsg.Visible = True
            ErrorMsg.Text = ""
            ErrorMsg.Text = ex.Message
        End Try
    End Sub

End Class
