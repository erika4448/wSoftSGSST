<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="wSoftSGSST.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SG-SST</title>
    <link href="App_Themes/SoftSGSST.css" rel="stylesheet" type="text/css" />

    <%--HOJAS DE ESTILO LIBRERIA DE MENSAJES--%>
    <link href="css/alertify.default.css" rel="stylesheet" />
    <link href="css/alertify.bootstrap.css" rel="stylesheet" />
    <link href="css/alertify.core.css" rel="stylesheet" />


    <%--JAVASCRIPT LIBRERIA DE MENSAJES--%>
    <script type="text/javascript" src="js/alertify.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/WaterMark.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("[id*=txtUsuario], [id*=txtPswd]").WaterMark();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table width="100%" id="LoginContent">
                <tr>
                    <td align="center" width="50%">
                        <asp:Image runat="server" ID="imLogoCliente" ImageUrl="~/Images/Login/imLogoCliente.png"></asp:Image>
                    </td>
                    <td width="50%">
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Image runat="server" ID="imIngreso" ImageUrl="~/Images/Login/ImIngreso.png"></asp:Image>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="DatosIngreso">
                                        <table align="left">
                                            <tr>
                                                <td align="left">
                                                    <asp:Panel ID="pnlTxtUsuario" runat="server" CssClass="pnlContentInfo">
                                                        <table>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Image ID="imUsuario" runat="server" ImageUrl="~/Images/Login/imUsuarioIngreso.png" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtUsuario" runat="server" Width="190px" ToolTip="Usuario"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Panel ID="pnlTxtPwd" runat="server" CssClass="pnlContentInfo">
                                                        <table>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Image ID="imPwd" runat="server" ImageUrl="~/Images/Login/imPswdIngreso.png" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtPswd" runat="server" TextMode="Password" Width="190px" ToolTip="Contraseña"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:ImageButton runat="server" ID="ibtnIngresa" CausesValidation="False" ImageUrl="~/Images/Botones/ibtnIngresarAzul.png"></asp:ImageButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div style="position: fixed; bottom: 0px; width: 100%; z-index: -1;">
            <div style="position: fixed; bottom: 0px; margin-bottom: -2px; margin-left: -8px;">
                <img src="Images/Login/imFooterFasem.png" />
            </div>
            <%--<div id="LoginFooter">
            </div>--%>
        </div>
    </form>
</body>
</html>
