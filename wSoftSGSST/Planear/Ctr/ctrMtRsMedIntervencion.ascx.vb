Public Class ctrMtRsMedIntervencion
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
    '====================================VARIABLES=======================================
    Dim varBoolGuardo As Boolean = False
    '====================================================================================
    '====================================EVENTOS=========================================
    Public Event evtGuardo()
    '====================================================================================
#Region "PROPIEDADES"
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    Public WriteOnly Property pBoolIniCtr As Boolean
        Set(value As Boolean)
            If value Then
                'INICIALIZA LA VISUALIZACION
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
                    'BOTONES================
                    Me.ibtnGuardarInfo.Visible = True
                    '=======================
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

            If value <> 0 Then
                'SE CARGA LA INFORMACION DE MEDIDAS INTERVENCION
                Me.CargarInfoMedidasIntervencion()
            End If
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub ibtnGuardarInfo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardarInfo.Click
        If (Me.PermiteGuardar()) Then
            'SE ENVIA A GUARDAR
            Me.GuardarMedidasIntervencion()

            If (Me.varBoolGuardo) Then
                Me.SuccessLog("Se guardó correctamente.")

                'SE LIMPIA EL CONTROL
                Me.LimpiarCtr()

                RaiseEvent evtGuardo()
            End If
        End If
    End Sub
#End Region
#Region "PRIVADO"
    Private Function PermiteGuardar() As Boolean
        Dim objMsjRtnValida As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        'VALIDA ELIMINACION
        If (Trim(Me.txtEliminacion.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Eliminación.")
        End If

        'VALIDA SUSTITUCION
        If (Trim(Me.txtSustitucion.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Sustitución.")
        End If

        'VALIDA CONTROL INGENIERIA
        If (Trim(Me.txtCtrIngenieria.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Controles de Ingeniería.")
        End If

        'VALIDA CONTROL ADMINISTRATIVOS
        If (Trim(Me.txtCtrAdmin.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Controles Administrativos.")
        End If

        'VALIDA CONTROL EEPP
        If (Trim(Me.txtEEPP.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Elementos / Equipos de Protección Personal.")
        End If

        If Not (objMsjRtnValida.pBoolRtn) Then
            Me.AlertDialog(objMsjRtnValida.GetMensajeValidacionCamposFaltantes())
        End If

        Return objMsjRtnValida.pBoolRtn
    End Function
    Private Sub GuardarMedidasIntervencion()
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion
        Try
            objTrans.trCrearTransaccion()

            objPeligro.sgplIdPeligro = Me.pIdPeligro
            objPeligro.sgplIntEliminacion = Trim(Me.txtEliminacion.Text)
            objPeligro.sgplIntSustitucion = Trim(Me.txtSustitucion.Text)
            objPeligro.sgplIntCtrIngenieria = Trim(Me.txtCtrIngenieria.Text)
            objPeligro.sgplIntCtrAdmin = Trim(Me.lblCtrAdmin.Text)
            objPeligro.sgplIntEEPP = Trim(Me.txtEEPP.Text)


            objPeligro.ActInfoMedIntervecionXPeligro(Me.pIdRelUsuXEmp, objTrans.trTransaccion)

            Me.varBoolGuardo = True
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            Me.varBoolGuardo = False
            objTrans.trRollBackTransaccion()
            Me.FailureLog("Error al intentar guardar información Medidas Intervención: " & ex.Message)
        End Try
    End Sub
    Private Sub CargarInfoMedidasIntervencion()
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro
        Dim dtDatos As New Data.DataTable

        'SE CARGA LA INFORMACION DE PELIGRO
        dtDatos = objPeligro.CargarInfoPeligroXIdPeligro(Me.pIdPeligro)

        If (dtDatos.Rows.Count > 0) Then
            Me.txtEliminacion.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplIntEliminacion")), "", dtDatos.Rows(0)("sgplIntEliminacion"))
            Me.txtSustitucion.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplIntSustitucion")), "", dtDatos.Rows(0)("sgplIntSustitucion"))
            Me.txtCtrIngenieria.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplIntCtrIngenieria")), "", dtDatos.Rows(0)("sgplIntCtrIngenieria"))
            Me.txtCtrAdmin.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplIntCtrAdmin")), "", dtDatos.Rows(0)("sgplIntCtrAdmin"))
            Me.txtEEPP.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplIntEEPP")), "", dtDatos.Rows(0)("sgplIntEEPP"))
        End If
    End Sub
#End Region
#Region "PUBLICO"
    Public Sub LimpiarCtr()
        Me.txtEliminacion.Text = ""
        Me.txtSustitucion.Text = ""
        Me.txtCtrIngenieria.Text = ""
        Me.txtCtrAdmin.Text = ""
        Me.txtEEPP.Text = ""
    End Sub
#End Region
End Class