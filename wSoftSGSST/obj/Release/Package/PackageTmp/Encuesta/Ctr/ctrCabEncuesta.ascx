<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrCabEncuesta.ascx.vb" Inherits="wSoftCentroErgonomia.ctrCabEncuesta" %>
<%@ Register Src="../../Comun/Ctr/ctrBusEmpleadoXTipYNumDoc.ascx" TagName="ctrBusEmpleadoXTipYNumDoc" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

<asp:UpdatePanel ID="upnlCabEncuesta" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlBusquedaEmpleado" runat="server">
                        <uc1:ctrBusEmpleadoXTipYNumDoc ID="ctrBusEmpleadoXTipYNumDoc1" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pnlCabEncuesta" runat="server" CssClass="pnlAgrupadorGral">
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblValNombreEmp" runat="server"></asp:Label>
                                </td>
                                <td align="left"></td>
                                <td align="left">
                                    <asp:Label ID="Label2" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblNumDoc" runat="server" Text="C.C."></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblValNumDocEmp" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblValFecha" runat="server"></asp:Label>
                                </td>
                                <td align="left"></td>
                                <td align="left">
                                    <asp:Label ID="Label4" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblSede" runat="server" Text="Sede"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblValSede" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblCargo" runat="server" Text="Cargo"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCargo" runat="server"></asp:TextBox>
                                </td>
                                <td align="left"></td>
                                <td align="left">
                                    <asp:Label ID="Label6" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblArea" runat="server" Text="Área"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label7" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblTiempoCargo" runat="server" Text="Tiempo en el cargo"></asp:Label>
                                </td>
                                <td align="left">
                                    <table align="left" cellpadding="0">
                                        <tr>
                                            <td align="left">
                                                <asp:TextBox ID="txtTiempoCargo" runat="server" Width="50px"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txtTiempoCargo_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtTiempoCargo">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlTiempoCargo" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left"></td>
                                <td align="left"></td>
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label8" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblNivelEscolaridad" runat="server" Text="Nivel Escolaridad"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlNivelEscolaridad" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="left"></td>
                                <td align="left">
                                    <asp:Label ID="Label9" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblUltimoTitulo" runat="server" Text="Último título  alcanzado"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtUltTitulo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
