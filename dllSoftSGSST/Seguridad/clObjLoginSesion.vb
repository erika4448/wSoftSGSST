Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Namespace Seguridad
    <Serializable()>
    Public Class clObjLoginSesion
#Region "VARIABLES"
        Public varObjInfoUsuario As dllSoftSGSST.Sistema.clInfoUsuario
#End Region
#Region "PROPIEDADES"
        Public ReadOnly Property pObjInfoUsuario As dllSoftSGSST.Sistema.clInfoUsuario
            Get
                Return varObjInfoUsuario
            End Get
        End Property
#End Region
        Public Sub New()

        End Sub
        Public Sub New(ByVal parInfoUsuario As dllSoftSGSST.Sistema.clInfoUsuario)
            varObjInfoUsuario = parInfoUsuario
        End Sub
        Public Function GetObjLogin() As String
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim binaryFormatter As BinaryFormatter = New BinaryFormatter
            binaryFormatter.Serialize(memoryStream, Me)
            Dim str As String = System.Convert.ToBase64String(memoryStream.ToArray())
            Return str
        End Function
        Public Sub CargarObjetoLogin(ByVal parStrObj As String)
            Dim memoryStream As MemoryStream
            Dim binaryFormatter As BinaryFormatter = New BinaryFormatter

            Dim k() As Byte
            k = System.Convert.FromBase64String(parStrObj)
            memoryStream = New MemoryStream(k)

            Dim objeto As dllSoftSGSST.Seguridad.clObjLoginSesion
            objeto = CType(binaryFormatter.Deserialize(memoryStream), dllSoftSGSST.Seguridad.clObjLoginSesion)
        End Sub
    End Class
End Namespace