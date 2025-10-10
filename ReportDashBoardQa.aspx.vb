Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Drawing

Partial Class ReportDashBoardQa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HyperLink6124.NavigateUrl = String.Format("~/QC/Reports/DailyQualityComplaintReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink311.NavigateUrl = String.Format("~/QC/Reports/DailySelfCalibrationReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink411.NavigateUrl = String.Format("~/QC/Reports/DailyWeightReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink5.NavigateUrl = String.Format("~/QC/Reports/DeviationReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink611.NavigateUrl = String.Format("~/QC/Reports/FirstPieceApprovalReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink711.NavigateUrl = String.Format("~/QC/Reports/LOTClearnceReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink6125.NavigateUrl = String.Format("~/QC/Reports/OnlineQualityReport.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink6126.NavigateUrl = String.Format("~/QC/Reports/RejectionNote.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink6.NavigateUrl = String.Format("~/Stores/Masters/TypeofIndustryMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink22.NavigateUrl = String.Format("~/Stores/Masters/CurrencyMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink18.NavigateUrl = String.Format("~/Stores/Masters/DepartmentMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink7.NavigateUrl = String.Format("~/Stores/Masters/ConstitutionMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink25.NavigateUrl = String.Format("~/Stores/Masters/OpeningStockMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink9.NavigateUrl = String.Format("~/Stores/Masters/SupplierCountryMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink10.NavigateUrl = String.Format("~/Stores/Masters/SupplierState.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink11.NavigateUrl = String.Format("~/Stores/Masters/SupplierCityMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink6124.NavigateUrl = String.Format("~/Stores/Masters/FamilyGroupMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
        End If
    End Sub
End Class
