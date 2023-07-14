Imports Telerik.Web.UI
Public Class FRM_TABEAN_HERB_SELECT_LCN_SUB_MENU
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _PAGE_MENU As String = ""

    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
        _PAGE_MENU = Request.QueryString("PAGE_MENU")
        _MENU_GROUP = Request.QueryString("MENU_GROUP")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            If _PAGE_MENU = "" Then
                div_news.Visible = True
            Else
                div_news.Visible = False
                panel1.Visible = True
            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim TR_ID As String = item("TR_ID").Text
            Dim FK_IDA As String = ""
            Try
                FK_IDA = item("FK_IDA").Text
            Catch ex As Exception

            End Try
            'Dim DAO As New DAO_CPN.clsDBsyslcnsnm

            'Dim sql As String
            'sql = "select URL from tb_User where IDA = '&MAS_MENU=" & 

            Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
            If _PAGE_MENU = 1 Then
                H.NavigateUrl = "../HERB_TABEAN_SUBSTITUTE/FRM_TABEAN_SUBSTITUTE_MAIN.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA
            ElseIf _PAGE_MENU = 2 Then
                H.NavigateUrl = "../HERB_TABEAN_RENEW/FRM_HERB_TABEAN_RENEW_MAIN.aspx?MENU_GROUP=2" & "&IDA_LCN=" & IDA & "&IDA_LCT=" & FK_IDA
            ElseIf _PAGE_MENU = 3 Then
                H.NavigateUrl = "../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_MAIN.aspx?MENU_GROUP=2" & "&PROCESS_ID=" & 20430
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
        Catch ex As Exception

        End Try
        'If IDGroup = 21020 Then
        RadGrid1.DataSource = bao.SP_CUSTOMER_LCN_DR_BY_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE)
        'RadGrid1.DataSource = dt

    End Sub
End Class