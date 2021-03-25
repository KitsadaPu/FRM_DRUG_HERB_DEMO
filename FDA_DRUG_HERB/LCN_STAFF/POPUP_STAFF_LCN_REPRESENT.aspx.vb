Public Class POPUP_STAFF_LCN_REPRESENT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBlcn_represent
        dao.GetDataby_id(Request.QueryString("id"))
        dao.fields.STATUS_ID = DropDownList1.SelectedValue
        If DropDownList1.SelectedValue <> 5 Then
            dao.fields.rcbno = 1
        Else dao.fields.rcbno = 0
        End If
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');parent.close_modal();", True)

    End Sub

End Class