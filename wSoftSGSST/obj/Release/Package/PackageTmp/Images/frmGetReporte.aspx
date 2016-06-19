<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmGetReporte.aspx.vb" Inherits="wSoftCentroErgonomia.frmGetReporte" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div>
        <rsweb:ReportViewer ID="rpVisor" runat="server"></rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
