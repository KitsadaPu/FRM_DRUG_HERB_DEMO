Public Class UC_LCN_DETAIL
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub get_data(ByVal IDA_LCN As Integer)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(IDA_LCN)
        Dim dao_a As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_a.GetDataby_IDA(dao.fields.FK_IDA)
        With dao.fields
            Txt_LCNNO.Text = .LCNNO_DISPLAY_NEW
            txt_Citizen.Text = .CITIZEN_ID_AUTHORIZE
            txt_Name.Text = .thanm
            txt_Write_Date.Text = Date.Now
            txt_email.Text = .Email
        End With
        With dao_a.fields
            txt_addr.Text = .thaaddr
            txt_Building.Text = .thabuilding
            txt_mu.Text = .thamu
            txt_Soi.Text = .thasoi
            txt_road.Text = .tharoad
            txt_tambol.Text = .thathmblnm
            txt_ampher.Text = .thathmblnm
            txt_changwat.Text = .thachngwtnm
            txt_zipcode.Text = .zipcode
            txt_Tel.Text = .tel
        End With
        RDL_EXTRACTION.SelectedValue = 1
        RDL_REQ.SelectedValue = 1
    End Sub
    Public Sub load_ddl_chwt()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()
        ddl_Province.DataSource = dt
        ddl_Province.DataBind()
        'ddl_Province.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Sub save_data(ByRef dao As DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION)
        With dao.fields
            .LCNNO_NEW = Txt_LCNNO.Text
            .CONSIDER_TRANSLATION_NM = txt_Name.Text
            .AGE = Txt_age.Text
            .Nationality = txt_Nationality.Text
            '.CITIZEN_ID = txt_Citizen.Text
            .thaaddr = txt_addr.Text
            .thabuilding = txt_Building.Text
            .thamu = txt_mu.Text
            .tharoad = txt_road.Text
            .thasoi = txt_Soi.Text
            .thathmblnm = txt_tambol.Text
            .thaamphrnm = txt_ampher.Text
            .thachngwtnm = txt_changwat.Text
            .zipcode = txt_zipcode.Text
            .tel = txt_Tel.Text
            .e_mail = txt_email.Text
            .fax = txt_fax.Text
            .PLACE_PLAN = Txt_CSTF_NAME.Text
            .Detail_Adjust = Txt_Detail_Edit_REQ.Text
            Try
                .Location_ChangwatID = ddl_Province.SelectedValue
                .Location_Changwat = ddl_Province.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                .EXTRACTION_ID = RDL_EXTRACTION.SelectedValue
                .EXTRACTION_NM = RDL_EXTRACTION.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                .TYPE_REQUEST = RDL_REQ.SelectedValue
                .TYPE_REQUEST_NM = RDL_REQ.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                .Translation_TYPE_ID = RBL_Translation_TYPE.SelectedValue
                .Translation_TYPE = RBL_Translation_TYPE.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                .WRITE_AT = Txt_Write_At.Text
                .WRITE_DATE = txt_Write_Date.Text
            Catch ex As Exception

            End Try
        End With

    End Sub
End Class