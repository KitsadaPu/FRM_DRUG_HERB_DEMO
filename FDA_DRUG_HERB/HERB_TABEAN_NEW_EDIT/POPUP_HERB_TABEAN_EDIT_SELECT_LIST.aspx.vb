Public Class POPUP_HERB_TABEAN_EDIT_SELECT_LIST
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
            Get_data()
        End If
    End Sub
    Sub Get_data()
        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        'dao.GetdatabyID_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        dao.GetdatabyID_FK_IDA(_IDA)
        'UC_TABEAN_EDIT_SELECT_LIST.get_data_tabean()
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA)
        Dim dao_qt As New DAO_DRUG.ClsDBdrrqt
        dao_qt.GetDataby_IDA(_IDA_DR)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        UC_TABEAN_EDIT_SELECT_LIST.SAVE_DATA()
            dao.fields.PAGE_ID = 2
            Try
                If IsNothing(TR_ID) = False Then
                    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                    bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                    TR_ID = bao_tran.insert_transection(_Process_ID)
                    dao.fields.TR_ID = TR_ID
                End If
            Catch ex As Exception

            End Try

            dao.fields.pvncd = dao_qt.fields.pvncd
            dao.fields.drgtpcd = dao_qt.fields.drgtpcd
            dao.fields.rgttpcd = dao_qt.fields.rgttpcd
            dao.fields.pvnabbr = dao_qt.fields.pvnabbr
            dao.fields.thadrgnm = dao_qt.fields.thadrgnm
            dao.fields.engdrgnm = dao_qt.fields.engdrgnm
            dao.fields.cnsdcd = dao_qt.fields.cnsdcd
            dao.fields.cnsddate = dao_qt.fields.cnsddate
        'dao.fields.cscd = dao_qt.fields.cscd
        dao.fields.rqttpcd = dao_qt.fields.rqttpcd
            dao.fields.FK_REGIS = dao_qt.fields.FK_REGIS
        dao.fields.CTZNO = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

        dao.Update()
        'Get_data()
        If dao_d.fields.IDA = 0 Then
                dao_d.fields.CITIZEN_ID = _CLS.CITIZEN_ID
                dao_d.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao_d.fields.ACTIVEFACT = 1
                dao_d.fields.TR_ID = TR_ID
                dao_d.fields.FK_IDA = _IDA
            dao_d.insert()
            'INSERT_OLD_DATA(dao_d.fields.IDA)
        Else
                dao_d.fields.CITIZEN_ID = _CLS.CITIZEN_ID
                dao_d.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao_d.fields.ACTIVEFACT = 1
                dao_d.fields.TR_ID = TR_ID
                dao_d.fields.FK_IDA = _IDA
                dao_d.Update()
            End If
        UC_TABEAN_EDIT_SELECT_LIST.INSERT_FILEUPLOAD(TR_ID)
        'alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", dao.fields.IDA)
        Response.Redirect("POPUP_HERB_TABEAN_EDIT_DETAIL.aspx?IDA=" & _IDA & "&PROCESS_ID=" & _Process_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & _IDA_DR)



    End Sub

    Sub INSERT_OLD_DATA(ByVal IDA As String)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''DETAIL_TABEAN''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean.GetdatabyID_IDA(_IDA_DR)

        Dim dao_tabean_old As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DR)
        If IsNothing(dao_tabean_old.fields.IDA) = True Then
            dao_tabean_old.fields.FK_IDA = dao_tabean.fields.FK_IDA_DQ
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
            dao_tabean.fields.OFF_REQ_ID = dao_tabean.fields.OFF_REQ_ID
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
            dao_tabean_old.fields.FK_IDA = dao_tabean.fields.FK_IDA_DQ
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
            dao_tabean.fields.OFF_REQ_ID = dao_tabean.fields.OFF_REQ_ID
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


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''SIZE_PACK''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim dao_sp As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
        Dim dao_sp_old As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLD
        dao_sp_old.GetdatabyID_FK_IDA_DQ(_IDA_DR)
        If IsNothing(dao_tabean_old.fields.IDA) = True Then
            For Each dao_sp.fields In dao_sp.datas
                Dim dao_sp_old2 As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLD
                dao_sp_old2.fields.FK_IDA_DQ = dao_sp.fields.FK_IDA_DQ
                dao_sp_old2.fields.PACK_F_ID = dao_sp.fields.PACK_F_ID
                dao_sp_old2.fields.PACK_F_NAME = dao_sp.fields.PACK_F_NAME
                dao_sp_old2.fields.NO_1 = dao_sp.fields.NO_1
                dao_sp_old2.fields.UNIT_F_ID = dao_sp.fields.UNIT_F_ID
                dao_sp_old2.fields.UNIT_F_NAME = dao_sp.fields.UNIT_F_NAME
                dao_sp_old2.fields.PACK_S_ID = dao_sp.fields.PACK_S_ID
                dao_sp_old2.fields.PACK_S_NAME = dao_sp.fields.PACK_S_NAME
                dao_sp_old2.fields.NO_2 = dao_sp.fields.NO_2
                dao_sp_old2.fields.UNIT_S_ID = dao_sp.fields.UNIT_S_ID
                dao_sp_old2.fields.UNIT_S_NAME = dao_sp.fields.UNIT_S_NAME
                dao_sp_old2.fields.PACK_T_ID = dao_sp.fields.PACK_T_ID
                dao_sp_old2.fields.PACK_T_NAME = dao_sp.fields.PACK_T_NAME
                dao_sp_old2.fields.NO_3 = dao_sp.fields.NO_3
                dao_sp_old2.fields.UNIT_T_ID = dao_sp.fields.UNIT_T_ID
                dao_sp_old2.fields.UNIT_T_NAME = dao_sp.fields.UNIT_T_NAME
                dao_sp_old2.fields.ACTIVEFACT = dao_sp.fields.ACTIVEFACT
                dao_sp_old2.fields.CREATE_DATE = dao_sp.fields.CREATE_DATE
                dao_sp_old2.fields.CREATE_USER = dao_sp.fields.CREATE_USER
                dao_sp_old2.insert()

                Dim dao_sp_edit As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK
                dao_sp_edit.fields.FK_IDA = dao_sp.fields.FK_IDA_DQ
                dao_sp_edit.fields.PACK_F_ID = dao_sp.fields.PACK_F_ID
                dao_sp_edit.fields.PACK_F_NAME = dao_sp.fields.PACK_F_NAME
                dao_sp_edit.fields.NO_1 = dao_sp.fields.NO_1
                dao_sp_edit.fields.UNIT_F_ID = dao_sp.fields.UNIT_F_ID
                dao_sp_edit.fields.UNIT_F_NAME = dao_sp.fields.UNIT_F_NAME
                dao_sp_edit.fields.PACK_S_ID = dao_sp.fields.PACK_S_ID
                dao_sp_edit.fields.PACK_S_NAME = dao_sp.fields.PACK_S_NAME
                dao_sp_edit.fields.NO_2 = dao_sp.fields.NO_2
                dao_sp_edit.fields.UNIT_S_ID = dao_sp.fields.UNIT_S_ID
                dao_sp_edit.fields.UNIT_S_NAME = dao_sp.fields.UNIT_S_NAME
                dao_sp_edit.fields.PACK_T_ID = dao_sp.fields.PACK_T_ID
                dao_sp_edit.fields.PACK_T_NAME = dao_sp.fields.PACK_T_NAME
                dao_sp_edit.fields.NO_3 = dao_sp.fields.NO_3
                dao_sp_edit.fields.UNIT_T_ID = dao_sp.fields.UNIT_T_ID
                dao_sp_edit.fields.UNIT_T_NAME = dao_sp.fields.UNIT_T_NAME
                dao_sp_edit.fields.ACTIVEFACT = dao_sp.fields.ACTIVEFACT
                dao_sp_edit.fields.CREATE_DATE = dao_sp.fields.CREATE_DATE
                dao_sp_edit.fields.CREATE_USER = dao_sp.fields.CREATE_USER
                dao_sp_edit.insert()
            Next
        Else
            For Each dao_sp.fields In dao_sp.datas
                Dim dao_sp_old2 As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLD
                dao_sp_old2.fields.FK_IDA_DQ = dao_sp.fields.FK_IDA_DQ
                dao_sp_old2.fields.PACK_F_ID = dao_sp.fields.PACK_F_ID
                dao_sp_old2.fields.PACK_F_NAME = dao_sp.fields.PACK_F_NAME
                dao_sp_old2.fields.NO_1 = dao_sp.fields.NO_1
                dao_sp_old2.fields.UNIT_F_ID = dao_sp.fields.UNIT_F_ID
                dao_sp_old2.fields.UNIT_F_NAME = dao_sp.fields.UNIT_F_NAME
                dao_sp_old2.fields.PACK_S_ID = dao_sp.fields.PACK_S_ID
                dao_sp_old2.fields.PACK_S_NAME = dao_sp.fields.PACK_S_NAME
                dao_sp_old2.fields.NO_2 = dao_sp.fields.NO_2
                dao_sp_old2.fields.UNIT_S_ID = dao_sp.fields.UNIT_S_ID
                dao_sp_old2.fields.UNIT_S_NAME = dao_sp.fields.UNIT_S_NAME
                dao_sp_old2.fields.PACK_T_ID = dao_sp.fields.PACK_T_ID
                dao_sp_old2.fields.PACK_T_NAME = dao_sp.fields.PACK_T_NAME
                dao_sp_old2.fields.NO_3 = dao_sp.fields.NO_3
                dao_sp_old2.fields.UNIT_T_ID = dao_sp.fields.UNIT_T_ID
                dao_sp_old2.fields.UNIT_T_NAME = dao_sp.fields.UNIT_T_NAME
                dao_sp_old2.fields.ACTIVEFACT = dao_sp.fields.ACTIVEFACT
                dao_sp_old2.fields.CREATE_DATE = dao_sp.fields.CREATE_DATE
                dao_sp_old2.fields.CREATE_USER = dao_sp.fields.CREATE_USER
                dao_sp_old2.insert()

                Dim dao_sp_edit As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK
                dao_sp_edit.fields.FK_IDA = dao_sp.fields.FK_IDA_DQ
                dao_sp_edit.fields.PACK_F_ID = dao_sp.fields.PACK_F_ID
                dao_sp_edit.fields.PACK_F_NAME = dao_sp.fields.PACK_F_NAME
                dao_sp_edit.fields.NO_1 = dao_sp.fields.NO_1
                dao_sp_edit.fields.UNIT_F_ID = dao_sp.fields.UNIT_F_ID
                dao_sp_edit.fields.UNIT_F_NAME = dao_sp.fields.UNIT_F_NAME
                dao_sp_edit.fields.PACK_S_ID = dao_sp.fields.PACK_S_ID
                dao_sp_edit.fields.PACK_S_NAME = dao_sp.fields.PACK_S_NAME
                dao_sp_edit.fields.NO_2 = dao_sp.fields.NO_2
                dao_sp_edit.fields.UNIT_S_ID = dao_sp.fields.UNIT_S_ID
                dao_sp_edit.fields.UNIT_S_NAME = dao_sp.fields.UNIT_S_NAME
                dao_sp_edit.fields.PACK_T_ID = dao_sp.fields.PACK_T_ID
                dao_sp_edit.fields.PACK_T_NAME = dao_sp.fields.PACK_T_NAME
                dao_sp_edit.fields.NO_3 = dao_sp.fields.NO_3
                dao_sp_edit.fields.UNIT_T_ID = dao_sp.fields.UNIT_T_ID
                dao_sp_edit.fields.UNIT_T_NAME = dao_sp.fields.UNIT_T_NAME
                dao_sp_edit.fields.ACTIVEFACT = dao_sp.fields.ACTIVEFACT
                dao_sp_edit.fields.CREATE_DATE = dao_sp.fields.CREATE_DATE
                dao_sp_edit.fields.CREATE_USER = dao_sp.fields.CREATE_USER
                dao_sp_edit.Update()
            Next
        End If

        '''''''''''''''''''''''''''''''''SIZE_PACK''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD.aspx?IDA=" & ida & "&PROCESS_ID=" & _Process_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & _IDA_DR
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class