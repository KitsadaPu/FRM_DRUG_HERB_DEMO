Imports System.Globalization
Imports Telerik.Web.UI
Imports Telerik.Web.UI.Scheduler.Views

Public Class UC_PHR_DETAIL
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION

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
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Get_data_phr()
            Search_FN()
            RadGrid_lcn.Rebind()
        End If
    End Sub
    Sub bind_ddl_phr_type()
        Try
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_PHR_HERB
            dao.GetDataAll()
            ddl_phr_type.DataSource = dao.datas
            ddl_phr_type.DataValueField = "TYPE_ID"
            ddl_phr_type.DataTextField = "TYPE_PHR_HERB"
            ddl_phr_type.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_phr_type.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub bind_DDL_STUDY_LEVEL()
        Try
            Dim dao As New DAO_LCN.TB_MAS_TYPE_QUALIFICATION
            dao.GetDataAll()
            DDL_STUDY_LEVEL.DataSource = dao.datas
            DDL_STUDY_LEVEL.DataValueField = "ID"
            DDL_STUDY_LEVEL.DataTextField = "NAME"
            DDL_STUDY_LEVEL.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            DDL_STUDY_LEVEL.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub bind_ddl_phr_type_other()
        Try
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_PHR_HERB
            dao.GetDataAll()
            ddl_phr_type.DataSource = dao.datas
            ddl_phr_type.DataValueField = "TYPE_ID"
            ddl_phr_type.DataTextField = "TYPE_PHR_HERB"
            ddl_phr_type.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_phr_type.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub bind_DDL_VETERINARY_FIELD()
        Try
            Dim dao As New DAO_LCN.TB_MAS_TYPE_MAJOR
            dao.GetDataAll()
            ddl_phr_type_other.DataSource = dao.datas
            ddl_phr_type_other.DataValueField = "ID"
            ddl_phr_type_other.DataTextField = "NAME"
            ddl_phr_type_other.DataBind()
            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_phr_type_other.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub bind_ddl_training_phr()
        Try
            Dim bao As New BAO_SHOW
            Dim dt As DataTable = bao.SP_MAS_DALCN_PHR_TRAINING()
            ddl_training_phr.DataSource = dt
            ddl_training_phr.DataValueField = "TRAINING_ID"
            ddl_training_phr.DataTextField = "TRAINING_DATE"
            ddl_training_phr.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_training_phr.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub get_date()
        txt_Write_Date.Text = Date.Now
    End Sub
    Sub bind_data(ByRef dao_PHR As DAO_DRUG.ClsDBDALCN_PHR)
        'Dim dao_PHR As DAO_DRUG.ClsDBDALCN_PHR
        dao_PHR.GetDataby_IDA(Request.QueryString("PHR_IDA"))
        Try

            With dao_PHR.fields
                txt_phr_name.Text = .PHR_NAME
                txt_age.Text = .PHR_AGE
                txt_Nationality.Text = .PHR_Nationality
                txt_phr_addr.Text = .PHR_ADDR
                txt_phr_Building.Text = .PHR_BUIDING
                Try
                    txt_phr_mu.Text = .PHR_MU
                Catch ex As Exception

                End Try
                txt_PHR_CTZNO.Text = .PHR_CTZNO
                Txt_Write_At.Text = .WRITE_AT
                txt_Write_Date.Text = .WRITE_DATE
                Try
                    rdl_Phr_Service_Chk.SelectedValue = .Phr_Service_ID
                Catch ex As Exception

                End Try
                txt_phr_Soi.Text = .PHR_SOI
                txt_phr_road.Text = .PHR_ROAD
                txt_phr_tambol.Text = .PHR_TAMBOL
                txt_phr_ampher.Text = .PHR_AMPHER
                txt_phr_changwat.Text = .PHR_CHANGWAT
                txt_phr_zipcode.Text = .PHR_ZIPCODE
                txt_phr_fax.Text = .PHR_FAX
                txt_phr_phone.Text = .PHR_TEL
                txt_phr_email.Text = .PHR_EMAIL
                'Try
                '    rdl_chk_job.SelectedValue = .PHR_CHK_JOB
                'Catch ex As Exception

                'End Try
                Try
                    '.PERSONAL_TYPE = ddl_phr_type.SelectedValue
                    '.STUDY_LEVEL = ddl_phr_type.SelectedItem.Text

                    ddl_phr_type.SelectedValue = .PERSONAL_TYPE_OTHER_ID
                    '.PERSONAL_TYPE_OTHER = ddl_phr_type.SelectedItem.Text
                Catch ex As Exception

                End Try
                txt_PHR_TEXT_NUM.Text = .PHR_ADDR_NUM
                'phr_date_num.Text = .PHR_DATE_NUM
                'txt_Study_Level.Text = .STUDY_LEVEL
                '.PHR_VETERINARY_FIELD = txt_phr_veterinary_field.Text
                Try
                    ddl_phr_type_other.SelectedValue = .PERSONAL_TYPE_OTHER_2_ID
                    ddl_phr_type.SelectedItem.Text = .PERSONAL_TYPE_OTHER_2
                Catch ex As Exception

                End Try
                txt_Study_Year.Text = .STUDY_YEAR
                'txt_Name_Siminar.Text = .NAME_SIMINAR
                'Try
                '    Siminar_Date.Text = .SIMINAR_DATE
                'Catch ex As Exception

                'End Try
                Try
                    ' .PHR_service_chk = rdl_Phr_Service_Chk.SelectedValue
                    txt_Phr_Service_Name.Text = .Phr_Service_Name
                Catch ex As Exception

                End Try
                Try
                    '.Service_Time = Service_Time_Open.Text & " - " & Service_Time_Close.Text
                Catch ex As Exception

                End Try
                txt_BN_addr.Text = .BSN_ADDR
                txt_Business_Name.Text = .BUSINESS_NAME
                txt_BN_Building.Text = .BSN_BUILDING
                Try
                    txt_BN_mu.Text = .BSN_MU
                Catch ex As Exception

                End Try
                txt_BSN_addr.Text = .PHR_ADDR_NUM
                txt_BN_Soi.Text = .BSN_SOI
                txt_BN_Soi.Text = .BSN_ROAD
                'ddl_bn_tambol.Text = .BSN_TAMBOL
                'txt_phr_ampher.Text = .BSN_AMPHER
                'txt_phr_changwat.Text = .BSN_CHANGWAT
                txt_BN_zipcode.Text = .BSN_ZIPCODE
                txt_BN_tel.Text = .BSN_TEL
                txt_BN_Opentime.Text = .BSN_OPENTIME
                txt_BN_road.Text = .BSN_ROAD
                'txt_BN_fax.Text = .bsn_fax
                Try
                    ddl_bn_ampher.SelectedValue = .BSN_AMPHER_ID
                Catch ex As Exception

                End Try
                Try
                    ddl_bn_tambol.SelectedValue = .BSN_TAMBOL_ID
                Catch ex As Exception

                End Try
                Try
                    ddl_bn_changwat.SelectedValue = .BSN_CHANGWAT_ID
                Catch ex As Exception

                End Try
                'Dim datetime As DateTime = datetime.ParseExact(Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            End With
        Catch ex As Exception

        End Try
    End Sub
    Function check_data()
        Dim check_ID As String = ""
        Dim message As String = "กรุณากรอกข้อมูลให้ครบ"
        If txt_PHR_CTZNO.Text = "" Or txt_BN_Opentime.Text = "" Or lbl_Service_Time_Open.Text = "" _
             Or txt_age.Text Is Nothing Or txt_age.Text = "" _
            And (rdl_Phr_Service_Chk.SelectedValue = 2 And Service_Time_Close.Text Is Nothing Or Service_Time_Close.Text = "") Then
            If txt_PHR_CTZNO.Text Is Nothing Or txt_PHR_CTZNO.Text = "" Then
                lbl_PHR_CTZNO.Visible = True
            Else
                lbl_PHR_CTZNO.Visible = False
            End If
            If txt_BN_Opentime.Text Is Nothing Or txt_BN_Opentime.Text = "" Then
                lbl_BN_Opentime.Visible = True
            Else
                lbl_BN_Opentime.Visible = False
            End If
            If Service_Time_Open.Text Is Nothing Or Service_Time_Open.Text = "" Or Service_Time_Close.Text Is Nothing Or Service_Time_Close.Text = "" Then
                lbl_Service_Time_Open.Visible = True
            Else
                lbl_Service_Time_Open.Visible = False
            End If

            If txt_age.Text Is Nothing Or txt_age.Text = "" Then
                lbl_age.Visible = True
            Else
                lbl_age.Visible = False
            End If
            message = "กรุณากรอกข้อมูลให้ครบถ้วน"
            check_ID = 0
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('" & message & "');", True)

        ElseIf ddl_bn_changwat.SelectedValue = "-- กรุณาเลือกตจังหวัด --" Or ddl_bn_changwat.SelectedValue = 0 _
             Or ddl_bn_ampher.SelectedValue = "-" Or ddl_bn_tambol.SelectedValue = "-" Then
            If ddl_bn_changwat.SelectedValue = "-- กรุณาเลือกตจังหวัด --" Or ddl_bn_changwat.SelectedValue = 0 Then
                lbl_bn_changwat.Visible = True
            Else
                lbl_bn_changwat.Visible = False
            End If
            If ddl_bn_ampher.SelectedValue = "-" Then
                lbl_bn_ampher.Visible = True
            Else
                lbl_bn_ampher.Visible = False
            End If
            If ddl_bn_tambol.SelectedValue = "-" Then
                lbl_bn_tambol.Visible = True
            Else
                lbl_bn_tambol.Visible = False
            End If
            If txt_PHR_CTZNO.Text Is Nothing Or txt_PHR_CTZNO.Text = "" Then
                lbl_PHR_CTZNO.Visible = True
            Else
                lbl_PHR_CTZNO.Visible = False
            End If
            If txt_BN_Opentime.Text Is Nothing Or txt_BN_Opentime.Text = "" Then
                lbl_BN_Opentime.Visible = True
            Else
                lbl_BN_Opentime.Visible = False
            End If
            message = "กรุณากรอกข้อมูลให้ครบถ้วน"
            check_ID = 0
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('" & message & "');", True)
        Else
            check_ID = 1
        End If
        Return check_ID
    End Function
    Sub set_data_phr(ByRef dao As DAO_DRUG.ClsDBDALCN_PHR)

        With dao.fields
            .PHR_CTZNO = txt_PHR_CTZNO.Text
            .PHR_NAME = txt_phr_name.Text
            .PHR_AGE = txt_age.Text
            .PHR_Nationality = txt_Nationality.Text
            .PHR_ADDR = txt_phr_addr.Text
            .PHR_BUIDING = txt_phr_Building.Text
            Try
                .PHR_MU = txt_phr_mu.Text
            Catch ex As Exception

            End Try
            .WRITE_AT = Txt_Write_At.Text
            .WRITE_DATE = txt_Write_Date.Text
            Try
                .Phr_Service_ID = rdl_Phr_Service_Chk.SelectedValue
            Catch ex As Exception

            End Try
            .PHR_SOI = txt_phr_Soi.Text
            .PHR_ROAD = txt_phr_road.Text
            .PHR_TAMBOL = txt_phr_tambol.Text
            .PHR_AMPHER = txt_phr_ampher.Text
            .PHR_CHANGWAT = txt_phr_changwat.Text
            .PHR_ZIPCODE = txt_phr_zipcode.Text
            .PHR_FAX = txt_phr_fax.Text
            .PHR_TEL = txt_phr_phone.Text
            .PHR_EMAIL = txt_phr_email.Text
            'Try
            '    .PHR_CHK_JOB = rdl_chk_job.SelectedValue
            'Catch ex As Exception

            'End Try
            Try
                '.PERSONAL_TYPE = ddl_phr_type.SelectedValue
                '.STUDY_LEVEL = ddl_phr_type.SelectedItem.Text

                .PERSONAL_TYPE_OTHER_ID = ddl_phr_type.SelectedValue
                .PERSONAL_TYPE_OTHER = ddl_phr_type.SelectedItem.Text
            Catch ex As Exception

            End Try
            .PHR_TEXT_NUM = txt_PHR_TEXT_NUM.Text
            '.PHR_DATE_NUM = phr_date_num.Text
            If ddl_phr_type.SelectedValue = "0" Then
                .STUDY_LEVEL = DDL_STUDY_LEVEL.SelectedItem.Text
            Else
                Try
                    If ddl_phr_type.SelectedValue = 32 Then
                        .STUDY_LEVEL = DDL_STUDY_LEVEL.SelectedItem.Text
                    Else
                        .STUDY_LEVEL = ddl_phr_type.SelectedItem.Text

                    End If
                    .PHR_JOB_TYPE = ddl_phr_type.SelectedValue
                Catch ex As Exception

                End Try
            End If
            Try
                .PHR_VETERINARY_FIELD = ddl_phr_type_other.SelectedItem.Text
            Catch ex As Exception

            End Try
            '.PHR_VETERINARY_FIELD = txt_phr_veterinary_field.Text
            Try
                .PERSONAL_TYPE_OTHER_2_ID = ddl_phr_type_other.SelectedValue
                .PERSONAL_TYPE_OTHER_2 = ddl_phr_type.SelectedItem.Text
            Catch ex As Exception

            End Try
            .STUDY_YEAR = txt_Study_Year.Text
            .NAME_SIMINAR = ddl_training_phr.SelectedItem.Text
            Try
                .SIMINAR_DATE = rdp_SIMINAR_DATE.SelectedDate
            Catch ex As Exception

            End Try
            Try
                ' .PHR_service_chk = rdl_Phr_Service_Chk.SelectedValue
                .Phr_Service_Name = txt_Phr_Service_Name.Text
            Catch ex As Exception

            End Try
            Try
                .Service_Time = Service_Time_Open.Text & " - " & Service_Time_Close.Text
            Catch ex As Exception

            End Try
            .BSN_ADDR = txt_BN_addr.Text
            .BUSINESS_NAME = txt_Business_Name.Text
            .BSN_BUILDING = txt_BN_Building.Text
            Try
                .BSN_MU = txt_BN_mu.Text
            Catch ex As Exception

            End Try
            .PHR_ADDR_NUM = txt_addr_num.Text
            .BSN_SOI = txt_BN_Soi.Text
            .BSN_ROAD = txt_BN_Soi.Text
            Try
                .BSN_TAMBOL_ID = ddl_bn_tambol.SelectedValue
                .BSN_TAMBOL = ddl_bn_tambol.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                .BSN_AMPHER_ID = ddl_bn_ampher.SelectedValue
                .BSN_AMPHER = ddl_bn_ampher.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                .BSN_CHANGWAT_ID = ddl_bn_changwat.SelectedValue
                .BSN_CHANGWAT = ddl_bn_changwat.SelectedItem.Text
            Catch ex As Exception

            End Try
            .BSN_ZIPCODE = txt_BN_zipcode.Text
            .BSN_TEL = txt_BN_tel.Text
            .BSN_OPENTIME = txt_BN_Opentime.Text
            .PHR_Operating_time = txt_PHR_TEXT_WORK_TIME.Text
            .ACTIVE = 1
        End With
    End Sub
    Public Sub load_ddl_chwt()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()
        ddl_Province.DataSource = dt
        ddl_Province.DataBind()
        'ddl_Province.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub load_ddl_amp()

        Dim bao As New BAO_SHOW
        Dim dt As New DataTable '
        Try
            dt = bao.SP_SYSAMPHR_BY_CHNGWTCD(ddl_Province.SelectedValue)
        Catch ex As Exception

        End Try

        ddl_amphor.DataSource = dt
        ddl_amphor.DataBind()
        'Dim item As New RadComboBoxItem
        'item.Text = "-- กรุณาเลือก --"
        'item.Value = "0"
        ddl_amphor.Items.Insert(0, "-- กรุณาเลือก --")
        'ddl_amphor.Items.Insert(0, item)
    End Sub
    Public Sub load_ddl_thambol()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        Try
            If ddl_amphor.SelectedValue = "-- กรุณาเลือก --" Then
                ddl_amphor.SelectedValue = 0
            End If
            dt = bao.SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD(ddl_Province.SelectedValue, ddl_amphor.SelectedValue)
        Catch ex As Exception

        End Try
        ddl_tambol.DataSource = dt
        ddl_tambol.DataBind()
        ddl_tambol.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Private Sub ddl_Province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Province.SelectedIndexChanged
        load_ddl_amp()
        'load_ddl_thambol()
    End Sub

    Private Sub ddl_amphor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_amphor.SelectedIndexChanged
        load_ddl_thambol()
    End Sub
    Public Sub load_ddl_bn_chwt()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()
        ddl_bn_changwat.DataSource = dt
        ddl_bn_changwat.DataBind()
        'ddl_bn_changwat.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub load_ddl_bn_amp()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        Try
            dt = bao.SP_SYSAMPHR_BY_CHNGWTCD(ddl_bn_changwat.SelectedValue)
        Catch ex As Exception
            Try
                Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
                dao.GetDataby_IDA(Request.QueryString("PHR_IDA"))
                dt = bao.SP_SYSAMPHR_BY_CHNGWTCD(dao.fields.BSN_CHANGWAT_ID)
            Catch ex2 As Exception

            End Try
        End Try

        ddl_bn_ampher.DataSource = dt
        ddl_bn_ampher.DataBind()
        ddl_bn_ampher.Items.Insert(0, "-")
    End Sub
    Public Sub load_ddl_bn_thambol()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        Try
            dt = bao.SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD(ddl_bn_changwat.SelectedValue, ddl_bn_ampher.SelectedValue)
        Catch ex As Exception
            Try
                Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
                dao.GetDataby_IDA(Request.QueryString("PHR_IDA"))
                dt = bao.SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD(dao.fields.BSN_CHANGWAT_ID, dao.fields.BSN_AMPHER_ID)
            Catch ex2 As Exception

            End Try
        End Try
        ddl_bn_tambol.DataSource = dt
        ddl_bn_tambol.DataBind()
        ddl_bn_tambol.Items.Insert(0, "-")
    End Sub

    Private Sub ddl_bn_changwat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bn_changwat.SelectedIndexChanged
        load_ddl_bn_amp()
        load_ddl_bn_thambol()
    End Sub

    Private Sub ddl_bn_amphor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bn_ampher.SelectedIndexChanged
        load_ddl_bn_thambol()
    End Sub

    Protected Sub rdl_Phr_Service_Chk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_Phr_Service_Chk.SelectedIndexChanged
        If rdl_Phr_Service_Chk.SelectedValue = 1 Then
            txt_Phr_Service_Name.Visible = False
            Service_Time.Visible = False
        ElseIf rdl_Phr_Service_Chk.SelectedValue = 2 Then
            txt_Phr_Service_Name.Visible = True
            Service_Time.Visible = True
        End If
    End Sub

    Protected Sub btn_save_training_Click(sender As Object, e As EventArgs) Handles btn_save_training.Click
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR_TRAINING
        Dim dao_m As New DAO_LCN.TB_MAS_DALCN_PHR_TRAINING
        dao_m.GetDataby_TRAINING_ID(ddl_training_phr.SelectedValue)
        Dim TRAINING_DATE_START As New Date
        Dim TRAINING_DATE_START_TH As String
        Dim TRAINING_DATE_END As New Date
        Dim TRAINING_DATE_END_TH As String
        Dim TRAINING_NAME As String = ddl_training_phr.SelectedItem.Text
        With dao.fields
            If dao_m.fields.TRAINING_DATE_START IsNot Nothing AndAlso Not dao_m.fields.TRAINING_DATE_START = Date.MinValue Then
                .NAME_SIMINAR = ddl_training_phr.SelectedItem.Text
            Else
                If dao_m.fields.TRAINING_DATE_START Is Nothing Then
                    TRAINING_DATE_START = rdp_SIMINAR_DATE.SelectedDate
                    TRAINING_DATE_START_TH = date_to_thai(TRAINING_DATE_START)
                    TRAINING_NAME = TRAINING_NAME & " (" & TRAINING_DATE_START_TH & "-"
                Else
                    TRAINING_DATE_START = Date.Now
                    TRAINING_DATE_START_TH = date_to_thai(TRAINING_DATE_START)
                    TRAINING_NAME = TRAINING_NAME & " (" & TRAINING_DATE_START_TH & "-"
                End If
                If dao_m.fields.TRAINING_DATE_END Is Nothing Then
                    TRAINING_DATE_END = rdp_SIMINAR_DATE_END.SelectedDate
                    TRAINING_DATE_END_TH = date_to_thai(TRAINING_DATE_END)
                    TRAINING_NAME = TRAINING_NAME & TRAINING_DATE_END_TH & ")"
                Else
                    TRAINING_DATE_END = Date.Now
                    TRAINING_DATE_END_TH = date_to_thai(TRAINING_DATE_END)
                    TRAINING_NAME = TRAINING_NAME & TRAINING_DATE_END_TH & ")"
                End If
                .NAME_SIMINAR = TRAINING_NAME
            End If
            .SIMINAR_DATE = rdp_SIMINAR_DATE.SelectedDate
            .phr_IDA = Request.QueryString("PHR_IDA")
            '.FK_IDA = Request.QueryString("IDA_LCN")
        End With
        dao.insert()
        rgns.Rebind()
        ddl_training_phr.SelectedValue = 0
        rdp_SIMINAR_DATE.SelectedDate = Date.Now
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim FK_IDA As String = Request.QueryString("PHR_IDA")
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR_LCN_ADDR
        Dim message As String = "กรุณากรอกข้อมูลให้ครบ"
        If txt_BSN_Opentime.Text = "" Then
            If txt_BSN_Opentime.Text Is Nothing Or txt_BSN_Opentime.Text = "" Then
                lbl_BSN_Opentime.Visible = True
            Else
                lbl_BSN_Opentime.Visible = False
            End If
            message = "กรุณากรอกข้อมูลให้ครบถ้วน"
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('" & message & "');", True)
        ElseIf ddl_Province.SelectedValue = "-- กรุณาเลือกตจังหวัด --" Or ddl_Province.SelectedValue = 0 Then
            If ddl_Province.SelectedValue = "-- กรุณาเลือกตจังหวัด --" Or ddl_Province.SelectedValue = 0 Then
                lbl_Province.Visible = True
            Else
                lbl_Province.Visible = False
            End If
            message = "กรุณาเลือกจังหวัด"
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('" & message & "');", True)
        Else
            With dao.fields
                .FK_IDA = FK_IDA
                Try
                    .LCN_IDA = txt_search_lcn_ida.Text
                Catch ex As Exception

                End Try
                .MATRA = DDL_Matra.SelectedValue
                .PHR_NAME_BSN = txt_Name_Bsn.Text
                .PHR_ADDR_BSN = txt_BSN_addr.Text
                .PHR_BILDING_BSN = txt_BSN_Building.Text
                .PHR_MU_BSN = txt_BSN_mu.Text
                .PHR_SOI_BSN = txt_BSN_Soi.Text
                .PHR_ROAD_BSN = txt_BSN_road.Text
                Try
                    .PHR_TAMBOL_BSN = ddl_tambol.SelectedItem.Text
                    .PHR_TAMBOL_ID = ddl_tambol.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    .PHR_AMPHER_BSN = ddl_amphor.SelectedItem.Text
                    .PHR_AMPHER_ID = ddl_amphor.SelectedValue
                Catch ex As Exception
                    .PHR_AMPHER_BSN = "-"
                End Try
                .PHR_CHANGWAT_BSN = ddl_Province.SelectedItem.Text
                .PHR_CHANGWAT_ID = ddl_Province.SelectedValue
                .PHR_ZIPCODE_BSN = txt_BSN_zipcode.Text
                .PHR_TEL_BSN = txt_BSN_tel.Text
                .OPEN_TIME = txt_BSN_Opentime.Text
                .ACTIVEFACT = 1
            End With
            dao.insert()
            RadGrid1.Rebind()
            Clear_txt()
        End If
    End Sub
    Sub Clear_txt()
        DDL_Matra.SelectedValue = 0
        txt_Name_Bsn.Text = ""
        txt_BSN_addr.Text = ""
        txt_BSN_Building.Text = ""
        txt_BSN_mu.Text = ""
        txt_BSN_Soi.Text = ""
        txt_BSN_road.Text = ""
        ddl_Province.SelectedValue = 0
        ddl_amphor.SelectedValue = "-- กรุณาเลือก --"
        ddl_tambol.SelectedValue = "-- กรุณาเลือก --"
        lbl_Province.Visible = False
        lbl_BSN_Opentime.Visible = False
        txt_BSN_zipcode.Text = ""
        txt_BSN_tel.Text = ""
        txt_BSN_Opentime.Text = ""
        txt_BSN_fax.Text = ""
    End Sub
    Function bind_data_rg()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        'dt = bao.SP_DALCN_PHR_BY_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE)
        dt = bao.SP_PHR_LOCATION_BY_PHR_IDA(Request.QueryString("PHR_IDA"))
        txt_addr_num.Text = dt.Rows.Count()
        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_rg()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim _ida As String = item("IDA").Text
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR_ADDR_BSN
            'If e.CommandName = "r_del" Then
            '    dao.GetDataby_IDA(_ida)
            '    dao.delete()
            '    RadGrid1.Rebind()

            'End If
        End If
    End Sub
    'Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
    '    Dim bao As New BAO_MASTER
    '    Dim dt As New DataTable
    '    Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
    '    dao.GetDataby_CTZNO(txt_PHR_CTZNO.Text)
    '    dt = dao.datas
    '    RadGrid1.DataSource = dt
    'End Sub
    Private Sub rgns_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgns.NeedDataSource
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        Dim dao_drug As New DAO_DRUG.ClsDBDALCN_PHR_TRAINING
        dt = bao.SP_DALCN_PHR_TRAINING(Request.QueryString("PHR_IDA"))
        rgns.DataSource = dt
    End Sub
    Private Sub rgns_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgns.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim _ida As String = item("IDA").Text
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR_TRAINING
            If e.CommandName = "r_del" Then
                dao.GetDataby_IDA(_ida)
                dao.delete()
                rgns.Rebind()

            End If
        End If
    End Sub
    Sub Get_data_phr()
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID
        Catch ex As Exception

        End Try
        txt_PHR_CTZNO.Text = CITIZEN_ID_AUTHORIZE
        txt_PHR_CTZNO.ReadOnly = True
        Dim Nation As String = ""
        Dim BirthDate As Date
        Dim Age_Person As Integer
        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
        If dao_syslcnsid.fields.IDA = 0 Then
            ' Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
        Else
            Try
                If ws_taxno.SYSLCTADDRs.thaaddr = Nothing Then
                    txt_phr_addr.Text = "-"
                Else
                    txt_phr_addr.Text = ws_taxno.SYSLCTADDRs.thaaddr
                End If
                'txt_phr_name.Text = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
                If ws_taxno.SYSLCTADDRs.mu = Nothing Then
                    txt_phr_mu.Text = "-"
                Else
                    txt_phr_mu.Text = ws_taxno.SYSLCTADDRs.mu
                End If
                If ws_taxno.SYSLCTADDRs.building = Nothing Then
                    txt_phr_Building.Text = "-"
                Else
                    txt_phr_Building.Text = ws_taxno.SYSLCTADDRs.building
                End If
                If ws_taxno.SYSLCTADDRs.thasoi = Nothing Then
                    txt_phr_Soi.Text = "-"
                Else
                    txt_phr_Soi.Text = ws_taxno.SYSLCTADDRs.thasoi
                End If
                If ws_taxno.SYSLCTADDRs.tharoad = Nothing Then
                    txt_phr_road.Text = "-"
                Else
                    txt_phr_road.Text = ws_taxno.SYSLCTADDRs.tharoad
                End If
                If ws_taxno.SYSLCTADDRs.thmblnm = Nothing Then
                    txt_phr_tambol.Text = "-"
                Else
                    txt_phr_tambol.Text = ws_taxno.SYSLCTADDRs.thmblnm
                End If
                If ws_taxno.SYSLCTADDRs.amphrnm = Nothing Then
                    txt_phr_ampher.Text = "-"
                Else
                    txt_phr_ampher.Text = ws_taxno.SYSLCTADDRs.amphrnm
                End If
                If ws_taxno.SYSLCTADDRs.chngwtnm = Nothing Then
                    txt_phr_changwat.Text = "-"
                Else
                    txt_phr_changwat.Text = ws_taxno.SYSLCTADDRs.chngwtnm
                End If
                If ws_taxno.SYSLCTADDRs.zipcode Is Nothing Then
                    txt_phr_zipcode.Text = "-"
                Else
                    txt_phr_zipcode.Text = ws_taxno.SYSLCTADDRs.zipcode
                End If
                If ws_taxno.SYSLCTADDRs.fax = Nothing Then
                    txt_phr_fax.Text = "-"
                Else
                    txt_phr_fax.Text = ws_taxno.SYSLCTADDRs.fax
                End If
                If ws_taxno.SYSLCTADDRs.tel = Nothing Then
                    txt_phr_phone.Text = "-"
                Else
                    txt_phr_phone.Text = ws_taxno.SYSLCTADDRs.tel
                End If

                'txt_phr_phone.Text = ws_taxno.SYSLCTADDRs.e
            Catch ex As Exception

            End Try
            Try
                Dim citizen_id As String = CITIZEN_ID_AUTHORIZE
                Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
                Dim obj As New XML_DATA
                'Dim cls As New CLS_COMMON.convert
                Dim result As String = ""
                'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
                result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
                obj = ConvertFromXml(Of XML_DATA)(result)
                Try
                    BirthDate = obj.SYSLCNSIDs.birthdate
                    'If BirthDate.Year < 2560 Then con_year(BirthDate.Year)
                    Dim thaiCalendar As New ThaiBuddhistCalendar()
                    Dim currentThaiYear As Integer = thaiCalendar.GetYear(DateTime.Now)
                    ' ปีเกิดที่เป็น พ.ศ. (ตัวอย่างเช่น 2560)
                    Dim birthYearThai As Integer = thaiCalendar.GetYear(BirthDate)
                    ' คำนวณอายุ
                    If birthYearThai > currentThaiYear Then
                        If birthYearThai > 3000 Then
                            birthYearThai = birthYearThai - 543
                        End If
                    End If
                    Dim ageThai As Integer
                    If currentThaiYear > birthYearThai Then ageThai = currentThaiYear - birthYearThai Else ageThai = birthYearThai - currentThaiYear
                    If ageThai > 120 Then ageThai = ageThai - 543
                    txt_age.Text = ageThai
                    Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
                    If TYPE_PERSON = 1 Then
                        txt_phr_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    ElseIf TYPE_PERSON = 99 Then
                        txt_phr_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    Else
                        If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                            txt_phr_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                        Else
                            txt_phr_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                        End If
                    End If
                    If IsNothing(obj.SYSLCNSIDs.nation) = True Then
                        Nation = "ไทย"
                    Else
                        Nation = obj.SYSLCNSIDs.nation
                    End If
                    txt_Nationality.Text = Nation
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        End If
    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_PHR_CTZNO.Text
        Catch ex As Exception

        End Try
        Dim Nation As String = ""
        Dim BirthDate As Date
        Dim Age_Person As Integer
        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
        If dao_syslcnsid.fields.IDA = 0 Then
            ' Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
        Else
            Try
                If ws_taxno.SYSLCTADDRs.thaaddr = Nothing Then
                    txt_phr_addr.Text = "-"
                Else
                    txt_phr_addr.Text = ws_taxno.SYSLCTADDRs.thaaddr
                End If
                'txt_phr_name.Text = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
                If ws_taxno.SYSLCTADDRs.mu = Nothing Then
                    txt_phr_mu.Text = "-"
                Else
                    txt_phr_mu.Text = ws_taxno.SYSLCTADDRs.mu
                End If
                If ws_taxno.SYSLCTADDRs.building = Nothing Then
                    txt_phr_Building.Text = "-"
                Else
                    txt_phr_Building.Text = ws_taxno.SYSLCTADDRs.building
                End If
                If ws_taxno.SYSLCTADDRs.thasoi = Nothing Then
                    txt_phr_Soi.Text = "-"
                Else
                    txt_phr_Soi.Text = ws_taxno.SYSLCTADDRs.thasoi
                End If
                If ws_taxno.SYSLCTADDRs.tharoad = Nothing Then
                    txt_phr_road.Text = "-"
                Else
                    txt_phr_road.Text = ws_taxno.SYSLCTADDRs.tharoad
                End If
                If ws_taxno.SYSLCTADDRs.thmblnm = Nothing Then
                    txt_phr_tambol.Text = "-"
                Else
                    txt_phr_tambol.Text = ws_taxno.SYSLCTADDRs.thmblnm
                End If
                If ws_taxno.SYSLCTADDRs.amphrnm = Nothing Then
                    txt_phr_ampher.Text = "-"
                Else
                    txt_phr_ampher.Text = ws_taxno.SYSLCTADDRs.amphrnm
                End If
                If ws_taxno.SYSLCTADDRs.chngwtnm = Nothing Then
                    txt_phr_changwat.Text = "-"
                Else
                    txt_phr_changwat.Text = ws_taxno.SYSLCTADDRs.chngwtnm
                End If
                If ws_taxno.SYSLCTADDRs.zipcode Is Nothing Then
                    txt_phr_zipcode.Text = "-"
                Else
                    txt_phr_zipcode.Text = ws_taxno.SYSLCTADDRs.zipcode
                End If
                If ws_taxno.SYSLCTADDRs.fax = Nothing Then
                    txt_phr_fax.Text = "-"
                Else
                    txt_phr_fax.Text = ws_taxno.SYSLCTADDRs.fax
                End If
                If ws_taxno.SYSLCTADDRs.tel = Nothing Then
                    txt_phr_phone.Text = "-"
                Else
                    txt_phr_phone.Text = ws_taxno.SYSLCTADDRs.tel
                End If

                'txt_phr_phone.Text = ws_taxno.SYSLCTADDRs.e
            Catch ex As Exception

            End Try
            Try
                Dim citizen_id As String = txt_PHR_CTZNO.Text
                Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
                Dim obj As New XML_DATA
                'Dim cls As New CLS_COMMON.convert
                Dim result As String = ""
                'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
                result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
                obj = ConvertFromXml(Of XML_DATA)(result)
                Try
                    BirthDate = obj.SYSLCNSIDs.birthdate
                    'If BirthDate.Year < 2560 Then con_year(BirthDate.Year)
                    Dim thaiCalendar As New ThaiBuddhistCalendar()
                    Dim currentThaiYear As Integer = thaiCalendar.GetYear(DateTime.Now)
                    ' ปีเกิดที่เป็น พ.ศ. (ตัวอย่างเช่น 2560)
                    Dim birthYearThai As Integer = thaiCalendar.GetYear(BirthDate)
                    ' คำนวณอายุ
                    If birthYearThai > currentThaiYear Then
                        If birthYearThai > 3000 Then
                            birthYearThai = birthYearThai - 543
                        End If
                    End If
                    Dim ageThai As Integer
                    If currentThaiYear > birthYearThai Then ageThai = currentThaiYear - birthYearThai Else ageThai = birthYearThai - currentThaiYear
                    If ageThai > 120 Then ageThai = ageThai - 543
                    txt_age.Text = ageThai
                    Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
                    If TYPE_PERSON = 1 Then
                        txt_phr_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    ElseIf TYPE_PERSON = 99 Then
                        txt_phr_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    Else
                        If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                            txt_phr_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                        Else
                            txt_phr_name.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                        End If
                    End If
                    If IsNothing(obj.SYSLCNSIDs.nation) = True Then
                        Nation = "ไทย"
                    Else
                        Nation = obj.SYSLCNSIDs.nation
                    End If
                    txt_Nationality.Text = Nation
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        End If
    End Sub
    Protected Sub ddl_phr_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_phr_type.SelectedIndexChanged
        If ddl_phr_type.SelectedValue = 0 Then
            P_Traning_Detail.Style.Add("display", "none")
        Else
            P_Traning_Detail.Style.Add("display", "block")
        End If
        If ddl_phr_type.SelectedValue = 32 Then
            Div_Major.Visible = True
            Div_Qualificate.Visible = True
            Div_Txt_num.Visible = False
        Else
            Div_Major.Visible = False
            Div_Qualificate.Visible = False
            Div_Txt_num.Visible = True
        End If
        If ddl_phr_type.SelectedValue = 32 Then
            time_open.Text = "เวลาปฏิบัติการของผู้มีหน้าที่ปฏิบัตการ"
        End If
    End Sub
    Protected Sub ddl_training_phr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_training_phr.SelectedIndexChanged
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_MAS_DALCN_PHR_TRAINING()
        Dim dao As New DAO_LCN.TB_MAS_DALCN_PHR_TRAINING
        dao.GetDataby_TRAINING_ID(ddl_training_phr.SelectedValue)
        'rdp_SIMINAR_DATE.SelectedDate = dao.fields.TRAINING_DATE_START
        'rdp_SIMINAR_DATE_END.SelectedDate = dao.fields.TRAINING_DATE_END

        ' ตรวจสอบ TRAINING_DATE_START
        If dao.fields.TRAINING_DATE_START IsNot Nothing AndAlso Not dao.fields.TRAINING_DATE_START = Date.MinValue Then
            rdp_SIMINAR_DATE.SelectedDate = dao.fields.TRAINING_DATE_START
            rdp_SIMINAR_DATE.Enabled = False
        Else
            'rdp_SIMINAR_DATE.SelectedDate = Nothing
            rdp_SIMINAR_DATE.SelectedDate = Date.Now
            rdp_SIMINAR_DATE.Enabled = True
        End If

        ' ตรวจสอบ TRAINING_DATE_END
        If dao.fields.TRAINING_DATE_END IsNot Nothing AndAlso Not dao.fields.TRAINING_DATE_END = Date.MinValue Then
            rdp_SIMINAR_DATE_END.SelectedDate = dao.fields.TRAINING_DATE_END
            rdp_SIMINAR_DATE_END.Enabled = False
        Else
            'rdp_SIMINAR_DATE_END.SelectedDate = Nothing
            rdp_SIMINAR_DATE_END.SelectedDate = Date.Now
            rdp_SIMINAR_DATE_END.Enabled = True
        End If
    End Sub

    Protected Sub BTN_SEARCH_HOME_NO_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_HOME_NO.Click
        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        If HOME_NO.Text IsNot Nothing Then
            dao.GetDataby_HOUSE_NO(HOME_NO.Text)
            If dao.fields.IDA = 0 Then
                'Dim HOUSE_NO As String = HOME_NO.Text
                'Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
                'Dim obj As New XML_DATA
                ''Dim cls As New CLS_COMMON.convert
                'Dim result As String = ""
                ''result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
                'result = ws_center.FDA_HOUSE_NO(HOUSE_NO, _CLS.CITIZEN_ID, "FUSION", "P@ssw0rdfusion440")
                'obj = ConvertFromXml(Of XML_DATA)(result)
                'txt_Business_Name.Text = obj.SYSLCTADDRs.branch
                'txt_BN_addr.Text = obj.SYSLCTADDRs.thaaddr
                'txt_BN_Building.Text = obj.SYSLCTADDRs.building
                'txt_BN_mu.Text = obj.SYSLCTADDRs.mu
                'txt_BN_Soi.Text = obj.SYSLCTADDRs.thasoi
                'txt_BN_road.Text = obj.SYSLCTADDRs.tharoad
                'txt_BN_zipcode.Text = obj.SYSLCTADDRs.zipcode
                'If dao.fields.chngwtcd IsNot Nothing Then ddl_bn_changwat.SelectedValue = obj.SYSLCTADDRs.chngwtcd
                'If dao.fields.amphrcd IsNot Nothing Then
                '    load_ddl_bn_amp()
                '    ddl_bn_ampher.SelectedValue = obj.SYSLCTADDRs.amphrcd
                'End If
                'If dao.fields.thmblcd IsNot Nothing Then
                '    load_ddl_bn_thambol()
                '    ddl_bn_tambol.SelectedValue = obj.SYSLCTADDRs.thmblcd
                'End If
                'Label_house_no.Visible = False
            Else
                txt_Business_Name.Text = dao.fields.thanameplace
                txt_BN_addr.Text = dao.fields.thaaddr
                txt_BN_Building.Text = dao.fields.thabuilding
                txt_BN_mu.Text = dao.fields.thamu
                txt_BN_Soi.Text = dao.fields.thasoi
                txt_BN_road.Text = dao.fields.tharoad
                txt_BN_zipcode.Text = dao.fields.zipcode
                If dao.fields.chngwtcd IsNot Nothing Then ddl_bn_changwat.SelectedValue = dao.fields.chngwtcd
                If dao.fields.amphrcd IsNot Nothing Then
                    load_ddl_bn_amp()
                    ddl_bn_ampher.SelectedValue = dao.fields.amphrcd
                End If
                If dao.fields.thmblcd IsNot Nothing Then
                    load_ddl_bn_thambol()
                    ddl_bn_tambol.SelectedValue = dao.fields.thmblcd
                End If
                Label_house_no.Visible = False
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('" & "กรุณากรอกรหัสประจำบ้าน" & "');", True)
            Label_house_no.Visible = True
        End If

    End Sub
    Sub Search_FN()
        Dim pvncd As Integer = 0
        Try
            pvncd = _CLS.PVCODE
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim PHR_IDEN As String = ""
        If txt_CITIZEN_AUTHORIZE.Text = "" And txt_lcnno_no.Text = "" Then
            PHR_IDEN = _CLS.CITIZEN_ID
        End If
        Dim dt As New DataTable
        Dim command As String = " "
        Dim command2 As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select * from dbo.Vw_SP_DALCN_SEARCH_EDIT "
        command2 = "select * from dbo.Vw_SP_DALCN_PHR_SEARCH "
        Dim str_where As String = ""
        Dim dt2 As New DataTable
        If txt_CITIZEN_AUTHORIZE.Text = "" And txt_lcnno_no.Text = "" Then
            command2 &= "where PHR_CTZNO='" & PHR_IDEN & "' AND STAT_DA = 'คงอยู่'"
            dt = bao_aa.Queryds(command2)
        Else
            If txt_CITIZEN_AUTHORIZE.Text <> "" Then
                str_where = "where CITIZEN_ID_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "' AND STAT_DA = 'คงอยู่'"
                If txt_lcnno_no.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and LCNNO_DISPLAY_NEW like '%" & txt_lcnno_no.Text & "%'"
                    Else
                        str_where &= "LCNNO_DISPLAY_NEW like '%" & txt_lcnno_no.Text & "%'"
                    End If

                End If
                command &= str_where
            Else
                If str_where = "" Then
                    If str_where <> "" Then
                        If txt_lcnno_no.Text <> "" Then
                            str_where &= " and LCNNO_DISPLAY_NEW like '%" & txt_lcnno_no.Text & "%' or lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                        End If
                    Else
                        If txt_lcnno_no.Text <> "" Then
                            str_where = "where LCNNO_DISPLAY_NEW like '%" & txt_lcnno_no.Text & "%' or lcnno_no like '%" & txt_lcnno_no.Text & "%'"

                        End If
                    End If
                    command &= str_where
                Else
                    If txt_lcnno_no.Text <> "" Then
                        str_where = "where lcnno_no like '%" & txt_lcnno_no.Text & "%' or lcnno_no like '%" & txt_lcnno_no.Text & "%'"

                    End If
                    command &= str_where
                End If
            End If
            dt = bao_aa.Queryds(command)
        End If
        'If pvncd = 10 Then
        '    If command.Contains("where") Then
        '        command &= " and lcn_stat=0"
        '    Else
        '        If command.Contains("pvncd") Then
        '            command &= " and lcn_stat=0 and lcntpcd <> 'ผย1' "
        '        Else
        '            command &= "where lcn_stat=0 and lcntpcd <> 'ผย1' "
        '        End If
        '    End If

        'Else
        '    'RadGrid1.DataSource = dt2.Select("lcn_stat=0 and pvncd = '" & pvncd & "'")
        '    If command.Contains("where") Then
        '        command &= " and lcn_stat=0 and pvncd = '" & pvncd & "'"
        '    Else
        '        command &= "where lcn_stat=0 and pvncd = '" & pvncd & "'"
        '    End If
        'End If
        If dt.Rows.Count > 1 Then
            rdl_phr.SelectedValue = 1
            chk_rad.Visible = True
        End If
        RadGrid_lcn.DataSource = dt
    End Sub

    Protected Sub btn_search_lcn_Click(sender As Object, e As EventArgs) Handles btn_search_lcn.Click
        Search_FN()
        RadGrid_lcn.Rebind()
    End Sub

    Private Sub RadGrid_lcn_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid_lcn.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "sel" Then
                Dim Name_thanm = item("thanm").Text
                Dim Addr = item("thanm_addr").Text
                Dim IDA = item("IDA").Text
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(IDA)
                Dim dao_lo As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                dao_lo.GetDataby_IDA(dao.fields.FK_IDA)
                With dao_lo.fields
                    '.MATRA = DDL_Matra.SelectedValue
                    txt_Name_Bsn.Text = .thanameplace
                    txt_BSN_addr.Text = .thaaddr
                    txt_BSN_Building.Text = .thabuilding
                    txt_BSN_mu.Text = .thamu
                    txt_BSN_Soi.Text = .thasoi
                    txt_BSN_road.Text = .tharoad
                    Try
                        ddl_Province.SelectedItem.Text = .thachngwtnm
                        ddl_Province.SelectedValue = .chngwtcd
                    Catch ex As Exception

                    End Try
                    Try
                        'ddl_amphor.SelectedItem.Text = .thathmblnm
                        ddl_amphor.SelectedValue = .amphrcd
                        load_ddl_amp()
                    Catch ex As Exception
                        '.PHR_AMPHER_BSN = "-"
                    End Try

                    Try
                        'ddl_tambol.SelectedItem.Text = .thathmblnm
                        ddl_tambol.SelectedValue = .thmblcd
                        load_ddl_thambol()
                    Catch ex As Exception

                    End Try

                    txt_BSN_zipcode.Text = .zipcode
                    txt_BSN_tel.Text = .tel
                    'txt_BSN_Opentime.Text =
                End With
                txt_search_lcn_ida.Text = IDA
            End If
        End If

    End Sub
    Protected Sub rdl_phr_CheckedChanged(sender As Object, e As EventArgs) Handles rdl_phr.SelectedIndexChanged
        If rdl_phr.SelectedValue = 1 Then
            chk_rad.Visible = True
        Else
            chk_rad.Visible = False
        End If
    End Sub

    Protected Sub BTN_SEARCH_LCNNO_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_LCNNO.Click
        Dim pvncd As Integer = 0
        Try
            pvncd = _CLS.PVCODE
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim dt As New DataTable
        Dim command As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select * from dbo.Vw_SP_DALCN_SEARCH_EDIT "
        Dim str_where As String = ""
        Dim dt2 As New DataTable
        If txt_lcnno_no.Text = "" Then
            command &= str_where
            dt = bao_aa.Queryds(command)
        Else
            If str_where = "" Then
                If txt_lcnno_no.Text <> "" Then
                    str_where = "where LCNNO_DISPLAY_NEW = '" & BTN_SEARCH_LCNNO.Text & "' or lcnno_no like '%" & BTN_SEARCH_LCNNO.Text & "%' and STAT_DA like N'%คงอยู่%'"
                End If
                command &= str_where
            Else
                If txt_lcnno_no.Text <> "" Then
                    str_where = "where lcnno_no = '" & BTN_SEARCH_LCNNO.Text & "' or lcnno_no like '%" & BTN_SEARCH_LCNNO.Text & "%' and STAT_DA like N'%คงอยู่%'"
                End If
                command &= str_where
            End If
        End If
        dt = bao_aa.Queryds(command)
        'RadGrid_lcn2.DataSource = dt
        Dim IDA As String = String.Empty
        If dt.Columns.Contains("IDA") Then
            ' ตรวจสอบว่าแถวแรกมีข้อมูลในคอลัมน์ IDA หรือไม่
            If dt.Rows.Count > 0 Then
                IDA = dt.Rows(0)("IDA").ToString()
            End If
        End If
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(IDA)
        Dim dao_lo As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_lo.GetDataby_IDA(dao.fields.FK_IDA)
        With dao_lo.fields
            '.MATRA = DDL_Matra.SelectedValue
            HOME_NO.Text = .HOUSENO
            txt_Business_Name.Text = .thanameplace
            txt_BN_addr.Text = .thaaddr
            txt_BN_Building.Text = .thabuilding
            txt_BN_mu.Text = .thamu
            txt_BN_Soi.Text = .thasoi
            txt_BN_road.Text = .tharoad
            Try
                ddl_bn_changwat.SelectedItem.Text = .thachngwtnm
                ddl_bn_changwat.SelectedValue = .chngwtcd
            Catch ex As Exception

            End Try
            Try
                'ddl_amphor.SelectedItem.Text = .thathmblnm
                ddl_bn_ampher.SelectedValue = .amphrcd
                load_ddl_amp()
            Catch ex As Exception
                '.PHR_AMPHER_BSN = "-"
            End Try

            Try
                'ddl_tambol.SelectedItem.Text = .thathmblnm
                ddl_bn_tambol.SelectedValue = .thmblcd
                load_ddl_thambol()
            Catch ex As Exception

            End Try

            txt_BN_zipcode.Text = .zipcode
            txt_BN_tel.Text = .tel
            'txt_BSN_Opentime.Text =
        End With
    End Sub
End Class