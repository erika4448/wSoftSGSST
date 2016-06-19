<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrBusquedaProcesaEmpleado.ascx.vb" Inherits="wSoftCentroErgonomia.ctrBusquedaProcesaEmpleado" %>
<%@ Register Src="../../Comun/Ctr/ctrBusquedaCargo.ascx" TagName="ctrBusquedaCargo" TagPrefix="uc3" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />
<table align="center">
    <tr>
        <td align="left" colspan="2">
            <table>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label1" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                        <asp:Label ID="lblEmpresa" runat="server" Text="Empresa"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
        <td align="left"></td>
        <td align="left">
            <asp:Panel ID="pnlCargo" runat="server">
                <uc3:ctrBusquedaCargo ID="ctrBusquedaCargo1" runat="server" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <asp:Panel ID="pnlSede" runat="server">
                <table cellpadding="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblSede" runat="server" Text="Sede"></asp:Label></td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSede" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td align="left"></td>
        <td align="left">
            <asp:Panel ID="pnlArea" runat="server">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblArea" runat="server" Text="Área"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlArea" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
