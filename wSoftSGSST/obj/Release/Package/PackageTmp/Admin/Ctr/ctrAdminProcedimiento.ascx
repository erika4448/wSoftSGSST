<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrAdminProcedimiento.ascx.vb" Inherits="wSoftCentroErgonomia.ctrAdminProcedimiento" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Admin/Ctr/ctrAdminActividad.ascx" TagPrefix="uc1" TagName="ctrAdminActividad" %>


<asp:UpdatePanel ID="upnlProcedimiento" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlGvProcedimiento" runat="server">
                        <table align="center">
                            <tr>
                                <td align="right">
                                    <table>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblProcedimiento" runat="server" Text="Procedimiento"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtBusProcedimiento" runat="server"></asp:TextBox>
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
                                                            <asp:GridView ID="gvProcedimiento" runat="server" AutoGenerateColumns="False" DataSourceID="odsProcedimiento" DataKeyNames="eprdIdProcedimiento" CssClass="gvGeneral">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="eprdIdProcedimiento" SortExpression="eprdIdProcedimiento" />
                                <asp:BoundField HeaderText="Nombre" DataField="eprdNombre" SortExpression="eprdNombre" />
                                <asp:BoundField HeaderText="Estado" DataField="StrEstado" SortExpression="StrEstado" />
                                <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" HeaderText="Editar" Text="Editar" ImageUrl="~/Images/Botones/imBtnEditar.fw.png" />
                                <asp:ButtonField ButtonType="Image" CommandName="cmdVerActividades" HeaderText="Ver Actividades" Text="Ver" ImageUrl="~/Images/Botones/imBtnVerGral.fw.png" />
                            </Columns>
                        </asp:GridView>
                        <asp:DropDownList ID="ddlNumPagProcedimiento" runat="server">
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>80</asp:ListItem>
                            <asp:ListItem>200</asp:ListItem>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsProcedimiento" runat="server" SelectMethod="GetTblProcedimientoXIdProcStrProcYEst" TypeName="dllSoftCentroErgonomia.Empresa.clEmpProcedimiento">
                            <SelectParameters>
                                <asp:Parameter Name="parIdProceso" Type="Int32" />
                                <asp:Parameter Name="parStrProcedimiento" Type="String" />
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
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Procedimiento" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlActividad" runat="server">
                        <uc1:ctrAdminActividad runat="server" id="ctrAdminActividad" />
                    </asp:Panel>
                </td>
            </tr>
        </table>

        <%--VENTANA MODAL INFORMACION PROCEDIMIENTO--%>
        <asp:ModalPopupExtender ID="ModalInfoProcedimiento" runat="server" BackgroundCssClass="cssBackGroundModal"
            Enabled="True" PopupControlID="pnlInfoProcedimiento" TargetControlID="btnFake">
        </asp:ModalPopupExtender>
        <asp:Button ID="btnFake" runat="server" Text="Fake" Style="display: none" />
        <asp:Panel ID="pnlInfoProcedimiento" CssClass="ModalPoup" runat="server" Style="display: none">
            <asp:UpdatePanel ID="upnlInfoProcedimiento" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Text="(*)"></asp:Label>
                                <asp:Label ID="lblNomProcedimiento" runat="server" Text="Nombre"></asp:Label>
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
