<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrRptActividades.ascx.vb" Inherits="wSoftCentroErgonomia.ctrRptActividades" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />
<table align="center">
    <tr>
        <td align="center">
            <asp:Panel ID="pnlRptActividades" runat="server">
                <table align="center">
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="imBtnExportarExcel" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/imBtnExportarExcel.fw.png" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                              <asp:GridView ID="gvRptActividades" runat="server" AutoGenerateColumns="False" CssClass="gvGeneral" DataSourceID="odsRptActividades" FooterStyle-CssClass="gvFooter" AllowSorting="True">
                    <Columns>
                        <asp:BoundField DataField="eactNombre" HeaderText="Actividad" SortExpression="eactNombre">
                            <ItemStyle HorizontalAlign="Left" />
                         </asp:BoundField>
                        <asp:BoundField DataField="StrProceso" HeaderText="Proceso" SortExpression="StrProceso">
                             <ItemStyle HorizontalAlign="Left" />
                         </asp:BoundField>
                        <asp:BoundField DataField="tmpTiempoInvertidoAnual" HeaderText="Tiempo Invertido Anual (Horas)" SortExpression="tmpTiempoInvertidoAnual" DataFormatString="{0:#,#.00}">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tmpPorcTiempoInv" HeaderText="% Tiempo Invertido" SortExpression="tmpPorcTiempoInv" DataFormatString="{0:0.00\%}" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tmpCostoAnual" HeaderText="Costo Anual" SortExpression="tmpCostoAnual" DataFormatString="${0:#,#}" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tmpPromSatisfaccion" HeaderText="Promedio Satisfacción" SortExpression="tmpPromSatisfaccion" DataFormatString="{0:0.00\%}" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tmpPromDificultad" HeaderText="Promedio Dificultad" SortExpression="tmpPromDificultad" DataFormatString="{0:0.00\%}" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tmpTotalVolumen" HeaderText="Total Volumen" SortExpression="tmpTotalVolumen" DataFormatString="{0:#,#}">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tmpCantCargos" HeaderText="Cantidad de Cargos que Intervienen" SortExpression="tmpCantCargos" DataFormatString="{0:#,#}">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tmpPorcTiempoDedicaActNoEstPerfil" HeaderText="% de Tiempo dedicado a la actividad por cargos que no la tienen asociada" SortExpression="tmpPorcTiempoDedicaActNoEstPerfil" DataFormatString="{0:0.00\%}" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle CssClass="gvFooter" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRptActividades" runat="server" SelectMethod="GetTblRptActividades" TypeName="dllSoftCentroErgonomia.Empresa.clEmpActividad">
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