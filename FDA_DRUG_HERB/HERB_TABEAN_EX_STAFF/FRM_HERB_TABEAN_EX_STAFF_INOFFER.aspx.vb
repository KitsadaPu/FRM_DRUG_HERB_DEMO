Imports System.Globalization
Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_EX_STAFF_INOFFER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String

    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
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
            bind_dd()
            bind_mas_staff()
            Run_Pdf_TB_Herb_EX()
            bind_data()
        End If
    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        'DD_OFF_APP.Text = dao.fields.EX_OFF_APP
        DATE_OFFER.Text = Date.Now.ToString("dd/MM/yyyy")

        RGTNO_FULL.Text = BIND_NO_EX(dao.fields.EX_DATE_YEAR, dao.fields.pvncd, _IDA, _ProcessID)
    End Sub
    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_STATUS_TABEAN_EX(2)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_OFFER.DataSource = dt
        DD_OFF_OFFER.DataBind()
        DD_OFF_OFFER.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ');", True)
        ElseIf DD_STATUS.SelectedValue = 6 Then
            P12.Visible = True
        Else
            P12.Visible = False
        End If
    End Sub
    'Public Sub bind_data()
    '    Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
    '    dao.GetdatabyID_IDA(_IDA)
    '    RCVNO_FULL.Text = dao.fields.RCVNO_FULL
    '    DD_OFF_OFFER.Text = _CLS.NAME
    '    DATE_OFFER.Text = Date.Now.ToString("dd/MM/yyyy")
    'End Sub
    Public Sub Run_Pdf_TB_Herb_EX()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(dao.fields.process_id, dao.fields.STATUS_ID, "ตย1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EX") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE_EX\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim RGTNO As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        'bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        dao.Update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)

        If DD_STATUS.SelectedValue = 19 Then
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.Update()

            'bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.Update()

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        Else
            If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_OFFER.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Then Thenใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ ประเภท ยอดสุทธิ หรือ เลือกเจ้าหน้าที่');", True)
            ElseIf DD_STATUS.SelectedValue = 6 Or DD_STATUS.SelectedValue = 11 Then
                Try
                    dao.fields.EX_DATE_OFFER = DateTime.ParseExact(DATE_OFFER.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                Catch ex As Exception
                    dao.fields.EX_DATE_OFFER = Date.Now
                End Try
                dao.fields.EX_NOTE_OFFER = NOTE_OFFER.Text
                'dao.fields.OFF_OFFER = OFF_OFFER.Text
                dao.fields.EX_OFF_OFFER_ID = DD_OFF_OFFER.SelectedValue
                dao.fields.EX_OFF_OFFER = DD_OFF_OFFER.SelectedItem.Text
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.fields.sample_no = RGTNO_FULL.Text
                RGTNO = GEN_NO_EX(dao.fields.EX_DATE_YEAR, dao.fields.pvncd, "SAM", _IDA)
                'dao.fields.ML_KEY_DATE = Date.Now
                dao.fields.sample_no_display = RGTNO
                dao.Update()


                'bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)

                Run_Pdf_Tabean_Herb_Intake()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            ElseIf DD_STATUS.SelectedValue = 10 Then
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.Update()

                'bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.Update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            End If
        End If
    End Sub
    Public Function BIND_NO_EX(ByVal YEAR As String, ByVal PVNCD As String, ByVal FK_IDA As Integer, ByVal PROCESS_ID As Integer) As String
        Dim int_no As Integer
        Dim full_rgtno As String = ""
        Dim str_no As String = int_no.ToString()
        Dim str_no2 As String = int_no.ToString()
        Dim dao As New DAO_TABEAN_HERB.TB_GEN_NO_NEW
        Dim dao2 As New DAO_TABEAN_HERB.TB_GEN_NO_NEW

        dao.GetDataby_TYPE_MAX(YEAR, "SAM", FK_IDA)
        dao2.GetDataby_FK_IDA(FK_IDA)
        If IsNothing(dao.fields.GENNO) = True Then
            int_no = 0
        Else
            int_no = dao.fields.GENNO
        End If
        int_no = int_no + 1
        'str_no = String.Format("{0:00000}", int_no.ToString("00000"))
        str_no2 = YEAR.Substring(2, 2) & str_no

        str_no2 = "HB" & " " & int_no.ToString() & "/" & con_year(YEAR).Substring(2, 2) & " SAM"

        Return str_no2
    End Function
    Public Function GEN_NO_EX(ByVal YEAR As String, ByVal PVNCD As String, ByVal TYPE As String, ByVal FK_IDA As Integer) As String
        Dim int_no As Integer
        Dim full_rgtno As String = ""
        TYPE = "SAM"
        Dim dao As New DAO_TABEAN_HERB.TB_GEN_NO_NEW
        dao.GetDataby_TYPE_MAX(YEAR, TYPE, FK_IDA)

        If IsNothing(dao.fields.GENNO) = True Then
            int_no = 0
        Else
            int_no = dao.fields.GENNO
        End If
        int_no = int_no + 1

        Dim str_no As String = int_no.ToString()
        'str_no = String.Format("{0:00000}", int_no.ToString("00000"))
        'str_no = YEAR.Substring(2, 2) & str_no
        full_rgtno = "HB" & " " & int_no.ToString() & "/" & con_year(YEAR).Substring(2, 2) & " SAM"
        dao = New DAO_TABEAN_HERB.TB_GEN_NO_NEW
        dao.fields.YEAR = YEAR
        dao.fields.PVCODE = PVNCD
        dao.fields.GENNO = int_no
        dao.fields.TYPE = TYPE
        dao.fields.FORMAT = full_rgtno
        dao.fields.IDA = FK_IDA
        dao.fields.LCNNO = str_no
        dao.fields.DESCRIPTION = str_no
        dao.insert()
        Return str_no
    End Function
    Public Sub Run_Pdf_Tabean_Herb_Intake()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_EX
        TABEAN_EX = XML.gen_xml_TB_EX(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(dao.fields.process_id, dao.fields.STATUS_ID, "ตย1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EX") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE_EX\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TABEAN_EX("HB_XML", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, dao.fields.process_id, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = path_XML
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_EX(_TR_ID, 17, dao.fields.process_id)

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
            H.NavigateUrl = "../HERB_TABEAN_EX/FRM_HERB_TABEAN_EX_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub
End Class