﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="FDA_XML_DRUG")>  _
Partial Public Class Linq_DAO_DRUGDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertXML_SEARCH_DRUG_LCN(instance As XML_SEARCH_DRUG_LCN)
    End Sub
  Partial Private Sub UpdateXML_SEARCH_DRUG_LCN(instance As XML_SEARCH_DRUG_LCN)
    End Sub
  Partial Private Sub DeleteXML_SEARCH_DRUG_LCN(instance As XML_SEARCH_DRUG_LCN)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("FDA_XML_DRUGConnectionString").ConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property XML_SEARCH_DRUG_LCNs() As System.Data.Linq.Table(Of XML_SEARCH_DRUG_LCN)
		Get
			Return Me.GetTable(Of XML_SEARCH_DRUG_LCN)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.XML_SEARCH_DRUG_LCN")>  _
Partial Public Class XML_SEARCH_DRUG_LCN
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IDA As Integer
	
	Private _lcnno As String
	
	Private _pvncd As String
	
	Private _lcntpcd As String
	
	Private _lcnsid As String
	
	Private _GROUPNAME As String
	
	Private _CITIZEN_AUTHORIZE As String
	
	Private _Identify As String
	
	Private _lcnno_no As String
	
	Private _lcnno_noo As String
	
	Private _lcnno_not_pvnabbr As String
	
	Private _typee As String
	
	Private _licen As String
	
	Private _licen_addr As String
	
	Private _licen_address As String
	
	Private _licen_time As String
	
	Private _grannm_lo As String
	
	Private _grannm_addr As String
	
	Private _grannm_address As String
	
	Private _thanm As String
	
	Private _thanm_addr As String
	
	Private _thanm_address As String
	
	Private _thaamphrnm As String
	
	Private _thachngwtnm As String
	
	Private _cncnm As String
	
	Private _appdate As String
	
	Private _expyear As String
	
	Private _lmdfdate As String
	
	Private _Newcode_not As String
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIDAChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDAChanged()
    End Sub
    Partial Private Sub OnlcnnoChanging(value As String)
    End Sub
    Partial Private Sub OnlcnnoChanged()
    End Sub
    Partial Private Sub OnpvncdChanging(value As String)
    End Sub
    Partial Private Sub OnpvncdChanged()
    End Sub
    Partial Private Sub OnlcntpcdChanging(value As String)
    End Sub
    Partial Private Sub OnlcntpcdChanged()
    End Sub
    Partial Private Sub OnlcnsidChanging(value As String)
    End Sub
    Partial Private Sub OnlcnsidChanged()
    End Sub
    Partial Private Sub OnGROUPNAMEChanging(value As String)
    End Sub
    Partial Private Sub OnGROUPNAMEChanged()
    End Sub
    Partial Private Sub OnCITIZEN_AUTHORIZEChanging(value As String)
    End Sub
    Partial Private Sub OnCITIZEN_AUTHORIZEChanged()
    End Sub
    Partial Private Sub OnIdentifyChanging(value As String)
    End Sub
    Partial Private Sub OnIdentifyChanged()
    End Sub
    Partial Private Sub Onlcnno_noChanging(value As String)
    End Sub
    Partial Private Sub Onlcnno_noChanged()
    End Sub
    Partial Private Sub Onlcnno_nooChanging(value As String)
    End Sub
    Partial Private Sub Onlcnno_nooChanged()
    End Sub
    Partial Private Sub Onlcnno_not_pvnabbrChanging(value As String)
    End Sub
    Partial Private Sub Onlcnno_not_pvnabbrChanged()
    End Sub
    Partial Private Sub OntypeeChanging(value As String)
    End Sub
    Partial Private Sub OntypeeChanged()
    End Sub
    Partial Private Sub OnlicenChanging(value As String)
    End Sub
    Partial Private Sub OnlicenChanged()
    End Sub
    Partial Private Sub Onlicen_addrChanging(value As String)
    End Sub
    Partial Private Sub Onlicen_addrChanged()
    End Sub
    Partial Private Sub Onlicen_addressChanging(value As String)
    End Sub
    Partial Private Sub Onlicen_addressChanged()
    End Sub
    Partial Private Sub Onlicen_timeChanging(value As String)
    End Sub
    Partial Private Sub Onlicen_timeChanged()
    End Sub
    Partial Private Sub Ongrannm_loChanging(value As String)
    End Sub
    Partial Private Sub Ongrannm_loChanged()
    End Sub
    Partial Private Sub Ongrannm_addrChanging(value As String)
    End Sub
    Partial Private Sub Ongrannm_addrChanged()
    End Sub
    Partial Private Sub Ongrannm_addressChanging(value As String)
    End Sub
    Partial Private Sub Ongrannm_addressChanged()
    End Sub
    Partial Private Sub OnthanmChanging(value As String)
    End Sub
    Partial Private Sub OnthanmChanged()
    End Sub
    Partial Private Sub Onthanm_addrChanging(value As String)
    End Sub
    Partial Private Sub Onthanm_addrChanged()
    End Sub
    Partial Private Sub Onthanm_addressChanging(value As String)
    End Sub
    Partial Private Sub Onthanm_addressChanged()
    End Sub
    Partial Private Sub OnthaamphrnmChanging(value As String)
    End Sub
    Partial Private Sub OnthaamphrnmChanged()
    End Sub
    Partial Private Sub OnthachngwtnmChanging(value As String)
    End Sub
    Partial Private Sub OnthachngwtnmChanged()
    End Sub
    Partial Private Sub OncncnmChanging(value As String)
    End Sub
    Partial Private Sub OncncnmChanged()
    End Sub
    Partial Private Sub OnappdateChanging(value As String)
    End Sub
    Partial Private Sub OnappdateChanged()
    End Sub
    Partial Private Sub OnexpyearChanging(value As String)
    End Sub
    Partial Private Sub OnexpyearChanged()
    End Sub
    Partial Private Sub OnlmdfdateChanging(value As String)
    End Sub
    Partial Private Sub OnlmdfdateChanged()
    End Sub
    Partial Private Sub OnNewcode_notChanging(value As String)
    End Sub
    Partial Private Sub OnNewcode_notChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDA", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property IDA() As Integer
		Get
			Return Me._IDA
		End Get
		Set
			If ((Me._IDA = value)  _
						= false) Then
				Me.OnIDAChanging(value)
				Me.SendPropertyChanging
				Me._IDA = value
				Me.SendPropertyChanged("IDA")
				Me.OnIDAChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnno", DbType:="VarChar(MAX)")>  _
	Public Property lcnno() As String
		Get
			Return Me._lcnno
		End Get
		Set
			If (String.Equals(Me._lcnno, value) = false) Then
				Me.OnlcnnoChanging(value)
				Me.SendPropertyChanging
				Me._lcnno = value
				Me.SendPropertyChanged("lcnno")
				Me.OnlcnnoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_pvncd", DbType:="VarChar(MAX)")>  _
	Public Property pvncd() As String
		Get
			Return Me._pvncd
		End Get
		Set
			If (String.Equals(Me._pvncd, value) = false) Then
				Me.OnpvncdChanging(value)
				Me.SendPropertyChanging
				Me._pvncd = value
				Me.SendPropertyChanged("pvncd")
				Me.OnpvncdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcntpcd", DbType:="VarChar(MAX)")>  _
	Public Property lcntpcd() As String
		Get
			Return Me._lcntpcd
		End Get
		Set
			If (String.Equals(Me._lcntpcd, value) = false) Then
				Me.OnlcntpcdChanging(value)
				Me.SendPropertyChanging
				Me._lcntpcd = value
				Me.SendPropertyChanged("lcntpcd")
				Me.OnlcntpcdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnsid", DbType:="VarChar(MAX)")>  _
	Public Property lcnsid() As String
		Get
			Return Me._lcnsid
		End Get
		Set
			If (String.Equals(Me._lcnsid, value) = false) Then
				Me.OnlcnsidChanging(value)
				Me.SendPropertyChanging
				Me._lcnsid = value
				Me.SendPropertyChanged("lcnsid")
				Me.OnlcnsidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_GROUPNAME", DbType:="VarChar(MAX)")>  _
	Public Property GROUPNAME() As String
		Get
			Return Me._GROUPNAME
		End Get
		Set
			If (String.Equals(Me._GROUPNAME, value) = false) Then
				Me.OnGROUPNAMEChanging(value)
				Me.SendPropertyChanging
				Me._GROUPNAME = value
				Me.SendPropertyChanged("GROUPNAME")
				Me.OnGROUPNAMEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CITIZEN_AUTHORIZE", DbType:="VarChar(MAX)")>  _
	Public Property CITIZEN_AUTHORIZE() As String
		Get
			Return Me._CITIZEN_AUTHORIZE
		End Get
		Set
			If (String.Equals(Me._CITIZEN_AUTHORIZE, value) = false) Then
				Me.OnCITIZEN_AUTHORIZEChanging(value)
				Me.SendPropertyChanging
				Me._CITIZEN_AUTHORIZE = value
				Me.SendPropertyChanged("CITIZEN_AUTHORIZE")
				Me.OnCITIZEN_AUTHORIZEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Identify", DbType:="VarChar(MAX)")>  _
	Public Property Identify() As String
		Get
			Return Me._Identify
		End Get
		Set
			If (String.Equals(Me._Identify, value) = false) Then
				Me.OnIdentifyChanging(value)
				Me.SendPropertyChanging
				Me._Identify = value
				Me.SendPropertyChanged("Identify")
				Me.OnIdentifyChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnno_no", DbType:="VarChar(MAX)")>  _
	Public Property lcnno_no() As String
		Get
			Return Me._lcnno_no
		End Get
		Set
			If (String.Equals(Me._lcnno_no, value) = false) Then
				Me.Onlcnno_noChanging(value)
				Me.SendPropertyChanging
				Me._lcnno_no = value
				Me.SendPropertyChanged("lcnno_no")
				Me.Onlcnno_noChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnno_noo", DbType:="VarChar(MAX)")>  _
	Public Property lcnno_noo() As String
		Get
			Return Me._lcnno_noo
		End Get
		Set
			If (String.Equals(Me._lcnno_noo, value) = false) Then
				Me.Onlcnno_nooChanging(value)
				Me.SendPropertyChanging
				Me._lcnno_noo = value
				Me.SendPropertyChanged("lcnno_noo")
				Me.Onlcnno_nooChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnno_not_pvnabbr", DbType:="VarChar(MAX)")>  _
	Public Property lcnno_not_pvnabbr() As String
		Get
			Return Me._lcnno_not_pvnabbr
		End Get
		Set
			If (String.Equals(Me._lcnno_not_pvnabbr, value) = false) Then
				Me.Onlcnno_not_pvnabbrChanging(value)
				Me.SendPropertyChanging
				Me._lcnno_not_pvnabbr = value
				Me.SendPropertyChanged("lcnno_not_pvnabbr")
				Me.Onlcnno_not_pvnabbrChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_typee", DbType:="VarChar(MAX)")>  _
	Public Property typee() As String
		Get
			Return Me._typee
		End Get
		Set
			If (String.Equals(Me._typee, value) = false) Then
				Me.OntypeeChanging(value)
				Me.SendPropertyChanging
				Me._typee = value
				Me.SendPropertyChanged("typee")
				Me.OntypeeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_licen", DbType:="VarChar(MAX)")>  _
	Public Property licen() As String
		Get
			Return Me._licen
		End Get
		Set
			If (String.Equals(Me._licen, value) = false) Then
				Me.OnlicenChanging(value)
				Me.SendPropertyChanging
				Me._licen = value
				Me.SendPropertyChanged("licen")
				Me.OnlicenChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_licen_addr", DbType:="VarChar(MAX)")>  _
	Public Property licen_addr() As String
		Get
			Return Me._licen_addr
		End Get
		Set
			If (String.Equals(Me._licen_addr, value) = false) Then
				Me.Onlicen_addrChanging(value)
				Me.SendPropertyChanging
				Me._licen_addr = value
				Me.SendPropertyChanged("licen_addr")
				Me.Onlicen_addrChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_licen_address", DbType:="VarChar(MAX)")>  _
	Public Property licen_address() As String
		Get
			Return Me._licen_address
		End Get
		Set
			If (String.Equals(Me._licen_address, value) = false) Then
				Me.Onlicen_addressChanging(value)
				Me.SendPropertyChanging
				Me._licen_address = value
				Me.SendPropertyChanged("licen_address")
				Me.Onlicen_addressChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_licen_time", DbType:="VarChar(MAX)")>  _
	Public Property licen_time() As String
		Get
			Return Me._licen_time
		End Get
		Set
			If (String.Equals(Me._licen_time, value) = false) Then
				Me.Onlicen_timeChanging(value)
				Me.SendPropertyChanging
				Me._licen_time = value
				Me.SendPropertyChanged("licen_time")
				Me.Onlicen_timeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_grannm_lo", DbType:="VarChar(MAX)")>  _
	Public Property grannm_lo() As String
		Get
			Return Me._grannm_lo
		End Get
		Set
			If (String.Equals(Me._grannm_lo, value) = false) Then
				Me.Ongrannm_loChanging(value)
				Me.SendPropertyChanging
				Me._grannm_lo = value
				Me.SendPropertyChanged("grannm_lo")
				Me.Ongrannm_loChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_grannm_addr", DbType:="VarChar(MAX)")>  _
	Public Property grannm_addr() As String
		Get
			Return Me._grannm_addr
		End Get
		Set
			If (String.Equals(Me._grannm_addr, value) = false) Then
				Me.Ongrannm_addrChanging(value)
				Me.SendPropertyChanging
				Me._grannm_addr = value
				Me.SendPropertyChanged("grannm_addr")
				Me.Ongrannm_addrChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_grannm_address", DbType:="VarChar(MAX)")>  _
	Public Property grannm_address() As String
		Get
			Return Me._grannm_address
		End Get
		Set
			If (String.Equals(Me._grannm_address, value) = false) Then
				Me.Ongrannm_addressChanging(value)
				Me.SendPropertyChanging
				Me._grannm_address = value
				Me.SendPropertyChanged("grannm_address")
				Me.Ongrannm_addressChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_thanm", DbType:="VarChar(MAX)")>  _
	Public Property thanm() As String
		Get
			Return Me._thanm
		End Get
		Set
			If (String.Equals(Me._thanm, value) = false) Then
				Me.OnthanmChanging(value)
				Me.SendPropertyChanging
				Me._thanm = value
				Me.SendPropertyChanged("thanm")
				Me.OnthanmChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_thanm_addr", DbType:="VarChar(MAX)")>  _
	Public Property thanm_addr() As String
		Get
			Return Me._thanm_addr
		End Get
		Set
			If (String.Equals(Me._thanm_addr, value) = false) Then
				Me.Onthanm_addrChanging(value)
				Me.SendPropertyChanging
				Me._thanm_addr = value
				Me.SendPropertyChanged("thanm_addr")
				Me.Onthanm_addrChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_thanm_address", DbType:="VarChar(MAX)")>  _
	Public Property thanm_address() As String
		Get
			Return Me._thanm_address
		End Get
		Set
			If (String.Equals(Me._thanm_address, value) = false) Then
				Me.Onthanm_addressChanging(value)
				Me.SendPropertyChanging
				Me._thanm_address = value
				Me.SendPropertyChanged("thanm_address")
				Me.Onthanm_addressChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_thaamphrnm", DbType:="VarChar(MAX)")>  _
	Public Property thaamphrnm() As String
		Get
			Return Me._thaamphrnm
		End Get
		Set
			If (String.Equals(Me._thaamphrnm, value) = false) Then
				Me.OnthaamphrnmChanging(value)
				Me.SendPropertyChanging
				Me._thaamphrnm = value
				Me.SendPropertyChanged("thaamphrnm")
				Me.OnthaamphrnmChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_thachngwtnm", DbType:="VarChar(MAX)")>  _
	Public Property thachngwtnm() As String
		Get
			Return Me._thachngwtnm
		End Get
		Set
			If (String.Equals(Me._thachngwtnm, value) = false) Then
				Me.OnthachngwtnmChanging(value)
				Me.SendPropertyChanging
				Me._thachngwtnm = value
				Me.SendPropertyChanged("thachngwtnm")
				Me.OnthachngwtnmChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_cncnm", DbType:="VarChar(MAX)")>  _
	Public Property cncnm() As String
		Get
			Return Me._cncnm
		End Get
		Set
			If (String.Equals(Me._cncnm, value) = false) Then
				Me.OncncnmChanging(value)
				Me.SendPropertyChanging
				Me._cncnm = value
				Me.SendPropertyChanged("cncnm")
				Me.OncncnmChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_appdate", DbType:="VarChar(MAX)")>  _
	Public Property appdate() As String
		Get
			Return Me._appdate
		End Get
		Set
			If (String.Equals(Me._appdate, value) = false) Then
				Me.OnappdateChanging(value)
				Me.SendPropertyChanging
				Me._appdate = value
				Me.SendPropertyChanged("appdate")
				Me.OnappdateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_expyear", DbType:="VarChar(MAX)")>  _
	Public Property expyear() As String
		Get
			Return Me._expyear
		End Get
		Set
			If (String.Equals(Me._expyear, value) = false) Then
				Me.OnexpyearChanging(value)
				Me.SendPropertyChanging
				Me._expyear = value
				Me.SendPropertyChanged("expyear")
				Me.OnexpyearChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lmdfdate", DbType:="VarChar(MAX)")>  _
	Public Property lmdfdate() As String
		Get
			Return Me._lmdfdate
		End Get
		Set
			If (String.Equals(Me._lmdfdate, value) = false) Then
				Me.OnlmdfdateChanging(value)
				Me.SendPropertyChanging
				Me._lmdfdate = value
				Me.SendPropertyChanged("lmdfdate")
				Me.OnlmdfdateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Newcode_not", DbType:="VarChar(MAX)")>  _
	Public Property Newcode_not() As String
		Get
			Return Me._Newcode_not
		End Get
		Set
			If (String.Equals(Me._Newcode_not, value) = false) Then
				Me.OnNewcode_notChanging(value)
				Me.SendPropertyChanging
				Me._Newcode_not = value
				Me.SendPropertyChanged("Newcode_not")
				Me.OnNewcode_notChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class