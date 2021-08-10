Imports Telerik.Web.UI
Public Class FRM_SOMORPO4_MAIN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rgphr_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgphr.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim dao_his As New DAO_DRUG.TB_DALCN_PHR_HISTORY
            If e.CommandName = "sel" Then
                lbl_title.Text = "ดูข้อมูล"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_SOMORPO4_CONFIRM.aspx?phr=" & item("PHR_IDA").Text & "&ida= " & Request.QueryString("IDA") & "');", True)
            End If
            rgphr.Rebind()
        End If
    End Sub
    Private Sub rgphr_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgphr.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_PHR_GET_DATA_STAFF()
        Catch ex As Exception
            'FRM_STAFF_LCN_PHR_EDIT.aspx
        End Try
        If dt.Rows.Count > 0 Then
            rgphr.DataSource = dt
        End If

    End Sub
End Class