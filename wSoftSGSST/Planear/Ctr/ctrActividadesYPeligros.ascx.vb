Public Class ctrActividadesYPeligros
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Event evtCerrarCtr()
#Region "PROPIEDADES"
    'ENUMERACION PARA EL MANEJO DE ACCIONES DEL CONTROL
    Public Enum EnmAccion
        Inicio = 1
        AsociarActividad = 2
        NuevaActividad = 3
        NuevoPeligro = 4
    End Enum
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    Public WriteOnly Property pBoolIniCtr As Boolean
        Set(value As Boolean)
            Me.pVisualizacionXAccion = EnmAccion.Inicio
        End Set
    End Property
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DEL CONTROL
    Public WriteOnly Property pVisualizacionXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'VISUALIZACION PANELES
                    Me.pnlGvActRiesgos.Visible = True
                    Me.pnlActividad.Visible = False
                    Me.pnlNuevaActividad.Visible = False
                    Me.pnlDescClasRies.Visible = False
                    Me.ibtnAgregarActividad.Visible = True
                    Me.ibtCerrar.Visible = True

                    'INICIALIZAR DATASET
                    Me.pTblPeligro = New dllSoftSGSST.SGSST.dtsPeligro.dtPeligroDataTable

                    'DEFINIR EL LBL DEL NOMBRE DEL CARGO
                    Me.lblNomCargo.Text = Me.pStrNomCargo

                    'CARGAR EL DDL DE CLASIFICACION DEL PELIGRO
                    Me.CargarDdlClasificacion()

                    'CARGAR EL DDL DE RIESGO
                    Me.CargarDdlRiesg

                    'CARGAR LA GRILLA DE PELIGROS RELACIONADAS AL CARGO
                    Me.CargarGrillaPeligrosXCargo()

                Case EnmAccion.AsociarActividad
                    'VISUALIZACION DE PANELES
                    Me.pnlPeligrosXCargo.Visible = False
                    Me.pnlActividad.Visible = True
                    Me.pnlNuevaActividad.Visible = False
                    Me.pnlDescClasRies.Visible = False
                    Me.ibtnAgregarActividad.Visible = False
                    Me.ibtCerrar.Visible = False

                    'INICIALIZAR CONTROL DINAMICO DE ACTIVIDADES
                    Me.ctrDinaConsObjActividad.pIdConfigCtrBusDina = 3
                    Me.ctrDinaConsObjActividad.pBoolIniCtr = True

                Case EnmAccion.NuevaActividad
                    'VISUALIZACION DE PANELES
                    Me.pnlPeligrosXCargo.Visible = False
                    Me.pnlActividad.Visible = False
                    Me.pnlNuevaActividad.Visible = True
                    Me.pnlDescClasRies.Visible = False

                    'LIMPIAR CTR DINA ACTIVIDAAD
                    Me.ctrDinaConsObjActividad.LimpiarCtr()

                    'LIMPIAR EL GV DE PELIGRO
                    Me.pTblPeligro = New dllSoftSGSST.SGSST.dtsPeligro.dtPeligroDataTable

                    Me.CargarGrillaPeligros()

                Case EnmAccion.NuevoPeligro
                    'VISUALIZACION DE PANELES
                    Me.pnlPeligrosXCargo.Visible = False
                    Me.pnlActividad.Visible = True
                    Me.pnlNuevaActividad.Visible = False
                    Me.pnlDescClasRies.Visible = True
            End Select
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL ID DEL CARGO
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
    'PROPIEDAD PARA ALMACENAR DATASET DE PELIGROS
    Public Property pTblPeligro As dllSoftSGSST.SGSST.dtsPeligro.dtPeligroDataTable
        Get
            Return ViewState("pTblPeligro")
        End Get
        Set(value As dllSoftSGSST.SGSST.dtsPeligro.dtPeligroDataTable)
            ViewState("pTblPeligro") = value
        End Set
    End Property
    'PROPIEDAD PARA GUARDAR EL ID ACTIVIDAD
    Public Property pIdActividad As Integer
        Get
            Return ViewState("pIdActividad")
        End Get
        Set(value As Integer)
            ViewState("pIdActividad") = value
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    'EVENTO DEL BOTON CERRAR CONTROL
    Protected Sub ibtCerrar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtCerrar.Click
        RaiseEvent evtCerrarCtr()
    End Sub
    'EVENTO DEL BOTON ELIMINAR PELIGRO X CARGO
    Protected Sub ibtnEliminar_Click(sender As Object, e As ImageClickEventArgs)
        Dim index As Integer = DirectCast(DirectCast(sender, System.Web.UI.Control).Parent.Parent, System.Web.UI.WebControls.GridViewRow).RowIndex
        Dim idRelPeligroXCargo As Integer = Me.gvPeligrosXCargo.DataKeys(index).Values("sracIdRelPeligroXCargo")

        'MANDA A INACTIVAR LA RELACION DEL PELIGRO POR EL CARGO
        Me.InactivarRelacionPeligroXCargo(idRelPeligroXCargo)

        'CARGAR GRILLA DE PELIGROS X CARGO
        Me.CargarGrillaPeligrosXCargo()
    End Sub
    'EVENTO DEL BOTON CERRAR REGISTRO NUEVA ACTIVIDAD
    Protected Sub ibtnCerrarActividad_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCerrarActividad.Click
        Me.pVisualizacionXAccion = EnmAccion.Inicio
    End Sub
    'EVENTO DEL BOTON AGREGAR NUEVA ACTIVIDAD CON PELIGRO
    Protected Sub ibtnAgregarActividad_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAgregarActividad.Click
        'MODIFICAR LA VISUALIZACION DEL CONTROL
        Me.pVisualizacionXAccion = EnmAccion.AsociarActividad

        'LIMPIAR CTR DINA ACTIVIDAAD
        Me.ctrDinaConsObjActividad.LimpiarCtr()

        'LIMPIAR EL GV DE PELIGRO
        Me.pTblPeligro = New dllSoftSGSST.SGSST.dtsPeligro.dtPeligroDataTable

        Me.CargarGrillaPeligros()
    End Sub
    'EVENTO DEL BOTON AGREGAR ACTIVIDAD
    Protected Sub ibnIncluirActividad_Click(sender As Object, e As ImageClickEventArgs) Handles ibnIncluirActividad.Click
        If (Me.pIdActividad <> 0) Then
            'LIMPIAR TABLA DE PELIGROS
            Me.pTblPeligro = New dllSoftSGSST.SGSST.dtsPeligro.dtPeligroDataTable

            'CARGAR LOS PELIGROS ASOCIADOS A UNA ACTIVIDAD
            Me.CargarPeligrosXIdActividad()

        Else
            Me.AlertDialog("Debe seleccionar una Actividad.")
        End If
    End Sub
    'EVENTO DEL BOTON NUEVA ACTIVIDAD
    Protected Sub ibtnNuevaActivdad_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnNuevaActivdad.Click
        'MODIFICAR LA VISUALIZACION
        Me.pVisualizacionXAccion = EnmAccion.NuevaActividad

    End Sub
    'EVENTO DEL BOTON CERRAR NUEVA ACTIVIDAD
    Protected Sub ibtnCerrarNuevaAct_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCerrarNuevaAct.Click
        Me.pVisualizacionXAccion = EnmAccion.AsociarActividad
    End Sub
    'EVENTO DEL BOTON GUARDAR NUEVA ACTIVIDAD
    Protected Sub ibtnGuardarNuevaAct_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardarNuevaAct.Click
        If (Me.esValidoParaguardarActividad._varBoolRtn) Then
            'MANDA A GUARDAR LA ACTIVIDAD
            Me.GuardarActividad()

            'CARGAR EL CONTROL DINAMICO CON LA ACTIVIDAD CREADA
            Me.ctrDinaConsObjActividad.BuscarXId(Me.pIdActividad)

            Me.pVisualizacionXAccion = EnmAccion.AsociarActividad
        End If
    End Sub
    'EVENTO DEL BOTON NUEVO RIESGO
    Protected Sub ibntNuevoRiesgo_Click(sender As Object, e As ImageClickEventArgs) Handles ibntNuevoRiesgo.Click
        'EVALUA SI SE HA SELECCIONADO ALGUNA ACTIVIDAD
        If (Me.pIdActividad <> 0) Then
            Me.pVisualizacionXAccion = EnmAccion.NuevoPeligro
        Else
            Me.AlertDialog("Debe selecionar una Actividad.")
        End If
    End Sub
    'EVENTO DEL BOTON AGREGAR DESCRIPCION, CLASIFICACION Y RIESGO
    Protected Sub ibtAgregarDescClasRies_Click(sender As Object, e As ImageClickEventArgs) Handles ibtAgregarDescClasRies.Click
        'EVALUA SI PERMITE AGREGAR NUEVA DESCRIPCION CLASIFICACION Y RIESGO ASOCIADO A LA ACTIVIDAD
        If (Me.PermiteAgregarPeligro._varBoolRtn) Then

            'AGREGAR LA INFORMACION DEL PELIGRO AL DATASET
            Me.AgregarPeligro()

            'LIMPIAR CAMPOS
            Me.LimpiarFrmDescClasifRiesgo()

            Me.pVisualizacionXAccion = EnmAccion.AsociarActividad
        End If
    End Sub
    'EVENTO DEL BOTON CARGAR PELIGROS AL CARGO
    Protected Sub ibtnCargar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCargar.Click
        If (Me.pTblPeligro.Rows.Count <> 0) Then
            Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion
            Try
                objTrans.trCrearTransaccion()
                'GUARDAR LA INFORMACION DEL PELIGRO
                Me.GuardarInfoPeligro(objTrans.trTransaccion)

                'GUARDAR LA INFORMACIUON DEL PELIGRO POR EL CARGO
                Me.GuardarInfoPeligrosXcargo(objTrans.trTransaccion)

                objTrans.trConfirmarTransaccion()

                Me.pVisualizacionXAccion = EnmAccion.Inicio
            Catch ex As Exception
                objTrans.trRollBackTransaccion()
                Me.AlertDialog("No se pudo guardar el Peligro :" & ex.Message.ToString)
            End Try

        Else
            Me.AlertDialog("Debe asociar informacion a la actividad para poder cargarla.")
        End If
    End Sub
    'EVENTO DEL BOTON DESCARTAR
    Protected Sub ibtnDescartar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnDescartar.Click
        'LIMPIAR CTR DINA ACTIVIDAAD
        Me.ctrDinaConsObjActividad.LimpiarCtr()

        'LIMPIAR EL GV DE PELIGRO
        Me.pTblPeligro = New dllSoftSGSST.SGSST.dtsPeligro.dtPeligroDataTable

        Me.CargarGrillaPeligros()

        Me.pVisualizacionXAccion = EnmAccion.Inicio
    End Sub
    'EVENTO DEL CHECK DE INCLUIR
    Protected Sub chkIcluirPeligro_CheckedChanged(sender As Object, e As EventArgs)
        Dim Index As Integer = DirectCast(DirectCast(sender, System.Web.UI.Control).Parent.Parent, System.Web.UI.WebControls.GridViewRow).RowIndex
        Dim IdCabPeligro As New Integer
        IdCabPeligro = Me.gvPeligro.DataKeys(Index).Values("idCabPeligro")

        For Each row As DataRow In Me.pTblPeligro.Rows
            If (row("idCabPeligro") = IdCabPeligro) Then
                row("EstIncluir") = IIf(DirectCast(sender, Web.UI.WebControls.CheckBox).Checked, 1, 0)
            End If
        Next
    End Sub
#End Region
#Region "PRIVADO"
    'FUNCION PARA CARGAR EL DDL DE CLASIFICACION DEL RIESGO
    Private Sub CargarDdlClasificacion()
        Dim objClasif As New dllSoftSGSST.SGSST.clSgsstClasificacionPeligro
        Dim dtDatos As New DataTable
        dtDatos = objClasif.GetTblInfoClasificacionPeligroXIdEst(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlClasificacion, dtDatos, "sclpIdClasificacionPeligro", "sclpNombre")
    End Sub
    'FUNCION PARA CARGAR EL DDL RIESGO
    Private Sub CargarDdlRiesg()
        Dim objRiesgo As New dllSoftSGSST.SGSST.clSgsstRiesgo
        Dim dtDatos As New DataTable
        dtDatos = objRiesgo.GetTblInfoRiesgoXIdEst(dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(ddlRiesgo, dtDatos, "sgriIdRiesgo", "sgriNombre")
    End Sub
    'FUNCION PARA CARGAR LAS ACTIVIDADES X CARGO
    Private Sub CargarGrillaPeligrosXCargo()
        Dim objRelPeligroXCargo As New dllSoftSGSST.SGSST.clSgsstRelPeligroXCargo
        Dim dtDatos As New DataTable
        dtDatos = objRelPeligroXCargo.GetTblInfoPeligroXIdCargo(Me.pIdCargo, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

        Me.gvPeligrosXCargo.DataSource = dtDatos
        Me.gvPeligrosXCargo.DataBind()

        If (dtDatos.Rows.Count <> 0) Then
            Me.pnlPeligrosXCargo.Visible = True
            Me.lblNoHayActividades.Visible = False
        Else
            Me.pnlPeligrosXCargo.Visible = False
            Me.lblNoHayActividades.Visible = True
        End If
    End Sub
    'FUNCION PARA INACTIVAR LA RELACION DEL PELIGRO POR EL CARGO
    Private Sub InactivarRelacionPeligroXCargo(ByVal parIdRelPeligroXCargo As Integer)
        Dim objRelPeligroXCargo As New dllSoftSGSST.SGSST.clSgsstRelPeligroXCargo
        objRelPeligroXCargo.InactivarRelPeligroXCargo(parIdRelPeligroXCargo)

    End Sub
    'FUNCION PARA VALIDAR SI PERMITE GUARDAR UNA NUEVA ACTIVIDAD
    Private Function esValidoParaguardarActividad() As dllSoftSGSST.Estructura.EstructuraMsjValidacion
        Dim tmpMsj As New dllSoftSGSST.Estructura.EstructuraMsjValidacion
        'VALIDAR TXT DE ACTIVIDAD
        If (Trim(Me.txtNuevaActividad.Text) = "") Then
            tmpMsj.AgregarMensaje("Debe ingresar un nombre de Actividad.")
            tmpMsj._varBoolRtn = False
        End If

        If Not (tmpMsj._varBoolRtn) Then
            Me.AlertDialog(tmpMsj.GetMensajeValidacion)
        End If

        Return tmpMsj
    End Function
    'FUNCION PARA GUARDAR UNA NUEVA ACTIVIDAD
    Private Sub GuardarActividad()
        Dim objActividad As New dllSoftSGSST.SGSST.clSgsstActividad
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion

        Try
            objTrans.trCrearTransaccion()
            objActividad.sgacIdActividad = 0
            objActividad.sgacIdEmpresa = 1
            objActividad.sgacNombre = Me.txtNuevaActividad.Text
            objActividad.sgacIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo
            objActividad.GuardarActividad(Me.pIdRelUsuXEmp, objTrans.trTransaccion)

            'DEFINIR LA PROPIEDAD DE ACTIVIDAD
            Me.pIdActividad = objActividad.sgacIdActividad
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            objTrans.trRollBackTransaccion()
            Me.AlertDialog("No se pudo guardar la Actividad :" & ex.Message.ToString)
        End Try

    End Sub
    'FUNCION PARA VALIDAR SI PERMITE AÑADIR NUEVA DESCRIPCION, CLASIFICAICON Y RIESGO A LA ACTIVIDAD
    Private Function PermiteAgregarPeligro() As dllSoftSGSST.Estructura.EstructuraMsjValidacion
        Dim tmMsj As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        'EVALUA DESCRIPCION DEL PELIGRO
        If (Trim(Me.txtDescripcion.Text) = "") Then
            tmMsj.AgregarMensaje("Debe ingresar Descripción del Peligro.")
            tmMsj._varBoolRtn = False
        End If

        'EVALUA CLASIFICACION DEL PELIGRO
        If (Me.ddlClasificacion.SelectedValue = 0) Then
            tmMsj.AgregarMensaje("Debe seleccionar Clasificación del Peligro.")
            tmMsj._varBoolRtn = False
        End If

        'EVALUA RIESGO
        If (Me.ddlRiesgo.SelectedValue = 0) Then
            tmMsj.AgregarMensaje("Debe seleccionar Riesgo.")
            tmMsj._varBoolRtn = False
        End If

        If Not (tmMsj._varBoolRtn) Then
            Me.AlertDialog(tmMsj.GetMensajeValidacion)
        End If

        Return tmMsj
    End Function
    'FUNCION PARA AGREGAR PELIGRO AL DATASET
    Private Sub AgregarPeligro()
        Dim varRow As dllSoftSGSST.SGSST.dtsPeligro.dtPeligroRow = Me.pTblPeligro.NewRow

        varRow("EstIncluir") = 1
        varRow("idPeligro") = 0
        varRow("idActividad") = Me.pIdActividad
        varRow("NomActividad") = Me.ctrDinaConsObjActividad.pStrNomSel
        varRow("NomDescripcionPeligro") = Me.txtDescripcion.Text
        varRow("idClasificacionPeligro") = Me.ddlClasificacion.SelectedValue
        varRow("NomClasificacionPeligro") = Me.ddlClasificacion.SelectedItem
        varRow("idRiesgo") = Me.ddlRiesgo.SelectedValue
        varRow("NomRiesgo") = Me.ddlRiesgo.SelectedItem
        varRow("idEstado") = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo

        Me.pTblPeligro.AdddtPeligroRow(varRow)

        'CARGAR LA GRILLA
        Me.CargarGrillaPeligros()

    End Sub
    'FUNCION PARA CARGAR LOS PELIGROS ASOCIADOS A UNA ACTIVIDAD
    Private Sub CargarPeligrosXIdActividad()
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro
        Dim dtDatos As New DataTable
        dtDatos = objPeligro.GetTblInfoPeligroXIdActividad(Me.pIdActividad, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

        'AGREGAR LOS PELIGROS AL DATATABLE
        If (dtDatos.Rows.Count <> 0) Then
            For Each row As DataRow In dtDatos.Rows
                Dim varRow As dllSoftSGSST.SGSST.dtsPeligro.dtPeligroRow = Me.pTblPeligro.NewRow
                varRow("EstIncluir") = 1
                varRow("idPeligro") = row("sgplIdPeligro")
                varRow("idActividad") = row("sgplIdActividad")
                varRow("NomActividad") = row("sgacNombre")
                varRow("NomDescripcionPeligro") = row("sgplDescripcionPeligro")
                varRow("idClasificacionPeligro") = row("sgplIdClasificacionPeligro")
                varRow("NomClasificacionPeligro") = row("sclpNombre")
                varRow("idRiesgo") = row("sgplIdRiesgo")
                varRow("NomRiesgo") = row("sgriNombre")
                varRow("idEstado") = row("sgplIdEstado")

                Me.pTblPeligro.AdddtPeligroRow(varRow)

                'CARGAR LA GRILLA
                Me.CargarGrillaPeligros()
            Next
        Else
            Me.AlertDialog("No hay Peligros asociados a esta Actividad.")
        End If
    End Sub
    'FUNCION PARA GUARDAR LA INFORMACION DEL PELIGRO
    Private Sub GuardarInfoPeligro(Optional ByVal parObjtrans As System.Data.Common.DbTransaction = Nothing)
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro


        For Each row As DataRow In Me.pTblPeligro.Rows
            If (row("EstIncluir") = 1) Then
                objPeligro.sgplIdPeligro = row("idPeligro")
                objPeligro.sgplIdEmpresa = 1
                objPeligro.sgplIdActividad = row("idActividad")
                objPeligro.sgplDescripcionPeligro = row("NomDescripcionPeligro")
                objPeligro.sgplIdClasificacionPeligro = row("idClasificacionPeligro")
                objPeligro.sgplIdRiesgo = row("idRiesgo")
                objPeligro.sgplAudIdUsuEmp = Me.pIdRelUsuXEmp
                objPeligro.sgplIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo
                objPeligro.GuardarInfoPeligro(parObjtrans)

                row("idPeligro") = objPeligro.sgplIdPeligro

            End If
        Next

    End Sub
    'FUNCION PARA GUARDAR LA INFORMACION DE PELIGROS X CARGO
    Private Sub GuardarInfoPeligrosXcargo(Optional ByVal parObjtrans As System.Data.Common.DbTransaction = Nothing)
        Dim objRelPelXCarg As New dllSoftSGSST.SGSST.clSgsstRelPeligroXCargo
        For Each row As DataRow In Me.pTblPeligro.Rows
            If (row("idPeligro") <> 0 AndAlso row("idEstado") = 1 AndAlso row("EstIncluir") = 1) Then
                objRelPelXCarg.sracIdRelPeligroXCargo = 0
                objRelPelXCarg.sracIdCargo = Me.pIdCargo
                objRelPelXCarg.sracIdPeligro = row("idPeligro")
                objRelPelXCarg.sracAudIdUsuEmp = Me.pIdRelUsuXEmp
                objRelPelXCarg.sracIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo
                objRelPelXCarg.GuardarInfoPeligroXCargo(parObjtrans)
            End If
        Next
    End Sub
#End Region
#Region "PUBLICO"
    'FUNCION PARA CARGAR LA GRILLA DE ACTIVIDADES X CARGO
    Public Sub CargarGrillaPeligros()
        Me.gvPeligro.DataSource = Me.pTblPeligro
        Me.gvPeligro.DataBind()

        If (Me.gvPeligro.Rows.Count <> 0) Then
            Me.pnlGvPeligro.Visible = True
        Else
            Me.pnlGvPeligro.Visible = False
        End If
    End Sub
    'EVENTO DE LA SELECCION DE ACTIVIDAD
    Public Sub evtSeleccionoActividad() Handles ctrDinaConsObjActividad.evtSelecciono
        Me.pIdActividad = Me.ctrDinaConsObjActividad.pIdSel
    End Sub
    'FUNCION PARA LIMPIAR LA DESCRIPCION, CLASIFICACION Y RIESGO
    Public Sub LimpiarFrmDescClasifRiesgo()
        Me.txtDescripcion.Text = ""
        Me.ddlClasificacion.SelectedValue = 0
        Me.ddlRiesgo.SelectedValue = 0
    End Sub
#End Region
End Class