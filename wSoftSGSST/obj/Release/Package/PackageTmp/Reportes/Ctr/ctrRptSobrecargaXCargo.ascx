<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrRptSobrecargaXCargo.ascx.vb" Inherits="wSoftCentroErgonomia.ctrRptSobrecargaXCargo" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />
<table align="center">
    <tr>
        <td align="center">
            <asp:Panel ID="pnlRptSobrecargaXCargo" runat="server">
                <table align="center">
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="imBtnExportarExcel" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/imBtnExportarExcel.fw.png" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvRptSobrecargaXCargo" runat="server" AutoGenerateColumns="False" CssClass="gvGeneral" DataSourceID="odsSobrecargaXCargo" FooterStyle-CssClass="gvFooter" AllowSorting="True">
                                <Columns>
                                    <asp:BoundField DataField="ecrgNombre" HeaderText="Cargo" SortExpression="ecrgNombre" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StrNivelOrganizacional" HeaderText="Nivel" SortExpression="StrNivelOrganizacional" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tmpSobrecarga" HeaderText="Sobrecarga" SortExpression="tmpSobrecarga" >
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tmpConceptoCargaLaboral" HeaderText="Concepto Carga Laboral" SortExpression="tmpConceptoCargaLaboral" />
                                </Columns>
                                <FooterStyle CssClass="gvFooter" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsSobrecargaXCargo" runat="server" SelectMethod="GetTblRptSobrecargaXCargo" TypeName="dllSoftCentroErgonomia.Empresa.clEmpCargo">
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
