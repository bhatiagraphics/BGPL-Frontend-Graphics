<%@ Page Title="ERP" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="OpenJob.aspx.vb" Inherits="OpenJob" %>

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
                    <h4 class="text-themecolor">Open Job</h4>
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
                                                    <asp:TextBox ID="txtinvoiceno" Enabled="false" runat="server" autocomplete="off" CssClass="form-control input-sm "></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 nopadding_left">
                                        <label class="">Job Date	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtinvoicedt" runat="server" autocomplete="off" CssClass="form-control input-sm req"></asp:TextBox>
                                                    <asp:MaskedEditExtender ID="txtpodate_Date" runat="server" Mask="99/99/9999" MaskType="Date" PromptCharacter="_" TargetControlID="txtinvoicedt" />
                                                    <asp:CalendarExtender ID="txtinvoicedt_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtinvoicedt">
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
                                                    <asp:DropDownList ID="ddlcuscode" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Normal</asp:ListItem>
                                                        <asp:ListItem>Urgent</asp:ListItem>
                                                        <asp:ListItem>Most Urgent</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="ddlcuscode" ErrorMessage="Customer"></asp:RequiredFieldValidator>
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
                                                    <asp:TextBox ID="txtgstno" runat="server" autocomplete="off" CssClass="form-control input-sm " MaxLength="60" ></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                   <div class="col-md-3 nopadding_left m-b-15">
                                        <label class="">Printing	</label>
                                        <div class="">
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DropDownList1" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Letterpress</asp:ListItem>
                                                        <asp:ListItem>Flexo</asp:ListItem>
                                                        <asp:ListItem>Dry Offset</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlcuscode" ErrorMessage="Customer"></asp:RequiredFieldValidator>
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
                                                    <asp:DropDownList ID="DropDownList2" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
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
                                                        <asp:TextBox ID="txtInternal"  runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtCustStreet" runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>

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
                                                    <asp:DropDownList ID="DropDownList3" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl req">
                                                        <asp:ListItem></asp:ListItem>
                                                     
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlcuscode" ErrorMessage="Customer"></asp:RequiredFieldValidator>
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
                                                        <asp:TextBox ID="txtCustLandMark" runat="server" CssClass="form-control input-sm" MaxLength="60"></asp:TextBox>
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

                                    <div class="col-md-12 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 1</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                    <ContentTemplate>
                                                        <asp:FileUpload ID="txtDelivTerms" runat="server"></asp:FileUpload>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>


                                     <div class="col-md-12 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 2</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" ></asp:FileUpload>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                     <div class="col-md-12 nopadding_left m-b-15">
                                        <div class="">
                                            <label class="">Attachment 3</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:FileUpload ID="FileUpload2" runat="server" ></asp:FileUpload>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 nopadding_left">
                                        <div class="">
                                            <label class="">Customer Instruction</label>
                                            <div class="">
                                                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtRemarks" TextMode="MultiLine" Rows="4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                
                            </div>



                            <div class="m-t-10" style="margin-bottom: 10px">
                                <div style="float: left; padding-bottom: 10px;">
                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-info  m-r-10"
                                        Text="Cancel"
                                        ValidationGroup="SV" />
                                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server"
                                        ConfirmText="Are you sure you want to Delete ?" OnClientCancel="CancelClick"
                                        TargetControlID="btnDelete">
                                    </asp:ConfirmButtonExtender>

                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-info  m-r-10"
                                        Text="Send To Grpahics"
                                        ValidationGroup="SV" />
                                  

                                </div>
                                <div style="float: right; padding-bottom: 10px;">
                                    <table>
                                        <tr>
                                            <td>
                                               
                                            </td>
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

