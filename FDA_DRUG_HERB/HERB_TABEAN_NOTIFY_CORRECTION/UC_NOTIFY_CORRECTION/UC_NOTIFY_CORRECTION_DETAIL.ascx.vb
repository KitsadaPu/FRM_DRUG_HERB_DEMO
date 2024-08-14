Imports Telerik.Web.UI
Public Class UC_NOTIFY_CORRECTION_DETAIL
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
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

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _IDA = Request.QueryString("IDA")
        _IDA_DR = Request.QueryString("IDA_DR")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _Process_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then

        End If
    End Sub
    Function bind_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        dt = bao.SP_MAS_TABEAN_HERB_NOTIFY_CORRECTION()

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()

    End Sub
    Function bind_data2()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        dt = bao.SP_MAS_TABEAN_HERB_NOTIFY_CORRECTION2()

        Return dt
    End Function

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data2()

    End Sub
    Function bind_data3()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        dt = bao.SP_MAS_TABEAN_HERB_NOTIFY_CORRECTION_LIST_EDIT(_IDA)
        txt_numb_edit.Text = dt.Rows.Count()
        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data3()
    End Sub
    Public Sub BindTable()

        Dim dao_sub As New DAO_TABEAN_HERB.TB_TABEAN_NOTIFY
        dao_sub.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = 0
        Dim dao_list As New DAO_TABEAN_HERB.TB_TABEAN_NOTIFY_LIST

        'TR_ID = dao_sub.fields.TR_ID
        'dao_list.GetdatabyID_TR_ID(TR_ID_JJ)
        'dao_list.GetdatabyID_TR_ID_PROCESS_TYPE(TR_ID_JJ, _PROCESS_ID, 1)
        dao_list.GetdatabyID_FK_IDA(_IDA)
        'tb_type_menu.Rows.
        Dim rows As Integer = 1
        Dim numbs As Integer = 0
        For Each dao_list.fields In dao_list.datas
            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tc.Width = 50
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_list.fields.IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            Try
                tc.Text = Replace("ชื่อ", "\n", "<br/>")
            Catch ex As Exception
                tc.Text = "ชื่อ"
            End Try
            tc.Width = 100
            tr.Cells.Add(tc)

            tc = New TableCell
            Try
                tc.Text = Replace(dao_list.fields.DRUG_NameTH, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_list.fields.DRUG_NameTH
            End Try
            tc.Width = 500
            tr.Cells.Add(tc)

            tc = New TableCell
            Try
                tc.Text = Replace("เลขที่อนุญาต", "\n", "<br/>")
            Catch ex As Exception
                tc.Text = "เลขที่อนุญาต"
            End Try
            tc.Width = 200
            tr.Cells.Add(tc)

            tc = New TableCell
            'tc.Text = dao_list.fields.NAME_REAL
            Try
                tc.Text = dao_list.fields.RGTNO_FULL
            Catch ex As Exception
                tc.Text = ""
            End Try
            tc.Width = 300
            tr.Cells.Add(tc)

            tb_type_menu.Rows.Add(tr)
            rows = rows + 1
            numbs = numbs + 1
        Next

        txt_numb_tabean.Text = numbs
    End Sub
    Sub SAVE_NAME_UP(ByVal TR_ID As Integer)
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_up.GetdatabyID_TR_ID(TR_ID)
        dao_up.fields.DOCUMENT_NAME = txt_upload_name.Text
        dao_up.Update()
    End Sub
    Sub ADD_DATA_ListEdit()
        Dim ID As String = ""
        Dim IDsub As String = ""
        Dim EDIT_NAME As String = ""
        Dim SEQ As String = ""
        Dim IDnumb As String = "1."
        Dim IDnumb2 As String = "2."
        Dim i As Integer = 0
        Dim ii As Integer = 0
        For Each item As GridDataItem In RadGrid1.SelectedItems
            ID = item("ID").Text
            IDsub = item("IDsub").Text
            EDIT_NAME = item("EditingStyle").Text
            i += 1
            Dim dao_list As New DAO_TABEAN_HERB.TB_TABEAN_NOTIFY_LIST_EDIT
            dao_list.fields.FK_IDA = _IDA
            dao_list.fields.ID = ID
            dao_list.fields.IDsub = IDnumb & i
            dao_list.fields.FK_IDA = _IDA
            dao_list.fields.EditingStyle_ID = 1
            dao_list.fields.EditingStyle_Name = EDIT_NAME
            dao_list.fields.SEQ = i
            dao_list.fields.Active = 1
            dao_list.fields.CREATE_DATE = Date.Now
            dao_list.insert()

        Next
        For Each item As GridDataItem In RadGrid2.SelectedItems
            ID = item("ID").Text
            IDsub = item("IDsub").Text
            EDIT_NAME = item("EditingStyle").Text
            ii += 1
            i += 1
            Dim dao_list As New DAO_TABEAN_HERB.TB_TABEAN_NOTIFY_LIST_EDIT
            dao_list.fields.FK_IDA = _IDA
            dao_list.fields.ID = ID
            dao_list.fields.IDsub = IDnumb2 & ii
            dao_list.fields.FK_IDA = _IDA
            dao_list.fields.EditingStyle_ID = 1
            dao_list.fields.EditingStyle_Name = EDIT_NAME
            dao_list.fields.SEQ = i
            dao_list.fields.Active = 1
            dao_list.fields.CREATE_DATE = Date.Now
            dao_list.insert()

        Next
        'RadGrid1.SelectedIndexes.Clear()
    End Sub

    Protected Sub BTN_ADD2_Click(sender As Object, e As EventArgs) Handles BTN_ADD2.Click
        ADD_DATA_ListEdit()
        RadGrid3.Rebind()
        Panel3.Style.Add("display", "block")
    End Sub
End Class