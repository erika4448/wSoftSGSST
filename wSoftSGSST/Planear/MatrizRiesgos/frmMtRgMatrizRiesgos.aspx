<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstSGSST.Master" CodeBehind="frmMtRgMatrizRiesgos.aspx.vb" Inherits="wSoftSGSST.frmMtRgMatrizRiesgos" %>

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
    <asp:UpdatePanel ID="upnlMatrizRiesgos" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblPathPagina" runat="server" Text="Planear / Matriz de Riesgos" CssClass="pathMenu"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table align="center" width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitulo" runat="server" Text="Matriz de Peligros" CssClass="tituloForm"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table width="100%">
                            <tr>
                                <td align="left">
                                    <table>
                                        <tr>
                                            <td align="left">
                                                <asp:ImageButton ID="ibtnFiltrosConsulta" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnFiltrosConsulta.png" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:ImageButton ID="ibtnEscogerCampos" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnEscogerCampos.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="ibtnMatrizPDF" runat="server" CausesValidation="false" ImageUrl="~/Images/Botones/ibtnMatrizPDF.png" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlMatrizRiesgos" runat="server">
                            <asp:GridView ID="gvMatrizRiesgos" runat="server" AutoGenerateColumns="False" CssClass="gvSGSST" DataSourceID="odsMatrizRiesgos" DataKeyNames="sgplIdPeligro">
                                <Columns>
                                    <asp:BoundField HeaderText="Procesos" DataField="StrProcesos" SortExpression="StrProcesos" />
                                    <asp:BoundField HeaderText="Cargos" DataField="StrCargos" SortExpression="StrCargos" />
                                    <asp:BoundField HeaderText="Actividad" DataField="StrActividad" SortExpression="StrActividad" />
                                    <asp:BoundField HeaderText="Descripción Peligro" DataField="StrDescripcionPeligro" SortExpression="StrDescripcionPeligro" />
                                    <asp:BoundField HeaderText="Clasificación Peligro" DataField="StrClasificacionPeligro" SortExpression="StrClasificacionPeligro" />
                                    <asp:BoundField HeaderText="Riesgo" DataField="StrRiesgo" SortExpression="StrRiesgo" />
                                    <asp:BoundField HeaderText="Nivel del Riesgo" DataField="sepValorNivRiesgo" SortExpression="sepValorNivRiesgo" />
                                    <asp:BoundField HeaderText="Interpretación del Riesgo" DataField="StrInterpretacionRiesgo" SortExpression="StrInterpretacionRiesgo" />
                                    <asp:BoundField HeaderText="Aceptabilidad Riesgo" DataField="StrAceptabilidad" SortExpression="StrAceptabilidad" />
                                    <asp:ButtonField ButtonType="Image" CommandName="cmdMedidas" HeaderText="Medidas" ImageUrl="~/Images/General/ibtnMedidaIntervencion.png" Text="Button" />
                                    <asp:ButtonField ButtonType="Image" CommandName="cmdCalificar" HeaderText="Calificar" ImageUrl="~/Images/General/ibtnCalificarRiesgo.png" Text="Button" />
                                </Columns>
                                <AlternatingRowStyle CssClass="gvSGSST_Tr_Alternate" />
                            </asp:GridView>
                            <asp:DropDownList ID="ddlNumPagMatrizRiesgos" runat="server" Width="50px">
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>80</asp:ListItem>
                                <asp:ListItem>160</asp:ListItem>
                                <asp:ListItem>320</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsMatrizRiesgos" runat="server" SelectMethod="GetTblInfoPeligroMatRiesgos" TypeName="dllSoftSGSST.SGSST.clSgsstPeligro">
                                <SelectParameters>
                                    <asp:Parameter Name="parIdEmpresa" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>
