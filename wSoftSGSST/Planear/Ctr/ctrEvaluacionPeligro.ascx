<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrEvaluacionPeligro.ascx.vb" Inherits="wSoftSGSST.ctrEvaluacionPeligro" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<asp:UpdatePanel ID="upnlEvaluacionRiesgo" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlEvaluacionPeligro" runat="server" CssClass="pnlContentInfo">
            <table>
                <tr>
                    <td colspan="3" align="right">
                        <asp:ImageButton ID="ibtnCerrar" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblEvalPeligro" runat="server" Text="Evaluación del Riesgo"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlDescripcion" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNomDescPeligro" runat="server" Text="Descripción del Peligro"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDescPeligro" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNomClasifPeligro" runat="server" Text="Clasificación del Peligro"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblClasifPeligro" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblExplicacion" runat="server" Text="Solo es necesario ingresar los valores del " Font-Italic="true"></asp:Label>
                        <asp:Label ID="lblExplicacion2" runat="server" Text="Nivel de Deficiencia, Nivel de Esposicion y Nivel de Consecuencia." Font-Bold="true" Font-Italic="true"></asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:Label ID="lblNomCriterio" runat="server" Text="Criterio"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblNomValoracion" runat="server" Text="Valoración"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblNomExpValoracion" runat="server" Text="Explicación Valoración"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNivDef" runat="server" Text="Nivel de Deficiencia ND"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNivDef" runat="server" AutoPostBack="True" Width="180px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Panel ID="pnlExpNivDef" runat="server" Width="400px">
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblExpNivDef" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNivExp" runat="server" Text="Nivel de Exposición NE"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNivExp" runat="server" AutoPostBack="True" Width="180px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Panel ID="pnlExpNivExp" runat="server" Width="400px">
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblExpNivExp" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNivProb" runat="server" Text="Nivel de Probabilidad (ND * NE)"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblValNivProb" runat="server" Text="" style="align-content:center"></asp:Label>
                    </td>
                    <td>
                        <asp:Panel ID="pnlExpNivProb" runat="server" Width="400px">
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblExpNivProb" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNivCons" runat="server" Text="Nivel de Consecuencia NC"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNivCons" runat="server" AutoPostBack="True" Width="180px">
                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                            <asp:ListItem Value="1">Mortal o Catastrofico (M)</asp:ListItem>
                            <asp:ListItem Value="1">Muy Grave (MG)</asp:ListItem>
                            <asp:ListItem Value="3">Grave (G)</asp:ListItem>
                            <asp:ListItem Value="4">Leve (L)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Panel ID="pnlExpNivCons" runat="server" Width="400px">
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblExpNivCons" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNivRies" runat="server" Text="Nivel de Riesgo"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblValNivRies" runat="server" Text="" style="align-content:center"></asp:Label>
                    </td>
                    <td>
                        <asp:Panel ID="pnlExpNivRies" runat="server" Width="400px">
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblExpNivRies" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAcepNiv" runat="server" Text="Aceptabilidad Nivel de Riesgo"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblValAcepNiv" runat="server" Text="" style="align-content:center"></asp:Label>
                    </td>
                    <td>
                        <asp:Panel ID="pnlExpValAcep" runat="server" Width="400px">
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblExpValAcep" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:ImageButton ID="ibtnGuardarEval" runat="server" ImageUrl="~/Images/Botones/ibtnGuardarInfoVerde.png" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

