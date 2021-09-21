Public Class UC_LCN_EDIT
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _lcn_ida As String
    Private _tr_id As String
    Private _year As String
    Private _STATUS_ID As Integer
    Private _STAFF_ID As Integer


    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        _ProcessID = Request.QueryString("process")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        _IDA = Request.QueryString("IDA")
        _lcn_ida = Request.QueryString("LCN_IDA")
        _STAFF_ID = Request.QueryString("staff")
        Dim date_full_now As DateTime
        date_full_now = System.DateTime.Now
        _year = date_full_now.Year

        _STATUS_ID = Request.QueryString("STATUS_ID")



    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        Set_Label(_iden)
        '
        'Set_ddl_type()
        set_txt_label()

        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        'เจ้าหน้าที่ทำแทน ผปก
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(_lcn_ida, 2)

        Dim ddl1 As Integer = 0
        Dim ddl2 As Integer = 0
        Dim note As String = ""
        For Each dr As DataRow In dt.Rows

            ddl1 = dr("LCN_EDIT_REASON_TYPE")
            Try
                ddl2 = dr("FK_SUB_REASON_TYPE")
            Catch ex As Exception
                ddl2 = 0
            End Try
            note = dr("NOTE_REASON")
        Next

        If Not IsPostBack Then
            If _ProcessID = "122" Then
                rdl_lcn_type.SelectedValue = "1"
            ElseIf _ProcessID = "121" Then
                rdl_lcn_type.SelectedValue = "2"
            ElseIf _ProcessID = "120" Then
                rdl_lcn_type.SelectedValue = "3"
            End If

            If dt.Rows.Count <> 0 Then
                bind_detail(ddl1, ddl2, note)
            Else
                bind_reason()
            End If
        End If



    End Sub

    Public Function bind_detail(ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal note_reason As String) 'ถ้าเคยยยื่นเรื่องคำขอแก้ไขแล้วให้ bind ข้อมูลขึ้นมา


        lb1.Visible = True
        DDL_EDIT_REASON_SUB.Visible = True

        'ส่งค่ามา bind dropdown ด้วย

        bind_reason()
        DDL_EDIT_REASON.SelectedValue = ddl1
        bind_reason_sub(DDL_EDIT_REASON.SelectedValue)
        DDL_EDIT_REASON_SUB.SelectedValue = ddl2

        p1.Visible = True 'เปิด upload-file
        BindTable(ddl1, ddl2)
        txt_reason_name.Text = note_reason
    End Function
    Public Sub bind_reason()
        Dim bao_show As New BAO_SHOW
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DDL_REASON()

        DDL_EDIT_REASON.DataSource = dt
        DDL_EDIT_REASON.DataBind()

        DDL_EDIT_REASON.Items.Insert(0, "กรุณาเลือก")

    End Sub
    Public Sub bind_reason_sub(ByVal IDA As Integer)
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DDL_REASON_SUB(IDA)

        DDL_EDIT_REASON_SUB.DataSource = dt
        DDL_EDIT_REASON_SUB.DataBind()

        DDL_EDIT_REASON_SUB.Items.Insert(0, "กรุณาเลือก")




    End Sub

    'Public Sub Set_ddl_type()
    '    If ddl_sub_purpose.DataValueField = "1" Then
    '        Panel1.Style.Add("display", "block")
    '        Panel2.Style.Add("display", "none")
    '    ElseIf ddl_sub_purpose.SelectedValue = "2" Then
    '        Panel1.Style.Add("display", "none")
    '        Panel2.Style.Add("display", "block")
    '    Else
    '        Panel1.Style.Add("display", "none")
    '        Panel2.Style.Add("display", "none")
    '    End If
    'End Sub
    Public Sub set_txt_label()

        'uc102_3.get_label("3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร")

    End Sub
    Sub Set_Label(ByVal CITIZEN_ID_AUTHORIZE As String)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        dt_lcn = bao.SP_Lisense_Name_and_Addr(_iden) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

        For Each dr As DataRow In dt_lcn.Rows
            'Try
            '    txt_da_opentime.Text = dr("thaaddr")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_addr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_floor.Text = dr("floor")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_room.Text = dr("room")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_ages.Text = dr("age")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_amphor.Text = dr("amphrnm")
            Catch ex As Exception

            End Try
            Try
                txt_sub_building.Text = dr("building")
            Catch ex As Exception

            End Try
            Try
                txt_sub_changwat.Text = dr("chngwtnm")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_email.Text = dr("email")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_fax.Text = dr("fax")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_iden.Text = dr("identify")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_iden2.Text = dr("identify")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_mu.Text = dr("mu")
            Catch ex As Exception

            End Try
            Try
                txt_sub_name.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try
            'Try
            '    txt_sub_nation.Text = dr("nation")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_road.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                txt_sub_soi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                txt_sub_tambol.Text = dr("thmblnm")
            Catch ex As Exception

            End Try
            Try
                txt_sub_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                txt_sub_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next

        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(_lcn_ida)
        txt_sub_opentime.Text = dao_main.fields.opentime
        txt_sub_location.Text = dao_main.fields.LOCATION_ADDRESS_thanameplace
        txt_sub_lcnno.Text = dao_main.fields.LCNNO_DISPLAY_NEW

        'เพิ่ม 20210831
        _tr_id = dao_main.fields.TR_ID

        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(_lcn_ida)
        If dao_phr.fields.PHR_NAME = Nothing Then
            txt_sub_phr_name.Text = "-"
        Else
            txt_sub_phr_name.Text = dao_phr.fields.PHR_NAME
        End If

    End Sub

    Public Function get_dt_edit(ByVal lcn As Integer)
        Dim bao_show As New BAO_SHOW
        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(_lcn_ida, 2)

        Return dt
    End Function


    Sub save_data(ByRef dao As DAO_LCN.TB_LCN_APPROVE_EDIT)


        dao.fields.FK_LCN_IDA = _lcn_ida
        dao.fields.FK_LOCATION_IDA = _lct_ida
        dao.fields.STAFF_TYPE = _STAFF_ID
        'dao.fields.STAFF_NAME = _STAFF_NAME

        'เลขดำเนินการ รันใหม่
        Dim TR_ID As String = ""
        'Dim bao_tran As New BAO_LCN_TRANSECTION
        Dim bao_tran As New BAO_TRANSECTION

        TR_ID = bao_tran.insert_transection(_ProcessID)
        dao.fields.TR_ID = TR_ID

        dao.fields.LCN_PROCESS_ID = 10201


        'dao.fields.TR_ID = _tr_id

        dao.fields.LCN_EDIT_REASON_TYPE = DDL_EDIT_REASON.SelectedValue
        dao.fields.LCN_EDIT_REASON_NAME = DDL_EDIT_REASON.SelectedItem.Text
        Try
            dao.fields.FK_SUB_REASON_TYPE = DDL_EDIT_REASON_SUB.SelectedValue
        Catch ex As Exception

        End Try
        Try
            dao.fields.FK_SUB_REASON_NAME = DDL_EDIT_REASON_SUB.SelectedItem.Text
        Catch ex As Exception

        End Try

        dao.fields.DATE_YEAR = con_year(Date.Now().Year())

        dao.fields.NOTE_REASON = txt_reason_name.Text

        dao.fields.LCN_TYPE_ID = rdl_lcn_type.SelectedValue
        dao.fields.LCN_TYPE_NAME = rdl_lcn_type.SelectedItem.Text
        dao.fields.LCN_NAME = txt_sub_name.Text
        dao.fields.LCN_NAME_SUB = txt_sub_phr_name.Text
        dao.fields.LCN_IDENTIFY = txt_sub_iden.Text
        dao.fields.LCNNO = txt_sub_lcnno.Text
        dao.fields.LCN_LOCATION = txt_sub_location.Text
        dao.fields.ADDR_NUM = txt_sub_addr.Text
        dao.fields.ADDR_BUILDING = txt_sub_building.Text
        dao.fields.ADDR_MOO = txt_sub_mu.Text
        dao.fields.ADDR_SOI = txt_sub_soi.Text
        dao.fields.ADDR_ROAD = txt_sub_road.Text
        dao.fields.ADDR_TAMBON = txt_sub_tambol.Text
        dao.fields.ADDR_AMPHOR = txt_sub_amphor.Text
        dao.fields.ADDR_CHANGWAT = txt_sub_changwat.Text
        dao.fields.ADDR_ZIPCODE = txt_sub_zipcode.Text
        dao.fields.ADDR_TEL = txt_sub_tel.Text
        dao.fields.LCN_OPENTIME = txt_sub_opentime.Text

        dao.fields.STATUS_ID = 0
        dao.fields.STATUS_NAME = "บันทึกคำขอรอส่งเรื่อง"

        dao.fields.ACTIVE = 1
        dao.fields.CREATE_DATE = System.DateTime.Now
        dao.fields.CREATE_BY = ""


    End Sub

    Protected Sub DDL_EDIT_REASON_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_EDIT_REASON.SelectedIndexChanged

        lb_select_reason.Text = DDL_EDIT_REASON.SelectedItem.Text
        Dim ddl_select_main As Integer = 0
        Try
            ddl_select_main = DDL_EDIT_REASON.SelectedValue
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');", True)
        End Try

        bind_reason_sub(ddl_select_main)
        p1.Visible = True 'เปิด upload-file
        Try
            If DDL_EDIT_REASON.SelectedValue = 1 Then
                DDL_EDIT_REASON_SUB.Visible = False 'ddl_ย่อย
                BindTable(DDL_EDIT_REASON.SelectedValue, 0)
            ElseIf DDL_EDIT_REASON.SelectedValue = 4 Then
                DDL_EDIT_REASON_SUB.Visible = False 'ddl_ย่อย
                BindTable(DDL_EDIT_REASON.SelectedValue, 0)
            ElseIf DDL_EDIT_REASON.SelectedValue = 5 Then
                DDL_EDIT_REASON_SUB.Visible = False 'ddl_ย่อย
                p1.Visible = True 'เปิด upload-file
                BindTable(DDL_EDIT_REASON.SelectedValue, 0)
            Else
                lb1.Visible = True
                DDL_EDIT_REASON_SUB.Visible = True
            End If
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');parent.close_modal();", True)
        End Try
    End Sub
    Protected Sub DDL_EDIT_REASON_SUB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_EDIT_REASON_SUB.SelectedIndexChanged
        Try
            BindTable(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');", True)
        End Try


    End Sub

    Private Sub BindTable(ByVal ddl1 As Integer, ByVal ddl2 As Integer)


        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE
        Dim dao_at As New DAO_LCN.TB_MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE
        Dim group As Integer = 0

        Dim Process As Integer = 10201


        Dim rows As Integer = 1

        If _STATUS_ID = 9 Then 'ขอเอกสารเพิ่มเติม
            edit1.Visible = False 'ปิด DDL ขอแก้ไข ให้อัพไฟล์อย่างเดียว
            edit2.Visible = False 'ปิด DDL ปิดเหตุผลการแก้ไข ให้อัพไฟล์อย่างเดียว
            cm1.Text = "*โปรดแนบไฟล์เอกสาร (เพิ่มเติม)"
            dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_AND_TYPE_EDIT(Process, ddl1, ddl2, 2, True)


            For Each dao_f.fields In dao_f.datas
                If dao_f.fields.FILE_NUMBER_NAME <> 69 Then
                    Dim tr As New TableRow
                    tr.CssClass = "rows"
                    Dim tc As New TableCell
                    'Dim tc1 As New TableCell
                    Dim GET_UPLOAD_HEAD_ID As Integer = 0
                    Dim GET_TITEL_ID As Integer = 0
                    Dim GET_TITEL_ID2 As Integer = 0

                    tc = New TableCell
                    tc.Text = dao_f.fields.HEAD_ID
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    tc.Text = dao_f.fields.FILE_NUMBER_NAME
                    tc.Style.Add("display", "none")
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Try
                        tc.Text = Replace(dao_f.fields.SUB_DOCUMENT_NAME, "\n", "<br/>")
                    Catch ex As Exception
                        tc.Text = dao_f.fields.SUB_DOCUMENT_NAME
                    End Try
                    tc.Width = 900
                    tr.Cells.Add(tc)

                    dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID(Process, GET_UPLOAD_HEAD_ID, GET_TITEL_ID, GET_TITEL_ID2, 1)

                    If dao_f.fields.NAME_REAL <> "" Then
                        tc = New TableCell
                        tc.Text = dao_f.fields.NAME_REAL
                        tc.Width = 100
                        tr.Cells.Add(tc)

                        tc = New TableCell
                        Dim img As New Image
                        Dim AA As String = "/Images/correct.png"
                        img.ImageUrl = AA
                        img.Width = 20
                        img.Height = 20
                        tc.Controls.Add(img)
                        tc.Width = 40
                        tr.Cells.Add(tc)

                        tc = New TableCell
                        Dim f As New FileUpload
                        f.ID = "F" & dao_f.fields.FILE_NUMBER_NAME
                        tc.Controls.Add(f)
                        'tc.Width = 100
                        tr.Cells.Add(tc)
                    Else
                        tc = New TableCell
                        'tc.Text = dao_f.fields.NAME_REAL
                        tc.Width = 100
                        tr.Cells.Add(tc)

                        tc = New TableCell
                        Dim img As New Image
                        Dim AA As String = "/Images/cancel.png"
                        img.ImageUrl = AA
                        img.Width = 20
                        img.Height = 20
                        tc.Controls.Add(img)
                        tc.Width = 40
                        tr.Cells.Add(tc)

                        tc = New TableCell
                        Dim f As New FileUpload
                        f.ID = "F" & dao_f.fields.FILE_NUMBER_NAME
                        tc.Controls.Add(f)
                        tr.Cells.Add(tc)
                    End If

                    tb_type_menu.Rows.Add(tr)
                    rows = rows + 1
                End If


            Next
        Else
            dao_at.GetDataby_DDL(ddl1, ddl2, True)

            For Each dao_at.fields In dao_at.datas

                Dim tr As New TableRow
                tr.CssClass = "rows"
                Dim tc As New TableCell
                'Dim tc1 As New TableCell
                Dim GET_UPLOAD_HEAD_ID As Integer = 0
                Dim GET_TITEL_ID As Integer = 0
                Dim GET_TITEL_ID2 As Integer = 0
                'เช็คว่า HEAD_ID ตัวเดียวกันไหม
                GET_UPLOAD_HEAD_ID = dao_at.fields.HEAD_ID
                GET_TITEL_ID = dao_at.fields.TITEL_ID
                GET_TITEL_ID2 = dao_at.fields.TITLE_ID2

                tc = New TableCell
                tc.Text = rows
                tr.Cells.Add(tc)

                tc = New TableCell
                tc.Text = dao_at.fields.ID
                tc.Style.Add("display", "none")
                tr.Cells.Add(tc)

                tc = New TableCell
                Try
                    tc.Text = Replace(dao_at.fields.DUCUMENT_NAME, "\n", "<br/>")
                Catch ex As Exception
                    tc.Text = dao_at.fields.DUCUMENT_NAME
                End Try
                tc.Width = 900
                tr.Cells.Add(tc)

                dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID(Process, GET_UPLOAD_HEAD_ID, GET_TITEL_ID, GET_TITEL_ID2, 1)

                If dao_f.fields.HEAD_ID = GET_UPLOAD_HEAD_ID And dao_f.fields.FK_TITEL_ID = GET_TITEL_ID And dao_f.fields.FK_TITEL_ID2 = GET_TITEL_ID2 Then
                    tc = New TableCell
                    tc.Text = dao_f.fields.NAME_REAL
                    tc.Width = 100
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Dim img As New Image
                    Dim AA As String = ""
                    If dao_f.fields.NAME_REAL <> "" Then
                        AA = "/Images/correct.png"
                    Else
                        AA = "/Images/cancel.png"
                    End If

                    img.ImageUrl = AA
                    img.Width = 20
                    img.Height = 20
                    tc.Controls.Add(img)
                    tc.Width = 40
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Dim f As New FileUpload
                    f.ID = "F" & dao_at.fields.ID
                    tc.Controls.Add(f)
                    'tc.Width = 100
                    tr.Cells.Add(tc)
                Else
                    tc = New TableCell
                    'tc.Text = dao_f.fields.NAME_REAL
                    tc.Width = 100
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Dim img As New Image
                    Dim AA As String = "/Images/cancel.png"
                    img.ImageUrl = AA
                    img.Width = 20
                    img.Height = 20
                    tc.Controls.Add(img)
                    tc.Width = 40
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Dim f As New FileUpload
                    f.ID = "F" & dao_at.fields.ID
                    tc.Controls.Add(f)
                    tr.Cells.Add(tc)
                End If

                tb_type_menu.Rows.Add(tr)
                rows = rows + 1


            Next
        End If






    End Sub


    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click


        Try


            Dim lcn_edit_process As Integer = 0
            lcn_edit_process = 10201

            Dim ddl1 As Integer = 0
            Dim ddl2 As Integer = 0

            ddl1 = DDL_EDIT_REASON.SelectedValue

            Try
                ddl2 = DDL_EDIT_REASON_SUB.SelectedValue
            Catch ex As Exception
                ddl2 = 0
            End Try


            BindTable(ddl1, ddl2)


            'Dim tr As TableRow
            'tr = tb_type_menu.DataBind()
            For Each tr As TableRow In tb_type_menu.Rows
                Dim HEAD_ID As Integer = tr.Cells(0).Text 'เอาข้อมูลช่องแรกมา
                Dim IDA_FILE As Integer = tr.Cells(1).Text 'เอาข้อมูลช่องแรกมา
                Dim GET_SUB_DOC_NAME As String = tr.Cells(2).Text

                Dim f As New FileUpload

                f = tr.FindControl("F" & IDA_FILE)
                If f.HasFile Then
                    Dim name_real As String = f.FileName
                    Dim Array_NAME_REAL() As String = Split(name_real, ".")
                    Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                    Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                    If exten.ToUpper = "PDF" Then
                        Dim bao As New BAO.AppSettings
                        Dim dao_f As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE

                        Dim Name_fake As String = "HB-" & lcn_edit_process & "-" & Date.Now.Year & "-" & IDA_FILE & ".pdf"
                        Dim GET_IDA_UPLOAD As Integer = 0
                        dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID(lcn_edit_process, HEAD_ID, ddl1, ddl2, 1)

                        Try
                            GET_IDA_UPLOAD = dao_f.fields.IDA
                        Catch ex As Exception
                            GET_IDA_UPLOAD = 0
                        End Try
                        If GET_IDA_UPLOAD = 0 Then

                            dao_f.fields.FILE_NUMBER_NAME = IDA_FILE

                            dao_f.fields.DATE_YEAR = con_year(Date.Now().Year())
                            dao_f.fields.NAME_FAKE = Name_fake
                            dao_f.fields.NAME_REAL = f.FileName
                            dao_f.fields.CREATE_DATE = System.DateTime.Now

                            dao_f.fields.PROCESS_ID = lcn_edit_process
                            dao_f.fields.FK_IDA = _lcn_ida
                            'dao_f.fields.TYPE = TYPE 'ลำดับไฟล์เก็บไว้เรียกข้อมูล


                            dao_f.fields.TYPE_LOCAL_NAME = DDL_EDIT_REASON.SelectedItem.Text
                            If ddl2 <> 0 Then
                                dao_f.fields.DUCUMENT_NAME = DDL_EDIT_REASON_SUB.SelectedItem.Text
                            End If
                            dao_f.fields.SUB_DOCUMENT_NAME = GET_SUB_DOC_NAME
                            dao_f.fields.HEAD_ID = HEAD_ID
                            dao_f.fields.FK_TITEL_ID = ddl1
                            dao_f.fields.FK_TITEL_ID2 = ddl2
                            dao_f.fields.TYPE = 1

                            dao_f.fields.ACTIVE = 1

                            dao_f.insert()
                        Else
                            dao_f.fields.HEAD_ID = HEAD_ID
                            dao_f.fields.NAME_FAKE = Name_fake
                            dao_f.fields.NAME_REAL = f.FileName
                            dao_f.fields.UPDATE_DATE = System.DateTime.Now

                            dao_f.fields.TYPE = 1

                            dao_f.update()
                        End If


                        Dim paths As String = bao._PATH_DEFAULT
                        f.SaveAs(paths & "upload\" & "LCN_EDIT\" & Name_fake)
                    Else
                        alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                    End If
                End If

            Next

            'เมื่ออัพไฟล์ (เพิ่มเติม) ให้ update status = 8  ;ยื่นเอกสาร (เพิ่มเติม)
            If _STATUS_ID = 9 Then

                Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT
                Dim _YEAR As String = con_year(Date.Now().Year())
                dao_update.GetDataby_LCN_IDA_AND_YEAR_AND_ACTIVE(_lcn_ida, _year, True)

                dao_update.fields.STATUS_ID = 11
                dao_update.fields.STATUS_NAME = "ยื่นเอกสาร (เพิ่มเติม)"
                dao_update.fields.UPDATE_DATE = System.DateTime.Now

                dao_update.update()

                bind_pdf_xml_11(dao_update.fields.IDA, _lcn_ida, dao_update.fields.LCN_PROCESS_ID, dao_update.fields.STATUS_ID, dao_update.fields.DATE_YEAR, dao_update.fields.TR_ID)

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพโหลดเรียบร้อยแล้ว');", True)
            End If




            tb_type_menu.Rows.Clear() 'เคลียข้อมูล table 
            BindTable(ddl1, ddl2) 'Upload แล้ว bind tableใหม่
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพโหลดไม่สำเร็จ');", True)
        End Try

    End Sub

    Public Sub bind_pdf_xml_11(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
        Dim XML As New CLASS_GEN_XML.LCN_EDIT_SMP3
        TB_SMP3 = XML.gen_xml(_IDA, LCN_IDA, _YEAR)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_ProcessID, _StatusID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_SMP3\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_SMP3("HB_XML", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

End Class