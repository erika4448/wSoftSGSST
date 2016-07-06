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
        'FUNCION PARA CARGAR INFORMACION DE CARGOS X ESTADO Y EMPRESA LST
        Public Function GetTblInfoCargoXIdEstLst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As List(Of String)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoCargoXIdEst")
            Dim lst As New List(Of String)

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    lst.Add(drLector("NOMBRE"))
                End While
            End Using
            Return lst
        End Function
        'FUNCION PARA CARGAR INFORMACION DEL CARGO POR ID_CARGO
        Public Function CargarInfoCargoXIdCargo(ByVal parIdCargo As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoCargoXIdCargo")

            db.AddInParameter(dbCommand, "parIdCargo", DbType.Int32, parIdCargo)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA GUARDAR INFORMACION DE CARGO
        Public Sub GuardarInfoCargo(Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoCargo")
            db.AddParameter(dbCommand, "parIdCargo", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgcaIdCargo)
            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, sgcaIdEmpresa)
            db.AddInParameter(dbCommand, "parNombre", DbType.String, sgcaNombre)
            db.AddInParameter(dbCommand, "parCodigo", DbType.String, sgcaCodigo)
            db.AddInParameter(dbCommand, "parObjetivos", DbType.String, sgcaObjetivos)
            db.AddInParameter(dbCommand, "parActividadesCargo", DbType.String, sgcaActividadesCargo)
            db.AddInParameter(dbCommand, "parIdEducacion", DbType.Int32, sgcaIdEducacion)
            db.AddInParameter(dbCommand, "parIdProfesion", DbType.Int32, sgcaIdProfesion)
            db.AddInParameter(dbCommand, "parAnosExperiencia", DbType.Int32, sgcaAnosExperiencia)
            db.AddInParameter(dbCommand, "parHabilidades", DbType.String, sgcaHabilidades)
            db.AddInParameter(dbCommand, "parAQuienRepotaIdCargo", DbType.Int32, sgcaAQuienRepotaIdCargo)
            db.AddInParameter(dbCommand, "parIdArea", DbType.Int32, sgcaIdArea)
            db.AddInParameter(dbCommand, "parAudIdUsuEmp", DbType.Int32, sgcaAudIdUsuEmp)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, sgcaIdEstado)

            If (parObjTrans Is Nothing) Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If
            db.GetParameterValue(dbCommand, "parIdCargo")

        End Sub
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
