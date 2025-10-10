
Imports System.Data
Imports System.Data.SqlClient
Imports AGPLCRM.Class
Imports AGPLERPWEB.DAL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Globalization

Partial Class MainDashBoard
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.Page.Title = "HRMS"
    End Sub
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("UserName") Is Nothing) Then
            Response.Redirect("~/SessionExpiredHRMS.aspx")
        End If
        'Dim o As New DBAccess, dt As DataTable
        'dt = o.GetDataTable("select * from Designation where DesignationCode='" & Trim(Session.Item("DesignationCode")) & "' and isnull(adm_dashboard,'')='1'")
        'If dt.Rows.Count > 0 Then
        '    'Header.Visible = True
        '    branchdet.Visible = True
        'Else
        '    'Header.Visible = False
        '    branchdet.Visible = False
        'End If
        'If check_reportin_mngr() = True Then
        '    AuthHeader.Visible = True
        '    Header.Visible = True
        'Else
        '    AuthHeader.Visible = False
        '    Header.Visible = False
        'End If

        GetDetails()
        'ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscriptChartLead", "LoadLead();", True)
    End Sub




    'Private Sub Fillcombo_PC(ByVal loccd As String)
    '    Dim sSQL As String
    '    Dim dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8 As DataTable
    '    Dim objDas As New DBAccess

    '    sSQL = "Lead_Search_pc_filter '" & Trim(loccd) & "','" & Trim(Session.Item("UserID")) & "' "
    '    dt3 = objDas.GetDataTable(sSQL)
    '    dt3.Rows.InsertAt(dt3.NewRow, 0)
    '    ddlpccode.DataSource = dt3
    '    ddlpccode.DataTextField = "empname"
    '    ddlpccode.DataValueField = "empcd"
    '    ddlpccode.DataBind()
    'End Sub



    Private Sub GetDetails()
        Try
            Parallel.Invoke(New Action(Sub() Get_Data()))
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert('" & (ex.Message).Replace("'", "") & "');", True)
            Exit Sub
        End Try
    End Sub

    Private Sub Get_Data()
        Dim dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9, dt10, dt11, dt12, dt13, dt14, dt15, dt16, dt17, dt18, dt19, dt20, dt21, dt22, dt23, dt24 As DataTable
        Dim da1, da2, da3, da4, da5, da6, da7, da8, da9, da10, da11, da12, da13, da14, da15, da16, da17, da18, da19, da20, da21, da22, da23, da24 As SqlDataAdapter
        Dim cnn As New SqlConnection()
        Dim objConnectionStringSettings As ConnectionStringSettings
        objConnectionStringSettings = ConfigurationManager.ConnectionStrings("ConStr")
        Dim sCon As String = ""
        sCon = objConnectionStringSettings.ConnectionString
        Dim objDas As New DBAccess
        Try
            cnn.ConnectionString = sCon
            Dim strfromdt, strtodt, strloccd, strpccd, strempcd, strsourcecd, struserid As String

            Dim sql1, sql2, sql3, sql4, sql5, sql6, sql7, sql8, sql9, sql10, sql11, sql12, sql13, sql14, sql15, sql16, sql17, sql18, sql19, sql20, sql21, sql22, sql23, sql24 As String
            Dim status_meet_Notworked, status_meeting_f2f, status_meeting_factsheet, status_meeting_followforfinalclosure, status_meeting_closed, status_meeting_soln_offerd As String



            sql1 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd1 As New SqlClient.SqlCommand(sql1, cnn)
            da1 = New SqlDataAdapter()
            cmd1.CommandText = sql1
            cmd1.CommandTimeout = 900
            da1.SelectCommand = cmd1
            dt1 = New DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                lblTotalJobs.Text = Val(dt1.Rows(0)("tot_jobs").ToString).ToString("N", New CultureInfo("hi-IN"))

            End If

            sql2 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd2 As New SqlClient.SqlCommand(sql2, cnn)
            da2 = New SqlDataAdapter()
            cmd2.CommandText = sql2
            cmd2.CommandTimeout = 900
            da2.SelectCommand = cmd2
            dt2 = New DataTable()
            da2.Fill(dt2)
            If dt2.Rows.Count > 0 Then
                lblPendingJobs.Text = Val(dt2.Rows(0)("pending_jobs").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql3 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd3 As New SqlClient.SqlCommand(sql3, cnn)
            da3 = New SqlDataAdapter()
            cmd3.CommandText = sql3
            cmd3.CommandTimeout = 900
            da3.SelectCommand = cmd3
            dt3 = New DataTable()
            da3.Fill(dt3)
            If dt3.Rows.Count > 0 Then
                lblSendToGraphics.Text = Val(dt3.Rows(0)("sendto_graphichs").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql4 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd4 As New SqlClient.SqlCommand(sql4, cnn)
            da4 = New SqlDataAdapter()
            cmd4.CommandText = sql4
            cmd4.CommandTimeout = 900
            da4.SelectCommand = cmd4
            dt4 = New DataTable()
            da4.Fill(dt4)
            If dt4.Rows.Count > 0 Then
                lblSendToCustomer.Text = Val(dt4.Rows(0)("sendto_customer").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql5 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd5 As New SqlClient.SqlCommand(sql5, cnn)
            da5 = New SqlDataAdapter()
            cmd5.CommandText = sql5
            cmd5.CommandTimeout = 900
            da5.SelectCommand = cmd5
            dt5 = New DataTable()
            da5.Fill(dt5)
            If dt5.Rows.Count > 0 Then
                lblSendTOCustomerForApproval.Text = Val(dt5.Rows(0)("sendto_customer_approval").ToString).ToString("N", New CultureInfo("hi-IN"))

            End If



            sql6 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd6 As New SqlClient.SqlCommand(sql6, cnn)
            da6 = New SqlDataAdapter()
            cmd6.CommandText = sql6
            cmd6.CommandTimeout = 900
            da6.SelectCommand = cmd6
            dt6 = New DataTable()
            da6.Fill(dt6)
            If dt6.Rows.Count > 0 Then
                lblSendToPrepress.Text = Val(dt6.Rows(0)("sendto_prepress").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql7 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd7 As New SqlClient.SqlCommand(sql7, cnn)
            da7 = New SqlDataAdapter()
            cmd7.CommandText = sql7
            cmd7.CommandTimeout = 900
            da7.SelectCommand = cmd5
            dt7 = New DataTable()
            da7.Fill(dt7)
            If dt7.Rows.Count > 0 Then
                lblSendToMaterialProduction.Text = Val(dt7.Rows(0)("sendto_materialprod").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If

            sql8 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd8 As New SqlClient.SqlCommand(sql8, cnn)
            da8 = New SqlDataAdapter()
            cmd8.CommandText = sql8
            cmd8.CommandTimeout = 900
            da8.SelectCommand = cmd8
            dt8 = New DataTable()
            da8.Fill(dt8)
            If dt8.Rows.Count > 0 Then
                lblSendToQCCheck.Text = Val(dt8.Rows(0)("sendto_qc").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql9 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd9 As New SqlClient.SqlCommand(sql9, cnn)
            da9 = New SqlDataAdapter()
            cmd9.CommandText = sql9
            cmd9.CommandTimeout = 900
            da9.SelectCommand = cmd9
            dt9 = New DataTable()
            da9.Fill(dt9)
            If dt9.Rows.Count > 0 Then
                lblSendToBilling.Text = Val(dt9.Rows(0)("sendto_billing").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql10 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd10 As New SqlClient.SqlCommand(sql10, cnn)
            da10 = New SqlDataAdapter()
            cmd10.CommandText = sql10
            cmd10.CommandTimeout = 900
            da10.SelectCommand = cmd10
            dt10 = New DataTable()
            da10.Fill(dt10)
            If dt10.Rows.Count > 0 Then
                lblSendToDispatch.Text = Val(dt10.Rows(0)("sendto_dispatch").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If

            sql11 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd11 As New SqlClient.SqlCommand(sql11, cnn)
            da11 = New SqlDataAdapter()
            cmd11.CommandText = sql11
            cmd11.CommandTimeout = 900
            da11.SelectCommand = cmd11
            dt11 = New DataTable()
            da11.Fill(dt11)
            If dt11.Rows.Count > 0 Then
                lblDispatchedJobs.Text = Val(dt11.Rows(0)("dispatched_jobs").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If

            sql12 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd12 As New SqlClient.SqlCommand(sql12, cnn)
            da12 = New SqlDataAdapter()
            cmd12.CommandText = sql12
            cmd12.CommandTimeout = 900
            da12.SelectCommand = cmd12
            dt12 = New DataTable()
            da12.Fill(dt12)
            If dt12.Rows.Count > 0 Then
                lblCancelledJobs.Text = Val(dt12.Rows(0)("cancelled_jobs").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            '----------------------------------letterflexo---------------------------------------

            sql13 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd13 As New SqlClient.SqlCommand(sql13, cnn)
            da13 = New SqlDataAdapter()
            cmd13.CommandText = sql13
            cmd13.CommandTimeout = 900
            da13.SelectCommand = cmd13
            dt13 = New DataTable()
            da13.Fill(dt13)
            If dt13.Rows.Count > 0 Then
                lblTotalJobslpf.Text = Val(dt13.Rows(0)("tot_jobs").ToString).ToString("N", New CultureInfo("hi-IN"))

            End If

            sql14 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd14 As New SqlClient.SqlCommand(sql14, cnn)
            da14 = New SqlDataAdapter()
            cmd14.CommandText = sql14
            cmd14.CommandTimeout = 900
            da14.SelectCommand = cmd14
            dt14 = New DataTable()
            da14.Fill(dt14)
            If dt14.Rows.Count > 0 Then
                lblPendingJobslpf.Text = Val(dt14.Rows(0)("pending_jobs").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql15 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd15 As New SqlClient.SqlCommand(sql15, cnn)
            da15 = New SqlDataAdapter()
            cmd15.CommandText = sql15
            cmd15.CommandTimeout = 900
            da15.SelectCommand = cmd15
            dt15 = New DataTable()
            da15.Fill(dt15)
            If dt15.Rows.Count > 0 Then
                lblSendToGraphicslpf.Text = Val(dt15.Rows(0)("sendto_graphichs").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql16 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd16 As New SqlClient.SqlCommand(sql16, cnn)
            da16 = New SqlDataAdapter()
            cmd16.CommandText = sql16
            cmd16.CommandTimeout = 900
            da16.SelectCommand = cmd16
            dt16 = New DataTable()
            da16.Fill(dt16)
            If dt16.Rows.Count > 0 Then
                lblSendToCustomerlpf.Text = Val(dt16.Rows(0)("sendto_customer").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql17 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd17 As New SqlClient.SqlCommand(sql17, cnn)
            da17 = New SqlDataAdapter()
            cmd17.CommandText = sql17
            cmd17.CommandTimeout = 900
            da17.SelectCommand = cmd17
            dt17 = New DataTable()
            da17.Fill(dt17)
            If dt17.Rows.Count > 0 Then
                lblSendTOCustomerForApprovallpf.Text = Val(dt17.Rows(0)("sendto_customer_approval").ToString).ToString("N", New CultureInfo("hi-IN"))

            End If



            sql18 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd18 As New SqlClient.SqlCommand(sql18, cnn)
            da18 = New SqlDataAdapter()
            cmd18.CommandText = sql18
            cmd18.CommandTimeout = 900
            da18.SelectCommand = cmd18
            dt18 = New DataTable()
            da18.Fill(dt18)
            If dt18.Rows.Count > 0 Then
                lblSendToPrepresslpf.Text = Val(dt18.Rows(0)("sendto_prepress").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql19 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd19 As New SqlClient.SqlCommand(sql19, cnn)
            da19 = New SqlDataAdapter()
            cmd19.CommandText = sql19
            cmd19.CommandTimeout = 900
            da19.SelectCommand = cmd19
            dt19 = New DataTable()
            da19.Fill(dt19)
            If dt19.Rows.Count > 0 Then
                lblSendToMaterialProductionlpf.Text = Val(dt19.Rows(0)("sendto_materialprod").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If

            sql20 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd20 As New SqlClient.SqlCommand(sql20, cnn)
            da20 = New SqlDataAdapter()
            cmd20.CommandText = sql20
            cmd20.CommandTimeout = 900
            da20.SelectCommand = cmd20
            dt20 = New DataTable()
            da20.Fill(dt20)
            If dt20.Rows.Count > 0 Then
                lblSendToQCChecklpf.Text = Val(dt20.Rows(0)("sendto_qc").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql21 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd21 As New SqlClient.SqlCommand(sql21, cnn)
            da21 = New SqlDataAdapter()
            cmd21.CommandText = sql21
            cmd21.CommandTimeout = 900
            da21.SelectCommand = cmd21
            dt21 = New DataTable()
            da21.Fill(dt21)
            If dt21.Rows.Count > 0 Then
                lblSendToBillinglpf.Text = Val(dt21.Rows(0)("sendto_billing").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If


            sql22 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd22 As New SqlClient.SqlCommand(sql22, cnn)
            da22 = New SqlDataAdapter()
            cmd22.CommandText = sql22
            cmd22.CommandTimeout = 900
            da22.SelectCommand = cmd22
            dt22 = New DataTable()
            da22.Fill(dt22)
            If dt22.Rows.Count > 0 Then
                lblSendToDispatchlpf.Text = Val(dt22.Rows(0)("sendto_dispatch").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If

            sql23 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd23 As New SqlClient.SqlCommand(sql23, cnn)
            da23 = New SqlDataAdapter()
            cmd23.CommandText = sql23
            cmd23.CommandTimeout = 900
            da23.SelectCommand = cmd23
            dt23 = New DataTable()
            da23.Fill(dt23)
            If dt23.Rows.Count > 0 Then
                lblDispatchedJobslpf.Text = Val(dt23.Rows(0)("dispatched_jobs").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If

            sql24 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd24 As New SqlClient.SqlCommand(sql24, cnn)
            da24 = New SqlDataAdapter()
            cmd24.CommandText = sql24
            cmd24.CommandTimeout = 900
            da24.SelectCommand = cmd24
            dt24 = New DataTable()
            da24.Fill(dt24)
            If dt24.Rows.Count > 0 Then
                lblCancelledJobslpf.Text = Val(dt24.Rows(0)("cancelled_jobs").ToString).ToString("N", New CultureInfo("hi-IN"))
            End If



            'sql5 = "Dashboard_Domestic_Revenue_sp   "
            'dt5 = objDas.GetDataTable(sql5)
            'If dt5.Rows.Count > 0 Then
            '    'lblgoalsheet.Text = Val(dt5.Rows(0)("qty").ToString).ToString("N", New CultureInfo("hi-IN"))
            '    lblleave.Text = Val(dt5.Rows(0)("revenue").ToString).ToString("N", New CultureInfo("hi-IN"))
            'End If

            'sql5 = "Dashboard_Export_Revenue_sp    "
            'dt5 = objDas.GetDataTable(sql5)
            'If dt5.Rows.Count > 0 Then
            '    'lblconfirm_app.Text = Val(dt5.Rows(0)("qty").ToString).ToString("N", New CultureInfo("hi-IN"))
            '    lblconfirm_pro.Text = Val(dt5.Rows(0)("revenue").ToString).ToString("N", New CultureInfo("hi-IN"))
            'End If


            'DBAccess.Find_company()
            'Dim finStart, FinEnd, DocDate As DateTime
            'finStart = DBAccess.FinStart

            'sql5 = "Dashboard_Pending_Order_Domestic_sp '" & finStart & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','','','DOMESTIC',''   "
            'dt5 = objDas.GetDataTable(sql5)
            'If dt5.Rows.Count > 0 Then
            '    'Label1.Text = Val(dt5.Rows(0)("balqty").ToString).ToString("N", New CultureInfo("hi-IN"))
            '    Label2.Text = Val(dt5.Rows(0)("balvalue").ToString).ToString("N", New CultureInfo("hi-IN"))
            'End If


            'sql5 = "Dashboard_Pending_Order_Export_sp '" & finStart & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','','','EXPORT',''  "
            'dt5 = objDas.GetDataTable(sql5)
            'If dt5.Rows.Count > 0 Then
            '    'Label3.Text = Val(dt5.Rows(0)("balqty").ToString).ToString("N", New CultureInfo("hi-IN"))
            '    Label4.Text = Val(dt5.Rows(0)("balvalue").ToString).ToString("N", New CultureInfo("hi-IN"))
            'End If


            'sql5 = "Dashboard_Advance_License_Summary_sp 'E'   "
            'dt5 = objDas.GetDataTable(sql5)
            'If dt5.Rows.Count > 0 Then
            '    Label5.Text = Trim(dt5.Rows(0)("advlicno1").ToString)
            '    Label6.Text = Trim(dt5.Rows(0)("tobexport1").ToString)
            'Else
            '    Label5.Text = ""
            '    Label6.Text = ""
            'End If


            'sql5 = "Dashboard_Advance_License_Summary_sp 'E'   "
            'dt5 = objDas.GetDataTable(sql5)
            'If dt5.Rows.Count > 0 Then
            '    Label7.Text = Trim(dt5.Rows(0)("advlicno2").ToString)
            '    Label8.Text = Trim(dt5.Rows(0)("tobexport2").ToString)
            'Else
            '    Label7.Text = ""
            '    Label8.Text = ""
            'End If


            'sql5 = "Dashboard_Advance_License_Summary_sp 'E'   "
            'dt5 = objDas.GetDataTable(sql5)
            'If dt5.Rows.Count > 0 Then
            '    Label1.Text = Trim(dt5.Rows(0)("advlicno3").ToString)
            '    Label3.Text = Trim(dt5.Rows(0)("tobexport3").ToString)
            'Else
            '    Label1.Text = ""
            '    Label3.Text = ""
            'End If









        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert('" & (ex.Message).Replace("'", "") & "');", True)
            Exit Sub
        End Try
    End Sub





End Class

Public Class CLSDashboard
    Private m_leadname As String
    Private m_leadval As Integer
    Private m_telname As String
    Private m_telval As Integer

    Private m_NewLeadname As String
    Private m_NewLeadval As Integer

    Private m_Appbooked As Integer
    Private m_AppCancelled As Integer
    Private m_Apprechs As Integer
    Private m_Meeting As Integer
    Private m_Prospects As Integer
    Private m_Statusname As String

    Private m_membertype As String
    Private m_membercount As Integer
    Private m_memberDays As Decimal

    Private m_Selltype As String
    Private m_SellCount As Integer

    Public Property Selltype() As String
        Get
            Return m_Selltype
        End Get
        Set(ByVal value As String)
            m_Selltype = value
        End Set
    End Property

    Public Property SellCount() As Integer
        Get
            Return m_SellCount
        End Get
        Set(ByVal value As Integer)
            m_SellCount = value
        End Set
    End Property

    Public Property membertype() As String
        Get
            Return m_membertype
        End Get
        Set(ByVal value As String)
            m_membertype = value
        End Set
    End Property

    Public Property membercount() As Integer
        Get
            Return m_membercount
        End Get
        Set(ByVal value As Integer)
            m_membercount = value
        End Set
    End Property

    Public Property memberDays() As Decimal
        Get
            Return m_memberDays
        End Get
        Set(ByVal value As Decimal)
            m_memberDays = value
        End Set
    End Property

    Public Property Statusname() As String
        Get
            Return m_Statusname
        End Get
        Set(ByVal value As String)
            m_Statusname = value
        End Set
    End Property

    Public Property Apprechs() As Integer
        Get
            Return m_Apprechs
        End Get
        Set(ByVal value As Integer)
            m_Apprechs = value
        End Set
    End Property

    Public Property Appbooked() As Integer
        Get
            Return m_Appbooked
        End Get
        Set(ByVal value As Integer)
            m_Appbooked = value
        End Set
    End Property

    Public Property AppCancelled() As Integer
        Get
            Return m_AppCancelled
        End Get
        Set(ByVal value As Integer)
            m_AppCancelled = value
        End Set
    End Property

    Public Property Meeting() As Integer
        Get
            Return m_Meeting
        End Get
        Set(ByVal value As Integer)
            m_Meeting = value
        End Set
    End Property

    Public Property Prospects() As Integer
        Get
            Return m_Prospects
        End Get
        Set(ByVal value As Integer)
            m_Prospects = value
        End Set
    End Property

    Public Property leadname() As String
        Get
            Return m_leadname
        End Get
        Set(ByVal value As String)
            m_leadname = value
        End Set
    End Property
    Public Property leadval() As Integer
        Get
            Return m_leadval
        End Get
        Set(ByVal value As Integer)
            m_leadval = value
        End Set
    End Property

    Public Property telname() As String
        Get
            Return m_telname
        End Get
        Set(ByVal value As String)
            m_telname = value
        End Set
    End Property
    Public Property telval() As Integer
        Get
            Return m_telval
        End Get
        Set(ByVal value As Integer)
            m_telval = value
        End Set
    End Property


    Public Property NewLeadname() As String
        Get
            Return m_NewLeadname
        End Get
        Set(ByVal value As String)
            m_NewLeadname = value
        End Set
    End Property
    Public Property NewLeadval() As Integer
        Get
            Return m_NewLeadval
        End Get
        Set(ByVal value As Integer)
            m_NewLeadval = value
        End Set
    End Property

End Class
