<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstSGSST.Master" CodeBehind="frmMtRgCalificarRiesgo.aspx.vb" Inherits="wSoftSGSST.frmMtRgCalificarRiesgo" %>

<%@ Register Src="../Ctr/ctrInfoPeligro.ascx" TagName="ctrInfoPeligro" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--HOJAS DE ESTILO LIBRERIA DE MENSAJES--%>
    <link href="../../css/alertify.bootstrap.css" rel="stylesheet" />
    <link href="../../css/alertify.bootstrap.css" rel="stylesheet" />
    <link href="../../css/alertify.core.css" rel="stylesheet" />
    <%--JAVASCRIPT LIBRERIA DE MENSAJES--%>
    <script type="text/javascript" src="../../js/alertify.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.3.min.js"></script>

    <%--MENU--%>
    <script type="text/javascript" src="../../js/jquery-3.0.0.min.js"></script>
    <link href="../../css/Menu/bootstrap-treeview.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/Menu/bootstrap-treeview.js"></script>
    <asp:UpdatePanel ID="upnlCalificarRiesgo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblPathPagina" runat="server" Text="Planear / Matriz de Riesgos" CssClass="pathMenu"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitulo" runat="server" Text="Matriz de Peligros" CssClass="tituloForm"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">

                        <asp:ImageButton ID="ibtnRegresarMatRiesgos" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnRegresarMatriz.png" />

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">

                        <uc1:ctrInfoPeligro ID="ctrInfoPeligro1" runat="server" />

                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
