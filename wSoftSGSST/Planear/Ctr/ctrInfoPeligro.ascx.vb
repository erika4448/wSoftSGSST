Public Class ctrInfoPeligro
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
    '====================================VARIABLES======================================
    Dim varBoolGuardoConfPeligro As Boolean = False
    '===================================================================================
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
    'ENUEMRACION PARA EL CONTROL DE ACCIONES QUE SE REALIZAN EN EL CONTROL
    Private Enum EnmAccion
        Inicio = 1
    End Enum
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DE LA ACCION
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'PANELES==========================
                    Me.pnlCargos.Visible = False
                    '=================================
                    'SE CARGA LA INFORMACION DEL PELIGRO
                    Me.CargarInfoPeligro()

                    'SE CARGA LA INFORMACION DE CARGOS
                    Me.CargarGrillaCargos()

                    'SE CARGA INFORAMCION DE PROCESOS
                    Me.ctrProceso1.pIdPeligro = Me.pIdPeligro
                    Me.ctrProceso1.pBoolIniCtr = True
                    Me.ctrProceso1.CargarInfoXPeligro()

                    'SE CARGA INFORMACION DE LUGARES
                    Me.ctrLugar1.pIdPeligro = Me.pIdPeligro
                    Me.ctrLugar1.pBoolIniCtr = True
                    Me.ctrLugar1.CargarInfoXPeligro()
            End Select
        End Set
    End Property
    'PROPIEDAD PARA EL ALMACENAMIENTO DEL ID_PELIGRO
    Public Property pIdPeligro As Integer
        Get
            Return ViewState("pIdPeligro")
        End Get
        Set(value As Integer)
            ViewState("pIdPeligro") = value
        End Set
    End Property
    'ENUMERACION PARA EL MANEJO DE RUTINARIA
    Private Enum EnmRutinaria
        Si = 1
        No = 2
    End Enum
#End Region
#Region "PROTEGIDO"
    Protected Sub ibtnIncluirRiesgo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnIncluirRiesgo.Click
        If (Me.PermiteConfigurarPeligro()) Then
            'SE ENVIA A GUARDAR INFORMACION DE PELIGRO
            Me.GuardarConfiguracionPeligro()

            If (Me.varBoolGuardoConfPeligro) Then
                Me.SuccessLog("Se guardó correctamente.")
            End If
        End If
    End Sub
#End Region
#Region "PRIVADO"
    Private Function PermiteConfigurarPeligro() As Boolean
        Dim objMsjRtnVaida As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        'PROCESO
        If Not (Me.ctrProceso1.SeleccionoProceso()) Then
            objMsjRtnVaida.AgregarMensaje("Seleccionar al menos un proceso.")
        End If

        'LUGAR
        If Not (Me.ctrLugar1.SeleccionoLugar()) Then
            objMsjRtnVaida.AgregarMensaje("Seleccionar al menos un lugar.")
        End If

        'RUTINARIA
        If (Me.ddlRutinaria.SelectedValue = 0) Then
            objMsjRtnVaida.AgregarMensaje("Rutinaria.")
        End If

        If Not (objMsjRtnVaida.pBoolRtn) Then
            Me.AlertDialog(objMsjRtnVaida.GetMensajeValidacionCamposFaltantes())
        End If

        Return objMsjRtnVaida.pBoolRtn
    End Function
    Private Sub ActMarcacionRutinarita(ByVal parAudIdRelUsuXEmp As Integer, ByVal parObjTrans As System.Data.Common.DbTransaction)
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro

        objPeligro.sgplIdPeligro = Me.pIdPeligro
        objPeligro.sgplEstRutinario = IIf(Me.ddlRutinaria.SelectedValue = 1, 1, 0)

        'SE ACUALIZA LA MARCACION DE RUTINARIA
        objPeligro.ActInfoEstRutinarioXPeligro(parAudIdRelUsuXEmp, parObjTrans)
    End Sub
    Private Sub GuardarConfiguracionPeligro()
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion
        Try
            objTrans.trCrearTransaccion()

            'SE ACTUALIZA LA MARCACION DE RUTINARIA
            Me.ActMarcacionRutinarita(Me.pIdRelUsuXEmp, objTrans.trTransaccion)

            'SE ENVIA A GUARDAR INFORMACION DE LUGAR
            Me.ctrLugar1.GuardarInfo(objTrans.trTransaccion)

            'SE ENVIA A GUARDAR INFORMACION DE PROCESOS
            Me.ctrProceso1.GuardarInfo(objTrans.trTransaccion)

            Me.varBoolGuardoConfPeligro = True
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            Me.varBoolGuardoConfPeligro = False
            objTrans.trRollBackTransaccion()
            Me.FailureLog("Error al guardar configuración del peligro " & ex.Message)
        End Try
    End Sub
    Private Sub CargarInfoPeligro()
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro
        Dim dtDatosPeligro As New Data.DataTable
        Dim varEstRutinaria As EnmRutinaria

        'SE CARGA LA INFORMACION DEL PELIGRO
        dtDatosPeligro = objPeligro.CargarInfoPeligroXIdPeligro(Me.pIdPeligro)

        If (dtDatosPeligro.Rows.Count > 0) Then
            Me.lblActividad.Text = dtDatosPeligro.Rows(0)("StrActividad")
            Me.txtDescripcion.Text = dtDatosPeligro.Rows(0)("StrDescripcion")
            Me.lblClasificacion.Text = dtDatosPeligro.Rows(0)("StrClasificacion")
            Me.lblRiesgo.Text = dtDatosPeligro.Rows(0)("StrRiesgo")

            varEstRutinaria = IIf(dtDatosPeligro.Rows(0)("sgplEstRutinario") = 1, EnmRutinaria.Si, EnmRutinaria.No)
            If Not (Me.ddlRutinaria.Items.FindByValue(varEstRutinaria) Is Nothing) Then
                Me.ddlRutinaria.SelectedValue = varEstRutinaria
            Else
                Me.ddlRutinaria.SelectedValue = 0
            End If
        End If
    End Sub
#End Region
#Region "DATA SOURCE GRILLA CARGOS"
    Public Sub CargarGrillaCargos()
        Me.gvCargos.DataBind()

        If (Me.gvCargos.Rows.Count > 0) Then
            Me.pnlCargos.Visible = True
        Else
            Me.pnlCargos.Visible = False
        End If
    End Sub
    Protected Sub odsFestivos_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsCargos.Selecting
        e.InputParameters("parIdPeligro") = Me.pIdPeligro
        e.InputParameters("parIdEstado") = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo
    End Sub
    Protected Sub odsCargos_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles odsCargos.Selected
        Me.gvCargos.Visible = True
    End Sub
    Protected Sub odsCargos_ObjectCreating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceEventArgs) Handles odsCargos.ObjectCreating
        e.ObjectInstance = New dllSoftSGSST.SGSST.clSgsstCargo
    End Sub
#End Region
End Class