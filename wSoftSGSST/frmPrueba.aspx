<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmPrueba.aspx.vb" Inherits="wSoftSGSST.frmPrueba" %>

<%@ Register Src="~/Ctr/ctrDinaConsObj.ascx" TagPrefix="uc1" TagName="ctrDinaConsObj" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ctrDinaConsObj runat="server" id="ctrDinaConsObj" />
    </div>
    </form>
</body>
</html>
