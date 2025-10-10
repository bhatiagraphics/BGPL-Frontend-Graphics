Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsRateList
        Private msrno As String
        Private mcuscode As String
        Private mplatetypecd As String
        Private mrate As String
        Private mrdate As String


        Public Property srno() As String
            Get
                Return msrno
            End Get
            Set(ByVal value As String)
                msrno = value
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

        Public Property platetypecd() As String
            Get
                Return mplatetypecd
            End Get
            Set(ByVal value As String)
                mplatetypecd = value
            End Set
        End Property

        Public Property rate() As String
            Get
                Return mrate
            End Get
            Set(ByVal value As String)
                mrate = value
            End Set
        End Property

        Public Property rdate() As String
            Get
                Return mrdate
            End Get
            Set(ByVal value As String)
                mrdate = value
            End Set
        End Property
        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function FillData(ByVal srno As String, ByVal Flag As String) As ClsRateList
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@srno", srno))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_RateList_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsRateList = New ClsRateList
                    obj.srno = dt.Rows(0)("srno").ToString
                    obj.cuscode = dt.Rows(0)("cuscode").ToString
                    obj.platetypecd = dt.Rows(0)("platetypecd").ToString
                    obj.rate = dt.Rows(0)("rate").ToString
                    obj.rdate = dt.Rows(0)("rdate").ToString

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal srno As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@srno", srno))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_RateList_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDocCode() As String
            Try
                Dim sSQL As String, objDas As New DBAccess, dt As DataTable
                sSQL = "SELECT MAX(cast(srno as Integer)) AS srno FROM ratelist"
                dt = objDas.GetDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("srno")) Then
                        If dt.Rows(0).Item("srno").ToString <> "" Then
                            GetDocCode = dt.Rows(0)("srno").ToString + 1
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

        Public Shared Function Update_Data(ByVal o As ClsRateList, ByVal mode As String) As Integer
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

            If o.platetypecd = "" Then
                Com1.Parameters.Add(New SqlParameter("@platetypecd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@platetypecd", o.platetypecd))
            End If
            Com1.Parameters.Add(New SqlParameter("@srno", o.srno))
            Com1.Parameters.Add(New SqlParameter("@cuscode", o.cuscode))
            Com1.Parameters.Add(New SqlParameter("@rate", o.rate))
            Com1.Parameters.Add(New SqlParameter("@rdate", o.rdate))

            'Com1.Parameters.Add(New SqlParameter("@platetypecd", o.platetypecd))


            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_RateList_AE"
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


        Public Shared Function CheckDuplicate_PS(ByVal platetypecd As String, ByVal cuscode As String, ByVal rdate As String) As String
            Dim s As Object
            CheckDuplicate_PS = ""
            s = Check_duplicate_Entry(Trim(platetypecd), Trim(cuscode), Trim(rdate))
            If s IsNot Nothing Then
                CheckDuplicate_PS = s.ToString
            End If
        End Function

        Public Shared Function Check_duplicate_Entry(ByVal platetypecd As String, ByVal cuscode As String, ByVal rdate As String) As String
            Dim con As New SqlConnection
            Dim com As New SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "CheckDuplicate_RateList"
            com.Parameters.AddWithValue("@cuscode", Trim(cuscode))
            com.Parameters.AddWithValue("@platetypecd", Trim(platetypecd))
            com.Parameters.AddWithValue("@rdate", Trim(rdate))

            pr = com.Parameters.Add("@retval", SqlDbType.VarChar, 255)
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
                obj = Nothing
            End If
            Return obj
        End Function

        Public Shared Function Delete(ByVal o As ClsRateList) As Integer
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

            Com1.Parameters.Add(New SqlParameter("@srno", o.srno))

            Ssql1 = "Sp_RateList_Delete"
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
            'Dim con As SqlConnection
            'Dim com As SqlCommand
            'Dim pr As SqlParameter
            'Dim obj As Object

            'con = GetConnection()
            'com = New SqlCommand
            'com.Connection = con
            'com.Commandcuscode = Commandcuscode.StoredProcedure
            'com.CommandText = "CheckIntegrity_domesticpricelistmaster_Sp"
            'com.Parameters.AddWithValue("@code", Trim(strcode))
            'pr = com.Parameters.Add("@reftblname", SqlDbcuscode.Char, 60)
            'pr.Direction = ParameterDirection.Output

            'Try
            '    con.Open()
            '    com.ExecuteNonQuery()
            'Catch ex As Exception
            '    Throw ex
            'Finally
            '    con.Close()
            '    con = Nothing
            '    com = Nothing
            'End Try

            'obj = pr.Value
            'If IsDBNull(obj) = True Or obj.ToString = "" Then
            '    obj = Nothing
            'End If

            'Return obj

        End Function


        Public Shared Function Find_platetypecdCode(ByVal strcode As String) As String
            Dim s As Object
            Find_platetypecdCode = ""
            s = DBAccess.Find_Value("fggroup", "platetypecd", "fggrpname", Trim(strcode))
            If s IsNot Nothing Then
                Find_platetypecdCode = s.ToString
            End If
        End Function

        Public Shared Function Find_platetypecdName(ByVal strcode As String) As String
            Dim s As Object
            Find_platetypecdName = ""
            s = DBAccess.Find_Value("fggroup", "fggrpname", "platetypecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_platetypecdName = s.ToString
            End If
        End Function

    End Class
End Namespace
