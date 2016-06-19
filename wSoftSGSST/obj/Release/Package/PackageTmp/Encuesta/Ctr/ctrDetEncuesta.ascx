<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrDetEncuesta.ascx.vb" Inherits="wSoftCentroErgonomia.ctrDetEncuesta" %>
<%@ Register Src="~/Comun/Ctr/ctrBusquedaActividad.ascx" TagPrefix="uc1" TagName="ctrBusquedaActividad" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

<asp:UpdatePanel ID="upnlDetEncuesta" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlDetInfoEncuesta" runat="server" CssClass="pnlAgrupadorGral">
                        <table align="center">
                            <tr>
                                <td align="left" colspan="2">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label9" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <uc1:ctrBusquedaActividad runat="server" ID="ctrBusquedaActividad" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left"></td>
                                <td align="left">
                                    <asp:Label ID="lblPorcDedicacion" runat="server" Text="Porcentaje Dedicación (%)"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPorcDedicacion" runat="server"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="txtPorcDedicacion_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtPorcDedicacion" ValidChars="0123456789,">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label2" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblVolumen" runat="server" Text="Volumen (Mensual)"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtVolumen" runat="server"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="txtVolumen_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtVolumen">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                                <td align="left"></td>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblDificultad" runat="server" Text="Qué tan difícil es la actividad"></asp:Label>
                                </td>
                                <td align="left">
                                    <table align="left" cellpadding="4" cellspacing="0">
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDificultad1" runat="server" ImageUrl="~/Images/Botones/imBtnDificultadUno.fw.png" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDificultad2" runat="server" ImageUrl="~/Images/Botones/imBtnDificultadDos.fw.png" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDificultad3" runat="server" ImageUrl="~/Images/Botones/imBtnDificultadTres.fw.png" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDificultad4" runat="server" ImageUrl="~/Images/Botones/imBtnDificultadCuatro.fw.png" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDificultad5" runat="server" ImageUrl="~/Images/Botones/imBtnDificultadCinco.fw.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label4" runat="server" Text="(*)" CssClass="lblValidador"></asp:Label>
                                    <asp:Label ID="lblDisfruta" runat="server" Text="Cuánto disfruta hacer la actividad"></asp:Label>
                                </td>
                                <td align="left">
                                    <table align="left" cellpadding="4" cellspacing="0">
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDisfruta1" runat="server" ImageUrl="~/Images/Botones/imBtnDisfruta1.png" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDisfruta2" runat="server" ImageUrl="~/Images/Botones/imBtnDisfruta2.png" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDisfruta3" runat="server" ImageUrl="~/Images/Botones/imBtnDisfruta3.png" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDisfruta4" runat="server" ImageUrl="~/Images/Botones/imBtnDisfruta4.fw.png" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnDisfruta5" runat="server" ImageUrl="~/Images/Botones/imBtnDisfruta5.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left"></td>
                                <td align="left"></td>
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td align="left"></td>
                                <td align="left"></td>
                                <td align="left"></td>
                                <td align="left"></td>
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td align="right" colspan="5">
                                    <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" Text="Cancelar" />
                                    <asp:Button ID="btnGuardar" runat="server" CausesValidation="False" Text="Guardar" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlGvDetEncuesta" runat="server">
                        <table align="center" cellpadding="0">
                            <tr>
                                <td align="right">
                                    <table align="right">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblPorcTotal" runat="server" Text="Porcentaje Total Dedicación:" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblValPorcTotalDedica" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" width="30px">
                                                
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label7" runat="server" Text="Porcentaje Dedicación Faltante:" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblPorcFaltante" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="gvDetEncuesta" runat="server" AutoGenerateColumns="False" DataKeyNames="tmpIdTabla" CssClass="gvGeneral">
                                        <Columns>
                                            <asp:BoundField HeaderText="Código Actividad" DataField="tmpStrCodActividad" />
                                            <asp:BoundField HeaderText="Actividad" DataField="tmpStrActividad" >
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Porcentaje Dedicación (%)">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtProcDedica" runat="server" AutoPostBack="True" OnTextChanged="txtProcDedica_TextChanged" Text='<%# Bind("tmpPorcDedicacion") %>' Width="50px"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="txtProcDedica_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom" TargetControlID="txtProcDedica" ValidChars="0123456789,">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Volumen (Mensual)" DataField="tmpVolumen" />
                                            <asp:TemplateField HeaderText="Dificultad de la Actividad">
                                                <ItemTemplate>
                                                    <asp:Image ID="iDificultad1" runat="server" ImageUrl='<%# GetImagenDificultad(Eval("tmpDificultad")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Disfruta hacer la Actividad">
                                                <ItemTemplate>
                                                    <asp:Image ID="iDisfruta2" runat="server" ImageUrl='<%# GetImagenDisfruta(Eval("tmpDisfruta")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" HeaderText="Editar" Text="Editar" ImageUrl="~/Images/Botones/imBtnEditar.fw.png" />
                                            <asp:ButtonField ButtonType="Image" CommandName="cmdEliminar" HeaderText="Eliminar" ImageUrl="~/Images/Botones/imBtnEliminar.fw.png" Text="Button" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
