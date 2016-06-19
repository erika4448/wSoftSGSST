<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrAdminUsuarios.ascx.vb" Inherits="wSoftCentroErgonomia.ctrAdminUsuarios" %>
<table>
    <tr>
        <td align="center">
            <asp:Panel ID="pnlGvUsuarios" runat="server">
                <table>
                    <tr>
                        <td align="right">
                            <table>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" Text="Buscar" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="False" DataSourceID="odsActividad" DataKeyNames="eactIdActividad">
                                <Columns>
                                    <asp:BoundField HeaderText="Usuario" DataField="eactCodigo" SortExpression="eactCodigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="eactNombre" SortExpression="eactNombre" />
                                    <asp:BoundField HeaderText="Estado" DataField="StrEstado" SortExpression="StrEstado" />
                                    <asp:ButtonField ButtonType="Button" CommandName="cmdEditar" HeaderText="Editar" Text="Editar" />
                                </Columns>
                            </asp:GridView>
                            <asp:DropDownList ID="ddlNumPagUsuario" runat="server">
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>80</asp:ListItem>
                                <asp:ListItem>200</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsUsuario" runat="server" SelectMethod="GetTblActividadXIdProcedimiento" TypeName="dllSoftCentroErgonomia.Empresa.clEmpActividad">
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
</table>
