Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstEducacion
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgedIdEducacion As Integer
        Public sgedNombre As String
        Public sgedIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
        Public sgedIdEmpresa As Integer
#End Region
        'FUNCION PARA CARGAR INFORMACION DE EDUCACION POR ESTADO
        Public Function GetTblInfoEducacionXEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoEducacionXEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace
