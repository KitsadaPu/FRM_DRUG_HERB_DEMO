
Imports FDA_DRUG_HERB.XML_CENTER
Imports Telerik.Web.UI
Imports Telerik.Web.UI.Scheduler.Views
Public Class POPUP_SUBSTITUTE_EDIT_REQUEST
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
        BindTable()
        If Not IsPostBack Then
            Bind_Data()
            UC_LCN_SUB.load_ddl_sub_purpose()
        End If
    End Sub

    Public Sub load_gv()
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(Request.QueryString("IDA"))
        Dim dao_a As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_a.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 3)
        Try
            RG_StaffFile.DataSource = dao_a.datas
            RG_StaffFile.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RG_StaffFile_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_StaffFile.NeedDataSource
        load_gv()
    End Sub
    Private Sub RG_StaffFile_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RG_StaffFile.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA
        End If
    End Sub
    Sub Bind_Data()
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(Request.QueryString("IDA"))
        If dao.fields.Check_Edit_ID = True Then
            Check_Edit.Visible = True
            TXT_EDIT_NOTE.Text = dao.fields.Note_Edit
        End If
        If dao.fields.Check_Edit_FileUpload_ID = True Then
            Check_Edit_Uplaod.Visible = True
            NOTE_EDIT.Text = dao.fields.Note_Edit_FileUpload
        End If
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(Request.QueryString("IDA"))
        If dao.fields.Check_Edit_FileUpload_ID = True Then
            If check_file() = False Then
                alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
            Else
                If dao.fields.Check_Edit_ID = False Then
                    dao.fields.STATUS_ID = 10
                    dao.update()
                    AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, Request.QueryString("IDA"))
                    alert("บันทึกข้อมูลแล้ว รอเจ้าหน้าที่ตรวจสอบความถูกต้อง")
                End If
            End If
        End If
        If dao.fields.Check_Edit_ID = True Then
            UC_LCN_SUB.set_data(dao)
            dao.fields.STATUS_ID = 10
            dao.update()
            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, Request.QueryString("IDA"))
            alert("บันทึกข้อมูลแล้ว รอเจ้าหน้าที่ตรวจสอบความถูกต้อง")
        End If
    End Sub

    Function bind_data_RG_Edit()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 1)
        Return dt
    End Function

    Private Sub RG_Edit_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_Edit.NeedDataSource
        RG_Edit.DataSource = bind_data_RG_Edit()
    End Sub
    Private Sub RG_Edit_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RG_Edit.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA
        End If
    End Sub
    Public Sub BindTable()

        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        Dim tr_id As Integer = 0
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try

        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        Dim dao_att As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        Dim group As Integer = 0

        'dao_f.GetDataby_TR_ID(tr_id)
        dao_f.GetDaTaby_TR_ID_And_TYPE_AND_FK_IDA(tr_id, 2, _IDA)

        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas


            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.DOCUMENT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.DOCUMENT_NAME
            End Try
            tc.Width = 700
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.NAME_REAL
            tc.Width = 100
            tr.Cells.Add(tc)

            tc = New TableCell
            Dim img As New Image
            If dao_f.fields.NAME_REAL Is Nothing OrElse dao_f.fields.NAME_REAL = "" Then
                Dim AA As String = "../Images/cancel.png"
                img.ImageUrl = AA
                img.Width = 20
                img.Height = 20
            Else
                Dim AA As String = "../Images/correct.png"
                img.ImageUrl = AA
                img.Width = 20
                img.Height = 20
            End If
            tc.Controls.Add(img)
            tr.Cells.Add(tc)

            tc = New TableCell
            Dim f As New FileUpload
            f.ID = "F" & dao_f.fields.IDA
            tc.Controls.Add(f)
            tr.Cells.Add(tc)

            tb_upload_file.Rows.Add(tr)
            rows = rows + 1
        Next
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
        _CLS.FILENAME_PDF = NAME_PDF("DA", Process_ID, YEAR, TR_ID)
        _CLS.PDFNAME = filename
    End Sub
    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Function check_file()

        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_check.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(TR_ID, _ProcessID, 1)

        Dim ck_file As Boolean = True

        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
            End If
        Next

        Return ck_file
    End Function
    Protected Sub btn_add_no_Click(sender As Object, e As EventArgs) Handles btn_add_no.Click
        Dim tr_id As Integer = 0
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        tr_id = dao.fields.TR_ID
        For Each tr As TableRow In tb_upload_file.Rows
            Dim IDA As Integer = tr.Cells(1).Text

            Dim f As New FileUpload
            f = tr.FindControl("F" & IDA)
            If f.HasFile Then
                Dim name_real As String = f.FileName
                Dim Array_NAME_REAL() As String = Split(name_real, ".")
                Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                If exten.ToUpper = "PDF" Then
                    Dim bao As New BAO.AppSettings
                    Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    dao_f.GetDataby_IDA(IDA)
                    Dim Name_fake As String = "HB-" & _ProcessID & "-" & Date.Now.Year & "-" & tr_id & ".pdf"
                    dao_f.fields.NAME_FAKE = Name_fake
                    dao_f.fields.NAME_REAL = f.FileName
                    dao_f.fields.CREATE_DATE = Date.Now
                    dao_f.update()
                    Dim paths As String = bao._PATH_XML_PDF_LCN_RENREW
                    f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)
                Else
                    alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If
        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class