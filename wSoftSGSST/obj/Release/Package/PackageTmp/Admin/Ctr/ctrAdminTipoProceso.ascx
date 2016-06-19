<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrAdminTipoProceso.ascx.vb" Inherits="wSoftCentroErgonomia.ctrAdminTipoProceso" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Admin/Ctr/ctrAdminProceso.ascx" TagPrefix="uc1" TagName="ctrAdminProceso" %>


<asp:UpdatePanel ID="upnlTipoProceso" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlGvTipoProceso" runat="server">
                        <asp:GridView ID="gvTipoProceso" runat="server" AutoGenerateColumns="False" DataSourceID="odsTipoProceso" DataKeyNames="etprIdTipoProceso" CssClass="gvGeneral">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="etprIdTipoProceso" SortExpression="etprIdTipoProceso" />
                                <asp:BoundField HeaderText="Nombre" DataField="etprNombre" SortExpression="etprNombre" />
                                <asp:BoundField HeaderText="Estado" DataField="StrEstado" SortExpression="StrEstado" />
                                <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" HeaderText="Editar" Text="Editar" ImageUrl="~/Images/Botones/imBtnEditar.fw.png" />
                                <asp:ButtonField ButtonType="Image" CommandName="cmdVerProcesos" HeaderText="Ver Procesos" Text="Ver" ImageUrl="~/Images/Botones/imBtnVerGral.fw.png" />
                            </Columns>
                        </asp:GridView>
                        <asp:DropDownList ID="ddlNumPagTipoProceso" runat="server">
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>80</asp:ListItem>
                            <asp:ListItem>200</asp:ListItem>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsTipoProceso" runat="server" SelectMethod="GetTblTipoProcesoXEmpresaYEstado" TypeName="dllSoftCentroErgonomia.Empresa.clEmpTipoProceso">
                            <SelectParameters>
                                <asp:Parameter Name="parIdEmpresa" Type="Int32" />
                                <asp:Parameter Name="parIdEstado" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Tipo Proceso" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlProceso" runat="server">
                        <uc1:ctrAdminProceso runat="server" ID="ctrAdminProceso" />
                    </asp:Panel>
                </td>
            </tr>
        </table>

        <%--VENTANA MODAL INFORMACION TIPO PROCESO--%>
        <asp:ModalPopupExtender ID="ModalInfoTipoProceso" runat="server" BackgroundCssClass="cssBackGroundModal"
            Enabled="True" PopupControlID="pnlInfoTipoProceso" TargetControlID="btnFake">
        </asp:ModalPopupExtender>
        <asp:Button ID="btnFake" runat="server" Text="Fake" Style="display: none" />
        <asp:Panel ID="pnlInfoTipoProceso" CssClass="ModalPoup" runat="server" Style="display: none">
            <asp:UpdatePanel ID="upnlInfoTipoProceso" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Text="(*)"></asp:Label>
                                <asp:Label ID="lblNomTipoProc" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTipoProceso" runat="server"></asp:TextBox>
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
