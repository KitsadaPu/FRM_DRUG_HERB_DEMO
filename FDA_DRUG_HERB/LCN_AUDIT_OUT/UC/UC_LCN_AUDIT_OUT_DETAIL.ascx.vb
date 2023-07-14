Imports Telerik.Web.UI
Public Class UC_LCN_AUDIT_OUT_DETAIL
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Protected Sub CBL_FILE_UP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBL_FILE_UP.SelectedIndexChanged
    '    Try
    '        For Each li As ListItem In CBL_FILE_UP.Items
    '            If li.Value = 6 Then
    '                If li.Selected Then
    '                    orther_up.Visible = True
    '                Else
    '                    orther_up.Visible = False
    '                End If
    '            End If
    '        Next
    '    Catch ex As Exception
    '        orther_up.Visible = False
    '    End Try
    'End Sub
    Shared PLACE_IDA As Integer = 0
    Shared PLACE_NAME As String = ""
    Shared PLACE_ADDRESS As String = ""
    Shared IDA_ADDRESS As Integer = 0
    Sub get_data(ByVal IDA_LCN As Integer)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(IDA_LCN)
        Dim dao_A As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_A.GetDataby_IDA(dao.fields.FK_IDA)
        Dim dao_B As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_B.GetDataby_LCN_IDA(dao.fields.IDA)
        With dao_A.fields
            txt_lcnno_dispaly.Text = dao.fields.LCNNO_DISPLAY_NEW
            txt_loacation_name.Text = .thanameplace
            txt_tel.Text = .tel
            txt_fax.Text = .fax
        End With
        txt_Name.Text = dao_B.fields.BSN_THAIFULLNAME
    End Sub
    Sub save_data(ByRef dao As DAO_LCN.TB_DALCN_AUDIT_OUT)
        With dao.fields
            .WRITE_DATE = txt_Write_Date.Text
            .WRITE_AT = Txt_Write_At.Text
            .AUDIT_NAME = txt_Name.Text
            .LCNNO_NEW = txt_lcnno_dispaly.Text
            .Loacation_Name = txt_loacation_name.Text
            .tel = txt_tel.Text
            .Fax = txt_fax.Text
            Try
                .CER_PRODUCT_ID = RDB_CER_PRO.SelectedValue
                .CER_PRODUCT_NM = RDB_CER_PRO.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                .SUB_CER_PRODUCT_ID = RDB_SUB_CER_PRO.SelectedValue
                .SUB_CER_PRODUCT_NM = RDB_SUB_CER_PRO.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                .FOREIGN_NAME_ID = txt_search_ida.Text
                .FOREIGN_NAME = striptags(txt_search.Text)
                .FOREIGN_NAME_PLACE_ID = txt_address_ida.Text
                .FOREIGN_NAME_PLACE = txt_address.Text.ToUpper()
            Catch ex As Exception

            End Try
        End With

    End Sub
    Public Function striptags(ByVal html As String) As String
        Return Regex.Replace(html, "\s", "")
    End Function
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_frgn()
    End Sub
    Protected Sub RDB_CER_PRO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RDB_CER_PRO.SelectedIndexChanged
        If RDB_CER_PRO.SelectedValue = 2 Then
            RDB_SUB_CER_PRO.Enabled = True
        Else
            RDB_SUB_CER_PRO.Enabled = False
        End If
    End Sub
    Sub Search_frgn()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_syspdcfrgn_SEARCH(txt_search.Text)

        RadGrid2.DataSource = dt
        RadGrid2.Rebind()
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        If txt_search.Text <> "" Then
            Search_frgn()
        End If
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim frgncd As Integer = 0
            Dim PLACE_NAME_THAI As String = ""
            Dim PLACE_NAME_ENG As String = ""

            PLACE_IDA = item("IDA").Text
            PLACE_NAME_THAI = item("thafrgnnm").Text
            PLACE_NAME_ENG = item("engfrgnnm").Text

            PLACE_NAME = PLACE_NAME_ENG.Replace("&nbsp;", "") & " " & PLACE_NAME_THAI.Replace("&nbsp;", "")
            txt_search.Text = PLACE_NAME
            txt_search_ida.Text = PLACE_IDA

            Try
                frgncd = item("frgncd").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dt As New DataTable
                Dim bao As New BAO_SHOW
                dt = bao.SP_drfrgnaddr_BY_frgncd(frgncd)
                HiddenField1.Value = frgncd
                RadGrid3.DataSource = dt

                RadGrid3.Rebind()

            End If

        End If
    End Sub

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource

    End Sub

    Private Sub RadGrid3_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid3.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "sel" Then
                IDA_ADDRESS = item("IDA").Text
                PLACE_ADDRESS = item("fulladdr4").Text

                txt_address.Text = PLACE_ADDRESS
                txt_address_ida.Text = IDA_ADDRESS
                txt_address.Text.ToUpper()
            End If
        End If
    End Sub
End Class