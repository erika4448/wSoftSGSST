Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstProceso
        Inherits dllSoftSGSST.Sistema.clBD
#Region "VARIABLES"
        Public sgpIdProceso As Integer
        Public sgpIdEmpresa As Integer
        Public sgpNombre As String
        Public sgpAudIdUsuEmp As Integer
        Public sgpdIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR INFORMACION DE PROCESO POR ESTADO
        Public Function GetTblInfoProcesoXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoProcesoXIdEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR INFORMACION DE PROCESO X PELIGRO
        Public Function GetTblInfoProcesoXIdPeligro(ByVal parIdPeligro As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoProcesoXIdPeligro")

            db.AddInParameter(dbCommand, "parIdPeligro", DbType.Int32, parIdPeligro)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace