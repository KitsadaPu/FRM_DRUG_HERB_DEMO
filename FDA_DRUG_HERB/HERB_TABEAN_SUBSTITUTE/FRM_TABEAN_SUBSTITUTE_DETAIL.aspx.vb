Imports Telerik.Web.UI

Public Class FRM_TABEAN_SUBSTITUTE_DETAIL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_DR As String = ""
    Private _TR_ID_DR As String = ""
    Private _PROCESS_ID_DR As String = ""
    Private _PROCESS_ID As String = ""
    Private _TR_ID As String = ""
    Private _DRRGT_REASON_ID As String = ""
    Private _PROCESS_TYPE_ID As String = ""

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

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _IDA_DR = Request.QueryString("IDA_DR")
        _TR_ID_DR = Request.QueryString("TR_ID_DR")
        _TR_ID = Request.QueryString("TR_ID")
        _PROCESS_ID_DR = Request.QueryString("PROCESS_ID_DR")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _DRRGT_REASON_ID = Request.QueryString("DRRGT_REASON_ID")
        _PROCESS_TYPE_ID = Request.QueryString("PROCESS_TYPE_ID")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data_dr()
        End If
    End Sub

    Public Sub bind_data_dr()
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_IDA_DR)

        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao_sub.GetDataby_FK_IDA(_IDA_DR)

        If dao_sub.fields.PROCESS_TYPE_ID = 20810 Then
            lbl_type.Text = "คำขอใบแทนใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร"
        ElseIf dao_sub.fields.PROCESS_TYPE_ID = 20820 Then
            lbl_type.Text = "คำขอใบแทนใบรับแจ้งรายละเอียดผลิตภัณฑ์สมุนไพร"
        ElseIf dao_sub.fields.PROCESS_TYPE_ID = 20830 Then
            lbl_type.Text = "คำขอใบแทนใบรับจดแจ้งผลิตภัณฑ์สมุนไพร"
        Else
            lbl_type.Text = ""
        End If

        lbl_name_thai.Text = dao.fields.thadrgnm
        lbl_name_eng.Text = dao.fields.engdrgnm

        txt_remark.Text = dao_sub.fields.DRRDT_SUB_NOTE
        Try
            ddl_reason.SelectedValue = dao_sub.fields.DRRGT_REASON_ID
            ddl_reason.SelectedItem.Text = dao_sub.fields.DRRGT_REASON_NAME
        Catch ex As Exception

        End Try

    End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        If _DRRGT_REASON_ID = 4 Then
            dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 4, _PROCESS_ID)
        ElseIf _DRRGT_REASON_ID = 5 Then
            dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 5, _PROCESS_ID)
        End If

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
            H.NavigateUrl = "FRM_TABEAN_SUBSTITUTE_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("FRM_TABEAN_SUBSTITUTE_SUB_DR.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_DR=" & _IDA_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID)
    End Sub
End Class