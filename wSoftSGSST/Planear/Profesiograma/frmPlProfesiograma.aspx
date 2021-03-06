﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestras/mstSGSST.Master" CodeBehind="frmPlProfesiograma.aspx.vb" Inherits="wSoftSGSST.frmPlProfesiograma" %>

<%@ Register Src="~/Ctr/ctrDinaConsObj.ascx" TagPrefix="uc1" TagName="ctrDinaConsObj" %>
<%@ Register Src="~/Planear/Ctr/ctrProfesiograma.ascx" TagPrefix="uc1" TagName="ctrProfesiograma" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--HOJAS DE ESTILO LIBRERIA DE MENSAJES--%>
    <link href="../../css/alertify.bootstrap.css" rel="stylesheet" />
    <link href="../../css/alertify.bootstrap.css" rel="stylesheet" />
    <link href="../../css/alertify.core.css" rel="stylesheet" />
    <%--JAVASCRIPT LIBRERIA DE MENSAJES--%>
    <script type="text/javascript" src="../../js/alertify.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.3.min.js"></script>
      
      <%--MENU--%>
    <script type="text/javascript"  src="../../js/jquery-3.0.0.min.js"></script>
    <link href="../../css/Menu/bootstrap-treeview.css" rel="stylesheet"/>
    <script type="text/javascript"  src="../../js/Menu/bootstrap-treeview.js"></script>

    <table align="center">
        <tr>
            <td>
                <asp:Panel ID="pnlCtrProfesiograma" runat="server" HorizontalAlign="Center" ScrollBars="Auto">
                    <uc1:ctrProfesiograma runat="server" ID="ctrProfesiograma" align="center"/>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
