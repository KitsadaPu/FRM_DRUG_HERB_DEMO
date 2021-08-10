Public Class UC_LCN_SUB
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _lcn_ida As String

    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        _ProcessID = Request.QueryString("process")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        _IDA = Request.QueryString("IDA")
        _lcn_ida = Request.QueryString("LCN_IDA")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        Set_Label(_iden)
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

    Sub Set_Label(ByVal CITIZEN_ID_AUTHORIZE As String)
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
                txt_sub_addr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_floor.Text = dr("floor")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_room.Text = dr("room")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_ages.Text = dr("age")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_amphor.Text = dr("amphrnm")
            Catch ex As Exception

            End Try
            Try
                txt_sub_building.Text = dr("building")
            Catch ex As Exception

            End Try
            Try
                txt_sub_changwat.Text = dr("chngwtnm")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_email.Text = dr("email")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_fax.Text = dr("fax")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_iden.Text = dr("identify")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_iden2.Text = dr("identify")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_mu.Text = dr("mu")
            Catch ex As Exception

            End Try
            Try
                txt_sub_name.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try
            'Try
            '    txt_sub_nation.Text = dr("nation")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_road.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                txt_sub_soi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                txt_sub_tambol.Text = dr("thmblnm")
            Catch ex As Exception

            End Try
            Try
                txt_sub_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                txt_sub_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next

        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(_lcn_ida)
        txt_sub_opentime.Text = dao_main.fields.opentime
        txt_sub_location.Text = dao_main.fields.LOCATION_ADDRESS_thanameplace
        txt_sub_lcnno.Text = dao_main.fields.LCNNO_DISPLAY_NEW

        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(_lcn_ida)
        If dao_phr.fields.PHR_NAME = Nothing Then
            txt_sub_phr_name.Text = "-"
        Else
            txt_sub_phr_name.Text = dao_phr.fields.PHR_NAME
        End If

    End Sub

    Sub set_data(ByRef dao_sub As DAO_DRUG.TB_DALCN_SUBSTITUTE)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_lcn_ida)
        Dim Process_TB As String = "10401"
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        TR_ID = bao_tran.insert_transection(Process_TB)

        Dim Process_sub As Integer
        If _ProcessID = 120 Then
            Process_sub = 3
        ElseIf _ProcessID = 121 Then
            Process_sub = 2
        ElseIf _ProcessID = 122 Then
            Process_sub = 1
        End If

        Try
            dao_sub.fields.lcntpcd = dao.fields.lcntpcd
            dao_sub.fields.lcnno = dao.fields.lcnno
            dao_sub.fields.LCNNO_DISPLAY_NEW = dao.fields.LCNNO_DISPLAY_NEW
            dao_sub.fields.IDENTIFY = _iden
            dao_sub.fields.TR_ID = TR_ID
            dao_sub.fields.WTIRE_DATE = Date.Now
            dao_sub.fields.PROCESS_ID = "10401"
            dao_sub.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao_sub.fields.FK_IDA = dao.fields.IDA
            dao_sub.fields.PURPOSE = txt_sub_PURPOSE.Text
            dao_sub.fields.LCN_TYPE = Process_sub
            dao_sub.fields.CITIZEN_ID_AUTHORIZE = dao.fields.CITIZEN_ID_AUTHORIZE

        Catch ex As Exception

        End Try
    End Sub
End Class