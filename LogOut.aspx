<%@ Page Title="WORKFLOW MANAGEMENT" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="LogOut.aspx.vb" Inherits="LogOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">


        .style3
        {
            width: 10px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center" style="width: 100%">
        <table align="center" style="width: 100%;">
            <tr>
                <td align="center" bgcolor="White" class="style3" style="width: 100%">
                    <br />
                    <table align="center" bgcolor="White" style="width: 100%; height: 364px;">
                        <tr>
                            <td align="center">
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
                                <b><span style="font-size: large">You have Successfully Logout<br />
                                </span>
                                <br />
                                <span style="font-size: medium">Please Close Window and Login Again. </span></b>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
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

