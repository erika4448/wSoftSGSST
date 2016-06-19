<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrEmpSedeDep.ascx.vb" Inherits="wSoftCentroErgonomia.ctrEmpSedeDep" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />
<table width="100%">
    <tr>
        <td align="left" class="tdColFormulario">
            <table width="100%" cellpadding="0">
                <tr>
                    <td align="left" class="tdEtiquetalLabelInfo">
                        <table>
                            <tr>
                                <td align="left" style="margin-left: 5px; width: 10px;">
                                    <asp:Label ID="Label1" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblEmpresa" runat="server" Text="Empresa"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEmpresa" runat="server" CausesValidation="True" AutoPostBack="True"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
        <td align="left" class="tdSeparacion"></td>
        <td align="left" class="tdColFormulario">
            <asp:Panel ID="pnlSede" runat="server">
                <table width="100%" cellpadding="0">
                    <tr>
                        <td align="left" class="tdEtiquetalLabelInfo">
                            <table>
                                <tr>
                                    <td align="left" style="margin-left: 5px; width: 10px;">
                                        <asp:Label ID="Label2" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSede" runat="server" Text="Sede"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSede" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
