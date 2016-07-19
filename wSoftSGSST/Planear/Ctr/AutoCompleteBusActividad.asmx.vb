Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class AutoCompleteBusActividad
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetLstActividad(ByVal prefixText As String) As String()
        Dim objActividad As New dllSoftSGSST.SGSST.clSgsstActividad
        Return objActividad.GetTblInfoActividadXStrNomLst(prefixText).ToArray
    End Function

End Class