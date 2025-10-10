<%@ Page Title="ERP" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false"
    CodeFile="Home_DashBoard.aspx.vb" Inherits="Home_DashBoard" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script>    window.jQuery || document.write(decodeURIComponent('%3Cscript src="js/jquery-3.1.0.min.js"%3E%3C/script%3E'))</script>
    
    <script src="GraphScripts/jquery.min.js"></script>
    <script src="GraphScripts/cldr.min.js" type="text/javascript"></script>
    <script src="GraphScripts/event.min.js" type="text/javascript"></script>
    <script src="GraphScripts/supplemental.min.js" type="text/javascript"></script>
    <script src="GraphScripts/unresolved.min.js" type="text/javascript"></script>
    <script src="GraphScripts/globalize.min.js" type="text/javascript"></script>
    <script src="GraphScripts/message.min.js" type="text/javascript"></script>
    <script src="GraphScripts/number.min.js" type="text/javascript"></script>
    <script src="GraphScripts/currency.min.js" type="text/javascript"></script>
    <script src="GraphScripts/date.min.js" type="text/javascript"></script>
    <script src="GraphScripts/dx.all.js" type="text/javascript"></script>

    <link href="GraphStyles/dx.common.css" rel="stylesheet" type="text/css" />
    <link href="GraphStyles/dx.light.css" rel="stylesheet" type="text/css" />
    <link href="GraphStyles/dx.spa.css" rel="stylesheet" type="text/css" />
    <link href="GraphStyles/StylesGraph.css" rel="stylesheet" type="text/css" />
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
       
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table style="width:100%; height: 100%;">
    <tr height="350px">
        <td align="center">
                <iframe src="Dashboard_chart_Area.aspx" width="100%" height="100%"></iframe>
            </td>
            <td align="center">
                <iframe src="Dashboard_chart_Product.aspx" width="100%" height="100%"></iframe>
            </td>
    </tr>
    <tr height="260px">
        <td align="center" colspan="2">
        <iframe src="Dashboard_chart_Month.aspx" width="100%" height="100%"></iframe>
    </td>
    </tr>
</table>


    </asp:Content>