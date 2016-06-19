<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrPreguntasEncuesta.ascx.vb" Inherits="wSoftCentroErgonomia.ctrPreguntasEncuesta" %>
<%@ Register Src="ctrCargosReporta.ascx" TagName="ctrCargosReporta" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />
<style type="text/css">
    .tdleft {
        width: 250px;
    }
</style>

<asp:UpdatePanel ID="upnlPreguntasEncuesta" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlPreguntasEncuesta" runat="server" CssClass="pnlAgrupadorGral">
            <table align="center">
                <tr>
                    <td align="left" class="tdleft">
                        <asp:Label ID="Label9" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="1. A quién reporta usted?"></asp:Label>

                    </td>
                    <td align="left">
                        <uc1:ctrCargosReporta ID="ctrCargosReportaQuienReporta" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="tdleft">
                        <asp:Label ID="Label6" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="2. A quién le reporta usted?"></asp:Label>
                    </td>
                    <td align="left">
                        <uc1:ctrCargosReporta ID="ctrCargosReportaAQuienReporta" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <asp:Label ID="Label7" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="3. Indicadores más importantes de su cargo y de los procesos de los cuales hace parte"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="txtIndicadores" runat="server" Width="610px" Height="80px" Style="margin-left:40px;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="tdleft">
                        <asp:Label ID="Label10" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="4. Cuál es el objetivo del cargo?"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtObjetivosCargo" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="tdleft">
                        <asp:Label ID="Label11" runat="server" CssClass="lblValidador" Text="(*)"></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text="5. Estimado de horas adicionales (meses)"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtHorasExtras" runat="server"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txtHorasExtras_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtHorasExtras">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
