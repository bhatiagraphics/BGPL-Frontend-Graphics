Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Partial Class JobEntry
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
    Public Shared AllowOrNotAuth As String


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

    Private Sub Fillcombo()
        Try
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            sSQL = "select ltrim(rtrim(printcd))as printcd,ltrim(rtrim(printname))as printname from printing order by printname"
            dt1 = objDas.GetDataTable(sSQL)
            dt1.Rows.InsertAt(dt1.NewRow, 0)
            ddlprintcd.DataSource = dt1
            ddlprintcd.DataTextField = "printname"
            ddlprintcd.DataValueField = "printcd"
            ddlprintcd.DataBind()


            sSQL = "select ltrim(rtrim(cuscode))as cuscode,ltrim(rtrim(cusname))as cusname from customer order by cusname"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlcuscode.DataSource = dt3
            ddlcuscode.DataTextField = "cusname"
            ddlcuscode.DataValueField = "cuscode"
            ddlcuscode.DataBind()

            sSQL = "select ltrim(rtrim(u_id))as u_id,ltrim(rtrim(u_name))as u_name from users order by u_name"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlassignedto.DataSource = dt3
            ddlassignedto.DataTextField = "u_name"
            ddlassignedto.DataValueField = "u_id"
            ddlassignedto.DataBind()

            sSQL = "select ltrim(rtrim(jobid))as jobid from jobentry  where isnull(cancelflag,0)=0 order by jobid"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlRecallJobId.DataSource = dt3
            ddlRecallJobId.DataTextField = "jobid"
            ddlRecallJobId.DataValueField = "jobid"
            ddlRecallJobId.DataBind()


        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Private Sub Refresh()
        ErrorMSG.Text = ""
        ErrorMSG.Visible = False
        'ddlgetype.Text = ""
        'txtgeno.Text = ""
        txtjobcreatedt.Text = Date.Now()
        'HFsuppcd.Value = ""
        ddlprioirty.Text = ""
        txtjobname.Text = ""
        ddlprintcd.Text = ""
        ddlcuscode.Text = ""
        txtintcode.Text = ""
        txtrevno.Text = ""
        ddlassignedto.Text = ""
        txtticketno.Text = ""



    End Sub

    Protected Sub New_Docno()
        Try
            j = clsJobEntry.Fetch_Paramno("")
            txtjobid.Text = clsJobEntry.Generate_Docno(j, "", "").ToString.Trim
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Private Sub Set_UserAccessRights()
        Try
            'AllowOrNotAuth = ""
            'Dim c As New DBAccess.Accessbuttons
            'c = DBAccess.Accessright(Trim(Session.Item("UserID")), Trim(Request.QueryString("mainid")))

            'If mode = "Add" Then
            '    btncancel.Visible = False

            'Else
            '    If c.allow_del = True Then
            '        btncancel.Visible = True
            '    Else
            '        btncancel.Visible = False
            '    End If
            '    'If c.allow_san = True Then
            '    '    btnAuthorize.Visible = True
            '    '    btnUnAuthorize.Visible = True
            '    '    AllowOrNotAuth = "Yes"
            '    'Else
            '    '    btnAuthorize.Visible = False
            '    '    btnUnAuthorize.Visible = False
            '    '    AllowOrNotAuth = "No"
            '    'End If
            '    'If c.allow_prev = True Then
            '    '    btnPreview.Visible = True
            '    'Else
            '    '    btnPreview.Visible = False
            '    'End If
            'End If

            'If mode = "Add" Then
            '    If c.allow_add = True Then
            '        btnSave.Visible = True
            '    Else
            '        btnSave.Visible = False
            '    End If
            'End If

            'If mode <> "Add" Then
            '    If c.allow_mod = True Then
            '        btnSave.Visible = True
            '    Else
            '        btnSave.Visible = False
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Session("UserName") Is Nothing) Then
                Response.Redirect("~/SessionExpired.aspx")
            End If
            If Not IsPostBack Then
                Fillcombo()
                ErrorMSG.Text = ""
                If Trim(Request.QueryString("docno")) = "" Then

                    mode = "Add"
                    Refresh()
                    btncancel.Enabled = False
                    btnSendToGrphics.Enabled = False
                    btnsendtopress.Enabled = False
                    btnRevoke.Enabled = False
                    btnAmendment.Enabled = False
                    txtjobcreatedt.Focus()

                    lblLog.Visible = False
                    gv1.Visible = False
                Else
                    mode = "Modify"
                    txtjobid.Text = Trim(Request.QueryString("docno"))
                    DisplayData(txtjobid.Text)
                    txtjobcreatedt.Focus()
                End If
                Set_UserAccessRights()


            End If
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub
    Private Function Check_GeUse(ByVal geno As String) As String
        Check_GeUse = ""
        Dim sSQL1 As String, dt1 As DataTable, objDas As New DBAccess
        sSQL1 = "select geno from grnhead Where geno = '" & Trim(geno) & "'"
        dt1 = objDas.GetDataTable(sSQL1)
        If dt1.Rows.Count > 0 Then
            Check_GeUse = "Use"
        Else
            Check_GeUse = ""
        End If
    End Function

    Private Function Check_Administrator(ByVal u_id As String) As Boolean
        Check_Administrator = False
        Dim sSQL As String, dt As DataTable, objDas As New DBAccess
        sSQL = "select administrator from users Where u_id = '" & Trim(u_id) & "'"
        dt = objDas.GetDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If Trim(dt.Rows(0)("administrator").ToString) = "1" Then
                Check_Administrator = True
            Else
                Check_Administrator = False
            End If
        End If
    End Function


    Private Sub DisplayData(ByVal geno As String)
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim ds As DataSet
        Dim dtdet As New DataTable
        con = clsJobEntry.GetConnection()
        com = clsJobEntry.GetCommand
        com.Connection = con
        com.CommandType = CommandType.Text
        Try
            Dim obj As clsJobEntry = clsJobEntry.FillData(geno, "B")
            If Not IsNothing(obj) Then
                txtjobid.Text = Trim(obj.jobid)
                hdnJobId.Value = Trim(obj.originaljobid)
                txtjobname.Text = Trim(obj.jobname)
                txtjobcreatedt.Text = Trim(obj.jobcreatedt)
                ddlprioirty.SelectedItem.Selected = False
                ddlprioirty.Items.FindByValue(Trim(obj.prioirty)).Selected = True
                ddlcuscode.SelectedItem.Selected = False
                ddlcuscode.Items.FindByValue(Trim(obj.cuscode)).Selected = True
                ddlprintcd.SelectedItem.Selected = False
                ddlprintcd.Items.FindByValue(Trim(obj.printcd)).Selected = True
                txtintcode.Text = Trim(obj.intcode)
                txtrevno.Text = Trim(obj.revno)
                ddlassignedto.SelectedItem.Selected = False
                ddlassignedto.Items.FindByValue(Trim(obj.assignedto)).Selected = True
                txtticketno.Text = Trim(obj.ticketno)
                Hfattachmentpath1.Value = Trim(obj.attachmentpath1)
                Hfattachmentname1.Value = Trim(obj.attachmentname1)
                Hfattachmentpath2.Value = Trim(obj.attachmentpath2)
                Hfattachmentname2.Value = Trim(obj.attachmentname2)
                Hfattachmentpath3.Value = Trim(obj.attachmentpath3)
                Hfattachmentname3.Value = Trim(obj.attachmentname3)
                Hfattachmentpath4.Value = Trim(obj.attachmentpath4)
                Hfattachmentname4.Value = Trim(obj.attachmentname4)
                Hfattachmentpath5.Value = Trim(obj.attachmentpath5)
                Hfattachmentname5.Value = Trim(obj.attachmentname5)
                Hfattachmentpath6.Value = Trim(obj.attachmentpath6)
                Hfattachmentname6.Value = Trim(obj.attachmentname6)
                Hfattachmentpath7.Value = Trim(obj.attachmentpath7)
                Hfattachmentname7.Value = Trim(obj.attachmentname7)
                Hfattachmentpath8.Value = Trim(obj.attachmentpath8)
                Hfattachmentname8.Value = Trim(obj.attachmentname8)
                Hfattachmentpath9.Value = Trim(obj.attachmentpath9)
                Hfattachmentname9.Value = Trim(obj.attachmentname9)
                Hfattachmentpath10.Value = Trim(obj.attachmentpath10)
                Hfattachmentname10.Value = Trim(obj.attachmentname10)

                txtLink1.Text = Trim(obj.link1)
                txtLink2.Text = Trim(obj.link2)
                txtLink3.Text = Trim(obj.link3)
                txtLink4.Text = Trim(obj.link4)
                txtLink5.Text = Trim(obj.link5)
                txtcustomerinstruction.Text = Trim(obj.customerinstruction)


                lblFileUpload1.Text = Trim(obj.attachment1filename)
                lblFileUpload2.Text = Trim(obj.attachment2filename)
                lblFileUpload3.Text = Trim(obj.attachment3filename)
                lblFileUpload4.Text = Trim(obj.attachment4filename)
                lblFileUpload5.Text = Trim(obj.attachment5filename)
                lblFileUpload6.Text = Trim(obj.attachment6filename)
                lblFileUpload7.Text = Trim(obj.attachment7filename)
                lblFileUpload8.Text = Trim(obj.attachment8filename)
                lblFileUpload9.Text = Trim(obj.attachment9filename)
                lblFileUpload10.Text = Trim(obj.attachment10filename)

                txtcancelremark.Text = Trim(obj.cancelremark)


                If Trim(obj.cancelflag) = "1" Then
                    btncancel.Visible = False
                    btnSendToGrphics.Visible = False
                    btnsendtopress.Visible = False
                    btnRevoke.Visible = False
                    btnSave.Visible = False
                    btnsave_SendtoGraphics.Visible = False
                    btnsave_SendtoPrepress.Visible = False

                End If

                If Trim(obj.dispatch_close_flag) = "1" Then
                    btncancel.Visible = False
                    btnSendToGrphics.Visible = False
                    btnsendtopress.Visible = False
                    btnSave.Visible = False
                    btnsave_SendtoGraphics.Visible = False
                    btnsave_SendtoPrepress.Visible = False
                    btnAmendment.Visible = True
                Else
                    btnAmendment.Visible = False
                End If

                If (Check_Administrator(Trim(Session.Item("UserID")).ToLower) = True OrElse Trim(Session.Item("UserID")).ToLower = "admin") Then
                    btnRevoke.Visible = True
                Else
                    btnRevoke.Visible = False
                End If

                FillData()

            End If
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        Finally
            con.Close()
            con = Nothing
        End Try
    End Sub

    Private Sub Save_Data_Add()
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim c As New clsJobEntry
        Dim i As Integer

        Dim ds As DataSet
        Dim dtdet As New DataTable
        Dim dr As DataRow

        con = clsJobEntry.GetConnection()
        com = clsJobEntry.GetCommand

        com.Connection = con
        com.CommandType = CommandType.Text

        Try
            Dim obj As New clsJobEntry, objDas As New DBAccess
            obj.jobid = Trim(txtjobid.Text)
            obj.jobcreatedt = objDas.FilteredString(txtjobcreatedt.Text)
            obj.startdate = DateTime.Now
            obj.starttime = DateTime.Now
            obj.jobname = Trim(txtjobname.Text)
            obj.prioirty = ddlprioirty.SelectedValue
            obj.printcd = ddlprintcd.SelectedValue
            obj.cuscode = ddlcuscode.SelectedValue
            obj.intcode = txtintcode.Text
            obj.revno = txtrevno.Text
            obj.assignedto = ddlassignedto.SelectedValue
            obj.ticketno = txtticketno.Text
            obj.originaljobid = Trim(txtjobid.Text)
            obj.jobversion = 0

            Dim attachmentname1, attachmentpath1 As String
            If FileUpload1.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
                attachmentname1 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath1 = ("Attachments\") + attachmentname1
                Dim FilePath As String = Server.MapPath(attachmentpath1)
                FileUpload1.PostedFile.SaveAs(FilePath)
                obj.attachment1filename = FileName + Extension
                obj.attachmentname1 = attachmentname1
                obj.attachmentpath1 = attachmentpath1
            Else
                obj.attachment1filename = Trim(lblFileUpload1.Text)
                obj.attachmentname1 = Trim(Hfattachmentname1.Value)
                obj.attachmentpath1 = Trim(Hfattachmentpath1.Value)
            End If


            Dim attachmentname2, attachmentpath2 As String
            If FileUpload2.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload2.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload2.PostedFile.FileName)
                attachmentname2 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath2 = ("Attachments\") + attachmentname2
                Dim FilePath As String = Server.MapPath(attachmentpath2)
                FileUpload2.PostedFile.SaveAs(FilePath)
                obj.attachment2filename = FileName + Extension
                obj.attachmentname2 = attachmentname2
                obj.attachmentpath2 = attachmentpath2
            Else
                obj.attachment2filename = Trim(lblFileUpload2.Text)
                obj.attachmentname2 = Trim(Hfattachmentname2.Value)
                obj.attachmentpath2 = Trim(Hfattachmentpath2.Value)
            End If


            Dim attachmentname3, attachmentpath3 As String
            If FileUpload3.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload3.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload3.PostedFile.FileName)
                attachmentname3 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath3 = ("Attachments\") + attachmentname3
                Dim FilePath As String = Server.MapPath(attachmentpath3)
                FileUpload3.PostedFile.SaveAs(FilePath)
                obj.attachment3filename = FileName + Extension
                obj.attachmentname3 = attachmentname3
                obj.attachmentpath3 = attachmentpath3
            Else
                obj.attachment3filename = Trim(lblFileUpload3.Text)
                obj.attachmentname3 = Trim(Hfattachmentname3.Value)
                obj.attachmentpath3 = Trim(Hfattachmentpath3.Value)
            End If


            Dim attachmentname4, attachmentpath4 As String
            If FileUpload4.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload4.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload4.PostedFile.FileName)
                attachmentname4 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath4 = ("Attachments\") + attachmentname4
                Dim FilePath As String = Server.MapPath(attachmentpath4)
                FileUpload4.PostedFile.SaveAs(FilePath)
                obj.attachment4filename = FileName + Extension
                obj.attachmentname4 = attachmentname4
                obj.attachmentpath4 = attachmentpath4
            Else
                obj.attachment4filename = Trim(lblFileUpload4.Text)
                obj.attachmentname4 = Trim(Hfattachmentname4.Value)
                obj.attachmentpath4 = Trim(Hfattachmentpath4.Value)
            End If

            Dim attachmentname5, attachmentpath5 As String
            If FileUpload5.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload5.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload5.PostedFile.FileName)
                attachmentname5 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath5 = ("Attachments\") + attachmentname5
                Dim FilePath As String = Server.MapPath(attachmentpath5)
                FileUpload5.PostedFile.SaveAs(FilePath)
                obj.attachment5filename = FileName + Extension
                obj.attachmentname5 = attachmentname5
                obj.attachmentpath5 = attachmentpath5
            Else
                obj.attachment5filename = Trim(lblFileUpload5.Text)
                obj.attachmentname5 = Trim(Hfattachmentname5.Value)
                obj.attachmentpath5 = Trim(Hfattachmentpath5.Value)
            End If

            Dim attachmentname6, attachmentpath6 As String
            If FileUpload6.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload6.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload6.PostedFile.FileName)
                attachmentname6 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath6 = ("Attachments\") + attachmentname6
                Dim FilePath As String = Server.MapPath(attachmentpath6)
                FileUpload6.PostedFile.SaveAs(FilePath)
                obj.attachment6filename = FileName + Extension
                obj.attachmentname6 = attachmentname6
                obj.attachmentpath6 = attachmentpath6
            Else
                obj.attachment6filename = Trim(lblFileUpload6.Text)
                obj.attachmentname6 = Trim(Hfattachmentname6.Value)
                obj.attachmentpath6 = Trim(Hfattachmentpath6.Value)
            End If


            Dim attachmentname7, attachmentpath7 As String
            If FileUpload7.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload7.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload7.PostedFile.FileName)
                attachmentname7 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath7 = ("Attachments\") + attachmentname7
                Dim FilePath As String = Server.MapPath(attachmentpath7)
                FileUpload7.PostedFile.SaveAs(FilePath)
                obj.attachment7filename = FileName + Extension
                obj.attachmentname7 = attachmentname7
                obj.attachmentpath7 = attachmentpath7
            Else
                obj.attachment7filename = Trim(lblFileUpload7.Text)
                obj.attachmentname7 = Trim(Hfattachmentname7.Value)
                obj.attachmentpath7 = Trim(Hfattachmentpath7.Value)
            End If



            Dim attachmentname8, attachmentpath8 As String
            If FileUpload8.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload8.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload8.PostedFile.FileName)
                attachmentname8 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath8 = ("Attachments\") + attachmentname8
                Dim FilePath As String = Server.MapPath(attachmentpath8)
                FileUpload8.PostedFile.SaveAs(FilePath)
                obj.attachment8filename = FileName + Extension
                obj.attachmentname8 = attachmentname8
                obj.attachmentpath8 = attachmentpath8
            Else
                obj.attachment8filename = Trim(lblFileUpload8.Text)
                obj.attachmentname8 = Trim(Hfattachmentname8.Value)
                obj.attachmentpath8 = Trim(Hfattachmentpath8.Value)
            End If

            Dim attachmentname9, attachmentpath9 As String
            If FileUpload9.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload9.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload9.PostedFile.FileName)
                attachmentname9 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath9 = ("Attachments\") + attachmentname9
                Dim FilePath As String = Server.MapPath(attachmentpath9)
                FileUpload9.PostedFile.SaveAs(FilePath)
                obj.attachment9filename = FileName + Extension
                obj.attachmentname9 = attachmentname9
                obj.attachmentpath9 = attachmentpath9
            Else
                obj.attachment9filename = Trim(lblFileUpload9.Text)
                obj.attachmentname9 = Trim(Hfattachmentname9.Value)
                obj.attachmentpath9 = Trim(Hfattachmentpath9.Value)
            End If

            Dim attachmentname10, attachmentpath10 As String
            If FileUpload10.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload10.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload10.PostedFile.FileName)
                attachmentname10 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath10 = ("Attachments\") + attachmentname10
                Dim FilePath As String = Server.MapPath(attachmentpath10)
                FileUpload10.PostedFile.SaveAs(FilePath)
                obj.attachment10filename = FileName + Extension
                obj.attachmentname10 = attachmentname10
                obj.attachmentpath10 = attachmentpath10
            Else
                obj.attachment10filename = Trim(lblFileUpload10.Text)
                obj.attachmentname10 = Trim(Hfattachmentname10.Value)
                obj.attachmentpath10 = Trim(Hfattachmentpath10.Value)
            End If

            obj.link1 = Trim(txtLink1.Text)
            obj.link2 = Trim(txtLink2.Text)
            obj.link3 = Trim(txtLink3.Text)
            obj.link4 = Trim(txtLink4.Text)
            obj.link5 = Trim(txtLink5.Text)
            obj.customerinstruction = Trim(txtcustomerinstruction.Text)



            obj.crtuserid = Trim(Session.Item("UserID"))
            obj.crtuserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.moduserid = Trim(Session.Item("UserID"))
            obj.moduserdt = (Format(Now.Date, "dd/MM/yyyy"))

            clsJobEntry.Update_Data_Add(obj, j, mode, "")

            If ErrorMSG.Text = "" Then
                HFsave_value.Value = ""
                Response.Write("<script>alert('Details Saved Succesfully " & Trim(txtjobid.Text) & "'); ")
                Response.Write("window.location='JobEntry.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")

            End If
            New_Docno()
            Call Refresh()
        Catch ex As Exception


            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        Finally
            con.Close()
            con = Nothing
        End Try
    End Sub

    Private Sub Save_Data_Edit()
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim c As New clsJobEntry
        Dim i As Integer

        Dim ds As DataSet
        Dim dtdet As New DataTable
        Dim dr As DataRow

        con = clsJobEntry.GetConnection()
        com = clsJobEntry.GetCommand

        com.Connection = con
        com.CommandType = CommandType.Text

        Try
            Dim obj As New clsJobEntry, objDas As New DBAccess
            obj.jobid = Trim(txtjobid.Text)
            obj.jobcreatedt = objDas.FilteredString(txtjobcreatedt.Text)
            obj.startdate = DateTime.Now
            obj.starttime = DateTime.Now
            obj.jobname = Trim(txtjobname.Text)
            obj.prioirty = ddlprioirty.SelectedValue
            obj.printcd = ddlprintcd.SelectedValue
            obj.cuscode = ddlcuscode.SelectedValue
            obj.intcode = txtintcode.Text
            obj.revno = txtrevno.Text
            obj.assignedto = ddlassignedto.SelectedValue
            obj.ticketno = txtticketno.Text
            obj.originaljobid = Trim(txtjobid.Text)
            obj.jobversion = 0

            Dim attachmentname1, attachmentpath1 As String
            If FileUpload1.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
                attachmentname1 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath1 = ("Attachments\") + attachmentname1
                Dim FilePath As String = Server.MapPath(attachmentpath1)
                FileUpload1.PostedFile.SaveAs(FilePath)
                obj.attachment1filename = FileName + Extension
                obj.attachmentname1 = attachmentname1
                obj.attachmentpath1 = attachmentpath1
            Else
                obj.attachment1filename = Trim(lblFileUpload1.Text)
                obj.attachmentname1 = Trim(Hfattachmentname1.Value)
                obj.attachmentpath1 = Trim(Hfattachmentpath1.Value)
            End If


            Dim attachmentname2, attachmentpath2 As String
            If FileUpload2.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload2.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload2.PostedFile.FileName)
                attachmentname2 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath2 = ("Attachments\") + attachmentname2
                Dim FilePath As String = Server.MapPath(attachmentpath2)
                FileUpload2.PostedFile.SaveAs(FilePath)
                obj.attachment2filename = FileName + Extension
                obj.attachmentname2 = attachmentname2
                obj.attachmentpath2 = attachmentpath2
            Else
                obj.attachment2filename = Trim(lblFileUpload2.Text)
                obj.attachmentname2 = Trim(Hfattachmentname2.Value)
                obj.attachmentpath2 = Trim(Hfattachmentpath2.Value)
            End If


            Dim attachmentname3, attachmentpath3 As String
            If FileUpload3.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload3.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload3.PostedFile.FileName)
                attachmentname3 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath3 = ("Attachments\") + attachmentname3
                Dim FilePath As String = Server.MapPath(attachmentpath3)
                FileUpload3.PostedFile.SaveAs(FilePath)
                obj.attachment3filename = FileName + Extension
                obj.attachmentname3 = attachmentname3
                obj.attachmentpath3 = attachmentpath3
            Else
                obj.attachment3filename = Trim(lblFileUpload3.Text)
                obj.attachmentname3 = Trim(Hfattachmentname3.Value)
                obj.attachmentpath3 = Trim(Hfattachmentpath3.Value)
            End If


            Dim attachmentname4, attachmentpath4 As String
            If FileUpload4.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload4.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload4.PostedFile.FileName)
                attachmentname4 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath4 = ("Attachments\") + attachmentname4
                Dim FilePath As String = Server.MapPath(attachmentpath4)
                FileUpload4.PostedFile.SaveAs(FilePath)
                obj.attachment4filename = FileName + Extension
                obj.attachmentname4 = attachmentname4
                obj.attachmentpath4 = attachmentpath4
            Else
                obj.attachment4filename = Trim(lblFileUpload4.Text)
                obj.attachmentname4 = Trim(Hfattachmentname4.Value)
                obj.attachmentpath4 = Trim(Hfattachmentpath4.Value)
            End If

            Dim attachmentname5, attachmentpath5 As String
            If FileUpload5.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload5.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload5.PostedFile.FileName)
                attachmentname5 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath5 = ("Attachments\") + attachmentname5
                Dim FilePath As String = Server.MapPath(attachmentpath5)
                FileUpload5.PostedFile.SaveAs(FilePath)
                obj.attachment5filename = FileName + Extension
                obj.attachmentname5 = attachmentname5
                obj.attachmentpath5 = attachmentpath5
            Else
                obj.attachment5filename = Trim(lblFileUpload5.Text)
                obj.attachmentname5 = Trim(Hfattachmentname5.Value)
                obj.attachmentpath5 = Trim(Hfattachmentpath5.Value)
            End If

            Dim attachmentname6, attachmentpath6 As String
            If FileUpload6.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload6.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload6.PostedFile.FileName)
                attachmentname6 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath6 = ("Attachments\") + attachmentname6
                Dim FilePath As String = Server.MapPath(attachmentpath6)
                FileUpload6.PostedFile.SaveAs(FilePath)
                obj.attachment6filename = FileName + Extension
                obj.attachmentname6 = attachmentname6
                obj.attachmentpath6 = attachmentpath6
            Else
                obj.attachment6filename = Trim(lblFileUpload6.Text)
                obj.attachmentname6 = Trim(Hfattachmentname6.Value)
                obj.attachmentpath6 = Trim(Hfattachmentpath6.Value)
            End If


            Dim attachmentname7, attachmentpath7 As String
            If FileUpload7.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload7.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload7.PostedFile.FileName)
                attachmentname7 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath7 = ("Attachments\") + attachmentname7
                Dim FilePath As String = Server.MapPath(attachmentpath7)
                FileUpload7.PostedFile.SaveAs(FilePath)
                obj.attachment7filename = FileName + Extension
                obj.attachmentname7 = attachmentname7
                obj.attachmentpath7 = attachmentpath7
            Else
                obj.attachment7filename = Trim(lblFileUpload7.Text)
                obj.attachmentname7 = Trim(Hfattachmentname7.Value)
                obj.attachmentpath7 = Trim(Hfattachmentpath7.Value)
            End If



            Dim attachmentname8, attachmentpath8 As String
            If FileUpload8.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload8.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload8.PostedFile.FileName)
                attachmentname8 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath8 = ("Attachments\") + attachmentname8
                Dim FilePath As String = Server.MapPath(attachmentpath8)
                FileUpload8.PostedFile.SaveAs(FilePath)
                obj.attachment8filename = FileName + Extension
                obj.attachmentname8 = attachmentname8
                obj.attachmentpath8 = attachmentpath8
            Else
                obj.attachment8filename = Trim(lblFileUpload8.Text)
                obj.attachmentname8 = Trim(Hfattachmentname8.Value)
                obj.attachmentpath8 = Trim(Hfattachmentpath8.Value)
            End If

            Dim attachmentname9, attachmentpath9 As String
            If FileUpload9.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload9.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload9.PostedFile.FileName)
                attachmentname9 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath9 = ("Attachments\") + attachmentname9
                Dim FilePath As String = Server.MapPath(attachmentpath9)
                FileUpload9.PostedFile.SaveAs(FilePath)
                obj.attachment9filename = FileName + Extension
                obj.attachmentname9 = attachmentname9
                obj.attachmentpath9 = attachmentpath9
            Else
                obj.attachment9filename = Trim(lblFileUpload9.Text)
                obj.attachmentname9 = Trim(Hfattachmentname9.Value)
                obj.attachmentpath9 = Trim(Hfattachmentpath9.Value)
            End If

            Dim attachmentname10, attachmentpath10 As String
            If FileUpload10.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload10.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload10.PostedFile.FileName)
                attachmentname10 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath10 = ("Attachments\") + attachmentname10
                Dim FilePath As String = Server.MapPath(attachmentpath10)
                FileUpload10.PostedFile.SaveAs(FilePath)
                obj.attachment10filename = FileName + Extension
                obj.attachmentname10 = attachmentname10
                obj.attachmentpath10 = attachmentpath10
            Else
                obj.attachment10filename = Trim(lblFileUpload10.Text)
                obj.attachmentname10 = Trim(Hfattachmentname10.Value)
                obj.attachmentpath10 = Trim(Hfattachmentpath10.Value)
            End If

            obj.link1 = Trim(txtLink1.Text)
            obj.link2 = Trim(txtLink2.Text)
            obj.link3 = Trim(txtLink3.Text)
            obj.link4 = Trim(txtLink4.Text)
            obj.link5 = Trim(txtLink5.Text)
            obj.customerinstruction = Trim(txtcustomerinstruction.Text)



            obj.crtuserid = Trim(Session.Item("UserID"))
            obj.crtuserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.moduserid = Trim(Session.Item("UserID"))
            obj.moduserdt = (Format(Now.Date, "dd/MM/yyyy"))

            clsJobEntry.Update_Data_Edit(obj, j, mode, "")
            If ErrorMSG.Text = "" Then
                Response.Write("<script>alert('Details Saved Succesfully'); ")
                Response.Write("window.location='JobEntrySearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
            End If
        Catch ex As Exception
            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        Finally
            con.Close()
            con = Nothing
        End Try
    End Sub

    Private Sub Save_Data_Add_Graphics()
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim c As New clsJobEntry
        Dim i As Integer

        Dim ds As DataSet
        Dim dtdet As New DataTable
        Dim dr As DataRow

        con = clsJobEntry.GetConnection()
        com = clsJobEntry.GetCommand

        com.Connection = con
        com.CommandType = CommandType.Text

        Try
            Dim obj As New clsJobEntry, objDas As New DBAccess
            obj.jobid = Trim(txtjobid.Text)
            obj.jobcreatedt = objDas.FilteredString(txtjobcreatedt.Text)
            obj.startdate = DateTime.Now
            obj.starttime = DateTime.Now
            obj.jobname = Trim(txtjobname.Text)
            obj.prioirty = ddlprioirty.SelectedValue
            obj.printcd = ddlprintcd.SelectedValue
            obj.cuscode = ddlcuscode.SelectedValue
            obj.intcode = txtintcode.Text
            obj.revno = txtrevno.Text
            obj.assignedto = ddlassignedto.SelectedValue
            obj.ticketno = txtticketno.Text
            obj.originaljobid = Trim(txtjobid.Text)
            obj.jobversion = 0

            Dim attachmentname1, attachmentpath1 As String
            If FileUpload1.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
                attachmentname1 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath1 = ("Attachments\") + attachmentname1
                Dim FilePath As String = Server.MapPath(attachmentpath1)
                FileUpload1.PostedFile.SaveAs(FilePath)
                obj.attachment1filename = FileName + Extension
                obj.attachmentname1 = attachmentname1
                obj.attachmentpath1 = attachmentpath1
            Else
                obj.attachment1filename = Trim(lblFileUpload1.Text)
                obj.attachmentname1 = Trim(Hfattachmentname1.Value)
                obj.attachmentpath1 = Trim(Hfattachmentpath1.Value)
            End If


            Dim attachmentname2, attachmentpath2 As String
            If FileUpload2.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload2.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload2.PostedFile.FileName)
                attachmentname2 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath2 = ("Attachments\") + attachmentname2
                Dim FilePath As String = Server.MapPath(attachmentpath2)
                FileUpload2.PostedFile.SaveAs(FilePath)
                obj.attachment2filename = FileName + Extension
                obj.attachmentname2 = attachmentname2
                obj.attachmentpath2 = attachmentpath2
            Else
                obj.attachment2filename = Trim(lblFileUpload2.Text)
                obj.attachmentname2 = Trim(Hfattachmentname2.Value)
                obj.attachmentpath2 = Trim(Hfattachmentpath2.Value)
            End If


            Dim attachmentname3, attachmentpath3 As String
            If FileUpload3.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload3.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload3.PostedFile.FileName)
                attachmentname3 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath3 = ("Attachments\") + attachmentname3
                Dim FilePath As String = Server.MapPath(attachmentpath3)
                FileUpload3.PostedFile.SaveAs(FilePath)
                obj.attachment3filename = FileName + Extension
                obj.attachmentname3 = attachmentname3
                obj.attachmentpath3 = attachmentpath3
            Else
                obj.attachment3filename = Trim(lblFileUpload3.Text)
                obj.attachmentname3 = Trim(Hfattachmentname3.Value)
                obj.attachmentpath3 = Trim(Hfattachmentpath3.Value)
            End If


            Dim attachmentname4, attachmentpath4 As String
            If FileUpload4.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload4.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload4.PostedFile.FileName)
                attachmentname4 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath4 = ("Attachments\") + attachmentname4
                Dim FilePath As String = Server.MapPath(attachmentpath4)
                FileUpload4.PostedFile.SaveAs(FilePath)
                obj.attachment4filename = FileName + Extension
                obj.attachmentname4 = attachmentname4
                obj.attachmentpath4 = attachmentpath4
            Else
                obj.attachment4filename = Trim(lblFileUpload4.Text)
                obj.attachmentname4 = Trim(Hfattachmentname4.Value)
                obj.attachmentpath4 = Trim(Hfattachmentpath4.Value)
            End If

            Dim attachmentname5, attachmentpath5 As String
            If FileUpload5.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload5.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload5.PostedFile.FileName)
                attachmentname5 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath5 = ("Attachments\") + attachmentname5
                Dim FilePath As String = Server.MapPath(attachmentpath5)
                FileUpload5.PostedFile.SaveAs(FilePath)
                obj.attachment5filename = FileName + Extension
                obj.attachmentname5 = attachmentname5
                obj.attachmentpath5 = attachmentpath5
            Else
                obj.attachment5filename = Trim(lblFileUpload5.Text)
                obj.attachmentname5 = Trim(Hfattachmentname5.Value)
                obj.attachmentpath5 = Trim(Hfattachmentpath5.Value)
            End If

            Dim attachmentname6, attachmentpath6 As String
            If FileUpload6.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload6.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload6.PostedFile.FileName)
                attachmentname6 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath6 = ("Attachments\") + attachmentname6
                Dim FilePath As String = Server.MapPath(attachmentpath6)
                FileUpload6.PostedFile.SaveAs(FilePath)
                obj.attachment6filename = FileName + Extension
                obj.attachmentname6 = attachmentname6
                obj.attachmentpath6 = attachmentpath6
            Else
                obj.attachment6filename = Trim(lblFileUpload6.Text)
                obj.attachmentname6 = Trim(Hfattachmentname6.Value)
                obj.attachmentpath6 = Trim(Hfattachmentpath6.Value)
            End If


            Dim attachmentname7, attachmentpath7 As String
            If FileUpload7.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload7.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload7.PostedFile.FileName)
                attachmentname7 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath7 = ("Attachments\") + attachmentname7
                Dim FilePath As String = Server.MapPath(attachmentpath7)
                FileUpload7.PostedFile.SaveAs(FilePath)
                obj.attachment7filename = FileName + Extension
                obj.attachmentname7 = attachmentname7
                obj.attachmentpath7 = attachmentpath7
            Else
                obj.attachment7filename = Trim(lblFileUpload7.Text)
                obj.attachmentname7 = Trim(Hfattachmentname7.Value)
                obj.attachmentpath7 = Trim(Hfattachmentpath7.Value)
            End If



            Dim attachmentname8, attachmentpath8 As String
            If FileUpload8.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload8.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload8.PostedFile.FileName)
                attachmentname8 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath8 = ("Attachments\") + attachmentname8
                Dim FilePath As String = Server.MapPath(attachmentpath8)
                FileUpload8.PostedFile.SaveAs(FilePath)
                obj.attachment8filename = FileName + Extension
                obj.attachmentname8 = attachmentname8
                obj.attachmentpath8 = attachmentpath8
            Else
                obj.attachment8filename = Trim(lblFileUpload8.Text)
                obj.attachmentname8 = Trim(Hfattachmentname8.Value)
                obj.attachmentpath8 = Trim(Hfattachmentpath8.Value)
            End If

            Dim attachmentname9, attachmentpath9 As String
            If FileUpload9.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload9.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload9.PostedFile.FileName)
                attachmentname9 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath9 = ("Attachments\") + attachmentname9
                Dim FilePath As String = Server.MapPath(attachmentpath9)
                FileUpload9.PostedFile.SaveAs(FilePath)
                obj.attachment9filename = FileName + Extension
                obj.attachmentname9 = attachmentname9
                obj.attachmentpath9 = attachmentpath9
            Else
                obj.attachment9filename = Trim(lblFileUpload9.Text)
                obj.attachmentname9 = Trim(Hfattachmentname9.Value)
                obj.attachmentpath9 = Trim(Hfattachmentpath9.Value)
            End If

            Dim attachmentname10, attachmentpath10 As String
            If FileUpload10.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload10.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload10.PostedFile.FileName)
                attachmentname10 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath10 = ("Attachments\") + attachmentname10
                Dim FilePath As String = Server.MapPath(attachmentpath10)
                FileUpload10.PostedFile.SaveAs(FilePath)
                obj.attachment10filename = FileName + Extension
                obj.attachmentname10 = attachmentname10
                obj.attachmentpath10 = attachmentpath10
            Else
                obj.attachment10filename = Trim(lblFileUpload10.Text)
                obj.attachmentname10 = Trim(Hfattachmentname10.Value)
                obj.attachmentpath10 = Trim(Hfattachmentpath10.Value)
            End If

            obj.link1 = Trim(txtLink1.Text)
            obj.link2 = Trim(txtLink2.Text)
            obj.link3 = Trim(txtLink3.Text)
            obj.link4 = Trim(txtLink4.Text)
            obj.link5 = Trim(txtLink5.Text)
            obj.customerinstruction = Trim(txtcustomerinstruction.Text)
            obj.sendtographics_flag = "1"
            obj.sentographic_uid = Trim(Session.Item("UserID"))
            obj.sentographic_dt = Date.Now()



            obj.crtuserid = Trim(Session.Item("UserID"))
            obj.crtuserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.moduserid = Trim(Session.Item("UserID"))
            obj.moduserdt = (Format(Now.Date, "dd/MM/yyyy"))

            clsJobEntry.Update_Data_Add_Graphics(obj, j, mode, "")

            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            sSQL = "update jobentry set assignedto_appformgraphic='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_appformsentcustomer='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_sendcustomerapproval='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_prepress='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_materialprod='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_qccheck='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_challan='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_dispatch='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_billing='" & Trim(ddlassignedto.SelectedValue) & "'  where jobid='" & txtjobid.Text & "'"
            dt1 = objDas.GetDataTable(sSQL)

            If ErrorMSG.Text = "" Then
                HFsave_value.Value = ""
                Response.Write("<script>alert('Send To Grpahics Succesfully " & Trim(txtjobid.Text) & "'); ")
                Response.Write("window.location='JobEntry.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
            End If
            New_Docno()
            Call Refresh()
        Catch ex As Exception


            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        Finally
            con.Close()
            con = Nothing
        End Try
    End Sub

    Private Sub Save_Data_Edit_Graphics()
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim c As New clsJobEntry
        Dim i As Integer

        Dim ds As DataSet
        Dim dtdet As New DataTable
        Dim dr As DataRow

        con = clsJobEntry.GetConnection()
        com = clsJobEntry.GetCommand

        com.Connection = con
        com.CommandType = CommandType.Text

        Try
            Dim obj As New clsJobEntry, objDas As New DBAccess
            obj.jobid = Trim(txtjobid.Text)
            obj.jobcreatedt = objDas.FilteredString(txtjobcreatedt.Text)
            obj.startdate = DateTime.Now
            obj.starttime = DateTime.Now
            obj.jobname = Trim(txtjobname.Text)
            obj.prioirty = ddlprioirty.SelectedValue
            obj.printcd = ddlprintcd.SelectedValue
            obj.cuscode = ddlcuscode.SelectedValue
            obj.intcode = txtintcode.Text
            obj.revno = txtrevno.Text
            obj.assignedto = ddlassignedto.SelectedValue
            obj.ticketno = txtticketno.Text
            obj.originaljobid = Trim(txtjobid.Text)
            obj.jobversion = 0

            Dim attachmentname1, attachmentpath1 As String
            If FileUpload1.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
                attachmentname1 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath1 = ("Attachments\") + attachmentname1
                Dim FilePath As String = Server.MapPath(attachmentpath1)
                FileUpload1.PostedFile.SaveAs(FilePath)
                obj.attachment1filename = FileName + Extension
                obj.attachmentname1 = attachmentname1
                obj.attachmentpath1 = attachmentpath1
            Else
                obj.attachment1filename = Trim(lblFileUpload1.Text)
                obj.attachmentname1 = Trim(Hfattachmentname1.Value)
                obj.attachmentpath1 = Trim(Hfattachmentpath1.Value)
            End If


            Dim attachmentname2, attachmentpath2 As String
            If FileUpload2.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload2.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload2.PostedFile.FileName)
                attachmentname2 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath2 = ("Attachments\") + attachmentname2
                Dim FilePath As String = Server.MapPath(attachmentpath2)
                FileUpload2.PostedFile.SaveAs(FilePath)
                obj.attachment2filename = FileName + Extension
                obj.attachmentname2 = attachmentname2
                obj.attachmentpath2 = attachmentpath2
            Else
                obj.attachment2filename = Trim(lblFileUpload2.Text)
                obj.attachmentname2 = Trim(Hfattachmentname2.Value)
                obj.attachmentpath2 = Trim(Hfattachmentpath2.Value)
            End If


            Dim attachmentname3, attachmentpath3 As String
            If FileUpload3.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload3.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload3.PostedFile.FileName)
                attachmentname3 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath3 = ("Attachments\") + attachmentname3
                Dim FilePath As String = Server.MapPath(attachmentpath3)
                FileUpload3.PostedFile.SaveAs(FilePath)
                obj.attachment3filename = FileName + Extension
                obj.attachmentname3 = attachmentname3
                obj.attachmentpath3 = attachmentpath3
            Else
                obj.attachment3filename = Trim(lblFileUpload3.Text)
                obj.attachmentname3 = Trim(Hfattachmentname3.Value)
                obj.attachmentpath3 = Trim(Hfattachmentpath3.Value)
            End If


            Dim attachmentname4, attachmentpath4 As String
            If FileUpload4.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload4.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload4.PostedFile.FileName)
                attachmentname4 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath4 = ("Attachments\") + attachmentname4
                Dim FilePath As String = Server.MapPath(attachmentpath4)
                FileUpload4.PostedFile.SaveAs(FilePath)
                obj.attachment4filename = FileName + Extension
                obj.attachmentname4 = attachmentname4
                obj.attachmentpath4 = attachmentpath4
            Else
                obj.attachment4filename = Trim(lblFileUpload4.Text)
                obj.attachmentname4 = Trim(Hfattachmentname4.Value)
                obj.attachmentpath4 = Trim(Hfattachmentpath4.Value)
            End If

            Dim attachmentname5, attachmentpath5 As String
            If FileUpload5.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload5.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload5.PostedFile.FileName)
                attachmentname5 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath5 = ("Attachments\") + attachmentname5
                Dim FilePath As String = Server.MapPath(attachmentpath5)
                FileUpload5.PostedFile.SaveAs(FilePath)
                obj.attachment5filename = FileName + Extension
                obj.attachmentname5 = attachmentname5
                obj.attachmentpath5 = attachmentpath5
            Else
                obj.attachment5filename = Trim(lblFileUpload5.Text)
                obj.attachmentname5 = Trim(Hfattachmentname5.Value)
                obj.attachmentpath5 = Trim(Hfattachmentpath5.Value)
            End If

            Dim attachmentname6, attachmentpath6 As String
            If FileUpload6.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload6.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload6.PostedFile.FileName)
                attachmentname6 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath6 = ("Attachments\") + attachmentname6
                Dim FilePath As String = Server.MapPath(attachmentpath6)
                FileUpload6.PostedFile.SaveAs(FilePath)
                obj.attachment6filename = FileName + Extension
                obj.attachmentname6 = attachmentname6
                obj.attachmentpath6 = attachmentpath6
            Else
                obj.attachment6filename = Trim(lblFileUpload6.Text)
                obj.attachmentname6 = Trim(Hfattachmentname6.Value)
                obj.attachmentpath6 = Trim(Hfattachmentpath6.Value)
            End If


            Dim attachmentname7, attachmentpath7 As String
            If FileUpload7.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload7.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload7.PostedFile.FileName)
                attachmentname7 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath7 = ("Attachments\") + attachmentname7
                Dim FilePath As String = Server.MapPath(attachmentpath7)
                FileUpload7.PostedFile.SaveAs(FilePath)
                obj.attachment7filename = FileName + Extension
                obj.attachmentname7 = attachmentname7
                obj.attachmentpath7 = attachmentpath7
            Else
                obj.attachment7filename = Trim(lblFileUpload7.Text)
                obj.attachmentname7 = Trim(Hfattachmentname7.Value)
                obj.attachmentpath7 = Trim(Hfattachmentpath7.Value)
            End If



            Dim attachmentname8, attachmentpath8 As String
            If FileUpload8.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload8.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload8.PostedFile.FileName)
                attachmentname8 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath8 = ("Attachments\") + attachmentname8
                Dim FilePath As String = Server.MapPath(attachmentpath8)
                FileUpload8.PostedFile.SaveAs(FilePath)
                obj.attachment8filename = FileName + Extension
                obj.attachmentname8 = attachmentname8
                obj.attachmentpath8 = attachmentpath8
            Else
                obj.attachment8filename = Trim(lblFileUpload8.Text)
                obj.attachmentname8 = Trim(Hfattachmentname8.Value)
                obj.attachmentpath8 = Trim(Hfattachmentpath8.Value)
            End If

            Dim attachmentname9, attachmentpath9 As String
            If FileUpload9.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload9.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload9.PostedFile.FileName)
                attachmentname9 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath9 = ("Attachments\") + attachmentname9
                Dim FilePath As String = Server.MapPath(attachmentpath9)
                FileUpload9.PostedFile.SaveAs(FilePath)
                obj.attachment9filename = FileName + Extension
                obj.attachmentname9 = attachmentname9
                obj.attachmentpath9 = attachmentpath9
            Else
                obj.attachment9filename = Trim(lblFileUpload9.Text)
                obj.attachmentname9 = Trim(Hfattachmentname9.Value)
                obj.attachmentpath9 = Trim(Hfattachmentpath9.Value)
            End If

            Dim attachmentname10, attachmentpath10 As String
            If FileUpload10.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload10.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload10.PostedFile.FileName)
                attachmentname10 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath10 = ("Attachments\") + attachmentname10
                Dim FilePath As String = Server.MapPath(attachmentpath10)
                FileUpload10.PostedFile.SaveAs(FilePath)
                obj.attachment10filename = FileName + Extension
                obj.attachmentname10 = attachmentname10
                obj.attachmentpath10 = attachmentpath10
            Else
                obj.attachment10filename = Trim(lblFileUpload10.Text)
                obj.attachmentname10 = Trim(Hfattachmentname10.Value)
                obj.attachmentpath10 = Trim(Hfattachmentpath10.Value)
            End If

            obj.link1 = Trim(txtLink1.Text)
            obj.link2 = Trim(txtLink2.Text)
            obj.link3 = Trim(txtLink3.Text)
            obj.link4 = Trim(txtLink4.Text)
            obj.link5 = Trim(txtLink5.Text)
            obj.customerinstruction = Trim(txtcustomerinstruction.Text)
            obj.sendtographics_flag = "1"
            obj.sentographic_uid = Trim(Session.Item("UserID"))
            obj.sentographic_dt = Date.Now()


            obj.crtuserid = Trim(Session.Item("UserID"))
            obj.crtuserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.moduserid = Trim(Session.Item("UserID"))
            obj.moduserdt = (Format(Now.Date, "dd/MM/yyyy"))
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            sSQL = "update jobentry set assignedto_appformgraphic='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_appformsentcustomer='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_sendcustomerapproval='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_prepress='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_materialprod='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_qccheck='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_challan='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_dispatch='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_billing='" & Trim(ddlassignedto.SelectedValue) & "'  where jobid='" & txtjobid.Text & "'"
            dt1 = objDas.GetDataTable(sSQL)

            If ErrorMSG.Text = "" Then
                HFsave_value.Value = ""
                Response.Write("<script>alert('Send To Grpahics Succesfully " & Trim(txtjobid.Text) & "'); ")
                Response.Write("window.location='JobEntry.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
            End If

            clsJobEntry.Update_Data_Edit_Graphics(obj, j, mode, "")
            If ErrorMSG.Text = "" Then
                Response.Write("<script>alert('Send To Grpahics Succesfully'); ")
                Response.Write("window.location='JobEntrySearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
            End If
        Catch ex As Exception
            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        Finally
            con.Close()
            con = Nothing
        End Try
    End Sub

    Private Sub Save_Data_Add_Prepress()
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim c As New clsJobEntry
        Dim i As Integer

        Dim ds As DataSet
        Dim dtdet As New DataTable
        Dim dr As DataRow

        con = clsJobEntry.GetConnection()
        com = clsJobEntry.GetCommand

        com.Connection = con
        com.CommandType = CommandType.Text

        Try
            Dim obj As New clsJobEntry, objDas As New DBAccess
            obj.jobid = Trim(txtjobid.Text)
            obj.jobcreatedt = objDas.FilteredString(txtjobcreatedt.Text)
            obj.startdate = DateTime.Now
            obj.starttime = DateTime.Now
            obj.jobname = Trim(txtjobname.Text)
            obj.prioirty = ddlprioirty.SelectedValue
            obj.printcd = ddlprintcd.SelectedValue
            obj.cuscode = ddlcuscode.SelectedValue
            obj.intcode = txtintcode.Text
            obj.revno = txtrevno.Text
            obj.assignedto = ddlassignedto.SelectedValue
            obj.ticketno = txtticketno.Text
            obj.originaljobid = Trim(txtjobid.Text)
            obj.jobversion = 0

            Dim attachmentname1, attachmentpath1 As String
            If FileUpload1.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
                attachmentname1 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath1 = ("Attachments\") + attachmentname1
                Dim FilePath As String = Server.MapPath(attachmentpath1)
                FileUpload1.PostedFile.SaveAs(FilePath)
                obj.attachment1filename = FileName + Extension
                obj.attachmentname1 = attachmentname1
                obj.attachmentpath1 = attachmentpath1
            Else
                obj.attachment1filename = Trim(lblFileUpload1.Text)
                obj.attachmentname1 = Trim(Hfattachmentname1.Value)
                obj.attachmentpath1 = Trim(Hfattachmentpath1.Value)
            End If


            Dim attachmentname2, attachmentpath2 As String
            If FileUpload2.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload2.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload2.PostedFile.FileName)
                attachmentname2 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath2 = ("Attachments\") + attachmentname2
                Dim FilePath As String = Server.MapPath(attachmentpath2)
                FileUpload2.PostedFile.SaveAs(FilePath)
                obj.attachment2filename = FileName + Extension
                obj.attachmentname2 = attachmentname2
                obj.attachmentpath2 = attachmentpath2
            Else
                obj.attachment2filename = Trim(lblFileUpload2.Text)
                obj.attachmentname2 = Trim(Hfattachmentname2.Value)
                obj.attachmentpath2 = Trim(Hfattachmentpath2.Value)
            End If


            Dim attachmentname3, attachmentpath3 As String
            If FileUpload3.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload3.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload3.PostedFile.FileName)
                attachmentname3 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath3 = ("Attachments\") + attachmentname3
                Dim FilePath As String = Server.MapPath(attachmentpath3)
                FileUpload3.PostedFile.SaveAs(FilePath)
                obj.attachment3filename = FileName + Extension
                obj.attachmentname3 = attachmentname3
                obj.attachmentpath3 = attachmentpath3
            Else
                obj.attachment3filename = Trim(lblFileUpload3.Text)
                obj.attachmentname3 = Trim(Hfattachmentname3.Value)
                obj.attachmentpath3 = Trim(Hfattachmentpath3.Value)
            End If


            Dim attachmentname4, attachmentpath4 As String
            If FileUpload4.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload4.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload4.PostedFile.FileName)
                attachmentname4 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath4 = ("Attachments\") + attachmentname4
                Dim FilePath As String = Server.MapPath(attachmentpath4)
                FileUpload4.PostedFile.SaveAs(FilePath)
                obj.attachment4filename = FileName + Extension
                obj.attachmentname4 = attachmentname4
                obj.attachmentpath4 = attachmentpath4
            Else
                obj.attachment4filename = Trim(lblFileUpload4.Text)
                obj.attachmentname4 = Trim(Hfattachmentname4.Value)
                obj.attachmentpath4 = Trim(Hfattachmentpath4.Value)
            End If

            Dim attachmentname5, attachmentpath5 As String
            If FileUpload5.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload5.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload5.PostedFile.FileName)
                attachmentname5 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath5 = ("Attachments\") + attachmentname5
                Dim FilePath As String = Server.MapPath(attachmentpath5)
                FileUpload5.PostedFile.SaveAs(FilePath)
                obj.attachment5filename = FileName + Extension
                obj.attachmentname5 = attachmentname5
                obj.attachmentpath5 = attachmentpath5
            Else
                obj.attachment5filename = Trim(lblFileUpload5.Text)
                obj.attachmentname5 = Trim(Hfattachmentname5.Value)
                obj.attachmentpath5 = Trim(Hfattachmentpath5.Value)
            End If

            Dim attachmentname6, attachmentpath6 As String
            If FileUpload6.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload6.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload6.PostedFile.FileName)
                attachmentname6 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath6 = ("Attachments\") + attachmentname6
                Dim FilePath As String = Server.MapPath(attachmentpath6)
                FileUpload6.PostedFile.SaveAs(FilePath)
                obj.attachment6filename = FileName + Extension
                obj.attachmentname6 = attachmentname6
                obj.attachmentpath6 = attachmentpath6
            Else
                obj.attachment6filename = Trim(lblFileUpload6.Text)
                obj.attachmentname6 = Trim(Hfattachmentname6.Value)
                obj.attachmentpath6 = Trim(Hfattachmentpath6.Value)
            End If


            Dim attachmentname7, attachmentpath7 As String
            If FileUpload7.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload7.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload7.PostedFile.FileName)
                attachmentname7 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath7 = ("Attachments\") + attachmentname7
                Dim FilePath As String = Server.MapPath(attachmentpath7)
                FileUpload7.PostedFile.SaveAs(FilePath)
                obj.attachment7filename = FileName + Extension
                obj.attachmentname7 = attachmentname7
                obj.attachmentpath7 = attachmentpath7
            Else
                obj.attachment7filename = Trim(lblFileUpload7.Text)
                obj.attachmentname7 = Trim(Hfattachmentname7.Value)
                obj.attachmentpath7 = Trim(Hfattachmentpath7.Value)
            End If



            Dim attachmentname8, attachmentpath8 As String
            If FileUpload8.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload8.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload8.PostedFile.FileName)
                attachmentname8 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath8 = ("Attachments\") + attachmentname8
                Dim FilePath As String = Server.MapPath(attachmentpath8)
                FileUpload8.PostedFile.SaveAs(FilePath)
                obj.attachment8filename = FileName + Extension
                obj.attachmentname8 = attachmentname8
                obj.attachmentpath8 = attachmentpath8
            Else
                obj.attachment8filename = Trim(lblFileUpload8.Text)
                obj.attachmentname8 = Trim(Hfattachmentname8.Value)
                obj.attachmentpath8 = Trim(Hfattachmentpath8.Value)
            End If

            Dim attachmentname9, attachmentpath9 As String
            If FileUpload9.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload9.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload9.PostedFile.FileName)
                attachmentname9 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath9 = ("Attachments\") + attachmentname9
                Dim FilePath As String = Server.MapPath(attachmentpath9)
                FileUpload9.PostedFile.SaveAs(FilePath)
                obj.attachment9filename = FileName + Extension
                obj.attachmentname9 = attachmentname9
                obj.attachmentpath9 = attachmentpath9
            Else
                obj.attachment9filename = Trim(lblFileUpload9.Text)
                obj.attachmentname9 = Trim(Hfattachmentname9.Value)
                obj.attachmentpath9 = Trim(Hfattachmentpath9.Value)
            End If

            Dim attachmentname10, attachmentpath10 As String
            If FileUpload10.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload10.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload10.PostedFile.FileName)
                attachmentname10 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath10 = ("Attachments\") + attachmentname10
                Dim FilePath As String = Server.MapPath(attachmentpath10)
                FileUpload10.PostedFile.SaveAs(FilePath)
                obj.attachment10filename = FileName + Extension
                obj.attachmentname10 = attachmentname10
                obj.attachmentpath10 = attachmentpath10
            Else
                obj.attachment10filename = Trim(lblFileUpload10.Text)
                obj.attachmentname10 = Trim(Hfattachmentname10.Value)
                obj.attachmentpath10 = Trim(Hfattachmentpath10.Value)
            End If

            obj.link1 = Trim(txtLink1.Text)
            obj.link2 = Trim(txtLink2.Text)
            obj.link3 = Trim(txtLink3.Text)
            obj.link4 = Trim(txtLink4.Text)
            obj.link5 = Trim(txtLink5.Text)
            obj.customerinstruction = Trim(txtcustomerinstruction.Text)
            obj.approve_sendforprepress_flag = "1"
            obj.approve_sendforprepress_uid = Trim(Session.Item("UserID"))
            obj.approve_sendforprepress_date = Date.Now()



            obj.crtuserid = Trim(Session.Item("UserID"))
            obj.crtuserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.moduserid = Trim(Session.Item("UserID"))
            obj.moduserdt = (Format(Now.Date, "dd/MM/yyyy"))

            clsJobEntry.Update_Data_Add_Prepress(obj, j, mode, "")
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            sSQL = "update jobentry set assignedto_appformgraphic='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_appformsentcustomer='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_sendcustomerapproval='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_prepress='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_materialprod='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_qccheck='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_challan='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_dispatch='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_billing='" & Trim(ddlassignedto.SelectedValue) & "'  where jobid='" & txtjobid.Text & "'"
            dt1 = objDas.GetDataTable(sSQL)

            If ErrorMSG.Text = "" Then
                HFsave_value.Value = ""
                Response.Write("<script>alert('Send To Prepress Succesfully " & Trim(txtjobid.Text) & "'); ")
                Response.Write("window.location='JobEntry.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")

            End If
            New_Docno()
            Call Refresh()
        Catch ex As Exception


            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        Finally
            con.Close()
            con = Nothing
        End Try
    End Sub

    Private Sub Save_Data_Edit_Prepress()
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim c As New clsJobEntry
        Dim i As Integer

        Dim ds As DataSet
        Dim dtdet As New DataTable
        Dim dr As DataRow

        con = clsJobEntry.GetConnection()
        com = clsJobEntry.GetCommand

        com.Connection = con
        com.CommandType = CommandType.Text

        Try
            Dim obj As New clsJobEntry, objDas As New DBAccess
            obj.jobid = Trim(txtjobid.Text)
            obj.jobcreatedt = objDas.FilteredString(txtjobcreatedt.Text)
            obj.startdate = DateTime.Now
            obj.starttime = DateTime.Now
            obj.jobname = Trim(txtjobname.Text)
            obj.prioirty = ddlprioirty.SelectedValue
            obj.printcd = ddlprintcd.SelectedValue
            obj.cuscode = ddlcuscode.SelectedValue
            obj.intcode = txtintcode.Text
            obj.revno = txtrevno.Text
            obj.assignedto = ddlassignedto.SelectedValue
            obj.ticketno = txtticketno.Text
            obj.originaljobid = Trim(txtjobid.Text)
            obj.jobversion = 0

            Dim attachmentname1, attachmentpath1 As String
            If FileUpload1.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
                attachmentname1 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath1 = ("Attachments\") + attachmentname1
                Dim FilePath As String = Server.MapPath(attachmentpath1)
                FileUpload1.PostedFile.SaveAs(FilePath)
                obj.attachment1filename = FileName + Extension
                obj.attachmentname1 = attachmentname1
                obj.attachmentpath1 = attachmentpath1
            Else
                obj.attachment1filename = Trim(lblFileUpload1.Text)
                obj.attachmentname1 = Trim(Hfattachmentname1.Value)
                obj.attachmentpath1 = Trim(Hfattachmentpath1.Value)
            End If


            Dim attachmentname2, attachmentpath2 As String
            If FileUpload2.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload2.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload2.PostedFile.FileName)
                attachmentname2 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath2 = ("Attachments\") + attachmentname2
                Dim FilePath As String = Server.MapPath(attachmentpath2)
                FileUpload2.PostedFile.SaveAs(FilePath)
                obj.attachment2filename = FileName + Extension
                obj.attachmentname2 = attachmentname2
                obj.attachmentpath2 = attachmentpath2
            Else
                obj.attachment2filename = Trim(lblFileUpload2.Text)
                obj.attachmentname2 = Trim(Hfattachmentname2.Value)
                obj.attachmentpath2 = Trim(Hfattachmentpath2.Value)
            End If


            Dim attachmentname3, attachmentpath3 As String
            If FileUpload3.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload3.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload3.PostedFile.FileName)
                attachmentname3 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath3 = ("Attachments\") + attachmentname3
                Dim FilePath As String = Server.MapPath(attachmentpath3)
                FileUpload3.PostedFile.SaveAs(FilePath)
                obj.attachment3filename = FileName + Extension
                obj.attachmentname3 = attachmentname3
                obj.attachmentpath3 = attachmentpath3
            Else
                obj.attachment3filename = Trim(lblFileUpload3.Text)
                obj.attachmentname3 = Trim(Hfattachmentname3.Value)
                obj.attachmentpath3 = Trim(Hfattachmentpath3.Value)
            End If


            Dim attachmentname4, attachmentpath4 As String
            If FileUpload4.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload4.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload4.PostedFile.FileName)
                attachmentname4 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath4 = ("Attachments\") + attachmentname4
                Dim FilePath As String = Server.MapPath(attachmentpath4)
                FileUpload4.PostedFile.SaveAs(FilePath)
                obj.attachment4filename = FileName + Extension
                obj.attachmentname4 = attachmentname4
                obj.attachmentpath4 = attachmentpath4
            Else
                obj.attachment4filename = Trim(lblFileUpload4.Text)
                obj.attachmentname4 = Trim(Hfattachmentname4.Value)
                obj.attachmentpath4 = Trim(Hfattachmentpath4.Value)
            End If

            Dim attachmentname5, attachmentpath5 As String
            If FileUpload5.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload5.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload5.PostedFile.FileName)
                attachmentname5 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath5 = ("Attachments\") + attachmentname5
                Dim FilePath As String = Server.MapPath(attachmentpath5)
                FileUpload5.PostedFile.SaveAs(FilePath)
                obj.attachment5filename = FileName + Extension
                obj.attachmentname5 = attachmentname5
                obj.attachmentpath5 = attachmentpath5
            Else
                obj.attachment5filename = Trim(lblFileUpload5.Text)
                obj.attachmentname5 = Trim(Hfattachmentname5.Value)
                obj.attachmentpath5 = Trim(Hfattachmentpath5.Value)
            End If

            Dim attachmentname6, attachmentpath6 As String
            If FileUpload6.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload6.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload6.PostedFile.FileName)
                attachmentname6 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath6 = ("Attachments\") + attachmentname6
                Dim FilePath As String = Server.MapPath(attachmentpath6)
                FileUpload6.PostedFile.SaveAs(FilePath)
                obj.attachment6filename = FileName + Extension
                obj.attachmentname6 = attachmentname6
                obj.attachmentpath6 = attachmentpath6
            Else
                obj.attachment6filename = Trim(lblFileUpload6.Text)
                obj.attachmentname6 = Trim(Hfattachmentname6.Value)
                obj.attachmentpath6 = Trim(Hfattachmentpath6.Value)
            End If


            Dim attachmentname7, attachmentpath7 As String
            If FileUpload7.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload7.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload7.PostedFile.FileName)
                attachmentname7 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath7 = ("Attachments\") + attachmentname7
                Dim FilePath As String = Server.MapPath(attachmentpath7)
                FileUpload7.PostedFile.SaveAs(FilePath)
                obj.attachment7filename = FileName + Extension
                obj.attachmentname7 = attachmentname7
                obj.attachmentpath7 = attachmentpath7
            Else
                obj.attachment7filename = Trim(lblFileUpload7.Text)
                obj.attachmentname7 = Trim(Hfattachmentname7.Value)
                obj.attachmentpath7 = Trim(Hfattachmentpath7.Value)
            End If



            Dim attachmentname8, attachmentpath8 As String
            If FileUpload8.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload8.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload8.PostedFile.FileName)
                attachmentname8 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath8 = ("Attachments\") + attachmentname8
                Dim FilePath As String = Server.MapPath(attachmentpath8)
                FileUpload8.PostedFile.SaveAs(FilePath)
                obj.attachment8filename = FileName + Extension
                obj.attachmentname8 = attachmentname8
                obj.attachmentpath8 = attachmentpath8
            Else
                obj.attachment8filename = Trim(lblFileUpload8.Text)
                obj.attachmentname8 = Trim(Hfattachmentname8.Value)
                obj.attachmentpath8 = Trim(Hfattachmentpath8.Value)
            End If

            Dim attachmentname9, attachmentpath9 As String
            If FileUpload9.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload9.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload9.PostedFile.FileName)
                attachmentname9 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath9 = ("Attachments\") + attachmentname9
                Dim FilePath As String = Server.MapPath(attachmentpath9)
                FileUpload9.PostedFile.SaveAs(FilePath)
                obj.attachment9filename = FileName + Extension
                obj.attachmentname9 = attachmentname9
                obj.attachmentpath9 = attachmentpath9
            Else
                obj.attachment9filename = Trim(lblFileUpload9.Text)
                obj.attachmentname9 = Trim(Hfattachmentname9.Value)
                obj.attachmentpath9 = Trim(Hfattachmentpath9.Value)
            End If

            Dim attachmentname10, attachmentpath10 As String
            If FileUpload10.HasFile Then
                Dim FileName As String = Path.GetFileNameWithoutExtension(FileUpload10.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload10.PostedFile.FileName)
                attachmentname10 = Trim(txtjobid.Text).Replace("/", "_") + "_" + FileName.Replace("&", "") + "_" + DateAndTime.Now().ToString("dd-mm-yyyyHHmmss") + Extension
                attachmentpath10 = ("Attachments\") + attachmentname10
                Dim FilePath As String = Server.MapPath(attachmentpath10)
                FileUpload10.PostedFile.SaveAs(FilePath)
                obj.attachment10filename = FileName + Extension
                obj.attachmentname10 = attachmentname10
                obj.attachmentpath10 = attachmentpath10
            Else
                obj.attachment10filename = Trim(lblFileUpload10.Text)
                obj.attachmentname10 = Trim(Hfattachmentname10.Value)
                obj.attachmentpath10 = Trim(Hfattachmentpath10.Value)
            End If

            obj.link1 = Trim(txtLink1.Text)
            obj.link2 = Trim(txtLink2.Text)
            obj.link3 = Trim(txtLink3.Text)
            obj.link4 = Trim(txtLink4.Text)
            obj.link5 = Trim(txtLink5.Text)
            obj.customerinstruction = Trim(txtcustomerinstruction.Text)
            obj.approve_sendforprepress_flag = "1"
            obj.approve_sendforprepress_uid = Trim(Session.Item("UserID"))
            obj.approve_sendforprepress_date = Date.Now()


            obj.crtuserid = Trim(Session.Item("UserID"))
            obj.crtuserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.moduserid = Trim(Session.Item("UserID"))
            obj.moduserdt = (Format(Now.Date, "dd/MM/yyyy"))

            clsJobEntry.Update_Data_Edit_Prepress(obj, j, mode, "")
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            sSQL = "update jobentry set assignedto_appformgraphic='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_appformsentcustomer='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_sendcustomerapproval='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_prepress='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_materialprod='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_qccheck='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_challan='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_dispatch='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_billing='" & Trim(ddlassignedto.SelectedValue) & "'  where jobid='" & txtjobid.Text & "'"
            dt1 = objDas.GetDataTable(sSQL)
            If ErrorMSG.Text = "" Then
                Response.Write("<script>alert('Send To Prepress Succesfully'); ")
                Response.Write("window.location='JobEntrySearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
            End If
        Catch ex As Exception
            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        Finally
            con.Close()
            con = Nothing
        End Try
    End Sub



    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click


        Try

            If Trim(Request.QueryString("docno")) = "" Then
                Call save_add()
            Else
                Call save_edit()
            End If
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            sSQL = "update jobentry set assignedto_appformgraphic='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_appformsentcustomer='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_sendcustomerapproval='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_prepress='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_materialprod='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_qccheck='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_challan='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_dispatch='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_billing='" & Trim(ddlassignedto.SelectedValue) & "'  where jobid='" & txtjobid.Text & "'"
            dt1 = objDas.GetDataTable(sSQL)
        Catch ex As Exception
            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
            Exit Sub
        End Try
    End Sub

    Private Sub save_add()
        Dim strdocno As String
        Call New_Docno()
        strdocno = Trim(txtjobid.Text)

        Call Save_Data_Add()
    End Sub

    Private Sub save_edit()
        Call Save_Data_Edit()
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btncancel.Click
        Try
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            sSQL = "update jobentry set cancelflag='1',canceluserid='" & Trim(Session.Item("UserID")) & "',canceldt=GetDate(),cancelremark='" & Trim(txtcancelremark.Text) & "' where jobid='" & txtjobid.Text & "'"
            dt1 = objDas.GetDataTable(sSQL)
            Response.Write("<script>alert('Cancel Job Entry Succesfully'); ")
            Response.Write("window.location='JobEntrySearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")

        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub


    Protected Sub btnSendToGrphics_Click(sender As Object, e As System.EventArgs) Handles btnSendToGrphics.Click
        Try
            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            sSQL = "update jobentry set sendtographics_flag='1',sentographic_uid='" & Trim(Session.Item("UserID")) & "',sentographic_dt=GetDate(),assignedto_appformgraphic='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_appformsentcustomer='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_sendcustomerapproval='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_prepress='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_materialprod='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_qccheck='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_challan='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_dispatch='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_billing='" & Trim(ddlassignedto.SelectedValue) & "' where jobid='" & txtjobid.Text & "'"
            dt1 = objDas.GetDataTable(sSQL)
            Response.Write("<script>alert('Send To Grpahics Succesfully'); ")
            Response.Write("window.location='JobEntrySearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")

        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnsendtopress_Click(sender As Object, e As System.EventArgs) Handles btnsendtopress.Click
        Try

            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            sSQL = "update jobentry set approve_sendforprepress_flag='1',approve_sendforprepress_uid='" & Trim(Session.Item("UserID")) & "',approve_sendforprepress_date=GetDate(), assignedto_appformgraphic='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_appformsentcustomer='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_sendcustomerapproval='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_prepress='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_materialprod='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_qccheck='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_challan='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_dispatch='" & Trim(ddlassignedto.SelectedValue) & "',assignedto_billing='" & Trim(ddlassignedto.SelectedValue) & "' where jobid='" & txtjobid.Text & "'"
            dt1 = objDas.GetDataTable(sSQL)
            Response.Write("<script>alert('Send To Prepress Succesfully'); ")
            Response.Write("window.location='JobEntrySearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")

        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub



    Protected Sub btnRevoke_Click(sender As Object, e As System.EventArgs) Handles btnRevoke.Click
        Try

            Dim sSQL As String
            Dim dt1, dt2, dt3 As DataTable
            Dim objDas As New DBAccess
            sSQL = "update jobentry set opcode=null,plate_processed_date=null,holdsendtographics_flag=0,hold_sendforprepress_flag=0,billing_close_flag=0,length_plate_cms='',width_plate_cms='',chlno='',chldt=null,billno='',billdate=null,transcd=null,docketno ='',sendtographics_flag=0,sentographic_dt=null ,sentographic_uid='',sento_customer_flag=0,sento_customer_uid='',sento_customer_date=null,approve_sendforprepress_flag=0,approve_sendforprepress_uid='',approve_sendforprepress_date=null,sendfor_reproduction_flag=0,sendfor_reproduction_uid='',sendfor_reproduction_udate=null,customer_approval_flag=0,approve_sendtocustomerforapprval_flag=0,approve_sendtocustomerforapprval_uid='',approve_sendtocustomerforapprval_date=null,qc_check_flag=0,qc_check_uid='',qc_check_date=null,sendfor_billing_flag=0,sendfor_billing_uid='',sendfor_billing_udate=null,sendfor_dispatch_flag=0,sendfor_dispatch_uid = '',sendfor_dispatch_udt=null,dispatch_close_flag=0,distpatch_uid='',dispatch_udate=null,sendfor_challan_flag=0,sendfor_challan_uid='',sendfor_challan_date=null,cancelflag=0 ,canceluserid='',canceldt=null where jobid='" & txtjobid.Text & "'"
            dt1 = objDas.GetDataTable(sSQL)
            Response.Write("<script>alert('Revoke Succesfully'); ")
            Response.Write("window.location='JobEntrySearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")

        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub


    Protected Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("JobEntrySearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
    End Sub


    Protected Sub btnViewFileUpload1_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload1.Click
        If Trim(Hfattachmentpath1.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath1.Value).Replace("\", "/") & "');", True)
        End If

    End Sub

    Protected Sub btnViewFileUpload2_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload2.Click
        If Trim(Hfattachmentpath2.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath2.Value).Replace("\", "/") & "');", True)
        End If

    End Sub

    Protected Sub btnViewFileUpload3_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload3.Click
        If Trim(Hfattachmentpath3.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath3.Value).Replace("\", "/") & "');", True)
        End If

    End Sub

    Protected Sub btnViewFileUpload4_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload4.Click
        If Trim(Hfattachmentpath4.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath4.Value).Replace("\", "/") & "');", True)
        End If

    End Sub

    Protected Sub btnViewFileUpload5_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload5.Click
        If Trim(Hfattachmentpath5.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath5.Value).Replace("\", "/") & "');", True)
        End If

    End Sub

    Protected Sub btnViewFileUpload6_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload6.Click
        If Trim(Hfattachmentpath6.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath6.Value).Replace("\", "/") & "');", True)
        End If

    End Sub

    Protected Sub btnViewFileUpload7_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload7.Click
        If Trim(Hfattachmentpath7.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath7.Value).Replace("\", "/") & "');", True)
        End If

    End Sub

    Protected Sub btnViewFileUpload8_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload8.Click
        If Trim(Hfattachmentpath8.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath8.Value).Replace("\", "/") & "');", True)
        End If

    End Sub

    Protected Sub btnViewFileUpload9_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload9.Click
        If Trim(Hfattachmentpath9.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath9.Value).Replace("\", "/") & "');", True)
        End If

    End Sub

    Protected Sub btnViewFileUpload10_Click(sender As Object, e As ImageClickEventArgs) Handles btnViewFileUpload10.Click
        If Trim(Hfattachmentpath10.Value) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(Hfattachmentpath10.Value).Replace("\", "/") & "');", True)
        End If

    End Sub


    Protected Sub btnDeleteFileUpload1_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload1.Click
        lblFileUpload1.Text = ""
        Hfattachmentpath1.Value = ""
        Hfattachmentname1.Value = ""
    End Sub
    Protected Sub btnDeleteFileUpload2_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload2.Click
        lblFileUpload2.Text = ""
        Hfattachmentpath2.Value = ""
        Hfattachmentname2.Value = ""
    End Sub

    Protected Sub btnDeleteFileUpload3_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload3.Click
        lblFileUpload3.Text = ""
        Hfattachmentpath3.Value = ""
        Hfattachmentname3.Value = ""
    End Sub

    Protected Sub btnDeleteFileUpload4_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload4.Click
        lblFileUpload4.Text = ""
        Hfattachmentpath4.Value = ""
        Hfattachmentname4.Value = ""
    End Sub
    Protected Sub btnDeleteFileUpload5_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload5.Click
        lblFileUpload5.Text = ""
        Hfattachmentpath5.Value = ""
        Hfattachmentname5.Value = ""
    End Sub

    Protected Sub btnDeleteFileUpload6_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload6.Click
        lblFileUpload6.Text = ""
        Hfattachmentpath6.Value = ""
        Hfattachmentname6.Value = ""
    End Sub

    Protected Sub btnDeleteFileUpload7_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload7.Click
        lblFileUpload7.Text = ""
        Hfattachmentpath7.Value = ""
        Hfattachmentname7.Value = ""
    End Sub
    Protected Sub btnDeleteFileUpload8_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload8.Click
        lblFileUpload8.Text = ""
        Hfattachmentpath8.Value = ""
        Hfattachmentname8.Value = ""
    End Sub

    Protected Sub btnDeleteFileUpload9_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload9.Click
        lblFileUpload9.Text = ""
        Hfattachmentpath9.Value = ""
        Hfattachmentname9.Value = ""
    End Sub

    Protected Sub btnDeleteFileUpload10_Click(sender As Object, e As ImageClickEventArgs) Handles btnDeleteFileUpload10.Click
        lblFileUpload10.Text = ""
        Hfattachmentpath10.Value = ""
        Hfattachmentname10.Value = ""
    End Sub


    Protected Sub link1View_Click(sender As Object, e As ImageClickEventArgs) Handles link1View.Click
        If Trim(txtLink1.Text) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(txtLink1.Text).Replace("\", "/") & "');", True)
        End If
    End Sub

    Protected Sub link2View_Click(sender As Object, e As ImageClickEventArgs) Handles link2View.Click
        If Trim(txtLink2.Text) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(txtLink2.Text).Replace("\", "/") & "');", True)
        End If
    End Sub

    Protected Sub link3View_Click(sender As Object, e As ImageClickEventArgs) Handles link3View.Click
        If Trim(txtLink3.Text) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(txtLink3.Text).Replace("\", "/") & "');", True)
        End If
    End Sub

    Protected Sub link4View_Click(sender As Object, e As ImageClickEventArgs) Handles link4View.Click
        If Trim(txtLink4.Text) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(txtLink4.Text).Replace("\", "/") & "');", True)
        End If
    End Sub

    Protected Sub link5View_Click(sender As Object, e As ImageClickEventArgs) Handles link5View.Click
        If Trim(txtLink5.Text) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('" & Trim(txtLink5.Text).Replace("\", "/") & "');", True)
        End If
    End Sub

    Private Sub btnAmendment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAmendment.Click
        Dim oldqtnno As String
        Dim newqtnno As String
        oldqtnno = txtjobid.Text
        j = clsJobEntry.Fetch_Paramno_amd(Trim(hdnJobId.Value))
        newqtnno = clsJobEntry.Generate_AmendDocno(j, Trim(hdnJobId.Value))

        Call clsJobEntry.AmmendData(j, oldqtnno, newqtnno)

        Dim objDas As New DBAccess
        Dim sSQL As String
        sSQL = "Update jobentry Set cancelflag = '1' Where jobid='" & Trim(oldqtnno) & "' "
        objDas.GetDataTable(sSQL)

        Response.Redirect("JobEntrySearch.aspx?docno=" & Trim(newqtnno) & "&MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")


    End Sub

    Protected Sub btnRecall_Click(sender As Object, e As System.EventArgs) Handles btnRecall.Click
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim ds As DataSet
        Dim dtdet As New DataTable
        con = clsJobEntry.GetConnection()
        com = clsJobEntry.GetCommand
        com.Connection = con
        com.CommandType = CommandType.Text
        Try
            Dim obj As clsJobEntry = clsJobEntry.FillData(ddlRecallJobId.SelectedValue, "B")
            If Not IsNothing(obj) Then

                txtjobname.Text = Trim(obj.jobname)
                ddlprioirty.SelectedItem.Selected = False
                ddlprioirty.Items.FindByValue(Trim(obj.prioirty)).Selected = True
                ddlcuscode.SelectedItem.Selected = False
                ddlcuscode.Items.FindByValue(Trim(obj.cuscode)).Selected = True
                ddlprintcd.SelectedItem.Selected = False
                ddlprintcd.Items.FindByValue(Trim(obj.printcd)).Selected = True
                txtintcode.Text = Trim(obj.intcode)
                txtrevno.Text = Trim(obj.revno)
                ddlassignedto.SelectedItem.Selected = False
                ddlassignedto.Items.FindByValue(Trim(obj.assignedto)).Selected = True
                txtticketno.Text = Trim(obj.ticketno)
                Hfattachmentpath1.Value = Trim(obj.attachmentpath1)
                Hfattachmentname1.Value = Trim(obj.attachmentname1)
                Hfattachmentpath2.Value = Trim(obj.attachmentpath2)
                Hfattachmentname2.Value = Trim(obj.attachmentname2)
                Hfattachmentpath3.Value = Trim(obj.attachmentpath3)
                Hfattachmentname3.Value = Trim(obj.attachmentname3)
                Hfattachmentpath4.Value = Trim(obj.attachmentpath4)
                Hfattachmentname4.Value = Trim(obj.attachmentname4)
                Hfattachmentpath5.Value = Trim(obj.attachmentpath5)
                Hfattachmentname5.Value = Trim(obj.attachmentname5)
                Hfattachmentpath6.Value = Trim(obj.attachmentpath6)
                Hfattachmentname6.Value = Trim(obj.attachmentname6)
                Hfattachmentpath7.Value = Trim(obj.attachmentpath7)
                Hfattachmentname7.Value = Trim(obj.attachmentname7)
                Hfattachmentpath8.Value = Trim(obj.attachmentpath8)
                Hfattachmentname8.Value = Trim(obj.attachmentname8)
                Hfattachmentpath9.Value = Trim(obj.attachmentpath9)
                Hfattachmentname9.Value = Trim(obj.attachmentname9)
                Hfattachmentpath10.Value = Trim(obj.attachmentpath10)
                Hfattachmentname10.Value = Trim(obj.attachmentname10)

                txtLink1.Text = Trim(obj.link1)
                txtLink2.Text = Trim(obj.link2)
                txtLink3.Text = Trim(obj.link3)
                txtLink4.Text = Trim(obj.link4)
                txtLink5.Text = Trim(obj.link5)
                txtcustomerinstruction.Text = Trim(obj.customerinstruction)


                lblFileUpload1.Text = Trim(obj.attachmentname1)
                lblFileUpload2.Text = Trim(obj.attachmentname2)
                lblFileUpload3.Text = Trim(obj.attachmentname3)
                lblFileUpload4.Text = Trim(obj.attachmentname4)
                lblFileUpload5.Text = Trim(obj.attachmentname5)
                lblFileUpload6.Text = Trim(obj.attachmentname6)
                lblFileUpload7.Text = Trim(obj.attachmentname7)
                lblFileUpload8.Text = Trim(obj.attachmentname8)
                lblFileUpload9.Text = Trim(obj.attachmentname9)
                lblFileUpload10.Text = Trim(obj.attachmentname10)






            End If
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        Finally
            con.Close()
            con = Nothing
        End Try
    End Sub


    Private Sub FillData(Optional pageIndex As Integer = 0)
        Try
            Dim pageSize As Integer = 10 ' Or get from a control

            ViewState("SortExpr") = sSortExp
            Dim dt1 As DataTable
            Dim objDas As New DBAccess

            Dim totalRecords As Integer = 0
            Dim params As New List(Of SqlParameter)()
            params.Add(New SqlParameter("@jobid", Trim(hdnJobId.Value)))
            params.Add(New SqlParameter("@PageNumber", pageIndex + 1))
            params.Add(New SqlParameter("@PageSize", pageSize))

            Dim totalRecordsParam As New SqlParameter("@TotalRecords", SqlDbType.Int)
            totalRecordsParam.Direction = ParameterDirection.Output
            params.Add(totalRecordsParam)

            ' Assuming Sp_jobentry_log_GetData is updated to support pagination
            dt1 = objDas.GetDataTableWithParams("Sp_jobentry_log_GetData", params.ToArray())

            If totalRecordsParam.Value IsNot DBNull.Value Then
                totalRecords = Convert.ToInt32(totalRecordsParam.Value)
            End If

            gv1.DataSource = dt1
            gv1.PageIndex = pageIndex
            gv1.VirtualItemCount = totalRecords
            gv1.DataBind()

        Catch ex As Exception
            Dim myscript As String = "alert('" & ex.Message & "');"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
        End Try
    End Sub

    Protected Sub gv1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        FillData(e.NewPageIndex)
    End Sub


    Protected Sub gv1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub OnRowDataBound_GV1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

    End Sub
    Protected Sub gv1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv1.SelectedIndexChanged

        If Trim(gv1.SelectedValue.ToString) <> "" Then
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "OpenWindow", "window.open('JobEntryLog.aspx?docno=" & Trim(gv1.SelectedValue.ToString) & "&MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "');", True)

            'Response.Redirect("JobEntryLog.aspx?docno=" & Trim(gv1.SelectedValue.ToString) & "&MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
        End If
    End Sub



    Private Sub save_add_Graphics()
        Dim strdocno As String
        Call New_Docno()
        strdocno = Trim(txtjobid.Text)

        Call Save_Data_Add_Graphics()
    End Sub

    Private Sub save_edit_Graphics()
        Call Save_Data_Edit_Graphics()
    End Sub

    Private Sub save_add_Prepress()
        Dim strdocno As String
        Call New_Docno()
        strdocno = Trim(txtjobid.Text)

        Call Save_Data_Add_Prepress()
    End Sub

    Private Sub save_edit_Prepress()
        Call Save_Data_Edit_Prepress()
    End Sub

    Private Sub btnsave_SendtoGraphics_Click(sender As Object, e As System.EventArgs) Handles btnsave_SendtoGraphics.Click
        Try
            If Trim(Request.QueryString("docno")) = "" Then
                Call save_add_Graphics()
            Else
                Call save_edit_Graphics()
            End If

        Catch ex As Exception
            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
            Exit Sub
        End Try
    End Sub

    Private Sub btnsave_SendtoPrepress_Click(sender As Object, e As System.EventArgs) Handles btnsave_SendtoPrepress.Click
        Try
            If Trim(Request.QueryString("docno")) = "" Then
                Call save_add_Prepress()
            Else
                Call save_edit_Prepress()
            End If

        Catch ex As Exception
            HFsave_value.Value = ""
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
            Exit Sub
        End Try
    End Sub

End Class