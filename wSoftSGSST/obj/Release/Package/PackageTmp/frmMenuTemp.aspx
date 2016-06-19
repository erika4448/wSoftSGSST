<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstCentroErgonomia.Master" CodeBehind="frmMenuTemp.aspx.vb" Inherits="wSoftCentroErgonomia.frmMenuTemp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
      <table align="center" style="border-style:dashed; border-width=2px; border-color:#1E4D8E; padding:20px;">
            <tr>
                <td align="left">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/AdmActividad.aspx">Administración Actividades</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Encuesta/frmEncuesta.aspx">Formulario Encuesta</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Procesamiento/frmProcesamientoActividad.aspx">Formulario Procesamiento Información Actividades</asp:HyperLink>
                </td>
            </tr>
           <tr>
                <td align="left">
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Procesamiento/frmProcesamientoEmpleado.aspx">Formulario Procesamiento Información Empleados</asp:HyperLink>
                </td>
            </tr>
           <tr>
                <td align="left">
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Procesamiento/frmConsultaProcEmpleado.aspx">Consulta Información Empleados</asp:HyperLink>
                </td>
            </tr>
           <tr>
                <td align="left">
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Procesamiento/frmConsultaProcActividad.aspx">Consulta Información Actividades</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Reportes/frmReportes.aspx">Reportes</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>
