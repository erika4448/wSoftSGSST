Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstNivelExposicion
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sneIdNivelExposicion As Integer
        Public sneNombre As String
        Public sneSignificado As String
        Public sneValor As Integer
        Public sneIdEstado As Integer
#End Region
        'FUNCION PARA CARGAR VARIABLES
        Public Sub CargarLector(ByVal drLector As IDataReader)
            sneIdNivelExposicion = IIf(IsDBNull(drLector("sneIdNivelExposicion")), 0, drLector("sneIdNivelExposicion"))
            sneNombre = IIf(IsDBNull(drLector("sneNombre")), "", drLector("sneNombre"))
            sneSignificado = IIf(IsDBNull(drLector("sneSignificado")), "", drLector("sneSignificado"))
            sneValor = IIf(IsDBNull(drLector("sneValor")), 0, drLector("sneValor"))
            sneIdEstado = IIf(IsDBNull(drLector("sneIdEstado")), 0, drLector("sneIdEstado"))
        End Sub
        'FUNCION PARA CARGAR INFORMACION DE NIVEL EXPOSICION X ID ESTADO
        Public Function GetTblInfoNivExpXIdEst(ByVal parIdEstado As Integer) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoNivExpXIdEst")
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR INFORMACION DE NIVEL DE EXPOSICION X IDNIVEX
        Public Sub CargarInfoNivelExposicionXId(ByVal parIdNivExp As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoNivelExposicionXId")
            db.AddInParameter(dbCommand, "parIdNivExp", DbType.Int32, parIdNivExp)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    Me.CargarLector(drLector)
                End While
            End Using
        End Sub
    End Class
End Namespace

