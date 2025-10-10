Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports System.IO
Imports System.Web.Services
Imports System.Net

Partial Class UserMaster
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

            sSQL = "SELECT ltrim(rtrim(desigcd)) as desigcd, designame From designation ORDER BY designame "
            dt4 = objDas.GetDataTable(sSQL)
            dt4.Rows.InsertAt(dt4.NewRow, 0)
            ddldesigcd.DataSource = dt4
            ddldesigcd.DataTextField = "designame"
            ddldesigcd.DataValueField = "desigcd"
            ddldesigcd.DataBind()

            sSQL = "SELECT Ltrim(Rtrim(u_id)) as u_id, Concat(LTrim(RTrim(u_name)),' ', Ltrim(Rtrim(lastname))) as u_name From users ORDER BY u_name "
            dt1 = objDas.GetDataTable(sSQL)
            dt1.Rows.InsertAt(dt1.NewRow, 0)
            ddlReportingTo.DataSource = dt1
            ddlReportingTo.DataTextField = "u_name"
            ddlReportingTo.DataValueField = "u_id"
            ddlReportingTo.DataBind()

        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub
    Private Sub Refresh()
        ErrorMSG.Text = ""
        ErrorMSG.Visible = False
        HFu_id.Value = ""
        txtu_id.Text = ""
        txtu_name.Text = ""
        txtlastname.Text = ""
        txtpass.Text = ""
        ddldesigcd.Text = ""
        ddlReportingTo.Text = ""

        chkactive.Checked = True
        chkadministrator.Checked = False
        chkallowbilling.Checked = False
        chkallowbilldone_close.Checked = False

        txtmobileno.Text = ""
        txtemailid.Text = ""
        txtlastpasschangedt.Text = ""

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
                    'HFu_id.Value = Generate_u_id(txtu_id.Text)
                    btnDelete.Enabled = False
                    txtu_name.Focus()
                    ' Paneluserdtls.Visible = False
                Else
                    mode = "Modify"
                    HFu_id.Value = Request.QueryString("docno")
                    DisplayData(HFu_id.Value)
                    txtu_name.Focus()
                    'set_doc_details(HFu_id.Value)
                End If
            End If
            'Set_UserAccessRights()
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    'Private Sub set_doc_details(ByVal docno As String)
    '    Dim o As New DBAccess, dt As DataTable, sql As String
    '    sql = "select h.u_id,cr.u_name as crtuserid,convert(char(10),h.crtuserdt,103) as crtuserdt,md.u_name as moduserid,convert(char(10),h.moduserdt,103)as moduserdt "
    '    sql += "from users h left join users cr on h.crtuserid=cr.u_id "
    '    sql += "left join users md on h.moduserid=md.u_id where h.u_id='" & Trim(docno) & "'"
    '    dt = o.GetDataTable(sql)
    '    If dt.Rows.Count > 0 Then
    '        lblcrtuserid.Text = Trim(dt.Rows(0)("crtuserid").ToString)
    '        lblcrtuserdt.Text = Trim(dt.Rows(0)("crtuserdt").ToString)
    '        lblmoduserid.Text = Trim(dt.Rows(0)("moduserid").ToString)
    '        lblmoduserdt.Text = Trim(dt.Rows(0)("moduserdt").ToString)
    '    Else
    '        lblcrtuserid.Text = ""
    '        lblcrtuserdt.Text = ""
    '        lblmoduserid.Text = ""
    '        lblmoduserdt.Text = ""
    '    End If
    'End Sub



    Private Sub DisplayData(ByVal u_id As String)
        Try
            Dim obj As ClsUserMaster = ClsUserMaster.FillData(u_id, "B")
            If Not IsNothing(obj) Then

                If obj.u_name = "" Then
                    txtu_name.Text = ""
                Else
                    txtu_name.Text = Trim(obj.u_name)
                End If

                If obj.lastname = "" Then
                    txtlastname.Text = ""
                Else
                    txtlastname.Text = Trim(obj.lastname)
                End If
                HFu_id.Value = obj.u_id
                txtu_id.Text = Trim(obj.u_id)

                txtpass.Text = Trim(obj.pass)
                ddldesigcd.SelectedItem.Selected = False
                ddldesigcd.Items.FindByValue(Trim(obj.desigcd)).Selected = True

                ddlReportingTo.SelectedItem.Selected = False
                ddlReportingTo.Items.FindByValue(Trim(obj.reportingto)).Selected = True
                txtmobileno.Text = Trim(obj.mobileno)
                txtemailid.Text = Trim(obj.emailid)
                txtlastpasschangedt.Text = Trim(obj.lastpasschangedt)
                If Trim(obj.active) = "0" Then
                    chkactive.Checked = False
                Else
                    chkactive.Checked = True
                End If

                If Trim(obj.administrator) = "" Or Trim(obj.administrator) = "0" Then
                    chkadministrator.Checked = False
                Else
                    chkadministrator.Checked = True
                End If

                If Trim(obj.allowbilling) = "" Or Trim(obj.allowbilling) = "0" Then
                    chkallowbilling.Checked = False
                Else
                    chkallowbilling.Checked = True
                End If

                If Trim(obj.allowbilldone_close) = "" Or Trim(obj.allowbilldone_close) = "0" Then
                    chkallowbilldone_close.Checked = False
                Else
                    chkallowbilldone_close.Checked = True
                End If

            End If
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Private Sub Save_Data()
        Try
            Dim obj As New ClsUserMaster, objDas As New DBAccess

            obj.u_name = Trim(txtu_name.Text)
            obj.lastname = Trim(txtlastname.Text)
            obj.u_id = Trim(HFu_id.Value)

            obj.u_id = Trim(txtu_id.Text)

            obj.desigcd = Trim(ddldesigcd.SelectedItem.Value)
            obj.reportingto = Trim(ddlReportingTo.SelectedItem.Value)
            obj.pass = Trim(txtpass.Text)

            obj.mobileno = Trim(txtmobileno.Text)
            obj.emailid = Trim(txtemailid.Text)
            obj.lastpasschangedt = Trim(txtlastpasschangedt.Text)
            If chkactive.Checked = False Then
                obj.active = "0"
            Else
                obj.active = "1"
            End If

            If chkadministrator.Checked = False Then
                obj.administrator = "0"
            Else
                obj.administrator = "1"
            End If

            If chkallowbilling.Checked = False Then
                obj.allowbilling = "0"
            Else
                obj.allowbilling = "1"
            End If
            If chkallowbilldone_close.Checked = False Then
                obj.allowbilldone_close = "0"
            Else
                obj.allowbilldone_close = "1"
            End If
            If mode = "Add" Then
                'obj.u_id = ClsUserMaster.GetDocCode
                If Check_Duplicate_UserID() = True Then
                    HFu_id.Value = ""
                    ErrorMSG.Visible = True
                    ErrorMSG.Text = "'" & txtu_id.Text & "' Already Exist"
                    Exit Try

                Else
                    ClsUserMaster.Update_Data(obj, "ADD")
                    Call Refresh()
                    'HFu_id.Value = ClsUserMaster.GetDocCode
                    Response.Write("<script>alert('Details Saved Succesfully'); ")
                    Response.Write("window.location='UserMasterSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
                End If
            Else
                'If Check_Duplicate_UserID() = True Then
                '    ErrorMSG.Visible = True
                '    ErrorMSG.Text = "'" & txtu_id.Text & "' Already Exist"
                '    Exit Try
                'Else
                ClsUserMaster.Update_Data(obj, "EDIT")
                    Response.Write("<script>alert('Details Saved Succesfully'); ")
                    Response.Write("window.location='UserMasterSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "'</script>")
                'End If
            End If

        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
            Exit Sub
        End Try
    End Sub

    Public Function Check_Duplicate_UserID() As Boolean
        Check_Duplicate_UserID = False
        strcode = ClsUserMaster.CheckDuplicate_User(txtu_id.Text).ToString
        If Trim(strcode) <> Trim("") And strcode <> "" Then
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
            If Trim(HFu_id.Value) = "" Then
                Exit Sub
            End If

            If HFu_id.Value <> "" Then
                Dim str As String
                str = ClsUserMaster.Check_Integrity(HFu_id.Value).ToString.Trim
                If str <> "" Then
                    Dim myscript As String = "alert('User Being Used In " & Trim(str) & "');"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                    str = ""
                    Exit Sub
                End If
                If mode <> "Add" Then
                    Dim obj As New ClsUserMaster
                    obj.u_id = HFu_id.Value
                    ClsUserMaster.Delete(obj)
                    Response.Redirect("UserMasterSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
                End If
            End If
        Catch ex As Exception
            ErrorMSG.Visible = True
            ErrorMSG.Text = ""
            ErrorMSG.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("UserMasterSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")) & "")
    End Sub

    'Protected Sub ddlReportingTo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlReportingTo.SelectedIndexChanged
    '    filluserid()
    'End Sub

    'Private Sub filluserid()
    '    Dim obj As New ClsUserMaster, objDas As New DBAccess
    '    Dim sSQL As String, dt As DataTable
    '    If ddlReportingTo.Text <> "" Then
    '        'sSQL = "Select u_id from hremployee Where empcd = '" & Trim(ddlReportingTo.SelectedValue.ToString) & "'"
    '        sSQL = "Select u_id From users"
    '        dt = objDas.GetDataTable(sSQL)
    '        If dt.Rows.Count > 0 Then
    '            txtu_id.Text = Trim(dt.Rows(0)("u_id").ToString)
    '            'txtReportingtoempDesig.Text = Trim(dt.Rows(0)("DesignationName").ToString)
    '        Else
    '            txtu_id.Text = ""
    '            'txtReportingtoempDesig.Text = ""
    '        End If
    '    Else
    '        txtu_id.Text = ""
    '        'txtReportingtoempDesig.Text = ""
    '    End If
    'End Sub

    Public Shared Function Generate_u_id(ByVal str As String) As String
        Dim sSQL As String, objDas As New DBAccess, dt As DataTable
        sSQL = "select MAX(CAST(SUBSTRING(u_id, PATINDEX('%[0-9]%', u_id), LEN(u_id))AS INT))AS u_id from users where u_id <>'ADMIN' and u_id <>'DemoBC' and u_id <>'jb' and len(u_id)>2"
        dt = objDas.GetDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0).Item("u_id")) Then
                If dt.Rows(0).Item("u_id").ToString <> "" Then
                    Generate_u_id = dt.Rows(0)("u_id").ToString + 1
                Else
                    Generate_u_id = 1
                End If
            Else
                Generate_u_id = 1
            End If
        End If
        Return str & DocumentSrno(Generate_u_id, 3)
    End Function

    Public Shared Function Generate_pass(ByVal str As String) As String
        Return str & "$123"
    End Function

    Public Shared Function DocumentSrno(ByVal p As Integer, ByVal strlen As Integer) As String
        If strlen > Len(CStr(p)) Then
            DocumentSrno = StrDup(strlen - Len(CStr(p)), "0") + CStr(p)
        Else
            DocumentSrno = CStr(p)
        End If
    End Function

    Public Shared Function CheckDupOfEmail2(ByVal u_name As String, ByVal LastName As String) As String
        Dim sSQL As String, objDas As New DBAccess, dt As DataTable
        sSQL = "Select Count(u_id) as u_id From users Where u_name = '" & Trim(u_name) & "' And lastname = '" & Trim(LastName) & "' "
        dt = objDas.GetDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0).Item("u_id")) Then
                If dt.Rows(0).Item("u_id").ToString <> "" Then
                    If dt.Rows(0)("u_id").ToString = 0 Then
                        CheckDupOfEmail2 = ""
                    Else
                        CheckDupOfEmail2 = dt.Rows(0)("u_id").ToString
                    End If
                Else
                    CheckDupOfEmail2 = ""
                End If
            Else
                CheckDupOfEmail2 = ""
            End If
        End If
        Return CheckDupOfEmail2
    End Function

    Protected Sub txtu_name_TextChanged(sender As Object, e As System.EventArgs) Handles txtu_name.TextChanged
        If Trim(HFu_id.Value) = "" Then
            txtu_id.Text = Generate_u_id(Left(Trim(txtu_name.Text), 1) & Left(Trim(txtlastname.Text), 1)).Replace(" ", "").ToLower
            txtpass.Text = Generate_pass(Left(Trim(txtu_name.Text), 1) & Left(Trim(txtlastname.Text), 1)).Replace(" ", "").ToLower
            'HFEmial2Count.Value = Trim(Trim(txtempname.Text) + "." + Trim(txtLastName.Text) + "@jaewoomachines.com").Replace(" ", "").ToLower
            'txtEmail2.Text = Trim(Trim(txtempname.Text) + "." + Trim(txtLastName.Text) + Trim(CheckDupOfEmail2(Trim(txtempname.Text), Trim(txtLastName.Text)) + "@jaewoomachines.com")).Replace(" ", "").ToLower
        End If
    End Sub

    Protected Sub txtlast_name_TextChanged(sender As Object, e As System.EventArgs) Handles txtlastname.TextChanged
        If Trim(HFu_id.Value) = "" Then
            txtu_id.Text = Generate_u_id(Left(Trim(txtu_name.Text), 1) & Left(Trim(txtlastname.Text), 1)).Replace(" ", "").ToLower
            txtpass.Text = Generate_pass(Left(Trim(txtu_name.Text), 1) & Left(Trim(txtlastname.Text), 1)).Replace(" ", "").ToLower
            'HFEmial2Count.Value = Trim(Trim(txtempname.Text) + "." + Trim(txtLastName.Text) + "@jaewoomachines.com").Replace(" ", "").ToLower
            'txtEmail2.Text = Trim(Trim(txtempname.Text) + "." + Trim(txtLastName.Text) + Trim(CheckDupOfEmail2(Trim(txtempname.Text), Trim(txtLastName.Text)) + "@jaewoomachines.com")).Replace(" ", "").ToLower
        End If
    End Sub

    Protected Sub txtmobileno_TextChanged(sender As Object, e As System.EventArgs) Handles txtmobileno.TextChanged
        If Trim(txtmobileno.Text.Count) < 10 Then
            txtmobileno.Text = ""
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "selectAndFocus", "$get('" + txtmobileno.ClientID + "').focus();$get('" + txtmobileno.ClientID + "').select();", True)
            Dim myscript As String = "alert('Invalid Mobile No');"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType, "myscript", myscript, True)
        Else
            'txtOffice1.Focus()
        End If
    End Sub
End Class

