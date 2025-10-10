Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic

Namespace FOODERPWEB.Class
    Public Class ClsUserRights
        Private mSsrno As String
        Private mu_id As String
        Private mmodule_id As String
        Private mmodule_name As String
        Private mparent_module As String
        Private mNavigateUrl As String
        Private mAllow As String
        Private mallow_add As String
        Private mallow_mod As String
        Private mallow_del As String
        Private mallow_view As String
        Private mallow_san As String
        Private mallow_refs As String
        Private mallow_print As String
        Private mallow_prev As String
        Private mDepartment As String
        Private mModuleType As String


        Public Property Ssrno() As String
            Get
                Return mSsrno
            End Get
            Set(ByVal value As String)
                mSsrno = value
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

        Public Property module_id() As String
            Get
                Return mmodule_id
            End Get
            Set(ByVal value As String)
                mmodule_id = value
            End Set
        End Property

        Public Property module_name() As String
            Get
                Return mmodule_name
            End Get
            Set(ByVal value As String)
                mmodule_name = value
            End Set
        End Property

        Public Property parent_module() As String
            Get
                Return mparent_module
            End Get
            Set(ByVal value As String)
                mparent_module = value
            End Set
        End Property

        Public Property NavigateUrl() As String
            Get
                Return mNavigateUrl
            End Get
            Set(ByVal value As String)
                mNavigateUrl = value
            End Set
        End Property

        Public Property Allow() As String
            Get
                Return mAllow
            End Get
            Set(ByVal value As String)
                mAllow = value
            End Set
        End Property

        Public Property allow_add() As String
            Get
                Return mallow_add
            End Get
            Set(ByVal value As String)
                mallow_add = value
            End Set
        End Property

        Public Property allow_mod() As String
            Get
                Return mallow_mod
            End Get
            Set(ByVal value As String)
                mallow_mod = value
            End Set
        End Property

        Public Property allow_del() As String
            Get
                Return mallow_del
            End Get
            Set(ByVal value As String)
                mallow_del = value
            End Set
        End Property

        Public Property allow_view() As String
            Get
                Return mallow_view
            End Get
            Set(ByVal value As String)
                mallow_view = value
            End Set
        End Property

        Public Property allow_san() As String
            Get
                Return mallow_san
            End Get
            Set(ByVal value As String)
                mallow_san = value
            End Set
        End Property

        Public Property allow_refs() As String
            Get
                Return mallow_refs
            End Get
            Set(ByVal value As String)
                mallow_refs = value
            End Set
        End Property

        Public Property allow_print() As String
            Get
                Return mallow_print
            End Get
            Set(ByVal value As String)
                mallow_print = value
            End Set
        End Property

        Public Property allow_prev() As String
            Get
                Return mallow_prev
            End Get
            Set(ByVal value As String)
                mallow_prev = value
            End Set
        End Property

        Public Property Department() As String
            Get
                Return mDepartment
            End Get
            Set(ByVal value As String)
                mDepartment = value
            End Set
        End Property

        Public Property ModuleType() As String
            Get
                Return mModuleType
            End Get
            Set(ByVal value As String)
                mModuleType = value
            End Set
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function GetCommand() As SqlCommand
            Return New SqlCommand()
        End Function

        Public Shared Function GetDataForGride(ByVal KeyCode As String) As DataSet
            Dim dadet As New SqlDataAdapter
            Dim con As SqlConnection
            Dim comdet As SqlCommand
            Dim ds As DataSet

            con = GetConnection()
            comdet = GetCommand()
            ds = New DataSet

            comdet.Connection = con
            comdet.CommandType = CommandType.Text
            comdet.CommandText = "select * from TreeviewRights where u_id='" & Trim(KeyCode) & "' order by srno desc"
            dadet.SelectCommand = comdet

            Try
                dadet.Fill(ds, "TreeviewRights")
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con = Nothing
                comdet = Nothing
                dadet = Nothing
            End Try
            Return ds
        End Function

        Public Shared Function Update_Data(ByVal o As ClsUserRights) As Integer
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
            If o.Ssrno = "" Then
                Com1.Parameters.Add(New SqlParameter("@Ssrno", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@Ssrno", o.Ssrno))
            End If
            If o.u_id = "" Then
                Com1.Parameters.Add(New SqlParameter("@u_id", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@u_id", o.u_id))
            End If
            If o.module_id = "" Then
                Com1.Parameters.Add(New SqlParameter("@module_id", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@module_id", o.module_id))
            End If
            If o.module_name = "" Then
                Com1.Parameters.Add(New SqlParameter("@module_name", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@module_name", o.module_name))
            End If
            If o.parent_module = "" Then
                Com1.Parameters.Add(New SqlParameter("@parent_module", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@parent_module", o.parent_module))
            End If
            If o.NavigateUrl = "" Then
                Com1.Parameters.Add(New SqlParameter("@NavigateUrl", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@NavigateUrl", o.NavigateUrl))
            End If
            Com1.Parameters.Add(New SqlParameter("@Allow", o.Allow))
            Com1.Parameters.Add(New SqlParameter("@allow_add", o.allow_add))
            Com1.Parameters.Add(New SqlParameter("@allow_mod", o.allow_mod))
            Com1.Parameters.Add(New SqlParameter("@allow_del", o.allow_del))
            Com1.Parameters.Add(New SqlParameter("@allow_view", o.allow_view))
            Com1.Parameters.Add(New SqlParameter("@allow_san", o.allow_san))
            Com1.Parameters.Add(New SqlParameter("@allow_prev", o.allow_prev))
            If o.Department = "" Then
                Com1.Parameters.Add(New SqlParameter("@Department", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@Department", o.Department))
            End If
            If o.ModuleType = "" Then
                Com1.Parameters.Add(New SqlParameter("@ModuleType", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@ModuleType", o.ModuleType))
            End If

            Ssql1 = "Sp_accessright_AE"
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

        'Public Shared Function Update_Data(ByVal ds As DataSet, ByVal KeyCode As String) As Integer
        '    Dim Con As SqlConnection
        '    Dim Trans As SqlTransaction
        '    Dim dadet As New SqlDataAdapter
        '    Dim comdetold As SqlCommand
        '    Dim comdet As SqlCommand
        '    Dim cbdet As SqlCommandBuilder
        '    Dim Com1 As SqlCommand
        '    Dim Ssql2, Ssql3 As String
        '    Dim i As Integer

        '    Con = GetConnection()
        '    Con.Open()
        '    Trans = Con.BeginTransaction

        '    comdet = New SqlCommand
        '    comdet.Connection = Con
        '    comdet.CommandType = CommandType.Text
        '    Ssql2 = "Select * From TreeviewRights Where u_id='" & Trim(KeyCode) & "'"
        '    comdet.CommandText = Ssql2
        '    comdet.Transaction = Trans

        '    comdetold = New SqlCommand
        '    comdetold.Connection = Con
        '    comdetold.CommandType = CommandType.Text
        '    Ssql3 = "Delete From TreeviewRights Where u_id='" & Trim(KeyCode) & "'"
        '    comdetold.CommandText = Ssql3
        '    comdetold.Transaction = Trans

        '    dadet.SelectCommand = comdet
        '    cbdet = New SqlCommandBuilder(dadet)

        '    Try
        '        comdetold.ExecuteNonQuery()
        '        i = dadet.Update(ds, "TreeviewRights")
        '        Trans.Commit()
        '    Catch ex As Exception
        '        If (Not (Trans) Is Nothing) Then
        '            Trans.Rollback()
        '        End If
        '        Throw ex
        '    Finally
        '        Com1 = Nothing
        '        Con.Close()
        '        Con = Nothing
        '        Trans = Nothing
        '    End Try
        '    Return i
        'End Function

        Public Shared Function Find_Machinecd(ByVal strcode As String) As String
            Dim s As Object
            Find_Machinecd = ""
            s = DBAccess.Find_Value("MachineMaster", "MachineName", "MachineCode", Trim(strcode))
            If s IsNot Nothing Then
                Find_Machinecd = s.ToString
            End If
        End Function

        Public Shared Function Find_MachineName(ByVal strcode As String) As String
            Dim s As Object
            Find_MachineName = ""
            s = DBAccess.Find_Value("MachineMaster", "MachineCode", "MachineName", Trim(strcode))
            If s IsNot Nothing Then
                Find_MachineName = s.ToString
            End If
        End Function

        Public Shared Function Find_Deptcd(ByVal strcode As String) As String
            Dim s As Object
            Find_Deptcd = ""
            s = DBAccess.Find_Value("department", "deptname", "deptcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Deptcd = s.ToString
            End If
        End Function

        Public Shared Function Find_DeptName(ByVal strcode As String) As String
            Dim s As Object
            Find_DeptName = ""
            s = DBAccess.Find_Value("department", "deptcd", "deptname", Trim(strcode))
            If s IsNot Nothing Then
                Find_DeptName = s.ToString
            End If
        End Function

        Public Shared Function Find_DeptShortcd(ByVal strcode As String) As String
            Dim s As Object
            Find_DeptShortcd = ""
            s = DBAccess.Find_Value("department", "deptcd", "shortcode", Trim(strcode))
            If s IsNot Nothing Then
                Find_DeptShortcd = s.ToString
            End If
        End Function

        Public Shared Function Find_Branchcd(ByVal strcode As String) As String
            Dim s As Object
            Find_Branchcd = ""
            s = DBAccess.Find_Value("crmlocation", "locname", "loccd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Branchcd = s.ToString
            End If
        End Function

        Public Shared Function Find_BranchName(ByVal strcode As String) As String
            Dim s As Object
            Find_BranchName = ""
            s = DBAccess.Find_Value("crmlocation", "loccd", "locname", Trim(strcode))
            If s IsNot Nothing Then
                Find_BranchName = s.ToString
            End If
        End Function

        Public Shared Function Find_BranchShortName(ByVal strcode As String) As String
            Dim s As Object
            Find_BranchShortName = ""
            s = DBAccess.Find_Value("crmlocation", "loccd", "Shortname", Trim(strcode))
            If s IsNot Nothing Then
                Find_BranchShortName = s.ToString
            End If
        End Function

        Public Shared Function Find_Suppcd(ByVal strcode As String) As String
            Dim s As Object
            Find_Suppcd = ""
            s = DBAccess.Find_Value("supplier", "suppname", "suppcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_Suppcd = s.ToString
            End If
        End Function

        Public Shared Function Find_SuppName(ByVal strcode As String) As String
            Dim s As Object
            Find_SuppName = ""
            s = DBAccess.Find_Value("supplier", "suppcd", "suppname", Trim(strcode))
            If s IsNot Nothing Then
                Find_SuppName = s.ToString
            End If
        End Function

        Public Shared Function Find_itemcd(ByVal strcode As String) As String
            Dim s As Object
            Find_itemcd = ""
            s = DBAccess.Find_Value("product", "productname", "productcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_itemcd = s.ToString
            End If
        End Function

        Public Shared Function Find_ItemName(ByVal strcode As String) As String
            Dim s As Object
            Find_ItemName = ""
            s = DBAccess.Find_Value("product", "productcd", "productname", Trim(strcode))
            If s IsNot Nothing Then
                Find_ItemName = s.ToString
            End If
        End Function

        Public Shared Function Find_UOM_Code(ByVal strcode As String) As String
            Dim s As Object
            Find_UOM_Code = ""
            s = DBAccess.Find_Value("uom", "uomname", "uomcd", Trim(strcode))
            If s IsNot Nothing Then
                Find_UOM_Code = s.ToString
            End If
        End Function

        Public Shared Function Find_UOMName(ByVal strcode As String) As String
            Dim s As Object
            Find_UOMName = ""
            s = DBAccess.Find_Value("uom", "uomcd", "uomname", Trim(strcode))
            If s IsNot Nothing Then
                Find_UOMName = s.ToString
            End If
        End Function

        Public Shared Function CheckPR(ByVal strcode As String) As String
            Dim s As Object
            CheckPR = ""
            s = DBAccess.Find_Value("POdet", "u_id", "pono", Trim(strcode))
            If s IsNot Nothing Then
                CheckPR = s.ToString
            End If
        End Function
    End Class
End Namespace
