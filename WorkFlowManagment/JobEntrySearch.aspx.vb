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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("UserName") Is Nothing) Then
            Response.Redirect("~/SessionExpired.aspx")
        End If

        Me.Form.DefaultButton = Me.btnSubmit.UniqueID

        If Not IsPostBack Then
            Refresh()
            Fillcombo()
            GridViewLST.DataBind()
        End If
        GridChkbox()
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

    Protected Sub GridViewLST_CustomBindingGetDataRowCount(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewCustomBindingGetDataRowCountEventArgs)
        Dim totalRecords As Integer = 0
        GetJobData(0, 0, totalRecords, True)
        e.RowCount = totalRecords
    End Sub

    Protected Sub GridViewLST_CustomBindingGetData(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewCustomBindingGetDataEventArgs)
        Dim totalRecords As Integer = 0
        e.Data = GetJobData(e.StartDataRowIndex / e.DataRowCount + 1, e.DataRowCount, totalRecords, False)
    End Sub

    Private Function GetJobData(ByVal pageNumber As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer, ByVal isCountOnly As Boolean) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(thisConnectionString)
            Using com As New SqlCommand("Sp_jobentry_GetData", con)
                com.CommandType = CommandType.StoredProcedure
                com.Parameters.AddWithValue("@jobid", If(String.IsNullOrEmpty(txtJobId.Text), DBNull.Value, txtJobId.Text))
                com.Parameters.AddWithValue("@jobname", If(String.IsNullOrEmpty(txtJobName.Text),  DBNull.Value, txtJobName.Text))
                com.Parameters.AddWithValue("@intcode", If(String.IsNullOrEmpty(txtInternalCode.Text),  DBNull.Value, txtInternalCode.Text))
                com.Parameters.AddWithValue("@prioirty", If(String.IsNullOrEmpty(ddlprioirty.SelectedValue),  DBNull.Value, ddlprioirty.SelectedValue))
                com.Parameters.AddWithValue("@assignedto", If(String.IsNullOrEmpty(ddlassignedto.SelectedValue),  DBNull.Value, ddlassignedto.SelectedValue))
                com.Parameters.AddWithValue("@cuscode", If(String.IsNullOrEmpty(ddlcuscode.SelectedValue),  DBNull.Value, ddlcuscode.SelectedValue))
                com.Parameters.AddWithValue("@jobcreatedt", If(String.IsNullOrEmpty(txtjobcreatedt.Text),  DBNull.Value, txtjobcreatedt.Text))
                com.Parameters.AddWithValue("@ticketno", If(String.IsNullOrEmpty(txtticketno.Text),  DBNull.Value, txtticketno.Text))
                com.Parameters.AddWithValue("@Flag", "A")
                com.Parameters.AddWithValue("@empcd", If(Session.Item("UserID") Is Nothing,  DBNull.Value, Trim(Session.Item("UserID").ToString())))
                com.Parameters.AddWithValue("@status", DBNull.Value)

                If isCountOnly Then
                    com.Parameters.AddWithValue("@PageNumber", 1)
                    com.Parameters.AddWithValue("@PageSize", 0)
                Else
                    com.Parameters.AddWithValue("@PageNumber", pageNumber)
                    com.Parameters.AddWithValue("@PageSize", pageSize)
                End If

                Dim totalRecordsParam As New SqlParameter("@TotalRecords", SqlDbType.Int)
                totalRecordsParam.Direction = ParameterDirection.Output
                com.Parameters.Add(totalRecordsParam)

                con.Open()
                If isCountOnly Then
                    com.ExecuteNonQuery()
                Else
                    dt.Load(com.ExecuteReader())
                End If

                If totalRecordsParam.Value IsNot DBNull.Value Then
                    totalRecords = Convert.ToInt32(totalRecordsParam.Value)
                End If
            End Using
        End Using
        Return dt
    End Function

    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
        GridViewLST.DataBind()
    End Sub

    Protected Sub btnEditEntry_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As ASPxButton = TryCast(sender, ASPxButton)
        Dim container As GridViewDataRowTemplateContainer = TryCast(button.NamingContainer, GridViewDataRowTemplateContainer)
        Dim keyValue As Object = container.KeyValue
        Dim roomName As String = DataBinder.Eval(container.DataItem, "jobid").ToString()
        If Trim(roomName) <> "" Then
            Response.Redirect("JobEntry.aspx?docno=" & Trim(roomName) & "&MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        GridViewLST.DataBind()
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