﻿Imports Telerik.Web.UI
Imports Telerik.Web.UI.Scheduler.Views
Public Class POP_UP_LCN_RENEW_CHECK_STAFF_EDIT_FILE
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
            'Bind_PDF()
        End If
    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        Try
            rgat_edit.Rebind()
            rgat.Rebind()
            NOTE_EDIT.Text = dao.fields.Note_Edit_Staff
        Catch ex As Exception

        End Try
        Dim dao_a As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_a.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 3)
        If dao_a.fields.IDA <> 0 Then
            img_cf.Visible = True
            img_not.Visible = False
            lbl_upload_file.Text = dao_a.fields.NAME_REAL
        End If
    End Sub
    Private Sub load_HL(ByVal IDA As String)
        Dim url As String = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA

        ST_AT.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao_p As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao_p.GET_DATA_BY_FK_LCN(_IDA_LCN, True)
        _TR_ID = dao_p.fields.TR_ID
        Dim Condition_ID As String = dao_p.fields.Check_Confirm
        Dim bao_show As New BAO_SHOW
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        'Dim dao_up As New DAO_DRUG.TB_MAS_DOCUMENT_NAME_UPLOAD_DALCN
        dao_up.GetDataby_FK_IDA_AND_TR_ID_AND_PROCESS(_IDA, _TR_ID, _ProcessID)
        Type_ID = dao_up.fields.TYPE
        If Type_ID = 1 Then
            'RadGrid1.Visible = False
            rgat_edit2.Visible = False
            ' dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO() 
        Else
            rgat_edit.Visible = False
            'RadGrid4.Visible = True

            btn_sumit.Enabled = False
            btn_sumit.CssClass = "btn-danger btn-lg"
            btn_add_upload.Enabled = False
            btn_add_upload.CssClass = "btn-danger btn-lg"
            'set_show.Visible = False
        End If

        If Condition_ID = "N" Then
            dt = bao_show.SP_DALCN_UPLOAD_FILE_BY_TR_ID_AND_DOCID(_TR_ID)
        Else
            dt = bao_show.SP_DALCN_UPLOAD_FILE_BY_TR_ID_V3(_TR_ID, 1)
        End If
        'dt = bao.SP_DALCN_UPLOAD_FILE_TYPE_BY_PROCESS(_ProcessID)
        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgat_edit.NeedDataSource
        rgat_edit.DataSource = bind_data_uploadfile()
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim IDA_UPLOAD As Integer = 0
        Dim NAME_FILE As String = ""
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        _TR_ID = dao.fields.TR_ID
        For Each item As GridDataItem In rgat_edit.SelectedItems
            IDA_UPLOAD = item("ID").Text
            NAME_FILE = item("DOCUMENT_NAME").Text
            Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_up.fields.DOCUMENT_NAME = NAME_FILE
            dao_up.fields.TR_ID = _TR_ID
            dao_up.fields.PROCESS_ID = _ProcessID
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.TYPE = 2
            'dao_up.fields.a = 1
            dao_up.fields.CREATE_DATE = Date.Now
            dao_up.fields.Active = True
            dao_up.insert()
        Next
        dao.fields.Note_Edit_Staff = NOTE_EDIT.Text
        dao.fields.STATUS_ID = 5
        Try
            dao.fields.staff_edit_id = _CLS.CITIZEN_ID
            dao.fields.SendEditStaffID = _CLS.CITIZEN_ID
            dao.fields.staff_edit_name = _CLS.NAME
            dao.fields.SendEditStaffNM = _CLS.NAME
            dao.fields.staff_edit_date = DateTime.Now
            dao.fields.Send_EditDate = DateTime.Now
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
            Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
            dao.GET_DATA_BY_IDA(_IDA)
            Dim Year As String
            Year = con_year(Date.Now.Year)
            Dim path As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_RENREW")
            UC_ATTACH_LCN.ATTACH_LCN(dao.fields.TR_ID, dao.fields.FK_LCN, dao.fields.PROCESS_ID, Year, "3", path)
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
    Function bind_data_uploadfile_1()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 1)
        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgat.NeedDataSource
        rgat.DataSource = bind_data_uploadfile_1()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgat.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA
        End If
    End Sub
    Function bind_data_uploadfile_4()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 2)
        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgat_edit2.NeedDataSource
        rgat_edit2.DataSource = bind_data_uploadfile_4()
    End Sub

End Class