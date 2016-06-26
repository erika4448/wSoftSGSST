<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrInfoEmpleado.ascx.vb" Inherits="wSoftSGSST.ctrInfoEmpleado" %>
<%@ Register src="../../Ctr/ctrFecha.ascx" tagname="ctrFecha" tagprefix="uc1" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>
<table>
     <tr>
        <td align="left" class="tdLabel">
            <asp:ImageButton ID="imEmpleado" runat="server" ImageUrl="~/Images/General/imAgregarFoto.png" />
        </td>
        <td align="center">
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblNombreEmpleado" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td align="center">
                        <asp:Label ID="lblAnios" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                </tr>
                 <tr>
                    <td align="center">
                        <asp:Label ID="lblTipDocNumDoc" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                </tr>
                 <tr>
                    <td align="center">
                        <asp:Label ID="lblCargo" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                </tr>
                 <tr>
                    <td align="center">
                        <asp:ImageButton ID="ibtnEditarInfo" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnEditarInfoAzul.png" />
                     </td>
                </tr>
            </table>
        </td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left">
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
         </td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left">
            <uc1:ctrFecha ID="ctrFecha1" runat="server" />
         </td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left">
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
         </td>
    </tr>
     <tr>
        <td align="left" class="auto-style1">

            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left" class="auto-style1">
            <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
         </td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left"></td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left"></td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left"></td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left"></td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left"></td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left"></td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left"></td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left"></td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>

        </td>
        <td align="left"></td>
    </tr>
     <tr>
        <td align="left" class="tdLabel">

        </td>
        <td align="left"></td>
    </tr>
</table>
