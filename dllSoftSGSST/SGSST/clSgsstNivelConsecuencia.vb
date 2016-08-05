Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstNivelConsecuencia
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sncIdNivelConsecuencia As Integer
        Public sncNombre As String
        Public sncSignificado As String
        Public sncValor As Integer
        Public sncIdEstado As Integer
#End Region
        'FUNCION PARA CARGAR VARIABLES
        Public Sub CargarLector(ByVal drLector As IDataReader)
            sncIdNivelConsecuencia = IIf(IsDBNull(drLector("sncIdNivelConsecuencia")), 0, drLector("sncIdNivelConsecuencia"))
            sncNombre = IIf(IsDBNull(drLector("sncNombre")), "", drLector("sncNombre"))
            sncSignificado = IIf(IsDBNull(drLector("sncSignificado")), "", drLector("sncSignificado"))
            sncValor = IIf(IsDBNull(drLector("sncValor")), 0, drLector("sncValor"))
            sncIdEstado = IIf(IsDBNull(drLector("sncIdEstado")), 0, drLector("sncIdEstado"))
        End Sub
        'FUNCION PARA CARGAR INFORMACION DE NIVEL CONSECUENCIA X ID ESTADO
        Public Function GetTblInfoNivConsXIdEst(ByVal parIdEstado As Integer) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoNivConsXIdEst")
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR INFORMACION DE NIVEL DE CONSECUENCIA X ID NIVEL CONSECUENCIA
        Public Sub CargarinfoNivelConsecuenciaXId(ByVal parIdNivCons As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarinfoNivelConsecuenciaXId")
            db.AddInParameter(dbCommand, "@parIdNivCons", DbType.Int32, parIdNivCons)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    Me.CargarLector(drLector)
                End While
            End Using
        End Sub
    End Class
End Namespace