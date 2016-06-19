<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrRptTiempoXProceso.ascx.vb" Inherits="wSoftCentroErgonomia.ctrRptTiempoXProceso" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />
<table align="center">
    <tr>
        <td align="center">
            <asp:Panel ID="pnlRptTiempoXProc" runat="server">
                <table align="center">
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="imBtnExportarExcel" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/imBtnExportarExcel.fw.png" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvRptTiempoXProc" runat="server" AutoGenerateColumns="False" CssClass="gvGeneral" DataSourceID="odsRptTiempoXProc" ShowFooter="True" FooterStyle-CssClass="gvFooter" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Proceso" SortExpression="eprcNombre">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblProceso" runat="server" Text='<%# Bind("eprcNombre")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tiempo Invertido Anual" SortExpression="tmpTiempoInvertidoAnual">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalTiempoInvAnual" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTiempoInvAnual" runat="server" Text='<%# Bind("tmpTiempoInvertidoAnual", "{0:#,#.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Costo Anual" SortExpression="tmpCostoAnual">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCostoAnual" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostoAnual" runat="server" Text='<%# Bind("tmpCostoAnual", "${0:#,#}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad Actividades" SortExpression="tmpCantidadActividades">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCantActividades" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCantActividades" runat="server" Text='<%# Bind("tmpCantidadActividades", "{0:#,#.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tiempo Promedio Anual por Actividad" SortExpression="tmpTiempoPromAct">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalTiempoPromAnualXAct" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTiempoPromAnualXAct" runat="server" Text='<%# Bind("tmpTiempoPromAct", "{0:#,#.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Costo Promedio Anual por Actividad" SortExpression="tmpCostoPromAct">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCostoPromAnualXAct" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostoPromAnualXAct" runat="server" Text='<%# Bind("tmpCostoPromAct", "${0:#,#}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Promedio Satisfacción" SortExpression="tmpPromedioSatisfaccion">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPromSatisfaccion" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPromSatisfaccion" runat="server" Text='<%# Bind("tmpPromedioSatisfaccion", "{0:#,#.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Promedio Dificultad" SortExpression="tmpPromedioDificultad">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPromDificultad" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPromDificultad" runat="server" Text='<%# Bind("tmpPromedioDificultad", "{0:#,#.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="% Actividades Complementarias" SortExpression="tmpPorcActComplementarias">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPorcActComp" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPorcActComp" runat="server" Text='<%# Bind("tmpPorcActComplementarias", "{0:0.00\%}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="% Actividades Fuera de Perfil" SortExpression="tmpPorcActFueraPerfil">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPorcActFueraPF" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPorcActFueraPF" runat="server" Text='<%# Bind("tmpPorcActFueraPerfil", "{0:0.00\%}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="gvFooter" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsRptTiempoXProc" runat="server" SelectMethod="GetTblRptTiempoXProceso" TypeName="dllSoftCentroErgonomia.Empresa.clEmpProceso">
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
