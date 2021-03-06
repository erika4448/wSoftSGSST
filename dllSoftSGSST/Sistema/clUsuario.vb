﻿Imports System.Data.Common
Namespace Sistema
    Public Class clUsuario
        Inherits clBD
#Region "VARIABLES"

#End Region
        Public Function ValidarUsuario(ByVal parTxtUsuario As String, ByVal parTxtPwd As String) As clInfoUsuario
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("sis.spSisCargarInfoUsuarioXLoginYPwd")
            Dim varIdUsuario As Integer = 0
            Dim varIdEmpresa As Integer = 0
            Dim varIdRelUsuXEmp As Integer = 0
            Dim varEstPrimerLogueo As Integer = 0
            Dim objInfoUsuario As clInfoUsuario

            db.AddInParameter(dbCommand, "parStrUsuario", DbType.String, parTxtUsuario)
            db.AddInParameter(dbCommand, "parStrPwd", DbType.String, parTxtPwd)
            db.AddParameter(dbCommand, "parOutIdUsuario", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, varIdUsuario)
            db.AddParameter(dbCommand, "parOutIdEmpresa", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, varIdEmpresa)
            db.AddParameter(dbCommand, "parOutEstPrimerLog", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, varEstPrimerLogueo)
            db.AddParameter(dbCommand, "parOutIdRelUsuXEmp", DbType.Int32, ParameterDirection.InputOutput, Nothing, DataRowVersion.Current, varIdRelUsuXEmp)

            db.ExecuteNonQuery(dbCommand)

            varIdUsuario = db.GetParameterValue(dbCommand, "parOutIdUsuario")
            varIdEmpresa = db.GetParameterValue(dbCommand, "parOutIdEmpresa")
            varEstPrimerLogueo = db.GetParameterValue(dbCommand, "parOutEstPrimerLog")
            varIdRelUsuXEmp = db.GetParameterValue(dbCommand, "parOutIdRelUsuXEmp")

            'varIdUsuario = 1
            'parTxtUsuario = "Administrator"
            'varIdEmpresa = 1
            'varEstPrimerLogueo = 0
            'varIdRelUsuXEmp = 1

            objInfoUsuario = New clInfoUsuario(varIdUsuario, parTxtUsuario, varIdEmpresa, varEstPrimerLogueo, varIdRelUsuXEmp)

            Return objInfoUsuario
        End Function
    End Class
    <Serializable>
    Public Class clInfoUsuario
#Region "VARIABLES"
        Dim varIdUsuario As Integer = 0
        Dim varStrLogin As String = ""
        Dim varIdEmpresa As Integer = 0
        Dim varIdRelUsuXEmp As Integer = 0
        Dim varEstPrimerLog As Integer = 0
#End Region
#Region "PROPIEDADES"
        Public ReadOnly Property pIdUsuario As Integer
            Get
                Return varIdUsuario
            End Get
        End Property
        Public ReadOnly Property pStrLogin As String
            Get
                Return varStrLogin
            End Get
        End Property
        Public ReadOnly Property pIdEmpresa As Integer
            Get
                Return varIdEmpresa
            End Get
        End Property
        Public ReadOnly Property pIdRelUsuXEmp As Integer
            Get
                Return varIdRelUsuXEmp
            End Get
        End Property
        Public Property pEstPrimerLog As Integer
            Get
                Return varEstPrimerLog
            End Get
            Set(value As Integer)
                varEstPrimerLog = value
            End Set
        End Property
#End Region
        Public Sub New(ByVal parIdUsuario As Integer, ByVal parStrLogin As String,
                       ByVal parIdEmpresa As Integer, ByVal parEstPrimerLog As Integer,
                       ByVal parIdRelUsuXEmp As Integer)
            varIdUsuario = parIdUsuario
            varStrLogin = parStrLogin
            varIdEmpresa = parIdEmpresa
            varEstPrimerLog = parEstPrimerLog
            varIdRelUsuXEmp = parIdRelUsuXEmp
        End Sub
    End Class
End Namespace