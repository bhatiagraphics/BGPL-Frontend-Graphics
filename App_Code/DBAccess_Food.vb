Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Namespace FOODERPWEB.DAL
    Public Class DBAccess
        Private cmd As IDbCommand = New SqlCommand()
        Private tran As IDbTransaction = Nothing
        Public Shared sCon As String = ""
        Private handleErrors As Boolean = False
        Private strLastError As String = ""
        Dim newServerName As String
        Dim newDatabaseName As String
        Dim userID As String
        Dim password As String, sIntegratedSecurity As String
        Public Shared GetDbName As String = ""
        Public Shared ErrorInSO As String = ""
        Public Shared CmpName As String
        Public Shared CmpCode As String
        Public Shared FinStart As String
        Public Shared FinEnd As String

        Public Function GetDataset(ByVal SQL As String) As DataSet
            Dim da As SqlDataAdapter = Nothing
            Dim dt As DataSet = Nothing
            Dim cnn As New SqlConnection()
            Try
                cnn.ConnectionString = sCon
                Dim cmd1 As New SqlClient.SqlCommand(SQL, cnn)
                da = New SqlDataAdapter()
                cmd1.CommandText = SQL
                da.SelectCommand = cmd1
                dt = New DataSet()
                da.Fill(dt)
            Catch ex As Exception
                If (handleErrors) Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return dt
        End Function

        Public Sub New()
            Dim objConnectionStringSettings As ConnectionStringSettings
            objConnectionStringSettings = ConfigurationManager.ConnectionStrings("ConStrFood")
            sCon = objConnectionStringSettings.ConnectionString
            Dim cnn As New SqlConnection()
            cnn.ConnectionString = sCon
            cmd.Connection = cnn
            cmd.CommandType = CommandType.StoredProcedure
        End Sub

        Public Function ExecuteReader() As IDataReader
            Dim reader As IDataReader = Nothing
            Try
                Me.Open()
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                'Me.Close()
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return reader
        End Function

        Public Function ExecuteReader(ByVal commandtext As String) As IDataReader
            Dim reader As IDataReader = Nothing
            Try
                cmd.CommandText = commandtext
                reader = Me.ExecuteReader()
            Catch ex As Exception
                If (handleErrors) Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return reader
        End Function

        Public Function GetDataTableWithParams(ByVal procName As String, ByVal params() As SqlParameter) As DataTable
            Dim dt As New DataTable()
            Dim cnn As New SqlConnection()
            Try
                cnn.ConnectionString = sCon
                Using cmd As New SqlCommand(procName, cnn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 60
                    
                    If params IsNot Nothing Then
                        cmd.Parameters.AddRange(params)
                    End If
                    
                    cnn.Open()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw New Exception("Error executing stored procedure with parameters: " & ex.Message, ex)
                End If
            End Try
            Return dt
        End Function

        Public Function ExecuteScalar() As Object
            Dim obj As Object = Nothing
            Try
                Me.Open()
                obj = cmd.ExecuteScalar()
                Me.Close()
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return obj
        End Function

        Public Function ExecuteScalar(ByVal commandtext As String) As Object
            Dim obj As Object = Nothing
            Try
                cmd.CommandText = commandtext
                obj = Me.ExecuteScalar()
            Catch ex As Exception
                If (handleErrors) Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return obj
        End Function

        Public Function ExecuteScalarWithTransaction(ByVal commandtext As String) As Object
            Dim obj As Object = Nothing
            Try
                cmd.CommandType = CommandType.Text
                cmd.CommandText = commandtext
                obj = cmd.ExecuteScalar()
            Catch ex As Exception
                If (handleErrors) Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return obj
        End Function

        Public Function ExecuteNonQuery() As Integer
            Dim i As Integer = -1
            Try
                Me.Open()
                i = cmd.ExecuteNonQuery()
                Me.Close()
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return i
        End Function

        Public Function ExecuteNonQuery(ByVal commandtext As String) As Integer
            Dim i As Integer = -1
            Try
                cmd.CommandText = commandtext
                i = Me.ExecuteNonQuery()
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return i
        End Function

        Public Function ExecuteDataTable() As DataTable
            Dim da As SqlDataAdapter = Nothing
            Dim dt As DataTable = Nothing
            Try
                da = New SqlDataAdapter()
                da.SelectCommand = CType(cmd, SqlCommand)
                dt = New DataTable()
                da.Fill(dt)
            Catch ex As Exception
                If (handleErrors) Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return dt
        End Function

        Public Function ExecuteDataTable(ByVal commandtext As String) As DataTable
            Dim dt As DataTable = Nothing
            Try
                cmd.CommandText = commandtext
                dt = Me.ExecuteDataTable()
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return dt
        End Function

        Public Function GetDataTable(ByVal SQL As String) As DataTable
            Dim da As SqlDataAdapter = Nothing
            Dim dt As DataTable = Nothing
            Dim cnn As New SqlConnection()
            Try
                cnn.ConnectionString = sCon
                Dim cmd1 As New SqlClient.SqlCommand(SQL, cnn)
                da = New SqlDataAdapter()
                cmd1.CommandText = SQL
                da.SelectCommand = cmd1
                dt = New DataTable()
                da.Fill(dt)
            Catch ex As Exception
                If (handleErrors) Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return dt
        End Function

        Public Function ExecuteSQL(ByVal sSQL As String) As Integer
            ErrorInSO = ""
            Try
                Dim conn As New SqlClient.SqlConnection
                conn.ConnectionString = sCon
                conn.Open()
                Dim cmd As New SqlClient.SqlCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sSQL
                cmd.Connection = conn
                ExecuteSQL = cmd.ExecuteNonQuery()
                conn.Close()
                ExecuteSQL = 1
            Catch ex As Exception
                ExecuteSQL = 0
                ErrorInSO = ex.Message
            End Try
        End Function

        Public Function ExecuteSQLWithTransaction(ByVal sSQL As String) As Integer
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sSQL
            ExecuteSQLWithTransaction = cmd.ExecuteNonQuery()
        End Function

        Public Property CommandText() As String
            Get
                Return cmd.CommandText
            End Get
            Set(ByVal value As String)
                cmd.CommandText = value
                cmd.Parameters.Clear()
            End Set
        End Property

        Public ReadOnly Property Parameters() As IDataParameterCollection
            Get
                Return cmd.Parameters
            End Get
        End Property

        Public Sub AddParameter(ByVal paramname As String, ByVal paramvalue As Object)
            Dim param As SqlParameter = New SqlParameter(paramname, paramvalue)
            cmd.Parameters.Add(param)
        End Sub

        Public Sub AddParameter(ByVal param As IDataParameter)
            cmd.Parameters.Add(param)
        End Sub

        Public Property ConnectionString() As String
            Get
                Return sCon
            End Get
            Set(ByVal value As String)
                sCon = value
            End Set
        End Property

        Private Sub Open()
            cmd.Connection.Open()
        End Sub

        Private Sub Close()
            cmd.Connection.Close()
        End Sub

        Public Property HandleExceptions() As Boolean
            Get
                Return handleErrors
            End Get
            Set(ByVal value As Boolean)
                handleErrors = value
            End Set
        End Property

        Public ReadOnly Property LastError() As String
            Get
                Return strLastError
            End Get
        End Property

        Public Sub Dispose()
            cmd.Dispose()
        End Sub

        Public Function FilteredStringProductMaster(ByVal SQL As String) As String
            Dim sFilteredSql As String = "", i As Integer, sChar As String
            For i = 1 To SQL.Length
                sChar = Mid(SQL, i, 1)
                Select Case LCase(sChar)
                    Case " ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "@", ".", "-", "_", "+", "/", ",", ":", "#", "(", ")", "[", "]", "{", "}", "α", "β", "γ"
                        sFilteredSql += sChar
                    Case Else
                End Select
            Next
            Return sFilteredSql
        End Function

        Public Function FilteredString(ByVal SQL As String) As String
            Dim sFilteredSql As String = "", i As Integer, sChar As String
            For i = 1 To SQL.Length
                sChar = Mid(SQL, i, 1)
                Select Case LCase(sChar)
                    Case " ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "@", ".", "-", "_", "+", "/", ",", ":", "#", ">", "<", """,", "[", "]", "{", "}", "*", "$", "α", "β", "γ"
                        sFilteredSql += sChar
                    Case Else
                End Select
            Next
            Return sFilteredSql
        End Function

        Public Sub GetConnectionDtls(ByVal ConStrFood As String)
            Dim i As Integer
            Dim sStr() As String = Split(ConStrFood, ";")
            For i = 0 To UBound(sStr)
                Dim sStr1() As String = Split(sStr(i), "=")
                Select Case LCase(sStr1(0))
                    Case "data source"
                        newServerName = sStr1(1)
                    Case "initial catalog"
                        newDatabaseName = sStr1(1)
                    Case " user id"
                        userID = sStr1(1)
                    Case " password"
                        password = sStr1(1)
                    Case "integrated security"
                        sIntegratedSecurity = sStr1(1)
                End Select
            Next
        End Sub

        Public Function GetServerDate() As Date
            Dim dt As DataTable
            dt = GetDataTable("Select Getdate()")
            Return dt.Rows(0)(0)
        End Function

        Public Sub TransactionBegin()
            cmd.Connection.Open()
            tran = cmd.Connection.BeginTransaction()
            cmd.Transaction = tran
        End Sub

        Public Sub Commit()
            If tran IsNot Nothing Then
                tran.Commit()
            End If
            If cmd.Connection IsNot Nothing And cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Sub

        Public Sub RollBack()
            Try
                If tran IsNot Nothing Then
                    tran.Rollback()
                End If
            Catch ex As Exception

            End Try
            If cmd.Connection IsNot Nothing And cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Sub

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function GetCommand() As SqlCommand
            Return New SqlCommand()
        End Function

        Public Shared Sub Find_company()
            Dim drhead As DataRow
            Dim sSQL As String, dt1 As DataTable, objDas As New DBAccess
            sSQL = "SELECT ccode,CNAME,finstart,finend From Company"
            dt1 = objDas.GetDataTable(sSQL)
            drhead = dt1.Rows(0)
            CmpCode = drhead("ccode")
            CmpName = drhead("cname")
            FinStart = drhead("finstart")
            FinEnd = drhead("finend")
        End Sub

        Public Shared Function CompanyCode() As String
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim res As Object

            con = GetConnection()
            com = GetCommand()

            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "select ccode from Company"
            CompanyCode = ""
            Try
                con.Open()
                res = com.ExecuteScalar()
                If res IsNot Nothing Then
                    CompanyCode = res.ToString.Trim
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
                Throw ex
            Finally
                con.Close()
                con = Nothing
            End Try
        End Function

        Public Function Find_UOM(ByVal strcode As String) As String
            Dim s As Object
            Find_UOM = ""
            s = Find_Value("uom", "uomcd", "uomname", Trim(strcode))
            If s IsNot Nothing Then
                Find_UOM = s.ToString
            End If
        End Function

        Public Shared Function Find_Value(ByVal tblname As String, ByVal infld As String, ByVal outfld As String, ByVal value As Object) As Object
            Dim con As New SqlConnection
            Dim com As New SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "findrecord_sp"
            com.Parameters.AddWithValue("@tab", Trim(tblname))
            com.Parameters.AddWithValue("@code", Trim(infld))
            com.Parameters.AddWithValue("@desc", Trim(outfld))
            com.Parameters.AddWithValue("@para", Trim(value))
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

        'Public Shared Function Find_Value(ByVal Table As String, ByVal Code As String, ByVal Name As String, ByVal value As Object) As Object
        '    Dim con As New SqlConnection
        '    Dim com As New SqlCommand
        '    Dim pr As SqlParameter
        '    Dim obj As Object

        '    con = GetConnection()
        '    com = New SqlCommand
        '    com.Connection = con
        '    com.CommandType = CommandType.StoredProcedure
        '    com.CommandText = "ChkDuplicate_sp"
        '    com.Parameters.AddWithValue("tab", Trim(Table))
        '    com.Parameters.AddWithValue("code", Trim(Code))
        '    com.Parameters.AddWithValue("desc", Trim(Name))
        '    com.Parameters.AddWithValue("para", Trim(value))
        '    pr = com.Parameters.Add("retval", SqlDbType.VarChar, 500)
        '    pr.Direction = ParameterDirection.Output

        '    Try
        '        con.Open()
        '        com.ExecuteNonQuery()
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        con.Close()
        '        con = Nothing
        '        com = Nothing
        '    End Try

        '    obj = pr.Value
        '    If IsDBNull(obj) = True Or IsNothing(obj.ToString) Then
        '        obj = Nothing
        '    End If

        '    Return obj
        'End Function

        '''''''''''''''Report

        Public Sub SetLoginDtls(ByVal report As ReportDocument)
            Dim connection As IConnectionInfo
            Dim conStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConStrFood").ToString
            GetConnectionDtls(conStr)
            ' Change the server name and database in main reports
            For Each connection In report.DataSourceConnections
                '    'If (String.Compare(LCase(connection.ServerName), LCase(newServerName), True) = -1 And String.Compare(LCase(connection.DatabaseName), LCase(newDatabaseName), True) = 0) Then
                '    ' SetConnection can also be used to set new logon and new database table
                'report.DataSourceConnections(connection.ServerName, connection.DatabaseName).SetConnection(newServerName, newDatabaseName, True)
                report.DataSourceConnections(connection.ServerName, connection.DatabaseName).SetConnection(newServerName, newDatabaseName, userID, password)
                '    'End If
            Next
        End Sub

        Public Structure Accessbuttons
            Public allow_add As Boolean
            Public allow_mod As Boolean
            Public allow_del As Boolean
            Public allow_save As Boolean
            Public allow_view As Boolean
            Public allow_print As Boolean
            Public allow_san As Boolean
            Public allow_prev As Boolean
            Public allow_refs As Boolean
        End Structure

        Public Shared Function Accessright(ByVal struserid As String, ByVal strmodulecd As String) As Accessbuttons
            Dim con As SqlConnection
            Dim com As SqlCommand
            'Dim pr As SqlParameter
            Dim da As SqlDataAdapter
            Dim ds As DataSet
            Dim ab As New Accessbuttons
            Dim dr As DataRow

            con = GetConnection()
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "accessright_sp"
            com.Parameters.AddWithValue("u_id", Trim(struserid))
            com.Parameters.AddWithValue("modcd", Trim(strmodulecd))
            ' pr = com.Parameters.Add("out_cur", SqlDbType.Char, 100)
            ' pr.Direction = ParameterDirection.Output
            da = New SqlDataAdapter
            da.SelectCommand = com
            ds = New DataSet
            Try
                da.Fill(ds)

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                da = Nothing
                com = Nothing
                con = Nothing
            End Try

            If ds.Tables(0).Rows.Count > 0 Then
                dr = ds.Tables(0).Rows(0)
                If dr("allow_add") = 1 Then
                    ab.allow_add = True
                Else
                    ab.allow_add = False
                End If

                If dr("allow_mod") = 1 Then
                    ab.allow_mod = True
                Else
                    ab.allow_mod = False
                End If

                If dr("allow_del") = 1 Then
                    ab.allow_del = True
                Else
                    ab.allow_del = False
                End If
                If dr("allow_mod") <> 1 And dr("allow_add") <> 1 Then
                    ab.allow_save = False
                Else
                    ab.allow_save = True
                End If

                If dr("allow_view") = 1 Then
                    ab.allow_view = True
                Else
                    ab.allow_view = False
                End If

                If dr("allow_san") = 1 Then
                    ab.allow_san = True
                Else
                    ab.allow_san = False
                End If

                If dr("allow_refs") = 1 Then
                    ab.allow_refs = True
                Else
                    ab.allow_refs = False
                End If

                If dr("allow_print") = 1 Then
                    ab.allow_print = True
                Else
                    ab.allow_print = False
                End If

                If dr("allow_prev") = 1 Then
                    ab.allow_prev = True
                Else
                    ab.allow_prev = False
                End If
            Else
                ab.allow_add = True
                ab.allow_mod = True
                ab.allow_del = True
                ab.allow_save = True
                ab.allow_view = True
                ab.allow_san = True
                ab.allow_refs = True
                ab.allow_print = True
                ab.allow_prev = True
            End If

            Return ab

        End Function
        Public Shared Function DateFreeze(ByVal infld1 As String) As Boolean
            Dim con As New SqlConnection()
            Dim com As New SqlCommand
            Dim pr As SqlParameter
            Dim obj As Object
            con.ConnectionString = DBAccess.sCon
            com = New SqlCommand
            com.Connection = con
            com.CommandType = CommandType.StoredProcedure
            com.CommandText = "Check_FreezeDt_Sp"
            com.Parameters.AddWithValue("@vchdt", Trim(infld1))
            pr = com.Parameters.Add("@flag", SqlDbType.Bit, 1)
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
                DateFreeze = False
            Else
                If obj = True Then
                    DateFreeze = True
                Else
                    DateFreeze = False
                End If
            End If

        End Function

        'Public Shared Function Check_duplicate_opening(ByVal infld As String, ByVal outfld As String) As String
        '    Dim con As New SqlConnection
        '    Dim com As New SqlCommand
        '    Dim pr As SqlParameter
        '    Dim obj As Object

        '    con = GetConnection()
        '    com = New SqlCommand
        '    com.Connection = con
        '    com.CommandType = CommandType.StoredProcedure
        '    com.CommandText = "CHECKDUPLICATEOPENING_SP"
        '    com.Parameters.AddWithValue("@productcd", Trim(infld))
        '    com.Parameters.AddWithValue("@lotno", Trim(outfld))
        '    pr = com.Parameters.Add("@retval", SqlDbType.VarChar, 255)
        '    pr.Direction = ParameterDirection.Output
        '    Try
        '        con.Open()
        '        com.ExecuteNonQuery()
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        con.Close()
        '        con = Nothing
        '        com = Nothing
        '    End Try
        '    obj = pr.Value
        '    If IsDBNull(obj) = True Or IsNothing(obj.ToString) Then
        '        obj = Nothing
        '    End If
        '    Return obj
        'End Function

    End Class
End Namespace
