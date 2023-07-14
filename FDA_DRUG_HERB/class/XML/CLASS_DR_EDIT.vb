Public Class CLASS_DR_EDIT
    Inherits CLASS_CENTER
    Public TABEAN_HERB_EDIT_REQUEST As New TABEAN_HERB_EDIT_REQUEST
    Public DRRGT_EDIT_REQUESTs As New DRRGT_EDIT_REQUEST

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

    '#Region "drrgt_edit_request"
    '    Private _DRRGT_EDIT_REQUESTs As New List(Of DRRGT_EDIT_REQUEST)
    '    Public Property DRRGT_EDIT_REQUESTs As List(Of DRRGT_EDIT_REQUEST)
    '        Get
    '            Return _DRRGT_EDIT_REQUESTs
    '        End Get
    '        Set(ByVal Value As List(Of DRRGT_EDIT_REQUEST))
    '            _DRRGT_EDIT_REQUESTs = Value
    '        End Set
    '    End Property
    '#End Region

    Private _RCVDATE_FULL_TH As String
    Public Property RCVDATE_FULL_THAI() As String
        Get
            Return _RCVDATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _RCVDATE_FULL_TH = value
        End Set
    End Property

    Private _WRITEDATE_FULL_TH As String
    Public Property WRITEDATE_FULL_THAI() As String
        Get
            Return _WRITEDATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _WRITEDATE_FULL_TH = value
        End Set
    End Property
    Private _APPDATE_FULL_TH As String
    Public Property APPDATE_FULL_THAI() As String
        Get
            Return _APPDATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _APPDATE_FULL_TH = value
        End Set
    End Property
    Private _BSN_THAINAME As String
    Public Property BSN_THAINAME() As String
        Get
            Return _BSN_THAINAME
        End Get
        Set(ByVal value As String)
            _BSN_THAINAME = value
        End Set
    End Property
    Private _THANM_THAIFULLNAME As String
    Public Property THANM_THAIFULLNAME() As String
        Get
            Return _THANM_THAIFULLNAME
        End Get
        Set(ByVal value As String)
            _THANM_THAIFULLNAME = value
        End Set
    End Property
    Private _RCVNO_FORMAT As String
    Public Property RCVNO_FORMAT() As String
        Get
            Return _RCVNO_FORMAT
        End Get
        Set(ByVal value As String)
            _RCVNO_FORMAT = value
        End Set
    End Property
    Private _RGTNO_FORMAT As String
    Public Property RGTNO_FORMAT() As String
        Get
            Return _RGTNO_FORMAT
        End Get
        Set(ByVal value As String)
            _RGTNO_FORMAT = value
        End Set
    End Property
    Private _DRUG_NAME As String
    Public Property DRUG_NAME() As String
        Get
            Return _DRUG_NAME
        End Get
        Set(ByVal value As String)
            _DRUG_NAME = value
        End Set
    End Property
End Class