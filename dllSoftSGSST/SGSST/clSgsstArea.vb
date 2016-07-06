Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstArea
        Inherits Sistema.clBD

        'FUNCION PARA OBTENER LAS REGIONES X ID EMPRESA Y ID ESTADO
        Public Function GetTblAreaXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblAreaXIdEst")
            db.AddInParameter(dbCommand, "", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "", DbType.Int32, parIdEstado)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace

