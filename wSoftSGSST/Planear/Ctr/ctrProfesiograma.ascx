<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrProfesiograma.ascx.vb" Inherits="wSoftSGSST.ctrProfesiograma" %>
<%@ Register Src="~/Ctr/ctrDinaConsObj.ascx" TagPrefix="uc1" TagName="ctrDinaConsObj" %>
<%@ Register Src="~/Planear/Ctr/ctrActividadesYPeligros.ascx" TagPrefix="uc1" TagName="ctrActividadesYPeligros" %>




<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<asp:Panel ID="pnlProfesiograma" runat="server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lblProfesiograma" runat="server" Text="Profesiograma" CssClass="tituloForm"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:ImageButton ID="ibtnNuevaConsulta" runat="server" ImageUrl="~/Images/Botones/ibtnNuevaConsulta.png" style="height: 14px" />
                <asp:ImageButton ID="ibtnVolver" runat="server" ImageUrl="~/Images/Botones/boton_volver.fw.png" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="ibtnNuevoProfesiograma" runat="server" ImageUrl="~\Images\Botones\boton_crear_nuevo_cargo.fw.png" />
                <asp:ImageButton ID="ibtnConsultarProfesiograma" runat="server" ImageUrl="~\Images\Botones\boton_consultar_editar_cargo.fw.png" Style="padding-left: 5px" />
            </td>
        </tr>
        <tr>
            <td>&nbsp</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlBuscarCargo" runat="server">
                    <table>
                        <tr>
                            <td width="140px">
                                <asp:Label ID="lblNomCargoBus" runat="server" Text="Nombre Cargo"></asp:Label>
                            </td>
                            <td align="center">
                                <uc1:ctrDinaConsObj runat="server" ID="ctrDinaConsObjCargo" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:ImageButton ID="ibntVerDetalle" runat="server" ImageUrl="~/Images/Botones/ibtnVerDetalleVerde.png" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlFormularioCargoInfoBasica" runat="server" ScrollBars="Auto">
                                <table width="100%" align="left">
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblNomCargo" runat="server" Text="*Nombre Cargo"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNomCargo" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNomCargoObliga" runat="server" Text="**Obligatorio" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblCodCargo" runat="server" Text="*Código del Cargo"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCodCargo" runat="server" AutoPostBack="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCodCargoObliga" runat="server" Text="**Obligatorio" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlFormularioCargoInfoComp" runat="server" ScrollBars="Auto">
                                <table>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblObjCargo" runat="server" Text="Objetivo Cargo"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtObjCargo" runat="server" TextMode="MultiLine" Height="120px" Width="400px"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblActividades" runat="server" Text="Actividades Cargo"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtActividades" runat="server" TextMode="MultiLine" Height="120px" Width="400px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblEducacion" runat="server" Text="Educación"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEducacion" runat="server"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblProfesion" runat="server" Text="Profesión"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlProfesion" runat="server"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblExperiencia" runat="server" Text="Campo de Experiencia"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExperiencia" runat="server"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblExperienciaAnos" runat="server" Text="Años de Experiencia"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExperienciaAnos" runat="server"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtExperienciaAnos_FilteredTextBoxExtender" runat="server" BehaviorID="txtExperienciaAnos_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="txtExperienciaAnos" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblHabilidades" runat="server" Text="Habilidades"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHabilidades" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblAQuienReporta" runat="server" Text="A quien le reporta"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlAQuienReporta" runat="server"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblQuienLePreporta" runat="server" Text="Quien le Reporta"></asp:Label>
                                        </td>
                                        <td>
                                            <uc1:ctrDinaConsObj runat="server" ID="ctrDinaConsObjQuienLeRep" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ibtnAgregarQuienLeReporta" runat="server" ImageUrl="~/Images/Botones/ibtnAgregarAzul.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="140px">&nbsp;</td>
                                        <td>
                                            <asp:Panel ID="pnlGvQuienLeReporta" runat="server">
                                                <asp:GridView ID="gvQuienLeReporta" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCabQuienRepCargo,idRelCargoXQuienRepIdCargo,QuienRepIdCargo">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Cargos quien le reportan" DataField="Nombre" SortExpression="Nombre" />
                                                        <asp:TemplateField HeaderText="Eliminar">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ibtnEliminar" runat="server" ImageUrl="~/Images/General/ibtnRegNoValido.png" OnClick="ibtnEliminar_Click" Style="height: 24px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left">
                                            <asp:Label ID="lblAreaDelCargo" runat="server" Text="Área del Cargo"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlAreaDelCargo" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ibtnAgreArea" runat="server" ImageUrl="~/Images/Botones/ibtnAgregarAzul.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel ID="pnlNuevaArea" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNewArea" runat="server" Text="Nueva Área"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNuevaArea" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnGuardarNuevaArea" runat="server" ImageUrl="~/Images/Botones/ibtnGuardarAzul.png" />
                                                            <asp:ImageButton ID="btnCerrarNuevaArea" runat="server" ImageUrl="~/Images/Botones/ibtnCerrarAzul.png" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="pnlRiesgos" runat="server">
                                                            <asp:ImageButton ID="ibtnRiesgos" runat="server" ImageUrl="~/Images/OpcPagina/ibtnRiesgosCargoGris.png" />
                                                        </asp:Panel>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlRqFisicos" runat="server">
                                                            <asp:ImageButton ID="itbnRqFisicos" runat="server" ImageUrl="~/Images/OpcPagina/ibtnReqFisicosGris.png" />
                                                        </asp:Panel>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlCondicSalud" runat="server">
                                                            <asp:ImageButton ID="ibtnCondicSalud" runat="server" ImageUrl="~/Images/OpcPagina/ibtnCondSaludGris.png" />
                                                        </asp:Panel>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlEpp" runat="server">
                                                            <asp:ImageButton ID="ibtEpp" runat="server" ImageUrl="~/Images/OpcPagina/ibtnEPPEntrenamientoGris.png" />
                                                        </asp:Panel>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlResponsabilidad" runat="server">
                                                            <asp:ImageButton ID="ibtnResponsabilidad" runat="server" ImageUrl="~/Images/OpcPagina/ibtnRespSGSSTGris.png" />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ImageButton ID="ibtnGuardar" runat="server" ImageUrl="~/Images/Botones/ibtnGuardarInfoVerde.png" />
                        </td>
                    </tr>
                </table>


            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlActividadesPeligros" runat="server">
    <table align="center">
        <tr>
            <td>
                <uc1:ctrActividadesYPeligros runat="server" ID="ctrActividadesYPeligros" />
            </td>
        </tr>
    </table>
</asp:Panel>
