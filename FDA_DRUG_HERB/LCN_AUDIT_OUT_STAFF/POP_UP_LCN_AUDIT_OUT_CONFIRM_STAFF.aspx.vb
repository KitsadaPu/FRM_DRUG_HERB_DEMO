Imports Telerik.Web.UI
Public Class POP_UP_LCN_AUDIT_OUT_CONFIRM_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _IDA_LCN As String
    Private _IDA As String
    Private _TR_ID As String
    Sub RunSession()
        '_ProcessID = 10901
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _ProcessID = Request.QueryString("process")

        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
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
        RunSession()
        If Not IsPostBack Then
            UC_ATTACH2.NAME = "เอกสารแนบ"
            UC_ATTACH2.BindData("เอกสารแนบ", 1, "pdf", "0", "91")

            bind_dd()
            bind_mas_staff()
            Blind_PDF()
        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_LCN.TB_DALCN_AUDIT_OUT
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao.GET_DATA_BY_IDA(_IDA)
        dao_lcn.GetDataby_IDA(dao.fields.FK_LCN)
        Dim bao As New BAO.GenNumber
        Dim RCVNO As String = ""
        Dim RCVNO_HERB_NEW As String = ""
        Dim pvncd As String = dao_lcn.fields.pvncd
        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        'dao.fields.DATE_COMFIRM = Date.Now
        If dao.fields.STATUS_ID = 8 Then
            dao.fields.appdate = DATE_REQ.Text
            dao.fields.app_staff_name = DD_OFF_REQ.SelectedItem.Text
            Blind_PDF()
        ElseIf dao.fields.STATUS_ID = 6 Then
            dao.fields.cnsddate = DATE_REQ.Text
            dao.fields.csn_staff_name = DD_OFF_REQ.SelectedItem.Text
            Blind_PDF()
        ElseIf dao.fields.STATUS_ID = 3 Then
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), pvncd, _ProcessID, _IDA)
            Dim TR_ID As String = dao.fields.TR_ID
            Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
            RCVNO_HERB_NEW = bao.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
            Dim RCVNO_FULL As String = "HB" & " " & pvncd & "-" & _ProcessID & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
            dao.fields.rcvno = RCVNO_FULL
            dao.fields.rcvno = RCVNO
            dao.fields.rcvdate = DATE_REQ.Text
            dao.fields.rcv_staff_name = DD_OFF_REQ.SelectedItem.Text
            Blind_PDF()
        End If
        dao.update()
        AddLogStatus_lcn(dao.fields.STATUS_ID, dao.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA, 0, 0)
        alert("อัพเดทคำขอแล้ว")
    End Sub
    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim ss_id As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_AUDIT_OUT
        dao.GET_DATA_BY_IDA(_IDA)
        'If dao.fields.STATUS_ID = 2 Or dao.fields.STATUS_ID = 12 Then
        '    ss_id = 1
        'ElseIf dao.fields.STATUS_ID = 3 Then
        '    ss_id = 2
        'End If
        If dao.fields.STATUS_ID = 2 Or dao.fields.STATUS_ID = 12 Then
            ss_id = 2
        ElseIf dao.fields.STATUS_ID = 3 Then
            ss_id = 3
        ElseIf dao.fields.STATUS_ID = 6 Then
            ss_id = 4
        ElseIf dao.fields.STATUS_ID = 8 Then
            P12.Visible = False
            btn_sumit.Visible = False
            KEEP_PAY.Visible = False
        End If
        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(10902, ss_id)
        dt = bao.dt

        DD_STATUS.DataSource = dt
        DD_STATUS.DataValueField = "STATUS_ID"
        DD_STATUS.DataTextField = "STATUS_NAME_STAFF"
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")
        'dt = bao.SP_DD_STATUS_JJ_EDIT(ss_id)

        'DD_STATUS.DataSource = dt
        'DD_STATUS.DataBind()
        'DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")
        DATE_REQ.Text = Date.Now

    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Sub Blind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_AUDIT_OUT
        dao.GET_DATA_BY_IDA(_IDA)
        'Dim _ProcessID As String = 10901

        Dim XML As New CLASS_GEN_XML.DALCN_AUDIT
        DALCN_AUDIT = XML.Gen_XML_LCN_AUDIT_OUT(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(dao.fields.PROCESS_ID, dao.fields.STATUS_ID, "ตปส", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_AUDIT") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PDF", dao.fields.PROCESS_ID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("XML", dao.fields.PROCESS_ID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    'Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
    '    Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    'End Sub
    Protected Sub btn_savefileapprove_Click(sender As Object, e As EventArgs) Handles btn_savefileapprove.Click

        If UC_ATTACH2.CHK_AD = False Then
            alert_nature("กรุณาแนบไฟล์")
        ElseIf UC_ATTACH2.CHK_AD = False Then
            alert_nature("กรุณาแนบไฟล์")
        Else
            UC_ATTACH2.insert_file_AD(_TR_ID, _ProcessID, _IDA, 1)
            alert_nature("อัพโหลดเอกสารแนบ เรียบร้อย")
        End If

        uc_upload1.Visible = False
        uc_upload1_btn.Visible = False
        uc_upload1_radgrid.Visible = True
        RadGrid4.Rebind()
    End Sub
    Function bind_data_uploadfile_92()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_AUDIT_IN
        dao.GET_DATA_BY_IDA(_IDA)
        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 92)
        If dt.Rows.Count <> 0 Then
            uc_upload1.Visible = False
            uc_upload1_btn.Visible = False
            uc_upload1_radgrid.Visible = True
            'RadGrid4.Rebind()
        Else
            uc_upload1_radgrid.Visible = False
        End If


        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_92()
    End Sub
    Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim bao As New BAO.AppSettings
            Dim paths As String = bao._PATH_XML_PDF_AUDIT
            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../PDF/FRFM_ATTACH_PREVIEW_LCN.aspx?ida=" & IDA & "&path= " & paths

        End If
    End Sub
    Sub alert_nature(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_AUDIT_OUT
        dao.GET_DATA_BY_IDA(_IDA)
        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, dao.fields.STATUS_FILE_UPLOAD)
        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim PATH As String = ""
            Dim bao As New BAO.AppSettings
            Dim paths As String = bao._PATH_XML_PDF_AUDIT
            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../PDF/FRFM_ATTACH_PREVIEW_LCN.aspx?ida=" & IDA & "&path= " & paths

        End If

    End Sub
End Class