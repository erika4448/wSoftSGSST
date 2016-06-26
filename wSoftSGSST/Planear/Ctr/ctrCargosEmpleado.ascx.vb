Public Class ctrCargosEmpleado
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

            End If
        End Set
    End Property
    'ENUMERACION PARA EL CONTROL DE ACCIONES QUE SE REALIZAN EN EL CONTROL
    Private Enum EnmAccion
        Inicio = 1
    End Enum
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DEL CONTROL
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'BOTONES===================
                    Me.ibtnHistorico.Visible = IIf(Me.pIdEmpleado = 0, False, True)
                    Me.ibtnRelNuevoCargo.Visible = IIf(Me.pIdEmpleado = 0, False, True)
                    Me.ibtnRequisitos.Visible = IIf(Me.pIdCargo = 0, False, True)
                    '==========================
                    'SE CARGAN LOS CARGOS
                    Me.CargarCargos()
            End Select
        End Set
    End Property
    'PROPIEDAD PAA EL ALMACENAMIENTO DE CARGOS
    Public Property pIdCargo As Integer
        Get
            Return ViewState("pIdCargo")
        End Get
        Set(value As Integer)
            ViewState("pIdCargo") = value

            If (value <> 0) Then
                Me.ibtnRequisitos.Visible = True
            Else
                Me.ibtnRequisitos.Visible = False
            End If
        End Set
    End Property
    'PROPIEDAD PARA EL ALMACENAMIENTO DEL ID_EMPLEADO
    Public Property pIdEmpleado As Integer
        Get
            Return ViewState("pIdEmpleado")
        End Get
        Set(value As Integer)
            ViewState("pIdEmpleado") = value
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub ddlCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCargo.SelectedIndexChanged
        Me.pIdCargo = Me.ddlCargo.SelectedValue
    End Sub
#End Region
#Region "PRIVADO"
    Private Sub CargarCargos()
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo

        Me.CargarListaDesplegable(Me.ddlCargo, objCargo.GetTblInfoCargoXIdEst(Me.pIdEmpresa, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo), "sgcaIdCargo", "sgcaNombre")
    End Sub
    Private Sub CargarInfoRequisitosCargo(ByVal parIdCargo As Integer)

    End Sub
    Protected Sub ibtnRequisitos_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnRequisitos.Click

        Me.modalReqCargo.Show()
        Me.upnlReqCargo.Update()
    End Sub
#End Region
End Class