Imports Telerik.Web.UI
Public Class FRM_LCN_EDIT
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    'Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _IDA As String = ""
    Private _iden As String


    Sub RunSession()

        _IDA = Request.QueryString("lcn_ida")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        '_process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            TEXT_LOAD()
        End If

    End Sub
    Private Sub TEXT_LOAD()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        TXT_LCNNO.Text = dao.fields.LCNNO_DISPLAY_NEW
        TXT_LCB_NAME.Text = dao.fields.LOCATION_ADDRESS_thanameplace
    End Sub


    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim bao_infor As New BAO.information
            Dim item As GridDataItem = e.Item




            Dim STATUS_ID As Integer = item("STATUS_ID").Text

            Dim _process As String = ""
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA)
            _process = dao_lcn.fields.PROCESS_ID

            If e.CommandName = "LCN_EDIT_DETAIL" Then
                If STATUS_ID = 9 Then
                    'lbl_head1.Text = "ข้อมูลขอเอกสาร (เพิ่มเติม) ยื่นคำขอแก้ไขใบอนุญาต"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_EDIT.aspx?process=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&LCN_IDA=" & _IDA & "&STATUS_ID=" & STATUS_ID & "');", True)
                End If
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource


        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(_IDA, 2)

        Dim status_id As Integer = 0

        For Each dr In dt.Rows
            status_id = dr("STATUS_ID")
        Next

        RadGrid1.DataSource = dt

        If status_id = 9 Then
            RadGrid1.MasterTableView.GetColumn("LCN_EDIT_DETAIL").Visible = True
        End If


    End Sub

    Protected Sub SUB_ADD_Click(sender As Object, e As EventArgs) Handles SUB_ADD.Click
        Dim _process As String = ""
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA)
        _process = dao_lcn.fields.PROCESS_ID

        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(_IDA, 2)

        Dim status_id As Integer = 0

        For Each dr In dt.Rows
            status_id = dr("STATUS_ID")
        Next

        If Request.QueryString("lcn_ida") = "" Then

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_EDIT.aspx?process=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&LCN_IDA=" & _IDA & "&STATUS_ID=" & status_id & "');", True)
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim lcn_ida As Integer = _IDA
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            Dim FILE_NUMBER_NAME As Integer = 0

            FILE_NUMBER_NAME = 69
            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_EDIT/FRM_LCN_EDIT_PREVIEW_FILE.aspx?file_id=" & FILE_NUMBER_NAME & "&lcn_ida=" & lcn_ida

            If STATUS_ID <> 9 Then
                H.Visible = False
            End If

        End If

    End Sub
End Class