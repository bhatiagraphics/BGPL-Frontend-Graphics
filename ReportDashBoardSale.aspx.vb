Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Drawing

Partial Class ReportDashBoardSale
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try

            HyperLink1.NavigateUrl = String.Format("~/Marketing/Reports/SalesOrderRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink2.NavigateUrl = String.Format("~/Marketing/Reports/SalesRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink3.NavigateUrl = String.Format("~/Marketing/Reports/SalesDetails.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink4.NavigateUrl = String.Format("~/Marketing/Reports/SalesReturnRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink5.NavigateUrl = String.Format("~/Marketing/Reports/ProductGroupwiseMonthlyCrosstab.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink6.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseCustomerwiseMonthlyCrossTab.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink7.NavigateUrl = String.Format("~/Marketing/Reports/PartywiseMonthlyCrosstab.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink8.NavigateUrl = String.Format("~/Marketing/Reports/AreawiseSalesSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink9.NavigateUrl = String.Format("~/Marketing/Reports/MonthlySalesSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink10.NavigateUrl = String.Format("~/Marketing/Reports/DatewiseSalesSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink11.NavigateUrl = String.Format("~/Marketing/Reports/PartywiseSalesSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink12.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseSalesSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink13.NavigateUrl = String.Format("~/Marketing/Reports/PendingSalesOrderRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink18.NavigateUrl = String.Format("~/Marketing/Reports/CustomerList.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink16.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseProductwiseSalesSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink17.NavigateUrl = String.Format("~/Marketing/Reports/ExportPriceListReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink19.NavigateUrl = String.Format("~/Marketing/Reports/PendingSalesOrderExport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink20.NavigateUrl = String.Format("~/Marketing/Reports/PendingSalesOrderDomestic.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))


            HyperLink21.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseSalesOrderSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink22.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseSalesOrderSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink23.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseProductwiseSalesOrderSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink24.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseSalesSummary_Value.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink25.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseSalesSummary_New.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink26.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseProductwiseSalesSummary_New.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink27.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseMonthwiseSalesSummary_Value.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink28.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwiseSalesSummary_Value.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink29.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwiseSalesSummary_Qty.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

            HyperLink30.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseMonthwiseSalesOrderSummary_Value.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink31.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwiseSalesOrderSummary_Value.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink32.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwiseSalesOrderSummary_Qty.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

            HyperLink33.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwisePendingSalesOrderSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink34.NavigateUrl = String.Format("~/Marketing/Reports/ProductwisePendingSalesOrderSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink35.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseProductwisePendingSalesOrderSummary.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink36.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseMonthwisePendingSalesOrderSummary_Value.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink37.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwisePendingSalesOrderSummary_Value.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink38.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwisePendingSalesOrderSummary_Qty.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))


            HyperLink39.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwisePendingSalesOrderSummary_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink40.NavigateUrl = String.Format("~/Marketing/Reports/ProductwisePendingSalesOrderSummary_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink41.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseProductwisePendingSalesOrderSummary_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink42.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseMonthwisePendingSalesOrderSummary_Value_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink43.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwisePendingSalesOrderSummary_Value_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink44.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwisePendingSalesOrderSummary_Qty_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

            HyperLink45.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseSalesOrderSummary_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink46.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseSalesOrderSummary_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink47.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseProductwiseSalesOrderSummary_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink48.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseMonthwiseSalesOrderSummary_Value_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink49.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwiseSalesOrderSummary_Value_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink50.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwiseSalesOrderSummary_Qty_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))


            HyperLink51.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseSalesSummary_Value_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink52.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseSalesSummary_New_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink53.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseProductwiseSalesSummary_New_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink54.NavigateUrl = String.Format("~/Marketing/Reports/CustomerwiseMonthwiseSalesSummary_Value_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink55.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwiseSalesSummary_Value_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink56.NavigateUrl = String.Format("~/Marketing/Reports/ProductwiseMonthwiseSalesSummary_Qty_EXPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

        Catch ex As Exception
        End Try
    End Sub
End Class
