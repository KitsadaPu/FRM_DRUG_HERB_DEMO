Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_SUB_MENU
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA_LCT As String = ""

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
        _IDA_LCN = Request.QueryString("lcn_ida")
        _IDA_LCT = Request.QueryString("lct_ida")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Bind_Buttom_Menu()
        End If
    End Sub

    Private Sub btn_tabean_sub_Click(sender As Object, e As EventArgs) Handles btn_tabean_sub.Click
        'T1.Visible = True
        'RadGrid1.Rebind()
        Response.Redirect("../HERB_TABEAN_SUBSTITUTE/FRM_TABEAN_SUBSTITUTE_MAIN.aspx?T&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN)
    End Sub

    Function bind_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        '"0000000000000"
        Dim CID As String = _CLS.CITIZEN_ID_AUTHORIZE
        'dt = bao.SP_CUSTOMER_LCN_DR_BY_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE)
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
            Dim PROCESS_ID As String = item("PROCESS_ID").Text

            Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
            H.NavigateUrl = "FRM_TABEAN_SUBSTITUTE_MAIN.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & PROCESS_ID '& "&PROCESS_ID=" & 20801 'URL หน้า ยืนยัน

        End If
    End Sub

    Protected Sub btn_tabean_edit_Click(sender As Object, e As EventArgs) Handles btn_tabean_edit.Click
        Response.Redirect("../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_MAIN.aspx?MENU_GROUP=2" & "&PROCESS_ID=" & 20430)
    End Sub

    Protected Sub btn_tabean_date_Click(sender As Object, e As EventArgs) Handles btn_tabean_date.Click
        Response.Redirect("../HERB_TABEAN_RENEW/FRM_HERB_TABEAN_RENEW_MAIN.aspx?MENU_GROUP=2" & "&IDA_LCN=" & _IDA_LCN & "&IDA_LCT=" & _IDA_LCT)
    End Sub

    Public Sub Bind_Buttom_Menu()
        Dim dao_h As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
        Dim dao_M As New DAO_DRUG.ClsDBMAS_MENU_AUTO
        dao_M.GetDataby_HEAD_ID(0, 4)
        Dim gg As String = ""
        Dim str_all As String = ""
        Dim p_name As String = ""
        'str_all &= "<ul class='nav nav-pills nav-stacked'>"
        For Each dao_M.fields In dao_M.datas
            If str_all = "" Then
                Dim i As Integer = 0
                If p_name = "" Then
                    'i = dao_u.Check_Page(p_name, _CLS.Groups)
                    Try
                        p_name = get_page_name()
                    Catch ex As Exception

                    End Try
                    Try
                        If CStr(dao_M.fields.URL).Contains(p_name) Then
                            i += 1
                        End If
                    Catch ex As Exception

                    End Try
                    If i = 0 Then
                        str_all &= "<li>"
                    Else
                        str_all &= "<li class='active'>"
                    End If
                    str_all &= "<a href='" & dao_M.fields.URL & "' target='_blank'>" & dao_M.fields.NAME & "</a>"
                    str_all &= "</li>"
                End If
            Else
                'str_all &= "<h4 class='text-center'><strong>" & dao_h.fields.GROUP_NAME & "</strong></h4>"
                Dim i As Integer = 0
                If p_name <> "" Then
                    'i = dao_u.Check_Page(p_name, _CLS.Groups)
                    Try
                        If CStr(dao_M.fields.URL).Contains(p_name) Then
                            i += 1
                        End If
                    Catch ex As Exception

                    End Try
                    str_all &= "<a href='" & dao_M.fields.URL & "' target='_blank'>" & dao_M.fields.NAME & "</a>"
                End If
            End If
        Next
        'str_all &= "</ul>"
        Literal1.Text = str_all
    End Sub
    Function get_page_name()
        Dim p_name As String = ""
        p_name = System.IO.Path.GetFileName(Request.Url.AbsolutePath)
        Return p_name
    End Function

    Sub CreateDynamicButton()
        ' Create a Button object 
        Dim dynamicButton As New Button
        ' Set Button properties
        'dynamicButton.Location = New Point(20, 150)
        dynamicButton.Height = 40
        dynamicButton.Width = 300
        ' Set background and foreground
        'dynamicButton.BackColor = color.Red
        'dynamicButton.ForeColor = Color.Blue
        dynamicButton.Text = "I am Dynamic Button"
        'dynamicButton.name = "DynamicButton"
        dynamicButton.Style.Add("Color", "Red")
        dynamicButton.Style.Add("border-color", "Blue")
        'dynamicButton.Font = New Font("Georgia", 16)
        AddHandler dynamicButton.Click, AddressOf DynamicButton_Click
        ' Add Button to the Form. Placement of the Button
        ' will be based on the Location and Size of button
        Controls.Add(dynamicButton)
    End Sub
    Private Sub DynamicButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        alert("Dynamic Button is clicked.")
    End Sub
    Sub alert(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _ProcessID & "&IDA=" & _IDA
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
End Class