﻿Public Class frmPlPerfDemografico
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
                    '===================

                    'INICIALIZA CONTROL DE DINA CONS
                    'Me.ctrDinaConsObj1.pIdConfigCtrBusDina =

                Case EnmAccion.NuevoEmpleado
                    'PANELES============
                    Me.pnlBusEmpleado.Visible = False
                    Me.pnlInfoEmpleado.Visible = True
                    '===================
                    'BOTONES============
                    Me.ibtnNuevoEmpleado.Visible = False
                    '===================

                Case EnmAccion.CargarEmpleado
                    'PANELES============
                    Me.pnlBusEmpleado.Visible = False
                    Me.pnlInfoEmpleado.Visible = True
                    '===================
                    'BOTONES============
                    Me.ibtnNuevoEmpleado.Visible = False
                    '===================
            End Select
        End Set
    End Property
#End Region
#Region "PRIVADO"
    Protected Sub ibtnNuevoEmpleado_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnNuevoEmpleado.Click
        'MODIFICA LA VISUALIZACION
        Me.pVisualizaXAccion = EnmAccion.NuevoEmpleado

        'INICIALIZA CONTROL DE INFO_EMPLEADO
        Me.ctrInfoEmpleado1.pBoolIniCtr = True

        Me.upnlPerfDemografico.Update()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.pVisualizaXAccion = EnmAccion.CargarEmpleado

        Me.ctrInfoEmpleado1.pIdEmpleado = 2
        Me.ctrInfoEmpleado1.pBoolIniCtr = True

        Me.ctrInfoEmpleado1.CargarEmpleado()

        Me.upnlPerfDemografico.Update()
    End Sub
#End Region
#Region "EVENTOS"

#End Region
End Class