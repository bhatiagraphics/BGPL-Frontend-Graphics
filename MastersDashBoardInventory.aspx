<%@ Page Title="ERP" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false"
    CodeFile="MastersDashBoardInventory.aspx.vb" Inherits="MastersDashBoardInventory" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
      <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Inventory - Masters	 	 </h4>
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
                        <table style="width: 50%;">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label685" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="13pt" Text="Master" Width="300px"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; FG Group Master</asp:HyperLink>
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
                                    <asp:Label ID="Label5" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink311" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Product Groups</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink411" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Product Sub Groups</asp:HyperLink>
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
                                    <asp:Label ID="Label700" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Product Sub Sub Groups</asp:HyperLink>
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
                                    <asp:Label ID="Label2" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink611" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; UOM</asp:HyperLink>
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
                                    <asp:Label ID="Label695" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink711" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Store</asp:HyperLink>
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
                                                                    <asp:Label ID="Label1" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
   
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
                                    <asp:HyperLink ID="HyperLink25" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Opening Stock</asp:HyperLink>
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
                                                                    <asp:Label ID="Label3" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
   
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
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt;FG Opening Stock</asp:HyperLink>
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
                                    <asp:Label ID="Label713" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink6127" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt;HSN Master</asp:HyperLink>
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
                                    <asp:Label ID="Label714" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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
                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt;GST Rate Master</asp:HyperLink>
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
                                    <asp:Label ID="Label4" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>    
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
                                    <asp:HyperLink ID="HyperLink6128" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt;FG Short Code Master</asp:HyperLink>
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
                                    <asp:Label ID="Label715" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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