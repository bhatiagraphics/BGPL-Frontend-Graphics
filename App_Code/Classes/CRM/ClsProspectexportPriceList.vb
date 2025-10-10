Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsProspectexportPriceList
        Public Shared docno As String
        Private mccode As String
        Private mpricelistno As String
        Private mpricelistDate As String
        Private mcontactcd As String
        Private mfreight As String
        Private mlocalchg As String
        Private mcarton As String

        Private mcurrcd As String
        Private meuro As String

        Private mdutyper As String

        Private mpaymentterm As String
        Private mDeliveryTerm As String
        Private mportofloading As String
        Private mportofdischarge As String
        Private mincoterm As String

        Private mpricevalidity As String


        Private mcrtuserid As String
        Private mcrtuserdt As String
        Private mmoduserid As String
        Private mmoduserdt As String

        Public Property pricevalidity() As String
            Get
                Return mpricevalidity
            End Get
            Set(ByVal value As String)
                mpricevalidity = value
            End Set
        End Property


        Public Property localchg() As String
            Get
                Return mlocalchg
            End Get
            Set(ByVal value As String)
                mlocalchg = value
            End Set
        End Property

        Public Property carton() As String
            Get
                Return mcarton
            End Get
            Set(ByVal value As String)
                mcarton = value
            End Set
        End Property
        Public Property paymentterm() As String
            Get
                Return mpaymentterm
            End Get
            Set(ByVal value As String)
                mpaymentterm = value
            End Set
        End Property

        Public Property DeliveryTerm() As String
            Get
                Return mDeliveryTerm
            End Get
            Set(ByVal value As String)
                mDeliveryTerm = value
            End Set
        End Property

        Public Property portofloading() As String
            Get
                Return mportofloading
            End Get
            Set(ByVal value As String)
                mportofloading = value
            End Set
        End Property

        Public Property portofdischarge() As String
            Get
                Return mportofdischarge
            End Get
            Set(ByVal value As String)
                mportofdischarge = value
            End Set
        End Property

        Public Property incoterm() As String
            Get
                Return mincoterm
            End Get
            Set(ByVal value As String)
                mincoterm = value
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

        Public Property dutyper() As String
            Get
                Return mdutyper
            End Get
            Set(ByVal value As String)
                mdutyper = value
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

        Public Property pricelistno() As String
            Get
                Return mpricelistno
            End Get
            Set(ByVal value As String)
                mpricelistno = value
            End Set
        End Property

        Public Property pricelistDate() As String
            Get
                Return mpricelistDate
            End Get
            Set(ByVal value As String)
                mpricelistDate = value
            End Set
        End Property

        Public Property freight() As String
            Get
                Return mfreight
            End Get
            Set(ByVal value As String)
                mfreight = value
            End Set
        End Property

        Public Property euro() As String
            Get
                Return meuro
            End Get
            Set(ByVal value As String)
                meuro = value
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

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function GetCommand() As SqlCommand
            Return New SqlCommand()
        End Function

        Public Shared Function FillDataRecall(ByVal contactcd As String, ByVal Flag As String) As ClsProspectexportPriceList
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@contactcd", contactcd))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_prospricelisthead_GetData_Recall")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsProspectexportPriceList = New ClsProspectexportPriceList

                    obj.ccode = dt.Rows(0)("ccode").ToString
                    obj.pricelistno = dt.Rows(0)("pricelistno").ToString
                    obj.pricelistDate = dt.Rows(0)("pricelistDate").ToString
                    obj.contactcd = dt.Rows(0)("contactcd").ToString
                    obj.freight = dt.Rows(0)("freight").ToString
                    obj.euro = dt.Rows(0)("euro").ToString
                    obj.currcd = dt.Rows(0)("currcd").ToString
                    obj.dutyper = dt.Rows(0)("dutyper").ToString

                    obj.localchg = dt.Rows(0)("localchg").ToString
                    obj.carton = dt.Rows(0)("carton").ToString
                    obj.paymentterm = dt.Rows(0)("paymentterm").ToString
                    obj.DeliveryTerm = dt.Rows(0)("DeliveryTerm").ToString
                    obj.portofloading = dt.Rows(0)("portofloading").ToString
                    obj.portofdischarge = dt.Rows(0)("portofdischarge").ToString
                    obj.incoterm = dt.Rows(0)("incoterm").ToString
                    obj.pricevalidity = dt.Rows(0)("pricevalidity").ToString


                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function FillData(ByVal pricelistno As String, ByVal Flag As String) As ClsProspectexportPriceList
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@pricelistno", pricelistno))
                db.Parameters.Add(New SqlParameter("@fromdt", ""))
                db.Parameters.Add(New SqlParameter("@todt", ""))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_prospricelisthead_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsProspectexportPriceList = New ClsProspectexportPriceList

                    obj.ccode = dt.Rows(0)("ccode").ToString
                    obj.pricelistno = dt.Rows(0)("pricelistno").ToString
                    obj.pricelistDate = dt.Rows(0)("pricelistDate").ToString
                    obj.contactcd = dt.Rows(0)("contactcd").ToString
                    obj.freight = dt.Rows(0)("freight").ToString
                    obj.euro = dt.Rows(0)("euro").ToString
                    obj.currcd = dt.Rows(0)("currcd").ToString
                    obj.dutyper = dt.Rows(0)("dutyper").ToString

                    obj.localchg = dt.Rows(0)("localchg").ToString
                    obj.carton = dt.Rows(0)("carton").ToString
                    obj.paymentterm = dt.Rows(0)("paymentterm").ToString
                    obj.DeliveryTerm = dt.Rows(0)("DeliveryTerm").ToString
                    obj.portofloading = dt.Rows(0)("portofloading").ToString
                    obj.portofdischarge = dt.Rows(0)("portofdischarge").ToString
                    obj.incoterm = dt.Rows(0)("incoterm").ToString
                    obj.pricevalidity = dt.Rows(0)("pricevalidity").ToString


                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal pricelistno As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@pricelistno", pricelistno))
                db.Parameters.Add(New SqlParameter("@fromdt", ""))
                db.Parameters.Add(New SqlParameter("@todt", ""))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_prospricelisthead_GetData")
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
            com.CommandText = "Select doccode from document where docname='PriceList Prospect'"
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

            'ccode = DBAccess.CompanyCode
            DOCCODE = DocumentCode()
            DOCTYPE = DocumentType()
            con = GetConnection()
            com = GetCommand()

            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "select paramno from parameter where ccode='" & Trim(ccode) & "' and doctype='" & Trim(DOCTYPE) & "' and paramtype='" & Trim(DOCCODE) & "'"

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

                'ccode = DBAccess.CompanyCode
                doccode = DocumentCode()
                doctype = DocumentType()

                Call DBAccess.Find_company()

                startyr = Right(Trim(DBAccess.FinStart), 2)
                endyr = Right(Trim(DBAccess.FinEnd), 2)
                docsrno = DocumentSrno(paramno, 5)

                '' 1
                'Generate_Docno = Trim(ccode) + Trim(startyr) + Trim(endyr) + "-" + Trim(DOCTYPE) + "-" + Trim(UnitCode) + Trim(doccode) + "-" + Trim(docsrno)

                '' 2
                'Generate_Docno = Trim(ccode) + Trim(startyr) + Trim(endyr) + "/" + Trim(DOCTYPE) + "/" + Trim(doccode) + "/" + Trim(docsrno)
                'Generate_Docno = Trim(ccode) & Trim(startyr) & Trim(endyr) & "/CON/" & Trim(docsrno)
                Generate_Docno = Trim(ccode) & Trim(startyr) & Trim(endyr) & "/" & Trim(doctype) & "/" & Trim(docsrno)
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
            comdet.CommandText = "Select * from prospricelistdet where pricelistno='" & Trim(docno) & "' order by pricelistno desc"
            dadet.SelectCommand = comdet

            Try
                dadet.Fill(ds, "prospricelistdet")
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
        Public Shared Function Update_Data_add(ByVal o As ClsProspectexportPriceList, ByVal ds As DataSet, ByVal paramno As Integer, ByVal mode As String) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim dadet As New SqlDataAdapter
            Dim comdetold As SqlCommand
            Dim comdet As SqlCommand
            Dim cbdet As SqlCommandBuilder
            Dim Com1 As SqlCommand
            Dim Ssql1, Ssql2, Ssql3 As String
            Dim i As Integer
            Dim comparam As SqlCommand
            Dim ccode, DOCTYPE, doccode As String

            Dim ComST As SqlCommand
            Dim SsqlST As String

            ccode = o.ccode
            doccode = DocumentCode()
            DOCTYPE = DocumentType()

            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            comdet = New SqlCommand
            comdet.Connection = Con
            comdet.CommandType = CommandType.Text
            Ssql2 = "Select * From prospricelistdet Where pricelistno='" & Trim(docno) & "'"
            comdet.CommandText = Ssql2
            comdet.Transaction = Trans

            comdetold = New SqlCommand
            comdetold.Connection = Con
            comdetold.CommandType = CommandType.Text
            Ssql3 = "Delete From prospricelistdet Where pricelistno='" & Trim(docno) & "'"
            comdetold.CommandText = Ssql3
            comdetold.Transaction = Trans

            dadet.SelectCommand = comdet
            cbdet = New SqlCommandBuilder(dadet)

            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure

            Com1.Parameters.Add(New SqlParameter("@ccode", o.ccode))
            Com1.Parameters.Add(New SqlParameter("@pricelistno", o.pricelistno))
            Com1.Parameters.Add(New SqlParameter("@pricelistDate", o.pricelistDate))
            If o.contactcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@contactcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@contactcd", o.contactcd))
            End If

            Com1.Parameters.Add(New SqlParameter("@freight", o.freight))
            Com1.Parameters.Add(New SqlParameter("@euro", o.euro))

            If o.currcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@currcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@currcd", o.currcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@dutyper", o.dutyper))


            Com1.Parameters.Add(New SqlParameter("@localchg", o.localchg))
            Com1.Parameters.Add(New SqlParameter("@carton", o.carton))
            Com1.Parameters.Add(New SqlParameter("@paymentterm", o.paymentterm))
            Com1.Parameters.Add(New SqlParameter("@DeliveryTerm", o.DeliveryTerm))
            If o.portofloading = "" Then
                Com1.Parameters.Add(New SqlParameter("@portofloading", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@portofloading", o.portofloading))
            End If

            If o.portofdischarge = "" Then
                Com1.Parameters.Add(New SqlParameter("@portofdischarge", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@portofdischarge", o.portofdischarge))
            End If
            Com1.Parameters.Add(New SqlParameter("@incoterm", o.incoterm))
            Com1.Parameters.Add(New SqlParameter("@pricevalidity", o.pricevalidity))



            Com1.Parameters.Add(New SqlParameter("@crtuserid", o.crtuserid))
            Com1.Parameters.Add(New SqlParameter("@crtuserdt", o.crtuserdt))
            Com1.Parameters.Add(New SqlParameter("@moduserid", o.moduserid))
            Com1.Parameters.Add(New SqlParameter("@moduserdt", o.moduserdt))
            Com1.Parameters.Add(New SqlParameter("@Flag", "A"))

            Ssql1 = "Sp_prospricelisthead_AE"
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
                i = dadet.Update(ds, "prospricelistdet")
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

        Public Shared Function Update_Data_Edit(ByVal o As ClsProspectexportPriceList, ByVal ds As DataSet, ByVal mode As String) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim dadet As New SqlDataAdapter
            Dim comdetold As SqlCommand
            Dim comdet As SqlCommand
            Dim cbdet As SqlCommandBuilder
            Dim Com1 As SqlCommand
            Dim Ssql1, Ssql2, Ssql3 As String
            Dim i As Integer
            Dim comparam As SqlCommand
            Dim ccode, DOCTYPE, doccode As String

            Dim ComST As SqlCommand
            Dim SsqlST As String

            ccode = DBAccess.CompanyCode
            doccode = DocumentCode()
            DOCTYPE = DocumentType()

            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            comdet = New SqlCommand
            comdet.Connection = Con
            comdet.CommandType = CommandType.Text
            Ssql2 = "Select * From prospricelistdet Where pricelistno='" & Trim(docno) & "'"
            comdet.CommandText = Ssql2
            comdet.Transaction = Trans

            comdetold = New SqlCommand
            comdetold.Connection = Con
            comdetold.CommandType = CommandType.Text
            Ssql3 = "Delete From prospricelistdet Where pricelistno='" & Trim(docno) & "'"
            comdetold.CommandText = Ssql3
            comdetold.Transaction = Trans

            dadet.SelectCommand = comdet
            cbdet = New SqlCommandBuilder(dadet)

            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure

            Com1.Parameters.Add(New SqlParameter("@ccode", o.ccode))
            Com1.Parameters.Add(New SqlParameter("@pricelistno", o.pricelistno))
            Com1.Parameters.Add(New SqlParameter("@pricelistDate", o.pricelistDate))
            If o.contactcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@contactcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@contactcd", o.contactcd))
            End If

            Com1.Parameters.Add(New SqlParameter("@freight", o.freight))
            Com1.Parameters.Add(New SqlParameter("@euro", o.euro))

            If o.currcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@currcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@currcd", o.currcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@dutyper", o.dutyper))


            Com1.Parameters.Add(New SqlParameter("@localchg", o.localchg))
            Com1.Parameters.Add(New SqlParameter("@carton", o.carton))
            Com1.Parameters.Add(New SqlParameter("@paymentterm", o.paymentterm))
            Com1.Parameters.Add(New SqlParameter("@DeliveryTerm", o.DeliveryTerm))
            If o.portofloading = "" Then
                Com1.Parameters.Add(New SqlParameter("@portofloading", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@portofloading", o.portofloading))
            End If

            If o.portofdischarge = "" Then
                Com1.Parameters.Add(New SqlParameter("@portofdischarge", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@portofdischarge", o.portofdischarge))
            End If
            Com1.Parameters.Add(New SqlParameter("@incoterm", o.incoterm))
            Com1.Parameters.Add(New SqlParameter("@pricevalidity", o.pricevalidity))



            Com1.Parameters.Add(New SqlParameter("@crtuserid", o.crtuserid))
            Com1.Parameters.Add(New SqlParameter("@crtuserdt", o.crtuserdt))
            Com1.Parameters.Add(New SqlParameter("@moduserid", o.moduserid))
            Com1.Parameters.Add(New SqlParameter("@moduserdt", o.moduserdt))
            Com1.Parameters.Add(New SqlParameter("@Flag", "E"))

            Ssql1 = "Sp_prospricelisthead_AE"
            Com1.CommandText = Ssql1
            Com1.Transaction = Trans

            Try
                i = comdetold.ExecuteNonQuery
                i = Com1.ExecuteNonQuery()
                i = dadet.Update(ds, "prospricelistdet")
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






        Public Shared Function Delete(ByVal o As ClsProspectexportPriceList) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim Com1 As SqlCommand
            Dim Ssql1 As String
            Dim i As Integer

            Dim ComST As SqlCommand
            Dim SsqlST As String

            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure

            Com1.Parameters.Add(New SqlParameter("@pricelistno", o.pricelistno))

            Ssql1 = "Sp_prospricelisthead_Delete"
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

        Public Shared Function Check_Integrity(ByVal strcode As String) As String
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "CheckIntegrity_prospricelisthead_Sp"
            com.Parameters.AddWithValue("@code", Trim(strcode))
            pr = com.Parameters.Add("@reftblname", SqlDbType.Char, 60)
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
            If IsDBNull(obj) = True Or obj.ToString = "" Then
                obj = Nothing
            End If

            Return obj
        End Function

        Public Shared Function DateFreezeAcc(ByVal infld1 As String) As Boolean
            Dim con As New SqlConnection()
            Dim com As New SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object
            con.ConnectionString = DBAccess.sCon
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "Check_FreezeDt_Acc_Sp"
            com.Parameters.AddWithValue("@vchdt", Trim(infld1))
            pr = com.Parameters.Add("@flag", SqlDbType.Bit, 1)
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
                DateFreezeAcc = False
            Else
                If obj = True Then
                    DateFreezeAcc = True
                Else
                    DateFreezeAcc = False
                End If
            End If

        End Function

        Public Shared Function Find_PPNProduct(ByVal strcode As String) As String
            Dim s As Object
            Find_PPNProduct = ""
            s = DBAccess.Find_Value("ppnhead", "PPNNO", "PRODUCTCD", Trim(strcode))
            If s IsNot Nothing Then
                Find_PPNProduct = s.ToString
            End If
        End Function

        Public Shared Function Find_SaleOrderNo(ByVal strcode As String) As String
            Dim s As Object
            Find_SaleOrderNo = ""
            s = DBAccess.Find_Value("SalordHeadNew", "SalordNo", "SalordNo", Trim(strcode))
            If s IsNot Nothing Then
                Find_SaleOrderNo = s.ToString
            End If
        End Function

        Public Shared Function Find_UOM(ByVal strcode As String) As String
            Dim s As Object
            Find_UOM = ""
            s = DBAccess.Find_Value("uom", "uomname", "uomcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_UOM = s.ToString
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

        Public Shared Function Find_Pgroupcd(ByVal strcode As String) As String
            Dim s As Object
            Find_Pgroupcd = ""
            s = DBAccess.Find_Value("productgroup", "Pgroupname", "Pgroupcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Pgroupcd = s.ToString
            End If
        End Function

        Public Shared Function Find_PgroupcdName(ByVal strcode As String) As String
            Dim s As Object
            Find_PgroupcdName = ""
            s = DBAccess.Find_Value("productgroup", "Pgroupcd", "Pgroupname", Trim(strcode))
            If s IsNot Nothing Then
                Find_PgroupcdName = s.ToString
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


        Public Shared Function Find_customercdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_customercdCode = ""
            s = DBAccess.Find_Value("customer", "contactcd", "cusname", Trim(strcode))
            If s IsNot Nothing Then
                Find_customercdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_customercdName(ByVal strcode As String) As String
            Dim s As Object
            Find_customercdName = ""
            s = DBAccess.Find_Value("customer", "cusname", "contactcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_customercdName = s.ToString
            End If
        End Function


        Public Shared Function Find_ProjectCode(ByVal strcode As String) As String
            Dim s As Object
            Find_ProjectCode = ""
            s = DBAccess.Find_Value("engprojectmaster", "projcd", "projname", Trim(strcode))
            If s IsNot Nothing Then
                Find_ProjectCode = s.ToString
            End If
        End Function

        Public Shared Function Find_ProjectName(ByVal strcode As String) As String
            Dim s As Object
            Find_ProjectName = ""
            s = DBAccess.Find_Value("engprojectmaster", "projname", "projcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_ProjectName = s.ToString
            End If
        End Function

        Public Shared Function Find_WONo(ByVal strcode As String) As String
            Dim s As Object
            Find_WONo = ""
            s = DBAccess.Find_Value("wohead", "wono", "wono", Trim(strcode))
            If s IsNot Nothing Then
                Find_WONo = s.ToString
            End If
        End Function

        Public Shared Function Find_Productcd(ByVal strcode As String) As String
            Dim s As Object
            Find_Productcd = ""
            s = DBAccess.Find_Value("Product", "productname", "Productcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Productcd = s.ToString
            End If
        End Function

        Public Shared Function Find_Customercd(ByVal strcode As String) As String
            Dim s As Object
            Find_Customercd = ""
            s = DBAccess.Find_Value("customer", "cusname", "contactcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Customercd = s.ToString
            End If
        End Function

        Public Shared Function BalanceToIssue(ByVal OrderNo As String, ByVal FromDate As String, ByVal ToDate As String, ByVal StoreCode As String) As String
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "StoreStockReport_Item_sp"
            com.Parameters.AddWithValue("@productcd", Trim(OrderNo))
            com.Parameters.AddWithValue("@contactcd", Trim(StoreCode))
            com.Parameters.AddWithValue("@fromdt", Trim(FromDate))
            com.Parameters.AddWithValue("@todt", Trim(ToDate))
            pr = com.Parameters.Add("@balQty", SqlDbType.Decimal)
            '
            pr.Precision = 19
            pr.Scale = 3
            pr.Direction = ParameterDirection.Output

            Try
                con.Open()
                com.ExecuteNonQuery()
            Catch ex As Exception
                'MsgBox(ex.Message)
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

    End Class
End Namespace
