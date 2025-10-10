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

Partial Class Customer
    Inherits System.Web.UI.Page
    Dim iPage As Integer = 0
    Dim sSortExp As String = ""
    Dim strcode As String
    Dim j, e1 As Integer
    Dim NewDocCode As String
    Public Shared mode As String
    Public i, cc1 As Integer
    Dim Duplicate, DuplicatePONO As String
    Dim Attachmentfullpath As String
    Dim sFileShortName As String, sFileName As String, sUrl As String
    Public Shared AllowOrNotAuth As String
    Public Shared TempTable As New DataTable

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
            Dim dt1, dt2, dt3, dt4, dt5, dt6 As DataTable
            Dim objDas As New DBAccess
            sSQL = "SELECT ltrim(rtrim(countrycd))as countrycd,countryname From country ORDER BY countryname"
            dt1 = objDas.GetDataTable(sSQL)
            dt1.Rows.InsertAt(dt1.NewRow, 0)
            ddlcountrycd.DataSource = dt1
            ddlcountrycd.DataTextField = "countryname"
            ddlcountrycd.DataValueField = "countrycd"
            ddlcountrycd.DataBind()

            ''sSQL = "SELECT ltrim(rtrim(statecd))as statecd,statename From state ORDER BY statename"
            ''dt1 = objDas.GetDataTable(sSQL)
            ''dt1.Rows.InsertAt(dt1.NewRow, 0)
            ''ddlstatecd.DataSource = dt1
            ''ddlstatecd.DataTextField = "statename"
            ''ddlstatecd.DataValueField = "statecd"
            ''ddlstatecd.DataBind()

            'sSQL = "SELECT ltrim(rtrim(citycd))as citycd,cityname From city ORDER BY cityname"
            'dt1 = objDas.GetDataTable(sSQL)
            'dt1.Rows.InsertAt(dt1.NewRow, 0)
            'ddlcitycd.DataSource = dt1
            'ddlcitycd.DataTextField = "cityname"
            'ddlcitycd.DataValueField = "citycd"
            'ddlcitycd.DataBind()

        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub
    Private Sub Refresh()
        ErrorMSG.Text = ""
        ErrorMSG.Visible = False
        HFcuscode.Value = ""
        txtcusname.Text = ""
        txtadd1.Text = ""
        txtadd2.Text = ""
        txtadd3.Text = ""
        txtpincode.Text = ""
        ddlcitycd.Text = ""

        'txtCountrycd.Text = ""
        'txtStatecd.Text = ""
        ddlstatecd.Text = ""
        ddlcountrycd.Text = ""
        txtemailid.Text = ""
        txtmobileno.Text = ""

    End Sub

    Private Sub setReadOnly()
        'txtvchtype.Attributes.Add("Readonly", "Readonly")
    End Sub

    'Private Sub Set_UserAccessRights()
    '    Try
    '        AllowOrNotAuth = ""
    '        Dim c As New DBAccess.Accessbuttons
    '        c = DBAccess.Accessright(Trim(Session.Item("UserID")), Trim(""))

    '        If mode = "Add" Then
    '            btnDelete.Visible = False

    '        Else
    '            If c.allow_del = True Then
    '                btnDelete.Visible = True
    '            Else
    '                btnDelete.Visible = False
    '            End If
    '            If c.allow_san = True Then

    '                AllowOrNotAuth = "Yes"
    '            Else
    '                AllowOrNotAuth = "No"
    '            End If
    '            If c.allow_prev = True Then
    '                'btnPreview.Visible = True
    '            Else
    '                'btnPreview.Visible = False
    '            End If
    '        End If

    '        If mode = "Add" Then
    '            If c.allow_add = True Then
    '                btnSave.Visible = True
    '            Else
    '                btnSave.Visible = False
    '            End If
    '        End If

    '        If mode <> "Add" Then
    '            If c.allow_mod = True Then
    '                btnSave.Visible = True
    '            Else
    '                btnSave.Visible = False
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Session("UserName") Is Nothing) Then
                Response.Redirect("~/SessionExpired.aspx")
            End If

            If Not IsPostBack Then
                ErrorMSG.Text = ""
                Fillcombo()

                setReadOnly()
                If Request.QueryString("docno") = "" Then
                    mode = "Add"
                    Refresh()
                    HFcuscode.Value = ClsCustomer.GetDocCode
                    btnDelete.Enabled = False
                    txtcusname.Focus()
                    Paneluserdtls.Visible = False
                Else
                    mode = "Modify"
                    HFcuscode.Value = Request.QueryString("docno")
                    DisplayData(HFcuscode.Value)
                    txtcusname.Focus()
                    set_doc_details(HFcuscode.Value)
                End If
            End If
            'Set_UserAccessRights()
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Private Sub set_doc_details(ByVal docno As String)
        Dim o As New DBAccess, dt As DataTable, sql As String
        sql = "select h.cuscode,cr.u_name as crtuserid,convert(char(10),h.crtuserdt,103) as crtuserdt,md.u_name as moduserid,convert(char(10),h.moduserdt,103)as moduserdt "
        sql += "from customer h left join users cr on h.crtuserid=cr.u_id "
        sql += "left join users md on h.moduserid=md.u_id where h.cuscode='" & Trim(docno) & "'"
        dt = o.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            lblcrtuserid.Text = Trim(dt.Rows(0)("crtuserid").ToString)
            lblcrtuserdt.Text = Trim(dt.Rows(0)("crtuserdt").ToString)
            lblmoduserid.Text = Trim(dt.Rows(0)("moduserid").ToString)
            lblmoduserdt.Text = Trim(dt.Rows(0)("moduserdt").ToString)
        Else
            lblcrtuserid.Text = ""
            lblcrtuserdt.Text = ""
            lblmoduserid.Text = ""
            lblmoduserdt.Text = ""
        End If
    End Sub



    Private Sub DisplayData(ByVal cuscode As String)
        Try
            Dim obj As ClsCustomer = ClsCustomer.FillData(cuscode, "B")
            If Not IsNothing(obj) Then
                HFcuscode.Value = obj.cuscode
                txtcusname.Text = Trim(obj.cusname)
                txtadd1.Text = Trim(obj.add1)
                txtadd2.Text = Trim(obj.add2)
                txtadd3.Text = Trim(obj.add3)
                txtpincode.Text = Trim(obj.pincode)
                ddlcountrycd.SelectedItem.Selected = False
                ddlcountrycd.Items.FindByValue(Trim(obj.countrycd)).Selected = True
                FillStatecdcombo()
                ddlstatecd.SelectedItem.Selected = False
                ddlstatecd.Items.FindByValue(Trim(obj.statecd)).Selected = True
                FillCitycdcombo()
                ddlcitycd.SelectedItem.Selected = False
                ddlcitycd.Items.FindByValue(Trim(obj.citycd)).Selected = True

                'HFcitycd.Value = Trim(obj.citycd)
                'ddlcitycd.SelectedItem.Selected = False
                'ddlcitycd.Items.FindByValue(obj.citycd).Selected = True
                'HFcountrycd.Value = Trim(obj.countrycd)
                'txtCountrycd.Text = Trim(ClsCustomer.Find_countrycdCode(Trim(HFcountrycd.Value)))
                'HFstatecd.Value = Trim(obj.statecd)
                'txtStatecd.Text = Trim(ClsCustomer.Find_statecdCode(Trim(HFstatecd.Value)))
                txtemailid.Text = Trim(obj.emailid)
                txtmobileno.Text = Trim(obj.mobileno)
                txtgstno.Text = Trim(obj.Gstno)

            End If
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Private Sub Save_Data()
        Try
            Dim obj As New ClsCustomer, objDas As New DBAccess
            obj.cuscode = Trim(HFcuscode.Value)
            obj.cusname = Trim(txtcusname.Text)
            obj.emailid = Trim(txtemailid.Text)
            obj.mobileno = Trim(txtmobileno.Text)
            obj.citycd = Trim(ddlcitycd.SelectedItem.Value)
            obj.statecd = Trim(ddlstatecd.SelectedItem.Value)
            obj.countrycd = Trim(ddlcountrycd.SelectedItem.Value)
            obj.add1 = Trim(txtadd1.Text)
            obj.add2 = Trim(txtadd2.Text)
            obj.add3 = Trim(txtadd3.Text)
            obj.pincode = Trim(txtpincode.Text)


            obj.crtuserid = Trim(Session.Item("UserID"))
            obj.crtuserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.moduserid = Trim(Session.Item("UserID"))
            obj.moduserdt = (Format(Now.Date, "dd/MM/yyyy"))
            obj.Gstno = Trim(txtgstno.Text)


            If mode = "Add" Then
                obj.cuscode = ClsCustomer.GetDocCode
                If Check_Duplicate() = True Then
                    ErrorMSG.Visible = True
                    ErrorMSG.Text = "'" & txtcusname.Text & "' Already Exist"
                    Exit Try

                Else
                    ClsCustomer.Update_Data(obj, "ADD")
                    'Call UploadAllAttechments()

                    Call Refresh()
                    HFcuscode.Value = ClsCustomer.GetDocCode

                    Response.Write("<script>alert('Details Saved Succesfully'); ")
                    Response.Write("window.location='CustomerSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
                End If
            Else
                If Check_Duplicate() = True Then
                    ErrorMSG.Visible = True
                    ErrorMSG.Text = "'" & txtcusname.Text & "' Already Exist"
                    Exit Try
                Else
                    ClsCustomer.Update_Data(obj, "EDIT")
                    'Call UploadAllAttechments()

                    Response.Write("<script>alert('Details Saved Succesfully'); ")
                    Response.Write("window.location='CustomerSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
                End If
            End If

        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
            Exit Sub
        End Try
    End Sub

    'Protected Sub UploadAllAttechments()
    '    ErrorMSG.Text = ""
    '    Try
    '        ''Save Image Name in Database And Image to ImageFolder in Server
    '        If FileUploadAttachment.HasFile Then
    '            ''Get Filename from fileupload control
    '            Dim Filename As String
    '            Filename = Path.GetFileName(FileUploadAttachment.PostedFile.FileName)
    '            ''//Save images into Images folder
    '            FileUploadAttachment.SaveAs(Server.MapPath("Attachments/" + Filename))
    '            ''
    '            Dim obj As New ClsStoreSupplier, objDas As New DBAccess
    '            obj.suppcd = objDas.FilteredString(HFSupplierCode.Value)
    '            obj.AttachmentName = objDas.FilteredString(Filename)
    '            obj.AttachmentPath = objDas.FilteredString("Attachments/" + Filename)
    '            ClsStoreSupplier.UploadAttechment(obj)
    '        End If
    '    Catch ex As Exception
    '        ErrorMSG.Text = ex.Message
    '        Exit Sub
    '    End Try
    'End Sub

    Public Function Check_Duplicate() As Boolean
        Check_Duplicate = False
        strcode = ClsCustomer.CheckDuplicate(txtcusname.Text).ToString
        If Trim(strcode) <> Trim(HFcuscode.Value) And strcode <> "" Then
            Return True
        Else
            Return False
            Exit Function
        End If
    End Function

    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        Call Save_Data()
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If Trim(HFcuscode.Value) = "" Then
                Exit Sub
            End If

            If HFcuscode.Value <> "" Then
                Dim str As String
                str = ClsCustomer.Check_Integrity(HFcuscode.Value).ToString.Trim
                If str <> "" Then
                    Dim myscript As String = "alert('Customer Being Used In " & Trim(str) & "');"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                    str = ""
                    Exit Sub
                End If
                If mode <> "Add" Then
                    Dim obj As New ClsCustomer
                    obj.cuscode = HFcuscode.Value
                    ClsCustomer.Delete(obj)
                    Response.Redirect("CustomerSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
                End If
            End If
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("CustomerSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
    End Sub

    Protected Sub txtmobileno_TextChanged(sender As Object, e As System.EventArgs) Handles txtmobileno.TextChanged
        If Trim(txtmobileno.Text.Count) < 10 Then
            txtmobileno.Text = ""
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "selectAndFocus", "$get('" + txtmobileno.ClientID + "').focus();$get('" + txtmobileno.ClientID + "').select();", True)
            Dim myscript As String = "alert('GST No already exist');"

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscript", myscript, True)
        Else
            'txtOffice1.Focus()
        End If
    End Sub

    Protected Sub txtgstno_TextChanged(sender As Object, e As System.EventArgs) Handles txtgstno.TextChanged
        If Trim(txtgstno.Text.Count) < 10 Then
            txtgstno.Text = ""
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "selectAndFocus", "$get('" + txtgstno.ClientID + "').focus();$get('" + txtgstno.ClientID + "').select();", True)
            Dim myscript As String = "alert('Invalid Gst No');"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscript", myscript, True)
        Else
            'txtOffice1.Focus()
        End If
    End Sub

    'Protected Sub txtGSTINOld_TextChanged(sender As Object, e As EventArgs)

    '    If Trim(txtgstno.Text).Count < 15 Then
    '        txtgstno.Text = ""

    '        Dim myscript As String = "alert('Please enter Valid GSTIN');"
    '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
    '        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscript", myscript, True)
    '        Exit Sub
    '    End If

    '    Dim sSQL As String, objDas As New DBAccess, dt1 As DataTable
    '    sSQL = "select gststatecd from gststate where statecode='" & txtgstno.Text.Substring(0, 2) & "' "
    '    dt1 = objDas.GetDataTable(sSQL)
    '    'If dt1.Rows.Count > 0 Then
    '    '    ddlgststatecd.SelectedItem.Selected = False
    '    '    ddlgststatecd.Items.FindByValue(dt1.Rows(0)("gststatecd").ToString).Selected = True
    '    '    txtgststatcode.Text = txtgstno.Text.Substring(0, 2)
    '    'End If
    'End Sub
    Private Sub FillStatecdcombo()
        'Try
        If ddlcountrycd.Text <> "" Then

            Dim sSQL As String
            Dim dt7 As DataTable
            Dim objDas As New DBAccess

            sSQL = "SELECT ltrim(rtrim(statecd)) as statecd, statename From state where countrycd='" & Trim(ddlcountrycd.SelectedItem.Value) & "'  ORDER BY statename "
            dt7 = objDas.GetDataTable(sSQL)
            dt7.Rows.InsertAt(dt7.NewRow, 0)
            ddlstatecd.DataSource = dt7
            ddlstatecd.DataTextField = "statename"
            ddlstatecd.DataValueField = "statecd"
            ddlstatecd.DataBind()
        Else
            ddlstatecd.Text = ""
            ddlcitycd.Text = ""
        End If


        'Catch ex As Exception
        '    ErrorMSG.Visible = True
        '    ErrorMSG.Text = ""
        '    ErrorMSG.Text = ex.Message
        'End Try
    End Sub


    Protected Sub ddlcountrycd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlcountrycd.SelectedIndexChanged
        FillStatecdcombo()
        FillCitycdcombo()
    End Sub

    Private Sub FillCitycdcombo()
        'Try
        If ddlcountrycd.Text <> "" And ddlstatecd.Text <> "" Then

            Dim sSQL As String
            Dim dt7 As DataTable
            Dim objDas As New DBAccess

            sSQL = "SELECT ltrim(rtrim(citycd)) as citycd, cityname From city where countrycd='" & Trim(ddlcountrycd.SelectedItem.Value) & "' and statecd='" & Trim(ddlstatecd.SelectedItem.Value) & "'  ORDER BY cityname "
            dt7 = objDas.GetDataTable(sSQL)
            dt7.Rows.InsertAt(dt7.NewRow, 0)
            ddlcitycd.DataSource = dt7
            ddlcitycd.DataTextField = "cityname"
            ddlcitycd.DataValueField = "citycd"
            ddlcitycd.DataBind()
        Else
            ddlcitycd.Text = ""
        End If


        'Catch ex As Exception
        '    ErrorMSG.Visible = True
        '    ErrorMSG.Text = ""
        '    ErrorMSG.Text = ex.Message
        'End Try
    End Sub


    Protected Sub ddlstatecd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlstatecd.SelectedIndexChanged
        FillCitycdcombo()
    End Sub


    'Protected Sub txtcity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcitycd.SelectedIndexChanged
    '    If ddlcitycd.Text <> "" Then
    '        HFcitycd.Value = Trim(ddlcitycd.SelectedItem.Value)
    '        If HFcitycd.Value = "" Then
    '            HFcitycd.Value = ""
    '            ddlcitycd.Text = ""
    '            HFstatecd.Value = ""
    '            txtStatecd.Text = ""
    '            HFcountrycd.Value = ""
    '            txtCountrycd.Text = ""


    '            'txtCitycd.Focus()
    '        Else
    '            GetCityDetails()
    '            'txtPincode.Focus()
    '        End If
    '    Else
    '        HFcitycd.Value = ""
    '        ddlcitycd.Text = ""
    '        HFstatecd.Value = ""
    '        txtStatecd.Text = ""
    '        HFcountrycd.Value = ""
    '        txtCountrycd.Text = ""


    '        'txtCitycd.Focus()
    '        Exit Sub
    '    End If
    'End Sub

    'Private Sub GetCityDetails()
    '    Try
    '        ClsCustomer.FillCityDetails(HFcitycd.Value)
    '        HFstatecd.Value = Trim(ClsCustomer.statecd1)
    '        txtStatecd.Text = Trim(ClsCustomer.Find_statecdCode(Trim(ClsCustomer.statecd1)))
    '        HFcountrycd.Value = Trim(ClsCustomer.countrycd1)
    '        txtCountrycd.Text = Trim(ClsCustomer.Find_countrycdCode(Trim(ClsCustomer.countrycd1)))



    '        'txtLSTNo.Focus()
    '    Catch ex As Exception
    '        ErrorMSG.Visible = True
    '        ErrorMSG.Text = ""
    '        ErrorMSG.Text = ex.Message
    '    End Try
    'End Sub


End Class

