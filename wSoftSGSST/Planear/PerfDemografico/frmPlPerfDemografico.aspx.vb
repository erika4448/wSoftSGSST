Public Class frmPlPerfDemografico
    Inherits dllSoftSGSST.Estructura.EstructuraPagina

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'SE INICIALIZA LA PAGINA
            Me.pBoolIniPagina = True
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
    'ENUMERACION PARA LAS ACCIONES QUE SE REALIZAN EN LA PAGINA
    Private Enum EnmAccion
        Inicio = 1
        NuevoEmpleado = 2
        CargarEmpleado = 3
    End Enum
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DE LA PAGINA
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'PANELES============
                    Me.pnlBusEmpleado.Visible = True
                    Me.pnlInfoEmpleado.Visible = False
                    '===================
                    'BOTONES============
                    Me.ibtnNuevoEmpleado.Visible = True
                    Me.btnNuevaConsulta.Visible = False
                    Me.btnLimpiar.Visible = False
                    '===================

                    'INICIALIZA CONTROL DE DINA CONS
                    Me.ctrDinaConsObj1.pIdConfigCtrBusDina = 2
                    Me.ctrDinaConsObj1.pBoolIniCtr = True

                Case EnmAccion.NuevoEmpleado
                    'PANELES============
                    Me.pnlBusEmpleado.Visible = False
                    Me.pnlInfoEmpleado.Visible = True
                    '===================
                    'BOTONES============
                    Me.ibtnNuevoEmpleado.Visible = True
                    Me.btnNuevaConsulta.Visible = True
                    Me.btnLimpiar.Visible = True
                    '===================

                Case EnmAccion.CargarEmpleado
                    'PANELES============
                    Me.pnlBusEmpleado.Visible = False
                    Me.pnlInfoEmpleado.Visible = True
                    '===================
                    'BOTONES============
                    Me.ibtnNuevoEmpleado.Visible = True
                    Me.btnNuevaConsulta.Visible = True
                    Me.btnLimpiar.Visible = False
                    '===================
            End Select
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub ibtnNuevoEmpleado_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnNuevoEmpleado.Click
        'MODIFICA LA VISUALIZACION
        Me.pVisualizaXAccion = EnmAccion.NuevoEmpleado


        'INICIALIZA CONTROL DE INFO_EMPLEADO
        Me.ctrInfoEmpleado1.pIdEmpleado = 0
        Me.ctrInfoEmpleado1.pBoolIniCtr = True
        Me.ctrInfoEmpleado1.LimpiarCtr()

        Me.upnlPerfDemografico.Update()
    End Sub
    Protected Sub btnNuevaConsulta_Click(sender As Object, e As EventArgs) Handles btnNuevaConsulta.Click
        'MODIFICA LA VISUALIZACION
        Me.pVisualizaXAccion = EnmAccion.Inicio

        Me.upnlPerfDemografico.Update()
    End Sub
#End Region
#Region "PRIVADO"
    Private Sub LimpiarCr()
        Me.ctrInfoEmpleado1.limpiarCtr()
    End Sub
#End Region
#Region "EVENTOS"
    Private Sub evtSelEmpleado() Handles ctrDinaConsObj1.evtSelecciono
        Me.pVisualizaXAccion = EnmAccion.CargarEmpleado

        Me.ctrInfoEmpleado1.pIdEmpleado = Me.ctrDinaConsObj1.pIdSel
        Me.ctrInfoEmpleado1.pBoolIniCtr = True

        Me.ctrInfoEmpleado1.CargarEmpleado()

        Me.upnlPerfDemografico.Update()
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.ConfirmationDialog("¿Confirma que desea limpiar el formulario?", Me.lbtnLimpiarForm.UniqueID)
        Me.upnlPerfDemografico.Update()
    End Sub

    Protected Sub lbtnLimpiarForm_Click(sender As Object, e As EventArgs) Handles lbtnLimpiarForm.Click
        Me.LimpiarCr()
        Me.upnlPerfDemografico.Update()
    End Sub
#End Region
End Class