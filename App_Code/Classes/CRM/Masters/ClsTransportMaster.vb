Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsTransportMaster
        Private mtranscd As String
        Private mtransname As String

        Public Property transcd() As String
            Get
                Return mtranscd
            End Get
            Set(ByVal value As String)
                mtranscd = value
            End Set
        End Property

        Public Property transname() As String
            Get
                Return mtransname
            End Get
            Set(ByVal value As String)
                mtransname = value
            End Set
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function FillData(ByVal transcd As String, ByVal Flag As String) As ClsTransportMaster
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@transcd", transcd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_transport_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsTransportMaster = New ClsTransportMaster
                    If Not IsDBNull(dt.Rows(0)("transcd")) Then
                        obj.transcd = dt.Rows(0)("transcd").ToString
                    End If
                    obj.transname = dt.Rows(0)("transname").ToString

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal transcd As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@transcd", transcd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_transport_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDocCode() As String
            Try
                Dim sSQL As String, objDas As New DBAccess, dt As DataTable
                sSQL = "SELECT MAX(cast(transcd as Integer)) AS transcd FROM transport"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("transcd")) Then
                        If dt.Rows(0).Item("transcd").ToString <> "" Then
                            GetDocCode = dt.Rows(0)("transcd").ToString + 1
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

        Public Shared Function Update_Data(ByVal o As ClsTransportMaster, ByVal mode As String) As Integer
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

            If o.transcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@transcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@transcd", o.transcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@transname", o.transname))
            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_transport_AE"
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

        Public Shared Function Delete(ByVal o As ClsTransportMaster) As Integer
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

            Com1.Parameters.Add(New SqlParameter("@transcd", o.transcd))

            Ssql1 = "Sp_transport_Delete"
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
            s = DBAccess.Find_Value("transport", "transname", "transcd", Trim(strcode))
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
            com.CommandText = "CheckIntegrity_transport_Sp"
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
