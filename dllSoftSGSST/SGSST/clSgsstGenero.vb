Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstGenero
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sggeIdGenero As Integer
        Public sggeNombre As String
        Public sggeAudIdUsuEmp As Integer
        Public sggeIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
        Public sggeIdEmpresa As Integer
#End Region
        'FUNCION PARA CARGAR GENERO POR ESTADO
        Public Function GetTblInfoGeneroXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoGeneroXIdEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace