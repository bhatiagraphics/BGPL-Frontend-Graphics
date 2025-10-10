Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Drawing

Partial Class ReportDashBoardCRM
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HyperLink1.NavigateUrl = String.Format("~/CRM/Reports/LeadRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink2.NavigateUrl = String.Format("~/CRM/Reports/ActivityRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink3.NavigateUrl = String.Format("~/CRM/Reports/DSRREPORT.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

            'HyperLink311.NavigateUrl = String.Format("~/Production/Reports/ProductionRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink2.NavigateUrl = String.Format("~/Production/Reports/ScrapGenerationRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink411.NavigateUrl = String.Format("~/Production/Reports/GrinderRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink6125.NavigateUrl = String.Format("~/Production/Reports/WorkOrderRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink6126.NavigateUrl = String.Format("~/Production/Reports/ConsumptionRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink6127.NavigateUrl = String.Format("~/Production/Reports/GeneralConsumptionRegister.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
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
