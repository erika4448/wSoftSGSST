Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstPeligro
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgplIdPeligro As Integer
        Public sgplIdEmpresa As Integer
        Public sgplIdActividad As Integer
        Public sgplIdDescripcionPeligro As Integer
        Public sgplIdClasificacionPeligro As Integer
        Public sgplIdRiesgo As Integer
        Public sgplEstRutinario As Integer
        Public sgplCtrExisCtrFuente As String
        Public sgplCtrExisCtrMedio As String
        Public sgplCtrExisCtrIndividuo As String
        Public sgplCriCtrNumExpuestos As String
        Public sgplCriCtrPeorConsec As String
        Public sgplCriCtrEstExisteRQLegal As String
        Public sgplIntEliminacion As String
        Public sgplIntSustitucion As String
        Public sgplIntCtrIngenieria As String
        Public sgplIntCtrAdmin As String
        Public sgplIntEEPP As String
        Public sgplAudIdUsuEmp As Integer
        Public sgplIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA CARGAR INFORMACION DE PELIGRO POR ID_PELIGRO
        Public Function CargarInfoPeligroXIdPeligro(ByVal parIdPeligro As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoPeligroXIdPeligro")

            db.AddInParameter(dbCommand, "parIdPeligro", DbType.Int32, parIdPeligro)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA ACTUALIZAR MARCACION DE RUTINARIO PARA EL PELIGRO
        Public Sub ActInfoEstRutinarioXPeligro(ByVal parIdRelUsuXEmp As Integer, Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstActInfoEstRutinarioXPeligro")

            db.AddParameter(dbCommand, "parSgplIdPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgplIdPeligro)
            db.AddInParameter(dbCommand, "parSgplEstRutinario", DbType.Int32, sgplEstRutinario)
            db.AddInParameter(dbCommand, "parSgplAudIdUsuEmp", DbType.Int32, parIdRelUsuXEmp)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sgplIdPeligro = db.GetParameterValue(dbCommand, "parSgplIdPeligro")
        End Sub
        'FUNCION PARA CARGAR INFORMACION DE PELIGRO POR ID_EMPRESA
        Public Function GetTblInfoPeligroMatRiesgos(ByVal parIdEmpresa As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoPeligroMatRiesgos")

            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, parIdEmpresa)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace