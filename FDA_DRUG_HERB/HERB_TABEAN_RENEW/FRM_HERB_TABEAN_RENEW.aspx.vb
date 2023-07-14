Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_HERB_TABEAN_RENEW
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA_DR As String = ""
    Private _PROCESS_ID As String = ""
    Private _PROCESS_DR As String = ""

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_DR = Request.QueryString("IDA_DR")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _PROCESS_DR = Request.QueryString("PROCESS_DR")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub
    Function bind_data()
        Dim dt As New DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim DAO_WHO As New DAO_WHO.TB_WHO_DALCN
        DAO_WHO.GetdatabyID_FK_LCN(_IDA_LCN)
        If _PROCESS_DR.Contains("201") Or _PROCESS_DR.Contains("1400001") Then
            dt = bao.SP_TABEAN_RENEW_TBN_CUSTOMER(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_DR)
        ElseIf _PROCESS_DR.Contains("203") Then
            dt = bao.SP_TABEAN_RENEW_JJ_CUSTOMER(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_DR)
        End If
        'dt = bao.SP_XML_TABEAN_JJ_EDIT_REQUEST(_CLS.CITIZEN_ID_AUTHORIZE, IDA_DR)                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        'RadGrid1.DataBind()
        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA_LCN As String = item("IDA_LCN").Text
            Dim TR_ID_LCN As String = item("TR_ID_LCN").Text
            Dim FK_IDA_LCT As String = ""
            Try
                FK_IDA_LCT = item("IDA_LCT").Text
            Catch ex As Exception

            End Try
            'Dim _PROCESS_JJ As Integer = item("DDHERB").Text
            Dim IDA As Integer = item("IDA").Text
            Dim FK_IDA As Integer = item("FK_IDA").Text
            Dim TR_ID As Integer = item("TR_ID").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text

            If e.CommandName = "sel" Then
                If STATUS_ID = 11 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "POPUP_HERB_TABEAN_RENEW_EDIT_REQUEST.aspx?IDA_LCT=" &
                                                                     IDA_LCN & "&TR_ID_LCN=" & TR_ID_LCN & "&IDA_DR=" & _IDA_DR & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID & "');", True)
                ElseIf STATUS_ID = 1 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "POPUP_HERB_TABEAN_RENEW_CONFIRM.aspx?IDA_LCT=" &
                                                                      IDA_LCN & "&TR_ID_LCN=" & TR_ID_LCN & "&IDA_DR=" & _IDA_DR & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "POPUP_HERB_TABEAN_RENEW_CONFIRM.aspx?IDA_LCT=" &
                                                                     IDA_LCN & "&TR_ID_LCN=" & TR_ID_LCN & "&IDA_DR=" & _IDA_DR & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID & "');", True)
                End If

            End If
        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.DataSource = bind_data()
        RadGrid1.DataBind()                         'เรียกฟังก์ชั่น  load_GV_JJ   มาใช้งาน
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_RENEW
        dao.fields.PROCESS_ID = _PROCESS_ID
        dao.fields.FK_IDA = _IDA_DR
        dao.fields.FK_LCN = _IDA_LCN
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_HERB_TABEAN_RENEW_ADD.aspx?IDA_DR=" & _IDA_DR & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & dao.fields.IDA & "');", True)
    End Sub
End Class