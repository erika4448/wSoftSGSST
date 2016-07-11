<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrProceso.ascx.vb" Inherits="wSoftSGSST.ctrProceso" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<table>
    <tr>
        <td align="left" class="tdLabel">
            <asp:Label ID="lblProceso" runat="server" Text="Proceso"></asp:Label>
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlProceso" runat="server"></asp:DropDownList>
        </td>
        <td align="left">
            <asp:ImageButton ID="ibtnAgregar" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnAgregarAzul.png" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3">
            <asp:Panel ID="pnlGvProcesos" runat="server">
                <asp:GridView ID="gvProceso" runat="server" AutoGenerateColumns="False" CssClass="gvSGSST" DataKeyNames="tmpIdTabla">
                    <Columns>
                        <asp:BoundField HeaderText="Proceso" DataField="tmpNombreProceso" SortExpression="tmpNombreProceso" />
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Botones/ibtnEliminarGrilla.png" Text="Eliminar" HeaderText="Eliminar" />
                    </Columns>
                </asp:GridView>

            </asp:Panel>
        </td>
    </tr>
</table>