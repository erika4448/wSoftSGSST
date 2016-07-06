Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstHistCargosEmp
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public shceIdHistCargosEmp As Integer
        Public shceIdEmpleado As Integer
        Public shceIdCargo As Integer
        Public shceFchIngreso As Date
        Public shceAudIdUsuEmp As Integer
        Public shceIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR INFORMACION DE HISTORICO CARGOS POR EMPLEADO
        Public Function GetTblInfoHistCargoXdEmp(ByVal parIdEmpleado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoHistCargoXdEmp")

            db.AddInParameter(dbCommand, "parIdEmpleado", DbType.Int32, parIdEmpleado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace
