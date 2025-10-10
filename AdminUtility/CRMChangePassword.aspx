<%@ Page Language="VB" MasterPageFile="~/MasterPageForExternal.master"  AutoEventWireup="false" CodeFile="CRMChangePassword.aspx.vb" Inherits="CRMChangePassword" title="FORTUNE CRM" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

        .tooltip {
            position: relative;
            display: inline-block;
        }

        .tooltip .tooltiptext {
            visibility: hidden;
            width: 340px;
            background-color: black;
            color: #fff;
            text-align: center;
            border-radius: 6px;
            padding: 5px 0;

            /* Position the tooltip */
            position: absolute;
            z-index: 1;
        }

        .tooltip:hover .tooltiptext {
            visibility: visible;
        }
        .style36
        {
            height: 287px;
            width: 354px;
        }
        .style38
        {
            width: 8px;
        }
        .style41
        {
        }
        .style46
        {
            width: 144px;
        }
        .style47
        {
            width: 169px;
        }
        
/* Popup container - can be anything you want */
.popup {
    position: relative;
    display: inline-block;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}

/* The actual popup */
.popup .popuptext {
    visibility: hidden;
    width: 160px;
    background-color: #555;
    color: #fff;
    text-align: center;
    border-radius: 6px;
    padding: 8px 0;
    position: absolute;
    z-index: 1;
    bottom: 125%;
    left: 50%;
    margin-left: -80px;
}

/* Popup arrow */
.popup .popuptext::after {
    content: "";
    position: absolute;
    top: 100%;
    left: 50%;
    margin-left: -5px;
    border-width: 5px;
    border-style: solid;
    border-color: #555 transparent transparent transparent;
}

/* Toggle this class - hide and show the popup */
.popup .show {
    visibility: visible;
    -webkit-animation: fadeIn 1s;
    animation: fadeIn 1s;
}

/* Add animation (fade in the popup) */
@-webkit-keyframes fadeIn {
    from {opacity: 0;} 
    to {opacity: 1;}
}

@keyframes fadeIn {
    from {opacity: 0;}
    to {opacity:1 ;}
}
        </style>

        
<script>
    // When the user clicks on div, open the popup
    function myFunction() {
        var popup = document.getElementById("myPopup");
        popup.classList.toggle("show");
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center" style="height: 534px; width: 100%;">
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Panel ID="Panel2" runat="server">
                                        
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="Label3" runat="server" CssClass="LableInterface" 
                                                        Font-Bold="False" 
                                                        Text="Password required at least 1 uppercase and 1 lowercase, 1 numeric, 1 special character'@%&amp;$', length from 6 to 20"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center">
                        <table align="center" bgcolor="White" style="border: 1px groove #808080;" 
                                            frame="border" class="style36">
                            <tr>
                                <td align="left" colspan="5" class="SectionHeading">
                                            <label ID="Label292" title="Test" __designer:mapid="683">
                                            <asp:Label ID="Label293" runat="server" Font-Bold="True" 
                                                Font-Names="Century Gothic" Font-Size="13pt" ForeColor="Black" 
                                                Text="CHANGE PASSWORD" style="text-align: left"></asp:Label>
                                            </label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                            <asp:Label ID="Label34" runat="server" Text="Current Password " Width="250px" 
                                Font-Bold="False" CssClass="LableInterface" Height="18px"></asp:Label>
                                </td>
                                <td align="left" class="style38">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                                            <asp:TextBox ID="txtCurrentPassword" runat="server" 
                                                CssClass="TextBoxCompulsoryInt" Font-Bold="True" TabIndex="2" 
                                                TextMode="Password" ValidationGroup="Save" Width="300px"></asp:TextBox>
                                </td>
                                <td align="left" class="style38">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCurrentPassword"
                                ErrorMessage="*" Font-Bold="True" Font-Size="Large"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                                    <asp:Label ID="Label7" runat="server" Text="New Password" Width="250px" 
                                        Font-Bold="False"  CssClass="LableInterface" Height="18px"></asp:Label>
                                </td>
                                <td align="left" class="style38">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                    
                                <td align="left" class="style41">
                                </td>
                                    
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" colspan="2">

                                            <asp:TextBox ID="txtPassword"  runat="server" CssClass="TextBoxCompulsoryInt" 
                                                Font-Bold="True" TabIndex="2" TextMode="Password" 
                                                ValidationGroup="Save" Width="300px"></asp:TextBox>
                                            <ajax:BalloonPopupExtender ID="PopupControlExtender2" runat="server" 
                                                TargetControlID="txtPassword"
                                                BalloonPopupControlID="Panel2"
                                                Position="BottomRight" 
                                                BalloonStyle="Rectangle"
                                                BalloonSize="Small"
                                                DisplayOnClick="true" 
                                                DisplayOnMouseOver="true"
                                                DisplayOnFocus="true"/>

                                </td>
                                <td align="left" class="style38">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                         <ContentTemplate>
                                             <asp:RegularExpressionValidator ID="Regex4" runat="server" 
                                                 ControlToValidate="txtPassword" ErrorMessage="*" 
                                                 ForeColor="Red" 
                                                 
                                                 ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{6,20}" 
                                                 Font-Bold="True" Font-Size="Large" />
                                         </ContentTemplate>
                                     </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                            <asp:Label ID="Label33" runat="server" Text="Confirm Password" Width="250px" 
                                Font-Bold="False" CssClass="LableInterface" Height="18px"></asp:Label>
                                </td>
                                <td align="left" class="style38">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="style41">
                                    </td>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                                            <asp:TextBox ID="txtConfrimPassword" runat="server" 
                                                CssClass="TextBoxCompulsoryInt" Font-Bold="True" TabIndex="2" 
                                                TextMode="Password" ValidationGroup="Save" Width="300px"></asp:TextBox>
                                </td>
                                <td align="left" class="style38">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConfrimPassword"
                                ErrorMessage="*" Font-Bold="True" Font-Size="Large"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="center" colspan="2">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtPassword" ControlToValidate="txtConfrimPassword" 
                                Font-Bold="True" Font-Names="Arial" Font-Size="Small">Password does not match</asp:CompareValidator>
                                </td>
                                <td align="left" class="style38">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                            <asp:Label ID="lblError" runat="server" ForeColor="#FF3300" Font-Bold="True" 
                                Font-Names="Century Gothic" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left" class="style38">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5" class="Headingseparator"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style46">
                                                            <asp:Button ID="btnLogout" runat="server" CssClass="ButtonInterface_Entry" 
                                                                Font-Bold="False" Height="31px" OnClientClick="Confirm()" Text="LogOut" 
                                                                Width="85px" />
                                                                
                                </td>
                                <td align="right" class="style47">
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonInterface_Entry" 
                                                                Font-Bold="False" Height="31px" OnClientClick="Confirm()" Text="Submit" 
                                                                Width="85px" />
                                                                
                                </td>
                                <td align="left" class="style38">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style41">
                                    &nbsp;</td>
                                <td align="left" class="style46">
                                    <asp:HiddenField ID="HFUserID" runat="server" />
                                </td>
                                <td align="right" class="style47">
                                    &nbsp;</td>
                                <td align="left" class="style38">
                                    &nbsp;</td>
                            </tr>
                            </table>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                </table>
                            </div>
</asp:Content>

