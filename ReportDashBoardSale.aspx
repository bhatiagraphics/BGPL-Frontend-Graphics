<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false"
    CodeFile="ReportDashBoardSale.aspx.vb" Inherits="ReportDashBoardSale" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">

        #frame1
        {
            width: 895px;
            height: 736px;
        }
                            
        .HighLightEventes
        {
            color: #333333;
            background: #FFEA81;
            border: 2px solid #FDD000;         
        }
        
        .HighLightToday
        {
            color: #333333;
            background: #E1ECF8;
            border: 2px solid #FDD000;         
        } 
       
        .style4
        {
            height: 20px;
        }
       
        .auto-style1 {
            height: 19px;
        }
        .auto-style2 {
            height: 21px;
        }
       
        .auto-style3 {
            width: 326px;
        }
        .auto-style4 {
            height: 21px;
            width: 326px;
        }
        .auto-style5 {
            height: 20px;
            width: 396px;
        }
        .auto-style6 {
            height: 19px;
            width: 326px;
        }
       
        </style>
        
       <script type="text/javascript" language="javascript">
           function SetTarget() {
               document.forms[0].target = "_blank";
           }
       </script>  

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Sales &amp; Marketing - Reports</h4>
                </div>
                <div class="col-md-7 align-self-center text-right">
                    <div class="d-flex justify-content-end align-items-center">
                    </div>
                </div>
            </div>
        </div>
    <div align="center" style="height: 100%; width: 100%; padding-left: 5px; padding-right: 5px;">
        <asp:Panel ID="Panel2" runat="server" Height="100%" Width="100%" BackColor="White">
            <table style="width: 100%; height: 100%;">
            
                <tr>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <table >
                            <tr>
                                <td align="left" class="auto-style3" >
                                    <asp:Label ID="Label707" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Registers" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left" >
                                    <asp:Label ID="Label744" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Sales Summaries" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label708" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Pending Register" Width="300px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style4">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td align="left" class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td align="left" class="auto-style2">
                                    </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Sales Order Register</asp:HyperLink>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink8" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Citywise Sales Summary</asp:HyperLink>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink13" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Sales Order</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">
                                    <asp:Label ID="Label734" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label745" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label759" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Sales Register</asp:HyperLink>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink9" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Monthly Sales Summary</asp:HyperLink>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink19" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Sales Order - Export</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:Label ID="Label735" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left">
                                    <asp:Label ID="Label750" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    <asp:Label ID="Label757" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Sales Detail Register</asp:HyperLink>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink10" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Datewise Sales Summary</asp:HyperLink>
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink20" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Sales Order - Domestic</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">
                                    <asp:Label ID="Label743" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:Label ID="Label751" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label758" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">
                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Sales Return Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Partywise Sales Summary</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:Label ID="Label754" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left">
                                    <asp:Label ID="Label752" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    <asp:Label ID="Label753" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Master List" Width="300px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:HyperLink ID="HyperLink17" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Export Price List Report</asp:HyperLink>
                                </td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink12" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Sales Summary</asp:HyperLink>
                                </td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left" class="style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:Label ID="Label756" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label755" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink18" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customer Master List</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    &nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink16" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Productwise Sales Summary</asp:HyperLink>
                                </td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left" class="style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    &nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left" class="style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    &nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left" class="style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    &nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left" class="style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    &nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left" class="style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td class="style4">&nbsp;</td>
                                <td align="left" class="style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">
                                    <asp:Label ID="Label739" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Crosstab Reports" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style4">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">
                                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Groupwise Monthly Cross Tab</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:Label ID="Label740" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    &nbsp;</td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Width="310px">&gt; Productwise Customerwise Monthly Cross Tab</asp:HyperLink>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    &nbsp;</td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">
                                    <asp:Label ID="Label741" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style5">
                                    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Sales Analysis Report</asp:HyperLink>
                                </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    &nbsp;</td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    </td>
                                <td align="left" class="style4">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label760" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Domestic Pre-Sales Summaries" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label781" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Domestic Pending Sales Summaries" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label774" runat="server" Text="Domestic Post-Sales Summaries" Width="300px" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style4">
                                    &nbsp;</td>
                                <td class="auto-style1"></td>
                                <td class="auto-style1"></td>
                                <td class="auto-style1"></td>
                                <td align="left" class="style4">
                                    &nbsp;</td>
                                <td class="auto-style1"></td>
                                <td class="auto-style1"></td>
                                <td class="auto-style1"></td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink21" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Sales Order Summary (Value) </asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink33" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Pending Sales Order Summary (Value) </asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink24" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Sales Summary (Value)</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style4">
                                    <asp:Label ID="Label762" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:Label ID="Label782" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:Label ID="Label775" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink22" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Sales Order Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink34" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Pending Sales Order Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink25" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Sales Summary</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label763" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label783" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label776" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink23" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Productwise Sales Order Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink35" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Productwise Pending Sales Order Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink26" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Productwise Sales Summary</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label764" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label784" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label777" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink30" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Monthwise Sales Order Summary (Value)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink36" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Monthwise Pending Sales Order Summary (Value)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink27" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Monthwise Sales Summary (Value)</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label771" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label785" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label778" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style1">
                                    <asp:HyperLink ID="HyperLink31" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Sales Order Summary (Value)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="auto-style1">
                                    <asp:HyperLink ID="HyperLink37" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Pending Sales Order Summary (Value)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="auto-style1">
                                    <asp:HyperLink ID="HyperLink28" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Sales Summary (Value)</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label772" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label786" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label779" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink32" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Sales Order Summary (Qty)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink38" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Pending Sales Order Summary (Qty)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink29" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Sales Summary (Qty)</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label773" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label787" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label780" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style3">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label795" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Export Pre-Sales Summaries" Width="300px"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label788" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Export Pending Sales Summaries" Width="300px"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label802" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Export Post-Sales Summaries" Width="300px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style4">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink45" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Sales Order Summary (Value) </asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink39" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Pending Sales Order Summary (Value) </asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink51" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Sales Summary (Value)</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style4">
                                    <asp:Label ID="Label796" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:Label ID="Label789" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:Label ID="Label803" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink46" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Sales Order Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink40" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Pending Sales Order Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink52" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Sales Summary</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label797" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label790" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label804" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink47" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Productwise Sales Order Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink41" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Productwise Pending Sales Order Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style4">
                                    <asp:HyperLink ID="HyperLink53" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Productwise Sales Summary</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label798" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label791" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label805" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink48" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Monthwise Sales Order Summary (Value)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink42" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Monthwise Pending Sales Order Summary (Value)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink54" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Monthwise Sales Summary (Value)</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label799" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label792" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label806" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style1">
                                    <asp:HyperLink ID="HyperLink49" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Sales Order Summary (Value)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="auto-style1">
                                    <asp:HyperLink ID="HyperLink43" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Pending Sales Order Summary (Value)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="auto-style1">
                                    <asp:HyperLink ID="HyperLink55" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Sales Summary (Value)</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label800" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label793" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label807" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink50" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Sales Order Summary (Qty)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink44" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Pending Sales Order Summary (Qty)</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink56" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Productwise Monthwise Sales Summary (Qty)</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label801" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label794" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label808" runat="server" ForeColor="#DFDFDF" Text="--------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="Headingseparator">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="style158">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
            </div>
    </asp:Content>