Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_HERB_NOTIFY_CORRECTION
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _PROCESS_ID As String = ""

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

        _IDA = Request.QueryString("IDA")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub
    Function bind_data()
        Dim dt As New DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        dt = bao.SP_TABEAN_NOTIFY_CORRECTION_CUSTOMER(_CLS.CITIZEN_ID_AUTHORIZE)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = item("IDA").Text
            'Dim FK_IDA As Integer = item("FK_IDA").Text
            Dim TR_ID As Integer = item("TR_ID").Text
            Dim PROCESS_ID As Integer = item("PROCESS_ID").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            If e.CommandName = "sel" Then
                If STATUS_ID = 11 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "POPUP_HERB_NOTIFY_CORRECTION_EDIT.aspx?PROCESS_ID=" & PROCESS_ID & "&IDA=" & IDA & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "POPUP_HERB_NOTIFY_CORRECTION_CONFIRM.aspx?PROCESS_ID=" & PROCESS_ID & "&IDA=" & IDA & "');", True)
                End If
            End If
        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.DataSource = bind_data()
        RadGrid1.DataBind()                         'เรียกฟังก์ชั่น  load_GV_JJ   มาใช้งาน
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_NOTIFY
        dao.fields.PROCESS_ID = _PROCESS_ID
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_HERB_NOTIFY_CORRECTION_ADD.aspx?PROCESS_ID=" & _PROCESS_ID & "&IDA=" & dao.fields.IDA & "');", True)
    End Sub
End Class