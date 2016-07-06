<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrFecha.ascx.vb" Inherits="wSoftSGSST.ctrFecha" %>


<link href="../../App_Themes/skDefault/InfopMaster.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="txtFecha" runat="server" Width="100px" 
    AutoCompleteType="Disabled" AutoPostBack="True"></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="txtFecha_CalExt" runat="server" Enabled="True" Format="dddd,dd/MMMM/yyyy" TargetControlID="txtFecha">
</ajaxToolkit:CalendarExtender>
<ajaxToolkit:TextBoxWatermarkExtender ID="txtFecha_TxtBWE" runat="server" Enabled="True" TargetControlID="txtFecha" WatermarkText="dddd,dd/MMMM/yyyy">
</ajaxToolkit:TextBoxWatermarkExtender>
<%--<asp:CustomValidator ID="cvFechaRango" runat="server" ErrorMessage="Rango de Fecha superior a 1900 e inferior a 2100" ControlToValidate="txtFecha" onservervalidate="esValidoRangoFecha" Display="Dynamic" >*</asp:CustomValidator>--%>