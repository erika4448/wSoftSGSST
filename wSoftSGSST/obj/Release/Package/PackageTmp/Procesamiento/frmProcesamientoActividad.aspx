<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstCentroErgonomia.Master" CodeBehind="frmProcesamientoActividad.aspx.vb" Inherits="wSoftCentroErgonomia.frmProcesamientoActividad" EnableEventValidation="false" %>

<%@ Register Src="Ctr/ctrBusquedaXEmpresa.ascx" TagName="ctrBusquedaXEmpresa" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .rbList {
            border-style:solid;
            border-color:white;
            border-width:1px;
        }

        .rbList table {
            border-style:solid;
            border-color:white;
            border-width:1px;
        }

        .rbList td {
            border-style:solid;
            border-color:white;
            border-width:1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <link href="../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

    <asp:UpdatePanel ID="upnlProcesamiento" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitulo" runat="server" Text="PROCESAMIENTO INFORMACIÓN ACTIVIDADES" CssClass="lblTituloPagina"></asp:Label>
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
                                    <asp:Panel ID="pnlBusqueda" runat="server" CssClass="pnlAgrupadorGral">
                                        <table align="center">
                                            <tr>
                                                <td align="center">
                                                    <uc1:ctrBusquedaXEmpresa ID="ctrBusquedaXEmpresa1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CausesValidation="False" />
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
                    <td align="left">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlGvProcesamiento" runat="server">
                            <asp:GridView ID="gvProcesamiento" runat="server" AutoGenerateColumns="False" DataSourceID="odsProcesamiento" AllowSorting="True" CssClass="gvGeneral" DataKeyNames="edenIdDetEncuesta">
                                <Columns>
                                    <asp:BoundField HeaderText="Cédula" DataField="StrCedulaEmp" SortExpression="StrCedulaEmp" />
                                    <asp:BoundField HeaderText="Sede" DataField="StrSedeEmp" SortExpression="StrSedeEmp" />
                                    <asp:BoundField HeaderText="Cargo" DataField="StrCargoEmp" SortExpression="StrCargoEmp" />
                                    <asp:BoundField HeaderText="Código" DataField="StrCodigoActividad" SortExpression="StrCodigoActividad" />
                                    <asp:BoundField HeaderText="Actividad" DataField="StrActividad" SortExpression="StrActividad" />
                                    <asp:BoundField HeaderText="Tipo de Actividad" />
                                    <asp:BoundField HeaderText="Tipo de Proceso" DataField="StrTipoProceso" SortExpression="StrTipoProceso" />
                                    <asp:BoundField HeaderText="Proceso" DataField="StrProceso" SortExpression="StrProceso" />
                                    <asp:BoundField HeaderText="Procedimiento" DataField="StrProcedimiento" SortExpression="StrProcedimiento" />
                                    <asp:BoundField HeaderText="% Dedicación" DataField="tmpPorcDedicacion" SortExpression="tmpPorcDedicacion" />
                                    <asp:BoundField HeaderText="Volumen" DataField="tmpVolumen" SortExpression="tmpVolumen" />
                                    <asp:BoundField HeaderText="Dificultad" DataField="tmpDificultad" SortExpression="tmpDificultad" />
                                    <asp:BoundField HeaderText="Satisfacción" DataField="tmpSatisfaccion" SortExpression="tmpSatisfaccion" />
                                    <asp:BoundField HeaderText="Salario" DataField="tmpSalario" SortExpression="tmpSalario" />
                                    <asp:BoundField HeaderText="Costo Mensual (Calculado)" DataField="tmpCostoMensual" SortExpression="tmpCostoMensual" />
                                    <asp:BoundField HeaderText="Costo Unitario (Calculado)" DataField="tmpCostoUnitario" SortExpression="tmpCostoUnitario" />
                                    <asp:BoundField HeaderText="Horas Jornada" DataField="tmpHorasJornada" SortExpression="tmpHorasJornada" />
                                    <asp:BoundField HeaderText="Horas Adicionales" DataField="tmpHorasAdicionales" SortExpression="tmpHorasAdicionales" />
                                    <asp:BoundField HeaderText="Total Horas (Calculado)" DataField="tmpHorasTotales" SortExpression="tmpHorasTotales" />
                                    <asp:BoundField HeaderText="Tiempo por Actividad (Calculado)" DataField="tmpTiempoActual" SortExpression="tmpTiempoActual" />
                                    <asp:BoundField HeaderText="Tiempo Unitario (Calculado)" DataField="tmpTiempoUnitario" SortExpression="tmpTiempoUnitario" />
                                    <asp:BoundField HeaderText="Perfil o No (Calculado)" DataField="tmpEstPerfilCargo" SortExpression="tmpEstPerfilCargo" />
                                    <asp:TemplateField HeaderText="Relación Actividad - Objetivo">
                                        <ItemTemplate>
                                             <asp:RadioButtonList ID="rblEstRelActObj" runat="server" RepeatDirection="Horizontal" style="border-color: white" BorderColor="Transparent" BorderStyle="Solid" BorderWidth="1px">
                                                <asp:ListItem Value="1"><img src="../Images/Botones/imBtnSi.fw.png" alt="" /></asp:ListItem>
                                                <asp:ListItem Value="2"><img src="../Images/Botones/imBtnNo.fw.png" alt="" /></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Complementaria">
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="rblEstComplementaria" runat="server" RepeatDirection="Horizontal" CssClass="rbList">
                                                <asp:ListItem Value="1"><img src="../Images/Botones/imBtnSi.fw.png" alt="" /></asp:ListItem>
                                                <asp:ListItem Value="2"><img src="../Images/Botones/imBtnNo.fw.png" alt="" /></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsProcesamiento" runat="server" SelectMethod="GetTblDetEncuestaXCriConsulta" TypeName="dllSoftCentroErgonomia.Encuesta.clEncDetEncuesta">
                                <SelectParameters>
                                    <asp:Parameter Name="parIdEmpresa" Type="Int32" />
                                    <asp:Parameter Name="parIdTipoProceso" Type="Int32" />
                                    <asp:Parameter Name="parIdProceso" Type="Int32" />
                                    <asp:Parameter Name="parIdProcedimiento" Type="Int32" />
                                    <asp:Parameter Name="parIdActividad" Type="Int32" />
                                    <asp:Parameter Name="parIdCargo" Type="Int32" />
                                    <asp:Parameter Name="parIdEstDetEncuesta" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
