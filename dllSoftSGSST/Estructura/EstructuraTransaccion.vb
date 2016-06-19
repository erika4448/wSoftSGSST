Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace Estructura
    Public Class EstructuraTransaccion
        Inherits Sistema.clBD
        Dim trConexion As DbConnection
        Public trTransaccion As DbTransaction
        Public Sub trCrearTransaccion()
            db = DatabaseFactory.CreateDatabase
            trConexion = db.CreateConnection
            trConexion.Open()
            trTransaccion = trConexion.BeginTransaction()
        End Sub
        Public Sub trConfirmarTransaccion()
            trTransaccion.Commit()
            trConexion.Close()
        End Sub
        Public Sub trRollBackTransaccion()
            trTransaccion.Rollback()
            trConexion.Close()
        End Sub
    End Class
End Namespace
