<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DiagnosticTreeviewRights.aspx.vb" Inherits="DiagnosticTreeviewRights" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>TreeviewRights Diagnostic</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        table { border-collapse: collapse; width: 100%; margin-top: 20px; }
        th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        th { background-color: #4CAF50; color: white; }
        tr:nth-child(even) { background-color: #f2f2f2; }
        .info { background-color: #e7f3fe; border-left: 6px solid #2196F3; padding: 10px; margin-bottom: 15px; }
        .warning { background-color: #fff3cd; border-left: 6px solid #ffc107; padding: 10px; margin-bottom: 15px; }
        .error { background-color: #f8d7da; border-left: 6px solid #dc3545; padding: 10px; margin-bottom: 15px; }
        .success { background-color: #d4edda; border-left: 6px solid #28a745; padding: 10px; margin-bottom: 15px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>TreeviewRights Table Diagnostic</h1>
        
        <asp:Panel ID="pnlResults" runat="server">
            <asp:Literal ID="litResults" runat="server"></asp:Literal>
        </asp:Panel>
    </form>
</body>
</html>
