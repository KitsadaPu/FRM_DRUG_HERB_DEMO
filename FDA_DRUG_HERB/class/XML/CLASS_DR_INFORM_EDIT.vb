Public Class CLASS_DR_INFORM_EDIT
    Inherits CLASS_CENTER
    Public TABEAN_INFORM_EDIT As New TABEAN_INFORM_EDIT
    Public TABEAN_INFORM_EDIT_CHECK As New TABEAN_INFORM_EDIT_CHECK_LIST

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

    Private _NAME_THAI_OLD As String
    Public Property NAME_THAI_OLD() As String
        Get
            Return _NAME_THAI_OLD
        End Get
        Set(ByVal value As String)
            _NAME_THAI_OLD = value
        End Set
    End Property
    Private _NAME_ENG_OLD As String
    Public Property NAME_ENG_OLD() As String
        Get
            Return _NAME_ENG_OLD
        End Get
        Set(ByVal value As String)
            _NAME_ENG_OLD = value
        End Set
    End Property
    Private _LOCATION_OLD As String
    Public Property LOCATION_OLD() As String
        Get
            Return _LOCATION_OLD
        End Get
        Set(ByVal value As String)
            _LOCATION_OLD = value
        End Set
    End Property
    Private _PACKING_OLD As String
    Public Property PACKING_OLD() As String
        Get
            Return _PACKING_OLD
        End Get
        Set(ByVal value As String)
            _PACKING_OLD = value
        End Set
    End Property
    Private _LABEL_OLD As String
    Public Property LABEL_OLD() As String
        Get
            Return _LABEL_OLD
        End Get
        Set(ByVal value As String)
            _LABEL_OLD = value
        End Set
    End Property
    Private _LABEL_NEW As String
    Public Property LABEL_NEW() As String
        Get
            Return _LABEL_NEW
        End Get
        Set(ByVal value As String)
            _LABEL_NEW = value
        End Set
    End Property
    Private _DOCUMENT_NEW As String
    Public Property DOCUMENT_NEW() As String
        Get
            Return _DOCUMENT_NEW
        End Get
        Set(ByVal value As String)
            _DOCUMENT_NEW = value
        End Set
    End Property
    Private _DOCUMENT_OLD As String
    Public Property DOCUMENT_OLD() As String
        Get
            Return _DOCUMENT_OLD
        End Get
        Set(ByVal value As String)
            _DOCUMENT_OLD = value
        End Set
    End Property
    Private _HOWUSE_OLD As String
    Public Property HOWUSE_OLD() As String
        Get
            Return _HOWUSE_OLD
        End Get
        Set(ByVal value As String)
            _HOWUSE_OLD = value
        End Set
    End Property
    Private _EATTING_OLD As String
    Public Property EATTING_OLD() As String
        Get
            Return _EATTING_OLD
        End Get
        Set(ByVal value As String)
            _EATTING_OLD = value
        End Set
    End Property
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
End Class
