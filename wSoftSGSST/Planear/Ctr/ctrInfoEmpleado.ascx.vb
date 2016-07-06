Public Class ctrInfoEmpleado
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
    '===================================VARIABLES=================================
    Dim varBoolGuardoEmpleado As Boolean = False
    '=============================================================================
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
        EditarEmpleado = 2
        CargarEmpleado = 3
    End Enum
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DEL COTNROL
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'PANELES================
                    Me.pnlInfoBasicaEmpleado.Visible = IIf(Me.pIdEmpleado <> 0, True, False)
                    Me.pnlInfoUsuario.Visible = True
                    Me.pnlInfoUsuario.Enabled = True
                    Me.pnlInfoUsuarioCreaMod.Visible = True
                    '=======================
                    'BOTONES================
                    Me.ibtnEditarInfo.Visible = False
                    Me.ibtnGuardarInfo.Visible = True

                    Me.ibtnInfoLaboral.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnInfoLaboralGris.png", "~/Images/OpcPagina/ibtnInfoLaboralAzul.png")
                    Me.ibtnAccidentesEnf.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnAccLaboralesGris.png", "~/Images/OpcPagina/ibtnAccLaboralesAzul.png")
                    Me.ibtnConceptosMed.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnConceptoMedicoGris.png", "~/Images/OpcPagina/ibtnConceptoMedicoAzul.png")
                    Me.ibtnRiesgosCargo.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnRiesgosCargoGris.png", "~/Images/OpcPagina/ibtnRiesgosCargoAzul.png")
                    Me.ibtnResponSGSST.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnRespSGSSTGris.png", "~/Images/OpcPagina/ibtnRespSGSSTAzul.png")
                    '=======================

                    'SE INICIALIZA CONTROL DE PAIS_CIUDAD
                    Me.ctrPaisCiudadDep1.pBoolIniCtr = True

                    'SE INICIALIZA CONROL DE CARGO
                    Me.ctrCargosEmpleado1.pIdEmpleado = Me.pIdEmpleado
                    Me.ctrCargosEmpleado1.pBoolIniCtr = True

                    'SE CARGA EL TIPO_DOCUMENTO
                    Me.CargarTipoDocumento(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

                    'SE CARGA EL GENERO
                    Me.CargarGenero(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

                    'SE CARGA LA EDUCACION
                    Me.CargarEducacion(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

                    'SE CARGA LA PROFESION
                    Me.CargarProfesion(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

                    'SE CARGA EL ESTADO_CIVIL
                    Me.CargarEstadoCivil(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

                    'SE CARGA EL TIPO_CONTRATO
                    Me.CargarTipoContrato(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

                Case EnmAccion.CargarEmpleado
                    'PANELES================
                    Me.pnlInfoBasicaEmpleado.Visible = IIf(Me.pIdEmpleado <> 0, True, False)
                    Me.pnlInfoUsuarioCreaMod.Visible = False

                    Me.pnlInfoUsuarioCreaMod.Enabled = False
                    Me.pnlInfoUsuario.Visible = True
                    Me.pnlInfoUsuario.Enabled = False
                    '=======================

                    'LISTAS DESPLEGABLES====
                    'Me.ddlTipDoc.Enabled = False
                    'Me.ddlGenero.Enabled = False
                    'Me.ddlEducacion.Enabled = False
                    'Me.ddlProfesion.Enabled = False
                    'Me.ddlEstCivil.Enabled = False
                    'Me.ddlTipoContrato.Enabled = False
                    ''=======================
                    ''FECHAS=================
                    'Me.ctrFechaIngreso.pBooSoloLectura = True
                    'Me.ctrFechaNacimiento.pBooSoloLectura = True
                    ''=======================
                    ''CAJAS DE TEXTO=========
                    'Me.txtNombres.Enabled = False
                    'Me.txtApellidos.Enabled = False
                    'Me.txtNumDoc.Enabled = False
                    '=======================
                    'BOTONES================
                    Me.ibtnEditarInfo.Visible = True
                    Me.ibtnGuardarInfo.Visible = False

                    Me.ibtnInfoLaboral.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnInfoLaboralGris.png", "~/Images/OpcPagina/ibtnInfoLaboralAzul.png")
                    Me.ibtnAccidentesEnf.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnAccLaboralesGris.png", "~/Images/OpcPagina/ibtnAccLaboralesAzul.png")
                    Me.ibtnConceptosMed.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnConceptoMedicoGris.png", "~/Images/OpcPagina/ibtnConceptoMedicoAzul.png")
                    Me.ibtnRiesgosCargo.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnRiesgosCargoGris.png", "~/Images/OpcPagina/ibtnRiesgosCargoAzul.png")
                    Me.ibtnResponSGSST.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnRespSGSSTGris.png", "~/Images/OpcPagina/ibtnRespSGSSTAzul.png")
                    '=======================

                Case EnmAccion.EditarEmpleado
                    'PANELES================
                    Me.pnlInfoBasicaEmpleado.Visible = False
                    Me.pnlInfoUsuarioCreaMod.Visible = True
                    Me.pnlInfoUsuarioCreaMod.Enabled = True
                    Me.pnlInfoUsuario.Visible = True
                    Me.pnlInfoUsuario.Enabled = True
                    '=======================
                    'BOTONES================
                    Me.ibtnEditarInfo.Visible = False
                    Me.ibtnGuardarInfo.Visible = True

                    Me.ibtnInfoLaboral.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnInfoLaboralGris.png", "~/Images/OpcPagina/ibtnInfoLaboralAzul.png")
                    Me.ibtnAccidentesEnf.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnAccLaboralesGris.png", "~/Images/OpcPagina/ibtnAccLaboralesAzul.png")
                    Me.ibtnConceptosMed.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnConceptoMedicoGris.png", "~/Images/OpcPagina/ibtnConceptoMedicoAzul.png")
                    Me.ibtnRiesgosCargo.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnRiesgosCargoGris.png", "~/Images/OpcPagina/ibtnRiesgosCargoAzul.png")
                    Me.ibtnResponSGSST.ImageUrl = IIf(Me.pIdEmpleado = 0, "~/Images/OpcPagina/ibtnRespSGSSTGris.png", "~/Images/OpcPagina/ibtnRespSGSSTAzul.png")
                    '=======================
            End Select
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
    Protected Sub ibtnGuardarInfo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardarInfo.Click
        If (Me.PermiteGuardarEmpleado()) Then
            'SE ENVIA A GUARDAR EMPLEADO
            Me.GuardarEmpleado()

            If (Me.pIdEmpleado <> 0 AndAlso Me.varBoolGuardoEmpleado) Then
                Me.SuccessLog("Empleado guardado correctamente")
            End If
        End If
    End Sub
    Protected Sub ibtnInfoLaboral_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnInfoLaboral.Click
        Me.AlertDialog("Funcionalidad en desarrollo. No se encuentra aún disponible.")
    End Sub
    Protected Sub ibtnAccidentesEnf_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAccidentesEnf.Click
        Me.AlertDialog("Funcionalidad en desarrollo. No se encuentra aún disponible.")
    End Sub
    Protected Sub ibtnConceptosMed_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnConceptosMed.Click
        Me.AlertDialog("Funcionalidad en desarrollo. No se encuentra aún disponible.")
    End Sub
    Protected Sub ibtnRiesgosCargo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnRiesgosCargo.Click
        Me.AlertDialog("Funcionalidad en desarrollo. No se encuentra aún disponible.")
    End Sub
    Protected Sub ibtnResponSGSST_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnResponSGSST.Click
        Me.AlertDialog("Funcionalidad en desarrollo. No se encuentra aún disponible.")
    End Sub
    Protected Sub ibtnEditarInfo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnEditarInfo.Click
        'MODIFICACION VISUALIZACION
        Me.pVisualizaXAccion = EnmAccion.EditarEmpleado
    End Sub
#End Region
#Region "PRIVADO"
    Private Sub CargarGenero(ByVal parIdEstado As Integer)
        Dim objGenero As New dllSoftSGSST.SGSST.clSgsstGenero

        Me.CargarListaDesplegable(Me.ddlGenero, objGenero.GetTblInfoGeneroXIdEst(Me.pIdEmpresa, parIdEstado), "sggeIdGenero", "sggeNombre")
    End Sub
    Private Sub CargarEducacion(ByVal parIdEstado As Integer)
        Dim objEducacion As New dllSoftSGSST.SGSST.clSgsstEducacion

        Me.CargarListaDesplegable(Me.ddlEducacion, objEducacion.GetTblInfoEducacionXEst(Me.pIdEmpresa, parIdEstado), "sgedIdEducacion", "sgedNombre")
    End Sub
    Private Sub CargarProfesion(ByVal parIdEstado As Integer)
        Dim objProfesion As New dllSoftSGSST.SGSST.clSgsstProfesion

        Me.CargarListaDesplegable(Me.ddlProfesion, objProfesion.GetTblInfoProfesionXIdEst(Me.pIdEmpresa, parIdEstado), "sgprIdProfesion", "sgprNombre")
    End Sub
    Private Sub CargarEstadoCivil(ByVal parIdEstado As Integer)
        Dim objEstCivil As New dllSoftSGSST.SGSST.clSgsstEstadoCivil

        Me.CargarListaDesplegable(Me.ddlEstCivil, objEstCivil.GetTblInfoEstCivilXIdEst(Me.pIdEmpresa, parIdEstado), "sgecIdEstadoCivil", "sgecNombre")
    End Sub
    Private Sub CargarTipoContrato(ByVal parIdEstado As Integer)
        Dim objTipoContrato As New dllSoftSGSST.SGSST.clSgsstTipoContrato

        Me.CargarListaDesplegable(Me.ddlTipoContrato, objTipoContrato.GetTblInfoTipoContratoXIdEst(Me.pIdEmpresa, parIdEstado), "sgtcIdTipoContrato", "sgtcNombre")
    End Sub
    Private Sub CargarTipoDocumento(ByVal parIdEstado As Integer)
        Dim objTipoDocumento As New dllSoftSGSST.SGSST.clSgsstTipoDocumento

        Me.CargarListaDesplegable(Me.ddlTipDoc, objTipoDocumento.GetTblInfoTipoDocumentoXEst(Me.pIdEmpresa, parIdEstado), "sgtdIdTipoDocumento", "sgtdNombre")
    End Sub
    Private Function PermiteGuardarEmpleado() As Boolean
        Dim objEmpleado As New dllSoftSGSST.SGSST.clSgsstEmpleado
        Dim objMsjRtnValida As New dllSoftSGSST.Estructura.EstructuraMsjValidacion
        Dim dtDatos As New Data.DataTable

        If (Me.ddlTipDoc.SelectedValue <> 0 AndAlso Trim(Me.txtNumDoc.Text).Length > 0) Then
            dtDatos = objEmpleado.CargarInfoEmpleadoXTipDocNumDoc(Me.ddlTipDoc.SelectedValue, Trim(Me.txtNumDoc.Text))

            If (dtDatos.Rows.Count > 0 AndAlso dtDatos.Rows(0)("sgemIdEmpleado") <> Me.pIdEmpleado) Then
                objMsjRtnValida.AgregarMensaje(String.Format("El empleado ya se encuentra creado con el nombre {0}. Por favor modifique los datos.", dtDatos.Rows(0)("sgemNomCompleto")))

                Me.AlertDialog(objMsjRtnValida.pStrMensaje)

                Return objMsjRtnValida.pBoolRtn
            End If
        End If

        'VALIDA NOMBRES
        If (Trim(Me.txtNombres.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Nombres Empleados", True)
        End If

        'VALIDA APELLIDOS
        If (Trim(Me.txtApellidos.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Apellidos Empleados", True)
        End If

        'VALIDA TIPO_DOCUMENTO
        If (Me.ddlTipDoc.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Tipo Documento", True)
        End If

        'VALIDA NUMERO_DOCUMENTO
        If (Trim(Me.txtNumDoc.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Número Documento", True)
        End If

        'VALIDA GENERO
        If (Me.ddlGenero.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Género", True)
        End If

        'VALIDA FECHA_NACIMIENTO
        If (Me.ctrFechaNacimiento.pBooEsFecha = False) Then
            objMsjRtnValida.AgregarMensaje("Fecha Nacimiento", True)
        End If

        'VALIDA PAIS
        If (Me.ctrPaisCiudadDep1.pIdPais = 0) Then
            objMsjRtnValida.AgregarMensaje("País", True)
        End If

        'VALIDA CIUDAD
        If (Me.ctrPaisCiudadDep1.pIdCiudad = 0) Then
            objMsjRtnValida.AgregarMensaje("Ciudad", True)
        End If

        'VALIDA EDUCACION
        If (Me.ddlEducacion.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Educación", True)
        End If

        'VALIDA PROFESION
        If (Me.ddlProfesion.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Profesión", True)
        End If

        'VALIDA ESTADO_CIVIL
        If (Me.ddlEstCivil.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Estado Civil", True)
        End If

        'VALIDA CARGO
        If (Me.ctrCargosEmpleado1.pIdCargo = 0) Then
            objMsjRtnValida.AgregarMensaje("Cargo", True)
        End If

        'VALIDA TIPO_CONTRATO
        If (Me.ddlTipoContrato.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Tipo Contrato", True)
        End If

        'VALIDA FECHA_INGRESO
        If (Me.ctrFechaIngreso.pBooEsFecha = False) Then
            objMsjRtnValida.AgregarMensaje("Fecha Ingreso", True)
        End If

        If Not (objMsjRtnValida.pBoolRtn) Then
            Me.AlertDialog(objMsjRtnValida.GetMensaje(dllSoftSGSST.Estructura.EstructuraMsjValidacion.EnmTipoMensaje.Advertencia, objMsjRtnValida.GetMensajeValidacion()))
        End If

        Return objMsjRtnValida.pBoolRtn
    End Function
    Private Sub GuardarEmpleado()
        Dim objEmpleado As New dllSoftSGSST.SGSST.clSgsstEmpleado
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion

        Try
            objTrans.trCrearTransaccion()

            objEmpleado.sgemIdEmpleado = Me.pIdEmpleado
            objEmpleado.sgemIdEmpresa = Me.pIdEmpresa
            objEmpleado.sgemNombres = Trim(Me.txtNombres.Text)
            objEmpleado.sgemApellidos = Trim(Me.txtApellidos.Text)
            objEmpleado.sgemIdTipDoc = Me.ddlTipDoc.SelectedValue
            objEmpleado.sgemNroDoc = Trim(Me.txtNumDoc.Text)
            objEmpleado.sgemIdGenero = Me.ddlGenero.SelectedValue
            objEmpleado.sgemFchNacimiento = Me.ctrFechaNacimiento.pFecha
            objEmpleado.sgemIdPais = Me.ctrPaisCiudadDep1.pIdPais
            objEmpleado.sgemIdCiudad = Me.ctrPaisCiudadDep1.pIdCiudad
            objEmpleado.sgemIdEducacion = Me.ddlEducacion.SelectedValue
            objEmpleado.sgemIdProfesion = Me.ddlProfesion.SelectedValue
            objEmpleado.sgemIdEstadoCivil = Me.ddlEstCivil.SelectedValue
            objEmpleado.sgemIdCargo = Me.ctrCargosEmpleado1.pIdCargo
            objEmpleado.sgemIdTipoContrato = Me.ddlTipoContrato.SelectedValue
            objEmpleado.sgemFchIngreso = Me.ctrFechaIngreso.pFecha
            objEmpleado.sgemIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo
            If (fuImagenEmp.HasFile) Then
                objEmpleado.sgemImagen = fuImagenEmp.FileBytes()
            End If


            objEmpleado.GuardarInfoEmpleado(Me.pIdRelUsuXEmp, objTrans.trTransaccion)

            Me.pIdEmpleado = objEmpleado.sgemIdEmpleado
            Me.varBoolGuardoEmpleado = True
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            Me.varBoolGuardoEmpleado = False
            objTrans.trRollBackTransaccion()

            Me.FailureLog("Error al intentar guardar información empleado: " & ex.Message)
        End Try
    End Sub
#End Region
#Region "PUBLICO"
    Public Sub CargarEmpleado()
        Dim objEmpleado As New dllSoftSGSST.SGSST.clSgsstEmpleado
        Dim dtDatos As New Data.DataTable

        'MOIFICACION VISUALIZACION
        Me.pVisualizaXAccion = EnmAccion.CargarEmpleado


        'SE CARGA LA INFORMACION DEL EMPELADO
        dtDatos = objEmpleado.CargarInfoEmpleadoXIdEmpleado(Me.pIdEmpleado)

        If (dtDatos.Rows.Count > 0) Then

            'CABEZOTE DE INFORMACION EMPLEADO
            Me.lblNombreEmpleado.Text = dtDatos.Rows(0)("sgemNomCompleto")
            Me.lblAnios.Text = ""
            Me.lblTipDocNumDoc.Text = dtDatos.Rows(0)("StrTipoDoc") & " " & dtDatos.Rows(0)("sgemNroDoc")
            Me.lblCargo.Text = dtDatos.Rows(0)("StrCargo")

            'INFORMACION DE EDICION
            Me.txtNombres.Text = dtDatos.Rows(0)("sgemNombres")
            Me.txtApellidos.Text = dtDatos.Rows(0)("sgemApellidos")
            Me.txtNumDoc.Text = dtDatos.Rows(0)("sgemNroDoc")
            Me.ctrFechaIngreso.pFecha = dtDatos.Rows(0)("sgemFchIngreso")
            Me.ctrFechaNacimiento.pFecha = dtDatos.Rows(0)("sgemFchNacimiento")

            'SE CARGA EL CARGO
            Me.ctrCargosEmpleado1.pIdCargo = dtDatos.Rows(0)("sgemIdCargo")
            Me.ctrCargosEmpleado1.pIdEmpleado = Me.pIdEmpleado
            Me.ctrCargosEmpleado1.CargarInfoCargoXID()

            'SE CARGA EL PAIS/CIUDAD
            Me.ctrPaisCiudadDep1.CargarPaisCiudad(dtDatos.Rows(0)("sgemIdPais"), dtDatos.Rows(0)("sgemIdCiudad"))

            'SE VAIDA SI TIENE IMAGEN RELACIONADA
            If Not (IsDBNull(dtDatos.Rows(0)("sgemImagen"))) Then
                Me.imEmpleado.ImageUrl = New System.Uri(Context.Request.Url, ResolveUrl("~/images/FrmGetImagenEmpleado.aspx?PIE=" & Me.pIdEmpleado)).ToString
            End If

            If Not (Me.ddlTipDoc.Items.FindByValue(dtDatos.Rows(0)("sgemIdTipDoc")) Is Nothing) Then
                    Me.ddlTipDoc.SelectedValue = dtDatos.Rows(0)("sgemIdTipDoc")
                Else
                    Me.ddlTipDoc.SelectedValue = 0
                End If

                If Not (Me.ddlGenero.Items.FindByValue(dtDatos.Rows(0)("sgemIdGenero")) Is Nothing) Then
                    Me.ddlGenero.SelectedValue = dtDatos.Rows(0)("sgemIdGenero")
                Else
                    Me.ddlGenero.SelectedValue = 0
                End If

                If Not (Me.ddlEducacion.Items.FindByValue(dtDatos.Rows(0)("sgemIdEducacion")) Is Nothing) Then
                    Me.ddlEducacion.SelectedValue = dtDatos.Rows(0)("sgemIdEducacion")
                Else
                    Me.ddlEducacion.SelectedValue = 0
                End If

                If Not (Me.ddlProfesion.Items.FindByValue(dtDatos.Rows(0)("sgemIdProfesion")) Is Nothing) Then
                    Me.ddlProfesion.SelectedValue = dtDatos.Rows(0)("sgemIdProfesion")
                Else
                    Me.ddlProfesion.SelectedValue = 0
                End If

                If Not (Me.ddlEstCivil.Items.FindByValue(dtDatos.Rows(0)("sgemIdEstadoCivil")) Is Nothing) Then
                    Me.ddlEstCivil.SelectedValue = dtDatos.Rows(0)("sgemIdEstadoCivil")
                Else
                    Me.ddlEstCivil.SelectedValue = 0
                End If

                If Not (Me.ddlTipoContrato.Items.FindByValue(dtDatos.Rows(0)("sgemIdTipoContrato")) Is Nothing) Then
                    Me.ddlTipoContrato.SelectedValue = dtDatos.Rows(0)("sgemIdTipoContrato")
                Else
                    Me.ddlTipoContrato.SelectedValue = 0
                End If
            End If
    End Sub
#End Region
End Class