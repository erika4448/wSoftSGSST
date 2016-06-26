Imports System.Data.Common
Namespace SGSST
    Public Class clSgsstEmpleado
        Inherits Sistema.clBD
#Region "VARIABLES"
        Public sgemIdEmpleado As Integer
        Public sgemIdEmpresa As Integer
        Public sgemNombres As String
        Public sgemApellidos As String
        Public sgemIdTipDoc As Integer
        Public sgemNroDoc As String
        Public sgemIdGenero As Integer
        Public sgemFchNacimiento As Date
        Public sgemIdPais As Integer
        Public sgemIdCiudad As Integer
        Public sgemIdEducacion As Integer
        Public sgemIdProfesion As Integer
        Public sgemIdEstadoCivil As Integer
        Public sgemIdCargo As Integer
        Public sgemIdTipoContrato As Integer
        Public sgemFchIngreso As Date
        Public sgemAudIdUsuEmp As Integer
        Public sgemIdEstado As dllSoftSGSST.Sistema.clSisEstado.EnmEstado
#End Region
        'FUNCION PARA ACTUALIZAR CARGO RELACIONADO AL EMPLEADO
        Public Sub ActInfoCargoEmpleadoXIdEmp(ByVal parAudIdUsuEmp As Integer, Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstActInfoCargoEmpleadoXIdEmp")

            db.AddInParameter(dbCommand, "parSgemIdEmpleado", DbType.Int32, sgemIdEmpleado)
            db.AddInParameter(dbCommand, "parSgemIdCargo", DbType.Int32, sgemIdCargo)
            db.AddInParameter(dbCommand, "parSgemFchIngreso", DbType.Date, sgemFchIngreso)
            db.AddInParameter(dbCommand, "parSgemAudIdUsuEmp", DbType.Int32, parAudIdUsuEmp)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If
        End Sub
    End Class
End Namespace
