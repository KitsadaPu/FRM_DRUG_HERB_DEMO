Public Class POPUP_LCN_TRANSFER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _pvncd As Integer
    Private _ProcessID As Integer
    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        get_pvncd()
        Set_Label(_CLS.CITIZEN_ID_AUTHORIZE)
        If Not IsPostBack Then
            If _ProcessID = "122" Then
                rdl_lcn_type.SelectedValue = "1"
            ElseIf _ProcessID = "121" Then
                rdl_lcn_type.SelectedValue = "2"
            ElseIf _ProcessID = "120" Then
                rdl_lcn_type.SelectedValue = "3"
            End If
        End If
    End Sub

    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub

    Sub Set_Label(ByVal CITIZEN_ID_AUTHORIZE As String)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        dt_lcn = bao.SP_Lisense_Name_and_Addr(CITIZEN_ID_AUTHORIZE) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        '
        For Each dr As DataRow In dt_lcn.Rows
            Try
                txt_location_trnf.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_floor.Text = dr("floor")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_lcn_room.Text = dr("room")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_lcn_ages.Text = dr("age")
            'Catch ex As Exception

            'End Try
            Try
                txt_trnf_amphor.Text = dr("amphrnm")
            Catch ex As Exception

            End Try
            Try
                txt_trnf_building.Text = dr("building")
            Catch ex As Exception

            End Try
            Try
                txt_trnf_changwat.Text = dr("chngwtnm")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_email.Text = dr("email")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_lcn_fax.Text = dr("fax")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_lcn_iden.Text = dr("identify")
            'Catch ex As Exception

            'End Try
            Try
                txt_trnf_iden.Text = dr("identify")
            Catch ex As Exception

            End Try
            Try
                txt_trnf_mu.Text = dr("mu")
            Catch ex As Exception

            End Try
            Try
                txt_name.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_nation.Text = dr("nation")
            'Catch ex As Exception

            'End Try
            Try
                txt_trnf_road.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                txt_trnf_soi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                txt_trnf_tambol.Text = dr("thmblnm")
            Catch ex As Exception

            End Try
            Try
                txt_lcn_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                txt_trnf_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next

        Dim dt_bsn As New DataTable
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(Request.QueryString("identify"))
        For Each dr As DataRow In dt_bsn.Rows

            Try
                txt_operator_name.Text = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
        Next

        Dim dt_lcp As New DataTable
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(Request.QueryString("lcn_ida"))
        Try
            txt_phr_name.Text = dao_phr.fields.PHR_NAME
        Catch ex As Exception

        End Try
        'Try
        '    lbl_PHR_prefix.Text = dao_phr.fields.PHR_PREFIX_NAME
        'Catch ex As Exception

        'End Try
        Dim lcnno As String = ""
        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        dao_dal.GetDataby_IDA(Request.QueryString("lcn_ida"))
        'Try
        '    txt_lcnno.Text = dao_dal.fields.LCNNO_DISPLAY
        'Catch ex As Exception

        'End Try
        Try
            txt_name_business.Text = dao_dal.fields.thanm
        Catch ex As Exception

        End Try
        Try
            If Right(Left(dao_dal.fields.lcnno, 3), 1) Then
                lcnno = dao_dal.fields.pvnabbr & " " & CInt(Right(dao_dal.fields.lcnno, 2)) & "/" & Left(dao_dal.fields.lcnno, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            If dao_dal.fields.lcnno IsNot Nothing Then
                Dim raw_lcn As String = dao_dal.fields.lcnno
                txt_lcnno.Text = lcnno 'CStr(CInt((Right(raw_lcn, 5))) & "/25" & Left(raw_lcn, 2))
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class