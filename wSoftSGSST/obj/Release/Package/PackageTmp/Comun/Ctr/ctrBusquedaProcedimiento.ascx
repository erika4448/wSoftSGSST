<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrBusquedaProcedimiento.ascx.vb" Inherits="wSoftCentroErgonomia.ctrBusquedaProcedimiento" %>

<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="upnlProcedimiento" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlBusActividad" runat="server">
            <table align="left">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblProcedimiento" runat="server" Text="Procedimiento"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtProcedimientoBus" runat="server" Width="180px"></asp:TextBox>
                    </td>
                    <td align="left">
                        <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/Images/Botones/imBtnBuscar.fw.png" ToolTip="Buscar" />
                    </td>
                    <td align="left">
                        <asp:ImageButton ID="ibtnActualizar" runat="server" ImageUrl="~/Images/Botones/imBtnActualizar.fw.png" ToolTip="Actualizar" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
         <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
    </ContentTemplate>
</asp:UpdatePanel>
<%--VENTANA MODAL BUSQUEDA PROCEDIMIENTO--%>
<asp:ModalPopupExtender ID="ModalBusquedaProcedimiento" runat="server" BackgroundCssClass="cssBackGroundModal"
    Enabled="True" PopupControlID="pnlBusquedaProcedimiento" TargetControlID="btnFake">
</asp:ModalPopupExtender>
<asp:Button ID="btnFake" runat="server" Text="Fake" Style="display: none" />
<asp:Panel ID="pnlBusquedaProcedimiento" CssClass="ModalPoup" runat="server"  Style="display: none" >
    <asp:UpdatePanel ID="upnlBusquedaProcedimiento" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center">
                        <table align="center">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblBusProcedimiento" runat="server" Text="Procedimiento"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtProcedimientoBusInt" runat="server"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:ImageButton ID="ibtnBuscarInt" runat="server" ImageUrl="~/Images/Botones/imBtnBuscar.fw.png" />

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlGvProcedimiento" runat="server">
                            <asp:GridView ID="gvProcedimiento" runat="server" AutoGenerateColumns="False" DataSourceID="odsProcedimiento" DataKeyNames="eprdIdProcedimiento,eprdNombre" AllowPaging="True" AllowSorting="True" CssClass="gvGeneral">
                                <Columns>
                                    <asp:BoundField HeaderText="Nombre" DataField="eprdNombre" SortExpression="eprdNombre" />
                                </Columns>
                            </asp:GridView>
                            <asp:DropDownList ID="ddlNumPagProcedimiento" runat="server">
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>80</asp:ListItem>
                                <asp:ListItem>200</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsProcedimiento" runat="server" SelectMethod="GetTblProcedimientoXCriConsulta" TypeName="dllSoftCentroErgonomia.Empresa.clEmpProcedimiento">
                                <SelectParameters>
                                    <asp:Parameter Name="parIdEmpresa" Type="Int32" />
                                    <asp:Parameter Name="parIdProceso" Type="Int32" />
                                    <asp:Parameter Name="parStrCriConsulta" Type="String" />
                                    <asp:Parameter Name="parIdEstado" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnCerrar" runat="server" CausesValidation="False" Text="Cerrar" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
