<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="AccountsLanding.aspx.vb" Inherits="AccountsLanding" title="ERP" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
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
                                    <span id="ctl00_ContentPlaceHolder1_Label685" class="EntryFormHeadingNew" style="font-weight:normal;"   > Accounts Landing </span>
                    
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
                                        ForeColor="#609ED2">&gt; Report &gt; Pending Jobs Approval Form Graphics (Summary)</asp:HyperLink>--%>
                    
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
                                                        Font-Bold="False" ForeColor="White" Text="Month" Width="80px" style="margin-bottom: 0px"></asp:Label>
                                                    </td>
                                                    <td class="style265">
                <asp:DropDownList ID="ddlmth" runat="server" Width="200px" OnSelectedIndexChanged="ddlmth_SelectedIndexChanged" 
                    CssClass="form-control searchableddl" Height="28px">
    <asp:ListItem Text="" Value=""></asp:ListItem>
    <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
    <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
    <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
    <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
    <asp:ListItem Text="May" Value="5"></asp:ListItem>
    <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
    <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
    <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
    <asp:ListItem Text="Sept" Value="9"></asp:ListItem>
    <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
    <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                </asp:DropDownList>
                                                        <asp:TextBox ID="txtfromdt" runat="server" style="margin-left: 0px" Visible="false" 
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
                                                    <td class="style268">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LableInterface" 
                                                        Font-Bold="False" ForeColor="White" Text="Company" Width="80px" style="margin-bottom: 0px"></asp:Label>
                                                    </td>
                                                    <td class="style253">
                <asp:DropDownList ID="ddlcompcd" runat="server" Width="200px" 
                    CssClass="form-control searchableddl" Height="28px">
                </asp:DropDownList>
                                                    </td>
                                                    <td class="style139">
                                                        &nbsp;</td>
                                                    <td class="style276">
                                                    <asp:Label ID="Label3" runat="server" CssClass="LableInterface" 
                                                        Font-Bold="False" ForeColor="White" Text="Courier" Width="80px" style="margin-bottom: 0px"></asp:Label>                                                        
                                                    </td>
                                                    <td class="style139">
                <asp:DropDownList ID="ddltranscd" runat="server" Width="200px" 
                    CssClass="form-control searchableddl" Height="28px">
                </asp:DropDownList>                                                        
                                                    </td>
                                                    <td class="style276">

<%--                                                    <asp:ImageButton ID="btnPreview" runat="server" Height="28px" OnClientClick="SetTarget();"
                                                        ImageUrl="~/images/BTPreview.png" Width="110px" Visible="False" />--%>
                                                    </td>
                                                    <td class="style139">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-warning" Text="Submit" Width="85px" />
                                                        
                                                    </td>
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
                                                        Font-Bold="False" ForeColor="White" Text="Year" Width="80px"></asp:Label>
                                                    </td>
                                                    <td class="style265">
                <asp:DropDownList ID="ddlyr" runat="server" Width="200px" OnSelectedIndexChanged="ddlyr_SelectedIndexChanged" 
                    CssClass="form-control searchableddl" Height="28px">
    <asp:ListItem Text="" Value=""></asp:ListItem>
    <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
    <asp:ListItem Text="2026" Value="2026"></asp:ListItem>
    <asp:ListItem Text="2027" Value="2027"></asp:ListItem>
    <asp:ListItem Text="2028" Value="2028"></asp:ListItem>
    <asp:ListItem Text="2029" Value="2029"></asp:ListItem>
    <asp:ListItem Text="2030" Value="2030"></asp:ListItem>
</asp:DropDownList>
                                                        <asp:TextBox ID="txttodt" runat="server" style="margin-left: 0px" Visible="false" 
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
                                                    <asp:Label ID="Label2" runat="server" CssClass="LableInterface" 
                                                        Font-Bold="False" ForeColor="White" Text="Ship To" Width="80px" style="margin-bottom: 0px"></asp:Label>

                                                    </td>
                                                    <td class="style253">
                <asp:DropDownList ID="ddlshipcuscode" runat="server" Width="200px" 
                    CssClass="form-control searchableddl" Height="28px">
                </asp:DropDownList>
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
            <!-- Validation Summary -->
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

            <!-- Error Label -->
            <tr>
                <td align="left" class="style248">
                    <asp:Label ID="ErrorMSG" runat="server" BackColor="#D3E1F1" BorderColor="Red" 
                        BorderStyle="Solid" BorderWidth="1px" ForeColor="Red" Visible="False"></asp:Label>
                </td>
            </tr>

            <!-- ASPxGridView1 - Full width -->
            <tr>
                <td align="left"  class="dx-justification">
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
                                        EnableViewState="False" KeyFieldName="jobid"
                                        OnCustomCallback="ASPxGridView1_CustomCallback" OnHeaderFilterFillItems="ASPxGridView1_HeaderFilter"
                                        OnDataBinding="ASPxGridView1_DataBinding" Theme="Default" 
                                        Width="100%" >

                         <Toolbars>
                                        <dx:GridViewToolbar EnableAdaptivity="true">
                                            <Items>
                                                <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Export To Excel" />
                                           
                                            </Items>
                                        </dx:GridViewToolbar>
                                    </Toolbars>

                                        <settingsbehavior processselectionchangedonserver="True" />
                               <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" />

                                        <SettingsBehavior AllowFocusedRow="True" 
                                            ProcessSelectionChangedOnServer="True" />
                        <Settings ShowGroupPanel="True" ShowFooter="True" ShowFilterRow="True" HorizontalScrollBarMode ="Visible"  />
                                        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" />

                                        <SettingsAdaptivity>
                                            <AdaptiveDetailLayoutProperties ColCount="1">
                                            </AdaptiveDetailLayoutProperties>
                                        </SettingsAdaptivity>
                                        <SettingsPager Mode="ShowAllRecords" Visible="False" />
                                        <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="600" />

                                        <settings showfilterrow="True" ShowFooter="True" ShowGroupButtons="True" 
                                            ShowGroupedColumns="False" ShowGroupFooter="VisibleAlways" 
                                            ShowGroupPanel="True" showheaderfilterbutton="True" />
                                                <SettingsBehavior AllowFocusedRow="True" AutoExpandAllGroups="True"/>
                                        <Settings ShowFilterRow="True" ShowGroupFooter="VisibleAlways" 
                                            ShowGroupPanel="True" ShowHeaderFilterButton="True" />
                                        <SettingsBehavior AllowFocusedRow="True" 
                                            ProcessSelectionChangedOnServer="True" AutoExpandAllGroups="True" />
                                        <EditFormLayoutProperties ColCount="1">
                                        </EditFormLayoutProperties>
                                        <SettingsPopup>
                                            <HeaderFilter Height="200">
                                                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" MinHeight="300" />
                                            </HeaderFilter>
                                        </SettingsPopup>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption=" " FieldName="jobcreatedt1" VisibleIndex="0" GroupIndex="1"  HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn VisibleIndex="0" Width="63px">
                                <DataItemTemplate>
                                    <dx:ASPxButton ID="btnBilling" runat="server" Height="2px" 
                                        OnClick="btnBilling_Click"  Text="Detail">
                                    </dx:ASPxButton>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Job Date" FieldName="jobcreatedt1" VisibleIndex="1" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px" >
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Job Week Day" FieldName="jobweekday" VisibleIndex="2" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px" />
                            <dx:GridViewDataTextColumn Caption="Job Day" FieldName="jobday" VisibleIndex="2" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px" />
                            <dx:GridViewDataTextColumn Caption="Challan No" FieldName="chlno" VisibleIndex="3" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="200px"/>
                            <dx:GridViewDataTextColumn Caption="Challan Date" FieldName="chldt" VisibleIndex="4" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px" >
                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy" />  
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Internal Job Code" FieldName="intcode" VisibleIndex="5" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px"/>
                            <dx:GridViewDataTextColumn Caption="Rev No" FieldName="revno" VisibleIndex="6" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px" />
                            <dx:GridViewDataTextColumn Caption="Job ID" FieldName="jobid" VisibleIndex="7" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px"/>
                            <dx:GridViewDataTextColumn Caption="Job Name" FieldName="jobname" VisibleIndex="8" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="200px" />
                            <dx:GridViewDataTextColumn Caption="Material" FieldName="platetypename" VisibleIndex="9" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="200px"/>
                            <dx:GridViewDataTextColumn Caption="Client" FieldName="cusname" VisibleIndex="10" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="200px"/>
                            <dx:GridViewDataTextColumn Caption="Width" FieldName="width_plate_cms" VisibleIndex="11" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="right" HeaderStyle-Wrap="True" width="100px"/>
                            <dx:GridViewDataTextColumn Caption="Qty" FieldName="noofplates" VisibleIndex="12" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="right" HeaderStyle-Wrap="True" width="100px"/>                            
                            <dx:GridViewDataTextColumn Caption="Length" FieldName="length_plate_cms" VisibleIndex="13" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="right" HeaderStyle-Wrap="True" width="100px" />
                            <dx:GridViewDataTextColumn Caption="Rate" FieldName="rate" VisibleIndex="14" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="right" HeaderStyle-Wrap="True" width="100px" />
                            <dx:GridViewDataTextColumn Caption="CMS" FieldName="cms" VisibleIndex="15" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="right" HeaderStyle-Wrap="True" width="100px"/>
                            <dx:GridViewDataTextColumn Caption="Total" FieldName="total" VisibleIndex="16" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="right" HeaderStyle-Wrap="True" width="100px"/>                            
                            <dx:GridViewDataTextColumn Caption="Supply To" FieldName="cusshiptoname" VisibleIndex="17" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px"/>
                            <dx:GridViewDataTextColumn Caption="Courier Name" FieldName="transname" VisibleIndex="18" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="200px" />
                            <dx:GridViewDataTextColumn Caption="Docket No." FieldName="docketno" VisibleIndex="19" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px"/>
                            <dx:GridViewDataTextColumn Caption="Bill No." FieldName="billno" VisibleIndex="20" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="200px" />
                            <dx:GridViewDataTextColumn Caption="Bill Dt." FieldName="billdt" VisibleIndex="21" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left" HeaderStyle-Wrap="True" width="100px" >
                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy" />  
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="width_plate_cms" ShowInColumn="width_plate_cms" SummaryType="Sum" ValueDisplayFormat="0.00" DisplayFormat="{0:N2}"></dx:ASPxSummaryItem>
                                        <dx:ASPxSummaryItem FieldName="noofplates" ShowInColumn="noofplates" SummaryType="Sum" ValueDisplayFormat="0.00" DisplayFormat="{0:N2}"></dx:ASPxSummaryItem>
                                        <dx:ASPxSummaryItem FieldName="length_plate_cms" ShowInColumn="length_plate_cms" SummaryType="Sum" ValueDisplayFormat="0.00" DisplayFormat="{0:N2}"></dx:ASPxSummaryItem>
                                        <dx:ASPxSummaryItem FieldName="rate" ShowInColumn="rate" SummaryType="Sum" ValueDisplayFormat="0.00" DisplayFormat="{0:N2}"></dx:ASPxSummaryItem>
                                        <dx:ASPxSummaryItem FieldName="cms" ShowInColumn="cms" SummaryType="Sum" ValueDisplayFormat="0.00" DisplayFormat="{0:N2}"></dx:ASPxSummaryItem>
                                        <dx:ASPxSummaryItem FieldName="total" ShowInColumn="total" SummaryType="Sum" ValueDisplayFormat="0.00" DisplayFormat="{0:N2}"></dx:ASPxSummaryItem>
                        </TotalSummary>
                                          <GroupSummary>
                                             <dx:ASPxSummaryItem FieldName="width_plate_cms" ShowInGroupFooterColumn="width_plate_cms" SummaryType="Sum" ValueDisplayFormat="0.00"  DisplayFormat="{0:N2}"/>
                                             <dx:ASPxSummaryItem FieldName="noofplates" ShowInGroupFooterColumn="noofplates" SummaryType="Sum" ValueDisplayFormat="0.00"  DisplayFormat="{0:N2}"/>
                                             <dx:ASPxSummaryItem FieldName="length_plate_cms" ShowInGroupFooterColumn="length_plate_cms" SummaryType="Sum" ValueDisplayFormat="0.00"  DisplayFormat="{0:N2}"/>
                                             <dx:ASPxSummaryItem FieldName="rate" ShowInGroupFooterColumn="rate" SummaryType="Sum" ValueDisplayFormat="0.00"  DisplayFormat="{0:N2}"/>
                                             <dx:ASPxSummaryItem FieldName="cms" ShowInGroupFooterColumn="cms" SummaryType="Sum" ValueDisplayFormat="0.00"  DisplayFormat="{0:N2}"/>
                                             <dx:ASPxSummaryItem FieldName="total" ShowInGroupFooterColumn="total" SummaryType="Sum" ValueDisplayFormat="0.00"  DisplayFormat="{0:N2}"/>

                                          </GroupSummary>
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
<tr>
    <td style="height:30px;"></td>
</tr>
            <!-- ASPxGridView2 and ASPxGridView3 side by side -->
<tr>
    <td align="left" class="style248">
        <table style="width:80%;">
            <tr>
                <!-- LEFT cell: Grid #2 -->
                <td style="width:30%; vertical-align: top;">
                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" 
                        EnableViewState="False"
                        OnCustomCallback="ASPxGridView2_CustomCallback" OnHeaderFilterFillItems="ASPxGridView2_HeaderFilter"
                        OnDataBinding="ASPxGridView2_DataBinding" Theme="Default"                         
                        Width="50%">
                        <SettingsBehavior ProcessSelectionChangedOnServer="True" AllowFocusedRow="True" />
                        <Settings ShowFooter="True" ShowFilterRow="True"  />
                        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" />
                        <SettingsPager Visible="false" />
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Summary" FieldName="summ" VisibleIndex="1" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left"  />
                            <dx:GridViewDataTextColumn Caption="Total" FieldName="totamt" VisibleIndex="2"  HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left"/>
                        </Columns>
                        <Styles>
                            <GroupRow Font-Bold="True" />
                            <Footer Font-Bold="True" />
                            <GroupFooter Font-Bold="True" />
                        </Styles>
                    </dx:ASPxGridView>
                </td>
                <!-- RIGHT cell: Grid #3 -->
                <td style="width:30%; vertical-align: top;">
                    <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" 
                        EnableViewState="False"
                        OnCustomCallback="ASPxGridView3_CustomCallback" OnHeaderFilterFillItems="ASPxGridView3_HeaderFilter"
                        OnDataBinding="ASPxGridView3_DataBinding" Theme="Default"                         
                        Width="50%">
                        <SettingsBehavior ProcessSelectionChangedOnServer="True" AllowFocusedRow="True" />
                        <Settings  ShowFooter="True" ShowFilterRow="True"  />
                        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" />
                        <SettingsPager PageSize="31" visible="false" />
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Date" FieldName="Date" VisibleIndex="1" HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left"  />
                            <dx:GridViewDataTextColumn Caption="Total" FieldName="totamt" VisibleIndex="2"  HeaderStyle-HorizontalAlign="Left" CellStyle-HorizontalAlign="Left"/>
                        </Columns>
                        <Styles>
                            <GroupRow Font-Bold="True" />
                            <Footer Font-Bold="True" />
                            <GroupFooter Font-Bold="True" />
                        </Styles>
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </td>
</tr>
            <!-- Bottom Label -->
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

