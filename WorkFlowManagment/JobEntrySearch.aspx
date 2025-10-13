<%@ Page Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="JobEntrySearch.aspx.vb" Inherits="JobEntrySearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <div class="col-12">
            <div class="row page-titles">
                <div class="col-md-5 align-self-center">
                    <h4 class="text-themecolor">Job Entry Form  </h4>
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
                            <label class="infolbl">Part of Job Id</label>
                            <asp:TextBox ID="txtJobId" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="infolbl">Part of Job Name</label>
                            <asp:TextBox ID="txtJobName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="infolbl">Part of Internal Code</label>
                            <asp:TextBox ID="txtInternalCode" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="infolbl">Priority</label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlprioirty" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl ">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Normal</asp:ListItem>
                                        <asp:ListItem>Urgent</asp:ListItem>
                                        <asp:ListItem>Most Urgent</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-3">
                            <label class="infolbl">Assigned To</label>
                            <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlassignedto" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl ">
                                        <asp:ListItem></asp:ListItem>

                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-3">
                            <label class="infolbl">Customer Name</label>
                            <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlcuscode" runat="server" Theme="Metropolis" AutoPostBack="true" Style="width: 100%" CssClass="form-control searchableddl">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="col-md-3">
                            <label class="infolbl">Job Creation Date</label>
                            <asp:TextBox ID="txtjobcreatedt" runat="server" autocomplete="off" CssClass="form-control input-sm "></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtjobcreatedt_Date" runat="server" Mask="99/99/9999" MaskType="Date" PromptCharacter="_" TargetControlID="txtjobcreatedt" />
                            <asp:CalendarExtender ID="txtjobcreatedt_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtjobcreatedt">
                            </asp:CalendarExtender>
                        </div>

                        <div class="col-md-3">
                            <label class="infolbl">Ticket No</label>
                            <asp:TextBox ID="txtticketno" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>

                        <%--<div class="col-md-12">
                        <label class="infolbl">Search</label>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>--%>
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
                                    EnableViewState="True" KeyFieldName="jobid"
                                    OnCustomCallback="ASPxGridView1_CustomCallback"
                                    OnCustomBindingGetDataRowCount="GridViewLST_CustomBindingGetDataRowCount"
                                    OnCustomBindingGetData="GridViewLST_CustomBindingGetData"
                                    Theme="Metropolis"
                                    Width="100%">
                                    <SettingsBehavior AllowFocusedRow="True" ProcessSelectionChangedOnServer="True" />
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
                                        <dx:GridViewDataTextColumn Caption="Job ID" FieldName="jobid"
                                            VisibleIndex="1" Width="200px">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Job Name " FieldName="jobname"
                                            VisibleIndex="2">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Customer " FieldName="cusname"
                                            VisibleIndex="3">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="INT Code " FieldName="intcode"
                                            VisibleIndex="4">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Rev" FieldName="revno"
                                            VisibleIndex="5">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Priority" FieldName="prioirty"
                                            VisibleIndex="6">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Printing Type" FieldName="printname"
                                            VisibleIndex="7">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                          <dx:GridViewDataTextColumn Caption="Ticket No" FieldName="ticketno"
                                            VisibleIndex="7">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Date & Time" FieldName="jobcreatedt"
                                            VisibleIndex="8">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Date" FieldName="jobcreatedt1"
                                            VisibleIndex="8">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Assign To" FieldName="assignedname"
                                            VisibleIndex="8">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Assign To Graphics" FieldName="assignedname_appfromgraphics"
                                            VisibleIndex="8">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Assign To Prepress" FieldName="assignedname_apptoprepress"
                                            VisibleIndex="8">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="Status" FieldName="status"
                                            VisibleIndex="8">
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

