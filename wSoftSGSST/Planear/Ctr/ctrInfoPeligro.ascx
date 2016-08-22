<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrInfoPeligro.ascx.vb" Inherits="wSoftSGSST.ctrInfoPeligro" %>
<%@ Register Src="ctrProceso.ascx" TagName="ctrProceso" TagPrefix="uc1" %>
<%@ Register Src="ctrLugar.ascx" TagName="ctrLugar" TagPrefix="uc2" %>
<%@ Register Src="ctrMtRsControlesExistentes.ascx" TagName="ctrMtRsControlesExistentes" TagPrefix="uc3" %>
<%@ Register Src="ctrMtRsCriControles.ascx" TagName="ctrMtRsCriControles" TagPrefix="uc4" %>
<%@ Register Src="ctrMtRsMedIntervencion.ascx" TagName="ctrMtRsMedIntervencion" TagPrefix="uc5" %>
<%@ Register Src="~/Planear/Ctr/ctrEvaluacionPeligro.ascx" TagPrefix="uc1" TagName="ctrEvaluacionPeligro" %>

<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<%--<asp:UpdatePanel ID="upnlInfoPeligro" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>
<table>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblNomActividad" runat="server" Text="Actividad"></asp:Label>

        </td>
        <td align="left">

            <asp:Label ID="lblActividad" runat="server"></asp:Label>

        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">

            <uc1:ctrProceso ID="ctrProceso1" runat="server" />

        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <asp:Label ID="lblCargosRel" runat="server">Cargos Relacionados</asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <table align="center">
                <tr>
                    <td>
                        <asp:Panel ID="pnlCargos" runat="server" CssClass="pnlContentGv">
                            <asp:GridView ID="gvCargos" runat="server" AutoGenerateColumns="False" CssClass="gvSGSST" DataSourceID="odsCargos">
                                <Columns>
                                    <asp:BoundField HeaderText="Cargos Relacionados" DataField="sgcaNombre" SortExpression="sgcaNombre" />
                                </Columns>
                                <AlternatingRowStyle CssClass="gvSGSST_Tr_Alternate" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsCargos" runat="server" SelectMethod="GetTblInfoCargoXIdPeligro" TypeName="dllSoftSGSST.SGSST.clSgsstCargo">
                                <SelectParameters>
                                    <asp:Parameter Name="parIdPeligro" Type="Int32" />
                                    <asp:Parameter Name="parIdEstado" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">

            <uc2:ctrLugar ID="ctrLugar1" runat="server" />

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblRutinaria" runat="server" Text="Rutinaria"></asp:Label>

        </td>
        <td align="left">

            <asp:DropDownList ID="ddlRutinaria" runat="server">
                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>

        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td align="left" colspan="2">

            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PnlInfo/imPnlInfoPeligro.png" />

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel" valign="top">

            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>

        </td>
        <td align="left">

            <asp:TextBox ID="txtDescripcion" runat="server" Width="400px" Height="100px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblNomClasificacion" runat="server" Text="Clasificación"></asp:Label>

        </td>
        <td align="left">

            <asp:Label ID="lblClasificacion" runat="server"></asp:Label>

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">

            <asp:Label ID="lblNomRiesgo" runat="server" Text="Riesgo"></asp:Label>

        </td>
        <td align="left">

            <asp:Label ID="lblRiesgo" runat="server"></asp:Label>

        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">

            <asp:ImageButton ID="ibtnIncluirRiesgo" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnIncluirRiesgoVerde.png" />

        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">&nbsp;</td>
        <td align="left">&nbsp;</td>
    </tr>
    <tr>
        <td align="center" colspan="2">

            <asp:ImageButton ID="ibtnCtrExistentes" runat="server" CausesValidation="false" ImageUrl="~/Images/OpcPagina/ibtnCtrExistentesAzul.png" />
            <asp:ImageButton ID="ibtnEvaluacionRiesgo" runat="server" CausesValidation="false" ImageUrl="~/Images/OpcPagina/ibtnEvalRiesgosAzul.png" />
            <asp:ImageButton ID="ibtnCriControles" runat="server" CausesValidation="false" ImageUrl="~/Images/OpcPagina/ibtnCriteriosCtrAzul.png" />
            <asp:ImageButton ID="ibtnMedIntervencion" runat="server" CausesValidation="false" ImageUrl="~/Images/OpcPagina/ibtnMedIntervencionAzul.png" />
        </td>
    </tr>
</table>

<%--VENTANA MODAL--%>
<asp:Button ID="btnFake123" runat="server" CausesValidation="False" Style="display: none" ToolTip="Editar Parámetro" />
<ajaxToolkit:ModalPopupExtender ID="modalInfoAdicPeligro" runat="server" BackgroundCssClass="cssModalBackGround" Enabled="True" PopupControlID="pnlInfoAdicPeligro" TargetControlID="btnFake123">
</ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlInfoAdicPeligro" runat="server" CssClass="ModalPoup" Style="display: none">
    <asp:UpdatePanel ID="upnlInfoAdicPeligro" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td align="right">

                        <asp:ImageButton ID="ibtnCerrarInfoAdicPeligro" runat="server" ImageUrl="~/Images/General/ibtnCerrarModal.png" CausesValidation="false" />

                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTituloInfoAdicPeligro" runat="server" CssClass="tituloForm"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="pnlInfoBasicaPeligro" runat="server" CssClass="pnlContentInfoGris">
                                        <table>
                                            <tr>
                                                <td align="left" class="tdLabel">
                                                    <asp:Label ID="bNomDescPeligro" runat="server" Text="Descripción del Peligro"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDescPeligro" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="tdLabel">
                                                    <asp:Label ID="lblNomClasiPeligro" runat="server" Text="Clasificación del Peligro"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblClasiPeligro" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <asp:Panel ID="pnlInfoAdicParamPeligro" runat="server">
                                                        <table>
                                                            <tr>
                                                                <td align="left" class="tdLabel">
                                                                    <asp:Label ID="lblNomEvalPeligro" runat="server">Evaluación del Peligro</asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblEvalPeligro" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="tdLabel">
                                                                    <asp:Label ID="lblNomNumExpuestos" runat="server">Número de Expuestos</asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblNumExpuestos" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="tdLabel">
                                                                    <asp:Label ID="lblNomPeorConsec" runat="server">Peor Consecuencia</asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPeorConsec" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="tdLabel">
                                                                    <asp:Label ID="lblNomReqLegal" runat="server">Requisito Legal</asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblReqLegal" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Panel ID="pnlCtrExistentes" runat="server">
                            <uc3:ctrMtRsControlesExistentes ID="ctrMtRsControlesExistentes1" runat="server" />

                        </asp:Panel>
                        <asp:Panel ID="pnlCriteriosCtr" runat="server">

                            <uc4:ctrMtRsCriControles ID="ctrMtRsCriControles1" runat="server" />

                        </asp:Panel>
                        <asp:Panel ID="pnlMedIntervencion" runat="server">

                            <uc5:ctrMtRsMedIntervencion ID="ctrMtRsMedIntervencion1" runat="server" />

                        </asp:Panel>
                        <asp:Panel ID="pnlEvalPeligro" runat="server">
                            <uc1:ctrEvaluacionPeligro runat="server" ID="ctrEvaluacionPeligro" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

<%-- VENTANA MODAL EVALUACION DEL RIESGO --%>
<%-- <asp:Button ID="btnFake2" runat="server" CausesValidation="False" Style="display: none" ToolTip="Editar Parámetro" />
        <ajaxToolkit:ModalPopupExtender ID="modalEvalPeligro" runat="server" BackgroundCssClass="cssModalBackGround" Enabled="True" PopupControlID="pnlEvalPeligro" TargetControlID="btnFake2">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="pnlEvalPeligro" runat="server" CssClass="ModalPoup" Style="display: none">
            <uc1:ctrEvaluacionPeligro runat="server" ID="ctrEvaluacionPeligro" />
        </asp:Panel>--%>
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>
