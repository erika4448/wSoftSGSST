Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Namespace Seguridad
    <Serializable()>
    Public Class clObjLoginSesion
#Region "VARIABLES"
        Public varObjInfoUsuario As dllSoftSGSST.Sistema.clInfoUsuario
#End Region


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
    End Class
End Namespace