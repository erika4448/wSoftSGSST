Public Class ctrPaisCiudadDep
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
#Region "PROPIEDADES"
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    Public WriteOnly Property pBoolIniCtr As Boolean
        Set(value As Boolean)
            If value Then
                'SE INICIALIZA LA VISUALIZACION
                Me.pVisualizaXAccion = EnmAccion.Inicio
            End If
        End Set
    End Property
    'ENUMERACION PARA EL CONTROL DE ACCIONES A REALIZAR EN EL CONTROL
    Private Enum EnmAccion
        Inicio = 1
        SelPais = 2
    End Enum
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DEL CONTROL
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'PANELES=====================
                    Me.pnlCiudad.Visible = False
                    '============================

                    'SE CARGA EL PAIS
                    Me.CargarPais()

                Case EnmAccion.SelPais
                    'PANELES=====================
                    Me.pnlCiudad.Visible = True
                    '============================
            End Select
        End Set
    End Property
    'PROPIEDAD PARA EL ACCESO AL PAIS_SELECIONADO
    Public ReadOnly Property pIdPais As Integer
        Get
            Return Me.ddlPais.SelectedValue
        End Get
    End Property
    'PROPIEDAD PARA EL ACCESO A LA CIUDAD_SELECCIONADA
    Public ReadOnly Property pIdCiudad As Integer
        Get
            Return IIf(Me.pnlCiudad.Visible, Me.ddlCiudad.SelectedValue, 0)
        End Get
    End Property
    'PROPIEDAD PARA ESTABLECE SOLO LECTURA
    Public Property pBoolSoloLectura() As Boolean
        Get
            Return ViewState("pBoolSoloLectura")
        End Get
        Set(value As Boolean)
            ViewState("pBoolSoloLectura") = value

            Me.ddlPais.Enabled = Not value
            Me.ddlCiudad.Enabled = Not value
        End Set
    End Property

#End Region
#Region "PRIVADO"
    Private Sub CargarPais()
        Dim objPais As New dllSoftSGSST.SGSST.clSgsstPais

        Me.CargarListaDesplegable(Me.ddlPais, objPais.GetTblPaisXEstado(Me.pIdEmpresa, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo), "sgpaIdPais", "sgpaNombre")
    End Sub
    Private Sub CargarCiudadXPais(ByVal parIdPais As Integer)
        Dim objCiudad As New dllSoftSGSST.SGSST.clSgsstCiudad

        Me.CargarListaDesplegable(Me.ddlCiudad, objCiudad.GetTblInfoCiudadXIdPaisYEst(parIdPais, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo), "sgciIdCiudad", "sgciNombre")
    End Sub
    Protected Sub ddlPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPais.SelectedIndexChanged
        If (Me.ddlPais.SelectedValue <> 0) Then
            'MODIFICACION VISUALIZACION
            Me.pVisualizaXAccion = EnmAccion.SelPais

            'SE CARGAN LAS CIUDADES DEL PAIS
            Me.CargarCiudadXPais(Me.ddlPais.SelectedValue)
        Else
            Me.pnlCiudad.Visible = False
        End If
    End Sub
#End Region
#Region "PULICO"
    Public Sub CargarPaisCiudad(ByVal parIdPais As Integer, ByVal parIdCiudad As Integer)

        'CARGA PAIS
        If Not (Me.ddlPais.Items.FindByValue(parIdPais) Is Nothing) Then
            Me.ddlPais.SelectedValue = parIdPais

            If (Me.ddlPais.SelectedValue <> 0) Then
                Me.pVisualizaXAccion = EnmAccion.SelPais

                'SE CARGAN LAS CIUDADES DEL PAIS
                Me.CargarCiudadXPais(Me.pIdPais)

                If Not (Me.ddlCiudad.Items.FindByValue(parIdCiudad) Is Nothing) Then
                    Me.ddlCiudad.SelectedValue = parIdCiudad
                Else
                    Me.ddlCiudad.SelectedValue = 0
                End If
            End If
        Else
            Me.ddlPais.SelectedValue = 0
        End If
    End Sub
    Public Sub LimpiarCtr()
        Me.pnlCiudad.Visible = False

        If (Me.ddlPais.Items.Count > 0) Then
            Me.ddlPais.SelectedValue = 0
        End If
    End Sub
#End Region
End Class