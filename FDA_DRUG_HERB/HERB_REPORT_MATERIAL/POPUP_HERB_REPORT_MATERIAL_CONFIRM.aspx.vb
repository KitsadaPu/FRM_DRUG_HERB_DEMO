Public Class POPUP_HERB_REPORT_MATERIAL_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _LCNNO_DISPLAY As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _PROCESS_ID As String = ""
    Private _IDA As String = ""
    Private _SID As String = ""

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
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _LCNNO_DISPLAY = Request.QueryString("LCNNO_DISPLAY")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")
        _SID = Request.QueryString("SID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            set_btn()
            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF") 'path
            Dim filename As String = ""
            If _PROCESS_ID = 30711 Then
                filename = "D:/path_demo/PDF_TEMPLATE/REPORT_1.pdf"
            ElseIf _PROCESS_ID = 30712 Then
                filename = "D:/path_demo/PDF_TEMPLATE/REPORT_2.pdf"
            ElseIf _PROCESS_ID = 30721 Then
                filename = "D:/path_demo/PDF_TEMPLATE/REPORT_3.pdf"
            ElseIf _PROCESS_ID = 30722 Then
                filename = "D:/path_demo/PDF_TEMPLATE/REPORT_4.pdf"
            End If

            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        End If
    End Sub
    Sub set_btn()
        Dim dao As New DAO_REPORT.TB_HERB_PRODUCT_REPORT
        dao.Getdataby_IDA(_IDA)

        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
        End If
        If dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 77 Or dao.fields.STATUS_ID = 75 Or dao.fields.STATUS_ID = 7 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
        If dao.fields.STATUS_ID = 1 Then
            btn_cancel.Text = "ยกเลิกการสร้างคำขอ"
        End If
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim bao As New BAO.GenNumber
        Dim RCVNO As String = ""
        Dim RCVNO_HERB_NEW As String = ""
        'Dim pvncd As String = dao.fields.pvncd
        Dim pvncd As String = 10
        Dim dao As New DAO_REPORT.TB_HERB_PRODUCT_REPORT
        dao.Getdataby_IDA(_IDA)
        dao.fields.STATUS_ID = 8
        dao.fields.appdate = Date.Now
        RCVNO = BAO.GEN_RCVNO_NO(con_year(Date.Now.Year()), pvncd, _PROCESS_ID, _IDA)
        Dim TR_ID As String = dao.fields.TR_ID
        Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
        RCVNO_HERB_NEW = BAO.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, _PROCESS_ID, _IDA)
        Dim RCVNO_FULL As String = "HB" & " " & pvncd & "-" & _PROCESS_ID & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
        dao.fields.RCVNO_NEW = RCVNO_FULL
        dao.fields.rcvno = RCVNO
        dao.Update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยื่นส่งรายงานเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
End Class