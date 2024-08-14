Imports Telerik.Web.UI
Public Class POPUP_TABEAN_SUBSTITUTE_CONFIRM
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_DR As String = ""
    Private _IDA As String = ""
    Private _IDA_LCN As String = ""
    Private _TR_ID_DR As String = ""
    Private _PROCESS_ID_DR As String = ""
    Private _PROCESS_ID As String = ""
    Private _TR_ID As String = ""
    Private _DRRGT_REASON_ID As String = ""
    Private _PROCESS_TYPE_ID As String = ""

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
        _IDA = Request.QueryString("IDA")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_DR = Request.QueryString("IDA_DR")
        _TR_ID_DR = Request.QueryString("TR_ID_DR")
        _PROCESS_ID_DR = Request.QueryString("PROCESS_ID_DR")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _TR_ID = Request.QueryString("TR_ID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Run_Pdf_Tabean_Herb()
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/TBN_SUB.pdf'></iframe>"
            set_btn()
        End If
    End Sub
    Sub set_btn()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SUBSTITUTE
        dao.GetdatabyID_IDA(_IDA)

        'If dao.fields.STATUS_ID = 77 Or dao.fields.STATUS_ID = 78 Or dao.fields.STATUS_ID = 79 Or dao.fields.STATUS_ID = 7 _
        '    Or dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 10 Or dao.fields.STATUS_ID = 14 Or dao.fields.STATUS_ID = 17 _
        '    Or dao.fields.STATUS_ID = 75 Then
        '    btn_cancel.Enabled = False
        '    btn_cancel.CssClass = "btn-danger btn-lg"
        '    btn_cancle_request.Enabled = False
        '    btn_cancle_request.CssClass = "btn-danger btn-lg"
        'End If

        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            'btn_edit.Enabled = False
            'btn_edit.CssClass = "btn-danger btn-lg"
            'ElseIf dao.fields.STATUS_ID = 8 Then
            '    btn_cancel.Enabled = False
            '    btn_cancel.CssClass = "btn-danger btn-lg"
            'btn_load.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Public Sub Run_Pdf_Tabean_Herb1()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SUBSTITUTE
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TB_TEMPLAETE1(_PROCESS_ID, dao.fields.STATUS_ID, "บท", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_SUB") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT '& "\" & NAME_PDF_TB("HB_PDF", _PROCESS_TYPE_ID, con_year(Date.Now.Year), dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_TEMPLATE & "' ></iframe>"

    End Sub
    Public Sub Run_Pdf_Tabean_Herb()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SUBSTITUTE
        dao.GetdatabyID_IDA(_IDA)
        Dim XML As New CLASS_GEN_XML.TABEAN_SUBSTITUTE
        TBN_SUB = XML.Gen_XML_SUBSTITUTE_TBN(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE_GROUP(_PROCESS_ID, dao.fields.STATUS_ID, "บท", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_SUB") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _PROCESS_ID, dao.fields.YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _PROCESS_ID, dao.fields.YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SUBSTITUTE
        dao.GetdatabyID_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, 1, _PROCESS_ID, _IDA)

        'If _DRRGT_REASON_ID = 4 Then
        '    dt = BAO.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 4, _PROCESS_ID)
        'ElseIf _DRRGT_REASON_ID = 5 Then
        '    dt = BAO.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 5, _PROCESS_ID)
        'End If

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_TABEAN_SUBSTITUTE_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SUBSTITUTE
        dao.GetdatabyID_IDA(_IDA)

        dao.fields.DATE_CONFIRM = Date.Now
        dao.fields.STATUS_ID = 2
        dao.Update()

        alert("ยืนคำขอเรียบร้อย")

    End Sub
    Sub alert_summit(ByVal text As String)
        Dim url As String = ""
        url = "FRM_TABEAN_SUBSTITUTE_SUB_DR.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_DR=" & _IDA_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class