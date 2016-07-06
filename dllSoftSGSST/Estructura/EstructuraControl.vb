Imports System.Web.Security
Imports System.Web.UI.WebControls
Namespace Estructura
    Public Class EstructuraControl
        Inherits System.Web.UI.UserControl
        Public Sub New()

        End Sub
#Region "PROPIEDADES"
        'PROPIEDAD PARA EL MANEJO DE SESION DE LA PAGINA
        Public ReadOnly Property pObjInfoUsuSesion() As dllSoftSGSST.Seguridad.clObjLoginSesion
            Get
                If Me.Session("pOIUS") Is Nothing Then
                    If Me.Page.User.Identity.IsAuthenticated Then
                        Me.Session("pOIUS") = New dllSoftSGSST.Seguridad.clObjLoginSesion
                        Me.Session("pOIUS").CargarObjetoLogin(Me.pTicket.UserData)
                    End If
                End If
                Return Me.Session("pOIUS")
            End Get
        End Property
        Public ReadOnly Property p_Identity() As FormsIdentity
            Get
                Return CType(Me.Page.User.Identity, FormsIdentity)
            End Get
        End Property
        Public ReadOnly Property pTicket() As FormsAuthenticationTicket
            Get
                Return p_Identity.Ticket
            End Get
        End Property
        Public ReadOnly Property pIdEmpresa As Integer
            Get
                Return Me.pObjInfoUsuSesion.pObjInfoUsuario.pIdEmpresa
            End Get
        End Property
        Public ReadOnly Property pIdRelUsuXEmp As Integer
            Get
                Return Me.pObjInfoUsuSesion.pObjInfoUsuario.pIdRelUsuXEmp
            End Get
        End Property
#End Region
#Region "PUBLICO"
        Public Sub CargarListaDesplegable(ByVal parCombo As DropDownList, ByVal parDtDatos As Data.DataTable, ByVal parValue As String, ByVal parTexto As String)
            parCombo.DataSource = parDtDatos
            parCombo.DataValueField = parValue
            parCombo.DataTextField = parTexto
            parCombo.DataBind()
            parCombo.Items.Add(New ListItem("Seleccione", 0))
            parCombo.SelectedValue = 0
        End Sub
        Public Sub AlertDialog(ByVal parStrMensaje As String)
            parStrMensaje = Replace(parStrMensaje, "'", "")
            parStrMensaje = Replace(parStrMensaje, ":", "")
            parStrMensaje = Replace(parStrMensaje, Chr(34), "")
            parStrMensaje = Replace(parStrMensaje, vbCrLf, " - ")
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MsjAlertDialog", String.Format("alertify.alert('{0}');", parStrMensaje), True)
        End Sub
        Public Sub SuccessLog(ByVal parStrMensaje As String)
            parStrMensaje = Replace(parStrMensaje, "'", "")
            parStrMensaje = Replace(parStrMensaje, ":", "")
            parStrMensaje = Replace(parStrMensaje, Chr(34), "")
            parStrMensaje = Replace(parStrMensaje, vbCrLf, " - ")
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MsjSuccessLog", String.Format("alertify.success('{0}');", parStrMensaje), True)
        End Sub
        Public Sub FailureLog(ByVal parStrMensaje As String)
            parStrMensaje = Replace(parStrMensaje, "'", "")
            parStrMensaje = Replace(parStrMensaje, ":", "")
            parStrMensaje = Replace(parStrMensaje, Chr(34), "")
            parStrMensaje = Replace(parStrMensaje, vbCrLf, " - ")
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MsjFailureLog", String.Format("alertify.error('{0}');", parStrMensaje), True)
        End Sub
#End Region
    End Class
End Namespace
