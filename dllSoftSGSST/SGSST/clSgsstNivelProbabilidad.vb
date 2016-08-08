Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstNivelProbabilidad
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgnIdNivelProbabilidad As Integer
        Public sgnNombre As String
        Public sgnSignificado As String
        Public sgnValorMin As Integer
        Public sgnValorMax As Integer
        Public sgnIdEstado As Integer
#End Region
        'FUNCION PARA CARGAR VARIABLES
        Public Sub CargarLector(ByVal drLector As IDataReader)
            sgnIdNivelProbabilidad = IIf(IsDBNull(drLector("sgnIdNivelProbabilidad")), 0, drLector("sgnIdNivelProbabilidad"))
            sgnNombre = IIf(IsDBNull(drLector("sgnNombre")), "", drLector("sgnNombre"))
            sgnSignificado = IIf(IsDBNull(drLector("sgnSignificado")), "", drLector("sgnSignificado"))
            sgnValorMin = IIf(IsDBNull(drLector("sgnValorMin")), 0, drLector("sgnValorMin"))
            sgnValorMax = IIf(IsDBNull(drLector("sgnValorMax")), 0, drLector("sgnValorMax"))
            sgnIdEstado = IIf(IsDBNull(drLector("sgnIdEstado")), 0, drLector("sgnIdEstado"))
        End Sub
        'FUNCION PARA CARGAR INFORMACION DE NIVEL DE PROBABILIDAD X VALOR
        Public Sub CargarInfoNivProbXValor(ByVal parValor As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoNivProbXValor")
            db.AddInParameter(dbCommand, "parValor", DbType.Int32, parValor)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    Me.CargarLector(drLector)
                End While
            End Using
        End Sub
    End Class
End Namespace