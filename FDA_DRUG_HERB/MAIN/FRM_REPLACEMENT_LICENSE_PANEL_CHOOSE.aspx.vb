Public Class FRM_REPLACEMENT_LICENSE_PANEL_CHOOSE
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
        Response.Redirect("../LOCATION/FRM_LCN_LCT.aspx")
    End Sub

    Private Sub btn_other_Click(sender As Object, e As EventArgs) Handles btn_other.Click
        Response.Redirect("FRM_SELECT_PROCESS_LCN.aspx?")
    End Sub
End Class