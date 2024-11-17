Imports Telerik.Web.UI
Public Class FRM_HERB_LCN_RENEW_CHECK_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub

    Private Sub RG_RNP_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RG_RNP.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_STAFF_LCN_RNP()
        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            RG_RNP.DataSource = dt
        End If
    End Sub

    Private Sub RG_RNP_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RG_RNP.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim IDA_LCN As Integer = item("FK_LCN").Text
            Dim TR_ID As Integer = item("TR_ID").Text
            Dim IDENTIFY As String = item("CITIZEN_ID_AUTHORIZE").Text
            Dim PROCESS_ID As String = item("PROCESS_ID").Text
            Dim STATUS_ID As String = item("STATUS_ID").Text
            If e.CommandName = "HL_SELECT" Then
                If STATUS_ID = 3 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CHECK_STAFF_EDIT_FILE.aspx?IDA=" & IDA & "&IDA_LCN=" & IDA_LCN & "&IDENTIFY=" & IDENTIFY & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CHECK_STAFF.aspx?IDA=" & IDA & "&IDA_LCN=" & IDA_LCN & "&IDENTIFY=" & IDENTIFY & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                End If
            End If
        End If
    End Sub
End Class