Imports Telerik.Web.UI
Imports Telerik.Web.UI.Scheduler.Views
    Public Class POPUP_LCN_TRANSFER_EDIT
        Inherits System.Web.UI.Page
        Private _CLS As New CLS_SESSION
        Private _ProcessID As String
        Private _IDA_LCN As String
        Private _IDA As String
        Private _IDEN As String
        Sub RunSession()
            '_ProcessID = 10104
            _ProcessID = Request.QueryString("PROCESS_ID")
            _IDEN = Request.QueryString("IDENTIFY")
        _IDA = Request.QueryString("IDA")

        Try
                _IDA_LCN = Request.QueryString("IDA_LCN")
                If Session("CLS") Is Nothing Then
                    Response.Redirect("http://privus.fda.moph.go.th/")
                Else
                    _CLS = Session("CLS")
                End If
            Catch ex As Exception
                Response.Redirect("http://privus.fda.moph.go.th/")
            End Try
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            RunSession()
            BindTable()
        If Not IsPostBack Then
            Bind_Data()
            'load_gv()
        End If
    End Sub
        Public Sub load_gv()
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(Request.QueryString("IDA"))
        'Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
        'dao_a.GetDataby_TR_ID(dao.fields.TR_ID)
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
            H.NavigateUrl = "../LCN_PHR/FRM_PHR_HERB_PREVIEW.aspx?ida=" & IDA
        End If

    End Sub
    Sub Bind_Data()
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(Request.QueryString("IDA"))
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
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(Request.QueryString("IDA"))
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
            dao.fields.TRANSFER_NM = txt_name.Text
            dao.fields.than_name_old = txt_name.Text
            dao.fields.BSN_NAME_OLD = txt_bsn_name.Text
            dao.fields.LCNNO_NEW_DISPLAY = txt_lcnno.Text
            dao.fields.BUSINESS_PLACE_NAME = txt_name_business.Text
            dao.fields.PASSPORT_NO = txt_PASSPORT_NO.Text
            dao.fields.PASSPORT_EXPIRE = RDP_PASSPORT_EXPDATE.SelectedDate
            dao.fields.WRITE_AT = Txt_Write_At.Text
            dao.fields.WRITE_DATE = txt_Write_Date.Text
            dao.fields.WORK_PERMIT = txt_DOC_NO.Text
            dao.fields.WORK_PERMIT_EXPIRE = RDP_DOC_NO_EXPDATE.SelectedDate
            dao.fields.TRANSFER_TO = txt_transfer_to.Text
            dao.fields.TRANSFER_TO_ID = txt_ctzid_lcn.Text
            dao.fields.than_name_new = txt_transfer_to.Text
            'dao.fields.BSN_TRANSFER = txt_operator_name.Text
            dao.fields.BSN_NAME_NEW = operator_name.Text
            dao.fields.BSN_IDENTIFY = txt_ctzid.Text
            dao.fields.TRANSFER_DATE = RPD_start_trnf.SelectedDate
            dao.fields.REMARK_TRANSFER = txt_trnf_remark.Text
            dao.fields.thaaddr = txt_location_trnf.Text
            dao.fields.thabuilding = txt_trnf_building.Text
            dao.fields.thamu = txt_trnf_mu.Text
            dao.fields.thasoi = txt_trnf_soi.Text
            dao.fields.tharoad = txt_trnf_road.Text
            dao.fields.thathmblnm = txt_trnf_tambol.Text
            dao.fields.thaamphrnm = txt_trnf_amphor.Text
            dao.fields.thachngwtnm = txt_trnf_changwat.Text
            dao.fields.zipcode = txt_trnf_zipcode.Text
            dao.fields.TEL = txt_lcn_tel.Text
            dao.fields.STATUS_ID = 10
            dao.update()
            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, Request.QueryString("IDA"))
            alert("บันทึกข้อมูลแล้ว รอเจ้าหน้าที่ตรวจสอบความถูกต้อง")

        End If
    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim dao As New DAO_CPN.TB_syslcnsnm
        If operator_name.Text IsNot Nothing Then
            Dim citizen_id As String = txt_ctzid.Text
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Try
                Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
                If TYPE_PERSON = 1 Then
                    operator_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                ElseIf TYPE_PERSON = 99 Then
                    operator_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                Else
                    If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                        operator_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    Else
                        operator_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    End If
                End If
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End Try

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขบัตรประชาชน หรือเลขนิติ');", True)
        End If
    End Sub

    Function bind_data_RG_Edit()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)

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
            H.NavigateUrl = "../LCN_PHR/FRM_PHR_HERB_PREVIEW.aspx?ida=" & IDA
        End If

    End Sub
    Public Sub BindTable()

        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)
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
                tc.Text = Replace(dao_f.fields.DUCUMENT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.DUCUMENT_NAME
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

    'Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click
    '    If check_file() = False Then
    '        alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
    '    Else
    '        alert("แนบไฟล์แล้ว กรุณากดดูข้อมูลเพื่อตรวจสอบความถูกต้องก่อนยื่นคำขอ")
    '    End If
    'End Sub
    Sub Blind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.DALCN_PHR_NEW
        LCN_PHR = XML.Gen_XML_PHR(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, 1, "สมพ4", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_PHR") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PHR_PDF", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("PHR_XML", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Function check_file()

        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)
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
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)
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

                    Dim Name_fake As String = "PHR-" & _ProcessID & "-" & Date.Now.Year & "-" & tr_id & ".pdf"
                        dao_f.fields.NAME_FAKE = Name_fake
                        dao_f.fields.NAME_REAL = f.FileName
                        dao_f.fields.CREATE_DATE = Date.Now
                        dao_f.update()

                        Dim paths As String = bao._PATH_XML_PDF_PHR
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
        Sub alert_summit(ByVal text As String, ByVal ida As Integer)
            Dim url As String = ""
            url = "FRM_PHR_HERB_UPLOAD.aspx?IDA=" & ida
            Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
        End Sub
        Private Sub alert(ByVal text As String)
            Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
        End Sub
        Private Sub alert_return(ByVal text As String)
            Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
        End Sub
    End Class