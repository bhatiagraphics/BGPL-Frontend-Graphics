Imports System
Imports System.Collections
Imports System.Linq
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Linq
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

' (c) Copyright Microsoft Corporation.
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
'*-------------------------------*
'*                               *
'*      Mahsa Hassankashi        *
'*     info@mahsakashi.com       *
'*   http://www.mahsakashi.com   * 
'*     kashi_mahsa@yahoo.com     * 
'*                               *
'*                               *
'*-------------------------------*

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
Public Class AutoComplete
    Inherits System.Web.Services.WebService
    Dim cn As New SqlClient.SqlConnection()

    <WebMethod()> _
    Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        ' '' Get Data with Hardcoded Values (Remove (, ByVal contextKey As String) from Public Function
        'cmd.CommandText = "Select LTrim(RTrim(indno)) as indno from indenthead Where indno like @myParameter"
        'cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")


        ' '' Get Data with Passing Table Name and Field Name From Textbox (Add (, ByVal contextKey As String) in Public Funtion)
        'Dim query As String = ("Select " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (" From " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Where " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + " like @myParameter"))))))

        Dim query As String = ("Select Ltrim(Rtrim(" _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (")) As " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (" From " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Where " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + " like @myParameter"))))))))

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        'Then return List of string(txtItems) as result
        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            ''String From DataBase(dbValues)
            dbValues = row((contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1)).ToString)
            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()

    End Function

    <WebMethod()> _
    Public Function GetCompletionListFOrAlternateItem(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        ' '' Get Data with Hardcoded Values (Remove (, ByVal contextKey As String) from Public Function
        'cmd.CommandText = "Select LTrim(RTrim(indno)) as indno from indenthead Where indno like @myParameter"
        'cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")


        ' '' Get Data with Passing Table Name and Field Name From Textbox (Add (, ByVal contextKey As String) in Public Funtion)
        'Dim query As String = ("Select " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (" From " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Where " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + " like @myParameter"))))))

        Dim query As String = ("Select Ltrim(Rtrim(" _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (")) As " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (" From " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Where MasterCategory='Item' And " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + " like @myParameter"))))))))

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        'Then return List of string(txtItems) as result
        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            ''String From DataBase(dbValues)
            dbValues = row((contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1)).ToString)
            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()

    End Function

    <WebMethod()> _
    Public Function GetCompletionListofProduct(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        ' '' Get Data with Hardcoded Values (Remove (, ByVal contextKey As String) from Public Function
        'cmd.CommandText = "Select LTrim(RTrim(indno)) as indno from indenthead Where indno like @myParameter"
        'cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")


        ' '' Get Data with Passing Table Name and Field Name From Textbox (Add (, ByVal contextKey As String) in Public Funtion)
        'Dim query As String = ("Select " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (" From " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Where " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + " like @myParameter"))))))

        Dim query As String = ("Select Ltrim(Rtrim(" _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (")) As " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (" From " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Where MasterCategory='Product' And " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + " like @myParameter"))))))))

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        'Then return List of string(txtItems) as result
        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            ''String From DataBase(dbValues)
            dbValues = row((contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1)).ToString)
            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()

    End Function

    <WebMethod()> _
    Public Function GetCompItemwithFilter(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = Trim(contextKey) + " like '" & Trim(prefixText) & "%'"
        cmd.CommandText = query
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("", "No match found.")
        End If

        'Then return List of string(txtItems) as result
        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            dbValues = row("productname").ToString
            dbValues = dbValues
            txtItems.Add(dbValues)
        Next
        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompProductList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("productname").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("productname"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompChalNoList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("chlno").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("chlno"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompInvNoList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("invoiceno").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("invoiceno"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompletionListofCr(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = ("Select Ltrim(Rtrim(" _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (")) As " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (" From " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Where grpcode = (Select CrGroup From Fasetup) And " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + " like @myParameter"))))))))

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception
            Exit Function
        Finally
            conn.Close()
        End Try
        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        'Then return List of string(txtItems) as result
        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            ''String From DataBase(dbValues)
            dbValues = row((contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1)).ToString)
            dbValues = dbValues
            txtItems.Add(dbValues)
        Next
        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompSupplierList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("accname").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("accname"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompCustomerForDist(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("cusname").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("cusname"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompDistCust(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
        End If

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("cusname").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("cusname"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompListOfPurEnqNo(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("PEnqNo").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("PEnqNo"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompListOfSalOrdNo(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("SalordNo").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("SalordNo"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompListOfProcuctNo(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("ProductName").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("ProductName"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompPackingList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + " like @myParameter ")

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
        End If

        'If Input don't match then show "No match found."

        Dim txtItems As New List(Of String)
        Dim dbValues As String

        If (dt.Rows.Count = 0) Then
            dbValues = "No match found."
            txtItems.Add(dbValues)
        End If

        For Each row As DataRow In dt.Rows
            If IsDBNull(row(("plno").ToString)) Then
                dbValues = "No match found."
            Else
                dbValues = row(("plno"))
            End If

            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompListofCustAndSupp(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Dim query As String = ("Select * From (Select Ltrim(Rtrim(" _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (")) As " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(4) + (" From " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Union Select Ltrim(Rtrim(" _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(3) + (")) As " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(4) + (" From " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(2) + (") CusSupp Where CusSuppName like @myParameter")))))))))))))

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        'Then return List of string(txtItems) as result
        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            ''String From DataBase(dbValues)
            dbValues = row((contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(4)).ToString)
            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()

    End Function


    <WebMethod()> _
    Public Function GetMouldMoveCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        ' '' Get Data with Hardcoded Values (Remove (, ByVal contextKey As String) from Public Function
        'cmd.CommandText = "Select LTrim(RTrim(indno)) as indno from indenthead Where indno like @myParameter"
        'cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")


        ' '' Get Data with Passing Table Name and Field Name From Textbox (Add (, ByVal contextKey As String) in Public Funtion)
        'Dim query As String = ("Select " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (" From " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Where " _
        '    + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + " like @myParameter"))))))

        Dim query As String = ("Select Ltrim(Rtrim(" _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (")) As " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + (" From " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(0) + (" Where iotype='" + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(2) + "' and " _
           + (contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1) + " like @myParameter")))))))))

        cmd.CommandText = query
        cmd.Parameters.AddWithValue("@myParameter", "%" + prefixText + "%")
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        dt = ds.Tables(0)

        'If Input don't match then show "No match found."
        If (dt.Rows.Count = 0) Then
            dt.Rows.Add("No match found.")
        End If

        'Then return List of string(txtItems) as result
        Dim txtItems As New List(Of String)
        Dim dbValues As String

        For Each row As DataRow In dt.Rows
            ''String From DataBase(dbValues)
            dbValues = row((contextKey.Split(Microsoft.VisualBasic.ChrW(35)).ElementAt(1)).ToString)
            dbValues = dbValues
            txtItems.Add(dbValues)
        Next

        Return txtItems.ToArray()

    End Function

End Class
