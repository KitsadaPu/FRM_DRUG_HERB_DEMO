Public Class POP_UP_LCN_RENEW_CHECK_STAFF_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As Integer
    Private _IDA As Integer
    Private _IDEN As String
    Private _PROCESS_ID As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _IDEN = Request.QueryString("IDENTIFY")
            _PROCESS_ID = Request.QueryString("PROCESS_ID")
            _IDA = Request.QueryString("IDA_LCN")
            _IDEN = Request.QueryString("IDENTIFY")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UC_HERB_PRE.Set_Label(_IDEN)
        UC_HERB_BSN_PRE.load_ddl_chwt()
        UC_HERB_BSN_PRE.load_ddl_amp()
        UC_HERB_BSN_PRE.load_ddl_thambol()
        UC_HERB_PHESAJ_PRE.bind_ddl_prefix()
        UC_HERB_PHESAJ_PRE.bind_ddl_phr_type()
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click

    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class