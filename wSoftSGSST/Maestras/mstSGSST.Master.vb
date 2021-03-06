﻿Public Class mstSGSST
    Inherits dllSoftSGSST.Estructura.EstructuraPaginaMaestra

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
        End If

        Me.CargarMenu()
    End Sub
#Region "PRIVADO"
    Private Sub CargarMenu()
        Dim objModulo As New dllSoftSGSST.Sistema.clSisModulo
        Dim objPagina As New dllSoftSGSST.Sistema.clSisPagina
        Dim dtDatosModulo As New Data.DataTable
        Dim dtDatosPagina As New Data.DataTable

        Dim strBuilder As New StringBuilder()
        Dim strBuilderGral As New StringBuilder()
        Dim strBuilderPag As New StringBuilder()
        Dim indexMod As Integer = 0

        strBuilder.Append("[")
        'SE CARGAN LOS MODULOS DE ACCESO
        dtDatosModulo = objModulo.GetTblModuloXIdRelUsuEmp(Me.pIdRelUsuXEmp)

        For Each drModuloRow As DataRow In dtDatosModulo.Rows
            strBuilder.Append(" {")
            strBuilder.AppendFormat("text: '<img src={0}{1}{0}/>',", Chr(34), New System.Uri(Context.Request.Url, ResolveUrl(drModuloRow("simoURL"))).ToString)
            strBuilder.AppendFormat("href: '{0}',", ResolveUrl(drModuloRow("simoURLModulo")))

            'SE CARGAN LAS PAGINAS DEL MODULO
            dtDatosPagina = objPagina.GetTblInfoPaginaXIdModYRelUsuEmp(drModuloRow("simoIdModulo"), Me.pIdRelUsuXEmp)
            If (dtDatosPagina.Rows.Count > 0) Then
                strBuilderPag = New StringBuilder()
                strBuilderPag.Append("    nodes: [")

                For Each drPaginaRow As DataRow In dtDatosPagina.Rows
                    strBuilderPag.Append("     {")
                    strBuilderPag.AppendFormat("   text: '<img src={0}{1}{0}/>',", Chr(34), New System.Uri(Context.Request.Url, ResolveUrl(drPaginaRow("sipaURLImagen"))).ToString)
                    strBuilderPag.AppendFormat("   href: '{0}',", ResolveUrl(drPaginaRow("sipaURLPag")))
                    strBuilderPag.Append("   selectable: true")
                    strBuilderPag.Append("     },")
                Next
                'QUITA LA ULTIMA COMA QUE QUEDA RELACIONADA
                strBuilder.Append(strBuilderPag.ToString.Substring(0, strBuilderPag.ToString.Length - 1))
                strBuilder.Append("]")
            End If
            strBuilder.Append(" },")
        Next
        If (strBuilder.ToString.Length > 12) Then
            'QUITA LA ULTIMA COMA QUE QUEDA RELACIONADA
            strBuilderGral.Append(strBuilder.ToString.Substring(0, strBuilder.ToString.Length - 1))
        End If
        strBuilderGral.Append("]")
        ScriptManager.RegisterStartupScript(Me.Page, GetType(Page), "TreeView", "$(document).ready(function(){$('#tree').treeview({ enableLinks: true,showIcon: false, data:" & strBuilderGral.ToString & "});});", True)
    End Sub
#End Region
End Class