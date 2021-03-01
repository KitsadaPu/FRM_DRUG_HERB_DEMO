Public Class POPUP_LCN_REQUEST_EDIT
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    ' Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _lct_ida = Request.QueryString("lct_ida")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _iden = Request.QueryString("identify")
            ' _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        Set_Label()
        setdata_DALCN()
        setdata_current_data()
        setdata_frgn_data()
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');parent.close_modal();", True)
    End Sub
    Sub Set_Label()
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        dt_lcn = bao.SP_Lisense_Name_and_Addr(_iden) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

        For Each dr As DataRow In dt_lcn.Rows
            'Try
            '    txt_da_opentime.Text = dr("thaaddr")
            'Catch ex As Exception

            'End Try
            Try
                lbl_lcn_addr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_floor.Text = dr("floor")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_room.Text = dr("room")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_ages.Text = dr("age")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_amphor.Text = dr("amphrnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_building.Text = dr("building")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_changwat.Text = dr("chngwtnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_email.Text = dr("email")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_fax.Text = dr("fax")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_iden.Text = dr("identify")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_iden2.Text = dr("identify")
            'Catch ex As Exception

            'End Try
            Try
                lbl_lcn_mu.Text = dr("mu")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_name.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_nation.Text = dr("nation")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_road.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_soi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_tambol.Text = dr("thmblnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next



        Dim dt_bsn As New DataTable
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
        For Each dr As DataRow In dt_bsn.Rows

            'Try
            '    lbl_BSN_ADDR.Text = dr("BSN_ADDR")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_FLOOR.Text = dr("BSN_FLOOR")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_ROOM.Text = dr("BSN_ROOM")
            'Catch ex As Exception

            'End Try
            Try
                lbl_BSN_AGE.Text = dr("AGE")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_BSN_AMPHR_NAME.Text = dr("BSN_AMPHR_NAME")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_BUILDING.Text = dr("BSN_BUILDING")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_FAX.Text = dr("BSN_FAX")
            'Catch ex As Exception

            'End Try
            Try
                lbl_BSN_IDENTIFY.Text = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_BSN_MOO.Text = dr("BSN_MOO")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_ROAD.Text = dr("BSN_ROAD")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_SOI.Text = dr("BSN_SOI")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_TEL.Text = dr("BSN_TEL")
            'Catch ex As Exception

            'End Try
            Try
                lbl_BSN_THAIFULLNAME.Text = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_BSN_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_ZIPCODE.Text = dr("BSN_ZIPCODE")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_thachngwtnm.Text = dr("thachngwtnm")
            'Catch ex As Exception

            'End Try
        Next

        Dim dt_lct As New DataTable
        dt_lct = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(Request.QueryString("lct_ida"))
        For Each dr As DataRow In dt_lct.Rows
            Try
                lbl_lct_HOUSENO.Text = dr("HOUSENO")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thanameplace.Text = dr("thanameplace")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thachngwtnm.Text = dr("thachngwtnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_fax.Text = dr("fax")
            Catch ex As Exception

            End Try
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
        'Dim dt_lcp As New DataTable




    End Sub
    Sub setdata_DALCN()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Try
            lbl_GIVE_PASSPORT_NO.Text = dao.fields.GIVE_PASSPORT_NO
        Catch ex As Exception

        End Try
        Try
            lbl_GIVE_PASSPORT_EXPDATE.Text = dao.fields.GIVE_PASSPORT_EXPDATE
        Catch ex As Exception

        End Try
        Try
            lbl_GIVE_WORK_LICENSE_NO.Text = dao.fields.GIVE_WORK_LICENSE_NO
        Catch ex As Exception

        End Try
        Try
            lbl_GIVE_WORK_LICENSE_EXPDATE.Text = dao.fields.GIVE_WORK_LICENSE_EXPDATE
        Catch ex As Exception

        End Try
    End Sub
    Sub setdata_current_data()
        Dim dao As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS
        dao.GetData_By_FK_IDA(_IDA)

        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_bsn As New DataTable
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA)
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)

        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(_IDA)
        If dao_frgn.fields.addr_status Is Nothing Then
            dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
            For Each dr As DataRow In dt_bsn.Rows

                Try
                    lbl_c_thaaddr.Text = dr("BSN_ADDR")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_floor.Text = dr("BSN_FLOOR")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_room.Text = dr("BSN_ROOM")
                Catch ex As Exception

                End Try
                Try
                    lbl_amphor.Text = dr("BSN_AMPHR_NAME")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thabuilding.Text = dr("BSN_BUILDING")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_fax.Text = dr("BSN_FAX")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thamu.Text = dr("BSN_MOO")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_tharoad.Text = dr("BSN_ROAD")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thasoi.Text = dr("BSN_SOI")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_tel.Text = dr("BSN_TEL")
                Catch ex As Exception

                End Try
                'Try
                '    lbl_c_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
                'Catch ex As Exception

                'End Try
                Try
                    lbl_tambol.Text = dr("BSN_THMBL_NAME")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_zipcode.Text = dr("BSN_ZIPCODE")
                Catch ex As Exception

                End Try
                Try
                    lbl_Province.Text = dr("BSN_CHWNGNAME")
                Catch ex As Exception

                End Try
            Next


        ElseIf dao_frgn.fields.addr_status IsNot Nothing Then
            dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
            For Each dr As DataRow In dt_bsn.Rows

                Try
                    lbl_c_thaaddr.Text = dr("BSN_ADDR")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_floor.Text = dr("BSN_FLOOR")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_room.Text = dr("BSN_ROOM")
                Catch ex As Exception

                End Try
                Try
                    lbl_amphor.Text = dr("BSN_AMPHR_NAME")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thabuilding.Text = dr("BSN_BUILDING")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_fax.Text = dr("BSN_FAX")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thamu.Text = dr("BSN_MOO")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_tharoad.Text = dr("BSN_ROAD")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thasoi.Text = dr("BSN_SOI")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_tel.Text = dr("BSN_TEL")
                Catch ex As Exception

                End Try
                'Try
                '    lbl_c_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
                'Catch ex As Exception

                'End Try
                Try
                    lbl_tambol.Text = dr("BSN_THMBL_NAME")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_zipcode.Text = dr("BSN_ZIPCODE")
                Catch ex As Exception

                End Try
                Try
                    lbl_Province.Text = dr("BSN_CHWNGNAME")
                Catch ex As Exception

                End Try
            Next

        End If





    End Sub

    'Sub setdata_systhmbl()
    '    Dim dao As New DAO_CPN.clsDBsyschngwt
    '    dao.GetData_by_chngwtcd()

    'End Sub
    Sub setdata_frgn_data()
        Dim dao As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao.GetDataby_FK_IDA(_IDA)
        Try
            lbl_PASSPORT_NO.Text = dao.fields.PASSPORT_NO
        Catch ex As Exception

        End Try
        Try
            lbl_PASSPORT_EXPDATE.Text = dao.fields.PASSPORT_EXPDATE
        Catch ex As Exception

        End Try
        Try
            lbl_DOC_NO.Text = dao.fields.DOC_NO
        Catch ex As Exception

        End Try
        Try
            lbl_DOC_DATE.Text = dao.fields.DOC_DATE
        Catch ex As Exception

        End Try
        Try
            lbl_WORK_LICENSE_NO.Text = dao.fields.WORK_LICENSE_NO
        Catch ex As Exception

        End Try
        Try
            lbl_WORK_LICENSE_EXPDATE.Text = dao.fields.WORK_LICENSE_EXPDATE
        Catch ex As Exception

        End Try
        Try
            lbl_BS_NO1.Text = dao.fields.BS_NO1
        Catch ex As Exception

        End Try
        Try
            lbl_BS_DATE1.Text = dao.fields.BS_DATE1
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_NO1.Text = dao.fields.FRGN_NO1
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_DATE1.Text = dao.fields.FRGN_DATE1
        Catch ex As Exception

        End Try
        Try
            lbl_BS_NO.Text = dao.fields.BS_NO
        Catch ex As Exception


        End Try
        Try
            lbl_BS_DATE.Text = dao.fields.BS_DATE
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_DATE.Text = dao.fields.FRGN_DATE
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_NO.Text = dao.fields.FRGN_NO
        Catch ex As Exception

        End Try
        Try
            cb_Personal_Type1.TabIndex = dao.fields.PERSONAL_TYPE
        Catch ex As Exception

        End Try
        Try
            cb_Personal_Type2.TabIndex = dao.fields.PERSONAL_TYPE
        Catch ex As Exception

        End Try
        Try
            rdl_sanchaat.SelectedValue = dao.fields.PERSONAL_TYPE_MENU
            If rdl_sanchaat.SelectedValue = 1 Then
                TB_Personal_Type1.Visible = False
                TB_Personal_Type2.Visible = False
                TB_Personal.Style.Add("display", "none")
            ElseIf rdl_sanchaat.SelectedValue = 2 Then
                TB_Personal_Type1.Visible = True
                TB_Personal_Type2.Visible = True
                TB_Personal.Style.Add("display", "initial")
            End If

        Catch ex As Exception

        End Try

        Try
            If cb_Personal_Type1.TabIndex = 1 Then
                cb_Personal_Type1.Checked = True
                TB_Personal_Type2.Visible = False
            ElseIf cb_Personal_Type2.TabIndex = 2 Then
                cb_Personal_Type2.Checked = True
                TB_Personal_Type1.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.ClsDBlcn_request

        With dao
            '.fields.IDA = 2
            .fields.ID_DALCN = CType(_IDA, Integer)
            .fields.ID_DALCN_FIX = 1
            .fields.ID_DALCN_LOCATION_ADDRESS = 1
            .fields.ID_DALCN_LOCATION_ADDRESS_FIX = 1
            .fields.TR_ID = 1
            .fields.STATUS = 1
            .fields.rcbno = 1
            .insert()
        End With
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)

    End Sub
End Class