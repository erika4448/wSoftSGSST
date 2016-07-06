Public Class frmPrueba
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.ctrDinaConsObj.pIdConfigCtrBusDina = 1
            Me.ctrDinaConsObj.pBoolIniCtr = True
        End If
    End Sub

End Class