<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstCentroErgonomia.Master" CodeBehind="frmConsultaProcEmpleado.aspx.vb" Inherits="wSoftCentroErgonomia.frmConsultaProcEmpleado" %>
<%@ Register src="Ctr/ctrBusquedaProcesaEmpleado.ascx" tagname="ctrBusquedaProcesaEmpleado" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
        <link href="../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

    <asp:UpdatePanel ID="upnlProcesamientoEmpleado" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitulo" runat="server" Text="CONSULTA INFORMACIÓN EMPLEADOS" CssClass="lblTituloPagina"></asp:Label>
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
                                                    
                                                    <uc1:ctrBusquedaProcesaEmpleado ID="ctrBusquedaProcesaEmpleado1" runat="server" />
                                                    
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
                        <asp:Panel ID="pnlGvProcesamientoEmpleado" runat="server">
                            <asp:GridView ID="gvProcesamientoEmpleado" runat="server" AutoGenerateColumns="False" DataSourceID="odsProcesamientoEmpleado" AllowSorting="True" CssClass="gvGeneral" DataKeyNames="ecenIdCabEncuesta">
                                <Columns>
                                    <asp:BoundField HeaderText="Cédula" DataField="eempNumDocumento" SortExpression="eempNumDocumento" />
                                    <asp:BoundField HeaderText="Nombre Completo" DataField="eempNombreCompleto" SortExpression="eempNombreCompleto" />
                                    <asp:BoundField HeaderText="Fecha Registro" DataField="ecenFchRegistro" SortExpression="ecenFchRegistro" />
                                    <asp:BoundField HeaderText="Sede" DataField="StrSede" SortExpression="StrSede" />
                                    <asp:BoundField HeaderText="Cargo" DataField="StrCargo" SortExpression="StrCargo" />
                                    <asp:BoundField HeaderText="Área" DataField="StrArea" SortExpression="StrArea" />
                                    <asp:BoundField DataField="StrNivelOrganizacional" HeaderText="Nivel Organizacional" SortExpression="StrNivelOrganizacional" />
                                    <asp:BoundField HeaderText="Salario" DataField="eempSalario" SortExpression="eempSalario" />
                                    <asp:BoundField HeaderText="Tiempo en el Cargo" DataField="ecenTiempoCargoEmplDigi" SortExpression="ecenTiempoCargoEmplDigi" />
                                    <asp:BoundField HeaderText="Nivel Escolaridad" DataField="StrNivelEscolaridad" SortExpression="StrNivelEscolaridad" />
                                    <asp:BoundField HeaderText="Último Título Alcanzado" DataField="ecenStrUltimoTitulo" SortExpression="ecenStrUltimoTitulo" />
                                    <asp:BoundField DataField="StrEstCoincideTituObj" HeaderText="Coincide Título Objetivo" SortExpression="StrEstCoincideTituObj" />
                                    <asp:BoundField HeaderText="Educación Perfil" DataField="StrEducacionPerfil" SortExpression="StrEducacionPerfil" />
                                    <asp:BoundField HeaderText="Coincide Educación" DataField="StrEstCoincideEduca" SortExpression="StrEstCoincideEduca" />
                                    <asp:BoundField HeaderText="Reporta a" DataField="StrCargosQuienReporta" SortExpression="StrCargosQuienReporta" />
                                    <asp:BoundField HeaderText="Le Reporta a" DataField="StrCargosAQuienReporta" SortExpression="StrCargosAQuienReporta" />
                                    <asp:TemplateField HeaderText="Objetivo Cargo">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Height="56px" Text='<%# bind("ecenPrgStrObjetivoCargo") %>' TextMode="MultiLine" Width="327px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Indicadores Principales">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Height="56px" Text='<%# bind("ecenPrgStrIndicaPrincipal") %>' TextMode="MultiLine" Width="327px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Horas Adicionales" DataField="ecenPorcTiempoAdic" SortExpression="ecenPorcTiempoAdic" />
                                    <asp:BoundField HeaderText="% Tiempo Adicional" DataField="ecenPorcTiempoAdic" SortExpression="ecenPorcTiempoAdic" />
                                    <asp:BoundField HeaderText="% Total Laborado" DataField="ecenPorcTotalLabora" SortExpression="ecenPorcTotalLabora" />
                                    <asp:BoundField DataField="StrSobrecarga" HeaderText="Sobrecarga" SortExpression="StrSobrecarga" />
                                    <asp:BoundField DataField="StrEstPerfilCargo" HeaderText="Perfil Cargo" SortExpression="StrEstPerfilCargo" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsProcesamientoEmpleado" runat="server" SelectMethod="GetTblCabEncuestaXCriConsulta" TypeName="dllSoftCentroErgonomia.Encuesta.clEncCabEncuesta">
                                <SelectParameters>
                                    <asp:Parameter Name="parIdEmpresa" Type="Int32" />
                                    <asp:Parameter Name="parIdSede" Type="Int32" />
                                    <asp:Parameter Name="parIdArea" Type="Int32" />
                                    <asp:Parameter Name="parIdCargo" Type="Int32" />
                                    <asp:Parameter Name="parIdEstCabEncuesta" Type="Int32" />
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
