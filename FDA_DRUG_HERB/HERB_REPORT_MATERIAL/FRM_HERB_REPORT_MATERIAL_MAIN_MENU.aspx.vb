Public Class FRM_HERB_REPORT_MATERIAL_MAIN_MENU
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Protected Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
        _CLS.SID_ID = 1
        Response.Redirect("FRM_HERB_REPORT_MATERIAL_MAIN_LCN.aspx?")
    End Sub
End Class