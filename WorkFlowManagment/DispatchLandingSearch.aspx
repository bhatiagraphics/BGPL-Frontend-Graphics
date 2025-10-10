<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="DispatchLandingSearch.aspx.vb" Inherits="DispatchLandingSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Dispatch Landing</h4>
                </div>
                <div class="col-md-7 align-self-center text-right">
                    <div class="d-flex justify-content-end align-items-center">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

        <div class="card" style="margin-bottom: 9px;">

            <div class="row  card-body">
                <div class="col-md-12 row align-self-center">
                    <div class="col-sm-10 row">
                        <div class="col-md-3">
                            <label class="infolbl">Plate Processed Date</label>
                            <asp:TextBox ID="txtplate_processed_date" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtplate_processed_date_Date" runat="server" Mask="99/99/9999" MaskType="Date" PromptCharacter="_" TargetControlID="txtplate_processed_date" />
                            <asp:CalendarExtender ID="txtplate_processed_date_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtplate_processed_date" TargetControlID="txtplate_processed_date">
                            </asp:CalendarExtender>
                        </div>
                        <div class="col-md-3">
                            <label class="infolbl">Company</label>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlcompcd" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl ">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-3">
                            <label class="infolbl">Customer</label>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlcuscode" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl ">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-3">
                            <label class="infolbl">Ship to</label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlshipto" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl ">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-3">
                            <label class="infolbl">Courier</label>
                            <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddltranscd" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl ">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                    <div class="col-sm-2  text-right">
                        <asp:UpdatePanel ID="UpdatePanel86" runat="server">
                            <ContentTemplate>
                                <div class="d-flex justify-content-start align-items-start" style="padding-top: 25px">
                                    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-info m-l-15" Style="width: 100%"><i class="fa fa-search"></i>&nbsp;Search</asp:LinkButton>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div>
                        </div>
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
                                    EnableViewState="False" KeyFieldName="jobid"
                                    OnCustomCallback="ASPxGridView1_CustomCallback"
                                    OnDataBinding="ASPxGridView1_DataBinding" Theme="Metropolis"
                                    Width="2500px">
                                      <Toolbars>
                                        <dx:GridViewToolbar EnableAdaptivity="true">
                                            <Items>
                                                <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Export To Excel" />
                                           
                                            </Items>
                                        </dx:GridViewToolbar>
                                    </Toolbars>


                                    <SettingsBehavior AllowFocusedRow="True" ProcessSelectionChangedOnServer="True" />
                               <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" />

                                    <Settings ShowFilterRow="True" ShowFooter="True" ShowGroupButtons="True"
                                        ShowGroupedColumns="False" ShowGroupFooter="VisibleAlways"
                                        ShowGroupPanel="False" ShowHeaderFilterButton="True" />
                                    <Settings ShowGroupFooter="VisibleAlways" />
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
                                        <dx:GridViewDataTextColumn Caption="Date" FieldName="plate_processed_date1"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="1" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Int Code" FieldName="intcode"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="3" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left"/>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Rev No" FieldName="revno"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="3" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left"/>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Challan No" FieldName="chlno"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="4" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Job Name " FieldName="jobname"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="5" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Plate Type" FieldName="platetypename"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="6" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Plate Length" FieldName="length_plate_cms"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="7" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Plate Width" FieldName="width_plate_cms"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="8" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Qty" FieldName="noofplates"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="9" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Client " FieldName="cusname"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="10" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Ship To " FieldName="cuscodeshiptoname"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="11" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Designer " FieldName="assignedname"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="12" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Courier " FieldName="transname"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="13" Width="350px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Company " FieldName="compname"  HeaderStyle-Wrap ="True"
                                            VisibleIndex="14" Width="350px">
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

    </div>
</asp:Content>

