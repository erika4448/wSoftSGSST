Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstCiudad
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgciIdCiudad As Integer
        Public sgciIdPais As Integer
        Public sgciNombre As String
        Public sgciAudIdUsuEmp As Integer
        Public sgciIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR CIUDAD POR PAIS Y ESTADO
        Public Function GetTblInfoCiudadXIdPaisYEst(ByVal parIdPais As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoCiudadXIdPaisYEst")

            db.AddInParameter(dbCommand, "parIdPais", DbType.Int32, parIdPais)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace

