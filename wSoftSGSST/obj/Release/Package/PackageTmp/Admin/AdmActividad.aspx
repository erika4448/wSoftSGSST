<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstCentroErgonomia.Master" CodeBehind="AdmActividad.aspx.vb" Inherits="wSoftCentroErgonomia.AdmActividad" %>

<%@ Register Src="~/Admin/Ctr/ctrAdminTipoProceso.ascx" TagPrefix="uc1" TagName="ctrAdminTipoProceso" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <asp:UpdatePanel ID="upnlAdminActividad" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitulo" runat="server" Text="ADMINISTRACIÓN ACTIVIDADES" CssClass="lblTituloPagina"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlEmpresa" runat="server">
                            <table align="center">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblEmpresa" runat="server" Text="Empresa"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="True"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="center">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlTipoProceso" runat="server">
                            <uc1:ctrAdminTipoProceso runat="server" ID="ctrAdminTipoProceso" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
