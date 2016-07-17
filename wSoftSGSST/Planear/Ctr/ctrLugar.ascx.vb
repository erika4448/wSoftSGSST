Public Class ctrLugar
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


        End If
    End Sub
    '=====================================BANDERAS=======================================
    Dim varBoolActEstRel As Boolean = False
    Dim varBoolGuardoLugar As Boolean = False
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
        SelLugar = 3
    End Enum
    'PROPIEDAD PARA EL CONTROL DE ACCIONES QUE SE REALIZAN EN EL CONTROL
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'PANELES==================
                    Me.pnlGvLugar.Visible = False
                    '=========================
                    'LISTAS DESPLEGABLES======
                    Me.ddlLugar.Visible = True
                    '=========================
                    'CAJA_TEXTO===============
                    Me.txtLugar.Visible = False
                    '=========================
                    'BOTONES==================
                    Me.ibtnAgregar.Visible = True
                    Me.ibtnIncluir.Visible = True
                    Me.ibtnGuardar.Visible = False
                    Me.ibtnCerrar.Visible = False
                    '=========================

                    'SE INCIALIZA EL DATASET
                    Me.pTblLugar = New dllSoftSGSST.SGSST.dtsLugar.dtLugarDataTable()

                    'SE CARGAN LOS LUGARES
                    Me.CargarLugares()

                Case EnmAccion.SelLugar
                    'LISTAS DESPLEGABLES======
                    Me.ddlLugar.Visible = True
                    '=========================
                    'CAJA_TEXTO===============
                    Me.txtLugar.Visible = False
                    '=========================
                    'BOTONES==================
                    Me.ibtnAgregar.Visible = True
                    Me.ibtnIncluir.Visible = True
                    Me.ibtnGuardar.Visible = False
                    Me.ibtnCerrar.Visible = False
                    '=========================

                Case EnmAccion.Nuevo
                    'LISTAS DESPLEGABLES======
                    Me.ddlLugar.Visible = False
                    '=========================
                    'CAJA_TEXTO===============
                    Me.txtLugar.Visible = True
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
    'PROPIEDAD PARA EL MANEJO DE DATASET LUGAR
    Private Property pTblLugar As dllSoftSGSST.SGSST.dtsLugar.dtLugarDataTable
        Get
            Return ViewState("pTblLugar")
        End Get
        Set(value As dllSoftSGSST.SGSST.dtsLugar.dtLugarDataTable)
            ViewState("pTblLugar") = value
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub gvLugar_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvLugar.RowCommand
        Select Case e.CommandName
            Case "cmdEliminar"
                Dim varIndex As Integer = 0
                Dim varIdTabla As Integer = 0
                Dim drRow As dllSoftSGSST.SGSST.dtsLugar.dtLugarRow
                varIndex = e.CommandArgument


                varIdTabla = gvLugar.DataKeys(varIndex).Values("tmpIdTabla")
                drRow = Me.pTblLugar.FindBytmpIdTabla(varIdTabla)

                If (drRow.tmpIdRel <> 0) Then
                    'ENVIA A ACTUALIZAR RELACION 
                    Me.ActEstRelLugarXPeligro(drRow.tmpIdRel, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Inactivo)

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
                Me.ActualizarGrillaLugares()
        End Select
    End Sub
    Protected Sub ibtnAgregar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAgregar.Click
        If (Me.PermiteAgregar()) Then
            'SE AGREGA EL LUGAR
            Me.AgregarLugar(Me.ddlLugar.SelectedValue, Me.ddlLugar.SelectedItem.Text)
        End If
    End Sub
    Protected Sub ibtnIncluir_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnIncluir.Click
        'ELIMINA LA SELECCION
        If (Me.ddlLugar.Items.Count > 0) Then
            Me.ddlLugar.SelectedValue = 0
        End If

        'MODIFICA_VISUALIZACION
        Me.pVisualizaXAccion = EnmAccion.Nuevo
    End Sub
    Protected Sub ibtnGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnGuardar.Click
        Dim varIdLugar As Integer = 0

        If (Me.PermiteGuardar()) Then
            'ENVIA A GUARDAR
            varIdLugar = Me.GuardarLugar()

            If (Me.varBoolGuardoLugar) Then
                Me.SuccessLog("Se guardó correctamente.")

                'SE LIMPIA EL CTR LUGAR
                Me.LimpiarCtrLugar()

                'SE CARGA LA INFORMACION DE LUGARES
                Me.CargarLugares()

                'VALIDA SI CARGA LA SELECCION
                If Not (Me.ddlLugar.Items.FindByValue(varIdLugar) Is Nothing) Then
                    Me.ddlLugar.SelectedValue = varIdLugar
                Else
                    Me.ddlLugar.SelectedValue = 0
                End If

                'MODIFICA VISUALIZACION
                Me.pVisualizaXAccion = EnmAccion.SelLugar

            End If
        End If
    End Sub
    Protected Sub ibtnCerrar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCerrar.Click
        'SE LIMPIA EL CTR LUGAR
        Me.LimpiarCtrLugar()

        'MODIFICA VISUALIZACION
        Me.pVisualizaXAccion = EnmAccion.SelLugar
    End Sub
#End Region
#Region "PRIVADO"
    Private Sub CargarLugares()
        Dim objLugar As New dllSoftSGSST.SGSST.clSgsstLugar

        Me.CargarListaDesplegable(Me.ddlLugar, objLugar.GetTblInfoLugarXIdEst(Me.pIdEmpresa, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo), "sglIdLugar", "sglNombre")
    End Sub
    Private Function EsLugarYaRelacionado(ByVal parIdLugar As Integer) As Boolean
        For Each dtsRow As dllSoftSGSST.SGSST.dtsLugar.dtLugarRow In Me.pTblLugar.Rows
            If (parIdLugar = dtsRow.tmpIdLugar) Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function PermiteAgregar() As Boolean
        Dim objMsjRtnValida As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        If (Me.ddlLugar.SelectedValue = 0) Then
            objMsjRtnValida.AgregarMensaje("Debe seleccionar un lugar.", True)
            objMsjRtnValida.pBoolRtn = False

        ElseIf (Me.EsLugarYaRelacionado(Me.ddlLugar.SelectedValue)) Then
            objMsjRtnValida.AgregarMensaje("El lugar seleccionado ya se encuentra relacionado.", True)
            objMsjRtnValida.pBoolRtn = False

        End If

        If Not objMsjRtnValida.pBoolRtn Then
            Me.AlertDialog(objMsjRtnValida.GetMensajeValidacion())
        End If

        Return objMsjRtnValida.pBoolRtn
    End Function
    Private Sub ActualizarGrillaLugares()
        Me.gvLugar.DataSource = Me.pTblLugar
        Me.gvLugar.DataBind()

        If (Me.gvLugar.Rows.Count > 0) Then
            Me.pnlGvLugar.Visible = True
        Else
            Me.pnlGvLugar.Visible = False
        End If
    End Sub
    Private Sub AgregarLugar(ByVal parIdLugar As Integer, ByVal parNomLugar As String)
        Me.pTblLugar.AdddtLugarRow(0,
                                    parIdLugar,
                                    parNomLugar,
                                    1)

        Me.ActualizarGrillaLugares()
    End Sub
    Private Sub ActEstRelLugarXPeligro(ByVal parIRelLugarXPeligro As Integer, ByVal parIdEstado As Integer)
        Dim objRelLugarXPeligro As New dllSoftSGSST.SGSST.clSgsstRelLugarXPeligro
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion
        Try
            objTrans.trCrearTransaccion()

            objRelLugarXPeligro.ActInfoEstRelLugarXPeligroXIdRel(parIRelLugarXPeligro, Me.pIdRelUsuXEmp, parIdEstado, objTrans.trTransaccion)

            Me.varBoolActEstRel = True
            objTrans.trConfirmarTransaccion()
        Catch ex As Exception
            Me.varBoolActEstRel = False
            objTrans.trRollBackTransaccion()
            Me.FailureLog("Error al intentar guardar información de Relación Lugar - Peligro " & ex.Message)
        End Try
    End Sub
    Private Function PermiteGuardar() As Boolean
        Dim objMsjRtnValida As New dllSoftSGSST.Estructura.EstructuraMsjValidacion

        'VALIDA INGRESO DE LUGAR
        If (Trim(Me.txtLugar.Text).Length = 0) Then
            objMsjRtnValida.AgregarMensaje("Debe ingresar lugar.", True)
        End If

        If Not (objMsjRtnValida.pBoolRtn) Then
            Me.AlertDialog(objMsjRtnValida.GetMensajeValidacion())
        End If

        Return objMsjRtnValida.pBoolRtn
    End Function
    Private Function GuardarLugar() As Integer
        Dim objLugar As New dllSoftSGSST.SGSST.clSgsstLugar
        Dim objTrans As New dllSoftSGSST.Estructura.EstructuraTransaccion
        Dim varIdLugar As Integer = 0
        Try
            objTrans.trCrearTransaccion()

            objLugar.sglIdLugar = 0
            objLugar.sglIdEmpresa = Me.pIdEmpresa
            objLugar.sglNombre = Trim(Me.txtLugar.Text)
            objLugar.sglIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo

            objLugar.GuardarInfoLugar(Me.pIdRelUsuXEmp, objTrans.trTransaccion)

            Me.varBoolGuardoLugar = True
            objTrans.trConfirmarTransaccion()

            varIdLugar = objLugar.sglIdLugar
        Catch ex As Exception
            Me.varBoolGuardoLugar = False
            objTrans.trRollBackTransaccion()
            Me.FailureLog("Error al intentar guardar lugar: " & ex.Message)
        End Try

        Return varIdLugar
    End Function
#End Region
#Region "PUBLICO"
    Public Function SeleccionoLugar() As Boolean
        If (Me.gvLugar.Rows.Count > 0) Then
            Return True
        Else Return False
        End If
    End Function
    Public Sub GuardarInfo(ByVal parObjTrans As System.Data.Common.DbTransaction)
        Dim objRelLugarXPeligro As New dllSoftSGSST.SGSST.clSgsstRelLugarXPeligro

        For Each drRow As dllSoftSGSST.SGSST.dtsLugar.dtLugarRow In Me.pTblLugar.Rows
            objRelLugarXPeligro.srlpIdRelLugarXPeligro = drRow.tmpIdRel
            objRelLugarXPeligro.srlpIdPeligro = Me.pIdPeligro
            objRelLugarXPeligro.srlpIdLugar = drRow.tmpIdLugar
            objRelLugarXPeligro.srlpIdEstado = dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo


            objRelLugarXPeligro.GuardarInfoRelLugarXPeligro(Me.pIdRelUsuXEmp, parObjTrans)
        Next
    End Sub
    Public Sub CargarInfoXPeligro()
        Dim objLugar As New dllSoftSGSST.SGSST.clSgsstLugar
        Dim dtDatos As New Data.DataTable

        Me.pTblLugar = New dllSoftSGSST.SGSST.dtsLugar.dtLugarDataTable

        'SE CARGA LA INFORMACION DE LUGAR POR PELIGRO
        dtDatos = objLugar.GetTblInfoLugarXIdPeligro(Me.pIdPeligro, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

        For Each drRow As DataRow In dtDatos.Rows
            Me.pTblLugar.AdddtLugarRow(drRow("srlpIdRelLugarXPeligro"),
                                           drRow("sglIdLugar"),
                                           drRow("sglNombre"),
                                           drRow("sglIdEstado"))
        Next

        'SE ACTUALIZA LA GRILLA
        Me.ActualizarGrillaLugares()
    End Sub
    Public Sub LimpiarCtrLugar()
        Me.txtLugar.Text = ""
    End Sub
#End Region
End Class