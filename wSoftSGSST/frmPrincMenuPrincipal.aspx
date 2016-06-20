<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstSGSST.Master" CodeBehind="frmPrincMenuPrincipal.aspx.vb" Inherits="wSoftSGSST.frmPrincMenuPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" align="center">
        <tr>
            <td align="left">
                <asp:Button ID="btnProfesiograma" runat="server" Text="Profesiograma" />
            </td>
        </tr>
        <tr>
            <td align="left">
             <asp:Button ID="btnPerfilDemografico" runat="server" Text="Perfil Demográfico" />
            </td>
        </tr>
    </table>
</asp:Content>
