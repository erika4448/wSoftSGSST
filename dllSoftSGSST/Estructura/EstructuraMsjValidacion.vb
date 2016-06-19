Imports System.Text

Namespace Estructura
    Public Class EstructuraMsjValidacion
        Public _varStrMensaje As String = ""
        Public Property pStrMensaje() As String
            Get
                Return _varStrMensaje
            End Get
            Set(value As String)
                _varStrMensaje = value
            End Set
        End Property
        Public _varBoolRtn As Boolean = True
        Public Property pBoolRtn As Boolean
            Get
                Return _varBoolRtn
            End Get
            Set(value As Boolean)
                _varBoolRtn = value
            End Set
        End Property
        'ENUMERACION PARA EL CONTROL DE TIPOS DE MENSAJE A MOSTRAR EN LA APLICACION
        Public Enum EnmTipoMensaje
            Advertencia = 1
            Informativo = 2
            ValidacionCampos = 3
        End Enum
        'FUNCION PARA AGREGAR MENSAJE AL CONSTRUCTOR
        Public Sub AgregarMensaje(ByVal parStrMensaje As String, Optional ByVal parBoolSaltoLinea As Boolean = True)
            pStrMensaje = pStrMensaje & parStrMensaje & IIf(parBoolSaltoLinea = True, "<br/>", "")

            Me.pBoolRtn = False
        End Sub

        Public Function GetMensajeValidacion() As String
            Dim strBuilder As New StringBuilder()

            strBuilder.Append("<table align='center' width='500px'>")
            strBuilder.Append(" <tr>")
            strBuilder.Append("     <td align='center' width='100px'>")
            strBuilder.Append("<img src='../../Images/Msj/imAdvertencia.png' />")
            strBuilder.Append("     </td>")
            strBuilder.Append("     <td align='left'>")
            strBuilder.Append("Por favor verifique <br/>" & Me.pStrMensaje)
            strBuilder.Append("     </td>")
            strBuilder.Append(" </tr>")
            strBuilder.Append("</table>")

            Return strBuilder.ToString()
        End Function

        Public Function GetMensaje(ByVal parIdTipoMensaje As EnmTipoMensaje, ByVal parStrMensaje As String) As String
            Dim strBuilder As New StringBuilder()

            If (parIdTipoMensaje = EnmTipoMensaje.Advertencia Or parIdTipoMensaje = EnmTipoMensaje.Informativo) Then
                strBuilder.Append("<table align='center'>")
                strBuilder.Append(" <tr>")
                strBuilder.Append("     <td align='center'>")
                strBuilder.Append(parStrMensaje)
                strBuilder.Append("     </td>")
                strBuilder.Append(" </tr>")
                strBuilder.Append("</table>")
            End If

            Return strBuilder.ToString()
        End Function
    End Class
End Namespace
