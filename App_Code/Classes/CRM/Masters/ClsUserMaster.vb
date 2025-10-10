Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsUserMaster
        Private mu_id As String
        Private mu_name As String
        Private mlastname As String

        Private mdesigcd As String
        Private mactive As String

        Private mpass As String
        Private mreportingto As String

        Private mmobileno As String
        Private memailid As String
        Private mlastpasschangedt As String
        Private madministrator As String
        Private mallowbilling As String
        Private mallowbilldone_close As String

        Private mcrtuserid As String
        Private mcrtuserdt As String
        Private mmoduserid As String
        Private mmoduserdt As String
        Public Property allowbilldone_close() As String
            Get
                Return mallowbilldone_close
            End Get
            Set(ByVal value As String)
                mallowbilldone_close = value
            End Set
        End Property

        Public Property allowbilling() As String
            Get
                Return mallowbilling
            End Get
            Set(ByVal value As String)
                mallowbilling = value
            End Set
        End Property

        Public Property administrator() As String
            Get
                Return madministrator
            End Get
            Set(ByVal value As String)
                madministrator = value
            End Set
        End Property

        Public Property u_id() As String
            Get
                Return mu_id
            End Get
            Set(ByVal value As String)
                mu_id = value
            End Set
        End Property

        Public Property u_name() As String
            Get
                Return mu_name
            End Get
            Set(ByVal value As String)
                mu_name = value
            End Set
        End Property

        Public Property lastname() As String
            Get
                Return mlastname
            End Get
            Set(ByVal value As String)
                mlastname = value
            End Set
        End Property

        Public Property desigcd() As String
            Get
                Return mdesigcd
            End Get
            Set(ByVal value As String)
                mdesigcd = value
            End Set
        End Property

        Public Property pass() As String
            Get
                Return mpass
            End Get
            Set(ByVal value As String)
                mpass = value
            End Set
        End Property

        Public Property reportingto() As String
            Get
                Return mreportingto
            End Get
            Set(ByVal value As String)
                mreportingto = value
            End Set
        End Property

        Public Property active() As String
            Get
                Return mactive
            End Get
            Set(ByVal value As String)
                mactive = value
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

        Public Property emailid() As String
            Get
                Return memailid
            End Get
            Set(ByVal value As String)
                memailid = value
            End Set
        End Property

        Public Property lastpasschangedt() As String
            Get
                Return mlastpasschangedt
            End Get
            Set(ByVal value As String)
                mlastpasschangedt = value
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

        Public Shared Function FillData(ByVal u_id As String, ByVal Flag As String) As ClsUserMaster
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@u_id", u_id))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_users_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsUserMaster = New ClsUserMaster
                    If Not IsDBNull(dt.Rows(0)("u_id")) Then
                        obj.u_id = dt.Rows(0)("u_id").ToString
                    End If
                    obj.u_name = dt.Rows(0)("u_name").ToString
                    obj.lastname = dt.Rows(0)("lastname").ToString
                    obj.pass = dt.Rows(0)("pass").ToString


                    If Not IsDBNull(dt.Rows(0)("desigcd")) Then
                        obj.desigcd = dt.Rows(0)("desigcd").ToString
                    End If
                    If Not IsDBNull(dt.Rows(0)("reportingto")) Then
                        obj.reportingto = dt.Rows(0)("reportingto").ToString
                    End If
                    obj.active = dt.Rows(0)("active").ToString
                    obj.mobileno = dt.Rows(0)("mobileno").ToString
                    obj.emailid = dt.Rows(0)("emailid").ToString
                    obj.lastpasschangedt = dt.Rows(0)("lastpasschangedt").ToString
                    obj.administrator = dt.Rows(0)("administrator").ToString
                    obj.allowbilling = dt.Rows(0)("allowbilling").ToString
                    obj.allowbilldone_close = dt.Rows(0)("allowbilldone_close").ToString

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal u_id As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@u_id", u_id))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_users_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function



        Public Shared Function Update_Data(ByVal o As ClsUserMaster, ByVal mode As String) As Integer
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

            If o.u_id = "" Then
                Com1.Parameters.Add(New SqlParameter("@u_id", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@u_id", o.u_id))
            End If
            Com1.Parameters.Add(New SqlParameter("@u_name", o.u_name))
            Com1.Parameters.Add(New SqlParameter("@lastname", o.lastname))


            Com1.Parameters.Add(New SqlParameter("@pass", o.pass))


            If o.desigcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@desigcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@desigcd", o.desigcd))
            End If

            If o.reportingto = "" Then
                Com1.Parameters.Add(New SqlParameter("@reportingto", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@reportingto", o.reportingto))
            End If


            Com1.Parameters.Add(New SqlParameter("@active", o.active))
            Com1.Parameters.Add(New SqlParameter("@mobileno", o.mobileno))
            Com1.Parameters.Add(New SqlParameter("@emailid", o.emailid))
            Com1.Parameters.Add(New SqlParameter("@lastpasschangedt", o.lastpasschangedt))
            Com1.Parameters.Add(New SqlParameter("@administrator", o.administrator))
            Com1.Parameters.Add(New SqlParameter("@allowbilling", o.allowbilling))
            Com1.Parameters.Add(New SqlParameter("@allowbilldone_close", o.allowbilldone_close))



            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_users_AE"
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

        Public Shared Function Delete(ByVal o As ClsUserMaster) As Integer
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

            Com1.Parameters.Add(New SqlParameter("@u_id", o.u_id))

            Ssql1 = "Sp_users_Delete"
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
            s = DBAccess.Find_Value("users", "u_name", "u_id", Trim(strcode))
            If s IsNot Nothing Then
                CheckDuplicate = s.ToString
            End If
        End Function

        Public Shared Function CheckDuplicate_User(ByVal strcode As String) As String
            Try
                Dim s As Object
                CheckDuplicate_User = ""
                s = DBAccess.Find_Value("users", "u_id", "u_id", Trim(strcode))
                If s IsNot Nothing Then
                    CheckDuplicate_User = s.ToString
                End If
            Catch ex As Exception
                Throw ex
            End Try
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
            com.CommandText = "CheckIntegrity_users_Sp"
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


        Public Shared Function Find_desigcdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_desigcdCode = ""
            s = DBAccess.Find_Value("designation", "desigcd", "designame", Trim(strcode))
            If s IsNot Nothing Then
                Find_desigcdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_desigcdName(ByVal strcode As String) As String
            Dim s As Object
            Find_desigcdName = ""
            s = DBAccess.Find_Value("designation", "designame", "desigcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_desigcdName = s.ToString
            End If
        End Function

    End Class
End Namespace
