﻿Public Class ctrDinaConsObj
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Event evtSelecciono()
#Region "PROPIEDADES"
    'ENUMERACION DE ACCIONES
    Public Enum EnmAccion
        Inicio = 1
    End Enum
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    WriteOnly Property pBoolIniCtr As Boolean
        Set(value As Boolean)
            Me.pVisualizacionXAccion = EnmAccion.Inicio
        End Set
    End Property
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DEL CONTROL
    Public WriteOnly Property pVisualizacionXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'CARGAR CONFIGURACION DEL CONTROL
                    Me.CargarConfigCtr()

                    'OCULTAR LA LISTA DESPLEGABLE Y LA IMAGEN DE REGISTRO VALIDO
                    Me.ddlObj.Visible = False
                    Me.imgRegValido.Visible = False
            End Select
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL ID DE CONFIGURACION DE CONTROL DE BUSQUEDA DINAMICO
    Public Property pIdConfigCtrBusDina As Integer
        Get
            Return ViewState("pIdConfigCtrBusDina")
        End Get
        Set(value As Integer)
            ViewState("pIdConfigCtrBusDina") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL ID DEL ITEM SELECCIONADO
    Public Property pIdSel As Integer
        Get
            Return ViewState("pIdSel")
        End Get
        Set(value As Integer)
            ViewState("pIdSel") = value
        End Set
    End Property
    'PROPIEAD PAR ALMACENAR EL NOMBRE DEL ELEMENTO SELECCIONADO
    Public Property pStrNomSel As String
        Get
            Return ViewState("pStrNomSel")
        End Get
        Set(value As String)
            ViewState("pStrNomSel") = value
        End Set
    End Property

    'PROPIEDAD PARA ALMACENAR EL DICCIONARIO CON LA CONTEXT KEY
    Public Property pContextKey As Dictionary(Of String, String)
        Get
            Return ViewState("pContextKey")
        End Get
        Set(value As Dictionary(Of String, String))
            ViewState("pContextKey") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL METODO QUE BUSCA POR NOMBRE
    Private Property pStrSpBusXNom As String
        Get
            Return ViewState("pStrSpBusXNom")
        End Get
        Set(value As String)
            ViewState("pStrSpBusXNom") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL METODO QUE BUSCA POR ID
    Private Property pStrSpBusXId As String
        Get
            Return ViewState("pStrSpBusXId")
        End Get
        Set(value As String)
            ViewState("pStrSpBusXId") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL VALUE DEL DDL
    Private Property pStrValueDdl As String
        Get
            Return ViewState("pStrValueDdl")
        End Get
        Set(value As String)
            ViewState("pStrValueDdl") = value
        End Set
    End Property
    'PROPIEDAD PARA ALMACENAR EL TXT DEL DDL
    Private Property pStrTxtDdl As String
        Get
            Return ViewState("pStrTxtDdl")
        End Get
        Set(value As String)
            ViewState("pStrTxtDdl") = value
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    'EVENTO DEL TXT
    Protected Sub txtObj_TextChanged(sender As Object, e As EventArgs) Handles txtObj.TextChanged
        If (Trim(Me.txtObj.Text).Length >= Me.AutoCompleteExtender.MinimumPrefixLength) Then
            Me.BuscarXNombre()
        End If
    End Sub
    Protected Sub ddlObj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlObj.SelectedIndexChanged
        If (Trim(Me.txtObj.Text).Length >= Me.AutoCompleteExtender.MinimumPrefixLength) Then
            Me.BuscarXId()
        End If
    End Sub
#End Region
#Region "PRIVADO"
    'FUNCION PARA CARGAR LA CONFIGURACION DEL CONTROL
    Private Sub CargarConfigCtr()
        'INSTANCIA DE LA CLASE DEL CONTROL DE CONFIGURACION DINAMICO
        Dim objConfigCtrDina As New dllSoftSGSST.Sistema.clSisConfigCtrBusDinamico

        objConfigCtrDina.CargarInfoCtrBusDinamicoXId(Me.pIdConfigCtrBusDina)

        'DEFINIR EL NOMBRE DEL CTR
        Me.lblNomObj.Text = objConfigCtrDina.scbdNombre

        'DEFINIR CONFIGURACION DEL AUTOCOMPLETE
        Me.AutoCompleteExtender.ServicePath = objConfigCtrDina.scbdUrlServicio
        Me.AutoCompleteExtender.ServiceMethod = objConfigCtrDina.scbdMetodoServicio
        Me.AutoCompleteExtender.UseContextKey = IIf(objConfigCtrDina.scbdEstUseContextKey = 1, True, False)
        Me.AutoCompleteExtender.MinimumPrefixLength = objConfigCtrDina.scbdMinCaracteres

        Me.pStrSpBusXNom = objConfigCtrDina.scbdMetodoBusXNombre
        Me.pStrSpBusXId = objConfigCtrDina.scbdMetodoBusXId

        Me.pStrValueDdl = objConfigCtrDina.scbdValueDdl
        Me.pStrTxtDdl = objConfigCtrDina.scbdTextoDdl

    End Sub
    'FUNCION PARA BUSCAR EL OBJETO POR NOMBRE
    Private Sub BuscarXNombre()
        'INSTANCIA DE LA CLASE DEL CONTROL DE CONFIGURACION DINAMICO
        Dim objConfigCtrDina As New dllSoftSGSST.Sistema.clSisConfigCtrBusDinamico
        Dim dtDatos As New DataTable
        dtDatos = objConfigCtrDina.BusXNom(Me.pStrSpBusXNom, Trim(Me.txtObj.Text), dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo)

        If (dtDatos.Rows.Count = 1) Then
            'DEFINIR EL OBJETO ENCONTRADO
            Me.pIdSel = dtDatos.Rows(0)(Me.pStrValueDdl)
            Me.pStrNomSel = dtDatos.Rows(0)(Me.pStrTxtDdl)
            Me.txtObj.Text = dtDatos.Rows(0)(Me.pStrTxtDdl)
            Me.txtObj.ToolTip = dtDatos.Rows(0)(Me.pStrTxtDdl)

            Me.imgRegValido.Visible = True
            Me.ddlObj.Visible = False

            RaiseEvent evtSelecciono()

        ElseIf (dtDatos.Rows.Count > 1) Then
            'DEFINIR EL OBJETO ENCONTRADO
            Me.pIdSel = 0
            Me.pStrNomSel = ""
            Me.txtObj.ToolTip = ""

            'LLENAR EL DDL CON LA LISTA ENCONTRADA
            Me.CargarListaDesplegable(Me.ddlObj, dtDatos, objConfigCtrDina.scbdValueDdl, objConfigCtrDina.scbdTextoDdl)

            'OCULTAR EL TXT
            Me.txtObj.Visible = False

        ElseIf (dtDatos.Rows.Count = 0) Then
            'DEFINIR PARAMETROS
            Me.pIdSel = 0
            Me.pStrNomSel = ""
            Me.txtObj.ToolTip = ""
        End If

    End Sub
    'FUNCION PARA BUSCAR EL OBJETO X ID
    Private Sub BuscarXId()
        'INSTANCIA DE LA CLASE DEL CONTROL DE CONFIGURACION DINAMICO
        Dim objConfigCtrDina As New dllSoftSGSST.Sistema.clSisConfigCtrBusDinamico
        Dim dtDatos As New DataTable
        dtDatos = objConfigCtrDina.BusXId(Me.pStrSpBusXId, Me.ddlObj.SelectedValue)

        If (dtDatos.Rows.Count <> 0) Then
            'DEFINIR EL OBJETO ENCONTRADO
            Me.pIdSel = dtDatos.Rows(0)(Me.pStrValueDdl)
            Me.pStrNomSel = dtDatos.Rows(0)(Me.pStrTxtDdl)
            Me.txtObj.Text = dtDatos.Rows(0)(Me.pStrTxtDdl)
            Me.txtObj.ToolTip = dtDatos.Rows(0)(Me.pStrTxtDdl)

            Me.imgRegValido.Visible = True
            Me.ddlObj.Visible = False
        End If
    End Sub
#End Region
End Class