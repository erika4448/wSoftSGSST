﻿Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class AutoCompleteBusCargo
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetLstCargo() As String()
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        Return objCargo.GetTblInfoCargoXIdEstLst(1, 1).ToArray
    End Function

End Class