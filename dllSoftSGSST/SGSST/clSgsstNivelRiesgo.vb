Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstNivelRiesgo
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public snrIdNivelRiesgo As Integer
        Public snrNombre As String
        Public snrSignificado As String
        Public snrValorMin As Integer
        Public snrValorMax As Integer
        Public snrIdEstado As Integer
#End Region
        'FUNCION PARA CARGAR VARIABLES
        Public Sub CargarLector(ByVal drLector As IDataReader)
            snrIdNivelRiesgo = IIf(IsDBNull(drLector("snrIdNivelRiesgo")), 0, drLector("snrIdNivelRiesgo"))
            snrNombre = IIf(IsDBNull(drLector("snrNombre")), "", drLector("snrNombre"))
            snrSignificado = IIf(IsDBNull(drLector("snrSignificado")), "", drLector("snrSignificado"))
            snrValorMin = IIf(IsDBNull(drLector("snrValorMin")), 0, drLector("snrValorMin"))
            snrValorMax = IIf(IsDBNull(drLector("snrValorMax")), 0, drLector("snrValorMax"))
            snrIdEstado = IIf(IsDBNull(drLector("snrIdEstado")), 0, drLector("snrIdEstado"))
        End Sub
        'FUNCION PARA CARGAR NIVEL DE RIESGO X VALOR
        Public Sub CargarInfoNivelRiesgoXValor(ByVal parValor As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoNivelRiesgoXValor")
            db.AddInParameter(dbCommand, "parValor", DbType.Int32, parValor)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    Me.CargarLector(drLector)
                End While
            End Using
        End Sub
    End Class
End Namespace

