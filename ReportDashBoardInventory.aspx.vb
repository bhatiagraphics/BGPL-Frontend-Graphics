Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Drawing

Partial Class ReportDashBoardInventory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                HyperLink5.NavigateUrl = String.Format("~/Stores/Reports/GRN_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink6.NavigateUrl = String.Format("~/Stores/Reports/PurchaseReturnRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink10.NavigateUrl = String.Format("~/Stores/Reports/Pending_GRN_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink11.NavigateUrl = String.Format("~/Stores/Reports/StockMovement.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink20.NavigateUrl = String.Format("~/Stores/Reports/StockLedger.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink14.NavigateUrl = String.Format("~/Stores/Reports/ProductList.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink19.NavigateUrl = String.Format("~/Stores/Reports/GateEntryRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink12.NavigateUrl = String.Format("~/Stores/Reports/StockReportBatchWise.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink21.NavigateUrl = String.Format("~/Stores/Reports/FGStockReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink22.NavigateUrl = String.Format("~/Stores/Reports/FGStockLedger.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink25.NavigateUrl = String.Format("~/Stores/Reports/MaterialIssueRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink24.NavigateUrl = String.Format("~/Stores/Reports/GatePassRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink26.NavigateUrl = String.Format("~/Stores/Reports/MaterialReturnNote.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink27.NavigateUrl = String.Format("~/Stores/Reports/PendingGateEntryRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink23.NavigateUrl = String.Format("~/Stores/Reports/PRStatusReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink28.NavigateUrl = String.Format("~/Stores/Reports/CustomerwiseBoxwiseInventory.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink32.NavigateUrl = String.Format("~/Stores/Reports/JobInwardRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink33.NavigateUrl = String.Format("~/Stores/Reports/FGAssemblyReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink34.NavigateUrl = String.Format("~/Marketing/Reports/DeliveryChallanRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink31.NavigateUrl = String.Format("~/Stores/Reports/SRN_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink30.NavigateUrl = String.Format("~/Stores/Reports/Pending_SRN_Register.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink35.NavigateUrl = String.Format("~/Stores/Reports/SRStatusReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
                HyperLink1.NavigateUrl = String.Format("~/Stores/Reports/GatePassStatusReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
