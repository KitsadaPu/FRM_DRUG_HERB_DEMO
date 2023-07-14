Public Class POP_UP_LCN_AUDIT_IN_ADD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As Integer
    Private _IDEN As String
    Sub RunSession()
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
        UC_LCN_AUDIT_IN_DETAIL_GROUP_DRUG.bind_head()
        UC_LCN_AUDIT_IN_DETAIL_GROUP_DRUG.BindTable()
        If Not IsPostBack Then
            UC_LCN_AUDIT_IN_DETAIL.get_data(_IDA_LCN)
            UC_LCN_AUDIT_IN_DETAIL_GROUP_DRUG.get_data(_IDA_LCN)
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_LCN.TB_DALCN_AUDIT_IN
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        UC_LCN_AUDIT_IN_DETAIL.save_data(dao)
        With dao.fields
            Try
                .FK_LCN = _IDA_LCN
            Catch ex As Exception

            End Try
            .PROCESS_ID = _ProcessID
            .CREATE_BY = _CLS.THANM
            .CREATE_DATE = Date.Now
            .CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            .CITIZEN_ID = _CLS.CITIZEN_ID
            .YEAR = con_year(Date.Now().Year())
            .STATUS_ID = 1
            .ACTIVEFACT = 1
        End With
        Try
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection(_ProcessID)
        Catch ex As Exception

        End Try
        dao.fields.TR_ID = TR_ID
        dao.insert()
        Try
            UC_LCN_AUDIT_IN_DETAIL_GROUP_DRUG.save_data(dao.fields.IDA)
            UC_LCN_AUDIT_IN_DETAIL_GROUP_DRUG.save_data_tb(dao.fields.IDA)
        Catch ex As Exception

        End Try
        Dim dao_attgroup As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME

        dao_attgroup.GetDataby_HEAD_ID_AND_PROCESS(0, _ProcessID)
        For Each dao_attgroup.fields In dao_attgroup.datas
            Dim dao_att As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            Dim dao_mas As New DAO_DRUG.TB_MAS_DUCUMENT_NAME_UPLOAD_DALCN
            dao_att.fields.DUCUMENT_NAME = dao_attgroup.fields.DUCUMENT_NAME
            dao_att.fields.TYPE_PERSON = 0
            dao_att.fields.TYPE_LOCAL = 0
            dao_att.fields.TYPE_BSN = 0
            dao_att.fields.TYPE = 1
            dao_att.fields.FK_IDA = dao.fields.IDA
            dao_att.fields.TR_ID = TR_ID
            dao_att.fields.PROCESS_ID = _ProcessID
            dao_att.fields.TYPE_PERSON_NAME = 0
            dao_att.fields.TYPE_LOCAL_NAME = 0
            dao_att.fields.TYPE_BSN_NAME = 0
            dao_att.insert()

        Next
        alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", dao.fields.IDA)
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POP_UP_LCN_AUDIT_IN_UPLOAD.aspx?IDA=" & ida & "&PROCESS_ID=" & _ProcessID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class