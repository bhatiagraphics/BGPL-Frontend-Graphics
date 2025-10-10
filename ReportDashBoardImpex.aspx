<%@ Page Title="ERP" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false"
    CodeFile="ReportDashBoardImpex.aspx.vb" Inherits="ReportDashBoardImpex" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
      <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Impex - Report	 	 </h4>
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
                                        Font-Bold="False" Font-Size="13pt" Text="Report" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label712" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="13pt" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label713" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="13pt" Width="300px"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink6124" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt;Impex Daily Report</asp:HyperLink>
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
                                    <asp:Label ID="Label720" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink311" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Export Master List</asp:HyperLink>
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
                                    <asp:Label ID="Label711" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink411" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Final Export Container Schedule</asp:HyperLink>
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
                                    <asp:Label ID="Label721" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink6125" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="false" >&gt; Export Daily Report</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink6126" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="false">&gt; Export Despatch Schedule</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink6127" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="false">&gt; Export Master List</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink6128" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="false">&gt; Import Daily Report</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink6129" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="false">&gt; Kostas Commission Details</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink6130" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="false">&gt; MEIS Lic DSR</asp:HyperLink>
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
                                <td align="left" class="auto-style1">
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    </td>
                                <td class="auto-style1">
                                    </td>
                                <td class="auto-style1">
                                    </td>
                                <td align="left" class="auto-style1">
                                    </td>
                                <td class="auto-style1">
                                    </td>
                                <td class="auto-style1">
                                    </td>
                                <td class="auto-style1">
                                    </td>
                                <td align="left" class="auto-style1">
                                    </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink6131" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="false">&gt; Daily Container Booking Report</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink6132" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="false">&gt; Export Container Schedule</asp:HyperLink>
                                </td>
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
                                    <asp:HyperLink ID="HyperLink6133" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="false">&gt; Export Job Sheet</asp:HyperLink>
                                </td>
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
                                <td align="left" >
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