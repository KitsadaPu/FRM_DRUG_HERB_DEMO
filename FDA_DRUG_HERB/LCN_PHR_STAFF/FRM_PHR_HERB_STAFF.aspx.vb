Imports Telerik.Web.UI
Public Class FRM_PHR_HERB_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As String = ""
    Private _SID As String = ""
    Private _pvncd As String = ""

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

        _IDA_LCN = Request.QueryString("IDA_LCN")
        _SID = Request.QueryString("SID")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            'bind_dd()
            ' RadGrid1.Rebind()
        End If
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        If _pvncd = 10 Then
            dt = bao.SP_DALCN_PHR_STAFF()
        Else
            dt = bao.SP_DALCN_PHR_STAFF_BY_PVNCD(_pvncd)
        End If

        Return dt
    End Function
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'Dim IDA_LCN As Integer = item("IDA_LCN").Text
            Dim IDA As Integer = item("PHR_IDA").Text
            Dim PROCESS_ID As String = item("PROCESS_ID").Text
            Dim STATUS_ID As Integer = item("phr_status").Text
            Dim TR_ID As Integer = item("TR_ID").Text

            If e.CommandName = "HL_SELECT" Then
                If STATUS_ID = 6 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POPUP_PHR_HERB_STAFF_EDIT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                Else
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " FRM_PHR_HERB_STAFF_CONFIRM.aspx?IDA=" & IDA & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                End If
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim STATUS_ID As String = item("phr_status").Text
            Dim IDA As String = item("PHR_IDA").Text
            Dim HL_SELECT As LinkButton = DirectCast(item("HL_SELECT").Controls(0), LinkButton)
            If STATUS_ID = 1 Then
                'HL_SELECT.Text = "ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
            ElseIf STATUS_ID > 1 Then
                HL_SELECT.Text = "ดูข้อมูล"
            Else
                HL_SELECT.Text = "ดูข้อมูล"
            End If

        End If
    End Sub
End Class