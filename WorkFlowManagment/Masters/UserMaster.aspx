<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="UserMaster.aspx.vb" Inherits="UserMaster" %>

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
            left: 0px;
            top: 0px;
        }
    </style>

        <script type="text/javascript" language="javascript">
            function CancelClick() {
                document.getElementById("<%=lbl2.ClientID %>").innerHTML = "";
            }
            function performCheck() {
                if (Page_ClientValidate()) {
                }

            }

            function Confirm() {
                performCheck();
                var pageValidated = Page_IsValid;
                if (pageValidated) {
                    var confirm_value = document.createElement("INPUT");
                    confirm_value.type = "hidden";
                    confirm_value.name = "confirm_value";
                    if (confirm("Do you want to save ?")) {
                        confirm_value.value = "Yes";
                    } else {
                        confirm_value.value = "No";
                    }
                    document.forms[0].appendChild(confirm_value);
                }
            }
        </script>






    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js"></script>

    <script src="../../Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>

   <script type="text/javascript">


       function validateEmail(Field) {
           if (Field.value !== "") {
               var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

               if (reg.test(Field.value) == false) {
                   alert('Invalid Email Address');
                   Field.value = "";
                   return false;
               }
           }
           return true;

       }

       function validateNumber(e) {

           const pattern = /^[0-9]$/;

           return pattern.test(e.key)
       }

       function validateMob(field) {

           if (field.value !== "") {
               if (field.value.length > 10) {
                   alert('Enter valid Mobile No');
                   field.value = "";

                   return false;
               }

               if (field.value.length < 10) {
                   alert('Enter valid Mobile No');
                   field.value = "";

                   return false;
               }
           }

           return true;

       }
   </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">User Master</h4>
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

                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">First Name</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtu_name" runat="server" AutoPostBack="true" CssClass="form-control input-sm req"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtu_name" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Last Name</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtlastname" runat="server" AutoPostBack="true" CssClass="form-control input-sm req"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtlastname" ErrorMessage="Enter Last Name"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="col-md-1 nopadding_left">
                                        <label class="">Active</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="chkactive" runat="server"></asp:CheckBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-2 nopadding_left">
                                        <label class="">Allow Send To Billing</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="chkallowbilling" runat="server"></asp:CheckBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Allow Billing Done & Job Close</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="chkallowbilldone_close" runat="server"></asp:CheckBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="col-md-3 nopadding_left  m-b-15">
                                        <label class="">Designation</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddldesigcd" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddldesigcd" ErrorMessage="Select Designation"></asp:RequiredFieldValidator>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Administrator </label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="chkadministrator" runat="server"></asp:CheckBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>

                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Reporting To</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlReportingTo" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlReportingTo" ErrorMessage="Select Reporting To"></asp:RequiredFieldValidator>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                        <label class="">User Id</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtu_id" runat="server" CssClass="form-control input-sm req" AutoPostBack="true" MaxLength="60" ReadOnly="True" Style="text-transform: lowercase"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtu_id" ErrorMessage="User Id"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Password</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtpass" runat="server" autocomplete="off" CssClass="form-control input-sm " ReadOnly ="true" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpass" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>

                                    <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Mobile	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtmobileno" runat="server" autocomplete="off" onfocusout="validateMob(this);" onkeypress="return validateNumber(event)" CssClass="form-control input-sm req" MaxLength="10"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="txtMobileNo_FilteredTextBoxExtende" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtmobileno" ValidChars="+-">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmobileno" ErrorMessage="Enter Mobile"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Email ID	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtemailid" runat="server" autocomplete="off" onfocusout="validateEmail(this);" CssClass="form-control input-sm req"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtemailid" ErrorMessage="Enter Email ID"></asp:RequiredFieldValidator>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>
                                    <div class="col-md-3 nopadding_left m-b-15">
<%--                                        <label class="">Last Password Chage Dt	</label>--%>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtlastpasschangedt" runat="server" autocomplete="off" CssClass="form-control input-sm req" ReadOnly ="true" visible="false" ></asp:TextBox>
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" PromptCharacter="_" TargetControlID="txtlastpasschangedt" />
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtlastpasschangedt">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtlastpasschangedt" ErrorMessage="Enter Last Password Chage Dt"></asp:RequiredFieldValidator>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="col-md-3 nopadding_lef">
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                    </div>



                                    <div class="col-md-3 nopadding_left m-b-15">
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <asp:UpdatePanel ID="UpdatePanel1300" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Paneluserdtls" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="Headingseparator"></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <%--<tr>
                                                    <td>
                                                        <table border="1">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Label ID="Label720" runat="server" CssClass="LableInterface" Font-Bold="True" Text="Created By" Width="150px"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="Label721" runat="server" CssClass="LableInterface" Font-Bold="True" Text="Created Date" Width="150px"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="Label722" runat="server" CssClass="LableInterface" Font-Bold="True" Text="Modified By" Width="150px"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="Label723" runat="server" CssClass="LableInterface" Font-Bold="True" Text="Modified Date" Width="150px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 4px">
                                                                    <asp:Label ID="lblcrtuserid" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                                </td>
                                                                <td align="center" style="padding: 4px">
                                                                    <asp:Label ID="lblcrtuserdt" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                                </td>
                                                                <td align="center" style="padding: 4px">
                                                                    <asp:Label ID="lblmoduserid" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                                </td>
                                                                <td align="center" style="padding: 4px">
                                                                    <asp:Label ID="lblmoduserdt" runat="server" CssClass="LableInterface" Font-Bold="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="m-t-10" style="margin-bottom: 10px">
                                <div style="float: left; padding-bottom: 10px;">
                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-info m-r-10"
                                        Text="Delete" />
                                </div>
                                <div style="float: right; padding-bottom: 10px;">
                                    <table>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <table>
                                                    <tr>

                                                        <td>
                                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info m-r-10" OnClientClick="Confirm()"
                                                                Text="Save" />

                                                        </td>

                                                        <td>
                                                            <asp:Button ID="btnClose" runat="server" CssClass="btn btn-light" ValidationGroup="sv"
                                                                Text="Close" />

                                                        </td>

                                                        <td>&nbsp;</td>

                                                        <td>&nbsp;</td>
                                                        <td></td>
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
    <td align="right" class="style183">
        <asp:Label ID="lbl2" runat="server"></asp:Label>
    </td>

    <asp:HiddenField ID="HFu_id" runat="server" />
    <asp:HiddenField ID="HFsave_value" runat="server" />
    <asp:HiddenField ID="HFdocdt" runat="server" />



</asp:Content>

