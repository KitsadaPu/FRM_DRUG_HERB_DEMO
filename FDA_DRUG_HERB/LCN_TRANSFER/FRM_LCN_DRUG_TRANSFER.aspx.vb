Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Public Class FRM_LCN_DRUG_TRANSFER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    Private _iden As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _lct_ida = Request.QueryString("lct_ida")
            _lcn_ida = Request.QueryString("lcn_ida")
            _type = Request.QueryString("type")
            _process_for = Request.QueryString("process_for")
            _iden = Request.QueryString("identify")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        load_lbl_name()
    End Sub

    Private Sub load_lbl_name()

        Dim dao_menu As New DAO_DRUG.ClsDBMAS_MENU
        dao_menu.GetDataby_Process2(_process)

        Dim dao_menu2 As New DAO_DRUG.ClsDBMAS_MENU
        dao_menu2.GetDataby_Process2(_process_for)
        If String.IsNullOrEmpty(_process_for) = False Then
            lbl_name_2.Text = " (" & dao_menu2.fields.NAME & ") > "
        End If

        lbl_name.Text = " (" & dao_menu.fields.NAME & ")" 'ดึงชื่อเมนูมาแสดง

    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_TRANSFER.aspx?lcn_ida=" & _lcn_ida & "&lct_ida=" & _lct_ida & "&process=" & _process & "&identify=" & _iden & "');", True)
    End Sub
End Class