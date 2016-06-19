Imports System.Web.UI.WebControls
Namespace Estructura
    Public Class EstructuraControl
        Inherits System.Web.UI.UserControl
        Public Sub New()
            pIdRelUsuXEmp = 1
        End Sub
        Public Property pIdRelUsuXEmp As Integer
            Get
                Return ViewState("pIdRelUsuXEmp")
            End Get
            Set(value As Integer)
                ViewState("pIdRelUsuXEmp") = value
            End Set
        End Property
        Public Sub NuevaVentana(ByVal parStrKey As String, ByVal parStrUrl As String)
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), _
                                                parStrKey, _
                                                "window.open('" & Me.Page.ResolveClientUrl(parStrUrl) & "');", _
                                                True)
        End Sub
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
    End Class
End Namespace
