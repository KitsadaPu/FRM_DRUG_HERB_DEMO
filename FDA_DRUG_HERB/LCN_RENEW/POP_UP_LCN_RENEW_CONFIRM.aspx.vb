﻿Imports Telerik.Web.UI
Public Class POP_UP_LCN_RENEW_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_LCN As String
    Private _ProcessID As String = ""

    Sub RunSession()
        _IDA = Request.QueryString("IDA")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _ProcessID = Request.QueryString("PROCESS_ID")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Blind_PDF()
            set_btn()
        End If
    End Sub

    Sub set_btn()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        Dim SSID As Integer = dao.fields.STATUS_ID
        If SSID = 1 Then
            btn_cancel.Visible = False
        Else
            btn_cancel.Visible = True
        End If

        If SSID = 77 Or SSID = 78 Or SSID = 79 Or SSID = 7 _
            Or SSID = 9 Or SSID = 10 Or SSID = 14 Or SSID = 17 _
            Or SSID = 75 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
        If SSID = 2 Then
            btn_KeepPay.Visible = True
        Else
            btn_KeepPay.Visible = False
        End If
        If SSID <> 1 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            'btn_edit.Enabled = False
            'btn_edit.CssClass = "btn-danger btn-lg"
            'btn_editUpload.CssClass = "btn-danger btn-lg"
        ElseIf SSID = 8 Then
            'btn_editUpload.Enabled = False
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If

    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim bao As New BAO.GenNumber
        Dim RCVNO As String = ""
        Dim RCVNO_HERB_NEW As String = ""
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        RCVNO = dao.fields.RCVNO
        If RCVNO = "" Then
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), dao.fields.pvncd, _ProcessID, _IDA)
            Dim TR_ID As String = dao.fields.TR_ID
            Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
            RCVNO_HERB_NEW = bao.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), dao.fields.pvncd, _ProcessID, _IDA)
            Dim RCVNO_FULL As String = "HB" & " " & dao.fields.pvncd & "-" & _ProcessID & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
            dao.fields.RCVNO_NEW = RCVNO_FULL
            dao.fields.RCVNO = RCVNO
        End If
        dao.fields.STATUS_ID = 2
        dao.fields.DATE_CONFIRM = Date.Now
        dao.fields.UPDATE_DATE = DateTime.Now
        dao.update()
        AddLogStatus(dao.fields.STATUS_ID, dao.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
        Dim bao2 As New BAO_TABEAN_HERB.tb_dd
        bao2.SP_INSERT_DRUG_PAYMENT_CENTER_L44(_CLS.CITIZEN_ID_AUTHORIZE, _IDA, dao.fields.PROCESS_ID)
        alert("ยื่นคำขอแล้ว กรุณาชำระค่าคำขอ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)

        dao.fields.STATUS_ID = 77
        dao.update()
        alert("ยกเลิกคำขอแล้ว")
    End Sub

    'Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
    '    'Response.Redirect("FRM_PHR_HERB_EDIT.aspx?IDA=" & _IDA)
    'End Sub

    'Protected Sub btn_editUpload_Click(sender As Object, e As EventArgs) Handles btn_editUpload.Click
    '    'Response.Redirect("FRM_PHR_HERB_EDIT.aspx?IDA=" & _IDA)
    'End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Sub Blind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        'Dim _ProcessID As String = 10501
        Dim XML As New CLASS_GEN_XML.DALCN_RENEW
        LCN_RENEW = XML.Gen_XML_LCN_RENEW(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "สมพ5", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_RENREW") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PDF", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("XML", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
            'STATUS_UPLOAD_ID = 1
        Catch ex As Exception
            STATUS_UPLOAD_ID = 0
        End Try

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, STATUS_UPLOAD_ID)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgat.NeedDataSource
        rgat.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgat.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub

    Private Sub btn_KeepPay_Click(sender As Object, e As EventArgs) Handles btn_KeepPay.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        dao.fields.STATUS_ID = 22
        dao.fields.DATE_PAY1 = Date.Now
        dao.fields.DATE_PAY2 = Date.Now
        dao.update()
        alert("ข้ามการชำระเงินแล้ว")
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Dim dao As New DAO_DRUG.TB_DALCN_UPLOAD_FILE

        Dim filePath As String = Server.MapPath("~/Path/To/Your/File.pdf") ' ระบุที่อยู่ของไฟล์ที่ต้องการให้ดาวน์โหลด
        Response.ContentType = "application/pdf"
        Response.AppendHeader("Content-Disposition", "attachment; filename=YourFile.pdf")
        Response.TransmitFile(filePath)
        Response.End()
    End Sub
End Class