Imports Telerik.Web.UI
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Public Class POPUP_STAFF_LCN_SUBTITUTE_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String = ""
    Private _STATUS_ID As String = ""
    Private _iden As String = ""
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _STATUS_ID = Request.QueryString("STATUS_ID")
        _iden = Request.QueryString("identify")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data()
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
            Cls_XML.DT_SHOW.DT1 = bao_show.SP_Lisense_Name_and_Addr(dao.fields.CITIZEN_ID_AUTHORIZE)
        Catch ex As Exception

        End Try
        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

        Dim dao_herb As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
        dao_herb.GetDataby_LCN_IDA(dao.fields.FK_IDA)


        Try
            Dim dt_thanm As DataTable = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_iden, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            For Each dr As DataRow In dt_thanm.Rows
                dr("thanm") = dao_herb.fields.licen
            Next
            Cls_XML.DT_SHOW.DT2 = dt_thanm
        Catch ex As Exception

        End Try
        Try
            Cls_XML.DT_SHOW.DT3 = bao_show.SP_LOCATION_ADDRESS_BY_FK_IDA(dao.fields.FK_IDA)
            '  Cls_XML.DT_SHOW.DT3 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao_main.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Catch ex As Exception

        End Try
        Dim lcnno_auto As String = ""
        Dim rcvno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_format_new As String = ""
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
            rcvno_format_new = dao.fields.rcvno_new
        Catch ex As Exception

        End Try
        Dim bsn_name As String = ""
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = dao.fields.CITIZEN_ID
        Catch ex As Exception

        End Try

        Dim ws_2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws_2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

        Try
            bsn_name = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception

        End Try
        Dim rcvdate As Date
        Dim rcvdate2 As String = ""
        Try
            If dao.fields.rcvdate IsNot Nothing Then
                rcvdate = dao.fields.rcvdate
                rcvdate2 = CDate(rcvdate).ToString("dd/MM/yyy")
            End If

        Catch ex As Exception

        End Try
        Dim bao_master As New BAO_MASTER
        Cls_XML.LCNNO_FORMAT = lcnno_format
        Cls_XML.LCNNO_SHOW = lcnno_format
        Cls_XML.LCNNO_FORMAT_NEW = lcnno_format_new
        Cls_XML.RCVNO_FORMAT = rcvno_format
        Cls_XML.RCVNO_FORMAT_NEW = rcvno_format_new
        Cls_XML.RCVDATE_DISPLAY = rcvdate2
        Cls_XML.PHR_NAME = dao_phr.fields.PHR_NAME
        Cls_XML.WTIRE_DATE = dao.fields.WTIRE_DATE
        Cls_XML.PUR_POSE = dao.fields.PURPOSE
        Cls_XML.OPENTIME = dao_main.fields.opentime
        Cls_XML.LCN_TYPE = dao.fields.LCN_TYPE
        Cls_XML.CITIZEN_AUTHORIZE = dao_main.fields.CITIZEN_ID_AUTHORIZE
        Cls_XML.TEL = dao_main.fields.tel
        Cls_XML.BSN_NAME = bsn_name
        Cls_XML.DT_MASTER.DT1 = bao_master.SP_PHR_BY_FK_IDA_SUB(dao.fields.FK_IDA)

        p_dalcn_subtitute = Cls_XML
        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim Process_ID As String = dao.fields.PROCESS_ID
        Dim TR_ID As String = dao.fields.TR_ID


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP_PREVIEW(Process_ID, statusId, 0, 0)
        Dim YEAR As String = dao_up.fields.YEAR

        Dim paths As String = bao._PATH_XML_PDF_LCN_SUB
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", Process_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", Process_ID, YEAR, _TR_ID)

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, Process_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        _CLS.FILENAME_PDF = NAME_PDF("DA", Process_ID, YEAR, TR_ID)
        _CLS.PDFNAME = filename
    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        Try
            If dao.fields.Check_Edit_ID = True Then
                DIV_SHOW_TXT_EDIT_TB1.Visible = True
                TXT_EDIT_NOTE_TB1.Text = dao.fields.Note_Edit
                TXT_EDIT_NOTE_TB1.ReadOnly = True
                CHK_TB1_EDIT.Checked = dao.fields.Check_Edit_ID
                CHK_TB1_EDIT.Enabled = True
            Else
                DIV_SHOW_TXT_EDIT_TB1.Visible = False
            End If
            If dao.fields.Check_Edit_FileUpload_ID = True Then
                DIV_EDIT_UPLOAD1.Visible = True
                DIV_EDIT_UPLOAD2.Visible = True
                RadGrid1.Rebind()
                RadGrid3.Rebind()
                NOTE_EDIT.Text = dao.fields.Note_Edit_FileUpload
                NOTE_EDIT.ReadOnly = True
                CHK_UPLOAD_EDIT.Checked = dao.fields.Check_Edit_FileUpload_ID
                CHK_UPLOAD_EDIT.Enabled = True
            Else
                DIV_EDIT_UPLOAD1.Visible = False
                DIV_EDIT_UPLOAD2.Visible = False
            End If
        Catch ex As Exception

        End Try
        'Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
        'dao_a.GetDataby_TR_ID(dao.fields.TR_ID)
        Dim dao_a As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_a.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 3)
        If dao_a.fields.IDA <> 0 Then
            img_cf.Visible = True
            img_not.Visible = False
            lbl_upload_file.Text = dao_a.fields.NAME_REAL
        End If
    End Sub
    Private Sub load_HL(ByVal IDA As String)
        Dim url As String = "../LCN_SUBSTITUTE/FRM_LCN_SUBSTITUTE_PREVIEW.aspx?ida=" & IDA

        ST_AT.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_up.GetDataby_FK_IDA_AND_TR_ID_AND_PROCESS(_IDA, _TR_ID, _ProcessID)
        Try
            Type_ID = dao_up.fields.TYPE
        Catch ex As Exception
            Type_ID = 1
        End Try

        If Type_ID = 1 Then
            RadGrid4.Visible = False
        Else
            RadGrid1.Visible = False
            btn_sumit.Enabled = False
            btn_sumit.CssClass = "btn-danger btn-lg"
            btn_add_upload.Enabled = False
            btn_add_upload.CssClass = "btn-danger btn-lg"
        End If

        dt = bao.SP_DALCN_UPLOAD_FILE_TYPE_BY_PROCESS(_ProcessID)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim IDA_UPLOAD As Integer = 0
        Dim NAME_FILE As String = ""
        For Each item As GridDataItem In RadGrid1.SelectedItems
            IDA_UPLOAD = item("ID").Text
            NAME_FILE = item("DOCUMENT_NAME").Text
            Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_up.fields.DOCUMENT_NAME = NAME_FILE
            dao_up.fields.TR_ID = _TR_ID
            dao_up.fields.PROCESS_ID = _ProcessID
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.TYPE = 2
            'dao_up.fields.a = 1
            dao_up.fields.CREATE_DATE = Date.Now
            dao_up.insert()
        Next
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        dao.fields.Note_Edit = NOTE_EDIT.Text
        If CHK_TB1_EDIT.Checked = True Then
            dao.fields.Check_Edit_ID = CHK_TB1_EDIT.Checked
            dao.fields.Note_Edit = TXT_EDIT_NOTE_TB1.Text
        Else
            dao.fields.Check_Edit_ID = CHK_TB1_EDIT.Checked
        End If
        If CHK_UPLOAD_EDIT.Checked = True Then
            dao.fields.Check_Edit_FileUpload_ID = CHK_UPLOAD_EDIT.Checked
            dao.fields.Note_Edit_FileUpload = NOTE_EDIT.Text
        Else
            dao.fields.Check_Edit_FileUpload_ID = CHK_UPLOAD_EDIT.Checked
        End If
        Try
            dao.fields.staff_edit_id = _CLS.CITIZEN_ID
            dao.fields.staff_edit_name = _CLS.NAME
            dao.fields.staff_edit_name = Date.Now
        Catch ex As Exception

        End Try
        dao.update()

        AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click
        If UC_ATTACH_LCN.check = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์');", True)
        Else
            Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
            dao.Getdata_by_IDA(_IDA)
            Dim Year As String
            Year = con_year(Date.Now.Year)
            Dim path As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_SUB")
            UC_ATTACH_LCN.ATTACH_LCN(dao.fields.TR_ID, dao.fields.IDA, dao.fields.PROCESS_ID, Year, "3", path)
            Dim up_edit As String = ""
            'Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
            'dao_a.GetDataby_TR_ID(dao.fields.TR_ID)
            Dim dao_a As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_a.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 3)
            If dao_a.fields.IDA <> 0 Then
                img_cf.Visible = True
                img_not.Visible = False
                lbl_upload_file.Text = dao_a.fields.NAME_REAL
            End If
            load_HL(dao_a.fields.IDA)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แนบไฟล์เรียบร้อยแล้ว');", True)
        End If
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub CHK_TB1_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_TB1_EDIT.CheckedChanged
        If CHK_TB1_EDIT.Checked = True Then
            DIV_SHOW_TXT_EDIT_TB1.Visible = True
        Else
            DIV_SHOW_TXT_EDIT_TB1.Visible = False
        End If
    End Sub

    Protected Sub CHK_UPLOAD_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_UPLOAD_EDIT.CheckedChanged
        If CHK_UPLOAD_EDIT.Checked = True Then
            DIV_EDIT_UPLOAD1.Visible = True
            DIV_EDIT_UPLOAD2.Visible = True
            RadGrid1.Rebind()
            RadGrid3.Rebind()
        Else
            DIV_EDIT_UPLOAD1.Visible = False
            DIV_EDIT_UPLOAD2.Visible = False
        End If
    End Sub
    Function bind_data_uploadfile_1()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 1)
        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_uploadfile_1()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_SUBSTITUTE/FRM_LCN_SUBSTITUTE_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub
    Function bind_data_uploadfile_4()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 2)
        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_4()
    End Sub

End Class