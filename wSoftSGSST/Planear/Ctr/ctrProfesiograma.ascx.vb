Public Class ctrProfesiograma
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
#Region "PROPIEDADES"
    'ENUMERACION PARA EL MANEJO DE ACCIONES
    Public Enum EnmAccion
        Inicio = 1
        Cargar = 2
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
                    'OCULTAR LOS LBL DE OBLIGATORIO
                    Me.lblNomCargoObliga.Visible = False
                    Me.lblCodCargoObliga.Visible = False
                    Me.lblActividadesObliga.Visible = False

                    'FUNCION PARA CARGAR EL DDL EDUCACION
                    Me.CargarDdlEducacion()

                    'FUNCION PARA CARGAR EL DDL PROFESION
                    Me.CargarDdlProfesion()

                    'CARGAR DDL AREA
                    Me.CargarDdlArea()

                    'INCIALIZAR LA TABLA DE QUIEN LE REPORTA
                    Me.pTblQuienReportaCargo = New dllSoftSGSST.SGSST.dtsQuienLeReportaCargo.dtQuienRepCargoDataTable
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
        If (Me.ctrDinaConsObj.pIdSel <> 0) Then
            Me.AgregarCargoQuienLeReporta
        Else
            Me.AlertDialog("Debe seleccionar Cargo quien le reporta.")
        End If
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
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        Dim dtDatos As New DataTable
        dtDatos = objCargo.GetTblInfoCargoXIdEst(1, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlAQuienReporta, dtDatos, "sgcaIdCargo", "sgcaNombre")
    End Sub
    'FUNCION PARA CARGAR EL DDL DE AREA
    Private Sub CargarDdlArea()
        Dim objArea As New dllSoftSGSST.SGSST.clSgsstArea
        Dim dtDatos As New DataTable
        dtDatos = objArea.GetTblAreaXIdEst(1, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)
        Me.CargarListaDesplegable(Me.ddlAreaDelCargo, dtDatos, "sgarIdArea", "sgarNombre")
    End Sub
    'FUNCION PARA VALIDAR SI ES VALIDO PARA GUARDAR
    Private Function esValidoParaguardar() As dllSoftSGSST.Estructura.EstructuraMsjValidacion
        Dim objMsj As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        'VALIDAR TXT NOMBRE
        If (Trim(Me.txtNomCargo.Text) = "") Then
            objMsj.AgregarMensaje("Debe digitar Nombre Cargo")
            objMsj._varBoolRtn = False
        End If

        'VALIDAR TXT CODIGO CARGO
        If (Trim(Me.txtCodCargo.Text) = "") Then
            objMsj.AgregarMensaje("Debe digitar Código Cargo")
            objMsj._varBoolRtn = False
        End If

        'VALIDAR TXT ACTIVIDADES DEL CARGO
        If (Trim(Me.txtActividades.Text) = "") Then
            objMsj.AgregarMensaje("Debe digitar Actividades Cargo")
            objMsj._varBoolRtn = False
        End If

        If Not (objMsj._varBoolRtn) Then
            Me.AlertDialog(objMsj.GetMensaje(dllSoftSGSST.Estructura.EstructuraMsjValidacion.EnmTipoMensaje.Advertencia, objMsj.GetMensajeValidacion))
        End If
        Return objMsj
    End Function
    Private Sub AgregarCargoQuienLeReporta()
        Dim row As DataRow = Me.pTblQuienReportaCargo.NewRow

        row("QuienRepIdCargo") = Me.ctrDinaConsObj.pIdSel
        row("Nombre") = Me.ctrDinaConsObj.pStrNomSel
        row("IdEstado") = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo

        Me.pTblQuienReportaCargo.Rows.Add(row)

        Me.CargarGvQuienLeReporta
    End Sub
    'FUNCION PARA GUARDAR LA INFORMACION DE EMPLEADO
    Private Sub GuardarInfoCargo()
        Dim objCargo As New dllSoftSGSST.SGSST.clSgsstCargo
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion

        Try
            objTrans.trCrearTransaccion()
            objCargo.sgcaIdCargo = Me.pIdCargo
            objCargo.sgcaIdEmpresa = 1 'FASEM
            objCargo.sgcaNombre = Me.txtNomCargo.Text
            objCargo.sgcaCodigo = Me.txtCodCargo.Text
            objCargo.sgcaObjetivos = Me.txtObjCargo.Text
            objCargo.sgcaActividadesCargo = Me.txtActividades.Text
            objCargo.sgcaIdEducacion = Me.ddlEducacion.SelectedValue
            objCargo.sgcaIdProfesion = Me.ddlProfesion.SelectedValue
            objCargo.sgcaAnosExperiencia = Me.txtExperienciaAnos.Text
            objCargo.sgcaHabilidades = Me.txtHabilidades.Text
            objCargo.sgcaAQuienRepotaIdCargo = Me.ddlAQuienReporta.SelectedValue
            objCargo.sgcaIdArea = Me.ddlAreaDelCargo.SelectedValue
            objCargo.sgcaAudIdUsuEmp = Me.pIdRelUsuXEmp
            objCargo.sgcaIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo
            objCargo.GuardarInfoCargo(objTrans.trTransaccion)

            Me.pIdCargo = objCargo.sgcaIdCargo
            objTrans.trConfirmarTransaccion()
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
#End Region
#Region "PUBLICO"


#End Region
End Class