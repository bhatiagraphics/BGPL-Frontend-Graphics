<%@ Page  Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false"
    CodeFile="ReportDashBoardSetup.aspx.vb" Inherits="ReportDashBoardSetup" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 20px;
        }
    </style>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
      <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Reports</h4>
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
                                <td align="left">
                                    <asp:Label ID="Label685" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="13pt" Text="Pending Jobs Reports" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label714" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="13pt" Width="300px" Text="Completed Jobs Reports"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr>
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
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Jobs</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink8" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Jobs Completed Approval form Graphics</asp:HyperLink>
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
                                <td align="left" class="auto-style3">
                                    </td>
                                <td class="auto-style3">
                                    </td>
                                <td class="auto-style3">
                                    </td>
                                <td class="auto-style3">
                                    </td>
                                <td align="left" class="auto-style3">
                                    </td>
                                <td class="auto-style3">
                                    </td>
                                <td class="auto-style3">
                                    </td>
                                <td class="auto-style3">
                                    </td>
                                <td align="left" class="auto-style3">
                                    </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Jobs Approval form Graphics </asp:HyperLink>
                                </td>
                                <td class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td align="left" class="auto-style2">
                                    <asp:HyperLink ID="HyperLink9" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Jobs Completed Send To Customer</asp:HyperLink>
                                </td>
                                <td class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td align="left" class="auto-style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
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
                                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Jobs Send to Customer</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink10" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Jobs Completed Send To Customer for Approval</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Jobs Send to Customer for Approval</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Jobs Completed for Prepress</asp:HyperLink>
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
                                <td align="left">
                                    &nbsp;</td>
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
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Jobs for Prepress</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Jobs Completed for Material Production</asp:HyperLink>
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
                                <td align="left">
                                    &nbsp;</td>
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
                                    <asp:HyperLink ID="HyperLink12" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Jobs for Material Production</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink14" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Jobs Completed for QC</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink13" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Jobs for QC Check</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink15" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Jobs Completed for Billing</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink19" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Jobs for Billing</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink20" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Jobs Completed for Dispatch</asp:HyperLink>
                                    
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
                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Pending Jobs for Dispatch</asp:HyperLink>
                                    
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
                                <td align="left" height="60px">
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