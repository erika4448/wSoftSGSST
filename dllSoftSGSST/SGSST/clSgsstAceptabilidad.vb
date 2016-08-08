Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstAceptabilidad
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgaIdAceptabilidad As Integer
        Public sgaIdNivelRiesgo As Integer
        Public sgaNombre As String
        Public sgaSignificado As String
        Public sgaIdEstado As Integer
#End Region
        'FUNCION PARA CARGAR VARIABLES
        Public Sub CargarLector(ByVal drLector As IDataReader)
            sgaIdAceptabilidad = IIf(IsDBNull(drLector("sgaIdAceptabilidad")), 0, drLector("sgaIdAceptabilidad"))
            sgaIdNivelRiesgo = IIf(IsDBNull(drLector("sgaIdNivelRiesgo")), 0, drLector("sgaIdNivelRiesgo"))
            sgaNombre = IIf(IsDBNull(drLector("sgaNombre")), "", drLector("sgaNombre"))
            sgaSignificado = IIf(IsDBNull(drLector("sgaSignificado")), "", drLector("sgaSignificado"))
            sgaIdEstado = IIf(IsDBNull(drLector("sgaIdEstado")), 0, drLector("sgaIdEstado"))
        End Sub
        'FUNCION PARA CARGAR INFORMACION DE ACEPTABILIDAD X ID NIVEL RIESGO
        Public Sub CargarInfoAceptabilidadXIdRiesgo(ByVal parIdNivelRiesgo As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoAceptabilidadXIdRiesgo")
            db.AddInParameter(dbCommand, "parIdRiesgos", DbType.Int32, parIdNivelRiesgo)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    Me.CargarLector(drLector)
                End While
            End Using
        End Sub
    End Class
End Namespace

