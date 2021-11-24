Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Imports Telerik.Web.UI

Public Class WebForm35
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    ' Private _ProcessID As String
    Private _YEARS As String
    Private _TR_ID As String
    Private b64 As String
    Private _iden As String
    Private _lct_ida As String
    Private _ProcessID As New Integer
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        ''_la_IDA = Request.QueryString("la_IDA")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        _IDA = Request.QueryString("IDA")

        _ProcessID = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub
 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        'If Session("b64") IsNot Nothing Then
        '    b64 = Session("b64")
        'End If
        Set_Label(_iden)
        setdata_frgn_data()
        setdata_DALCN()
        'setdata_current_data()

        If Not IsPostBack Then
            TXT_APP_DATE.Text = Date.Now.ToShortDateString()
            HiddenField2.Value = 0

            Try
                Dim dao1 As New DAO_DRUG.ClsDBdalcn
                dao1.GetDataby_IDA(_IDA)
                'BindData_PDF()

                If dao1.fields.STATUS_ID = 8 Then
                    BindData_PDF()
                    Panel1.Style.Add("display", "none")
                Else
                    Panel1.Style.Add("display", "block")
                End If
            Catch ex As Exception
                Response.Redirect("https://privus.fda.moph.go.th/")
            End Try
            Bind_ddl_Status_staff()
            Bind_lbl_type_date()
            Bind_ddl_staff_name()
            load_fdpdtno()
            'UC_GRID_PHARMACIST.load_gv(_IDA)
            If _TR_ID <> "" Then
                'UC_GRID_ATTACH.load_gv(_TR_ID)
            End If

            set_hide(_IDA)
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(_IDA)
            Try
                txt_ref_no.Text = dao.fields.ref_no
            Catch ex As Exception

            End Try
            Try

                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_up.GetDataby_IDA(dao.fields.TR_ID)
                If dao_up.fields.PROCESS_ID = "106" Then
                    btn_drug_group.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
            Try
                If dao.fields.STATUS_ID >= 6 Then
                    lbl_ref_no.Style.Add("display", "block")
                    txt_ref_no.Style.Add("display", "block")
                Else
                    lbl_ref_no.Style.Add("display", "none")
                    txt_ref_no.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
            Try
                If Not IsPostBack Then
                    If _ProcessID = "122" Then
                        rdl_lcn_type.SelectedValue = "1"
                    ElseIf _ProcessID = "121" Then
                        rdl_lcn_type.SelectedValue = "2"
                    ElseIf _ProcessID = "120" Then
                        rdl_lcn_type.SelectedValue = "3"
                    End If
                End If
            Catch ex As Exception

            End Try

        End If

        If _ProcessID = 120 Or _ProcessID = 121 Or _ProcessID = 122 Then
            btn_sormorpo1.Style.Add("display", "block")
        Else
            btn_sormorpo1.Style.Add("display", "none")
        End If
        set_lbl()
        show_btn(_IDA)
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
                lbl_lcn_addr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_floor.Text = dr("floor")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_room.Text = dr("room")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_ages.Text = dr("age")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_amphor.Text = dr("amphrnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_building.Text = dr("building")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_changwat.Text = dr("chngwtnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_email.Text = dr("email")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_fax.Text = dr("fax")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_iden.Text = dr("identify")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_iden2.Text = dr("identify")
            'Catch ex As Exception

            'End Try
            Try
                lbl_lcn_mu.Text = dr("mu")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_name.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_nation.Text = dr("nation")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_road.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_soi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_tambol.Text = dr("thmblnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next



        Dim dt_bsn As New DataTable
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
        For Each dr As DataRow In dt_bsn.Rows
            Try
                lbl_BSN_THAIFULLNAME.Text = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_IDENTIFY.Text = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_AGE.Text = dr("AGE")
            Catch ex As Exception

            End Try
            Try
                lbl_c_thaaddr.Text = dr("BSN_ADDR")
            Catch ex As Exception

            End Try
            Try
                lbl_c_floor.Text = dr("BSN_FLOOR")
            Catch ex As Exception

            End Try
            Try
                lbl_c_room.Text = dr("BSN_ROOM")
            Catch ex As Exception

            End Try
            Try
                lbl_amphor.Text = dr("BSN_AMPHR_NAME")
            Catch ex As Exception

            End Try
            Try
                lbl_c_thabuilding.Text = dr("BSN_BUILDING")
            Catch ex As Exception

            End Try
            Try
                lbl_c_fax.Text = dr("BSN_FAX")
            Catch ex As Exception

            End Try
            Try
                lbl_c_thamu.Text = dr("BSN_MOO")
            Catch ex As Exception

            End Try
            Try
                lbl_c_tharoad.Text = dr("BSN_ROAD")
            Catch ex As Exception

            End Try
            Try
                lbl_c_thasoi.Text = dr("BSN_SOI")
            Catch ex As Exception

            End Try
            Try
                lbl_c_tel.Text = dr("BSN_TEL")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_c_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
            'Catch ex As Exception

            'End Try
            Try
                lbl_tambol.Text = dr("BSN_THMBL_NAME")
            Catch ex As Exception

            End Try
            Try
                lbl_c_zipcode.Text = dr("BSN_ZIPCODE")
            Catch ex As Exception

            End Try
            Try
                lbl_Province.Text = dr("BSN_CHWNGNAME")
            Catch ex As Exception

            End Try
        Next

        Dim dt_lct As New DataTable
        dt_lct = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(Request.QueryString("lct_ida"))
        For Each dr As DataRow In dt_lct.Rows
            Try
                lbl_lct_HOUSENO.Text = dr("HOUSENO")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thanameplace.Text = dr("thanameplace")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thachngwtnm.Text = dr("thachngwtnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_fax.Text = dr("fax")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thaaddr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thaamphrnm.Text = dr("thaamphrnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thabuilding.Text = dr("thabuilding")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thamu.Text = dr("thamu")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_tharoad.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thasoi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thathmblnm.Text = dr("thathmblnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next
        Dim dt_lcp As New DataTable
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(_IDA)
        Try
            lbl_PHR_NAME.Text = dao_phr.fields.PHR_NAME
        Catch ex As Exception

        End Try
        Try
            lbl_PHR_TEXT_NUM.Text = dao_phr.fields.PHR_TEXT_NUM
        Catch ex As Exception

        End Try
        Try
            lbl_STUDY_LEVEL.Text = dao_phr.fields.STUDY_LEVEL
        Catch ex As Exception

        End Try
        Try
            lbl_PHR_prefix.Text = dao_phr.fields.PHR_PREFIX_NAME
        Catch ex As Exception

        End Try
        Try
            lbl_PHR_VETERINARY_FIELD.Text = dao_phr.fields.PHR_VETERINARY_FIELD
        Catch ex As Exception

        End Try
        Try
            lbl_PHR_TEXT_WORK_TIME.Text = dao_phr.fields.PHR_TEXT_WORK_TIME
        Catch ex As Exception

        End Try
        Try
            lbl_NAME_SIMINAR.Text = dao_phr.fields.NAME_SIMINAR
        Catch ex As Exception

        End Try
        Try
            lbl_SIMINAR_DATE.Text = dao_phr.fields.SIMINAR_DATE
        Catch ex As Exception

        End Try
        Try
            rdl_mastra.SelectedValue = dao_phr.fields.PHR_LAW_SECTION
        Catch ex As Exception

        End Try



    End Sub
    Sub setdata_DALCN()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Try
            lbl_GIVE_PASSPORT_NO.Text = dao.fields.GIVE_PASSPORT_NO
        Catch ex As Exception

        End Try
        Try
            lbl_GIVE_PASSPORT_EXPDATE.Text = dao.fields.GIVE_PASSPORT_EXPDATE
        Catch ex As Exception

        End Try
        Try
            lbl_GIVE_WORK_LICENSE_NO.Text = dao.fields.GIVE_WORK_LICENSE_NO
        Catch ex As Exception

        End Try
        Try
            lbl_GIVE_WORK_LICENSE_EXPDATE.Text = dao.fields.GIVE_WORK_LICENSE_EXPDATE
        Catch ex As Exception

        End Try
    End Sub
    'Sub setdata_current_data()
    '    Dim dao As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS
    '    dao.GetData_By_FK_IDA(_IDA)

    '    Dim bao_show As New BAO_SHOW
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt_bsn As New DataTable
    '    Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
    '    dao_lcn.GetDataby_IDA(_IDA)
    '    dt_bsn = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(_iden)

    '    Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
    '    dao_frgn.GetDataby_FK_IDA(_IDA)
    '    If dao_frgn.fields.addr_status Is Nothing Then
    '        dt_bsn = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(_iden)
    '        For Each dr As DataRow In dt_bsn.Rows
    '            Try
    '                lbl_c_thaaddr.Text = dr("BSN_ADDR")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                lbl_c_floor.Text = dr("BSN_FLOOR")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                lbl_c_room.Text = dr("BSN_ROOM")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                lbl_BSN_AGE.Text = dr("AGE")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                lbl_amphor.Text = dr("BSN_AMPHR_NAME")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                lbl_c_thabuilding.Text = dr("BSN_BUILDING")
    '            Catch ex As Exception

    '            End Try
    '            'Try
    '            '    txt_c_fax.Text = dr("BSN_FAX")
    '            'Catch ex As Exception

    '            'End Try
    '            'Try
    '            '    lbl_BSN_IDENTIFY.Text = dr("BSN_IDENTIFY")
    '            'Catch ex As Exception

    '            'End Try
    '            Try
    '                lbl_c_thamu.Text = dr("BSN_MOO")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                lbl_c_tharoad.Text = dr("BSN_ROAD")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                lbl_c_thasoi.Text = dr("BSN_SOI")
    '            Catch ex As Exception

    '            End Try
    '            'Try
    '            '    txt_c_tel.Text = dr("BSN_TEL")
    '            'Catch ex As Exception

    '            'End Try
    '            'Try
    '            '    lbl_BSN_THAIFULLNAME.Text = dr("BSN_THAIFULLNAME")
    '            'Catch ex As Exception

    '            'End Try
    '            Try
    '                lbl_tambol.Text = dr("BSN_THMBL_NAME")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                lbl_c_zipcode.Text = dr("BSN_ZIPCODE")
    '            Catch ex As Exception

    '            End Try
    '            Try
    '                lbl_Province.Text = dr("thachngwtnm")
    '            Catch ex As Exception

    '            End Try
    '        Next


    '    ElseIf dao_frgn.fields.addr_status IsNot Nothing Then

    '        Try
    '            lbl_c_thaaddr.Text = dao.fields.thaaddr
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            lbl_c_floor.Text = dao.fields.thafloor
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            lbl_c_room.Text = dao.fields.tharoom
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            lbl_c_thabuilding.Text = dao.fields.thabuilding
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            lbl_c_thamu.Text = dao.fields.thamu
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            lbl_c_thasoi.Text = dao.fields.thasoi
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            lbl_c_tharoad.Text = dao.fields.tharoad
    '        Catch ex As Exception

    '        End Try

    '        Try
    '            lbl_c_zipcode.Text = dao.fields.zipcode
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            lbl_c_email.Text = dao.fields.email
    '        Catch ex As Exception

    '        End Try
    '        If dao.fields.thmblcd IsNot Nothing Then
    '            Dim dao_thambol As New DAO_CPN.clsDBsysthmbl
    '            dao_thambol.GetData_by_chngwtcd_amphrcd_thmblcd(dao.fields.chngwtcd, dao.fields.amphrcd, dao.fields.thmblcd)
    '            Try
    '                lbl_tambol.Text = dao_thambol.fields.thathmblnm
    '            Catch ex As Exception

    '            End Try
    '        ElseIf dao.fields.thmblcd Is Nothing Then
    '            For Each dr As DataRow In dt_bsn.Rows
    '                Try
    '                    lbl_tambol.Text = dr("BSN_THMBL_NAME")
    '                Catch ex As Exception

    '                End Try
    '            Next

    '        End If

    '        If dao.fields.amphrcd IsNot Nothing Then
    '            Dim dao_amper As New DAO_CPN.clsDBsysamphr
    '            dao_amper.GetData_by_chngwtcd_amphrcd(dao.fields.chngwtcd, dao.fields.amphrcd)
    '            Try
    '                lbl_amphor.Text = dao_amper.fields.thaamphrnm

    '            Catch ex As Exception

    '            End Try
    '        ElseIf dao.fields.amphrcd Is Nothing Then
    '            For Each dr As DataRow In dt_bsn.Rows
    '                Try
    '                    lbl_amphor.Text = dr("BSN_AMPHR_NAME")
    '                Catch ex As Exception

    '                End Try
    '            Next
    '        End If

    '        If dao.fields.chngwtcd IsNot Nothing Then
    '            Dim dao_province As New DAO_CPN.clsDBsyschngwt
    '            dao_province.GetData_by_chngwtcd(dao.fields.chngwtcd)
    '            Try
    '                lbl_Province.Text = dao_province.fields.thachngwtnm
    '            Catch ex As Exception

    '            End Try
    '        ElseIf dao.fields.chngwtcd Is Nothing Then
    '            For Each dr As DataRow In dt_bsn.Rows
    '                Try
    '                    lbl_Province.Text = dr("thachngwtnm")
    '                Catch ex As Exception

    '                End Try
    '            Next
    '        End If
    '    End If





    'End Sub

    'Sub setdata_systhmbl()
    '    Dim dao As New DAO_CPN.clsDBsyschngwt
    '    dao.GetData_by_chngwtcd()

    'End Sub
    Sub setdata_frgn_data()
        Dim dao As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao.GetDataby_FK_IDA(_IDA)
        Try
            lbl_PASSPORT_NO.Text = dao.fields.PASSPORT_NO
        Catch ex As Exception

        End Try
        Try
            lbl_PASSPORT_EXPDATE.Text = dao.fields.PASSPORT_EXPDATE
        Catch ex As Exception

        End Try
        Try
            lbl_DOC_NO.Text = dao.fields.DOC_NO
        Catch ex As Exception

        End Try
        Try
            lbl_DOC_DATE.Text = dao.fields.DOC_DATE
        Catch ex As Exception

        End Try
        Try
            lbl_WORK_LICENSE_NO.Text = dao.fields.WORK_LICENSE_NO
        Catch ex As Exception

        End Try
        Try
            lbl_WORK_LICENSE_EXPDATE.Text = dao.fields.WORK_LICENSE_EXPDATE
        Catch ex As Exception

        End Try
        Try
            lbl_BS_NO1.Text = dao.fields.BS_NO1
        Catch ex As Exception

        End Try
        Try
            lbl_BS_DATE1.Text = dao.fields.BS_DATE1
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_NO1.Text = dao.fields.FRGN_NO1
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_DATE1.Text = dao.fields.FRGN_DATE1
        Catch ex As Exception

        End Try
        Try
            lbl_BS_NO.Text = dao.fields.BS_NO
        Catch ex As Exception


        End Try
        Try
            lbl_BS_DATE.Text = dao.fields.BS_DATE
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_DATE.Text = dao.fields.FRGN_DATE
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_NO.Text = dao.fields.FRGN_NO
        Catch ex As Exception

        End Try
        Try
            cb_Personal_Type1.TabIndex = dao.fields.PERSONAL_TYPE
        Catch ex As Exception

        End Try
        Try
            cb_Personal_Type2.TabIndex = dao.fields.PERSONAL_TYPE
        Catch ex As Exception

        End Try
        Try
            rdl_sanchaat.SelectedValue = dao.fields.PERSONAL_TYPE_MENU
            If rdl_sanchaat.SelectedValue = 1 Then
                TB_Personal_Type1.Visible = False
                TB_Personal_Type2.Visible = False
                TB_Personal.Visible = False
            ElseIf rdl_sanchaat.SelectedValue = 2 Then
                TB_Personal_Type1.Visible = True
                TB_Personal_Type2.Visible = True
            End If

        Catch ex As Exception

        End Try

        Try
            If cb_Personal_Type1.TabIndex = 1 Then
                cb_Personal_Type1.Checked = True
                TB_Personal_Type2.Visible = False
            ElseIf cb_Personal_Type2.TabIndex = 2 Then
                cb_Personal_Type2.Checked = True
                TB_Personal_Type1.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID <> 5 And dao.fields.STATUS_ID <> 6 Then
            btn_preview.Enabled = False
            ' btn_cancel.Enabled = False
            btn_preview.CssClass = "btn-danger btn-lg"
            'btn_preview.CssClass = "btn-danger btn-lg"

        End If


    End Sub
    Public Sub set_hide(ByVal IDA As String)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(IDA)
        If dao.fields.STATUS_ID = 8 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
            btn_preview.CssClass = "btn-danger btn-lg"
            ddl_cnsdcd.Style.Add("display", "none")
        End If

        'If dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 6 Then
        '    ddl_template.Style.Add("display", "block")
        'End If
        'Try
        '    Dim dao_u As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        '    dao_u.GetDataby_IDA(_TR_ID)
        '    If dao_u.fields.PROCESS_ID = "104" Then
        '        ddl_template.Style.Add("display", "block")
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub
    Sub set_lbl()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)

        Dim dao_s As New DAO_DRUG.TB_MAS_STAFF_NAME_HERB
        Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
        Try
            dao_s.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
            lbl_staff_consider.Text = dao_s.fields.STAFF_NAME
        Catch ex As Exception
            lbl_staff_consider.Text = "-"
        End Try
        Try
            'lbl_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
        Catch ex As Exception
            'lbl_app_date.Text = "-"
        End Try
        Try
            lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
        Catch ex As Exception

        End Try

        Try
            dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 2)
            lbl_Status.Text = dao_stat.fields.STATUS_NAME
        Catch ex As Exception

        End Try


    End Sub
    Sub load_fdpdtno()
        Dim bao As New BAO.ClsDBSqlcommand
        'lbl_fdpdtno.Text = get_fdpdtno().Substring(0, 2) & "-" & get_fdpdtno().Substring(2, 1) & "-" & get_fdpdtno().Substring(3, 5) & "-" & get_fdpdtno().Substring(8, 1) & "-"
        'lbl_fdpdtno2.Text = _CLS.IDA    'ปรับให้runno

    End Sub
    Function get_fdpdtno() As String
        Dim fdpdtno As String = String.Empty
        Dim pvncd As String = String.Empty
        Dim lcntypecd As String = String.Empty
        Dim lcnno_num As String = String.Empty
        Dim tpye As String = String.Empty
        Dim REF_NO As String = String.Empty
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim bao As New BAO.ClsDBSqlcommand
        dao_up.GetDataby_IDA(_CLS.IDA)
        REF_NO = dao_up.fields.REF_NO
        dao.GetDataby_IDA(_CLS.IDA)
        pvncd = dao.fields.pvncd.ToString()


        lcntypecd = dao.fields.lcntpcd.ToString()
        lcntypecd = Chn_lcntpcd(dao.fields.lcntpcd)
        lcnno_num = dao.fields.lcnno.ToString().Trim().Substring(2, 5)
        If _CLS.PVCODE = 10 Then
            If lcntypecd = "1" Then
                tpye = "1"
            ElseIf lcntypecd = "2" Then
                tpye = "3"
            End If
        Else
            If lcntypecd = "1" Then
                tpye = "2"
            ElseIf lcntypecd = "2" Then
                tpye = "4"
            End If
        End If
        fdpdtno = pvncd & lcntypecd & lcnno_num & tpye
        Return fdpdtno
    End Function

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click

        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer

        dao.GetDataby_IDA(_IDA)
        dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Try
            dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
        dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        dao_date.fields.PROCESS_ID = 0
        dao_date.insert()
        Dim ddl_id As Integer = 0
        Dim ddl_name As String = ""
        If rcb_staff_offer.SelectedValue <> 0 Then
            Try
                ddl_id = rcb_staff_offer.SelectedValue
                ddl_name = rcb_staff_offer.SelectedItem.Text
            Catch ex As Exception
                ddl_id = 0
            End Try
        End If
        If rcb_staff_offer.SelectedValue = "-- กรุณาเลือก --" Or rcb_staff_offer.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกเจ้าหน้าที่รับผิดชอบ');", True)
        Else
            If STATUS_ID = 3 Or STATUS_ID = 17 Then
                Dim LCNNO_V2 As Integer
                Dim bao2 As New BAO.GenNumber
                Dim RCVNO_HERB_NEW As Integer
                dao.fields.STATUS_ID = STATUS_ID
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

                RCVNO_HERB_NEW = bao2.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)

                Dim _year As Integer = con_year(Date.Now.Year)
                If _year < 2500 Then
                    _year += 543
                End If

                dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                Try
                    dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try

                LCNNO_V2 = con_year(Date.Now.Year).Substring(2, 2) & RCVNO_HERB_NEW

                dao.fields.RCVNO_NEW = "HB " & _CLS.PVCODE & "-" & PROCESS_ID & "-" & con_year(Date.Now.Year).Substring(2, 2) & "-" & RCVNO_HERB_NEW

                dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
                'dao.fields.frtappdate = Date.Now
                AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)
                AddLogStatus(3, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                dao.update()

                'Dim cls_sop As New CLS_SOP
                'cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", PROCESS_ID, _CLS.PVCODE, 2, "รับคำขอ", "SOP-DRUG-10-" & PROCESS_ID & "-2", "เสนอลงนาม", "รอเจ้าหน้าที่เสนอลงนาม", "STAFF", _TR_ID, SOP_STATUS:="รับคำขอ")

                '-----------------ลิ้งไปหน้าคีย์มือ----------
                Response.Redirect("FRM_STAFF_LCN_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                '--------------------------------
                alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
            ElseIf STATUS_ID = 11 Then
                AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)
                Response.Redirect("FRM_STAFF_LCN_PAY_NOTE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&STATUS_ID=" & STATUS_ID)
            ElseIf STATUS_ID = 12 Then
                AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)
                Response.Redirect("FDA_STAFF_LCN_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&STATUS_ID=" & STATUS_ID)
                'ElseIf STATUS_ID = 13 Then
                '    Response.Redirect("FRM_STAFF_LCN_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&STATUS_ID=" & "13")
            ElseIf STATUS_ID = 13 Then
                AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)
                AddLogStatus(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                Response.Redirect("FDA_STAFF_LCN_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&STATUS_ID=" & STATUS_ID)

                'Response.Redirect("FRM_STAFF_LCN_PAY_NOTE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                alert("อัพเดทเรียบร้อยแล้ว")
            ElseIf STATUS_ID = 5 Or STATUS_ID = 16 Then
                dao.fields.STATUS_ID = STATUS_ID

                AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)
                AddLogStatus(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                'Response.Redirect("FRM_STAFF_LCN_PAY_NOTE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                dao.update()
                alert("อัพเดทเรียบร้อยแล้ว")

            ElseIf STATUS_ID = 14 Then
                If Txt_Remark.Text = "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาระบุหมายเหต');", True)
                Else
                    dao.fields.REMARK_PREVIEW = Txt_Remark.Text
                    dao.fields.STATUS_ID = STATUS_ID
                    dao.update()
                    AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)
                    alert("อัพเดทเรียบร้อยแล้ว")
                    'Response.Redirect("FRM_STAFF_LCN_REMARK_REVIEW.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&STATUS_ID=" & STATUS_ID)
                End If
                'dao.fields.STATUS_ID = 11
                'dao.update()
                'alert("อัพเดทเรียบร้อยแล้ว")

            ElseIf STATUS_ID = 6 Then
                    Try
                        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
                        dao_p.GetDataby_Process_ID(PROCESS_ID)
                        Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

                        Dim CONSIDER_DATE As Date = CDate(TXT_APP_DATE.Text)
                        Dim _type_da As String = ""
                        If dao.fields.PROCESS_ID = "120" Then
                            _type_da = "3"
                        ElseIf dao.fields.PROCESS_ID = "121" Then
                            _type_da = "2"
                        ElseIf dao.fields.PROCESS_ID = "122" Then
                            _type_da = "1"
                        End If

                        '--------------------------------
                        Dim chw As String = ""
                        Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
                        Try
                            dao_cpn.GetData_by_chngwtcd(dao.fields.pvncd)
                            chw = dao_cpn.fields.thacwabbr
                        Catch ex As Exception

                        End Try
                        Dim bao2 As New BAO.GenNumber
                        Dim LCNNO As Integer
                        Dim LCNNO_V2 As Integer
                        LCNNO = bao2.GEN_LCNNO_NEW(con_year(Date.Now.Year), _CLS.PVCODE, GROUP_NUMBER, PROCESS_ID, 0, 0, _IDA, "")

                        Dim _year As Integer = con_year(Date.Now.Year)
                        If _year < 2500 Then
                            _year += 543
                        End If

                        LCNNO_V2 = con_year(Date.Now.Year).Substring(2, 2) & LCNNO
                        'Convert.ToInt32(LCNNO_V2)
                        dao.fields.lcnno = LCNNO_V2
                        dao.fields.LCNNO_DISPLAY_NEW = "HB " & _CLS.PVCODE & "-" & _type_da & "-" & con_year(Date.Now.Year).Substring(2, 2) & "-" & LCNNO
                        '---------------------------------------
                        dao.fields.remark = Txt_Remark.Text
                        dao.fields.STATUS_ID = 6
                        dao.fields.CONSIDER_DATE = CONSIDER_DATE

                        dao.fields.FK_STAFF_OFFER_IDA = rcb_staff_offer.SelectedValue
                        dao.update()

                        alert("บันทึกข้อมูลเรียบร้อย")
                        AddLogStatus(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                        AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)
                    Catch ex As Exception
                        Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
                    End Try
                    ' Response.Redirect("FRM_STAFF_LCN_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                ElseIf STATUS_ID = 8 Then
                    dao.fields.STATUS_ID = STATUS_ID
                    Try
                        dao.fields.appdate = CDate(TXT_APP_DATE.Text)
                    Catch ex As Exception

                    End Try
                    If IsNothing(dao.fields.appdate) = False Then
                        Dim appdate As Date = CDate(dao.fields.appdate)
                        Dim expyear As Integer = 0
                        Try
                            expyear = Year(appdate)
                            If expyear <> 0 Then
                                If expyear < 2500 Then
                                    expyear += 543
                                End If
                                dao.fields.expyear = expyear
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            If dao.fields.PROCESS_ID = "120" Or dao.fields.PROCESS_ID = "121" Or dao.fields.PROCESS_ID = "122" Then
                                dao.fields.expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 5, appdate))
                            End If
                        Catch ex As Exception

                        End Try
                        dao.fields.STATUS_ID = STATUS_ID
                        dao.update()
                    End If

                    Dim cls_sop As New CLS_SOP
                    cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", dao.fields.PROCESS_ID, _CLS.PVCODE, 8, "อนุมัติ", "SOP-DRUG-10-" & dao.fields.PROCESS_ID & "-3", "อนุมัติ", "เจ้าหน้าที่อนุมัติคำขอแล้ว", "STAFF", _TR_ID, SOP_STATUS:="อนุมัติ")

                    AddLogStatus(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                    AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)

                    ''-----------------ลิ้งไปหน้าคีย์มือ----------
                    ''Response.Redirect("FRM_STAFF_LCN_LCNNO_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                    ''--------------------------------
                    'Dim cls_sop As New CLS_SOP
                    'cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", PROCESS_ID, _CLS.PVCODE, 8, "อนุมัติ", "SOP-DRUG-10-" & PROCESS_ID & "-3", "อนุมัติ", "เจ้าหน้าที่อนุมัติคำขอแล้ว", "STAFF", _TR_ID, SOP_STATUS:="อนุมัติ")

                    alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
                    'alert_reload("ดำเนินการอนุมัติเรียบร้อยแล้ว")
                ElseIf STATUS_ID = 7 Then
                    AddLogStatus(STATUS_ID, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)
                Response.Redirect("FRM_STAFF_LCN_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            End If

        End If

    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")

        Dim dao_n As New DAO_DRUG.ClsDBdalcn
        dao_n.GetDataby_IDA(_IDA)
        Try
            If dao_n.fields.SEND_POST = 1 Then
                '  Label2.Text = "รับด้วยตัวเอง"
            ElseIf dao_n.fields.SEND_POST = 2 Then
                '   Label2.Text = "ส่งไปรษณีย์"
            Else
                '   Label2.Text = "รับด้วยตัวเอง"
            End If
        Catch ex As Exception

        End Try

        Bind_ddl_Status_staff()
        BindData_PDF()
    End Sub

    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)

        If dao.fields.STATUS_ID = 2 Then
            int_group_ddl = 1
        ElseIf dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 14 Then
            int_group_ddl = 2
        ElseIf dao.fields.STATUS_ID = 5 Or dao.fields.STATUS_ID = 16 Then
            int_group_ddl = 3
        ElseIf dao.fields.STATUS_ID >= 6 And dao.fields.STATUS_ID < 11 Then
            int_group_ddl = 4
        ElseIf dao.fields.STATUS_ID = 17 Then
            int_group_ddl = 6
        ElseIf dao.fields.STATUS_ID = 18 Then
            int_group_ddl = 7
        End If


        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()
    End Sub
    Public Sub Bind_ddl_staff_name()
        Dim dao As New DAO_DRUG.TB_MAS_STAFF_NAME_HERB
        dao.GetDataby_All()

        rcb_staff_offer.DataSource = dao.datas 'dao.datas
        rcb_staff_offer.DataTextField = "STAFF_NAME"
        rcb_staff_offer.DataValueField = "IDA"
        rcb_staff_offer.DataBind()
        Dim item As New RadComboBoxItem
        item.Text = "---กรุณาเลือก---"
        item.Value = "0"
        rcb_staff_offer.Items.Insert(0, item)
    End Sub
    Public Sub Bind_lbl_type_date()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)

        If dao.fields.STATUS_ID = 2 Then
            lbl_update_date.Text = "วันที่รับคำขอ :"

        ElseIf dao.fields.STATUS_ID = 11 Then
            lbl_update_date.Text = "วันที่ประเมิน"
        ElseIf dao.fields.STATUS_ID = 5 Or dao.fields.STATUS_ID = 16 Then
            lbl_update_date.Text = "วันที่ลงนาม :"
            show02.Visible = True
            SHOW03.Visible = True
            'show01.Style.Add("display", "none")
            'show02.Style.Add("display", "none")
            'SHOW03.Style.Add("display", "none")
        ElseIf dao.fields.STATUS_ID = 14 Then
            lbl_update_date.Text = "วันที่รับเรื่อง  :"
            txt_remark_review.Text = dao.fields.REMARK_PREVIEW
            SHOW03.Visible = True
            SHOW04_NOTE.Visible = True
        ElseIf dao.fields.STATUS_ID >= 6 And dao.fields.STATUS_ID < 11 Then
            lbl_update_date.Text = "วันที่รับเรื่อง :"
            SHOW03.Visible = True
        ElseIf dao.fields.STATUS_ID = 17 Then
            lbl_update_date.Text = "วันที่รับเรื่อง :"
        ElseIf dao.fields.STATUS_ID = 18 Then
            lbl_update_date.Text = "วันที่รับเรื่อง :"
        End If
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = 78
        dao.update()

        AddLogStatus(78, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        alert("ดำเนินการยกเลิกคำขอแล้ว")
    End Sub

    'Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
    '    load_pdf(HiddenField1.Value)
    '    'Dim clsds As New ClassDataset

    '    'Response.Clear()
    '    'Response.ContentType = "Application/pdf"
    '    'Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
    '    'Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

    '    'Response.Flush()
    '    'Response.Close()
    '    'Response.End()
    'End Sub

    'Sub load_pdf(ByVal filename As String)
    '    Try

    '        Dim clsds As New ClassDataset
    '        Response.Clear()
    '        Response.ContentType = "Application/pdf"
    '        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")

    '        Response.BinaryWrite(clsds.UpLoadImageByte(filename)) '"C:\path\PDF_XML_CLASS\"

    '    Catch ex As Exception

    '    Finally

    '        Response.Flush()
    '        Response.Close()
    '        Response.End()
    '    End Try

    'End Sub
    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        'UC_CONFIRM.load_SORBOR5(p2)
    End Sub
    ' ''' <summary>
    ' ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF_Output(ByVal filename As String)
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()
    '    Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & "PDFdalcn_output_5.pdf") 'C:\path\PDF_TEMPLATE\
    '        Using outputStream = New FileStream(bao._PATH_PDF_TRADER & filename & "-output.pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset


    'End Sub

    Private Sub BindData_PDF(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim lcnno_format_NEW As String = ""
        Dim pvncd As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_PHR2 As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)

        Dim ProcessID As String = ""
        Try
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        If PROCESS_ID = "" Then
            PROCESS_ID = dao.fields.PROCESS_ID
        End If
        Try
            pvncd = dao.fields.pvncd
        Catch ex As Exception

        End Try
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntpcd = Chn_lcntpcd(lcntpcd)
        Dim lcnsid_da As Integer = 0
        Try
            lcnsid_da = dao.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, lcnsid_da, lcnno:=lcnno_auto, lcntpcd:=lcntpcd, pvncd:=pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        Dim bao_show As New BAO_SHOW
        'class_xml = cls_dalcn.gen_xml()

        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(1, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        'class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA(_IDA)
        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao.fields.FK_IDA) ' 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)

        Dim tt As Integer = 0
        If dao.fields.lcntpcd.Contains("ผ") Then
            tt = 1
            'ElseIf dao.fields.lcntpcd.Contains("น") Then
            '   tt = 2
        Else
            tt = 3
        End If
        If tt = 1 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, tt)
        ElseIf tt = 2 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB_V3(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, tt)
        ElseIf tt = 3 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB2(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, tt)
        End If

        Dim dt9 As New DataTable

        'dt9 = class_xml.DT_SHOW.DT9
        For Each drr As DataRow In class_xml.DT_SHOW.DT9.Rows
            Try
                drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
            Catch ex As Exception

            End Try
            Try
                '
                Try
                    drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                drr("tharoom") = NumEng2Thai(drr("tharoom"))
            Catch ex As Exception

            End Try
            Try
                drr("thanameplace") = NumEng2Thai(drr("thanameplace"))
            Catch ex As Exception

            End Try
            Try
                drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
            Catch ex As Exception

            End Try
            Try
                drr("tel1") = NumEng2Thai(drr("tel1"))
            Catch ex As Exception

            End Try
            '
            '
            Try
                drr("thamu") = NumEng2Thai(drr("thamu"))
            Catch ex As Exception

            End Try
            Try
                drr("thafloor") = NumEng2Thai(drr("thafloor"))
            Catch ex As Exception

            End Try
            Try
                drr("thasoi") = NumEng2Thai(drr("thasoi"))
            Catch ex As Exception

            End Try
            Try
                drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
            Catch ex As Exception

            End Try
            Try
                drr("tharoad") = NumEng2Thai(drr("tharoad"))
            Catch ex As Exception

            End Try
            Try
                drr("zipcode") = NumEng2Thai(drr("zipcode"))
            Catch ex As Exception

            End Try
            Try
                drr("tel") = NumEng2Thai(drr("tel"))
            Catch ex As Exception

            End Try
            Try
                drr("fax") = NumEng2Thai(drr("fax"))
            Catch ex As Exception

            End Try
            Try
                drr("Mobile") = NumEng2Thai(drr("Mobile"))
            Catch ex As Exception

            End Try
            Try
                drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
            Catch ex As Exception

            End Try

        Next
        'class_xml.DT_SHOW.DT9 = dt9

        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Dim DT11 As New DataTable
        Try
            'DT11 = class_xml.DT_SHOW.DT11
            For Each drr As DataRow In class_xml.DT_SHOW.DT11.Rows
                Try
                    If drr("thaaddr") = "" Then
                        drr("thaaddr") = "-"
                    End If
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"

        Try
            Dim dao_phr_c As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr_c.GetDataby_FK_IDA(_IDA)
            Dim c_phr As Integer = 0
            For Each dao_phr_c.fields In dao_phr_c.datas
                c_phr += 1
            Next
            class_xml.PHR_COUNT = c_phr
        Catch ex As Exception

        End Try

        Try
            'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            ' class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            'SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        Catch ex As Exception

        End Try

        'Dim bao_lisense_neme As New BAO.ClsDBSqlcommand
        Try
            class_xml.DT_MASTER.DT38 = bao_show.SP_Lisense_Name_and_Addr(_iden) 'ผู้ขออนุญาติ
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        Dim DT13 As New DataTable
        Try
            DT13 = class_xml.DT_SHOW.DT13
            For Each drr As DataRow In DT13.Rows
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน

        Dim BSN_IDENTIFY As String = ""
        Try
            'If MAIN_LCN_IDA <> 0 Then
            '    Dim dao_lcn2 As New DAO_DRUG.ClsDBdalcn
            '    dao_lcn2.GetDataby_IDA(MAIN_LCN_IDA)
            'End If
            BSN_IDENTIFY = NumEng2Thai(dao.fields.BSN_IDENTIFY)
        Catch ex As Exception

        End Try
        Dim MAIN_LCN_IDA As Integer = 0
        'If IsNothing(dao.fields.MAIN_LCN_IDA) = False Then
        '    If (Integer.TryParse(dao.fields.MAIN_LCN_IDA, MAIN_LCN_IDA) = True) Then        'เปลี่ยน ร
        '        class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        '    End If
        'End If
        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(BSN_IDENTIFY) 'ผู้ดำเนิน
        'If MAIN_LCN_IDA <> 0 Then
        '    'ใบย่อย
        '    class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(MAIN_LCN_IDA) 'ผู้ดำเนิน

        '    'Dim dao_mn As New DAO_DRUG.ClsDBdalcn
        '    'dao_mn.GetDataby_IDA(MAIN_LCN_IDA)
        '    'lcnno_auto = dao_mn.fields.lcnno
        'Else

        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        'End If
        Dim dt14 As New DataTable
        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(_IDA)
        Try
            If dao_frgn.fields.addr_status = 0 Or dao_frgn.fields.addr_status = 1 Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_DALCN_CURRENT_ADDRESS(_IDA)
            ElseIf dao_frgn.fields.addr_status = Nothing Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
            End If

        Catch ex As Exception

        End Try
        'Dim DT39 As New DataTable
        'Try
        '    DT39 = class_xml.DT_MASTER.DT39
        '    For Each drr As DataRow In DT39.Rows
        '        drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
        '        drr("CREATE_DATE") = NumEng2Thai(drr("CREATE_DATE"))
        '        drr("AGE") = NumEng2Thai(drr("AGE"))
        '        drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
        '        drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
        '        drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
        '        'fulladdr
        '    Next
        'Catch ex As Exception

        'End Try
        Try
            dt14 = class_xml.DT_SHOW.DT14
            For Each drr As DataRow In dt14.Rows
                drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA) 'ผู้มีหน้าที่ปฎิบัติการ
        'Dim DT18 As New DataTable

        'DT18 = class_xml.DT_MASTER.DT18
        'For Each drr As DataRow In DT18.Rows
        '    Try
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '    Catch ex As Exception

        '    End Try

        'Next
        class_xml.DT_SHOW.DT35 = bao_master.SP_DALCN_FRGN_DATA(_IDA)

        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao.fields.IDA)
        Dim DT24 As New DataTable
        Try
            DT24 = class_xml.DT_MASTER.DT24
            For Each drr As DataRow In DT24.Rows
                Try
                    drr("thanameplace2") = NumEng2Thai(drr("thanameplace2"))
                Catch ex As Exception

                End Try
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
            class_xml.DT_MASTER.DT24 = DT24
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        Dim DT25 As New DataTable
        Try
            DT25 = class_xml.DT_MASTER.DT25
            For Each drr As DataRow In DT25.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        Dim DT26 As New DataTable
        Try
            DT26 = class_xml.DT_MASTER.DT26
            For Each drr As DataRow In DT26.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 2)
        Dim DT27 As New DataTable
        Try
            DT27 = class_xml.DT_MASTER.DT27
            For Each drr As DataRow In DT27.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 1)
        Dim DT28 As New DataTable
        Try
            DT28 = class_xml.DT_MASTER.DT28
            For Each drr As DataRow In DT28.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 2)
        Dim DT29 As New DataTable
        Try
            DT29 = class_xml.DT_MASTER.DT29
            For Each drr As DataRow In DT29.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"

        class_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(dao.fields.IDA)
        Dim DT31 As New DataTable

        DT31 = class_xml.DT_MASTER.DT31
        For Each drr As DataRow In DT31.Rows
            Try
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Catch ex As Exception

            End Try

        Next


        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try
        'Try
        '    If Len(lcnno_auto) > 0 Then

        '        If Right(Left(lcnno_auto, 3), 1) = "5" Then
        '            lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
        '        Else
        '            lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
        Try
            If dao.fields.REVOCATION Is Nothing Or Trim(dao.fields.REVOCATION) = "" Then
                If Len(lcnno_auto) > 0 Then

                    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                        lcnno_format = dao.fields.pvnabbr & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                    'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)

                End If

                lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW

            Else

                Dim _type_da As String = ""
                If dao.fields.PROCESS_ID = "120" Then
                    _type_da = "3"
                ElseIf dao.fields.PROCESS_ID = "121" Then
                    _type_da = "2"
                ElseIf dao.fields.PROCESS_ID = "122" Then
                    _type_da = "1"
                End If

                If Not dao.fields.LCNNO_DISPLAY_NEW Is Nothing Then
                    lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    'Try
                    '    Dim App_Date As Date = dao.fields.appdate
                    '    If App_Date > #10/1/2019 12:00:00 AM# Then
                    '        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    '    Else
                    '        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then
                            lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                        Else
                            lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                        End If
                        'lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    Else
                        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                End If

            End If

        Catch ex As Exception

        End Try
        Try
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

            Try
                'lcnno_format = 
                'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
                    class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                Else
                    class_xml.HEAD_LCNNO = dao_main2.fields.pvnabbr & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                End If

                class_xml.HEAD_LCNNO = NumEng2Thai(class_xml.HEAD_LCNNO)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT32 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT32.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"
        class_xml.DT_MASTER.DT33 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT33.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"

        class_xml.DT_MASTER.DT34 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 3)
        Dim DT34 As New DataTable
        Try
            DT34 = class_xml.DT_MASTER.DT34
            For Each drr As DataRow In DT34.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
                drr("PHR_CERTIFICATE_TRAINING1") = NumEng2Thai(drr("PHR_CERTIFICATE_TRAINING1"))
                '
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT34.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_3_1_ROW"

        Dim rcvno_format As String = ""
        Dim RCV_DATE As String = ""
        Try
            rcvno_format = dao.fields.RCVNO_NEW
        Catch ex As Exception

        End Try

        Dim rcvdate1 As Date
        Dim rcvdate2 As String = ""
        Try
            If dao.fields.rcvdate IsNot Nothing Then
                rcvdate1 = dao.fields.rcvdate
                rcvdate2 = CDate(rcvdate1).ToString("dd/MM/yyy")
            End If

        Catch ex As Exception

        End Try
        'class_xml.LCNNO_SHOW = lcnno_format
        'class_xml.SHOW_LCNNO = lcnno_text
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        ' If MAIN_LCN_IDA = 0 Then

        'class_xml.LCNNO_SHOW = NumEng2Thai(lcnno_format)  RCVNO_FORMAT
        'class_xml.LCNNO_SHOW_NEW = NumEng2Thai(lcnno_format_NEW)
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.RCVDATE_DISPLAY = rcvdate2
        class_xml.LCNNO_SHOW = lcnno_format
        class_xml.LCNNO_SHOW_NUMTHAI = NumEng2Thai(lcnno_format)
        class_xml.LCNNO_SHOW_NEW = lcnno_format_NEW
        class_xml.LCNNO_SHOW_NEW_NUMTHAI = NumEng2Thai(lcnno_format_NEW)
        class_xml.SHOW_LCNNO = lcnno_text
        class_xml.SHOW_LCNNO_NUMTHAI = NumEng2Thai(lcnno_text)

        Try

            class_xml.COUNT_PHESAJ1 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 1)
        Catch ex As Exception

        End Try

        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ2 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 2)
        Catch ex As Exception

        End Try
        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ3 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 3)
        Catch ex As Exception

        End Try
        'Else

        '    class_xml.LCNNO_SHOW = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(dao_main.fields.lcnno, 5))) & "/25" & Left(dao_main.fields.lcnno, 2)
        '    class_xml.SHOW_LCNNO = dao_main.fields.LCNNO_MANUAL
        'End If
        class_xml.CHK_VALUE = dao_PHR.fields.PHR_MEDICAL_TYPE

        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = NumEng2Thai(appdate.Day)
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = NumEng2Thai(con_year(appdate.Year))

                If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then

                    class_xml.RCVDAY_NUMTHAI_NEW = NumEng2Thai(appdate.Day.ToString())
                    class_xml.RCVMONTH_NUMTHAI_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NUMTHAI_NEW = NumEng2Thai(con_year(appdate.Year))

                    class_xml.RCVDAY_NEW = appdate.Day.ToString()
                    class_xml.RCVMONTH_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NEW = con_year(appdate.Year)


                End If


                class_xml.RCVDAY_NUMTHAI = NumEng2Thai(appdate.Day.ToString())
                class_xml.RCVMONTH_NUMTHAI = appdate.ToString("MMMM")
                class_xml.RCVYEAR_NUMTHAI = NumEng2Thai(con_year(appdate.Year))

                class_xml.RCVDAY = appdate.Day.ToString()
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                Dim expyear As Integer = 0
                    Try
                        expyear = dao.fields.expyear
                        If expyear <> 0 Then
                            If expyear < 2500 Then
                                expyear += 543
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    If expyear = 0 Then
                        expyear = con_year(appdate.Year)
                    End If
                    class_xml.EXP_YEAR = NumEng2Thai(expyear)
                End If
            Else
            If IsNothing(dao.fields.expyear) = False Then
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                class_xml.EXP_YEAR = NumEng2Thai(expyear)
            End If
        End If
        If IsNothing(dao.fields.expdate) = False Then
            Dim expdate As Date
            If Date.TryParse(dao.fields.expdate, expdate) = True Then
                class_xml.SHOW_EXPDATE_DAY = expdate.Day
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR = con_year(expdate.Year)

                class_xml.SHOW_EXPDATE_DAY_NUMTHAI = NumEng2Thai(expdate.Day)
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR_NUMTHAI = NumEng2Thai(con_year(expdate.Year))


                class_xml.EXPDAY = NumEng2Thai(expdate.Day.ToString())
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXPYEAR = NumEng2Thai(con_year(expdate.Year))
                'Try
                '    class_xml.EXP_YEAR = dao.fields.expyear 'con_year(appdate.Year)
                'Catch ex As Exception
                '    class_xml.EXP_YEAR = con_year(appdate.Year)
                'End Try
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(expdate.Year)
                End If
                class_xml.EXP_YEAR = NumEng2Thai(expyear)

            End If
        End If




        '-------------------เก่า------------------
        'For Each dao_PHR.fields In dao_PHR.datas
        '    Dim cls_DALCN_PHR As New DALCN_PHRi
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        For Each dao_PHR.fields In dao_PHR.Details
            Try
                If dao_PHR.fields.PHR_TEXT_WORK_TIME <> "" Then
                    dao_PHR.fields.PHR_TEXT_WORK_TIME = NumEng2Thai(dao_PHR.fields.PHR_TEXT_WORK_TIME)
                End If
            Catch ex As Exception

            End Try
            class_xml.DALCN_PHRs.Add(dao_PHR.fields)
        Next
        '-------------------------------------


        For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In dao_DALCN_DETAIL_LOCATION_KEEP.datas
            Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
            cls_DALCN_DETAIL_LOCATION_KEEP = dao_DALCN_DETAIL_LOCATION_KEEP.fields
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thafloor = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thafloor)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm)
            Catch ex As Exception

            End Try
            class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)



        Catch ex As Exception

        End Try
        class_xml.dalcns = dao.fields
        Try
            class_xml.dalcns.CATEGORY_DRUG = NumEng2Thai(class_xml.dalcns.CATEGORY_DRUG)
        Catch ex As Exception

        End Try
        Try
            class_xml.dalcns.opentime = NumEng2Thai(dao.fields.opentime)
        Catch ex As Exception

        End Try

        class_xml.syslctaddr_engaddr = dao.fields.syslctaddr_engaddr
        class_xml.syslctaddr_floor = dao.fields.syslctaddr_floor
        class_xml.syslctaddr_mu = dao.fields.syslctaddr_mu
        class_xml.syslctaddr_room = dao.fields.syslctaddr_room
        class_xml.syslctaddr_thaaddr = dao.fields.syslctaddr_thaaddr
        class_xml.syslctaddr_thasoi = dao.fields.syslctaddr_thasoi

        Try
            If dao.fields.lcntpcd = "ขสม" Then
                class_xml.LCN_TYPE = "ขาย"
                class_xml.LCN_TYPE_ID = "3"
            ElseIf dao.fields.lcntpcd = "ผสม" Then
                class_xml.LCN_TYPE = "ผลิต"
                class_xml.LCN_TYPE_ID = "1"
            ElseIf dao.fields.lcntpcd = "นสม" Then
                class_xml.LCN_TYPE = "นำเข้า"
                class_xml.LCN_TYPE_ID = "2"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dao_pph As New DAO_DRUG.ClsDBDALCN_PHR
            dao_pph.GetDataby_FK_IDA(_IDA)
            If dao_pph.fields.PHR_LAW_SECTION = "1" Then
                class_xml.MASTRA = "มาตรา 31"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๑"
                class_xml.MASTRA_NO = "31"
                class_xml.MASTRA_NO_NUMTHAI = "๓๑"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "2" Then
                class_xml.MASTRA = "มาตรา 32"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๒"
                class_xml.MASTRA_NO = "32"
                class_xml.MASTRA_NO_NUMTHAI = "๓๒"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "3" Then
                class_xml.MASTRA = "มาตรา 33"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๓"
                class_xml.MASTRA_NO = "33"
                class_xml.MASTRA_NO_NUMTHAI = "๓๓"
            End If
        Catch ex As Exception

        End Try

        ' p_dalcn2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_dalcn2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_dalcn2)

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = ""
        Try
            lcntype = dao.fields.lcntpcd
        Catch ex As Exception

        End Try

        'Dim url2 As String = "https://medicina.fda.moph.go.th/FDA_DRUG"
        'Dim Cls_qr As New QR_CODE.GEN_QR_CODE
        'Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2)


        lcntype = Chn_lcntpcd(lcntype)
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim template_id As Integer = 0
        If statusId = 8 Then
            Dim Group As Integer
            If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
                ElseIf template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 99)
                Else
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 0)
                End If
            ElseIf _group = 2 Or _group = 3 Then
                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            Else

                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
                ElseIf template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 99)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 0)
                End If

            End If
        Else

            Try
                template_id = dao.fields.TEMPLATE_ID
            Catch ex As Exception
                template_id = 0
            End Try
            'If template_id = 2 Then
            '    If statusId > 6 Then
            '        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
            '    Else
            '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
            '    End If
            'Else
            If _group = 1 Then
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
                ElseIf template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=99)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            ElseIf _group = 2 Then
                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            ElseIf _group = 3 Then
                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            Else

                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=99)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=0)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If



                'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
            End If

            'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
            'End If

        End If

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)


        'Try
        Dim url As String = ""
            ' If Request.QueryString("status") = 8 Or Request.QueryString("status") = 14 Then
            url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
        'Else
        '    url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF_VIEW.aspx?filename=" & filename
        'End If

        'Dim url As String 
        class_xml.QR_CODE = QR_CODE_IMG(url)
        'Catch ex As Exception

        'End Try


        p_dalcn = class_xml


        'Dim p_dalcn2 As New XML_CENTER.CLASS_DALCN
        'p_dalcn2 = p_dalcn

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
        'load_pdf(filename)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        'hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
        _CLS.FILENAME_PDF = NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim _group As Integer = 0
        If HiddenField2.Value = 0 Then
            HiddenField2.Value = 1
            _group = 1
        ElseIf HiddenField2.Value = 1 Then
            HiddenField2.Value = 0
            _group = 0
        End If
        'Dim template_id As Integer = 0
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        'Dim _group As Integer = 0
        'Try
        '    template_id = dao.fields.TEMPLATE_ID
        'Catch ex As Exception

        'End Try
        'If template_id = 2 Then
        '    _group = 9
        'End If

        '_group:=_group
        show01.Visible = True
        BindData_PDF(_group:=_group)

    End Sub


    Private Sub btn_drug_group_Click(sender As Object, e As EventArgs) Handles btn_drug_group.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx?ida=" & Request.QueryString("ida") & "'); ", True)
    End Sub

    Private Sub ddl_template_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_template.SelectedIndexChanged
        update_template(_IDA)
        BindData_PDF()
    End Sub
    Sub update_template(ByVal ida As String)
        If ddl_template.SelectedValue <> "0" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(ida)
            dao.fields.TEMPLATE_ID = ddl_template.SelectedValue
            dao.update()
        End If

    End Sub
    Private Sub load_pdf(ByVal FilePath As String)


        ''  Response.ContentType = "Application/pdf"

        'Dim clsds As New ClassDataset

        'Dim bb As Byte() = clsds.UpLoadImageByte(FilePath)

        'Dim ws_F As New WS_FLATTEN.WS_FLATTEN

        'Dim b_o As Byte() = ws_F.FlattenPDF_DIGITAL(bb)

        'Response.ContentType = "application/pdf"
        'Response.AddHeader("content-length", b_o.Length.ToString())
        'Response.BinaryWrite(b_o)



        ''Response.Clear()
        ''Response.ContentType = "application/pdf"
        ''Response.AddHeader("Content-Disposition", "attachment;filename=abc.pdf")

        ''Response.BinaryWrite(clsds.UpLoadImageByte(FilePath))

        ''Response.Flush()

        'Response.End()


        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.FILENAME_PDF)
        Response.BinaryWrite(clsds.UpLoadImageByte(FilePath)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()


    End Sub


    Public Function UpLoadImageByte(ByVal info As String) As Byte()
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        Try
            imgBin = reader.ReadBytes(stream.Length)
        Catch ex As Exception
        Finally
            stream.Close()
            reader.Close()
        End Try
        Return imgBin
    End Function

    Protected Sub btn_sormorpo1_Click(sender As Object, e As EventArgs) Handles btn_sormorpo1.Click
        Dim _group As Integer = 0
        If HiddenField2.Value = 0 Then
            HiddenField2.Value = 1
            _group = 2
        ElseIf HiddenField2.Value = 1 Then
            HiddenField2.Value = 0
            _group = 3
        End If

        'BindData_PDF(_group:=1)
        BindData_PDF_SOMORPO1(_group:=0)
    End Sub
    Private Sub BindData_PDF_SOMORPO1(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim lcnno_format_NEW As String = ""
        Dim pvncd As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_PHR2 As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)

        Dim ProcessID As String = ""
        Try
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        If PROCESS_ID = "" Then
            PROCESS_ID = dao.fields.PROCESS_ID
        End If
        Try
            pvncd = dao.fields.pvncd
        Catch ex As Exception

        End Try
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntpcd = Chn_lcntpcd(lcntpcd)
        Dim lcnsid_da As Integer = 0
        Try
            lcnsid_da = dao.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, lcnsid_da, lcnno:=lcnno_auto, lcntpcd:=lcntpcd, pvncd:=pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        Dim bao_show As New BAO_SHOW

        'class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA(_IDA)
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao.fields.FK_IDA) ' 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)

        class_xml.DT_SHOW.DT10 = bao_show.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(_IDA)

        Dim tt As Integer = 0
        If dao.fields.lcntpcd.Contains("ผ") Then
            tt = 1
            'ElseIf dao.fields.lcntpcd.Contains("น") Then
            '   tt = 2
        Else
            tt = 3
        End If
        If tt = 1 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, 1)

        ElseIf tt = 2 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB_V3(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, 1)
        ElseIf tt = 3 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB2(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, 1)

        End If

        Dim DDL_DRUG_SMP_31 As String = ""
        Dim DDL_DRUG_SMP_32 As String = ""
        Dim DDL_DRUG_SMP_33 As String = ""
        Dim DDL_DRUG_SMP_34 As String = ""
        Dim DDL_DRUG_SMP_35 As String = ""
        Dim DDL_DRUG_SMP_36 As String = ""
        Dim DDL_DRUG_SMP_37 As String = ""
        Dim DDL_DRUG_SMP_38 As String = ""
        Dim DDL_DRUG_SMP_39 As String = ""
        Dim DDL_DRUG_SMP_310 As String = ""
        Dim DDL_DRUG_SMP_311 As String = ""
        Dim DDL_DRUG_SMP_312 As String = ""

        class_xml.DT_SHOW.DT23 = bao_show.SP_DRUG_GROUP_HERB_NO3(_IDA)
        For Each drr As DataRow In class_xml.DT_SHOW.DT23.Rows
            Try
                If drr("FK_IDA") = 27 Then
                    DDL_DRUG_SMP_31 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 28 Then
                    DDL_DRUG_SMP_32 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 29 Then
                    DDL_DRUG_SMP_33 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 30 Then
                    DDL_DRUG_SMP_34 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 31 Then
                    DDL_DRUG_SMP_35 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 32 Then
                    DDL_DRUG_SMP_36 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 33 Then
                    DDL_DRUG_SMP_37 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 34 Then
                    DDL_DRUG_SMP_38 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 35 Then
                    DDL_DRUG_SMP_39 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 36 Then
                    DDL_DRUG_SMP_310 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 37 Then
                    DDL_DRUG_SMP_311 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 38 Then
                    DDL_DRUG_SMP_312 = drr("GROUP_NAME")
                End If

            Catch ex As Exception

            End Try
        Next
        class_xml.DT_SHOW.DT22 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1_V2(_IDA)

        Dim chk_smp1 As String = "0"
        Dim chk_smp1_1 As String = "0"
        Dim chk_smp1_2 As String = "0"
        Dim chk_smp1_3 As String = "0"
        Dim chk_smp1_4 As String = "0"
        Dim chk_smp1_5 As String = "0"
        Dim chk_smp1_6 As String = "0"
        Dim chk_smp1_7 As String = "0"
        Dim chk_smp1_8 As String = "0"
        Dim chk_smp1_9 As String = "0"
        Dim chk_smp1_10 As String = ""
        Dim chk_smp1_11 As String = ""
        Dim chk_smp2 As String = "0"
        Dim chk_smp2_1 As String = "0"
        Dim chk_smp2_2 As String = "0"
        Dim chk_smp2_3 As String = "0"
        Dim chk_smp2_4 As String = "0"
        Dim chk_smp2_5 As String = "0"
        Dim chk_smp2_6 As String = "0"
        Dim chk_smp2_7 As String = "0"
        Dim chk_smp2_8 As String = "0"
        Dim chk_smp2_9 As String = "0"
        Dim chk_smp2_10 As String = "0"
        Dim chk_smp2_11 As String = ""
        Dim chk_smp2_12 As String = ""
        Dim chk_smp3 As String = "0"
        Dim chk_smp3_1 As String = "0"
        Dim chk_smp3_2 As String = "0"
        Dim chk_smp3_3 As String = "0"
        Dim chk_smp3_4 As String = "0"
        Dim chk_smp3_5 As String = "0"
        Dim chk_smp3_6 As String = "0"
        Dim chk_smp3_7 As String = "0"
        Dim chk_smp3_8 As String = "0"
        Dim chk_smp3_9 As String = "0"
        Dim chk_smp3_10 As String = "0"
        Dim chk_smp3_11 As String = ""
        Dim chk_smp3_12 As String = ""
        Dim chk_smp4 As String = "0"
        Dim chk_smp4_1 As String = "0"
        Dim chk_smp4_1_1 As String = ""
        Dim chk_smp4_1_2 As String = ""
        Dim chk_smp4_2 As String = "0"
        Dim chk_smp4_3 As String = ""
        Dim CHK_SMP1_MAIN_1 As String = "0"
        Dim CHK_SMP1_MAIN_2 As String = "0"
        Dim CHK_SMP1_MAIN_3 As String = "0"
        Dim CHK_SMP1_MAIN_4 As String = "0"

        For Each drr As DataRow In class_xml.DT_SHOW.DT22.Rows
            Try
                If dao.fields.PROCESS_ID = 122 Then
                    If drr("HEAD_NO") = 1 Then
                        chk_smp1 = 1
                    End If
                    If drr("HEAD_NO") = 2 Then
                        chk_smp1_1 = 1
                    End If
                    If drr("HEAD_NO") = 3 Then
                        chk_smp1_2 = 1
                    End If
                    If drr("HEAD_NO") = 4 Then
                        chk_smp1_3 = 1
                    End If
                    If drr("HEAD_NO") = 5 Then
                        chk_smp1_4 = 1
                    End If
                    If drr("HEAD_NO") = 6 Then
                        chk_smp1_5 = 1
                    End If
                    If drr("HEAD_NO") = 7 Then
                        chk_smp1_6 = 1
                    End If
                    If drr("HEAD_NO") = 8 Then
                        chk_smp1_7 = 1
                    End If
                    If drr("HEAD_NO") = 9 Then
                        chk_smp1_8 = 1
                    End If
                    If drr("HEAD_NO") = 10 Then
                        chk_smp1_9 = 1
                    End If
                    If drr("HEAD_NO") = 11 Then
                        chk_smp1_10 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 12 Then
                        chk_smp1_11 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 13 Then
                        chk_smp2 = 1
                    End If
                    If drr("HEAD_NO") = 14 Then
                        chk_smp2_1 = 1
                    End If
                    If drr("HEAD_NO") = 15 Then
                        chk_smp2_2 = 1
                    End If
                    If drr("HEAD_NO") = 16 Then
                        chk_smp2_3 = 1
                    End If
                    If drr("HEAD_NO") = 17 Then
                        chk_smp2_4 = 1
                    End If
                    If drr("HEAD_NO") = 18 Then
                        chk_smp2_5 = 1
                    End If
                    If drr("HEAD_NO") = 19 Then
                        chk_smp2_6 = 1
                    End If
                    If drr("HEAD_NO") = 20 Then
                        chk_smp2_7 = 1
                    End If
                    If drr("HEAD_NO") = 21 Then
                        chk_smp2_8 = 1
                    End If
                    If drr("HEAD_NO") = 22 Then
                        chk_smp2_9 = 1
                    End If
                    If drr("HEAD_NO") = 23 Then
                        chk_smp2_10 = 1
                    End If
                    If drr("HEAD_NO") = 24 Then
                        chk_smp2_11 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 25 Then
                        chk_smp2_12 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 26 Then
                        chk_smp3 = 1
                    End If
                    If drr("HEAD_NO") = 27 Then
                        chk_smp3_1 = 1
                    End If
                    If drr("HEAD_NO") = 28 Then
                        chk_smp3_2 = 1
                    End If
                    If drr("HEAD_NO") = 29 Then
                        chk_smp3_3 = 1
                    End If
                    If drr("HEAD_NO") = 30 Then
                        chk_smp3_4 = 1
                    End If
                    If drr("HEAD_NO") = 31 Then
                        chk_smp3_5 = 1
                    End If
                    If drr("HEAD_NO") = 32 Then
                        chk_smp3_6 = 1
                    End If
                    If drr("HEAD_NO") = 33 Then
                        chk_smp3_7 = 1
                    End If
                    If drr("HEAD_NO") = 34 Then
                        chk_smp3_8 = 1
                    End If
                    If drr("HEAD_NO") = 35 Then
                        chk_smp3_9 = 1
                    End If
                    If drr("HEAD_NO") = 36 Then
                        chk_smp3_10 = 1
                    End If
                    If drr("HEAD_NO") = 37 Then
                        chk_smp3_11 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 38 Then
                        chk_smp3_12 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 39 Then
                        chk_smp4 = 1
                    End If
                    If drr("HEAD_NO") = 40 Then
                        chk_smp4_1 = 1
                    End If
                    If drr("HEAD_NO") = 41 Then
                        chk_smp4_1_1 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 42 Then
                        chk_smp4_1_2 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 43 Then
                        chk_smp4_2 = 1
                    End If
                    If drr("HEAD_NO") = 44 Then
                        chk_smp4_3 = drr("COL_ID1")
                    End If
                ElseIf dao.fields.PROCESS_ID = 121 Then
                    If drr("HEAD_NO") = 1 Then
                        chk_smp1 = 1
                    End If
                    If drr("HEAD_NO") = 13 Then
                        chk_smp2 = 1
                    End If
                    If drr("HEAD_NO") = 26 Then
                        chk_smp3 = 1
                    End If
                    If drr("HEAD_NO") = 39 Then
                        chk_smp4 = 1
                    End If
                ElseIf dao.fields.PROCESS_ID = 120 Then
                    If drr("HEAD_NO") = 1 Then
                        CHK_SMP1_MAIN_1 = 1
                    End If
                    If drr("HEAD_NO") = 13 Then
                        CHK_SMP1_MAIN_2 = 1
                    End If
                    If drr("HEAD_NO") = 26 Then
                        CHK_SMP1_MAIN_3 = 1
                    End If
                    If drr("HEAD_NO") = 39 Then
                        CHK_SMP1_MAIN_4 = 1
                    End If
                End If


            Catch ex As Exception

            End Try
        Next

        Dim dt9 As New DataTable

        'dt9 = class_xml.DT_SHOW.DT9
        For Each drr As DataRow In class_xml.DT_SHOW.DT9.Rows
            Try
                drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
            Catch ex As Exception

            End Try
            Try
                '
                Try
                    drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                drr("tharoom") = NumEng2Thai(drr("tharoom"))
            Catch ex As Exception

            End Try
            Try
                drr("thanameplace") = NumEng2Thai(drr("thanameplace"))
            Catch ex As Exception

            End Try
            Try
                drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
            Catch ex As Exception

            End Try
            Try
                drr("tel1") = NumEng2Thai(drr("tel1"))
            Catch ex As Exception

            End Try
            '
            '
            Try
                drr("thamu") = NumEng2Thai(drr("thamu"))
            Catch ex As Exception

            End Try
            Try
                drr("thafloor") = NumEng2Thai(drr("thafloor"))
            Catch ex As Exception

            End Try
            Try
                drr("thasoi") = NumEng2Thai(drr("thasoi"))
            Catch ex As Exception

            End Try
            Try
                drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
            Catch ex As Exception

            End Try
            Try
                drr("tharoad") = NumEng2Thai(drr("tharoad"))
            Catch ex As Exception

            End Try
            Try
                drr("zipcode") = NumEng2Thai(drr("zipcode"))
            Catch ex As Exception

            End Try
            Try
                drr("tel") = NumEng2Thai(drr("tel"))
            Catch ex As Exception

            End Try
            Try
                drr("fax") = NumEng2Thai(drr("fax"))
            Catch ex As Exception

            End Try
            Try
                drr("Mobile") = NumEng2Thai(drr("Mobile"))
            Catch ex As Exception

            End Try
            Try
                drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
            Catch ex As Exception

            End Try

        Next

        Try
            Dim dao_phr_c As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr_c.GetDataby_FK_IDA(_IDA)
            Dim c_phr As Integer = 0
            For Each dao_phr_c.fields In dao_phr_c.datas
                c_phr += 1
            Next
            class_xml.PHR_COUNT = c_phr
        Catch ex As Exception

        End Try

        Try
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        Catch ex As Exception

        End Try

        Try
            class_xml.DT_MASTER.DT38 = bao_show.SP_Lisense_Name_and_Addr(_iden) 'ผู้ขออนุญาติ
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ



        Dim BSN_IDENTIFY As String = ""
        Try
            BSN_IDENTIFY = NumEng2Thai(dao.fields.BSN_IDENTIFY)
        Catch ex As Exception

        End Try
        Dim MAIN_LCN_IDA As Integer = 0

        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

        class_xml.DT_SHOW.DT15 = bao_show.SP_DALCN_CURRENT_ADDRESS(_IDA)
        'End If
        Dim dt14 As New DataTable
        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(_IDA)
        Try
            If dao_frgn.fields.addr_status = 0 Or dao_frgn.fields.addr_status = 1 Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_DALCN_CURRENT_ADDRESS(_IDA)
            ElseIf dao_frgn.fields.addr_status = Nothing Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
            End If

        Catch ex As Exception

        End Try

        Try
            dt14 = class_xml.DT_SHOW.DT14
            For Each drr As DataRow In dt14.Rows
                drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA) 'ผู้มีหน้าที่ปฎิบัติการ

        class_xml.DT_SHOW.DT35 = bao_master.SP_DALCN_FRGN_DATA(_IDA)


        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        Dim DT25 As New DataTable
        Try
            DT25 = class_xml.DT_MASTER.DT25
            For Each drr As DataRow In DT25.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try

        class_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(dao.fields.IDA)
        Dim DT31 As New DataTable

        DT31 = class_xml.DT_MASTER.DT31
        For Each drr As DataRow In DT31.Rows
            Try
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Catch ex As Exception

            End Try

        Next


        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try

        Try
            If dao.fields.REVOCATION Is Nothing Or Trim(dao.fields.REVOCATION) = "" Then
                If Len(lcnno_auto) > 0 Then

                    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                        lcnno_format = dao.fields.pvnabbr & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                    'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)

                End If

                lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW

            Else

                Dim _type_da As String = ""
                If dao.fields.PROCESS_ID = "120" Then
                    _type_da = "3"
                ElseIf dao.fields.PROCESS_ID = "121" Then
                    _type_da = "2"
                ElseIf dao.fields.PROCESS_ID = "122" Then
                    _type_da = "1"
                End If

                If Not dao.fields.LCNNO_DISPLAY_NEW Is Nothing Then
                    lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    'Try
                    '    Dim App_Date As Date = dao.fields.appdate
                    '    If App_Date > #10/1/2019 12:00:00 AM# Then
                    '        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    '    Else
                    '        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then
                        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    End If
                    'lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                Else
                    lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                End If

            End If

        Catch ex As Exception

        End Try
        Try
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

            Try
                'lcnno_format = 
                'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
                    class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                Else
                    class_xml.HEAD_LCNNO = dao_main2.fields.pvnabbr & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                End If

                class_xml.HEAD_LCNNO = NumEng2Thai(class_xml.HEAD_LCNNO)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
        Dim rcvno_format As String = ""
        Dim RCV_DATE As String = ""
        Try
            rcvno_format = dao.fields.RCVNO_NEW
        Catch ex As Exception

        End Try

        Dim rcvdate1 As Date
        Dim rcvdate2 As String = ""
        Try
            If dao.fields.rcvdate IsNot Nothing Then
                rcvdate1 = dao.fields.rcvdate
                rcvdate2 = CDate(rcvdate1).ToString("dd/MM/yyy")
            End If

        Catch ex As Exception

        End Try


        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        Dim op_time As String = ""
        op_time = dao.fields.opentime

        class_xml.LCNNO_SHOW = lcnno_format
        class_xml.LCNNO_SHOW_NUMTHAI = NumEng2Thai(lcnno_format)
        class_xml.LCNNO_SHOW_NEW = lcnno_format_NEW
        class_xml.LCNNO_SHOW_NEW_NUMTHAI = NumEng2Thai(lcnno_format_NEW)
        class_xml.SHOW_LCNNO = lcnno_text
        class_xml.SHOW_LCNNO_NUMTHAI = NumEng2Thai(lcnno_text)
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.RCVDATE_DISPLAY = rcvdate2
        class_xml.OPEN_TIME = op_time
        class_xml.chk_smp1 = chk_smp1
        class_xml.chk_smp1_1 = chk_smp1_1
        class_xml.chk_smp1_2 = chk_smp1_2
        class_xml.chk_smp1_3 = chk_smp1_3
        class_xml.chk_smp1_4 = chk_smp1_4
        class_xml.chk_smp1_5 = chk_smp1_5
        class_xml.chk_smp1_6 = chk_smp1_6
        class_xml.chk_smp1_7 = chk_smp1_7
        class_xml.chk_smp1_8 = chk_smp1_8
        class_xml.chk_smp1_9 = chk_smp1_9
        class_xml.chk_smp1_10 = chk_smp1_10
        class_xml.chk_smp1_11 = chk_smp1_11
        class_xml.chk_smp2 = chk_smp2
        class_xml.chk_smp2_1 = chk_smp2_1
        class_xml.chk_smp2_2 = chk_smp2_2
        class_xml.chk_smp2_3 = chk_smp2_3
        class_xml.chk_smp2_4 = chk_smp2_4
        class_xml.chk_smp2_5 = chk_smp2_5
        class_xml.chk_smp2_6 = chk_smp2_6
        class_xml.chk_smp2_7 = chk_smp2_7
        class_xml.chk_smp2_8 = chk_smp2_8
        class_xml.chk_smp2_9 = chk_smp2_9
        class_xml.chk_smp2_10 = chk_smp2_10
        class_xml.chk_smp2_11 = chk_smp2_11
        class_xml.chk_smp2_12 = chk_smp2_12
        class_xml.chk_smp3 = chk_smp3
        class_xml.chk_smp3_1 = chk_smp3_1
        class_xml.chk_smp3_2 = chk_smp3_2
        class_xml.chk_smp3_3 = chk_smp3_3
        class_xml.chk_smp3_4 = chk_smp3_4
        class_xml.chk_smp3_5 = chk_smp3_8
        class_xml.chk_smp3_6 = chk_smp3_6
        class_xml.chk_smp3_7 = chk_smp3_7
        class_xml.chk_smp3_8 = chk_smp3_8
        class_xml.chk_smp3_9 = chk_smp3_9
        class_xml.chk_smp3_10 = chk_smp3_10
        class_xml.chk_smp3_11 = chk_smp3_11
        class_xml.chk_smp3_12 = chk_smp3_12
        class_xml.chk_smp4 = chk_smp4
        class_xml.chk_smp4_1 = chk_smp4_1
        class_xml.chk_smp4_1_1 = chk_smp4_1_1
        class_xml.chk_smp4_1_2 = chk_smp4_1_2
        class_xml.chk_smp4_2 = chk_smp4_2
        class_xml.chk_smp4_3 = chk_smp4_3

        class_xml.CHK_SMP1_SELL_1 = CHK_SMP1_MAIN_1
        class_xml.CHK_SMP1_SELL_2 = CHK_SMP1_MAIN_2
        class_xml.CHK_SMP1_SELL_3 = CHK_SMP1_MAIN_3
        class_xml.CHK_SMP1_SELL_4 = CHK_SMP1_MAIN_4

        class_xml.DDL_MENU_DRUG_GROUP_3_1 = DDL_DRUG_SMP_31
        class_xml.DDL_MENU_DRUG_GROUP_3_2 = DDL_DRUG_SMP_32
        class_xml.DDL_MENU_DRUG_GROUP_3_3 = DDL_DRUG_SMP_33
        class_xml.DDL_MENU_DRUG_GROUP_3_4 = DDL_DRUG_SMP_34
        class_xml.DDL_MENU_DRUG_GROUP_3_5 = DDL_DRUG_SMP_35
        class_xml.DDL_MENU_DRUG_GROUP_3_6 = DDL_DRUG_SMP_36
        class_xml.DDL_MENU_DRUG_GROUP_3_7 = DDL_DRUG_SMP_37
        class_xml.DDL_MENU_DRUG_GROUP_3_8 = DDL_DRUG_SMP_38
        class_xml.DDL_MENU_DRUG_GROUP_3_9 = DDL_DRUG_SMP_39
        class_xml.DDL_MENU_DRUG_GROUP_3_10 = DDL_DRUG_SMP_310
        class_xml.DDL_MENU_DRUG_GROUP_3_11 = DDL_DRUG_SMP_311
        class_xml.DDL_MENU_DRUG_GROUP_3_12 = DDL_DRUG_SMP_312


        class_xml.PROCESS_ID = PROCESS_ID

        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = NumEng2Thai(appdate.Day)
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = NumEng2Thai(con_year(appdate.Year))

                If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then

                    class_xml.RCVDAY_NUMTHAI_NEW = NumEng2Thai(appdate.Day.ToString())
                    class_xml.RCVMONTH_NUMTHAI_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NUMTHAI_NEW = NumEng2Thai(con_year(appdate.Year))

                    class_xml.RCVDAY_NEW = appdate.Day.ToString()
                    class_xml.RCVMONTH_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NEW = con_year(appdate.Year)


                End If


                class_xml.RCVDAY_NUMTHAI = NumEng2Thai(appdate.Day.ToString())
                class_xml.RCVMONTH_NUMTHAI = appdate.ToString("MMMM")
                class_xml.RCVYEAR_NUMTHAI = NumEng2Thai(con_year(appdate.Year))

                class_xml.RCVDAY = appdate.Day.ToString()
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(appdate.Year)
                End If
                class_xml.EXP_YEAR = NumEng2Thai(expyear)
            End If
        Else
            If IsNothing(dao.fields.expyear) = False Then
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                class_xml.EXP_YEAR = NumEng2Thai(expyear)
            End If
        End If
        If IsNothing(dao.fields.expdate) = False Then
            Dim expdate As Date
            If Date.TryParse(dao.fields.expdate, expdate) = True Then
                class_xml.SHOW_EXPDATE_DAY = expdate.Day
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR = con_year(expdate.Year)

                class_xml.SHOW_EXPDATE_DAY_NUMTHAI = NumEng2Thai(expdate.Day)
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR_NUMTHAI = NumEng2Thai(con_year(expdate.Year))


                class_xml.EXPDAY = NumEng2Thai(expdate.Day.ToString())
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXPYEAR = NumEng2Thai(con_year(expdate.Year))
                'Try
                '    class_xml.EXP_YEAR = dao.fields.expyear 'con_year(appdate.Year)
                'Catch ex As Exception
                '    class_xml.EXP_YEAR = con_year(appdate.Year)
                'End Try
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(expdate.Year)
                End If
                class_xml.EXP_YEAR = NumEng2Thai(expyear)

            End If
        End If




        '-------------------เก่า------------------
        'For Each dao_PHR.fields In dao_PHR.datas
        '    Dim cls_DALCN_PHR As New DALCN_PHRi
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        For Each dao_PHR.fields In dao_PHR.Details
            Try
                If dao_PHR.fields.PHR_TEXT_WORK_TIME <> "" Then
                    dao_PHR.fields.PHR_TEXT_WORK_TIME = NumEng2Thai(dao_PHR.fields.PHR_TEXT_WORK_TIME)
                End If
            Catch ex As Exception

            End Try
            class_xml.DALCN_PHRs.Add(dao_PHR.fields)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)



        Catch ex As Exception

        End Try
        class_xml.dalcns = dao.fields
        Try
            class_xml.dalcns.CATEGORY_DRUG = NumEng2Thai(class_xml.dalcns.CATEGORY_DRUG)
        Catch ex As Exception

        End Try
        Try
            class_xml.dalcns.opentime = NumEng2Thai(dao.fields.opentime)
        Catch ex As Exception

        End Try

        class_xml.syslctaddr_engaddr = dao.fields.syslctaddr_engaddr
        class_xml.syslctaddr_floor = dao.fields.syslctaddr_floor
        class_xml.syslctaddr_mu = dao.fields.syslctaddr_mu
        class_xml.syslctaddr_room = dao.fields.syslctaddr_room
        class_xml.syslctaddr_thaaddr = dao.fields.syslctaddr_thaaddr
        class_xml.syslctaddr_thasoi = dao.fields.syslctaddr_thasoi

        Try
            If dao.fields.lcntpcd = "ขสม" Then
                class_xml.LCN_TYPE = "ขาย"
                class_xml.LCN_TYPE_ID = "3"
            ElseIf dao.fields.lcntpcd = "ผสม" Then
                class_xml.LCN_TYPE = "ผลิต"
                class_xml.LCN_TYPE_ID = "1"
            ElseIf dao.fields.lcntpcd = "นสม" Then
                class_xml.LCN_TYPE = "นำเข้า"
                class_xml.LCN_TYPE_ID = "2"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dao_pph As New DAO_DRUG.ClsDBDALCN_PHR
            dao_pph.GetDataby_FK_IDA(_IDA)
            If dao_pph.fields.PHR_LAW_SECTION = "1" Then
                class_xml.MASTRA = "มาตรา 31"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๑"
                class_xml.MASTRA_NO = "31"
                class_xml.MASTRA_NO_NUMTHAI = "๓๑"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "2" Then
                class_xml.MASTRA = "มาตรา 32"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๒"
                class_xml.MASTRA_NO = "32"
                class_xml.MASTRA_NO_NUMTHAI = "๓๒"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "3" Then
                class_xml.MASTRA = "มาตรา 33"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๓"
                class_xml.MASTRA_NO = "33"
                class_xml.MASTRA_NO_NUMTHAI = "๓๓"
            End If
        Catch ex As Exception

        End Try

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = ""
        Try
            lcntype = dao.fields.lcntpcd
        Catch ex As Exception

        End Try

        lcntype = Chn_lcntpcd(lcntype)
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim template_id As Integer = 0
        If statusId = 8 Then
            Dim Group As Integer
            If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                ElseIf template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 1, 7)
                Else
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 1, 7)
                End If
            ElseIf _group = 2 Or _group = 3 Then
                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            Else

                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                ElseIf template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 1, 7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 1, 7)
                End If

            End If
        Else

            Try
                template_id = dao.fields.TEMPLATE_ID
            Catch ex As Exception
                template_id = 0
            End Try

            If _group = 1 Then
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                ElseIf template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            ElseIf _group = 2 Then
                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            ElseIf _group = 3 Then
                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            Else

                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=99)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If



                'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
            End If

        End If

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)


        Dim url As String = ""
        url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
        class_xml.QR_CODE = QR_CODE_IMG(url)


        p_dalcn = class_xml

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
        _CLS.FILENAME_PDF = NAME_PDF2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
    End Sub

    Protected Sub btn_up_Click(sender As Object, e As EventArgs) Handles btn_up.Click
        Response.Redirect("FRM_LCN_UPLOAD_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&Process=" & _ProcessID & "&lct_ida=" & _lct_ida & "&identify=" & _iden)
    End Sub

    Protected Sub ddl_cnsdcd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_cnsdcd.SelectedIndexChanged
        If ddl_cnsdcd.SelectedValue = 8 Or ddl_cnsdcd.SelectedValue = 6 Or ddl_cnsdcd.SelectedValue = 5 Then
            '    Div1.Visible = True
            'Else
            '    Div1.Visible = False
        End If
    End Sub
End Class