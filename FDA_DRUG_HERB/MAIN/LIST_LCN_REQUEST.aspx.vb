Imports Telerik.Web.UI
Public Class LIST_LCN_REQUEST
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    ' Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _id_lcn As String


    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _lct_ida = Request.QueryString("lct_ida")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _iden = Request.QueryString("identify")
            _id_lcn = Request.QueryString("ID_LCN")
            ' _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
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

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_CONFIRM_LCN_REQUEST.aspx?ID=" & id & "');", True)

            End If

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Response.Redirect("POPUP_LCN_REQUEST_EDIT.aspx?IDA=" & _IDA & "&ID_LCN=" & _id_lcn & "&identify=" & _iden & "&TR_ID=" & _TR_ID & " &Process=" & _ProcessID & " &lct_ida=" & _lct_ida & "")
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_REQUEST_EDIT.aspx?IDA=" & _IDA & "&ID_LCN=" & _id_lcn & "&identify=" & _iden & "&TR_ID=" & _TR_ID & " &Process=" & _ProcessID & " &lct_ida=" & _lct_ida & "');", True)

    End Sub
End Class