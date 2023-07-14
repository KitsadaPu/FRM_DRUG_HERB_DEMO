Public Class CLASS_DALCN_PLAN
    Inherits CLASS_CENTER
    Public DALCN_PLAN As New DALCN_CONSIDER_TRANSLATION
    'Public DALCN_PHR_ADDR_BSN As New DALCN_PHR_ADDR_BSN
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

#Region "TABLE_CHK"
    Private _DT1_1 As DataTable
    Public Property DT1_1() As DataTable
        Get
            Return _DT1_1
        End Get
        Set(ByVal value As DataTable)
            _DT1_1 = value
        End Set
    End Property
    Private _DT1_2 As DataTable
    Public Property DT1_2() As DataTable
        Get
            Return _DT1_2
        End Get
        Set(ByVal value As DataTable)
            _DT1_2 = value
        End Set
    End Property
    Private _DT1_3 As DataTable
    Public Property DT1_3() As DataTable
        Get
            Return _DT1_3
        End Get
        Set(ByVal value As DataTable)
            _DT1_3 = value
        End Set
    End Property
    Private _DT1_4 As DataTable
    Public Property DT1_4() As DataTable
        Get
            Return _DT1_4
        End Get
        Set(ByVal value As DataTable)
            _DT1_4 = value
        End Set
    End Property
#End Region


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
    Private _CNSDATE_FULL_TH As String
    Public Property CNSDATE_FULL_TH() As String
        Get
            Return _CNSDATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _CNSDATE_FULL_TH = value
        End Set
    End Property
End Class