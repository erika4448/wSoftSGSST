Public Class ctrCargosEmpleado
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
    '======================================VARIABLES===============================
    Dim varBoolGuardoCargo As Boolean = False
    '==============================================================================
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
    Protected Sub ibtnRequisitos_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnRequisitos.Click
        'SE ENVIA A CARGAR INFORMACION DE REQUISITOS CARGO
        Me.CargarInfoRequisitosCargo(Me.pIdCargo)

        Me.modalReqCargo.Show()
        Me.upnlReqCargo.Update()
    End Sub
    Protected Sub ibtnHistorico_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnHistorico.Click
        'SE ENVIA A CARGAR GRILLA DE HISTORICO CARGOS
        Me.CargarGrillaHistCargos()

        Me.modalHistCargo.Show()
        Me.upnlHistCargo.Update()
    End Sub
    Protected Sub ibtnRelNuevoCargo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnRelNuevoCargo.Click
        'SE CARGA EL NOMBRE DEL CARGO ACTUAL
        Me.lblInfoCargoActualRelNuevoCargo.Text = Me.CargarNombreCargo(Me.pIdCargo)

        'SE ENVIA A CARGAR CARGOS
        Me.CargarNuevosCargos()

        Me.modalRelNuevoCargo.Show()
        Me.upnlRelNuevoCargo.Update()
    End Sub
    Protected Sub ibtnGuardarCargo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardarCargo.Click
        If (Me.PermiteGuardarCargo()) Then
            'SE ENVIA A GUARDAR CARGO
            Me.GuardarCargo()

            If (varBoolGuardoCargo = True) Then
                Me.pIdCargo = Me.ddlNuevoCargo.SelectedValue

                'SE CARGA EL CARGO GUARDADO
                If Not (Me.ddlCargo.Items.FindByValue(Me.pIdCargo) Is Nothing) Then
                    Me.ddlCargo.SelectedValue = Me.pIdCargo
                Else
                    Me.ddlCargo.SelectedValue = 0
                End If

                'SE LIMPIA EL FORMULARIO DE REL_NUEVO_CARGO
                Me.LimpiarFormRelNuevoCargo()
            End If
        End If
    End Sub
    Protected Sub ibtnCerrarHistCargo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCerrarHistCargo.Click
        Me.modalHistCargo.Hide()
        Me.upnlHistCargo.Update()
    End Sub
    Protected Sub ibtnCerrarReqCargo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCerrarReqCargo.Click
        Me.modalReqCargo.Hide()
        Me.upnlReqCargo.Update()
    End Sub
    Protected Sub ibtnCerrarRelNuevoCargo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCerrarRelNuevoCargo.Click
        'SE LIMPIA LE FORMULARIO
        Me.LimpiarFormRelNuevoCargo()

        Me.modalRelNuevoCargo.Hide()
        Me.upnlRelNuevoCargo.Update()
    End Sub
#End Region
#Region "PRIVADO"
    Private Sub CargarCargos()
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo

        Me.CargarListaDesplegable(Me.ddlCargo, objCargo.GetTblInfoCargoXIdEst(Me.pIdEmpresa, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo), "sgcaIdCargo", "sgcaNombre")
    End Sub
    Private Sub CargarNuevosCargos()
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo

        Me.CargarListaDesplegable(Me.ddlNuevoCargo, objCargo.GetTblInfoCargoXIdEst(Me.pIdEmpresa, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo), "sgcaIdCargo", "sgcaNombre")
    End Sub
    Private Sub CargarInfoRequisitosCargo(ByVal parIdCargo As Integer)
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        Dim dtDatos As New Data.DataTable


        dtDatos = objCargo.CargarInfoCargoXIdCargo(parIdCargo)

        If (dtDatos.Rows.Count > 0) Then
            Me.lblInfoCargoActual.Text = dtDatos.Rows(0)("sgcaNombre")
            Me.lblInfoEducacion.Text = dtDatos.Rows(0)("StrEducacion")
            Me.lblInfoProfesion.Text = dtDatos.Rows(0)("StrProfesion")
            Me.lblInfoExperienciaAnios.Text = dtDatos.Rows(0)("sgcaAnosExperiencia")
            Me.lblInfoHabilidades.Text = dtDatos.Rows(0)("sgcaHabilidades")
        End If
    End Sub
    Private Function CargarNombreCargo(ByVal parIdCargo As Integer) As String
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        Dim dtDatos As New Data.DataTable

        dtDatos = objCargo.CargarInfoCargoXIdCargo(parIdCargo)

        If (dtDatos.Rows.Count > 0) Then
            Return dtDatos.Rows(0)("sgcaNombre")
        Else
            Return ""
        End If
    End Function
    Private Function PermiteGuardarCargo() As Boolean
        Dim objMsjRtnValida As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        'VALIDA CARGO
        If (Me.ddlNuevoCargo.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Cargo", True)
            Me.lblAstValNuevoCargo.Visible = True
        Else
            Me.lblAstValNuevoCargo.Visible = False
        End If

        'VALDA FECHA_INGRESO
        If (Me.ctrFechaIngreso.pBooEsFecha = False) Then
            objMsjRtnValida.AgregarMensaje("Fecha Ingreso", True)
            Me.lblAstValNuevoCargo.Visible = True
        Else
            Me.lblAstValNuevoCargo.Visible = False
        End If

        If Not (objMsjRtnValida.pBoolRtn) Then
            Me.AlertDialog(objMsjRtnValida.GetMensajeValidacion())
        End If

        Return objMsjRtnValida.pBoolRtn
    End Function
    Private Sub GuardarCargo()
        Dim objEmpleado As New dllSoftSGSST.SGSST.clSgsstEmpleado
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion

        Try
            objTrans.trCrearTransaccion()

            objEmpleado.sgemIdEmpleado = Me.pIdEmpleado
            objEmpleado.sgemIdCargo = Me.ddlNuevoCargo.SelectedValue
            objEmpleado.sgemFchIngreso = Me.ctrFechaIngreso.pFecha

            objEmpleado.ActInfoCargoEmpleadoXIdEmp(Me.pIdRelUsuXEmp, objTrans.trTransaccion)
            Me.varBoolGuardoCargo = True
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            Me.varBoolGuardoCargo = False
            objTrans.trRollBackTransaccion()
            Me.FailureLog("Error guardando cargo: " & ex.Message)
        End Try
    End Sub
    Private Sub LimpiarFormRelNuevoCargo()
        Me.ctrFechaIngreso.LimpiarControl()
    End Sub
#End Region
#Region "PUBLICO"
    Public Sub CargarInfoCargoXID()
        If Not (Me.ddlCargo.Items.FindByValue(Me.pIdCargo) Is Nothing) Then
            Me.ddlCargo.SelectedValue = Me.pIdCargo
        Else
            Me.ddlCargo.SelectedValue = 0
        End If
    End Sub
#End Region
#Region "DATA SOURCE GRILLA HISTORICO CARGOS"
    Public Sub CargarGrillaHistCargos()
        Me.gvHistCargos.DataBind()
    End Sub
    Protected Sub odsHistCargo_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsHistCargo.Selecting
        e.InputParameters("parIdEmpleado") = Me.pIdEmpleado
    End Sub
    Protected Sub odsHistCargo_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles odsHistCargo.Selected
        Me.gvHistCargos.Visible = True
    End Sub
    Protected Sub odsHistCargo_ObjectCreating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceEventArgs) Handles odsHistCargo.ObjectCreating
        e.ObjectInstance = New dllSoftSGSST.SGSST.clSgsstHistCargosEmp
    End Sub
#End Region
End Class