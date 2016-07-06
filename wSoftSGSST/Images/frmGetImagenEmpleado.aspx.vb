Public Class frmGetImagenEmpleado
    Inherits dllSoftSGSST.Estructura.EstructuraPagina

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.Params("PIE") Is Nothing Then
            Dim objSopEmp As New dllSoftSGSST.SGSST.clSgsstEmpleado
            Dim dtDatos As New Data.DataTable

            'CARGA LA INFORMACION DEL EMPLEADO
            dtDatos = objSopEmp.CargarInfoEmpleadoXIdEmpleado(Request.Params("PIE"))
            If (dtDatos.Rows.Count > 0) Then
                Response.ContentType = "image/jpeg"
                Response.BinaryWrite(dtDatos.Rows(0)("sgemImagen"))
                HttpContext.Current.ApplicationInstance.CompleteRequest()
            End If
        End If
    End Sub

End Class