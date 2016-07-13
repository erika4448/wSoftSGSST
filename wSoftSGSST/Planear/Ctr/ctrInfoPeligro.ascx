<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrInfoPeligro.ascx.vb" Inherits="wSoftSGSST.ctrInfoPeligro" %>
<%@ Register src="ctrProceso.ascx" tagname="ctrProceso" tagprefix="uc1" %>
<%@ Register src="ctrLugar.ascx" tagname="ctrLugar" tagprefix="uc2" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>
<table>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblNomActividad" runat="server" Text="Actividad"></asp:Label>

        </td>
        <td align="left">

            <asp:Label ID="lblActividad" runat="server"></asp:Label>

        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">

            <uc1:ctrProceso ID="ctrProceso1" runat="server" />

        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Panel ID="pnlCargos" runat="server">
                <asp:GridView ID="gvCargos" runat="server" AutoGenerateColumns="False" CssClass="gvSGSST" DataSourceID="odsCargos">
                    <Columns>
                        <asp:BoundField HeaderText="Cargos Relacionados" DataField="sgcaNombre" SortExpression="sgcaNombre" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCargos" runat="server" SelectMethod="GetTblInfoCargoXIdPeligro" TypeName="dllSoftSGSST.SGSST.clSgsstCargo">
                    <SelectParameters>
                        <asp:Parameter Name="parIdPeligro" Type="Int32" />
                        <asp:Parameter Name="parIdEstado" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">

            <uc2:ctrLugar ID="ctrLugar1" runat="server" />

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblRutinaria" runat="server" Text="Rutinaria"></asp:Label>

        </td>
        <td align="left">

            <asp:DropDownList ID="ddlRutinaria" runat="server">
                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">

        </td>
        <td align="left">

        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">

            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PnlInfo/imPnlInfoPeligro.png" />

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel" valign="top">

            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>

        </td>
        <td align="left">

            <asp:TextBox ID="txtDescripcion" runat="server" Width="400px" Height="100px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblNomClasificacion" runat="server" Text="Clasificación"></asp:Label>

        </td>
        <td align="left">

            <asp:Label ID="lblClasificacion" runat="server"></asp:Label>

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblNomRiesgo" runat="server" Text="Riesgo"></asp:Label>

        </td>
        <td align="left">

            <asp:Label ID="lblRiesgo" runat="server"></asp:Label>

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">

        </td>
        <td align="left">

        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">

            <asp:ImageButton ID="ibtnIncluirRiesgo" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnIncluirRiesgoVerde.png" />

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">

            &nbsp;</td>
        <td align="left">

            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" colspan="2">

            <asp:ImageButton ID="ibtnCtrExistentes" runat="server"  CausesValidation="false" ImageUrl="~/Images/OpcPagina/ibtnCtrExistentesAzul.png"/>
            <asp:ImageButton ID="ibtnEvaluacionRiesgo" runat="server"  CausesValidation="false" ImageUrl="~/Images/OpcPagina/ibtnEvalRiesgosAzul.png"/>
            <asp:ImageButton ID="ibtnCriControles" runat="server"  CausesValidation="false" ImageUrl="~/Images/OpcPagina/ibtnCriteriosCtrAzul.png"/>
            <asp:ImageButton ID="ibtnMedIntervencion" runat="server"  CausesValidation="false" ImageUrl="~/Images/OpcPagina/ibtnMedIntervencionAzul.png" />
        </td>
    </tr>
</table>