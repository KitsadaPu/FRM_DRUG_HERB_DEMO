Public Class POPUP_LCN_EDIT1
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    'Private _IDA As String
    ' Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _lcn_ida As String
    Private _STATUS_ID As Integer



    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        ''_la_IDA = Request.QueryString("la_IDA")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        '_IDA = Request.QueryString("IDA")
        _lcn_ida = Request.QueryString("LCN_IDA")
        _STATUS_ID = Request.QueryString("STATUS_ID")


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            'set_txt_label()

        End If
        If _STATUS_ID = 9 Then
            btn_save.Visible = False
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        UC_LCN_EDIT1.save_data(dao)
        Dim dt As DataTable
        dt = UC_LCN_EDIT1.get_dt_edit(_lcn_ida)

        Dim YEAR_S As String = ""
        YEAR_S = con_year(Date.Now().Year())

        If dt.Rows.Count <> 0 Then

            For Each dr As DataRow In dt.Rows
                Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT
                Dim get_ida As Integer = 0
                get_ida = dr("IDA")
                dao_update.GetDataby_IDA_YEAR(get_ida, YEAR_S, True)
                dao_update.fields.ACTIVE = 0
                dao_update.fields.UPDATE_DATE = System.DateTime.Now
                dao_update.update()
            Next
        End If

        dao.insert()

        dao.GetDataby_IDA_YEAR(_lcn_ida, YEAR_S, True)
        Dim ida_xml As Integer = 0
        Dim process_xml As Integer = 0
        Dim year_xml As Integer = 0
        Dim tr_id_xml As Integer = 0

        ida_xml = dao.fields.IDA
        process_xml = dao.fields.LCN_PROCESS_ID
        year_xml = dao.fields.DATE_YEAR
        tr_id_xml = dao.fields.TR_ID

        dao.fields.STATUS_ID = 2
        dao.update()

        bind_pdf_xml_2(ida_xml, _lcn_ida, process_xml, dao.fields.STATUS_ID, year_xml, tr_id_xml)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)

    End Sub

    Public Sub bind_pdf_xml_2(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
        Dim XML As New CLASS_GEN_XML.LCN_EDIT_SMP3
        TB_SMP3 = XML.gen_xml(_IDA, LCN_IDA, _YEAR)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_ProcessID, _StatusID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_SMP3\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_SMP3("HB_XML", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
End Class