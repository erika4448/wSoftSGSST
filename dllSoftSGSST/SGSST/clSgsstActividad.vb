Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstActividad
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgacIdActividad As Integer
        Public sgacIdEmpresa As Integer
        Public sgacNombre As String
        Public sgacIdEstado As Integer
#End Region
        'FUNCION PARA CARGAR LAS ACTIVIDADES POR NOMBRE
        Public Function GetTblInfoActividadXStrNom(ByVal parStrNom As String) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoActividadXStrNom")
            db.AddInParameter(dbCommand, "parCriCons", DbType.String, parStrNom)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR LAS ACTIVIDADES POR NOMBRE LST
        Public Function GetTblInfoActividadXStrNomLst(ByVal parStrNom As String) As List(Of String)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoActividadXStrNom")
            db.AddInParameter(dbCommand, "parCriCons", DbType.String, parStrNom)
            Dim lstNom As New List(Of String)

            Using drLector As IDataReader = db.ExecuteReader(dbCommand)
                While drLector.Read
                    lstNom.Add(drLector("sgacNombre"))
                End While
            End Using

            Return lstNom
        End Function
        'FUNCION PARA GUARDAR UNA ACTIVIDAD
        Public Sub GuardarActividad(ByVal parAudIdUsuEmpSr As Integer, Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarActividad")
            db.AddParameter(dbCommand, "parIdActividad", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgacIdActividad)
            db.AddInParameter(dbCommand, "parIdEmpresa", DbType.Int32, sgacIdEmpresa)
            db.AddInParameter(dbCommand, "parNombre", DbType.String, sgacNombre)
            db.AddInParameter(dbCommand, "parAudIdUsuEmpSr", DbType.Int32, parAudIdUsuEmpSr)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, sgacIdEstado)

            If (parObjTrans Is Nothing) Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sgacIdActividad = db.GetParameterValue(dbCommand, "parIdActividad")
        End Sub
    End Class
End Namespace

