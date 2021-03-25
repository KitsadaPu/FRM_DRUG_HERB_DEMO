Public Class POPUP_CONFIRM_LCN_REPRESENT
    Inherits System.Web.UI.Page

    Private _ID As String
    Sub RunQuery()
        _ID = Request.QueryString("ID")
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        Dim dao As New DAO_DRUG.ClsDBlcn_represent
        dao.GetDataby_id(_ID)
        If dao.fields.STATUS_ID = 1 Then
                btn_confirm.Style.Add("display", "initial")
            Else btn_confirm.Style.Add("display", "none")
            End If


    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBlcn_represent
        dao.GetDataby_id(Request.QueryString("id"))
        dao.fields.STATUS_ID = 2
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');parent.close_modal();", True)

    End Sub
End Class