<%@ Page Title="ERP" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false"
    CodeFile="ReportDashBoardAccounts.aspx.vb" Inherits="ReportDashBoardAccounts" %>

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
       
        .style8
        {
            height: 20px;
        }
       
        .auto-style1 {
        width: 10px;
    }
    .auto-style2 {
        height: 20px;
        width: 10px;
    }
       
        .auto-style3 {
            margin-bottom: 0px;
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
                    <h4 class="text-themecolor">Finance - Reports</h4>
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
                                <td align="left" >
                                    <asp:Label ID="Label685" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="13pt" Text="Registers" Width="300px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left" >
                                    <asp:Label ID="Label686" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="13pt" Text="Ledgers" Width="300px"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label687" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="13pt" Text="AR/AP" 
                                        Width="300px"></asp:Label>
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
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Journal Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; General Ledger</asp:HyperLink>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1064" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Accounts Receivables</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label700" runat="server" ForeColor="#DFDFDF" 
                                        Text="------------------------------------------------------------" 
                                        Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label701" runat="server" ForeColor="#DFDFDF" 
                                        Text="------------------------------------------------------------" 
                                        Width="100%"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label814" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1076" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Purchase Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink8" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Debtors Ledger</asp:HyperLink>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Accounts Receivables Salesman wise</asp:HyperLink>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label697" runat="server" ForeColor="#DFDFDF" 
                                        Text="------------------------------------------------------------" 
                                        Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label698" runat="server" ForeColor="#DFDFDF" 
                                        Text="------------------------------------------------------------" 
                                        Width="100%"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>                                 
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Purchase Register (with GST% breakup)</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink9" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Creditors Ledger</asp:HyperLink>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink10" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Accounts Receivables - Local Debtors</asp:HyperLink>
     
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label827" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label696" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label702" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1031" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Purchase Detail Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Bank Book</asp:HyperLink>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1046" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Accounts Receivables - Overseas Debtors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label826" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label707" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label783" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1099" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Expense Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style8">
                                    <asp:HyperLink ID="HyperLink12" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Cash Book</asp:HyperLink>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Accounts Receivables - USD</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label805" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label756" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label784" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1000" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Expense Register (with GST% breakup)</asp:HyperLink>
                                </td>
                                <td class="style8">
                                    </td>
                                <td class="style8">
                                    </td>
                                <td class="style8">
                                    </td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1018" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Account Confirmation Letter</asp:HyperLink>
                                </td>
                                <td align="left" class="style8">
                                    &nbsp;</td>
                                <td class="style8">
                                    </td>
                                <td class="style8">
                                    </td>
                                <td class="auto-style2">
                                    </td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1063" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Accounts Payables</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label849" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label811" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label813" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1066" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Expense Detail Register</asp:HyperLink>
                                </td>
                                <td>
                                    </td>
                                <td>
                                    </td>
                                <td>
                                    </td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1019" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Balance Confirmation Letter</asp:HyperLink>
                                </td>
                                <td align="left">
                                    </td>
                                <td>
                                    </td>
                                <td>
                                    </td>
                                <td class="auto-style1">
                                    </td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink26" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Accounts Payables - Local Creditors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label825" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label810" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label699" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Debit Note Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1020" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Loan Confirmation Letter</asp:HyperLink>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1048" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Accounts Payables - Overseas Creditors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label836" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label812" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label795" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style8">
                                    <asp:HyperLink ID="HyperLink1067" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; E - Debit Note Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1072" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; General Ledger (Multi Curr)</asp:HyperLink>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1047" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Accounts Payables - USD</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label837" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label854" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label738" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Credit Note Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1103" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Loan Ledger</asp:HyperLink>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink25" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; AR Ageing - Local Debtors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label838" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label794" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style8">
                                    <asp:HyperLink ID="HyperLink1068" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; E - Credit Note Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left" class="style8">
                                    <asp:HyperLink ID="HyperLink1044" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; AR Ageing - Overseas Debtors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label839" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label793" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink22" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Sales Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink13" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; AR Ageing - New</asp:HyperLink>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label840" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label714" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="Final Books" Width="250px"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label2" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1062" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Export Sales Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink27" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; AP Ageing - Local Creditors</asp:HyperLink>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label841" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1008" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Trial Balance </asp:HyperLink>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label792" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1033" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Sales Detail Register</asp:HyperLink>
                                </td>
                                <td class="style8"></td>
                                <td class="style8"></td>
                                <td class="style8"></td>
                                <td align="left" class="style8">
                                    <asp:Label ID="Label715" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left" class="style8"></td>
                                <td class="style8"></td>
                                <td class="style8"></td>
                                <td class="auto-style2"></td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1054" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; AP Ageing - Overseas Creditors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label842" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1009" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Profit &amp; Loss A/C</asp:HyperLink>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label801" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink23" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Sales Return Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label743" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1012" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customer Billwise Ageing - Local Debtors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label843" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1010" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Balance Sheet</asp:HyperLink>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label796" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1001" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Receipt Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1045" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Customer Billwise Ageing - Overseas Debtors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    
                                    <asp:Label ID="Label844" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label797" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1002" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Payment Register</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1027" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Supplier Billwise Ageing - Local Creditors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label845" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label798" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1003" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Daybook Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1057" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Supplier Billwise Ageing - Overseas Creditors</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label846" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td class="style8"></td>
                                <td class="style8"></td>
                                <td class="style8"></td>
                                <td align="left" class="style8">
                                    &nbsp;</td>
                                <td align="left" class="style8"></td>
                                <td class="style8"></td>
                                <td class="style8"></td>
                                <td class="auto-style2"></td>
                                <td align="left">
                                    <asp:Label ID="Label804" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink21" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; TDS Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1016" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Debtors Net Outstanding Summary</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label847" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label802" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style8">
                                    <asp:HyperLink ID="HyperLink1004" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; TCS Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left" class="style8">
                                    <asp:HyperLink ID="HyperLink1017" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Interest on Outstanding</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label848" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label803" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1032" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Monthly Sales Summary</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label828" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1034" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Partywise Sales Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label829" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1035" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Total Sales As On</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label774" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="13pt" Text="GST" Width="250px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style8">
                                    <asp:Label ID="Label830" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1036" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Import Advance License Report</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink50" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GSTR 1</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label831" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label775" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1038" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Export Advance License Report</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink75" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GSTR 2</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label832" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label776" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1037" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2" Visible="False">&gt; Bank Payment Sheet</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink1039" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Advance License Summary</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left" class="style8">
                                    <asp:HyperLink ID="HyperLink1013" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Inward GST Summary</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label833" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label777" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1040" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; BRC Status Report</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1014" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Outward GST Summary</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label834" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label778" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1065" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Export Packing List Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1029" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GST Input Report</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label835" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label779" runat="server" CssClass="auto-style3" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1069" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; PCFC Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1030" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GST Output Report</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label821" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label851" runat="server" CssClass="auto-style3" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1070" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; Bill Purchase Register</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1105" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GST Reconcillation </asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label822" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label852" runat="server" CssClass="auto-style3" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1071" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; NEPRA Report File</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1101" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GST ITC Balance Receivable</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label823" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label857" runat="server" CssClass="auto-style3" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1073" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; EPCG Licence Report</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1104" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GST 2A Reco Uplaod</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label824" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label856" runat="server" CssClass="auto-style3" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1100" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GST Refund Report</asp:HyperLink>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1102" runat="server" CssClass="EntryFormHeadingNew" Font-Bold="False" Font-Size="10pt" Font-Underline="False" ForeColor="#609ED2">&gt; GST 2A Reco Report (Match - Mismatch)</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label850" runat="server" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label855" runat="server" CssClass="auto-style3" ForeColor="#DFDFDF" Text="------------------------------------------------------------" Width="100%"></asp:Label>
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