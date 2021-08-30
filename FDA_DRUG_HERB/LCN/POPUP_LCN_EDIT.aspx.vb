Public Class POPUP_LCN_EDIT
    Inherits System.Web.UI.Page
    Private _type_id As String = ""
    Private _IDA As String = ""
    Private _ProcessID As Integer
    Private _pvncd As Integer
    Private _CLS As New CLS_SESSION
    Private _TR_ID As String
    Sub runQuery()
        _type_id = Request.QueryString("type_id")
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("ida")
        _TR_ID = Request.QueryString("TR_ID")

    End Sub
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
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
        UC_GRID_ATTACH.load_gv(_TR_ID)
        If Not IsPostBack Then
            get_data(_IDA)
            get_label(_IDA)
        End If

    End Sub

    Protected Sub get_label(ByVal IDA As String)
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_up.GetDataby_FK_IDA(IDA)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(IDA)
        txt_edit_remark.Text = dao.fields.REMARK_EDIT
    End Sub
    Protected Sub get_data(ByVal IDA As String)
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_up.GetDataby_FK_IDA(IDA)

    End Sub

    Protected Sub BTN_CLOSE_Click(sender As Object, e As EventArgs) Handles BTN_CLOSE.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub

    Protected Sub BTN_UPDATE_EDIT_Click(sender As Object, e As EventArgs) Handles BTN_UPDATE_EDIT.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        If dao.fields.STATUS_ID = 12 Then
            dao.fields.STATUS_ID = 3
            dao.update()
        ElseIf dao.fields.STATUS_ID = 13 Then
            dao.fields.STATUS_ID = 5
            dao.update()
        End If
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยื่นคำขอแล้ว');parent.close_modal();", True)
    End Sub
End Class