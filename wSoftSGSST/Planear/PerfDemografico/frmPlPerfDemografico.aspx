<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstSGSST.Master" CodeBehind="frmPlPerfDemografico.aspx.vb" Inherits="wSoftSGSST.frmPlPerfDemografico" %>

<%@ Register Src="../Ctr/ctrInfoEmpleado.ascx" TagName="ctrInfoEmpleado" TagPrefix="uc1" %>
<%@ Register Src="../../Ctr/ctrDinaConsObj.ascx" TagName="ctrDinaConsObj" TagPrefix="uc2" %>
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

    <asp:UpdatePanel ID="upnlPerfDemografico" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblPathPagina" runat="server" Text="Planear / Perfil Demográfico" CssClass="pathMenu"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table align="center" width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitulo" runat="server" Text="Empleados y Colaboradores" CssClass="tituloForm"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="ibtnLimpiar" runat="server" CausesValidation="false" ImageUrl="~/Images/General/ibtnLimpiar.png" />
                        <asp:ImageButton ID="ibtnNuevaConsulta" runat="server" CausesValidation="false" ImageUrl="~/Images/General/ibtnNuevaConsulta.png" />
                        <asp:ImageButton ID="ibtnNuevoEmpleado" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnNuevoEmpleado.png" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="lbtnLimpiarForm" runat="server"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlBusEmpleado" runat="server">
                            <table>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblEmpleado" runat="server" Text="Número Documento o Nombre Empleado"></asp:Label>
                                    </td>
                                    <td align="left">

                                        <uc2:ctrDinaConsObj ID="ctrDinaConsObj1" runat="server" />

                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlInfoEmpleado" runat="server">
                            <uc1:ctrInfoEmpleado ID="ctrInfoEmpleado1" runat="server" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>
