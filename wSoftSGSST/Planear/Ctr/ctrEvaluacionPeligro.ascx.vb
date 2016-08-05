Public Class ctrEvaluacionPeligro
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'EVENTOS+
    Public Event evtCerrar()
#Region "PROPIEDADES"
    'ENUMERACION DE ACCIONES
    Public Enum EnmAccion
        Inicio = 1
    End Enum
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    Public WriteOnly Property pBoolIniCtr As Boolean
        Set(value As Boolean)
            Me.pVisualizacionXAccion = EnmAccion.Inicio
        End Set
    End Property
    'PROPIEDAD PARA MANEJAR LA VISUALIZACION DEL CONTROL
    Public WriteOnly Property pVisualizacionXAccion As EnmAccion
        Set(value As EnmAccion)
            'MOSTRAR PANEL
            Me.pnlEvaluacionPeligro.Visible = True

            'INICIALIZAR EL DDL DE NIVEL DEFICIENCIA
            Me.CargarDdlNivelDeficiencia()

            'INICIALIZAR EL DDL DE NIVEL EXPOSICION
            Me.CargarDdlNivelExposicion()

            'INICIALIZAR DDL NIVEL CONSECUENCIA
            Me.CargarDdlNivelConsecuencia()

            'CARGAR INFORMACION PELIGRO X ID PELIGRO
            Me.CargarEvaluacionPeligro()
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL ID PELIGRO
    Public Property pIdPeligro As Integer
        Get
            Return ViewState("pIdPeligro")
        End Get
        Set(value As Integer)
            ViewState("pIdPeligro") = value
        End Set
    End Property
    'PROPIEDAD PAARA DEFINIR EL NIVEL DE DEFICIENCIA
    Public Property pNivelDeficiencia As Integer
        Get
            Return ViewState("pNivelDeficiencia")
        End Get
        Set(value As Integer)
            ViewState("pNivelDeficiencia") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL NIVEL DE EXPOSICION
    Public Property pNivelExposicion As Integer
        Get
            Return ViewState("pNivelExposicion")
        End Get
        Set(value As Integer)
            ViewState("pNivelExposicion") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL ID NIVEL DE PROBABILIDAD
    Public Property pIdNivelProbabilidad As Integer
        Get
            Return ViewState("pIdNivelProbabilidad")
        End Get
        Set(value As Integer)
            ViewState("pIdNivelProbabilidad") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL NIVEL DE PROBABILIDAD
    Public Property pNivelProbabilidad As Integer
        Get
            Return ViewState("pNivelProbabilidad")
        End Get
        Set(value As Integer)
            ViewState("pNivelProbabilidad") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL NIVEL DE CONSECUENCIA
    Public Property pNivelConsecuencia As Integer
        Get
            Return ViewState("pNivelConsecuencia")
        End Get
        Set(value As Integer)
            ViewState("pNivelConsecuencia") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL VALOR DEL NIVEL DE RIESGO
    Public Property pValNivelRiesgo As Integer
        Get
            Return ViewState("pNivelRiesgo")
        End Get
        Set(value As Integer)
            ViewState("pNivelRiesgo") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL NIVEL DE RIESGO
    Public Property pIdNivelRiesgo As Integer
        Get
            Return ViewState("pIdNivelRiesgo")
        End Get
        Set(value As Integer)
            ViewState("pIdNivelRiesgo") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL NIVEL DE ACEPTABILIDAD
    Public Property pIdAceptabilidad As Integer
        Get
            Return ViewState("pIdAceptabilidad")
        End Get
        Set(value As Integer)
            ViewState("pIdAceptabilidad") = value
        End Set
    End Property

#End Region
#Region "PROTEGIDO"
    'EVENTO DEL BOTON CERRAR POPUP
    Protected Sub ibtnCerrar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCerrar.Click
        RaiseEvent evtCerrar()
    End Sub
    'EVENTO DEL DDL NIVEL DE DEFICIENCIA
    Protected Sub ddlNivDef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlNivDef.SelectedIndexChanged
        'CARGAR INFORMACION NIVEL DE DEFICIENCIA
        Me.CargarNivDef(Me.ddlNivDef.SelectedValue)
        'CALCULAR EL NIVEL DE PROBABILIDAD
        Me.CalcularNivelProbabilidad()

        Me.upnlEvaluacionRiesgo.Update()
    End Sub
    'EVENTO DEL DDL NIVEL DE EXPOSICION
    Protected Sub ddlNivExp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlNivExp.SelectedIndexChanged
        'CARGAR NIVEL DE EXPOSICION
        Me.CargarNivExp(Me.ddlNivExp.SelectedValue)

        'CALCULAR EL NIVEL DE PROBABILIDAD
        Me.CalcularNivelProbabilidad()

        Me.upnlEvaluacionRiesgo.Update()
    End Sub
    'EVENTO DE LA LISTA DESPLEGABLE NIVEL DE CONSECUENCIA
    Protected Sub ddlNivCons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlNivCons.SelectedIndexChanged
        'CARGAR EL NIVEL DE CONSECUENCIA
        Me.CargarNivCons(Me.ddlNivCons.SelectedValue)
        'CALCULAR EL NIVEL DE RIESGO
        Me.CalcularNivelRiesgo()

        'CALCULAR ACEPTABILIDAD NIVEL DE RIESGO
        Me.CalcularNivelAceptabilidad()

        Me.upnlEvaluacionRiesgo.Update()

    End Sub
    'EVENTO DEL BOTON GUARDAR EVALUACION
    Protected Sub ibtnGuardarEval_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardarEval.Click
        If (Me.esValidoParaGuardar._varBoolRtn) Then

            Me.GuardarEvaluacionPeligro()

            Me.AlertDialog("Se guardo correctamente.")
        End If

    End Sub
#End Region
#Region "PRIVADO"
    'FUNCION PARA CARGAR EL DDL DE NIVEL DE DEFICIENCIA
    Private Sub CargarDdlNivelDeficiencia()
        Dim objNivDef As New dllSoftSGSST.SGSST.clSgsstNivelDeficiencia
        Dim dtDatos As New DataTable
        dtDatos = objNivDef.GetTblInfoNivelDeficienciaXIdEst(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlNivDef, dtDatos, "sndIdNivelDeficiencia", "sndNombre")
    End Sub
    'FUNCION PARA CARGAR EL DDL DE NIVEL DE EXPOSICION
    Private Sub CargarDdlNivelExposicion()
        Dim objNivExp As New dllSoftSGSST.SGSST.clSgsstNivelExposicion
        Dim dtDatos As New DataTable
        dtDatos = objNivExp.GetTblInfoNivExpXIdEst(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlNivExp, dtDatos, "sneIdNivelExposicion", "sneNombre")
    End Sub
    'CARGAR INFORMACION NIVEL DE DEFICIENCIA
    Private Sub CargarNivDef(ByVal parIdNivDef As Integer)
        'CARGAR INFORMACION DE NIVEL DEFICIENCIA
        Dim objNivDef As New dllSoftSGSST.SGSST.clSgsstNivelDeficiencia
        objNivDef.CargarInfoNivelDeficienciaXId(parIdNivDef)

        If (objNivDef.sndIdNivelDeficiencia <> 0) Then
            Me.pNivelDeficiencia = objNivDef.sndValor
            Me.lblExpNivDef.Text = "Significado Nivel de Deficiencia (" & objNivDef.sndNombre & ") - Valor " & objNivDef.sndValor & ") " & objNivDef.sndSignificado
        Else
            Me.pNivelDeficiencia = 0

            Me.lblExpNivDef.Text = ""
        End If
    End Sub
    'CARGAR NIVEL EXPOSICION
    Private Sub CargarNivExp(ByVal parIdNivExp As Integer)
        'CARGAR INFORMACION DE NIVEL DE EXPOSICION
        Dim objNivExp As New dllSoftSGSST.SGSST.clSgsstNivelExposicion
        objNivExp.CargarInfoNivelExposicionXId(parIdNivExp)

        'DEFINIR EL LABEL DE NIVEL EXPOSICION SEGUN LA SELECCION
        If (objNivExp.sneIdNivelExposicion <> 0) Then
            Me.pNivelExposicion = objNivExp.sneValor
            Me.lblExpNivExp.Text = "Significado Nivel de Exposición (" & objNivExp.sneNombre & ") - Valor " & objNivExp.sneValor & ") " & objNivExp.sneSignificado
        Else
            Me.pNivelExposicion = objNivExp.sneValor
            Me.lblExpNivExp.Text = ""
        End If
    End Sub
    'CARGAR NIVEL DE CONSECUENCIA
    Private Sub CargarNivCons(ByVal parIdNivCons As Integer)
        'CARGAR INFORMACION DE NIVEL DE CONSECUENCIA
        Dim objNivCons As New dllSoftSGSST.SGSST.clSgsstNivelConsecuencia
        objNivCons.CargarinfoNivelConsecuenciaXId(parIdNivCons)

        If (objNivCons.sncIdNivelConsecuencia <> 0) Then

            Me.pNivelConsecuencia = objNivCons.sncValor
            Me.lblExpNivCons.Text = "Significado Nivel de Consecuencia (" & objNivCons.sncNombre & ") - Valor " & objNivCons.sncValor & objNivCons.sncSignificado
        Else
            Me.pNivelConsecuencia = objNivCons.sncIdNivelConsecuencia
            Me.lblExpNivCons.Text = ""
        End If
    End Sub
    'FUNCION PARA CARGAR EL DDL DE NIVEL DE CONSECUENCIA
    Private Sub CargarDdlNivelConsecuencia()
        Dim objNivCons As New dllSoftSGSST.SGSST.clSgsstNivelConsecuencia
        Dim dtDatos As New DataTable
        dtDatos = objNivCons.GetTblInfoNivConsXIdEst(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlNivCons, dtDatos, "sncIdNivelConsecuencia", "sncNombre")
    End Sub
    'FUNCION PARA CALCULAR EL NIVEL DE PROBABILIDAD
    Private Sub CalcularNivelProbabilidad()
        Me.pNivelProbabilidad = Me.pNivelDeficiencia * Me.pNivelExposicion

        'CARGAR NIVEL DE PROBABILIDAD X VALOR
        Dim objNivProb As New dllSoftSGSST.SGSST.clSgsstNivelProbabilidad
        objNivProb.CargarInfoNivProbXValor(Me.pNivelProbabilidad)

        If (objNivProb.sgnIdNivelProbabilidad <> 0) Then
            Me.pIdNivelProbabilidad = objNivProb.sgnIdNivelProbabilidad
            Me.lblValNivProb.Text = Me.pNivelProbabilidad
            Me.lblExpNivProb.Text = "Significado Nivel de Probabilidad (" & objNivProb.sgnNombre & ") - Valor " & objNivProb.sgnValorMax & " y " & objNivProb.sgnValorMin & objNivProb.sgnSignificado

        Else
            Me.pIdNivelProbabilidad = 0
            Me.lblValNivProb.Text = 0
            Me.lblExpNivProb.Text = ""
        End If
    End Sub
    'CALCULAR NIVEL DE RIESGO
    Private Sub CalcularNivelRiesgo()
        Me.pValNivelRiesgo = Me.pNivelProbabilidad * Me.pNivelConsecuencia

        'CARGAR INFORMACION DE NIVEL DE RIESGO X VALOR
        Dim objNivRies As New dllSoftSGSST.SGSST.clSgsstNivelRiesgo
        objNivRies.CargarInfoNivelRiesgoXValor(Me.pValNivelRiesgo)


        If (objNivRies.snrIdNivelRiesgo <> 0) Then
            Me.pIdNivelRiesgo = objNivRies.snrIdNivelRiesgo
            Me.lblValNivRies.Text = Me.pValNivelRiesgo
            Me.lblExpNivRies.Text = "Significado Nivel de Riesgo (" & objNivRies.snrNombre & ") - Valor " & objNivRies.snrValorMax & " - " & objNivRies.snrValorMin & objNivRies.snrSignificado
        Else
            Me.pIdNivelRiesgo = 0
            Me.lblValNivRies.Text = Me.pValNivelRiesgo
            Me.lblExpNivRies.Text = ""
        End If
    End Sub
    'CARLCULAR NIVEL DE ACEPTABILIDAD
    Private Sub CalcularNivelAceptabilidad()
        'CARGAR INFORMACION DE NIVEL DE ACEPTABILIDAD
        Dim objNivAcep As New dllSoftSGSST.SGSST.clSgsstAceptabilidad
        objNivAcep.CargarInfoAceptabilidadXIdRiesgo(Me.pIdNivelRiesgo)

        If (objNivAcep.sgaIdNivelRiesgo <> 0) Then
            Me.pIdAceptabilidad = objNivAcep.sgaIdAceptabilidad
            Me.lblValAcepNiv.Text = objNivAcep.sgaNombre
            Me.lblExpValAcep.Text = "Significado Aceptabilidad Nivel de Riesgo (" & objNivAcep.sgaIdNivelRiesgo & ") - Valor " & objNivAcep.sgaNombre & objNivAcep.sgaSignificado

        Else
            Me.pIdAceptabilidad = 0
            Me.lblValAcepNiv.Text = ""
            Me.lblExpValAcep.Text = ""
        End If
    End Sub
    'FUNCION PARA CALCULAR SI ES VALIDO PARA GUARDAR LA EVALUACION DEL RIESGO
    Private Function esValidoParaGuardar() As dllSoftSGSST.Estructura.EstructuraMsjValidacion
        Dim objMsj As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        If (Me.ddlNivDef.SelectedValue = 0) Then
            objMsj.AgregarMensaje("Debe seleccionar Nivel de Deficiencia.")
            objMsj._varBoolRtn = False
        End If

        If (Me.ddlNivExp.SelectedValue = 0) Then
            objMsj.AgregarMensaje("Debe seleccionar Nivel de Exposición.")
            objMsj._varBoolRtn = False
        End If

        If (Me.ddlNivCons.SelectedValue = 0) Then
            objMsj.AgregarMensaje("Debe seleccionar Nivel de Consecuencia.")
            objMsj._varBoolRtn = False
        End If

        If Not objMsj._varBoolRtn Then
            Me.AlertDialog("Por favor verifique: " & objMsj.GetMensajeValidacion)
        End If

        Return objMsj
    End Function
    'FUNCION PARA GUARDAR EVALUACION DEL PELIGRO
    Private Sub GuardarEvaluacionPeligro()
        Dim objEvalPeligro As New dllSoftSGSST.SGSST.clSgsstEvaluacionPeligro
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion

        Try
            objTrans.trCrearTransaccion()
            objEvalPeligro.sepIdEvaluacionPeligro = 0
            objEvalPeligro.sepIdPeligro = Me.pIdPeligro
            objEvalPeligro.sepIdNivelDeficiencia = Me.ddlNivDef.SelectedValue
            objEvalPeligro.sepIdNivelExposicion = Me.ddlNivExp.SelectedValue
            objEvalPeligro.sepValorNivProbabilidad = Me.pNivelProbabilidad
            objEvalPeligro.sepIdNivelProbabilidad = Me.pIdNivelProbabilidad
            objEvalPeligro.sepIdNivelConsecuencia = Me.ddlNivCons.SelectedValue
            objEvalPeligro.sepIdNivelRiesgo = Me.pIdNivelRiesgo
            objEvalPeligro.sepValorNivRiesgo = Me.pValNivelRiesgo
            objEvalPeligro.sepIdAceptabilidad = Me.pIdAceptabilidad
            objEvalPeligro.sepAudIdUsuEmp = Me.pIdRelUsuXEmp
            objEvalPeligro.sepIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo
            objEvalPeligro.GuardarInfoEvaluacionPeligro(objTrans.trTransaccion)
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            objTrans.trRollBackTransaccion()
            Me.AlertDialog("No se pudo guardar la evaluacion del riesgo. " & ex.Message.ToString)
        End Try
    End Sub
    'FUNCION PARA CARGAR LA EVALUACION DEL PELIGRO X ID PELIGRO
    Private Sub CargarEvaluacionPeligro()
        Dim objEvalPeligro As New dllSoftSGSST.SGSST.clSgsstEvaluacionPeligro
        objEvalPeligro.CargarInfoEvalRiesgo(Me.pIdPeligro)

        If (objEvalPeligro.sepIdEvaluacionPeligro <> 0) Then

            'CARGAR NIVEL DE DEFICIENCIA
            Me.ddlNivDef.SelectedValue = objEvalPeligro.sepIdNivelDeficiencia
            Me.CargarNivDef(objEvalPeligro.sepIdNivelDeficiencia)

            'CARGAR NIVEL EXPOSICION
            Me.ddlNivExp.SelectedValue = objEvalPeligro.sepIdNivelExposicion
            Me.CargarNivExp(objEvalPeligro.sepIdNivelExposicion)

            'CARGAR NIVEL PROBABILIDAD
            Me.CalcularNivelProbabilidad()

            'CARGAR NIVEL CONSECUENCIA
            Me.ddlNivCons.SelectedValue = objEvalPeligro.sepIdNivelConsecuencia
            Me.CargarNivCons(objEvalPeligro.sepIdNivelConsecuencia)

            'CARGAR NIVEL RIESGO
            Me.CalcularNivelRiesgo()

            'CARGAR ACEPTABILIDAD DEL RIESGO
            Me.CalcularNivelAceptabilidad()
        End If
    End Sub
#End Region
End Class