Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstCargo
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgcaIdCargo As Integer
        Public sgcaIdEmpresa As Integer
        Public sgcaNombre As String
        Public sgcaCodigo As String
        Public sgcaObjetivos As String
        Public sgcaActividadesCargo As String
        Public sgcaIdEducacion As Integer
        Public sgcaIdProfesion As Integer
        Public sgcaAnosExperiencia As Integer
        Public sgcaHabilidades As String
        Public sgcaAQuienRepotaIdCargo As Integer
        Public sgcaIdArea As Integer
        Public sgcaAudIdUsuEmp As Integer
        Public sgcaIdEstado As Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR INFORMACION DE CARGOS POR ESTADO
        Public Function GetTblInfoCargoXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoCargoXIdEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR INFORMACION DEL CARGO POR ID_CARGO
        Public Function CargarInfoCargoXIdCargo(ByVal parIdCargo As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoCargoXIdCargo")

            db.AddInParameter(dbCommand, "parIdCargo", DbType.Int32, parIdCargo)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace
