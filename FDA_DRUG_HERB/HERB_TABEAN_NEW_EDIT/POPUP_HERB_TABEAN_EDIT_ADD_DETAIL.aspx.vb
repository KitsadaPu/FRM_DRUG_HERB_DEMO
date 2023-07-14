Imports Telerik.Web.UI
Public Class POPUP_HERB_TABEAN_EDIT_ADD_DETAIL
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
    Private _Process_ID As String = ""
    Shared PLACE_IDA As Integer = 0
    Shared PLACE_NAME As String = ""
    Shared PLACE_ADDRESS As String = ""
    Shared IDA_ADDRESS As Integer = 0
    Shared IDA_DQ As Integer = 0
    Shared NEWCODE As String = ""
    Shared NEWCODE_U As String = ""
    Shared IDA_LCN_NEW As String = ""
    Shared LCNNO_NEW As String = ""
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
        _IDA = Request.QueryString("IDA")
        _IDA_DR = Request.QueryString("IDA_DR")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _Process_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

            load_ddl_chwt()
            bind_SALE_CHANNEL()
            bind_dd_storage()
            bind_dd_eatting_condition()
            bind_dd_eatting()
            bind_dd_manufac()
            bind_dd_pack_1()
            bind_dd_pack_2()
            bind_dd_pack_3()
            bind_dd_unit_1()
            bind_dd_unit_2()
            bind_dd_unit_3()

            UC_TABEAN_EDIT_DETAIL_CAS.bind_unit1()
            UC_TABEAN_EDIT_DETAIL_CAS.bind_unit2()
            UC_TABEAN_EDIT_DETAIL_CAS.bind_unit3()
            UC_TABEAN_EDIT_DETAIL_CAS.bind_unit4()
            UC_TABEAN_EDIT_DETAIL_CAS.get_data_drgperunit()
            UC_TABEAN_EDIT_DETAIL_CAS.bind_unit_each()
            UC_TABEAN_EDIT_DETAIL_CAS.bind_lbl()
            UC_TABEAN_EDIT_DETAIL_CAS.bind_unit()
            'UC_TABEAN_EDIT_DETAIL_CAS.rg_chem_Rebind()
            Get_data()
        End If
        'BindTable()
    End Sub
    Public Sub load_ddl_chwt()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()
        ddl_Province.DataSource = dt
        ddl_Province2.DataSource = dt

        ddl_Province.DataBind()
        ddl_Province2.DataBind()
    End Sub
    Public Sub bind_dd_manufac()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_MENUFACTRUE()

        DD_MANUFAC_ID.DataSource = dt
        DD_MANUFAC_ID.DataBind()
        DD_MANUFAC_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_SALE_CHANNEL()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_TABEAN_HERB_SALE()

        DD_SALE_CHANNEL.DataSource = dt
        DD_SALE_CHANNEL.DataBind()
        DD_SALE_CHANNEL.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub bind_dd_storage()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STORAGE_JJ()

        DD_STORAGE_ID.DataSource = dt
        DD_STORAGE_ID.DataBind()
        DD_STORAGE_ID.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub bind_dd_eatting_condition()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_CONDITION()

        DD_EATING_CONDITION_ID.DataSource = dt
        DD_EATING_CONDITION_ID.DataBind()
        DD_EATING_CONDITION_ID.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub bind_dd_eatting()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_JJ()

        DD_EATTING_ID.DataSource = dt
        DD_EATTING_ID.DataBind()
        DD_EATTING_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_dd_pack_1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_PRIMARY()

        DD_PCAK_1.DataSource = dt
        DD_PCAK_1.DataBind()
        DD_PCAK_1.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_pack_2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_SECONDARY()

        DD_PCAK_2.DataSource = dt
        DD_PCAK_2.DataBind()
        DD_PCAK_2.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_pack_3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_TERTIRY()

        DD_PCAK_3.DataSource = dt
        DD_PCAK_3.DataBind()
        DD_PCAK_3.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_PRIMARY()

        DD_UNIT_1.DataSource = dt
        DD_UNIT_1.DataBind()
        DD_UNIT_1.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_SCONDARY()

        DD_UNIT_2.DataSource = dt
        DD_UNIT_2.DataBind()
        DD_UNIT_2.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_TERTIARY()

        DD_UNIT_3.DataSource = dt
        DD_UNIT_3.DataBind()
        DD_UNIT_3.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Sub Get_data()
        Dim dao_c As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        dao_c.GetdatabyID_FK_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA)
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        dao_g.GetDataby_IDA(_IDA_DR)
        Dim dao_h As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
        Try
            If dao_g.fields.rgtno IsNot Nothing Then
                dao_h.GetDataby_4Key(dao_g.fields.rgtno, dao_g.fields.rgttpcd, dao_g.fields.drgtpcd, dao_g.fields.pvncd)
            Else
                dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
            End If
        Catch ex As Exception
            dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
        End Try
        Dim dao_c124 As New DAO_XML_DRUG_HERB.TB_XML_DRUG_CONTAIN_HERB
        Try
            dao_c124.GetDataby_Newcode(dao_h.fields.Newcode)
            NEWCODE = dao_h.fields.Newcode
            NEWCODE_U = dao_h.fields.Newcode_U
        Catch ex As Exception

        End Try
        Dim dao_q As New DAO_DRUG.ClsDBdrrqt
        dao_q.GetDataby_IDA(dao_g.fields.FK_DRRQT)
        IDA_DQ = dao_q.fields.IDA
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_tn.GetdatabyID_FK_IDA_DQ(dao_g.fields.FK_DRRQT)
        Catch ex As Exception

        End Try
        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        dao_dal.GetDataby_IDA(dao.fields.FK_LCN_IDA)
        Dim dao_f As New DAO_DRUG.ClsDBsyspdcfrgn
        Dim dao_fa As New DAO_DRUG.ClsDBdrfrgnaddr
        With dao_c.fields
            If .NAME_PRODUCT_ID = True Then
                DV_NAME_SL.Visible = True
                CB_NAME_PRODUCT_ID.Checked = True
                If .SUB_NAME_ENG = True Then
                    CB_NAME_ENG.Checked = True
                    'DIV_NAME_ENG.Visible = True
                    Panel_Name_Eng.Style.Add("display", "block")
                End If
                If .SUB_NAME_OTHER = True Then
                    CB_NAME_OTHER.Checked = True
                    'DIV_NAME_OTHER.Visible = True
                    Panel_Name_Other.Style.Add("display", "block")
                End If
                If .SUB_NAME_EXPORT = True Then
                    CB_NAME_EXPORT.Checked = True
                    'DIV_NAME_EXPORT.Visible = True
                    Panel_Name_Export.Style.Add("display", "block")
                End If
            End If
            If dao_h.fields.engdrgnm = "" Then
                NAME_ENG.Text = dao_g.fields.engdrgnm
            Else
                If dao_h.fields.engdrgnm = "" Then
                    NAME_ENG.Text = "ไม่มีข้อมูล"
                    NAME_ENG.Style.Add("color", "red")
                Else
                    NAME_ENG.Text = dao_h.fields.engdrgnm
                End If
            End If
            If dao_h.fields.thadrgnm = "" Then
                NAME_EXPORT.Text = dao_h.fields.engdrgnm
            Else
                If dao_h.fields.engdrgnm = "" Then
                    NAME_EXPORT.Text = "ไม่มีข้อมูล"
                    NAME_EXPORT.Style.Add("color", "red")
                Else
                    NAME_EXPORT.Text = dao_h.fields.engdrgnm
                End If
            End If
            NAME_ENG_NEW.Text = dao_d.fields.NAME_ENG
            If dao_tn.fields.NAME_OTHER = "" Then
                NAME_OTHER.Text = "ไม่มีข้อมูล"
                NAME_OTHER.Style.Add("color", "red")
            Else
                NAME_OTHER.Text = dao_tn.fields.NAME_OTHER
            End If
            NAME_OTHER_NEW.Text = dao_tn.fields.NAME_OTHER
            NAME_EXPORT_NEW.Text = dao_h.fields.engdrgnm
            If .NAME_LOCATION_ID = True Then
                Div_NAME_LOCATION.Visible = True
                CB_NAME_LOCATION_ID.Checked = True
                If .SUB_Location1_ID = True Then
                    CheckBox1.Checked = True
                    lbl_lcntpcd_new.Text = dao_dal.fields.lcntpcd
                    Panel_cheng_Location.Style.Add("display", "block")
                End If
                If .SUB_Location2_ID = True Then
                    CheckBox2.Checked = True
                    lbl_lcntpcd_new2.Text = dao_dal.fields.lcntpcd
                    Panel_cheng_Location2.Style.Add("display", "block")
                End If
                If .SUB_Location3_ID = True Then
                    CheckBox3.Checked = True
                    Panel_cheng_Location3.Style.Add("display", "block")
                End If
            End If
            lbl_name_thanm.Text = dao_d.fields.LCN_NAME
            lbl_name_location.Text = dao_d.fields.LCN_THANAMEPLACE
            lbl_Full_addr.Text = dao_d.fields.LCN_ADDR
            lbl_name_thanm2.Text = dao_d.fields.LCN_NAME
            lbl_name_location2.Text = dao_d.fields.LCN_THANAMEPLACE
            lbl_Full_addr2.Text = dao_d.fields.LCN_ADDR
            If dao_h.fields.engfrgnnm = "" Then
                txt_name_producer.Text = dao_tn.fields.FOREIGN_NAME
            Else
                If dao_h.fields.engfrgnnm = "" Then
                    txt_name_producer.Text = "ไม่มีข้อมูล"
                    txt_name_producer.Style.Add("color", "red")
                Else
                    txt_name_producer.Text = dao_h.fields.engfrgnnm
                End If
            End If
            If dao_h.fields.engfrgnnm_addr = "" Then
                txt_address.Text = dao_tn.fields.FOREIGN_NAME_PLACE
            Else
                If dao_h.fields.engfrgnnm_addr = "" Then
                    txt_address.Text = "ไม่มีข้อมูล"
                    txt_address.Style.Add("color", "red")
                Else
                    txt_address.Text = dao_h.fields.engfrgnnm_addr
                End If
            End If
            If .PRODUCT_RECIPE_ID = True Then
                PANEL_PRODUCT_RECIPE.Style.Add("display", "block")
                Div_SubProductRecipe.Visible = True
                CB_PRODUCT_RECIPE_ID.Checked = True
                If .SubProductRecipe_1 = True Then
                    CheckBox_SubRecipe1.Checked = True
                End If
                If .SubProductRecipe_1_1 = True Then
                    CheckBox_SubRecipe1_1.Checked = True
                End If
                If .SubProductRecipe_1_2 = True Then
                    CheckBox_SubRecipe1_2.Checked = True
                End If
                If .SubProductRecipe_2 = True Then
                    CheckBox_SubRecipe2.Checked = True
                End If
                If .SubProductRecipe_2_1 = True Then
                    CheckBox_SubRecipe2_1.Checked = True
                End If

                'Panel_PRODUCT_RECIPE.Style.Add("display", "block")
            End If

            If .PRODUCTION_PROCESS_ID = True Then
                CB_PRODUCTION_PROCESS_ID.Checked = True
                Panel_Production_Process.Style.Add("display", "block")
            End If
            If .PROPERTIES_ID = True Then
                CB_PROPERTIES_ID.Visible = True

                'txt_Indication.Text = dao_c124.fields.
                Panel_Properties.Style.Add("display", "block")
            End If

            If dao_h.fields.indication = "" Then
                txt_PROPERTIES.Text = "ไม่มีข้อมูล"
                txt_PROPERTIES.Style.Add("color", "red")
            Else
                txt_PROPERTIES.Text = dao_h.fields.indication
            End If
            If .SIZE_USE_ID = True Then
                Panel_Size_Use.Visible = True
                Panel_Size_Use.Style.Add("display", "block")

            End If

            If dao_tn.fields.SIZE_USE = "" Then
                txt_Size_Use.Text = "ไม่มีข้อมูล"
                txt_Size_Use.Style.Add("color", "red")
            Else
                txt_Size_Use.Text = dao_tn.fields.SIZE_USE
            End If
            If dao_c124.fields.SUBTITLE_SIZE_DRUG = "" Or dao_c124.fields.SUBTITLE_SIZE_DRUG Is Nothing Then
                SIZE_PACK_OLD.Text = "ไม่มีข้อมูล"
                SIZE_PACK_OLD.Style.Add("color", "red")
            Else
                SIZE_PACK_OLD.Text = dao_c124.fields.SUBTITLE_SIZE_DRUG
            End If

            If dao_d.fields.SIZE_PACK = "" Then
                If dao_c124.fields.SUBTITLE_SIZE_DRUG = "" Then
                    SIZE_PACK_NEW.Text = "ไม่มีข้อมูล"
                    SIZE_PACK_NEW.Style.Add("color", "red")
                Else
                    SIZE_PACK_NEW.Text = dao_c124.fields.SUBTITLE_SIZE_DRUG
                End If
            Else
                SIZE_PACK_NEW.Text = dao_d.fields.SIZE_PACK
            End If

            If .CONTAINER_PACKING_ID = True Then
                CB_CONTAINER_PACKING_ID.Checked = True
                Panel_Container_Packing.Style.Add("display", "block")
            End If

            If .PREPARE_EAT_ID = True Then
                CB_PREPARE_EAT_ID.Checked = True
                Panel_Prepare_Eat.Style.Add("display", "block")
            End If

            If .EAT_CONDITION_ID = True Then
                CB_EAT_CONDITION_ID.Checked = True
                Panel_EatCondition.Style.Add("display", "block")
            End If

            If .QUALITY_CONTROL_ID = True Then
                CB_QUALITY_CONTROL_ID.Checked = True

                Panel_Quality_Control.Style.Add("display", "block")
            End If

            If .CER_LCN_ID = True Then
                CB_CER_LCN_ID.Checked = True
            End If

            If .STORAGE_ID = True Then
                CB_STORAGE_ID.Checked = True
                Panel_Storage.Style.Add("display", "block")
            End If

            If .ETIQUETQ_ID = True Then
                CB_ETIQUETQ_ID.Checked = True
                bind_datatable_RG_ETIQUETQ()
                PANEL_ETIQUETQ.Style.Add("display", "block")
            End If

            If .CHANNEL_SALE_ID = True Then
                CB_CHANNEL_SALE_ID.Checked = True
                PANEL_CHANNEL_SALE.Style.Add("display", "block")
            End If

            If .OTHER_ID = True Then
                CB_OTHER.Checked = True
                Panel_OTHER.Style.Add("display", "block")
            End If
        End With

        'txt_rgtno.Text = dao.fields.RGTNO_NEW
        Dim full_rgtno As String = ""
        If dao_q.fields.RGTNO_NEW = "" Then
            full_rgtno = dao_g.fields.rgttpcd & " " & Integer.Parse(Right(dao_g.fields.rgtno, 5)).ToString() & "/" & Left(dao_g.fields.rgtno, 2)
            txt_rgtno.Text = full_rgtno
        Else
            txt_rgtno.Text = dao_q.fields.RGTNO_NEW
        End If

        If dao_tn.fields.EATING_CONDITION_NAME = "" Then
            txt_EATING_CONDITION.Text = "ไม่มีข้อมูล"
            txt_EATING_CONDITION.Style.Add("color", "red")
        Else
            txt_EATING_CONDITION.Text = dao_tn.fields.EATING_CONDITION_NAME
        End If

        If dao_tn.fields.EATTING_NAME = "" Then
            txt_EATTING.Text = "ไม่มีข้อมูล"
            txt_EATTING.Style.Add("color", "red")
        Else
            txt_EATTING.Text = dao_tn.fields.EATTING_NAME
        End If
        Try
            DD_EATTING_ID.SelectedValue = dao_tn.fields.EATTING_ID
        Catch ex As Exception

        End Try

        If dao_tn.fields.EATING_CONDITION_NAME = "" Then
            EATING_CONDITION_NAME.Text = "ไม่มีข้อมูล"
            EATING_CONDITION_NAME.Style.Add("color", "red")
        Else
            EATING_CONDITION_NAME.Text = dao_tn.fields.EATING_CONDITION_NAME
        End If
        Try
            If dao_tn.fields.STORAGE_NAME = "" Then
                txt_STORAGE.Text = "ไม่มีข้อมูล"
                txt_STORAGE.Style.Add("color", "red")
            Else
                txt_STORAGE.Text = dao_tn.fields.STORAGE_NAME
            End If
            DD_STORAGE_ID.SelectedValue = dao_tn.fields.STORAGE_ID
        Catch ex As Exception

        End Try
        Try
            If (dao_tn.fields.TREATMENT_AGE Is Nothing Or dao_tn.fields.TREATMENT_AGE = 0) And dao_tn.fields.TREATMENT_AGE_MONTH IsNot Nothing Then
                txt_TREATMENT_AGE.Text = dao_tn.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
            ElseIf (dao_tn.fields.TREATMENT_AGE_MONTH Is Nothing Or dao_tn.fields.TREATMENT_AGE_MONTH = 0) And dao_tn.fields.TREATMENT_AGE IsNot Nothing Then
                txt_TREATMENT_AGE.Text = dao_tn.fields.TREATMENT_AGE & " " & "ปี"
            ElseIf (dao_tn.fields.TREATMENT_AGE Is Nothing Or dao_tn.fields.TREATMENT_AGE = 0) And dao_tn.fields.TREATMENT_AGE_MONTH Is Nothing Then
                txt_TREATMENT_AGE.Text = "ไม่มีข้อมูล"
                txt_TREATMENT_AGE.Style.Add("color", "red")
            Else
                txt_TREATMENT_AGE.Text = dao_tn.fields.TREATMENT_AGE & " " & "ปี" & " " & dao_tn.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
            End If
            TREATMENT_AGE_YEAR.SelectedValue = dao_tn.fields.TREATMENT_AGE_ID
            TREATMENT_AGE_MONTH_SUB.SelectedValue = dao_tn.fields.TREATMENT_AGE_MONTH
        Catch ex As Exception

        End Try

        Try
            If dao_tn.fields.SALE_CHANNEL_NAME = "" Then
                txt_SALE_CHANNEL.Text = "ไม่มีข้อมูล"
                txt_SALE_CHANNEL.Style.Add("color", "red")
            Else
                txt_SALE_CHANNEL.Text = dao_tn.fields.SALE_CHANNEL_NAME
            End If
            DD_SALE_CHANNEL.SelectedValue = dao_tn.fields.SALE_CHANNEL_ID
        Catch ex As Exception

        End Try

        If dao_dal.fields.LCNNO_DISPLAY_NEW IsNot Nothing Then
            lbl_lcnno_display.Text = dao_dal.fields.LCNNO_DISPLAY_NEW
            lbl_lcnno_display2.Text = dao_dal.fields.LCNNO_DISPLAY_NEW
        Else
            lbl_lcnno_display.Text = dao_dal.fields.LCNNO_DISPLAY
            lbl_lcnno_display2.Text = dao_dal.fields.LCNNO_DISPLAY
        End If
        lbl_lcntpcd.Text = dao_dal.fields.lcntpcd
        lbl_lcntpcd2.Text = dao_dal.fields.lcntpcd

        txt_upload_name.Text = dao_d.fields.FILE_NAME_OTHER
        Try
            dao_f.GetData_by_frgncd(dao_tn.fields.FOREIGN_NAME_ID)
            txt_name_producer.Text = dao_tn.fields.FOREIGN_NAME
            txt_address.Text = dao_tn.fields.FOREIGN_NAME_PLACE
        Catch ex As Exception

        End Try
        'txt_SALE_CHANNEL.Text = dao_tn.fields.SALE_CHANNEL_NAME
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dt As New DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim ACTION_DESCRIPTION As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA)
        Dim dao_gt As New DAO_DRUG.ClsDBdrrgt
        dao_gt.GetDataby_IDA(_IDA_DR)
        Dim dao_qt As New DAO_DRUG.ClsDBdrrqt
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_qt.GetDataby_IDA(IDA_DQ)
            dao_tabean.GetdatabyID_FK_IDA_DQ(IDA_DQ)
        Catch ex As Exception

        End Try
        INsert_CheckBox()
        Dim dao_c As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        dao_c.GetdatabyID_FK_IDA(_IDA)

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)

        If dao_tabean.fields.IDA = 0 Then
            dt = bao.SP_TRANSFER_DRR_TO_TABEAN_HERB_INSERT(_IDA_DR)
        End If
        INSERT_OLD_DATA() ' insert ข้อมูลเก่า
        If CB_NAME_PRODUCT_ID.Checked = True Then
            If CB_NAME_ENG.Checked = True Or CB_NAME_EXPORT.Checked = True Then
                dao_d.fields.NAME_ENG = NAME_ENG_NEW.Text
            End If
            If CB_NAME_OTHER.Checked = True Then
                dao_d.fields.NAME_OTHER = NAME_OTHER_NEW.Text
            End If
            If CB_NAME_EXPORT.Checked = True Then
                dao_d.fields.NAME_EXPORT = NAME_EXPORT_NEW.Text
            End If

            ACTION_DESCRIPTION = "ชื่อของผลิตภัณฑ์ "
        End If
        If CB_NAME_LOCATION_ID.Checked = True Then
            If CheckBox1.Checked = True Or CheckBox2.Checked = True Then
                dao_d.fields.LCN_ID = IDA_LCN_NEW
                dao_d.fields.IDA_LCN = IDA_LCN_NEW
                dao_d.fields.LCNNO = LCNNO_NEW
                If CheckBox1.Checked = True Then
                    dao_d.fields.LCN_NAME = lbl_name_thanm.Text
                    dao_d.fields.LCN_THANAMEPLACE = lbl_name_location.Text
                    dao_d.fields.LCN_ADDR = lbl_Full_addr.Text
                ElseIf CheckBox2.Checked = True Then
                    dao_d.fields.LCN_NAME = lbl_name_thanm2.Text
                    dao_d.fields.LCN_THANAMEPLACE = lbl_name_location2.Text
                    dao_d.fields.LCN_ADDR = lbl_Full_addr2.Text
                End If
            End If

            If CheckBox3.Checked = True Then
                'dao_d.fields.FOREIGN_NAME = txt_name_producer.Text
                dao_d.fields.FOREIGN_NAME = striptags(txt_search.Text)
                dao_d.fields.FOREIGN_NAME_ID = PLACE_IDA
                dao_d.fields.FOREIGN_NAME_PLACE = txt_address_New.Text.ToUpper()
                dao_d.fields.FOREIGN_NAME_PLACE_ID = IDA_ADDRESS
            End If

            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", ที่อยู่ของสถานที่ "
        End If
        If CB_PRODUCT_RECIPE_ID.Checked = True Then

            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", ตำรับผลิตภัณฑ์สมุนไพร "
        End If
        If CB_PRODUCTION_PROCESS_ID.Checked = True Then
            'dao_d.fields.PRODUCT_PROCESS = txt_name_producer.Text
            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", กรรมวิธีการผลิต  "
        End If
        If CB_PROPERTIES_ID.Checked = True Then
            dao_d.fields.PROPERTIES = txt_PROPERTIES_NEW.Text
            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", สรรพคุณ/ข้อบ่งใช้/ ข้อความกล่าวอ้างทางสุขภาพ "
        End If
        If CB_SIZE_USE_ID.Checked = True Then
            dao_d.fields.SIZE_USE = txt_Size_Use_New.Text
            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", ขนาดและวิธีการใช้ "
        End If
        If CB_PREPARE_EAT_ID.Checked = True Then
            dao_d.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
            dao_d.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text
            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", วิธีเตรียมก่อนรับประทาน "
        End If
        If CB_EAT_CONDITION_ID.Checked = True Then
            dao_d.fields.EATING_CONDITION_ID = DD_EATING_CONDITION_ID.SelectedValue
            dao_d.fields.EATING_CONDITION_NAME = DD_EATING_CONDITION_ID.SelectedItem.Text
            dao_d.fields.EATING_CONDITION_NAME_DETAIL = EATING_CONDITION_NAME.Text
            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", เงื่อนไขการรับประทาน "
        End If
        If CB_STORAGE_ID.Checked = True Then
            dao_d.fields.STORAGE_ID = DD_STORAGE_ID.SelectedValue
            dao_d.fields.STORAGE_NAME = DD_STORAGE_ID.SelectedItem.Text
            Try
                dao_d.fields.TREATMENT_AGE_ID = TREATMENT_AGE_YEAR.SelectedValue
                dao_d.fields.TREATMENT_AGE_MONTH = TREATMENT_AGE_MONTH_SUB.SelectedValue
            Catch ex As Exception

            End Try
            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", การเก็บรักษา/อายุการเก็บรักษา "
        End If
        If CB_CONTAINER_PACKING_ID.Checked = True Then
            dao_d.fields.SIZE_PACK = SIZE_PACK_NEW.Text
            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", ภาชนะและขนาดบรรจุ "
        End If
        If CB_QUALITY_CONTROL_ID.Checked = True Then

            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", วิธีควบคุมคุณภาพและข้อกำหนดเฉพาะของผลิตภัณฑ์สมุนไพร"
        End If
        If CB_ETIQUETQ_ID.Checked = True Then

            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", ฉลาก "
        End If
        If CB_CHANNEL_SALE_ID.Checked = True Then
            dao_d.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
            dao_d.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", ช่องทางการจำหน่าย "
        End If
        If CB_OTHER.Checked = True Then
            dao_d.fields.FILE_NAME_OTHER = txt_upload_name.Text
            ACTION_DESCRIPTION = ACTION_DESCRIPTION & ", อื่นๆ "
        End If

        Dim TR_ID As String = ""
        'Dim bao_tran As New BAO_TRANSECTION
        Try
            If dao.fields.TR_ID Is Nothing Then
                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                TR_ID = bao_tran.insert_transection(_Process_ID)
                dao.fields.TR_ID = TR_ID
            End If
        Catch ex As Exception

        End Try

        Try
            If IsNothing(dao_gt.fields.pvncd) = False Then dao.fields.pvncd = dao_gt.fields.pvncd Else dao.fields.pvncd = Nothing
            If IsNothing(dao_gt.fields.drgtpcd) = False Then dao.fields.drgtpcd = dao_gt.fields.drgtpcd Else dao.fields.drgtpcd = Nothing
            If IsNothing(dao_gt.fields.rgttpcd) = False Then dao.fields.rgttpcd = dao_gt.fields.rgttpcd Else dao.fields.rgttpcd = Nothing
            If IsNothing(dao_gt.fields.pvnabbr) = False Then dao.fields.pvnabbr = dao_gt.fields.pvnabbr Else dao.fields.pvnabbr = Nothing
            If IsNothing(dao_gt.fields.rgtno) = False Then dao.fields.rgtno = dao_gt.fields.rgtno Else dao.fields.rgtno = Nothing
            dao.fields.RGTNO_NEW = txt_rgtno.Text
            dao.fields.ACTIVEFACT = 1
            dao.Update()
        Catch ex As Exception

        End Try
        'dao.fields.pvncd = dao_qt.fields.pvncd
        'dao.fields.drgtpcd = dao_qt.fields.drgtpcd
        'dao.fields.rgttpcd = dao_qt.fields.rgttpcd
        'dao.fields.pvnabbr = dao_qt.fields.pvnabbr
        dao.fields.thadrgnm = dao_qt.fields.thadrgnm
        dao.fields.engdrgnm = dao_qt.fields.engdrgnm
        dao.fields.cnsdcd = dao_qt.fields.cnsdcd
        dao.fields.cnsddate = dao_qt.fields.cnsddate
        'dao.fields.cscd = dao_qt.fields.cscd
        dao.fields.rqttpcd = dao_qt.fields.rqttpcd
        dao.fields.FK_REGIS = dao_qt.fields.FK_REGIS
        Try
            dao.fields.FK_DRRQT = dao_qt.fields.IDA
        Catch ex As Exception

        End Try
        dao.fields.REMARK = NOTE_EDIT.Text
        dao.fields.CTZNO = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        dao.Update()
        Get_data()
        If dao_d.fields.IDA = 0 Then
            dao_d.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao_d.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao_d.fields.ACTIVEFACT = 1
            dao_d.fields.TR_ID = TR_ID
            dao_d.fields.FK_IDA = _IDA
            dao_d.fields.LCN_ID = _IDA_LCN
            dao_d.insert()
        Else
            dao_d.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao_d.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao_d.fields.ACTIVEFACT = 1
            dao_d.fields.TR_ID = TR_ID
            dao_d.fields.FK_IDA = _IDA
            dao_d.fields.LCN_ID = _IDA_LCN
            dao_d.Update()
        End If
        dao_d.fields.ACTIVEFACT = 1
        dao_d.Update()
        dao.fields.ACTIVEFACT = 1
        dao.Update()


        Dim dao_log As New DAO_DRUG.TB_LOG_EDIT_TABEAN
        dao_log.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao_log.fields.CREATEDATE = Date.Now
        dao_log.fields.ACTION_DESCRIPTION = ACTION_DESCRIPTION
        dao_log.fields.FK_IDA = _IDA
        dao_log.insert()

        INSERT_FILEUPLOAD(dao.fields.TR_ID)
        'Updata_data_tabean_to_BC()
        Response.Redirect("POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD.aspx?IDA=" & _IDA & "&PROCESS_ID=" & _Process_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & _IDA_DR)
        'alert("บันทึกข้อมูลแล้ว")
    End Sub
    Sub INsert_CheckBox()
        Dim dao_c As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        dao_c.GetdatabyID_FK_IDA(_IDA)
        If dao_c.fields.IDA = 0 Then
            dao_c.fields.NAME_PRODUCT_ID = CB_NAME_PRODUCT_ID.Checked
            dao_c.fields.SUB_NAME_ENG = CB_NAME_ENG.Checked
            dao_c.fields.SUB_NAME_OTHER = CB_NAME_OTHER.Checked
            dao_c.fields.SUB_NAME_EXPORT = CB_NAME_EXPORT.Checked
            dao_c.fields.NAME_LOCATION_ID = CB_NAME_LOCATION_ID.Checked
            dao_c.fields.SUB_Location1_ID = CheckBox1.Checked
            dao_c.fields.SUB_Location2_ID = CheckBox2.Checked
            dao_c.fields.SUB_Location3_ID = CheckBox3.Checked
            dao_c.fields.PRODUCT_RECIPE_ID = CB_PRODUCT_RECIPE_ID.Checked
            dao_c.fields.SubProductRecipe_1 = CheckBox_SubRecipe1.Checked
            dao_c.fields.SubProductRecipe_1_1 = CheckBox_SubRecipe1_1.Checked
            dao_c.fields.SubProductRecipe_1_2 = CheckBox_SubRecipe1_2.Checked
            dao_c.fields.SubProductRecipe_2 = CheckBox_SubRecipe2.Checked
            dao_c.fields.SubProductRecipe_2_1 = CheckBox_SubRecipe2_1.Checked
            dao_c.fields.PRODUCTION_PROCESS_ID = CB_PRODUCTION_PROCESS_ID.Checked
            dao_c.fields.PROPERTIES_ID = CB_PROPERTIES_ID.Checked
            dao_c.fields.SIZE_USE_ID = CB_SIZE_USE_ID.Checked
            dao_c.fields.PREPARE_EAT_ID = CB_PREPARE_EAT_ID.Checked
            dao_c.fields.EAT_CONDITION_ID = CB_EAT_CONDITION_ID.Checked
            dao_c.fields.STORAGE_ID = CB_STORAGE_ID.Checked
            dao_c.fields.CONTAINER_PACKING_ID = CB_CONTAINER_PACKING_ID.Checked
            dao_c.fields.QUALITY_CONTROL_ID = CB_QUALITY_CONTROL_ID.Checked
            dao_c.fields.CER_LCN_ID = CB_CER_LCN_ID.Checked
            dao_c.fields.ETIQUETQ_ID = CB_ETIQUETQ_ID.Checked
            dao_c.fields.CHANNEL_SALE_ID = CB_CHANNEL_SALE_ID.Checked
            dao_c.fields.OTHER_ID = CB_OTHER.Checked
            dao_c.fields.FK_IDA = _IDA
            dao_c.insert()
        Else
            dao_c.fields.NAME_PRODUCT_ID = CB_NAME_PRODUCT_ID.Checked
            dao_c.fields.SUB_NAME_ENG = CB_NAME_ENG.Checked
            dao_c.fields.SUB_NAME_OTHER = CB_NAME_OTHER.Checked
            dao_c.fields.SUB_NAME_EXPORT = CB_NAME_EXPORT.Checked
            dao_c.fields.NAME_LOCATION_ID = CB_NAME_LOCATION_ID.Checked
            dao_c.fields.SUB_Location1_ID = CheckBox1.Checked
            dao_c.fields.SUB_Location2_ID = CheckBox2.Checked
            dao_c.fields.SUB_Location3_ID = CheckBox3.Checked
            dao_c.fields.PRODUCT_RECIPE_ID = CB_PRODUCT_RECIPE_ID.Checked
            dao_c.fields.SubProductRecipe_1 = CheckBox_SubRecipe1.Checked
            dao_c.fields.SubProductRecipe_1_1 = CheckBox_SubRecipe1_1.Checked
            dao_c.fields.SubProductRecipe_1_2 = CheckBox_SubRecipe1_2.Checked
            dao_c.fields.SubProductRecipe_2 = CheckBox_SubRecipe2.Checked
            dao_c.fields.SubProductRecipe_2_1 = CheckBox_SubRecipe2_1.Checked
            dao_c.fields.PRODUCTION_PROCESS_ID = CB_PRODUCTION_PROCESS_ID.Checked
            dao_c.fields.PROPERTIES_ID = CB_PROPERTIES_ID.Checked
            dao_c.fields.SIZE_USE_ID = CB_SIZE_USE_ID.Checked
            dao_c.fields.PREPARE_EAT_ID = CB_PREPARE_EAT_ID.Checked
            dao_c.fields.EAT_CONDITION_ID = CB_EAT_CONDITION_ID.Checked
            dao_c.fields.STORAGE_ID = CB_STORAGE_ID.Checked
            dao_c.fields.CONTAINER_PACKING_ID = CB_CONTAINER_PACKING_ID.Checked
            dao_c.fields.QUALITY_CONTROL_ID = CB_QUALITY_CONTROL_ID.Checked
            dao_c.fields.CER_LCN_ID = CB_CER_LCN_ID.Checked
            dao_c.fields.ETIQUETQ_ID = CB_ETIQUETQ_ID.Checked
            dao_c.fields.CHANNEL_SALE_ID = CB_CHANNEL_SALE_ID.Checked
            dao_c.fields.OTHER_ID = CB_OTHER.Checked
            dao_c.fields.FK_IDA = _IDA
            dao_c.Update()
        End If

    End Sub
    Sub INSERT_FILEUPLOAD(ByVal TR_ID As Integer)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        Try
            dao.GetdatabyID_FK_IDA(_IDA)
        Catch ex As Exception

        End Try
        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_EDIT_FILEUPLOAD
        Dim dao_up2 As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
        If CB_NAME_ENG.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(1)
            dao_up2.GetdatabyID_IDA(_IDA)
            'If dao_up2.fields.IDA = 0 Then
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
            'End If
        End If
        If CB_NAME_OTHER.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(2)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If
        If CB_NAME_EXPORT.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(3)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox1.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(4)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox2.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(5)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox3.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(6)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox_SubRecipe1_1.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(11)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox_SubRecipe1_2.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(12)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox_SubRecipe2_1.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(25)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_PRODUCTION_PROCESS_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(13)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_PROPERTIES_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(14)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_SIZE_USE_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(15)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_PREPARE_EAT_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(16)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_EAT_CONDITION_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(17)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_STORAGE_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(18)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_CONTAINER_PACKING_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(19)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox_SubQuality1.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(20)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If
        If CheckBox_SubQuality2.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(21)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_ETIQUETQ_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(23)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_CHANNEL_SALE_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(24)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_OTHER.Checked = True Then
            Dim DT_MASUP As New DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_main
            DT_MASUP = bao.SP_MAS_TABEAN_HERB_EDIT_UPLOADFILE(_IDA)
            'For Each DR As DataRow In DT_MASUP.Rows
            Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
            dao_d.GetdatabyID_TR_ID(TR_ID)
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DUCUMENT_NAME = dao_d.fields.FILE_NAME_OTHER
            dao_up.fields.TR_ID = TR_ID
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.PROCESS_ID = _Process_ID
                dao_up.fields.FK_IDA_LCN = _IDA_LCN
                dao_up.fields.TYPE = 1
                dao_up.insert()
            'Next
        Else
            Dim DT_MASUP As New DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_main
            DT_MASUP = bao.SP_MAS_TABEAN_HERB_EDIT_UPLOADFILE(_IDA)
            For Each DR As DataRow In DT_MASUP.Rows
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao_up.fields.DUCUMENT_NAME = DR("DUCUMENT_NAME")
                dao_up.fields.TR_ID = TR_ID
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.PROCESS_ID = _Process_ID
                dao_up.fields.FK_IDA_LCN = _IDA_LCN
                dao_up.fields.TYPE = 1
                dao_up.insert()
            Next
        End If
    End Sub
    Public Function striptags(ByVal html As String) As String
        Return Regex.Replace(html, "\s", "")
    End Function
    Public Sub Updata_data_tabean_to_BC()
        Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        Dim cls_xml As New Cls_XML
        Dim p2 As New LGT_IOW_E
        Dim xml_str As String
        Dim dao_h As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA)
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        dao_g.GetDataby_IDA(_IDA_DR)
        Try
            If dao_g.fields.rgtno IsNot Nothing Then
                dao_h.GetDataby_4Key(dao_g.fields.rgtno, dao_g.fields.rgttpcd, dao_g.fields.drgtpcd, dao_g.fields.pvncd)
            Else
                dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
            End If
            NEWCODE = dao_h.fields.Newcode
            NEWCODE_U = dao_h.fields.Newcode_U
        Catch ex As Exception
            dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
        End Try

        xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(NEWCODE)
        p2 = ConvertFromXml(Of LGT_IOW_E)(xml_str)   'ดึงไฟล์xml จาก BC


        If CB_NAME_PRODUCT_ID.Checked = True Then
            p2.XML_SEARCH_DRUG_DR.thadrgnm = dao_d.fields.NAME_THAI
            p2.XML_SEARCH_DRUG_DR.engdrgnm = dao_d.fields.NAME_ENG
        End If
        If CB_NAME_LOCATION_ID.Checked = True Then
            Dim dao_herb_lcn As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            dao_herb_lcn.GetDataby_LCN_IDA(dao_d.fields.IDA_LCN)
            Dim dao_licen_loca As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
            dao_licen_loca.GetDataby_LCN_IDA(dao_d.fields.IDA_LCN)
            If CheckBox1.Checked = True Or CheckBox2.Checked = True Then

                If CheckBox1.Checked = True Then
                    p2.XML_SEARCH_DRUG_DR.lpvncd = dao_herb_lcn.fields.pvncd
                    p2.XML_SEARCH_DRUG_DR.thanm = dao_herb_lcn.fields.thanm
                    p2.XML_SEARCH_DRUG_DR.lcnno = dao_herb_lcn.fields.lcnno
                    p2.XML_SEARCH_DRUG_DR.lcnno_no = dao_herb_lcn.fields.lcnno_no
                    p2.XML_SEARCH_DRUG_DR.lcntpcd = dao_herb_lcn.fields.lcntpcd
                    p2.XML_SEARCH_DRUG_DR.thanm_locaion = dao_herb_lcn.fields.thanm
                    p2.XML_SEARCH_DRUG_DR.licen_loca = dao_licen_loca.fields.licen
                    p2.XML_SEARCH_DRUG_DR.lcntpcd = dao_herb_lcn.fields.lcntpcd
                    p2.XML_SEARCH_DRUG_DR.fulladdr = dao_herb_lcn.fields.thanm_addr
                    p2.XML_SEARCH_DRUG_DR.thaaddr_thanm = dao_herb_lcn.fields.thaaddr
                    p2.XML_SEARCH_DRUG_DR.tharoom_thanm = dao_herb_lcn.fields.tharoom
                    p2.XML_SEARCH_DRUG_DR.thafloor_thanm = dao_herb_lcn.fields.thafloor
                    p2.XML_SEARCH_DRUG_DR.thabuilding_thanm = dao_herb_lcn.fields.thabuilding
                    p2.XML_SEARCH_DRUG_DR.thasoi_thanm = dao_herb_lcn.fields.thasoi
                    p2.XML_SEARCH_DRUG_DR.tharoad_thanm = dao_herb_lcn.fields.tharoad
                    p2.XML_SEARCH_DRUG_DR.thamu_thanm = dao_herb_lcn.fields.thamu
                    p2.XML_SEARCH_DRUG_DR.thathmblnm_thanm = dao_herb_lcn.fields.thathmblnm
                    p2.XML_SEARCH_DRUG_DR.thaamphrnm_thanm = dao_herb_lcn.fields.thaamphrnm
                    p2.XML_SEARCH_DRUG_DR.zipcode_thanm = dao_herb_lcn.fields.zipcode
                    p2.XML_SEARCH_DRUG_DR.tel_thanm = dao_herb_lcn.fields.tel
                    p2.XML_SEARCH_DRUG_DR.Newcode_not = dao_herb_lcn.fields.Newcode_not
                ElseIf CheckBox2.Checked = True Then
                    p2.XML_SEARCH_DRUG_DR.lpvncd = dao_herb_lcn.fields.pvncd
                    p2.XML_SEARCH_DRUG_DR.thanm = dao_herb_lcn.fields.thanm
                    p2.XML_SEARCH_DRUG_DR.lcnno = dao_herb_lcn.fields.lcnno
                    p2.XML_SEARCH_DRUG_DR.lcnno_no = dao_herb_lcn.fields.lcnno_no
                    p2.XML_SEARCH_DRUG_DR.lcntpcd = dao_herb_lcn.fields.lcntpcd
                    p2.XML_SEARCH_DRUG_DR.thanm_locaion = dao_herb_lcn.fields.thanm
                    p2.XML_SEARCH_DRUG_DR.licen_loca = dao_licen_loca.fields.licen
                    p2.XML_SEARCH_DRUG_DR.lcntpcd = dao_herb_lcn.fields.lcntpcd
                    p2.XML_SEARCH_DRUG_DR.fulladdr = dao_herb_lcn.fields.thanm_addr
                    p2.XML_SEARCH_DRUG_DR.thaaddr_thanm = dao_herb_lcn.fields.thaaddr
                    p2.XML_SEARCH_DRUG_DR.tharoom_thanm = dao_herb_lcn.fields.tharoom
                    p2.XML_SEARCH_DRUG_DR.thafloor_thanm = dao_herb_lcn.fields.thafloor
                    p2.XML_SEARCH_DRUG_DR.thabuilding_thanm = dao_herb_lcn.fields.thabuilding
                    p2.XML_SEARCH_DRUG_DR.thasoi_thanm = dao_herb_lcn.fields.thasoi
                    p2.XML_SEARCH_DRUG_DR.tharoad_thanm = dao_herb_lcn.fields.tharoad
                    p2.XML_SEARCH_DRUG_DR.thamu_thanm = dao_herb_lcn.fields.thamu
                    p2.XML_SEARCH_DRUG_DR.thathmblnm_thanm = dao_herb_lcn.fields.thathmblnm
                    p2.XML_SEARCH_DRUG_DR.thaamphrnm_thanm = dao_herb_lcn.fields.thaamphrnm
                    p2.XML_SEARCH_DRUG_DR.zipcode_thanm = dao_herb_lcn.fields.zipcode
                    p2.XML_SEARCH_DRUG_DR.tel_thanm = dao_herb_lcn.fields.tel
                    p2.XML_SEARCH_DRUG_DR.Newcode_not = dao_herb_lcn.fields.Newcode_not
                End If
            End If

            If CheckBox3.Checked = True Then
                p2.XML_SEARCH_DRUG_DR.engfrgnnm = dao_d.fields.FOREIGN_NAME
                p2.XML_SEARCH_DRUG_DR.engfrgnnm_addr = dao_d.fields.FOREIGN_NAME_PLACE
            End If

        End If
        Dim dt As New DataTable
        If CB_PRODUCT_RECIPE_ID.Checked = True Then
            Dim dao_recipe As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_IOWA
            dao_recipe.GetDataby_Newcode_U(NEWCODE_U)
            'p2.LGT_IOW_EQ.XML_DRUG_IOW_TYPE = dao_recipe.datas
        End If
        If CB_PRODUCTION_PROCESS_ID.Checked = True Then

        End If
        If CB_PROPERTIES_ID.Checked = True Then
            p2.XML_SEARCH_DRUG_DR.indication = dao_d.fields.PROPERTIES
        End If
        If CB_SIZE_USE_ID.Checked = True Then

        End If
        If CB_PREPARE_EAT_ID.Checked = True Then

        End If
        If CB_EAT_CONDITION_ID.Checked = True Then

        End If
        If CB_STORAGE_ID.Checked = True Then

        End If
        If CB_CONTAINER_PACKING_ID.Checked = True Then
            'dao_d.fields.SIZE_PACK = txt_SizePack_New.Te
            Dim dao_contain As New DAO_XML_DRUG_HERB.TB_XML_DRUG_CONTAIN_HERB
            dao_contain.GetDataby_Newcode(NEWCODE)
            dao_contain.fields.SUBTITLE_SIZE_DRUG = dao_d.fields.SIZE_PACK
            'p2.LGT_XML_DRUG_CONTAIN = dao_contain.datas
        End If
        If CB_QUALITY_CONTROL_ID.Checked = True Then

        End If
        If CB_ETIQUETQ_ID.Checked = True Then

        End If
        If CB_CHANNEL_SALE_ID.Checked = True Then

        End If

        'SEND_XML(p2)
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD.aspx?IDA=" & ida & "&PROCESS_ID=" & _Process_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & _IDA_DR
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub CB_NAME_ENG_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NAME_ENG.CheckedChanged
        If CB_NAME_ENG.Checked = True Then
            'DIV_NAME_ENG.Visible = True
            Panel_Name_Eng.Style.Add("display", "block")
        Else
            'DIV_NAME_ENG.Visible = False
            Panel_Name_Eng.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub CB_NAME_OTHER_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NAME_OTHER.CheckedChanged
        If CB_NAME_OTHER.Checked = True Then
            'DIV_NAME_OTHER.Visible = True
            Panel_Name_Other.Style.Add("display", "block")
        Else
            'DIV_NAME_OTHER.Visible = False
            Panel_Name_Other.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub CB_NAME_EXPORT_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NAME_EXPORT.CheckedChanged
        If CB_NAME_EXPORT.Checked = True Then
            'DIV_NAME_EXPORT.Visible = True
            Panel_Name_Export.Style.Add("display", "block")
        Else
            'DIV_NAME_EXPORT.Visible = False
            Panel_Name_Export.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Panel_cheng_Location.Style.Add("display", "block")
            CheckBox2.Enabled = False
        Else
            Panel_cheng_Location.Style.Add("display", "none")
            CheckBox2.Enabled = True
        End If
    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Panel_cheng_Location2.Style.Add("display", "block")
            CheckBox1.Enabled = False
        Else
            Panel_cheng_Location2.Style.Add("display", "none")
            CheckBox1.Enabled = True
        End If
    End Sub

    Protected Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Panel_cheng_Location3.Style.Add("display", "block")
        Else
            Panel_cheng_Location3.Style.Add("display", "none")
        End If
    End Sub
    Protected Sub BTN_SEARCH_LCN_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_LCN.Click
        If txt_lcnno.Text IsNot "" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            Dim dao_lo As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            Dim lcntpcd As String = ""
            Dim bao_dal As New BAO_SHOW
            Dim dt_lcn As New DataTable
            If CheckBox1.Checked = True Then
                lcntpcd = "ผสม"
            ElseIf CheckBox2.Checked = True Then
                lcntpcd = "นสม"
            End If
            dao.GetDataby_pvncd_lcnno_lcntpcd(ddl_Province.SelectedValue, txt_lcnno.Text, lcntpcd)
            Try
                IDA_LCN_NEW = dao.fields.IDA
                dao_lo.GetDataby_IDA(dao.fields.FK_IDA)
            Catch ex As Exception

            End Try
            dt_lcn = bao_dal.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.IDA)
            For Each dr As DataRow In dt_lcn.Rows
                Try
                    lbl_Full_addr.Text = dr("fulladdr")
                Catch ex As Exception

                End Try
            Next
            lbl_lcntpcd_new.Text = dao.fields.lcntpcd
            lbl_name_location.Text = dao_lo.fields.thanameplace
            lbl_name_thanm.Text = dao.fields.syslcnsnm_prefixnm & " " & dao.fields.syslcnsnm_thanm & " " & dao.fields.syslcnsnm_thalnm
            If dao.fields.LCNNO_DISPLAY_NEW IsNot Nothing Then
                lbl_lcnno_display_new.Text = dao.fields.LCNNO_DISPLAY_NEW
            Else
                lbl_lcnno_display_new.Text = dao.fields.LCNNO_DISPLAY
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลก่อนค้นหา');", True)
        End If

    End Sub
    Protected Sub BTN_SEARCH_LCN2_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_LCN2.Click
        If txt_lcnno2.Text IsNot "" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            Dim dao_lo As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            Dim lcntpcd As String = ""
            Dim bao_dal As New BAO_SHOW
            Dim dt_lcn As New DataTable
            If CheckBox1.Checked = True Then
                lcntpcd = "ผสม"
            ElseIf CheckBox2.Checked = True Then
                lcntpcd = "นสม"
            End If
            dao.GetDataby_pvncd_lcnno_lcntpcd(ddl_Province2.SelectedValue, txt_lcnno2.Text, lcntpcd)
            Try
                IDA_LCN_NEW = dao.fields.IDA
                dao_lo.GetDataby_IDA(dao.fields.FK_IDA)
            Catch ex As Exception

            End Try
            dt_lcn = bao_dal.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.IDA)
            For Each dr As DataRow In dt_lcn.Rows
                Try
                    lbl_Full_addr2.Text = dr("fulladdr")
                Catch ex As Exception

                End Try
            Next
            lbl_lcntpcd_new2.Text = dao.fields.lcntpcd
            lbl_name_location2.Text = dao_lo.fields.thanameplace
            lbl_name_thanm2.Text = dao.fields.syslcnsnm_prefixnm & " " & dao.fields.syslcnsnm_thanm & " " & dao.fields.syslcnsnm_thalnm
            If dao.fields.LCNNO_DISPLAY_NEW IsNot Nothing Then
                lbl_lcnno_display_new2.Text = dao.fields.LCNNO_DISPLAY_NEW
                LCNNO_NEW = dao.fields.LCNNO_DISPLAY_NEW
            Else
                lbl_lcnno_display_new2.Text = dao.fields.LCNNO_DISPLAY
                LCNNO_NEW = dao.fields.LCNNO_DISPLAY
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลก่อนค้นหา');", True)
        End If

    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_frgn()
        'RadGrid1.Rebind()
    End Sub

    Sub Search_frgn()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_syspdcfrgn_SEARCH(txt_search.Text)

        RadGrid1.DataSource = dt
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        If txt_search.Text <> "" Then
            Search_frgn()
        End If
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim frgncd As Integer = 0
            Dim PLACE_NAME_THAI As String = ""
            Dim PLACE_NAME_ENG As String = ""

            PLACE_IDA = item("IDA").Text
            PLACE_NAME_THAI = item("thafrgnnm").Text
            PLACE_NAME_ENG = item("engfrgnnm").Text

            PLACE_NAME = PLACE_NAME_ENG & " " & PLACE_NAME_THAI
            txt_search.Text = PLACE_NAME
            txt_search_ida.Text = PLACE_IDA

            Try
                frgncd = item("frgncd").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dt As New DataTable
                Dim bao As New BAO_SHOW
                dt = bao.SP_drfrgnaddr_BY_frgncd(frgncd)
                HiddenField1.Value = frgncd
                RadGrid2.DataSource = dt
                RadGrid2.Rebind()
            End If

        End If
    End Sub
    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "sel" Then
                IDA_ADDRESS = item("IDA").Text
                PLACE_ADDRESS = item("fulladdr2").Text

                'txt_address.Text = PLACE_ADDRESS
                txt_address_New.Text = PLACE_ADDRESS
                txt_address_ida.Text = IDA_ADDRESS
                txt_address_New.Text.ToUpper()
            End If
        End If
    End Sub
    Protected Sub CB_NAME_PRODUCT_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NAME_PRODUCT_ID.CheckedChanged
        If CB_NAME_PRODUCT_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PRODUCTION_PROCESS_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            DV_NAME_SL.Visible = True
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PRODUCTION_PROCESS_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            DV_NAME_SL.Visible = False
        End If
    End Sub

    Protected Sub CB_NAME_LOCATION_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NAME_LOCATION_ID.CheckedChanged
        If CB_NAME_LOCATION_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PRODUCTION_PROCESS_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            'CB_CHANNEL_SALE_ID.Enabled = False
            Div_NAME_LOCATION.Visible = True
            Div_NAME_LOCATION.Visible = True
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PRODUCTION_PROCESS_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            'Div_NAME_LOCATION.Visible = False
            Div_NAME_LOCATION.Visible = False
        End If
    End Sub

    Protected Sub CB_PRODUCT_RECIPE_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PRODUCT_RECIPE_ID.CheckedChanged
        If CB_PRODUCT_RECIPE_ID.Checked = True Then
            PANEL_PRODUCT_RECIPE.Style.Add("display", "block")
            insert_iowa_tabean_edit()
            UC_TABEAN_EDIT_DETAIL_CAS.rg_chem_Rebind()
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCTION_PROCESS_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCTION_PROCESS_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            PANEL_PRODUCT_RECIPE.Style.Add("display", "none")

        End If
    End Sub
    Sub insert_iowa_tabean_edit()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EDIT_DETAIL_CAS
        dao.GetDataby_FKIDA(_IDA)
        Dim dao_iow124 As New DAO_XML_DRUG_HERB.TB_XML_DRUG_IOW_HERB
        dao_iow124.GetDataby_Newcode_U(NEWCODE_U)
        Dim dao_iow168 As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_IOWA
        dao_iow168.GetDataby_Newcode_U(NEWCODE_U)
        If dao.fields.IDA = 0 Then
            If dao_iow124.fields.IDA <> 0 Then
                For Each dao_iow124.fields In dao_iow124.datas
                    Dim DAO_NEW As New DAO_TABEAN_HERB.TB_TABEAN_EDIT_DETAIL_CAS
                    DAO_NEW.fields.FK_IDA = _IDA
                    DAO_NEW.fields.FK_IDA_DG = _IDA_DR
                    DAO_NEW.fields.ROWS = dao_iow124.fields.rid
                    DAO_NEW.fields.IOWA = dao_iow124.fields.iowacd
                    DAO_NEW.fields.IOWANM = dao_iow124.fields.iowanm
                    DAO_NEW.fields.AORI = dao_iow124.fields.aori
                    DAO_NEW.fields.BASE_FORM = dao_iow124.fields.qtytxt_all
                    DAO_NEW.fields.QTY = dao_iow124.fields.qty
                    DAO_NEW.fields.REMARK = dao_iow124.fields.remark
                    DAO_NEW.fields.register = dao_iow124.fields.register
                    DAO_NEW.fields.FK_SET = dao_iow124.fields.flineno
                    DAO_NEW.fields.Newcode_U = NEWCODE_U
                    DAO_NEW.fields.FK_DETAIL_CAS = dao_iow124.fields.IDA_DRRGT_DETAIL_CAS
                    DAO_NEW.insert()
                Next
            End If
        End If

        If dao_iow168.fields.IDA = 0 Then
            If dao_iow124.fields.IDA <> 0 Then
                For Each dao_iow124.fields In dao_iow124.datas
                    Dim DAO_IOWA_NEW As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_IOWA
                    DAO_IOWA_NEW.fields.FK_IDA = _IDA
                    DAO_IOWA_NEW.fields.FK_IDA_DRRGT = _IDA_DR
                    DAO_IOWA_NEW.fields.pvncd = dao_iow124.fields.pvncd
                    DAO_IOWA_NEW.fields.drgtpcd = dao_iow124.fields.drgtpcd
                    DAO_IOWA_NEW.fields.rgttpcd = dao_iow124.fields.rgttpcd
                    DAO_IOWA_NEW.fields.rgtno = dao_iow124.fields.rgtno
                    DAO_IOWA_NEW.fields.rgtno = dao_iow124.fields.rgtno
                    DAO_IOWA_NEW.fields.register = dao_iow124.fields.register
                    DAO_IOWA_NEW.fields.lcnsid = dao_iow124.fields.lcnsid
                    DAO_IOWA_NEW.fields.CITIZEN_AUTHORIZE = dao_iow124.fields.CITIZEN_AUTHORIZE
                    DAO_IOWA_NEW.fields.flineno = dao_iow124.fields.flineno
                    DAO_IOWA_NEW.fields.drgqty = dao_iow124.fields.drgqty
                    DAO_IOWA_NEW.fields.drgperunit = dao_iow124.fields.drgperunit
                    DAO_IOWA_NEW.fields.drgcdt = dao_iow124.fields.drgcdt
                    DAO_IOWA_NEW.fields.thadsgnm = dao_iow124.fields.thadsgnm
                    DAO_IOWA_NEW.fields.thadsgnm = dao_iow124.fields.thadsgnm
                    DAO_IOWA_NEW.fields.rid = dao_iow124.fields.rid
                    DAO_IOWA_NEW.fields.iowacd = dao_iow124.fields.iowacd
                    DAO_IOWA_NEW.fields.iowanm = dao_iow124.fields.iowanm
                    DAO_IOWA_NEW.fields.SinggleContent = dao_iow124.fields.SinggleContent
                    DAO_IOWA_NEW.fields.UnitForSinggleContent = dao_iow124.fields.UnitForSinggleContent
                    DAO_IOWA_NEW.fields.qtytxt_all = dao_iow124.fields.qtytxt_all
                    DAO_IOWA_NEW.fields.qtytxt = dao_iow124.fields.qtytxt
                    DAO_IOWA_NEW.fields.qty = dao_iow124.fields.qty
                    DAO_IOWA_NEW.fields.qty_y = dao_iow124.fields.qty_y
                    DAO_IOWA_NEW.fields.sunitengnm = dao_iow124.fields.sunitengnm
                    DAO_IOWA_NEW.fields.thadrgnm = dao_iow124.fields.thadrgnm
                    DAO_IOWA_NEW.fields.engdrgnm = dao_iow124.fields.engdrgnm
                    DAO_IOWA_NEW.fields.engdrgnm = dao_iow124.fields.engdrgnm
                    DAO_IOWA_NEW.fields.aori = dao_iow124.fields.aori
                    DAO_IOWA_NEW.fields.remark = dao_iow124.fields.remark
                    DAO_IOWA_NEW.fields.aori_description = dao_iow124.fields.aori_description
                    DAO_IOWA_NEW.fields.cncnm = dao_iow124.fields.cncnm
                    DAO_IOWA_NEW.fields.licen_loca = dao_iow124.fields.licen_loca
                    DAO_IOWA_NEW.fields.Newcode_rid = dao_iow124.fields.Newcode_rid
                    DAO_IOWA_NEW.fields.Newcode_R = dao_iow124.fields.Newcode_R
                    DAO_IOWA_NEW.fields.Newcode_U = dao_iow124.fields.Newcode_U
                    DAO_IOWA_NEW.fields.RoleinFomular = dao_iow124.fields.RoleinFomular
                    DAO_IOWA_NEW.fields.ConditionContent = dao_iow124.fields.ConditionContent
                    DAO_IOWA_NEW.fields.MultiplyNumberStart = dao_iow124.fields.MultiplyNumberStart
                    DAO_IOWA_NEW.fields.BaseNumberStart = dao_iow124.fields.BaseNumberStart
                    DAO_IOWA_NEW.fields.PowerNumberStart = dao_iow124.fields.PowerNumberStart
                    DAO_IOWA_NEW.fields.MultiplyNumberEND = dao_iow124.fields.MultiplyNumberEND
                    DAO_IOWA_NEW.fields.BaseNumberEND = dao_iow124.fields.BaseNumberEND
                    DAO_IOWA_NEW.fields.PowerNumberEND = dao_iow124.fields.PowerNumberEND
                    DAO_IOWA_NEW.fields.UnitForRangeContent = dao_iow124.fields.UnitForRangeContent
                    DAO_IOWA_NEW.fields.IDA_DRRGT_DETAIL_CAS = dao_iow124.fields.IDA_DRRGT_DETAIL_CAS
                    DAO_IOWA_NEW.fields.lcnno = dao_iow124.fields.lcnno
                    DAO_IOWA_NEW.insert()
                Next
            End If
        End If

        Dim dao_eqto As New DAO_DRUG.TB_DRRGT_EQTO
        dao_eqto.GetDataby_FK_DRRQT_IDA(_IDA_DR)
        Dim DAO_EQ As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_EQTO
        DAO_EQ.GetDataby_FK_DRRQT_IDA(_IDA_DR)
        If DAO_EQ.fields.IDA = 0 Then
            If dao_eqto.fields.IDA <> 0 Then
                For Each dao_eqto.fields In dao_eqto.datas
                    Dim DAO_EQNEW As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_EQTO
                    DAO_EQNEW.fields.FK_IDA = dao_eqto.fields.FK_IDA
                    DAO_EQNEW.fields.FK_SET = dao_eqto.fields.FK_SET
                    DAO_EQNEW.fields.ROWS = dao_eqto.fields.ROWS
                    DAO_EQNEW.fields.IOWA = dao_eqto.fields.IOWA
                    DAO_EQNEW.fields.QTY = dao_eqto.fields.QTY
                    DAO_EQNEW.fields.MULTIPLY = dao_eqto.fields.MULTIPLY
                    DAO_EQNEW.fields.STR_VALUE = dao_eqto.fields.STR_VALUE
                    DAO_EQNEW.fields.SUNITCD = dao_eqto.fields.SUNITCD
                    DAO_EQNEW.fields.aori = dao_eqto.fields.aori
                    DAO_EQNEW.fields.FK_DRRQT_IDA = dao_eqto.fields.FK_DRRQT_IDA
                    DAO_EQNEW.fields.FK_SET = dao_eqto.fields.FK_SET
                    DAO_EQNEW.fields.QTY_END = dao_eqto.fields.QTY_END
                    DAO_EQNEW.fields.SUNITCD_END = dao_eqto.fields.SUNITCD_END
                    DAO_EQNEW.fields.REMARK = dao_eqto.fields.REMARK
                    DAO_EQNEW.fields.REF = dao_eqto.fields.REF
                    DAO_EQNEW.fields.CONDITION = dao_eqto.fields.CONDITION
                    DAO_EQNEW.insert()
                Next
            End If
        End If

    End Sub
    Protected Sub CB_PRODUCTION_PROCESS_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PRODUCTION_PROCESS_ID.CheckedChanged
        If CB_PRODUCTION_PROCESS_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            Panel_Production_Process.Style.Add("display", "block")
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            Panel_Production_Process.Style.Add("display", "none")
        End If
        insert_menufactrue()
    End Sub
    Sub insert_menufactrue()
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        dao_g.GetDataby_IDA(_IDA_DR)
        Dim dao_q As New DAO_DRUG.ClsDBdrrqt
        dao_q.GetDataby_IDA(dao_g.fields.FK_DRRQT)
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_tn.GetdatabyID_FK_IDA_DQ(dao_g.fields.FK_DRRQT)
        Catch ex As Exception

        End Try
        Dim dao_n As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_MANUFACTRUE
        Dim dao_o As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE
        dao_n.GetdatabyID_FK_IDA_DQ(dao_q.fields.IDA)
        dao_n.GetdatabyID_FK_IDA(_IDA)
        If dao_o.fields.IDA <> 0 Then
            If dao_n.fields.IDA = 0 Then
                For Each dao_o.fields In dao_o.datas
                    Dim dao_new As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_MANUFACTRUE
                    dao_new.fields.FK_IDA = _IDA
                    dao_new.fields.FK_IDA = dao_o.fields.FK_IDA_DQ
                    dao_new.fields.NO_ID = dao_o.fields.NO_ID
                    dao_new.fields.MENUFAC_ID = dao_o.fields.MENUFAC_ID
                    dao_new.fields.MENUFAC_NAME = dao_o.fields.MENUFAC_NAME
                    dao_new.fields.ACTIVEFACT = 1
                    dao_new.fields.CREATE_DATE = Date.Now
                    dao_new.fields.CREATE_USER = _CLS.THANM
                    dao_new.insert()
                Next
            End If
        End If
    End Sub
    Protected Sub CB_PROPERTIES_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PROPERTIES_ID.CheckedChanged
        If CB_PROPERTIES_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            'CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            Panel_Properties.Style.Add("display", "block")
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            Panel_Properties.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub CB_SIZE_USE_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SIZE_USE_ID.CheckedChanged
        If CB_SIZE_USE_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            Panel_Size_Use.Style.Add("display", "block")
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            Panel_Size_Use.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub CB_PREPARE_EAT_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PREPARE_EAT_ID.CheckedChanged
        If CB_PREPARE_EAT_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            Panel_Prepare_Eat.Style.Add("display", "block")
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            Panel_Prepare_Eat.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub CB_EAT_CONDITION_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_EAT_CONDITION_ID.CheckedChanged
        If CB_EAT_CONDITION_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            Panel_EatCondition.Style.Add("display", "block")
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            Panel_EatCondition.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub CB_STORAGE_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_STORAGE_ID.CheckedChanged
        If CB_STORAGE_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            Panel_Storage.Style.Add("display", "block")
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            Panel_Storage.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub CB_CONTAINER_PACKING_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_CONTAINER_PACKING_ID.CheckedChanged
        If CB_CONTAINER_PACKING_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            Panel_Container_Packing.Style.Add("display", "block")
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            Panel_Container_Packing.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub CB_QUALITY_CONTROL_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_QUALITY_CONTROL_ID.CheckedChanged
        If CB_QUALITY_CONTROL_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_CER_LCN_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_CER_LCN_ID.CheckedChanged

    End Sub

    Protected Sub CB_ETIQUETQ_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_ETIQUETQ_ID.CheckedChanged
        If CB_ETIQUETQ_ID.Checked = True Then
            'CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            bind_datatable_RG_ETIQUETQ()
            PANEL_ETIQUETQ.Style.Add("display", "block")
        Else
            'CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            PANEL_ETIQUETQ.Style.Add("display", "none")

        End If
    End Sub
    Protected Sub CB_CHANNEL_SALE_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_CHANNEL_SALE_ID.CheckedChanged
        If CB_CHANNEL_SALE_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            'CB_CHANNEL_SALE_ID.Enabled = False
            PANEL_CHANNEL_SALE.Style.Add("display", "block")
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            PANEL_CHANNEL_SALE.Style.Add("display", "none")
        End If
    End Sub
    Protected Sub CB_OTHER_CheckedChanged(sender As Object, e As EventArgs) Handles CB_OTHER.CheckedChanged
        If CB_OTHER.Checked = True Then
            Panel_OTHER.Style.Add("display", "block")
        Else
            Panel_OTHER.Style.Add("display", "none")
        End If
    End Sub
    Protected Sub btn_add_muc_add_Click(sender As Object, e As EventArgs) Handles btn_add_muc_add.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_MANUFACTRUE
        dao.fields.FK_IDA = _IDA
        dao.fields.FK_IDA_DQ = IDA_DQ
        dao.fields.NO_ID = NO_ID.Text
        If DD_MANUFAC_ID.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทกระบวนการ');", True)
        Else
            dao.fields.MENUFAC_ID = DD_MANUFAC_ID.SelectedValue
            dao.fields.MENUFAC_NAME = DD_MANUFAC_ID.SelectedItem.Text
            dao.fields.ACTIVEFACT = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_USER = _CLS.THANM
            dao.insert()
        End If
        DD_MANUFAC_ID.ClearSelection()
        NO_ID.Text = ""
        RG_PRODUCTION_PROCESS_NEW.Rebind()
        bind_manu_New()
    End Sub
    Private Sub bind_manu()
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        dao_g.GetDataby_IDA(_IDA_DR)
        Dim dao_q As New DAO_DRUG.ClsDBdrrqt
        dao_q.GetDataby_IDA(dao_g.fields.FK_DRRQT)
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_tn.GetdatabyID_FK_IDA_DQ(dao_g.fields.FK_DRRQT)
        Catch ex As Exception

        End Try
        Dim dao_manu As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE
        dao_manu.GetdatabyID_FK_IDA_DQ2(dao_q.fields.IDA)
        RG_PRODUCTION_PROCESS.DataSource = dao_manu.datas
    End Sub
    Private Sub RG_PRODUCTION_PROCESS_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_PRODUCTION_PROCESS.NeedDataSource
        bind_manu()
    End Sub
    Private Sub RG_PRODUCTION_PROCESS_NEW_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_PRODUCTION_PROCESS_NEW.NeedDataSource
        bind_manu_New()
    End Sub
    Private Sub bind_manu_New()
        Dim dao_manu As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_MANUFACTRUE
        dao_manu.GetdatabyID_FK_IDA(_IDA)
        RG_PRODUCTION_PROCESS_NEW.DataSource = dao_manu.datas
    End Sub
    Private Sub RG_PRODUCTION_PROCESS_NEW_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RG_PRODUCTION_PROCESS_NEW.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_MANUFACTRUE
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RG_PRODUCTION_PROCESS_NEW.Rebind()
            End If
        End If
    End Sub
    Private Sub RG_SIZE_PACK_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RG_SIZE_PACK.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RG_SIZE_PACK.Rebind()
            End If
        End If
    End Sub

    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
        dao_size.GetdatabyID_FK_IDA_DQ2(IDA_DQ)

        RG_SIZE_PACK.DataSource = dao_size.datas

    End Sub

    Private Sub RG_SIZE_PACK_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_SIZE_PACK.NeedDataSource
        bind_size()
    End Sub
    Private Sub RG_SIZE_PACK_NEW_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RG_SIZE_PACK_NEW.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RG_SIZE_PACK_NEW.Rebind()
            End If
        End If
    End Sub

    Private Sub bind_size_new()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK
        dao_size.GetdatabyID_FK_IDA_DQ2(IDA_DQ)

        RG_SIZE_PACK_NEW.DataSource = dao_size.datas

    End Sub

    Private Sub RG_SIZE_PACK_NEW_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_SIZE_PACK_NEW.NeedDataSource
        bind_size_new()
    End Sub
    Private Sub rg_chem_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_chem.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        Dim DDL_ID As Integer = 0

        Dim dao_iow As New DAO_XML_DRUG_HERB.TB_XML_DRUG_IOW_HERB
        dao_iow.GetDataby_Newcode_U(NEWCODE_U)
        'dt = bao.SP_TABEAN_EDIT_DETAIL_CAS_BY_FK_IDA(_IDA, DDL_ID)
        'dt = bao.SP_DRRQT_DETAIL_CAS_BY_FK_IDAV2(IDA_DQ)
        'dt = bao.SP_DRRGT_DETAIL_CAS_BY_FK_IDAV2(IDA_DQ)    
        rg_chem.DataSource = dao_iow.datas
    End Sub
    Sub bind_datatable_RG_ETIQUETQ()
        Dim bao As New BAO.AppSettings
        Dim DT As New DataTable
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(IDA_DQ)
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        dao_g.GetDataby_IDA(_IDA_DR)
        If dao_g.fields.PROCESS_ID = 1400001 Then
            Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
            Try
                dao_a.GetDataby_TR_ID_And_Process(dao_g.fields.TR_ID, dao_g.fields.PROCESS_ID)
            Catch ex As Exception

            End Try
            RG_ETIQUETQ.DataSource = dao_a.datas
            'bao._PATH_DEFAULT & "upload\" & dao_a.fields.NAME_FAKE)
        Else
            Dim TR_ID_JJ As Integer = 0
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            Dim bao_tabean As New BAO_TABEAN_HERB.tb_main
            Dim TR_ID As Integer = 0
            If IsNothing(dao.fields.TR_ID) = False Then
                TR_ID = dao.fields.TR_ID
            End If
            'DT = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_q.fields.TR_ID_JJ, 1, dao_q.fields.DDHERB)
            DT = bao_tabean.SP_TABEAN_HERB_UPLOAD_FILE_JJ_EDIT(TR_ID, 1, dao.fields.PROCESS_ID)
            RG_ETIQUETQ.DataSource = DT
        End If

        'RG_ETIQUETQ.Rebind()
        'Return DT
    End Sub

    Private Sub RG_ETIQUETQ_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_ETIQUETQ.NeedDataSource
        bind_datatable_RG_ETIQUETQ()
    End Sub
    Sub bind_datatable_RG_ETIQUETQ_NEW()
        Dim bao As New BAO.AppSettings
        Dim DT As New DataTable
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(IDA_DQ)
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        dao_g.GetDataby_IDA(_IDA_DR)
        Dim dao_edit As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao_edit.GetdatabyID_IDA(_IDA)
        Dim TR_ID_JJ As Integer = 0
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        Dim bao_tabean As New BAO_TABEAN_HERB.tb_main
        Dim TR_ID As Integer = 0
        If IsNothing(dao_edit.fields.TR_ID) = False Then
            TR_ID = dao_edit.fields.TR_ID
        End If
        Dim DC As String = "ฉลากและเอกสารกำกับผลิตภัณฑ์ที่ขอแก้ไขเปลี่ยนแปลง"
        dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE_DC2(_IDA, TR_ID, _Process_ID, 1, DC)
        'RG_ETIQUETQ_NEW.DataSource = dao_up.datas
        'RG_ETIQUETQ_NEW.Rebind()
        'Return DT
    End Sub

    'Private Sub RG_ETIQUETQ_NeedDataSource_NEW(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_ETIQUETQ_NEW.NeedDataSource
    '    bind_datatable_RG_ETIQUETQ_NEW()
    'End Sub
    'Public Sub BindTable()

    '    Dim dao_edit As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
    '    dao_edit.GetdatabyID_IDA(_IDA)
    '    Dim TR_ID As Integer = 0
    '    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
    '    Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_EDIT_FILEUPLOAD
    '    If dao_edit.fields.TR_ID <> 0 Then
    '        TR_ID = dao_edit.fields.TR_ID
    '        'dao_up.GetdatabyID_TR_ID(TR_ID_JJ)
    '        'dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(TR_ID_JJ, _PROCESS_ID, 1)
    '        'dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE(_IDA, TR_ID, _Process_ID, 1)
    '        Dim DC As String = "ฉลากและเอกสารกำกับผลิตภัณฑ์ที่ขอแก้ไขเปลี่ยนแปลง"
    '        dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE_DC2(_IDA, TR_ID, _Process_ID, 1, DC)
    '        If dao_up.fields.IDA = 0 Then
    '            If CB_ETIQUETQ_ID.Checked = True Then
    '                'dao_up_mas.Getdataby_IDgroup(23)
    '                dao_up_mas.Getdataby_DUCUMENT_NAME(DC)
    '                'dao_up.GetdatabyID_IDA(_IDA)
    '                Dim dao_up2 As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
    '                dao_up2.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE_DC(_IDA, 1, DC)
    '                If dao_up2.fields.IDA = 0 Then
    '                    dao_up2.fields.FK_IDA = _IDA
    '                    'dao_up2.fields.TR_ID = TR_ID
    '                    dao_up2.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
    '                    dao_up2.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
    '                    dao_up2.fields.Condition = dao_up_mas.fields.Condition
    '                    dao_up2.fields.IDcondition = dao_up_mas.fields.IDcondition
    '                    dao_up2.fields.REMARK = dao_up_mas.fields.REMARK
    '                    dao_up2.fields.IDgroup = dao_up_mas.fields.IDgroup
    '                    dao_up2.fields.SEQ = dao_up_mas.fields.SEQ
    '                    dao_up2.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
    '                    dao_up2.insert()
    '                End If

    '                dao_up.fields.TYPE = dao_up_mas.fields.TYPE_ID
    '                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
    '                dao_up.fields.TR_ID = dao_edit.fields.TR_ID
    '                dao_up.fields.FK_IDA_LCN = _IDA_LCN
    '                dao_up.fields.FK_IDA = _IDA
    '                dao_up.fields.PROCESS_ID = dao_edit.fields.PROCESS_ID
    '                dao_up.fields.TYPE = 1
    '                dao_up.insert()
    '            End If
    '        End If
    '        Dim rows As Integer = 1
    '        'dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE_DC2(_IDA, TR_ID, _Process_ID, 1, DC)
    '        For Each dao_up.fields In dao_up.datas
    '            Dim tr As New TableRow
    '            tr.CssClass = "rows"
    '            Dim tc As New TableCell

    '            tc = New TableCell
    '            tc.Text = rows
    '            tr.Cells.Add(tc)

    '            tc = New TableCell
    '            tc.Text = dao_up.fields.IDA
    '            tc.Style.Add("display", "none")
    '            tr.Cells.Add(tc)

    '            tc = New TableCell
    '            Try
    '                tc.Text = Replace(dao_up.fields.DUCUMENT_NAME, "\n", "<br/>")
    '            Catch ex As Exception
    '                tc.Text = dao_up.fields.DUCUMENT_NAME
    '            End Try
    '            tc.Width = 800
    '            tr.Cells.Add(tc)

    '            tc = New TableCell
    '            'tc.Text = dao_up.fields.NAME_REAL
    '            Try
    '                tc.Text = dao_up.fields.NAME_REAL
    '            Catch ex As Exception
    '                tc.Text = ""
    '            End Try
    '            tc.Width = 600
    '            tc.Style.Add("text-align", "right")
    '            tr.Cells.Add(tc)

    '            tc = New TableCell
    '            tc.Width = 80
    '            Dim img As New Image
    '            Try
    '                If dao_up.fields.NAME_REAL Is Nothing OrElse dao_up.fields.NAME_REAL = "" Then
    '                    Dim AA As String = "../Images/cancel.png"
    '                    img.ImageUrl = AA
    '                    img.Width = 20
    '                    img.Height = 20
    '                Else
    '                    Dim AA As String = "../Images/correct.png"
    '                    img.ImageUrl = AA
    '                    img.Width = 20
    '                    img.Height = 20
    '                End If
    '            Catch ex As Exception

    '            End Try
    '            tc.Controls.Add(img)
    '            tr.Cells.Add(tc)

    '            tc = New TableCell
    '            Dim f As New FileUpload
    '            f.ID = "F" & dao_up.fields.IDA
    '            tc.Controls.Add(f)
    '            tr.Cells.Add(tc)

    '            'tb_type_menu.Rows.Add(tr)
    '            rows = rows + 1
    '        Next

    '    End If

    'End Sub
    'Protected Sub btn_save_at_Click(sender As Object, e As EventArgs) Handles btn_save_at.Click

    '    Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
    '    dao.GetdatabyID_IDA(_IDA)
    '    Dim TR_ID As Integer = dao.fields.TR_ID
    '    Dim DD_HERB_PROCESS As String = _Process_ID

    '    For Each tr As TableRow In tb_type_menu.Rows
    '        Dim IDA As Integer = tr.Cells(1).Text

    '        Dim f As New FileUpload
    '        f = tr.FindControl("F" & IDA)
    '        If f.HasFile Then
    '            Dim name_real As String = f.FileName
    '            Dim Array_NAME_REAL() As String = Split(name_real, ".")
    '            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
    '            Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
    '            If exten.ToUpper = "PDF" Then
    '                Dim bao As New BAO.AppSettings
    '                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
    '                Dim Name_fake As String = "HB-" & _Process_ID & "-" & Date.Now.Year & "-" & TR_ID & "-" & IDA & ".pdf"

    '                dao_up.GetdatabyID_IDA(IDA)

    '                dao_up.fields.NAME_FAKE = Name_fake
    '                dao_up.fields.NAME_REAL = f.FileName
    '                dao_up.fields.CREATE_DATE = Date.Now
    '                dao_up.fields.FK_IDA = dao.fields.IDA
    '                '   dao_up.fields.FK_IDA_LCN = _IDA_LCN
    '                dao_up.fields.CREATE_DATE = Date.Now
    '                dao_up.fields.ACTIVE = 1

    '                Try
    '                    dao_up.fields.TR_ID = TR_ID
    '                Catch ex As Exception

    '                End Try

    '                dao_up.fields.PROCESS_ID = _Process_ID

    '                dao_up.Update()

    '                Dim paths As String = bao._PATH_XML_PDF_TABEAN_EDIT
    '                f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)

    '            Else
    '                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบเป็นไฟล์ PDF');", True)
    '                'alert_file_error(name_real & "กรุณาแนบเป็นไฟล์ PDF")
    '                'alert_no_file(name_real & "กรุณาแนบเป็นไฟล์ PDF")
    '            End If
    '        End If

    '    Next

    '    'BindTable()
    '    RG_ETIQUETQ_NEW.Rebind()
    '    'Response.Redirect(Request.Url.AbsoluteUri)
    'End Sub

    Private Function check_file()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID, _Process_ID, 1)

        Dim ck_file As Boolean = True

        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
            End If
        Next

        Return ck_file
    End Function
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub btn_size_pack_Click(sender As Object, e As EventArgs) Handles btn_size_pack.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK

        dao.fields.FK_IDA_DQ = IDA_DQ
        dao.fields.FK_IDA = _IDA

        If DD_PCAK_1.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_1.SelectedValue = "-- กรุณาเลือก --" Then '_
            'Or DD_PCAK_2.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_2.SelectedValue = "-- กรุณาเลือก --" Then ' _
            'Or DD_PCAK_3.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_3.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูล Primary Seceondary Tertiary Packaging');", True)
        Else
            dao.fields.PACK_F_ID = DD_PCAK_1.SelectedValue
            dao.fields.PACK_F_NAME = DD_PCAK_1.SelectedItem.Text
            dao.fields.NO_1 = NO_1.Text
            dao.fields.UNIT_F_ID = DD_UNIT_1.SelectedValue
            dao.fields.UNIT_F_NAME = DD_UNIT_1.SelectedItem.Text
            Try
                dao.fields.PACK_S_ID = DD_PCAK_2.SelectedValue
                dao.fields.PACK_S_NAME = DD_PCAK_2.SelectedItem.Text
                dao.fields.NO_2 = NO_2.Text
                dao.fields.UNIT_S_ID = DD_UNIT_2.SelectedValue
                dao.fields.UNIT_S_NAME = DD_UNIT_2.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_S_ID = 0
                dao.fields.PACK_S_NAME = ""
                dao.fields.NO_2 = ""
                dao.fields.UNIT_S_ID = 0
                dao.fields.UNIT_S_NAME = ""
            End Try


            Try
                dao.fields.PACK_T_ID = DD_PCAK_3.SelectedValue
                dao.fields.PACK_T_NAME = DD_PCAK_3.SelectedItem.Text
                dao.fields.NO_3 = NO_3.Text
                dao.fields.UNIT_T_ID = DD_UNIT_3.SelectedValue
                dao.fields.UNIT_T_NAME = DD_UNIT_3.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_T_ID = 0
                dao.fields.PACK_T_NAME = ""
                dao.fields.NO_3 = ""
                dao.fields.UNIT_T_ID = 0
                dao.fields.UNIT_T_NAME = ""
            End Try


            dao.fields.ACTIVEFACT = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_USER = _CLS.THANM

            dao.insert()
        End If

        DD_PCAK_1.ClearSelection()
        DD_UNIT_1.ClearSelection()
        DD_PCAK_2.ClearSelection()
        DD_UNIT_2.ClearSelection()
        DD_PCAK_3.ClearSelection()
        DD_UNIT_3.ClearSelection()
        NO_1.Text = ""
        NO_2.Text = ""
        NO_3.Text = ""

        RG_SIZE_PACK_NEW.Rebind()
    End Sub
    Sub INSERT_OLD_DATA()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''DETAIL_TABEAN''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_tabean.GetdatabyID_FK_IDA_DQ(IDA_DQ)
        Catch ex As Exception
            dao_tabean.GetdatabyID_IDA(IDA_DQ)
        End Try


        Dim dao_tabean_old As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        'dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DR)
        dao_tabean_old.GetdatabyID_FK_IDA(_IDA)
        If dao_tabean_old.fields.IDA = 0 Then
            dao_tabean_old.fields.FK_IDA = _IDA
            'dao_tabean_old.fields.FK_IDA = dao_tabean.fields.FK_IDA_DQ
            dao_tabean_old.fields.LCN_ID = dao_tabean.fields.LCN_ID
            dao_tabean_old.fields.LCNNO = dao_tabean.fields.LCNNO
            dao_tabean_old.fields.LCN_ADDR = dao_tabean.fields.LCN_ADDR
            dao_tabean_old.fields.LCN_NAME = dao_tabean.fields.LCN_NAME
            dao_tabean_old.fields.LCN_THANAMEPLACE = dao_tabean.fields.LCN_THANAMEPLACE
            dao_tabean_old.fields.CUSTOMER_IDENTIFY = dao_tabean.fields.CUSTOMER_IDENTIFY
            dao_tabean_old.fields.COMPANY_NAME = dao_tabean.fields.COMPANY_NAME
            dao_tabean_old.fields.FOREIGN_NAME_ID = dao_tabean.fields.FOREIGN_NAME_ID
            dao_tabean_old.fields.FOREIGN_NAME = dao_tabean.fields.FOREIGN_NAME
            dao_tabean_old.fields.FOREIGN_NAME_PLACE_ID = dao_tabean.fields.FOREIGN_NAME_PLACE_ID
            dao_tabean_old.fields.FOREIGN_NAME_PLACE = dao_tabean.fields.FOREIGN_NAME_PLACE
            dao_tabean_old.fields.MAIN_PROCESS_ID = dao_tabean.fields.MAIN_PROCESS_ID
            dao_tabean_old.fields.MAIN_PROCESS_NAME = dao_tabean.fields.MAIN_PROCESS_NAME
            dao_tabean_old.fields.TYPE_ID = dao_tabean.fields.TYPE_ID
            dao_tabean_old.fields.TYPE_NAME = dao_tabean.fields.TYPE_NAME
            dao_tabean_old.fields.TYPE_SUB_ID = dao_tabean.fields.TYPE_SUB_ID
            dao_tabean_old.fields.TYPE_SUB_NAME = dao_tabean.fields.TYPE_SUB_NAME
            dao_tabean_old.fields.CATEGORY_ID = dao_tabean.fields.CATEGORY_ID
            dao_tabean_old.fields.CATEGORY_NAME = dao_tabean.fields.CATEGORY_NAME
            dao_tabean_old.fields.CATEGORY_OUT_ID = dao_tabean.fields.CATEGORY_OUT_ID
            dao_tabean_old.fields.CATEGORY_OUT_NAME = dao_tabean.fields.CATEGORY_OUT_NAME
            dao_tabean_old.fields.NAME_PLACE_JJ = dao_tabean.fields.NAME_PLACE_JJ
            dao_tabean_old.fields.NAME_JJ = dao_tabean.fields.NAME_JJ
            dao_tabean_old.fields.NAME_THAI = dao_tabean.fields.NAME_THAI
            dao_tabean_old.fields.NAME_ENG = dao_tabean.fields.NAME_ENG
            dao_tabean_old.fields.NAME_OTHER = dao_tabean.fields.NAME_OTHER
            dao_tabean_old.fields.STYPE_ID = dao_tabean.fields.STYPE_ID
            dao_tabean_old.fields.STYPE_NAME = dao_tabean.fields.STYPE_NAME
            dao_tabean_old.fields.RECIPE_NAME = dao_tabean.fields.RECIPE_NAME
            dao_tabean_old.fields.RECIPE_UNIT_ID = dao_tabean.fields.RECIPE_UNIT_ID
            dao_tabean_old.fields.RECIPE_UNIT_NAME = dao_tabean.fields.RECIPE_UNIT_NAME
            dao_tabean_old.fields.ACCOUNT_NO = dao_tabean.fields.ACCOUNT_NO
            dao_tabean_old.fields.ARTICLE_NO = dao_tabean.fields.ARTICLE_NO
            dao_tabean_old.fields.PRODUCT_JJ = dao_tabean.fields.PRODUCT_JJ
            dao_tabean_old.fields.NATURE = dao_tabean.fields.NATURE
            dao_tabean_old.fields.MANUFAC_ID = dao_tabean.fields.MANUFAC_ID
            dao_tabean_old.fields.MANUFAC_NAME = dao_tabean.fields.MANUFAC_NAME
            dao_tabean_old.fields.PRODUCT_PROCESS = dao_tabean.fields.PRODUCT_PROCESS
            dao_tabean_old.fields.WEIGHT_TABLE_CAP = dao_tabean.fields.WEIGHT_TABLE_CAP
            dao_tabean_old.fields.WEIGHT_TABLE_CAP_UNIT_ID = dao_tabean.fields.WEIGHT_TABLE_CAP_UNIT_ID
            dao_tabean_old.fields.WEIGHT_TABLE_CAP_UNIT_NAME = dao_tabean.fields.WEIGHT_TABLE_CAP_UNIT_NAME
            dao_tabean_old.fields.SIZE_PACK = dao_tabean.fields.SIZE_PACK
            dao_tabean_old.fields.SYNDROME_ID = dao_tabean.fields.SYNDROME_ID
            dao_tabean_old.fields.SYNDROME_NAME = dao_tabean.fields.SYNDROME_NAME
            dao_tabean_old.fields.PROPERTIES = dao_tabean.fields.PROPERTIES
            dao_tabean_old.fields.SIZE_USE = dao_tabean.fields.SIZE_USE
            dao_tabean_old.fields.HOW_USE = dao_tabean.fields.HOW_USE
            dao_tabean_old.fields.EATTING_ID = dao_tabean.fields.EATTING_ID
            dao_tabean_old.fields.EATTING_NAME = dao_tabean.fields.EATTING_NAME
            dao_tabean_old.fields.EATTING_NAME_DETAIL = dao_tabean.fields.EATTING_NAME_DETAIL
            dao_tabean_old.fields.EATING_CONDITION_ID = dao_tabean.fields.EATING_CONDITION_ID
            dao_tabean_old.fields.EATING_CONDITION_NAME = dao_tabean.fields.EATING_CONDITION_NAME
            dao_tabean_old.fields.EATING_CONDITION_NAME_DETAIL = dao_tabean.fields.EATING_CONDITION_NAME_DETAIL
            dao_tabean_old.fields.STORAGE_ID = dao_tabean.fields.STORAGE_ID
            dao_tabean_old.fields.STORAGE_NAME = dao_tabean.fields.STORAGE_NAME
            dao_tabean_old.fields.TREATMENT = dao_tabean.fields.TREATMENT
            dao_tabean_old.fields.TREATMENT_AGE = dao_tabean.fields.TREATMENT_AGE
            dao_tabean_old.fields.TREATMENT_AGE_ID = dao_tabean.fields.TREATMENT_AGE_ID
            dao_tabean_old.fields.TREATMENT_AGE_NAME = dao_tabean.fields.TREATMENT_AGE_NAME
            dao_tabean_old.fields.TREATMENT_AGE_MONTH = dao_tabean.fields.TREATMENT_AGE_MONTH
            dao_tabean_old.fields.CONTRAINDICATION_ID = dao_tabean.fields.CONTRAINDICATION_ID
            dao_tabean_old.fields.CONTRAINDICATION_NAME = dao_tabean.fields.CONTRAINDICATION_NAME
            dao_tabean_old.fields.WARNING_TYPE_ID = dao_tabean.fields.WARNING_TYPE_ID
            dao_tabean_old.fields.WARNING_TYPE_NAME = dao_tabean.fields.WARNING_TYPE_NAME
            dao_tabean_old.fields.WARNING_ID = dao_tabean.fields.WARNING_ID
            dao_tabean_old.fields.WARNING_NAME = dao_tabean.fields.WARNING_NAME
            dao_tabean_old.fields.WARNING_SUB_ID = dao_tabean.fields.WARNING_SUB_ID
            dao_tabean_old.fields.WARNING_SUB_NAME = dao_tabean.fields.WARNING_SUB_NAME
            dao_tabean_old.fields.CAUTION_ID = dao_tabean.fields.CAUTION_ID
            dao_tabean_old.fields.CAUTION_NAME = dao_tabean.fields.CAUTION_NAME
            dao_tabean_old.fields.ADV_REACTIVETION_ID = dao_tabean.fields.ADV_REACTIVETION_ID
            dao_tabean_old.fields.ADV_REACTIVETION_NAME = dao_tabean.fields.ADV_REACTIVETION_NAME
            dao_tabean_old.fields.SALE_CHANNEL_ID = dao_tabean.fields.SALE_CHANNEL_ID
            dao_tabean_old.fields.SALE_CHANNEL_NAME = dao_tabean.fields.SALE_CHANNEL_NAME
            dao_tabean_old.fields.NOTE = dao_tabean.fields.NOTE
            dao_tabean_old.fields.ACCEPT_FORMULA_ID = dao_tabean.fields.ACCEPT_FORMULA_ID
            dao_tabean_old.fields.ACCEPT_FORMULA = dao_tabean.fields.ACCEPT_FORMULA
            dao_tabean_old.fields.ACCEPT_FORMULA_NOTE = dao_tabean.fields.ACCEPT_FORMULA_NOTE
            dao_tabean_old.fields.RGTTPCD_GROUP_ID = dao_tabean.fields.RGTTPCD_GROUP_ID
            dao_tabean_old.fields.RGTTPCD_GROUP = dao_tabean.fields.RGTTPCD_GROUP
            dao_tabean_old.fields.RGTTPCD_GROUP_ENG = dao_tabean.fields.RGTTPCD_GROUP_ENG
            dao_tabean_old.fields.OFF_REQ_ID = dao_tabean.fields.OFF_REQ_ID
            dao_tabean_old.fields.OFF_REQ = dao_tabean.fields.OFF_REQ
            dao_tabean_old.fields.DATE_OFFER = dao_tabean.fields.DATE_OFFER
            dao_tabean_old.fields.NOTE_OFFER = dao_tabean.fields.NOTE_OFFER
            dao_tabean_old.fields.OFF_OFFER_ID = dao_tabean.fields.OFF_OFFER_ID
            dao_tabean_old.fields.OFF_OFFER = dao_tabean.fields.OFF_OFFER
            dao_tabean_old.fields.DATE_APP = dao_tabean.fields.DATE_APP
            dao_tabean_old.fields.NOTE_APP = dao_tabean.fields.NOTE_APP
            dao_tabean_old.fields.OFF_APP_ID = dao_tabean.fields.OFF_APP_ID
            dao_tabean_old.fields.OFF_APP = dao_tabean.fields.OFF_APP
            dao_tabean_old.fields.NOTE_EDIT = dao_tabean.fields.NOTE_EDIT
            dao_tabean_old.fields.CITIZEN_ID_AUTHORIZE = dao_tabean.fields.CITIZEN_ID_AUTHORIZE
            dao_tabean_old.fields.CITIZEN_ID = dao_tabean.fields.CITIZEN_ID
            dao_tabean_old.fields.MENU_GROUP = dao_tabean.fields.MENU_GROUP
            dao_tabean_old.fields.TR_ID_LCN = dao_tabean.fields.TR_ID_LCN
            dao_tabean_old.fields.TR_ID = dao_tabean.fields.TR_ID
            dao_tabean_old.fields.IDA_LCN = dao_tabean.fields.IDA_LCN
            dao_tabean_old.fields.STATUS_ID = dao_tabean.fields.STATUS_ID
            dao_tabean_old.fields.DATE_YEAR = dao_tabean.fields.DATE_YEAR
            dao_tabean_old.fields.ACTIVEFACT = dao_tabean.fields.ACTIVEFACT
            dao_tabean_old.fields.CREATE_DATE = dao_tabean.fields.CREATE_DATE
            dao_tabean_old.fields.CREATE_BY = dao_tabean.fields.CREATE_BY
            dao_tabean_old.fields.UPDATE_DATE = dao_tabean.fields.UPDATE_DATE
            dao_tabean_old.fields.UPDATE_BY = dao_tabean.fields.UPDATE_BY
            dao_tabean_old.fields.NAME_CONFIRM = dao_tabean.fields.NAME_CONFIRM
            dao_tabean_old.fields.DATE_CONFIRM = dao_tabean.fields.DATE_CONFIRM
            dao_tabean_old.fields.ML_ID = dao_tabean.fields.ML_ID
            dao_tabean_old.fields.ML_NAME = dao_tabean.fields.ML_NAME
            dao_tabean_old.fields.ML_PAY = dao_tabean.fields.ML_PAY
            dao_tabean_old.fields.ML_MINUS = dao_tabean.fields.ML_MINUS
            dao_tabean_old.fields.ML_SUM = dao_tabean.fields.ML_SUM
            dao_tabean_old.fields.ML_KEY_NAME = dao_tabean.fields.ML_KEY_NAME
            dao_tabean_old.fields.ML_KEY_DATE = dao_tabean.fields.ML_KEY_DATE
            dao_tabean_old.fields.DATE_PAY1 = dao_tabean.fields.DATE_PAY1
            dao_tabean_old.fields.DATE_PAY2 = dao_tabean.fields.DATE_PAY2
            dao_tabean_old.fields.CHK_EDIT_TB1 = dao_tabean.fields.CHK_EDIT_TB1
            dao_tabean_old.fields.PRODUCER_NAME = dao_tabean.fields.PRODUCER_NAME
            dao_tabean_old.fields.PRODUCER_ID = dao_tabean.fields.PRODUCER_ID
            dao_tabean_old.fields.REF_NO = dao_tabean.fields.REF_NO
            dao_tabean_old.fields.PERSON_AGE = dao_tabean.fields.PERSON_AGE
            dao_tabean_old.fields.PERSON_AGE = dao_tabean.fields.PERSON_AGE
            dao_tabean_old.fields.NATIONALITY_PERSON = dao_tabean.fields.NATIONALITY_PERSON
            dao_tabean_old.fields.NATIONALITY_PERSON_OTHER = dao_tabean.fields.NATIONALITY_PERSON_OTHER
            dao_tabean_old.fields.AGENT_99 = dao_tabean.fields.AGENT_99
            dao_tabean_old.fields.IDEN_AGENT_99 = dao_tabean.fields.IDEN_AGENT_99
            dao_tabean_old.fields.SYNDROME_ID2 = dao_tabean.fields.SYNDROME_ID2
            dao_tabean_old.fields.SYNDROME_NAME2 = dao_tabean.fields.SYNDROME_NAME2
            dao_tabean_old.fields.TYPEPERSON = dao_tabean.fields.TYPEPERSON
            dao_tabean_old.insert()
        Else
            dao_tabean_old.fields.FK_IDA = _IDA
            dao_tabean_old.fields.LCN_ID = dao_tabean.fields.LCN_ID
            dao_tabean_old.fields.LCNNO = dao_tabean.fields.LCNNO
            dao_tabean_old.fields.LCN_ADDR = dao_tabean.fields.LCN_ADDR
            dao_tabean_old.fields.LCN_NAME = dao_tabean.fields.LCN_NAME
            dao_tabean_old.fields.LCN_THANAMEPLACE = dao_tabean.fields.LCN_THANAMEPLACE
            dao_tabean_old.fields.CUSTOMER_IDENTIFY = dao_tabean.fields.CUSTOMER_IDENTIFY
            dao_tabean_old.fields.COMPANY_NAME = dao_tabean.fields.COMPANY_NAME
            dao_tabean_old.fields.FOREIGN_NAME_ID = dao_tabean.fields.FOREIGN_NAME_ID
            dao_tabean_old.fields.FOREIGN_NAME = dao_tabean.fields.FOREIGN_NAME
            dao_tabean_old.fields.FOREIGN_NAME_PLACE_ID = dao_tabean.fields.FOREIGN_NAME_PLACE_ID
            dao_tabean_old.fields.FOREIGN_NAME_PLACE = dao_tabean.fields.FOREIGN_NAME_PLACE
            dao_tabean_old.fields.MAIN_PROCESS_ID = dao_tabean.fields.MAIN_PROCESS_ID
            dao_tabean_old.fields.MAIN_PROCESS_NAME = dao_tabean.fields.MAIN_PROCESS_NAME
            dao_tabean_old.fields.TYPE_ID = dao_tabean.fields.TYPE_ID
            dao_tabean_old.fields.TYPE_NAME = dao_tabean.fields.TYPE_NAME
            dao_tabean_old.fields.TYPE_SUB_ID = dao_tabean.fields.TYPE_SUB_ID
            dao_tabean_old.fields.TYPE_SUB_NAME = dao_tabean.fields.TYPE_SUB_NAME
            dao_tabean_old.fields.CATEGORY_ID = dao_tabean.fields.CATEGORY_ID
            dao_tabean_old.fields.CATEGORY_NAME = dao_tabean.fields.CATEGORY_NAME
            dao_tabean_old.fields.CATEGORY_OUT_ID = dao_tabean.fields.CATEGORY_OUT_ID
            dao_tabean_old.fields.CATEGORY_OUT_NAME = dao_tabean.fields.CATEGORY_OUT_NAME
            dao_tabean_old.fields.NAME_PLACE_JJ = dao_tabean.fields.NAME_PLACE_JJ
            dao_tabean_old.fields.NAME_JJ = dao_tabean.fields.NAME_JJ
            dao_tabean_old.fields.NAME_THAI = dao_tabean.fields.NAME_THAI
            dao_tabean_old.fields.NAME_ENG = dao_tabean.fields.NAME_ENG
            dao_tabean_old.fields.NAME_OTHER = dao_tabean.fields.NAME_OTHER
            dao_tabean_old.fields.STYPE_ID = dao_tabean.fields.STYPE_ID
            dao_tabean_old.fields.STYPE_NAME = dao_tabean.fields.STYPE_NAME
            dao_tabean_old.fields.RECIPE_NAME = dao_tabean.fields.RECIPE_NAME
            dao_tabean_old.fields.RECIPE_UNIT_ID = dao_tabean.fields.RECIPE_UNIT_ID
            dao_tabean_old.fields.RECIPE_UNIT_NAME = dao_tabean.fields.RECIPE_UNIT_NAME
            dao_tabean_old.fields.ACCOUNT_NO = dao_tabean.fields.ACCOUNT_NO
            dao_tabean_old.fields.ARTICLE_NO = dao_tabean.fields.ARTICLE_NO
            dao_tabean_old.fields.PRODUCT_JJ = dao_tabean.fields.PRODUCT_JJ
            dao_tabean_old.fields.NATURE = dao_tabean.fields.NATURE
            dao_tabean_old.fields.MANUFAC_ID = dao_tabean.fields.MANUFAC_ID
            dao_tabean_old.fields.MANUFAC_NAME = dao_tabean.fields.MANUFAC_NAME
            dao_tabean_old.fields.PRODUCT_PROCESS = dao_tabean.fields.PRODUCT_PROCESS
            dao_tabean_old.fields.WEIGHT_TABLE_CAP = dao_tabean.fields.WEIGHT_TABLE_CAP
            dao_tabean_old.fields.WEIGHT_TABLE_CAP_UNIT_ID = dao_tabean.fields.WEIGHT_TABLE_CAP_UNIT_ID
            dao_tabean_old.fields.WEIGHT_TABLE_CAP_UNIT_NAME = dao_tabean.fields.WEIGHT_TABLE_CAP_UNIT_NAME
            dao_tabean_old.fields.SIZE_PACK = dao_tabean.fields.SIZE_PACK
            dao_tabean_old.fields.SYNDROME_ID = dao_tabean.fields.SYNDROME_ID
            dao_tabean_old.fields.SYNDROME_NAME = dao_tabean.fields.SYNDROME_NAME
            dao_tabean_old.fields.PROPERTIES = dao_tabean.fields.PROPERTIES
            dao_tabean_old.fields.SIZE_USE = dao_tabean.fields.SIZE_USE
            dao_tabean_old.fields.HOW_USE = dao_tabean.fields.HOW_USE
            dao_tabean_old.fields.EATTING_ID = dao_tabean.fields.EATTING_ID
            dao_tabean_old.fields.EATTING_NAME = dao_tabean.fields.EATTING_NAME
            dao_tabean_old.fields.EATTING_NAME_DETAIL = dao_tabean.fields.EATTING_NAME_DETAIL
            dao_tabean_old.fields.EATING_CONDITION_ID = dao_tabean.fields.EATING_CONDITION_ID
            dao_tabean_old.fields.EATING_CONDITION_NAME = dao_tabean.fields.EATING_CONDITION_NAME
            dao_tabean_old.fields.EATING_CONDITION_NAME_DETAIL = dao_tabean.fields.EATING_CONDITION_NAME_DETAIL
            dao_tabean_old.fields.STORAGE_ID = dao_tabean.fields.STORAGE_ID
            dao_tabean_old.fields.STORAGE_NAME = dao_tabean.fields.STORAGE_NAME
            dao_tabean_old.fields.TREATMENT = dao_tabean.fields.TREATMENT
            dao_tabean_old.fields.TREATMENT_AGE = dao_tabean.fields.TREATMENT_AGE
            dao_tabean_old.fields.TREATMENT_AGE_ID = dao_tabean.fields.TREATMENT_AGE_ID
            dao_tabean_old.fields.TREATMENT_AGE_NAME = dao_tabean.fields.TREATMENT_AGE_NAME
            dao_tabean_old.fields.TREATMENT_AGE_MONTH = dao_tabean.fields.TREATMENT_AGE_MONTH
            dao_tabean_old.fields.CONTRAINDICATION_ID = dao_tabean.fields.CONTRAINDICATION_ID
            dao_tabean_old.fields.CONTRAINDICATION_NAME = dao_tabean.fields.CONTRAINDICATION_NAME
            dao_tabean_old.fields.WARNING_TYPE_ID = dao_tabean.fields.WARNING_TYPE_ID
            dao_tabean_old.fields.WARNING_TYPE_NAME = dao_tabean.fields.WARNING_TYPE_NAME
            dao_tabean_old.fields.WARNING_ID = dao_tabean.fields.WARNING_ID
            dao_tabean_old.fields.WARNING_NAME = dao_tabean.fields.WARNING_NAME
            dao_tabean_old.fields.WARNING_SUB_ID = dao_tabean.fields.WARNING_SUB_ID
            dao_tabean_old.fields.WARNING_SUB_NAME = dao_tabean.fields.WARNING_SUB_NAME
            dao_tabean_old.fields.CAUTION_ID = dao_tabean.fields.CAUTION_ID
            dao_tabean_old.fields.CAUTION_NAME = dao_tabean.fields.CAUTION_NAME
            dao_tabean_old.fields.ADV_REACTIVETION_ID = dao_tabean.fields.ADV_REACTIVETION_ID
            dao_tabean_old.fields.ADV_REACTIVETION_NAME = dao_tabean.fields.ADV_REACTIVETION_NAME
            dao_tabean_old.fields.SALE_CHANNEL_ID = dao_tabean.fields.SALE_CHANNEL_ID
            dao_tabean_old.fields.SALE_CHANNEL_NAME = dao_tabean.fields.SALE_CHANNEL_NAME
            dao_tabean_old.fields.NOTE = dao_tabean.fields.NOTE
            dao_tabean_old.fields.ACCEPT_FORMULA_ID = dao_tabean.fields.ACCEPT_FORMULA_ID
            dao_tabean_old.fields.ACCEPT_FORMULA = dao_tabean.fields.ACCEPT_FORMULA
            dao_tabean_old.fields.ACCEPT_FORMULA_NOTE = dao_tabean.fields.ACCEPT_FORMULA_NOTE
            dao_tabean_old.fields.RGTTPCD_GROUP_ID = dao_tabean.fields.RGTTPCD_GROUP_ID
            dao_tabean_old.fields.RGTTPCD_GROUP = dao_tabean.fields.RGTTPCD_GROUP
            dao_tabean_old.fields.RGTTPCD_GROUP_ENG = dao_tabean.fields.RGTTPCD_GROUP_ENG
            dao_tabean_old.fields.OFF_REQ_ID = dao_tabean.fields.OFF_REQ_ID
            dao_tabean_old.fields.OFF_REQ = dao_tabean.fields.OFF_REQ
            dao_tabean_old.fields.DATE_OFFER = dao_tabean.fields.DATE_OFFER
            dao_tabean_old.fields.NOTE_OFFER = dao_tabean.fields.NOTE_OFFER
            dao_tabean_old.fields.OFF_OFFER_ID = dao_tabean.fields.OFF_OFFER_ID
            dao_tabean_old.fields.OFF_OFFER = dao_tabean.fields.OFF_OFFER
            dao_tabean_old.fields.DATE_APP = dao_tabean.fields.DATE_APP
            dao_tabean_old.fields.NOTE_APP = dao_tabean.fields.NOTE_APP
            dao_tabean_old.fields.OFF_APP_ID = dao_tabean.fields.OFF_APP_ID
            dao_tabean_old.fields.OFF_APP = dao_tabean.fields.OFF_APP
            dao_tabean_old.fields.NOTE_EDIT = dao_tabean.fields.NOTE_EDIT
            dao_tabean_old.fields.CITIZEN_ID_AUTHORIZE = dao_tabean.fields.CITIZEN_ID_AUTHORIZE
            dao_tabean_old.fields.CITIZEN_ID = dao_tabean.fields.CITIZEN_ID
            dao_tabean_old.fields.MENU_GROUP = dao_tabean.fields.MENU_GROUP
            dao_tabean_old.fields.TR_ID_LCN = dao_tabean.fields.TR_ID_LCN
            dao_tabean_old.fields.TR_ID = dao_tabean.fields.TR_ID
            dao_tabean_old.fields.IDA_LCN = dao_tabean.fields.IDA_LCN
            dao_tabean_old.fields.STATUS_ID = dao_tabean.fields.STATUS_ID
            dao_tabean_old.fields.DATE_YEAR = dao_tabean.fields.DATE_YEAR
            dao_tabean_old.fields.ACTIVEFACT = dao_tabean.fields.ACTIVEFACT
            dao_tabean_old.fields.CREATE_DATE = dao_tabean.fields.CREATE_DATE
            dao_tabean_old.fields.CREATE_BY = dao_tabean.fields.CREATE_BY
            dao_tabean_old.fields.UPDATE_DATE = dao_tabean.fields.UPDATE_DATE
            dao_tabean_old.fields.UPDATE_BY = dao_tabean.fields.UPDATE_BY
            dao_tabean_old.fields.NAME_CONFIRM = dao_tabean.fields.NAME_CONFIRM
            dao_tabean_old.fields.DATE_CONFIRM = dao_tabean.fields.DATE_CONFIRM
            dao_tabean_old.fields.ML_ID = dao_tabean.fields.ML_ID
            dao_tabean_old.fields.ML_NAME = dao_tabean.fields.ML_NAME
            dao_tabean_old.fields.ML_PAY = dao_tabean.fields.ML_PAY
            dao_tabean_old.fields.ML_MINUS = dao_tabean.fields.ML_MINUS
            dao_tabean_old.fields.ML_SUM = dao_tabean.fields.ML_SUM
            dao_tabean_old.fields.ML_KEY_NAME = dao_tabean.fields.ML_KEY_NAME
            dao_tabean_old.fields.ML_KEY_DATE = dao_tabean.fields.ML_KEY_DATE
            dao_tabean_old.fields.DATE_PAY1 = dao_tabean.fields.DATE_PAY1
            dao_tabean_old.fields.DATE_PAY2 = dao_tabean.fields.DATE_PAY2
            dao_tabean_old.fields.CHK_EDIT_TB1 = dao_tabean.fields.CHK_EDIT_TB1
            dao_tabean_old.fields.PRODUCER_NAME = dao_tabean.fields.PRODUCER_NAME
            dao_tabean_old.fields.PRODUCER_ID = dao_tabean.fields.PRODUCER_ID
            dao_tabean_old.fields.REF_NO = dao_tabean.fields.REF_NO
            dao_tabean_old.fields.PERSON_AGE = dao_tabean.fields.PERSON_AGE
            dao_tabean_old.fields.PERSON_AGE = dao_tabean.fields.PERSON_AGE
            dao_tabean_old.fields.NATIONALITY_PERSON = dao_tabean.fields.NATIONALITY_PERSON
            dao_tabean_old.fields.NATIONALITY_PERSON_OTHER = dao_tabean.fields.NATIONALITY_PERSON_OTHER
            dao_tabean_old.fields.AGENT_99 = dao_tabean.fields.AGENT_99
            dao_tabean_old.fields.IDEN_AGENT_99 = dao_tabean.fields.IDEN_AGENT_99
            dao_tabean_old.fields.SYNDROME_ID2 = dao_tabean.fields.SYNDROME_ID2
            dao_tabean_old.fields.SYNDROME_NAME2 = dao_tabean.fields.SYNDROME_NAME2
            dao_tabean_old.fields.TYPEPERSON = dao_tabean.fields.TYPEPERSON
            dao_tabean_old.Update()
        End If
    End Sub
End Class