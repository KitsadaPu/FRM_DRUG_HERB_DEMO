Public Class FRM_PHR_HERB_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As String
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
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        If Not IsPostBack Then
            UC_PHR_DETAIL.bind_ddl_phr_type()
            UC_PHR_DETAIL.bind_data(dao)
            UC_PHR_DETAIL.get_date()
            UC_PHR_DETAIL.bind_ddl_phr_type_other()
            UC_PHR_DETAIL.load_ddl_chwt()
            UC_PHR_DETAIL.load_ddl_amp()
            UC_PHR_DETAIL.load_ddl_thambol()
            UC_PHR_DETAIL.load_ddl_bn_chwt()
            UC_PHR_DETAIL.load_ddl_bn_amp()
            UC_PHR_DETAIL.load_ddl_bn_thambol()
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(Request.QueryString("PHR_IDA"))
        UC_PHR_DETAIL.set_data_phr(dao)
        With dao.fields
            'Try
            '    .FK_IDA = _IDA_LCN
            'Catch ex As Exception

            'End Try
            '.CITIZEN_ID_AUTHORIZE = _IDEN
            '.YEAR = con_year(Date.Now().Year())
            '.phr_status = 1
            .IS_ACTIVE = 1
        End With
        dao.update()
        alert("บันทึกข้อมูลแล้ว")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
End Class