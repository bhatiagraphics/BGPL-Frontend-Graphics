<%@ Page Title="ERP" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="UserRightsAsPerTemplate.aspx.vb" Inherits="UserRightsAsPerTemplate" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
       <%-- <link href="../Styles_Menu/bootstrap.min.css" rel="stylesheet" 
            type="text/css" />
        <link href="../Styles_Menu/style.css" rel="stylesheet" type="text/css" />
        <script src="../Styles_Menu/jquery-1.12.0.min.js" type="text/javascript"></script>
        <script src="../Styles_Menu/bootstrap.min.js" type="text/javascript"></script>--%>

    <style type="text/css">



        .style51
        {
            height: 10px;
            text-align: left;
            width: 16%;
        }
        
        .style40
        {
          height: 10px;
            text-align: left;
        }
                       
                 
         .style158
    {
        width: 841px;
    }
        .style181
        {
            height: 10px;
            width: 29%;
        }
        .style182
        {
            text-align: left;
            }
        .style183
        {
            height: 10px;
            width: 12%;
        }
                                       
                 
         .style184
        {
            width: 6px;
        }
                               
                 
         .style202
        {
            width: 52px;
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
                       confirm_value.value = "";
                       confirm_value.value = "Yes";
                       var myHidden = document.getElementById('<%= HFsave_value.ClientID %>').value;
                       if (myHidden == "") {
                           document.getElementById("<%=HFsave_value.ClientID %>").value = "click";
                       }
                       else {
                           document.getElementById("<%=HFsave_value.ClientID %>").value = "click1";
                       }

                   } else {
                       confirm_value.value = "";
                       confirm_value.value = "No";
                   }
                   document.forms[0].appendChild(confirm_value);
                   document.forms[0].target = "";
               }
           }
            </script>  
 
<%--       <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>--%>
       <script type="text/javascript">
           $(function () {
               $(document).keydown(function (event) {
                   var f2Key = 27;
                   if (event.which == f2Key) {
                       // alert('you pressed F1');
                       //$("#<%=btnClose.ClientID %>").click()
                   }
               });
               document.onkeydown = function (event) {
                   if (event.ctrlKey && event.keyCode == 83) {
                       event.preventDefault();
                       $("#<%=btnSave.ClientID %>").click()
                       return false;
                   }
               };
           });
          
    </script>
        <script type="text/javascript" language="javascript">
            function SetTarget() {
                document.forms[0].target = "_blank";
            }
       </script>  
        <script type="text/javascript" language="javascript">
            function SetTargetOff() {
                document.forms[0].target = "";
            }
       </script> 

  
<%--  <script src="../Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>--%>
  <script type="text/javascript">
      function LoadScript() {
          //GrossTotal();

          $(document).ready(function () {
              $("[id*=GridView1]input[type=text][id*=txtqty]").keyup(function (e) {
                  GrossTotal();
              });
          });

          var gross;
          function GrossTotal() {
              gross = 0;
              $("[id*=GridView1][id*=txtqty]").each(function (index, item) {
                  if (($(this).closest('tr').find("input[type=text][id*=txtqty]").val() != '')) {
                      //gross = gross + parseInt($(this).closest('tr').find("input[type=text][id*=txtqty]").val());
                      gross = gross + parseFloat($(this).closest('tr').find("input[type=text][id*=txtqty]").val() || 0);
                  }
              });
              $("[id*=txtscoreTot]").val(gross);
          }
      }
  </script>         
                        
                                                  
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="container-fluid "  >
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">
                        <asp:Label ID="Label2" runat="server" Text="User Acces Rights"></asp:Label></h4>

                   
                </div>
                <div class="col-md-7 align-self-center text-right">
                    <div class="d-flex justify-content-end align-items-center">
                    </div>
                </div>
            </div>
        </div>
   <div class="">
            <div class="card col-12">
    <div align="center" 
        style="height: 100%; width: 100%; padding-left: 5px; padding-right: 5px;">
        <asp:Panel ID="Panel2" runat="server" Height="100%" 
            Width="100%" BackColor="White">
        <table bgcolor="White" width="100%">
           
            <tr>
                <td align="center" colspan="5">
                        <asp:UpdatePanel ID="UpdatePanel125" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="ErrorMSG" runat="server" BackColor="#D3E1F1" BorderColor="Red" 
                                    BorderStyle="Solid" BorderWidth="1px" ForeColor="Red" Visible="False"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="5" 
                    style="padding-top: 5px; padding-right: 3px; padding-left: 3px">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                        CssClass="ValidationSummaryInterface" DisplayMode="SingleParagraph" 
                        EnableClientScript="true" Font-Bold="False" ForeColor="" 
                        HeaderText="Please Select User" ValidationGroup="Save" Width="100%" />
                </td>
            </tr>
            <tr>
                <td align="left" class="style158" colspan="5">
                    <table style="width: 32px">
                        <tr>
                            <td align="left" class="style182">
                                <asp:Label ID="Label456" runat="server" CssClass="LableInterface" 
                                    Font-Bold="False" Text="Select Template" Width="140px"></asp:Label>
                            </td>
                            <td align="left" class="style183">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                <asp:Label ID="Label685" runat="server" CssClass="LableInterface" 
                                    Font-Bold="False" Text="Select User" Width="140px"></asp:Label>
                            </td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                            <td align="left" class="style182">
                                <asp:Label ID="Label686" runat="server" CssClass="LableInterface" 
                                    Font-Bold="False" Text="Select Department" Width="140px"></asp:Label>
                            </td>
                            <td align="left" class="style182">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                <asp:Label ID="Label687" runat="server" CssClass="LableInterface" 
                                    Font-Bold="False" Text="Select Module Type" Width="140px"></asp:Label>
                            </td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" class="style182">
                                <asp:UpdatePanel ID="UpdatePanel132" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTemplate" runat="server" 
                                            CssClass="form-control searchableddl" Width="225px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="style183">
                                <asp:RequiredFieldValidator ID="txtcustcd_RequiredFieldValidator" 
                                    runat="server" ControlToValidate="ddlTemplate" 
                                    ErrorMessage="Select Template," Visible="False" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left" class="style184">
                                <asp:UpdatePanel ID="UpdatePanel1226" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlUID" runat="server" 
                                            CssClass="form-control searchableddl" Width="225px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="style184">
                                <asp:RequiredFieldValidator ID="txtcustcd_RequiredFieldValidator0" 
                                    runat="server" ControlToValidate="ddlUID" 
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left" class="style182">
                                <asp:UpdatePanel ID="UpdatePanel_txtPEnqNo" runat="server">
                                    <ContentTemplate>
                                        <%--<asp:TextBoxWatermarkExtender ID="txtPEnqNo_TextBoxWatermarkExtender0" 
                                            runat="server" Enabled="True" TargetControlID="txtMRNo" 
                                            WatermarkCssClass="watermark" WatermarkText="Type to Search">
                                        </asp:TextBoxWatermarkExtender>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel1227" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDepartment" runat="server" 
                                            CssClass="form-control searchableddl" Width="225px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="style182">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                <asp:UpdatePanel ID="UpdatePanel1228" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlModuleType" runat="server" 
                                            CssClass="form-control searchableddl" Width="225px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                <asp:UpdatePanel ID="UpdatePanel86" runat="server">
                                    <ContentTemplate>
                                        <%--<asp:Button ID="btnSubmit" runat="server" BorderColor="Silver" 
                                                        BorderStyle="Solid" BorderWidth="2px" CssClass="ButtonInterface_Search_AddNew" 
                                                        Height="31px" Text="Submit" Width="75px" />--%>
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" 
                                            Font-Bold="False" Height="31px" Text="Submit" ValidationGroup="Submit" 
                                            Width="85px" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="style184">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                    AssociatedUpdatePanelID="UpdatePanel86">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgprogress2" runat="server" Height="24px" 
                                            ImageUrl="~/images/Processing.gif" Width="24px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                            <td align="left" class="style184">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <%--<td align="left" class="SectionHeading" colspan="5" 
                    style="vertical-align: bottom">
                    <table class="style201">
                        <tr>
                            <td class="style202" height="25" 
                                style="background-image: url('../../images/Headinf of Details.jpg'); background-repeat: no-repeat; background-attachment: inherit; padding-left: 15px;">
                                <asp:Label ID="Label346" runat="server" Font-Bold="False" 
                                    Font-Names="Century Gothic" Font-Size="11pt" ForeColor="White" 
                                    Text="PRODUCT DETAILS" Width="320px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>--%>
               <td align="left" style="vertical-align: bottom" colspan="5">
                                                <div align="left" style="width: 100%">
                                                    <asp:Panel ID="pnlClick2" runat="server" CssClass="pnlCSS" Width="100%">
                                                        <div class="SectionHeading" style="height: 35px; vertical-align: middle; width: 100%;">
                                                            <div style="float: left; color: #333333; padding: 3px 5px 0px 5px; font-family: calibri; font-size: 14px; font-weight: normal; width:100%;">
                                                                <table width="100%">
                                                                <tr>
                                                                     <td class="style202" height="25" 
                                                                         style="padding-left: 15px; padding-top: 4px; padding-bottom: 4px;">
                                                                         <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                                                                             Text="Department and Modules" Width="250px" 
                                                                             CssClass="EntryFormSectionsHeading"></asp:Label>
                                                                     </td>
                                                                    <td height="25" style="padding-right: 20px;" align="left">
                                                                         
                                                                        &nbsp;</td>
                                                                     <td align="right" height="25" style="padding-right: 20px;">
                                                                         <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                                                             AssociatedUpdatePanelID="UpdatePanel14">
                                                                             <ProgressTemplate>
                                                                                 <asp:Image ID="imgprogress1" runat="server" Height="24px" 
                                                                                     ImageUrl="~/images/Processing.gif" Width="24px" />
                                                                             </ProgressTemplate>
                                                                         </asp:UpdateProgress>
                                                                     </td>
                                                                </tr>
                                                            </table>
                                                            </div>
                                                           
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlCollapsable2" runat="server" CssClass="pnlCSS" Width="100%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td align="left" width="100%">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" width="100%">
                                                                                <asp:UpdatePanel ID="UpdatePanel1229" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Panel ID="PanelNoRecordFound" runat="server" Visible="False">
                                                                                            <table style="width:100%;">
                                                                                                <tr>
                                                                                                    <td align="center" style="padding-right: 10px; padding-left: 10px">
                                                                                                        <asp:Label ID="Label688" runat="server" CssClass="ValidationSummaryInterface" 
                                                                                                            Font-Bold="False" Text="Please Select Template" Width="100%"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" width="100%">
                                                                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:Panel ID="PanelRecordFound" runat="server" Height="500px" Width="100%" ScrollBars="Vertical">
                                                                                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                                                                CssClass="table table-striped table-bordered responsive" DataKeyNames="srno" 
                                                                                                OnRowCommand="GridView1_RowCommand" OnRowCreated="gvHover_RowCreated" 
                                                                                                OnRowDataBound="GridView1_RowDataBound" PageSize="100" Width="100%">
                                                                                                <PagerSettings FirstPageText="First    ." LastPageText="Last    " 
                                                                                                    Mode="NextPreviousFirstLast" NextPageText="Next    ." 
                                                                                                    PreviousPageText="Previous    ." />
                                                                                                <EditRowStyle Wrap="False" />
                                                                                                <EmptyDataRowStyle Wrap="False" />
                                                                                                <FooterStyle BorderStyle="None" Height="27px" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Sr No.">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtsrno" runat="server" autocomplete="off" 
                                                                                                                CssClass="TextBoxGrideReadOnly" Enabled="False" ReadOnly="False" 
                                                                                                                Style="margin-top: 0px; margin-left: 1px; text-align: center;" 
                                                                                                                Text='<%# eval("srno").ToString().Trim() %>' Width="40"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="SsrNo">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtSsrno" runat="server" autocomplete="off" 
                                                                                                                CssClass="TextBoxGrideReadOnly" Enabled="False" ReadOnly="False" 
                                                                                                                Style="margin-top: 0px; margin-left: 1px; text-align: center;" 
                                                                                                                Text='<%# eval("Ssrno").ToString().Trim() %>' Width="40"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="User ID">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:UpdatePanel ID="UpdatePanel138" runat="server">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="txtu_id" runat="server" autocomplete="off" 
                                                                                                                        CssClass="TextBoxGrideInterface" MaxLength="500" ReadOnly="False" 
                                                                                                                        Style="margin-top: 3px; margin-left: 1px; text-align: left;" 
                                                                                                                        Text='<%# eval("u_id").ToString().Trim() %>' TextMode="SingleLine" Width="50px"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Module ID">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtmodule_id" runat="server" autocomplete="off" 
                                                                                                                CssClass="TextBoxGrideInterface" MaxLength="200" ReadOnly="False" 
                                                                                                                Style="margin-top: 3px; margin-left: 1px; text-align: left;" 
                                                                                                                Text='<%# eval("module_id").ToString().Trim() %>' TextMode="SingleLine" 
                                                                                                                Width="50px"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Module Name">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtmodule_name" runat="server" autocomplete="off" 
                                                                                                                CssClass="TextBoxGrideInterface" MaxLength="200" ReadOnly="True" 
                                                                                                                Style="margin-top: 3px; margin-left: 1px; text-align: left;" 
                                                                                                                Text='<%# eval("module_name").ToString() %>' TextMode="SingleLine" Width="99%"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="99%" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="parent_module">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtparent_module" runat="server" autocomplete="off" 
                                                                                                                CssClass="TextBoxGrideInterface" MaxLength="200" ReadOnly="False" 
                                                                                                                Style="margin-top: 3px; margin-left: 1px; text-align: left;" 
                                                                                                                Text='<%# eval("parent_module").ToString().Trim() %>' TextMode="SingleLine" 
                                                                                                                Width="99%"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="99%" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="NavigateUrl">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtNavigateUrl" runat="server" autocomplete="off" 
                                                                                                                CssClass="TextBoxGrideInterface" MaxLength="200" ReadOnly="False" 
                                                                                                                Style="margin-top: 3px; margin-left: 1px; text-align: left;" 
                                                                                                                Text='<%# eval("NavigateUrl").ToString().Trim() %>' TextMode="SingleLine" 
                                                                                                                Width="99%"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="99%" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Allow">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="CBAllowAll" runat="server" AutoPostBack="True" 
                                                                                                                oncheckedchanged="CBAllowAll_CheckedChanged" Text="&amp;nbspAllow" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%--<asp:UpdatePanel ID="UpdatePanel20Terminate" runat="server">
                                                                                                                <ContentTemplate>--%>
                                                                                                            <asp:CheckBox ID="CBAllow" runat="server" AutoPostBack="False" 
                                                                                                                Checked='<%# IIF(IsDbNull(Eval("Allow")),"0", Eval("Allow")) %>' 
                                                                                                                oncheckedchanged="CBTerminate_CheckedChanged" width="60px" />
                                                                                                            <%--</ContentTemplate>
                                                                                                            </asp:UpdatePanel>--%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Add">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="CBAllowAddAll" runat="server" AutoPostBack="True" Visible="false" 
                                                                                                                oncheckedchanged="CBAllowAddAll_CheckedChanged" Text="&amp;nbspAdd" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%--<asp:UpdatePanel ID="UpdatePanel20Terminate" runat="server">
                                                                                                                <ContentTemplate>--%>
                                                                                                            <asp:CheckBox ID="CBallow_add" runat="server" AutoPostBack="False" Visible="false" 
                                                                                                                Checked='<%# IIF(IsDbNull(Eval("allow_add")),"0", Eval("allow_add")) %>' 
                                                                                                                width="60px" />
                                                                                                            <%--</ContentTemplate>
                                                                                                            </asp:UpdatePanel>--%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Modify">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="CBAllowModifyAll" runat="server" AutoPostBack="True" Visible="false" 
                                                                                                                oncheckedchanged="CBAllowModifyAll_CheckedChanged" Text="&amp;nbspModify" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%--<asp:UpdatePanel ID="UpdatePanel20Terminate" runat="server">
                                                                                                                <ContentTemplate>--%>
                                                                                                            <asp:CheckBox ID="CBallow_mod" runat="server" AutoPostBack="False" Visible="false" 
                                                                                                                Checked='<%# IIF(IsDbNull(Eval("allow_mod")),"0", Eval("allow_mod")) %>' 
                                                                                                                width="60px" />
                                                                                                            <%--</ContentTemplate>
                                                                                                            </asp:UpdatePanel>--%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="CBAllowDeleteAll" runat="server" AutoPostBack="True" Visible="false" 
                                                                                                                oncheckedchanged="CBAllowDeleteAll_CheckedChanged" Text="&amp;nbspDelete" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%--<asp:UpdatePanel ID="UpdatePanel20Terminate" runat="server">
                                                                                                                <ContentTemplate>--%>
                                                                                                            <asp:CheckBox ID="CBallow_del" runat="server" AutoPostBack="False" Visible="false" 
                                                                                                                Checked='<%# IIF(IsDbNull(Eval("allow_del")),"0", Eval("allow_del")) %>' 
                                                                                                                width="60px" />
                                                                                                            <%--</ContentTemplate>
                                                                                                            </asp:UpdatePanel>--%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="View">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="CBAllowViewAll" runat="server" AutoPostBack="True" Visible="false" 
                                                                                                                oncheckedchanged="CBAllowViewAll_CheckedChanged" Text="&amp;nbspView" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%--<asp:UpdatePanel ID="UpdatePanel20Terminate" runat="server">
                                                                                                                <ContentTemplate>--%>
                                                                                                            <asp:CheckBox ID="CBallow_view" runat="server" AutoPostBack="False" Visible="false" 
                                                                                                                Checked='<%# IIF(IsDbNull(Eval("allow_view")),"0", Eval("allow_view")) %>' 
                                                                                                                width="60px" />
                                                                                                            <%--</ContentTemplate>
                                                                                                            </asp:UpdatePanel>--%>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Authorize">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="CBAllowAuthoAll" runat="server" AutoPostBack="True" Visible="false" 
                                                                                                                oncheckedchanged="CBAllowAuthoAll_CheckedChanged" Text="&amp;nbspAuthorize" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%--<asp:UpdatePanel ID="UpdatePanel20Terminate" runat="server">
                                                                                                                <ContentTemplate>--%>
                                                                                                            <asp:CheckBox ID="CBallow_san" runat="server" AutoPostBack="False" Visible="false" 
                                                                                                                Checked='<%# IIF(IsDbNull(Eval("allow_san")),"0", Eval("allow_san")) %>' 
                                                                                                                width="70px" />
                                                                                                            <%--</ContentTemplate>
                                                                                                            </asp:UpdatePanel>--%>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Preview">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="CBAllowPreviewAll" runat="server" AutoPostBack="True" Visible="false" 
                                                                                                                oncheckedchanged="CBAllowPreviewAll_CheckedChanged" Text="&amp;nbspPreview" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%--<asp:UpdatePanel ID="UpdatePanel20Terminate" runat="server">
                                                                                                                <ContentTemplate>--%>
                                                                                                            <asp:CheckBox ID="CBallow_prev" runat="server" AutoPostBack="False" Visible="false" 
                                                                                                                Checked='<%# IIF(IsDbNull(Eval("allow_prev")),"0", Eval("allow_prev")) %>' 
                                                                                                                width="70px" />
                                                                                                            <%--</ContentTemplate>
                                                                                                            </asp:UpdatePanel>--%>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Department">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtDepartment" runat="server" autocomplete="off" 
                                                                                                                CssClass="TextBoxGrideInterface" MaxLength="200" ReadOnly="False" 
                                                                                                                Style="margin-top: 3px; margin-left: 1px; text-align: left;" 
                                                                                                                Text='<%# eval("Department").ToString().Trim() %>' TextMode="SingleLine" 
                                                                                                                Width="100px"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="ModuleType">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtModuleType" runat="server" autocomplete="off" 
                                                                                                                CssClass="TextBoxGrideInterface" MaxLength="200" ReadOnly="False" 
                                                                                                                Style="margin-top: 3px; margin-left: 1px; text-align: left;" 
                                                                                                                Text='<%# eval("ModuleType").ToString().Trim() %>' TextMode="SingleLine" 
                                                                                                                Width="100px"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <PagerStyle CssClass="pgr" HorizontalAlign="Left" Wrap="False" />
                                                                                                <RowStyle Wrap="False" />
                                                                                                <SelectedRowStyle Wrap="False" />
                                                                                                <HeaderStyle Wrap="False" />
                                                                                                <AlternatingRowStyle Wrap="False" />
                                                                                                <SortedAscendingCellStyle Wrap="True" />
                                                                                            </asp:GridView>
                                                                                            </asp:Panel>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                   <%-- <asp:CollapsiblePanelExtender ID="pnlCollapsable2_CollapsiblePanelExtender" 
                                                        runat="server" CollapseControlID="pnlClick2" Collapsed="true" 
                                                        CollapsedImage="~/Images/downarrow.jpg" CollapsedText="Show" 
                                                        ExpandControlID="pnlClick2" ExpandDirection="Vertical" 
                                                        ExpandedImage="~/Images/uparrow.jpg" ExpandedText="Hide" 
                                                        ImageControlID="imgArrows2" ScrollContents="false" 
                                                        TargetControlID="pnlCollapsable2" TextLabelID="lblMessage2">
                                                    </asp:CollapsiblePanelExtender>--%>
                                                </div>
                                            </td>
            </tr>
           
           
            <tr>
                <td align="left" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" class="Headingseparator" colspan="5">
                    <table>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="HFprno" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="HFMachineCode" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel133" runat="server">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="HFdeptcd" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel136" runat="server">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="HFItemcd" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1225" runat="server">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="HFsave_value" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" class="style51">
                    <%-- <ItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel2Rate" runat="server">
                                             <ContentTemplate>
                                             <wijmo:C1InputNumeric ID="txtRate" runat="server" Height="20px" Width="90px"
                                                Text='<%# eval("rate") %>' onblur="return validateBegin();" onkeydown="return jsDecimals(event);"
                                                 ontextchanged="txtPassQty_ValueChanged" AutoPostBack="True">
                                                </wijmo:C1InputNumeric>
                                                 </ContentTemplate>
                                            </asp:UpdatePanel>
                                          
                                        </ItemTemplate>--%>
                </td>
                <td class="style181">
                    &nbsp;</td>
                <td class="style182">
                </td>
                <td align="right" class="style183">
                    <asp:Label ID="lbl2" runat="server"></asp:Label>
                </td>
                <td class="style40">
                    <table align="right" style="height: 14px; ">
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="right">
                                <%--<asp:ImageButton ID="btnPreview" runat="server" Height="26px" OnClientClick="SetTarget();"
                                    ImageUrl="~/images/BTPreview.png" ValidationGroup="SV" Width="100px" />--%>
                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                                    AssociatedUpdatePanelID="UpdatePanel157">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgprogress3" runat="server" Height="24px" 
                                            ImageUrl="~/images/Processing.gif" Width="24px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right">
                                &nbsp;</td>
                            <td align="right">
                                <asp:UpdatePanel ID="UpdatePanel157" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" 
                                            Font-Bold="False" Height="31px" OnClientClick="SetTargetOff()" Text="Save" 
                                            Width="85px" ValidationGroup="Save" />
                                        <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_btnSave" runat="server" 
                                            ConfirmText="Are you sure you want to Save ?" OnClientCancel="CancelClick" 
                                            TargetControlID="btnSave">
                                        </asp:ConfirmButtonExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="right">
                                &nbsp;</td>
                            <td align="right">
                                <%--<asp:ImageButton ID="btnClose" runat="server" Height="26px" OnClientClick="SetTargetOff();" 
                                    ImageUrl="~/images/BTClose.png" ValidationGroup="SV" Width="100px" />--%>
                                <asp:Button ID="btnClose" runat="server" CssClass="btn btn-light" 
                                    Font-Bold="False" Height="31px" OnClientClick="SetTargetOff();" Text="Close" 
                                    ValidationGroup="SV" Width="85px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" class="style51">
                    &nbsp;</td>
                <td class="style181">
                    &nbsp;</td>
                <td class="style182">
                    &nbsp;</td>
                <td align="right" class="style183">
                    &nbsp;</td>
                <td class="style40">
                    &nbsp;</td>
            </tr>
            </table>
        </asp:Panel>
    </div>
                </div>
       </div>
         </div>
</asp:Content>

