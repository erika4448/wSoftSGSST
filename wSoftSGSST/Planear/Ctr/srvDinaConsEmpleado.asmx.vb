Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class srvDinaConsEmpleado
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetTblEmpleadoXStrNomBus(ByVal prefixText As String) As String()
        Dim objEmpleado As New dllSoftSGSST.SGSST.clSgsstEmpleado
        Dim listaObj As New List(Of String)
        Dim dtDatosEmpleado As New Data.DataTable

        dtDatosEmpleado = objEmpleado.GetTblnfoEmpleadoXStrNom(prefixText)
        For Each drRow As Data.DataRow In dtDatosEmpleado.Rows
            listaObj.Add(drRow("sgemNomCompleto"))
        Next

        Return listaObj.ToArray()

    End Function

End Class