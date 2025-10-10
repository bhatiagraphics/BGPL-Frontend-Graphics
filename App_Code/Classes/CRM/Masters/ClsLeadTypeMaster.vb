Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsLeadTypeMaster
        Private mleadtypecd As String
        Private mleadtypename As String

        Public Property leadtypecd() As String
            Get
                Return mleadtypecd
            End Get
            Set(ByVal value As String)
                mleadtypecd = value
            End Set
        End Property

        Public Property leadtypename() As String
            Get
                Return mleadtypename
            End Get
            Set(ByVal value As String)
                mleadtypename = value
            End Set
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function FillData(ByVal leadtypecd As String, ByVal Flag As String) As ClsLeadTypeMaster
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@leadtypecd", leadtypecd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_LeadTypeMaster_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsLeadTypeMaster = New ClsLeadTypeMaster
                    If Not IsDBNull(dt.Rows(0)("leadtypecd")) Then
                        obj.leadtypecd = dt.Rows(0)("leadtypecd").ToString
                    End If
                    obj.leadtypename = dt.Rows(0)("leadtypename").ToString

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal leadtypecd As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@leadtypecd", leadtypecd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_LeadTypeMaster_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDocCode() As String
            Try
                Dim sSQL As String, objDas As New DBAccess, dt As DataTable
                sSQL = "SELECT MAX(cast(leadtypecd as Integer)) AS leadtypecd FROM crmleadtype"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("leadtypecd")) Then
                        If dt.Rows(0).Item("leadtypecd").ToString <> "" Then
                            GetDocCode = dt.Rows(0)("leadtypecd").ToString + 1
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

        Public Shared Function Update_Data(ByVal o As ClsLeadTypeMaster, ByVal mode As String) As Integer
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

            If o.leadtypecd = "" Then
                Com1.Parameters.Add(New SqlParameter("@leadtypecd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@leadtypecd", o.leadtypecd))
            End If
            Com1.Parameters.Add(New SqlParameter("@leadtypename", o.leadtypename))
            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_LeadTypeMaster_AE"
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

        Public Shared Function Delete(ByVal o As ClsLeadTypeMaster) As Integer
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

            Com1.Parameters.Add(New SqlParameter("@leadtypecd", o.leadtypecd))

            Ssql1 = "Sp_LeadTypeMaster_Delete"
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
            s = DBAccess.Find_Value("crmleadtype", "leadtypename", "leadtypecd", Trim(strcode))
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
            com.CommandText = "CheckIntegrity_LeadTypeMaster_Sp"
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

    End Class
End Namespace
