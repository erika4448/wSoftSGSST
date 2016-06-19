<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrAdminProceso.ascx.vb" Inherits="wSoftCentroErgonomia.ctrAdminProceso" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Admin/Ctr/ctrAdminProcedimiento.ascx" TagPrefix="uc1" TagName="ctrAdminProcedimiento" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

<asp:UpdatePanel ID="upnlProceso" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlGvProceso" runat="server">
                        <table align="center">
                            <tr>
                                <td align="right">
                                    <table>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblProceso" runat="server" Text="Proceso"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtBusProceso" runat="server"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CausesValidation="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                                            <asp:GridView ID="gvProceso" runat="server" AutoGenerateColumns="False" DataSourceID="odsProceso" DataKeyNames="eprcIdProceso" CssClass="gvGeneral">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="eprcIdProceso" SortExpression="eprcIdProceso" />
                                <asp:BoundField HeaderText="Nombre" DataField="eprcNombre" SortExpression="eprcNombre" />
                                <asp:BoundField HeaderText="Estado" DataField="StrEstado" SortExpression="StrEstado" />
                                <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" HeaderText="Editar" Text="Editar" ImageUrl="~/Images/Botones/imBtnEditar.fw.png" />
                                <asp:ButtonField ButtonType="Image" CommandName="cmdVerProcedimientos" HeaderText="Ver Procedimientos" Text="Ver" ImageUrl="~/Images/Botones/imBtnVerGral.fw.png" />
                            </Columns>
                        </asp:GridView>
                        <asp:DropDownList ID="ddlNumPagProceso" runat="server">
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>80</asp:ListItem>
                            <asp:ListItem>200</asp:ListItem>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsProceso" runat="server" SelectMethod="GetTblTipoProcesoXTipoProcStrProcYEst" TypeName="dllSoftCentroErgonomia.Empresa.clEmpProceso">
                            <SelectParameters>
                                <asp:Parameter Name="parIdTipoProceso" Type="Int32" />
                                <asp:Parameter Name="parStrProceso" Type="String" />
                                <asp:Parameter Name="parIdEstado" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Proceso" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlProcedimiento" runat="server">
                        <uc1:ctrAdminProcedimiento runat="server" ID="ctrAdminProcedimiento" />
                    </asp:Panel>
                </td>
            </tr>
        </table>

        <%--VENTANA MODAL INFORMACION PROCESO--%>
        <asp:ModalPopupExtender ID="ModalInfoProceso" runat="server" BackgroundCssClass="cssBackGroundModal"
            Enabled="True" PopupControlID="pnlInfoProceso" TargetControlID="btnFake">
        </asp:ModalPopupExtender>
        <asp:Button ID="btnFake" runat="server" Text="Fake" Style="display: none" />
        <asp:Panel ID="pnlInfoProceso" CssClass="ModalPoup" runat="server" Style="display: none">
            <asp:UpdatePanel ID="upnlInfoProceso" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Text="(*)"></asp:Label>
                                <asp:Label ID="lblNomTipoProc" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            </td>
                            <td align="left"></td>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Text="(*)"></asp:Label>
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
                            <td align="left"></td>
                            <td align="left"></td>
                            <td align="left"></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="5">
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
