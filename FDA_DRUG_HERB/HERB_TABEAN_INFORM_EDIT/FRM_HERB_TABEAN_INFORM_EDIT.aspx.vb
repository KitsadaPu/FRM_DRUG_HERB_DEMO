Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_INFORM_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA_IF As String = ""
    Private _LCNNO_DISPLAY As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _PROCESS_ID As String = ""
    Private _TYPEPERSON As String = ""
    Private _SID As String = ""

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
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_IF = Request.QueryString("IDA_IF")
        _LCNNO_DISPLAY = Request.QueryString("LCNNO_DISPLAY")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _TYPEPERSON = Request.QueryString("TYPEPERSON")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _SID = Request.QueryString("SID")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            RadGrid1.Rebind()
        End If
    End Sub

    Protected Sub btn_tb_herb_Click(sender As Object, e As EventArgs) Handles btn_tb_herb.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.fields.CREATE_DATE = Date.Now
        dao.insert()
        If Request.QueryString("staff") = 1 Then
            _MENU_GROUP = 1
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POPUP_HERB_TABEAN_INFORM_EDIT_ADD.aspx?PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_IF=" & _IDA_IF & "');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POPUP_HERB_TABEAN_INFORM_EDIT_ADD.aspx?PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_IF=" & _IDA_IF & "');", True)
        End If
    End Sub

    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim DAO_WHO As New DAO_WHO.TB_WHO_DALCN
        Dim TP_PERSON As Integer = 0
        dt = bao.SP_TABEAN_INFORM_EDIT_BY_FK_IDA_LCN_AND_IDEN(_IDA_LCN, _CLS.CITIZEN_ID_AUTHORIZE, _IDA_IF)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()

    End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA_LCN As Integer = item("FK_LCN").Text
            Dim IDA As Integer = item("IDA").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            Dim TR_ID As Integer = item("TR_ID").Text
            Dim PROCESS_ID As Integer = item("PROCESS_ID").Text

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(IDA_LCN)
            Dim TR_ID_LCN As String = dao_lcn.fields.TR_ID

            If e.CommandName = "HL_SELECT" Then
                If STATUS_ID = 11 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_INFORM_EDIT/POPUP_HERB_TABEAN_INFORM_EDIT_REQUEST.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA=" & IDA & "&PROCESS_ID=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&staff=" & Request.QueryString("staff") & "');", True)
                Else
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_INFORM_EDIT/POPUP_HERB_TABEAN_INFORM_EDIT_CONFIRM.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA=" & IDA & "&PROCESS_ID=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&staff=" & Request.QueryString("staff") & "');", True)
                End If
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_INFORM_EDIT/POPUP_HERB_TABEAN_INFORM_EDIT_CONFIRM.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA=" & IDA & "&PROCESS_ID=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&staff=" & Request.QueryString("staff") & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim STATUS_ID As String = item("STATUS_ID").Text

            Dim HL1_SELECT As LinkButton = DirectCast(item("HL1_SELECT").Controls(0), LinkButton)
            Dim HL2_SELECT As LinkButton = DirectCast(item("HL2_SELECT").Controls(0), LinkButton)
            'Dim HL3_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            'Dim HL4_SELECT As LinkButton = DirectCast(item("HL4_SELECT").Controls(0), LinkButton)
            'Dim HL5_SELECT As LinkButton = DirectCast(item("HL5_SELECT").Controls(0), LinkButton)

            HL1_SELECT.Style.Add("display", "none")
            HL2_SELECT.Style.Add("display", "none")
            'HL3_SELECT.Style.Add("display", "none")
            'HL4_SELECT.Style.Add("display", "none")
            'HL5_SELECT.Style.Add("display", "none")

            Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
            ' Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=HERB&acc_type=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            If Request.QueryString("staff") <> "" Then
                urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID & "&system=staffherb"
            Else
                urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID & "&system=herb"
            End If

            Dim H As HyperLink = e.Item.FindControl("HL5_SELECT")
            H.Style.Add("display", "none")
            H.Target = "_blank"
            H.NavigateUrl = urls

            If STATUS_ID = 8 Then
                'HL2_SELECT.Style.Add("display", "block")
                'HL1_SELECT.Style.Add("display", "block")
                'HL4_SELECT.Style.Add("display", "block")
                'ElseIf STATUS_ID = 6 Or STATUS_ID = 11 Or STATUS_ID = 12 Or STATUS_ID = 13 Then
                'ElseIf STATUS_ID >= 1 Then
                '    HL1_SELECT.Style.Add("display", "block")

            End If
            If STATUS_ID = 3 Then
                'HL3_SELECT.Style.Add("display", "block")
            ElseIf STATUS_ID = 6 Then
                H.Style.Add("display", "block")
                'HL4_SELECT.Style.Add("display", "block")
            ElseIf STATUS_ID = 13 Then
                'HL4_SELECT.Style.Add("display", "block")
            End If
        End If
    End Sub

End Class