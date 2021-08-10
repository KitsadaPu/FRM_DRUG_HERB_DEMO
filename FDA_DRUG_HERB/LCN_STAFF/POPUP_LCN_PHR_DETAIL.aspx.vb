Public Class POPUP_LCN_PHR_DETAIL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            dao.GetDataby_IDA(Request.QueryString("phr"))
            'dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            bind_ddl_prefix()
            bind_ddl_job()
            bind_ddl_work_type()
            bind_lcn_type()
            get_data(dao)
        End If
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.ClsDBDALCN_PHR)
        With dao.fields
            txt_PHR_NAME.Text = .PHR_NAME
            txt_PHR_LEVEL.Text = .PHR_LEVEL
            Try
                ddl_prefix.DropDownSelectData(.PHR_PREFIX_ID)
            Catch ex As Exception

            End Try
            Try
                ddl_job.DropDownSelectData(.PHR_JOB_TYPE)
            Catch ex As Exception

            End Try
            Try
                ddl_law.DropDownSelectData(.PHR_LAW_SECTION)
            Catch ex As Exception

            End Try
            txt_PHR_VETERINARY_FIELD.Text = .PHR_VETERINARY_FIELD
            'txt_PHR_CTZNO.Text = .PHR_CTZNO
            txt_PHR_TEXT_NUM.Text = .PHR_TEXT_NUM
            txt_PHR_TEXT_WORK_TIME.Text = .PHR_TEXT_WORK_TIME
            txt_STUDY_LEVEL.Text = .STUDY_LEVEL
            Try
                'rdl_per_type.SelectedValue = .PERSONAL_TYPE
                ddl_worker_type.DropDownSelectData(.PERSONAL_TYPE)
            Catch ex As Exception
                'rdl_per_type.SelectedValue = 1
            End Try
            Try
                txt_PHR_TEXT_JOB.Text = .PHR_TEXT_JOB
            Catch ex As Exception

            End Try
            'Try
            '    ddl_PHR_MEDICAL_TYPE.DropDownSelectData(.PHR_MEDICAL_TYPE)
            'Catch ex As Exception

            'End Try
            'Try
            '    .SIMINAR_DATE = rdp_SIMINAR_DATE.SelectedDate
            'Catch ex As Exception

            'End Try

            rgns.DataBind()

        End With
    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub
    Sub bind_ddl_job()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_PHR_JOB()
        Catch ex As Exception

        End Try
        ddl_job.DataSource = dt
        ddl_job.DataValueField = "functcd"
        ddl_job.DataTextField = "functnm"
        ddl_job.DataBind()
    End Sub
    Sub bind_ddl_work_type()
        Try
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_PHR_HERB
            dao.GetDataAll()
            ddl_worker_type.DataSource = dao.datas
            ddl_worker_type.DataValueField = "TYPE_ID"
            ddl_worker_type.DataTextField = "TYPE_PHR_HERB"
            ddl_worker_type.DataBind()

            Dim item As New ListItem
            item.Text = "-"
            item.Value = "0"
            ' ddl_worker_type.Items.Insert(0, item)
        Catch ex As Exception

        End Try


    End Sub
    Sub bind_lcn_type()
        Dim dao As New DAO_DRUG.TB_MAS_TYPE_PHR_HERB
        Try
            dao.GetData_by_TYPE_ID(ddl_worker_type.SelectedValue)
            'lbl_lcn_type.Text = dao.fields.lcndtlnm
        Catch ex As Exception

        End Try

    End Sub
End Class