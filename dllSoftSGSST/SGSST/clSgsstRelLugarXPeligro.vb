Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstRelLugarXPeligro
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public srlpIdRelLugarXPeligro As Integer
        Public srlpIdPeligro As Integer
        Public srlpIdLugar As Integer
        Public srlpAudIdUsuEmp As Integer
        Public srlpIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA ACTUALIZAR ESTADO DE RELACION LUGAR-PELIGRO
        Public Sub ActInfoEstRelLugarXPeligroXIdRel(ByVal parIdRelLugarXPeligro As Integer, ByVal parAudIdUsuEmp As Integer,
                                                      ByVal parIdEstado As Integer,
                                                      Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstActInfoEstRelLugarXPeligroXIdRel")

            db.AddParameter(dbCommand, "parIdRelLugarXPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, parIdRelLugarXPeligro)
            db.AddInParameter(dbCommand, "parAudIdUsuEmp", DbType.Int32, parAudIdUsuEmp)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If
            srlpIdRelLugarXPeligro = db.GetParameterValue(dbCommand, "parIdRelLugarXPeligro")
        End Sub
        'FUNCION PARA GURDAR INFORMACION DE RELACION
        Public Sub GuardarInfoRelLugarXPeligro(ByVal parAudIdUsuEmp As Integer,
                                             Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoRelLugarXPeligro")

            db.AddParameter(dbCommand, "parSrlpIdRelLugarXPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, srlpIdRelLugarXPeligro)
            db.AddInParameter(dbCommand, "parSrlpIdPeligro", DbType.Int32, srlpIdPeligro)
            db.AddInParameter(dbCommand, "parSrlpIdLugar", DbType.Int32, srlpIdLugar)
            db.AddInParameter(dbCommand, "parSrlpAudIdUsuEmp", DbType.Int32, parAudIdUsuEmp)
            db.AddInParameter(dbCommand, "parSrlpIdEstado", DbType.Int32, srlpIdEstado)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If
            srlpIdRelLugarXPeligro = db.GetParameterValue(dbCommand, "parSrlpIdRelLugarXPeligro")
        End Sub
    End Class
End Namespace