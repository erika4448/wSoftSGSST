<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstSGSST.Master" CodeBehind="frmMenuPlanear.aspx.vb" Inherits="wSoftSGSST.frmMenuPlanear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" style="margin-top: 30px;">
        <tr>
            <td align="center" style="padding-right: 50px;">

                <asp:Image ID="imTotalPlanear" runat="server" ImageUrl="~/Images/ZoomPlanear/imZoomTotalPlanear0.png" />

            </td>
            <td align="left">
                <table cellpadding="0" cellspacing="0" style="border-spacing: 0px 0px!important;">
                    <tr>
                        <td align="left">
                            <a href="Profesiograma/frmPlProfesiograma.aspx">
                                <asp:Image ID="imTotalProfesiograma" runat="server" ImageUrl="~/Images/ZoomPlanear/imZoomProfesiograma_0.png" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <a href="PerfDemografico/frmPlPerfDemografico.aspx">
                                <asp:Image ID="imTotalPerfilSocioDemografico" runat="server" ImageUrl="~/Images/ZoomPlanear/imZoomPerfilSocioDemografico_0.png" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <a href="MatrizRiesgos/frmMtRgMatrizRiesgos.aspx">
                                <asp:Image ID="imTotalMatrizRiesgos" runat="server" ImageUrl="~/Images/ZoomPlanear/imZoomMatrizRiesgos_0.png" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Image ID="imTotalMatrizLegal" runat="server" ImageUrl="~/Images/ZoomPlanear/imZoomMatrizLegal_0.png" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Image ID="imTotalProgramasVigilancia" runat="server" ImageUrl="~/Images/ZoomPlanear/imZoomProgramaVigilancia_0.png" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Image ID="imTotalProgramasGestion" runat="server" ImageUrl="~/Images/ZoomPlanear/imZoomProgramaGestion_0.png" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Image ID="imTotalPoliticasYObjetivos" runat="server" ImageUrl="~/Images/ZoomPlanear/imZoomPoliticasYObjetivos_0.png" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
