<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrActividadesYPeligros.ascx.vb" Inherits="wSoftSGSST.ctrActividadesYPeligros" %>
<%@ Register Src="~/Ctr/ctrDinaConsObj.ascx" TagPrefix="uc1" TagName="ctrDinaConsObj" %>


<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<asp:Panel ID="pnlActividad" runat="server">
    <table width="100%">
        <tr>
            <td align="right" colspan="3">
                <%--<asp:ImageButton ID="ibtnCerrarActividad" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" />--%>
                <asp:ImageButton ID="ibtCerrar" runat="server" ImageUrl="~/Images/Botones/boton_volver.fw.png" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lblRiesgos" runat="server" Text="Registro de nueva Actividad con Riesgo" CssClass="tituloForm"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                <asp:Label ID="lblNomNomCargo" runat="server" Text="Nombre Cargo: " Font-Bold="true"></asp:Label>
                <asp:Label ID="lblNomCargo" runat="server" Text="" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                <asp:Label ID="lblInfor1" runat="server" Text="1. Porfavor primero seleccione o incluya una nueva actividad" Font-Italic="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblActividad" runat="server" Text="Actividad"></asp:Label>
            </td>
            <td align="center">
                <uc1:ctrDinaConsObj runat="server" ID="ctrDinaConsObjActividad" />
            </td>
            <td>
                <asp:ImageButton ID="ibtnNuevaActivdad" runat="server" ImageUrl="~/Images/Botones/Nueva_Actividad.fw.png" />
                <%--<asp:ImageButton ID="ibnIncluirActividad" runat="server" ImageUrl="~/Images/Botones/ibtIncluirAzul.png" />--%>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblInfor2" runat="server" Text="Si no encontro la actividad que buscaba, debe crearla con el botón 'Crear Actividad'" Font-Italic="true" Font-Size="Smaller"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlNuevaActividad" runat="server" CssClass="pnlContentInfoGris">
                    <table align="center">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Nueva Actividad"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNuevaActividad" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="ibtnGuardarNuevaAct" runat="server" ImageUrl="~/Images/Botones/ibtnGuardarAzul.png" />
                                <asp:ImageButton ID="ibtnCerrarNuevaAct" runat="server" ImageUrl="~/Images/Botones/ibtnCerrarAzul.png" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="left">
                <asp:Label ID="lblInfor3" runat="server" Text="2. Una vez haya seleccionado  una actividad por favor incluya los riesgos asociados a la actividad." Font-Italic="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lblRiesXAct" runat="server" Text="Riesgos relacionados a la Actividad" CssClass="tituloForm"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:UpdatePanel ID="upnlPeligro" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlGvPeligro" runat="server" CssClass="pnlContentGv">
                            <asp:GridView ID="gvPeligro" runat="server" CssClass="gvSGSST" AutoGenerateColumns="False" DataKeyNames="EstIncluir,idCabPeligro">
                                <Columns>
                                    <asp:TemplateField HeaderText="Incluir">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkIcluirPeligro" runat="server" Checked='<%# IIf(Eval("EstIncluir") = 1, True, False) %>' AutoPostBack="True" OnCheckedChanged="chkIcluirPeligro_CheckedChanged" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NomDescripcionPeligro" HeaderText="Descripción del Peligro" SortExpression="NomDescripcionPeligro" />
                                    <asp:BoundField DataField="NomClasificacionPeligro" HeaderText="Clasificación del Peligro" SortExpression="NomClasificacionPeligro" />
                                    <asp:BoundField DataField="NomRiesgo" HeaderText="Riesgo" SortExpression="NomRiesgo" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:ImageButton ID="ibntNuevoRiesgo" runat="server" ImageUrl="~/Images/Botones/ibtnNuevoRiesgoAzul.png" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:ImageButton ID="ibtnCargar" runat="server" ImageUrl="~/Images/Botones/ibtnGuardarInfoVerde.png" Style="height: 27px" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlGvActRiesgos" runat="server">
    <table width="100%">
        <tr>
            <td align="center">
                <%--<asp:ImageButton ID="ibtnAgregarActividad" runat="server" ImageUrl="~/Images/Botones/ibtnAgregarActRiesgos.png" />--%>
                
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlPeligrosXCargo" runat="server">
                    <asp:GridView ID="gvPeligrosXCargo" runat="server" AutoGenerateColumns="False" CssClass="gvSGSST" DataKeyNames="sracIdRelPeligroXCargo">
                        <Columns>
                            <asp:BoundField HeaderText="Actividad" DataField="sgacNombre" SortExpression="sgacNombre" />
                            <asp:BoundField HeaderText="Descripción del Peligro" DataField="sgplDescripcionPeligro" SortExpression="sgplDescripcionPeligro" />
                            <asp:BoundField HeaderText="Clasificación del Peligro" DataField="sclpNombre" SortExpression="sclpNombre" />
                            <asp:BoundField HeaderText="Riesgo" DataField="sgriNombre" SortExpression="sgriNombre" />
                            <asp:BoundField HeaderText="Evaluación" />
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnEliminar" runat="server" ImageUrl="~/Images/General/boton_grilla_eliminar.png" OnClick="ibtnEliminar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Button ID="btnfake" runat="server" Text="" Style="display: none" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderNuevoRiesgo" runat="server" PopupControlID="pnlDescClasRies" TargetControlID="btnfake" BackgroundCssClass="cssModalBackGround" Enabled="true"></ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlDescClasRies" runat="server" CssClass="ModalPoup" Style="display: none">
    <asp:UpdatePanel ID="upnlDescClasRies" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td align="right">
                        <asp:ImageButton ID="btnCerrarModalRiesgo" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Label ID="lblNuevoRiesgo" runat="server" Text="Definir el Peligro y Riesgo asociado a la actividad" CssClass="tituloForm"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción del Peligro"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCladificacion" runat="server" Text="Clasificación del Peligro"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClasificacion" runat="server"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRiesgo" runat="server" Text="Riesgo"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRiesgo" runat="server"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="ibtAgregarDescClasRies" runat="server" ImageUrl="~/Images/Botones/ibtnAgregarVerde.png" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
