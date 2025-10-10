Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Drawing

Partial Class MastersDashBoardAccounts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HyperLink1.NavigateUrl = String.Format("~/Accounts/Masters/AccountGroupMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink2.NavigateUrl = String.Format("~/Accounts/Masters/AccountMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink3.NavigateUrl = String.Format("~/Accounts/Masters/AccountTDSMapping.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink4.NavigateUrl = String.Format("~/Accounts/Masters/FACostCenter.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink6.NavigateUrl = String.Format("~/Accounts/Masters/AccOpeningSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink7.NavigateUrl = String.Format("~/Accounts/Masters/FAFORMTYPE.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink8.NavigateUrl = String.Format("~/Accounts/Masters/VoucherTypeSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink9.NavigateUrl = String.Format("~/Accounts/Masters/BeneficiaryCodeMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink10.NavigateUrl = String.Format("~/Accounts/Masters/DestinationLocationCodeMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink11.NavigateUrl = String.Format("~/Accounts/Masters/attachdocmaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))

        End If
    End Sub
End Class
