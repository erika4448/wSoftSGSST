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
        End Select

        Me.upnlMatrizRiesgos.Update()
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