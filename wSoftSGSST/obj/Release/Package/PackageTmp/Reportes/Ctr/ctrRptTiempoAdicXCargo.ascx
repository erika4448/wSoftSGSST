<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrRptTiempoAdicXCargo.ascx.vb" Inherits="wSoftCentroErgonomia.ctrRptTiempoAdicXCargo" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />
<table align="center">
    <tr>
        <td align="center">
            <asp:Panel ID="pnlRptTiempoAdicXCargo" runat="server">
                <table align="center">
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="imBtnExportarExcel" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/imBtnExportarExcel.fw.png" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvRptTiempoAdicXCargo" runat="server" AutoGenerateColumns="False" CssClass="gvGeneral" DataSourceID="odsRptTiempoAdicXCargo" ShowFooter="True" FooterStyle-CssClass="gvFooter" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Cargo" SortExpression="ecrgNombre">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCargo" runat="server" Text='<%# Bind("ecrgNombre")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Horas Adicionales Promedio" SortExpression="tmpPromHorasAdicionales">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPromHorasAdic" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPromHorasAdic" runat="server" Text='<%# Bind("tmpPromHorasAdicionales", "{0:#,#.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Promedio Satisfacción" SortExpression="tmpPromSatisfaccion">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPromSatisfaccion" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPromSatisfaccion" runat="server" Text='<%# Bind("tmpPromSatisfaccion", "{0:#,#.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Promedio Dificultad" SortExpression="tmpPromDificultad">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPromDificultad" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPromDificultad" runat="server" Text='<%# Bind("tmpPromDificultad", "{0:#,#.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="% Actividad Complementaria" SortExpression="tmpPorcActComplementaria">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPorcActComplementaria" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPorcActComplementaria" runat="server" Text='<%# Bind("tmpPorcActComplementaria", "{0:0.00\%}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="% Actividad Fuera de Perfil" SortExpression="tmpPorcActFueraPerfil">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPorcActFueraPF" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPorcActFueraPF" runat="server" Text='<%# Bind("tmpPorcActFueraPerfil", "{0:0.00\%}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="% Actividades no Relacionadas con el Objetivo" SortExpression="tmpPorcNoRelacionadas">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPorcActNoRel" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPorcActNoRel" runat="server" Text='<%# Bind("tmpPorcNoRelacionadas", "{0:0.00\%}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad Personas Entrevistadas en Cargo" SortExpression="tmpNumEmpleadosCargo">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalEmplCargo" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmplCargo" runat="server" Text='<%# Bind("tmpNumEmpleadosCargo", "{0:#,#}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Costo Total Salario Anual" SortExpression="tmpCostoAnualSalarioEmpl">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCostoAnualSalEmpl" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostoAnualSalEmpl" runat="server" Text='<%# Bind("tmpCostoAnualSalarioEmpl", "${0:#,#}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sumatoria del Tiempo por Actividad" SortExpression="tmpSumaTiempoEmpl">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSumaTiempoEmpl" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSumaTiempoEmpl" runat="server" Text='<%# Bind("tmpSumaTiempoEmpl", "{0:#,#.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="gvFooter" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsRptTiempoAdicXCargo" runat="server" SelectMethod="GetTblRptTiempoAdicXCargo" TypeName="dllSoftCentroErgonomia.Empresa.clEmpCargo">
                                <SelectParameters>
                                    <asp:Parameter Name="parIdEmpresa" Type="Int32" />
                                    <asp:Parameter Name="parIdSede" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
