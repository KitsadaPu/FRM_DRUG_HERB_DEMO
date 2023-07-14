Imports Telerik.Web.UI
Imports Telerik.Web.UI.Scheduler.Views
Public Class POP_UP_LCN_STAFF_TRANSFER_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String = ""
    Private _STATUS_ID As String = ""

    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _STATUS_ID = Request.QueryString("STATUS_ID")

        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data()
        End If
    End Sub

    Public Sub bind_data()
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)
        Try
            If dao.fields.Check_Edit_ID = True Then
                DIV_SHOW_TXT_EDIT_TB1.Visible = True
                TXT_EDIT_NOTE_TB1.Text = dao.fields.Note_Edit
                TXT_EDIT_NOTE_TB1.ReadOnly = True
                CHK_TB1_EDIT.Checked = dao.fields.Check_Edit_ID
                CHK_TB1_EDIT.Enabled = True
            Else
                DIV_SHOW_TXT_EDIT_TB1.Visible = False
            End If
            If dao.fields.Check_Edit_FileUpload_ID = True Then
                DIV_EDIT_UPLOAD1.Visible = True
                DIV_EDIT_UPLOAD2.Visible = True
                RadGrid1.Rebind()
                RadGrid3.Rebind()
                NOTE_EDIT.Text = dao.fields.Note_Edit_FileUpload
                NOTE_EDIT.ReadOnly = True
                CHK_UPLOAD_EDIT.Checked = dao.fields.Check_Edit_FileUpload_ID
                CHK_UPLOAD_EDIT.Enabled = True
            Else
                DIV_EDIT_UPLOAD1.Visible = False
                DIV_EDIT_UPLOAD2.Visible = False
            End If
        Catch ex As Exception

        End Try
        'Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
        'dao_a.GetDataby_TR_ID(dao.fields.TR_ID)
        Dim dao_a As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_a.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 3)
        If dao_a.fields.IDA <> 0 Then
            img_cf.Visible = True
            img_not.Visible = False
            lbl_upload_file.Text = dao_a.fields.NAME_REAL
        End If
    End Sub
    Private Sub load_HL(ByVal IDA As String)
        Dim url As String = "../LCN_TRANSFER/FRM_LCN_DRUG_TRANSFER_PREVIEW.aspx?ida=" & IDA

        ST_AT.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        'Dim dao_up As New DAO_DRUG.TB_MAS_DUCUMENT_NAME_UPLOAD_DALCN
        dao_up.GetDataby_FK_IDA_AND_TR_ID_AND_PROCESS(_IDA, _TR_ID, _ProcessID)
        Type_ID = dao_up.fields.TYPE
        If Type_ID = 1 Then
            'RadGrid1.Visible = False
            RadGrid4.Visible = False
            ' dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO() 
        Else
            RadGrid1.Visible = False
            'RadGrid4.Visible = True

            btn_sumit.Enabled = False
            btn_sumit.CssClass = "btn-danger btn-lg"
            btn_add_upload.Enabled = False
            btn_add_upload.CssClass = "btn-danger btn-lg"
            'set_show.Visible = False
        End If

        dt = bao.SP_DALCN_UPLOAD_FILE_TYPE_BY_PROCESS(_ProcessID)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim IDA_UPLOAD As Integer = 0
        Dim NAME_FILE As String = ""
        For Each item As GridDataItem In RadGrid1.SelectedItems
            IDA_UPLOAD = item("ID").Text
            NAME_FILE = item("DUCUMENT_NAME").Text
            Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_up.fields.DUCUMENT_NAME = NAME_FILE
            dao_up.fields.TR_ID = _TR_ID
            dao_up.fields.PROCESS_ID = _ProcessID
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.TYPE = 2
            'dao_up.fields.a = 1
            dao_up.fields.CREATE_DATE = Date.Now
            dao_up.insert()
        Next
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)
        dao.fields.Note_Edit = NOTE_EDIT.Text
        If CHK_TB1_EDIT.Checked = True Then
            dao.fields.Check_Edit_ID = CHK_TB1_EDIT.Checked
            dao.fields.Note_Edit = TXT_EDIT_NOTE_TB1.Text
        Else
            dao.fields.Check_Edit_ID = CHK_TB1_EDIT.Checked
        End If
        If CHK_UPLOAD_EDIT.Checked = True Then
            dao.fields.Check_Edit_FileUpload_ID = CHK_UPLOAD_EDIT.Checked
            dao.fields.Note_Edit_FileUpload = NOTE_EDIT.Text
        Else
            dao.fields.Check_Edit_FileUpload_ID = CHK_UPLOAD_EDIT.Checked
        End If
        Try
            dao.fields.staff_edit_id = _CLS.CITIZEN_ID
            dao.fields.staff_edit_name = _CLS.NAME
            dao.fields.staff_edit_name = Date.Now
        Catch ex As Exception

        End Try
        dao.update()

        AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click
        If UC_ATTACH_LCN.check = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์');", True)
        Else
            Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
            dao.GET_DATA_BY_IDA(_IDA)
            Dim Year As String
            Year = con_year(Date.Now.Year)
            UC_ATTACH_LCN.ATTACH_TRANSFER(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "3")
            Dim up_edit As String = ""
            'Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
            'dao_a.GetDataby_TR_ID(dao.fields.TR_ID)
            Dim dao_a As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_a.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 3)
            If dao_a.fields.IDA <> 0 Then
                img_cf.Visible = True
                img_not.Visible = False
                lbl_upload_file.Text = dao_a.fields.NAME_REAL
            End If
            load_HL(dao_a.fields.IDA)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แนบไฟล์เรียบร้อยแล้ว');", True)
        End If
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub CHK_TB1_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_TB1_EDIT.CheckedChanged
        If CHK_TB1_EDIT.Checked = True Then
            DIV_SHOW_TXT_EDIT_TB1.Visible = True
        Else
            DIV_SHOW_TXT_EDIT_TB1.Visible = False
        End If
    End Sub

    Protected Sub CHK_UPLOAD_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_UPLOAD_EDIT.CheckedChanged
        If CHK_UPLOAD_EDIT.Checked = True Then
            DIV_EDIT_UPLOAD1.Visible = True
            DIV_EDIT_UPLOAD2.Visible = True
            RadGrid1.Rebind()
            RadGrid3.Rebind()
        Else
            DIV_EDIT_UPLOAD1.Visible = False
            DIV_EDIT_UPLOAD2.Visible = False
        End If
    End Sub
    Function bind_data_uploadfile_1()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 1)
        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_uploadfile_1()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_TRANSFER/FRM_LCN_DRUG_TRANSFER_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub
    Function bind_data_uploadfile_4()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 2)
        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_4()
    End Sub

End Class