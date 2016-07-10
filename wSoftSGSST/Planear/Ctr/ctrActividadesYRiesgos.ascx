<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrActividadesYRiesgos.ascx.vb" Inherits="wSoftSGSST.ctrActividadesYRiesgos" %>
<%@ Register Src="~/Ctr/ctrDinaConsObj.ascx" TagPrefix="uc1" TagName="ctrDinaConsObj" %>


<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<asp:Panel ID="pnlGvActRiesgos" runat="server">
    <table width="100%">
        <tr>
            <td colspan="3" align="right">
                <asp:ImageButton ID="ibtCerrar" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" />
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td align="center">
                <asp:Label ID="lblRiesgos" runat="server" Text="Riesgos del Cargo"></asp:Label>
            </td>
            <td align="rigth">
                
            </td>
        </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Label ID="lblNomNomCargo" runat="server" Text="Nombre Cargo: "></asp:Label>
                <asp:Label ID="lblNomCargo" runat="server" Text=""></asp:Label>
            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:ImageButton ID="ibtnAgregarActividad" runat="server" ImageUrl="~/Images/Botones/ibtnAgregarActRiesgos.png" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Panel ID="pnlGvActividad" runat="server">
                    <asp:GridView ID="gvActividades" runat="server" AutoGenerateColumns="False" CssClass="gvSGSST">
                        <Columns>
                            <asp:BoundField HeaderText="Actividad" />
                            <asp:BoundField HeaderText="Descripción del Peligro" />
                            <asp:BoundField HeaderText="Clasificación del Peligro" />
                            <asp:BoundField HeaderText="Riesgo" />
                            <asp:BoundField HeaderText="Evaluación" />
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnEliminar" runat="server" ImageUrl="~/Images/General/boton_grilla_eliminar.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
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
            <td align="center" colspan="2">
                <asp:Label ID="lblRegNuevaAct" runat="server" Text="Registro Nueva Actividad"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <uc1:ctrDinaConsObj runat="server" ID="ctrDinaConsObj" />
            </td>
            <td>
                <asp:ImageButton ID="ibnIncluirActividad" runat="server" ImageUrl="~/Images/Botones/ibtIncluirAzul.png" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:ImageButton ID="ibntNuevaActividad" runat="server" ImageUrl="~/Images/Botones/ibtnNuevoRiesgoAzul.png" />
            </td>
        </tr>
        <tr>
            <td>
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
            </td>
        </tr>
    </table>
</asp:Panel>
