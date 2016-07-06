<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrCargosEmpleado.ascx.vb" Inherits="wSoftSGSST.ctrCargosEmpleado" %>
<%@ Register Src="../../Ctr/ctrFecha.ascx" TagName="ctrFecha" TagPrefix="uc1" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>
<table>
    <tr>
        <td align="left" class="tdLabel">
            <asp:Label ID="lblCargo" runat="server" Text="*Cargo"></asp:Label>
        </td>
        <td align="left">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <asp:DropDownList ID="ddlCargo" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td align="left">
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:ImageButton ID="ibtnRequisitos" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnRequisitosAzul.png" />
                                </td>
                                <td align="left">
                                    <asp:ImageButton ID="ibtnHistorico" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnHistoricoAzul.png" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <asp:ImageButton ID="ibtnRelNuevoCargo" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnRelNuevoCargoAzul.png" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--VENTANA MODAL HISTORICO DEL CARGO--%>
<asp:Button ID="btnFake" runat="server" CausesValidation="False" Style="display: none" ToolTip="Editar Parámetro" />
<ajaxToolkit:ModalPopupExtender ID="modalHistCargo" runat="server" BackgroundCssClass="cssModalBackGround" Enabled="True" PopupControlID="pnlHistCargo" TargetControlID="btnFake">
</ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlHistCargo" runat="server" CssClass="ModalPoup" Style="display: none">
    <asp:UpdatePanel ID="upnlHistCargo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="ibtnCerrarHistCargo" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblHistCargos" runat="server" CssClass="tituloForm" Text="Histórico de Cargos"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvHistCargos" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="odsHistCargo" CssClass="gvSGSST">
                            <Columns>
                                <asp:BoundField DataField="StrCargo" HeaderText="Cargo" SortExpression="StrCargo" />
                                <asp:BoundField DataField="shceFchIngreso" HeaderText="Fecha Ingreso" SortExpression="shceFchIngreso" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="odsHistCargo" runat="server" SelectMethod="GetTblInfoHistCargoXdEmp" TypeName="dllSoftSGSST.SGSST.clSgsstHistCargosEmp">
                            <SelectParameters>
                                <asp:Parameter Name="parIdEmpleado" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<%--VENTANA MODAL REQUISITOS DEL CARGO--%>
<asp:Button ID="btnFake2" runat="server" CausesValidation="False" Style="display: none" ToolTip="Editar Parámetro" />
<ajaxToolkit:ModalPopupExtender ID="modalReqCargo" runat="server" BackgroundCssClass="cssModalBackGround" Enabled="True" PopupControlID="pnlReqCargo" TargetControlID="btnFake2">
</ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlReqCargo" runat="server" CssClass="ModalPoup" Style="display: none">
    <asp:UpdatePanel ID="upnlReqCargo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="padding:10px;">
                <tr>
                    <td align="right">

                        <asp:ImageButton ID="ibtnCerrarReqCargo" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" />

                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblReqCargo" runat="server" Text="Requisitos del Cargo" CssClass="tituloForm"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table>
                            <tr>
                                <td align="left" class="tdLabel">
                                    <asp:Label ID="lblCargoActual" runat="server" Text="Cargo Actual"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblInfoCargoActual" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdLabel">
                                    <asp:Label ID="lblEducacion" runat="server" Text="Educación"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblInfoEducacion" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdLabel">
                                    <asp:Label ID="lblProfesion" runat="server" Text="Profesión"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblInfoProfesion" runat="server"></asp:Label>
                                </td>
                            </tr>
                            </tr>
                            <tr>
                                <td align="left" class="tdLabel">
                                    <asp:Label ID="lblExperienciaAnios" runat="server" Text="Experiencia Años"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblInfoExperienciaAnios" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdLabel">
                                    <asp:Label ID="lblHabilidades" runat="server" Text="Habilidades"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblInfoHabilidades" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<%--VENTANA RELACIONAR NUEVO CARGO--%>
<asp:Button ID="btnFake3" runat="server" CausesValidation="False" Style="display: none" ToolTip="Editar Parámetro" />
<ajaxToolkit:ModalPopupExtender ID="modalRelNuevoCargo" runat="server" BackgroundCssClass="cssModalBackGround" Enabled="True" PopupControlID="pnlRelNuevoCargo" TargetControlID="btnFake3">
</ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlRelNuevoCargo" runat="server" CssClass="ModalPoup" Style="display: none">
    <asp:UpdatePanel ID="upnlRelNuevoCargo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td align="right">

                        <asp:ImageButton ID="ibtnCerrarRelNuevoCargo" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" />

                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblRelNuevoCargo" runat="server" Text="Relacionar Nuevo Cargo" CssClass="tituloForm"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table>
                            <tr>
                                <td align="left" class="tdLabel">

                                    <asp:Label ID="Label1" runat="server" Text="Cargo Actual"></asp:Label>

                                </td>
                                <td align="left" class="tdLabel">

                                    <asp:Label ID="lblInfoCargoActualRelNuevoCargo" runat="server"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdLabel">

                                    <asp:Label ID="lblNuevoCargo" runat="server" Text="Nuevo Cargo"></asp:Label>

                                </td>
                                <td align="left" class="tdLabel">

                                    <asp:DropDownList ID="ddlNuevoCargo" runat="server">
                                    </asp:DropDownList><asp:Label ID="lblAstValNuevoCargo" runat="server" Text="*"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdLabel">

                                    <asp:Label ID="lblFchIngresoCargo" runat="server" Text="Fecha Ingreso Cargo"></asp:Label>
                                    <asp:Label ID="lblAstValFchIngresoCargo" runat="server" Text="*"></asp:Label>
                                </td>
                                <td align="left" class="tdLabel">

                                    <uc1:ctrFecha ID="ctrFechaIngreso" runat="server" />

                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdLabel"></td>
                                <td align="left" class="tdLabel"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">

                                    <asp:ImageButton ID="ibtnGuardarCargo" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnGuardarCargoVerde.png" />

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
