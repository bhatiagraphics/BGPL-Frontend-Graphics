Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic
Imports FOODERPWEB.Class

Namespace FOODERPWEB.Class
    Public Class clsLead
        Public Shared UpdateOrNot As String
        '' For GP Details 
        Private mcontactcd As String
        Private mleaddate As String
        Private mleadtypecd As String
        Private mfirstname As String
        Private mLastName As String
        Private mdesignation As String
        Private mchannelcode As String
        Private mregname As String
        Private mmobile1 As String
        Private mmobile2 As String
        Private memail1 As String
        Private memail2 As String
        Private moffice1 As String
        Private moffice2 As String
        Private mbusinessname As String
        Private myearofest As String
        Private mannualturnover As String
        Private mbstypecd As String
        Private mindcd As String
        Private msubindcd As String
        Private madd1 As String
        Private madd2 As String
        Private mlocation As String
        Private mcity As String
        Private mpincode As String
        Private mstatecd As String
        Private mcountrycd As String

        Private mintmod1code As String
        Private mintmod2code As String
        Private mintoff1code As String
        Private mintoff2code As String
        Private mwebsite As String

        Private mcontacttype As String



        Private mcrtuserid As String
        Private mcrtuserdt As String
        Private mmoduserid As String
        Private mmoduserdt As String

        Public Property contacttype() As String
            Get
                Return mcontacttype
            End Get
            Set(ByVal value As String)
                mcontacttype = value
            End Set
        End Property

        Public Property intmod1code() As String
            Get
                Return mintmod1code
            End Get
            Set(ByVal value As String)
                mintmod1code = value
            End Set
        End Property

        Public Property intmod2code() As String
            Get
                Return mintmod2code
            End Get
            Set(ByVal value As String)
                mintmod2code = value
            End Set
        End Property

        Public Property intoff1code() As String
            Get
                Return mintoff1code
            End Get
            Set(ByVal value As String)
                mintoff1code = value
            End Set
        End Property

        Public Property intoff2code() As String
            Get
                Return mintoff2code
            End Get
            Set(ByVal value As String)
                mintoff2code = value
            End Set
        End Property

        Public Property website() As String
            Get
                Return mwebsite
            End Get
            Set(ByVal value As String)
                mwebsite = value
            End Set
        End Property

        Public Property contactcd() As String
            Get
                Return mcontactcd
            End Get
            Set(ByVal value As String)
                mcontactcd = value
            End Set
        End Property

        Public Property leaddate() As String
            Get
                Return mleaddate
            End Get
            Set(ByVal value As String)
                mleaddate = value
            End Set
        End Property

        Public Property leadtypecd() As String
            Get
                Return mleadtypecd
            End Get
            Set(ByVal value As String)
                mleadtypecd = value
            End Set
        End Property

        Public Property firstname() As String
            Get
                Return mfirstname
            End Get
            Set(ByVal value As String)
                mfirstname = value
            End Set
        End Property

        Public Property lastname() As String
            Get
                Return mLastName
            End Get
            Set(ByVal value As String)
                mLastName = value
            End Set
        End Property

        Public Property designation() As String
            Get
                Return mdesignation
            End Get
            Set(ByVal value As String)
                mdesignation = value
            End Set
        End Property

        Public Property channelcode() As String
            Get
                Return mchannelcode
            End Get
            Set(ByVal value As String)
                mchannelcode = value
            End Set
        End Property

        Public Property regname() As String
            Get
                Return mregname
            End Get
            Set(ByVal value As String)
                mregname = value
            End Set
        End Property

        Public Property mobile1() As String
            Get
                Return mmobile1
            End Get
            Set(ByVal value As String)
                mmobile1 = value
            End Set
        End Property

        Public Property mobile2() As String
            Get
                Return mmobile2
            End Get
            Set(ByVal value As String)
                mmobile2 = value
            End Set
        End Property

        Public Property email1() As String
            Get
                Return memail1
            End Get
            Set(ByVal value As String)
                memail1 = value
            End Set
        End Property

        Public Property email2() As String
            Get
                Return memail2
            End Get
            Set(ByVal value As String)
                memail2 = value
            End Set
        End Property

        Public Property office1() As String
            Get
                Return moffice1
            End Get
            Set(ByVal value As String)
                moffice1 = value
            End Set
        End Property

        Public Property office2() As String
            Get
                Return moffice2
            End Get
            Set(ByVal value As String)
                moffice2 = value
            End Set
        End Property

        Public Property businessname() As String
            Get
                Return mbusinessname
            End Get
            Set(ByVal value As String)
                mbusinessname = value
            End Set
        End Property

        Public Property yearofest() As String
            Get
                Return myearofest
            End Get
            Set(ByVal value As String)
                myearofest = value
            End Set
        End Property

        Public Property annualturnover() As String
            Get
                Return mannualturnover
            End Get
            Set(ByVal value As String)
                mannualturnover = value
            End Set
        End Property

        Public Property bstypecd() As String
            Get
                Return mbstypecd
            End Get
            Set(ByVal value As String)
                mbstypecd = value
            End Set
        End Property

        Public Property indcd() As String
            Get
                Return mindcd
            End Get
            Set(ByVal value As String)
                mindcd = value
            End Set
        End Property

        Public Property subindcd() As String
            Get
                Return msubindcd
            End Get
            Set(ByVal value As String)
                msubindcd = value
            End Set
        End Property

        Public Property add1() As String
            Get
                Return madd1
            End Get
            Set(ByVal value As String)
                madd1 = value
            End Set
        End Property

        Public Property add2() As String
            Get
                Return madd2
            End Get
            Set(ByVal value As String)
                madd2 = value
            End Set
        End Property

        Public Property location() As String
            Get
                Return mlocation
            End Get
            Set(ByVal value As String)
                mlocation = value
            End Set
        End Property

        Public Property city() As String
            Get
                Return mcity
            End Get
            Set(ByVal value As String)
                mcity = value
            End Set
        End Property

        Public Property pincode() As String
            Get
                Return mpincode
            End Get
            Set(ByVal value As String)
                mpincode = value
            End Set
        End Property

        Public Property statecd() As String
            Get
                Return mstatecd
            End Get
            Set(ByVal value As String)
                mstatecd = value
            End Set
        End Property

        Public Property countrycd() As String
            Get
                Return mcountrycd
            End Get
            Set(ByVal value As String)
                mcountrycd = value
            End Set
        End Property


        Public Property crtuserid() As String
            Get
                Return mcrtuserid
            End Get
            Set(ByVal value As String)
                mcrtuserid = value
            End Set
        End Property
        Public Property crtuserdt() As String
            Get
                Return mcrtuserdt
            End Get
            Set(ByVal value As String)
                mcrtuserdt = value
            End Set
        End Property
        Public Property moduserid() As String
            Get
                Return mmoduserid
            End Get
            Set(ByVal value As String)
                mmoduserid = value
            End Set
        End Property
        Public Property moduserdt() As String
            Get
                Return mmoduserdt
            End Get
            Set(ByVal value As String)
                mmoduserdt = value
            End Set
        End Property








        '' Start Client Details
        Public Shared Function FillData(ByVal contactcd As String, ByVal Flag As String) As clsLead
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@contactcd", contactcd))
                db.Parameters.Add(New SqlParameter("@channelcode", ""))
                db.Parameters.Add(New SqlParameter("@userid", ""))
                db.Parameters.Add(New SqlParameter("@Flag", "B"))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_crmcontacts_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As clsLead = New clsLead
                    If Not IsDBNull(dt.Rows(0)("contactcd")) Then
                        obj.contactcd = dt.Rows(0)("contactcd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("leaddate").ToString) Then
                        obj.leaddate = ""
                    Else
                        obj.leaddate = dt.Rows(0)("leaddate").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("leadtypecd").ToString) Then
                        obj.leadtypecd = ""
                    Else
                        obj.leadtypecd = dt.Rows(0)("leadtypecd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("firstname").ToString) Then
                        obj.firstname = ""
                    Else
                        obj.firstname = dt.Rows(0)("firstname").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("lastname").ToString) Then
                        obj.lastname = ""
                    Else
                        obj.lastname = dt.Rows(0)("lastname").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("designation").ToString) Then
                        obj.designation = ""
                    Else
                        obj.designation = dt.Rows(0)("designation").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("channelcode").ToString) Then
                        obj.channelcode = ""
                    Else
                        obj.channelcode = dt.Rows(0)("channelcode").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("regname").ToString) Then
                        obj.regname = ""
                    Else
                        obj.regname = dt.Rows(0)("regname").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("mobile1").ToString) Then
                        obj.mobile1 = ""
                    Else
                        obj.mobile1 = dt.Rows(0)("mobile1").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("mobile2").ToString) Then
                        obj.mobile2 = ""
                    Else
                        obj.mobile2 = dt.Rows(0)("mobile2").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("email1").ToString) Then
                        obj.email1 = ""
                    Else
                        obj.email1 = dt.Rows(0)("email1").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("email2").ToString) Then
                        obj.email2 = ""
                    Else
                        obj.email2 = dt.Rows(0)("email2").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("office1").ToString) Then
                        obj.office1 = ""
                    Else
                        obj.office1 = dt.Rows(0)("office1").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("office2").ToString) Then
                        obj.office2 = ""
                    Else
                        obj.office2 = dt.Rows(0)("office2").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("businessname").ToString) Then
                        obj.businessname = ""
                    Else
                        obj.businessname = dt.Rows(0)("businessname").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("yearofest").ToString) Then
                        obj.yearofest = ""
                    Else
                        obj.yearofest = dt.Rows(0)("yearofest").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("annualturnover").ToString) Then
                        obj.annualturnover = ""
                    Else
                        obj.annualturnover = dt.Rows(0)("annualturnover").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("bstypecd").ToString) Then
                        obj.bstypecd = ""
                    Else
                        obj.bstypecd = dt.Rows(0)("bstypecd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("indcd").ToString) Then
                        obj.indcd = ""
                    Else
                        obj.indcd = dt.Rows(0)("indcd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("subindcd").ToString) Then
                        obj.subindcd = ""
                    Else
                        obj.subindcd = dt.Rows(0)("subindcd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("add1").ToString) Then
                        obj.add1 = ""
                    Else
                        obj.add1 = dt.Rows(0)("add1").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("add2").ToString) Then
                        obj.add2 = ""
                    Else
                        obj.add2 = dt.Rows(0)("add2").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("location").ToString) Then
                        obj.location = ""
                    Else
                        obj.location = dt.Rows(0)("location").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("city").ToString) Then
                        obj.city = ""
                    Else
                        obj.city = dt.Rows(0)("city").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("pincode").ToString) Then
                        obj.pincode = ""
                    Else
                        obj.pincode = dt.Rows(0)("pincode").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("statecd").ToString) Then
                        obj.statecd = ""
                    Else
                        obj.statecd = dt.Rows(0)("statecd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("countrycd").ToString) Then
                        obj.countrycd = ""
                    Else
                        obj.countrycd = dt.Rows(0)("countrycd").ToString
                    End If


                    If IsDBNull(dt.Rows(0)("intmod1code").ToString) Then
                        obj.intmod1code = ""
                    Else
                        obj.intmod1code = dt.Rows(0)("intmod1code").ToString
                    End If

                    If IsDBNull(dt.Rows(0)("intmod2code").ToString) Then
                        obj.intmod2code = ""
                    Else
                        obj.intmod2code = dt.Rows(0)("intmod2code").ToString
                    End If

                    If IsDBNull(dt.Rows(0)("intoff1code").ToString) Then
                        obj.intoff1code = ""
                    Else
                        obj.intoff1code = dt.Rows(0)("intoff1code").ToString
                    End If

                    If IsDBNull(dt.Rows(0)("intoff2code").ToString) Then
                        obj.intoff2code = ""
                    Else
                        obj.intoff2code = dt.Rows(0)("intoff2code").ToString
                    End If

                    If IsDBNull(dt.Rows(0)("website").ToString) Then
                        obj.website = ""
                    Else
                        obj.website = dt.Rows(0)("website").ToString
                    End If

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function Update_Data(ByVal o As clsLead, ByVal mode As String) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim Com1, Com2 As SqlCommand
            Dim Ssql1, Ssql2 As String
            Dim i As Integer

            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure

            Com2 = New SqlCommand
            Com2.Connection = Con
            Com2.CommandType = CommandType.Text

            If o.contactcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@contactcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@contactcd", o.contactcd))
            End If
            If o.leaddate = "" Then
                Com1.Parameters.Add(New SqlParameter("@leaddate", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@leaddate", o.leaddate))
            End If

            If o.leadtypecd = "" Then
                Com1.Parameters.Add(New SqlParameter("@leadtypecd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@leadtypecd", o.leadtypecd))
            End If

            Com1.Parameters.Add(New SqlParameter("@firstname", o.firstname))
            Com1.Parameters.Add(New SqlParameter("@lastname", o.lastname))
            Com1.Parameters.Add(New SqlParameter("@designation", o.designation))
            Com1.Parameters.Add(New SqlParameter("@channelcode", o.channelcode))
            Com1.Parameters.Add(New SqlParameter("@regname", o.regname))
            Com1.Parameters.Add(New SqlParameter("@mobile1", o.mobile1))
            Com1.Parameters.Add(New SqlParameter("@mobile2", o.mobile2))
            Com1.Parameters.Add(New SqlParameter("@email1", o.email1))
            Com1.Parameters.Add(New SqlParameter("@email2", o.email2))
            Com1.Parameters.Add(New SqlParameter("@office1", o.office1))
            Com1.Parameters.Add(New SqlParameter("@office2", o.office2))
            Com1.Parameters.Add(New SqlParameter("@businessname", o.businessname))
            Com1.Parameters.Add(New SqlParameter("@yearofest", o.yearofest))
            Com1.Parameters.Add(New SqlParameter("@annualturnover", o.annualturnover))
            If Trim(o.bstypecd) = "" Then
                Com1.Parameters.Add(New SqlParameter("@bstypecd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@bstypecd", o.bstypecd))
            End If
            If Trim(o.indcd) = "" Then
                Com1.Parameters.Add(New SqlParameter("@indcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@indcd", o.indcd))
            End If
            If Trim(o.subindcd) = "" Then
                Com1.Parameters.Add(New SqlParameter("@subindcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@subindcd", o.subindcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@add1", o.add1))
            Com1.Parameters.Add(New SqlParameter("@add2", o.add2))
            Com1.Parameters.Add(New SqlParameter("@location", o.location))
            Com1.Parameters.Add(New SqlParameter("@city", o.city))
            Com1.Parameters.Add(New SqlParameter("@pincode", o.pincode))
            If Trim(o.statecd) = "" Then
                Com1.Parameters.Add(New SqlParameter("@statecd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@statecd", o.statecd))
            End If
            If Trim(o.countrycd) = "" Then
                Com1.Parameters.Add(New SqlParameter("@countrycd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@countrycd", o.countrycd))
            End If



            Com1.Parameters.Add(New SqlParameter("@intmod1code", o.intmod1code))
            Com1.Parameters.Add(New SqlParameter("@intmod2code", o.intmod2code))
            Com1.Parameters.Add(New SqlParameter("@intoff1code", o.intoff1code))
            Com1.Parameters.Add(New SqlParameter("@intoff2code", o.intoff2code))
            Com1.Parameters.Add(New SqlParameter("@website", o.website))

            Com1.Parameters.Add(New SqlParameter("@contacttype", o.contacttype))




            Com1.Parameters.Add(New SqlParameter("@crtuserid", o.crtuserid))
            Com1.Parameters.Add(New SqlParameter("@crtuserdt", o.crtuserdt))
            Com1.Parameters.Add(New SqlParameter("@moduserid", o.moduserid))
            Com1.Parameters.Add(New SqlParameter("@moduserdt", o.moduserdt))

            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_crmcontacts_AE"
            Com1.CommandText = Ssql1
            Com1.Transaction = Trans

            'Ssql2 = "update crmcontacts set allocated_uid='" & Trim(o.refbyContactcd) & "', allocatedBy_uid='" & Trim(o.crtuserid) & "' where contactcd ='" & Trim(o.Contactcd) & "' And ISNULL(allocated_uid,'') = '' "
            'Com2.CommandText = Ssql2
            'Com2.Transaction = Trans

            Try
                i = Com1.ExecuteNonQuery()
                Trans.Commit()
            Catch ex As Exception
                If (Not (Trans) Is Nothing) Then
                    Trans.Rollback()
                End If
                Throw ex
            Finally
                Com1 = Nothing
                Con.Close()
                Con = Nothing
                Trans = Nothing
            End Try
            Return i
        End Function



        'Public Shared Function Generate_Docno_ForClient_Reg(ByVal paramno As Integer, ByVal loccd As String, ByVal Productcd As String)
        '    Try
        '        Dim startyr, endyr, doccode As String
        '        Dim ccode, LSN, PSN, docsrno As String

        '        Call DBAccess.Find_company()
        '        ccode = DBAccess.CmpCode
        '        Call DBAccess.Find_LocationShortName(loccd)
        '        LSN = DBAccess.LocationShortName
        '        Call DBAccess.Find_ProductShortName(Productcd)
        '        PSN = DBAccess.ProductShortName

        '        startyr = Right(Trim(DBAccess.FinStart), 2)
        '        endyr = Right(Trim(DBAccess.FinEnd), 2)
        '        docsrno = DocumentSrno(paramno, 1)

        '        Generate_Docno_ForClient_Reg = Trim(ccode) + "/" + Trim(LSN) + "/" + Trim(startyr) + "-" + Trim(endyr) + "/" + Trim(PSN) + "/" + Trim(docsrno)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function






        Public Shared Function GetDocCode() As String
            Dim sSQL As String, objDas As New DBAccess, dt As DataTable
            sSQL = "SELECT MAX(cast(Contactcd as Integer)) AS Contactcd FROM crmcontacts"
            dt = objDas.GetDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item("Contactcd")) Then
                    If dt.Rows(0).Item("Contactcd").ToString <> "" Then
                        GetDocCode = dt.Rows(0)("Contactcd").ToString + 1
                    Else
                        GetDocCode = 1
                    End If
                Else
                    GetDocCode = 1
                End If
            End If
            Return GetDocCode
        End Function

        Public Shared Function GetAccounts() As DataTable
            Dim db As DBAccess = New DBAccess
            Dim dt As DataTable = db.ExecuteDataTable("Sp_ContactDatabase_SelectAll")
            Return dt
        End Function

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function CheckDuplicate(ByVal strcode As String) As String
            Try
                Dim s As Object
                CheckDuplicate = ""
                s = DBAccess.Find_Value("crmcontacts", "contactname", "contactcd", Trim(strcode))
                If s IsNot Nothing Then
                    CheckDuplicate = s.ToString
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function CheckDuplicate_MobileNo(ByVal strcode As String) As String
            Try
                Dim s As Object
                CheckDuplicate_MobileNo = ""
                s = DBAccess.Find_Value("crmcontacts", "mobile1", "contactcd", Trim(strcode))
                If s IsNot Nothing Then
                    CheckDuplicate_MobileNo = s.ToString
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function CheckDuplicate_Email(ByVal strcode As String) As String
            Try
                Dim sSQL As String, dt As DataTable, objDas As New DBAccess
                CheckDuplicate_Email = ""

                sSQL = "select contactcd from crmcontacts where isnull(email1,'')<>'' and email1='" & Trim(strcode) & "'"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    CheckDuplicate_Email = Trim(dt.Rows(0)("contactcd").ToString)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function Check_Duplicate_Name_email_Mobile(ByVal strname As String, ByVal strEmail As String, ByVal strmobile As String) As String
            Try
                Dim sSQL As String, dt As DataTable, objDas As New DBAccess
                Check_Duplicate_Name_email_Mobile = ""

                sSQL = "select contactcd from crmcontacts where isnull(email,'')<>'' and email='" & Trim(strEmail) & "' and Contactname='" & Trim(strname) & "' and mobile='" & Trim(strmobile) & "'"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    Check_Duplicate_Name_email_Mobile = Trim(dt.Rows(0)("contactcd").ToString)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function Check_Duplicate_FName_LName_Mobile(ByVal strname As String, ByVal strLName As String, ByVal strmobile As String) As String
            Try
                Dim sSQL As String, dt As DataTable, objDas As New DBAccess
                Check_Duplicate_FName_LName_Mobile = ""

                sSQL = "select contactcd from crmcontacts where isnull(firstname,'')<>'' and firstname='" & Trim(strname) & "' and LastName='" & Trim(strLName) & "' and mobile1='" & Trim(strmobile) & "'"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    Check_Duplicate_FName_LName_Mobile = Trim(dt.Rows(0)("contactcd").ToString)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function CheckDuplicate_Client(ByVal contactcd As String, ByVal LeadName As String, ByVal CompName As String, ByVal MobileNo As String) As String
            Dim s As Object
            CheckDuplicate_Client = ""
            s = Check_duplicate_CLient(Trim(contactcd), Trim(LeadName), Trim(CompName), Trim(MobileNo))
            If s IsNot Nothing Then
                CheckDuplicate_Client = s.ToString
            End If
        End Function

        Public Shared Function Check_duplicate_CLient(ByVal contactcd As String, ByVal LeadName As String, ByVal CompName As String, ByVal MobileNo As String) As String
            Dim con As New SqlConnection
            Dim com As New SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "CheckDuplicate_GP_SP"
            com.Parameters.AddWithValue("@contactcd", Trim(contactcd))
            com.Parameters.AddWithValue("@LeadName", Trim(LeadName))
            com.Parameters.AddWithValue("@CompName", Trim(CompName))
            com.Parameters.AddWithValue("@MobileNo", Trim(MobileNo))
            pr = com.Parameters.Add("@retval", SqlDbType.VarChar, 255)
            pr.Direction = ParameterDirection.Output
            Try
                con.Open()
                com.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con = Nothing
                com = Nothing
            End Try
            obj = pr.Value
            If IsDBNull(obj) = True Or IsNothing(obj.ToString) Then
                obj = Nothing
            End If
            Return obj
        End Function

        Public Shared Function CheckDuplicate_GP(ByVal contactcd As String, ByVal LeadName As String, ByVal MobileNo As String) As String
            Dim s As Object
            CheckDuplicate_GP = ""
            s = Check_duplicate_GP(Trim(contactcd), Trim(LeadName), Trim(MobileNo))
            If s IsNot Nothing Then
                CheckDuplicate_GP = s.ToString
            End If
        End Function

        Public Shared Function Check_duplicate_GP(ByVal contactcd As String, ByVal LeadName As String, ByVal MobileNo As String) As String
            Dim con As New SqlConnection
            Dim com As New SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "CheckDuplicate_Client_SP"
            com.Parameters.AddWithValue("@contactcd", Trim(contactcd))
            com.Parameters.AddWithValue("@LeadName", Trim(LeadName))
            'com.Parameters.AddWithValue("@CompName", Trim(CompName))
            com.Parameters.AddWithValue("@MobileNo", Trim(MobileNo))
            pr = com.Parameters.Add("@retval", SqlDbType.VarChar, 255)
            pr.Direction = ParameterDirection.Output
            Try
                con.Open()
                com.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con = Nothing
                com = Nothing
            End Try
            obj = pr.Value
            If IsDBNull(obj) = True Or IsNothing(obj.ToString) Then
                obj = Nothing
            End If
            Return obj
        End Function

        Public Shared Function GetDataAllFor_Client_Pending_IMP(ByVal loccd As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@loccd", loccd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_crmContacts_GetData_Pending_IMP")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function Check_Account_Details(ByVal contactcd As String, ByVal productcd As String) As String
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "Check_AccountForReg_SP"
            com.Parameters.AddWithValue("@contactcd", Trim(contactcd))
            com.Parameters.AddWithValue("@productcd", Trim(productcd))
            pr = com.Parameters.Add("@RETVAL", SqlDbType.Char, 5)
            pr.Direction = ParameterDirection.Output
            Try
                con.Open()
                com.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                con = Nothing
                com = Nothing
            End Try

            obj = pr.Value
            If IsDBNull(obj) = True Or obj.ToString = "" Then
                obj = Nothing
            End If

            Return obj

        End Function

        Public Shared Function Find_Value(ByVal Table As String, ByVal Code As String, ByVal Name As String, ByVal value As Object) As Object
            Dim con As New SqlConnection
            Dim com As New SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "crmChkDuplicate_sp"
            com.Parameters.AddWithValue("tab", Trim(Table))
            com.Parameters.AddWithValue("code", Trim(Code))
            com.Parameters.AddWithValue("desc", Trim(Name))
            com.Parameters.AddWithValue("para", Trim(value))
            pr = com.Parameters.Add("RetVal", SqlDbType.VarChar, 500)
            pr.Direction = ParameterDirection.Output

            Try
                con.Open()
                com.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                con = Nothing
                com = Nothing
            End Try

            obj = pr.Value
            If IsDBNull(obj) = True Or IsNothing(obj.ToString) Then
                obj = Nothing
            End If

            Return obj
        End Function

        Public Shared Function CompanyCode() As String
            CompanyCode = "Z"
        End Function

        Public Shared Function GetCommand() As SqlCommand
            Return New SqlCommand()
        End Function

        Public Shared Function DocumentCode() As String
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim res As Object

            con = GetConnection()
            com = GetCommand()

            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "select doccode from documents where docname='tr'"
            DocumentCode = ""

            Try
                con.Open()
                res = com.ExecuteScalar()
                If res IsNot Nothing Then
                    DocumentCode = res.ToString.Trim
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                con = Nothing
            End Try
        End Function

        Public Shared Function DocumentType() As String
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim res As Object

            con = GetConnection()
            com = GetCommand()

            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "select typecode from doctype where typename='ot' and doccode='ot'"
            DocumentType = ""
            Try
                con.Open()
                res = com.ExecuteScalar()
                If res IsNot Nothing Then
                    DocumentType = res.ToString.Trim
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                con = Nothing
            End Try
        End Function

        Public Shared Function Fetch_Paramno() As Integer
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim ccode, DOCCODE, DOCTYPE As String
            Dim p As Int16

            ccode = CompanyCode()
            DOCCODE = DocumentCode()
            DOCTYPE = DocumentType()
            con = GetConnection()
            com = GetCommand()

            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "select paramno from parameter where ccode='agpl'and paramtype='" & Trim(DOCCODE) & "' and doctype='" & Trim(DOCTYPE) & "'"

            Try
                con.Open()
                p = com.ExecuteScalar
                If IsDBNull(p) Then
                    p = 0
                End If
                p = p + 1
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                con = Nothing
            End Try

            Return p
        End Function

        Public Shared Function Generate_Docno(ByVal paramno As Integer) As String
            Dim startyr, endyr, doctype, doccode As String
            Dim ccode, docsrno As String

            ccode = CompanyCode()
            doccode = DocumentCode()
            doctype = DocumentType()
            docsrno = DocumentSrno(paramno, 5)

            'startyr = Right((ClsGeneral.FinStart).ToString.Trim, 2)
            'endyr = Right((ClsGeneral.FinEnd).ToString.Trim, 2)
            startyr = Right("1/4/2012", 2)
            endyr = Right("1/4/2013", 2)

            Generate_Docno = Trim(ccode) + "-" + Trim(docsrno)
        End Function

        Public Shared Function DocumentSrno(ByVal p As Integer, ByVal strlen As Integer) As String
            If strlen > Len(CStr(p)) Then
                DocumentSrno = StrDup(strlen - Len(CStr(p)), "0") + CStr(p)
            Else
                DocumentSrno = CStr(p)
            End If
        End Function

        Public Shared Function Check_Integrity(ByVal strcode As String) As String
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "CheckIntegrity_Contact_Sp"
            com.Parameters.AddWithValue("@code", Trim(strcode))
            pr = com.Parameters.Add("@reftblname", SqlDbType.Char, 60)
            pr.Direction = ParameterDirection.Output

            Try
                con.Open()
                com.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                con = Nothing
                com = Nothing
            End Try

            obj = pr.Value
            If IsDBNull(obj) = True Or obj.ToString = "" Then
                obj = Nothing
            End If

            Return obj

        End Function

        Public Shared Function GetDataForGride() As DataSet
            Dim dadet, dadet1 As New SqlDataAdapter
            Dim con As SqlConnection
            Dim comdet, comdet1 As SqlCommand
            Dim ds As DataSet

            con = GetConnection()
            comdet = GetCommand()
            comdet1 = GetCommand()
            ds = New DataSet

            comdet.Connection = con
            comdet.CommandType = CommandType.Text
            comdet.CommandText = "select * from crmcontacts where statuscd=''"
            dadet.SelectCommand = comdet

            Try
                dadet.Fill(ds, "crmcontacts")
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con = Nothing
                comdet = Nothing
                dadet = Nothing
            End Try
            Return ds
        End Function



        Public Shared Function Find_Citycd(ByVal strcode As String) As String
            Dim s As Object
            Find_Citycd = ""
            s = DBAccess.Find_Value("crmcity", "cityname", "citycd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Citycd = s.ToString
            End If
        End Function

        Public Shared Function Find_Statecd(ByVal strcode As String) As String
            Dim s As Object
            Find_Statecd = ""
            s = DBAccess.Find_Value("crmstate", "statename", "statecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Statecd = s.ToString
            End If
        End Function

        Public Shared Function Find_Countrycd(ByVal strcode As String) As String
            Dim s As Object
            Find_Countrycd = ""
            s = DBAccess.Find_Value("crmcountry", "countryname", "countrycd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Countrycd = s.ToString
            End If
        End Function

        Public Shared Function Find_Areacd(ByVal strcode As String) As String
            Dim s As Object
            Find_Areacd = ""
            s = DBAccess.Find_Value("crmarea", "areaname", "areacd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Areacd = s.ToString
            End If
        End Function

        Public Shared Function Find_Sourcecd(ByVal strcode As String) As String
            Dim s As Object
            Find_Sourcecd = ""
            s = DBAccess.Find_Value("CRMSourceMaster", "SourceName", "Sourcecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Sourcecd = s.ToString
            End If
        End Function

        Public Shared Function Find_Segmentcd(ByVal strcode As String) As String
            Dim s As Object
            Find_Segmentcd = ""
            s = DBAccess.Find_Value("CRMSegmentMaster", "Segmentname", "Segmentcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Segmentcd = s.ToString
            End If
        End Function

        Public Shared Function Find_Agecd(ByVal strcode As String) As String
            Dim s As Object
            Find_Agecd = ""
            s = DBAccess.Find_Value("CRMAgeMaster", "AgeName", "Agecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Agecd = s.ToString
            End If
        End Function

        Public Shared Function Find_AgeQScore(ByVal strcode As String) As String
            Dim s As Object
            Find_AgeQScore = ""
            s = DBAccess.Find_Value("CRMAgeMaster", "Agecd", "AgeName", Trim(strcode))
            If s IsNot Nothing Then
                Find_AgeQScore = s.ToString
            End If
        End Function

        Public Shared Function Find_LivingInCitycd(ByVal strcode As String) As String
            Dim s As Object
            Find_LivingInCitycd = ""
            s = DBAccess.Find_Value("CRMLivingInCityMaster", "LivingInCityName", "LivingInCitycd", Trim(strcode))
            If s IsNot Nothing Then
                Find_LivingInCitycd = s.ToString
            End If
        End Function

        Public Shared Function Find_CityQScore(ByVal strcode As String) As String
            Dim s As Object
            Find_CityQScore = ""
            s = DBAccess.Find_Value("CRMLivingInCityMaster", "LivingInCitycd", "LivingInCityName", Trim(strcode))
            If s IsNot Nothing Then
                Find_CityQScore = s.ToString
            End If
        End Function

        Public Shared Function Find_incomerangecd(ByVal strcode As String) As String
            Dim s As Object
            Find_incomerangecd = ""
            s = DBAccess.Find_Value("crmincomerange", "incomerangename", "incomerangecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_incomerangecd = s.ToString
            End If
        End Function

        Public Shared Function Find_incomerangeQScore(ByVal strcode As String) As String
            Dim s As Object
            Find_incomerangeQScore = ""
            s = DBAccess.Find_Value("crmincomerange", "incomerangecd", "incomerangename", Trim(strcode))
            If s IsNot Nothing Then
                Find_incomerangeQScore = s.ToString
            End If
        End Function

        Public Shared Function Find_Educationcd(ByVal strcode As String) As String
            Dim s As Object
            Find_Educationcd = ""
            s = DBAccess.Find_Value("CRMEducationMaster", "EducationName", "Educationcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Educationcd = s.ToString
            End If
        End Function

        Public Shared Function Find_EducationQScore(ByVal strcode As String) As String
            Dim s As Object
            Find_EducationQScore = ""
            s = DBAccess.Find_Value("CRMEducationMaster", "Educationcd", "EducationName", Trim(strcode))
            If s IsNot Nothing Then
                Find_EducationQScore = s.ToString
            End If
        End Function

        Public Shared Function Find_Occupationcd(ByVal strcode As String) As String
            Dim s As Object
            Find_Occupationcd = ""
            s = DBAccess.Find_Value("CRMOccupationMaster", "OccupationName", "Occupationcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Occupationcd = s.ToString
            End If
        End Function

        Public Shared Function Find_OccupationQScore(ByVal strcode As String) As String
            Dim s As Object
            Find_OccupationQScore = ""
            s = DBAccess.Find_Value("CRMOccupationMaster", "Occupationcd", "OccupationName", Trim(strcode))
            If s IsNot Nothing Then
                Find_OccupationQScore = s.ToString
            End If
        End Function

        Public Shared Function Find_leadindcd(ByVal strcode As String) As String
            Dim s As Object
            Find_leadindcd = ""
            s = DBAccess.Find_Value("crmleadindustry", "leadindname", "leadindcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_leadindcd = s.ToString
            End If
        End Function

        Public Shared Function Find_RefBy(ByVal strcode As String) As String
            Dim s As Object
            Find_RefBy = ""
            s = DBAccess.Find_Value("crmleadtype", "ltypename", "ltypecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_RefBy = s.ToString
            End If
        End Function

        Public Shared Function Find_NoofEmployeescd(ByVal strcode As String) As String
            Dim s As Object
            Find_NoofEmployeescd = ""
            s = DBAccess.Find_Value("CRMNoofEmployeesMaster", "NoofEmployeesName", "NoofEmployeescd", Trim(strcode))
            If s IsNot Nothing Then
                Find_NoofEmployeescd = s.ToString
            End If
        End Function

        Public Shared Function Find_AnnualTurnoverCd(ByVal strcode As String) As String
            Dim s As Object
            Find_AnnualTurnoverCd = ""
            s = DBAccess.Find_Value("CRMAnnualTurnoverMaster", "AnnualTurnoverName", "AnnualTurnover", Trim(strcode))
            If s IsNot Nothing Then
                Find_AnnualTurnoverCd = s.ToString
            End If
        End Function

        Public Shared Function Find_YearofEst(ByVal strcode As String) As String
            Dim s As Object
            Find_YearofEst = ""
            s = DBAccess.Find_Value("CRMYearofEstablishmentMaster", "YearofEstablishmentName", "YearofEst", Trim(strcode))
            If s IsNot Nothing Then
                Find_YearofEst = s.ToString
            End If
        End Function

        Public Shared Function Find_qulificationcd(ByVal strcode As String) As String
            Dim s As Object
            Find_qulificationcd = ""
            s = DBAccess.Find_Value("qulificationcd", "qulificationname", "qulificationcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_qulificationcd = s.ToString
            End If
        End Function

        Public Shared Function Find_AreaLocationcd(ByVal strcode As String) As String
            Dim s As Object
            Find_AreaLocationcd = ""
            s = DBAccess.Find_Value("AreaLocation", "AreaLocationname", "AreaLocationcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_AreaLocationcd = s.ToString
            End If
        End Function

        Public Shared Function Find_contactcdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_contactcdCode = ""
            s = DBAccess.Find_Value("crmcontacts", "contactcd", "contactname", Trim(strcode))
            If s IsNot Nothing Then
                Find_contactcdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_contactcdName(ByVal strcode As String) As String
            Dim s As Object
            Find_contactcdName = ""
            s = DBAccess.Find_Value("crmcontacts", "contactname", "contactcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_contactcdName = s.ToString
            End If
        End Function

        Public Shared Function Find_empcdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_empcdCode = ""
            s = DBAccess.Find_Value("hremployee", "empcd", "empname", Trim(strcode))
            If s IsNot Nothing Then
                Find_empcdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_empcdName(ByVal strcode As String) As String
            Dim s As Object
            Find_empcdName = ""
            s = DBAccess.Find_Value("hremployee", "empname", "empcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_empcdName = s.ToString
            End If
        End Function

        Public Shared Function Find_empMobileCode(ByVal strcode As String) As String
            Dim s As Object
            Find_empMobileCode = ""
            s = DBAccess.Find_Value("hremployee", "empcd", "mobile", Trim(strcode))
            If s IsNot Nothing Then
                Find_empMobileCode = s.ToString
            End If
        End Function

        Public Shared Function Find_ProductShortName(ByVal strcode As String) As String
            Dim s As Object
            Find_ProductShortName = ""
            s = DBAccess.Find_Value("product", "productcd", "shortname", Trim(strcode))
            If s IsNot Nothing Then
                Find_ProductShortName = s.ToString
            End If
        End Function

        Public Shared Function Find_DesigcdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_DesigcdCode = ""
            s = DBAccess.Find_Value("Designation", "DesignationCode", "DesignationName", Trim(strcode))
            If s IsNot Nothing Then
                Find_DesigcdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_DesigcdName(ByVal strcode As String) As String
            Dim s As Object
            Find_DesigcdName = ""
            s = DBAccess.Find_Value("Designation", "DesignationName", "DesignationCode", Trim(strcode))
            If s IsNot Nothing Then
                Find_DesigcdName = s.ToString
            End If
        End Function

        Public Shared Function Find_ProductcdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_ProductcdCode = ""
            s = DBAccess.Find_Value("product", "productcd", "productname", Trim(strcode))
            If s IsNot Nothing Then
                Find_ProductcdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_ProductcdName(ByVal strcode As String) As String
            Dim s As Object
            Find_ProductcdName = ""
            s = DBAccess.Find_Value("product", "productname", "productcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_ProductcdName = s.ToString
            End If
        End Function

        Public Shared Function Find_LtypecdByName(ByVal strcode As String) As String
            Dim s As Object
            Find_LtypecdByName = ""
            s = DBAccess.Find_Value("CrmLeadtype", "ltypename", "ltypecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_LtypecdByName = s.ToString
            End If
        End Function
    End Class
End Namespace

