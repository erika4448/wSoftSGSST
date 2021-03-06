﻿Public Class ctrProceso
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


        End If
    End Sub
    '=====================================BANDERAS=======================================
    Dim varBoolActEstRel As Boolean = False
    Dim varBoolGuardoProceso As Boolean = False
    '====================================================================================
#Region "PROPIEDADES"
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    Public WriteOnly Property pBoolIniCtr As Boolean
        Set(value As Boolean)
            If value Then
                'SE INICIALIZ LA VISUALIZACION
                Me.pVisualizaXAccion = EnmAccion.Inicio
            End If
        End Set
    End Property
    'ENUMERACION PARA EL CONTROL DE ACCIONES QUE SE REALIZAN EN EL CONTROL
    Private Enum EnmAccion
        Inicio = 1
        Nuevo = 2
        SelProceso = 3
    End Enum
    'PROPIEDAD PARA EL CONTROL DE ACCIONES QUE SE REALIZAN EN EL CONTROL
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'PANELES==================
                    Me.pnlGvProcesos.Visible = False
                    '=========================
                    'LISTAS DESPLEGABLES======
                    Me.ddlProceso.Visible = True
                    '=========================
                    'CAJA_TEXTO===============
                    Me.txtProceso.Visible = False
                    '=========================
                    'BOTONES==================
                    Me.ibtnAgregar.Visible = True
                    Me.ibtnIncluir.Visible = True
                    Me.ibtnGuardar.Visible = False
                    Me.ibtnCerrar.Visible = False
                    '=========================

                    'SE INCIALIZA EL DATASET
                    Me.pTblProceso = New dllSoftSGSST.SGSST.dtsProceso.dtProcesoDataTable()

                    'SE CARGAN LOS PROCESOS
                    Me.CargarProcesos()

                Case EnmAccion.SelProceso
                    'LISTAS DESPLEGABLES======
                    Me.ddlProceso.Visible = True
                    '=========================
                    'CAJA_TEXTO===============
                    Me.txtProceso.Visible = False
                    '=========================
                    'BOTONES==================
                    Me.ibtnAgregar.Visible = True
                    Me.ibtnIncluir.Visible = True
                    Me.ibtnGuardar.Visible = False
                    Me.ibtnCerrar.Visible = False
                    '=========================

                Case EnmAccion.Nuevo
                    'LISTAS DESPLEGABLES======
                    Me.ddlProceso.Visible = False
                    '=========================
                    'CAJA_TEXTO===============
                    Me.txtProceso.Visible = True
                    '=========================
                    'BOTONES==================
                    Me.ibtnAgregar.Visible = False
                    Me.ibtnIncluir.Visible = False
                    Me.ibtnGuardar.Visible = True
                    Me.ibtnCerrar.Visible = True
                    '=========================
            End Select
        End Set
    End Property
    'PROPIEDAD PARA EL ALMACENAMIETO DEL ID_PELIGRO
    Public Property pIdPeligro As Integer
        Get
            Return ViewState("pIdPeligro")
        End Get
        Set(value As Integer)
            ViewState("pIdPeligro") = value
        End Set
    End Property
    'PROPIEDAD PARA EL MANEJO DE DATASET PROCESO
    Private Property pTblProceso As dllSoftSGSST.SGSST.dtsProceso.dtProcesoDataTable
        Get
            Return ViewState("pDtsProceso")
        End Get
        Set(value As dllSoftSGSST.SGSST.dtsProceso.dtProcesoDataTable)
            ViewState("pDtsProceso") = value
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub gvProceso_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvProceso.RowCommand
        Select Case e.CommandName
            Case "cmdEliminar"
                Dim varIndex As Integer = 0
                Dim varIdTabla As Integer = 0
                Dim drRow As dllSoftSGSST.SGSST.dtsProceso.dtProcesoRow
                varIndex = e.CommandArgument


                varIdTabla = gvProceso.DataKeys(varIndex).Values("tmpIdTabla")
                drRow = Me.pTblProceso.FindBytmpIdTabla(varIdTabla)

                If (drRow.tmpIdRel <> 0) Then
                    'ENVIA A ACTUALIZAR RELACION 
                    Me.ActEstRelProcesoXPeligro(drRow.tmpIdRel, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Inactivo)

                    'ELIMINA LA FILA
                    drRow.Delete()

                    If (Me.varBoolActEstRel) Then
                        Me.SuccessLog("Eliminado correctamente.")
                    End If
                Else
                    'ELIMINA LA FILA
                    drRow.Delete()
                    Me.SuccessLog("Eliminado correctamente.")
                End If

                'SE ACTUALIZA LA GRILLA
                Me.ActualizarGrillaProcesos()
        End Select
    End Sub
    Protected Sub ibtnAgregar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAgregar.Click
        If (Me.PermiteAgregar()) Then
            'SE AGREGA EL PROCESO
            Me.AgregarProceso(Me.ddlProceso.SelectedValue, Me.ddlProceso.SelectedItem.Text)
        End If
    End Sub
    Protected Sub ibtnIncluir_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnIncluir.Click
        'ELIMINA LA SELECCION
        If (Me.ddlProceso.Items.Count > 0) Then
            Me.ddlProceso.SelectedValue = 0
        End If

        'MODIFICA_VISUALIZACION
        Me.pVisualizaXAccion = EnmAccion.Nuevo
    End Sub
    Protected Sub ibtnGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardar.Click
        Dim varIdProceso As Integer = 0

        If (Me.PermiteGuardar()) Then
            'ENVIA A GUARDAR
            varIdProceso = Me.GuardarProceso()

            If (Me.varBoolGuardoProceso) Then
                Me.SuccessLog("Se guardó correctamente.")

                'SE LIMPIA EL CTR PROCESO
                Me.LimpiarCtrProceso()

                'SE CARGA LA INFORMACION DE PROCESOS
                Me.CargarProcesos()

                'VALIDA SI CARGA LA SELECCION
                If Not (Me.ddlProceso.Items.FindByValue(varIdProceso) Is Nothing) Then
                    Me.ddlProceso.SelectedValue = varIdProceso
                Else
                    Me.ddlProceso.SelectedValue = 0
                End If

                'MODIFICA VISUALIZACION
                Me.pVisualizaXAccion = EnmAccion.SelProceso

            End If
        End If
    End Sub
    Protected Sub ibtnCerrar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCerrar.Click
        'SE LIMPIA EL CTR PROCESO
        Me.LimpiarCtrProceso()

        'MODIFICA VISUALIZACION
        Me.pVisualizaXAccion = EnmAccion.SelProceso
    End Sub
#End Region
#Region "PRIVADO"
    Private Sub CargarProcesos()
        Dim objProceso As New dllSoftSGSST.SGSST.clSgsstProceso

        Me.CargarListaDesplegable(Me.ddlProceso, objProceso.GetTblInfoProcesoXIdEst(Me.pIdEmpresa, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo), "sgpIdProceso", "sgpNombre")
    End Sub
    Private Function EsProcesoYaRelacionado(ByVal parIdProceso As Integer) As Boolean
        For Each dtsRow As dllSoftSGSST.SGSST.dtsProceso.dtProcesoRow In Me.pTblProceso.Rows
            If (parIdProceso = dtsRow.tmpIdProceso) Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function PermiteAgregar() As Boolean
        Dim objMsjRtnValida As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        If (Me.ddlProceso.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Debe seleccionar un proceso.", True)
            objMsjRtnValida.pBoolRtn = False

        ElseIf (Me.EsProcesoYaRelacionado(Me.ddlProceso.SelectedValue)) Then
            objMsjRtnValida.AgregarMensaje("El proceso seleccionado ya se encuentra relacionado.", True)
            objMsjRtnValida.pBoolRtn = False

        End If

        If Not objMsjRtnValida.pBoolRtn Then
            Me.AlertDialog(objMsjRtnValida.GetMensajeValidacion())
        End If

        Return objMsjRtnValida.pBoolRtn
    End Function
    Private Sub ActualizarGrillaProcesos()
        Me.gvProceso.DataSource = Me.pTblProceso
        Me.gvProceso.DataBind()

        If (Me.gvProceso.Rows.Count > 0) Then
            Me.pnlGvProcesos.Visible = True
        Else
            Me.pnlGvProcesos.Visible = False
        End If
    End Sub
    Private Sub AgregarProceso(ByVal parIdProceso As Integer, ByVal parNomProceso As String)
        Me.pTblProceso.AdddtProcesoRow(0,
                                       parIdProceso,
                                       parNomProceso,
                                       1)

        Me.ActualizarGrillaProcesos()
    End Sub
    Private Sub ActEstRelProcesoXPeligro(ByVal parIdRelProcesoXPeligro As Integer, ByVal parIdEstado As Integer)
        Dim objRelProcesoXPeligro As New dllSoftSGSST.SGSST.clSgsstRelProcesoXPeligro
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion
        Try
            objTrans.trCrearTransaccion()

            objRelProcesoXPeligro.ActInfoEstRelProcesoXPeligroXIdRel(parIdRelProcesoXPeligro, Me.pIdRelUsuXEmp, parIdEstado, objTrans.trTransaccion)

            Me.varBoolActEstRel = True
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            Me.varBoolActEstRel = False
            objTrans.trRollBackTransaccion()
            Me.FailureLog("Error al intentar guardar información de Relación Proceso - Peligro " & ex.Message)
        End Try
    End Sub
    Private Function PermiteGuardar() As Boolean
        Dim objMsjRtnValida As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        'VALIDA INGRESO DE PROCESO
        If (Trim(Me.txtProceso.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Debe ingresar proceso.", True)
        End If

        If Not (objMsjRtnValida.pBoolRtn) Then
            Me.AlertDialog(objMsjRtnValida.GetMensajeValidacion())
        End If

        Return objMsjRtnValida.pBoolRtn
    End Function
    Private Function GuardarProceso() As Integer
        Dim objProceso As New dllSoftSGSST.SGSST.clSgsstProceso
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion
        Dim varIdProceso As Integer = 0
        Try
            objTrans.trCrearTransaccion()

            objProceso.sgpIdProceso = 0
            objProceso.sgpIdEmpresa = Me.pIdEmpresa
            objProceso.sgpNombre = Trim(Me.txtProceso.Text)
            objProceso.sgpdIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo

            objProceso.GuardarInfoProceso(Me.pIdRelUsuXEmp, objTrans.trTransaccion)

            Me.varBoolGuardoProceso = True
            objTrans.trConfirmarTransaccion()

            varIdProceso = objProceso.sgpIdProceso
        Catch ex As Exception
            Me.varBoolGuardoProceso = False
            objTrans.trRollBackTransaccion()
            Me.FailureLog("Error al intentar guardar proceso: " & ex.Message)
        End Try

        Return varIdProceso
    End Function
#End Region
#Region "PUBLICO"
    Public Function SeleccionoProceso() As Boolean
        If (Me.gvProceso.Rows.Count > 0) Then
            Return True
        Else Return False
        End If
    End Function
    Public Sub GuardarInfo(ByVal parObjTrans As System.Data.Common.DbTransaction)
        Dim objRelProcesoXPeligro As New dllSoftSGSST.SGSST.clSgsstRelProcesoXPeligro

        For Each drRow As dllSoftSGSST.SGSST.dtsProceso.dtProcesoRow In Me.pTblProceso.Rows
            objRelProcesoXPeligro.srppIdRelProcesoXPeligro = drRow.tmpIdRel
            objRelProcesoXPeligro.srppIdPeligro = Me.pIdPeligro
            objRelProcesoXPeligro.srppIdProceso = drRow.tmpIdProceso
            objRelProcesoXPeligro.srppIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo


            objRelProcesoXPeligro.GuardarInfoRelProcesoXPeligro(Me.pIdRelUsuXEmp, parObjTrans)
        Next
    End Sub
    Public Sub CargarInfoXPeligro()
        Dim objProceso As New dllSoftSGSST.SGSST.clSgsstProceso
        Dim dtDatos As New Data.DataTable

        Me.pTblProceso = New dllSoftSGSST.SGSST.dtsProceso.dtProcesoDataTable()

        'SE CARGA LA INFORMACION DE PROCESO POR PELIGRO
        dtDatos = objProceso.GetTblInfoProcesoXIdPeligro(Me.pIdPeligro, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

        For Each drRow As DataRow In dtDatos.Rows
            Me.pTblProceso.AdddtProcesoRow(drRow("srppIdRelProcesoXPeligro"),
                                           drRow("sgpIdProceso"),
                                           drRow("sgpNombre"),
                                           drRow("sgpdIdEstado"))
        Next

        'SE ACTUALIZA LA GRILLA
        Me.ActualizarGrillaProcesos()
    End Sub
    Public Sub LimpiarCtrProceso()
        Me.txtProceso.Text = ""
    End Sub
#End Region
End Class