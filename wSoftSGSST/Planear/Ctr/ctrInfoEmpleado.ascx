<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrInfoEmpleado.ascx.vb" Inherits="wSoftSGSST.ctrInfoEmpleado" %>
<%@ Register Src="../../Ctr/ctrFecha.ascx" TagName="ctrFecha" TagPrefix="uc1" %>
<%@ Register Src="../../Ctr/ctrPaisCiudadDep.ascx" TagName="ctrPaisCiudadDep" TagPrefix="uc2" %>
<%@ Register Src="ctrCargosEmpleado.ascx" TagName="ctrCargosEmpleado" TagPrefix="uc3" %>
<%If (False) Then %>
<link rel="Stylesheet" type="text/css" href="../../App_Themes/SoftSGSST.css" />
<%end if%>

<table>
    <tr>
        <td colspan="2">
            <asp:Panel ID="pnlInfoBasicaEmpleado" runat="server">
                <table width="100%" style="border-spacing:0px 1px!important;">
                    <tr>
                        <td align="left" class="tdLabel">
                            <asp:ImageButton ID="imEmpleado" runat="server" ImageUrl="~/Images/General/imAgregarFoto.png" />
                        </td>
                        <td align="center">
                            <table align="center">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblNombreEmpleado" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblAnios" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblTipDocNumDoc" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblCargo" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:ImageButton ID="ibtnEditarInfo" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnEditarInfoAzul.png" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left" class="tdLabel">&nbsp;</td>
        <td align="left">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="pnlInfoUsuario" runat="server">
                <table width="100%">
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Panel ID="pnlInfoUsuarioCreaMod" runat="server">
                                <table>
                                    <tr>
                                        <td align="left" class="tdLabel">
                                            <asp:Label ID="lblNombres" runat="server" Text="*Nombres Empleado"></asp:Label>
                                        </td>
                                        <td align="left">

                                            <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="tdLabel">
                                            <asp:Label ID="lblApellidos" runat="server" Text="*Apellidos Empleado"></asp:Label>
                                        </td>
                                        <td align="left">

                                            <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="tdLabel">
                                            <asp:Label ID="lblTipDoc" runat="server" Text="*Tipo Documento"></asp:Label>
                                        </td>
                                        <td align="left">

                                            <asp:DropDownList ID="ddlTipDoc" runat="server">
                                            </asp:DropDownList>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="tdLabel">
                                            <asp:Label ID="lblNumDoc" runat="server" Text="*Número Documento"></asp:Label>
                                        </td>
                                        <td align="left">

                                            <asp:TextBox ID="txtNumDoc" runat="server"></asp:TextBox>

                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="tdLabel">

                            <asp:Label ID="lblGenero" runat="server" Text="*Género"></asp:Label>

                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlGenero" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="tdLabel">

                            <asp:Label ID="lblFchNacimiento" runat="server" Text="*Fecha Nacimiento"></asp:Label>

                        </td>
                        <td align="left">
                            <uc1:ctrFecha ID="ctrFechaNacimiento" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">

                            <uc2:ctrPaisCiudadDep ID="ctrPaisCiudadDep1" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style1">

                            <asp:Label ID="lblEducacion" runat="server" Text="*Educación"></asp:Label>

                        </td>
                        <td align="left" class="auto-style1">
                            <asp:DropDownList ID="ddlEducacion" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="tdLabel">

                            <asp:Label ID="lblProfesion" runat="server" Text="*Profesión"></asp:Label>

                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlProfesion" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="tdLabel">

                            <asp:Label ID="lblEstCivil" runat="server" Text="*Estado Civil"></asp:Label>

                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlEstCivil" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">

                            <uc3:ctrCargosEmpleado ID="ctrCargosEmpleado1" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="tdLabel">

                            <asp:Label ID="lblTipoCont" runat="server" Text="*Tipo Contrato"></asp:Label>

                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlTipoContrato" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="tdLabel">

                            <asp:Label ID="lblFchIngreso" runat="server" Text="*Fecha de Ingreso"></asp:Label>

                        </td>
                        <td align="left">
                            <uc1:ctrFecha ID="ctrFechaIngreso" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="tdLabel">
                            <asp:Label ID="lblImagen" runat="server" Text="Imagen"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:FileUpload ID="fuImagenEmp" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="tdLabel">&nbsp;</td>
                        <td align="left">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">

                            <asp:ImageButton ID="ibtnGuardarInfo" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnGuardarInfoVerde.png" />

                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:ImageButton ID="ibtnInfoLaboral" runat="server" CausesValidation="False" ImageUrl="~/Images/OpcPagina/ibtnInfoLaboralGris.png" />
            <asp:ImageButton ID="ibtnAccidentesEnf" runat="server" CausesValidation="False" ImageUrl="~/Images/OpcPagina/ibtnAccLaboralesGris.png" />
            <asp:ImageButton ID="ibtnConceptosMed" runat="server" CausesValidation="False" ImageUrl="~/Images/OpcPagina/ibtnConceptoMedicoGris.png" />
            <asp:ImageButton ID="ibtnRiesgosCargo" runat="server" CausesValidation="False" ImageUrl="~/Images/OpcPagina/ibtnRiesgosCargoGris.png" />
            <asp:ImageButton ID="ibtnResponSGSST" runat="server" CausesValidation="False" ImageUrl="~/Images/OpcPagina/ibtnRespSGSSTGris.png" />
        </td>
    </tr>
</table>


