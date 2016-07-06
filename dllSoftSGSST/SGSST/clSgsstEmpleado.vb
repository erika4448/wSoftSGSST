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
        Public sgemImagen As Byte()
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
        'FUNCION PARA VALIDAR SI EXISTE UN USUARIO POR TIPO Y NUMERO_DOCUMENTO
        Public Function CargarInfoEmpleadoXTipDocNumDoc(ByVal parIdTipoDocumento As Integer, ByVal parNumDocumento As String)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoEmpleadoXTipDocNumDoc")

            db.AddInParameter(dbCommand, "parIdTipoDocumento", DbType.Int32, parIdTipoDocumento)
            db.AddInParameter(dbCommand, "parNumDocumento", DbType.String, parNumDocumento)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA GUARDAR INFORMACION DE EMPLEADO
        Public Sub GuardarInfoEmpleado(ByVal parAudIdUsuXEmp As Integer, Optional ByVal parObjTrans As System.Data.Common.DbTransaction = Nothing)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGuardarInfoEmpleado")

            db.AddParameter(dbCommand, "parSgemIdEmpleado", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, sgemIdEmpleado)
            db.AddInParameter(dbCommand, "parSgemIdEmpresa", DbType.Int32, sgemIdEmpresa)
            db.AddInParameter(dbCommand, "parSgemNombres", DbType.String, sgemNombres)
            db.AddInParameter(dbCommand, "parSgemApellidos", DbType.String, sgemApellidos)
            db.AddInParameter(dbCommand, "parSgemIdTipDoc", DbType.Int32, sgemIdTipDoc)
            db.AddInParameter(dbCommand, "parSgemNroDoc", DbType.String, sgemNroDoc)
            db.AddInParameter(dbCommand, "parSgemIdGenero", DbType.Int32, sgemIdGenero)
            db.AddInParameter(dbCommand, "parSgemFchNacimiento", DbType.Date, sgemFchNacimiento)
            db.AddInParameter(dbCommand, "parSgemIdPais", DbType.Int32, sgemIdPais)
            db.AddInParameter(dbCommand, "parSgemIdCiudad", DbType.Int32, sgemIdCiudad)
            db.AddInParameter(dbCommand, "parSgemIdEducacion", DbType.Int32, sgemIdEducacion)
            db.AddInParameter(dbCommand, "parSgemIdProfesion", DbType.Int32, sgemIdProfesion)
            db.AddInParameter(dbCommand, "parSgemIdEstadoCivil", DbType.Int32, sgemIdEstadoCivil)
            db.AddInParameter(dbCommand, "parSgemIdCargo", DbType.Int32, sgemIdCargo)
            db.AddInParameter(dbCommand, "parSgemIdTipoContrato", DbType.Int32, sgemIdTipoContrato)
            db.AddInParameter(dbCommand, "parSgemFchIngreso", DbType.Date, sgemFchIngreso)
            db.AddInParameter(dbCommand, "parSgemAudIdUsuEmp", DbType.Int32, parAudIdUsuXEmp)
            db.AddInParameter(dbCommand, "parSgemIdEstado", DbType.Int32, sgemIdEstado)
            db.AddInParameter(dbCommand, "parSgemImagen", DbType.Binary, sgemImagen)

            If parObjTrans Is Nothing Then
                db.ExecuteNonQuery(dbCommand)
            Else
                db.ExecuteNonQuery(dbCommand, parObjTrans)
            End If

            sgemIdEmpleado = db.GetParameterValue(dbCommand, "parSgemIdEmpleado")
        End Sub
        'FUNCION PARA CARGAR INFORMACION EMPLEADO POR ID_EMPLEADO
        Public Function CargarInfoEmpleadoXIdEmpleado(ByVal parIdEmpleado As Integer) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstCargarInfoEmpleadoXIdEmpleado")

            db.AddInParameter(dbCommand, "parId", DbType.Int32, parIdEmpleado)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA CARGAR INFORMACION DE EMPLEDOS POR NOMBRE
        Public Function GetTblnfoEmpleadoXStrNom(ByVal parStrNom As String) As Data.DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("spSgsstGetTblnfoEmpleadoXStrNom")

            db.AddInParameter(dbCommand, "parCriCons", DbType.String, parStrNom)

            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace
