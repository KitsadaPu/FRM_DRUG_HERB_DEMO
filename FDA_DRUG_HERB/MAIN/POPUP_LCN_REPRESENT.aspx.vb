Public Class POPUP_LCN_REPRESENT
    Inherits System.Web.UI.Page
    Private _IDA As String
    ' Private _CLS As New CLS_SESSION
    Private _iden As String
    Private _lct_ida As String
    Sub RunQuery()
        Try
            _lct_ida = Request.QueryString("lct_ida")
            _IDA = Request.QueryString("IDA")
            _iden = Request.QueryString("identify")
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
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
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
        dt_lct = BAO_SHOW.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(_lct_ida)
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
        label4.Text = Request.QueryString("ID_LCN")
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        label16.Text = dao.fields.opentime

    End Sub
    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim regDate As Date = Date.Now()
        Dim dao As New DAO_DRUG.ClsDBlcn_represent
        With dao
            .fields.DATE = regDate
            .fields.ID_DALCN = Request.QueryString("IDA")
            .fields.NOTE = TextBox1.Text
            .fields.rcbno = 0
            .fields.STATUS_ID = 1
            .fields.TR_ID = 1
            .insert()
            .fields.TR_ID = .fields.IDA
            .update()
        End With
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)

    End Sub
End Class