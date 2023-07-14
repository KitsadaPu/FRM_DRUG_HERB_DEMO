Imports Telerik.Web.UI

Public Class POPUP_HERB_TABEAN_RENEW_ADD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
    Private _Process_ID As String = ""

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
        _IDA_DR = Request.QueryString("IDA_DR")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _Process_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            BIND_PDF_TABEAN()
        End If
    End Sub

    Sub BIND_PDF_TABEAN()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_RENEW
        dao.GetdatabyID_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_RENEW
        If _Process_ID = 20710 Then
            TBN_RENEW = XML.Gen_XML_RENREW_TBN(_IDA, _IDA_DR, _IDA_LCN)
        ElseIf _Process_ID = 20720 Then

        ElseIf _Process_ID = 20730 Then
            TBN_RENEW = XML.Gen_XML_RENREW_JJ(_IDA, _IDA_DR, _IDA_LCN)
        End If

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_Process_ID, 0, "ตอ", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_RENEW") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", _Process_ID, Date.Now.Year, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", _Process_ID, Date.Now.Year, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    'Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
    '    Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
    '    dao.GetdatabyID_IDA(_IDA)

    '    dao.fields.DATE_CONFIRM = Date.Now
    '    dao.fields.STATUS_ID = 78
    '    dao.Update()

    '    'gen_xml_jj1()
    '    alert("ยกเลิกคำขอแล้ว")
    'End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_RENEW
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(_IDA_LCN)
        Catch ex As Exception

        End Try
        dao.fields.PROCESS_ID = _Process_ID
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CREATE_BY = _CLS.THANM
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.YEAR = con_year(Date.Now().Year())
        dao.fields.STATUS_ID = 1
        dao.fields.ACTIVEFACT = 1
        Try
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection(_Process_ID)
        Catch ex As Exception

        End Try
        dao.fields.FK_LCN = dao_lcn.fields.IDA
        dao.fields.pvncd = dao_lcn.fields.pvncd
        dao.fields.lcnsid = dao_lcn.fields.lcnsid
        dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
        dao.fields.LCNNO = dao_lcn.fields.lcnno
        dao.fields.LCNNO_DISPLAY_NEW = dao_lcn.fields.LCNNO_DISPLAY_NEW
        dao.fields.LCNNO_NEW = dao_lcn.fields.LCNNO_DISPLAY_NEW
        dao.fields.FK_IDA = _IDA_DR
        dao.fields.FK_LCT = dao_lcn.fields.FK_IDA
        dao.fields.IDA_DR = _IDA_DR
        dao.fields.TR_ID = TR_ID
        If _Process_ID = 20710 Then
            Dim dao_dr As New DAO_DRUG.ClsDBdrrqt
            dao_dr.GetDataby_IDA(_IDA_DR)
            Dim dao_dr2 As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao_dr2.GetdatabyID_FK_IDA_DQ(_IDA_DR)
            dao.fields.RGTNO_FULL = dao_dr.fields.RGTNO_NEW
            dao.fields.LCN_NAME = dao_dr2.fields.LCN_NAME
        ElseIf _Process_ID = 20720 Then

        ElseIf _Process_ID = 20730 Then
            Dim dao_dr As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao_dr.GetdatabyID_IDA(_IDA_DR)
            dao.fields.RGTNO_FULL = dao_dr.fields.RGTNO_FULL
            dao.fields.LCN_NAME = dao_dr.fields.LCN_NAME
        End If
        dao.Update()

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        dao_up_mas.GetdatabyID_TYPE(270)
        'If _Process_ID = 20710 Then
        '    dao_up_mas.GetdatabyID_TYPE(270)
        'ElseIf _Process_ID = 20720 Then
        '    dao_up_mas.GetdatabyID_TYPE(261)
        'ElseIf _Process_ID = 20730 Then
        '    dao_up_mas.GetdatabyID_TYPE(261)
        'End If

        For Each dao_up_mas.fields In dao_up_mas.datas
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
            dao_up.fields.TR_ID = TR_ID
            dao_up.fields.FK_IDA = dao.fields.IDA
            dao_up.fields.PROCESS_ID = _Process_ID
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.TYPE = 1
            dao_up.insert()
        Next
        alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", dao.fields.IDA)
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POPUP_HERB_TABEAN_RENEW_UPLOAD.aspx?IDA=" & ida & "&PROCESS_ID=" & _Process_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & _IDA_DR
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
End Class