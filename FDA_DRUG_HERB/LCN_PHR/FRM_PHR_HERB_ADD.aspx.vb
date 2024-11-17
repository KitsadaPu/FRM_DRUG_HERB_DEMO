Public Class FRM_PHR_HERB_ADD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _IDA_LCN As String
    Private _IDEN As String
    Sub RunSession()
        '_ProcessID = 10104
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")

        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
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
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            dao.GetDataby_IDA(Request.QueryString("PHR_IDA"))
            UC_PHR_DETAIL.bind_ddl_phr_type()
            UC_PHR_DETAIL.get_date()
            UC_PHR_DETAIL.bind_ddl_phr_type_other()
            UC_PHR_DETAIL.bind_ddl_training_phr()
            UC_PHR_DETAIL.bind_DDL_VETERINARY_FIELD()
            UC_PHR_DETAIL.bind_DDL_STUDY_LEVEL()
            UC_PHR_DETAIL.bind_data(dao)
            'UC_PHR_DETAIL.load_ddl_thambol()
            'UC_PHR_DETAIL.load_ddl_amp()
            UC_PHR_DETAIL.load_ddl_chwt()
            UC_PHR_DETAIL.load_ddl_bn_chwt()
            'UC_PHR_DETAIL.load_ddl_bn_amp()
            'UC_PHR_DETAIL.load_ddl_bn_thambol()
        End If
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim TR_ID As String = ""
        Dim check_id As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(Request.QueryString("PHR_IDA"))
        check_id = UC_PHR_DETAIL.check_data()
        If check_id = 1 Then
            UC_PHR_DETAIL.set_data_phr(dao)
            With dao.fields
                Try
                    .FK_IDA = _IDA_LCN
                Catch ex As Exception

                End Try
                .CITIZEN_ID_AUTHORIZE = _IDEN
                .YEAR = con_year(Date.Now().Year())
                .phr_status = 1
                .ACTIVEFACT = 1
            End With
            Try
                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

                TR_ID = bao_tran.insert_transection(_ProcessID)
            Catch ex As Exception

            End Try
            dao.fields.TRANSECTION_ID_UPLOAD = TR_ID
            dao.fields.TR_ID = TR_ID
            dao.update()
            Try
                Dim head_id As Integer = 0
                Dim id As Integer = 0
                Dim id2 As Integer = 0
                Dim type_p As String = ""
                Dim type_b As String = ""
                Dim type_l As String = ""
                Dim process As Integer = 0
                'Dim dao_attgroup As New DAO.tb_attachgroup
                Dim dao_attgroup As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
                Dim dao_attgroup2 As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
                'Dim dao As New DAO_DRUG.ClsDBdalcn
                'dao.GetDataby_IDA(_IDA)
                TR_ID = TR_ID

                process = _ProcessID
                Dim TYPE_ID As Integer = 1

                'dao_attgroup.GetDataby_HEAD_ID_AND_TITLE_ID_AND_PROCESS(head_id, id, id2, TYPE_ID)
                dao_attgroup.GetDataby_TYPE_ID_AND_PROCESS(1, process)
                Dim btn As Button = CType(sender, Button)

                For Each dao_attgroup.fields In dao_attgroup.datas
                    Dim dao_att As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    Dim dao_mas As New DAO_DRUG.TB_MAS_DOCUMENT_NAME_UPLOAD_DALCN
                    'dao_mas.GetDataby_ID(dao_attgroup.fields.MAIN_MENU)
                    dao_att.fields.DOCUMENT_NAME = dao_attgroup.fields.DOCUMENT_NAME
                    'dao_att.fields.DOCUMENT_NAME = dao_attgroup.fields.DOCUMENT_NAME
                    dao_att.fields.TYPE_PERSON = head_id
                    dao_att.fields.TYPE_LOCAL = id
                    dao_att.fields.TYPE_BSN = id2
                    dao_att.fields.TYPE = 1
                    dao_att.fields.FK_IDA = Request.QueryString("PHR_IDA")
                    dao_att.fields.TR_ID = TR_ID
                    dao_att.fields.PROCESS_ID = process
                    dao_att.fields.TYPE_PERSON_NAME = type_p
                    dao_att.fields.TYPE_LOCAL_NAME = type_l
                    dao_att.fields.TYPE_BSN_NAME = type_b
                    dao_att.fields.Active = True
                    dao_att.insert()
                Next
            Catch ex As Exception

            End Try
            alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", Request.QueryString("PHR_IDA"))
        End If

    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "FRM_PHR_HERB_UPLOAD.aspx?IDA=" & ida
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
End Class