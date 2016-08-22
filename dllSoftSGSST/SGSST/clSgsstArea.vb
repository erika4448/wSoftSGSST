Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstArea
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgarIdArea As Integer
        Public sgarNombre As String
        Public sgarIdEstado As Integer
        Public sgarIdEmpresa As Integer
#End Region
        'FUNCION PARA OBTENER LAS REGIONES X ID EMPRESA Y ID ESTADO
        Public Function GetTblAreaXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblAreaXIdEst")
            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA GUARDAR LAS AREAS
        Public Sub GuardarArea(Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarArea")
            db.AddParameter(dbCommand, "parIdArea", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgarIdArea)
            db.AddInParameter(dbCommand, "parNombre", DbType.String, sgarNombre)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, sgarIdEstado)
            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, sgarIdEmpresa)

            If (parObjTrans Is Nothing) Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sgarIdArea = db.GetParameterValue(dbCommand, "parIdArea")
        End Sub
    End Class
End Namespace

