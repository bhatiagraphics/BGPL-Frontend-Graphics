Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.VisualBasic

Public Class JobEntrySearchDataSource
    Public Shared thisConnectionString As String = ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString

    Public Shared Function GetJobData(maximumRows As Integer, startRowIndex As Integer, jobid As String, jobname As String, intcode As String, prioirty As String, assignedto As String, cuscode As String, jobcreatedt As String, ticketno As String, empcd As String) As DataTable
        Dim pageSize As Integer = maximumRows
        Dim pageNumber As Integer = 1
        If pageSize > 0 Then
            pageNumber = (startRowIndex / pageSize) + 1
        End If
        Dim totalRecords As Integer = 0
        Return FetchJobData(pageNumber, pageSize, totalRecords, jobid, jobname, intcode, prioirty, assignedto, cuscode, jobcreatedt, ticketno, empcd)
    End Function

    Public Shared Function GetJobDataCount(jobid As String, jobname As String, intcode As String, prioirty As String, assignedto As String, cuscode As String, jobcreatedt As String, ticketno As String, empcd As String) As Integer
        Dim totalRecords As Integer = 0
        FetchJobData(1, 0, totalRecords, jobid, jobname, intcode, prioirty, assignedto, cuscode, jobcreatedt, ticketno, empcd)
        Return totalRecords
    End Function

    Private Shared Function FetchJobData(ByVal pageNumber As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer, ByVal jobid As String, ByVal jobname As String, ByVal intcode As String, ByVal prioirty As String, ByVal assignedto As String, ByVal cuscode As String, ByVal jobcreatedt As String, ByVal ticketno As String, ByVal empcd As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(thisConnectionString)
            Using com As New SqlCommand("Sp_jobentry_GetData", con)
                com.CommandType = CommandType.StoredProcedure
                com.Parameters.AddWithValue("@jobid", If(String.IsNullOrEmpty(jobid), DBNull.Value, jobid))
                com.Parameters.AddWithValue("@jobname", If(String.IsNullOrEmpty(jobname), DBNull.Value, jobname))
                com.Parameters.AddWithValue("@intcode", If(String.IsNullOrEmpty(intcode), DBNull.Value, intcode))
                com.Parameters.AddWithValue("@prioirty", If(String.IsNullOrEmpty(prioirty), DBNull.Value, prioirty))
                com.Parameters.AddWithValue("@assignedto", If(String.IsNullOrEmpty(assignedto), DBNull.Value, assignedto))
                com.Parameters.AddWithValue("@cuscode", If(String.IsNullOrEmpty(cuscode), DBNull.Value, cuscode))
                com.Parameters.AddWithValue("@jobcreatedt", If(String.IsNullOrEmpty(jobcreatedt), DBNull.Value, jobcreatedt))
                com.Parameters.AddWithValue("@ticketno", If(String.IsNullOrEmpty(ticketno), DBNull.Value, ticketno))
                com.Parameters.AddWithValue("@Flag", "A")
                com.Parameters.AddWithValue("@empcd", If(String.IsNullOrEmpty(empcd), DBNull.Value, empcd))
                com.Parameters.AddWithValue("@status", DBNull.Value)
                com.Parameters.AddWithValue("@PageNumber", pageNumber)
                com.Parameters.AddWithValue("@PageSize", pageSize)

                Dim totalRecordsParam As New SqlParameter("@TotalRecords", SqlDbType.Int)
                totalRecordsParam.Direction = ParameterDirection.Output
                com.Parameters.Add(totalRecordsParam)

                con.Open()
                Using reader As SqlDataReader = com.ExecuteReader()
                    dt.Load(reader)
                End Using

                If totalRecordsParam.Value IsNot DBNull.Value Then
                    totalRecords = Convert.ToInt32(totalRecordsParam.Value)
                End If
            End Using
        End Using
        Return dt
    End Function
End Class