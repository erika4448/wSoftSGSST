Imports System.Data.Common
Imports System.Web
Imports System.Web.Security

Namespace Seguridad
    Public Class clUsuario
        Public Sub GenerarTicketAutenticacion(ByVal parRefPagina As System.Web.UI.Page,
                                ByVal parStrLogin As String,
                                ByVal parObjLoginSesion As dllSoftSGSST.Seguridad.clObjLoginSesion,
                                ByVal parStrURLRetorno As String)

            Dim varTicketAutentica As FormsAuthenticationTicket
            Dim varStrInfoCookie As String
            Dim varCookie As HttpCookie
            Dim varStrURLRedirecciona As String

            'CREA EL TICKET DE AUTENTICACION CON LA INFORMACION PROVEIDA
            varTicketAutentica = New FormsAuthenticationTicket(1,
                                                parStrLogin,
                                                DateTime.Now,
                                                DateTime.Now.AddMinutes(30),
                                                False,
                                                parObjLoginSesion.GetObjLogin())

            varStrInfoCookie = FormsAuthentication.Encrypt(varTicketAutentica)
            varCookie = New HttpCookie(FormsAuthentication.FormsCookieName, varStrInfoCookie)


            varCookie.Path = FormsAuthentication.FormsCookiePath

            'LE AÑADE AL RESPONSE DE LA PAGINA LA COOKIE DE AUTENTICACION
            parRefPagina.Response.Cookies.Add(varCookie)
            varStrURLRedirecciona = parRefPagina.Request("ReturnUrl")

            'REDIRECCIONA A LA URL DEL SOLICITADA POR EL SISTEMA
            parRefPagina.Response.Redirect(varStrURLRedirecciona, False)
        End Sub
    End Class
End Namespace