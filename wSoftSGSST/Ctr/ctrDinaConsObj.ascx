<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrDinaConsObj.ascx.vb" Inherits="wSoftSGSST.ctrDinaConsObj" %>

<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<table>
    <tr>
        <td>
            <asp:Label ID="lblNomObj" runat="server" Text=""></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtObj" runat="server" AutoPostBack="True"></asp:TextBox>
        </td>
        <td>
            <asp:DropDownList ID="ddlObj" runat="server"></asp:DropDownList>
        </td>
        <td>
            <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/Images/General/ibtnBuscar.png" />
        </td>
        <td>
            <asp:ImageButton ID="ibtnActualizar" runat="server" ImageUrl="~/Images/General/ibtnRefrescar.png" style="height: 25px" />
        </td>
        <td>
            <asp:Image ID="imgRegValido" runat="server" ImageUrl="~/Images/General/ibtnRegValido.png" />
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender" runat="server" TargetControlID="txtObj" ServiceMethod="metodo"></ajaxToolkit:AutoCompleteExtender>
        </td>
    </tr>
</table>
