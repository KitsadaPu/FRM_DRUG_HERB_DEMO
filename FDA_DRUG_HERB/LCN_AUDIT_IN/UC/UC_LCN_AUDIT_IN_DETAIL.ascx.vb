Public Class UC_LCN_AUDIT_IN_DETAIL
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
    Sub get_data(ByVal IDA_LCN As Integer)
        Dim bao_show As New BAO_SHOW
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(IDA_LCN)
        Dim dao_A As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_A.GetDataby_IDA(dao.fields.FK_IDA)
        Dim dao_B As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_B.GetDataby_LCN_IDA(dao.fields.IDA)
        With dao.fields

            txt_location_name.Text = .thanameplace
            txt_tel.Text = .tel
            txt_fax.Text = .fax
        End With
        txt_lcnno_dispaly.Text = dao.fields.LCNNO_DISPLAY_NEW
        txt_Name.Text = dao_B.fields.BSN_THAIFULLNAME

        Dim dt As New DataTable
        dt = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao.fields.FK_IDA)
        For Each drr As DataRow In dt.Rows
            Try
                txt_location_addr.Text = drr("fulladdr")
            Catch ex As Exception

            End Try
        Next
    End Sub
    Sub save_data(ByRef dao As DAO_LCN.TB_DALCN_AUDIT_IN)
        With dao.fields
            .AUDIT_NAME = txt_Name.Text
            .LCNNO_NEW = txt_lcnno_dispaly.Text
            .Loacation_Name = txt_location_name.Text
            .tel = txt_tel.Text
            .Fax = txt_fax.Text
            .WRITE_AT = Txt_Write_At.Text
            .WRITE_DATE = txt_Write_Date.Text
            .Loacation_ADDR = txt_location_addr.Text
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
        End With

        'Return dao
    End Sub
    Protected Sub RDB_CER_PRO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RDB_CER_PRO.SelectedIndexChanged
        If RDB_CER_PRO.SelectedValue = 2 Then
            RDB_SUB_CER_PRO.Enabled = True
        Else
            RDB_SUB_CER_PRO.Enabled = False
        End If
    End Sub
End Class