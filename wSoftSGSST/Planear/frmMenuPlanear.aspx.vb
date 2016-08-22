Public Class frmMenuPlanear
    Inherits dllSoftSGSST.Estructura.EstructuraPagina

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'SE CARGA EL PORCENTAJE DE AVANCE DE CDA PAGINA DEL MODULO PLANEAR
            Me.CargarProcentajesMenuPlanear()
        End If
    End Sub
#Region "PRIVADO"
    Private Sub CargarProcentajesMenuPlanear()
        Dim objPagina As New dllSoftSGSST.Sistema.clSisPagina
        Dim dtDatos As New Data.DataSet

        dtDatos = objPagina.CargarPorcAvanceMenuPlanear(Me.pIdEmpresa)

        If (dtDatos.Tables.Count > 0) Then
            'VALIDA PORCENTAJE AVANCE PAGINA PROFESIOGRAMA
            Select Case dtDatos.Tables(0).Rows(0)("tmpPorcAvance")
                Case "0"
                    Me.imTotalProfesiograma.ImageUrl = New System.Uri(Context.Request.Url, ResolveUrl("~/Images/ZoomPlanear/imZoomProfesiograma_0.png")).ToString
                Case "100"
                    Me.imTotalProfesiograma.ImageUrl = New System.Uri(Context.Request.Url, ResolveUrl("~/Images/ZoomPlanear/imZoomProfesiograma_100.png")).ToString
            End Select

            'VALIDA PORCENTAJE AVANCE PAGINA PERFIL DEMOGRAFICO
            Select Case dtDatos.Tables(1).Rows(0)("tmpPorcAvance")
                Case "0"
                    Me.imTotalPerfilSocioDemografico.ImageUrl = New System.Uri(Context.Request.Url, ResolveUrl("~/Images/ZoomPlanear/imZoomPerfilSocioDemografico_0.png")).ToString
                Case "100"
                    Me.imTotalPerfilSocioDemografico.ImageUrl = New System.Uri(Context.Request.Url, ResolveUrl("~/Images/ZoomPlanear/imZoomPerfilSocioDemografico_100.png")).ToString
            End Select

            'VALIDA PORCENTAJE AVANCE PAGINA MATRIZ RIESGOS
            Select Case dtDatos.Tables(2).Rows(0)("tmpPorcAvance")
                Case "0"
                    Me.imTotalMatrizRiesgos.ImageUrl = New System.Uri(Context.Request.Url, ResolveUrl("~/Images/ZoomPlanear/imZoomMatrizRiesgos_0.png")).ToString
                Case "100"
                    Me.imTotalMatrizRiesgos.ImageUrl = New System.Uri(Context.Request.Url, ResolveUrl("~/Images/ZoomPlanear/imZoomMatrizRiesgos_100.png")).ToString
            End Select
        End If
    End Sub
#End Region
End Class