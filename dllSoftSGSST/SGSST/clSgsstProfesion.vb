Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstProfesion
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgprIdProfesion As Integer
        Public sgprNombre As String
        Public sgprIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
        Public sgprIdEmpresa As Integer
#End Region
        'FUNCION PARA CARGAR PROFESION POR ESTADO
        Public Function GetTblInfoProfesionXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoProfesionXIdEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace
