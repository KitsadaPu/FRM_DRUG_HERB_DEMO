Imports Telerik.Web.UI
Public Class POPUP_HERB_PRODUCT_NOTIFIED_CONFIRM
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            set_btn()
            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF") 'path
            Dim filename As String = "D:/path_demo/PDF_TEMPLATE/MATERIAL.pdf"
            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        End If

    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_REPORT.TB_HERB_PRODUCT_NOTIFIED
        dao.Getdataby_IDA(Request.QueryString("IDA"))

        dao.fields.CREATE_DATE = Date.Now
        dao.fields.STATUS_ID = 2
        dao.Update()

        alert("ยืนคำขอเรียบร้อย")

    End Sub
    Sub set_btn()
        Dim dao As New DAO_REPORT.TB_HERB_PRODUCT_NOTIFIED
        dao.Getdataby_IDA(Request.QueryString("IDA"))

        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
        End If
        If dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 77 Or dao.fields.STATUS_ID = 75 Or dao.fields.STATUS_ID = 7 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
        If dao.fields.STATUS_ID = 1 Then
            btn_cancel.Text = "ยกเลิกการสร้างคำขอ"
        End If
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_REPORT.TB_HERB_PRODUCT_NOTIFIED
        dao.Getdataby_IDA(Request.QueryString("IDA"))
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_FILE_UPLOAD
        Catch ex As Exception
            STATUS_UPLOAD_ID = 0
        End Try

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, STATUS_UPLOAD_ID, Request.QueryString("PROCESS_ID"), Request.QueryString("IDA"))

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

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_INFORM_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub
End Class