Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_STAFF_TABEAN_INOFFER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String

    Sub RunSession()
        _ProcessID = Request.QueryString("process")
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
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_REPORT_RDLC.aspx?IDA=" & _IDA & "&rpt=1' ></iframe>"
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/จจ๑.pdf'></iframe>"
            Run_Pdf_Tabean_Herb()
            bind_data()
            bind_dd()
            bind_mas_staff()
            bind_data_rgtno()
            bind_mas_ml()
            bind_dd_discount()
        End If
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
        dao_dq.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_dq.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"


    End Sub

    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_OFFER.DataSource = dt
        DD_OFF_OFFER.DataBind()
        DD_OFF_OFFER.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Public Sub bind_mas_ml()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        'dt = bao.SP_MAS_TABEAN_HERB_ML()
        dt = bao.SP_MAS_TABEAN_HERB_ML_PROCESSID(_ProcessID)

        DD_ML_ID.DataSource = dt
        DD_ML_ID.DataBind()
        DD_ML_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_data()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        RCVNO_FULL.Text = dao.fields.RCVNO_NEW
        DD_OFF_OFFER.Text = _CLS.NAME
        DATE_OFFER.Text = Date.Now.ToString("dd/MM/yyyy")
    End Sub

    Public Sub bind_data_rgtno()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        'If dao.fields.RGTNO_FULL = "" Then
        If dao.fields.RGTNO_NEW Is Nothing Then
            'Dim RG As String = GEN_RGTNO(dao.fields.rgttpcd)
            Dim dao_maxrgt_dq As New DAO_DRUG.ClsDBdrrqt
            dao_maxrgt_dq.GET_RGTNO_NEW_BYTPCD(dao.fields.rgttpcd)
            Dim dict = New Dictionary(Of String, Object)
            Dim tempb = Convert.ToInt32(DateTime.Now.Year.ToString()) + 543
            If dao.fields.DATE_YEAR IsNot Nothing Then tempb = dao.fields.DATE_YEAR
            tempb = tempb.ToString().Substring(2, 2)
            dict(tempb) = 0
            For Each item In dao_maxrgt_dq.datas
                Dim str = item.ToString.Substring(2).Split("/")
                Dim n = CInt(str(0))
                Dim y = CInt(str(1))
                If dict(tempb) < n Then
                    dict(tempb) = (n)
                End If
            Next
            Dim num As Integer = dict(tempb)
            num += 1
            'Dim str_no = String.Format("{0:50000}", num.ToString("50000"))
            RGTNO_FULL.Text = dao.fields.rgttpcd & " " & num.ToString & "/" & tempb.ToString()
            'dao.fields.RGTNO_FULL = RGTNO_FULL.Text
            'dao.Update()
        Else
            RGTNO_FULL.Text = dao.fields.RGTNO_NEW
        End If
        'RGTNO_FULL.Text = dao.fields.RGTNO_FULL
    End Sub

    Private Function GEN_RGTNO(ByVal rgttpcd As String) As String

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim str_no As String = ""

        If dao.fields.IDA = 1 And dao.fields.DATE_YEAR = con_year(Date.Now.Year) Then
            Dim max_no As Integer = 0
            Try
                max_no = CInt("00002")
                max_no += 1

            Catch ex As Exception

            End Try

            str_no = max_no.ToString()
            str_no = String.Format("{0:50000}", max_no.ToString("50000"))
            dao.fields.RGTNO_JJ = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            dao.Update()
            'str_no = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            str_no = str_no & "/" & dao.fields.DATE_YEAR.Substring(2, 2)
        Else
            Dim max_no As Integer = 0

            Dim dt As New DataTable
            Dim bao_max As New BAO_TABEAN_HERB.tb_main
            Dim _YEAR As String
            _YEAR = con_year(Date.Now.Year)
            dt = bao_max.SP_TABEAN_HERB_GET_MAX_RGTNO_JJ(rgttpcd, _YEAR.Substring(2, 2))
            Try
                max_no = dt(0)("MAX_ID")
                max_no += 1
            Catch ex As Exception

            End Try

            str_no = max_no.ToString()
            str_no = String.Format("{0:50000}", max_no.ToString("50000"))
            If dao.fields.DATE_YEAR IsNot Nothing Then
                dao.fields.RGTNO_JJ = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            Else
                Dim tempb = Convert.ToInt32(DateTime.Now.Year.ToString()) + 543
                dao.fields.RGTNO_JJ = tempb.ToString().Substring(2, 2) & str_no
            End If
            dao.Update()
            str_no = str_no & "/" & _YEAR.Substring(2, 2)
            'str_no = _YEAR.Substring(2, 2) & str_no
        End If

        Return str_no
    End Function

    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_STATUS_TABEAN(3)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 7, _ProcessID)

        Return dt
    End Function
    Function bind_data_uploadfile_edit2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 12, _ProcessID)

        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_edit2()
    End Sub
    Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

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
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 10, _ProcessID)

        Return dt
    End Function

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile_edit()
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกประเภททะเบียน');", True)
        ElseIf DD_STATUS.SelectedValue = 6 Then
            P12.Visible = True
        Else
            P12.Visible = False
        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)

        Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean_herb.GetdatabyID_FK_IDA_DQ(_IDA)

        If DD_STATUS.SelectedValue = 24 Then
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.update()

            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.update()

            dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao_tabean_herb.Update()
        ElseIf DD_STATUS.SelectedValue = 10 Then
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.update()

            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.update()

            dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao_tabean_herb.Update()
        Else
            If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_OFFER.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_ML_ID.SelectedValue = "-- กรุณาเลือก --" Or TXT_SUM.Text = "" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ ประเภท ยอดสุทธิ หรือ เลือกเจ้าหน้าที่');", True)
            ElseIf DD_STATUS.SelectedValue = 6 Then
                Try
                    dao.fields.CONSIDER_DATE = DateTime.ParseExact(DATE_OFFER.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                Catch ex As Exception
                    dao.fields.CONSIDER_DATE = Date.Now
                End Try
                dao.fields.REMARK = NOTE_OFFER.Text
                dao.fields.FK_STAFF_OFFER_IDA = DD_OFF_OFFER.SelectedValue
                dao.fields.STAFF_OFFER_NAME = DD_OFF_OFFER.SelectedItem.Text
                dao.fields.RGTNO_NEW = RGTNO_FULL.Text
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.update()

                dao_tabean_herb.fields.ML_ID = DD_ML_ID.SelectedValue
                dao_tabean_herb.fields.ML_NAME = DD_ML_ID.SelectedItem.Text

                Try
                    dao_tabean_herb.fields.ML_PAY = TXT_BATH.Text
                    'dao_tabean_herb.fields.ML_MINUS = TXT_MINUS.Text
                    dao_tabean_herb.fields.ML_MINUS = DDL_DISCOUNT.SelectedItem.Text
                Catch ex As Exception

                End Try

                dao_tabean_herb.fields.ML_SUM = TXT_SUM.Text

                dao_tabean_herb.fields.ML_KEY_NAME = _CLS.THANM
                dao_tabean_herb.fields.ML_KEY_DATE = Date.Now

                dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao_tabean_herb.Update()

                AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)

                Run_Pdf_Tabean_Herb_6()
                Run_Pdf_Tabean_Herb_6_2()
                'Run_Pdf_Tabean_Herb_APPROVE_2_11_12()   
            End If
        End If
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Public Sub Run_Pdf_Tabean_Herb_6()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
    Public Sub Run_Pdf_Tabean_Herb_6_2()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn_2(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "ทบ2", 0)


        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub

    Public Sub Run_Pdf_Tabean_Herb_APPROVE_2_11_12()
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_approve(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "APPROVE_TBN_2", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_APPROVE") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_APPROVE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Protected Sub btn_preview_tb2_Click(sender As Object, e As EventArgs) Handles btn_preview_tb2.Click
        Dim Url As String = "FRM_HERB_TABEAN_STAFF_TABEAN_PREVIEW_TABEAN2.aspx?IDA=" & _IDA
        Response.Write("<script>window.open('" & Url & "','_blank')</script>")
        'load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    End Sub

    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    Function bind_data_uploadfile_6()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 6, _ProcessID)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_uploadfile_6()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Function bind_data_uploadfile_8()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 8, _ProcessID)

        Return dt
    End Function

    Private Sub RadGrid5_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid5.NeedDataSource
        RadGrid5.DataSource = bind_data_uploadfile_8()
    End Sub

    Private Sub RadGrid5_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid5.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Protected Sub DD_ML_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ML_ID.SelectedIndexChanged
        Dim dao_ml As New DAO_TABEAN_HERB.TB_TABEAN_HERB_ML

        If DD_ML_ID.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทค่าธรรมเนียม');", True)
        Else
            dao_ml.GetdatabyID_IDA(DD_ML_ID.SelectedValue)

            TXT_BATH.Text = dao_ml.fields.ML_PAY
            DDL_DISCOUNT.ClearSelection()
            TXT_SUM.Text = ""
            'TXT_MINUS.Text = ""
            'TXT_SUM.Text = ""
        End If

    End Sub
    'Protected Sub TXT_MINUS_TextChanged(sender As Object, e As EventArgs) Handles TXT_MINUS.TextChanged
    '    Dim number1 As Integer = 0
    '    Dim number2 As Integer = 0
    '    Dim number3 As Integer = 100
    '    Dim answer1 As Decimal
    '    Dim sum1 As Integer
    '    Dim sum2 As Integer

    '    number1 = TXT_BATH.Text
    '    ' number2 = TXT_MINUS.Text
    '    number2 = DDL_DISCOUNT.SelectedItem.Text
    '    sum1 = number1 * number2
    '    sum2 = sum1 / number3
    '    answer1 = number1 - sum2
    '    TXT_SUM.Text = answer1
    'End Sub
    Public Sub bind_dd_discount()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_DISCOUNT_TABEAN()

        DDL_DISCOUNT.DataSource = dt
        DDL_DISCOUNT.DataBind()
        DDL_DISCOUNT.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Protected Sub DDL_DISCOUNT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_DISCOUNT.SelectedIndexChanged
        Dim dao_ml As New DAO_TABEAN_HERB.TB_TABEAN_HERB_ML

        If DDL_DISCOUNT.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทค่าธรรมเนียม');", True)
        Else
            Dim number1 As Integer = 0
            Dim number2 As Integer = 0
            Dim number3 As Integer = 100
            Dim answer1 As Decimal
            Dim sum1 As Integer
            Dim sum2 As Integer

            number1 = TXT_BATH.Text
            number2 = DDL_DISCOUNT.SelectedItem.Text
            sum1 = number1 * number2
            sum2 = sum1 / number3
            answer1 = number1 - sum2
            TXT_SUM.Text = answer1
        End If

    End Sub
End Class