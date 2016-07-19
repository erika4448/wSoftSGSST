<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrProceso.ascx.vb" Inherits="wSoftSGSST.ctrProceso" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<table width="100%">
    <tr>
        <td align="left" class="tdLabel">
            <asp:Label ID="lblProceso" runat="server" Text="Proceso"></asp:Label>
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlProceso" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtProceso" runat="server"></asp:TextBox>
        </td>
        <td align="left">
            <table>
                <tr>
                    <td align="left">
                        <asp:ImageButton ID="ibtnIncluir" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtIncluirAzul.png" />
                        <asp:ImageButton ID="ibtnGuardar" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnGuardarAzul.png" />
                    </td>
                    <td align="left">
                        <asp:ImageButton ID="ibtnCerrar" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnCerrarAzul.png" />
                    </td>
                </tr>
            </table>
        </td>
        <td align="left">
            <asp:ImageButton ID="ibtnAgregar" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnAgregarAzul.png" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="4">
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlGvProcesos" runat="server" CssClass="pnlContentGv">
                            <asp:GridView ID="gvProceso" runat="server" AutoGenerateColumns="False" CssClass="gvSGSST" DataKeyNames="tmpIdTabla">
                                <Columns>
                                    <asp:BoundField HeaderText="Proceso" DataField="tmpNombreProceso" SortExpression="tmpNombreProceso" />
                                    <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Botones/ibtnEliminarGrilla.png" Text="Eliminar" HeaderText="Eliminar" CommandName="cmdEliminar" />
                                </Columns>
                                <AlternatingRowStyle CssClass="gvSGSST_Tr_Alternate" />
                            </asp:GridView>

                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
