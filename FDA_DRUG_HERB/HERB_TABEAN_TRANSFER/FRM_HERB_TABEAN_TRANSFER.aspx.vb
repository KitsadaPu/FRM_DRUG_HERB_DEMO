Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_HERB_TABEAN_TRANSFER
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA_DR As String = ""
    Private _PROCESS_ID As String = ""
    Private _PROCESS_DR As String = ""

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
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_ddl_rgtno()
        End If
    End Sub
    Function bind_data()
        Dim dt As New DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        'Dim DAO_WHO As New DAO_WHO.TB_WHO_DALCN
        'DAO_WHO.GetdatabyID_FK_LCN(_IDA_LCN)
        dt = bao.SP_TABEAN_HERB_TRANSFER_BY_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)

        Return dt
    End Function
    Sub bind_ddl_rgtno()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DDL_TABEAN_HERB_BY_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)

        DD_TABEAN_NO.DataSource = dt
        DD_TABEAN_NO.DataTextField = "RGTNO_FULL"
        DD_TABEAN_NO.DataValueField = "IDA"
        DD_TABEAN_NO.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = ""
        DD_TABEAN_NO.Items.Insert(0, item)
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA_LCN As String = item("FK_LCN").Text
            Dim IDA_LCT As String = item("FK_LCT").Text
            Dim IDA As Integer = item("IDA").Text
            Dim IDA_DR As Integer = item("FK_DRRQT").Text
            Dim FK_TABEAN_HERB As Integer = item("FK_TABEAN_HERB").Text
            Dim FK_IDA As Integer = item("FK_IDA").Text
            Dim TR_ID As Integer = item("TR_ID").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            If e.CommandName = "sel" Then

                If STATUS_ID = 1 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "POPUP_HERB_TABEAN_TRANSFER_CONFIRM.aspx?IDA_LCT=" &
                                                                      IDA_LCT & "&IDA_DR=" & IDA_DR & "&IDA_LCN=" & IDA_LCN & "&IDA_TABEAN_HERB=" & FK_TABEAN_HERB & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "POPUP_HERB_TABEAN_TRANSFER_CONFIRM.aspx?IDA_LCT=" &
                                                                     IDA_LCN & "&IDA_DR=" & IDA_DR & "&IDA_LCN=" & IDA_LCN & "&IDA_TABEAN_HERB=" & FK_TABEAN_HERB & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID & "');", True)
                End If

            End If
        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()                         'เรียกฟังก์ชั่น  load_GV_JJ   มาใช้งาน
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_TRANSFER
        If DD_TABEAN_NO.SelectedValue = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกทะเบียน');", True)
        Else
            Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
            dao_drrqt.GetDataby_IDA(DD_TABEAN_NO.SelectedValue)
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_drrqt.fields.FK_LCN_IDA)
            Dim dao_tbn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao_tbn.GetdatabyID_FK_IDA_DQ(DD_TABEAN_NO.SelectedValue)
            dao.fields.PROCESS_ID = _PROCESS_ID
            dao.fields.FK_IDA = DD_TABEAN_NO.SelectedValue
            dao.fields.FK_LCN = dao_drrqt.fields.FK_LCN_IDA
            dao.fields.PROCESS_ID_TABEAN = dao_drrqt.fields.PROCESS_ID
            dao.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_HERB_TABEAN_TRANSFER_ADD.aspx?IDA_DR=" & DD_TABEAN_NO.SelectedValue _
                & "&IDA_DQ=" & dao_drrqt.fields.IDA & "&PROCESS_ID=" & _PROCESS_ID & "&PROCESS_ID_DQ=" & dao_drrqt.fields.PROCESS_ID & "&PROCESS_ID_LCN=" & dao_lcn.fields.PROCESS_ID & "&IDA_LCN=" & dao_lcn.fields.IDA & "&IDA=" & dao.fields.IDA & "');", True)
        End If
    End Sub

    Protected Sub DD_TABEAN_NO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_TABEAN_NO.SelectedIndexChanged
        If DD_TABEAN_NO.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกทะเบียน');", True)
        End If
    End Sub
End Class