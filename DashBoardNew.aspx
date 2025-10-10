<%@ Page Title="ERP" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false"
    CodeFile="DashBoardNew.aspx.vb" Inherits="Home" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <iframe
        src="MainDashBoard.aspx" style=" width: 100%; border: none; overflow: auto;" width="100%" frameborder="0"  scrolling="no" onload="javascript:(function(o){o.style.height=o.contentWindow.document.body.scrollHeight+'px';}(this));"
                        height="100%" ></iframe>


    </asp:Content>