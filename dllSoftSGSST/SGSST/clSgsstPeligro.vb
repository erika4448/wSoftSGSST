Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstPeligro
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgplIdPeligro As Integer
        Public sgplIdEmpresa As Integer
        Public sgplIdActividad As Integer
        Public sgplDescripcionPeligro As String
        Public sgplIdClasificacionPeligro As Integer
        Public sgplIdRiesgo As Integer
        Public sgplAudIdUsuEmp As Integer
        Public sgplIdEstado As Integer
#End Region
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