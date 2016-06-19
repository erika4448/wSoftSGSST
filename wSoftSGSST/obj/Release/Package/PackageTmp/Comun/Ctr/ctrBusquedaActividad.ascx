<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrBusquedaActividad.ascx.vb" Inherits="wSoftCentroErgonomia.ctrBusquedaActividad" %>

<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="upnlActividad" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlBusActividad" runat="server">
            <table align="left">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblActividad" runat="server" Text="Actividad"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtActividadBus" runat="server" Width="180px"></asp:TextBox>
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
<%--VENTANA MODAL BUSQUEDA ACTIVIDAD--%>
<asp:ModalPopupExtender ID="ModalBusquedaActividad" runat="server" BackgroundCssClass="cssBackGroundModal"
    Enabled="True" PopupControlID="pnlBusquedaActividad" TargetControlID="btnFake">
</asp:ModalPopupExtender>
<asp:Button ID="btnFake" runat="server" Text="Fake" Style="display: none" />
<asp:Panel ID="pnlBusquedaActividad" CssClass="ModalPoup" runat="server" Style="display: none"> 
    <asp:UpdatePanel ID="upnlBusquedaActividad" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="right">
                        <table align="center">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblBusActividad" runat="server" Text="Código"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtActividadBusInt" runat="server"></asp:TextBox>
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
                        <asp:Panel ID="pnlGvActividad" runat="server" Height="300px" ScrollBars="Auto">
                            <asp:GridView ID="gvActividad" runat="server" AutoGenerateColumns="False" DataSourceID="odsActividad" DataKeyNames="eactIdActividad,eactNombre,eactCodigo" CssClass="gvGeneral">
                                <Columns>
                                    <asp:BoundField HeaderText="Código" DataField="eactCodigo" SortExpression="eactCodigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="eactNombre" SortExpression="eactNombre" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:DropDownList ID="ddlNumPagActividad" runat="server">
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>80</asp:ListItem>
                                <asp:ListItem>200</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsActividad" runat="server" SelectMethod="GetTblActividadXCriConsulta" TypeName="dllSoftCentroErgonomia.Empresa.clEmpActividad">
                                <SelectParameters>
                                    <asp:Parameter Name="parStrCriConsulta" Type="String" />
                                    <asp:Parameter Name="parIdEstado" Type="Int32" />
                                    <asp:Parameter Name="parIdEmpresa" Type="Int32" />
                                    <asp:Parameter Name="parIdProcedimiento" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnCerrar" runat="server" CausesValidation="False" Text="Cerrar" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
