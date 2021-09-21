Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_NEW
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""

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
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btn_tabean_Click(sender As Object, e As EventArgs) Handles btn_tabean.Click
        Response.Redirect("")
    End Sub

    Protected Sub btn_detail_Click(sender As Object, e As EventArgs) Handles btn_detail.Click
        Response.Redirect("")
    End Sub

    Protected Sub btn_jj_Click(sender As Object, e As EventArgs) Handles btn_jj.Click
        T1.Visible = True
        RadGrid1.Rebind()
    End Sub

    Function bind_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        '"0000000000000"
        Dim CID As String = _CLS.CITIZEN_ID_AUTHORIZE
        dt = bao.SP_CUSTOMER_LCN_BY_IDENTIFY(CID)
        Return dt

    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA_LCN As Integer = item("IDA").Text
            Dim TR_ID_LCN As String = item("TR_ID").Text
            'Dim LCNNO_DISPLAY As String = item("LCNNO_DISPLAY").Text
            Dim PROCESS_ID As String = item("PROCESS_ID").Text
            Dim FK_IDA_LCT As String = ""
            Try
                FK_IDA_LCT = item("FK_IDA").Text
            Catch ex As Exception

            End Try

            Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
            H.NavigateUrl = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & FK_IDA_LCT & "&TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & PROCESS_ID 'URL หน้า ยืนยัน

        End If
    End Sub

End Class