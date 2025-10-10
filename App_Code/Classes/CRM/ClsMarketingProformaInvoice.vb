Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsQuotation
        Public Shared docno As String
        Private mpinvno As String
        Private mpinvdt As String
        Private mcuscode As String
        Private mconsigneecd As String
        Private mOrdRefNo As String
        Private mOrdRefdate As String
        Private mtranscd As String
        Private mModeOfTranCode As String
        Private mNetamt As Decimal
        Private mDelivTerms As String
        Private mRemarks As String
        Private mccode As String
        Private mcrtuserid As String
        Private mcrtuserdt As String
        Private mmoduserid As String
        Private mmoduserdt As String
        Private msanuserid As String
        Private msanuserdt As String

        Private mexrate As String
        Private mcurrcd As String
        Private mdeliverydate As String



        Private mfreightAmt As String
        Private mdiscountPer As String
        Private mdiscountAmt As String
        Private mroundOffAmt As String
        Private mpayterms As String
        Private mfordet As String
        Private mprepaidcollect As String

        Private mpricelistno As String
        Private mpricelistdate As String

        Private mcreditPeriod As String
        Private mduedate As String

        'For Ship to address
        Private mconsaddcd As String
        Private mconsadd1 As String
        Private mconsadd2 As String
        Private mconsadd3 As String
        Private mconsadd4 As String
        Private mconscontactperson1 As String
        Private mconscontact1email As String
        Private mconscontact1mob As String
        Private mconscountrycd As String
        Private mconsstatecd As String
        Private mconscitycd As String
        Private mconsregioncd As String
        Private mconspincode As String

        Public Property consaddcd() As String
            Get
                Return mconsaddcd
            End Get
            Set(ByVal value As String)
                mconsaddcd = value
            End Set
        End Property
        Public Property consadd1() As String
            Get
                Return mconsadd1
            End Get
            Set(ByVal value As String)
                mconsadd1 = value
            End Set
        End Property

        Public Property consadd2() As String
            Get
                Return mconsadd2
            End Get
            Set(ByVal value As String)
                mconsadd2 = value
            End Set
        End Property

        Public Property consadd3() As String
            Get
                Return mconsadd3
            End Get
            Set(ByVal value As String)
                mconsadd3 = value
            End Set
        End Property

        Public Property consadd4() As String
            Get
                Return mconsadd4
            End Get
            Set(ByVal value As String)
                mconsadd4 = value
            End Set
        End Property

        Public Property conscitycd() As String
            Get
                Return mconscitycd
            End Get
            Set(ByVal value As String)
                mconscitycd = value
            End Set
        End Property


        Public Property conscountrycd() As String
            Get
                Return mconscountrycd
            End Get
            Set(ByVal value As String)
                mconscountrycd = value
            End Set
        End Property

        Public Property consstatecd() As String
            Get
                Return mconsstatecd
            End Get
            Set(ByVal value As String)
                mconsstatecd = value
            End Set
        End Property

        Public Property consregioncd() As String
            Get
                Return mconsregioncd
            End Get
            Set(ByVal value As String)
                mconsregioncd = value
            End Set
        End Property

        Public Property conspincode() As String
            Get
                Return mconspincode
            End Get
            Set(ByVal value As String)
                mconspincode = value
            End Set
        End Property



        Public Property conscontactperson1() As String
            Get
                Return mconscontactperson1
            End Get
            Set(ByVal value As String)
                mconscontactperson1 = value
            End Set
        End Property


        Public Property conscontact1email() As String
            Get
                Return mconscontact1email
            End Get
            Set(ByVal value As String)
                mconscontact1email = value
            End Set
        End Property



        Public Property conscontact1mob() As String
            Get
                Return mconscontact1mob
            End Get
            Set(ByVal value As String)
                mconscontact1mob = value
            End Set
        End Property

        'End

        Public Property creditPeriod() As String
            Get
                Return mcreditPeriod
            End Get
            Set(ByVal value As String)
                mcreditPeriod = value
            End Set
        End Property
        Public Property duedate() As String
            Get
                Return mduedate
            End Get
            Set(ByVal value As String)
                mduedate = value
            End Set
        End Property
        Public Property exrate() As String
            Get
                Return mexrate
            End Get
            Set(ByVal value As String)
                mexrate = value
            End Set
        End Property

        Public Property currcd() As String
            Get
                Return mcurrcd
            End Get
            Set(ByVal value As String)
                mcurrcd = value
            End Set
        End Property
        Public Property deliverydate() As String
            Get
                Return mdeliverydate
            End Get
            Set(ByVal value As String)
                mdeliverydate = value
            End Set
        End Property

        Public Property pricelistno() As String
            Get
                Return mpricelistno
            End Get
            Set(ByVal value As String)
                mpricelistno = value
            End Set
        End Property

        Public Property pricelistdate() As String
            Get
                Return mpricelistdate
            End Get
            Set(ByVal value As String)
                mpricelistdate = value
            End Set
        End Property


        Public Property payterms() As String
            Get
                Return mpayterms
            End Get
            Set(ByVal value As String)
                mpayterms = value
            End Set
        End Property


        Public Property fordet() As String
            Get
                Return mfordet
            End Get
            Set(ByVal value As String)
                mfordet = value
            End Set
        End Property


        Public Property prepaidcollect() As String
            Get
                Return mprepaidcollect
            End Get
            Set(ByVal value As String)
                mprepaidcollect = value
            End Set
        End Property


        Public Property freightAmt() As String
            Get
                Return mfreightAmt
            End Get
            Set(ByVal value As String)
                mfreightAmt = value
            End Set
        End Property

        Public Property discountPer() As String
            Get
                Return mdiscountPer
            End Get
            Set(ByVal value As String)
                mdiscountPer = value
            End Set
        End Property

        Public Property discountAmt() As String
            Get
                Return mdiscountAmt
            End Get
            Set(ByVal value As String)
                mdiscountAmt = value
            End Set
        End Property

        Public Property roundOffAmt() As String
            Get
                Return mroundOffAmt
            End Get
            Set(ByVal value As String)
                mroundOffAmt = value
            End Set
        End Property

        Public Property pinvno() As String
            Get
                Return mpinvno
            End Get
            Set(ByVal value As String)
                mpinvno = value
            End Set
        End Property
        Public Property pinvdt() As String
            Get
                Return mpinvdt
            End Get
            Set(ByVal value As String)
                mpinvdt = value
            End Set
        End Property
        Public Property cuscode() As String
            Get
                Return mcuscode
            End Get
            Set(ByVal value As String)
                mcuscode = value
            End Set
        End Property
        Public Property consigneecd() As String
            Get
                Return mconsigneecd
            End Get
            Set(ByVal value As String)
                mconsigneecd = value
            End Set
        End Property
        Public Property transcd() As String
            Get
                Return mtranscd
            End Get
            Set(ByVal value As String)
                mtranscd = value
            End Set
        End Property
        Public Property ModeOfTranCode() As String
            Get
                Return mModeOfTranCode
            End Get
            Set(ByVal value As String)
                mModeOfTranCode = value
            End Set
        End Property
        Public Property OrdRefNo() As String
            Get
                Return mOrdRefNo
            End Get
            Set(ByVal value As String)
                mOrdRefNo = value
            End Set
        End Property
        Public Property OrdRefdate() As String
            Get
                Return mOrdRefdate
            End Get
            Set(ByVal value As String)
                mOrdRefdate = value
            End Set
        End Property
        Public Property Netamt() As Decimal
            Get
                Return mNetamt
            End Get
            Set(ByVal value As Decimal)
                mNetamt = value
            End Set
        End Property
        Public Property DelivTerms() As String
            Get
                Return mDelivTerms
            End Get
            Set(ByVal value As String)
                mDelivTerms = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Return mRemarks
            End Get
            Set(ByVal value As String)
                mRemarks = value
            End Set
        End Property
        Public Property ccode() As String
            Get
                Return mccode
            End Get
            Set(ByVal value As String)
                mccode = value
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
        Public Property sanuserid() As String
            Get
                Return msanuserid
            End Get
            Set(ByVal value As String)
                msanuserid = value
            End Set
        End Property
        Public Property sanuserdt() As String
            Get
                Return msanuserdt
            End Get
            Set(ByVal value As String)
                msanuserdt = value
            End Set
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function
        Public Shared Function GetCommand() As SqlCommand
            Return New SqlCommand()
        End Function

        Public Shared Function FillData(ByVal pinvno As String, ByVal Flag As String) As ClsQuotation
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@pinvno", pinvno))
                db.Parameters.Add(New SqlParameter("@fromdt", ""))
                db.Parameters.Add(New SqlParameter("@todt", ""))
                db.Parameters.Add(New SqlParameter("@cuscode", ""))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_profinvhead_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsQuotation = New ClsQuotation
                    If Not IsDBNull(dt.Rows(0)("pinvno")) Then
                        obj.pinvno = dt.Rows(0)("pinvno").ToString
                    End If
                    obj.pinvdt = dt.Rows(0)("pinvdt").ToString
                    obj.cuscode = dt.Rows(0)("cuscode").ToString
                    obj.consigneecd = dt.Rows(0)("consigneecd").ToString
                    obj.transcd = dt.Rows(0)("transcd").ToString
                    obj.ModeOfTranCode = dt.Rows(0)("ModeOfTranCode").ToString
                    obj.OrdRefNo = dt.Rows(0)("OrdRefNo").ToString
                    obj.OrdRefdate = dt.Rows(0)("OrdRefdate").ToString
                    If Trim(dt.Rows(0)("Netamt").ToString) = "" Then
                        obj.Netamt = 0.0#
                    Else
                        obj.Netamt = dt.Rows(0)("Netamt").ToString
                    End If
                    obj.DelivTerms = dt.Rows(0)("DelivTerms").ToString
                    obj.Remarks = dt.Rows(0)("Remarks").ToString
                    obj.ccode = dt.Rows(0)("ccode").ToString

                    obj.freightAmt = dt.Rows(0)("freightAmt").ToString
                    obj.discountPer = dt.Rows(0)("discountPer").ToString
                    obj.discountAmt = dt.Rows(0)("discountAmt").ToString
                    obj.roundOffAmt = dt.Rows(0)("roundOffAmt").ToString
                    obj.payterms = dt.Rows(0)("payterms").ToString
                    obj.fordet = dt.Rows(0)("fordet").ToString
                    obj.prepaidcollect = dt.Rows(0)("prepaidcollect").ToString

                    obj.pricelistno = dt.Rows(0)("pricelistno").ToString
                    obj.pricelistdate = dt.Rows(0)("pricelistdate").ToString

                    obj.currcd = dt.Rows(0)("currcd").ToString
                    obj.exrate = dt.Rows(0)("exrate").ToString
                    obj.deliverydate = dt.Rows(0)("deliverydate").ToString

                    obj.consaddcd = dt.Rows(0)("consaddcd").ToString
                    obj.consadd1 = dt.Rows(0)("consadd1").ToString
                    obj.consadd2 = dt.Rows(0)("consadd2").ToString
                    obj.consadd3 = dt.Rows(0)("consadd3").ToString
                    obj.consadd4 = dt.Rows(0)("consadd4").ToString
                    obj.conscitycd = dt.Rows(0)("conscitycd").ToString
                    obj.conscountrycd = dt.Rows(0)("conscountrycd").ToString
                    obj.consstatecd = dt.Rows(0)("consstatecd").ToString
                    obj.consregioncd = dt.Rows(0)("consregioncd").ToString
                    obj.conspincode = dt.Rows(0)("conspincode").ToString
                    obj.conscontactperson1 = dt.Rows(0)("conscontactperson1").ToString
                    obj.conscontact1email = dt.Rows(0)("conscontact1email").ToString
                    obj.conscontact1mob = dt.Rows(0)("conscontact1mob").ToString
                    obj.creditPeriod = dt.Rows(0)("creditPeriod").ToString
                    obj.duedate = dt.Rows(0)("duedate").ToString

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Shared Function GetDataAll(ByVal pinvno As String, ByVal fromdt As String, ByVal todt As String, ByVal cuscode As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@pinvno", pinvno))
                db.Parameters.Add(New SqlParameter("@fromdt", ""))
                db.Parameters.Add(New SqlParameter("@todt", ""))
                db.Parameters.Add(New SqlParameter("@cuscode", ""))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_profinvhead_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Shared Function DocumentCode() As String
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim res As Object

            con = GetConnection()
            com = GetCommand()

            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "Select doccode from document where docname='Proforma Invoice'"
            DocumentCode = ""
            Try
                con.Open()
                res = com.ExecuteScalar()
                If res IsNot Nothing Then
                    DocumentCode = res.ToString.Trim
                End If
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con = Nothing
            End Try
        End Function

        Public Shared Function DocumentType() As String
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim DOCCODE As String
            Dim res As Object

            DOCCODE = DocumentCode()
            con = GetConnection()
            com = GetCommand()

            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "Select doctype from doctype where doccode = '" & Trim(DOCCODE) & "'"
            DocumentType = ""
            Try
                con.Open()
                res = com.ExecuteScalar()
                If res IsNot Nothing Then
                    DocumentType = res.ToString.Trim
                End If
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con = Nothing
            End Try
        End Function

        Public Shared Function Fetch_Paramno(ByVal ccode As String) As Integer
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim DOCTYPE, DOCCODE As String
            Dim p As Int16

            'ccode = DBAccess.CmpCode
            DOCCODE = DocumentCode()
            DOCTYPE = DocumentType()
            con = GetConnection()
            com = GetCommand()

            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "Select paramno from parameter where ccode='" & Trim(ccode) & "' and doctype='" & Trim(DOCTYPE) & "' and paramtype='" & Trim(DOCCODE) & "'"

            Try
                con.Open()
                p = com.ExecuteScalar
                If IsDBNull(p) Then
                    p = 0
                End If
                p = p + 1
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con = Nothing
            End Try

            Return p
        End Function

        Public Shared Function Generate_Docno(ByVal paramno As Integer, ByVal ccode As String)
            Try
                Dim startyr, endyr, doccode, doctype As String
                Dim docsrno As String

                'ccode = DBAccess.CmpCode
                doccode = DocumentCode()
                doctype = DocumentType()

                Call DBAccess.Find_company()
                startyr = Right(Trim(DBAccess.FinStart), 2)
                endyr = Right(Trim(DBAccess.FinEnd), 2)
                docsrno = DocumentSrno(paramno, 5)

                '' 1
                'Generate_Docno = Trim(ccode) + Trim(startyr) + Trim(endyr) + "-" + Trim(DOCTYPE) + "-" + Trim(UnitCode) + Trim(doccode) + "-" + Trim(docsrno)

                '' 2
                'Generate_Docno = Trim(ccode) + "/SO/" + Trim(startyr) + Trim(endyr) + "/" + Trim(docsrno)
                ''Generate_Docno = Trim(ccode) + "/" + Trim(loccd) + "/PO" + "/" + Trim(startyr) + Trim(endyr) + "/" + Trim(docsrno)

                ''3
                Generate_Docno = Trim(ccode) + Trim(startyr) + Trim(endyr) + "/" + Trim(doctype) + "/" + Trim(docsrno)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function DocumentSrno(ByVal p As Integer, ByVal strlen As Integer) As String
            If strlen > Len(CStr(p)) Then
                DocumentSrno = StrDup(strlen - Len(CStr(p)), "0") + CStr(p)
            Else
                DocumentSrno = CStr(p)
            End If
        End Function

        Public Shared Function GetDataForGride() As DataSet
            Dim dadet As New SqlDataAdapter
            Dim con As SqlConnection
            Dim comdet As SqlCommand
            Dim ds As DataSet

            con = GetConnection()
            comdet = GetCommand()
            ds = New DataSet

            comdet.Connection = con
            comdet.CommandType = CommandType.Text
            comdet.CommandText = "Select * from profinvdet where pinvno='" & Trim(docno) & "' order by pinvno desc"
            dadet.SelectCommand = comdet

            Try
                dadet.Fill(ds, "profinvdet")
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

        Public Shared Function Update_Data_Add(ByVal o As ClsQuotation, ByVal ds As DataSet, ByVal paramno As Integer, ByVal mode As String, ByVal ccode As String) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim dadet As New SqlDataAdapter
            Dim comdetold As SqlCommand
            Dim comdet As SqlCommand
            Dim cbdet As SqlCommandBuilder
            Dim Com1, Com2 As SqlCommand
            Dim Ssql1, Ssql2, Ssql3 As String
            Dim i As Integer
            Dim comparam As SqlCommand
            Dim DOCTYPE, doccode As String

            'ccode = DBAccess.CmpCode
            doccode = DocumentCode()
            DOCTYPE = DocumentType()

            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            comdet = New SqlCommand
            comdet.Connection = Con
            comdet.CommandType = CommandType.Text
            Ssql2 = "Select * From profinvdet Where pinvno='" & Trim(docno) & "'"
            comdet.CommandText = Ssql2
            comdet.Transaction = Trans

            comdetold = New SqlCommand
            comdetold.Connection = Con
            comdetold.CommandType = CommandType.Text
            Ssql3 = "Delete From profinvdet Where pinvno='" & Trim(docno) & "'"
            comdetold.CommandText = Ssql3
            comdetold.Transaction = Trans

            dadet.SelectCommand = comdet
            cbdet = New SqlCommandBuilder(dadet)
            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure

            If o.pinvno = "" Then
                Com1.Parameters.Add(New SqlParameter("@pinvno", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@pinvno", o.pinvno))
            End If
            Com1.Parameters.Add(New SqlParameter("@pinvdt", o.pinvdt))
            Com1.Parameters.Add(New SqlParameter("@cuscode", o.cuscode))
            If o.consigneecd = "" Then
                Com1.Parameters.Add(New SqlParameter("@consigneecd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@consigneecd", o.consigneecd))
            End If
            If o.transcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@transcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@transcd", o.transcd))
            End If
            If o.ModeOfTranCode = "" Then
                Com1.Parameters.Add(New SqlParameter("@ModeOfTranCode", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@ModeOfTranCode", o.ModeOfTranCode))
            End If
            Com1.Parameters.Add(New SqlParameter("@OrdRefNo", o.OrdRefNo))
            Com1.Parameters.Add(New SqlParameter("@OrdRefdate", o.OrdRefdate))
            Com1.Parameters.Add(New SqlParameter("@Netamt", o.Netamt))
            Com1.Parameters.Add(New SqlParameter("@DelivTerms", o.DelivTerms))
            Com1.Parameters.Add(New SqlParameter("@Remarks", o.Remarks))
            Com1.Parameters.Add(New SqlParameter("@ccode", ccode))
            Com1.Parameters.Add(New SqlParameter("@crtuserid", o.crtuserid))
            Com1.Parameters.Add(New SqlParameter("@crtuserdt", o.crtuserdt))
            Com1.Parameters.Add(New SqlParameter("@moduserid", o.moduserid))
            Com1.Parameters.Add(New SqlParameter("@moduserdt", o.moduserdt))

            Com1.Parameters.Add(New SqlParameter("@freightAmt", o.freightAmt))
            Com1.Parameters.Add(New SqlParameter("@discountPer", o.discountPer))
            Com1.Parameters.Add(New SqlParameter("@discountAmt", o.discountAmt))
            Com1.Parameters.Add(New SqlParameter("@roundOffAmt", o.roundOffAmt))
            Com1.Parameters.Add(New SqlParameter("@payterms", o.payterms))
            Com1.Parameters.Add(New SqlParameter("@fordet", o.fordet))
            Com1.Parameters.Add(New SqlParameter("@prepaidcollect", o.prepaidcollect))

            Com1.Parameters.Add(New SqlParameter("@pricelistno", o.pricelistno))
            Com1.Parameters.Add(New SqlParameter("@pricelistdate", o.pricelistdate))

            If o.currcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@currcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@currcd", o.currcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@deliverydate", o.deliverydate))
            Com1.Parameters.Add(New SqlParameter("@exrate", o.exrate))

            'For Ship to address
            If o.consaddcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@consaddcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@consaddcd", o.consaddcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@consadd1", o.consadd1))
            Com1.Parameters.Add(New SqlParameter("@consadd2", o.consadd2))
            Com1.Parameters.Add(New SqlParameter("@consadd3", o.consadd3))
            Com1.Parameters.Add(New SqlParameter("@consadd4", o.consadd4))
            Com1.Parameters.Add(New SqlParameter("@conscitycd", o.conscitycd))
            Com1.Parameters.Add(New SqlParameter("@conscountrycd", o.conscountrycd))
            Com1.Parameters.Add(New SqlParameter("@consstatecd", o.consstatecd))
            Com1.Parameters.Add(New SqlParameter("@consregioncd", o.consregioncd))
            Com1.Parameters.Add(New SqlParameter("@conspincode", o.conspincode))
            Com1.Parameters.Add(New SqlParameter("@conscontactperson1", o.conscontactperson1))
            Com1.Parameters.Add(New SqlParameter("@conscontact1email", o.conscontact1email))
            Com1.Parameters.Add(New SqlParameter("@conscontact1mob", o.conscontact1mob))
            'End For Ship to address

            Com1.Parameters.Add(New SqlParameter("@creditPeriod", o.creditPeriod))
            Com1.Parameters.Add(New SqlParameter("@duedate", o.duedate))

            Com1.Parameters.Add(New SqlParameter("@Flag", "A"))

            Ssql1 = "Sp_profinvhead_AE"
            Com1.CommandText = Ssql1
            Com1.Transaction = Trans

            comparam = New SqlCommand
            comparam.Connection = Con
            comparam.CommandType = CommandType.Text
            comparam.CommandText = "Update parameter Set [paramno]=" & Val(paramno) & " Where [ccode]='" & Trim(ccode) & "' And [doctype]='" & Trim(DOCTYPE) & "' And [paramtype]='" & Trim(doccode) & "' "
            comparam.Transaction = Trans

            Try
                comparam.ExecuteNonQuery()
                i = Com1.ExecuteNonQuery()
                i = dadet.Update(ds, "profinvdet")
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

        Public Shared Function Update_Data_Edit(ByVal o As ClsQuotation, ByVal ds As DataSet, ByVal paramno As Integer, ByVal mode As String, ByVal ccode As String) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim dadet As New SqlDataAdapter
            Dim comdetold As SqlCommand
            Dim comdet As SqlCommand
            Dim cbdet As SqlCommandBuilder
            Dim Com1, Com2 As SqlCommand
            Dim Ssql1, Ssql2, Ssql3 As String
            Dim i As Integer
            Dim comparam As SqlCommand
            Dim doccode As String

            'ccode = DBAccess.CmpCode
            doccode = DocumentCode()

            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            comdet = New SqlCommand
            comdet.Connection = Con
            comdet.CommandType = CommandType.Text
            Ssql2 = "Select * From profinvdet Where pinvno='" & Trim(docno) & "'"
            comdet.CommandText = Ssql2
            comdet.Transaction = Trans

            comdetold = New SqlCommand
            comdetold.Connection = Con
            comdetold.CommandType = CommandType.Text
            Ssql3 = "Delete From profinvdet Where pinvno='" & Trim(docno) & "'"
            comdetold.CommandText = Ssql3
            comdetold.Transaction = Trans

            dadet.SelectCommand = comdet
            cbdet = New SqlCommandBuilder(dadet)
            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure

            If o.pinvno = "" Then
                Com1.Parameters.Add(New SqlParameter("@pinvno", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@pinvno", o.pinvno))
            End If
            Com1.Parameters.Add(New SqlParameter("@pinvdt", o.pinvdt))
            Com1.Parameters.Add(New SqlParameter("@cuscode", o.cuscode))
            If o.consigneecd = "" Then
                Com1.Parameters.Add(New SqlParameter("@consigneecd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@consigneecd", o.consigneecd))
            End If
            If o.transcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@transcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@transcd", o.transcd))
            End If
            If o.ModeOfTranCode = "" Then
                Com1.Parameters.Add(New SqlParameter("@ModeOfTranCode", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@ModeOfTranCode", o.ModeOfTranCode))
            End If
            Com1.Parameters.Add(New SqlParameter("@OrdRefNo", o.OrdRefNo))
            Com1.Parameters.Add(New SqlParameter("@OrdRefdate", o.OrdRefdate))
            Com1.Parameters.Add(New SqlParameter("@Netamt", o.Netamt))
            Com1.Parameters.Add(New SqlParameter("@DelivTerms", o.DelivTerms))
            Com1.Parameters.Add(New SqlParameter("@Remarks", o.Remarks))
            Com1.Parameters.Add(New SqlParameter("@ccode", ccode))
            Com1.Parameters.Add(New SqlParameter("@crtuserid", o.crtuserid))
            Com1.Parameters.Add(New SqlParameter("@crtuserdt", o.crtuserdt))
            Com1.Parameters.Add(New SqlParameter("@moduserid", o.moduserid))
            Com1.Parameters.Add(New SqlParameter("@moduserdt", o.moduserdt))

            Com1.Parameters.Add(New SqlParameter("@freightAmt", o.freightAmt))
            Com1.Parameters.Add(New SqlParameter("@discountPer", o.discountPer))
            Com1.Parameters.Add(New SqlParameter("@discountAmt", o.discountAmt))
            Com1.Parameters.Add(New SqlParameter("@roundOffAmt", o.roundOffAmt))
            Com1.Parameters.Add(New SqlParameter("@payterms", o.payterms))
            Com1.Parameters.Add(New SqlParameter("@fordet", o.fordet))
            Com1.Parameters.Add(New SqlParameter("@prepaidcollect", o.prepaidcollect))

            Com1.Parameters.Add(New SqlParameter("@pricelistno", o.pricelistno))
            Com1.Parameters.Add(New SqlParameter("@pricelistdate", o.pricelistdate))

            If o.currcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@currcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@currcd", o.currcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@deliverydate", o.deliverydate))
            Com1.Parameters.Add(New SqlParameter("@exrate", o.exrate))

            'For Ship to address
            If o.consaddcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@consaddcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@consaddcd", o.consaddcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@consadd1", o.consadd1))
            Com1.Parameters.Add(New SqlParameter("@consadd2", o.consadd2))
            Com1.Parameters.Add(New SqlParameter("@consadd3", o.consadd3))
            Com1.Parameters.Add(New SqlParameter("@consadd4", o.consadd4))
            Com1.Parameters.Add(New SqlParameter("@conscitycd", o.conscitycd))
            Com1.Parameters.Add(New SqlParameter("@conscountrycd", o.conscountrycd))
            Com1.Parameters.Add(New SqlParameter("@consstatecd", o.consstatecd))
            Com1.Parameters.Add(New SqlParameter("@consregioncd", o.consregioncd))
            Com1.Parameters.Add(New SqlParameter("@conspincode", o.conspincode))
            Com1.Parameters.Add(New SqlParameter("@conscontactperson1", o.conscontactperson1))
            Com1.Parameters.Add(New SqlParameter("@conscontact1email", o.conscontact1email))
            Com1.Parameters.Add(New SqlParameter("@conscontact1mob", o.conscontact1mob))
            'End For Ship to address

            Com1.Parameters.Add(New SqlParameter("@creditPeriod", o.creditPeriod))
            Com1.Parameters.Add(New SqlParameter("@duedate", o.duedate))
            Com1.Parameters.Add(New SqlParameter("@Flag", "E"))

            Ssql1 = "Sp_profinvhead_AE"
            Com1.CommandText = Ssql1
            Com1.Transaction = Trans

            Try
                comdetold.ExecuteNonQuery()
                i = Com1.ExecuteNonQuery()
                i = dadet.Update(ds, "profinvdet")
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

        Public Shared Function Delete(ByVal o As ClsQuotation) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim Com1 As SqlCommand
            Dim Ssql1 As String
            Dim i As Integer

            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure
            Com1.Parameters.Add(New SqlParameter("@pinvno", o.pinvno))

            Ssql1 = "Sp_profinvhead_Delete"
            Com1.CommandText = Ssql1
            Com1.Transaction = Trans

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

        Public Shared Function Find_CusCode(ByVal strcode As String) As String
            Dim s As Object
            Find_CusCode = ""
            s = DBAccess.Find_Value("customer", "cusname", "cuscode", Trim(strcode))
            If s IsNot Nothing Then
                Find_CusCode = s.ToString
            End If
        End Function

        Public Shared Function Find_CusName(ByVal strcode As String) As String
            Dim s As Object
            Find_CusName = ""
            s = DBAccess.Find_Value("customer", "cuscode", "cusname", Trim(strcode))
            If s IsNot Nothing Then
                Find_CusName = s.ToString
            End If
        End Function

        Public Shared Function Find_TransCode(ByVal strcode As String) As String
            Dim s As Object
            Find_TransCode = ""
            s = DBAccess.Find_Value("transport", "transname", "transcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_TransCode = s.ToString
            End If
        End Function

        Public Shared Function Find_TransName(ByVal strcode As String) As String
            Dim s As Object
            Find_TransName = ""
            s = DBAccess.Find_Value("transport", "transcd", "transname", Trim(strcode))
            If s IsNot Nothing Then
                Find_TransName = s.ToString
            End If
        End Function

        Public Shared Function Find_ModeofTranCd(ByVal strcode As String) As String
            Dim s As Object
            Find_ModeofTranCd = ""
            s = DBAccess.Find_Value("modeoftransport", "ModeofTranName", "ModeofTranCode", Trim(strcode))
            If s IsNot Nothing Then
                Find_ModeofTranCd = s.ToString
            End If
        End Function

        Public Shared Function Find_ModeofTranName(ByVal strcode As String) As String
            Dim s As Object
            Find_ModeofTranName = ""
            s = DBAccess.Find_Value("modeoftransport", "ModeofTranCode", "ModeofTranName", Trim(strcode))
            If s IsNot Nothing Then
                Find_ModeofTranName = s.ToString
            End If
        End Function

        Public Shared Function Find_UOMCd(ByVal strcode As String) As String
            Dim s As Object
            Find_UOMCd = ""
            s = DBAccess.Find_Value("uom", "uomname", "uomcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_UOMCd = s.ToString
            End If
        End Function

        Public Shared Function Find_UOMName(ByVal strcode As String) As String
            Dim s As Object
            Find_UOMName = ""
            s = DBAccess.Find_Value("uom", "uomcd", "uomname", Trim(strcode))
            If s IsNot Nothing Then
                Find_UOMName = s.ToString
            End If
        End Function

        Public Shared Function Find_HSNCode(ByVal strcode As String) As String
            Dim s As Object
            Find_HSNCode = ""
            s = DBAccess.Find_Value("product", "productcd", "chapterheading", Trim(strcode))
            If s IsNot Nothing Then
                Find_HSNCode = s.ToString
            End If
        End Function

        Public Shared Function Find_UOMFromProduct(ByVal strcode As String) As String
            Dim s As Object
            Find_UOMFromProduct = ""
            s = DBAccess.Find_Value("product", "productcd", "uomcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_UOMFromProduct = s.ToString
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

        Public Shared Function Find_ProductcdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_ProductcdCode = ""
            s = DBAccess.Find_Value("product", "productcd", "productname", Trim(strcode))
            If s IsNot Nothing Then
                Find_ProductcdCode = s.ToString
            End If
        End Function
    End Class
End Namespace
