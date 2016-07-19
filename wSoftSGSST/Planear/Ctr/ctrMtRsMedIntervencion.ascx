<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrMtRsMedIntervencion.ascx.vb" Inherits="wSoftSGSST.ctrMtRsMedIntervencion" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>
<table>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblEliminacion" runat="server" Text="Eliminación"></asp:Label>

        </td>
         <td align="left">

             <asp:TextBox ID="txtEliminacion" runat="server"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">
            
            <asp:Label ID="lblSustitucion" runat="server" Text="Sustitución"></asp:Label>
        </td>
         <td align="left">
              <asp:TextBox ID="txtSustitucion" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
         <td align="left" class="tdLabel">
            
            <asp:Label ID="lblCtrIngenieria" runat="server" Text="Controles de Ingeniería"></asp:Label>
        </td>
         <td align="left">
              <asp:TextBox ID="txtCtrIngenieria" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left">     
            <asp:Label ID="lblCtrAdmin" runat="server" Text="Controles Administrativos"></asp:Label>
        </td>
         <td align="left">
              <asp:TextBox ID="txtCtrAdmin" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left">
            
            <asp:Label ID="lblEEPP" runat="server" Text="Elementos / Equipos de Protección Personal"></asp:Label>
        </td>
         <td align="left">
              <asp:TextBox ID="txtEEPP" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
         <td align="left">
             &nbsp;</td>
    </tr>
     <tr>
        <td align="center" colspan="2">

            <asp:ImageButton ID="ibtnGuardarInfo" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnGuardarInfoVerde.png" />

        </td>
    </tr>
</table>