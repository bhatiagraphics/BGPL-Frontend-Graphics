<%@ Page title="ERP" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false"
    CodeFile="ReportDashBoardInventory.aspx.vb" Inherits="ReportDashBoardInventory" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <style type="text/css">
        .style44
        {
            height: 20px;
        }
        .auto-style1 {
            height: 18px;
        }
    </style>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
       <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Inventory - Reports</h4>
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
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label717" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Registers" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label718" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="13pt" Text="Pending Registers" Width="300px"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label690" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Stock Reports" Width="250px"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    &nbsp;</td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink19" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Gate Entry Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                <asp:HyperLink ID="HyperLink10" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending GRN for Bills</asp:HyperLink>   
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Stock Reports</asp:HyperLink>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    <asp:Label ID="Label698" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    <asp:Label ID="Label723" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">
                                    <asp:Label ID="Label693" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GRN Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    
                                    <asp:HyperLink ID="HyperLink27" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Gate Entry Register</asp:HyperLink>
                                    
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink12" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Stock Report - Batchwise</asp:HyperLink>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label696" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label737" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label716" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Purchase Return Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink30" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending SRN Register</asp:HyperLink>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink20" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Stock Ledger</asp:HyperLink>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label705" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label741" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label731" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style44">
                                    &nbsp;</td>
                                <td align="left" class="style44">
                                <asp:HyperLink ID="HyperLink14" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Product List</asp:HyperLink>    
                                </td>
                                <td class="style44">
                                    &nbsp;</td>
                                <td class="style44">
                                    &nbsp;</td>
                                <td class="style44">
                                    &nbsp;</td>
                                <td align="left" class="style44">
                                    &nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">
                                    <asp:HyperLink ID="HyperLink21" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; FG Stock Report</asp:HyperLink>
                                </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style44">
                                    &nbsp;</td>
                                <td align="left" class="style44">
                                    <asp:Label ID="Label730" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style44">
                                    &nbsp;</td>
                                <td class="style44">
                                    &nbsp;</td>
                                <td class="style44">
                                    &nbsp;</td>
                                <td align="left" class="style44">
                                    &nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">
                                    <asp:Label ID="Label732" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style44">
                                </td>
                                <td align="left" class="style44">
                                    <asp:HyperLink ID="HyperLink24" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Gate Pass Register</asp:HyperLink>
                                </td>
                                <td class="style44">
                                </td>
                                <td class="style44">
                                </td>
                                <td class="style44">
                                </td>
                                <td align="left" class="style44">
                                    &nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">
                                    <asp:HyperLink ID="HyperLink22" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; FG Stock Ledger</asp:HyperLink>
                                </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label734" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label733" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    </td>
                                <td align="left" class="auto-style1">
                                    <asp:HyperLink ID="HyperLink25" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Material Issue Register</asp:HyperLink>
                                </td>
                                <td class="auto-style1">
                                    </td>
                                <td class="auto-style1">
                                    </td>
                                <td class="auto-style1">
                                    </td>
                                <td align="left" class="auto-style1">
                                    </td>
                                <td align="left" class="auto-style1"></td>
                                <td align="left" class="auto-style1"></td>
                                <td align="left" class="auto-style1"></td>
                                <td align="left" class="auto-style1">
                                    &nbsp;</td>
                                <td align="left" class="auto-style1"></td>
                                <td align="left" class="auto-style1"></td>
                                <td align="left" class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label735" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    <asp:HyperLink ID="HyperLink26" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Material Return Note</asp:HyperLink>
                                </td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">
                                    &nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    <asp:Label ID="Label736" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">
                                    
                                </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink23" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; PR Status Report</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label738" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink28" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customerwise Boxwise Inventory</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label739" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink32" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Job Inward Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    <asp:Label ID="Label740" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td class="style44">
                                    </td>
                                <td align="left" class="style44">
                                    </td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                                <td align="left" class="style44">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink33" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; FG Assembly Report</asp:HyperLink>
                                    </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label742" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink34" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Delivery Challan Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label743" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink31" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; SRN Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label744" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink35" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; SR Status Report</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label745" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Gate Pass Status Report</asp:HyperLink>
                                    
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left" class="style44" height="40px">&nbsp;</td>
                                <td align="left" class="style44" height="40px">&nbsp;</td>
                                <td align="left" class="style44" height="40px">&nbsp;</td>
                                <td align="left" class="style44" height="40px">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label746" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left" class="style44" height="40px">&nbsp;</td>
                                <td align="left" class="style44" height="40px">&nbsp;</td>
                                <td align="left" class="style44" height="40px">&nbsp;</td>
                                <td align="left" class="style44" height="40px">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
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
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
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