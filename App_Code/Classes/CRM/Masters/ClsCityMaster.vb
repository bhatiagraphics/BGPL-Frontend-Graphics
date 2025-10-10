Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsCityMaster
        Private mcitycd As String
        Private mcityname As String
        Private mstatecd As String
        Private mcountrycd As String

        Public Shared countrycd1, countryname1, statecd1, statename1 As String


        Public Property citycd() As String
            Get
                Return mcitycd
            End Get
            Set(ByVal value As String)
                mcitycd = value
            End Set
        End Property

        Public Property cityname() As String
            Get
                Return mcityname
            End Get
            Set(ByVal value As String)
                mcityname = value
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

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function FillData(ByVal citycd As String, ByVal Flag As String) As ClsCityMaster
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@citycd", citycd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_city_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsCityMaster = New ClsCityMaster
                    If Not IsDBNull(dt.Rows(0)("citycd")) Then
                        obj.citycd = dt.Rows(0)("citycd").ToString
                    End If
                    obj.cityname = dt.Rows(0)("cityname").ToString

                    If Not IsDBNull(dt.Rows(0)("statecd")) Then
                        obj.statecd = dt.Rows(0)("statecd").ToString
                    End If

                    If Not IsDBNull(dt.Rows(0)("countrycd")) Then
                        obj.countrycd = dt.Rows(0)("countrycd").ToString
                    End If

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal citycd As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@citycd", citycd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_city_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDocCode() As String
            Try
                Dim sSQL As String, objDas As New DBAccess, dt As DataTable
                sSQL = "SELECT MAX(cast(citycd as Integer)) AS citycd FROM city"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("citycd")) Then
                        If dt.Rows(0).Item("citycd").ToString <> "" Then
                            GetDocCode = dt.Rows(0)("citycd").ToString + 1
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

        Public Shared Function Update_Data(ByVal o As ClsCityMaster, ByVal mode As String) As Integer
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

            If o.citycd = "" Then
                Com1.Parameters.Add(New SqlParameter("@citycd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@citycd", o.citycd))
            End If
            Com1.Parameters.Add(New SqlParameter("@cityname", o.cityname))

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

            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_city_AE"
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

        Public Shared Function Delete(ByVal o As ClsCityMaster) As Integer
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

            Com1.Parameters.Add(New SqlParameter("@citycd", o.citycd))

            Ssql1 = "Sp_city_Delete"
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
            s = DBAccess.Find_Value("city", "cityname", "citycd", Trim(strcode))
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
            com.CommandText = "CheckIntegrity_city_Sp"
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

        Public Shared Function FillCountryDetails(ByVal statecd As String) As ClsCityMaster
            Try
                Dim sSQL As String, objDas As New DBAccess, dt As DataTable
                sSQL = "Select S.countrycd,CO.countryname,S.statecd,S.statename "
                sSQL += "From COUNTRY CO,STATE S "
                sSQL += "Where CO.countrycd =S.countrycd And S.statecd = '" & Trim(statecd) & "'"


                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    statecd1 = dt.Rows(0)("statecd").ToString
                    statename1 = dt.Rows(0)("statename").ToString
                    countrycd1 = dt.Rows(0)("countrycd").ToString
                    countryname1 = dt.Rows(0)("countryname").ToString
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function


    End Class
End Namespace
