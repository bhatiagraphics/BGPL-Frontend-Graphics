Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.Class
Imports FOODERPWEB.DAL
Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Drawing

Partial Class MastersDashBoardInventory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HyperLink311.NavigateUrl = String.Format("~/Stores/Masters/ItemGroupMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink411.NavigateUrl = String.Format("~/Stores/Masters/SubGroupMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink5.NavigateUrl = String.Format("~/Stores/Masters/ProductSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink611.NavigateUrl = String.Format("~/Stores/Masters/UOMMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink711.NavigateUrl = String.Format("~/Stores/Masters/StoreMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink25.NavigateUrl = String.Format("~/Stores/Masters/OpeningStockMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            'HyperLink6126.NavigateUrl = String.Format("~/Stores/Masters/ItemMasterSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink1.NavigateUrl = String.Format("~/Stores/Masters/SubSubGroupMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink2.NavigateUrl = String.Format("~/Stores/Masters/FGOpeningStockMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink6127.NavigateUrl = String.Format("~/Stores/Masters/HSNMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink3.NavigateUrl = String.Format("~/Stores/Masters/FGGroupSearch.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink4.NavigateUrl = String.Format("~/Marketing/Masters/GstRateMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
            HyperLink6128.NavigateUrl = String.Format("~/Marketing/Masters/FGShortCodeMaster.aspx?MMModuleid=" & Trim(Request.QueryString("MMModuleid")) & "&mainid=" & Trim(Request.QueryString("mainid")) & "&subid=" & Trim(Request.QueryString("subid")))
        End If
    End Sub
End Class
