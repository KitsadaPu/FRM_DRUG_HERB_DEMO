Public Class FRM_HERB_APPOINMENT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_LCN As String
    Private _TR_ID As String
    Private _ProcessID As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_JJ")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then
            bind_pdf()
        End If

    End Sub

    Private Sub bind_pdf()
        Dim cls As New CLASS_GEN_XML.APPOINTMAENT
        Dim xml As New CLASS_APPOINTMENT

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

        Dim LCNNO_DISPLAY_NEW As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanm As String = dao_lcn.fields.thanm
        Dim tel As String = dao_lcn.fields.tel
        Dim NAME_JJ As String = dao.fields.NAME_JJ
        Dim RCVNO_FULL As String = dao.fields.RCVNO_FULL
        Dim NAME_THAI_NAME_PLACE As String = dao.fields.NAME_THAI '& " / " & dao.fields.NAME_PLACE_JJ

        'Dim date_req_day As Date
        'Dim date_req_month As Date
        'Dim date_req_year As Date
        'Dim date_req_full As String = ""

        Dim date_con_day As Date
        Dim date_con_month As Date
        Dim date_con_year As Date

        Dim date_con_day_end As Date
        Dim date_con_month_end As Date
        Dim date_con_year_end As Date

        Dim date_con_full As String = ""
        Dim date_con_full_END As String = ""

        Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
        Dim date_result_start As Date
        Dim date_result_end As Date
        Dim days_start As Integer = 1
        Dim days_end As Integer = 10
        If _ProcessID = 20301 Or _ProcessID = 20302 Or _ProcessID = 20303 Then
            days_end = 11
        ElseIf _ProcessID = 20304 Or _ProcessID = 20305 Then
            days_end = 16
        End If
        Dim number_day_start As String = ""
        Dim number_day_end As String = ""
        ws.GETDATE_WORKING(CDate(dao.fields.DATE_CONFIRM), True, days_start, True, date_result_start, True)
        ws.GETDATE_WORKING(CDate(dao.fields.DATE_CONFIRM), True, days_end, True, date_result_end, True)
        number_day_start = date_result_start.ToLongDateString()
        number_day_end = date_result_end.ToLongDateString()

        If dao.fields.STATUS_ID >= 3 Then

            date_con_full = number_day_start
            date_con_full_END = number_day_end
            dao.fields.EXPECTED_DATE = date_result_end
            dao.Update()
            'date_con_day = number_day_start
            'date_con_month = number_day_start
            'date_con_year = number_day_start

            'date_con_day_end = number_day_end
            'date_con_month_end = number_day_end
            'date_con_year_end = number_day_end

            'date_con_full = date_con_day.Day.ToString() & " " & date_con_month.ToString("MMMM") & " " & con_year(date_con_year.Year)
            'date_con_full_END = date_con_day_end.Day.ToString() & " " & date_con_month_end.ToString("MMMM") & " " & con_year(date_con_year_end.Year)
            'ElseIf dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 12 Then
            '    date_req_day = dao.fields.DATE_REQ
            '    date_req_month = dao.fields.DATE_REQ
            '    date_req_year = dao.fields.DATE_REQ

            '    date_con_full = date_req_day.Day.ToString() & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
            '    date_req_full = date_req_day.Day.ToString() + 7 & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
        End If

        cls.process_id = _ProcessID
        cls.lcnno_display_new = LCNNO_DISPLAY_NEW
        cls.rcvno_full = RCVNO_FULL
        cls.name_thai_name_place = NAME_THAI_NAME_PLACE
        cls.date_req_full = date_con_full
        cls.thanm = thanm
        'cls.thanm = thanm
        cls.NAME_CONTACT = dao.fields.Appoinment_Contact
        cls.TR_ID = dao.fields.TR_ID_JJ
        'cls.NAME_CONTACT = NAME_JJ
        cls.E_MAIL = dao.fields.Appoinment_Email
        cls.tel_callback = dao.fields.Appoinment_Phone
        'cls.tel_callback = tel
        cls.citizen_id = _CLS.CITIZEN_ID
        cls.appointment_date = date_con_full_END
        cls.group_assign = "กลุ่มทะเบียนผลิตภัณฑ์ กองผลิตภัณฑ์สมุนไพร"

        xml = cls.XML_APOINTMENT()
        TB_AP = xml
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, 3, "APPROVE_JJ_1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_APPROVE") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_APPROVE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_APPOINTMENT("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_APPOINTMENT("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, "AP", PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub

    'Sub Bind_Date()
    '    Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
    '    Dim date_result As Date
    '    ws.GETDATE_WORKING(CDate(txt_date.Text), True, txt_number.Text, True, date_result, True)
    '    lbl_number_day.Text = date_result.ToLongDateString()

    'End Sub

End Class