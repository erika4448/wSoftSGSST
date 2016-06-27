Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstTipoContrato
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgtcIdTipoContrato As Integer
        Public sgtcNombre As String
        Public sgtcAudIdUsuEmp As Integer
        Public sgtcIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
        Public sgtcIdEmpresa As Integer
#End Region
        'FUNCION PARA CARGAR TIPO_CONTRATO POR ESTADO
        Public Function GetTblInfoTipoContratoXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoTipoContratoXIdEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace
