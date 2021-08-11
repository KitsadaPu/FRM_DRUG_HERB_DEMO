Public Class POPUP_CONFIRM_LCN_REQUEST
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
        If Request.QueryString("id") <> Nothing Then
            Dim dao As New DAO_DRUG.ClsDBlcn_request
            dao.GetDataby_id(Request.QueryString("id"))
            If dao.fields.STATUS = 1 Then
                btn_confirm.Style.Add("display", "initial")
            Else btn_confirm.Style.Add("display", "none")
            End If
        End If

    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBlcn_request
        dao.GetDataby_id(Request.QueryString("id"))
        dao.fields.STATUS = 2
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal2();", True)

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');parent.close_modal2();", True)

    End Sub
End Class