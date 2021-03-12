Public Class UC_CONFIRM_REPRESENT
    Inherits System.Web.UI.UserControl

    Private _IDA As String
    ' Private _CLS As New CLS_SESSION
    Private _iden As String
    Private _lct_ida As String
    Private _ID_DALCN As String
    Sub RunQuery()
        Try
            '_lct_ida = Request.QueryString("lct_ida")
            '_ID_DALCN = Request.QueryString("ID_DALCN")
            _IDA = Request.QueryString("ID")
            '_iden = Request.QueryString("identify")
            ' _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        set_label()
        'Label3.Text = Request.QueryString("ID_LCN")
    End Sub
    Sub set_label()
        Dim dao_re As New DAO_DRUG.ClsDBlcn_represent
        dao_re.GetDataby_id(_IDA)
        label17.Text = dao_re.fields.NOTE
        _ID_DALCN = dao_re.fields.ID_DALCN
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_ID_DALCN)
        _lct_ida = dao.fields.LOCATION_ADDRESS_IDA
        _iden = dao.fields.syslcnsnm_identify
        label16.Text = dao.fields.opentime
        label4.Text = dao.fields.LCNNO_MANUAL
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        dt_lcn = bao.SP_Lisense_Name_and_Addr(_iden) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        For Each dr As DataRow In dt_lcn.Rows
            Try
                lbl_lcn_name.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try

        Next
        Dim dt_bsn As New DataTable
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_ID_DALCN)
        For Each dr As DataRow In dt_bsn.Rows

            Try
                lbl_BSN_IDENTIFY.Text = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try

            Try
                lbl_BSN_THAIFULLNAME.Text = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
        Next
        Dim dt_lct As New DataTable
        dt_lct = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(_lct_ida)
        For Each dr As DataRow In dt_lct.Rows
            'Try
            '    lbl_lct_HOUSENO.Text = dr("HOUSENO")
            'Catch ex As Exception

            'End Try
            Try
                lbl_lct_thanameplace.Text = dr("thanameplace")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thachngwtnm.Text = dr("thachngwtnm")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lct_fax.Text = dr("fax")
            'Catch ex As Exception

            'End Try
            Try
                lbl_lct_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thaaddr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thaamphrnm.Text = dr("thaamphrnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thabuilding.Text = dr("thabuilding")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thamu.Text = dr("thamu")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_tharoad.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thasoi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thathmblnm.Text = dr("thathmblnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next




    End Sub

End Class