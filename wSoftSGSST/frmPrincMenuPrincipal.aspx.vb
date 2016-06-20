Public Class frmPrincMenuPrincipal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnProfesiograma_Click(sender As Object, e As EventArgs) Handles btnProfesiograma.Click
        Me.Response.Redirect("~/Planear/Profesiograma/frmPlProfesiograma.aspx")
    End Sub

    Protected Sub btnPerfilDemografico_Click(sender As Object, e As EventArgs) Handles btnPerfilDemografico.Click
        Me.Response.Redirect("~/Planear/Profesiograma/frmPlPerfDemografico.aspx")
    End Sub
End Class