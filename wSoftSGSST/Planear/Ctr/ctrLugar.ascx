<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrLugar.ascx.vb" Inherits="wSoftSGSST.ctrLugar" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<table width="100%">
    <tr>
        <td align="left" class="tdLabel">
            <asp:Label ID="lblLugar" runat="server" Text="Lugar"></asp:Label>
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlLugar" runat="server"></asp:DropDownList>
        </td>
        <td align="left">
            <asp:ImageButton ID="ibtnAgregar" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnAgregarAzul.png" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3">
            <asp:Panel ID="pnlGvLugar" runat="server">
                <asp:GridView ID="gvLugar" runat="server" AutoGenerateColumns="False" CssClass="gvSGSST" DataKeyNames="tmpIdTabla">
                    <Columns>
                        <asp:BoundField HeaderText="Lugar" DataField="tmpNombreLugar" SortExpression="tmpNombreLugar" />
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Botones/ibtnEliminarGrilla.png" Text="Eliminar" HeaderText="Eliminar" CommandName="cmdEliminar" />
                    </Columns>
                </asp:GridView>

            </asp:Panel>
        </td>
    </tr>
</table>