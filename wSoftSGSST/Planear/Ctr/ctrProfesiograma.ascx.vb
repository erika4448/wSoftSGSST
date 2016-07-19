Public Class ctrProfesiograma
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
#Region "PROPIEDADES"
    'ENUMERACION PARA EL MANEJO DE ACCIONES
    Public Enum EnmAccion
        Inicio = 1
        Cargar = 2
        ActividadesPeligros = 3
    End Enum
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    Public WriteOnly Property pBoolIniCtr As Boolean
        Set(value As Boolean)
            Me.pVisualizacionXAccion = EnmAccion.Inicio
        End Set
    End Property
    'PROPIEDAD PARA EL MANEJO DE BISUALIZACION
    Public WriteOnly Property pVisualizacionXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'MOSTRAR PANELES
                    Me.pnlProfesiograma.Visible = True
                    Me.pnlBuscarCargo.Visible = True
                    Me.pnlFormularioCargo.Visible = False
                    Me.pnlActividadesPeligros.Visible = False

                    'INICIALIZAR EL CONTROL DE BUSQUEDA DINAMICO
                    Me.ctrDinaConsObjCargo.pIdConfigCtrBusDina = 1
                    Me.ctrDinaConsObjCargo.pBoolIniCtr = True

                    'OCULTAR BOTON DE VER DETALLES
                    Me.ibntVerDetalle.Visible = True

                    'OCULTAR LOS LBL DE OBLIGATORIO
                    Me.lblNomCargoObliga.Visible = False
                    Me.lblCodCargoObliga.Visible = False
                    Me.lblActividadesObliga.Visible = False

                    'INABILITAR LOS BOTONES COMPLEMENTARIOS
                    Me.pnlRiesgos.Enabled = False
                    Me.pnlRqFisicos.Enabled = False
                    Me.pnlCondicSalud.Enabled = False
                    Me.pnlEpp.Enabled = False
                    Me.pnlResponsabilidad.Enabled = False

                    'FUNCION PARA CARGAR EL DDL EDUCACION
                    Me.CargarDdlEducacion()

                    'FUNCION PARA CARGAR EL DDL PROFESION
                    Me.CargarDdlProfesion()

                    'FUNCION PARA CARGAR EL DDL A QUIEN LE REPORTA
                    Me.CargarDdlAQuienLeReporta()

                    'FUNCION PARA INICIALIZAR EL AUTOCOMPLETE QUIEN LE REPORTA
                    Me.ctrDinaConsObjQuienLeRep.pIdConfigCtrBusDina = 1
                    Me.ctrDinaConsObjQuienLeRep.pBoolIniCtr = True

                    'CARGAR DDL AREA
                    Me.CargarDdlArea()

                    'INCIALIZAR LA TABLA DE QUIEN LE REPORTA
                    Me.pTblQuienReportaCargo = New dllSoftSGSST.SGSST.dtsQuienLeReportaCargo.dtQuienRepCargoDataTable

                Case EnmAccion.Cargar
                    'MOSTRAR PANELES
                    Me.pnlProfesiograma.Visible = True
                    Me.pnlBuscarCargo.Visible = False
                    Me.pnlFormularioCargo.Visible = True
                    Me.pnlActividadesPeligros.Visible = False

                    'OCULTAR BOTON DE VER DETALLES
                    Me.ibntVerDetalle.Visible = False

                    'INABILITAR LOS BOTONES COMPLEMENTARIOS
                    Me.pnlRiesgos.Enabled = True
                    Me.pnlRqFisicos.Enabled = False
                    Me.pnlCondicSalud.Enabled = False
                    Me.pnlEpp.Enabled = False
                    Me.pnlResponsabilidad.Enabled = False

                    'CAMBIAR LA IMAGEN DE LOS BOTONES
                    Me.ibtnRiesgos.ImageUrl = "~/Images/OpcPagina/ibtnRiesgosCargoAzul.png"
                    Me.itbnRqFisicos.ImageUrl = "~/Images/OpcPagina/ibtnReqFisiciosAzul.png"

                Case EnmAccion.ActividadesPeligros
                    'MOSTRAR PANELES
                    Me.pnlProfesiograma.Visible = False
                    Me.pnlBuscarCargo.Visible = False
                    Me.pnlFormularioCargo.Visible = False
                    Me.pnlActividadesPeligros.Visible = True
            End Select
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL ID CARGO
    Public Property pIdCargo As Integer
        Get
            Return ViewState("pIdCargo")
        End Get
        Set(value As Integer)
            ViewState("pIdCargo") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL NOMBRE DEL CARGO
    Public Property pStrNomCargo As String
        Get
            Return ViewState("pStrNomCargo")
        End Get
        Set(value As String)
            ViewState("pStrNomCargo") = value
        End Set
    End Property
    'PROPIEDAD PARA EL ALMACENAMIENTO DE LOS CARGOS QUIEN LE REPORTA
    Public Property pTblQuienReportaCargo As dllSoftSGSST.SGSST.dtsQuienLeReportaCargo.dtQuienRepCargoDataTable
        Get
            Return ViewState("pTblQuienReportaCargo")
        End Get
        Set(value As dllSoftSGSST.SGSST.dtsQuienLeReportaCargo.dtQuienRepCargoDataTable)
            ViewState("pTblQuienReportaCargo") = value
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    'EVENTO DEL BOTON GUARDAR
    Protected Sub ibtnGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardar.Click
        If (esValidoParaguardar._varBoolRtn) Then
            Me.GuardarInfoCargo
        End If
    End Sub
    'EVENTO DEL BOTON AGREGAR CARGO A QUIEN LE REPORTA
    Protected Sub ibtnAgregarQuienLeReporta_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAgregarQuienLeReporta.Click
        If (Me.ctrDinaConsObjQuienLeRep.pIdSel <> 0) Then
            If (Me.ctrDinaConsObjQuienLeRep.pIdSel <> Me.pIdCargo) Then
                Me.AgregarCargoQuienLeReporta()

                Me.ctrDinaConsObjQuienLeRep.LimpiarCtr()
            Else
                Me.AlertDialog("No puede agregar un cargo igual al actual.")
            End If

        Else
                Me.AlertDialog("Debe seleccionar Cargo quien le reporta.")
        End If
    End Sub
    'EVENTO DEL BOTON RIESGOS
    Protected Sub ibtnRiesgos_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnRiesgos.Click
        'CAMBIAR VISUALIZACION
        Me.pVisualizacionXAccion = EnmAccion.ActividadesPeligros

        'INICIALIZAR Y MOSTRAR CONTROL DE ACTIVIDADES Y PELIGROS
        Me.ctrActividadesYPeligros.pIdCargo = Me.pIdCargo
        Me.ctrActividadesYPeligros.pStrNomCargo = Me.pStrNomCargo
        Me.ctrActividadesYPeligros.pBoolIniCtr = True


    End Sub
    'EVENTO DEL BOTON VER DETALLE
    Protected Sub ibntVerDetalle_Click(sender As Object, e As ImageClickEventArgs) Handles ibntVerDetalle.Click
        If (Me.ctrDinaConsObjCargo.pIdSel <> 0) Then
            'DEFINIR LA PROPIEDAD DE ID CARGO
            Me.pIdCargo = Me.ctrDinaConsObjCargo.pIdSel

            'CARGAR EL CONTROL DE PROFESIOGRAMA
            Me.CargarInfoCargoXIdCargo()

            'CARGAR VISUALIZACION
            Me.pVisualizacionXAccion = EnmAccion.Cargar

        Else
            Me.AlertDialog("Debe seleccionar un Cargo.")
        End If
    End Sub
    'EVENTO DEL BOTON NUEVA CONSULTA
    Protected Sub ibtnNuevaConsulta_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnNuevaConsulta.Click
        'LIMPIAR EL CONTROL
        Me.LimpiarBuscador()

        'CARGAR LA VISUALIZACION DE INICIO
        Me.pVisualizacionXAccion = EnmAccion.Inicio
    End Sub
    'EVENTO DEL BOTON NUEVO PROFESIOGRAMA
    Protected Sub ibtnNuevoProfesiograma_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnNuevoProfesiograma.Click
        Me.pVisualizacionXAccion = EnmAccion.Cargar
        Me.LimpiarForm()
    End Sub
    'EVENTO DEL BOTON ELIMINAR DE LA GRILLA
    Protected Sub ibtnEliminar_Click(sender As Object, e As ImageClickEventArgs)
        Dim Index As New Integer
        Index = DirectCast(DirectCast(sender, System.Web.UI.Control).Parent.Parent, System.Web.UI.WebControls.GridViewRow).RowIndex

        Dim tmpIdCabRel As Integer = Me.gvQuienLeReporta.DataKeys(Index).Values("IdCabQuienRepCargo")

        'IACTIVAR LA RELACION
        For Each row As DataRow In Me.pTblQuienReportaCargo.Rows
            If row("IdCabQuienRepCargo") = tmpIdCabRel Then
                If (row("idRelCargoXQuienRepIdCargo") = 0) Then
                    'row("IdEstado") = 2
                    row.Delete()
                    Exit For
                Else
                    row("IdEstado") = 2

                    Me.GuardarInfoCargo()

                    row.Delete()
                    Exit For
                End If
            End If
        Next

        Me.CargarGvQuienLeReporta()
    End Sub
    'EVENTO DEL TXT CODIGO CARGO PARA VALIDAR SI YA EXISTE UN CARGO CON ESE CODIGO
    Protected Sub txtCodCargo_TextChanged(sender As Object, e As EventArgs) Handles txtCodCargo.TextChanged
        Me.ValidarExisteCodigoCargo
    End Sub
#End Region
#Region "PRIVADO"
    'FUNCION PARA CAGAR EL DD EDUCACION
    Private Sub CargarDdlEducacion()
        Dim objEducacion As New dllSoftSGSST.SGSST.clSgsstEducacion
        Dim dtDatos As New DataTable
        dtDatos = objEducacion.GetTblInfoEducacionXEst(1, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlEducacion, dtDatos, "sgedIdEducacion", "sgedNombre")
    End Sub
    'FUNCION PARA CARGAR EL DDL DE PROFESION
    Private Sub CargarDdlProfesion()
        Dim objProfesion As New dllSoftSGSST.SGSST.clSgsstProfesion
        Dim dtDatos As New DataTable
        dtDatos = objProfesion.GetTblInfoProfesionXIdEst(1, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlProfesion, dtDatos, "sgprIdProfesion", "sgprNombre")
    End Sub
    'FUNCION PARA CARGAR EL DDL DE AREA
    Private Sub CargarDdlArea()
        Dim objArea As New dllSoftSGSST.SGSST.clSgsstArea
        Dim dtDatos As New DataTable
        dtDatos = objArea.GetTblAreaXIdEst(1, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlAreaDelCargo, dtDatos, "sgarIdArea", "sgarNombre")
    End Sub
    'FUNCION PARA CARGAR EL DDL A QUIEN LE REPORTA
    Private Sub CargarDdlAQuienLeReporta()
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        Dim dtDatos As New DataTable
        dtDatos = objCargo.GetTblInfoCargoXIdEst(1, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlAQuienReporta, dtDatos, "sgcaIdCargo", "sgcaNombre")
    End Sub
    'FUNCION PARA VALIDAR SI ES VALIDO PARA GUARDAR
    Private Function esValidoParaguardar() As dllSoftSGSST.Estructura.EstructuraMsjValidacion
        Dim objMsj As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        'VALIDAR TXT NOMBRE
        If (Trim(Me.txtNomCargo.Text) = "") Then
            objMsj.AgregarMensaje("Debe digitar Nombre Cargo")
            Me.lblNomCargoObliga.Visible = True
            objMsj._varBoolRtn = False

        Else
            Me.lblNomCargoObliga.Visible = False
        End If

        'VALIDAR TXT CODIGO CARGO
        If (Trim(Me.txtCodCargo.Text) = "") Then
            objMsj.AgregarMensaje("Debe digitar Código Cargo")
            Me.lblCodCargoObliga.Visible = True
            objMsj._varBoolRtn = False

        Else
            Me.lblCodCargoObliga.Visible = False
        End If

        'VALIDAR EXISTENCIA DEL CODIGO
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        objCargo.CargarInfoCargoXStrCodCargo(Me.pIdCargo, Trim(Me.txtCodCargo.Text), dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

        If (objCargo.sgcaIdCargo <> 0) Then
            objMsj.AgregarMensaje("Código ya creado y perteneciente al cargo " & objCargo.sgcaNombre)
            objMsj._varBoolRtn = False
        End If

        'VALIDAR TXT ACTIVIDADES DEL CARGO
        If (Trim(Me.txtActividades.Text) = "") Then
            objMsj.AgregarMensaje("Debe digitar Actividades Cargo")
            Me.lblActividadesObliga.Visible = True
            objMsj._varBoolRtn = False

        Else
            Me.lblActividadesObliga.Visible = False
        End If

        If Not (objMsj._varBoolRtn) Then
            Me.AlertDialog(objMsj.GetMensaje(dllSoftSGSST.Estructura.EstructuraMsjValidacion.EnmTipoMensaje.Advertencia, objMsj.GetMensajeValidacionCamposFaltantes()))
        End If
        Return objMsj
    End Function
    Private Sub AgregarCargoQuienLeReporta()
        Dim row As DataRow = Me.pTblQuienReportaCargo.NewRow
        row("idRelCargoXQuienRepIdCargo") = 0
        row("QuienRepIdCargo") = Me.ctrDinaConsObjQuienLeRep.pIdSel
        row("Nombre") = Me.ctrDinaConsObjQuienLeRep.pStrNomSel
        row("IdEstado") = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo

        Me.pTblQuienReportaCargo.Rows.Add(row)

        Me.CargarGvQuienLeReporta()
    End Sub
    'FUNCION PARA GUARDAR LA INFORMACION DE EMPLEADO
    Private Sub GuardarInfoCargo()
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        Dim objCargoXQuienRep As New dllSoftSGSST.SGSST.clSgsstRelCargoXQuienRepIdCargo
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion

        Try
            'GUARDAR INFORMACION BASICA DEL CARGO
            objTrans.trCrearTransaccion()
            objCargo.sgcaIdCargo = Me.pIdCargo
            objCargo.sgcaIdEmpresa = 1 'FASEM
            objCargo.sgcaNombre = Me.txtNomCargo.Text
            objCargo.sgcaCodigo = Me.txtCodCargo.Text
            objCargo.sgcaObjetivos = Me.txtObjCargo.Text
            objCargo.sgcaActividadesCargo = Me.txtActividades.Text
            objCargo.sgcaIdEducacion = Me.ddlEducacion.SelectedValue
            objCargo.sgcaIdProfesion = Me.ddlProfesion.SelectedValue
            objCargo.sgcaExperiencia = Me.txtExperiencia.Text
            objCargo.sgcaAnosExperiencia = Me.txtExperienciaAnos.Text
            objCargo.sgcaHabilidades = Me.txtHabilidades.Text
            objCargo.sgcaAQuienRepotaIdCargo = Me.ddlAQuienReporta.SelectedValue
            objCargo.sgcaIdArea = Me.ddlAreaDelCargo.SelectedValue
            objCargo.sgcaAudIdUsuEmp = Me.pIdRelUsuXEmp
            objCargo.sgcaIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo
            objCargo.GuardarInfoCargo(objTrans.trTransaccion)

            Me.pIdCargo = objCargo.sgcaIdCargo
            Me.pStrNomCargo = Me.txtNomCargo.Text

            'GUARDAR INFORMACION DE QUIEN LE REPOTA
            For Each row As DataRow In Me.pTblQuienReportaCargo.Rows
                objCargoXQuienRep.srqrIdCargo = Me.pIdCargo
                objCargoXQuienRep.srqrQuienRepIdCargo = row("QuienRepIdCargo")
                objCargoXQuienRep.srqrIdEstado = row("IdEstado")
                objCargoXQuienRep.GuardarInfoCargoXQuienLeReportaIdCargo(Me.pIdRelUsuXEmp, objTrans.trTransaccion)

                row("idRelCargoXQuienRepIdCargo") = objCargoXQuienRep.srqrIdRelCargoXQuienRepIDCargo
            Next


            objTrans.trConfirmarTransaccion()

            Me.AlertDialog("Se ha guardado correctamente.")

        Catch ex As Exception
            objTrans.trRollBackTransaccion()
            Me.AlertDialog("No se ha podido guardar el Cargo. " & ex.Message.ToString)
        End Try

    End Sub
    'FUNCION PARA CARGAR LA GRILLA DE QUIEN LE REPORTA
    Private Sub CargarGvQuienLeReporta()
        Me.gvQuienLeReporta.DataSource = Me.pTblQuienReportaCargo
        Me.gvQuienLeReporta.DataBind()

        If (Me.gvQuienLeReporta.Rows.Count > 0) Then
            Me.pnlGvQuienLeReporta.Visible = True
        Else
            Me.pnlGvQuienLeReporta.Visible = False
        End If
    End Sub
    'FUNCION PARA VALIDAR SI YA EXISTE UN CARGO CON ESE CODIGO
    Private Sub ValidarExisteCodigoCargo()
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        objCargo.CargarInfoCargoXStrCodCargo(Me.pIdCargo, Trim(Me.txtCodCargo.Text), dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

        If (objCargo.sgcaIdCargo <> 0) Then
            Me.AlertDialog("Código ya creado y perteneciente al cargo " & objCargo.sgcaNombre)
        End If
    End Sub
#End Region
#Region "PUBLICO"
    'FUNCION PARA CARGAR LA INFORMACION DE UN CARGO X ID CARGO
    Public Sub CargarInfoCargoXIdCargo()
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        Dim objCargoXQuienRep As New dllSoftSGSST.SGSST.clSgsstRelCargoXQuienRepIdCargo
        Dim dtDatos As New DataTable
        Dim dtDatosQuienRep As New DataTable

        dtDatos = objCargo.CargarInfoCargoXIdCargo(Me.pIdCargo)

        If (dtDatos.Rows.Count <> 0) Then
            Me.pStrNomCargo = dtDatos.Rows(0)("sgcaNombre")
            Me.txtNomCargo.Text = dtDatos.Rows(0)("sgcaNombre")
            Me.txtCodCargo.Text = dtDatos.Rows(0)("sgcaCodigo")
            Me.txtObjCargo.Text = dtDatos.Rows(0)("sgcaObjetivos")
            Me.txtActividades.Text = dtDatos.Rows(0)("sgcaActividadesCargo")
            Me.ddlEducacion.SelectedValue = dtDatos.Rows(0)("sgcaIdEducacion")
            Me.ddlProfesion.SelectedValue = dtDatos.Rows(0)("sgcaIdProfesion")
            Me.txtExperiencia.Text = dtDatos.Rows(0)("sgcaExperiencia")
            Me.txtExperienciaAnos.Text = dtDatos.Rows(0)("sgcaAnosExperiencia")
            Me.txtHabilidades.Text = dtDatos.Rows(0)("sgcaHabilidades")
            Me.ddlAQuienReporta.Text = dtDatos.Rows(0)("sgcaAQuienRepotaIdCargo")
            Me.ddlAreaDelCargo.SelectedValue = dtDatos.Rows(0)("sgcaIdArea")

            'CARGAR QUIEN LE REPORTA

            dtDatosQuienRep = objCargoXQuienRep.GetTblInfoQuienLeReportaCargoXIdCargo(Me.pIdCargo, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

            If (dtDatosQuienRep.Rows.Count <> 0) Then
                For Each rowQuienRep As DataRow In dtDatosQuienRep.Rows
                    Dim row As DataRow = Me.pTblQuienReportaCargo.NewRow
                    row("idRelCargoXQuienRepIdCargo") = rowQuienRep("srqrIdRelCargoXQuienRepIDCargo")
                    row("QuienRepIdCargo") = rowQuienRep("srqrQuienRepIdCargo")
                    row("Nombre") = rowQuienRep("sgcaNombre")
                    row("IdEstado") = rowQuienRep("srqrIdEstado")

                    Me.pTblQuienReportaCargo.Rows.Add(row)
                Next
                Me.CargarGvQuienLeReporta()
            End If
        End If
    End Sub
    'FUNCION PARA LIMPIAR EL CONTROL
    Public Sub LimpiarBuscador()
        'LIMPIAR CONTROL DE CARGOS
        Me.ctrDinaConsObjCargo.LimpiarCtr()
    End Sub
    'FUNCION PARA LIMPIAR EL FORMULARIO DEL CONTROL
    Public Sub LimpiarForm()
        Me.pIdCargo = 0

        Me.txtNomCargo.Text = ""
        Me.txtCodCargo.Text = ""
        Me.txtObjCargo.Text = ""
        Me.txtActividades.Text = ""
        Me.ddlEducacion.SelectedValue = 0
        Me.ddlProfesion.SelectedValue = 0
        Me.txtExperiencia.Text = ""
        Me.txtExperienciaAnos.Text = ""
        Me.txtHabilidades.Text = ""
        Me.ddlAQuienReporta.SelectedValue = 0

        'LIMPIAR LA GRILLA DE QUIEN LE REPORTA
        Me.pTblQuienReportaCargo = New dllSoftSGSST.SGSST.dtsQuienLeReportaCargo.dtQuienRepCargoDataTable
        Me.CargarGvQuienLeReporta()

        Me.ddlAreaDelCargo.SelectedValue = 0
    End Sub
    'MANEJO DEL EVENTO CERRAR CTR DE ACTIVIDADES Y PELIGROS
    Public Sub evtCerrarCtrActividades() Handles ctrActividadesYPeligros.evtCerrarCtr
        Me.pVisualizacionXAccion = EnmAccion.Cargar
    End Sub


#End Region
End Class