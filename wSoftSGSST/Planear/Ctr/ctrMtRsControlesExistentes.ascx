<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrMtRsControlesExistentes.ascx.vb" Inherits="wSoftSGSST.ctrMtRsControlesExistentes" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>
<table>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblCtrFte" runat="server" Text="Control en la Fuente"></asp:Label>

        </td>
         <td align="left">

             <asp:TextBox ID="txtCtrFuente" runat="server" Width="300px" Height="100px" TextMode="MultiLine"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">
            
            <asp:Label ID="lblCtrMedio" runat="server" Text="Control en el Medio"></asp:Label>
        </td>
         <td align="left">
              <asp:TextBox ID="txtCtrMedio" runat="server" Width="300px" Height="100px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
         <td align="left" class="tdLabel">
            
            <asp:Label ID="lblCtrIndividuo" runat="server" Text="Control en el Individuo"></asp:Label>
        </td>
         <td align="left">
              <asp:TextBox ID="txtCtrIndividuo" runat="server" Width="300px" Height="100px" TextMode="MultiLine"></asp:TextBox>
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