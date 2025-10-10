<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="CountryMaster.aspx.vb" Inherits="CountryMaster" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
<%--        <link href="../../Styles_Menu/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="../../Styles_Menu/style.css" rel="stylesheet" type="text/css" />
        <script src="../../Styles_Menu/jquery-1.12.0.min.js" type="text/javascript"></script>
        <script src="../../Styles_Menu/bootstrap.min.js" type="text/javascript"></script>--%>
 <style type="text/css">

     .SpaceBetween {
            padding-top: 5px;
        }
        .overlayMaster {
            position: fixed;
            top: 0px;
            bottom: 0px;
            left: 0px;
            right: 0px;
            overflow: hidden;
            padding: 0;
            margin: 0;
            background-color: rgba(0, 0, 0, 0.6);


            filter: alpha(opacity=50);
            opacity: 0.5;
            z-index: 100;
        }       
        .SectionHeading {
            background-color: #FFFFFF;
            height: 35px;
            vertical-align: middle;
            width: 100%;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            border-bottom-color: darkorange;
        }
        .Headingseparator {
            border-bottom-width: 1px;
            border-bottom-color: darkorange;
            border-bottom-style: solid;
        }
        .EntryFormHeadingNew {
            font-family: 'Century Gothic';
            font-size: 21pt;
            color: black;
            font-weight: bold;
        }
   .popupMaster {
            position: fixed;
            background-color: #fff;
            top: 30%;
            left: 50%;
            z-index: 100;
            padding: 15px;
            -webkit-transform: translate(-50%, -50%);
            -moz-transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            -o-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            -ms-border-radius: 10px;
            -o-border-radius: 10px;
            border-radius: 10px;
            -webkit-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -moz-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -ms-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -o-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -webkit-transition: opacity .5s, top .5s;
            -moz-transition: opacity .5s, top .5s;
            -ms-transition: opacity .5s, top .5s;
            -o-transition: opacity .5s, top .5s;
            transition: opacity .5s, top .5s;
        }


        .style81
     {
         width: 160px;
     }
        
           
        .auto-style1 {
         height: 26px;
     }
        
           
        .auto-style4 {
         height: 17px;
     }
        
           
        </style>

      
       <script type="text/javascript" language="javascript">
           function CancelClick() {
               document.getElementById("<%=lbl2.ClientID %>").innerHTML = "";
           }
       </script>   
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Country Master</h4>
                </div>
                <div class="col-md-7 align-self-center text-right">
                    <div class="d-flex justify-content-end align-items-center">
                        <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-info m-l-15"><i class="fa fa-plus-circle"></i>&nbsp;New</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    
    <div class="">
       <div class="card">
            <div class="">
                <div class="table-responsive ">
                    <asp:UpdatePanel ID="UpdatePanel87" runat="server">
                        <ContentTemplate>

                           <dx:ASPxGridView ID="GridViewLST" runat="server" AutoGenerateColumns="False" 
                                            EnableViewState="False" KeyFieldName="countrycd" 
                                            OnCustomCallback="ASPxGridView1_CustomCallback" 
                                            OnDataBinding="ASPxGridView1_DataBinding" Theme="Metropolis" 
                                            Width="100%">
                                            <SettingsBehavior AllowFocusedRow="True" ProcessSelectionChangedOnServer="True" />
                                            <settings showfilterrow="True" ShowFooter="True" ShowGroupButtons="True" 
                                                ShowGroupedColumns="False" ShowGroupFooter="VisibleAlways" 
                                                ShowGroupPanel="False" showheaderfilterbutton="True" />
                                            <Settings ShowGroupFooter="VisibleAlways"  />
                                            <SettingsAdaptivity>
                                                <AdaptiveDetailLayoutProperties ColCount="1">
                                                </AdaptiveDetailLayoutProperties>
                                            </SettingsAdaptivity>
                                            <SettingsPager PageSize="15">
                                                <PageSizeItemSettings Items="15, 25, 35, 45, 55, 75, 100" Visible="true" />
                                                <PageSizeItemSettings Items="15, 25, 35, 45, 55, 75, 100" Visible="True">
                                                </PageSizeItemSettings>
                                            </SettingsPager>
                                            <Settings ShowFooter="True" />
                                            <SettingsPopup>
                                                <HeaderFilter Height="200">
                                                    <SettingsAdaptivity MinHeight="300" Mode="OnWindowInnerWidth" 
                                                        SwitchAtWindowInnerWidth="768" />
                                                </HeaderFilter>
                                            </SettingsPopup>
                                            <Settings ShowTitlePanel="True" />
                                            <SettingsSearchPanel Visible="False" />
                                            <SettingsLoadingPanel Delay="100" />
                                            <EditFormLayoutProperties ColCount="1">
                                            </EditFormLayoutProperties>
                                            <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="0" Width="8px">
                            <DataItemTemplate>
                                <dx:ASPxButton ID="btnEditEntry" runat="server" OnClick="btnEditEntry_Click"
                                    CssPostfix="none" RenderMode="Link" CssClass="fa fa-edit devexeditStyle">
                                </dx:ASPxButton>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Country Code" FieldName="countrycd" 
                                                    VisibleIndex="1" Width="200px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Country Name " FieldName="countryname" 
                                                    VisibleIndex="2">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <GroupRow Font-Bold="True">
                                                </GroupRow>
                                                <Header CssClass="dxgvHeaderInterface dxgvHeader_Moderno">
                                                </Header>
                                                <SelectedRow CssClass="dxgvSelectedRow_DevEx">
                                                </SelectedRow>
                                                <FocusedRow CssClass="dxgvSelectedRow_DevEx">
                                                </FocusedRow>
                                                <Footer CssClass="dxgvFooterInterface">
                                                </Footer>
                                                <GroupFooter Font-Bold="True">
                                                </GroupFooter>
                                                <GroupPanel Font-Bold="False">
                                                </GroupPanel>
                                                <SearchPanel>
                                                </SearchPanel>
                                            </Styles>
                                        </dx:ASPxGridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div> 

<div>
    <table>
            <tr>
                <td align="left">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="left">

         <asp:UpdatePanel ID="upPopUps" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Panel ID="panelOverlay" runat="server" class="overlayMaster" 
                                Visible="false">
                            </asp:Panel>
                            <asp:Panel ID="panelPopUpPanel" runat="server" class="popupMaster" 
                                Height="269px" Visible="false">
                                <asp:Panel ID="panelPopUpTitle" runat="server" 
                                    style="width:100%;height:20px;text-align:right;">
                                    <asp:ImageButton ID="cmdClosePopUp" runat="server" Height="20px" 
                                        ImageUrl="~/images/Close.png" ValidationGroup="SV" />
                                </asp:Panel>
                                <div>
                                    <table class="auto-style1">
                                        <tr>
                                            <td colspan="6" class="Headingseparator">
                                                <label ID="Label239" title="Test">
                                                <asp:Label ID="Label240" runat="server" CssClass="EntryFormHeadingNew" 
                                                    Font-Bold="True" Font-Size="Medium" ForeColor="Black" Text="Country Master"></asp:Label>
                                                </label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style80">
                                                &nbsp;</td>
                                            <td class="style83" colspan="4">
                                                &nbsp;</td>
                                            <td class="style79">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style80">
                                                &nbsp;</td>
                                            <td class="style83">
                                                &nbsp;</td>
                                            <td class="style83">
                                                &nbsp;</td>
                                            <td class="style83">
                                                &nbsp;</td>
                                            <td class="style78">
                                                &nbsp;</td>
                                            <td class="style79">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style80" >
                                                &nbsp;</td>
                                            <td align="right" class="style83">
                                                <asp:Label ID="Label233" runat="server" CssClass="LableInterface" 
                                                    Text="Country Name" Width="140px"></asp:Label>
                                            </td>
                                            <td align="left" class="style83">
                                                &nbsp;</td>
                                        
                                            <td align="left" class="style78">
                                                <asp:TextBox ID="txtCountryName" runat="server" autocomplete="off" 
                                                    CssClass="form-control input-sm req" MaxLength="60" 
                                                    Style="margin-top: 0px; " Width="373px"></asp:TextBox>
                                            </td>
                                            <td class="style79">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style80">&nbsp;</td>
                                            <td align="right" class="style83">
                                                &nbsp;</td>
                                            <td align="left" class="style83">&nbsp;</td>
                                           
                                            <td align="left" class="style78">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCountryName" ErrorMessage="Enter Country Name"></asp:RequiredFieldValidator>
                                            </td>
                                          
                                        </tr>
                                          <tr>
                                            <td class="auto-style4"></td>
                                            <td align="right" class="auto-style4">
                                                </td>
                                            <td align="left" class="auto-style4"></td>
                                           
                                            <td align="left" class="auto-style4">
                                               <asp:Label ID="ErrorMsg0" runat="server" ForeColor="Red" Height="10px"></asp:Label>
                                            </td>
                                          
                                        </tr>
                                        
                                            <tr>
                                                <td class="Headingseparator" colspan="6">
                                                    <label id="Label239" title="Test">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style80">&nbsp;</td>
                                                <td align="center" colspan="4" style="padding-top:12px">
                                                    <table style="width: 102%; height: 14px">
                                                        <tr>
                                                               <td align="left" class="style77">
                                                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-info" 
                                                                Font-Bold="False" OnClientClick="SetTargetOff();" Text="Delete" 
                                                                ValidationGroup="SV" />
                                                            <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                                                ConfirmText="Are you sure you want to Delete ?" OnClientCancel="CancelClick" 
                                                                TargetControlID="btnDelete">
                                                            </asp:ConfirmButtonExtender>
                                                        </td>
                                                            <td>
                                                                <asp:Label ID="Label238" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="White" Height="20px" Text="" Width="220px"></asp:Label>
                                                            </td>
                                                            <td class="style77" width="85px"></td>
                                                            <td align="right">&nbsp;</td>
                                                            <td align="right" class="style77" width="100px">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" Font-Bold="False" OnClientClick="Confirm()" Text="Save" />
                                                                        </td>
                                                                        <td>&nbsp; </td>
                                                                        <td>
                                                                            <asp:Button ID="btnClose" runat="server" CssClass="btn btn-secondary" Font-Bold="False" OnClientClick="SetTargetOff();" Text="Close" ValidationGroup="SV" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <td align="center" colspan="4" style="padding-top:12px"></td>
                                                    <td class="style79">&nbsp;</td>
                                                </td>
                                            </tr>
                                        </caption>
                                          </table>
                                </div>
                                <div>
                                    &nbsp;</div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
      
      
        
                </td>
            </tr>
            <tr>
                <td align="left">

                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left">

                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left">

        <asp:Label ID="lbl2" runat="server"></asp:Label>
        
                </td>
            </tr>
            <tr>
                <td align="left">
        
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="HFCountryCode" runat="server" />
               
            </ContentTemplate>
        </asp:UpdatePanel>
                </td>
            </tr>
            </table>
    </div>
        </div>
</asp:Content>

