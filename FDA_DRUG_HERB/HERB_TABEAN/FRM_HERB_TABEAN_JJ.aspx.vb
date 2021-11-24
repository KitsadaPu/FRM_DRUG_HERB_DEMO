Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_JJ
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _LCNNO_DISPLAY As String = ""
    Private _PROCESS_ID_LCN As String = ""

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
        _LCNNO_DISPLAY = Request.QueryString("LCNNO_DISPLAY")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'bind_dd()
            RadGrid1.Rebind()
        End If
    End Sub

    Protected Sub DD_HERB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_HERB.SelectedIndexChanged
        bind_dd(DD_HERB.SelectedValue)

        If DD_HERB.SelectedValue = 20301 Then
            DD_HERB_NAME_PRODUCT.Visible = True
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = True
            herb_ya.Visible = True
        ElseIf DD_HERB.SelectedValue = 20302 Then
            DD_HERB_NAME_PRODUCT.Visible = False
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = False
            herb_ya.Visible = False
        ElseIf DD_HERB.SelectedValue = 20303 Then
            DD_HERB_NAME_PRODUCT.Visible = True
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = True
            herb_ya.Visible = True
        ElseIf DD_HERB.SelectedValue = 20304 Then
            DD_HERB_NAME_PRODUCT.Visible = False
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = False
            herb_ya.Visible = False
        Else
            DD_HERB_NAME_PRODUCT.Visible = False
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = False
            herb_ya.Visible = False
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
        End If
    End Sub

    Public Sub bind_dd(ByVal dd_herb As Integer)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd

        dt = bao.SP_DD_MAS_TABEAN_HERB_NAME_JJ(dd_herb)

        DD_HERB_NAME_PRODUCT.DataSource = dt
        DD_HERB_NAME_PRODUCT.DataBind()
        DD_HERB_NAME_PRODUCT.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Protected Sub btn_jj_herb_Click(sender As Object, e As EventArgs) Handles btn_jj_herb.Click

        If DD_HERB_NAME_PRODUCT.SelectedValue <> "-- กรุณาเลือก --" Then
            Dim DD_HERB_NAME_PRODUCT_1 As Integer = 0
            Dim DD_HERB_NAME_PRODUCT_HEALTH_2 As Integer = 0
            Dim PROCESS_JJ As Integer = 0
            PROCESS_JJ = DD_HERB.SelectedValue
            If Request.QueryString("staff") = 1 Then
                _MENU_GROUP = 1
                If DD_HERB_NAME_PRODUCT.SelectedValue <> 0 Then
                    DD_HERB_NAME_PRODUCT_1 = DD_HERB_NAME_PRODUCT.SelectedValue
                    Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_1 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&staff=" & Request.QueryString("staff"))
                    'ElseIf DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue <> 0 Then
                    '    DD_HERB_NAME_PRODUCT_HEALTH_2 = DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue
                    '    Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_HEALTH_2 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&staff=" & Request.QueryString("staff"))

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
                End If
            Else

                If DD_HERB_NAME_PRODUCT.SelectedValue <> 0 Then
                    DD_HERB_NAME_PRODUCT_1 = DD_HERB_NAME_PRODUCT.SelectedValue
                    Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_1 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
                    'Response.Redirect("FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_1 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
                    'ElseIf DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue <> 0 Then
                    '    DD_HERB_NAME_PRODUCT_HEALTH_2 = DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue
                    '    Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_HEALTH_2 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
                    '
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
                End If
            End If

        Else
            alert_normal("กรุณาเลือกรายการ")
        End If

    End Sub

    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        'Dim C_ID As String = _CLS.CITIZEN_ID_AUTHORIZE
        'dt = bao.SP_TABEAN_JJ(C_ID)       
        dt = bao.SP_TABEAN_JJ(_IDA_LCN)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    'Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound

    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA_LCN As Integer = item("IDA_LCN").Text
    '        Dim TR_ID_LCN As String = item("TR_ID_LCN").Text
    '        Dim FK_IDA_LCT As String = ""
    '        Try
    '            FK_IDA_LCT = item("FK_IDA_LCT").Text
    '        Catch ex As Exception

    '        End Try
    '        Dim DD As Integer = item("DD_HERB_NAME_ID").Text
    '        Dim DD_H As Integer = item("DDHERB").Text
    '        Dim IDA As Integer = item("IDA").Text
    '        Dim TR_ID_JJ As Integer = item("TR_ID_JJ").Text
    '        Dim STATUS_ID As Integer = item("STATUS_ID").Text

    '        Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
    '        If H.Text = "ดูรายละเอียด" And STATUS_ID = 4 Then
    '            lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&process=" & DD_H & "');", True)
    '        ElseIf H.Text = "ดูรายละเอียด" Then
    '            H.NavigateUrl = "FRM_HERB_TABEAN_JJ_DETAIL.aspx?IDA_LCT=" & FK_IDA_LCT & "&TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&DDHERB=" & DD_H & "&IDA=" & IDA & "&TR_ID_JJ=" & TR_ID_JJ 'URL หน้า ยืนยัน
    '        End If

    '    End If
    'End Sub

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

            Dim IDA_LCN As Integer = item("IDA_LCN").Text
            Dim TR_ID_LCN As String = item("TR_ID_LCN").Text
            Dim FK_IDA_LCT As String = ""
            Try
                FK_IDA_LCT = item("FK_IDA_LCT").Text
            Catch ex As Exception

            End Try
            Dim DD As Integer = item("DD_HERB_NAME_ID").Text
            Dim _PROCESS_JJ As Integer = item("DDHERB").Text
            Dim IDA As Integer = item("IDA").Text
            Dim TR_ID_JJ As Integer = item("TR_ID_JJ").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text

            If e.CommandName = "HL_SELECT" Then

                If STATUS_ID = 4 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA_LCN=" & _IDA_LCN & "');", True)
                ElseIf STATUS_ID = 1 Then
                    ' Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL_CHKACC.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
                    'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL_CHKACC.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ & "');", True)
                ElseIf STATUS_ID = 2 Then
                    'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ & "');", True)
                    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ & "');", True)
                    ' Response.Redirect("FRM_HERB_TABEAN_JJ_DETAIL.aspx?IDA_LCT=" & FK_IDA_LCT & "&TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&TR_ID_JJ=" & TR_ID_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
                End If

            ElseIf e.CommandName = "HL1_SELECT" Then
                lbl_head1.Text = "คำขอจดแจ้งผลิตภัณฑ์สมุนไพร แบบ จจ.1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_PREVIEW_JJ1.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "&DD_HERB_NAME_ID=" & DD & "');", True)
            ElseIf e.CommandName = "HL2_SELECT" Then
                lbl_head1.Text = "ใบรับจดแจ้งผลิตภัณฑ์สมุนไพร แบบ จจ.2"
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_PREVIEW_JJ2.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "&DD_HERB_NAME_ID=" & DD & "');", True)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_PREVIEW_JJ2_UPLOAD.aspx?ida=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "');", True)
            ElseIf e.CommandName = "HL3_SELECT" Then
                lbl_head1.Text = "ใบนัดหมาย"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_APPOINMENT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA_LCN=" & IDA_LCN & "');", True)
            ElseIf e.CommandName = "HL4_SELECT" Then
                'Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
                'If Request.QueryString("staff") <> "" Then
                '    urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffherb"
                'Else
                '    urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=herb"
                'End If

                'Dim H As HyperLink = e.Item.FindControl("HL4_SELECT")
                'H.NavigateUrl = urls
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim TR_ID_JJ As String = item("TR_ID_JJ").Text
            Dim IDA As String = item("IDA").Text
            Dim DDHERB As String = item("DDHERB").Text


            Dim HL1_SELECT As LinkButton = DirectCast(item("HL1_SELECT").Controls(0), LinkButton)
            Dim HL2_SELECT As LinkButton = DirectCast(item("HL2_SELECT").Controls(0), LinkButton)
            Dim HL3_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            Dim HL4_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            HL1_SELECT.Style.Add("display", "none")
            HL2_SELECT.Style.Add("display", "none")
            HL3_SELECT.Style.Add("display", "none")
            HL4_SELECT.Style.Add("display", "none")

            Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
            ' Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=HERB&acc_type=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            If Request.QueryString("staff") <> "" Then
                urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=staffherb"
            Else
                urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=herb"
            End If
            Dim H As HyperLink = e.Item.FindControl("HL4_SELECT")
            H.Style.Add("display", "none")
            H.Target = "_blank"
            H.NavigateUrl = urls

            If STATUS_ID = 8 Then
                HL1_SELECT.Style.Add("display", "block")
                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(TR_ID_JJ, IDA, DDHERB)
                Dim status_upload13 As Integer = dao.fields.TYPE
                If status_upload13 = 13 Then
                    HL2_SELECT.Style.Add("display", "block")
                End If

            ElseIf STATUS_ID >= 1 Then
                HL1_SELECT.Style.Add("display", "block")
                If STATUS_ID = 6 Then
                    HL4_SELECT.Style.Add("display", "block")
                    H.Style.Add("display", "block")
                End If
            ElseIf STATUS_ID = 3 Then
                HL3_SELECT.Style.Add("display", "block")
            End If

        End If
    End Sub
End Class