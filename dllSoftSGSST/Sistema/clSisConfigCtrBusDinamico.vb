Imports System.Data.Common
Namespace Sistema
    Public Class clSisConfigCtrBusDinamico
        Inherits clBD
#Region "VARIABLES"
        Public scbdIdConfigCtrBusDinamico As Integer
        Public scbdNombre As String
        Public scbdDescripcion As String
        Public scbdUrlServicio As String
        Public scbdMetodoServicio As String
        Public scbdValueDdl As String
        Public scbdTextoDdl As String
        Public scbdEstUseContextKey As Integer
        Public scbdMinCaracteres As Integer
        Public scbdMetodoBusXNombre As String
        Public scbdMetodoBusXId As String
#End Region
        'FUNCION PARA CARGAR LAS VARIABLES CON EL LECTOR
        Public Sub CargarLector(ByVal drLector As IDataReader)
            scbdIdConfigCtrBusDinamico = IIf(IsDBNull(drLector("scbdIdConfigCtrBusDinamico")), 0, drLector("scbdIdConfigCtrBusDinamico"))
            scbdNombre = IIf(IsDBNull(drLector("scbdNombre")), 0, drLector("scbdNombre"))
            scbdDescripcion = IIf(IsDBNull(drLector("scbdDescripcion")), 0, drLector("scbdDescripcion"))
            scbdUrlServicio = IIf(IsDBNull(drLector("scbdUrlServicio")), 0, drLector("scbdUrlServicio"))
            scbdMetodoServicio = IIf(IsDBNull(drLector("scbdMetodoServicio")), 0, drLector("scbdMetodoServicio"))
            scbdValueDdl = IIf(IsDBNull(drLector("scbdValueDdl")), 0, drLector("scbdValueDdl"))
            scbdTextoDdl = IIf(IsDBNull(drLector("scbdTextoDdl")), 0, drLector("scbdTextoDdl"))
            scbdEstUseContextKey = IIf(IsDBNull(drLector("scbdEstUseContextKey")), 0, drLector("scbdEstUseContextKey"))
            scbdMinCaracteres = IIf(IsDBNull(drLector("scbdMinCaracteres")), 0, drLector("scbdMinCaracteres"))
            scbdMetodoBusXNombre = IIf(IsDBNull(drLector("scbdMetodoBusXNombre")), 0, drLector("scbdMetodoBusXNombre"))
            scbdMetodoBusXId = IIf(IsDBNull(drLector("scbdMetodoBusXId")), 0, drLector("scbdMetodoBusXId"))
        End Sub
        'FUNCION PARA CARGAR CONFIGURACION DEL CONTROL DE BUSQUEDA DINAMICO X ID
        Public Sub CargarInfoCtrBusDinamicoXId(ByVal parIdConfigCtrDinamico As Integer)
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("sis.spSisCargarInfoCtrBusDinamicoXId")
            db.AddInParameter(dbCommand, "parIdConfCtrBusDinamico", DbType.Int32, scbdIdConfigCtrBusDinamico)

            Using drlector As IDataReader = db.ExecuteReader(dbCommand)
                While drlector.Read

                End While
            End Using
        End Sub
        'FUNCION PARA BUSCAR POR NOMBRE SEGUN LA PARAMETRIZACION
        Public Function BusXNom(ByVal parStrNomSp As String, ByVal parCriCons As String, ByVal parIdEstado As Sistema.clSisEstado.EnmEstado) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand(parStrNomSp)
            db.AddInParameter(dbCommand, "parCriCons", DbType.String, parCriCons)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
        'FUNCION PARA BUSCAR X ID
        Public Function BusXId(ByVal parStrNomSp As String, ByVal parId As Integer) As DataTable
            Dim dbCommand As DbCommand = db.GetStoredProcCommand(parStrNomSp)
            db.AddInParameter(dbCommand, "parId", DbType.Int32, parId)
            Return db.ExecuteDataSet(dbCommand).Tables(0)
        End Function
    End Class
End Namespace

