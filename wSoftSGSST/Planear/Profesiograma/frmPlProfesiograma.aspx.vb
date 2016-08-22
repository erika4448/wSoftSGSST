Public Class frmPlProfesiograma
    Inherits dllSoftSGSST.Estructura.EstructuraPagina

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            Me.pBoolIniPagina = True
        End If
    End Sub
#Region "PROPIEDADES"
    'ENUMERACION DE ACCIONES DEL CONTROL
    Public Enum EnmAccion
        Inicio = 1
    End Enum
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    Public WriteOnly Property pBoolIniPagina As Boolean
        Set(value As Boolean)
            Me.pVisualizacionXAccion = EnmAccion.Inicio
        End Set
    End Property
    'PROPIEDAD PARA EL MANJO DE LA VISUALIZACION DEL CONTROL
    Private WriteOnly Property pVisualizacionXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'MANEJO DE PANELES
                    Me.pnlCtrProfesiograma.Visible = True

                    'INICIALIZAR EL CONTROL DE PROFESIOGRAMA
                    Me.ctrProfesiograma.pBoolIniCtr = True

            End Select
        End Set
    End Property
#End Region
#Region "PROTEGIDO"

#End Region
#Region "PRIVADO"
#End Region
#Region "PUBLICO"

#End Region
End Class