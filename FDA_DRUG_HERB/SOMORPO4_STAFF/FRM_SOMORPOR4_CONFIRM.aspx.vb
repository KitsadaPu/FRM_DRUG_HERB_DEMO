Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Public Class FRM_SOMORPOR4_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private _newcode As String
    Private _iden As String
    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _iden = Request.QueryString("identify")
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            BindData_PDF()
        End If
    End Sub
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings

        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim cls_dalcn_edt As New CLASS_GEN_XML.DALCN_SUB(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID, "1", "10")
        Dim lct_ida As Integer = 0 '101680
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        Dim FK_IDA As Integer = dao.fields.FK_IDA
        dao_phr.GetDataby_FK_IDA(dao.fields.FK_IDA)
        Dim bao_cls As New BAO.ClsDBSqlcommand
        Dim Cls_XML As New CLASS_DALCN_SUBSTITUTE
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Try
            dao_main.GetDataby_IDA(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try

        Dim lcnno_auto As String = ""
        Dim rcvno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim rcvno_format As String = ""
        Dim MAIN_LCN_IDA As Integer = 0
        Dim lcnno_format_new As String = ""

        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            If dao.fields.rcvno <> 0 Then
                rcvno_auto = dao.fields.rcvno
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rcvno_auto) > 0 Then
                rcvno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/25" & Left(rcvno_auto, 2)
            End If
        Catch ex As Exception

        End Try


        Dim bao_master As New BAO_MASTER

        Cls_XML.LCNNO_FORMAT = lcnno_format
        Cls_XML.LCNNO_SHOW = lcnno_format
        Cls_XML.LCNNO_FORMAT_NEW = lcnno_format_new
        Cls_XML.RCVNO_FORMAT = rcvno_format
        Cls_XML.PHR_NAME = dao_phr.fields.PHR_NAME
        Cls_XML.WTIRE_DATE = dao.fields.WTIRE_DATE
        Cls_XML.PUR_POSE = dao.fields.PURPOSE
        Cls_XML.OPENTIME = dao_main.fields.opentime
        Cls_XML.LCN_TYPE = dao.fields.LCN_TYPE

        Cls_XML.DT_MASTER.DT1 = bao_master.SP_PHR_BY_FK_IDA_SUB(dao.fields.FK_IDA)


        p_dalcn_subtitute = Cls_XML
        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim Process_ID As String = dao.fields.PROCESS_ID
        Dim TR_ID As String = dao.fields.TR_ID


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP_PREVIEW(Process_ID, statusId, 0, 0)
        Dim YEAR As String = dao_up.fields.YEAR

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", Process_ID, YEAR, TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", Process_ID, YEAR, TR_ID)
        'load_PDF(filename)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, Process_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", Process_ID, YEAR, TR_ID)
        _CLS.PDFNAME = filename
    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer = 0
        Dim PROCESS_ID As Integer
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        PROCESS_ID = dao_up.fields.PROCESS_ID

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Try
            dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
        'dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao_date.fields.STATUS_ID = 4
        dao_date.fields.DATE_NOW = Date.Now
        dao_date.fields.PROCESS_ID = PROCESS_ID
        dao_date.insert()

        If STATUS_ID = 3 Then
            'dao.fields.STATUS_ID = STATUS_ID
            'Dim bao2 As New BAO.GenNumber
            'RCVNO = bao2.GEN_NO_07(con_year(Date.Now.Year), _CLS.PVCODE, IIf(IsDBNull(dao.fields.lcnno), "", dao.fields.lcnno), PROCESS_ID, 0, 0, _IDA, "")
            'dao.fields.rcvno = RCVNO
            'Try
            '    dao.fields.rcvdate = txt_appdate.Text
            'Catch ex As Exception

            'End Try
            dao.fields.STATUS_ID = STATUS_ID
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
            dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

            Try
                dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.STATUS_ID = STATUS_ID
            dao.update()

            alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class