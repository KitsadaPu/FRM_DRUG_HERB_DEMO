Imports Telerik.Web.UI
Public Class FRM_PHR_HERB_STAFF_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As String
    Private _IDA As String
    Sub RunSession()
        '_ProcessID = 10104
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")

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
            Blind_PDF()
        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(_IDA)

        dao.fields.phr_status = DD_STATUS.SelectedValue
        'dao.fields.DATE_COMFIRM = Date.Now
        If dao.fields.phr_status = 8 Then
            dao.fields.appdate = DATE_REQ.Text
            dao.fields.app_staff_name = DD_OFF_REQ.SelectedItem.Text
        ElseIf dao.fields.phr_status = 6 Then
            dao.fields.staff_edit_name = DD_OFF_REQ.SelectedItem.Text
            dao.fields.staff_edit_date = DATE_REQ.Text
            dao.fields.staff_edit_id = DD_OFF_REQ.SelectedValue
            dao.update()
            AddLogStatus(dao.fields.phr_status, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            Response.Redirect("POPUP_PHR_HERB_STAFF_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & dao.fields.TR_ID & "&PROCESS_ID=" & _ProcessID)
        Else
            dao.fields.rcvdate = DATE_REQ.Text
            dao.fields.rcv_staff_name = DD_OFF_REQ.SelectedItem.Text
        End If
        dao.update()
        AddLogStatus(dao.fields.phr_status, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        alert("อัพเดทคำขอแล้ว")
    End Sub
    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim ss_id As Integer = 0
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(_IDA)
        If dao.fields.phr_status = 2 Or dao.fields.phr_status = 11 Then
            ss_id = 1
        ElseIf dao.fields.phr_status = 3 Then
            ss_id = 2
        ElseIf dao.fields.phr_status = 5 Then
            ss_id = 3
        End If
        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(5, ss_id)
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
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(_IDA)
        'Dim _ProcessID As String = 10104

        Dim XML As New CLASS_GEN_XML.DALCN_PHR_NEW
        LCN_PHR = XML.Gen_XML_PHR(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.phr_status, "สมพ4", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_PHR") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PHR_PDF", _ProcessID, dao.fields.YEAR, dao.fields.TRANSECTION_ID_UPLOAD, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("PHR_XML", _ProcessID, dao.fields.YEAR, dao.fields.TRANSECTION_ID_UPLOAD, _IDA)

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
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(_IDA)
        Try
            dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 1)
        Catch ex As Exception

        End Try
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
            Dim paths As String = bao._PATH_XML_PDF_PHR
            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../PDF/FRFM_ATTACH_PREVIEW_LCN.aspx?ida=" & IDA & "&path= " & paths

        End If

    End Sub
End Class