Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstRiesgo
        Inherits Sistema.clBD
        'FUNCION PARA OBTENER INFORMACION DE RIESGOS X ID ESTADI
        Public Function GetTblInfoRiesgoXIdEst(ByVal parIdEstado As Integer) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoRiesgoXIdEst")
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace

