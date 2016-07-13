Public Class frmMtRgCalificarRiesgo
    Inherits dllSoftSGSST.Estructura.EstructuraPagina

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'VALIDA INGRESO POR LINK
            Me.SeIngresoPorLink()
        End If
    End Sub
#Region "PROPIEDADES"
    'PROPIEDAD PARA INICIALIZAR LA PAGINA
    Public WriteOnly Property pBoolIniPagina As Boolean
        Set(value As Boolean)
            If value Then
                'SE INICIALIZA LA VISUALIZACION
                Me.pVisualizaXAccion = EnmAccion.Inicio
            End If
        End Set
    End Property
    'ENUMERACION PARA EL CONTROL DE ACCIONES QUE SE REALIZAN EN LA PAGINA
    Private Enum EnmAccion
        Inicio = 1
    End Enum
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DE LA PAGINA
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio

                    'SE INICIALIZA EL CONTROL DE PELIGRO
                    Me.ctrInfoPeligro1.pIdPeligro = Me.pIdPeligro
                    Me.ctrInfoPeligro1.pBoolIniCtr = True
            End Select
        End Set
    End Property
    'PROPIEDAD PARA EL ALMACENAMIENTO DEL ID_PELIGRO
    Private Property pIdPeligro As Integer
        Get
            Return ViewState("pIdPeligro")
        End Get
        Set(value As Integer)
            ViewState("pIdPeligro") = value
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub ibtnRegresarMatRiesgos_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnRegresarMatRiesgos.Click
        Dim varStrURL As String = ""

        varStrURL = New System.Uri(Context.Request.Url, ResolveUrl("~/Planear/MatrizRiesgos/frmMtRgMatrizRiesgos.aspx")).ToString
        Me.Response.Redirect(varStrURL)
    End Sub
#End Region
#Region "PRIVADO"
    Private Function SeIngresoPorLink()
        If (Me.Request.Params("PIP") IsNot Nothing AndAlso IsNumeric(Me.Request.Params("PIP"))) Then
            Me.pIdPeligro = Me.Request.Params("PIP")
        End If

        If (Me.pIdPeligro <> 0) Then
            Me.pBoolIniPagina = True
            Return True
        End If
        Return False
    End Function
#End Region
End Class