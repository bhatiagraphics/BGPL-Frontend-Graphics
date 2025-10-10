
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

        txtFromDate.Text = 1 & "/" & Date.Now.Month & "/" & Date.Now.Year
        txtToDate.Text = (Format(Now.Date, "dd/MM/yyyy"))
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
        Dim dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9, dt10, dt11, dt12, dt13, dt14, dt15, dt16, dt17, dt18, dt19, dt20, dt21, dt22, dt23, dt24, dt49, dt50 As DataTable
        Dim dt25, dt26, dt27, dt28, dt29, dt30, dt31, dt32, dt33, dt34, dt35, dt36, dt37, dt38, dt39, dt40, dt41, dt42, dt43, dt44, dt45, dt46, dt47, dt48, dt51, dt52 As DataTable
        Dim da1, da2, da3, da4, da5, da6, da7, da8, da9, da10, da11, da12, da13, da14, da15, da16, da17, da18, da19, da20, da21, da22, da23, da24, da49, da50 As SqlDataAdapter
        Dim da25, da26, da27, da28, da29, da30, da31, da32, da33, da34, da35, da36, da37, da38, da39, da40, da41, da42, da43, da44, da45, da46, da47, da48, da51, da52 As SqlDataAdapter

        Dim cnn As New SqlConnection()
        Dim objConnectionStringSettings As ConnectionStringSettings
        objConnectionStringSettings = ConfigurationManager.ConnectionStrings("ConStr")
        Dim sCon As String = ""
        sCon = objConnectionStringSettings.ConnectionString
        Dim objDas As New DBAccess
        Try
            cnn.ConnectionString = sCon
            Dim strfromdt, strtodt, strloccd, strpccd, strempcd, strsourcecd, struserid As String

            Dim sql1, sql2, sql3, sql4, sql5, sql6, sql7, sql8, sql9, sql10, sql11, sql12, sql13, sql14, sql15, sql16, sql17, sql18, sql19, sql20, sql21, sql22, sql23, sql24, sql49, sql50 As String
            Dim sql25, sql26, sql27, sql28, sql29, sql30, sql31, sql32, sql33, sql34, sql35, sql36, sql37, sql38, sql39, sql40, sql41, sql42, sql43, sql44, sql45, sql46, sql47, sql48, sql51, sql52 As String
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
                lblTotalJobs.Text = Val(dt1.Rows(0)("tot_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))

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
                lblPendingJobs.Text = Val(dt2.Rows(0)("pending_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToGraphics.Text = Val(dt3.Rows(0)("sendto_graphichs").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToCustomer.Text = Val(dt4.Rows(0)("sendto_customer").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendTOCustomerForApproval.Text = Val(dt5.Rows(0)("sendto_customer_approval").ToString).ToString("N0", New CultureInfo("hi-IN"))

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
                lblSendToPrepress.Text = Val(dt6.Rows(0)("sendto_prepress").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql7 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd7 As New SqlClient.SqlCommand(sql7, cnn)
            da7 = New SqlDataAdapter()
            cmd7.CommandText = sql7
            cmd7.CommandTimeout = 900
            da7.SelectCommand = cmd7
            dt7 = New DataTable()
            da7.Fill(dt7)
            If dt7.Rows.Count > 0 Then
                lblSendToMaterialProduction.Text = Val(dt7.Rows(0)("sendto_materialprod").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToQCCheck.Text = Val(dt8.Rows(0)("sendto_qc").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToChallan.Text = Val(dt9.Rows(0)("sendto_challan").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToDispatch.Text = Val(dt10.Rows(0)("sendto_dispatch").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToBilling.Text = Val(dt11.Rows(0)("sendto_billing").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                Label1.Text = Val(dt12.Rows(0)("billingdone_jobclose").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If

            sql49 = "exec Dashboard_dryoffset_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd49 As New SqlClient.SqlCommand(sql49, cnn)
            da49 = New SqlDataAdapter()
            cmd49.CommandText = sql49
            cmd49.CommandTimeout = 900
            da49.SelectCommand = cmd49
            dt49 = New DataTable()
            da49.Fill(dt49)
            If dt49.Rows.Count > 0 Then
                lblCancelledJobs.Text = Val(dt49.Rows(0)("cancelled_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            '---------------------------------DryOffSet Monthly----------------------------------

            sql25 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd25 As New SqlClient.SqlCommand(sql25, cnn)
            da25 = New SqlDataAdapter()
            cmd25.CommandText = sql25
            cmd25.CommandTimeout = 900
            da25.SelectCommand = cmd25
            dt25 = New DataTable()
            da25.Fill(dt25)
            If dt25.Rows.Count > 0 Then
                lblMTotalJobs.Text = Val(dt25.Rows(0)("tot_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))

            End If

            sql26 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd26 As New SqlClient.SqlCommand(sql26, cnn)
            da26 = New SqlDataAdapter()
            cmd26.CommandText = sql26
            cmd26.CommandTimeout = 900
            da26.SelectCommand = cmd26
            dt26 = New DataTable()
            da26.Fill(dt26)
            If dt26.Rows.Count > 0 Then
                lblMPendingJobs.Text = Val(dt26.Rows(0)("pending_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql27 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd27 As New SqlClient.SqlCommand(sql27, cnn)
            da27 = New SqlDataAdapter()
            cmd27.CommandText = sql27
            cmd27.CommandTimeout = 900
            da27.SelectCommand = cmd27
            dt27 = New DataTable()
            da27.Fill(dt27)
            If dt27.Rows.Count > 0 Then
                lblMSendToGraphics.Text = Val(dt27.Rows(0)("sendto_graphichs").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql28 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd28 As New SqlClient.SqlCommand(sql28, cnn)
            da28 = New SqlDataAdapter()
            cmd28.CommandText = sql28
            cmd28.CommandTimeout = 900
            da28.SelectCommand = cmd28
            dt28 = New DataTable()
            da28.Fill(dt28)
            If dt28.Rows.Count > 0 Then
                lblMSendToCustomer.Text = Val(dt28.Rows(0)("sendto_customer").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql29 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd29 As New SqlClient.SqlCommand(sql29, cnn)
            da29 = New SqlDataAdapter()
            cmd29.CommandText = sql29
            cmd29.CommandTimeout = 900
            da29.SelectCommand = cmd29
            dt29 = New DataTable()
            da29.Fill(dt29)
            If dt29.Rows.Count > 0 Then
                lblMSendTOCustomerForApproval.Text = Val(dt29.Rows(0)("sendto_customer_approval").ToString).ToString("N0", New CultureInfo("hi-IN"))

            End If



            sql30 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd30 As New SqlClient.SqlCommand(sql30, cnn)
            da30 = New SqlDataAdapter()
            cmd30.CommandText = sql30
            cmd30.CommandTimeout = 900
            da30.SelectCommand = cmd30
            dt30 = New DataTable()
            da30.Fill(dt30)
            If dt30.Rows.Count > 0 Then
                lblMSendToPrepress.Text = Val(dt30.Rows(0)("sendto_prepress").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql31 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd31 As New SqlClient.SqlCommand(sql31, cnn)
            da31 = New SqlDataAdapter()
            cmd31.CommandText = sql31
            cmd31.CommandTimeout = 900
            da31.SelectCommand = cmd31
            dt31 = New DataTable()
            da31.Fill(dt31)
            If dt31.Rows.Count > 0 Then
                lblMSendToMaterialProduction.Text = Val(dt31.Rows(0)("sendto_materialprod").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If

            sql32 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd32 As New SqlClient.SqlCommand(sql32, cnn)
            da32 = New SqlDataAdapter()
            cmd32.CommandText = sql32
            cmd32.CommandTimeout = 900
            da32.SelectCommand = cmd32
            dt32 = New DataTable()
            da32.Fill(dt32)
            If dt32.Rows.Count > 0 Then
                lblMSendToQCCheck.Text = Val(dt32.Rows(0)("sendto_qc").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql33 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd33 As New SqlClient.SqlCommand(sql33, cnn)
            da33 = New SqlDataAdapter()
            cmd33.CommandText = sql33
            cmd33.CommandTimeout = 900
            da33.SelectCommand = cmd33
            dt33 = New DataTable()
            da33.Fill(dt33)
            If dt33.Rows.Count > 0 Then
                lblMSendToChallan.Text = Val(dt33.Rows(0)("sendto_challan").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql34 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd34 As New SqlClient.SqlCommand(sql34, cnn)
            da34 = New SqlDataAdapter()
            cmd34.CommandText = sql34
            cmd34.CommandTimeout = 900
            da34.SelectCommand = cmd34
            dt34 = New DataTable()
            da34.Fill(dt34)
            If dt34.Rows.Count > 0 Then
                lblMSendToDispatch.Text = Val(dt34.Rows(0)("sendto_dispatch").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If

            sql35 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd35 As New SqlClient.SqlCommand(sql35, cnn)
            da35 = New SqlDataAdapter()
            cmd35.CommandText = sql35
            cmd35.CommandTimeout = 900
            da35.SelectCommand = cmd35
            dt35 = New DataTable()
            da35.Fill(dt35)
            If dt35.Rows.Count > 0 Then
                lblMSendToBilling.Text = Val(dt35.Rows(0)("sendto_billing").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If

            sql50 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd50 As New SqlClient.SqlCommand(sql50, cnn)
            da50 = New SqlDataAdapter()
            cmd50.CommandText = sql50
            cmd50.CommandTimeout = 900
            da50.SelectCommand = cmd50
            dt50 = New DataTable()
            da50.Fill(dt50)
            If dt50.Rows.Count > 0 Then
                Label2.Text = Val(dt50.Rows(0)("billingdone_jobclose").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If

            sql36 = "exec Dashboard_dryoffset_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','1'"
            Dim cmd36 As New SqlClient.SqlCommand(sql36, cnn)
            da36 = New SqlDataAdapter()
            cmd36.CommandText = sql36
            cmd36.CommandTimeout = 900
            da36.SelectCommand = cmd36
            dt36 = New DataTable()
            da36.Fill(dt36)
            If dt36.Rows.Count > 0 Then
                lblMCancelledJobs.Text = Val(dt36.Rows(0)("cancelled_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblTotalJobslpf.Text = Val(dt13.Rows(0)("tot_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))

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
                lblPendingJobslpf.Text = Val(dt14.Rows(0)("pending_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToGraphicslpf.Text = Val(dt15.Rows(0)("sendto_graphichs").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToCustomerlpf.Text = Val(dt16.Rows(0)("sendto_customer").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendTOCustomerForApprovallpf.Text = Val(dt17.Rows(0)("sendto_customer_approval").ToString).ToString("N0", New CultureInfo("hi-IN"))

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
                lblSendToPrepresslpf.Text = Val(dt18.Rows(0)("sendto_prepress").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToMaterialProductionlpf.Text = Val(dt19.Rows(0)("sendto_materialprod").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToQCChecklpf.Text = Val(dt20.Rows(0)("sendto_qc").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToChallanlpf.Text = Val(dt21.Rows(0)("sendto_challan").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToDispatchlpf.Text = Val(dt22.Rows(0)("sendto_dispatch").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblSendToBillinglpf.Text = Val(dt23.Rows(0)("sendto_billing").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql51 = "exec Dashboard_letterflexo_sp '" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd51 As New SqlClient.SqlCommand(sql51, cnn)
            da51 = New SqlDataAdapter()
            cmd51.CommandText = sql51
            cmd51.CommandTimeout = 900
            da51.SelectCommand = cmd51
            dt51 = New DataTable()
            da51.Fill(dt51)
            If dt51.Rows.Count > 0 Then
                Label3.Text = Val(dt51.Rows(0)("billingdone_jobclose").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
                lblCancelledJobslpf.Text = Val(dt24.Rows(0)("cancelled_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If




            '----------------------------------letterflexo Monthly---------------------------------------

            sql37 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd37 As New SqlClient.SqlCommand(sql37, cnn)
            da37 = New SqlDataAdapter()
            cmd37.CommandText = sql37
            cmd37.CommandTimeout = 900
            da37.SelectCommand = cmd37
            dt37 = New DataTable()
            da37.Fill(dt37)
            If dt37.Rows.Count > 0 Then
                lblMTotalJobslpf.Text = Val(dt37.Rows(0)("tot_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))

            End If

            sql38 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd38 As New SqlClient.SqlCommand(sql38, cnn)
            da38 = New SqlDataAdapter()
            cmd38.CommandText = sql38
            cmd38.CommandTimeout = 900
            da38.SelectCommand = cmd38
            dt38 = New DataTable()
            da38.Fill(dt38)
            If dt38.Rows.Count > 0 Then
                lblMPendingJobslpf.Text = Val(dt38.Rows(0)("pending_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql39 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd39 As New SqlClient.SqlCommand(sql39, cnn)
            da39 = New SqlDataAdapter()
            cmd39.CommandText = sql39
            cmd39.CommandTimeout = 900
            da39.SelectCommand = cmd39
            dt39 = New DataTable()
            da39.Fill(dt39)
            If dt39.Rows.Count > 0 Then
                lblMSendToGraphicslpf.Text = Val(dt39.Rows(0)("sendto_graphichs").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql40 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd40 As New SqlClient.SqlCommand(sql40, cnn)
            da40 = New SqlDataAdapter()
            cmd40.CommandText = sql40
            cmd40.CommandTimeout = 900
            da40.SelectCommand = cmd40
            dt40 = New DataTable()
            da40.Fill(dt40)
            If dt40.Rows.Count > 0 Then
                lblMSendToCustomerlpf.Text = Val(dt40.Rows(0)("sendto_customer").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql41 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd41 As New SqlClient.SqlCommand(sql41, cnn)
            da41 = New SqlDataAdapter()
            cmd41.CommandText = sql41
            cmd41.CommandTimeout = 900
            da41.SelectCommand = cmd41
            dt41 = New DataTable()
            da41.Fill(dt41)
            If dt41.Rows.Count > 0 Then
                lblMSendTOCustomerForApprovallpf.Text = Val(dt41.Rows(0)("sendto_customer_approval").ToString).ToString("N0", New CultureInfo("hi-IN"))

            End If

            sql42 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd42 As New SqlClient.SqlCommand(sql42, cnn)
            da42 = New SqlDataAdapter()
            cmd42.CommandText = sql42
            cmd42.CommandTimeout = 900
            da42.SelectCommand = cmd42
            dt42 = New DataTable()
            da42.Fill(dt42)
            If dt42.Rows.Count > 0 Then
                lblMSendToPrepresslpf.Text = Val(dt42.Rows(0)("sendto_prepress").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql43 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd43 As New SqlClient.SqlCommand(sql43, cnn)
            da43 = New SqlDataAdapter()
            cmd43.CommandText = sql43
            cmd43.CommandTimeout = 900
            da43.SelectCommand = cmd43
            dt43 = New DataTable()
            da43.Fill(dt43)
            If dt43.Rows.Count > 0 Then
                lblMSendToMaterialProductionlpf.Text = Val(dt43.Rows(0)("sendto_materialprod").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If

            sql44 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd44 As New SqlClient.SqlCommand(sql44, cnn)
            da44 = New SqlDataAdapter()
            cmd44.CommandText = sql44
            cmd44.CommandTimeout = 900
            da44.SelectCommand = cmd44
            dt44 = New DataTable()
            da44.Fill(dt44)
            If dt44.Rows.Count > 0 Then
                lblMSendToQCChecklpf.Text = Val(dt44.Rows(0)("sendto_qc").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql45 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd45 As New SqlClient.SqlCommand(sql45, cnn)
            da45 = New SqlDataAdapter()
            cmd45.CommandText = sql45
            cmd45.CommandTimeout = 900
            da45.SelectCommand = cmd45
            dt45 = New DataTable()
            da45.Fill(dt45)
            If dt45.Rows.Count > 0 Then
                lblMSendToChallanlpf.Text = Val(dt45.Rows(0)("sendto_challan").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If


            sql46 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd46 As New SqlClient.SqlCommand(sql46, cnn)
            da46 = New SqlDataAdapter()
            cmd46.CommandText = sql46
            cmd46.CommandTimeout = 900
            da46.SelectCommand = cmd46
            dt46 = New DataTable()
            da46.Fill(dt46)
            If dt46.Rows.Count > 0 Then
                lblMSendToDispatchlpf.Text = Val(dt46.Rows(0)("sendto_dispatch").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If

            sql47 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd47 As New SqlClient.SqlCommand(sql47, cnn)
            da47 = New SqlDataAdapter()
            cmd47.CommandText = sql47
            cmd47.CommandTimeout = 900
            da47.SelectCommand = cmd47
            dt47 = New DataTable()
            da47.Fill(dt47)
            If dt47.Rows.Count > 0 Then
                lblMSendToBillinglpf.Text = Val(dt47.Rows(0)("sendto_billing").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If

            sql52 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd52 As New SqlClient.SqlCommand(sql52, cnn)
            da52 = New SqlDataAdapter()
            cmd52.CommandText = sql52
            cmd52.CommandTimeout = 900
            da52.SelectCommand = cmd52
            dt52 = New DataTable()
            da52.Fill(dt52)
            If dt52.Rows.Count > 0 Then
                Label4.Text = Val(dt52.Rows(0)("billingdone_jobclose").ToString).ToString("N0", New CultureInfo("hi-IN"))
            End If

            sql48 = "exec Dashboard_letterflexo_monthly_sp '" & Trim(txtFromDate.Text) & "','" & Trim(txtToDate.Text) & "','" & Trim(Session.Item("UserID")) & "','2'"
            Dim cmd48 As New SqlClient.SqlCommand(sql48, cnn)
            da48 = New SqlDataAdapter()
            cmd48.CommandText = sql48
            cmd48.CommandTimeout = 900
            da48.SelectCommand = cmd48
            dt48 = New DataTable()
            da48.Fill(dt48)
            If dt48.Rows.Count > 0 Then
                lblMCancelledJobslpf.Text = Val(dt48.Rows(0)("cancelled_jobs").ToString).ToString("N0", New CultureInfo("hi-IN"))
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
