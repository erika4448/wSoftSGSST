<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstCentroErgonomia.Master" CodeBehind="frmEncuesta.aspx.vb" Inherits="wSoftCentroErgonomia.frmEncuesta" EnableEventValidation="false" %>

<%@ Register Src="~/Encuesta/Ctr/ctrCabEncuesta.ascx" TagPrefix="uc1" TagName="ctrCabEncuesta" %>
<%@ Register Src="~/Encuesta/Ctr/ctrDetEncuesta.ascx" TagPrefix="uc1" TagName="ctrDetEncuesta" %>
<%@ Register Src="~/Encuesta/Ctr/ctrPreguntasEncuesta.ascx" TagPrefix="uc1" TagName="ctrPreguntasEncuesta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <asp:UpdatePanel ID="upnlEncuesta" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td aling="left"></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlPaso1InfoEmpleado" runat="server">
                            <uc1:ctrCabEncuesta runat="server" ID="ctrCabEncuesta" />
                        </asp:Panel>
                        <asp:Panel ID="pnlPaso2InfoActividad" runat="server">
                            <uc1:ctrDetEncuesta runat="server" ID="ctrDetEncuesta" />
                        </asp:Panel>
                        <asp:Panel ID="pnlPaso3InfoPreguntas" runat="server">
                            <uc1:ctrPreguntasEncuesta runat="server" ID="ctrPreguntasEncuesta" />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnAnterior" runat="server" CausesValidation="False" Text="Anterior" />
                        <asp:Button ID="btnSiguiente" runat="server" CausesValidation="False" Text="Siguiente" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
