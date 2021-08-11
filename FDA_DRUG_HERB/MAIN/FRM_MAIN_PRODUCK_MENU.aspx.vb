Public Class FRM_MAIN_PRODUCK_MENU
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Sub RunSession()
        Try
            '_IDA = Request.QueryString("IDA")
            _IDA = Request.QueryString("lcn_ida")
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Protected Sub BTN_ON_Click(sender As Object, e As EventArgs) Handles BTN_ON.Click
        Response.Redirect("../LOCATION/FRM_LCN_LCT.aspx")
    End Sub

    Protected Sub BTN_SUBTITUTE_Click(sender As Object, e As EventArgs) Handles BTN_SUBTITUTE.Click
        Response.Redirect("../LCN_SUBSTITUTE/FRM_LCN_SUBSTITUTE_MAIN.aspx?lcn_ida=" & _IDA)
    End Sub

    Protected Sub BTN_EDIT_Click(sender As Object, e As EventArgs) Handles BTN_EDIT.Click
        Response.Redirect("../MAIN/SELECT_LICENSE.aspx")
    End Sub

    Protected Sub BTN_TOR_Click(sender As Object, e As EventArgs) Handles BTN_TOR.Click
        Response.Redirect("../LOCATION/FRM_LCN_LCT.aspx")
    End Sub
End Class