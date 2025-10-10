<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="CustomerSearch.aspx.vb" Inherits="CustomerSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Customer Master</h4>
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
                        </div>
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-3">
                        </div>
                          <div class="col-md-3">
                        </div>
                          <div class="col-md-3">
                        </div>
                          <div class="col-md-3">
                        
                        </div>
                    </div>
                    <div class="col-sm-2  text-right">

                        <asp:UpdatePanel ID="UpdatePanel86" runat="server">
                            <ContentTemplate>
                                <div class="d-flex justify-content-start align-items-start" style="padding-bottom: 3px">

                                    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-info m-l-15" Style="width: 100%"><i class="fa fa-search"></i>&nbsp;Search</asp:LinkButton>

                                    <%--                        <button type="submit" href="#" class="btn btn-info d-none d-lg-block m-l-15" style="width: 100%"><i class="fa fa-search"></i>Search</button>--%>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div>
                            <div class="d-flex justify-content-start align-items-start">
                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-info m-l-15" Style="width: 100%"> <i class="fa fa-plus-circle"></i>&nbsp;New</asp:LinkButton>
                                <%--                        <a type="button" href="#" class="btn btn-info d-none d-lg-block m-l-15" style="width: 100%"><i class="fa fa-plus-circle"></i>New</a>--%>
                            </div>
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
                                            EnableViewState="False" KeyFieldName="cuscode" ClientInstanceName="grid" CssClass="gridFixedHeight"
                                            OnCustomCallback="ASPxGridView1_CustomCallback" 
                                            OnDataBinding="ASPxGridView1_DataBinding" Theme="Metropolis" 
                                            Width="100%">
                                   

                                  <Toolbars>
                                        <dx:GridViewToolbar EnableAdaptivity="true">
                                            <Items>
                                                <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Export To Excel" />
                                          
                                            </Items>
                                        </dx:GridViewToolbar>
                                    </Toolbars>
                                                   <SettingsBehavior EnableCustomizationWindow="true" />

                                            <SettingsBehavior AllowFocusedRow="True" ProcessSelectionChangedOnServer="True" />
                               <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" />

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
                                                <dx:GridViewDataTextColumn Caption="Customer Code" FieldName="cuscode" 
                                                    VisibleIndex="1" Width="200px" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Customer Name " FieldName="cusname" 
                                                    VisibleIndex="2">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="City " FieldName="cityname" 
                                                    VisibleIndex="3">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="State " FieldName="statename" 
                                                    VisibleIndex="4">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Country" FieldName="countryname" 
                                                    VisibleIndex="5">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </dx:GridViewDataTextColumn>

                                                 <dx:GridViewDataTextColumn Caption="Gst NO" FieldName="Gstno" 
                                                    VisibleIndex="6">
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

