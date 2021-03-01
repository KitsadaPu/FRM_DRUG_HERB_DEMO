Imports Telerik.Web.UI
Public Class LIST_STAFF_LCN_REQUEST
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub rgns_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgns.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable        'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        dt = bao.SP_LIST_LCN_REQUEST
        rgns.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        'rgns.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub

    Protected Sub rgns_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgns.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim id As String = item("IDA").Text
            'Dim id_lcn As String = item("LCNNO_MANUAL").Text
            'Dim _process As String = item("PROCESS_ID").Text
            'Dim _lct_ida As String = item("LOCATION_ADDRESS_IDA").Text
            'Dim _TRANSECTION As String = item("TRANSECTION_ID_UPLOAD").Text

            If e.CommandName = "sele" Then
                'Response.Redirect("POPUP_CONFIRM_LCN_REQUEST.aspx?IDA=" & id & "&ID_LCN=" & id_lcn & "&identify=" & _iden & "&TR_ID=" & _TRANSECTION & " &Process=" & _process & " &lct_ida=" & _lct_ida & "")
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_CONFIRM_LCN_REQUEST.aspx?IDA=" & _IDA & "&ID_LCN=" & _id_lcn & "&identify=" & _iden & "&TR_ID=" & _TR_ID & " &Process=" & _ProcessID & " &lct_ida=" & _lct_ida & "');", True)

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_STAFF_LCN_REQUEST.aspx?ID=" & id & "');", True)

            End If

        End If
    End Sub
End Class