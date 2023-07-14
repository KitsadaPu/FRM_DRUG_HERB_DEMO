Imports Telerik.Web.UI
Public Class POP_UP_STAFF_LCN_CONSIDER_TRANSLATION_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As String
    Private _IDA As String
    Sub RunSession()
        '_ProcessID = 10901
        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("PROCESS_ID")

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
            bind_dd()
            bind_mas_staff()
            Bind_PDF()
        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION
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
            dao.fields.frtappdate = DATE_REQ.Text
            dao.fields.appdate = DATE_REQ.Text
            dao.fields.app_staff_name = DD_OFF_REQ.SelectedItem.Text
        ElseIf dao.fields.STATUS_ID = 6 Then
            dao.fields.cnsdate = DATE_REQ.Text
            dao.fields.csn_staff_name = DD_OFF_REQ.SelectedItem.Text
        ElseIf dao.fields.STATUS_ID = 10 Then
            dao.fields.EstimateDate = DATE_REQ.Text
            dao.fields.EstimateName = DD_OFF_REQ.SelectedItem.Text
        ElseIf dao.fields.STATUS_ID = 15 Then
            dao.fields.staff_edit_name = DD_OFF_REQ.SelectedItem.Text
            dao.fields.staff_edit_date = DATE_REQ.Text
            dao.fields.staff_edit_id = DD_OFF_REQ.SelectedValue
            dao.update()
            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            Response.Redirect("POP_UP_STAFF_LCN_CONSIDER_TRANSLATION_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & dao.fields.TR_ID & "&PROCESS_ID=" & _ProcessID)
        ElseIf dao.fields.STATUS_ID = 3 Or dao.fields.STATUS_ID = 12 Then
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), pvncd, _ProcessID, _IDA)
            Dim TR_ID As String = dao.fields.TR_ID
            Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
            RCVNO_HERB_NEW = BAO.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
            Dim RCVNO_FULL As String = "HB" & " " & pvncd & "-" & _ProcessID & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
            dao.fields.RCVNO_NEW = RCVNO_FULL
            dao.fields.rcvno = RCVNO
            dao.fields.rcvdate = DATE_REQ.Text
            dao.fields.rcv_staff_name = DD_OFF_REQ.SelectedItem.Text
        End If
        Bind_PDF()
        dao.update()
        AddLogStatus_lcn(dao.fields.STATUS_ID, dao.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA, 0, 0)
        alert("อัพเดทคำขอแล้ว")
    End Sub
    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim ss_id As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION
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
            ss_id = 5
        ElseIf dao.fields.STATUS_ID = 10 Then
            ss_id = 4
        ElseIf dao.fields.STATUS_ID = 14 Then
            ss_id = 6
        ElseIf dao.fields.STATUS_ID = 8 Then
            P12.Visible = False
            btn_sumit.Visible = False
            KEEP_PAY.Visible = False
        End If
        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(10801, ss_id)
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
    Sub Bind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION
        dao.GET_DATA_BY_IDA(_IDA)
        'Dim _ProcessID As String = 10701

        Dim XML As New CLASS_GEN_XML.DALCN_PLAN
        LCN_PLAN = XML.Gen_XML_LCN_PLAN(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "บปอ", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_PLAN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF2("PDF", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML2("XML", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    'Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
    '    Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    'End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim Type_ID As Integer = 0
        'Dim dao As New DAO_LCN.TB_DALCN_AUDIT_IN
        'dao.GET_DATA_BY_IDA(_IDA)
        'dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, dao.fields.STATUS_FILE_UPLOAD)
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