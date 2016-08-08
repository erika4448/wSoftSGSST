﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrActividadesYPeligros.ascx.vb" Inherits="wSoftSGSST.ctrActividadesYPeligros" %>
<%@ Register Src="~/Ctr/ctrDinaConsObj.ascx" TagPrefix="uc1" TagName="ctrDinaConsObj" %>


<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<style type="text/css">
    .auto-style1 {
        height: 21px;
    }
</style>

<asp:Panel ID="pnlGvActRiesgos" runat="server">
    <table width="100%">
        <tr>
            <td colspan="3" align="right">
                <asp:ImageButton ID="ibtCerrar" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td align="center">
                <asp:Label ID="lblRiesgos" runat="server" Text="Riesgos del Cargo"></asp:Label>
            </td>
            <td align="right"></td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblNomNomCargo" runat="server" Text="Nombre Cargo: "></asp:Label>
                <asp:Label ID="lblNomCargo" runat="server" Text=""></asp:Label>
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:ImageButton ID="ibtnAgregarActividad" runat="server" ImageUrl="~/Images/Botones/ibtnAgregarActRiesgos.png" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
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
                <asp:Label ID="lblNoHayActividades" runat="server" Text="No hay Peligros relacionadas al Cargo."></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlActividad" runat="server">
    <table width="100%">
        <tr>
            <td align="right" colspan="2">
                <asp:ImageButton ID="ibtnCerrarActividad" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" class="auto-style1">
                <asp:Label ID="lblRegNuevaAct" runat="server" Text="Registro Nueva Actividad"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblActividad" runat="server" Text="Actividad"></asp:Label>
            </td>
            <td align="center">
                <uc1:ctrDinaConsObj runat="server" ID="ctrDinaConsObjActividad" />
            </td>
            <td>
                <asp:ImageButton ID="ibtnNuevaActivdad" runat="server" ImageUrl="~/Images/Botones/ibtnAgregarAzul.png" />
                <asp:ImageButton ID="ibnIncluirActividad" runat="server" ImageUrl="~/Images/Botones/ibtIncluirAzul.png" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Panel ID="pnlGvPeligro" runat="server">
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
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:ImageButton ID="ibtnDescartar" runat="server" ImageUrl="~/Images/Botones/ibtnDescartarAzul.png" />
                <asp:ImageButton ID="ibtnCargar" runat="server" ImageUrl="~/Images/Botones/ibtnCargarAzul.png" style="height: 27px" />
                <asp:ImageButton ID="ibntNuevoRiesgo" runat="server" ImageUrl="~/Images/Botones/ibtnNuevoRiesgoAzul.png" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlNuevaActividad" runat="server">
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="lblNuevaAct" runat="server" Text="Nueva Actividad"></asp:Label>
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
<asp:Panel ID="pnlDescClasRies" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción del Peligro"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCladificacion" runat="server" Text="Clasificación del Peligro"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlClasificacion" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRiesgo" runat="server" Text="Riesgo"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlRiesgo" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:ImageButton ID="ibtAgregarDescClasRies" runat="server" ImageUrl="~/Images/Botones/ibtnAgregarVerde.png" />
            </td>
        </tr>
    </table>
</asp:Panel>
