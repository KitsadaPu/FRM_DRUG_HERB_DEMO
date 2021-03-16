Public Class POPUP_STAFF_LCN_REQUEST
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    ' Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _IDA_DAL_FIX As String
    Private _IDA_DAL As String
    ' Private _id_lcn As String


    Sub RunQuery()
        _IDA = Request.QueryString("id")
        _IDA_DAL_FIX = Request.QueryString("ID_DAL_FIX")
        Dim dao As New DAO_DRUG.ClsDBdalcn_fix
        dao.GetDataby_IDA(_IDA_DAL_FIX)
        With dao.fields
            _ProcessID = .PROCESS_ID
            _iden = .syslcnsnm_identify
            _lct_ida = .LOCATION_ADDRESS_IDA
            _IDA_DAL = .FK_DALCN
        End With

        Session("Process") = _ProcessID
        Session("lct_ida") = _lct_ida
        Session("identify") = _iden
        Session("ID_DAL_FIX") = _IDA_DAL_FIX
        Session("_IDA_DAL") = _IDA_DAL
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBlcn_request
        dao.GetDataby_id(Request.QueryString("id"))
        dao.fields.STATUS = DropDownList1.SelectedValue
        If DropDownList1.SelectedValue = 5 Then
            dao.fields.rcbno = 0
        ElseIf DropDownList1.SelectedValue = 99 Then
            Dim bao As New BAO.ClsDBSqlcommand
            bao.SP_UPDATE_CLONE(_IDA_DAL_FIX)

            Dim dao_keep As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            dao_keep.GetDataby_FK(_IDA_DAL)
            For Each item In dao_keep.Details
                Dim dao_keep_update As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                dao_keep_update.GetDataby_IDA(item.IDA)
                dao_keep_update.fields.ACTIVE = 0
                dao_keep_update.update()
            Next
            Dim dao_keep_fix As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP_FIX
            dao_keep_fix.GetDataby_BY_FK(_IDA_DAL_FIX)
            For Each item In dao_keep_fix.Details
                Dim dao_wait As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                With dao_wait.fields
                    .IDA = item.IDA
                    .LCN_IDA = item.LCN_IDA
                    .LOCATION_IDA = item.LOCATION_IDA
                    .IDENTIFY = item.IDENTIFY
                    .TR_ID = item.TR_ID
                    .FK_IDA = _IDA_DAL
                    .LOCATION_ADDRESS_thanameplace = item.LOCATION_ADDRESS_thanameplace
                    .LOCATION_ADDRESS_thaaddr = item.LOCATION_ADDRESS_thaaddr
                    .LOCATION_ADDRESS_thasoi = item.LOCATION_ADDRESS_thasoi
                    .LOCATION_ADDRESS_tharoad = item.LOCATION_ADDRESS_tharoad
                    .LOCATION_ADDRESS_thamu = item.LOCATION_ADDRESS_thamu
                    .LOCATION_ADDRESS_thathmblnm = item.LOCATION_ADDRESS_thathmblnm
                    .LOCATION_ADDRESS_thaamphrnm = item.LOCATION_ADDRESS_thaamphrnm
                    .LOCATION_ADDRESS_thachngwtnm = item.LOCATION_ADDRESS_thachngwtnm
                    .LOCATION_ADDRESS_tel = item.LOCATION_ADDRESS_tel
                    .LOCATION_ADDRESS_fax = item.LOCATION_ADDRESS_fax
                    .LOCATION_ADDRESS_lcnsid = item.LOCATION_ADDRESS_lcnsid
                    .LOCATION_ADDRESS_engaddr = item.LOCATION_ADDRESS_engaddr
                    .LOCATION_ADDRESS_tharoom = item.LOCATION_ADDRESS_tharoom
                    .LOCATION_ADDRESS_thafloor = item.LOCATION_ADDRESS_thafloor
                    .LOCATION_ADDRESS_thabuilding = item.LOCATION_ADDRESS_thabuilding
                    .LOCATION_ADDRESS_engsoi = item.LOCATION_ADDRESS_engsoi
                    .LOCATION_ADDRESS_engroad = item.LOCATION_ADDRESS_engroad
                    .LOCATION_ADDRESS_zipcode = item.LOCATION_ADDRESS_zipcode
                    .LOCATION_ADDRESS_lstfcd = item.LOCATION_ADDRESS_lstfcd
                    .LOCATION_ADDRESS_lmdfdate = item.LOCATION_ADDRESS_lmdfdate
                    .LOCATION_ADDRESS_IDA = item.LOCATION_ADDRESS_IDA
                    .LOCATION_ADDRESS_FK_IDA = item.LOCATION_ADDRESS_FK_IDA
                    .LOCATION_ADDRESS_TR_ID = item.LOCATION_ADDRESS_TR_ID
                    .LOCATION_ADDRESS_DOWN_ID = item.LOCATION_ADDRESS_DOWN_ID
                    .LOCATION_ADDRESS_CITIZEN_ID = item.LOCATION_ADDRESS_CITIZEN_ID
                    .LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = item.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD
                    .LOCATION_ADDRESS_XMLNAME = item.LOCATION_ADDRESS_XMLNAME
                    .LOCATION_ADDRESS_engmu = item.LOCATION_ADDRESS_engmu
                    .LOCATION_ADDRESS_engfloor = item.LOCATION_ADDRESS_engfloor
                    .LOCATION_ADDRESS_engbuilding = item.LOCATION_ADDRESS_engbuilding
                    .LOCATION_ADDRESS_rcvno = item.LOCATION_ADDRESS_rcvno
                    .LOCATION_ADDRESS_rcvdate = item.LOCATION_ADDRESS_rcvdate
                    .LOCATION_ADDRESS_lctcd = item.LOCATION_ADDRESS_lctcd
                    .LOCATION_ADDRESS_engnameplace = item.LOCATION_ADDRESS_engnameplace
                    .LOCATION_ADDRESS_STATUS_ID = item.LOCATION_ADDRESS_STATUS_ID
                    .LOCATION_ADDRESS_HOUSENO = item.LOCATION_ADDRESS_HOUSENO
                    .LOCATION_ADDRESS_Branch = item.LOCATION_ADDRESS_Branch
                    .LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = item.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL
                    .LOCATION_ADDRESS_LOCATION_TYPE_OTHER = item.LOCATION_ADDRESS_LOCATION_TYPE_OTHER
                    .LOCATION_ADDRESS_LOCATION_TYPE_ID = item.LOCATION_ADDRESS_LOCATION_TYPE_ID
                    .LOCATION_ADDRESS_SYSTEM_NAME = item.LOCATION_ADDRESS_SYSTEM_NAME
                    .LOCATION_ADDRESS_thmblcd = item.LOCATION_ADDRESS_thmblcd
                    .LOCATION_ADDRESS_chngwtcd = item.LOCATION_ADDRESS_chngwtcd
                    .LOCATION_ADDRESS_engthmblnm = item.LOCATION_ADDRESS_engthmblnm
                    .LOCATION_ADDRESS_engamphrnm = item.LOCATION_ADDRESS_engamphrnm
                    .LOCATION_ADDRESS_engchngwtnm = item.LOCATION_ADDRESS_engchngwtnm
                    .LOCATION_ADDRESS_IDENTIFY = item.LOCATION_ADDRESS_IDENTIFY
                    .LOCATION_ADDRESS_REMARK = item.LOCATION_ADDRESS_REMARK
                    .LOCATION_ADDRESS_Mobile = item.LOCATION_ADDRESS_Mobile
                    .LOCATION_ADDRESS_amphrcd = item.LOCATION_ADDRESS_amphrcd
                    '.ACTIVE = item.ACTIVE



                End With
                If (item.FK_KEEP_IDA Is Nothing) Then
                    Dim dao_keep_insert As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                    dao_keep_insert.fields = dao_wait.fields
                    dao_keep_insert.fields.ACTIVE = 1
                    dao_keep_insert.insert()
                Else
                    Dim dao_keep_update As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                    dao_keep_update.GetDataby_IDA(item.FK_KEEP_IDA)
                    dao_keep_update.fields.ACTIVE = 1
                    dao_keep_update.update()
                End If
            Next

            Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr.GetDataby_FK_IDA(_IDA_DAL)

            For Each item In dao_phr.Details
                Dim dao_phr_update As New DAO_DRUG.ClsDBDALCN_PHR
                dao_phr_update.GetDataby_IDA(item.PHR_IDA)
                dao_phr_update.fields.ACTIVE = 0
                dao_phr_update.update()
            Next
            Dim dao_phr_fix As New DAO_DRUG.ClsDBDALCN_PHR_FIX
            dao_phr_fix.GetDataby_BY_FK(_IDA_DAL_FIX)
            For Each item In dao_phr_fix.Details
                Dim dao_wait As New DAO_DRUG.ClsDBDALCN_PHR
                With dao_wait.fields
                    .PHR_IDA = item.PHR_IDA
                    .PHR_NAME = item.PHR_NAME
                    .PHR_SURNAME = item.PHR_SURNAME
                    .PHR_CTZNO = item.PHR_CTZNO
                    .PHR_LEVEL = item.PHR_LEVEL
                    .TRANSECTION_ID_UPLOAD = item.TRANSECTION_ID_UPLOAD
                    .CTZNO_UPLOAD = item.CTZNO_UPLOAD
                    .PHR_STATUS_UPLOAD = item.PHR_STATUS_UPLOAD
                    .PHR_CHK_JOB = item.PHR_CHK_JOB
                    .PHR_TEXT_JOB = item.PHR_TEXT_JOB
                    .PHR_CHK_NUM = item.PHR_CHK_NUM
                    .PHR_TEXT_NUM = item.PHR_TEXT_NUM
                    .PHR_TEXT_DAY = item.PHR_TEXT_DAY
                    .PHR_TEXT_MOUTH = item.PHR_TEXT_MOUTH
                    .PHR_TEXT_YEAR = item.PHR_TEXT_YEAR
                    .PHR_TEXT_EXP = item.PHR_TEXT_EXP
                    .PHR_CHK_NOT_WORK = item.PHR_CHK_NOT_WORK
                    .PHR_CHK_WORK = item.PHR_CHK_WORK
                    .PHR_TEXT_WORK_OFFICE = item.PHR_TEXT_WORK_OFFICE
                    .PHR_TEXT_WORK_TIME = item.PHR_TEXT_WORK_TIME
                    .PHR_JOB_TYPE = item.PHR_JOB_TYPE
                    .TR_ID = item.TR_ID
                    .FK_IDA = _IDA_DAL
                    .PHR_PREFIX_ID = item.PHR_PREFIX_ID
                    .PHR_PREFIX_NAME = item.PHR_PREFIX_NAME
                    .PHR_VETERINARY_FIELD = item.PHR_VETERINARY_FIELD
                    .PHR_MEDICAL_TYPE = item.PHR_MEDICAL_TYPE
                    .PHR_CERTIFICATE_TRAINING = item.PHR_CERTIFICATE_TRAINING
                    .PHR_LAW_SECTION = item.PHR_LAW_SECTION
                    .POSITION_NAME = item.POSITION_NAME
                    .POSITION_IDA = item.POSITION_IDA
                    .IS_ACTIVE = item.IS_ACTIVE
                    .pvncd = item.pvncd
                    .lcntpcd = item.lcntpcd
                    .lcnno = item.lcnno
                    .phrcd = item.phrcd
                    .phrid = item.phrid
                    .phr_status = item.phr_status
                    .INACTIVE_DATE = item.INACTIVE_DATE
                    .PERSONAL_TYPE = item.PERSONAL_TYPE
                    .STUDY_LEVEL = item.STUDY_LEVEL
                    .NAME_SIMINAR = item.NAME_SIMINAR
                    .SIMINAR_DATE = item.SIMINAR_DATE
                    .addr_status = item.addr_status
                    '.ACTIVE = item.ACTIVE


                End With
                If (item.FK_PHR_IDA Is Nothing) Then
                    Dim dao_phr_insert As New DAO_DRUG.ClsDBDALCN_PHR
                    dao_phr_insert.fields = dao_wait.fields
                    dao_phr_insert.fields.ACTIVE = 1
                    dao_phr_insert.insert()
                Else
                    Dim dao_phr_update As New DAO_DRUG.ClsDBDALCN_PHR
                    dao_phr_update.GetDataby_IDA(item.FK_PHR_IDA)
                    dao_phr_update.fields.ACTIVE = 1
                    dao_phr_update.update()
                End If
            Next
        Else dao.fields.rcbno = 1
        End If
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');parent.close_modal();", True)

    End Sub
End Class