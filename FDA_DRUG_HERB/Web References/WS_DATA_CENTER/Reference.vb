﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace WS_DATA_CENTER
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WS_DATA_CENTERSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class WS_DATA_CENTER
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private FDA_HOUSE_NOOperationCompleted As System.Threading.SendOrPostCallback
        
        Private FDA_IDENTIFYOperationCompleted As System.Threading.SendOrPostCallback
        
        Private FDA_IDENTIFY_DTOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GET_DATA_IDENTIFYOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GET_DATA_IDENTIFY_DSOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GET_DATA_IDENTIFY_DTOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GET_DATA_IDEMOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GET_DATA_IDEM_NEWOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GET_DATA_IDEM_JSONOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GET_DATA_IDEM_ORGOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_DRUG_HERB.My.MySettings.Default.FDA_DRUG_HERB_WS_DATA_CENTER_WS_DATA_CENTER
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event FDA_HOUSE_NOCompleted As FDA_HOUSE_NOCompletedEventHandler
        
        '''<remarks/>
        Public Event FDA_IDENTIFYCompleted As FDA_IDENTIFYCompletedEventHandler
        
        '''<remarks/>
        Public Event FDA_IDENTIFY_DTCompleted As FDA_IDENTIFY_DTCompletedEventHandler
        
        '''<remarks/>
        Public Event GET_DATA_IDENTIFYCompleted As GET_DATA_IDENTIFYCompletedEventHandler
        
        '''<remarks/>
        Public Event GET_DATA_IDENTIFY_DSCompleted As GET_DATA_IDENTIFY_DSCompletedEventHandler
        
        '''<remarks/>
        Public Event GET_DATA_IDENTIFY_DTCompleted As GET_DATA_IDENTIFY_DTCompletedEventHandler
        
        '''<remarks/>
        Public Event GET_DATA_IDEMCompleted As GET_DATA_IDEMCompletedEventHandler
        
        '''<remarks/>
        Public Event GET_DATA_IDEM_NEWCompleted As GET_DATA_IDEM_NEWCompletedEventHandler
        
        '''<remarks/>
        Public Event GET_DATA_IDEM_JSONCompleted As GET_DATA_IDEM_JSONCompletedEventHandler
        
        '''<remarks/>
        Public Event GET_DATA_IDEM_ORGCompleted As GET_DATA_IDEM_ORGCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FDA_HOUSE_NO", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function FDA_HOUSE_NO(ByVal HOUSE_NO As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String) As String
            Dim results() As Object = Me.Invoke("FDA_HOUSE_NO", New Object() {HOUSE_NO, CTZNO, USERNAME, PASSWORD})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub FDA_HOUSE_NOAsync(ByVal HOUSE_NO As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String)
            Me.FDA_HOUSE_NOAsync(HOUSE_NO, CTZNO, USERNAME, PASSWORD, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub FDA_HOUSE_NOAsync(ByVal HOUSE_NO As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal userState As Object)
            If (Me.FDA_HOUSE_NOOperationCompleted Is Nothing) Then
                Me.FDA_HOUSE_NOOperationCompleted = AddressOf Me.OnFDA_HOUSE_NOOperationCompleted
            End If
            Me.InvokeAsync("FDA_HOUSE_NO", New Object() {HOUSE_NO, CTZNO, USERNAME, PASSWORD}, Me.FDA_HOUSE_NOOperationCompleted, userState)
        End Sub
        
        Private Sub OnFDA_HOUSE_NOOperationCompleted(ByVal arg As Object)
            If (Not (Me.FDA_HOUSE_NOCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent FDA_HOUSE_NOCompleted(Me, New FDA_HOUSE_NOCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FDA_IDENTIFY", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function FDA_IDENTIFY(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String) As String
            Dim results() As Object = Me.Invoke("FDA_IDENTIFY", New Object() {IDENTIFY, CTZNO, USERNAME, PASSWORD})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub FDA_IDENTIFYAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String)
            Me.FDA_IDENTIFYAsync(IDENTIFY, CTZNO, USERNAME, PASSWORD, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub FDA_IDENTIFYAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal userState As Object)
            If (Me.FDA_IDENTIFYOperationCompleted Is Nothing) Then
                Me.FDA_IDENTIFYOperationCompleted = AddressOf Me.OnFDA_IDENTIFYOperationCompleted
            End If
            Me.InvokeAsync("FDA_IDENTIFY", New Object() {IDENTIFY, CTZNO, USERNAME, PASSWORD}, Me.FDA_IDENTIFYOperationCompleted, userState)
        End Sub
        
        Private Sub OnFDA_IDENTIFYOperationCompleted(ByVal arg As Object)
            If (Not (Me.FDA_IDENTIFYCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent FDA_IDENTIFYCompleted(Me, New FDA_IDENTIFYCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FDA_IDENTIFY_DT", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function FDA_IDENTIFY_DT(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String) As System.Data.DataTable
            Dim results() As Object = Me.Invoke("FDA_IDENTIFY_DT", New Object() {IDENTIFY, CTZNO, USERNAME, PASSWORD})
            Return CType(results(0),System.Data.DataTable)
        End Function
        
        '''<remarks/>
        Public Overloads Sub FDA_IDENTIFY_DTAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String)
            Me.FDA_IDENTIFY_DTAsync(IDENTIFY, CTZNO, USERNAME, PASSWORD, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub FDA_IDENTIFY_DTAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal userState As Object)
            If (Me.FDA_IDENTIFY_DTOperationCompleted Is Nothing) Then
                Me.FDA_IDENTIFY_DTOperationCompleted = AddressOf Me.OnFDA_IDENTIFY_DTOperationCompleted
            End If
            Me.InvokeAsync("FDA_IDENTIFY_DT", New Object() {IDENTIFY, CTZNO, USERNAME, PASSWORD}, Me.FDA_IDENTIFY_DTOperationCompleted, userState)
        End Sub
        
        Private Sub OnFDA_IDENTIFY_DTOperationCompleted(ByVal arg As Object)
            If (Not (Me.FDA_IDENTIFY_DTCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent FDA_IDENTIFY_DTCompleted(Me, New FDA_IDENTIFY_DTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_DATA_IDENTIFY", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GET_DATA_IDENTIFY(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String) As String
            Dim results() As Object = Me.Invoke("GET_DATA_IDENTIFY", New Object() {IDENTIFY, CTZNO, USERNAME, PASSWORD})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDENTIFYAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String)
            Me.GET_DATA_IDENTIFYAsync(IDENTIFY, CTZNO, USERNAME, PASSWORD, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDENTIFYAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal userState As Object)
            If (Me.GET_DATA_IDENTIFYOperationCompleted Is Nothing) Then
                Me.GET_DATA_IDENTIFYOperationCompleted = AddressOf Me.OnGET_DATA_IDENTIFYOperationCompleted
            End If
            Me.InvokeAsync("GET_DATA_IDENTIFY", New Object() {IDENTIFY, CTZNO, USERNAME, PASSWORD}, Me.GET_DATA_IDENTIFYOperationCompleted, userState)
        End Sub
        
        Private Sub OnGET_DATA_IDENTIFYOperationCompleted(ByVal arg As Object)
            If (Not (Me.GET_DATA_IDENTIFYCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GET_DATA_IDENTIFYCompleted(Me, New GET_DATA_IDENTIFYCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_DATA_IDENTIFY_DS", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GET_DATA_IDENTIFY_DS(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal DT_NAME As String, ByVal USERNAME As String, ByVal PASSWORD As String) As System.Data.DataSet
            Dim results() As Object = Me.Invoke("GET_DATA_IDENTIFY_DS", New Object() {IDENTIFY, CTZNO, DT_NAME, USERNAME, PASSWORD})
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDENTIFY_DSAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal DT_NAME As String, ByVal USERNAME As String, ByVal PASSWORD As String)
            Me.GET_DATA_IDENTIFY_DSAsync(IDENTIFY, CTZNO, DT_NAME, USERNAME, PASSWORD, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDENTIFY_DSAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal DT_NAME As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal userState As Object)
            If (Me.GET_DATA_IDENTIFY_DSOperationCompleted Is Nothing) Then
                Me.GET_DATA_IDENTIFY_DSOperationCompleted = AddressOf Me.OnGET_DATA_IDENTIFY_DSOperationCompleted
            End If
            Me.InvokeAsync("GET_DATA_IDENTIFY_DS", New Object() {IDENTIFY, CTZNO, DT_NAME, USERNAME, PASSWORD}, Me.GET_DATA_IDENTIFY_DSOperationCompleted, userState)
        End Sub
        
        Private Sub OnGET_DATA_IDENTIFY_DSOperationCompleted(ByVal arg As Object)
            If (Not (Me.GET_DATA_IDENTIFY_DSCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GET_DATA_IDENTIFY_DSCompleted(Me, New GET_DATA_IDENTIFY_DSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_DATA_IDENTIFY_DT", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GET_DATA_IDENTIFY_DT(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal DT_NAME As String, ByVal USERNAME As String, ByVal PASSWORD As String) As System.Data.DataTable
            Dim results() As Object = Me.Invoke("GET_DATA_IDENTIFY_DT", New Object() {IDENTIFY, CTZNO, DT_NAME, USERNAME, PASSWORD})
            Return CType(results(0),System.Data.DataTable)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDENTIFY_DTAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal DT_NAME As String, ByVal USERNAME As String, ByVal PASSWORD As String)
            Me.GET_DATA_IDENTIFY_DTAsync(IDENTIFY, CTZNO, DT_NAME, USERNAME, PASSWORD, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDENTIFY_DTAsync(ByVal IDENTIFY As String, ByVal CTZNO As String, ByVal DT_NAME As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal userState As Object)
            If (Me.GET_DATA_IDENTIFY_DTOperationCompleted Is Nothing) Then
                Me.GET_DATA_IDENTIFY_DTOperationCompleted = AddressOf Me.OnGET_DATA_IDENTIFY_DTOperationCompleted
            End If
            Me.InvokeAsync("GET_DATA_IDENTIFY_DT", New Object() {IDENTIFY, CTZNO, DT_NAME, USERNAME, PASSWORD}, Me.GET_DATA_IDENTIFY_DTOperationCompleted, userState)
        End Sub
        
        Private Sub OnGET_DATA_IDENTIFY_DTOperationCompleted(ByVal arg As Object)
            If (Not (Me.GET_DATA_IDENTIFY_DTCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GET_DATA_IDENTIFY_DTCompleted(Me, New GET_DATA_IDENTIFY_DTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_DATA_IDEM", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GET_DATA_IDEM(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String) As String
            Dim results() As Object = Me.Invoke("GET_DATA_IDEM", New Object() {IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDEMAsync(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String)
            Me.GET_DATA_IDEMAsync(IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDEMAsync(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal userState As Object)
            If (Me.GET_DATA_IDEMOperationCompleted Is Nothing) Then
                Me.GET_DATA_IDEMOperationCompleted = AddressOf Me.OnGET_DATA_IDEMOperationCompleted
            End If
            Me.InvokeAsync("GET_DATA_IDEM", New Object() {IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD}, Me.GET_DATA_IDEMOperationCompleted, userState)
        End Sub
        
        Private Sub OnGET_DATA_IDEMOperationCompleted(ByVal arg As Object)
            If (Not (Me.GET_DATA_IDEMCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GET_DATA_IDEMCompleted(Me, New GET_DATA_IDEMCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_DATA_IDEM_NEW", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GET_DATA_IDEM_NEW(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String) As String
            Dim results() As Object = Me.Invoke("GET_DATA_IDEM_NEW", New Object() {IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDEM_NEWAsync(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String)
            Me.GET_DATA_IDEM_NEWAsync(IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDEM_NEWAsync(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal userState As Object)
            If (Me.GET_DATA_IDEM_NEWOperationCompleted Is Nothing) Then
                Me.GET_DATA_IDEM_NEWOperationCompleted = AddressOf Me.OnGET_DATA_IDEM_NEWOperationCompleted
            End If
            Me.InvokeAsync("GET_DATA_IDEM_NEW", New Object() {IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD}, Me.GET_DATA_IDEM_NEWOperationCompleted, userState)
        End Sub
        
        Private Sub OnGET_DATA_IDEM_NEWOperationCompleted(ByVal arg As Object)
            If (Not (Me.GET_DATA_IDEM_NEWCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GET_DATA_IDEM_NEWCompleted(Me, New GET_DATA_IDEM_NEWCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_DATA_IDEM_JSON", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GET_DATA_IDEM_JSON(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String) As String
            Dim results() As Object = Me.Invoke("GET_DATA_IDEM_JSON", New Object() {IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDEM_JSONAsync(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String)
            Me.GET_DATA_IDEM_JSONAsync(IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDEM_JSONAsync(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal userState As Object)
            If (Me.GET_DATA_IDEM_JSONOperationCompleted Is Nothing) Then
                Me.GET_DATA_IDEM_JSONOperationCompleted = AddressOf Me.OnGET_DATA_IDEM_JSONOperationCompleted
            End If
            Me.InvokeAsync("GET_DATA_IDEM_JSON", New Object() {IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD}, Me.GET_DATA_IDEM_JSONOperationCompleted, userState)
        End Sub
        
        Private Sub OnGET_DATA_IDEM_JSONOperationCompleted(ByVal arg As Object)
            If (Not (Me.GET_DATA_IDEM_JSONCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GET_DATA_IDEM_JSONCompleted(Me, New GET_DATA_IDEM_JSONCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_DATA_IDEM_ORG", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GET_DATA_IDEM_ORG(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal ORG As String) As String
            Dim results() As Object = Me.Invoke("GET_DATA_IDEM_ORG", New Object() {IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD, ORG})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDEM_ORGAsync(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal ORG As String)
            Me.GET_DATA_IDEM_ORGAsync(IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD, ORG, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GET_DATA_IDEM_ORGAsync(ByVal IDENTIFY As String, ByVal CTZNO_CALL As String, ByVal USERNAME As String, ByVal PASSWORD As String, ByVal ORG As String, ByVal userState As Object)
            If (Me.GET_DATA_IDEM_ORGOperationCompleted Is Nothing) Then
                Me.GET_DATA_IDEM_ORGOperationCompleted = AddressOf Me.OnGET_DATA_IDEM_ORGOperationCompleted
            End If
            Me.InvokeAsync("GET_DATA_IDEM_ORG", New Object() {IDENTIFY, CTZNO_CALL, USERNAME, PASSWORD, ORG}, Me.GET_DATA_IDEM_ORGOperationCompleted, userState)
        End Sub
        
        Private Sub OnGET_DATA_IDEM_ORGOperationCompleted(ByVal arg As Object)
            If (Not (Me.GET_DATA_IDEM_ORGCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GET_DATA_IDEM_ORGCompleted(Me, New GET_DATA_IDEM_ORGCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub FDA_HOUSE_NOCompletedEventHandler(ByVal sender As Object, ByVal e As FDA_HOUSE_NOCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class FDA_HOUSE_NOCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub FDA_IDENTIFYCompletedEventHandler(ByVal sender As Object, ByVal e As FDA_IDENTIFYCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class FDA_IDENTIFYCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub FDA_IDENTIFY_DTCompletedEventHandler(ByVal sender As Object, ByVal e As FDA_IDENTIFY_DTCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class FDA_IDENTIFY_DTCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataTable
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataTable)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub GET_DATA_IDENTIFYCompletedEventHandler(ByVal sender As Object, ByVal e As GET_DATA_IDENTIFYCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GET_DATA_IDENTIFYCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub GET_DATA_IDENTIFY_DSCompletedEventHandler(ByVal sender As Object, ByVal e As GET_DATA_IDENTIFY_DSCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GET_DATA_IDENTIFY_DSCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataSet
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataSet)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub GET_DATA_IDENTIFY_DTCompletedEventHandler(ByVal sender As Object, ByVal e As GET_DATA_IDENTIFY_DTCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GET_DATA_IDENTIFY_DTCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataTable
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataTable)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub GET_DATA_IDEMCompletedEventHandler(ByVal sender As Object, ByVal e As GET_DATA_IDEMCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GET_DATA_IDEMCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub GET_DATA_IDEM_NEWCompletedEventHandler(ByVal sender As Object, ByVal e As GET_DATA_IDEM_NEWCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GET_DATA_IDEM_NEWCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub GET_DATA_IDEM_JSONCompletedEventHandler(ByVal sender As Object, ByVal e As GET_DATA_IDEM_JSONCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GET_DATA_IDEM_JSONCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub GET_DATA_IDEM_ORGCompletedEventHandler(ByVal sender As Object, ByVal e As GET_DATA_IDEM_ORGCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GET_DATA_IDEM_ORGCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
