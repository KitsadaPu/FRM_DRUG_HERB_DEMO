Imports Telerik.Web.UI
Public Class LCN_REQUEST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    'Private Citizen As String = "0000000000000"
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        If Not IsPostBack Then      'ให้รันฟังก์ชั่นลำดับที่ 2
            ' load_GV_lcnno()         'ให้รันฟังก์ชั่นลำดับที่ 3
        End If
    End Sub



    Protected Sub rgns_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgns.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable 'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        dt = bao.SP_CUSTOMER_LCN_LISTREQUEST_BY_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)
        rgns.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        'rgns.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub

    Protected Sub rgns_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgns.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim id As String = item("IDA").Text
            Dim id_lcn As String = item("LCNNO_MANUAL").Text
            Dim _process As String = item("PROCESS_ID").Text
            Dim _lct_ida As String = item("LOCATION_ADDRESS_IDA").Text
            Dim _TRANSECTION As String = item("TRANSECTION_ID_UPLOAD").Text
            Dim _identify As String = item("_identify").Text

            If e.CommandName = "req" Then
                Response.Redirect("LIST_LCN_REQUEST.aspx?IDA=" & id & "&ID_LCN=" & id_lcn & "&identify=" & _identify & "&TR_ID=" & _TRANSECTION & " &Process=" & _process & " &lct_ida=" & _lct_ida & "")

                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "LIST_LCN_REQUEST.aspx?IDA=" & id & "&ID_LCN=" & id_lcn & "&identify=" & Citizen & "&TR_ID=" & _TRANSECTION & " &Process=" & _process & " &lct_ida=" & _lct_ida & "');", True)


            ElseIf e.CommandName = "rep" Then
                Response.Redirect("LIST_LCN_REPRESENT.aspx?IDA=" & id & "&ID_LCN=" & id_lcn & "&identify=" & _identify & "&lct_ida=" & _lct_ida & "")

                ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "LIST_LCN_REPRESENT.aspx?ID=" & id & "&ID_LCN=" & id_lcn & "');", True)

            End If

        End If
    End Sub


    'Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable        'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
    '    dt = bao.SP_CUSTOMER_LCN_BY_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)
    '    rgns.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
    '    rgns.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    'End Sub
    'Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
    '    GV_lcnno.PageIndex = e.NewPageIndex
    '    load_GV_lcnno()
    'End Sub

End Class