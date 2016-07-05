Imports System.Data.Common
Namespace Sistema
    Public Class clSisModulo
        Inherits clBD
#Region "VARIABLES"
        Public simoIdModulo As Integer
        Public simoNombre As String
        Public simoDescripcion As String
        Public simoIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR LISTADO DE MODULOS A LOS QUE TIENE ACCESO EL USUARIO
    End Class
End Namespace
