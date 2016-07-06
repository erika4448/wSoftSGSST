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
        Public Function GetTblModuloXIdRelUsuEmp(ByVal parRelIdUsuXEmp As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("sis.spSisGetTblModuloXIdRelUsuEmp")

            db.AddInParameter(dbCommand, "parRelIdUsuXEmp", DbType.Int32, parRelIdUsuXEmp)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace
