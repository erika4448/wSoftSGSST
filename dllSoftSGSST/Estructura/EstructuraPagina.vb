Imports System.IO
Imports System.IO.Compression
Imports System.Web.Security
Imports System.Web.UI.WebControls
Namespace Estructura
    Public Class EstructuraPagina
        Inherits System.Web.UI.Page
        Dim _objInfoUsuSesion As dllSoftSGSST.Seguridad.clObjLoginSesion

        Public Sub New()
        End Sub
#Region "PROPIEDADES"
        'PROPIEDAD PARA EL MANEJO DE SESION DE LA PAGINA
        Public ReadOnly Property pObjInfoUsuSesion() As dllSoftSGSST.Seguridad.clObjLoginSesion
            Get
                If Me.Session("pOIUS") Is Nothing Then
                    If Me.User.Identity.IsAuthenticated Then
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
#Region "VIEWSTATE"
        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal pViewState As Object)
            Dim pair1 As Pair
            Dim pageStatePersister1 As System.Web.UI.PageStatePersister = Me.PageStatePersister
            Dim ViewState As Object
            If (pViewState.GetType = GetType(Pair)) Then

                pair1 = CType(pViewState, Pair)
                pageStatePersister1.ControlState = pair1.First
                ViewState = pair1.Second
            Else
                ViewState = pViewState
            End If
            Dim mFormat As LosFormatter = New LosFormatter()
            Dim mWriter As StringWriter = New StringWriter()
            mFormat.Serialize(mWriter, ViewState)
            Dim mViewStateStr As String = mWriter.ToString()
            Dim pBytes As Byte() = System.Convert.FromBase64String(mViewStateStr)
            pBytes = Compress(pBytes)
            Dim vStateStr As String = System.Convert.ToBase64String(pBytes)
            pageStatePersister1.ViewState = vStateStr
            pageStatePersister1.Save()
        End Sub
        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Dim pageStatePersister1 As System.Web.UI.PageStatePersister = Me.PageStatePersister
            pageStatePersister1.Load()
            Dim vState As String = pageStatePersister1.ViewState.ToString()
            Dim pBytes As Byte() = System.Convert.FromBase64String(vState)
            pBytes = Decompress(pBytes)
            Dim mFormat As LosFormatter = New LosFormatter()
            Dim ViewState As Object = mFormat.Deserialize(System.Convert.ToBase64String(pBytes))
            Return New Pair(pageStatePersister1.ControlState, ViewState)
        End Function
        Private Function Compress(ByVal bytes As Byte()) As Byte()
            Dim ms As New MemoryStream
            Dim zs = New GZipStream(ms, Compression.CompressionMode.Compress, True)
            zs.Write(bytes, 0, bytes.Length)
            zs.Close()
            Return ms.ToArray()
        End Function
        Private Function Decompress(ByVal bytes As Byte()) As Byte()
            Dim ms As MemoryStream = New MemoryStream()
            Dim zs As GZipStream = New GZipStream(New MemoryStream(bytes), CompressionMode.Decompress, True)
            Dim buffer(4096) As Byte
            buffer(4096) = New Byte()
            Dim size As Integer
            While True
                size = zs.Read(buffer, 0, buffer.Length)
                If (size > 0) Then
                    ms.Write(buffer, 0, size)
                Else
                    Exit While
                End If
            End While
            zs.Close()
            Return ms.ToArray()
        End Function
#End Region
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