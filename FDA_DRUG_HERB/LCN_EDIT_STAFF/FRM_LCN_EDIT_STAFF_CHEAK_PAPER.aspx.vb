Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_LCN_EDIT_STAFF_CHEAK_PAPER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _LCN_IDA As Integer
    Private _TR_ID As String

    Private _REASON_TYPE As String
    Private _STATUS_GROUP As Integer
    Private _STATUS_ID As Integer
    Private _dd1_file As Integer
    Private _dd2_file As Integer
    Private _PROCESS_ID As Integer
    Private _IDA As Integer

    Sub RunSession()

        _LCN_IDA = Request.QueryString("LCN_IDA")
        _REASON_TYPE = Request.QueryString("LCN_EDIT_REASON_TYPE")
        _STATUS_GROUP = Request.QueryString("STATUS_GROUP")
        _STATUS_ID = Request.QueryString("STATUS_ID")

        _dd1_file = Request.QueryString("ddl_up1")
        _dd2_file = Request.QueryString("ddl_up2")
        _IDA = Request.QueryString("IDA")


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
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/สมพ๓.pdf'></iframe>"


            bind_data()
            BIND_STATUS()
            bind_mas_staff()
            Run_PDF_SMP3()

            'DD_STATUS.SelectedValue = _STATUS_ID
        End If
    End Sub

    Public Sub bind_data()
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim _YEAR As String = con_year(Date.Now().Year())
        dao.GetDataby_LCN_IDA_AND_YEAR_AND_ACTIVE(_LCN_IDA, _YEAR, True)
        _PROCESS_ID = dao.fields.LCN_PROCESS_ID
        TXT_RQ_NUM.Text = dao.fields.STAFF_RQ_NUMBER
        TXT_CHECK_DATE.Text = Date.Now.ToString("dd/MM/yyyy")
    End Sub

    Public Sub Run_PDF_SMP3()

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(dao.fields.LCN_PROCESS_ID, dao.fields.STATUS_ID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", dao.fields.LCN_PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub

    Public Sub BIND_STATUS()
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_LCN_EDIT_STATUS(5)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DDL_CHECK_STAFF.DataSource = dt
        DDL_CHECK_STAFF.DataBind()
        DDL_CHECK_STAFF.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub







    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW

        dt = bao.SP_LCN_APPROVE_EDIT_GET_UPLOAD_FILE(_REASON_TYPE)

        Return dt
    End Function

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

        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกสถานะ');", True)
        Else
            Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT

            Dim _YEAR As String = con_year(Date.Now().Year())
            dao.GetDataby_LCN_IDA_AND_YEAR_AND_ACTIVE(_LCN_IDA, _YEAR, True)

            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.fields.STATUS_NAME = DD_STATUS.SelectedItem.Text

            If DD_STATUS.SelectedValue = 4 Then
                Try
                    dao.fields.STAFF_CHECK_DATE = DateTime.ParseExact(TXT_CHECK_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                Catch ex As Exception
                    dao.fields.STAFF_CHECK_DATE = System.DateTime.Now
                End Try
                dao.fields.STAFF_CHECK_ID = DDL_CHECK_STAFF.SelectedValue
                dao.fields.STAFF_CHECK_NAME = DDL_CHECK_STAFF.SelectedItem.Text
            End If

            dao.update()

            Dim ida_xml As Integer = 0
            Dim process_xml As Integer = 0
            Dim year_xml As Integer = 0
            Dim tr_id_xml As Integer = 0
            ida_xml = dao.fields.IDA
            process_xml = dao.fields.LCN_PROCESS_ID
            year_xml = dao.fields.DATE_YEAR
            tr_id_xml = dao.fields.TR_ID

            bind_pdf_xml_4(ida_xml, _LCN_IDA, process_xml, dao.fields.STATUS_ID, year_xml, tr_id_xml)

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        End If

    End Sub

    Public Sub bind_pdf_xml_4(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
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
        ElseIf DD_STATUS.SelectedValue = 4 Then
            txt1.Visible = True
        ElseIf DD_STATUS.SelectedValue = 9 Then
            txt1.Visible = False
        End If
    End Sub


End Class