Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports Newtonsoft.Json
Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services

Partial Class Dashboard_chart_Month
    Inherits System.Web.UI.Page

    Public Shared uid, did As String
    Public Shared finstart, finend As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Session("UserName") Is Nothing) Then
                Response.Redirect("~/SessionExpired.aspx")
            End If

            DBAccess.Find_company()
            uid = Trim(Session.Item("UserID"))
            did = Trim(Session.Item("DistID"))

            finstart = Trim(DBAccess.FinStart)
            finend = Trim(DBAccess.FinEnd)


        Catch ex As Exception

        End Try
    End Sub

    <WebMethod()>
    Public Shared Function GetChartData() As List(Of CLSTestingGraph4)
        Dim dt As New DataTable()
        Dim objDas As New DBAccess
        dt = objDas.GetDataTable("MonthlySales_graph_sp '" & Trim(finstart) & "','" & Trim(finend) & "' ")
        'dt = objDas.GetDataTable("SP_GetOrderDataForPieChart 'user1','C1' ")
        Dim dataList As New List(Of CLSTestingGraph4)()
        For Each dtrow As DataRow In dt.Rows
            Dim details As New CLSTestingGraph4()
            details.name = Trim(dtrow(0).ToString())
            details.amt = Trim(dtrow(1))
            dataList.Add(details)
        Next
        Return dataList
    End Function
End Class

Public Class CLSTestingGraph4
    Private m_name As String
    Private m_amt As Integer

    Public Property name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property
    Public Property amt() As Integer
        Get
            Return m_amt
        End Get
        Set(value As Integer)
            m_amt = value
        End Set
    End Property
End Class
