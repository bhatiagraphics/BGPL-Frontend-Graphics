Imports System.Data
Imports FOODERPWEB.DAL
Imports System.Text

Partial Class DiagnosticTreeviewRights
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            DiagnoseTreeviewRights()
        End If
    End Sub

    Private Sub DiagnoseTreeviewRights()
        Dim objDas As New DBAccess
        Dim sb As New StringBuilder()
        
        Try
            Dim sSQL As String = "SELECT COUNT(*) as total FROM TreeviewRights"
            Dim dt As DataTable = objDas.GetDataTable(sSQL)
            Dim totalRows As Integer = Convert.ToInt32(dt.Rows(0)("total"))
            
            sb.Append("<div class='info'>")
            sb.Append("<h3>Table Status</h3>")
            sb.Append("<p><strong>Total rows in TreeviewRights:</strong> " & totalRows.ToString() & "</p>")
            sb.Append("</div>")
            
            If totalRows = 0 Then
                sb.Append("<div class='error'>")
                sb.Append("<h3>⚠️ ISSUE FOUND: Table is Empty</h3>")
                sb.Append("<p>The TreeviewRights table has no data. This is why menu items don't load.</p>")
                sb.Append("<p><strong>Fix:</strong> Need to populate TreeviewRights with menu entries.</p>")
                sb.Append("</div>")
            Else
                sSQL = "SELECT DISTINCT u_id, COUNT(*) as menu_count FROM TreeviewRights GROUP BY u_id ORDER BY u_id"
                dt = objDas.GetDataTable(sSQL)
                
                sb.Append("<div class='info'>")
                sb.Append("<h3>Users with Menu Entries</h3>")
                sb.Append("<table>")
                sb.Append("<tr><th>User ID (u_id)</th><th>Menu Item Count</th></tr>")
                
                For i As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td>" & dt.Rows(i)("u_id").ToString() & "</td>")
                    sb.Append("<td>" & dt.Rows(i)("menu_count").ToString() & "</td>")
                    sb.Append("</tr>")
                Next
                
                sb.Append("</table>")
                sb.Append("</div>")
                
                sSQL = "SELECT TOP 30 module_id, module_name, ISNULL(NavigateUrl,'[EMPTY]') as NavigateUrl, u_id, ISNULL(Allow,'0') as Allow, parent_module, ISNULL(ssrno,0) as ssrno FROM TreeviewRights ORDER BY u_id, parent_module, ssrno"
                dt = objDas.GetDataTable(sSQL)
                
                sb.Append("<div class='info'>")
                sb.Append("<h3>Sample TreeviewRights Data (First 30 rows)</h3>")
                sb.Append("<table>")
                sb.Append("<tr><th>module_id</th><th>module_name</th><th>NavigateUrl</th><th>u_id</th><th>Allow</th><th>parent_module</th><th>ssrno</th></tr>")
                
                Dim emptyUrlCount As Integer = 0
                Dim allowZeroCount As Integer = 0
                
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim navUrl As String = dt.Rows(i)("NavigateUrl").ToString()
                    Dim allowVal As String = dt.Rows(i)("Allow").ToString()
                    
                    If navUrl = "[EMPTY]" Or navUrl = "" Then
                        emptyUrlCount += 1
                    End If
                    
                    If allowVal = "0" Or allowVal = "" Then
                        allowZeroCount += 1
                    End If
                    
                    sb.Append("<tr>")
                    sb.Append("<td>" & dt.Rows(i)("module_id").ToString() & "</td>")
                    sb.Append("<td>" & dt.Rows(i)("module_name").ToString() & "</td>")
                    sb.Append("<td>" & navUrl & "</td>")
                    sb.Append("<td>" & dt.Rows(i)("u_id").ToString() & "</td>")
                    sb.Append("<td>" & allowVal & "</td>")
                    sb.Append("<td>" & dt.Rows(i)("parent_module").ToString() & "</td>")
                    sb.Append("<td>" & dt.Rows(i)("ssrno").ToString() & "</td>")
                    sb.Append("</tr>")
                Next
                
                sb.Append("</table>")
                sb.Append("</div>")
                
                If emptyUrlCount > 0 Then
                    sb.Append("<div class='warning'>")
                    sb.Append("<h3>⚠️ ISSUE FOUND: Empty NavigateUrl Values</h3>")
                    sb.Append("<p><strong>Count:</strong> " & emptyUrlCount.ToString() & " rows have empty NavigateUrl</p>")
                    sb.Append("<p>Menu items with empty NavigateUrl will have href='#' and won't navigate anywhere.</p>")
                    sb.Append("<p><strong>Fix:</strong> Need to update NavigateUrl column with proper page paths.</p>")
                    sb.Append("</div>")
                End If
                
                If allowZeroCount > 0 Then
                    sb.Append("<div class='warning'>")
                    sb.Append("<h3>⚠️ ISSUE FOUND: Allow = 0 or Empty</h3>")
                    sb.Append("<p><strong>Count:</strong> " & allowZeroCount.ToString() & " rows have Allow=0 or empty</p>")
                    sb.Append("<p>Menu items with Allow=0 won't be displayed in the menu.</p>")
                    sb.Append("<p><strong>Fix:</strong> Need to set Allow='1' for menu items to appear.</p>")
                    sb.Append("</div>")
                End If
                
                sSQL = "SELECT COUNT(*) as cnt FROM TreeviewRights WHERE u_id='admin'"
                dt = objDas.GetDataTable(sSQL)
                Dim adminCount As Integer = Convert.ToInt32(dt.Rows(0)("cnt"))
                
                sSQL = "SELECT COUNT(*) as cnt FROM TreeviewRights WHERE u_id='DEVINTEST'"
                dt = objDas.GetDataTable(sSQL)
                Dim devintestCount As Integer = Convert.ToInt32(dt.Rows(0)("cnt"))
                
                sb.Append("<div class='info'>")
                sb.Append("<h3>Specific User Checks</h3>")
                sb.Append("<p><strong>admin user entries:</strong> " & adminCount.ToString() & "</p>")
                sb.Append("<p><strong>DEVINTEST user entries:</strong> " & devintestCount.ToString() & "</p>")
                sb.Append("</div>")
                
                If emptyUrlCount = 0 And allowZeroCount = 0 And (adminCount > 0 Or devintestCount > 0) Then
                    sb.Append("<div class='success'>")
                    sb.Append("<h3>✅ TreeviewRights appears to be configured correctly</h3>")
                    sb.Append("<p>If modules still don't load, check browser console for JavaScript errors.</p>")
                    sb.Append("</div>")
                End If
            End If
            
        Catch ex As Exception
            sb.Append("<div class='error'>")
            sb.Append("<h3>Error</h3>")
            sb.Append("<p>" & ex.Message & "</p>")
            sb.Append("<p><strong>Stack Trace:</strong><br/>" & ex.StackTrace & "</p>")
            sb.Append("</div>")
        End Try
        
        litResults.Text = sb.ToString()
    End Sub
End Class
