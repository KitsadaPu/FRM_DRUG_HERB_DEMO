Imports Telerik.Web.UI

Public Class FRM_TABEAN_SUBSTITUTE_SUB_DR
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_DR As String = ""
    Private _TR_ID_DR As String = ""
    Private _PROCESS_ID_DR As String = ""
    Private _PROCESS_ID As String = ""
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
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_DR = Request.QueryString("IDA_DR")
        _TR_ID_DR = Request.QueryString("TR_ID_DR")
        _PROCESS_ID_DR = Request.QueryString("PROCESS_ID_DR")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _PROCESS_TYPE_ID = Request.QueryString("PROCESS_TYPE_ID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btn_add_tabean_Click(sender As Object, e As EventArgs) Handles btn_add_tabean.Click
        Response.Redirect("FRM_TABEAN_SUBSTITUTE_ADD.aspx?&MENU_GROUP=" & _MENU_GROUP & "&IDA_DR=" & _IDA_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID)
    End Sub

    Function bind_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        dt = bao.SP_DRRGT_SUBSTITUTE_BY_FK_IDA(_IDA_DR)
        Return dt

    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim IDA_DR As Integer = item("IDA").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            Dim DRRGT_REASON_ID As Integer = item("DRRGT_REASON_ID").Text
            Dim TR_ID As Integer = item("TR_ID").Text
            Dim H As HyperLink = e.Item.FindControl("HL_SELECT")

            'If STATUS_ID = 1 Then
            '    H.NavigateUrl = "FRM_TABEAN_SUBSTITUTE_ADD.aspx?FK_LCN_IDA=" & _IDA_LCN & "&IDA_DR=" & IDA_DR & "&MENU_GROUP=" & _MENU_GROUP & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID & "&DRRGT_REASON_ID=" & DRRGT_REASON_ID & "&TR_ID=" & TR_ID 'URL หน้า ยืนยัน

            'Else

            If STATUS_ID = 2 Then
                H.NavigateUrl = "FRM_TABEAN_SUBSTITUTE_CONFIRM.aspx?FK_LCN_IDA=" & _IDA_LCN & "&IDA_DR=" & IDA_DR & "&MENU_GROUP=" & _MENU_GROUP & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID & "&DRRGT_REASON_ID=" & DRRGT_REASON_ID & "&TR_ID=" & TR_ID 'URL หน้า ยืนยัน

            Else
                H.NavigateUrl = "FRM_TABEAN_SUBSTITUTE_DETAIL.aspx?FK_LCN_IDA=" & _IDA_LCN & "&IDA_DR=" & IDA_DR & "&MENU_GROUP=" & _MENU_GROUP & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID & "&DRRGT_REASON_ID=" & DRRGT_REASON_ID & "&TR_ID=" & TR_ID 'URL หน้า ยืนยัน

            End If
        End If
    End Sub

End Class