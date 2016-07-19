Public Class ctrMtRsControlesExistentes
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
                'SE CARGA LA INFORMACION DE CONTROLES EXISTENTES
                Me.CargarInfoCtrExistentes()
            End If
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub ibtnGuardarInfo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardarInfo.Click
        If (Me.PermiteGuardar()) Then
            'SE ENVIA A GUARDAR
            Me.GuardarControlesExistentes()

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

        'VALIDA CONTROL EN LA FUENTE
        If (Trim(Me.txtCtrFuente.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Control en la Fuente.")
        End If

        'VALIDA CONTROL EN EL MEDIO
        If (Trim(Me.txtCtrMedio.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Control en el Medio.")
        End If

        'VALIDA CONTROL EN EL INDIVIDUO
        If (Trim(Me.txtCtrIndividuo.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Control en el Individuo.")
        End If

        If Not (objMsjRtnValida.pBoolRtn) Then
            Me.AlertDialog(objMsjRtnValida.GetMensajeValidacionCamposFaltantes())
        End If

        Return objMsjRtnValida.pBoolRtn
    End Function
    Private Sub GuardarControlesExistentes()
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion
        Try
            objTrans.trCrearTransaccion()

            objPeligro.sgplIdPeligro = Me.pIdPeligro
            objPeligro.sgplCtrExisCtrFuente = Trim(Me.txtCtrFuente.Text)
            objPeligro.sgplCtrExisCtrMedio = Trim(Me.txtCtrMedio.Text)
            objPeligro.sgplCtrExisCtrIndividuo = Trim(Me.txtCtrIndividuo.Text)


            objPeligro.ActInfoCtrExistentesXPeligro(Me.pIdRelUsuXEmp, objTrans.trTransaccion)

            Me.varBoolGuardo = True
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            Me.varBoolGuardo = False
            objTrans.trRollBackTransaccion()
            Me.FailureLog("Error al intentar guardar información Controles Existentes: " & ex.Message)
        End Try
    End Sub
    Private Sub CargarInfoCtrExistentes()
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro
        Dim dtDatos As New Data.DataTable

        'SE CARGA LA INFORMACION DE PELIGRO
        dtDatos = objPeligro.CargarInfoPeligroXIdPeligro(Me.pIdPeligro)

        If (dtDatos.Rows.Count > 0) Then
            Me.txtCtrFuente.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplCtrExisCtrFuente")), "", dtDatos.Rows(0)("sgplCtrExisCtrFuente"))
            Me.txtCtrMedio.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplCtrExisCtrMedio")), "", dtDatos.Rows(0)("sgplCtrExisCtrMedio"))
            Me.txtCtrIndividuo.Text = IIf(IsDBNull(dtDatos.Rows(0)("sgplCtrExisCtrIndividuo")), "", dtDatos.Rows(0)("sgplCtrExisCtrIndividuo"))
        End If
    End Sub
#End Region
#Region "PUBLICO"
    Public Sub LimpiarCtr()
        Me.txtCtrFuente.Text = ""
        Me.txtCtrMedio.Text = ""
        Me.txtCtrIndividuo.Text = ""
    End Sub
#End Region
End Class