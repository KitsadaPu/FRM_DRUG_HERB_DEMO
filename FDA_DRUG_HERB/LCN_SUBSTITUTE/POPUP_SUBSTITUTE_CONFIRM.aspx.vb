Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG_HERB.XML_CENTER
Public Class POPUP_SUBSTITUTE_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As Integer
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _iden As String
    Private _lcn_ida As String

    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _IDA = Request.QueryString("IDA")
            _lcn_ida = Request.QueryString("LCN_IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
            _iden = Request.QueryString("identify")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            BindData_PDF()
            UC_GRID_ATTACH.load_gv(_TR_ID)
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
        ' class_xml = cls_dalcn.gen_xml()
        'Cls_XML.DALCN_NCT_SUBSTITUTEs = dao.fields

        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Try
            dao_main.GetDataby_IDA(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            dao_bsn.GetDataby_LCN_IDA(dao_main.fields.IDA)
        Catch ex As Exception

        End Try
        Dim bao_show As New BAO_SHOW

        Try
            lct_ida = dao_main.fields.FK_IDA
        Catch ex As Exception

        End Try
        Dim identify As String = ""
        Try
            identify = dao_main.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try

        Try
            Cls_XML.DT_SHOW.DT1 = bao_show.SP_Lisense_Name_and_Addr(_iden)
        Catch ex As Exception

        End Try

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

        Dim dao_herb As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
        dao_herb.GetDataby_LCN_IDA(_lcn_ida)


        'Try
        '    Cls_XML.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(dao_bsn.fields.BSN_IDENTIFY) 'ผู้ดำเนิน
        '    Cls_XML.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        'Catch ex As Exception

        'End Try
        Try
            Dim dt_thanm As DataTable = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_iden, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            For Each dr As DataRow In dt_thanm.Rows
                dr("thanm") = dao_herb.fields.licen
            Next
            'Dim dt_thanm2 As DataTable
            'dt_thanm2 = dt_thanm.Clone
            'Dim dr_nm As DataRow = dt_thanm2.NewRow()
            'dr_nm("thanm") = dao_e.fields.licen_loca
            'dt_thanm2.Rows.Add(dr_nm)
            Cls_XML.DT_SHOW.DT2 = dt_thanm
        Catch ex As Exception

        End Try

        Try
            Cls_XML.DT_SHOW.DT3 = bao_show.SP_LOCATION_ADDRESS_BY_FK_IDA(_lcn_ida)
            '  Cls_XML.DT_SHOW.DT3 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao_main.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Catch ex As Exception

        End Try

        Try
            Cls_XML.DT_SHOW.DT4 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(dao_bsn.fields.BSN_IDENTIFY) 'ผู้ดำเนิน
            Cls_XML.DT_SHOW.DT4.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
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
            If Len(lcnno_auto) > 0 Then
                If dao_main.fields.lcnno > 1000000 Then
                    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    Else
                        'lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        lcnno_format = dao_main.fields.LCNNO_DISPLAY_NEW
                    End If
                Else
                    lcnno_format = dao_main.fields.LCNNO_DISPLAY_NEW
                    lcnno_format_new = dao_main.fields.LCNNO_DISPLAY_NEW
                End If

                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
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
        Cls_XML.CITIZEN_AUTHORIZE = dao_main.fields.CITIZEN_ID_AUTHORIZE
        Cls_XML.TEL = dao_main.fields.tel


        Cls_XML.DT_MASTER.DT1 = bao_master.SP_PHR_BY_FK_IDA_SUB(_lcn_ida)
        'Cls_XML.DT_MASTER.DT1 = bao_master.SP_PHR_BY_FK_IDA(_lcn_ida)

        p_dalcn_subtitute = Cls_XML
        'Dim dao_sub As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        'dao_sub.Getdata_by_IDA(_IDA)
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
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        Dim bao As New BAO.ClsDBSqlcommand
        dao.Getdata_by_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 2
        dao.update()

        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        alert("ยื่นเรื่องเรียบร้อยแล้ว")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class