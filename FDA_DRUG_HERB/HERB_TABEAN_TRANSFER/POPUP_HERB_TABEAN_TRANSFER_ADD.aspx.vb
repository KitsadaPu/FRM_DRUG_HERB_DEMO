Public Class POPUP_HERB_TABEAN_TRANSFER_ADD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA_DQ As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA As String = ""
    Private _TR_ID As String = ""
    Private _SID As String = ""
    Private _PROCESS_ID As String = ""
    Private _PROCESS_ID_DQ As String = ""
    Private _IDA_TBN_NEW As String = ""

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
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_DQ = Request.QueryString("IDA_DQ")
        _IDA = Request.QueryString("IDA")
        _SID = Request.QueryString("SID")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _PROCESS_ID_DQ = Request.QueryString("PROCESS_ID_DQ")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim IDA_QT As Integer = 0
        Dim IDA_TN As Integer = 0
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_TRANSFER
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Try
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection(_PROCESS_ID)
            _TR_ID = TR_ID
        Catch ex As Exception

        End Try
        IDA_QT = Insert_DRRQT()
        IDA_TN = Insert_TabeanNew(IDA_QT)
        'dao.fields.PROCESS_ID = _Process_ID
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CREATE_BY = _CLS.THANM
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.YEAR = con_year(Date.Now().Year())
        dao.fields.STATUS_ID = 1
        dao.fields.ACTIVEFACT = 1
        dao.fields.FK_DRRQT = IDA_QT
        dao.fields.FK_IDA = IDA_QT
        dao.fields.FK_TABEAN_HERB = IDA_TN
        dao.fields.TR_ID = TR_ID
        dao.Update()


        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        dao_up_mas.GetdatabyID_TYPE(7)
        For Each dao_up_mas.fields In dao_up_mas.datas
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DOCUMENT_NAME = dao_up_mas.fields.DOCUMENT_NAME
            dao_up.fields.TR_ID = TR_ID
            dao_up.fields.PROCESS_ID = _PROCESS_ID_DQ
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.TYPE = 1
            dao_up.insert()
        Next
        alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", _IDA, _PROCESS_ID_DQ)
    End Sub
    Public Function Insert_TabeanNew(ByVal IDA_TBN As Integer)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Dim dao_tabean2 As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean2.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        With dao_tabean.fields
            .FK_IDA_DQ = IDA_TBN
            Try
                .LCN_ID = dao_tabean2.fields.LCN_ID
            Catch ex As Exception

            End Try
            .LCNNO = dao_tabean2.fields.LCNNO
            .LCN_ADDR = dao_tabean2.fields.LCN_ADDR
            .LCN_NAME = dao_tabean2.fields.LCN_NAME
            .LCN_THANAMEPLACE = dao_tabean2.fields.LCN_THANAMEPLACE
            .CUSTOMER_IDENTIFY = dao_tabean2.fields.CUSTOMER_IDENTIFY
            .COMPANY_NAME = dao_tabean2.fields.COMPANY_NAME
            Try
                .FOREIGN_NAME_ID = dao_tabean2.fields.FOREIGN_NAME_ID
                .FOREIGN_NAME = dao_tabean2.fields.FOREIGN_NAME
                .FOREIGN_NAME_PLACE_ID = dao_tabean2.fields.FOREIGN_NAME_PLACE_ID
                .FOREIGN_NAME_PLACE = dao_tabean2.fields.FOREIGN_NAME_PLACE
            Catch ex As Exception

            End Try
            Try
                .MAIN_PROCESS_ID = dao_tabean2.fields.MAIN_PROCESS_ID
                .MAIN_PROCESS_NAME = dao_tabean2.fields.MAIN_PROCESS_NAME
                .TYPE_ID = dao_tabean2.fields.TYPE_ID
                .TYPE_NAME = dao_tabean2.fields.TYPE_NAME
            Catch ex As Exception

            End Try
            Try
                .TYPE_SUB_ID = dao_tabean2.fields.TYPE_SUB_ID
                .TYPE_SUB_NAME = dao_tabean2.fields.TYPE_SUB_NAME
                .CATEGORY_ID = dao_tabean2.fields.CATEGORY_ID
                .CATEGORY_NAME = dao_tabean2.fields.CATEGORY_NAME
                .CATEGORY_OUT_ID = dao_tabean2.fields.CATEGORY_OUT_ID
                .CATEGORY_OUT_NAME = dao_tabean2.fields.CATEGORY_OUT_NAME
            Catch ex As Exception

            End Try
            .NAME_PLACE_JJ = dao_tabean2.fields.NAME_PLACE_JJ
            .NAME_JJ = dao_tabean2.fields.NAME_JJ
            .NAME_THAI = dao_tabean2.fields.NAME_THAI
            .NAME_ENG = dao_tabean2.fields.NAME_ENG
            .NAME_OTHER = dao_tabean2.fields.NAME_OTHER
            .STYPE_ID = dao_tabean2.fields.STYPE_ID
            .STYPE_NAME = dao_tabean2.fields.STYPE_NAME
            .RECIPE_NAME = dao_tabean2.fields.RECIPE_NAME
            .RECIPE_UNIT_ID = dao_tabean2.fields.RECIPE_UNIT_ID
            .RECIPE_UNIT_NAME = dao_tabean2.fields.RECIPE_UNIT_NAME
            .ACCOUNT_NO = dao_tabean2.fields.ACCOUNT_NO
            .ARTICLE_NO = dao_tabean2.fields.ARTICLE_NO
            .PRODUCT_JJ = dao_tabean2.fields.PRODUCT_JJ
            .NATURE = dao_tabean2.fields.NATURE
            Try
                .MANUFAC_ID = dao_tabean2.fields.MANUFAC_ID
                .MANUFAC_NAME = dao_tabean2.fields.MANUFAC_NAME
            Catch ex As Exception

            End Try
            .PRODUCT_PROCESS = dao_tabean2.fields.PRODUCT_PROCESS
            .WEIGHT_TABLE_CAP = dao_tabean2.fields.WEIGHT_TABLE_CAP
            Try
                .WEIGHT_TABLE_CAP_UNIT_ID = dao_tabean2.fields.WEIGHT_TABLE_CAP_UNIT_ID
                .WEIGHT_TABLE_CAP_UNIT_NAME = dao_tabean2.fields.WEIGHT_TABLE_CAP_UNIT_NAME
            Catch ex As Exception

            End Try
            .SIZE_PACK = dao_tabean2.fields.SIZE_PACK
            Try
                .PROPERTIES = dao_tabean2.fields.PROPERTIES
                .SYNDROME_ID = dao_tabean2.fields.SYNDROME_ID
                .SYNDROME_NAME = dao_tabean2.fields.SYNDROME_NAME
            Catch ex As Exception

            End Try
            .SIZE_USE = dao_tabean2.fields.SIZE_USE
            .HOW_USE = dao_tabean2.fields.HOW_USE
            Try
                .EATTING_ID = dao_tabean2.fields.EATTING_ID
                .EATTING_NAME = dao_tabean2.fields.EATTING_NAME
                .EATTING_NAME_DETAIL = dao_tabean2.fields.EATTING_NAME_DETAIL
            Catch ex As Exception

            End Try
            Try
                .EATING_CONDITION_ID = dao_tabean2.fields.EATING_CONDITION_ID
                .EATING_CONDITION_NAME = dao_tabean2.fields.EATING_CONDITION_NAME
                .EATING_CONDITION_NAME_DETAIL = dao_tabean2.fields.EATING_CONDITION_NAME_DETAIL
            Catch ex As Exception

            End Try
            Try
                .STORAGE_ID = dao_tabean2.fields.STORAGE_ID
                .STORAGE_NAME = dao_tabean2.fields.STORAGE_NAME
            Catch ex As Exception

            End Try
            Try
                .TREATMENT = dao_tabean2.fields.TREATMENT
                .TREATMENT_AGE = dao_tabean2.fields.TREATMENT_AGE
                .TREATMENT_AGE_ID = dao_tabean2.fields.TREATMENT_AGE_ID
                .TREATMENT_AGE_NAME = dao_tabean2.fields.TREATMENT_AGE_NAME
                .TREATMENT_AGE_MONTH = dao_tabean2.fields.TREATMENT_AGE_MONTH
            Catch ex As Exception

            End Try
            Try
                .CONTRAINDICATION_ID = dao_tabean2.fields.CONTRAINDICATION_ID
                .CONTRAINDICATION_NAME = dao_tabean2.fields.CONTRAINDICATION_NAME
            Catch ex As Exception

            End Try
            Try
                .WARNING_TYPE_ID = dao_tabean2.fields.WARNING_TYPE_ID
                .WARNING_TYPE_NAME = dao_tabean2.fields.WARNING_TYPE_NAME
            Catch ex As Exception

            End Try
            Try
                .WARNING_ID = dao_tabean2.fields.WARNING_ID
                .WARNING_NAME = dao_tabean2.fields.WARNING_NAME
            Catch ex As Exception

            End Try
            Try
                .WARNING_SUB_ID = dao_tabean2.fields.WARNING_SUB_ID
                .WARNING_SUB_NAME = dao_tabean2.fields.WARNING_SUB_NAME
            Catch ex As Exception

            End Try
            Try
                .CAUTION_ID = dao_tabean2.fields.CAUTION_ID
                .CAUTION_NAME = dao_tabean2.fields.CAUTION_NAME
            Catch ex As Exception

            End Try
            Try
                .ADV_REACTIVETION_ID = dao_tabean2.fields.ADV_REACTIVETION_ID
                .ADV_REACTIVETION_NAME = dao_tabean2.fields.ADV_REACTIVETION_ID
            Catch ex As Exception

            End Try
            Try
                .SALE_CHANNEL_ID = dao_tabean2.fields.SALE_CHANNEL_ID
            Catch ex As Exception

            End Try
            .SALE_CHANNEL_NAME = dao_tabean2.fields.SALE_CHANNEL_NAME
            .NOTE = dao_tabean2.fields.NOTE
            Try
                .ACCEPT_FORMULA_ID = dao_tabean2.fields.ACCEPT_FORMULA_ID
            Catch ex As Exception

            End Try
            .ACCEPT_FORMULA = dao_tabean2.fields.ACCEPT_FORMULA
            .ACCEPT_FORMULA_NOTE = dao_tabean2.fields.ACCEPT_FORMULA_NOTE
            Try
                .RGTTPCD_GROUP_ID = dao_tabean2.fields.RGTTPCD_GROUP_ID
            Catch ex As Exception

            End Try
            .RGTTPCD_GROUP = dao_tabean2.fields.RGTTPCD_GROUP
            .RGTTPCD_GROUP_ENG = dao_tabean2.fields.RGTTPCD_GROUP_ENG
            '.DATE_REQ = dao_tabean2.fields.DATE_REQ
            '.OFF_REQ_ID = dao_tabean2.fields.OFF_REQ_ID
            '.OFF_REQ = dao_tabean2.fields.OFF_REQ
            '.DATE_OFFER = dao_tabean2.fields.DATE_OFFER
            '.NOTE_OFFER = dao_tabean2.fields.NOTE_OFFER
            '.OFF_OFFER_ID = dao_tabean2.fields.OFF_OFFER_ID
            '.OFF_OFFER = dao_tabean2.fields.OFF_OFFER
            '.DATE_APP = dao_tabean2.fields.DATE_APP
            '.NOTE_APP = dao_tabean2.fields.NOTE_APP
            '.OFF_APP_ID = dao_tabean2.fields.OFF_APP_ID
            '.OFF_APP = dao_tabean2.fields.OFF_APP
            '.NOTE_EDIT = dao_tabean2.fields.NOTE_EDIT
            .CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            .CITIZEN_ID = _CLS.CITIZEN_ID
            .MENU_GROUP = dao_tabean2.fields.MENU_GROUP
            .TR_ID_LCN = dao_tabean2.fields.TR_ID_LCN
            .TR_ID = _TR_ID
            '.IDA_LCN = dao_tabean2.fields.IDA_LCN
            .STATUS_ID = 1
            '.DATE_YEAR = dao_tabean2.fields.DATE_YEAR
            .ACTIVEFACT = dao_tabean2.fields.ACTIVEFACT
            '.CREATE_DATE = dao_tabean2.fields.CREATE_DATE
            '.CREATE_BY = dao_tabean2.fields.CREATE_BY
            '.UPDATE_DATE = dao_tabean2.fields.UPDATE_DATE
            '.UPDATE_BY = dao_tabean2.fields.UPDATE_BY
            '.NAME_CONFIRM = dao_tabean2.fields.NAME_CONFIRM
            '.DATE_CONFIRM = dao_tabean2.fields.DATE_CONFIRM
            '.ML_ID = dao_tabean2.fields.ML_ID
            '.ML_NAME = dao_tabean2.fields.ML_NAME
            '.ML_PAY = dao_tabean2.fields.ML_PAY
            '.ML_MINUS = dao_tabean2.fields.ML_MINUS
            '.ML_SUM = dao_tabean2.fields.ML_SUM
            '.ML_KEY_NAME = dao_tabean2.fields.ML_KEY_NAME
            '.ML_KEY_DATE = dao_tabean2.fields.ML_KEY_DATE
            '.DATE_PAY1 = dao_tabean2.fields.DATE_PAY1
            '.DATE_PAY2 = dao_tabean2.fields.DATE_PAY2
            .CHK_EDIT_TB1 = dao_tabean2.fields.CHK_EDIT_TB1
            .PRODUCER_NAME = dao_tabean2.fields.PRODUCER_NAME
            .PRODUCER_ID = dao_tabean2.fields.PRODUCER_ID
            .REF_NO = dao_tabean2.fields.PERSON_AGE
            .PERSON_AGE = dao_tabean2.fields.PERSON_AGE
            .NATIONALITY_PERSON_ID = dao_tabean2.fields.NATIONALITY_PERSON_ID
            .NATIONALITY_PERSON = dao_tabean2.fields.NATIONALITY_PERSON
            .NATIONALITY_PERSON_OTHER = dao_tabean2.fields.NATIONALITY_PERSON_OTHER
            .AGENT_99 = dao_tabean2.fields.AGENT_99
            .IDEN_AGENT_99 = dao_tabean2.fields.IDEN_AGENT_99
            .SYNDROME_ID2 = dao_tabean2.fields.SYNDROME_ID2
            .SYNDROME_NAME2 = dao_tabean2.fields.SYNDROME_NAME2
            .TYPEPERSON = dao_tabean2.fields.TYPEPERSON
            .ACTIVEFACT = 1
        End With
        dao_tabean.insert()

        dao_tabean2.fields.STATUS_ID = 78
        'dao_tabean2.fields.can = "ยกเลิกคำขอเนื่องจากมีการขอใหม่แบบอ้างอิง(transfer)"
        dao_tabean2.Update()
        Return dao_tabean.fields.IDA
    End Function
    Public Function Insert_DRRQT()
        Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
        'dao_drrqt.GetDataby_FK_IDA(_IDA_DQ)
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA_DQ)
        With dao_drrqt.fields
            .pvncd = dao.fields.pvncd
            .drgtpcd = dao.fields.drgtpcd
            .rgttpcd = dao.fields.rgttpcd
            .rcvno = dao.fields.rcvno
            .rcvdate = dao.fields.rcvdate
            .docno = dao.fields.docno
            .pvnabbr = dao.fields.lpvncd
            .lpvncd = dao.fields.lpvncd
            .lcntpcd = dao.fields.lcntpcd
            .lcnno = dao.fields.lcnno
            .lcnsid = dao.fields.lcnsid
            .lcnscd = dao.fields.lcnscd
            .lctnmcd = dao.fields.lctnmcd
            .lctcd = dao.fields.lctcd
            .thadrgnm = dao.fields.thadrgnm
            .engdrgnm = dao.fields.engdrgnm
            .potency = dao.fields.potency
            .ctgcd = dao.fields.ctgcd
            .kindcd = dao.fields.kindcd
            .ndrgtp = dao.fields.ndrgtp
            .accttp = dao.fields.accttp
            .classcd = dao.fields.classcd
            .dsgcd = dao.fields.dsgcd
            .packcd = dao.fields.packcd
            .rsbstfcd = dao.fields.rsbstfcd
            .drgexpst = dao.fields.drgexpst
            .drgbiost = dao.fields.drgbiost
            .drgnewst = dao.fields.drgnewst
            .fdano = dao.fields.fdano
            .cnsdcd = dao.fields.cnsdcd
            .cnsddate = dao.fields.cnsddate
            .appdate = dao.fields.appdate
            .cscd = dao.fields.cscd
            .lcnabbr = dao.fields.lcnabbr
            .rgtdrgtpcd = dao.fields.rgtdrgtpcd
            .rgtno = dao.fields.rgtno
            .jpctpcd = dao.fields.jpctpcd
            .rqttpcd = dao.fields.rqttpcd
            .cndno = dao.fields.cndno
            .feepayst = dao.fields.feepayst
            .dvcd = dao.fields.dvcd
            .feetpcd = dao.fields.feetpcd
            .feeno = dao.fields.feeno
            .chngdrgtpcd = dao.fields.chngdrgtpcd
            .lstfcd = dao.fields.lstfcd
            .lmdfdate = dao.fields.lmdfdate
            .REMARK = dao.fields.REMARK
            .FK_LCN_IDA = dao.fields.FK_LCN_IDA
            .FK_REGIS = dao.fields.FK_REGIS
            .TR_ID = _TR_ID
            .FK_IDA = dao.fields.FK_IDA
            .STATUS_ID = dao.fields.STATUS_ID
            .CTZNO = _CLS.CITIZEN_ID_AUTHORIZE
            .CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            .REMARK1 = dao.fields.REMARK1
            .IDENTIFY = dao.fields.IDENTIFY
            .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            .PROCESS_ID = dao.fields.PROCESS_ID
            .FK_DRRQT = dao.fields.FK_DRRQT
            .TABEAN_TYPE = dao.fields.TABEAN_TYPE
            .CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            .CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            .CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            .EXTEND_DATE = dao.fields.EXTEND_DATE
            .FK_DOSAGE_FORM = dao.fields.FK_DOSAGE_FORM
            '.FIRST_APP_DATE = dao.fields.FIRST_APP_DATE
            '.CONSIDER_DATE = dao.fields.CONSIDER_DATE
            .FK_STAFF_OFFER_IDA = dao.fields.FK_STAFF_OFFER_IDA
            .drgtpcd_rcv = dao.fields.drgtpcd_rcv
            .STAFF_APP_IDENTIFY = dao.fields.STAFF_APP_IDENTIFY
            .REGIST_TYPE = dao.fields.REGIST_TYPE
            .R_NO = dao.fields.R_NO
            .C_NO = dao.fields.C_NO
            .A_NO = dao.fields.A_NO
            .YOR8_FK_IDA = dao.fields.YOR8_FK_IDA
            .TYPE_REQUEST_ID = dao.fields.TYPE_REQUEST_ID
            .AMOUNT = dao.fields.AMOUNT
            .AMOUNT_CAL = dao.fields.AMOUNT_CAL
            .DRUG_STYLE = dao.fields.DRUG_STYLE
            .UNIT_NORMAL = dao.fields.UNIT_NORMAL
            .UNIT_BIO = dao.fields.UNIT_BIO
            .DRUG_PACKING = dao.fields.DRUG_PACKING
            .DRUG_COLOR = dao.fields.DRUG_COLOR
            .TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
            .TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
            .STAFF_RCV_IDENTIFY = dao.fields.STAFF_RCV_IDENTIFY
            .PACKAGE_DETAIL = dao.fields.PACKAGE_DETAIL
            .FK_TRANSFER = _IDA
            .TRANSFER_TYPE = 1
            .SIGN_NAME = dao.fields.SIGN_NAME
            .SIGN_IDENTIFY = dao.fields.SIGN_IDENTIFY
            .pvnabbr2 = dao.fields.pvnabbr2
            .USE_PVNABBR2 = dao.fields.USE_PVNABBR2
            .TYPE_TBN = dao.fields.TYPE_TBN
            .STATUS_ID = 1
            '.ESTIMATE_BY = dao.fields.ESTIMATE_BY
            '.ESTIMATE_NAME_BY = dao.fields.ESTIMATE_NAME_BY
            '.ESTIMATE_DATE = dao.fields.ESTIMATE_DATE
            '.NOTE_ESTIMATE = dao.fields.NOTE_ESTIMATE
            '.NOTE_APPROVE = dao.fields.NOTE_APPROVE
            '.NOTE_EDIT = dao.fields.NOTE_EDIT
            '.EDIT_RQ_ID = dao.fields.EDIT_RQ_ID
            '.EDIT_RQ_NAME = dao.fields.EDIT_RQ_NAME
            '.EDIT_RQ_DATE = dao.fields.EDIT_RQ_DATE
            .STAFF_OFFER_NAME = dao.fields.STAFF_OFFER_NAME
            .RGTNO_NEW = dao.fields.RGTNO_NEW
            '.STAFF_RCV_NAME = dao.fields.STAFF_RCV_NAME
            '.NAME_CONFIRM = dao.fields.NAME_CONFIRM
            '.DATE_CONFIRM = dao.fields.DATE_CONFIRM
            .DATE_PAY1 = dao.fields.DATE_PAY1
            .DATE_PAY2 = dao.fields.DATE_PAY2
            '.STAFF_RCV_ID = dao.fields.STAFF_RCV_ID
            .rgttpcd_id = dao.fields.rgttpcd_id
            .NOTE_EDIT2 = dao.fields.NOTE_EDIT2
            .EDIT_RQ2_ID = dao.fields.EDIT_RQ2_ID
            .EDIT_RQ2_NAME = dao.fields.EDIT_RQ2_NAME
            .EDIT_RQ2_DATE = dao.fields.EDIT_RQ2_DATE
            .INOFFICE_STAFF_ID = dao.fields.INOFFICE_STAFF_ID
            .INOFFICE_STAFF_CITIZEN_ID = dao.fields.INOFFICE_STAFF_CITIZEN_ID
            .CHK_EDIT_TB1 = dao.fields.CHK_EDIT_TB1
            .NOTE_EDIT_TB1 = dao.fields.NOTE_EDIT_TB1
            .CHK_UPLOAD_TB = dao.fields.CHK_UPLOAD_TB
            .RCVNO_OLD = dao.fields.RCVNO_OLD
            .WHO_ID = dao.fields.WHO_ID
            .HerbFromNarcotics_ID = dao.fields.HerbFromNarcotics_ID
            .HerbFromNarcotics_Name = dao.fields.HerbFromNarcotics_Name
        End With
        dao_drrqt.insert()

        dao.fields.STATUS_ID = 78
        dao.fields.REMARK = "ยกเลิกคำขอเนื่องจากมีการขอใหม่แบบอ้างอิง(transfer)"
        dao.update()
        Return dao_drrqt.fields.IDA
    End Function
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer, ByVal Process_ID As Integer)
        Dim url As String = ""
        url = "POPUP_HERB_TABEAN_TRANSFER_UPLOAD.aspx?IDA=" & ida & "&PROCESS_ID=" & Process_ID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
End Class