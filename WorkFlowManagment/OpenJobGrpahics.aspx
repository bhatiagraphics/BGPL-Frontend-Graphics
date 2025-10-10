<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="OpenJobGrpahics.aspx.vb" Inherits="OpenJobGrpahics" %>

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


    <script type="text/javascript">
        function UploadFile1(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload1.ClientID %>").click();
            }
        }
        function UploadFile2(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload2.ClientID %>").click();
            }
        }
        function UploadFile3(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload3.ClientID %>").click();
            }
        }
        function UploadFile4(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload4.ClientID %>").click();
            }
        }
        function UploadFile5(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload5.ClientID %>").click();
            }
        }
        function UploadFile6(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload6.ClientID %>").click();
            }
        }
        function UploadFile7(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload7.ClientID %>").click();
            }
        }
        function UploadFile8(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload8.ClientID %>").click();
            }
        }
        function UploadFile9(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload9.ClientID %>").click();
            }
        }
        function UploadFile10(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload10.ClientID %>").click();
            }
        }
    </script>



    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js"></script>

    <script src="../../Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Approval Form(Graphic)</h4>
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
                                                    <asp:DropDownList ID="ddlprioirty" runat="server" Theme="Metropolis" Style="width: 100%" CssClass="form-control searchableddl req">
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
                                                    <asp:DropDownList ID="ddlprintcd" AutoPostBack="true" OnSelectedIndexChanged="ddlprintcd_SelectedIndexChanged" runat="server" Theme="Metropolis" Style="width: 100%" CssClass="form-control searchableddl req">
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
                                                    <asp:DropDownList ID="ddlcuscode" runat="server" Theme="Metropolis" Style="width: 100%" CssClass="form-control searchableddl req">
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
                                                    <asp:DropDownList ID="ddlassignedto_appformgraphic" runat="server" Theme="Metropolis" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        <asp:ListItem></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlassignedto_appformgraphic" ErrorMessage="Job Assign To"></asp:RequiredFieldValidator>
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
                                                            <asp:Button ID="btnUpload1" runat="server" OnClick="UploadImage1"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />
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
                                                                    <asp:FileUpload ID="FileUpload2" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname2" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath2" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload2" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                            <asp:Button ID="btnUpload2" runat="server" OnClick="UploadImage2"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />

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
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload3" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname3" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath3" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload3" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                            <asp:Button ID="btnUpload3" runat="server" OnClick="UploadImage3"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />
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
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload4" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname4" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath4" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload4" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                            <asp:Button ID="btnUpload4" runat="server" OnClick="UploadImage4"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload5" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname5" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath5" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload5" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                            <asp:Button ID="btnUpload5" runat="server" OnClick="UploadImage5"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />
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
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload6" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname6" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath6" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload6" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                            <asp:Button ID="btnUpload6" runat="server" OnClick="UploadImage6"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />
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
                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload7" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname7" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath7" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload7" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                            <asp:Button ID="btnUpload7" runat="server" OnClick="UploadImage7"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />
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
                                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload8" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname8" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath8" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload8" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                            <asp:Button ID="btnUpload8" runat="server" OnClick="UploadImage8"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />
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
                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload9" runat="server"></asp:FileUpload>
                                                                    <asp:HiddenField ID="Hfattachmentname9" runat="server" />
                                                                    <asp:HiddenField ID="Hfattachmentpath9" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>

                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnViewFileUpload9" runat="server" ImageUrl="~/images/View_Doc_Icon.png" ValidationGroup="sv" />
                                                            <asp:Button ID="btnUpload9" runat="server" OnClick="UploadImage9"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />
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
                                                            <asp:Button ID="btnUpload10" runat="server" OnClick="UploadImage10"
                                                                Style="display: none" Text="Upload" ValidationGroup="SV" />
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
                                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
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
                                                            <asp:UpdatePanel ID="UpdatePanel45" runat="server">
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
                                </div>


                                <div class="form-horizontal">
                                    <div class="row">
                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">
                                                <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblcantube" runat="server" Text="Can/Tube/Seamless Tube"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel4s" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlcan_tube" runat="server" Theme="Metropolis" Style="width: 100%" CssClass="form-control searchableddl ">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem>Can</asp:ListItem>
                                                            <asp:ListItem>Tube</asp:ListItem>
                                                            <asp:ListItem>Seamless Tube</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                         <div class="col-md-3 nopadding_left m-b-15">
                                             </div>
                                         <div class="col-md-3 nopadding_left m-b-15">
                                             </div>
                                         <div class="col-md-3 nopadding_left m-b-15">
                                             </div>
                                        <div class="col-md-3 nopadding_left m-b-15">
                                            <label class="">
                                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lbllabellami" runat="server" Text="Label/Lami"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddllabellami" AutoPostBack="true" OnSelectedIndexChanged="ddllabellami_SelectedIndexChanged" runat="server" Theme="Metropolis" Style="width: 100%" CssClass="form-control searchableddl">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem>Label</asp:ListItem>
                                                            <asp:ListItem>Lami</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                         <div class="col-md-3 nopadding_left m-b-15">
                                             </div>
                                         <div class="col-md-3 nopadding_left m-b-15">
                                             </div>
                                         <div class="col-md-3 nopadding_left m-b-15">
                                             </div>

                                        <div class="col-md-3 nopadding_left">
                                            <label class="">
                                                <asp:UpdatePanel ID="UpdatePanel53" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblDiameter" runat="server" Text="Diameter"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtdiameter" runat="server" CssClass="form-control input-sm " MaxLength="60"></asp:TextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div class="col-md-3 nopadding_left">
                                            <label class="">
                                                <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblTubeHeight" runat="server" Text="Tube/Can Length/Height"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtcan_tube_height" runat="server" CssClass="form-control input-sm " MaxLength="60"></asp:TextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                         <div class="col-md-3 nopadding_left m-b-15">
                                             </div>
                                         <div class="col-md-3 nopadding_left m-b-15">
                                             </div>

                                        <div class="col-md-3 nopadding_left">
                                            <label class="">
                                                <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblleballength" runat="server" Text="Label Length"></asp:Label>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtlabellength" runat="server" CssClass="form-control input-sm " MaxLength="60"></asp:TextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div class="col-md-3 nopadding_left">
                                            <label class="">
                                                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lbllebalwidth" runat="server" Text="Label Width"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtlabelwidth" runat="server" CssClass="form-control input-sm " MaxLength="60"></asp:TextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                         <div class="col-md-3 nopadding_left m-b-15">
                                             </div>
                                         <div class="col-md-3 nopadding_left m-b-15">
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
                                                            <asp:Button ID="btnAmendment" runat="server" CssClass="btn btn-info  m-r-10"
                                                                Text="Amendment Req"
                                                                ValidationGroup="SV" />
                                                        </td>

                                                        <td>

                                                            <asp:Button ID="btnSendToCustomer" runat="server" CssClass="btn btn-info  m-r-10"
                                                                Text="Send To Customer" />



                                                        </td>

                                                        <td>
                                                            <asp:Button ID="btnHold" runat="server" CssClass="btn btn-info m-r-10"  ValidationGroup="SV"
                                                                Text="Hold" />

                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info m-r-10"
                                                                Text="Update" />

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

