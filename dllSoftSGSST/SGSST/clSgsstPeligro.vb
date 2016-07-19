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
        'FUNCION PARA ACTUALIZAR INFORMACION CONTROLES EXISTENTES
        Public Sub ActInfoCtrExistentesXPeligro(ByVal parIdRelUsuXEmp As Integer, Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstActInfoCtrExistentesXPeligro")

            db.AddParameter(dbCommand, "parSgplIdPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgplIdPeligro)
            db.AddInParameter(dbCommand, "parSgplCtrExisCtrFuente", DbType.String, sgplCtrExisCtrFuente)
            db.AddInParameter(dbCommand, "parSgplCtrExisCtrMedio", DbType.String, sgplCtrExisCtrMedio)
            db.AddInParameter(dbCommand, "parSgplCtrExisCtrIndividuo", DbType.String, sgplCtrExisCtrIndividuo)
            db.AddInParameter(dbCommand, "parSgplAudIdUsuEmp", DbType.Int32, parIdRelUsuXEmp)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sgplIdPeligro = db.GetParameterValue(dbCommand, "parSgplIdPeligro")
        End Sub
        'FUNCION PARA ACTUALIZAR INFORMACION CRITERIOS CONTROLES
        Public Sub ActInfoCriteriosCtrXPeligro(ByVal parIdRelUsuXEmp As Integer, Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstActInfoCriteriosCtrXPeligro")

            db.AddParameter(dbCommand, "parSgplIdPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgplIdPeligro)
            db.AddInParameter(dbCommand, "parSgplCriCtrNumExpuestos", DbType.String, sgplCriCtrNumExpuestos)
            db.AddInParameter(dbCommand, "parSgplCriCtrPeorConsec", DbType.String, sgplCriCtrPeorConsec)
            db.AddInParameter(dbCommand, "parSgplCriCtrEstExisteRQLegal", DbType.Int32, sgplCriCtrEstExisteRQLegal)
            db.AddInParameter(dbCommand, "parSgplAudIdUsuEmp", DbType.Int32, parIdRelUsuXEmp)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sgplIdPeligro = db.GetParameterValue(dbCommand, "parSgplIdPeligro")
        End Sub
        'FUNCION PARA ACTUALIZACION INFORMACION MEDIDAS INTERVENCION
        Public Sub ActInfoMedIntervecionXPeligro(ByVal parIdRelUsuXEmp As Integer, Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstActInfoMedIntervecionXPeligro")

            db.AddParameter(dbCommand, "parSgplIdPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgplIdPeligro)
            db.AddInParameter(dbCommand, "parSgplIntEliminacion", DbType.String, sgplIntEliminacion)
            db.AddInParameter(dbCommand, "parSgplIntSustitucion", DbType.String, sgplIntSustitucion)
            db.AddInParameter(dbCommand, "parSgplIntCtrIngenieria", DbType.String, sgplIntCtrIngenieria)
            db.AddInParameter(dbCommand, "parSgplIntCtrAdmin", DbType.String, sgplIntCtrAdmin)
            db.AddInParameter(dbCommand, "parSgplIntEEPP", DbType.String, sgplIntEEPP)
            db.AddInParameter(dbCommand, "parSgplAudIdUsuEmp", DbType.Int32, parIdRelUsuXEmp)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sgplIdPeligro = db.GetParameterValue(dbCommand, "parSgplIdPeligro")
        End Sub
        'FUNCION PARA OBTENER INFORMACION DE PELIGROS X ID ACTIVIDAD Y ESTADO
        Public Function GetTblInfoPeligroXIdActividad(ByVal parIdActividad As Integer, ByVal parIdEstado As Integer) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoPeligroXIdActividad")
            db.AddInParameter(dbCommand, "parIdActividad", DbType.Int32, parIdActividad)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA GUARDAR INFORMACION DE PELIGRO
        Public Sub GuardarInfoPeligro(Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoPeligro")
            db.AddParameter(dbCommand, "parIdPeligro", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgplIdPeligro)
            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, sgplIdEmpresa)
            db.AddInParameter(dbCommand, "parIdActividad", DbType.Int32, sgplIdActividad)
            db.AddInParameter(dbCommand, "parDescripcionPeligro", DbType.String, sgplDescripcionPeligro)
            db.AddInParameter(dbCommand, "parIdClasificacionPeligro", DbType.Int32, sgplIdClasificacionPeligro)
            db.AddInParameter(dbCommand, "parIdRiesgo", DbType.Int32, sgplIdRiesgo)
            db.AddInParameter(dbCommand, "parAudIdUsuEmp", DbType.Int32, sgplAudIdUsuEmp)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, sgplIdEstado)

            If (parObjTrans Is Nothing) Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sgplIdPeligro = db.GetParameterValue(dbCommand, "parIdPeligro")
        End Sub
    End Class
End Namespace