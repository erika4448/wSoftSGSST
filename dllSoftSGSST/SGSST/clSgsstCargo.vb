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
        Public sgcaExperiencia As String
        Public sgcaAnosExperiencia As Integer
        Public sgcaHabilidades As String
        Public sgcaAQuienRepotaIdCargo As Integer
        Public sgcaIdArea As Integer
        Public sgcaAudIdUsuEmp As Integer
        Public sgcaIdEstado As Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR VARIABLES DE CARGO CON LECTOR
        Public Sub CargarLector(ByVal drLector As IDataReader)
            sgcaIdCargo = IIf(IsDBNull(drLector("sgcaIdCargo")), 0, drLector("sgcaIdCargo"))
            sgcaIdEmpresa = IIf(IsDBNull(drLector("sgcaIdEmpresa")), 0, drLector("sgcaIdEmpresa"))
            sgcaNombre = IIf(IsDBNull(drLector("sgcaNombre")), "", drLector("sgcaNombre"))
            sgcaCodigo = IIf(IsDBNull(drLector("sgcaCodigo")), "", drLector("sgcaCodigo"))
            sgcaObjetivos = IIf(IsDBNull(drLector("sgcaObjetivos")), "", drLector("sgcaObjetivos"))
            sgcaActividadesCargo = IIf(IsDBNull(drLector("sgcaActividadesCargo")), "", drLector("sgcaActividadesCargo"))
            sgcaIdEducacion = IIf(IsDBNull(drLector("sgcaIdEducacion")), 0, drLector("sgcaIdEducacion"))
            sgcaIdProfesion = IIf(IsDBNull(drLector("sgcaIdProfesion")), 0, drLector("sgcaIdProfesion"))
            sgcaExperiencia = IIf(IsDBNull(drLector("sgcaExperiencia")), "", drLector("sgcaExperiencia"))
            sgcaAnosExperiencia = IIf(IsDBNull(drLector("sgcaAnosExperiencia")), 0, drLector("sgcaAnosExperiencia"))
            sgcaHabilidades = IIf(IsDBNull(drLector("sgcaHabilidades")), "", drLector("sgcaHabilidades"))
            sgcaAQuienRepotaIdCargo = IIf(IsDBNull(drLector("sgcaAQuienRepotaIdCargo")), 0, drLector("sgcaAQuienRepotaIdCargo"))
            sgcaIdArea = IIf(IsDBNull(drLector("sgcaIdArea")), 0, drLector("sgcaIdArea"))
            sgcaAudIdUsuEmp = IIf(IsDBNull(drLector("sgcaAudIdUsuEmp")), 0, drLector("sgcaAudIdUsuEmp"))
            sgcaIdEstado = IIf(IsDBNull(drLector("sgcaIdEstado")), 0, drLector("sgcaIdEstado"))
        End Sub
        'FUNCION PARA CARGAR INFORMACION DE CARGOS POR ESTADO
        Public Function GetTblInfoCargoXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoCargoXIdEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR INFORMACION DE CARGOS X ESTADO Y EMPRESA LST
        Public Function GetTblInfoCargoXNomLst(ByVal parIdEmpresa As Integer, ByVal parStrNom As String) As List(Of String)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblCargosXNom")
            Dim lst As New List(Of String)

            db.AddInParameter(dbCommand, "parCriCons", DbType.String, parStrNom)
            'db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    lst.Add(drLector("sgcaNombre"))
                End While
            End Using
            Return lst
        End Function
        'FUNCION PARA CARGAR INFORMACION DEL CARGO POR ID_CARGO
        Public Function CargarInfoCargoXIdCargo(ByVal parIdCargo As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoCargoXIdCargo")

            db.AddInParameter(dbCommand, "parId", DbType.Int32, parIdCargo)

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
            db.AddInParameter(dbCommand, "parExperiencia", DbType.String, sgcaExperiencia)
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
            sgcaIdCargo = db.GetParameterValue(dbCommand, "parIdCargo")

        End Sub
        'FUNCION PARA CARGAR INFORMACION DE CARGO X CODIGO CARGO
        Public Sub CargarInfoCargoXStrCodCargo(ByVal parIdCargo As Integer, ByVal parStrCodigoCargo As String, ByVal parIdEstado As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoCargoXStrCodCargo")
            db.AddInParameter(dbCommand, "parIdCargo", DbType.Int32, parIdCargo)
            db.AddInParameter(dbCommand, "parCodigoCargo", DbType.String, parStrCodigoCargo)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    Me.CargarLector(drLector)
                End While
            End Using
        End Sub
        'FUNCION PARA CARGAR INFORMACION DE CARGOS POR ID_ACTIVIDAD
        Public Function GetTblInfoCargoXIdPeligro(ByVal parIdPeligro As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoCargoXIdPeligro")

            db.AddInParameter(dbCommand, "parIdPeligro", DbType.Int32, parIdPeligro)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace
