Public Class FRM_TABEAN_SUBSTITUTE_STAFF_PREVIEW_DR
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _PROCESS_ID As String

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
            If _PROCESS_ID = 20610 Then
                Run_Pdf_Tabean_Herb()
            ElseIf _PROCESS_ID = 20620 Then

            ElseIf _PROCESS_ID = 20630 Then
                Run_Pdf_Tabean_JJ()
            End If


        End If
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        'Dim dao_dg As New DAO_DRUG.ClsDBdrrgt
        'dao_dg.GetDataby_IDA(_IDA)
        Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
        dao_dq.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        Dim _PROCESSID As String = dao_dq.fields.PROCESS_ID
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(_PROCESS_ID, dao_dq.fields.STATUS_ID, 0, 1)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_SUB") 'path

        'Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", dao_dq.fields.PROCESS_ID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _PROCESSID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub

    Public Sub Run_Pdf_Tabean_JJ()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        Dim _ProcessID As String = dao.fields.DDHERB
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(_PROCESS_ID, dao.fields.STATUS_ID, 0, 2)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_SUB") 'path

        'Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", dao_dq.fields.PROCESS_ID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub
End Class