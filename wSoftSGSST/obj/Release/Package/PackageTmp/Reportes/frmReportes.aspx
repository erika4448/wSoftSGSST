<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstCentroErgonomia.Master" CodeBehind="frmReportes.aspx.vb" Inherits="wSoftCentroErgonomia.frmReportes" %>

<%@ Register Src="Ctr/ctrRptTiempoXTipoProceso.ascx" TagName="ctrRptTiempoXTipoProceso" TagPrefix="uc1" %>
<%@ Register Src="Ctr/ctrRptTiempoXProceso.ascx" TagName="ctrRptTiempoXProceso" TagPrefix="uc2" %>
<%@ Register Src="Ctr/ctrEmpSedeDep.ascx" TagName="ctrEmpSedeDep" TagPrefix="uc3" %>
<%@ Register Src="Ctr/ctrRptTiempoAdicXCargo.ascx" TagName="ctrRptTiempoAdicXCargo" TagPrefix="uc4" %>
<%@ Register Src="Ctr/ctrGrfTiempoInvAnualXTipoProc.ascx" TagName="ctrGrfTiempoInvAnualXTipoProc" TagPrefix="uc5" %>
<%@ Register Src="Ctr/ctrRptActividades.ascx" TagName="ctrRptActividades" TagPrefix="uc6" %>
<%@ Register Src="Ctr/ctrRptSobrecargaXCargo.ascx" TagName="ctrRptSobrecargaXCargo" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <asp:UpdatePanel ID="upnlReportes" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlConsulta" runat="server" CssClass="pnlAgrupadorGral">
                            <table align="center">
                                <tr>
                                    <td align="left" colspan="3">
                                        <uc3:ctrEmpSedeDep ID="ctrEmpSedeDep1" runat="server" />
                                    </td>
                                </tr>
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
                                                                <asp:Label ID="lblTipoReporte" runat="server" Text="Reporte"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlTipoReporte" runat="server">
                                                        <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                        <asp:ListItem Value="5">Actividades</asp:ListItem>
                                                        <asp:ListItem Value="6">Sobrecarga por Cargo</asp:ListItem>
                                                        <asp:ListItem Value="4">Tiempo Invertido Anual por Tipo Proceso</asp:ListItem>
                                                        <asp:ListItem Value="2">Tiempo por Proceso</asp:ListItem>
                                                        <asp:ListItem Value="1">Tiempo por Tipo Proceso</asp:ListItem>
                                                        <asp:ListItem Value="3">Tiempos Adicionales por Cargo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" class="tdSeparacion"></td>
                                    <td align="left" class="tdColFormulario"></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="3">
                                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CausesValidation="False" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlRptTiempoXTipoProceso" runat="server">
                            <uc1:ctrRptTiempoXTipoProceso ID="ctrRptTiempoXTipoProceso1" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="pnlRptTiempoXProceso" runat="server">
                            <uc2:ctrRptTiempoXProceso ID="ctrRptTiempoXProceso1" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="pnlRptTiempoAdicXCargo" runat="server">
                            <uc4:ctrRptTiempoAdicXCargo ID="ctrRptTiempoAdicXCargo1" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="pnlGrfTiempoInvAnualXTipoProc" runat="server">
                            <uc5:ctrGrfTiempoInvAnualXTipoProc ID="ctrGrfTiempoInvAnualXTipoProc1" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="pnlRptActividades" runat="server">
                            <uc6:ctrRptActividades ID="ctrRptActividades1" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="pnlRptSobrecargaXCargo" runat="server">
                            <uc7:ctrRptSobrecargaXCargo ID="ctrRptSobrecargaXCargo1" runat="server" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnBuscar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
