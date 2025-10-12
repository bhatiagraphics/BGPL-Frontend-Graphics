<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="JobEntry.aspx.vb" Inherits="JobEntry" EnableEventValidation="false" %>

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
                    <h4 class="text-themecolor">Job Entry Form</h4>
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
                                                    <asp:HiddenField ID="hdnJobId" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Job Date	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtjobcreatedt" runat="server" autocomplete="off" CssClass="form-control input-sm req"></asp:TextBox>
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
                                                    <asp:DropDownList ID="ddlprioirty" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
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
                                                    <asp:TextBox ID="txtjobname" runat="server" autocomplete="off" CssClass="form-control input-sm req" MaxLength="60"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtjobname" ErrorMessage="Job Name"></asp:RequiredFieldValidator>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Printing	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlprintcd" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlprintcd" ErrorMessage="Printing"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                   <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Recall	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlRecallJobId" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl ">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                          <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                <ContentTemplate>
                                          <asp:Button ID="btnRecall" runat="server" CssClass="btn btn-info  m-t-20"
                                            Text="Recall"
                                            ValidationGroup="SV" />
                                                     </ContentTemplate>
                                            </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Customer	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlcuscode" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
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
                                                        <asp:TextBox ID="txtintcode" runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtrevno" runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>

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
                                                    <asp:DropDownList ID="ddlassignedto" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        <asp:ListItem></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlassignedto" ErrorMessage="Job Assign To"></asp:RequiredFieldValidator>
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
                                                        <asp:TextBox ID="txtticketno" runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <!-- form-group -->
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
                                                                    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentpath1" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentname1" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload1" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel1315" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload1" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>


                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload2" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname2" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath2" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload2" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload2" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload3" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname3" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath3" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload3" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload3" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload4" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname4" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath4" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload4" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload4" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload5" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname5" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath5" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload5" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload5" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload6" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname6" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath6" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload6" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload6" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload7" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname7" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath7" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload7" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload7" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload8" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname8" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath8" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload8" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload8" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload9" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname9" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath9" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>

                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload9" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload9" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel43" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload10" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname10" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath10" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload10" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel210" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:ImageButton ID="btnDeleteFileUpload10" runat="server" ImageUrl="~/images/Delete_Icon.png" ValidationGroup="sv" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <asp:UpdatePanel ID="UpdatePanel44" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink1" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink3" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                                            <asp:UpdatePanel ID="UpdatePanel55" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtLink5" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                                        <asp:TextBox ID="txtcustomerinstruction" TextMode="MultiLine" Rows="4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 nopadding_left">
                                        <div class="">
                                            <label class="">Cancel Remark</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtcancelremark" TextMode="MultiLine" Rows="4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>



                            </div>
                            <h5 class="card-title  m-t-25">
                                <asp:Label ID="lblLog" runat="server"> Log </asp:Label>
                            </h5>

                            <div class="form-horizontal">
                                <div class="row">

                                    <div class="col-sm-12" style="overflow-x: scroll;overflow-y: scroll">

                                        <asp:UpdatePanel ID="UpdatePanel87" runat="server">
                                            <ContentTemplate>

                                                <asp:GridView ID="gv1" runat="server" GridLines="None" 
                                                    AutoGenerateColumns="False" CssClass="table table-striped"
                                                    DataKeyNames="ssrno" ShowHeaderWhenEmpty="true"
                                                    OnRowDataBound="OnRowDataBound_GV1" Width="2000px"
                                                    AllowPaging="True" OnPageIndexChanging="gv1_PageIndexChanging" PageSize="10" >
                                                    <Columns>
                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Edit-icon.png"
                                                            ShowSelectButton="True">
                                                            <ItemStyle Width="1%" Wrap="True" />
                                                        </asp:CommandField>
                                                        <asp:BoundField DataField="logsrno" HeaderText="Sr.No.">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="logdate" HeaderText="Log Date">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="jobid" HeaderText="Job ID">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="cusname" HeaderText="Customer">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="intcode" HeaderText="INT Code">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="revno" HeaderText="Rev">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="prioirty" HeaderText="Priority">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="printname" HeaderText="Printing Type">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="jobcreatedt" HeaderText="Date & Time">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="assignedname" HeaderText="Assign To">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="status" HeaderText="Status">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>

                                                    </Columns>

                                                </asp:GridView>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>



                                <div class="m-t-10" style="margin-bottom: 10px">
                                    <div style="float: left; padding-bottom: 10px;">
                                        <asp:Button ID="btncancel" runat="server" CssClass="btn btn-info  m-r-10"
                                            Text="Cancel Job Entry"
                                            ValidationGroup="SV" />
                                        <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server"
                                            ConfirmText="Are you sure you want to Cancel Job ?"
                                            TargetControlID="btncancel">
                                        </asp:ConfirmButtonExtender>

                                        <asp:Button ID="btnSendToGrphics" runat="server" CssClass="btn btn-info  m-r-10"
                                            Text="Send To Graphics "
                                            ValidationGroup="SV" />

                                        <asp:Button ID="btnsendtopress" runat="server" CssClass="btn btn-info  m-r-10"
                                            Text="Send To Prepress "
                                            ValidationGroup="SV" />

                                           <asp:Button ID="btnRevoke" runat="server" CssClass="btn btn-info  m-r-10"
                                            Text="Revoke  "
                                            ValidationGroup="SV" />


                                    </div>
                                    <div style="float: right; padding-bottom: 10px;">
                                        <table>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                        <asp:Button ID="btnsave_SendtoGraphics" runat="server" CssClass="btn btn-info  m-r-10"
                                            Text="Save & Send To Graphics "
                                             />
                                                                </td>
                                                            <td>
                                        <asp:Button ID="btnsave_SendtoPrepress" runat="server" CssClass="btn btn-info  m-r-10"
                                            Text="Save & Send To Prepress "
                                            />
                                                                </td>
                                                            <td>
                                                                <asp:Button ID="btnAmendment" runat="server" CssClass="btn btn-info  m-r-10"
                                                                    Text="Amendment Req"
                                                                    ValidationGroup="SV" />
                                                            </td>

                                                            <td>
                                                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info m-r-10"
                                                                    Text="Save" />

                                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                                                    ConfirmText="Do You want to save Job ?"
                                                                    TargetControlID="btnSave">
                                                                </asp:ConfirmButtonExtender>

                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnClose" runat="server" CssClass="btn btn-light" ValidationGroup="sv"
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

