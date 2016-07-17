Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstLugar
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sglIdLugar As Integer
        Public sglIdEmpresa As Integer
        Public sglNombre As String
        Public sglAudIdUsuEmp As Integer
        Public sglIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR INFORMACION DE LUGAR POR ESTADO
        Public Function GetTblInfoLugarXIdEst(ByVal parIdEmpresa As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoLugarXIdEst")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR INFORMACION DE PROCESO X PELIGRO
        Public Function GetTblInfoLugarXIdPeligro(ByVal parIdPeligro As Integer, ByVal parIdEstado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoLugarXIdPeligro")

            db.AddInParameter(dbCommand, "parIdPeligro", DbType.Int32, parIdPeligro)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA GUARDAR INFORMACION DE LUGAR
        Public Sub GuardarInfoLugar(ByVal parIdUsuEmp As Integer, Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoLugar")

            db.AddParameter(dbCommand, "parSglIdLugar", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sglIdLugar)
            db.AddInParameter(dbCommand, "parSglIdEmpresa", DbType.Int32, sglIdEmpresa)
            db.AddInParameter(dbCommand, "parSglNombre", DbType.String, sglNombre)
            db.AddInParameter(dbCommand, "parSglAudIdUsuEmp", DbType.Int32, parIdUsuEmp)
            db.AddInParameter(dbCommand, "parSglIdEstado", DbType.Int32, sglIdEstado)


            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sglIdLugar = db.GetParameterValue(dbCommand, "parSglIdLugar")
        End Sub
    End Class
End Namespace
