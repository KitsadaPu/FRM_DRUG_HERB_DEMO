Public Class POPUP_TABEAN_LOG_EDIT_DETAIL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _PROCESS_ID As String
    Private _IDA_LCN As String

    Sub RunSession()
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

            Run_Pdf_Tabean_Herb()

        End If
    End Sub

    Shared DRRGT_EDIT_REQUEST As New DRRGT_EDIT_REQUEST
    Shared List_DRRGT_EDIT_REQUEST As New List(Of DRRGT_EDIT_REQUEST)
    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        'Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
        'dao_dq.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim process_id As String = 30001
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim _PATH_FILE As String = ""
        Dim PATH_PDF_TEMPLATE As String = ""
        Dim PATH_PDF_OUTPUT As String = ""
        Dim Path_XML As String = ""
        If _PROCESS_ID = "130099" Then
            Dim dao_rgedit As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            dao_rgedit.GetDatabyIDA(_IDA)
            'process_id = 30002
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(process_id, 0, "log", 1)
            Dim class_xml As New CLASS_DR_EDIT
            Dim XML As New CLASS_GEN_XML.TABEAN_NEW_EDIT
            'class_xml.DRRGT_EDIT_REQUESTs = dao_rgedit.fieslds
            'DRRGT_EDIT_REQUEST = dao_rgedit.fields
            'List_DRRGT_EDIT_REQUEST.Add(DRRGT_EDIT_REQUEST)
            'class_xml.DRRGT_EDIT_REQUESTs = List_DRRGT_EDIT_REQUEST
            'TBN_NEW_EDIT.DRRGT_EDIT_REQUESTs = class_xml.DRRGT_EDIT_REQUESTs
            TBN_NEW_EDIT = XML.GEN_XML_TABEAN_NEW_EDIT2(_IDA)
            _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
            PATH_PDF_TEMPLATE = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            PATH_PDF_OUTPUT = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", process_id, Date.Now.Year, dao_rgedit.fields.TR_ID)
            Path_XML = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", process_id, Date.Now.Year, dao_rgedit.fields.TR_ID)
        Else
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(process_id, 0, "log", 0)
            _IDA_LCN = dao.fields.FK_LCN_IDA
            Dim XML As New CLASS_GEN_XML.TABEAN_NEW_EDIT
            TBN_NEW_EDIT = XML.GEN_XML_TABEAN_NEW_EDIT(_IDA, _IDA_LCN)

            _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
            PATH_PDF_TEMPLATE = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            PATH_PDF_OUTPUT = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", process_id, Date.Now.Year, dao.fields.TR_ID)
            Path_XML = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", process_id, Date.Now.Year, dao.fields.TR_ID)
        End If


        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, process_id, PATH_PDF_OUTPUT)
        lr_preview.Text = "<iframe id='iframe1'  style='height:980px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub
End Class