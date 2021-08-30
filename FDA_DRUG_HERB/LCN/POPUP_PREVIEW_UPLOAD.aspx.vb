Public Class POPUP_PREVIEW_UPLOAD
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private _pvncd As Integer
    Private b64 As String
    Private _iden As String
    Private _lct_ida As String
    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _lct_ida = Request.QueryString("lct_ida")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _iden = Request.QueryString("identify")
            _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
    End Sub

End Class