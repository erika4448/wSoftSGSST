Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstClasificacionPeligro
        Inherits Sistema.clBD
        'FUNCION PARA OBTENER LA INFORMACION DE CLASIFICACION DEL PELIGRO X ID ESTADO
        Public Function GetTblInfoClasificacionPeligroXIdEst(ByVal parIdEstado As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoClasificacionPeligroXIdEst")
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace

