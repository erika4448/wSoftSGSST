Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstProceso
        Inherits dllSoftSGSST.Sistema.clBD
#Region "VARIABLES"
        Public sgpIdProceso As Integer
        Public sgpIdEmpresa As Integer
        Public sgpNombre As String
        Public sgpAudIdUsuEmp As Integer
        Public sgpdIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR INFORMACION DE PROCESO POR ESTADO
        Public Function GetTblInfoProcesoXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoProcesoXIdEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR INFORMACION DE PROCESO X PELIGRO
        Public Function GetTblInfoProcesoXIdPeligro(ByVal parIdPeligro As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoProcesoXIdPeligro")

            db.AddInParameter(dbCommand, "parIdPeligro", DbType.Int32, parIdPeligro)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA GUARDAR INFORMACION DE PROCESO
        Public Sub GuardarInfoProceso(ByVal parIdUsuEmp As Integer, Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoProceso")

            db.AddParameter(dbCommand, "parSgpIdProceso", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgpIdProceso)
            db.AddInParameter(dbCommand, "parSgpIdEmpresa", DbType.Int32, sgpIdEmpresa)
            db.AddInParameter(dbCommand, "parSgpNombre", DbType.String, sgpNombre)
            db.AddInParameter(dbCommand, "parSgpAudIdUsuEmp", DbType.Int32, parIdUsuEmp)
            db.AddInParameter(dbCommand, "parSgpdIdEstado", DbType.Int32, sgpdIdEstado)


            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sgpIdProceso = db.GetParameterValue(dbCommand, "parSgpIdProceso")
        End Sub
    End Class
End Namespace