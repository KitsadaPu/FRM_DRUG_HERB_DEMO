Public Class POPUP_HERB_TABEAN_INFORM_EDIT_ADD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA_IF As String = ""
    Private _LCNNO_DISPLAY As String = ""
    Private _PROCESS_ID As String = ""
    Private _SID As String = ""

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception


        End Try
            _IDA_LCT = Request.QueryString("IDA_LCT")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_IF = Request.QueryString("IDA_IF")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _SID = Request.QueryString("SID")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_EDIT
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_EDIT_DETAIL
        Dim dao_l As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_EDIT_CHECK_LIST
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        UC_INFORM_DEDAIL.SET_DATA(dao)
        TR_ID = bao_tran.insert_transection(_PROCESS_ID)
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.TR_ID = TR_ID
        dao.fields.PROCESS_ID = _PROCESS_ID
        dao.fields.FK_LCN = _IDA_LCN
        dao.fields.CREATE_BY = _CLS.THANM
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.FK_LCN = _IDA_LCN
        dao.fields.FK_IDA = _IDA_IF
        dao.insert()
        UC_INFORM_DEDAIL.SET_DATA_LIST(dao_l, dao.fields.IDA)
        dao_l.insert()
        UC_INFORM_DEDAIL.SET_SUB_DATA(dao_d, dao.fields.IDA)
        dao_d.insert()

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        dao_up_mas.GetdatabyID_TYPE(240)
        For Each dao_up_mas.fields In dao_up_mas.datas
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DOCUMENT_NAME = dao_up_mas.fields.DOCUMENT_NAME
            dao_up.fields.TR_ID = TR_ID
            dao_up.fields.PROCESS_ID = _PROCESS_ID
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.FK_IDA = dao.fields.IDA
            dao_up.fields.TYPE = 1
            dao_up.insert()
        Next
        Response.Redirect("POPUP_HERB_TABEAN_INFORM_EDIT_UPLOAD.aspx?IDA=" & dao.fields.IDA & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN & "&staff=" & Request.QueryString("staff"))
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class