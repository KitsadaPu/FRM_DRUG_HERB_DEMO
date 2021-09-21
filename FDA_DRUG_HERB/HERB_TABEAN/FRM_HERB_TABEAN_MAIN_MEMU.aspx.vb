Public Class FRM_HERB_TABEAN_MAIN_MEMU
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
        Response.Redirect("FRM_HERB_TABEAN_NEW.aspx?MENU_GROUP=1")
    End Sub

    Private Sub btn_other_Click(sender As Object, e As EventArgs) Handles btn_other.Click
        Response.Redirect("FRM_HERB_TABEAN_OTHER.aspx?MENU_GROUP=2")
    End Sub

End Class