Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class FRM_TABEAN_STAFF_DETAIL
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
            'bind_data()
            Gen_Pdf_Tabean_Herb()
            'Run_Pdf_Tabean_Herb()
            'set_btn()
            bind_data()
        End If
    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetDataby_IDA(_IDA)
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA)
        lbl_create_by.Text = dao.fields.CREATE_BY
        lbl_create_date.Text = dao.fields.CREATE_DATE
        Dim STATUS_ID As String = dao.fields.STATUS_ID
        If STATUS_ID = 77 Or STATUS_ID = 7 Or STATUS_ID = 18 Or STATUS_ID = 19 _
            Or STATUS_ID = 9 Or STATUS_ID = 20 Or STATUS_ID = 10 Or STATUS_ID = 16 Then
            TXT_CANCLE_REMARK.Text = dao_tabean.fields.DD_CANCEL_NM
            NOTE_CANCLE.Text = dao.fields.REMARK
            CANCEL_DETAIL.Visible = True
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

        lr_preview.Text = "<iframe id='iframe1'  style='height:100%;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"


    End Sub
    Public Sub Gen_Pdf_Tabean_Herb()
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

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_deeqt.fields.TR_ID, 7, _ProcessID)

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
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_deeqt.fields.TR_ID, 10, _ProcessID)

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

    Function bind_data_uploadfile_cancel()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_deeqt.fields.TR_ID, dao_deeqt.fields.STATUS_ID, _ProcessID)

        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_cancel()
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
End Class