Imports System.Globalization
Imports Telerik.Web.UI
Public Class FRM_TABEAN_SUBSTITUTE_STAFF_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _IDA_G As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private _newcode As String

    Sub RunQuery()
        _YEARS = con_year(Date.Now.Year)
        Try
            _ProcessID = Request.QueryString("Process")

        Catch ex As Exception

        End Try
        Try
            _IDA_G = Request.QueryString("rgt_ida")
        Catch ex As Exception

        End Try
        Try
            _IDA = Request.QueryString("IDA")

        Catch ex As Exception

        End Try
        Try
            _newcode = Request.QueryString("newcode")
        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")

        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
            dao_sub.GetDatabyIDA(_IDA)
            txt_appdate.Text = Date.Now.ToShortDateString()
            Bind_ddl()
            show_btn(_IDA)
            'If dao_sub.fields.STATUS_ID = 8 Then
            '    BindData_PDF()
            'Else
            Run_Pdf_Tabean_Herb()
            'End If
            Try
                ddl_template.DropDownSelectData(dao_sub.fields.TEMPLATE_ID)
            Catch ex As Exception

            End Try
            UC_GRID_ATTACH.load_gv(_TR_ID)
            Bind_ddl_Status_staff()
            bind_mas_staff()
        End If
    End Sub
    Sub show_btn(ByVal ID As String)

        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(_IDA)
        If dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 7 Then
            btn_confirm.Enabled = False
            'btn_cancel.Enabled = False

            btn_confirm.CssClass = "btn-danger btn-lg"
            'btn_cancel.CssClass = "btn-danger btn-lg"     
        End If
        If dao.fields.STATUS_ID = 6 Then
            BTN_KEEP_PAY.Visible = True
        Else
            BTN_KEEP_PAY.Visible = False
        End If
        If dao.fields.STATUS_ID >= 3 Then
            'Panel1.Style.Add("display", "block")
        Else
            btn_preview.Enabled = False
            btn_preview.CssClass = "btn-danger btn-lg"
        End If

    End Sub
    Private Sub ddl_template_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_template.SelectedIndexChanged
        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao_sub.GetDatabyIDA(Request.QueryString("IDA"))
        dao_sub.fields.TEMPLATE_ID = ddl_template.SelectedValue
        dao_sub.update()
        Try
            If ddl_template.SelectedValue = 0 Then
                Run_Pdf_Tabean_Herb()
            Else
                BindData_PDF()
                'BindData_PDF_SAI(Request.QueryString("newcode"))
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Sub Bind_ddl()
        Dim dao As New DAO_DRUG.TB_MAS_SUBSTITUTE_TEMPLATE
        dao.GetDataAll()
        ddl_template.DataSource = dao.datas
        ddl_template.DataBind()

        Dim item As New ListItem
        item.Text = "---เลือกแบบ pdf---"
        item.Value = "0"
        ddl_template.Items.Insert(0, item)
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl1 As Integer = 0
        Dim int_group_ddl2 As Integer = 0
        Dim status_id1 As Integer = 0
        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        Try
            dao_sub.GetDatabyIDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        Try
            status_id1 = dao_sub.fields.STATUS_ID
        Catch ex As Exception

        End Try

        'If status_id1 = 2 Then
        '    int_group_ddl1 = 1
        '    int_group_ddl2 = 0
        'ElseIf status_id1 = 4 Then
        '    int_group_ddl1 = 2
        '    int_group_ddl2 = 0
        'ElseIf status_id1 = 5 Then
        '    int_group_ddl1 = 3
        '    int_group_ddl2 = 0
        'End If
        If status_id1 = 2 Then
            int_group_ddl1 = 1
            int_group_ddl2 = 0
        ElseIf status_id1 = 3 Then
            int_group_ddl1 = 2
            int_group_ddl2 = 0
        ElseIf status_id1 = 4 Then
            int_group_ddl1 = 3
            int_group_ddl2 = 0
        End If

        dt = Get_DDL_DATA(12, int_group_ddl1, int_group_ddl2)

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME_STAFF"
        ddl_cnsdcd.DataBind()
    End Sub
    Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
        'Dim dt As New DataTable
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
        Dim dta As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dta = bao.Queryds(sql)
        Return dta
    End Function
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""
        Dim Old_process As String = "1400001"
        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim lcnsid As String = ""
        Dim regis_ida As Integer = 0
        Dim lcntpcd As String = ""
        Dim rcvno As String = ""
        Dim lcnno As String = ""
        Dim rgtno As String = ""
        Dim pvnabbr As String = ""
        Dim thadrgnm As String = ""
        Dim engdrgnm As String = ""
        Dim appdate As Date
        Dim STATUS_ID As Integer = 0
        Dim dsgcd As String = ""
        Dim FK_LCN_IDA As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim Chanid_ya As String = ""
        Dim class_xml As New CLASS_DR
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_IDA_G)
        lcnsid = dao.fields.lcnsid
        Dim dao2 As New DAO_DRUG.ClsDBdrrqt
        Try
            dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
        Catch ex As Exception

        End Try
        Try
            dsgcd = dao.fields.dsgcd

        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            Dim dao_dose As New DAO_DRUG.TB_drdosage
            dao_dose.GetDataby_cd(dao.fields.dsgcd)
            If dao_dose.fields.thadsgnm <> "-" Then
                If dao_dose.fields.engdsgnm <> "-" Then
                    Chanid_ya = dao_dose.fields.thadsgnm & "/" & dao_dose.fields.engdsgnm
                Else
                    Chanid_ya = dao_dose.fields.thadsgnm
                End If
            ElseIf dao_dose.fields.engdsgnm <> "-" Then
                Chanid_ya = dao_dose.fields.engdsgnm
            End If
            'Chanid_ya = dao_dose.fields.engdsgnm
        Catch ex As Exception

        End Try

        class_xml.CHANID_YA = Chanid_ya
        Try
            'dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
            regis_ida = dao.fields.FK_IDA
        Catch ex As Exception

        End Try
        Try
            pvncd = dao.fields.pvncd
        Catch ex As Exception
            pvncd = ""
        End Try
        DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
        Try
            rgttpcd = dao.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = dao2.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno = dao.fields.rgtno
        Catch ex As Exception

        End Try

        Try
            thadrgnm = dao.fields.thadrgnm
        Catch ex As Exception

        End Try
        Try
            engdrgnm = dao.fields.engdrgnm
        Catch ex As Exception

        End Try
        Try
            appdate = dao.fields.appdate
        Catch ex As Exception

        End Try
        Try
            STATUS_ID = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try
        Try
            FK_LCN_IDA = dao.fields.FK_LCN_IDA
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
        Catch ex As Exception

        End Try
        Try
            TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
        Catch ex As Exception

        End Try
        Try
            TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
        Catch ex As Exception

        End Try
        Try
            drug_name_th = dao.fields.thadrgnm
            'drug_name
        Catch ex As Exception
            drug_name_th = "-"
        End Try
        Try
            drug_name_eng = dao.fields.engdrgnm
        Catch ex As Exception
            drug_name_eng = "-"
        End Try


        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(regis_ida)
        Catch ex As Exception

        End Try
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(FK_LCN_IDA)
            lcntpcd = dao_lcn.fields.lcntpcd
        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_lcn.fields.pvnabbr
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        Try
            class_xml.DRUG_STRENGTH = DRUG_STRENGTH
        Catch ex As Exception

        End Try
        'class_xml = cls.gen_xml()
        Dim head_type As String = ""
        Try
            head_type = ""
            If lcntpcd.Contains("บ") Then
                head_type = "โบราณ"
            Else
                head_type = "ปัจจุบัน"
            End If
        Catch ex As Exception

        End Try

        Dim dao_dos As New DAO_DRUG.TB_drdosage
        Try
            dao_dos.GetDataby_cd(dsgcd)
            If head_type = "โบราณ" Then
                If dao_dos.fields.thadsgnm <> "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            ElseIf head_type = "ปัจจุบัน" Then
                If Trim(dao_dos.fields.engdsgnm) = "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            End If

        Catch ex As Exception

        End Try
        Try
            Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
            dao_color.GetDataby_FK_IDA(_IDA_G)
            class_xml.DRRGT_COLORs = dao_color.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA_G)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(_IDA_G)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
        Catch ex As Exception

        End Try
        Try
            Try
                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_type.GetDataby_rgttpcd(rgttpcd)
                lcn_long_type = dao_type.fields.thargttpnm_short
            Catch ex As Exception
                lcn_long_type = ""
            End Try
        Catch ex As Exception

        End Try


        Try
            rcvno_auto = rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try
        Try
            If Len(lcnno_auto) > 0 Then
                Dim dao4 As New DAO_DRUG.ClsDBdrrgt
                dao4.GetDataby_IDA(_IDA_G)
                If dao_lcn.fields.lcnno < 1000000 Then
                    lcnno_format = dao_lcn.fields.LCNNO_DISPLAY_NEW
                Else
                    If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    Else
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        Dim aa As String = ""
        Dim aa2 As String = ""
        Dim dao3 As New DAO_DRUG.ClsDBdrrgt
        dao3.GetDataby_IDA(_IDA_G)
        Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
        daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

        Try
            Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
            dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
            Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype2.GetDataby_drgtpcd(dao_rq.fields.drgtpcd)

            aa2 = daodrgtype2.fields.engdrgtpnm
        Catch ex As Exception

        End Try

        Try
            aa = daodrgtype.fields.engdrgtpnm
        Catch ex As Exception

        End Try
        Try

            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try

        Try
            If Len(rcvno_auto) > 0 Then
                If aa2 = "(NG)" Then
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
                Else
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
                End If

            End If
        Catch ex As Exception

        End Try
        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If
        If IsNothing(appdate) = False Then
            If Date.TryParse(appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
            End If
        End If

        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format
        Dim DRUG_PROPERTIES_AND_DETAIL As String = ""

        class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
        class_xml.LCN_TYPE = lcn_long_type 'ยานี้
        class_xml.TABEAN_FORMAT = rgtno_format
        class_xml.DRUG_NAME = drug_name
        class_xml.COUNTRY = "ไทย"
        class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
        class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
        class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                class_xml.TABEAN_TYPE1 = "2"
                'cls_xml.TABEAN_TYPE2 = "2"
            Else
                class_xml.TABEAN_TYPE1 = "1"
                'cls_xml.TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try
        class_xml.TABEAN_TYPE2 = TABEAN_TYPE2


        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        Try
            'class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        Catch ex As Exception

        End Try




        Dim dao_det_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
        dao_det_prop.GetDataby_FK_IDA(_IDA_G)
        Try
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
        Catch ex As Exception

        End Try
        Dim dt_pack As New DataTable
        Dim bao_pack As New BAO_SHOW
        dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(_IDA_G)
        Try
            PACK_SIZE = dt_pack(0)("contain_detail")
            class_xml.PACK_SIZE = PACK_SIZE
        Catch ex As Exception

        End Try
        Try
            Dim dao_dpn As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
            dao_dpn.GetDataby_FKIDA(_IDA_G)
            class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA_G) 'ขนาดบรรจุ
        class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA_G) 'ATC
        class_xml.DT_SHOW.DT9.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
        class_xml.DT_SHOW.DT20 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA_G) 'สารสำคัญ/ส่วนประกอบ(รวม)
        class_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
        class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA_G) 'สรรพคุณ
        class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA_G) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ


        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_DATA(_IDA_G)

        class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA_G, 1)
        class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA_G, 2)
        class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA_G, 3)
        class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"

        class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
        class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        class_xml.DT_SHOW.DT21 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA_G, 9, LCNTPCD_GROUP)
        class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
        class_xml.DT_SHOW.DT23 = bao_show.SP_DRRQT_CAS_EQTO(_IDA_G)
        class_xml.DT_SHOW.DT23.TableName = "SP_regis"

        Dim statusId As Integer = STATUS_ID
        Dim lcntype As String = "" 'dao.fields.lcntpcd

        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao_sub.GetDatabyIDA(_IDA_G)
        Dim subs_appdate As Date
        Try
            subs_appdate = dao_sub.fields.appdate
        Catch ex As Exception

        End Try
        Dim template_id As Integer = 0
        Try
            template_id = dao_sub.fields.TEMPLATE_ID
        Catch ex As Exception
            template_id = 0
        End Try
        Dim E_VALUE As String = ""
        Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
        Try
            dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
            E_VALUE = dao_drgtpcd.fields.engdrgtpnm

        Catch ex As Exception

        End Try

        If IsNothing(subs_appdate) = False Then
            ''Dim appdate As Date
            If Date.TryParse(subs_appdate, subs_appdate) = True Then
                class_xml.SUBS_APP_DAY = subs_appdate.Day
                class_xml.SUBS_APP_MONTH = subs_appdate.ToString("MMMM")
                class_xml.SUBS_APP_YEAR = con_year(subs_appdate.Year)
                class_xml.FULL_SUBS_APPDATER = subs_appdate.Day & " " & subs_appdate.ToString("MMMM") & " " & con_year(subs_appdate.Year)

            End If
        End If
        Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Try
            dao_st.GetDataby_IDA(dao_sub.fields.STAFF_SIGN_IDA)
            class_xml.STAFF_NAME2 = dao_st.fields.STAFF_OFFER_NAME
            Try
                Dim dt_staffname As New DataTable
                'dt_staffname = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
                class_xml.STAFF_NAME1 = set_name_company(dao_st.fields.INSERT_CITIZEN)
                'class_xml.STAFF_NAME1 = 
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
        Try
            class_xml.POSITION_NAME1 = dao_sub.fields.POSITION_NAME1
        Catch ex As Exception

        End Try
        Try
            Dim dao_position As New DAO_DRUG.TB_MAS_STAFF_POSITION
            dao_position.GetDatabyIDA(dao_sub.fields.POSITION_NAME2)
            class_xml.POSITION_NAME2 = dao_position.fields.POSITION_NAME
        Catch ex As Exception

        End Try
        Try

        Catch ex As Exception

        End Try
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(Old_process)
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try

        p_dr = class_xml

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim NAME_TEMPLATE As String = ""
        Try
            If ddl_template.SelectedValue = "0" Then
                If E_VALUE <> "(E)" Then
                    NAME_TEMPLATE = "DATAN_YOR_2_NCIENT_READONLY.pdf"
                Else
                    NAME_TEMPLATE = "DATAN_YOR_2_NCIENT_READONLY_E.pdf"
                End If
            Else
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2("1400001", "1400001", 8, ddl_template.SelectedValue, _group:=1)
                NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            End If

        Catch ex As Exception

        End Try
        '-----------------------------------------------------
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", Old_process, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", Old_process, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, Old_process, filename, SUBSTITUTE:="1") 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", Old_process, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TB
        TB_DRRGT_SUBSTITUTE = XML.gen_xml_tb(_IDA, dao.fields.FK_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TB_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "บท", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TB") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TB_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TB("HB_PDF", _ProcessID, con_year(Date.Now.Year), dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TB("HB_XML", _ProcessID, con_year(Date.Now.Year), dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer = 0
        Dim PROCESS_ID As Integer
        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(_IDA)
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

        If DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert(' เลือกเจ้าหน้าที่');", True)
        Else
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
                Dim dao_rcvgen As New DAO_DRUG.ClsDBGEN_RCVNO
                dao_rcvgen.GetDataby_Year_PVNCD_PROCESS_ID(_CLS.PVCODE, con_year(Date.Now.Year()), PROCESS_ID)
                Dim PROCESS_ID_OLD As String = "130098"
                If dao_rcvgen.fields.IDA = 0 Or dao_rcvgen.fields Is Nothing Then
                    RCVNO = bao.GEN_RCVNO_NO_OLD(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID_OLD, _IDA)
                    PROCESS_ID = 20801
                Else
                    RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                End If

                'RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

                'Dim PROCESS_ID_NEW As String = "20801"
                Dim bao2 As New BAO.GenNumber
                Dim RCVNO_HERB_NEW As Integer
                RCVNO_HERB_NEW = bao2.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)

                Dim _year As Integer = con_year(Date.Now.Year)
                If _year < 2500 Then
                    _year += 543
                End If

                dao.fields.RCVNO_NEW = "HB " & _CLS.PVCODE & "-" & PROCESS_ID & "-" & con_year(Date.Now.Year).Substring(2, 2) & "-" & RCVNO_HERB_NEW

                Try
                    dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                dao.fields.RCV_ID_STAFF = DD_OFF_REQ.SelectedValue
                dao.fields.RCV_NAME_STAFF = DD_OFF_REQ.SelectedItem.Text
                dao.fields.STATUS_ID = STATUS_ID
                'dao.fields.STATUS_ID = 4
                dao.update()

                Run_Pdf_Tabean_Herb()
                alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.RCVNO_NEW)
            ElseIf STATUS_ID = 5 Then
                dao.fields.CONSIDER_ID_STAFF = DD_OFF_REQ.SelectedValue
                dao.fields.CONSIDER_NAME_STAFF = DD_OFF_REQ.SelectedItem.Text
                dao.update()
                Response.Redirect("FRM_TABEAN_SUBSTITUTE_STAFF_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & PROCESS_ID)

            ElseIf STATUS_ID = 8 Then
                '    dao.fields.appdate = CDate(txt_appdate.Text)
                'dao.fields.STATUS_ID = STATUS_ID
                'dao.update()
                dao.fields.APPROVE_ID_STAFF = DD_OFF_REQ.SelectedValue
                dao.fields.APPROVE_NAME_STAFF = DD_OFF_REQ.SelectedItem.Text
                dao.update()
                Response.Redirect("FRM_TABEAN_SUBSTITUTE_STAFF_APPROVE_DATE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & PROCESS_ID)
                'alert("ดำเนินการอนุมัติแล้ว")
            End If
        End If
    End Sub
    Private Sub BTN_KEEP_PAY_Click(sender As Object, e As EventArgs) Handles BTN_KEEP_PAY.Click
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer = 0
        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(_IDA)
        If STATUS_ID = 6 Then
            dao.fields.STATUS_ID = 4
            dao.fields.APPROVE_ID_STAFF = DD_OFF_REQ.SelectedValue
            dao.fields.APPROVE_NAME_STAFF = DD_OFF_REQ.SelectedItem.Text
            dao.update()
        End If

    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(_IDA)
        Dim type_id As String = 0
        type_id = dao.fields.DRRGT_REASON_ID
        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, type_id, _ProcessID)

        Return dt
    End Function
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_SUBSTITUTE/FRM_TABEAN_SUBSTITUTE_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub

    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "'); parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Panel1.Style.Add("display", "block")
        BindData_PDF()
        'BindData_PDF_SAI(Request.QueryString("newcode"))
    End Sub
    Private Sub BindData_PDF_SAI(ByVal newcode As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""
        Dim lcnno As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drgtpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim tr_id As String = 0
        Dim IDA_regist As Integer = 0
        Dim lcnsid As Integer = 0
        Dim lcntpcd As String = ""
        Dim appdate As Date
        Dim expdate As Date
        Dim pvnabbr As String = ""
        Dim dsgcd As String = ""
        Dim STATUS_ID As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = "0"
        Dim FK_LCN_IDA As Integer = 0
        Dim wong_lep As String = ""
        Dim _COUNTRY As String = ""
        Try
            STATUS_ID = 8 'Request.QueryString("STATUS_ID") 'Get_drrqt_Status(_IDA)
        Catch ex As Exception

        End Try
        Dim tamrap_id As Integer = 0
        Dim class_xml As New CLASS_DR

        'Dim dao_e As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB  			เก่า
        Dim dao_e As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
        dao_e.GetDataby_u1_frn_no(newcode)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        'dao.GetDataby_IDA(_IDA)
        dao.GetDataby_4key(dao_e.fields.rgtno, dao_e.fields.rgttpcd, dao_e.fields.drgtpcd, dao_e.fields.pvncd)
        Dim dao2 As New DAO_DRUG.ClsDBdrrqt
        Try
            class_xml.drrgts = dao.fields
        Catch ex As Exception

        End Try
        Try
            dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
            'regis_ida = dao.fields.FK_IDA
            tamrap_id = dao2.fields.feepayst
        Catch ex As Exception

        End Try
        Try
            'Dim dao_color As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_COLOR			เก่า
            Dim dao_color As New DAO_XML_DRUG_HERB.TB_XML_DRUG_COLOR_HERB
            dao_color.GetDataby_Newcode(newcode)
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_color.fields.drgchrtha
        Catch ex As Exception

        End Try
        Try
            'Dim dao_class As New DAO_DRUG.TB_drkdofdrg
            'dao_class.GetData_by_kindcd(dao.fields.kindcd)
            class_xml.DRUG_CLASS_NAME = dao_e.fields.thakindnm
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            ElseIf dao.fields.lcntpcd = "ผย" Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        lcnno = dao_e.fields.lcnno
        Try
            If dao_e.fields.lcntpcd.Contains("ผยบ") Or dao_e.fields.lcntpcd.Contains("นยบ") Then
                TABEAN_TYPE1 = "1"
                'cls_xml.TABEAN_TYPE2 = "2"
            Else
                TABEAN_TYPE1 = "2"
                'cls_xml.TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
        Catch ex As Exception

        End Try
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try
        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
        Try
            dao_rq.GetDataby_IDA(dao.fields.FK_DRRQT)
        Catch ex As Exception

        End Try

        Try
            IDA_regist = dao_rq.fields.FK_IDA
        Catch ex As Exception

        End Try
        Try
            FK_LCN_IDA = dao.fields.FK_LCN_IDA
        Catch ex As Exception

        End Try
        Try
            lcnsid = dao.fields.lcnsid
        Catch ex As Exception

        End Try

        DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
        pvncd = dao_e.fields.pvncd
        rgttpcd = dao_e.fields.rgttpcd
        dsgcd = dao_e.fields.dsgcd
        Try
            STATUS_ID = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try

        Try
            rcvno_auto = dao_e.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao_e.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = dao_e.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            drgtpcd = dao_e.fields.drgtpcd
        Catch ex As Exception

        End Try
        Try
            appdate = dao_e.fields.appdate
        Catch ex As Exception

        End Try
        Try
            expdate = dao_e.fields.expdate
        Catch ex As Exception

        End Try
        pvnabbr = dao_e.fields.pvnabbr
        Try
            drug_name_th = dao_e.fields.thadrgnm
            'drug_name
        Catch ex As Exception
            drug_name_th = "-"
        End Try
        Try
            drug_name_eng = dao_e.fields.engdrgnm
        Catch ex As Exception
            drug_name_eng = "-"
        End Try

        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(IDA_regist)
        Catch ex As Exception

        End Try

        'Dim dao_lcn168 As New DAO_DRUG.ClsDBdalcn
        'dao_lcn168.GetDataby_IDA(dao.fields.FK_LCN_IDA)

        'Dim dao_lcn As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB  		เก่า
        Dim dao_lcn As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        Try
            dao_lcn.GetDataby_u1(dao_e.fields.Newcode_not)
            lcntpcd = dao_lcn.fields.lcntpcd
            pvnabbr = dao_lcn.fields.pvnabbr
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        ' Dim _process As String = 0
        Try
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            If Len(_TR_ID) >= 9 Then
                dao_tr.GetDataby_TR_ID_Process(_TR_ID, "1400001")
            Else
                dao_tr.GetDataby_IDA(_TR_ID)
            End If
            '_process = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try


        Try
            class_xml.DRUG_STRENGTH = dao_e.fields.potency
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)
            'Dim dao_cas As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_IOW
            'dao_cas.GetDataby_Newcode_U(newcode)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
            'class_xml.DRRGT_DETAIL_Cs.AORI = dao_cas.fields.aori
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
        Catch ex As Exception

        End Try




        'class_xml = cls.gen_xml()
        Dim head_type As String = ""
        Try
            head_type = ""
            If lcntpcd.Contains("บ") Then
                head_type = "โบราณ"
            Else
                head_type = "ปัจจุบัน"
            End If
        Catch ex As Exception

        End Try

        Dim dao_dos As New DAO_DRUG.TB_drdosage
        Try

            'dao_dos.GetDataby_cd(dsgcd)
            If head_type = "โบราณ" Then
                If dao_e.fields.thadsgnm <> "-" Then
                    class_xml.Dossage_form = dao_e.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_e.fields.engdsgnm
                End If

            ElseIf head_type = "ปัจจุบัน" Then
                If Trim(dao_dos.fields.engdsgnm) = "-" Then
                    class_xml.Dossage_form = dao_e.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_e.fields.engdsgnm
                End If

            End If

        Catch ex As Exception

        End Try

        Try
            pvncd = pvncd
        Catch ex As Exception
            pvncd = ""
        End Try
        Try
            Try
                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_type.GetDataby_rgttpcd(rgttpcd)
                lcn_long_type = dao_type.fields.thargttpnm_short
            Catch ex As Exception
                lcn_long_type = ""
            End Try
        Catch ex As Exception

        End Try



        If IsNothing(appdate) = False Then
            Dim appdate2 As Date
            If Date.TryParse(appdate, appdate2) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                If class_xml.SHOW_LCNDATE_YEAR = 544 Then
                    class_xml.SHOW_LCNDATE_DAY = ""
                    class_xml.SHOW_LCNDATE_MONTH = ""
                    class_xml.SHOW_LCNDATE_YEAR = ""
                End If

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
            End If
        End If

        If IsNothing(expdate) = False Then
            Dim expdate2 As Date
            If Date.TryParse(expdate, expdate2) = True Then
                class_xml.EXPDAY = expdate.Day
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXP_YEAR = con_year(expdate.Year)
                Try
                    class_xml.EXPDATESHORT = expdate.Day & "/" & expdate.Month & "/" & con_year(expdate.Year)
                Catch ex As Exception

                End Try

                If class_xml.EXP_YEAR = 544 Then
                    class_xml.EXPDAY = ""
                    class_xml.EXPMONTH = ""
                    class_xml.EXP_YEAR = ""
                    class_xml.EXPDATESHORT = ""
                End If


            End If
        End If

        Dim aa As String = ""
        Dim aa2 As String = ""

        'Try
        '    If Len(rgtno_auto) > 0 Then
        'rgtno_format = dao_e.fields.register 'rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
        '    End If
        'Catch ex As Exception

        'End Try
        Dim pvnabbr2 As String = ""
        Try
            pvnabbr2 = dao_e.fields.pvnabbr2
        Catch ex As Exception

        End Try
        Try

            'If dao_e.fields.lcntpcd.Contains("ผย1") Then
            '    If dao_e.fields.pvnabbr = "กท" Then
            '        lcnno_format = CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
            '    Else
            '        lcnno_format = dao_e.fields.pvnabbr2 & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2)
            '    End If

            'Else
            If dao_lcn.fields.lcnno_display_new Is Nothing Then
                lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            Else
                lcnno_format = dao_lcn.fields.lcnno_display_new
            End If
            'lcnno_format = pvnabbr2 & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
            'End If


        Catch ex As Exception

        End Try
        'dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)

        'Try
        rcvno_format = dao_e.fields.register_rcvno 'rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
        'Catch ex As Exception

        'End Try

        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If


        'Try
        rgtno_format = dao_e.fields.register
        'Catch ex As Exception

        'End Try
        Dim dao_frgn As New DAO_XML_DRUG_HERB.TB_XML_DRUG_FRGN_HERB
        dao_frgn.GetDataby_u1_and_funcd(newcode, 3)
        If dao_frgn.fields.funccd = 3 Then
            _COUNTRY = dao_frgn.fields.engcntnm
        End If


        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
        class_xml.LCN_TYPE = lcn_long_type 'ยานี้
        class_xml.TABEAN_FORMAT = rgtno_format
        class_xml.DRUG_NAME = drug_name
        class_xml.COUNTRY = _COUNTRY
        class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
        class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
        class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
        class_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        class_xml.TABEAN_TYPE2 = TABEAN_TYPE2

        Dim bao_show As New BAO_SHOW
        Try
            class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.IDA_dalcn) 'ข้อมูลสถานที่จำลอง
        Catch ex As Exception
            'Response.Write("<script type='text/javascript'>alert('" + "ไม่เจอ NEWCODE หรือ NEWCODE ไม่ตรงกัน" + "'); parent.close_modal();</script> ")
        End Try

        Try
            Dim dt_thanm As DataTable = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_e.fields.Identify, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            For Each dr As DataRow In dt_thanm.Rows
                dr("thanm") = dao_e.fields.licen_loca
            Next
            'Dim dt_thanm2 As DataTable
            'dt_thanm2 = dt_thanm.Clone
            'Dim dr_nm As DataRow = dt_thanm2.NewRow()
            'dr_nm("thanm") = dao_e.fields.licen_loca
            'dt_thanm2.Rows.Add(dr_nm)
            class_xml.DT_SHOW.DT17 = dt_thanm
        Catch ex As Exception

        End Try

        'Dim dao_det_prop As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_COLOR			เก่า
        Dim dao_det_prop As New DAO_XML_DRUG_HERB.TB_XML_DRUG_COLOR_HERB
        dao_det_prop.GetDataby_Newcode(newcode)
        Try
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.drgchrtha
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 1)
        class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 2)
        class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 10)
        class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"

        class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 3)
        class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"



        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        dao_dal.GetDataby_IDA(dao_lcn.fields.IDA)
        class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_NEWCODE_SAI(newcode)
        class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        class_xml.DT_SHOW.DT23 = bao_show.SP_drrgt_cas(_IDA)
        class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        class_xml.DT_SHOW.DT21 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
        class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
        class_xml.DT_SHOW.DT23 = bao_show.SP_DRRGT_CAS_EQTO(_IDA)
        class_xml.DT_SHOW.DT23.TableName = "SP_regis"


        Dim lcntype As String = "0" 'dao.fields.lcntpcd

        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID("1400001")
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
        Catch ex As Exception

        End Try

        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao_sub.GetDatabyIDA(_IDA)
        Dim subs_appdate As Date
        Try
            subs_appdate = dao_sub.fields.appdate
        Catch ex As Exception

        End Try
        Dim template_id As Integer = 0
        Try
            template_id = dao_sub.fields.TEMPLATE_ID
        Catch ex As Exception
            template_id = 0
        End Try
        Dim E_VALUE As String = ""
        Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
        Try
            dao_drgtpcd.GetDataby_drgtpcd(dao_e.fields.drgtpcd)
            E_VALUE = dao_drgtpcd.fields.engdrgtpnm

        Catch ex As Exception

        End Try

        Dim NAME_TEMPLATE As String = ""

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP("1400001", 8, HiddenField2.Value, 0)

        'Try
        If ddl_template.SelectedValue = "0" Then
            If E_VALUE <> "(E)" Then
                'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2("1400001", "1400001", 8, ddl_template.SelectedValue, _group:=1)
                'NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
                NAME_TEMPLATE = "DATAN_TORYOR5_NCIENT_READONLY.pdf"
            Else
                'If Request.QueryString("status") = "8" Or Request.QueryString("status") = "14" Then
                NAME_TEMPLATE = "DATAN_TORYOR5_NCIENT_READONLY.pdf"
                'Else
                '    NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
                'End If
            End If

            'dao_pdftemplate.GetDataby_TEMPLAETE_TABEAN(_process, statusId, 0)
        Else
            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2("1400001", "1400001", 8, ddl_template.SelectedValue, _group:=1)
            NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
        End If

        'Catch ex As Exception

        'End Try


        'End If

        p_dr = class_xml

        '-----------------------------------------------------
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, "1400001", filename, SUBSTITUTE:="1") 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", "1400001", _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub
    Private Sub DD_OFF_REQ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_OFF_REQ.SelectedIndexChanged
        If DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกเจ้าหน้าที่');", True)
        End If
    End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
        End Try

        Return fullname
    End Function


End Class