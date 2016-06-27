Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstEstadoCivil
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgecIdEstadoCivil As Integer
        Public sgecNombre As String
        Public sgecAudIdUsuEmp As Integer
        Public sgecIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
        Public sgecIdEmpresa As Integer
#End Region
        'FUNCION PARA CARGAR ESTADO_CIVIL POR ESTADO
        Public Function GetTblInfoEstCivilXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoEstCivilXIdEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace