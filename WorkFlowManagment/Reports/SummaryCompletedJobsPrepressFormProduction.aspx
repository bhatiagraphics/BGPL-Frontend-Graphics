<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="SummaryCompletedJobsPrepressFormProduction.aspx.vb" Inherits="SummaryCompletedJobsPrepressFormProduction" title="ERP" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<%@ Register assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

       <%-- <link href="../../Styles_Menu/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="../../Styles_Menu/style.css" rel="stylesheet" type="text/css" />
        <script src="../../Styles_Menu/jquery-1.12.0.min.js" type="text/javascript"></script>
        <script src="../../Styles_Menu/bootstrap.min.js" type="text/javascript"></script>--%>

<style type="text/css">
        .WordWrap {
            width: 120px;
            word-break: break-all;
        }
    </style>
    <style type="text/css">
                   
        .style105
        {
            width: 1%;
        }
           
        .style139
        {
            width: 4px;
        }
           
        .style248
        {
            height: 20px;
            text-align: center;
        }
           
      .EntryFormHeadingNew
{
    font-family: 'Century Gothic';
    font-size: 21pt;
    color: #333333;
    font-weight: bold;
} 

        .style253
        {
            width: 120px;
        }
        .style259
        {
            width: 52px;
        }
        .style260
        {
            width: 70px;
        }
        .style263
        {
            width: 45px;
        }
        .style265
        {
            width: 106px;
        }
        .style268
        {
            width: 80px;
        }
        .style276
        {
            width: 110px;
        }

        </style>
       <script type="text/javascript" language="javascript">
           function SetTarget() { 
            document.forms[0].target = "_blank"; }
       </script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center" style="width: 100%; height: 100%" class="clsReportss">
        <table align="center" bgcolor="White" 
            style="border-color: #000000; width: 100%;">
             <tr>
                <td align="left" style="border-bottom-width: 1px; border-bottom-color: #1279C0; border-bottom-style: solid;
                    padding-bottom: 4px;">
                </td>
            </tr>
            <tr>
               <td align="left" 
                     style="border-bottom-width: 1px; border-bottom-color: #1279C0; border-bottom-style: solid; padding-bottom: 4px;">
                                    <span id="ctl00_ContentPlaceHolder1_Label685" class="EntryFormHeadingNew" style="font-weight:normal;"   > COMPLETED JOBS PREPRESS FORM PRODUCTION (SUMMARY) </span>
                    
                </td>
            </tr>
            <tr>
                <td align="left">
                    
                                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left">
                    
<%--                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="EntryFormHeadingNew" 
                                        Font-Bold="False" Font-Size="10pt" Font-Underline="False" 
                                        ForeColor="#609ED2">&gt; Report &gt; Completed Jobs Prepress Form Production (Summary)</asp:HyperLink>--%>
                    
                </td>
            </tr>
            <tr>
                <td align="left">
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="background-color: #949699">
                                            <table style="background-color: #949699;">
                                                <tr>
                                                    <td class="style139" rowspan="5">
                                                        &nbsp;</td>
                                                    <td class="style259" rowspan="5">
                                <asp:ImageButton ID="btnSubmit0" runat="server" Enabled="False" Height="50px" 
                                    ImageUrl="~/images/SearchArrow.png" Width="52px" />
                                                    </td>
                                                    <td class="style260" rowspan="5">
                                <asp:Label ID="lblBranch1" runat="server" Font-Bold="True"
                                    Font-Names="Century Gothic" Font-Size="16pt" ForeColor="White" Text="Filters" 
                                    Width="70px"></asp:Label>
                                                    </td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style263">
                                                        &nbsp;</td>
                                                    <td class="style265">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style268">
                                                        &nbsp;</td>
                                                    <td class="style253">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td rowspan="5" align="left" 
                                                        style="background-color: #949699;">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style139">
                                                                &nbsp;</td>
                                                    <td class="style263">
                                                    <asp:Label ID="lblBranch" runat="server" CssClass="LableInterface" 
                                                        Font-Bold="False" ForeColor="White" Text="From Date" Width="80px"></asp:Label>
                                                    </td>
                                                    <td class="style265">
                                                        <asp:TextBox ID="txtfromdt" runat="server" style="margin-left: 0px" 
                                                                Width="100px" CssClass="TextBoxInterface" Height="28px"></asp:TextBox>
                                                        <asp:CalendarExtender ID="txtfromdt_CalendarExtender" runat="server" 
                                                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtfromdt">
                                                        </asp:CalendarExtender>
                                                        <asp:maskededitextender ID="txtfromdt_MaskedEditExtender" runat="server" 
                                                                Mask="99/99/9999" MaskType="Date" PromptCharacter="_" 
                                                                TargetControlID="txtfromdt" UserDateFormat="DayMonthYear" />
                                                    </td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style268" style="padding-right:5px">


                                                    </td>
                                                    <td class="style253">

                                                    </td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                    <asp:ImageButton ID="btnPreview" runat="server" Height="28px" OnClientClick="SetTarget();"
                                                        ImageUrl="~/images/BTPreview.png" Width="110px" Visible="False" />
                                                    </td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style139">
                                                                &nbsp;</td>
                                                    <td class="style263">
                                                        &nbsp;</td>
                                                    <td class="style265">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style268">
                                                        &nbsp;</td>
                                                    <td class="style253">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style139">
                                                                &nbsp;</td>
                                                    <td class="style263">
                                                    <asp:Label ID="lblBranch0" runat="server" CssClass="LableInterface" 
                                                        Font-Bold="False" ForeColor="White" Text="To Date" Width="80px"></asp:Label>
                                                    </td>
                                                    <td class="style265">
                                                        <asp:TextBox ID="txttodt" runat="server" style="margin-left: 0px" 
                                                                Width="100px" CssClass="TextBoxInterface" Height="28px"></asp:TextBox>
                                                        <asp:CalendarExtender ID="txttodt_CalendarExtender" runat="server" 
                                                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txttodt">
                                                        </asp:CalendarExtender>
                                                        <asp:maskededitextender ID="txttodt_Maskededitextender" runat="server" 
                                                                Mask="99/99/9999" MaskType="Date" PromptCharacter="_" 
                                                                TargetControlID="txttodt" UserDateFormat="DayMonthYear" />
                                                    </td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style268">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-warning" Text="Submit" Width="85px" />
           
                                                    </td>
                                                    <td class="style253">

                                                    </td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">

                                                    </td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                                <asp:ImageButton ID="btnExcel" runat="server" Height="28px" OnClientClick="SetTarget();"
                                                        
    ImageUrl="~/images/BTExcel.png" Width="110px" Visible="False" />
                                                            </td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                                &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style139">
                                                                &nbsp;</td>
                                                    <td class="style263">
                                                                &nbsp;</td>
                                                    <td class="style265">
                                                                &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style268">
                                                        &nbsp;</td>
                                                    <td class="style253">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                </tr>
                                                </table>
                </td>
            </tr>
            <tr>
                <td align="left" class="style105">
                        <table style="width:100%;">
                            <tr>
                                <td align="center">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            BackColor="#D3E1F1" BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" 
                                            DisplayMode="SingleParagraph" EnableClientScript="true" Font-Bold="False" 
                                            Font-Names="Arial" Font-Size="Small" 
                                            HeaderText="You must fill the following fields (*) :   " Height="16px" 
                                            Width="98%" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style248">
                                    <asp:Label ID="ErrorMSG" runat="server" BackColor="#D3E1F1" BorderColor="Red" 
                                        BorderStyle="Solid" BorderWidth="1px" ForeColor="Red" Visible="False"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td align="left" class="style248">
                        <table style="width:100%;">
                            <tr>
                                <td align="left" class="dx-justification" style="vertical-align: top">
                                    <dx:ASPxGridView ID="Completed_Jobs_Prepress_Form_Production_Summary" runat="server" AutoGenerateColumns="False" 
                                        EnableViewState="False" KeyFieldName="assignedto"
                                        OnCustomCallback="ASPxGridView1_CustomCallback" OnHeaderFilterFillItems="ASPxGridView1_HeaderFilter"
                                        OnDataBinding="ASPxGridView1_DataBinding" Theme="Default" 
                                        Width="100%" OnCustomUnboundColumnData="grid_CustomUnboundColumnData">
                                        <settingsbehavior processselectionchangedonserver="True" />
                                        <SettingsBehavior AllowFocusedRow="True" 
                                            ProcessSelectionChangedOnServer="True" />

                                        <Toolbars>
                                        <dx:GridViewToolbar EnableAdaptivity="true">
                                                <Items>
                                                    <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Export To Excel" />
                                                </Items>
                                        </dx:GridViewToolbar>
                                        </Toolbars>

                                      <Settings ShowGroupPanel="True" ShowFooter="True" ShowFilterRow="True" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500"/>  
                                        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" />

                                        <SettingsAdaptivity>
                                            <AdaptiveDetailLayoutProperties ColCount="1">
                                            </AdaptiveDetailLayoutProperties>
                                        </SettingsAdaptivity>
                                        <SettingsPager PageSize="55">
                                            <PageSizeItemSettings Items="15, 25, 35, 45, 55,75,100" Visible="true" />
                                            <PageSizeItemSettings Items="15, 25, 35, 45, 55,75,100" Visible="True">
                                            </PageSizeItemSettings>
                                        </SettingsPager>
                                        <settings showfilterrow="True" ShowFooter="True" ShowGroupButtons="True" 
                                            ShowGroupedColumns="False" ShowGroupFooter="VisibleAlways" 
                                            ShowGroupPanel="True" showheaderfilterbutton="True" />
                                        <SettingsBehavior AllowFocusedRow="True" />
                                        <Settings ShowFilterRow="True" ShowGroupFooter="VisibleAlways" 
                                            ShowGroupPanel="True" ShowHeaderFilterButton="True" />
                                        <SettingsBehavior AllowFocusedRow="True" 
                                            ProcessSelectionChangedOnServer="True" />
                                        <EditFormLayoutProperties ColCount="1">
                                        </EditFormLayoutProperties>
                                        <SettingsPopup>
                                            <HeaderFilter Height="200">
                                                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" MinHeight="300" />
                                            </HeaderFilter>
                                        </SettingsPopup>
                                        <Columns>
                                        <dx:GridViewDataTextColumn VisibleIndex="0" Width="63px">
                                            <DataItemTemplate>
                                                <dx:ASPxButton ID="btnLedger" runat="server" Height="2px" OnClick="btnLedger_Click" Text="Detail">
                                               <%-- <ClientSideEvents Click="SetTarget" />--%>
                                                </dx:ASPxButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="Assigned To" FieldName="assignedname" VisibleIndex="1" HeaderStyle-HorizontalAlign="Left" >
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>  
                                        </dx:GridViewDataTextColumn> 
                                         <dx:GridViewDataTextColumn Caption="Reporting To" FieldName="reportingtoname" VisibleIndex="2" HeaderStyle-HorizontalAlign="Left" >
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>  
                                        </dx:GridViewDataTextColumn>    
                                         <dx:GridViewDataTextColumn Caption="Count" FieldName="cnt" VisibleIndex="3" HeaderStyle-HorizontalAlign="Left" >
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>  
                                        </dx:GridViewDataTextColumn>                                              
                                        </Columns>    
                                        <totalsummary>
                                        <dx:ASPxSummaryItem FieldName="cnt" ShowInColumn="cnt" SummaryType="Sum" ></dx:ASPxSummaryItem>
                                        </totalsummary>                                         
                                        <Styles>
                                            <GroupRow Font-Bold="True">
                                            </GroupRow>
                                            <Footer Font-Bold="True">
                                            </Footer>
                                            <GroupFooter Font-Bold="True">
                                            </GroupFooter>
                                            <GroupPanel Font-Bold="False">
                                            </GroupPanel>
                                        </Styles>
                                        </dx:ASPxGridView>
                                    </td>
                                </tr>
                            </table>
                    
                    
                                    </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label305" runat="server" ForeColor="White" Height="560px" 
                                        Text="."></asp:Label>
                                </td>
                            </tr>
                        </table>
                    
                    
                </td>
            </tr>
            </table>
    </div>
</asp:Content>

