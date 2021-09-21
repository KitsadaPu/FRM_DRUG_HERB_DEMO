Public Class CLS_TABEAN_HERB_JJ
    Inherits CLASS_CENTER

#Region "SHOW"
    Private _DT_SHOW As New CLS_SHOW
    Public Property DT_SHOW() As CLS_SHOW
        Get
            Return _DT_SHOW
        End Get
        Set(ByVal value As CLS_SHOW)
            _DT_SHOW = value
        End Set
    End Property
#End Region

#Region "MASTER"
    Private _DT_MASTER As New CLS_MASTER
    Public Property DT_MASTER() As CLS_MASTER
        Get
            Return _DT_MASTER
        End Get
        Set(ByVal value As CLS_MASTER)
            _DT_MASTER = value
        End Set
    End Property
#End Region

    Private _TABEAN_JJ As New TABEAN_JJ
    Public Property TABEAN_JJ() As TABEAN_JJ
        Get
            Return _TABEAN_JJ
        End Get
        Set(ByVal value As TABEAN_JJ)
            _TABEAN_JJ = value
        End Set
    End Property

    Private _list_tabean_jj As New List(Of String)
    Public Property list_tabean_jj() As List(Of String)
        Get
            Return _list_tabean_jj
        End Get
        Set(ByVal value As List(Of String))
            _list_tabean_jj = value
        End Set
    End Property

    Private _TABEAN_SUBPACKAGE As New List(Of TABEAN_JJ_SUB_PACKSIZE)
    Public Property TABEAN_SUBPACKAGE() As List(Of TABEAN_JJ_SUB_PACKSIZE)
        Get
            Return _TABEAN_SUBPACKAGE
        End Get
        Set(ByVal value As List(Of TABEAN_JJ_SUB_PACKSIZE))
            _TABEAN_SUBPACKAGE = value
        End Set
    End Property

    Private _list_subpackage As New List(Of String)
    Public Property list_subpackage() As List(Of String)
        Get
            Return _list_subpackage
        End Get
        Set(ByVal value As List(Of String))
            _list_subpackage = value
        End Set
    End Property

    Private _date_approve_day As String
    Public Property date_approve_day() As String
        Get
            Return _date_approve_day
        End Get
        Set(ByVal value As String)
            _date_approve_day = value
        End Set
    End Property

    Private _date_approve_month As String
    Public Property date_approve_month() As String
        Get
            Return _date_approve_month
        End Get
        Set(ByVal value As String)
            _date_approve_month = value
        End Set
    End Property

    Private _date_approve_year As String
    Public Property date_approve_year() As String
        Get
            Return _date_approve_year
        End Get
        Set(ByVal value As String)
            _date_approve_year = value
        End Set
    End Property

    Private _date_req_day As String
    Public Property date_req_day() As String
        Get
            Return _date_req_day
        End Get
        Set(ByVal value As String)
            _date_req_day = value
        End Set
    End Property

    Private _date_req_month As String
    Public Property date_req_month() As String
        Get
            Return _date_req_month
        End Get
        Set(ByVal value As String)
            _date_req_month = value
        End Set
    End Property

    Private _date_req_year As String
    Public Property date_req_year() As String
        Get
            Return _date_req_year
        End Get
        Set(ByVal value As String)
            _date_req_year = value
        End Set
    End Property

    Private _date_req_full As String
    Public Property date_req_full() As String
        Get
            Return _date_req_full
        End Get
        Set(ByVal value As String)
            _date_req_full = value
        End Set
    End Property

    Private _TYPE_PERSON As String
    Public Property TYPE_PERSON() As String
        Get
            Return _TYPE_PERSON
        End Get
        Set(ByVal value As String)
            _TYPE_PERSON = value
        End Set
    End Property

End Class
