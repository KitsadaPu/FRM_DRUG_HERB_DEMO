Imports Telerik.Web.UI
Public Class UC_TRANSFER_DETAIL
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _IDA_DQ As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA As String = ""
    Private _SID As String = ""
    Private _PROCESS_ID As String = ""
    Private _PROCESS_ID_DQ As String = ""
    Private _PROCESS_ID_LCN As String = ""

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
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_DQ = Request.QueryString("IDA_DQ")
        _IDA = Request.QueryString("IDA_DQ")
        _SID = Request.QueryString("SID")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _PROCESS_ID_DQ = Request.QueryString("PROCESS_ID_DQ")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then
            bind_data()
            bind_dd_stype()
            bind_dd_syndrome()
            bind_dd_eatting()
            bind_dd_eatting_condition()
            bind_dd_warning()
            bind_dd_manufac()
            bind_dd_storage()
            bind_dd_HERB_PROCESS()
            bind_dd_herb()


            Try
                If _PROCESS_ID_DQ.Contains(2019) Then
                    If _PROCESS_ID_LCN = 121 Then
                        DD_CATEGORY_ID.SelectedValue = 1210
                        DD_CATEGORY_OUT_ID.SelectedValue = 1200
                    ElseIf _PROCESS_ID_LCN = 122 Then
                        DD_CATEGORY_ID.SelectedValue = 1220
                        DD_CATEGORY_OUT_ID.SelectedValue = 1200
                    End If
                Else
                    DD_CATEGORY_ID.SelectedValue = _PROCESS_ID_LCN
                End If

            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA_DQ)
            Try
                If Request.QueryString("staff") = 2 Then
                    SALE_CHANNEL_SET.Visible = True
                    STAFF_KEY_SET.Visible = True
                    'STAFF_HIDE_SET.Visible = False
                ElseIf Request.QueryString("staff") = 1 Then
                    'STAFF_HIDE_SET.Visible = True
                Else
                    SALE_CHANNEL_SET.Visible = False
                    STAFF_KEY_SET.Visible = False
                    'STAFF_HIDE_SET.Visible = True
                End If
            Catch ex As Exception

            End Try


            If _PROCESS_ID_DQ = 20191 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            ElseIf _PROCESS_ID_DQ = 20192 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            ElseIf _PROCESS_ID_DQ = 20193 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            ElseIf _PROCESS_ID_DQ = 20194 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            Else
                DD_CATEGORY_OUT_ID.Visible = False
                lab_category_out_id.Visible = False
            End If

        End If
    End Sub
    Public Sub bind_dd_warning()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_WARNING()

        DD_WARNING.DataSource = dt
        DD_WARNING.DataBind()
        DD_WARNING.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_manufac()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_MENUFACTRUE()

        DD_MANUFAC_ID.DataSource = dt
        DD_MANUFAC_ID.DataBind()
        DD_MANUFAC_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_storage()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STORAGE_JJ()

        DD_STORAGE_ID.DataSource = dt
        DD_STORAGE_ID.DataBind()
        DD_STORAGE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_warning_sub(ByVal fk_ida As Integer)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_WARNING_SUB(fk_ida)

        DD_WARNING_SUB.DataSource = dt
        DD_WARNING_SUB.DataBind()
        DD_WARNING_SUB.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_HERB_PROCESS()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA_DQ)
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tn.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_DD_HERB(dao_tn.fields.CATEGORY_ID)

        DD_TYPE_NAME.DataSource = dt
        DD_TYPE_NAME.DataBind()
        DD_TYPE_NAME.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_stype()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STYPE_JJ()

        DD_STYPE_ID.DataSource = dt
        DD_STYPE_ID.DataBind()
        DD_STYPE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_syndrome()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ()
        DD_SYNDROME_ID.DataSource = dt
        DD_SYNDROME_ID.DataBind()
        DD_SYNDROME_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_dd_eatting()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_JJ()
        DD_EATTING_ID.DataSource = dt
        DD_EATTING_ID.DataBind()
        DD_EATTING_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_dd_eatting_condition()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_CONDITION()
        DD_EATING_CONDITION_ID.DataSource = dt
        DD_EATING_CONDITION_ID.DataBind()
        DD_EATING_CONDITION_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_dd_herb()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        If _PROCESS_ID_DQ = 20101 Then
            DD_TYPE_NAME.SelectedValue = 20101
            DD_TYPE_SUB_ID.SelectedValue = 1
        ElseIf _PROCESS_ID_DQ = 20102 Then
            DD_TYPE_NAME.SelectedValue = 20102
            DD_TYPE_SUB_ID.SelectedValue = 2
        ElseIf _PROCESS_ID_DQ = 20103 Then
            DD_TYPE_NAME.SelectedValue = 20103
            DD_TYPE_SUB_ID.SelectedValue = 3
        ElseIf _PROCESS_ID_DQ = 20104 Then
            DD_TYPE_NAME.SelectedValue = 20104
            DD_TYPE_SUB_ID.SelectedValue = 4
        ElseIf _PROCESS_ID_DQ = 20191 Then
            DD_TYPE_NAME.SelectedValue = 20191
            DD_TYPE_SUB_ID.SelectedValue = 1
        ElseIf _PROCESS_ID_DQ = 20192 Then
            DD_TYPE_NAME.SelectedValue = 20192
            DD_TYPE_SUB_ID.SelectedValue = 2
        ElseIf _PROCESS_ID_DQ = 20193 Then
            DD_TYPE_NAME.SelectedValue = 20193
            DD_TYPE_SUB_ID.SelectedValue = 3
        ElseIf _PROCESS_ID_DQ = 20194 Then
            DD_TYPE_NAME.SelectedValue = 20194
            DD_TYPE_SUB_ID.SelectedValue = 4
        End If
    End Sub
    Public Sub bind_data()
        Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
        dao_drrqt.GetDataby_IDA(_IDA_DQ)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        ' Dim thanm As String = dao_lcn.fields.thanm
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try

        Dim THANM As String = dao_lcn.fields.thanm
        Dim dao_who As New DAO_WHO.TB_WHO_DALCN
        dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
        If _SID = "2" Then
            THANM = dao_who.fields.THANM_NAME
        Else
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
        End If

        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            tb_location.GetDataby_LCN_IDA(_IDA_LCN)
        Catch ex As Exception

        End Try
        Dim dao_pfx As New DAO_CPN.TB_sysprefix
        Dim BSN_THAIFULLNAME As String = ""
        Try
            dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
            Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
            Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
            Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
            BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

        Catch ex As Exception

        End Try
        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)

        Dim dao_cpnWho As New DAO_CPN.clsDBsyslcnsid
        dao_cpnWho.GetDataby_identify(_CLS.CITIZEN_ID_AUTHORIZE)
        Dim TYPE_PERSON_WHO As Integer = dao_cpnWho.fields.type

        Dim TYPE_PERSON As Integer = dao_cpn.fields.type
        Dim NATION As String = dao_lcn.fields.NATION
        If _SID = 2 Then
            If TYPE_PERSON_WHO = 1 Then
                data_show3.Visible = False
            ElseIf TYPE_PERSON_WHO = 99 Then
                data_show3.Visible = True
            End If
        Else
            If TYPE_PERSON = 1 Then
                data_show3.Visible = False
            ElseIf TYPE_PERSON = 99 Then
                data_show3.Visible = True
                txt_agent99.Text = BSN_THAIFULLNAME

            End If
        End If
        dao_who.GetdatabyID_FK_LCN_IDEN(_IDA_LCN, _CLS.CITIZEN_ID)
        If _SID = "2" Then
            If TYPE_PERSON_WHO = 1 Then
                THANM = _CLS.THANM
                NAME_TB.Text = THANM
            Else
                THANM = dao_who.fields.THANM_NAME
                NAME_TB.Text = THANM
            End If

        Else
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            NAME_TB.Text = THANM
        End If
        NAME_PLACE_TB.Text = locationaddress
        Try
            NAME_THAI.Text = dao_tabean.fields.NAME_THAI
            NAME_ENG.Text = dao_tabean.fields.NAME_ENG
            'NAME_OTHER.Text = dao_tabean.fields.NAME_OTHER
            txt_person_age.Text = dao_tabean.fields.PERSON_AGE
            txt_agent99.Text = dao_tabean.fields.PERSON_AGE
            SIZE_PACK.Text = dao_tabean.fields.SIZE_PACK
            NATURE.Text = dao_tabean.fields.NATURE
            PROPERTIES.Text = dao_tabean.fields.PROPERTIES
            SIZE_USE.Text = dao_tabean.fields.SIZE_USE
            HOW_USE.Text = dao_tabean.fields.HOW_USE
            NOTE.Text = dao_tabean.fields.NOTE
            RECIPE_NAME.Text = dao_tabean.fields.RECIPE_NAME
            DDL_NATION.SelectedValue = dao_tabean.fields.NATIONALITY_PERSON_ID
            DD_EATING_CONDITION_ID.SelectedValue = dao_tabean.fields.EATING_CONDITION_ID
            DD_EATTING_ID.SelectedValue = dao_tabean.fields.EATTING_ID
            DD_MANUFAC_ID.SelectedValue = dao_tabean.fields.MANUFAC_ID
            DD_SALE_CHANNEL.SelectedValue = dao_tabean.fields.SALE_CHANNEL_ID
            DD_STORAGE_ID.SelectedValue = dao_tabean.fields.STORAGE_ID
            DD_SYNDROME_ID.SelectedValue = dao_tabean.fields.SYNDROME_ID
            DD_WARNING.SelectedValue = dao_tabean.fields.WARNING_ID
            DD_STYPE_ID.SelectedValue = dao_tabean.fields.STYPE_ID
            DDL_RECIPE_NAME.SelectedValue = dao_tabean.fields.RECIPE_UNIT_ID
            TREATMENT_AGE_MONTH_SUB.SelectedValue = dao_tabean.fields.TREATMENT_AGE_MONTH
            TREATMENT_AGE_YEAR.SelectedValue = dao_tabean.fields.TREATMENT_AGE_ID
            R_CAUTION.SelectedValue = dao_tabean.fields.CAUTION_ID
            R_CONTRAINDICATION.SelectedValue = dao_tabean.fields.CONTRAINDICATION_ID

        Catch ex As Exception

        End Try
    End Sub
    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
        dao_size.GetdatabyID_FK_IDA_DQ2(_IDA_DQ)
        RadGrid4.DataSource = dao_size.datas

    End Sub
    Sub save_data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        dao.fields.NAME_THAI = NAME_THAI.Text
        dao.fields.NAME_ENG = NAME_ENG.Text
        'dao.fields.NAME_OTHER = NAME_OTHER.Text
        dao.Update()

        Dim dao_QT As New DAO_DRUG.ClsDBdrrqt
        dao_QT.GetDataby_IDA(_IDA_DQ)
        dao_QT.fields.thadrgnm = NAME_THAI.Text
        dao_QT.fields.engdrgnm = NAME_ENG.Text
        dao_QT.update()
    End Sub
    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        bind_size()
    End Sub
End Class