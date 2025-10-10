Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Drawing

Partial Class ReportDashBoardStores
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                HyperLink1.NavigateUrl = String.Format("~/Stores/Reports/PR_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink2.NavigateUrl = String.Format("~/Stores/Reports/SR_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink7.NavigateUrl = String.Format("~/Stores/Reports/Pending_PR_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink8.NavigateUrl = String.Format("~/Stores/Reports/Pending_PO_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink9.NavigateUrl = String.Format("~/Stores/Reports/Pending_SR_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink13.NavigateUrl = String.Format("~/Stores/Reports/SupplierList.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink18.NavigateUrl = String.Format("~/Stores/Reports/PO_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

                HyperLink23.NavigateUrl = String.Format("~/Stores/Reports/PRStatusReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink24.NavigateUrl = String.Format("~/Stores/Reports/CustomerwiseBoxwiseInventory.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink25.NavigateUrl = String.Format("~/Stores/Reports/ImportShipmentStatusReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink26.NavigateUrl = String.Format("~/Stores/Reports/QuotationComparison.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

                HyperLink27.NavigateUrl = String.Format("~/Stores/Reports/SO_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink28.NavigateUrl = String.Format("~/Stores/Reports/Pending_SO_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink29.NavigateUrl = String.Format("~/Stores/Reports/SRStatusReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
