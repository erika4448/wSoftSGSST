Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstRelPeligroXCargo
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sracIdRelPeligroXCargo As Integer
        Public sracIdCargo As Integer
        Public sracIdPeligro As Integer
        Public sracAudIdUsuEmp As Integer
        Public sracIdEstado As Integer
#End Region
        'FUNCION PARA CARGAR INFORMACION DE PELIGRO X CARGO X ID CARGO
        Public Function GetTblInfoPeligroXIdCargo(ByVal parIdCargo As Integer, ByVal parIdEstado As Sistema.clSisEstado.EnmEstado) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoPeligroXIdCargo")
            db.AddInParameter(dbCommand, "parIdCargo", DbType.Int32, parIdCargo)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA GUARDAR INFORMACION DE RELACION PELIGRO X CARGO
        Public Sub GuardarInfoPeligroXCargo(Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoPeligroXCargo")
            db.AddParameter(dbCommand, "parIdRelPeligroXCargo", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sracIdRelPeligroXCargo)
            db.AddInParameter(dbCommand, "parIdCargo", DbType.Int32, sracIdCargo)
            db.AddInParameter(dbCommand, "parIdPeligro", DbType.Int32, sracIdPeligro)
            db.AddInParameter(dbCommand, "parAudIdUsuEmp", DbType.Int32, sracAudIdUsuEmp)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, sracIdEstado)

            If (parObjTrans Is Nothing) Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If
        End Sub
        'FUNCION PARA INACTIVAR LA RELACION DEL PELIGRO X EL CARGO
        Public Sub InactivarRelPeligroXCargo(ByVal parIdRelPeligroXCargo As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstInactivarRelPeligroXCargo")
            db.AddInParameter(dbCommand, "parIdRelPeligroXCargo", DbType.Int32, parIdRelPeligroXCargo)
            db.ExecuteNonQuery(dbCommand)
        End Sub
    End Class
End Namespace

