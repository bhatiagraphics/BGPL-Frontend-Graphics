Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports System.IO
Imports System.Data.OleDb
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports AGPLCRM.Class
Imports FOODERPWEB.Class

Partial Class UpdateBalanceExisting
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As DataTable, objDas As New DBAccess, sSQL As String

        'sSQL = "exec sp_update_existingbal"
        ''sSQL = "Select u_id, u_name, pass, ISNULL(dist_id,'') as dist_id From Users Where u_name = '" & objDas.FilteredString(txtUserName.Text) & "'"
        'objDas.GetDataTable(sSQL)

        'sSQL = "SELECT us.u_id, us.u_name, us.pass, ISNULL(us.dist_id,'') as dist_id, us.unitcode, ut.unitname FROM users us, unit ut WHERE us.unitcode=ut.unitcode And u_name = '" & objDas.FilteredString(txtUserName.Text) & "'"
        sSQL = "select * from updatevchaccounts where isupdate='0'"
        'sSQL = "Select u_id, u_name, pass, ISNULL(dist_id,'') as dist_id From Users Where u_name = '" & objDas.FilteredString(txtUserName.Text) & "'"
        dt = objDas.GetDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            For Each gvRow As DataRow In dt.Rows
                ClsAdjustmentImportExport.Update_balance(gvRow("CrRefNo").ToString.Trim, Trim(gvRow("AccCode").ToString), "Dr", Trim(gvRow("CrSrNo").ToString))
                ClsAdjustmentImportExport.Update_balance(gvRow("CrRefNo").ToString.Trim, Trim(gvRow("AccCode").ToString), "Cr", Trim(gvRow("CrSrNo").ToString))

                ClsAdjustmentImportExport.Update_balance(gvRow("DrRefNo").ToString.Trim, Trim(gvRow("AccCode").ToString), "Dr", Trim(gvRow("DrSrNo").ToString))
                ClsAdjustmentImportExport.Update_balance(gvRow("DrRefNo").ToString.Trim, Trim(gvRow("AccCode").ToString), "Cr", Trim(gvRow("DrSrNo").ToString))

                sSQL = "update updatevchaccounts set isupdate='1'  where srno=" & Trim(gvRow("srno").ToString)
                dt = objDas.GetDataTable(sSQL)

            Next


        End If
    End Sub
End Class
