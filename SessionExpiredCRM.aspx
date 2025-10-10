<%@ Page Title="WORKFLOW MANAGEMENT" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SessionExpiredCRM.aspx.vb" Inherits="SessionExpiredCRM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
      <script>
    
          window.onload = function () {

              if (window.parent.location.href != window.location.href) {

                  window.parent.location.href = window.location.href;
              }
          };
      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center" style="width: 100%; height: auto">
        <table align="center" bgcolor="#DDE8F4" class="TableInterface" 
            style="width: 100%;">
            <tr>
                <td align="center" bgcolor="White" style="width: 100%;">
                    <br />
                    <table align="center" bgcolor="White" style="width:100%; height: 364px;">
                        <tr>
                            <td>
                                <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
                                </asp:Timer>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="White">
                                <b><span style="font-size: large">Your Session has Expired<br /></span>
                                <br /><span style="font-size: medium">Please Close Window and Login Again. 
                                </span></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            <br />
                            <br />
                            <br />
                            <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

