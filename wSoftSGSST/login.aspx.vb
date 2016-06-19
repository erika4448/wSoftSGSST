Public Class login
    Inherits dllSoftSGSST.Estructura.EstructuraPagina

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
#Region "PROPIEDADES"
    Private Property pObjInfoUsuario As dllSoftSGSST.Sistema.clInfoUsuario
        Get
            Return ViewState("pObjInfoUsuario")
        End Get
        Set(value As dllSoftSGSST.Sistema.clInfoUsuario)
            ViewState("pObjInfoUsuario") = value
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub ibtnIngresa_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnIngresa.Click
        'VALIDA SI SE PERMITE INGRESAR AL USUARIO
        If (Me.PermiteIngresar()) Then
            'REALIZA EL INGRESO DEL USUARIO
            Me.IngresarUsuario()
        End If
    End Sub
#End Region
#Region "PRIVADO"
    Private Function GetInfoUsuario() As dllSoftSGSST.Sistema.clInfoUsuario
        Dim objUsuario As New dllSoftSGSST.Sistema.clUsuario
        Dim varObjInfoUsuario As dllSoftSGSST.Sistema.clInfoUsuario

        'SE CARGA LA INFORMACION DEL USUARIO
        varObjInfoUsuario = objUsuario.ValidarUsuario(Trim(Me.txtUsuario.Text), Trim(txtPswd.Text))

        Return varObjInfoUsuario
    End Function
    Private Function PermiteIngresar()
        Dim objMsjRtn As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        'VALIDA USUARIO
        If (Trim(Me.txtUsuario.Text).Length = 0) Then
            objMsjRtn.AgregarMensaje("Debe ingresar Usuario.")
        End If

        'VALIDA CONTRASEÑA
        If (Trim(Me.txtPswd.Text).Length = 0) Then
            objMsjRtn.AgregarMensaje("Debe ingresar Contraseña.")
        End If

        'VALIDA SI EL USUARIO EXISTE
        Me.pObjInfoUsuario = Me.GetInfoUsuario()
        If (Me.pObjInfoUsuario.pIdUsuario = 0) Then
            objMsjRtn.AgregarMensaje("Datos de ingreso errados, por favor verifique el usuario o contraseña y vuelva a intentarlo.")
        End If

        If Not (objMsjRtn.pBoolRtn) Then
            Me.AlertDialog(objMsjRtn.GetMensaje(dllSoftSGSST.Estructura.EstructuraMsjValidacion.EnmTipoMensaje.Advertencia, objMsjRtn.pStrMensaje))
        End If

        Return objMsjRtn.pBoolRtn
    End Function
    Private Function IngresarUsuario() As Boolean
        Dim objUsuario As New dllSoftSGSST.Seguridad.clUsuario

        Try
            'GENERA EL TICKET DE AUTENTICACION
            objUsuario.GenerarTicketAutenticacion(Me.Page,
                                              Me.pObjInfoUsuario.pStrLogin,
                                              New dllSoftSGSST.Seguridad.clObjLoginSesion(Me.pObjInfoUsuario),
                                              IIf(Me.pObjInfoUsuario.pEstPrimerLog, "123", "456"))

            Return True
        Catch ex As Exception
            Me.FailureLog("Error intentando loguear: " & ex.Message)
            Return False
        End Try
    End Function
#End Region
End Class