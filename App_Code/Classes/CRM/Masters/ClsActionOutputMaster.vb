Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsActionOutputMaster
        Private moutputcd As String
        Private msrno As String
        Private moutputname As String
        Private macttypecd As String

        Public Property outputcd() As String
            Get
                Return moutputcd
            End Get
            Set(ByVal value As String)
                moutputcd = value
            End Set
        End Property
        Public Property srno() As String
            Get
                Return msrno
            End Get
            Set(ByVal value As String)
                msrno = value
            End Set
        End Property

        Public Property outputname() As String
            Get
                Return moutputname
            End Get
            Set(ByVal value As String)
                moutputname = value
            End Set
        End Property

        Public Property acttypecd() As String
            Get
                Return macttypecd
            End Get
            Set(ByVal value As String)
                macttypecd = value
            End Set
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function FillData(ByVal outputcd As String, ByVal Flag As String) As ClsActionOutputMaster
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@outputcd", outputcd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_ActionOutputMaster_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsActionOutputMaster = New ClsActionOutputMaster
                    If Not IsDBNull(dt.Rows(0)("outputcd")) Then
                        obj.outputcd = dt.Rows(0)("outputcd").ToString
                    End If
                    obj.srno = dt.Rows(0)("srno").ToString

                    obj.outputname = dt.Rows(0)("outputname").ToString
                    If Not IsDBNull(dt.Rows(0)("acttypecd")) Then
                        obj.acttypecd = dt.Rows(0)("acttypecd").ToString
                    End If

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal outputcd As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@outputcd", outputcd))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_ActionOutputMaster_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDocCode() As String
            Try
                Dim sSQL As String, objDas As New DBAccess, dt As DataTable
                sSQL = "SELECT MAX(cast(outputcd as Integer)) AS outputcd FROM crmactionoutput"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("outputcd")) Then
                        If dt.Rows(0).Item("outputcd").ToString <> "" Then
                            GetDocCode = dt.Rows(0)("outputcd").ToString + 1
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

        Public Shared Function Update_Data(ByVal o As ClsActionOutputMaster, ByVal mode As String) As Integer
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

            If o.outputcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@outputcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@outputcd", o.outputcd))
            End If
            Com1.Parameters.Add(New SqlParameter("@srno", o.srno))

            Com1.Parameters.Add(New SqlParameter("@outputname", o.outputname))
            If o.acttypecd = "" Then
                Com1.Parameters.Add(New SqlParameter("@acttypecd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@acttypecd", o.acttypecd))
            End If

            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_ActionOutputMaster_AE"
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

        Public Shared Function Delete(ByVal o As ClsActionOutputMaster) As Integer
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

            Com1.Parameters.Add(New SqlParameter("@outputcd", o.outputcd))

            Ssql1 = "Sp_ActionOutputMaster_Delete"
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
            s = DBAccess.Find_Value("crmactionoutput", "outputname", "outputcd", Trim(strcode))
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
            com.CommandText = "CheckIntegrity_ActionOutputMaster_Sp"
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

        Public Shared Function Find_acttypecdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_acttypecdCode = ""
            s = DBAccess.Find_Value("crmactivitytype", "acttypecd", "acttypename", Trim(strcode))
            If s IsNot Nothing Then
                Find_acttypecdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_acttypecdName(ByVal strcode As String) As String
            Dim s As Object
            Find_acttypecdName = ""
            s = DBAccess.Find_Value("crmactivitytype", "acttypename", "acttypecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_acttypecdName = s.ToString
            End If
        End Function

    End Class
End Namespace
