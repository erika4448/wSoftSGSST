<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrProfesiograma.ascx.vb" Inherits="wSoftSGSST.ctrProfesiograma" %>
<%@ Register Src="~/Ctr/ctrDinaConsObj.ascx" TagPrefix="uc1" TagName="ctrDinaConsObj" %>


<table align="center">
    <tr>
        <td colspan="3" align="center">
            <asp:Label ID="lblProfesiograma" runat="server" Text="Profesiograma"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td align="rigth">
            <asp:ImageButton ID="ibtnNuevaConsulta" runat="server" ImageUrl="~/Images/Botones/ibtnNuevaConsulta.png" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td align="rigth">
            <asp:ImageButton ID="ibtnNuevoProfesiograma" runat="server" ImageUrl="~/Images/Botones/ibtnNuevoProfesiograma.png" />
        </td>
    </tr>
    <tr>
        <td colspan="3">&nbsp</td>
    </tr>
    <tr>
        <td>
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
        <td>

            <asp:Label ID="lblCodCargo" runat="server" Text="*Código del Cargo"></asp:Label>

        </td>
        <td>
            <asp:TextBox ID="txtCodCargo" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="lblCodCargoObliga" runat="server" Text="**Obligatorio" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblObjCargo" runat="server" Text="Objetivo Cargo"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtObjCargo" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblActividades" runat="server" Text="*Actividades Cargo"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtActividades" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="lblActividadesObliga" runat="server" Text="**Obligatorio" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblEducacion" runat="server" Text="Educación"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlEducacion" runat="server"></asp:DropDownList>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblProfesion" runat="server" Text="Profesión"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlProfesion" runat="server"></asp:DropDownList>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblExperiencia" runat="server" Text="Experiencia"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtExperiencia" runat="server"></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblExperienciaAnos" runat="server" Text="Esperiencia Años"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtExperienciaAnos" runat="server"></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblHabilidades" runat="server" Text="Habilidades"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtHabilidades" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblAQuienReporta" runat="server" Text="A quien le reporta"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlAQuienReporta" runat="server"></asp:DropDownList>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblQuienLePreporta" runat="server" Text="Quien le Reporta"></asp:Label>
        </td>
        <td>
            <uc1:ctrDinaConsObj runat="server" id="ctrDinaConsObj" />
            <asp:Panel ID="pnlGvQuienLeReporta" runat="server">
                <asp:GridView ID="gvQuienLeReporta" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCabQuienRepCargo,QuienRepIdCargo">
                    <Columns>
                        <asp:BoundField HeaderText="Cargos quien le reportan" DataField="QuienRepIdCargo" SortExpression="QuienRepIdCargo" />
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/General/ibtnRegNoValido.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </td>
        <td>
            <asp:ImageButton ID="ibtnAgregarQuienLeReporta" runat="server" ImageUrl="~/Images/Botones/ibtnAgregarAzul.png" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblAreaDelCargo" runat="server" Text="Área del Cargo"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlAreaDelCargo" runat="server"></asp:DropDownList>
        </td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3" align="center">
            <asp:ImageButton ID="ibtnRiesgos" runat="server" ImageUrl="~/Images/OpcPagina/ibtnRiesgosCargoGris.png" />
            <asp:ImageButton ID="itbnRqFisicos" runat="server" ImageUrl="~/Images/OpcPagina/ibtnReqFisicosGris.png" />
            <asp:ImageButton ID="ibtnCondicSalud" runat="server" ImageUrl="~/Images/OpcPagina/ibtnCondSaludGris.png" />
            <asp:ImageButton ID="ibtEpp" runat="server" ImageUrl="~/Images/OpcPagina/ibtnEPPEntrenamientoGris.png" />
            <asp:ImageButton ID="ibtnResponsabilidad" runat="server" ImageUrl="~/Images/OpcPagina/ibtnRespSGSSTGris.png" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3" align="center">
            <asp:ImageButton ID="ibtnGuardar" runat="server" ImageUrl="~/Images/Botones/ibtnGuardarInfoVerde.png" />
        </td>
    </tr>
</table>
