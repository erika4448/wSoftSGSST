Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstRelCargoXQuienRepIdCargo
        Inherits Sistema.clBD

#Region "VARIABLES"
        Public srqrIdRelCargoXQuienRepIDCargo As Integer
        Public srqrIdCargo As Integer
        Public srqrQuienRepIdCargo As Integer
        Public srqrIdEstado As Integer
#End Region
        'FUNCION PARA GUARDAR LA INFORMACION DE CARGO X QUIEN LE REPOTA
        Public Sub GuardarInfoCargoXQuienLeReportaIdCargo(ByVal parAudIdUsuEmpSR As Integer,
                                                                 Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoCargoXQuienLeReportaIdCargo")
            db.AddParameter(dbCommand, "parIdRelCargoXQuienRepIDCargo", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, srqrIdRelCargoXQuienRepIDCargo)
            db.AddInParameter(dbCommand, "parIdCargo", DbType.Int32, srqrIdCargo)
            db.AddInParameter(dbCommand, "parQuienRepIdCargo", DbType.Int32, srqrQuienRepIdCargo)
            db.AddInParameter(dbCommand, "parAudIdUsuEmp", DbType.Int32, parAudIdUsuEmpSR)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, srqrIdEstado)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            srqrIdRelCargoXQuienRepIDCargo = db.GetParameterValue(dbCommand, "parIdRelCargoXQuienRepIDCargo")
        End Sub
        'FUNCION PARA CARGAR LA INFORMACION DE QUIEN LE REPORTA X ID CARGO Y ESTADO
        Public Function GetTblInfoQuienLeReportaCargoXIdCargo(ByVal parIdCargo As Integer, ByVal parIdEstado As Integer) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblInfoQuienLeReportaCargoXIdCargo")
            db.AddInParameter(dbCommand, "parIdCargo", DbType.Int32, parIdCargo)
            db.AddInParameter(dbCommand, "parIdEstado", DbType.Int32, parIdEstado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace

