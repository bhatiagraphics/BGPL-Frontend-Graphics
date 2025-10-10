Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports DevExpress.Web

Partial Class RateList
    Inherits System.Web.UI.Page
    Dim iPage As Integer = 0
    Dim sSortExp As String = ""
    Dim ds As DataSet
    Dim strcode As String
    Public Shared dv1 As DataView
    Public Shared dt As DataTable
    Dim ViewEntry, Authorization, CallMeth As String
    Public Shared mode As String
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
        HFsrno.Value = ""
        txtrdate.Text = ""
        HFcuscode.Value = ""
        ddlcuscode.Text = ""
        HFcuscodeold.Value = ""
        ddlplatetypecd.Text = ""
        HFrate.Value = ""
        txtrate.Text = "0"
        ErrorMsg.Text = ""
        ErrorMsg0.Text = ""
    End Sub

    Private Sub Fillcombo()
        Try
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            sSQL = "select ltrim(rtrim(cuscode))as cuscode,ltrim(rtrim(cusname))as cusname from customer order by cusname "
            dt1 = objDas.GetDataTable(sSQL)
            dt1.Rows.InsertAt(dt1.NewRow, 0)
            ddlcuscode.DataSource = dt1
            ddlcuscode.DataTextField = "cusname"
            ddlcuscode.DataValueField = "cuscode"
            ddlcuscode.DataBind()

            sSQL = "select ltrim(rtrim(platetypecd))as platetypecd,ltrim(rtrim(platetypename))as platetypename from platetype order by platetypename "
            dt1 = objDas.GetDataTable(sSQL)
            dt1.Rows.InsertAt(dt1.NewRow, 0)
            ddlplatetypecd.DataSource = dt1
            ddlplatetypecd.DataTextField = "platetypename"
            ddlplatetypecd.DataValueField = "platetypecd"
            ddlplatetypecd.DataBind()


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

        'Me.Form.DefaultButton = Me.btnSearch.UniqueID
        'Set_UserAccessRights()
        If Not IsPostBack Then
            ErrorMsg.Text = ""
            Fillcombo()
            Refresh()
            CreateGridView()
            mode = "Add"


            'FillData()
        End If
        GridChkbox()
        Set_UserAccessRights()
    End Sub

    Private Sub CreateGridView()
        GridViewLST.SettingsBehavior.AllowFocusedRow = True
        GridViewLST.DataSource = CreateData()
        GridViewLST.DataBind()
        'CType(GridViewLST.Columns("grpname"), GridViewDataColumn).GroupBy()
        GridViewLST.ExpandAll()
    End Sub

    Private Function CreateData() As SqlDataSource
        Dim selectCmnd As String = "Exec Sp_RateList_GetData '','A' "
        Return New SqlDataSource(thisConnectionString, selectCmnd)
    End Function

    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
        GridViewLST.Columns.Clear()
        GridViewLST.AutoGenerateColumns = False
        GridViewLST.DataBind()
    End Sub

    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        TryCast(sender, ASPxGridView).DataSource = CreateData()
        Set_UserAccessRights()
        'If ViewEntry = True Then
        GridViewLST.Columns(0).Visible = True
        'Else
        '    GridViewLST.Columns(0).Visible = False
        'End If
    End Sub

    Private Sub DisplayData(ByVal srno As String)
        Try
            Dim obj As ClsRateList = ClsRateList.FillData(srno, "B")
            If Not IsNothing(obj) Then
                HFsrno.Value = Trim(obj.srno)
                'HFDate.Value = Trim(obj.rdate)
                txtrdate.Text = Trim(obj.rdate)
                HFcuscodeold.Value = Trim(obj.cuscode)
                ddlcuscode.SelectedItem.Selected = False
                ddlcuscode.Items.FindByValue(Trim(obj.cuscode)).Selected = True

                HFrate.Value = Trim(obj.rate)

                If Trim(obj.rate) <> "" Then
                    txtrate.Text = Trim(obj.rate)
                Else
                    txtrate.Text = 0.0#
                End If
                HFplatetypecdold.Value = Trim(obj.platetypecd)
                If Trim(obj.platetypecd) <> "" Then
                    ddlplatetypecd.SelectedItem.Selected = False
                    ddlplatetypecd.Items.FindByValue(Trim(obj.platetypecd)).Selected = True
                Else
                    ddlplatetypecd.Text = ""
                End If
            End If
        Catch ex As Exception
            ErrorMsg.Visible = True
            ErrorMsg.Text = ""
            ErrorMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub Set_UserAccessRights()
        'Dim c As New DBAccess.Accessbuttons
        'c = DBAccess.Accessright(Trim(Session.Item("UserID")), Trim("116"))

        'If c.allow_view = True Then
        '    ViewEntry = "True"
        'Else
        '    ViewEntry = "False"
        'End If

        'If mode = "Add" Then
        '    btnDelete.Visible = False
        'Else
        '    If c.allow_del = True Then
        '        btnDelete.Visible = True
        '    Else
        '        btnDelete.Visible = False
        '    End If
        'End If

        'If mode = "Add" Then
        '    If c.allow_add = True Then
        '        btnSave.Visible = True
        '        btnAdd.Visible = True
        '    Else
        '        btnSave.Visible = False
        '        btnAdd.Visible = False
        '    End If
        'End If

        'If mode <> "Add" Then
        '    If c.allow_mod = True Then
        '        btnSave.Visible = True
        '    Else
        '        btnSave.Visible = False
        '    End If
        'End If
    End Sub

    Protected Sub btnEditEntry_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As ASPxButton = TryCast(sender, ASPxButton)
        Dim container As GridViewDataRowTemplateContainer = TryCast(button.NamingContainer, GridViewDataRowTemplateContainer)
        Dim visibleIndex As Integer = container.VisibleIndex
        Dim keyValue As Object = container.KeyValue
        Dim roomName As String = DataBinder.Eval(container.DataItem, "srno").ToString()
        If Trim(roomName) <> "" Then
            mode = "Modify"
            Set_UserAccessRights()
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

    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Refresh()
        btnDelete.Enabled = False
        'chkActive.Checked = True
        showPopUp(True)
        ddlcuscode.Enabled = True
        ddlplatetypecd.Enabled = True
        txtrate.Enabled = True
        txtrdate.Enabled = True
        mode = "Add"
        Set_UserAccessRights()
    End Sub

    'Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
    '    CreateGridView()
    'End Sub

#Region "Buttons' Events"

    Private Sub cmdClosePopUp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdClosePopUp.Click
        showPopUp(False)
        Refresh()
    End Sub
#End Region

#Region "Own Functions"

    Private Sub showPopUp(ByVal b As Boolean)
        panelOverlay.Visible = b
        panelPopUpPanel.Visible = b
    End Sub

#End Region

    Public Function Check_Duplicate() As Boolean
        Check_Duplicate = False
        strcode = ClsRateList.CheckDuplicate_PS(Trim(ddlplatetypecd.SelectedItem.Value), Trim(ddlcuscode.SelectedItem.Value), Trim(txtrdate.Text)).ToString
        If strcode = "T" Then
            Return True
        Else
            Return False
            Exit Function
        End If
    End Function



    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        If ddlcuscode.SelectedItem.Value = "" Then
            ErrorMsg0.Text = ""
            ErrorMsg0.Visible = True
            Exit Sub
        Else
            ErrorMsg0.Text = ""
            ErrorMsg0.Visible = False
        End If
        If ddlplatetypecd.SelectedItem.Value = "" Then
            ErrorMsg0.Text = ""
            ErrorMsg0.Visible = True
            Exit Sub
        Else
            ErrorMsg0.Text = ""
            ErrorMsg0.Visible = False
        End If
        Try
            Dim obj As New ClsRateList, objDas As New DBAccess
            obj.srno = HFsrno.Value
            obj.rdate = txtrdate.Text
            If Trim(txtrate.Text) <> "" Then
                obj.rate = Trim(txtrate.Text)
            Else
                obj.rate = 0.0#
            End If
            obj.cuscode = Trim(ddlcuscode.SelectedValue)
            obj.platetypecd = Trim(ddlplatetypecd.SelectedValue)

            If HFsrno.Value = "" Then
                obj.srno = ClsRateList.GetDocCode
                If Check_Duplicate() = True Then
                    ErrorMsg0.Text = "Combination of Customer And Plate Type Already Exist"
                    ErrorMsg0.Visible = True
                    Exit Try
                Else
                    ClsRateList.Update_Data(obj, "ADD")
                End If
            Else
                If Trim(HFcuscodeold.Value) = Trim(ddlcuscode.SelectedItem.Value) And Trim(HFplatetypecdold.Value) = Trim(ddlplatetypecd.SelectedItem.Value) Then
                    ClsRateList.Update_Data(obj, "EDIT")
                Else
                    If Check_Duplicate() = True Then
                        ErrorMsg0.Text = "Combination of Customer And Plate Type  Already Exist"
                        ErrorMsg0.Visible = True
                        Exit Try
                    Else
                        ClsRateList.Update_Data(obj, "EDIT")
                    End If
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
            If HFsrno.Value <> "" Then
                Dim str As String
                'str = ClsRateList.Check_Integrity(HFsrno.Value).ToString.Trim
                If str <> "" Then
                    Dim myscript As String = "alert('Rate List Being Used In  " & Trim(str) & "');"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                    ErrorMsg0.Visible = True
                    ErrorMsg0.Text = ""
                    ErrorMsg0.Text = "Rate List Being Used In  " & Trim(str)
                    str = ""
                    Exit Sub
                End If

                Dim obj As New ClsRateList
                obj.srno = HFsrno.Value
                ClsRateList.Delete(obj)
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

    Protected Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
        showPopUp(False)
        Refresh()
    End Sub


End Class
