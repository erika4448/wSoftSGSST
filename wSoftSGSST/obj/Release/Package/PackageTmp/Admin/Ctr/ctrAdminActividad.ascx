<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrAdminActividad.ascx.vb" Inherits="wSoftCentroErgonomia.ctrAdminActividad" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

<asp:UpdatePanel ID="upnlActividad" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlGvActividad" runat="server">
                        <table align="center">
                            <tr>
                                <td align="right">
                                    <table>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblActividad" runat="server" Text="Actividad"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtBusActividad" runat="server"></asp:TextBox>
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
                                    <asp:GridView ID="gvActividad" runat="server" AutoGenerateColumns="False" DataSourceID="odsActividad" DataKeyNames="eactIdActividad" CssClass="gvGeneral">
                                        <Columns>
                                            <asp:BoundField HeaderText="ID" DataField="eactIdActividad" SortExpression="eactIdActividad" />
                                            <asp:BoundField HeaderText="Código" DataField="eactCodigo" SortExpression="eactCodigo" />
                                            <asp:BoundField HeaderText="Nombre" DataField="eactNombre" SortExpression="eactNombre" />
                                            <asp:BoundField HeaderText="Estado" DataField="StrEstado" SortExpression="StrEstado" />
                                            <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" HeaderText="Editar" Text="Editar" ImageUrl="~/Images/Botones/imBtnEditar.fw.png" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:DropDownList ID="ddlNumPagActividad" runat="server">
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>40</asp:ListItem>
                                        <asp:ListItem>80</asp:ListItem>
                                        <asp:ListItem>200</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsActividad" runat="server" SelectMethod="GetTblActividadXIdProcedimiento" TypeName="dllSoftCentroErgonomia.Empresa.clEmpActividad">
                                        <SelectParameters>
                                            <asp:Parameter Name="parIdProcedimiento" Type="Int32" />
                                            <asp:Parameter Name="parStrCriConsulta" Type="String" />
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
                    <asp:Button ID="btnNuevo" runat="server" Text="Nueva Actividad" CausesValidation="False" />
                </td>
            </tr>
        </table>

        <%--VENTANA MODAL INFORMACION ACTIVIDAD--%>
        <asp:ModalPopupExtender ID="ModalInfoActividad" runat="server" BackgroundCssClass="cssBackGroundModal"
            Enabled="True" PopupControlID="pnlInfoActividad" TargetControlID="btnFake">
        </asp:ModalPopupExtender>
        <asp:Button ID="btnFake" runat="server" Text="Fake" Style="display: none" />
        <asp:Panel ID="pnlInfoActividad" CssClass="ModalPoup" runat="server" Style="display: none">
            <asp:UpdatePanel ID="upnlInfoActividad" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label3" runat="server" Text="(*)"></asp:Label>
                                <asp:Label ID="lblCodActividad" runat="server" Text="Código"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                            </td>
                            <td align="left"></td>
                            <td align="left">
                                <asp:Label ID="lbl" runat="server" Text="(*)"></asp:Label>
                                <asp:Label ID="lblNomActividad" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5">
                                <asp:Label ID="Label1" runat="server" Text="(*)"></asp:Label>
                                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5">
                                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Height="86px" Width="446px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Text="(*)"></asp:Label>
                                <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="left"></td>
                            <td align="left"></td>
                            <td align="left"></td>
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
