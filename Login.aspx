<%@ Page Title="WORKFLOW MANAGEMENT" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    <div class="login-register">
        <div class="login-box " style="text-align: center; padding-bottom: 5px; background: white">


            <div class="col-sm-12" style="margin-bottom: 30px;padding-top: 10px;background: #002d66;">
                <img id="ctl00_ContentPlaceHolder1_Image1" src="/images/Bhalcon_Logo_trans.png" height="112px" style="border-width: 0px;">
            </div>
            <div class="col-sm-12">
                <h3 class="text-left text-center " style="font-size: 14px; font-weight: 400;">Login to your Account</h3>
            </div>
        </div>
        <div class="login-box card">


            <div class="card-body">
                <div class="form-group" style="">
                    <label class="infolbl">User Name</label>
                    <div class="col-xs-12">
                        <asp:TextBox ID="txtUserName" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="">
                    <label class="infolbl">Password</label>
                    <div class="col-xs-12">
                        <asp:TextBox ID="txtPassword" TextMode="Password"  runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row" style="">
                    <div class="col-md-12">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="Century Gothic"
                                    Font-Size="10.5pt" ForeColor="#FF3300"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="d-flex no-block align-items-center">
                            <div class="custom-control custom-checkbox">
                                <asp:CheckBox ID="ChkRemember" runat="server" Text="" CssClass="custom-control-input" />
                                <%--<input type="checkbox" class="custom-control-input" id="customCheck1">--%>
                                <label class="custom-control-label" for="ChkRemember">Remember me</label>
                            </div>
                            <div class="ml-auto">
                                <a style="visibility:hidden" href="javascript:void(0)" id="to-recover" class="text-muted"><i class="fas fa-lock m-r-5"></i>Forgot Password?</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group text-center">
                    <div class="col-xs-12 p-b-0">
                        <asp:Button ID="btnLogin" runat="server" Text="Log In" CssClass="btn btn-block btn-lg btn-info btn-rounded" />
                        
                    </div>
                </div>




            </div>
        </div>
    </div>

</asp:Content>
