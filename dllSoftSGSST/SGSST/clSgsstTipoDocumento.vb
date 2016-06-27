Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstTipoDocumento
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgtdIdTipoDocumento As Integer
        Public sgtdNombre As String
        Public sgtdAudIdUsuEmp As Integer
        Public sgtdIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
        Public sgtIdEmpresa As Integer
#End Region
        'FUNCION PARA CARGAR INFORMACION DE TIPO_DOCUMENTO POR ESTADO
        Public Function GetTblInfoTipoDocumentoXEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoTipoDocumentoXEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace