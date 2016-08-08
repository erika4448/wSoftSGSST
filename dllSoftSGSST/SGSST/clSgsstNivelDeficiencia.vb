Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstNivelDeficiencia
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sndIdNivelDeficiencia As Integer
        Public sndNombre As String
        Public sndSignificado As String
        Public sndValor As Integer
        Public sndIdEstado As Integer
#End Region
        'FUNCION PARA CARGAR VARIABLES
        Public Sub CargarLector(ByVal drLector As IDataReader)
            sndIdNivelDeficiencia = IIf(IsDBNull(drLector("sndIdNivelDeficiencia")), 0, drLector("sndIdNivelDeficiencia"))
            sndNombre = IIf(IsDBNull(drLector("sndNombre")), "", drLector("sndNombre"))
            sndSignificado = IIf(IsDBNull(drLector("sndSignificado")), "", drLector("sndSignificado"))
            sndValor = IIf(IsDBNull(drLector("sndValor")), 0, drLector("sndValor"))
            sndIdEstado = IIf(IsDBNull(drLector("sndIdEstado")), 0, drLector("sndIdEstado"))
        End Sub
        'FUNCION PARA CARGAR INFORMACION DE  NIVEL DEFICIENCIA X ID ESTADO
        Public Function GetTblInfoNivelDeficienciaXIdEst(ByVal parIdEstado As Integer) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoNivelDeficienciaXIdEst")
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR INFORMACION DE NIVEL DE DEFICIENCIA X ID NIV DEF
        Public Sub CargarInfoNivelDeficienciaXId(ByVal parIdNivDef As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoNivelDeficienciaXId")
            db.AddInParameter(dbCommand, "parIdNivDef", DbType.Int32, parIdNivDef)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    Me.CargarLector(drLector)
                End While
            End Using
        End Sub
    End Class
End Namespace

