<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrPaisCiudadDep.ascx.vb" Inherits="wSoftSGSST.ctrPaisCiudadDep" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../App_Themes/SoftSGSST.css" />
<%end if%>
<table>
    <tr>
        <td align="left" class="tdLabel">
            <asp:Label ID="lblPais" runat="server" Text="País"></asp:Label>
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <asp:Panel ID="pnlCiudad" runat="server">
        <tr>
            <td align="left" class="tdLabel">
                 <asp:Label ID="lblCiudad" runat="server" Text="Ciudad"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlCiudad" runat="server">
            </asp:DropDownList>
            </td>
        </tr>
    </asp:Panel>
</table>
