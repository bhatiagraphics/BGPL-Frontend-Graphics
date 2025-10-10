Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Partial Class DispatchLanding
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
            ddlassignedto_challan.DataSource = dt3
            ddlassignedto_challan.DataTextField = "u_name"
            ddlassignedto_challan.DataValueField = "u_id"
            ddlassignedto_challan.DataBind()



            sSQL = "select ltrim(rtrim(platetypecd))as platetypecd,ltrim(rtrim(platetypename))as platetypename from platetype order by platetypename"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlplatetypecd.DataSource = dt3
            ddlplatetypecd.DataTextField = "platetypename"
            ddlplatetypecd.DataValueField = "platetypecd"
            ddlplatetypecd.DataBind()

            sSQL = "select ltrim(rtrim(opcode))as opcode,ltrim(rtrim(opname))as opname from operator order by opname"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlopcode.DataSource = dt3
            ddlopcode.DataTextField = "opname"
            ddlopcode.DataValueField = "opcode"
            ddlopcode.DataBind()

            sSQL = "select ltrim(rtrim(printercd))as printercd,ltrim(rtrim(printername))as printername from printer order by printername"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlprintercd.DataSource = dt3
            ddlprintercd.DataTextField = "printername"
            ddlprintercd.DataValueField = "printercd"
            ddlprintercd.DataBind()

            sSQL = "select ltrim(rtrim(transcd))as transcd,ltrim(rtrim(transname))as transname from transport order by transname"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddltranscd.DataSource = dt3
            ddltranscd.DataTextField = "transname"
            ddltranscd.DataValueField = "transcd"
            ddltranscd.DataBind()

            sSQL = "select ltrim(rtrim(compcd))as compcd,ltrim(rtrim(compname))as compname from Company_PPC order by compname"
            dt3 = objDas.GetDataTable(sSQL)
            dt3.Rows.InsertAt(dt3.NewRow, 0)
            ddlcompcd.DataSource = dt3
            ddlcompcd.DataTextField = "compname"
            ddlcompcd.DataValueField = "compcd"
            ddlcompcd.DataBind()


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
        ddlassignedto_challan.Text = ""
        txtticketno.Text = ""
        ddltranscd.Text = ""
        ddlcompcd.Text = ""


    End Sub

    Protected Sub New_Docno()
        Try
            j = clsDispatchLanding.Fetch_Paramno("")
            txtjobid.Text = clsDispatchLanding.Generate_Docno(j, "", "").ToString.Trim
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

            'Else
            '    If c.allow_del = True Then
            '    Else
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
                    txtjobcreatedt.Focus()
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


    Private Sub DisplayData(ByVal geno As String)
        Dim con As SqlConnection
        Dim com As SqlCommand
        Dim ds As DataSet
        Dim dtdet As New DataTable
        con = clsDispatchLanding.GetConnection()
        com = clsDispatchLanding.GetCommand
        com.Connection = con
        com.CommandType = CommandType.Text
        Try
            Dim obj As clsDispatchLanding = clsDispatchLanding.FillData(geno, "B")
            If Not IsNothing(obj) Then
                txtjobid.Text = Trim(obj.jobid)
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
                ddlassignedto_challan.SelectedItem.Selected = False
                ddlassignedto_challan.Items.FindByValue(Trim(obj.assignedto_challan)).Selected = True
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

                ddlplatetypecd.SelectedItem.Selected = False
                ddlplatetypecd.Items.FindByValue(Trim(obj.platetypecd)).Selected = True
                txtnoofplates.Text = Trim(obj.noofplates)

                ddlopcode.SelectedItem.Selected = False
                ddlopcode.Items.FindByValue(Trim(obj.opcode)).Selected = True

                txtlength_plate_cms.Text = Trim(obj.length_plate_cms)
                txtwidth_plate_cms.Text = Trim(obj.width_plate_cms)
                txtchlno.Text = Trim(obj.chlno)
                txtchldt.Text = Trim(obj.chldt)
                'txtbillno.Text = Trim(obj.billno)
                'txtBilldate.Text = Trim(obj.billdate)
                txtsendfor_dispatch_comments.Text = Trim(obj.sendfor_dispatch_comments)




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

                'If Trim(obj.sendfor_dispatch_flag) = "1" Then
                '    ' btnsendToDispatch.Visible = False
                '    btnSave.Visible = False
                '    btnSave.Visible = False
                'End If
                ddlprintercd.SelectedItem.Selected = False
                ddlprintercd.Items.FindByValue(Trim(obj.printercd)).Selected = True

                txtplate_processed_date.Text = Trim(obj.plate_processed_date)
                ddltranscd.SelectedItem.Selected = False
                ddltranscd.Items.FindByValue(Trim(obj.transcd)).Selected = True

                ddlcompcd.SelectedItem.Selected = False
                ddlcompcd.Items.FindByValue(Trim(obj.compcd)).Selected = True
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
        Dim c As New clsDispatchLanding
        Dim i As Integer

        Dim ds As DataSet
        Dim dtdet As New DataTable
        Dim dr As DataRow

        con = clsDispatchLanding.GetConnection()
        com = clsDispatchLanding.GetCommand

        com.Connection = con
        com.CommandType = CommandType.Text

        Try
            Dim obj As New clsDispatchLanding, objDas As New DBAccess
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
            obj.assignedto_challan = ddlassignedto_challan.SelectedValue
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

            obj.transcd = Trim(ddltranscd.SelectedValue)
            obj.compcd = Trim(ddlcompcd.SelectedValue)


            obj.crtuserid = Trim(Session.Item("UserID"))
            obj.crtuserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.moduserid = Trim(Session.Item("UserID"))
            obj.moduserdt = (Format(Now.Date, "dd/MM/yyyy"))

            clsDispatchLanding.Update_Data_Add(obj, j, mode, "")

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
        Dim c As New clsDispatchLanding
        Dim i As Integer

        Dim ds As DataSet
        Dim dtdet As New DataTable
        Dim dr As DataRow

        con = clsDispatchLanding.GetConnection()
        com = clsDispatchLanding.GetCommand

        com.Connection = con
        com.CommandType = CommandType.Text

        Try
            Dim obj As New clsDispatchLanding, objDas As New DBAccess
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
            obj.assignedto_challan = ddlassignedto_challan.SelectedValue
            obj.ticketno = txtticketno.Text
            obj.originaljobid = Trim(txtjobid.Text)
            obj.jobversion = 0

            obj.sendfor_dispatch_comments = Trim(txtsendfor_dispatch_comments.Text)
            obj.plate_processed_date = objDas.FilteredString(txtplate_processed_date.Text)


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

            obj.platetypecd = ddlplatetypecd.SelectedValue
            obj.noofplates = txtnoofplates.Text
            obj.opcode = ddlopcode.SelectedValue

            obj.length_plate_cms = txtlength_plate_cms.Text
            obj.width_plate_cms = txtwidth_plate_cms.Text
            obj.chlno = txtchlno.Text
            obj.chldt = txtchldt.Text
            'obj.billno = txtbillno.Text
            'obj.billdate = txtBilldate.Text
            obj.transcd = Trim(ddltranscd.SelectedValue)
            obj.compcd = Trim(ddlcompcd.SelectedValue)


            obj.crtuserid = Trim(Session.Item("UserID"))
            obj.crtuserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.moduserid = Trim(Session.Item("UserID"))
            obj.moduserdt = (Format(Now.Date, "dd/MM/yyyy"))

            clsDispatchLanding.Update_Data_Edit(obj, j, mode, "")

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
        ErrorMSG.Text = ""
        Call Save_Data_Edit()
        If ErrorMSG.Text = "" Then
            Response.Write("<script>alert('Details Saved Succesfully'); ")
            Response.Write("window.location='DispatchLandingSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
        End If
    End Sub




    'Protected Sub btnSendToGrphics_Click(sender As Object, e As System.EventArgs) Handles btnsendToDispatch.Click
    '    Try
    '        Call Save_Data_Edit()
    '        Dim sSQL As String
    '        Dim dt1, dt2, dt3 As DataTable
    '        Dim objDas As New DBAccess
    '        sSQL = "update jobentry set sendfor_dispatch_flag='1',sendfor_dispatch_uid='" & Trim(Session.Item("UserID")) & "',sendfor_dispatch_udt=GetDate(),sendfor_dispatch_comments='" & txtsendfor_dispatch_comments.Text & "',assignedto_challan='" & Trim(ddlassignedto_challan.SelectedValue) & "',assignedto_dispatch='" & Trim(ddlassignedto_challan.SelectedValue) & "',assignedto_billing='" & Trim(ddlassignedto_challan.SelectedValue) & "',transcd='" & Trim(ddltranscd.SelectedValue) & "'  where jobid='" & txtjobid.Text & "'"
    '        dt1 = objDas.GetDataTable(sSQL)
    '        Response.Write("<script>alert('Send To Dispatch Succesfully'); ")
    '        Response.Write("window.location='DispatchLandingSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")

    '    Catch ex As Exception
    '        ErrorMSG.Visible = True
    '        ErrorMSG.Text = ""
    '        ErrorMSG.Text = ex.Message
    '    End Try
    'End Sub



    Protected Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnclose.Click
        Response.Redirect("DispatchLandingSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
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
End Class