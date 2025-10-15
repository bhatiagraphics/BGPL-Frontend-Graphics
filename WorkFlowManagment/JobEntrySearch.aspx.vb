Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class WorkFlowManagement_JobEntrySearch
    Inherits System.Web.UI.Page

    Private Const PAGE_SIZE As Integer = 50
    Private ReadOnly Property ConStr As String
        Get
            Return ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGrid(1)
        End If
    End Sub

    ' Search button
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
        gvJobs.PageIndex = 0
        BindGrid(1)
    End Sub

    ' Grid paging (custom paging)
    Protected Sub gvJobs_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        ' GridView is 0-based, our proc expects 1-based
        Dim pageIndex As Integer = e.NewPageIndex + 1
        BindGrid(pageIndex)
    End Sub

    Private Sub BindGrid(ByVal pageIndex As Integer)
        lblError.Visible = False

        Try
            Using con As New SqlConnection(ConStr)
                Using cmd As New SqlCommand("dbo.usp_GetJobEntriesPaged", con)
                    cmd.CommandType = CommandType.StoredProcedure

                    ' --- Required proc parameters
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex)
                    cmd.Parameters.AddWithValue("@PageSize", PAGE_SIZE)

                    Dim pTotal As New SqlParameter("@TotalRows", SqlDbType.Int)
                    pTotal.Direction = ParameterDirection.Output
                    cmd.Parameters.Add(pTotal)

                    ' NOTE:
                    ' If your procedure supports optional filters (JobIdPart, JobNamePart, INTCodePart, etc.)
                    ' you can add them here, else leave them out. The UI calls the proc exactly as-is.

                    Dim dt As New DataTable()
                    Using da As New SqlDataAdapter(cmd)
                        con.Open()
                        da.Fill(dt)
                    End Using

                    ' Bind page's rows
                    gvJobs.DataSource = dt
                    gvJobs.DataBind()

                    ' Total rows for pager (custom paging)
                    Dim total As Integer = 0
                    If pTotal.Value IsNot Nothing AndAlso pTotal.Value IsNot DBNull.Value Then
                        total = Convert.ToInt32(pTotal.Value)
                    End If
                    gvJobs.VirtualItemCount = total
                    gvJobs.PageIndex = pageIndex - 1

                    ' Show count
                    lblTotal.Text = String.Format("Total rows: {0:N0}", total)
                End Using
            End Using

        Catch ex As Exception
            lblError.Text = "Unable to load jobs. " & ex.Message
            lblError.Visible = True
            gvJobs.DataSource = Nothing
            gvJobs.DataBind()
            gvJobs.VirtualItemCount = 0
            lblTotal.Text = ""
        End Try
    End Sub

End Class
