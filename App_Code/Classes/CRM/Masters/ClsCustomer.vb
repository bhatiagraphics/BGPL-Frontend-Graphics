Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsCustomer
        Private mcuscode As String
        Private mcusname As String

        Private madd1 As String
        Private madd2 As String
        Private madd3 As String
        Private mpincode As String


        Private mcitycd As String
        Private mstatecd As String
        Private mcountrycd As String

        Private memailid As String
        Private mmobileno As String

        Private mcrtuserid As String
        Private mcrtuserdt As String
        Private mmoduserid As String
        Private mmoduserdt As String
        Private mGstno As String

        ' Public Shared Citycd1, Cityname1, countrycd1, countryname1, statecd1, statename1 As String




        Public Property cuscode() As String
            Get
                Return mcuscode
            End Get
            Set(ByVal value As String)
                mcuscode = value
            End Set
        End Property

        Public Property cusname() As String
            Get
                Return mcusname
            End Get
            Set(ByVal value As String)
                mcusname = value
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

        Public Property add3() As String
            Get
                Return madd3
            End Get
            Set(ByVal value As String)
                madd3 = value
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

        Public Property citycd() As String
            Get
                Return mcitycd
            End Get
            Set(ByVal value As String)
                mcitycd = value
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

        Public Property emailid() As String
            Get
                Return memailid
            End Get
            Set(ByVal value As String)
                memailid = value
            End Set
        End Property

        Public Property mobileno() As String
            Get
                Return mmobileno
            End Get
            Set(ByVal value As String)
                mmobileno = value
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

        Public Property Gstno() As String
            Get
                Return mGstno
            End Get
            Set(ByVal value As String)
                mGstno = value
            End Set
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function FillData(ByVal cuscode As String, ByVal Flag As String) As ClsCustomer
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@cuscode", cuscode))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_customer_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsCustomer = New ClsCustomer
                    If Not IsDBNull(dt.Rows(0)("cuscode")) Then
                        obj.cuscode = dt.Rows(0)("cuscode").ToString
                    End If
                    obj.cusname = dt.Rows(0)("cusname").ToString
                    obj.add1 = dt.Rows(0)("add1").ToString
                    obj.add2 = dt.Rows(0)("add2").ToString
                    obj.add3 = dt.Rows(0)("add3").ToString
                    obj.pincode = dt.Rows(0)("pincode").ToString

                    If Not IsDBNull(dt.Rows(0)("citycd")) Then
                        obj.citycd = dt.Rows(0)("citycd").ToString
                    End If

                    If Not IsDBNull(dt.Rows(0)("statecd")) Then
                        obj.statecd = dt.Rows(0)("statecd").ToString
                    End If

                    If Not IsDBNull(dt.Rows(0)("countrycd")) Then
                        obj.countrycd = dt.Rows(0)("countrycd").ToString
                    End If
                    obj.mobileno = dt.Rows(0)("mobileno").ToString
                    obj.emailid = dt.Rows(0)("emailid").ToString
                    obj.crtuserid = dt.Rows(0)("crtuserid").ToString
                    obj.crtuserdt = dt.Rows(0)("crtuserdt").ToString
                    obj.moduserid = dt.Rows(0)("moduserid").ToString
                    obj.moduserdt = dt.Rows(0)("moduserdt").ToString
                    obj.Gstno = dt.Rows(0)("Gstno").ToString


                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal cuscode As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@cuscode", cuscode))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_customer_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDocCode() As String
            Try
                Dim sSQL As String, objDas As New DBAccess, dt As DataTable
                sSQL = "SELECT MAX(cast(cuscode as Integer)) AS cuscode FROM customer"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("cuscode")) Then
                        If dt.Rows(0).Item("cuscode").ToString <> "" Then
                            GetDocCode = dt.Rows(0)("cuscode").ToString + 1
                        Else
                            GetDocCode = 1
                        End If
                    Else
                        GetDocCode = 1
                    End If
                End If
                Return GetDocCode
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function Update_Data(ByVal o As ClsCustomer, ByVal mode As String) As Integer
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

            If o.cuscode = "" Then
                Com1.Parameters.Add(New SqlParameter("@cuscode", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@cuscode", o.cuscode))
            End If
            Com1.Parameters.Add(New SqlParameter("@cusname", o.cusname))

            Com1.Parameters.Add(New SqlParameter("@add1", o.add1))
            Com1.Parameters.Add(New SqlParameter("@add2", o.add2))
            Com1.Parameters.Add(New SqlParameter("@add3", o.add3))
            Com1.Parameters.Add(New SqlParameter("@pincode", o.pincode))

            If o.citycd = "" Then
                Com1.Parameters.Add(New SqlParameter("@citycd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@citycd", o.citycd))
            End If

            If o.countrycd = "" Then
                Com1.Parameters.Add(New SqlParameter("@countrycd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@countrycd", o.countrycd))
            End If

            If o.statecd = "" Then
                Com1.Parameters.Add(New SqlParameter("@statecd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@statecd", o.statecd))
            End If


            Com1.Parameters.Add(New SqlParameter("@emailid", o.emailid))
            Com1.Parameters.Add(New SqlParameter("@mobileno", o.mobileno))

            Com1.Parameters.Add(New SqlParameter("@crtuserid", o.crtuserid))
            Com1.Parameters.Add(New SqlParameter("@crtuserdt", o.crtuserdt))
            Com1.Parameters.Add(New SqlParameter("@moduserid", o.moduserid))
            Com1.Parameters.Add(New SqlParameter("@moduserdt", o.moduserdt))
            Com1.Parameters.Add(New SqlParameter("@Gstno", o.Gstno))


            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_customer_AE"
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

        Public Shared Function Delete(ByVal o As ClsCustomer) As Integer
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

            Com1.Parameters.Add(New SqlParameter("@cuscode", o.cuscode))

            Ssql1 = "Sp_customer_Delete"
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

        Public Shared Function CheckDuplicate(ByVal strcode As String) As String
            Dim s As Object
            CheckDuplicate = ""
            s = DBAccess.Find_Value("customer", "cusname", "cuscode", Trim(strcode))
            If s IsNot Nothing Then
                CheckDuplicate = s.ToString
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
            com.CommandText = "CheckIntegrity_customer_Sp"
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



        Public Shared Function Find_citycdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_citycdCode = ""
            s = DBAccess.Find_Value("city", "citycd", "cityname", Trim(strcode))
            If s IsNot Nothing Then
                Find_citycdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_citycdName(ByVal strcode As String) As String
            Dim s As Object
            Find_citycdName = ""
            s = DBAccess.Find_Value("city", "cityname", "citycd", Trim(strcode))
            If s IsNot Nothing Then
                Find_citycdName = s.ToString
            End If
        End Function

        Public Shared Function Find_countrycdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_countrycdCode = ""
            s = DBAccess.Find_Value("country", "countrycd", "countryname", Trim(strcode))
            If s IsNot Nothing Then
                Find_countrycdCode = s.ToString
            End If
        End Function



        Public Shared Function Find_countrycdName(ByVal strcode As String) As String
            Dim s As Object
            Find_countrycdName = ""
            s = DBAccess.Find_Value("country", "countryname", "countrycd", Trim(strcode))
            If s IsNot Nothing Then
                Find_countrycdName = s.ToString
            End If
        End Function


        Public Shared Function Find_statecdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_statecdCode = ""
            s = DBAccess.Find_Value("state", "statecd", "statename", Trim(strcode))
            If s IsNot Nothing Then
                Find_statecdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_statecdName(ByVal strcode As String) As String
            Dim s As Object
            Find_statecdName = ""
            s = DBAccess.Find_Value("state", "statename", "statecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_statecdName = s.ToString
            End If
        End Function

        'Public Shared Function FillCityDetails(ByVal Citycd As String) As ClsCustomer
        '    Try
        '        Dim sSQL As String, objDas As New DBAccess, dt As DataTable
        '        sSQL = "Select C.citycd,C.cityname,C.countrycd,CO.countryname,C.statecd,S.statename "
        '        sSQL += "From CITY C,COUNTRY CO,STATE S "
        '        sSQL += "Where CO.countrycd =C.countrycd And s.statecd =C.statecd And C.citycd = '" & Trim(Citycd) & "'"


        '        dt = objDas.GetDataTable(sSQL)
        '        If dt.Rows.Count > 0 Then
        '            Citycd1 = dt.Rows(0)("citycd").ToString
        '            Cityname1 = dt.Rows(0)("cityname").ToString
        '            countrycd1 = dt.Rows(0)("countrycd").ToString
        '            countryname1 = dt.Rows(0)("countryname").ToString
        '            statecd1 = dt.Rows(0)("statecd").ToString
        '            statename1 = dt.Rows(0)("statename").ToString
        '        Else
        '            Return Nothing
        '        End If
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function




    End Class
End Namespace
