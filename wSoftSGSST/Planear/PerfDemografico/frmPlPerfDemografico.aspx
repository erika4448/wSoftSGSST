<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstSGSST.Master" CodeBehind="frmPlPerfDemografico.aspx.vb" Inherits="wSoftSGSST.frmPlPerfDemografico" %>

<%@ Register Src="../Ctr/ctrInfoEmpleado.ascx" TagName="ctrInfoEmpleado" TagPrefix="uc1" %>
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
    <asp:UpdatePanel ID="upnlPerfDemografico" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center" width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitulo" runat="server" Text="Empleados y Colaboradores" CssClass="tituloForm"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="Button1" runat="server" Text="Empleado" />
                        <asp:ImageButton ID="ibtnNuevoEmpleado" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnNuevoProfesiograma.png" />
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlBusEmpleado" runat="server">
                        </asp:Panel>
                        <asp:Panel ID="pnlInfoEmpleado" runat="server">
                            <uc1:ctrInfoEmpleado ID="ctrInfoEmpleado1" runat="server" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
