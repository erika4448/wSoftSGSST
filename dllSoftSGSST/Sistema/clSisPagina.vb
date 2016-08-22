Imports System.Data.Common
Namespace Sistema
    Public Class clSisPagina
        Inherits clBD
#Region "VARIABLES"
        Public sipaIdpagina As Integer
        Public sipaIdModulo As Integer
        Public sipaNombre As String
        Public sipaDescripcion As String
        Public sipaURLPag As String
        Public sipaIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR LAS PAGINAS RELACIONADAS AL USUARIO POR MODULO
        Public Function GetTblInfoPaginaXIdModYRelUsuEmp(ByVal parIdModulo As Integer, ByVal parIdRelUsuXEmp As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("sis.spSisGetTblInfoPaginaXIdModYRelUsuEmp")

            db.AddInParameter(dbCommand, "parIdModulo", DbType.Int32, parIdModulo)
            db.AddInParameter(dbCommand, "parIdRelUsuXEmp", DbType.Int32, parIdRelUsuXEmp)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR PORCENTAJE AVANCE DE PAGINAS PARA MENU PLANEAR
        Public Function CargarPorcAvanceMenuPlanear(ByVal parIdEmpresa As Integer) As Data.DataSet
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("sis.spSisCargarPorcAvanceMenuPlanear")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)

            Return db.ExecuteDataSet(dbCommand)
        End Function
    End Class
End Namespace
