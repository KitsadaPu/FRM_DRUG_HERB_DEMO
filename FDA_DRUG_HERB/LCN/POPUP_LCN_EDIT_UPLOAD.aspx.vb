Public Class POPUP_LCN_EDIT_UPLOAD
    Inherits System.Web.UI.Page
    Private _type_id As String = ""
    Private _IDA As String = ""
    Private _lct_ida As String = ""
    Private _TR_ID As String = ""
    Private _ProcessID As Integer
    Private _pvncd As Integer
    Private _CLS As New CLS_SESSION
    Sub runQuery()
        _type_id = Request.QueryString("type_id")
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("ida")
        _lct_ida = Request.QueryString("lct_ida")
        _TR_ID = Request.QueryString("TR_ID")
    End Sub
    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Response.Redirect("POPUP_PREVIEW_UPLOAD.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&Process=" & _ProcessID & "&lct_ida=" & _lct_ida)
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class