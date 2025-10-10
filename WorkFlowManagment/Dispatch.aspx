<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Dispatch.aspx.vb" Inherits="Dispatch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <%--        <link href="../../Styles_Menu/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="../../Styles_Menu/style.css" rel="stylesheet" type="text/css" />
        <script src="../../Styles_Menu/jquery-1.12.0.min.js" type="text/javascript"></script>
        <script src="../../Styles_Menu/bootstrap.min.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .style51 {
            height: 10px;
            text-align: left;
            width: 16%;
        }


        .style158 {
            width: 841px;
        }

        .style182 {
            text-align: left;
        }

        .style183 {
            height: 10px;
        }


        .style184 {
        }


        .style201 {
            width: 74px;
        }

        .style202 {
            width: 52px;
        }




        .style204 {
            text-align: left;
            width: 4px;
        }

        .style205 {
            height: 10px;
            width: 257px;
        }

        .style206 {
            width: 6px;
        }

        .style208 {
            width: 257px;
        }

        .style209 {
            width: 4px;
        }

        .style212 {
            width: 180px;
        }

        .style213 {
            width: 77px;
        }

        .tblcont th, .tblcont td {
            padding-bottom: 5px
        }

        .dxeButtonEditSys {
            height: 33px
        }

        .auto-style1 {
            left: 1px;
            top: 1px;
        }
    </style>






    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js"></script>

    <script src="../../Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Dispatch</h4>
                </div>
                <div class="col-md-7 align-self-center text-right">
                    <div class="d-flex justify-content-end align-items-center">
                        <asp:HiddenField runat="server" ID="HFSalOrdno" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <asp:UpdatePanel ID="UpdatePanel125" runat="server">
                <ContentTemplate>
                    <asp:Label ID="ErrorMSG" runat="server" BackColor="#D3E1F1" BorderColor="Red"
                        BorderStyle="Solid" BorderWidth="1px" ForeColor="Red" Visible="False"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row">
            <div class="card col-12">
                <div class="card-body p-b-0">
                    <div class="testform" name="registration">
                        <div class="card-body" style="padding-left: 0px; padding-right: 0px">
                            <%-- <h5 class="card-title">Customer Master</h5>--%>
                            <div class="form-horizontal">
                                <div class="row">

                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Job Id.	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtjobid" Enabled="false" runat="server" autocomplete="off" CssClass="form-control input-sm "></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Job Date	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtjobcreatedt" Enabled="false" runat="server" autocomplete="off" CssClass="form-control input-sm req"></asp:TextBox>
                                                    <asp:MaskedEditExtender ID="txtjobcreatedt_Date" runat="server" Mask="99/99/9999" MaskType="Date" PromptCharacter="_" TargetControlID="txtjobcreatedt" />
                                                    <asp:CalendarExtender ID="txtjobcreatedt_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtjobcreatedt">
                                                    </asp:CalendarExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>


                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Job Priority	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlprioirty" Enabled="false" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Normal</asp:ListItem>
                                                        <asp:ListItem>Urgent</asp:ListItem>
                                                        <asp:ListItem>Most Urgent</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="ddlprioirty" ErrorMessage="Job Priority"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Job Name	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtjobname" runat="server" autocomplete="off" CssClass="form-control input-sm " MaxLength="60"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Printing	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlprintcd" Enabled="false" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlprintcd" ErrorMessage="Printing"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>
                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Customer	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlcuscode"  runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        <asp:ListItem></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlcuscode" ErrorMessage="Customer"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Internal Code</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtintcode"  runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <!-- form-group -->
                                    </div>

                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Rev No </label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtrevno"  runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>
                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Job Assign To	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlassignedto_dispatch" Enabled="false" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        <asp:ListItem></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlassignedto_dispatch" ErrorMessage="Job Assign To"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>


                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Ticket No</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtticketno" Enabled="false" runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <!-- form-group -->
                                    </div>

                                        <div class="col-md-3 nopadding_left">
                                            <label class="">Company</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlcompcd" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlcompcd" ErrorMessage="Company"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>



                                </div>
                            </div>


                            <div class="form-horizontal">
                                <div class="row">




                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 1</label>
                                            <div class="">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload1" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentpath1" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentname1" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload1" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>


                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload1" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 2</label>
                                            <div class="">



                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload2" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname2" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath2" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload2" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload2" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 3</label>
                                            <div class="">

                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload3" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname3" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath3" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload3" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload3" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 4</label>
                                            <div class="">


                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload4" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname4" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath4" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload4" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload4" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 5</label>
                                            <div class="">


                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload5" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname5" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath5" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload5" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload5" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 6</label>
                                            <div class="">


                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload6" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname6" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath6" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload6" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload6" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 7</label>
                                            <div class="">


                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload7" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname7" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath7" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload7" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload7" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 8</label>
                                            <div class="">

                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload8" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname8" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath8" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload8" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload8" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 9</label>
                                            <div class="">

                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload9" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname9" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath9" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>

                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload9" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload9" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 10</label>
                                            <div class="">


                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload10" Enabled="false" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname10" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath10" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload10" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblFileUpload10" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Link 1</label>
                                            <div class="">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink1" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="link1View" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                    </tr>
                                                </table>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Link 2</label>
                                            <div class="">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel53" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink2" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="link2View" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Link 3</label>
                                            <div class="">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink3" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="link3View" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Link 4</label>
                                            <div class="">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel55" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink4" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="link4View" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Link 5</label>
                                            <div class="">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel56" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink5" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="link5View" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>





                                    <div class="col-md-12 nopadding_left">
                                        <div class="">
                                            <label class="">Customer Instruction</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtcustomerinstruction" Enabled="false" TextMode="MultiLine" Rows="4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>





                                <div class="form-horizontal">
                                    <div class="row">
                                        

                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Plate Type 	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlplatetypecd"  runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlplatetypecd" ErrorMessage="Plate Type"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                       <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Printer 	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlprintercd" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req"  >
                                                            <asp:ListItem></asp:ListItem>

                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlprintercd" ErrorMessage="Printer"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">No Of Plate 	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtnoofplates" runat="server" CssClass="form-control input-sm req" MaxLength="60"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtnoofplates" ErrorMessage="No Of Plate"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>


                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Operator 	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlopcode" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlopcode" ErrorMessage="Operator"></asp:RequiredFieldValidator>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>



                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Length Of Plate in cms	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtlength_plate_cms" runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Width Of Plate in cms	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtwidth_plate_cms" runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Challan No	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtchlno"  runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Challan Date	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtchldt"  runat="server" autocomplete="off" CssClass="form-control input-sm req"></asp:TextBox>
                                                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" PromptCharacter="_" TargetControlID="txtchldt" />
                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtchldt">
                                                        </asp:CalendarExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                     

                                        <%--<div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Bill No	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtbillno" Enabled="false" runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Bill Date	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtBilldate" Enabled="false" runat="server" autocomplete="off" CssClass="form-control input-sm "></asp:TextBox>
                                                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" PromptCharacter="_" TargetControlID="txtBilldate" />
                                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtBilldate">
                                                        </asp:CalendarExtender>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>--%>


                                        <div class="col-md-3 nopadding_left  m-b-15">
                                            <label class="">Courier</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddltranscd" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddltranscd" ErrorMessage="Courier"></asp:RequiredFieldValidator>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">Docket No	</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtdocketno" runat="server" CssClass="form-control input-sm req" MaxLength="60"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtdocketno" ErrorMessage="Docket No"></asp:RequiredFieldValidator>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Plate Processed Date	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtplate_processed_date" runat="server" autocomplete="off" CssClass="form-control input-sm req"></asp:TextBox>
                                                    <asp:MaskedEditExtender ID="txtplate_processed_date_MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" PromptCharacter="_" TargetControlID="txtplate_processed_date" />
                                                    <asp:CalendarExtender ID="txtplate_processed_date_CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtplate_processed_date">
                                                    </asp:CalendarExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>


                                        <div class="col-md-12 nopadding_left">
                                            <div class="">
                                                <label class="">Any Other Comments</label>
                                                <div class="">
                                                    <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtdispatch_comments" TextMode="MultiLine" Rows="4" runat="server" CssClass="form-control input-sm req"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>


                            </div>




                            <div class="m-t-10" style="margin-bottom: 10px">
                                <div style="float: left; padding-bottom: 10px;">
                                </div>
                                <div style="float: right; padding-bottom: 10px;">
                                    <table>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-info m-r-10" OnClick ="btnUpdate_Click" 
                                                                Text="Update" />
                                                        </td>                                           
                                                        <td>
                                                            <asp:Button ID="btnSendForBilling" runat="server" CssClass="btn btn-info m-r-10"
                                                                Text="Send To Billing" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnclose" runat="server" CssClass="btn btn-light" ValidationGroup="sv"
                                                                Text="Close" />
                                                        </td>
                                                    </tr>
                                                </table>





                                            </td>
                                        </tr>
                                    </table>


                                    <%--    <b href="#" class="btn btn-inverse waves-effect waves-light">Cancel</b>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
                <td align="right" class="style183">
                    <asp:Label ID="lbl2" runat="server"></asp:Label>
                </td>

    <asp:HiddenField ID="HFgststatecd" runat="server" />
    <asp:HiddenField ID="HFsave_value" runat="server" />
    <asp:HiddenField ID="HFdocdt" runat="server" />



</asp:Content>

