Public Class ctrFecha
    Inherits dllSoftSGSST.Estructura.EstructuraControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'CAMBIAR FORMATO TRAIDO DE LA BASE DE DATOS
            Me.txtFecha_CalExt.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern
            'Me.rvFechaReq.InitialValue = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern
            Me.txtFecha_TxtBWE.WatermarkText = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern

            'SE ESTABLECE EL FORMATO DE FECHA MANEJADO POR EL CONTROL DE FECHA TOMADO DE LA CONFIGURACION RELIZADA EN ARHCIVO GLOBAL.ASAX
            Me.txtFecha_CalExt.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern
            Me.txtFecha_TxtBWE.WatermarkText = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern
            'Me.rvFechaReq.InitialValue = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern

            'SE ESTABLECEN LOS RANGOS MINIMOS Y MAXIMOS
            Dim formatDate As String = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern
        End If
    End Sub
    Public Event evtSelFecha()
#Region "PROPIEDADES"
    Public Property pReadOnly() As Boolean
        Get
            Return Me.txtFecha.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me.txtFecha.Enabled = value
        End Set
    End Property
    'Public Property pValidationGroup() As String
    '    Get
    '        Return Me._pValidationGroup
    '    End Get
    '    Set(ByVal value As String)
    '        Me._pValidationGroup = value
    '        Me.cvFechaRango.ValidationGroup = value
    '        Me.rvFechaRango.ValidationGroup = value
    '        Me.rvFechaReq.ValidationGroup = value
    '    End Set
    'End Property
    'Public Property pFechaMinima() As Date
    '    Get
    '        Return ViewState("pFechaMinima")
    '        'Me.rvFechaRango.MinimumValue()
    '    End Get
    '    Set(ByVal value As Date)
    '        'Me.rvFechaRango.MinimumValue = value
    '        ViewState("pFechaMinima") = value
    '    End Set
    'End Property
    'Public Property pFechaMaxima() As Date
    '    Get
    '        Return ViewState("pFechaMaxima")
    '        'Return Me.rvFechaRango.MaximumValue
    '    End Get
    '    Set(ByVal value As Date)
    '        'Me.rvFechaRango.MaximumValue = value
    '        ViewState("pFechaMaxima") = value
    '    End Set
    'End Property
    Public Property pAutopostback() As Boolean
        Get
            Return Me.txtFecha.AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            Me.txtFecha.AutoPostBack = value
        End Set
    End Property
    Public Property pBooSoloLectura() As Boolean
        Get
            Return Me.txtFecha.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me.txtFecha.Enabled = Not value
        End Set
    End Property
    Public Property pTabIndexFch As Integer
        Get
            Return Me.txtFecha.TabIndex
        End Get
        Set(value As Integer)
            Me.txtFecha.TabIndex = value
        End Set
    End Property
    'Public Property pFecha() As Date
    '    Get
    '        Return Date.ParseExact(Me.txtFecha.Text, "yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
    '    End Get
    '    Set(ByVal value As Date)
    '        Me.txtFecha.Text = value.ToString("yyyy/MM/dd")
    '    End Set
    'End Property
    Public gfecha As Date
    Public Property pFecha() As Date
        Get
            If Me.pBooEsFecha Then
                Return gFecha
            Else
                Return Date.Now
            End If
        End Get
        Set(ByVal value As Date)
            'CAMBIAR FORMATO DE LA BASE DE DATOS
            Me.txtFecha.Text = value.ToString(System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern)
            'Me.txtFecha.Text = value.ToString(System.Threading.Thread.CurrentThread.CurrentCulture.CultureTypes.SpecificCultures.Equals(""))
        End Set
    End Property
    'Public Property pBooFchObliga() As Boolean
    '    Get
    '        Return Me.rvFechaReq.Visible
    '    End Get
    '    Set(value As Boolean)
    '        Me.rvFechaReq.Visible = value
    '    End Set
    'End Property

#End Region
#Region "PROTEGIDO"
    'Protected Sub esValidoRangoFecha(ByVal source As Object, ByVal args As ServerValidateEventArgs) Handles cvFechaRango.ServerValidate
    '    Dim fchTemp As Date

    '    If (Date.TryParse(args.Value, fchTemp) AndAlso fchTemp <= Me.pFechaMaxima AndAlso fchTemp >= Me.pFechaMinima) Then
    '        args.IsValid = True
    '    Else
    '        args.IsValid = False
    '    End If
    'End Sub
#End Region
#Region "PRIVADO"
    Protected Sub txtFecha_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.TextChanged
        RaiseEvent evtSelFecha()
    End Sub
#End Region
#Region "PUBLICO"
    'Public Function pBooEsFecha() As Boolean
    '    Return IsDate(Me.txtFecha.Text)
    'End Function
    Public Function pBooEsFecha() As Boolean
        Dim varCulture As New System.Globalization.CultureInfo("en-US")
        'CAMBIAR FORMATO DE LA BASE DE DATOS EN System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePatter SE REEMPLAZA POR FORMATO "YYYY/MM/DDD"
        'reeemplazo System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat por varCulture
        Return Date.TryParseExact(Me.txtFecha.Text, _
                                      System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern, _
                                       System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat, _
                                       System.Globalization.DateTimeStyles.None, gfecha)
        'Return IsDate(Me.txtFecha.Text)
    End Function

    Dim _pValidationGroup As String
    Public Sub LimpiarControl()
        Me.txtFecha.Text = ""
    End Sub
#End Region
End Class