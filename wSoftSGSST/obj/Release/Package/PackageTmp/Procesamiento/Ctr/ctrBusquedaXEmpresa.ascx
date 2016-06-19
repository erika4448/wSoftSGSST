<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrBusquedaXEmpresa.ascx.vb" Inherits="wSoftCentroErgonomia.ctrBusquedaXEmpresa" %>
<%@ Register Src="../../Comun/Ctr/ctrBusquedaProcedimiento.ascx" TagName="ctrBusquedaProcedimiento" TagPrefix="uc1" %>
<%@ Register Src="../../Comun/Ctr/ctrBusquedaActividad.ascx" TagName="ctrBusquedaActividad" TagPrefix="uc2" %>
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
            <asp:Panel ID="pnlTipoProceso" runat="server">
                <table cellpadding="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblTipoProceso" runat="server" Text="Tipo Proceso"></asp:Label></td>
                        <td align="left">
                            <asp:DropDownList ID="ddlTipoProceso" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <asp:Panel ID="pnlProceso" runat="server">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblProceso" runat="server" Text="Proceso"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlProceso" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td align="left"></td>
        <td align="left">
            <asp:Panel ID="pnlProcedimiento" runat="server">
                <uc1:ctrBusquedaProcedimiento ID="ctrBusquedaProcedimiento1" runat="server" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <asp:Panel ID="pnlActividad" runat="server">
                <uc2:ctrBusquedaActividad ID="ctrBusquedaActividad1" runat="server" />
            </asp:Panel>
        </td>
        <td align="left"></td>
        <td align="left">
            <asp:Panel ID="pnlCargo" runat="server">
                <uc3:ctrBusquedaCargo ID="ctrBusquedaCargo1" runat="server" />

            </asp:Panel>
        </td>
    </tr>
</table>
