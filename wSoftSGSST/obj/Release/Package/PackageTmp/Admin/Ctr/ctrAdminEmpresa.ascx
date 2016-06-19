<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrAdminEmpresa.ascx.vb" Inherits="wSoftCentroErgonomia.ctrAdminEmpresa" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

<asp:UpdatePanel ID="upnlEmpresa" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlGvNivelOrganiza" runat="server">
                        <table align="center">
                            <tr>
                                <td align="right">
                                    <table>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:ImageButton ID="ibtnAgregar" runat="server" ImageUrl="~/Images/Botones/imBtnAgregar.fw.png" CausesValidation="False" />
                                                <asp:ImageButton ID="ibtnEditar" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/imBtnEditar.fw.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>

        <%--VENTANA MODAL INFORMACION EMPRESA--%>
        <asp:ModalPopupExtender ID="ModalInfoEmpresa" runat="server" BackgroundCssClass="cssBackGroundModal"
            Enabled="True" PopupControlID="pnlInfoEmpresa" TargetControlID="btnFake">
        </asp:ModalPopupExtender>
        <asp:Button ID="btnFake" runat="server" Text="Fake" Style="display: none" />
        <asp:Panel ID="pnlInfoEmpresa" CssClass="ModalPoup" runat="server" >
            <asp:UpdatePanel ID="upnlInfoEmpresa" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lbl" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                <asp:Label ID="lblNomEmpresa" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lbl0" runat="server" CssClass="lblValidador" Text="(*)"></asp:Label>
                                <asp:Label ID="lblHorasBase" runat="server" Text="Horas Base"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtHorasBase" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left"></td>
                            <td align="left"></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnGuardar" runat="server" CausesValidation="False" Text="Guardar" />
                                <asp:Button ID="btnCerrar" runat="server" CausesValidation="False" Text="Cerrar" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
