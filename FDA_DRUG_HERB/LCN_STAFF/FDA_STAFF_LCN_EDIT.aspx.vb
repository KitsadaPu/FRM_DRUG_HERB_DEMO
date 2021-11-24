Imports Telerik.Web.UI
Public Class FDA_STAFF_LCN_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _STATUS_ID As String = ""

    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
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
        'BindTable()
    End Sub

    Public Sub bind_data()
        Try
            Dim dao_up_mas As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_up_mas.GetDataby_FK_IDA(_IDA)
            Dim dao_chk As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_chk.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(_TR_ID, _ProcessID, dao_up_mas.fields.TYPE)
            If dao_chk.fields.IDA = 0 Then
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = _TR_ID
                    dao_up.fields.PROCESS_ID = _ProcessID
                    dao_up.fields.FK_IDA = _IDA
                    dao_up.fields.TYPE = 2
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.insert()
                Next
            End If
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ผู้ประกอบการยังไม่ได้อัพโหลดเอกสาาร');", True)
        End Try



    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_FK_IDA_AND_TYPE(_IDA, 2)

        RadGrid1.DataSource = dt
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim IDA_UPLOAD As Integer = 0
        Dim _TYPE As Integer = 0
        Dim NAME_FILE As String = ""
        If _STATUS_ID = 12 Then
            _TYPE = 3
        ElseIf _STATUS_ID = 13 Then
            _TYPE = 5
        End If
        For Each item As GridDataItem In RadGrid1.SelectedItems
            IDA_UPLOAD = item("IDA").Text
            NAME_FILE = item("DUCUMENT_NAME").Text

            Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_up.fields.DUCUMENT_NAME = NAME_FILE
            dao_up.fields.TR_ID = _TR_ID
            dao_up.fields.PROCESS_ID = _ProcessID
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.TYPE = _TYPE
            dao_up.fields.CREATE_DATE = Date.Now
            dao_up.insert()

        Next

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = _STATUS_ID
        dao.fields.REMARK_EDIT = NOTE_EDIT.Text
        dao.update()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิก');parent.close_modal();", True)
    End Sub

    'Public Sub BindTable()


    'End Sub

    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)

        Dim Year As String
        Year = con_year(Date.Now.Year)
        UC_ATTACH_LCN.ATTACH1(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "1")


        Dim up_edit As String = ""
        Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
        dao_a.GetDataby_TR_ID(_TR_ID)
        If dao_a.fields.IDA <> 0 Then
            img_cf.Visible = True
            img_not.Visible = False
            lbl_upload_file.Text = dao_a.fields.NAME_REAL
        End If

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แนบไฟล์เรียบร้อยแล้ว');", True)
        'alert_normal("แนบไฟล์เรียบร้อยแล้ว")

    End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

End Class