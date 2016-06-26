Public Class ctrPaisCiudadDep
    Inherits dllSoftSGSST.Estructura.EstructuraControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
#Region "PROPIEDADES"
    'PROPIEDAD PARA INICIALIZAR EL CONTROL
    Private WriteOnly Property pBoolIniCtr As Boolean
        Set(value As Boolean)
            If value Then

            End If
        End Set
    End Property
    'ENUMERACION PARA EL CONTROL DE ACCIONES A REALIZAR EN EL CONTROL
    Private Enum EnmAccion
        Inicio = 1
    End Enum
    'PROPIEDAD PARA EL MANEJO DE VISUALIZACION DEL CONTROL
    Private WriteOnly Property pVisualizaXAccion As EnmAccion
        Set(value As EnmAccion)
            Select Case value
                Case EnmAccion.Inicio
                    'PANELES=====================
                    Me.pnlCiudad.Visible = False
                    '============================

                    'SE CARGA EL PAIS
                    Me.CargarPais()
            End Select
        End Set
    End Property
#End Region
#Region "PRIVADO"
    Private Sub CargarPais()
        Dim objPais As New dllSoftSGSST.SGSST.clSgsstPais

        Me.CargarListaDesplegable(Me.ddlPais, objPais.GetTblPaisXEstado(Me.pIdEmpresa, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo), "sgpaIdPais", "sgpaNombre")
    End Sub
    Private Sub CargarCiudadXPais(ByVal parIdPais As Integer)
        Dim objCiudad As New dllSoftSGSST.SGST.clSgsstCiudad

        Me.CargarListaDesplegable(Me.ddlCiudad, objCiudad.GetTblInfoCiudadXIdPaisYEst(parIdPais, dllSoftSGSST.Sistema.clSisEstado.EnmEstado.Activo), "sgciIdCiudad", "sgciNombre")
    End Sub
    Protected Sub ddlPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPais.SelectedIndexChanged
        If (Me.ddlPais.SelectedValue <> 0) Then


            'SE CARGAN LAS CIUDADES DEL PAIS
            Me.CargarCiudadXPais(Me.ddlPais.SelectedValue)
        End If
    End Sub
#End Region
End Class