<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstSGSST.Master" CodeBehind="frmPrincMenuPrincipal.aspx.vb" Inherits="wSoftSGSST.frmPrincMenuPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="50px" style="padding-left: 20px;">
                    <tr>
                        <td align="center">
                            <asp:Image ID="imLogo" runat="server" ImageUrl="~/Images/MenuPrincipal/imMenuLogo.png" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblPorcAvance" runat="server" Text="Porcentaje de Avance" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table cellpadding="0" cellspacing="0" style="border-spacing: 0px 0px!important;">
                    <tr>
                        <td>
                            <a href="Planear/frmMenuPlanear.aspx">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/MenuPrincipal/imMenuPlanear.png" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/MenuPrincipal/imMenuHacer.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/MenuPrincipal/imMenuVerificar.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/MenuPrincipal/imMenuActuar.png" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
