Public Class ctrMtRsCriControles
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
                'SE CARGA LA INFORMACION DE CRITERIOS CONTROLES
                Me.CargarInfoCriteriosCtr()
            End If
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub ibtnGuardarInfo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardarInfo.Click
        If (Me.PermiteGuardar()) Then
            'SE ENVIA A GUARDAR
            Me.GuardarCriteriosCtr()

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

        'VALIDA NUMERO DE EXPUESTOS
        If (Trim(Me.txtNumExpuestos.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Número de Expuestos.")
        End If

        'VALIDA PEOR CONSECUENCIA
        If (Trim(Me.txtPeorConsec.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Peor Consecuencia.")
        End If

        'VALIDA ESTADO REQUISITO LEGAL
        If (Me.ddlEstReqLegal.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Existe Requisito Legal Específico Asociado.")
        End If

        If Not (objMsjRtnValida.pBoolRtn) Then
            Me.AlertDialog(objMsjRtnValida.GetMensajeValidacionCamposFaltantes())
        End If

        Return objMsjRtnValida.pBoolRtn
    End Function
    Private Sub GuardarCriteriosCtr()
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion
        Try
            objTrans.trCrearTransaccion()

            objPeligro.sgplIdPeligro = Me.pIdPeligro
            objPeligro.sgplCriCtrNumExpuestos = Trim(Me.txtNumExpuestos.Text)
            objPeligro.sgplCriCtrPeorConsec = Trim(Me.txtPeorConsec.Text)
            objPeligro.sgplCriCtrEstExisteRQLegal = IIf(Me.ddlEstReqLegal.SelectedValue = 1, 1, 0)


            objPeligro.ActInfoCriteriosCtrXPeligro(Me.pIdRelUsuXEmp, objTrans.trTransaccion)

            Me.varBoolGuardo = True
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            Me.varBoolGuardo = False
            objTrans.trRollBackTransaccion()
            Me.FailureLog("Error al intentar guardar información Criterios Controles: " & ex.Message)
        End Try
    End Sub
    Private Sub CargarInfoCriteriosCtr()
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro
        Dim dtDatos As New Data.DataTable
        Dim tpEstReqLegal As Integer = 0

        'SE CARGA LA INFORMACION DE PELIGRO
        dtDatos = objPeligro.CargarInfoPeligroXIdPeligro(Me.pIdPeligro)

        If (dtDatos.Rows.Count > 0) Then
            Me.txtNumExpuestos.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplCriCtrNumExpuestos")), "", dtDatos.Rows(0)("sgplCriCtrNumExpuestos"))
            Me.txtPeorConsec.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplCriCtrPeorConsec")), "", dtDatos.Rows(0)("sgplCriCtrPeorConsec"))


            If Not (IsDBNull(dtDatos.Rows(0)("sgplCriCtrEstExisteRQLegal"))) Then
                tpEstReqLegal = IIf(dtDatos.Rows(0)("sgplCriCtrEstExisteRQLegal") = 1, 1, 2)

                If Not (Me.ddlEstReqLegal.Items.FindByValue(tpEstReqLegal) Is Nothing) Then
                    Me.ddlEstReqLegal.SelectedValue = tpEstReqLegal
                Else
                    Me.ddlEstReqLegal.SelectedValue = 0
                End If
            End If
        Else
            Me.ddlEstReqLegal.SelectedValue = 0
        End If
    End Sub
#End Region
#Region "PUBLICO"
    Public Sub LimpiarCtr()
        Me.txtNumExpuestos.Text = ""
        Me.txtPeorConsec.Text = ""

        If (Me.ddlEstReqLegal.Items.Count > 0) Then
            Me.ddlEstReqLegal.SelectedValue = 0
        End If
    End Sub
#End Region
End Class