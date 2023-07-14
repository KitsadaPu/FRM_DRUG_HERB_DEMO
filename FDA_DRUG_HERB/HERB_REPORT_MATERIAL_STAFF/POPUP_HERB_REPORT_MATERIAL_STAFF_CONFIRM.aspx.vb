Public Class POPUP_HERB_REPORT_MATERIAL_STAFF_CONFIRM
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

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
End Class