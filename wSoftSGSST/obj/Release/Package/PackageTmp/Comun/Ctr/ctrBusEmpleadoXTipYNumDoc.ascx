<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrBusEmpleadoXTipYNumDoc.ascx.vb" Inherits="wSoftCentroErgonomia.ctrBusEmpleadoXTipYNumDoc" %>
<asp:Panel ID="pnlBusEmpleado" runat="server">
    <table align="center">
        <tr>
            <td align="left">
                <asp:Label ID="lblTipoDic" runat="server" Text="Tipo Documento"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlTipoDoc" runat="server"></asp:DropDownList>
            </td>
            <td align="left">
                
            </td>
            <td align="left">
                <asp:Label ID="lblNumDoc" runat="server" Text="Número Documento"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtNumDoc" runat="server"></asp:TextBox>
            </td>
            <td align="left">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CausesValidation="False" />
            </td>
        </tr>
    </table>
</asp:Panel>