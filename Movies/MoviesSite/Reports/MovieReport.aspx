<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieReport.aspx.cs" Inherits="MoviesSite.Reports.MovieReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h1>Movie Report</h1>        
            <%--<rsweb:ReportViewer ID="ReportViewer1" OnReportRefresh="ReportViewer1_ReportRefresh1"  runat="server" Width="800" Height="400"></rsweb:ReportViewer>
            --%>
        
        
    </div>  
    </form>
</body>
</html>
