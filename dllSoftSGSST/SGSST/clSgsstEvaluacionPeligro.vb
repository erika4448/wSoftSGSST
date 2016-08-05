Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstEvaluacionPeligro
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sepIdEvaluacionPeligro As Integer
        Public sepIdPeligro As Integer
        Public sepIdNivelDeficiencia As Integer
        Public sepIdNivelExposicion As Integer
        Public sepValorNivProbabilidad As Integer
        Public sepIdNivelProbabilidad As Integer
        Public sepIdNivelConsecuencia As Integer
        Public sepIdNivelRiesgo As Integer
        Public sepValorNivRiesgo As Integer
        Public sepIdAceptabilidad As Integer
        Public sepAudIdUsuEmp As Integer
        Public sepIdEstado As Integer
#End Region
        'FUNCION PARA CARGAR LAS VARIABLES DE LA CLASE CON LECTOR
        Public Sub CargarLector(ByVal drLector As IDataReader)
            sepIdEvaluacionPeligro = IIf(IsDBNull(drLector("sepIdEvaluacionPeligro")), 0, drLector("sepIdEvaluacionPeligro"))
            sepIdPeligro = IIf(IsDBNull(drLector("sepIdPeligro")), 0, drLector("sepIdPeligro"))
            sepIdNivelDeficiencia = IIf(IsDBNull(drLector("sepIdNivelDeficiencia")), 0, drLector("sepIdNivelDeficiencia"))
            sepIdNivelExposicion = IIf(IsDBNull(drLector("sepIdNivelExposicion")), 0, drLector("sepIdNivelExposicion"))
            sepValorNivProbabilidad = IIf(IsDBNull(drLector("sepValorNivProbabilidad")), 0, drLector("sepValorNivProbabilidad"))
            sepIdNivelProbabilidad = IIf(IsDBNull(drLector("sepIdNivelProbabilidad")), 0, drLector("sepIdNivelProbabilidad"))
            sepIdNivelConsecuencia = IIf(IsDBNull(drLector("sepIdNivelConsecuencia")), 0, drLector("sepIdNivelConsecuencia"))
            sepIdNivelRiesgo = IIf(IsDBNull(drLector("sepIdNivelRiesgo")), 0, drLector("sepIdNivelRiesgo"))
            sepValorNivRiesgo = IIf(IsDBNull(drLector("sepValorNivRiesgo")), 0, drLector("sepValorNivRiesgo"))
            sepIdAceptabilidad = IIf(IsDBNull(drLector("sepIdAceptabilidad")), 0, drLector("sepIdAceptabilidad"))
            sepAudIdUsuEmp = IIf(IsDBNull(drLector("sepAudIdUsuEmp")), 0, drLector("sepAudIdUsuEmp"))
            sepIdEstado = IIf(IsDBNull(drLector("sepIdEstado")), 0, drLector("sepIdEstado"))
        End Sub
        'FUNCION PARA GUARDAR INFORMACION DE EVALUACION PELIGRO
        Public Sub GuardarInfoEvaluacionPeligro(Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoEvaluacionPeligro")
            db.AddParameter(dbCommand, "parIdEvaluacionPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sepIdEvaluacionPeligro)
            db.AddInParameter(dbCommand, "parIdPeligro", DbType.Int32, sepIdPeligro)
            db.AddInParameter(dbCommand, "parIdNivelDeficiencia", DbType.Int32, sepIdNivelDeficiencia)
            db.AddInParameter(dbCommand, "parIdNivelExposicion", DbType.Int32, sepIdNivelExposicion)
            db.AddInParameter(dbCommand, "parValorNivProbabilidad", DbType.Int32, sepValorNivProbabilidad)
            db.AddInParameter(dbCommand, "parIdNivelProbabilidad", DbType.Int32, sepIdNivelProbabilidad)
            db.AddInParameter(dbCommand, "parIdNivelConsecuencia", DbType.Int32, sepIdNivelConsecuencia)
            db.AddInParameter(dbCommand, "parIdNivelRiesgo", DbType.Int32, sepIdNivelRiesgo)
            db.AddInParameter(dbCommand, "parValorNivRiesgo", DbType.Int32, sepValorNivRiesgo)
            db.AddInParameter(dbCommand, "parIdAceptabilidad", DbType.Int32, sepIdAceptabilidad)
            db.AddInParameter(dbCommand, "parAudIdUsuEmp", DbType.Int32, sepAudIdUsuEmp)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, sepIdEstado)

            If (parObjTrans IsNot Nothing) Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sepIdEvaluacionPeligro = db.GetParameterValue(dbCommand, "parIdEvaluacionPeligro")
        End Sub
        'FUNCION PARA CARGAR INFORMACION DE EVALUACION PELIGRO X ID PELIGRO
        Public Sub CargarInfoEvalRiesgo(ByVal parIdPeligro As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoEvalRiesgo")
            db.AddInParameter(dbCommand, "parIdPeligro", DbType.Int32, parIdPeligro)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    Me.CargarLector(drLector)
                End While
            End Using
        End Sub
    End Class
End Namespace

