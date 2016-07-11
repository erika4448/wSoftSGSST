Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstRelProcesoXPeligro
        Inherits dllSoftSGSST.Sistema.clBD
#Region "VARIABLES"
        Public srppIdRelProcesoXPeligro As Integer
        Public srppIdPeligro As Integer
        Public srppIdProceso As Integer
        Public srppAudIdUsuEmp As Integer
        Public srppIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA ACTUALIZAR ESTADO DE RELACION PROCESO-PELIGRO
        Public Sub ActInfoEstRelProcesoXPeligroXIdRel(ByVal parIdRelProcesoXPeligro As Integer, ByVal parAudIdUsuEmp As Integer,
                                                      ByVal parIdEstado As Integer,
                                                      Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstActInfoEstRelProcesoXPeligroXIdRel")

            db.AddParameter(dbCommand, "parIdRelProcesoXPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, parIdRelProcesoXPeligro)
            db.AddInParameter(dbCommand, "parAudIdUsuEmp", DbType.Int32, parAudIdUsuEmp)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If
            srppIdRelProcesoXPeligro = db.GetParameterValue(dbCommand, "parIdRelProcesoXPeligro")
        End Sub
        'FUNCION PARA GURDAR INFORMACION DE RELACION
        Public Sub GuardarInfoRelProcesoXPeligro(ByVal parAudIdUsuEmp As Integer,
                                             Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoRelProcesoXPeligro")

            db.AddParameter(dbCommand, "parSrppIdRelProcesoXPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, srppIdRelProcesoXPeligro)
            db.AddInParameter(dbCommand, "parSrppIdPeligro", DbType.Int32, srppIdPeligro)
            db.AddInParameter(dbCommand, "parSrppIdProceso", DbType.Int32, srppIdProceso)
            db.AddInParameter(dbCommand, "parSrppAudIdUsuEmp", DbType.Int32, parAudIdUsuEmp)
            db.AddInParameter(dbCommand, "parSrppIdEstado", DbType.Int32, srppIdEstado)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If
            srppIdRelProcesoXPeligro = db.GetParameterValue(dbCommand, "parSrppIdRelProcesoXPeligro")
        End Sub
    End Class
End Namespace
