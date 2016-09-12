Public Class frmMtRgMatrizRiesgos
    Inherits dllSoftSGSST.Estructura.EstructuraPagina

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'SE INICIALIZA LA PAGINA
            Me.pBoolIniPagina = True
        End If
    End Sub
#Region "PROPIEDADES"
    'PROPIEDAD PARA INICIALIZAR LA PAGINA
    Public WriteOnly Property pBoolIniPagina As Boolean
        Set(value As Boolean)
            If value Then
                'SE INICIALIZA LA VISUALIZACION
                Me.pVisualizaXAccion = EnmAccion.Inicio
            End If
        End Set
    End Property
    'ENUMERACION PARA EL CONTROL DE ACCIONES QUE SE REALIZAN EN LA PAGINA
    Private Enum EnmAccion
        Inicio = 1
    End Enum
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DE LA PAGINA
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'BOTONES=================
                    Me.ibtnEscogerCampos.Visible = True
                    Me.ibtnFiltrosConsulta.Visible = True
                    Me.ibtnMatrizPDF.Visible = True
                    '========================

                    'SE CARGA LA GRILLA DE MATRIZ DE PELIGROS
                    Me.CargarGrillaMatrizPeligros()
            End Select
        End Set
    End Property
#End Region
#Region "PROTEGIDO"
    Protected Sub gvMatrizRiesgos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvMatrizRiesgos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then


            Select Case e.Row.DataItem("snrIdNivelRiesgo")
                Case 0
                    e.Row.Cells(6).ForeColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Black)
                    e.Row.Cells(6).BackColor = Nothing

                Case 1
                    e.Row.Cells(6).ForeColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.White)
                    e.Row.Cells(6).BackColor = Drawing.Color.FromArgb(217, 0, 0)

                Case 2
                    e.Row.Cells(6).ForeColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.White)
                    e.Row.Cells(6).BackColor = Drawing.Color.FromArgb(255, 128, 0)

                Case 3
                    e.Row.Cells(6).ForeColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.White)
                    e.Row.Cells(6).BackColor = Drawing.Color.FromArgb(70, 140, 0)

                Case 4
                    e.Row.Cells(6).ForeColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Black)
                    e.Row.Cells(6).BackColor = Drawing.Color.FromArgb(255, 255, 255)
            End Select
        End If
        Me.upnlMatrizRiesgos.Update()
    End Sub
    Protected Sub gvMatrizRiesgos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvMatrizRiesgos.RowCommand
        Select Case e.CommandName
            Case "cmdCalificar"
                Dim varIdPeligro As Integer = 0
                Dim varStrURL As String = ""

                varIdPeligro = Me.gvMatrizRiesgos.DataKeys(e.CommandArgument).Values("sgplIdPeligro")

                If (varIdPeligro <> 0) Then
                    varStrURL = New System.Uri(Context.Request.Url, ResolveUrl("~/Planear/MatrizRiesgos/frmMtRgCalificarRiesgo.aspx?PIP=" & varIdPeligro)).ToString
                    Me.Response.Redirect(varStrURL)
                End If

            Case "cmdMedidas"
                Dim varIdPeligro As Integer = 0

                varIdPeligro = Me.gvMatrizRiesgos.DataKeys(e.CommandArgument).Values("sgplIdPeligro")

                'INICIALIZA CONTROL DE MEDIDAS INTERVENCION
                Me.ctrMtRsMedIntervencion1.pIdPeligro = varIdPeligro
                Me.ctrMtRsMedIntervencion1.pBoolIniCtr = True
                Me.ctrMtRsMedIntervencion1.pBoolPermiteEditar = False

                'SE CARGA LA INFORMACION DE PELIGRO
                Me.CargarInfoPeligro(varIdPeligro)

                Me.modalInfoMedIntervencion.Show()
                Me.upnlInfoMedIntervencion.Update()
        End Select

        Me.upnlMatrizRiesgos.Update()
    End Sub
    Protected Sub ibtnCerrarMedIntervencion_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnCerrarMedIntervencion.Click
        Me.modalInfoMedIntervencion.Hide()
        Me.upnlInfoMedIntervencion.Update()
        Me.upnlMatrizRiesgos.Update()
    End Sub
#End Region
#Region "PRIVADO"
    Private Sub CargarInfoPeligro(ByVal parIdPeligro As Integer)
        Dim objPeligro As New dllSoftSGSST.SGSST.clSgsstPeligro
        Dim dtDatosPeligro As New Data.DataTable

        'SE CARGA LA INFORMACION DEL PELIGRO
        dtDatosPeligro = objPeligro.CargarInfoPeligroXIdPeligro(parIdPeligro)

        If (dtDatosPeligro.Rows.Count > 0) Then
            'INFORMACION BASICA QUE SE MUESTRA EN LAS VENTANAS MODALES
            Me.lblDescPeligro.Text = dtDatosPeligro.Rows(0)("StrDescripcion")
            Me.lblClasiPeligro.Text = dtDatosPeligro.Rows(0)("StrClasificacion")
            Me.lblEvalPeligro.Text = dtDatosPeligro.Rows(0)("tmpNivelRiesgo")
            Me.lblNumExpuestos.Text = dtDatosPeligro.Rows(0)("sgplCriCtrNumExpuestos")
            Me.lblPeorConsec.Text = dtDatosPeligro.Rows(0)("sgplCriCtrPeorConsec")
            Me.lblReqLegal.Text = dtDatosPeligro.Rows(0)("StrReqLegal")
        End If
    End Sub
#End Region
#Region "DATA SOURCE GRILLA MATRIZ PELIGROS"
    Public Sub CargarGrillaMatrizPeligros()
        Me.gvMatrizRiesgos.PageSize = Me.ddlNumPagMatrizRiesgos.SelectedValue
        Me.gvMatrizRiesgos.DataBind()

        If (Me.gvMatrizRiesgos.Rows.Count > 0) Then
            Me.pnlMatrizRiesgos.Visible = True
            Me.ddlNumPagMatrizRiesgos.Visible = True
        Else
            Me.pnlMatrizRiesgos.Visible = False
            Me.ddlNumPagMatrizRiesgos.Visible = False
        End If
    End Sub
    Protected Sub odsMatrizRiesgos_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsMatrizRiesgos.Selecting
        e.InputParameters("parIdEmpresa") = Me.pIdEmpresa
    End Sub
    Protected Sub ddlNumPagMatrizRiesgos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlNumPagMatrizRiesgos.SelectedIndexChanged
        Me.gvMatrizRiesgos.PageSize = Me.ddlNumPagMatrizRiesgos.SelectedValue
        Me.gvMatrizRiesgos.DataBind()
    End Sub
    Protected Sub odsMatrizRiesgos_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles odsMatrizRiesgos.Selected
        Me.gvMatrizRiesgos.Visible = True
    End Sub
    Protected Sub odsMatrizRiesgos_ObjectCreating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceEventArgs) Handles odsMatrizRiesgos.ObjectCreating
        e.ObjectInstance = New dllSoftSGSST.SGSST.clSgsstPeligro
    End Sub
#End Region
End Class