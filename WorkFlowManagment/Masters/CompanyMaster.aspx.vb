Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports DevExpress.Web

Partial Class CompanyMaster
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
            ErrorMsg.Text = ""
            'FillData()
            CreateGridView()
            mode = "Add"
        End If
    End Sub

    Private Sub Refresh()
        HFcompcd.Value = ""
        txtcompname.Text = ""
        ErrorMsg.Text = ""
        ErrorMsg0.Text = ""
    End Sub

    Private Sub DisplayData(ByVal compcd As String)
        Try
            Dim obj As ClsCompanyMaster = ClsCompanyMaster.FillData(compcd, "B")
            If Not IsNothing(obj) Then
                HFcompcd.Value = obj.compcd
                txtcompname.Text = Trim(obj.compname)
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
        Dim selectCmnd As String = "Exec Sp_Company_PPC_GetData '','A' "
        Return New SqlDataSource(thisConnectionString, selectCmnd)
    End Function

    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs) Handles GridViewLST.CustomCallback
        GridViewLST.Columns.Clear()
        GridViewLST.AutoGenerateColumns = False
        GridViewLST.DataBind()
    End Sub

    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs) Handles GridViewLST.DataBinding
        GridViewLST.Columns(0).Visible = True
    End Sub



    Protected Sub btnEditEntry_Click(sender As Object, e As System.EventArgs)
        Dim button As ASPxButton = TryCast(sender, ASPxButton)
        Dim container As GridViewDataRowTemplateContainer = TryCast(button.NamingContainer, GridViewDataRowTemplateContainer)
        Dim visibleIndex As Integer = container.VisibleIndex
        Dim keyValue As Object = container.KeyValue
        Dim roomName As String = DataBinder.Eval(container.DataItem, "compcd").ToString()
        If Trim(roomName) <> "" Then
            mode = "Modify"
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
            strcode = ClsCompanyMaster.CheckDuplicate(txtcompname.Text).ToString
            If Trim(strcode) <> Trim(HFcompcd.Value) And strcode <> "" Then
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
            If txtcompname.Text = "" Then
                ErrorMsg0.Text = ""
                ErrorMsg0.Visible = True
                Exit Sub
            Else
                ErrorMsg0.Text = ""
                ErrorMsg0.Visible = False
            End If

            Dim obj As New ClsCompanyMaster, objDas As New DBAccess
            obj.compcd = HFcompcd.Value
            obj.compname = objDas.FilteredString(txtcompname.Text)

            If HFcompcd.Value = "" Then
                obj.compcd = ClsCompanyMaster.GetDocompcd
                If Check_Duplicate() = True Then
                    ErrorMsg0.Text = "'" & txtcompname.Text & "' Already Exist"
                    ErrorMsg0.Visible = True
                    Exit Try
                Else
                    ClsCompanyMaster.Update_Data(obj, "ADD")
                End If
            Else
                If Check_Duplicate() = True Then
                    ErrorMsg0.Text = "'" & txtcompname.Text & "' Already Exist"
                    ErrorMsg0.Visible = True
                    Exit Try
                Else
                    ClsCompanyMaster.Update_Data(obj, "EDIT")
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
            If HFcompcd.Value <> "" Then
                Dim str As String
                str = ClsCompanyMaster.Check_Integrity(HFcompcd.Value).ToString.Trim
                If str <> "" Then
                    'Dim myscript As String = "alert('Country Being Used In " & Trim(str) & "');"
                    'Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                    'str = ""
                    'Exit Sub

                    Dim myscript As String = "alert('Company Being Used In " & Trim(str) & "');"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                    ErrorMsg0.Visible = True
                    ErrorMsg0.Text = ""
                    ErrorMsg0.Text = "Company Being Used In " & Trim(str)
                    str = ""
                    Exit Sub
                End If

                Dim obj As New ClsCompanyMaster
                obj.compcd = HFcompcd.Value
                ClsCompanyMaster.Delete(obj)
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
End Class
