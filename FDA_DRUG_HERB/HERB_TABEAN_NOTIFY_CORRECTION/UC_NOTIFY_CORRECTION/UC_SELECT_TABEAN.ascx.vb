Imports Telerik.Web.UI
Imports Telerik.Web.UI.PivotGrid.Core.Totals

Public Class UC_SELECT_TABEAN
    Inherits System.Web.UI.UserControl


    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _Process_ID As String = ""

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
        _IDA = Request.QueryString("IDA")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub
    Function bind_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_TB As New BAO_TABEAN_HERB.tb_main
        Dim dt As DataTable
        Dim index As Integer = 0
        If DD_TYPE_TABEAN.SelectedValue = 21410 Then
            dt = bao.SP_XML_TABEAN_HERB_BY_IDEN_V2(_CLS.CITIZEN_ID_AUTHORIZE)
            Panel2.Style.Add("display", "block")
            dt.Columns.Add("ID")
            For Each item As DataRow In dt.Rows
                index += 1
                item("ID") = index
            Next
        ElseIf DD_TYPE_TABEAN.SelectedValue = 21420 Then
            dt = bao_TB.SP_TABEAN_INFORM_EDIT_BY_FK_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)
            Panel2.Style.Add("display", "block")
            dt.Columns.Add("ID")
            For Each item As DataRow In dt.Rows
                index += 1
                item("ID") = index
            Next
        ElseIf DD_TYPE_TABEAN.SelectedValue = 21430 Then
            dt = bao.SP_XML_TABEAN_JJ_BY_IDEN_V3(_CLS.CITIZEN_ID_AUTHORIZE)
            Panel2.Style.Add("display", "block")
            dt.Columns.Add("ID")
            For Each item As DataRow In dt.Rows
                index += 1
                item("ID") = index
            Next
        Else
            DD_TYPE_TABEAN.SelectedValue = 21410
            dt = bao.SP_XML_TABEAN_HERB_BY_IDEN_V2(_CLS.CITIZEN_ID_AUTHORIZE)
            Panel2.Style.Add("display", "block")
            dt.Columns.Add("ID")
            For Each item As DataRow In dt.Rows
                index += 1
                item("ID") = index
            Next
        End If

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()

    End Sub
    Sub SAVE_DATA()
        Dim IDA_DR As Integer = 0
        Dim IDA_LCN As Integer = 0
        Dim IDA_LCT As String = 0
        Dim TR_ID As String = ""
        Dim RGTNO_FULL As String = ""
        Dim RCVNO_FULL As String = ""
        Dim LCNNO_DISPLAY_NEW As String = ""
        Dim DRUG_NAME As String = ""
        Dim DRUG_NAME_ENG As String = ""
        Dim RCVNO As Integer = 0
        Dim PROCESS_ID As Integer = 0
        For Each item As GridDataItem In RadGrid1.SelectedItems
            IDA_DR = item("IDA").Text
            TR_ID = item("TR_ID").Text
            IDA_LCN = item("FK_LCN").Text
            IDA_LCT = item("FK_LCT").Text
            PROCESS_ID = item("PROCESS_ID").Text
            RGTNO_FULL = item("RGTNO_FULL").Text
            DRUG_NAME = item("NAME_THAI").Text
            DRUG_NAME_ENG = item("NAME_ENG").Text
            LCNNO_DISPLAY_NEW = item("LCNNO_DISPLAY_NEW").Text

            Dim dao_list As New DAO_TABEAN_HERB.TB_TABEAN_NOTIFY_LIST
            dao_list.fields.FK_IDA = _IDA
            dao_list.fields.TR_ID = TR_ID
            dao_list.fields.PROCESS_ID = PROCESS_ID
            dao_list.fields.FK_LCN = IDA_LCN
            dao_list.fields.FK_LCT = IDA_LCT
            dao_list.fields.RCVNO = RCVNO_FULL
            dao_list.fields.ACTIVEFACT = 1
            dao_list.fields.RGTNO_FULL = RGTNO_FULL
            dao_list.fields.DRUG_NameTH = DRUG_NAME
            dao_list.fields.DRUG_NameENG = DRUG_NAME_ENG
            dao_list.fields.LCNNO_NEW = LCNNO_DISPLAY_NEW
            'dao_up.fields.CREATE_DATE = Date.Now
            dao_list.insert()

        Next
        'RadGrid1.SelectedIndexes.Clear()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_NOTIFY
        dao.GetdatabyID_IDA(_IDA)
        dao.fields.PROCESS_NAME = DD_TYPE_TABEAN.SelectedItem.Text
        dao.fields.PROCESS_ID = DD_TYPE_TABEAN.SelectedValue
        dao.Update()
    End Sub
    Protected Sub DD_TYPE_TABEAN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_TYPE_TABEAN.SelectedIndexChanged
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim bao_TB As New BAO_TABEAN_HERB.tb_main
        'Dim dt As DataTable
        'Dim index As Integer = 0
        'If DD_TYPE_TABEAN.SelectedValue = 21410 Then
        '    dt = BAO.SP_XML_TABEAN_HERB_BY_IDEN_V2(_CLS.CITIZEN_ID_AUTHORIZE)
        '    Panel2.Style.Add("display", "block")
        '    dt.Columns.Add("ID")
        '    For Each item As DataRow In dt.Rows
        '        index += 1
        '        item("ID") = Index
        '    Next
        'ElseIf DD_TYPE_TABEAN.SelectedValue = 21420 Then
        '    dt = bao_TB.SP_TABEAN_INFORM_EDIT_BY_FK_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)
        '    Panel2.Style.Add("display", "block")
        '    dt.Columns.Add("ID")
        '    For Each item As DataRow In dt.Rows
        '        index += 1
        '        item("ID") = index
        '    Next
        'ElseIf DD_TYPE_TABEAN.SelectedValue = 21430 Then
        '    dt = bao.SP_XML_TABEAN_JJ_BY_IDEN_V3(_CLS.CITIZEN_ID_AUTHORIZE)
        '    Panel2.Style.Add("display", "block")
        '    dt.Columns.Add("ID")
        '    For Each item As DataRow In dt.Rows
        '        index += 1
        '        item("ID") = Index
        '    Next
        'End If
        RadGrid1.Rebind()
    End Sub
End Class