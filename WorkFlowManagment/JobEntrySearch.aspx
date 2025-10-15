<%@ Page Language="VB" AutoEventWireup="false" CodeFile="JobEntrySearch.aspx.vb" Inherits="WorkFlowManagement_JobEntrySearch" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Job Entry Form</title>
    <style>
        /* Tiny overlay while loading */
        .loading-overlay {
            position: fixed;
            inset: 0;
            background: rgba(255,255,255,.65);
            display: flex;
            align-items: center;
            justify-content: center;
            z-index: 9999;
            font: 600 15px/1.2 system-ui, -apple-system, Segoe UI, Roboto, Arial;
            color: #333;
        }
        .spinner {
            width: 26px;height: 26px;
            border: 3px solid #ddd;
            border-top-color: #0ea5e9;
            border-radius: 50%;
            animation: spin .9s linear infinite;
            margin-right:10px;
        }
        @keyframes spin { to { transform: rotate(360deg);} }

        .table { width: 100%; border-collapse: collapse; }
        .table th, .table td { border: 1px solid #e5e7eb; padding: 8px; }
        .table th { background:#f3f4f6; white-space:nowrap; }
        .text-right { text-align:right; }
        .muted { color:#6b7280; }
        .error { color:#b91c1c; margin:8px 0; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="sm" />
        
        <!-- Small loading indicator -->
        <asp:UpdateProgress runat="server" ID="updProg" DisplayAfter="150">
            <ProgressTemplate>
                <div class="loading-overlay">
                    <div class="spinner"></div>
                    <div>Loading, please wait…</div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel runat="server" ID="updMain" UpdateMode="Conditional">
            <ContentTemplate>

                <!-- (Keep your existing filter UI above if you already had it on the page) -->
                <div style="margin:8px 0;">
                    <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
                </div>

                <!-- Errors (if any) -->
                <asp:Label ID="lblError" runat="server" CssClass="error" Visible="false" />

                <!-- Grid -->
                <asp:GridView ID="gvJobs"
                              runat="server"
                              CssClass="table"
                              AutoGenerateColumns="False"
                              AllowPaging="True"
                              PageSize="50"
                              OnPageIndexChanging="gvJobs_PageIndexChanging"
                              DataKeyNames="jobid"
                              PagerSettings-Mode="Numeric"
                              PagerStyle-CssClass="text-right">

                    
                    <Columns>
                        <asp:BoundField DataField="jobid" HeaderText="Job ID" />
                        <asp:BoundField DataField="jobname" HeaderText="Job Name" />
                        <asp:BoundField DataField="cusname" HeaderText="Customer" />
                        <asp:BoundField DataField="intcode" HeaderText="INT Code" />
                        <asp:BoundField DataField="revno" HeaderText="Rev" />
                        <asp:BoundField DataField="priority" HeaderText="Priority" />
                        <asp:BoundField DataField="printingtype" HeaderText="Printing Type" />
                        <asp:BoundField DataField="ticketno" HeaderText="Ticket No" />
                        <asp:BoundField DataField="jobcreatedt" HeaderText="Date &amp; Time" 
                            DataFormatString="{0:dd/MM/yyyy HH:mm}" HtmlEncode="False" />
                        <asp:BoundField DataField="startdate" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                        <asp:BoundField DataField="assignto" HeaderText="Assign To" />
                        <asp:BoundField DataField="assigntographics" HeaderText="Assign To Graphics" />
                        <asp:BoundField DataField="assigntoprepress" HeaderText="Assign To Prepress" />
                        <asp:BoundField DataField="status" HeaderText="Status" />
                    </Columns>
                </asp:GridView>

                <div class="muted" style="margin-top:6px;">
                    Page size: 50&nbsp;&nbsp;|&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblTotal" />
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
