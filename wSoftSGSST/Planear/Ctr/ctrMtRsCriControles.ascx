<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrMtRsCriControles.ascx.vb" Inherits="wSoftSGSST.ctrMtRsCriControles" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>
<table>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblNumExpuestos" runat="server" Text="Número de Expuestos"></asp:Label>

        </td>
         <td align="left">

             <asp:TextBox ID="txtNumExpuestos" runat="server"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">
            
            <asp:Label ID="blPeorConsec" runat="server" Text="Peor Consecuencia"></asp:Label>
        </td>
         <td align="left">
              <asp:TextBox ID="txtPeorConsec" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
         <td align="left" class="tdLabel">
            
            <asp:Label ID="lblEstReqLega" runat="server" Text="Existe Requisito Legal Específico Asociado"></asp:Label>
        </td>
         <td align="left">
              <asp:DropDownList ID="ddlEstReqLegal" runat="server">
                  <asp:ListItem Value="0">Seleccione</asp:ListItem>
                  <asp:ListItem Value="1">Si</asp:ListItem>
                  <asp:ListItem Value="2">No</asp:ListItem>
              </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="left">
&nbsp;
        </td>
         <td align="left">
&nbsp;
        </td>
    </tr>
     <tr>
        <td align="center" colspan="2">

            <asp:ImageButton ID="ibtnGuardarInfo" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnGuardarInfoVerde.png" />

        </td>
    </tr>
</table>