Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsSubIndustryMaster
        Private msubindcd As String
        Private msubindname As String
        Private mindcd As String

        Public Property subindcd() As String
            Get
                Return msubindcd
            End Get
            Set(ByVal value As String)
                msubindcd = value
            End Set
        End Property

        Public Property subindname() As String
            Get
                Return msubindname
            End Get
            Set(ByVal value As String)
                msubindname = value
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

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function FillData(ByVal subindcd As String, ByVal Flag As String) As ClsSubIndustryMaster
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@subindcd", subindcd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_SubIndustryMaster_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsSubIndustryMaster = New ClsSubIndustryMaster
                    If Not IsDBNull(dt.Rows(0)("subindcd")) Then
                        obj.subindcd = dt.Rows(0)("subindcd").ToString
                    End If
                    obj.subindname = dt.Rows(0)("subindname").ToString
                    If Not IsDBNull(dt.Rows(0)("indcd")) Then
                        obj.indcd = dt.Rows(0)("indcd").ToString
                    End If

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal subindcd As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@subindcd", subindcd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_SubIndustryMaster_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDocCode() As String
            Try
                Dim sSQL As String, objDas As New DBAccess, dt As DataTable
                sSQL = "SELECT MAX(cast(subindcd as Integer)) AS subindcd FROM crmsubindustry"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("subindcd")) Then
                        If dt.Rows(0).Item("subindcd").ToString <> "" Then
                            GetDocCode = dt.Rows(0)("subindcd").ToString + 1
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

        Public Shared Function Update_Data(ByVal o As ClsSubIndustryMaster, ByVal mode As String) As Integer
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

            If o.subindcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@subindcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@subindcd", o.subindcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@subindname", o.subindname))
            If o.indcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@indcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@indcd", o.indcd))
            End If

            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_SubIndustryMaster_AE"
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

        Public Shared Function Delete(ByVal o As ClsSubIndustryMaster) As Integer
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

            Com1.Parameters.Add(New SqlParameter("@subindcd", o.subindcd))

            Ssql1 = "Sp_SubIndustryMaster_Delete"
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
            s = DBAccess.Find_Value("crmsubindustry", "subindname", "subindcd", Trim(strcode))
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
            com.CommandText = "CheckIntegrity_SubIndustryMaster_Sp"
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

        Public Shared Function Find_indcdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_indcdCode = ""
            s = DBAccess.Find_Value("crmindustry", "indcd", "indname", Trim(strcode))
            If s IsNot Nothing Then
                Find_indcdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_indcdName(ByVal strcode As String) As String
            Dim s As Object
            Find_indcdName = ""
            s = DBAccess.Find_Value("crmindustry", "indname", "indcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_indcdName = s.ToString
            End If
        End Function

    End Class
End Namespace
