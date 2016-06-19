<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrBusquedaCargo.ascx.vb" Inherits="wSoftCentroErgonomia.ctrBusquedaCargo" %>

<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="upnlCargo" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlBusCargo" runat="server">
            <table align="left">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblCargo" runat="server" Text="Cargo"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCargoBus" runat="server" Width="180px"></asp:TextBox>
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
<%--VENTANA MODAL BUSQUEDA CARGO--%>
<asp:ModalPopupExtender ID="ModalBusquedaCargo" runat="server" BackgroundCssClass="cssBackGroundModal"
    Enabled="True" PopupControlID="pnlBusquedaCargo" TargetControlID="btnFake">
</asp:ModalPopupExtender>
<asp:Button ID="btnFake" runat="server" Text="Fake" Style="display: none" />
<asp:Panel ID="pnlBusquedaCargo" CssClass="ModalPoup" runat="server" Style="display: none">
    <asp:UpdatePanel ID="upnlBusquedaCargo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center">
                        <table align="center">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblBusCargo" runat="server" Text="Cargo"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCargoBusInt" runat="server"></asp:TextBox>
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
                        <asp:Panel ID="pnlGvCargo" runat="server">
                            <asp:GridView ID="gvCargo" runat="server" AutoGenerateColumns="False" DataSourceID="odsCargo" DataKeyNames="ecrgIdCargo,ecrgNombre" AllowPaging="True" AllowSorting="True" CssClass="gvGeneral">
                                <Columns>
                                    <asp:BoundField HeaderText="Nombre" DataField="ecrgNombre" SortExpression="ecrgNombre" />
                                </Columns>
                            </asp:GridView>
                            <asp:DropDownList ID="ddlNumPagCargo" runat="server">
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>80</asp:ListItem>
                                <asp:ListItem>200</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsCargo" runat="server" SelectMethod="GetTblCargoXCriConsulta" TypeName="dllSoftCentroErgonomia.Empresa.clEmpCargo">
                                <SelectParameters>
                                    <asp:Parameter Name="parIdEmpresa" Type="Int32" />
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
