Imports Telerik.Web.UI
Public Class LIST_LCN_REPRESENT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub rgns_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgns.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable        'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        dt = bao.SP_CUSTOMER_LCN_BY_IDEN("0000000000000")
        rgns.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        'rgns.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("POPUP_LCN_REPRESENT.aspx")
    End Sub
End Class