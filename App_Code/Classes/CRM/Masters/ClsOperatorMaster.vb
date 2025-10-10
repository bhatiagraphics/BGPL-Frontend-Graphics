Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsOperatorMaster
        Private mopcode As String
        Private mopname As String

        Public Property opcode() As String
            Get
                Return mopcode
            End Get
            Set(ByVal value As String)
                mopcode = value
            End Set
        End Property

        Public Property opname() As String
            Get
                Return mopname
            End Get
            Set(ByVal value As String)
                mopname = value
            End Set
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function FillData(ByVal opcode As String, ByVal Flag As String) As ClsOperatorMaster
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@opcode", opcode))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_operator_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsOperatorMaster = New ClsOperatorMaster
                    If Not IsDBNull(dt.Rows(0)("opcode")) Then
                        obj.opcode = dt.Rows(0)("opcode").ToString
                    End If
                    obj.opname = dt.Rows(0)("opname").ToString

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal opcode As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@opcode", opcode))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_operator_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDocCode() As String
            Try
                Dim sSQL As String, objDas As New DBAccess, dt As DataTable
                sSQL = "SELECT MAX(cast(opcode as Integer)) AS opcode FROM operator"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("opcode")) Then
                        If dt.Rows(0).Item("opcode").ToString <> "" Then
                            GetDocCode = dt.Rows(0)("opcode").ToString + 1
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

        Public Shared Function Update_Data(ByVal o As ClsOperatorMaster, ByVal mode As String) As Integer
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

            If o.opcode = "" Then
                Com1.Parameters.Add(New SqlParameter("@opcode", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@opcode", o.opcode))
            End If
            Com1.Parameters.Add(New SqlParameter("@opname", o.opname))
            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_operator_AE"
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

        Public Shared Function Delete(ByVal o As ClsOperatorMaster) As Integer
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

            Com1.Parameters.Add(New SqlParameter("@opcode", o.opcode))

            Ssql1 = "Sp_operator_Delete"
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
            s = DBAccess.Find_Value("operator", "opname", "opcode", Trim(strcode))
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
            com.CommandText = "CheckIntegrity_operator_Sp"
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
