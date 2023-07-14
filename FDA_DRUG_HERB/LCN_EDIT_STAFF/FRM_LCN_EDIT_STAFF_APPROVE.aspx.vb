Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_LCN_EDIT_STAFF_APPROVE
    Inherits System.Web.UI.Page

    Private _LCN_IDA As Integer
    Private _LCT_IDA As Integer

    Private _ProcessID As String
    Private _REASON_TYPE As String
    Private _STATUS_GROUP As Integer
    Private _STATUS_ID As Integer
    Private _ddl1 As Integer
    Private _ddl2 As Integer
    Private _IDA As Integer
    Private _TR_LCN_EDIT As String

    Private _CLS As New CLS_SESSION
    Private _CLS_CITIZEN_ID_AUTHORIZE As String = ""
    Private _CLS_CITIZEN_ID As String = ""
    Private _CLS_THANM As String = ""



    Sub RunSession()

        _LCN_IDA = Request.QueryString("LCN_IDA")
        _LCT_IDA = Request.QueryString("LCT_IDA")

        _REASON_TYPE = Request.QueryString("LCN_EDIT_REASON_TYPE")
        _STATUS_GROUP = Request.QueryString("STATUS_GROUP")
        _STATUS_ID = Request.QueryString("STATUS_ID")

        _ddl1 = Request.QueryString("ddl_up1")
        _ddl2 = Request.QueryString("ddl_up2")
        _IDA = Request.QueryString("IDA")

        _TR_LCN_EDIT = Request.QueryString("TR_LCN_EDIT")


        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_REPORT_RDLC.aspx?IDA=" & _IDA & "&rpt=1' ></iframe>"
            lr_preview.Text = "<iframe id='iframe1'  style='height:850px;width:100%;' src='../PDF/สมพ๓.pdf'></iframe>"
            BIND_STATUS()
            bind_mas_staff()
            bind_data()
            Run_PDF_SMP3()
            If _STATUS_ID = 8 Then
                DD_STATUS.SelectedValue = _STATUS_ID
                DD_STATUS.Enabled = False
                TXT_APPROVE_DATE.ReadOnly = True
                DDL_APPROVE_STAFF.Enabled = False
                TXT_APPROVE_NOTE.ReadOnly = True

                btn_sumit.Visible = False
            End If

        End If
        _CLS_CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        _CLS_CITIZEN_ID = _CLS.CITIZEN_ID
        _CLS_THANM = _CLS.THANM
    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim _YEAR As String = con_year(Date.Now().Year())
        dao.GetDataby_LCN_IDA_AND_YEAR_TR_ID_AND_ACTIVE(_LCN_IDA, _YEAR, _TR_LCN_EDIT, True)
        TXT_RQ_NUMBER.Text = dao.fields.STAFF_RQ_NUMBER
        TXT_APPROVE_DATE.Text = Date.Now.ToString("dd/MM/yyyy")

        Try
            DDL_APPROVE_STAFF.SelectedValue = dao.fields.STAFF_APPROVE_NAME_ID
        Catch ex As Exception

        End Try
        TXT_APPROVE_NOTE.Text = dao.fields.STAFF_APPROVE_NOTE
    End Sub
    Public Sub BIND_STATUS()
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_LCN_EDIT_STATUS(9)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DDL_APPROVE_STAFF.DataSource = dt
        DDL_APPROVE_STAFF.DataBind()
        DDL_APPROVE_STAFF.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        ' Dim bao As New BAO_LCN.TABLE_VIEW
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_DALCN_EDIT_UPLOAD_FILE(dao.fields.TR_ID, 1)
        'dt = bao.SP_LCN_APPROVE_EDIT_GET_UPLOAD_FILE(_REASON_TYPE)

        Return dt
    End Function

    'Function bind_data_uploadfile()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_LCN.TABLE_VIEW

    '    dt = bao.SP_LCN_APPROVE_EDIT_GET_UPLOAD_FILE(_REASON_TYPE)

    '    Return dt
    'End Function

    Public Sub Run_PDF_SMP3()

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(dao.fields.LCN_PROCESS_ID, dao.fields.STATUS_ID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", dao.fields.LCN_PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:850px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim lcn_ida As Integer = _LCN_IDA
            Dim FILE_NUMBER_NAME As Integer = item("FILE_NUMBER_NAME").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_EDIT/FRM_LCN_EDIT_PREVIEW_FILE.aspx?file_id=" & FILE_NUMBER_NAME & "&lcn_ida=" & lcn_ida

        End If

    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click

        Dim dao_log As New DAO_DRUG.TB_LOG_STATUS
        dao_log.fields.STATUS_ID = DD_STATUS.SelectedValue
        dao_log.fields.PROCESS_ID = 10201
        dao_log.fields.STATUS_DATE = System.DateTime.Now
        dao_log.fields.IDENTIFY = _CLS_CITIZEN_ID
        dao_log.fields.FK_IDA = _LCN_IDA
        dao_log.insert()

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim _YEAR As String = con_year(Date.Now().Year())
        'dao.GetDataBY_LCN_IDA_LCN_EDIT_REASON_TYPE_YEAR(_LCN_IDA, _ddl1, _YEAR, True)
        dao.GetDataby_IDA(_IDA)

        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        dao.fields.STATUS_NAME = DD_STATUS.SelectedItem.Text

        Try
            dao.fields.STAFF_APPROVE_DATE = DateTime.ParseExact(TXT_APPROVE_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.STAFF_APPROVE_DATE = System.DateTime.Now
        End Try

        dao.fields.STAFF_APPROVE_NAME_ID = DDL_APPROVE_STAFF.SelectedValue
        dao.fields.STAFF_APPROVE_NAME = DDL_APPROVE_STAFF.SelectedItem.Text
        dao.fields.STAFF_APPROVE_NOTE = TXT_APPROVE_NOTE.Text

        dao.update()

        AddLogStatus(dao.fields.STATUS_ID, dao.fields.LCN_PROCESS_ID, _CLS.CITIZEN_ID, dao.fields.IDA)

        If DD_STATUS.SelectedValue = 8 Then

            If _ddl1 = 1 Then
                SET_UPDATE_DDL1()
            ElseIf _ddl1 = 2 Then
                SET_UPDATE_DDL2()
            ElseIf _ddl1 = 3 Then
                If _ddl2 = 1 Then
                    SET_UPDATE_DDL3_SUB1()
                ElseIf _ddl2 = 2 Then
                    SET_UPDATE_DDL3_SUB2()
                End If
            ElseIf _ddl1 = 4 Then
                SET_UPDATE_DDL4()
            ElseIf _ddl1 = 5 Then
                SET_UPDATE_DDL5()
            ElseIf _ddl1 = 6 Then
                SET_UPDATE_DDL6()
            ElseIf _ddl1 = 7 Then
                SET_UPDATE_DDL7()
            ElseIf _ddl1 = 8 Then
                SET_UPDATE_DDL8()
            ElseIf _ddl1 = 9 Then
                If _ddl2 = 1 Then
                    SET_UPDATE_DDL9_SUB1()
                ElseIf _ddl2 = 2 Then
                    SET_UPDATE_DDL9_SUB2()
                ElseIf _ddl2 = 3 Then
                    SET_UPDATE_DDL9_SUB3()
                End If
            ElseIf _ddl1 = 10 Then
                SET_UPDATE_DDL10()
            ElseIf _ddl1 = 11 Then
                SET_UPDATE_DDL11()
            End If
        End If

        LOG_EDIT_MIGRATE()
        Dim ida_xml As Integer = 0
        Dim process_xml As Integer = 0
        Dim year_xml As Integer = 0
        Dim tr_id_xml As Integer = 0
        ida_xml = dao.fields.IDA
        process_xml = dao.fields.LCN_PROCESS_ID
        year_xml = dao.fields.DATE_YEAR
        tr_id_xml = dao.fields.TR_ID

        bind_pdf_xml_8(ida_xml, _LCN_IDA, process_xml, dao.fields.STATUS_ID, year_xml, tr_id_xml)
        'Run_Service(_LCN_IDA)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub
    Sub Run_Service(ByVal IDA As Integer)
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.HERB_UPDATE_LICEN(IDA, _CLS.CITIZEN_ID)
    End Sub
    Public Sub bind_pdf_xml_8(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
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

    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');", True)
        End If

    End Sub

    Public Sub SET_UPDATE_DDL1()
        Dim GET_1 As String = ""
        Dim GET_2 As String = ""
        Dim GET_3 As String = ""
        Dim GET_4 As String = ""
        Dim GET_5 As String = ""
        Dim GET_6 As DateTime

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)

        GET_1 = dao1.fields.PHR_TEXT_JOB
        GET_2 = dao1.fields.PHR_TEXT_NUM
        GET_3 = dao1.fields.STUDY_LEVEL
        GET_4 = dao1.fields.PHR_SAKHA
        GET_5 = dao1.fields.NAME_SIMINAR
        If dao1.fields.SIMINAR_DATE IsNot Nothing Then
            GET_6 = dao1.fields.SIMINAR_DATE
        End If

        For Each dao1.fields In dao1.datas
            Dim dao_update As New DAO_DRUG.ClsDBDALCN_PHR
            dao_update.GetDataby_IDA(dao1.fields.PHR_IDA) 'เพิ่ม get ตัวใหม่
            If dao_update.fields.PHR_IDA = 0 Then
                dao_update.fields.PHR_TEXT_JOB = GET_1
                dao_update.fields.PHR_TEXT_NUM = GET_2
                dao_update.fields.STUDY_LEVEL = GET_3
                dao_update.fields.PHR_SAKHA = GET_4
                dao_update.fields.NAME_SIMINAR = GET_5
                If dao1.fields.SIMINAR_DATE IsNot Nothing Then
                    dao_update.fields.SIMINAR_DATE = GET_6
                End If
                dao_update.fields.SIMINAR_DATE = GET_6
                dao_update.fields.PHR_CTZNO = dao1.fields.PHR_CTZNO
                dao_update.fields.PHR_PREFIX_ID = dao1.fields.PHR_PREFIX_ID
                dao_update.fields.PHR_NAME = dao1.fields.PHR_NAME
                dao_update.fields.PHR_TEXT_WORK_TIME = dao1.fields.PHR_TEXT_WORK_TIME
                dao_update.fields.PHR_LAW_SECTION = dao1.fields.PHR_LAW_SECTION
                'dao_update.fields.PHR_TEXT_JOB = dao1.fields.PHR_TEXT_JOB
                dao_update.insert()
            Else
                dao_update.fields.PHR_TEXT_JOB = GET_1
                dao_update.fields.PHR_TEXT_NUM = GET_2
                dao_update.fields.STUDY_LEVEL = GET_3
                dao_update.fields.PHR_SAKHA = GET_4
                dao_update.fields.NAME_SIMINAR = GET_5
                If dao1.fields.SIMINAR_DATE IsNot Nothing Then
                    dao_update.fields.SIMINAR_DATE = GET_6
                End If
                dao_update.fields.PHR_CTZNO = dao1.fields.PHR_CTZNO
                dao_update.fields.PHR_PREFIX_ID = dao1.fields.PHR_PREFIX_ID
                dao_update.fields.PHR_NAME = dao1.fields.PHR_NAME
                dao_update.fields.PHR_TEXT_WORK_TIME = dao1.fields.PHR_TEXT_WORK_TIME
                dao_update.fields.PHR_LAW_SECTION = dao1.fields.PHR_LAW_SECTION
                'dao_update.fields.PHR_TEXT_JOB = dao1.fields.PHR_TEXT_JOB
                dao_update.update()
            End If
        Next

    End Sub
    Public Sub SET_UPDATE_DDL2()
        Dim GET_1 As String = ""
        Dim GET_2 As String = ""
        Dim GET_3 As String = ""
        Dim GET_4 As String = ""
        Dim GET_5 As String = ""
        Dim GET_6 As String = ""
        Dim GET_7 As String = ""
        Dim GET_8 As String = ""
        Dim GET_9 As String = ""
        Dim GET_10 As String = ""
        Dim GET_11 As String = ""
        Dim GET_12 As String = ""
        Dim GET_13 As String = ""
        Dim GET_14 As String = ""
        Dim GET_15 As String = ""

        Dim GET_KEEP_1 As String = ""
        Dim GET_KEEP_2 As String = ""
        Dim GET_KEEP_3 As String = ""
        Dim GET_KEEP_4 As String = ""
        Dim GET_KEEP_5 As String = ""
        Dim GET_KEEP_6 As String = ""
        Dim GET_KEEP_7 As String = ""
        Dim GET_KEEP_8 As String = ""
        Dim GET_KEEP_9 As String = ""
        Dim GET_KEEP_10 As String = ""
        Dim GET_KEEP_11 As String = ""
        Dim GET_KEEP_12 As String = ""
        Dim GET_KEEP_13 As String = ""
        Dim GET_KEEP_14 As String = ""

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL2_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCT_IDA, _ddl1, _ddl2, True)

        GET_1 = dao1.fields.thanameplace
        GET_2 = dao1.fields.HOUSENO
        GET_3 = dao1.fields.thaaddr
        GET_4 = dao1.fields.thabuilding
        GET_5 = dao1.fields.thamu
        GET_6 = dao1.fields.thasoi
        GET_7 = dao1.fields.tharoad
        GET_8 = dao1.fields.thathmblnm
        GET_9 = dao1.fields.thaamphrnm
        GET_10 = dao1.fields.thachngwtnm
        GET_11 = dao1.fields.zipcode
        GET_12 = dao1.fields.fax
        GET_13 = dao1.fields.tel
        GET_14 = dao1.fields.email
        GET_15 = dao1.fields.opentime




        'สถานที่เก็บ

        GET_KEEP_1 = dao1.fields.KEEP_thanameplace
        GET_KEEP_2 = dao1.fields.KEEP_HOUSENO
        GET_KEEP_3 = dao1.fields.KEEP_thaaddr
        GET_KEEP_4 = dao1.fields.KEEP_thabuilding
        GET_KEEP_5 = dao1.fields.KEEP_thamu
        GET_KEEP_6 = dao1.fields.KEEP_thasoi
        GET_KEEP_7 = dao1.fields.KEEP_tharoad
        GET_KEEP_8 = dao1.fields.KEEP_thathmblnm
        GET_KEEP_9 = dao1.fields.KEEP_thaamphrnm
        GET_KEEP_10 = dao1.fields.KEEP_thachngwtnm
        GET_KEEP_11 = dao1.fields.KEEP_zipcode
        GET_KEEP_12 = dao1.fields.KEEP_fax
        GET_KEEP_13 = dao1.fields.KEEP_tel
        GET_KEEP_14 = dao1.fields.KEEP_email


        Dim dao_update1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_update1.GetDataby_IDA(_LCT_IDA)

        dao_update1.fields.thanameplace = GET_1
        dao_update1.fields.HOUSENO = GET_2
        dao_update1.fields.thaaddr = GET_3
        dao_update1.fields.thabuilding = GET_4
        dao_update1.fields.thamu = GET_5
        dao_update1.fields.thasoi = GET_6
        dao_update1.fields.tharoad = GET_7
        dao_update1.fields.thathmblnm = GET_8
        dao_update1.fields.thaamphrnm = GET_9
        dao_update1.fields.thachngwtnm = GET_10
        dao_update1.fields.zipcode = GET_11
        dao_update1.fields.fax = GET_12
        dao_update1.fields.tel = GET_13
        'dao_update1.fields.email = GET_14 'รอเพิ่มฟิว email
        'dao_update1.fields.opentime = GET_15 'รอเพิ่มฟิว opentime

        dao_update1.update()

        'สถานที่เก็บ
        Dim dao_update2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        Dim CHK_ROW As String = ""
        Try
            dao_update2.GetData_by_LOCATION_ADDRESS_IDA_AND_LCN_IDA(_LCT_IDA, _LCN_IDA)
            If dao_update2.fields.IDA <> 0 Then
                CHK_ROW = "HAVE"
            Else
                CHK_ROW = "NULL"
            End If
        Catch ex As Exception
            CHK_ROW = "NULL"
        End Try
        If CHK_ROW = "HAVE" Then
            dao_update2.fields.LOCATION_ADDRESS_thanameplace = GET_KEEP_1
            dao_update2.fields.LOCATION_ADDRESS_HOUSENO = GET_KEEP_2
            dao_update2.fields.LOCATION_ADDRESS_thaaddr = GET_KEEP_3
            dao_update2.fields.LOCATION_ADDRESS_thabuilding = GET_KEEP_4
            dao_update2.fields.LOCATION_ADDRESS_thamu = GET_KEEP_5
            dao_update2.fields.LOCATION_ADDRESS_thasoi = GET_KEEP_6
            dao_update2.fields.LOCATION_ADDRESS_tharoad = GET_KEEP_7
            dao_update2.fields.LOCATION_ADDRESS_thathmblnm = GET_KEEP_8
            dao_update2.fields.LOCATION_ADDRESS_thaamphrnm = GET_KEEP_9
            dao_update2.fields.LOCATION_ADDRESS_thachngwtnm = GET_KEEP_10
            dao_update2.fields.LOCATION_ADDRESS_zipcode = GET_KEEP_11
            dao_update2.fields.LOCATION_ADDRESS_fax = GET_KEEP_12
            dao_update2.fields.LOCATION_ADDRESS_tel = GET_KEEP_13
            'dao_update2.fields.KEEP_email = GET_KEEP_14 'รอเพิ่มฟิว KEEP_email

            dao_update2.update()
        ElseIf CHK_ROW = "NULL" Then
            dao_update2.fields.LCN_IDA = _LCN_IDA
            dao_update2.fields.LOCATION_ADDRESS_IDA = _LCT_IDA

            dao_update2.fields.LOCATION_ADDRESS_thanameplace = GET_KEEP_1
            dao_update2.fields.LOCATION_ADDRESS_HOUSENO = GET_KEEP_2
            dao_update2.fields.LOCATION_ADDRESS_thaaddr = GET_KEEP_3
            dao_update2.fields.LOCATION_ADDRESS_thabuilding = GET_KEEP_4
            dao_update2.fields.LOCATION_ADDRESS_thamu = GET_KEEP_5
            dao_update2.fields.LOCATION_ADDRESS_thasoi = GET_KEEP_6
            dao_update2.fields.LOCATION_ADDRESS_tharoad = GET_KEEP_7
            dao_update2.fields.LOCATION_ADDRESS_thathmblnm = GET_KEEP_8
            dao_update2.fields.LOCATION_ADDRESS_thaamphrnm = GET_KEEP_9
            dao_update2.fields.LOCATION_ADDRESS_thachngwtnm = GET_KEEP_10
            dao_update2.fields.LOCATION_ADDRESS_zipcode = GET_KEEP_11
            dao_update2.fields.LOCATION_ADDRESS_fax = GET_KEEP_12
            dao_update2.fields.LOCATION_ADDRESS_tel = GET_KEEP_13
            'dao_update2.fields.KEEP_email = GET_KEEP_14 'รอเพิ่มฟิว KEEP_email
            dao_update2.fields.ACTIVE = 1

            dao_update2.insert()
        End If

    End Sub

    Public Sub SET_UPDATE_DDL3_SUB1()

        Dim GET_1 As String = ""
        Dim GET_2 As String = ""
        Dim GET_3 As String = ""
        Dim GET_4 As String = ""
        Dim GET_5 As String = ""
        Dim GET_6 As Integer = 0
        Dim GET_7 As Integer = 0
        Dim GET_8 As Integer = 0
        Dim GET_9 As String = ""
        Dim GET_10 As String = ""
        Dim GET_11 As String = ""
        Dim GET_12 As String = ""

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)

        GET_1 = dao1.fields.thaaddr
        GET_2 = dao1.fields.thabuilding
        GET_3 = dao1.fields.thamu
        GET_4 = dao1.fields.thasoi
        GET_5 = dao1.fields.tharoad

        GET_6 = dao1.fields.thmblcd
        GET_7 = dao1.fields.amphrcd
        GET_8 = dao1.fields.chngwtcd

        GET_9 = dao1.fields.zipcode
        GET_10 = dao1.fields.tel
        GET_11 = dao1.fields.fax
        GET_12 = dao1.fields.email

        Dim dao_update1 As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS

        dao_update1.GetData_By_FK_IDA(_LCN_IDA)
        dao_update1.fields.thaaddr = GET_1
        dao_update1.fields.thabuilding = GET_2
        dao_update1.fields.thamu = GET_3
        dao_update1.fields.thasoi = GET_4
        dao_update1.fields.tharoad = GET_5

        dao_update1.fields.thmblcd = GET_6 'ควรแก้เป็น String
        dao_update1.fields.amphrcd = GET_7 'ควรแก้เป็น String
        dao_update1.fields.chngwtcd = GET_8 'ควรแก้เป็น String
        dao_update1.fields.zipcode = GET_9
        dao_update1.fields.tel = GET_10
        dao_update1.fields.fax = GET_11
        dao_update1.fields.email = GET_12

        dao_update1.update()



    End Sub
    Public Sub SET_UPDATE_DDL3_SUB2()

        Dim GET_1 As String = ""
        Dim GET_2 As DateTime
        Dim GET_3 As String = ""
        Dim GET_4 As DateTime

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)

        GET_1 = dao1.fields.GIVE_PASSPORT_NO

        GET_2 = dao1.fields.GIVE_PASSPORT_EXPDATE
        GET_3 = dao1.fields.GIVE_WORK_LICENSE_NO
        GET_4 = dao1.fields.GIVE_WORK_LICENSE_EXPDATE


        Dim dao_update As New DAO_DRUG.ClsDBdalcn
        dao_update.GetDataby_IDA(_LCN_IDA)
        dao_update.fields.GIVE_PASSPORT_NO = GET_1
        dao_update.fields.GIVE_PASSPORT_EXPDATE = GET_2
        dao_update.fields.GIVE_WORK_LICENSE_NO = GET_3
        dao_update.fields.GIVE_WORK_LICENSE_EXPDATE = GET_4


        dao_update.update()

    End Sub

    Public Sub SET_UPDATE_DDL4()
        Dim GET_1 As String = ""
        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL4_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
        GET_1 = dao1.fields.opentime

        Dim dao_update As New DAO_DRUG.ClsDBdalcn
        dao_update.GetDataby_IDA(_LCN_IDA)
        dao_update.fields.opentime = GET_1
        dao_update.update()
    End Sub
    Public Sub SET_UPDATE_DDL5()

        Dim GET_1 As String = ""
        Dim GET_2 As String = ""
        Dim GET_3 As String = ""
        Dim GET_4 As String = ""

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA(_LCT_IDA, True)

        GET_1 = dao1.fields.tel
        GET_2 = dao1.fields.email
        GET_3 = dao1.fields.KEEP_tel
        GET_4 = dao1.fields.KEEP_email


        Dim dao_update1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_update1.GetDataby_IDA(_LCT_IDA)

        dao_update1.fields.tel = GET_1
        'dao_update1.fields.email = GET_2 'รอเพิ่มฟิว email 
        dao_update1.update()

        'สถานที่เก็บ
        Dim dao_update2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_update2.GetData_by_LOCATION_ADDRESS_IDA_AND_LCN_IDA(_LCT_IDA, _LCN_IDA)

        dao_update2.fields.LOCATION_ADDRESS_tel = GET_3
        'dao_update2.fields.KEEP_email = GET_4 'รอเพิ่มฟิว KEEP_email
        dao_update2.update()

        Dim dao2 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON
        dao2.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)
        'UPDATE ACTIVE = 0 ก่อน update ใหม่
        Dim dao_update3 As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        Try
            dao_update3.GetDataby_FKIDA(_LCN_IDA)
        Catch ex As Exception

        End Try

        For Each dao_update3.fields In dao_update3.datas
            dao_update3.delete()
        Next

        For Each dao2.fields In dao2.datas
            Dim GET_DDL5_1 As Integer = 0
            Dim GET_DDL5_2 As Integer = 0
            Dim GET_DDL5_3 As String = ""
            Dim GET_DDL5_4 As String = ""
            Dim GET_DDL5_5 As String = ""
            Dim GET_DDL5_6 As String = ""
            Dim GET_DDL5_7 As String = ""
            Dim GET_DDL5_8 As String = ""
            Dim GET_DDL5_9 As String = ""

            'dao2.fields.ddl1 = _ddl1
            'dao2.fields.ddl2 = _ddl2

            GET_DDL5_1 = dao2.fields.FK_IDA_CHK_ROW
            GET_DDL5_2 = dao2.fields.FK_LCN_IDA
            GET_DDL5_3 = dao2.fields.COL1
            GET_DDL5_4 = dao2.fields.COL2
            GET_DDL5_5 = dao2.fields.COL3
            GET_DDL5_6 = dao2.fields.COL4
            GET_DDL5_7 = dao2.fields.COL5
            GET_DDL5_8 = dao2.fields.COL6
            GET_DDL5_9 = dao2.fields.COL6_OTHER

            Dim dao_new As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

            dao_new.fields.FK_IDA = GET_DDL5_1
                dao_new.fields.LCN_IDA = GET_DDL5_2
                dao_new.fields.COL1 = GET_DDL5_3
                dao_new.fields.COL2 = GET_DDL5_4
                dao_new.fields.COL3 = GET_DDL5_5
                dao_new.fields.COL4 = GET_DDL5_6
                dao_new.fields.COL5 = GET_DDL5_7
                dao_new.fields.COL6 = GET_DDL5_8
                dao_new.fields.COL6_OTHER = GET_DDL5_9
            dao_new.insert()

        Next
    End Sub
    Public Sub SET_UPDATE_DDL6()

        Dim GET_1 As String = ""
        Dim GET_2 As String = ""
        Dim GET_3 As String = ""
        Dim GET_4 As String = ""
        Dim GET_5 As String = ""
        Dim GET_6 As String = ""
        Dim GET_7 As String = ""
        Dim GET_8 As String = ""
        Dim GET_9 As String = ""
        Dim GET_10 As String = ""
        Dim GET_11 As String = ""
        Dim GET_12 As String = ""
        Dim GET_13 As String = ""
        Dim GET_14 As String = ""
        Dim GET_15 As String = ""

        Dim GET_KEEP_1 As String = ""
        Dim GET_KEEP_2 As String = ""
        Dim GET_KEEP_3 As String = ""
        Dim GET_KEEP_4 As String = ""
        Dim GET_KEEP_5 As String = ""
        Dim GET_KEEP_6 As String = ""
        Dim GET_KEEP_7 As String = ""
        Dim GET_KEEP_8 As String = ""
        Dim GET_KEEP_9 As String = ""
        Dim GET_KEEP_10 As String = ""
        Dim GET_KEEP_11 As String = ""
        Dim GET_KEEP_12 As String = ""
        Dim GET_KEEP_13 As String = ""
        Dim GET_KEEP_14 As String = ""

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL6_REASON
        dao1.GET_DATA_BY_FK_LCT_IDA(_LCT_IDA, True)

        GET_1 = dao1.fields.thanameplace
        GET_2 = dao1.fields.HOUSENO
        GET_3 = dao1.fields.thaaddr
        GET_4 = dao1.fields.thabuilding
        GET_5 = dao1.fields.thamu
        GET_6 = dao1.fields.thasoi
        GET_7 = dao1.fields.tharoad
        GET_8 = dao1.fields.thathmblnm
        GET_9 = dao1.fields.thaamphrnm
        GET_10 = dao1.fields.thachngwtnm
        GET_11 = dao1.fields.zipcode
        GET_12 = dao1.fields.fax
        GET_13 = dao1.fields.tel
        GET_14 = dao1.fields.email
        GET_15 = dao1.fields.opentime


        'สถานที่เก็บ
        GET_KEEP_1 = dao1.fields.KEEP_thanameplace
        GET_KEEP_2 = dao1.fields.KEEP_HOUSENO
        GET_KEEP_3 = dao1.fields.KEEP_thaaddr
        GET_KEEP_4 = dao1.fields.KEEP_thabuilding
        GET_KEEP_5 = dao1.fields.KEEP_thamu
        GET_KEEP_6 = dao1.fields.KEEP_thasoi
        GET_KEEP_7 = dao1.fields.KEEP_tharoad
        GET_KEEP_8 = dao1.fields.KEEP_thathmblnm
        GET_KEEP_9 = dao1.fields.KEEP_thaamphrnm
        GET_KEEP_10 = dao1.fields.KEEP_thachngwtnm
        GET_KEEP_11 = dao1.fields.KEEP_zipcode
        GET_KEEP_12 = dao1.fields.KEEP_fax
        GET_KEEP_13 = dao1.fields.KEEP_tel
        GET_KEEP_14 = dao1.fields.KEEP_email

        Dim dao_update1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_update1.GetDataby_IDA(_LCT_IDA)

        dao_update1.fields.thanameplace = GET_1
        dao_update1.fields.HOUSENO = GET_2
        dao_update1.fields.thaaddr = GET_3
        dao_update1.fields.thabuilding = GET_4
        dao_update1.fields.thamu = GET_5
        dao_update1.fields.thasoi = GET_6
        dao_update1.fields.tharoad = GET_7
        dao_update1.fields.thathmblnm = GET_8
        dao_update1.fields.thaamphrnm = GET_9
        dao_update1.fields.thachngwtnm = GET_10
        dao_update1.fields.zipcode = GET_11
        dao_update1.fields.fax = GET_12
        dao_update1.fields.tel = GET_13
        'dao_update1.fields.email = GET_14 'รอเพิ่มฟิว email
        'dao_update1.fields.opentime= GET_15 'รอเพิ่มฟิว opentime

        dao_update1.update()

        'สถานที่เก็บ
        Dim dao_update2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_update2.GetData_by_LOCATION_ADDRESS_IDA_AND_LCN_IDA(_LCT_IDA, _LCN_IDA)

        dao_update2.fields.LOCATION_ADDRESS_thanameplace = GET_KEEP_1
        dao_update2.fields.LOCATION_ADDRESS_HOUSENO = GET_KEEP_2
        dao_update2.fields.LOCATION_ADDRESS_thaaddr = GET_KEEP_3
        dao_update2.fields.LOCATION_ADDRESS_thabuilding = GET_KEEP_4
        dao_update2.fields.LOCATION_ADDRESS_thamu = GET_KEEP_5
        dao_update2.fields.LOCATION_ADDRESS_thasoi = GET_KEEP_6
        dao_update2.fields.LOCATION_ADDRESS_tharoad = GET_KEEP_7
        dao_update2.fields.LOCATION_ADDRESS_thathmblnm = GET_KEEP_8
        dao_update2.fields.LOCATION_ADDRESS_thaamphrnm = GET_KEEP_9
        dao_update2.fields.LOCATION_ADDRESS_thachngwtnm = GET_KEEP_10
        dao_update2.fields.LOCATION_ADDRESS_zipcode = GET_KEEP_11
        dao_update2.fields.LOCATION_ADDRESS_fax = GET_KEEP_12
        dao_update2.fields.LOCATION_ADDRESS_tel = GET_KEEP_13
        'dao_update2.fields.LOCATION_ADDRESS_email = GET_KEEP_14 'รอเพิ่มฟิว  LOCATION_ADDRESS_email

        dao_update2.update()

    End Sub
    Public Sub SET_UPDATE_DDL7()

        Dim GET_1 As String = ""
        Dim GET_2 As String = ""
        Dim GET_3 As String = ""

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL7_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)

        GET_1 = dao1.fields.DALCN_BSN_THAIFULLNAME
        GET_2 = dao1.fields.BSN_THAIFULLNAME
        GET_3 = dao1.fields.PHR_TEXT_JOB

        Dim dao_update1 As New DAO_DRUG.ClsDBdalcn
        dao_update1.GetDataby_IDA(_LCN_IDA)
        dao_update1.fields.BSN_THAIFULLNAME = GET_1
        dao_update1.update()

        Dim dao_update2 As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_update2.GetDataby_LCN_IDA(_LCN_IDA)
        dao_update2.fields.BSN_THAIFULLNAME = GET_2
        dao_update2.update()

        Dim dao_update3 As New DAO_DRUG.ClsDBDALCN_PHR
        dao_update3.GetDataby_FK_IDA(_LCN_IDA)
        dao_update3.fields.PHR_TEXT_JOB = GET_3
        dao_update3.update()

    End Sub
    Public Sub SET_UPDATE_DDL8()

        Dim GET_1 As String = ""
        Dim GET_2 As String = ""
        Dim GET_3 As String = ""
        Dim GET_4 As String = ""

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL8_REASON
        dao1.GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(_LCT_IDA, _ddl1, _ddl2, True)

        GET_1 = dao1.fields.thanameplace
        GET_2 = dao1.fields.HOUSENO
        GET_3 = dao1.fields.thaaddr
        GET_4 = dao1.fields.thabuilding

        Dim dao_update1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_update1.GetDataby_IDA(_LCT_IDA)
        dao_update1.fields.thanameplace = GET_1
        dao_update1.fields.HOUSENO = GET_2
        dao_update1.fields.thaaddr = GET_3
        dao_update1.fields.thabuilding = GET_4

        dao_update1.update()

    End Sub
    Public Sub SET_UPDATE_DDL9_SUB1()
        Dim GET_1 As String = ""
        Dim GET_2 As DateTime
        Dim GET_3 As String = ""
        Dim GET_4 As DateTime
        Dim GET_5 As String = ""
        Dim GET_6 As DateTime
        Dim GET_7 As String = ""
        Dim GET_8 As DateTime
        Dim GET_9 As String = ""
        Dim GET_10 As DateTime

        Dim dao_get As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
        dao_get.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)

        GET_1 = dao_get.fields.PASSPORT_NO
        GET_2 = dao_get.fields.PASSPORT_EXPDATE
        GET_3 = dao_get.fields.BS_NO
        GET_4 = dao_get.fields.BS_DATE
        GET_5 = dao_get.fields.WORK_LICENSE_NO
        GET_6 = dao_get.fields.WORK_LICENSE_EXPDATE
        GET_7 = dao_get.fields.DOC_NO
        GET_8 = dao_get.fields.DOC_DATE
        GET_9 = dao_get.fields.FRGN_NO
        GET_10 = dao_get.fields.FRGN_DATE

        Dim dao_update As New DAO_DRUG.TB_DALCN_FRGN_DATA
        Dim CHK_ROW As String = ""
        Try
            dao_update.GetDataby_FK_IDA_AND_PERSON_TYPE(_LCN_IDA, 1)
            If dao_update.fields.IDA <> 0 Then
                CHK_ROW = "HAVE"
            Else
                CHK_ROW = "NULL"
            End If
        Catch ex As Exception
            CHK_ROW = "NULL"
        End Try

        If CHK_ROW = "HAVE" Then

            dao_update.fields.PASSPORT_NO = GET_1
            dao_update.fields.PASSPORT_EXPDATE = GET_2
            dao_update.fields.BS_NO = GET_3
            dao_update.fields.BS_DATE = GET_4
            dao_update.fields.WORK_LICENSE_NO = GET_5
            dao_update.fields.WORK_LICENSE_EXPDATE = GET_6
            dao_update.fields.DOC_NO = GET_7
            dao_update.fields.DOC_DATE = GET_8
            dao_update.fields.FRGN_NO = GET_9
            dao_update.fields.FRGN_DATE = GET_10

            dao_update.update()

        ElseIf CHK_ROW = "NULL" Then

            dao_update.fields.FK_IDA = _LCN_IDA
            dao_update.fields.PASSPORT_NO = GET_1
            dao_update.fields.PASSPORT_EXPDATE = GET_2
            dao_update.fields.BS_NO = GET_3
            dao_update.fields.BS_DATE = GET_4
            dao_update.fields.WORK_LICENSE_NO = GET_5
            dao_update.fields.WORK_LICENSE_EXPDATE = GET_6
            dao_update.fields.DOC_NO = GET_7
            dao_update.fields.DOC_DATE = GET_8
            dao_update.fields.FRGN_NO = GET_9
            dao_update.fields.FRGN_DATE = GET_10

            dao_update.insert()
        End If
    End Sub
    Public Sub SET_UPDATE_DDL9_SUB2()
        Dim GET_1 As String = ""
        Dim GET_2 As DateTime
        Dim GET_3 As String = ""
        Dim GET_4 As DateTime
        Dim GET_5 As String = ""
        Dim GET_6 As DateTime
        Dim GET_7 As String = ""
        Dim GET_8 As DateTime

        Dim dao_get As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
        dao_get.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)

        GET_1 = dao_get.fields.DOC_NO
        GET_2 = dao_get.fields.DOC_DATE
        GET_3 = dao_get.fields.FRGN_NO
        GET_4 = dao_get.fields.FRGN_DATE
        GET_5 = dao_get.fields.GIVE_PASSPORT_NO
        GET_6 = dao_get.fields.GIVE_PASSPORT_EXPDATE
        GET_7 = dao_get.fields.GIVE_WORK_LICENSE_NO
        GET_8 = dao_get.fields.GIVE_WORK_LICENSE_EXPDATE

        Dim dao_update1 As New DAO_DRUG.TB_DALCN_FRGN_DATA
        Dim CHK_ROW As String = ""
        Try
            dao_update1.GetDataby_FK_IDA_AND_PERSON_TYPE(_LCN_IDA, 2)
            If dao_update1.fields.IDA <> 0 Then
                CHK_ROW = "HAVE"
            Else
                CHK_ROW = "NULL"
            End If
        Catch ex As Exception
            CHK_ROW = "NULL"
        End Try

        If CHK_ROW = "HAVE" Then
            dao_update1.fields.DOC_NO = GET_1
            dao_update1.fields.DOC_DATE = GET_2
            dao_update1.fields.FRGN_NO = GET_3
            dao_update1.fields.FRGN_DATE = GET_4

            dao_update1.update()
        ElseIf CHK_ROW = "NULL" Then
            dao_update1.fields.FK_IDA = _LCN_IDA
            dao_update1.fields.PERSONAL_TYPE = 2
            dao_update1.fields.DOC_NO = GET_1
            dao_update1.fields.DOC_DATE = GET_2
            dao_update1.fields.FRGN_NO = GET_3
            dao_update1.fields.FRGN_DATE = GET_4

            dao_update1.insert()
        End If


        Dim dao_update2 As New DAO_DRUG.ClsDBdalcn
        dao_update2.GetDataby_IDA(_LCN_IDA)
        dao_update2.fields.GIVE_PASSPORT_NO = GET_5
        dao_update2.fields.GIVE_PASSPORT_EXPDATE = GET_6
        dao_update2.fields.GIVE_WORK_LICENSE_NO = GET_7
        dao_update2.fields.GIVE_WORK_LICENSE_EXPDATE = GET_8

        dao_update2.update()


    End Sub
    Public Sub SET_UPDATE_DDL9_SUB3()

    End Sub
    Public Sub SET_UPDATE_DDL10()
        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL10_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)
        'UPDATE ACTIVE = 0 ก่อน update ใหม่
        Dim dao_update1 As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        Try
            dao_update1.GetDataby_FKIDA(_LCN_IDA)
        Catch ex As Exception

        End Try

        For Each dao_update1.fields In dao_update1.datas
            dao_update1.delete()
        Next

        For Each dao1.fields In dao1.datas
            Dim GET_DDL10_1 As Integer = 0
            Dim GET_DDL10_2 As Integer = 0
            Dim GET_DDL10_3 As String = ""
            Dim GET_DDL10_4 As String = ""
            Dim GET_DDL10_5 As String = ""
            Dim GET_DDL10_6 As String = ""
            Dim GET_DDL10_7 As String = ""
            Dim GET_DDL10_8 As String = ""
            Dim GET_DDL10_9 As String = ""

            'dao2.fields.ddl1 = _ddl1
            'dao2.fields.ddl2 = _ddl2

            GET_DDL10_1 = dao1.fields.FK_IDA_CHK_ROW
            GET_DDL10_2 = dao1.fields.FK_LCN_IDA
            GET_DDL10_3 = dao1.fields.COL1
            GET_DDL10_4 = dao1.fields.COL2
            GET_DDL10_5 = dao1.fields.COL3
            GET_DDL10_6 = dao1.fields.COL4
            GET_DDL10_7 = dao1.fields.COL5
            GET_DDL10_8 = dao1.fields.COL6
            GET_DDL10_9 = dao1.fields.COL6_OTHER

            Dim dao_new As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

            dao_new.fields.FK_IDA = GET_DDL10_1
            dao_new.fields.LCN_IDA = GET_DDL10_2
            dao_new.fields.COL1 = GET_DDL10_3
            dao_new.fields.COL2 = GET_DDL10_4
            dao_new.fields.COL3 = GET_DDL10_5
            dao_new.fields.COL4 = GET_DDL10_6
            dao_new.fields.COL5 = GET_DDL10_7
            dao_new.fields.COL6 = GET_DDL10_8
            dao_new.fields.COL6_OTHER = GET_DDL10_9
            dao_new.insert()

        Next

    End Sub

    Public Sub SET_UPDATE_DDL11()
        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL11_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)
        'UPDATE ACTIVE = 0 ก่อน update ใหม่
        Dim dao_update1 As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        Try
            dao_update1.GetDataby_FKIDA(_LCN_IDA)
        Catch ex As Exception

        End Try

        For Each dao_update1.fields In dao_update1.datas
            dao_update1.delete()
        Next

        For Each dao1.fields In dao1.datas
            Dim GET_DDL11_1 As Integer = 0
            Dim GET_DDL11_2 As Integer = 0
            Dim GET_DDL11_3 As String = ""
            Dim GET_DDL11_4 As String = ""
            Dim GET_DDL11_5 As String = ""
            Dim GET_DDL11_6 As String = ""
            Dim GET_DDL11_7 As String = ""
            Dim GET_DDL11_8 As String = ""
            Dim GET_DDL11_9 As String = ""

            'dao2.fields.ddl1 = _ddl1
            'dao2.fields.ddl2 = _ddl2

            GET_DDL11_1 = dao1.fields.FK_IDA_CHK_ROW
            GET_DDL11_2 = dao1.fields.FK_LCN_IDA
            GET_DDL11_3 = dao1.fields.COL1
            GET_DDL11_4 = dao1.fields.COL2
            GET_DDL11_5 = dao1.fields.COL3
            GET_DDL11_6 = dao1.fields.COL4
            GET_DDL11_7 = dao1.fields.COL5
            GET_DDL11_8 = dao1.fields.COL6
            GET_DDL11_9 = dao1.fields.COL6_OTHER

            Dim dao_new As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

            dao_new.fields.FK_IDA = GET_DDL11_1
            dao_new.fields.LCN_IDA = GET_DDL11_2
            dao_new.fields.COL1 = GET_DDL11_3
            dao_new.fields.COL2 = GET_DDL11_4
            dao_new.fields.COL3 = GET_DDL11_5
            dao_new.fields.COL4 = GET_DDL11_6
            dao_new.fields.COL5 = GET_DDL11_7
            dao_new.fields.COL6 = GET_DDL11_8
            dao_new.fields.COL6_OTHER = GET_DDL11_9
            dao_new.insert()

        Next
    End Sub
    Sub LOG_EDIT_MIGRATE()
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim URL As String = ""
        Dim Before_des As String = ""
        Dim After_des As String = ""
        Dim Citizen_ID As String = dao.fields.LCN_IDENTIFY
        If _ddl1 = 1 Then
            Before_des = "แก้ไขผู้มีหน้าที่ปฏิบัติการ เดิม "
            After_des = "แก้ไขผู้มีหน้าที่ปฏิบัติการ เป็น "
            Dim dao_dd1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON
            dao_dd1.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            After_des = After_des & dao_dd1.fields.PHR_NAME
            Dim dao_odd1 As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL1_REASON
            dao_odd1.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            Before_des = Before_des & dao_odd1.fields.PHR_NAME
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        ElseIf _ddl1 = 2 Then
            Dim thanameplace As String = ""
            Dim keep_thanameplace As String = ""
            Before_des = "แก้ไขสถานที่ตั้ง/เก็บ เดิม "
            After_des = "แก้ไขสถานที่ตั้ง/เก็บ เป็น "
            Dim dao_before As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL2_REASON
            dao_before.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            If dao_before.fields.thanameplace Is Nothing Then
                thanameplace = " "
            Else
                thanameplace = dao_before.fields.thanameplace
            End If
            If dao_before.fields.KEEP_thanameplace Is Nothing Then
                keep_thanameplace = "-"
            Else
                keep_thanameplace = dao_before.fields.KEEP_thanameplace
            End If
            Before_des = Before_des & thanameplace & "/" & keep_thanameplace
            Dim dao_after As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL2_REASON
            dao_after.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            If dao_after.fields.thanameplace Is Nothing Then
                thanameplace = "-"
            Else
                thanameplace = dao_after.fields.thanameplace
            End If
            If dao_after.fields.KEEP_thanameplace Is Nothing Then
                keep_thanameplace = "-"
            Else
                keep_thanameplace = dao_after.fields.KEEP_thanameplace
            End If
            After_des = After_des & thanameplace & "/" & keep_thanameplace
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        ElseIf _ddl1 = 3 Then
            If _ddl2 = 1 Then
                SET_UPDATE_DDL3_SUB1()
                Before_des = "แก้ไขที่อยู่ผู้รับมอบหมายหรือผู้ดำเนินกิจการ เดิม "
                After_des = "แก้ไขที่อยู่ผู้รับมอบหมายหรือผู้ดำเนินกิจการ เป็น "
                Dim dao_before As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL3_REASON
                dao_before.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
                Dim dao_c As New DAO_CPN.clsDBsyschngwt
                Try
                    dao_c.GetData_by_chngwtcd(dao_before.fields.chngwtcd)
                Catch ex As Exception

                End Try
                Before_des = Before_des & dao_c.fields.engchngwtnm
                Dim dao_after As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
                dao_after.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
                Try
                    dao_c.GetData_by_chngwtcd(dao_after.fields.chngwtcd)
                Catch ex As Exception

                End Try
                Before_des = Before_des & dao_c.fields.engchngwtnm
                After_des = After_des & dao_c.fields.engchngwtnm
                KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
            ElseIf _ddl2 = 2 Then
                Before_des = "แก้ไขเลขหนังสือเดินทางผู้ดำเนินกิจการ เดิม "
                After_des = "แก้ไขเลขหนังสือเดินทางผู้ดำเนินกิจการ เป็น "
                Dim dao_before As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL3_REASON
                dao_before.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
                Before_des = Before_des & dao_before.fields.GIVE_PASSPORT_NO
                Dim dao_after As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
                dao_after.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
                After_des = After_des & dao_after.fields.GIVE_PASSPORT_NO
                KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
            End If
        ElseIf _ddl1 = 4 Then
            Before_des = "แก้ไขเวลาทำการ เดิม "
            After_des = "แก้ไขเวลาทำการ เป็น "
            Dim dao_before As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL4_REASON
            dao_before.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            Before_des = Before_des & dao_before.fields.opentime
            Dim dao_after As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL4_REASON
            dao_after.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            After_des = After_des & dao_after.fields.opentime
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        ElseIf _ddl1 = 5 Then
            Before_des = "แก้ไขเบอร์โทรศัพท์ เดิม "
            After_des = "แก้ไขเบอร์โทรศัพท์ เป็น "
            Dim dao_before As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL5_REASON
            dao_before.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            Before_des = Before_des & dao_before.fields.tel
            Dim dao_after As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON
            dao_after.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            After_des = After_des & dao_after.fields.tel
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        ElseIf _ddl1 = 6 Then
            Before_des = "แก้ไขหมายเลขบ้าน/รายละเอียดของสถานที่ตั้ง  เดิม "
            After_des = "แก้ไขหมายเลขบ้าน/รายละเอียดของสถานที่ตั้ง  เป็น "
            Dim dao_before As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL6_REASON
            dao_before.GET_DATA_BY_FK_LCT_IDA(_LCT_IDA, True)
            Before_des = Before_des & dao_before.fields.thanameplace
            Dim dao_after As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL6_REASON
            dao_after.GET_DATA_BY_FK_LCT_IDA(_LCT_IDA, True)
            After_des = After_des & dao_after.fields.thanameplace
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        ElseIf _ddl1 = 7 Then
            Dim thanm_name As String = ""
            Dim bsn_name As String = ""
            Dim phr_name As String = ""
            Before_des = "แก้ไขคำนำหน้า/ชื่อตัว/ชื่อสกุล/ ของผู้รับอนุญาต ผู้มีหน้าที่ปฏิบัติการ ผู้ดำเนินกิจการ  เดิม "
            After_des = "แก้ไขคำนำหน้า/ชื่อตัว/ชื่อสกุล/ ของผู้รับอนุญาต ผู้มีหน้าที่ปฏิบัติการ ผู้ดำเนินกิจการ  เป็น "
            Dim dao_before As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL7_REASON
            dao_before.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            If dao_before.fields.DALCN_BSN_THAIFULLNAME Is Nothing Then
                thanm_name = "-"
            Else
                thanm_name = dao_before.fields.DALCN_BSN_THAIFULLNAME
            End If
            If dao_before.fields.BSN_THAIFULLNAME Is Nothing Then
                bsn_name = "-"
            Else
                bsn_name = dao_before.fields.BSN_THAIFULLNAME
            End If
            If dao_before.fields.PHR_TEXT_JOB Is Nothing Then
                phr_name = "-"
            Else
                phr_name = dao_before.fields.PHR_TEXT_JOB
            End If
            Before_des = Before_des & thanm_name & "/ " & bsn_name & "/ " & phr_name
            Dim dao_after As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL7_REASON
            dao_after.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            If dao_after.fields.DALCN_BSN_THAIFULLNAME Is Nothing Then
                thanm_name = "-"
            Else
                thanm_name = dao_after.fields.DALCN_BSN_THAIFULLNAME
            End If
            If dao_after.fields.BSN_THAIFULLNAME Is Nothing Then
                bsn_name = "-"
            Else
                bsn_name = dao_after.fields.BSN_THAIFULLNAME
            End If
            If dao_after.fields.PHR_TEXT_JOB Is Nothing Then
                phr_name = "-"
            Else
                phr_name = dao_after.fields.PHR_TEXT_JOB
            End If
            After_des = After_des & thanm_name & "/ " & bsn_name & "/ " & phr_name
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        ElseIf _ddl1 = 8 Then
            Before_des = "แก้ไขชื่อร้าน/ชื่อสถานที่  เดิม "
            After_des = "แก้ไขชื่อร้าน/ชื่อสถานที่ เป็น "
            Dim dao_before As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL8_REASON
            dao_before.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            Before_des = Before_des & dao_before.fields.thanameplace
            Dim dao_after As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL8_REASON
            dao_after.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
            After_des = After_des & dao_after.fields.thanameplace
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        ElseIf _ddl1 = 9 Then
            Before_des = "แก้ไขชื่อร้าน/ชื่อสถานที่  เดิม "
                After_des = "แก้ไขชื่อร้าน/ชื่อสถานที่ เป็น "
                Dim dao_before As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL8_REASON
                dao_before.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
                Before_des = Before_des & dao_before.fields.thanameplace
                Dim dao_after As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL8_REASON
                dao_after.GET_DATA_BY_FK_LCN_IDA(_LCN_IDA, True)
                After_des = After_des & dao_after.fields.thanameplace
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        ElseIf _ddl1 = 10 Then
            SET_UPDATE_DDL10()
            Before_des = " "
            After_des = "เพิ่มประเภทการผลิต"
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        ElseIf _ddl1 = 11 Then
            SET_UPDATE_DDL11()
            Before_des = " "
            After_des = "เพิ่มรายการผลิตผลิตภัณฑ์สมุนไพรที่ขออนุญาตนำเข้าหรือขาย"
            KEEP_LOGS_EDIT_LCN(_IDA, Before_des, After_des, Citizen_ID, URL)
        End If


    End Sub

End Class