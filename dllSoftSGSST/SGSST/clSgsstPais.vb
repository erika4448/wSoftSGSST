Imports System.Data.Common

Namespace SGSST
    Public Class clSgsstPais
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgpaIdPais As Integer
        Public sgpaNombre As String
        Public sgpaAudIdUsuEmp As Integer
        Public sgpaIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR INFORMACION DE PAIS POR ESTADO
        Public Function GetTblPaisXEstado(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblPaisXEstado")
            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace