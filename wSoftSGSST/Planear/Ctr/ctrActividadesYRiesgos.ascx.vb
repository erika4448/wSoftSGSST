Public Class ctrActividadesYRiesgos
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
#Region "PROPIEDADES"
    'ENUMERACION PARA EL MANEJO DE ACCIONES DEL CONTROL
    Public Enum EnmAccion
        Inicio = 1
    End Enum
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    Public WriteOnly Property pBoolIniciarCtr As Boolean
        Set(value As Boolean)
            'VISUALIZACION PANELES
            Me.pnlGvActRiesgos.Visible = True
            Me.pnlActividad.Visible = False

            'DEFINIR EL LBL DEL NOMBRE DEL CARGO
            Me.lblNomCargo.Text = Me.pStrNomCargo


        End Set
    End Property
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DEL CONTROL
    Public WriteOnly Property pVisualizacionXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio

            End Select
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL ID DEL CARGO
    Public Property pIdCargo As Integer
        Get
            Return ViewState("pIdCargo")
        End Get
        Set(value As Integer)
            ViewState("pIdCargo") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL NOMBRE DEL CARGO
    Public Property pStrNomCargo As String
        Get
            Return ViewState("pStrNomCargo")
        End Get
        Set(value As String)
            ViewState("pStrNomCargo") = value
        End Set
    End Property
#End Region
#Region "PROTEGIDO"

#End Region
#Region "PRIVADO"

#End Region
#Region "PUBLICO"

#End Region
End Class