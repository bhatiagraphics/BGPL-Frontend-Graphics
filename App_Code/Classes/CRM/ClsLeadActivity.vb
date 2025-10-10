Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsLeadActivity
        Private mactivityno As String
        Private mactivitysrno As String
        Private mcontactcd As String
        Private macttypecd As String
        Private mactivitydate As String
        Private mactivitytime As String

        Private moutputcd As String
        Private mjfw As String
        Private mjfwcd As String
        Private mnextoutputcd As String
        Private mnextoutputdate As String
        Private mnextoutputtime As String
        Private mcomments As String
        Private mcrtuserid As String
        Private mcrtuserdt As String
        Private mmoduserid As String
        Private mmoduserdt As String
        Private mnextactivity As String

        Public Property nextactivity() As String
            Get
                Return mnextactivity
            End Get
            Set(ByVal value As String)
                mnextactivity = value
            End Set
        End Property
        Public Property activityno() As String
            Get
                Return mactivityno
            End Get
            Set(ByVal value As String)
                mactivityno = value
            End Set
        End Property

        Public Property activitysrno() As String
            Get
                Return mactivitysrno
            End Get
            Set(ByVal value As String)
                mactivitysrno = value
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

        Public Property acttypecd() As String
            Get
                Return macttypecd
            End Get
            Set(ByVal value As String)
                macttypecd = value
            End Set
        End Property

        Public Property activitydate() As String
            Get
                Return mactivitydate
            End Get
            Set(ByVal value As String)
                mactivitydate = value
            End Set
        End Property

        Public Property activitytime() As String
            Get
                Return mactivitytime
            End Get
            Set(ByVal value As String)
                mactivitytime = value
            End Set
        End Property

        Public Property outputcd() As String
            Get
                Return moutputcd
            End Get
            Set(ByVal value As String)
                moutputcd = value
            End Set
        End Property

        Public Property jfw() As String
            Get
                Return mjfw
            End Get
            Set(ByVal value As String)
                mjfw = value
            End Set
        End Property

        Public Property jfwcd() As String
            Get
                Return mjfwcd
            End Get
            Set(ByVal value As String)
                mjfwcd = value
            End Set
        End Property

        Public Property nextoutputcd() As String
            Get
                Return mnextoutputcd
            End Get
            Set(ByVal value As String)
                mnextoutputcd = value
            End Set
        End Property

        Public Property nextoutputdate() As String
            Get
                Return mnextoutputdate
            End Get
            Set(ByVal value As String)
                mnextoutputdate = value
            End Set
        End Property

        Public Property nextoutputtime() As String
            Get
                Return mnextoutputtime
            End Get
            Set(ByVal value As String)
                mnextoutputtime = value
            End Set
        End Property

        Public Property comments() As String
            Get
                Return mcomments
            End Get
            Set(ByVal value As String)
                mcomments = value
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




        Public Shared Function FillData(ByVal activityno As String, ByVal Flag As String) As ClsLeadActivity
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@contactcd", ""))
                db.Parameters.Add(New SqlParameter("@activityno", activityno))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_crmactivity_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As ClsLeadActivity = New ClsLeadActivity
                    If Not IsDBNull(dt.Rows(0)("activityno")) Then
                        obj.activityno = dt.Rows(0)("activityno").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("contactcd").ToString) Then
                        obj.contactcd = ""
                    Else
                        obj.contactcd = dt.Rows(0)("contactcd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("acttypecd").ToString) Then
                        obj.acttypecd = ""
                    Else
                        obj.acttypecd = dt.Rows(0)("acttypecd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("activitydate").ToString) Then
                        obj.activitydate = ""
                    Else
                        obj.activitydate = dt.Rows(0)("activitydate").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("activitytime").ToString) Then
                        obj.activitytime = ""
                    Else
                        obj.activitytime = dt.Rows(0)("activitytime").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("outputcd").ToString) Then
                        obj.outputcd = ""
                    Else
                        obj.outputcd = dt.Rows(0)("outputcd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("jfw").ToString) Then
                        obj.jfw = ""
                    Else
                        obj.jfw = dt.Rows(0)("jfw").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("jfwcd").ToString) Then
                        obj.jfwcd = ""
                    Else
                        obj.jfwcd = dt.Rows(0)("jfwcd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("nextoutputcd").ToString) Then
                        obj.nextoutputcd = ""
                    Else
                        obj.nextoutputcd = dt.Rows(0)("nextoutputcd").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("nextoutputdate").ToString) Then
                        obj.nextoutputdate = ""
                    Else
                        obj.nextoutputdate = dt.Rows(0)("nextoutputdate").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("nextoutputtime").ToString) Then
                        obj.nextoutputtime = ""
                    Else
                        obj.nextoutputtime = dt.Rows(0)("nextoutputtime").ToString
                    End If
                    If IsDBNull(dt.Rows(0)("comments").ToString) Then
                        obj.comments = ""
                    Else
                        obj.comments = dt.Rows(0)("comments").ToString
                    End If

                    If IsDBNull(dt.Rows(0)("nextactivity").ToString) Then
                        obj.nextactivity = ""
                    Else
                        obj.nextactivity = dt.Rows(0)("nextactivity").ToString
                    End If

                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function Update_Data(ByVal o As ClsLeadActivity, ByVal mode As String) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim Com1, Com2, com31, com32, com33, com34, com35 As SqlCommand
            Dim Ssql1, Ssql2, Ssql31, Ssql32, Ssql33, Ssql34, Ssql35 As String
            Dim i As Integer

            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure

            Com2 = New SqlCommand
            Com2.Connection = Con
            Com2.CommandType = CommandType.Text

            com31 = New SqlCommand
            com31.Connection = Con
            com31.CommandType = CommandType.Text
            com32 = New SqlCommand
            com32.Connection = Con
            com32.CommandType = CommandType.Text
            com33 = New SqlCommand
            com33.Connection = Con
            com33.CommandType = CommandType.Text
            com34 = New SqlCommand
            com34.Connection = Con
            com34.CommandType = CommandType.Text
            com35 = New SqlCommand
            com35.Connection = Con
            com35.CommandType = CommandType.Text

            If o.activityno = "" Then
                Com1.Parameters.Add(New SqlParameter("@activityno", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@activityno", o.activityno))
            End If
            Com1.Parameters.Add(New SqlParameter("@activitysrno", o.activitysrno))
            Com1.Parameters.Add(New SqlParameter("@contactcd", o.contactcd))
            Com1.Parameters.Add(New SqlParameter("@acttypecd", o.acttypecd))
            Com1.Parameters.Add(New SqlParameter("@activitydate", o.activitydate))
            Com1.Parameters.Add(New SqlParameter("@activitytime", o.activitytime))
            Com1.Parameters.Add(New SqlParameter("@outputcd", o.outputcd))
            Com1.Parameters.Add(New SqlParameter("@jfw", o.jfw))
            Com1.Parameters.Add(New SqlParameter("@jfwcd", System.DBNull.Value))

            If o.nextoutputcd = "" Then
                Com1.Parameters.Add(New SqlParameter("@nextoutputcd", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@nextoutputcd", o.nextoutputcd))
            End If

            If o.nextactivity = "" Then
                Com1.Parameters.Add(New SqlParameter("@nextactivity", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@nextactivity", o.nextactivity))
            End If

            Com1.Parameters.Add(New SqlParameter("@nextoutputdate", o.nextoutputdate))
            Com1.Parameters.Add(New SqlParameter("@nextoutputtime", o.nextoutputtime))
            Com1.Parameters.Add(New SqlParameter("@comments", o.comments))


            Com1.Parameters.Add(New SqlParameter("@crtuserid", o.crtuserid))
            Com1.Parameters.Add(New SqlParameter("@crtuserdt", o.crtuserdt))
            Com1.Parameters.Add(New SqlParameter("@moduserid", o.moduserid))
            Com1.Parameters.Add(New SqlParameter("@moduserdt", o.moduserdt))

            If UCase(mode.Trim) = "ADD" Then
                Com1.Parameters.Add(New SqlParameter("@Flag", "A"))
            Else
                Com1.Parameters.Add(New SqlParameter("@Flag", "E"))
            End If

            Ssql1 = "Sp_crmactivity_AE"
            Com1.CommandText = Ssql1
            Com1.Transaction = Trans

            If UCase(mode.Trim) = "ADD" Then
                Ssql2 = "update crmcontacts set lastoutputcd='" & o.outputcd & "',lastoutputdate=convert(smalldatetime,'" & o.activitydate & "',103),nextoutputcd='" & o.nextoutputcd & "',nextoutputdate=convert(smalldatetime,'" & o.nextoutputdate & "',103) where contactcd='" & o.contactcd & "'"
                Com2.CommandText = Ssql2
                Com2.Transaction = Trans


            End If

            Try
                i = Com1.ExecuteNonQuery()
                If UCase(mode.Trim) = "ADD" Then
                    i = Com2.ExecuteNonQuery()

                End If
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



        Public Shared Function Find_ContactName(ByVal strcode As String) As String
            Dim s As Object
            Find_ContactName = ""
            s = DBAccess.Find_Value("crmcontacts", "contactcd", "contactname", Trim(strcode))
            If s IsNot Nothing Then
                Find_ContactName = s.ToString
            End If
        End Function



        Public Shared Function GetDocCode() As String
            Dim sSQL As String, objDas As New DBAccess, dt As DataTable
            sSQL = "SELECT MAX(cast(activityno as Integer)) AS activityno FROM crmactivity"
            dt = objDas.GetDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item("activityno")) Then
                    If dt.Rows(0).Item("activityno").ToString <> "" Then
                        GetDocCode = dt.Rows(0)("activityno").ToString + 1
                    Else
                        GetDocCode = 1
                    End If
                Else
                    GetDocCode = 1
                End If
            End If
            Return GetDocCode
        End Function

        Public Shared Function GetSrno(ByVal ContactCode As String) As String
            Dim sSQL As String, objDas As New DBAccess, dt As DataTable
            sSQL = "SELECT MAX(activitysrno) AS srno FROM crmactivity where contactcd ='" & Trim(ContactCode) & "'"
            dt = objDas.GetDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item("srno")) Then
                    If dt.Rows(0).Item("srno").ToString <> "" Then
                        GetSrno = dt.Rows(0)("srno").ToString + 1
                    Else
                        GetSrno = 1
                    End If
                Else
                    GetSrno = 1
                End If
            End If
            Return GetSrno
        End Function





        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function CheckDuplicate(ByVal strcode As String) As String
            Try
                Dim s As Object
                CheckDuplicate = ""
                s = DBAccess.Find_Value("activity", "Actioncd", "activityno", Trim(strcode))
                If s IsNot Nothing Then
                    CheckDuplicate = s.ToString
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function Find_Value(ByVal Table As String, ByVal Code As String, ByVal Name As String, ByVal value As Object) As Object
            Dim con As New SqlConnection
            Dim com As New SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "crmChkDuplicate_sp"
            com.Parameters.AddWithValue("tab", Trim(Table))
            com.Parameters.AddWithValue("code", Trim(Code))
            com.Parameters.AddWithValue("desc", Trim(Name))
            com.Parameters.AddWithValue("para", Trim(value))
            pr = com.Parameters.Add("RetVal", SqlDbType.VarChar, 500)
            pr.Direction = ParameterDirection.Output

            Try
                con.Open()
                com.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
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

        Public Shared Function CompanyCode() As String
            CompanyCode = "Z"
        End Function

        Public Shared Function GetCommand() As SqlCommand
            Return New SqlCommand()
        End Function

        Public Shared Function Find_Citycd(ByVal strcode As String) As String
            Dim s As Object
            Find_Citycd = ""
            s = DBAccess.Find_Value("crmcity", "cityname", "citycd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Citycd = s.ToString
            End If
        End Function
        Public Shared Function Find_Statecd(ByVal strcode As String) As String
            Dim s As Object
            Find_Statecd = ""
            s = DBAccess.Find_Value("crmstate", "statename", "statecd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Statecd = s.ToString
            End If
        End Function
        Public Shared Function Find_Countrycd(ByVal strcode As String) As String
            Dim s As Object
            Find_Countrycd = ""
            s = DBAccess.Find_Value("crmcountry", "countryname", "countrycd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Countrycd = s.ToString
            End If
        End Function
        Public Shared Function Find_Areacd(ByVal strcode As String) As String
            Dim s As Object
            Find_Areacd = ""
            s = DBAccess.Find_Value("crmarea", "areaname", "areacd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Areacd = s.ToString
            End If
        End Function

    End Class
End Namespace
