<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrCargosReporta.ascx.vb" Inherits="wSoftCentroErgonomia.ctrCargosReporta" %>
<link href="../../App_Themes/tmSoftCentroErgonomia/Principal.css" rel="stylesheet" />

<style type="text/css">
    .pnlCargosReporte {
    }

        .pnlCargosReporte tr:hover {
            background-color: #CFFFB9;
            -o-transition: all 0.1s ease-in-out;
            -webkit-transition: all 0.1s ease-in-out;
            -moz-transition: all 0.1s ease-in-out;
            -ms-transition: all 0.1s ease-in-out;
            transition: all 0.1s ease-in-out;
        }
     .pnlCargosReporte td {
        padding-left: 4px; 
        padding-right: 4px; 
        padding-top: 4px; 
        padding-bottom: 4px;
    }
</style>
<table>
    <tr>
        <td align="left" valign="top">
            <table align="left">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblCargo" runat="server" Text="Cargo"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>
                    </td>
                    <td align="left">
                        <asp:ImageButton ID="ibtnAgregarCargo" runat="server" CausesValidation="False" ImageUrl="~/Images/Botones/imBtnAgregar.fw.png" />
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 20px;">&nbsp;
        </td>
        <td align="left">
            <asp:DataList ID="dtlCargosReporte" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" DataKeyField="tmpIdTabla">
                <ItemTemplate>
                    <div class="pnlCargosReporte">
                        <table cellpadding="0" cellspacing="0" style="border: 1px solid #C0C0C0; background-color: #FFFFFF;">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblNombreCargo" runat="server" Text='<%# bind("tmpStrCargo") %>'></asp:Label>
                                </td>
                                <td align="center" style="width: 30px;">
                                    <asp:ImageButton ID="ibtmEliminar" runat="server" ImageUrl="~/Images/Botones/imBtnEliminar.fw.png" OnClick="ibtmEliminar_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
