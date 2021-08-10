Public Class FRM_CHANGE_DRUG_GROUP
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'If Not IsPostBack Then
    '    UC_TABLE_DRUG_GROUP_CHANGE.bind_table_edit()
    '    'bind_table()
    '    'End If
    'End Sub


    'Private Sub btn_SAVE_Click(sender As Object, e As EventArgs) Handles btn_SAVE.Click
    '    UC_TABLE_DRUG_GROUP_CHANGE.save_date()

    '    UC_TABLE_DRUG_GROUP_CHANGE.bind_table()
    'End Sub

    'Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
    '    UC_TABLE_DRUG_GROUP_CHANGE.save_data_edit()
    '    UC_TABLE_DRUG_GROUP_CHANGE.bind_table_edit()
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UC_TABLE_DRUG_GROUP_CHANGE_HERB.bind_type(Request.QueryString("ida"))
        UC_TABLE_DRUG_GROUP_CHANGE_HERB.bind_table(Request.QueryString("ida"))
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        UC_TABLE_DRUG_GROUP_CHANGE_HERB.save_data(Request.QueryString("ida"))
        alert("บันทึกเรียบร้อย")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class