Imports Telerik.Web.UI
Public Class POPUP_HERB_PRODUCT_NOTIFIED_ADD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _LCNNO_DISPLAY As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _PROCESS_ID As String = ""
    Private _IDA As String = ""
    Private _SID As String = ""

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

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _LCNNO_DISPLAY = Request.QueryString("LCNNO_DISPLAY")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")
        _SID = Request.QueryString("SID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            blind_DATA_lcn()
        End If
    End Sub
    Sub blind_DATA_lcn()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim dao_ad As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao.GetDataby_IDA(_IDA_LCN)
        dao_ad.GetDataby_IDA(dao.fields.FK_IDA)
        lcnno.Text = dao.fields.LCNNO_DISPLAY_NEW
        thanm.Text = dao.fields.thanm
        name_addr.Text = dao_ad.fields.thanameplace
        addr.Text = dao_ad.fields.thaaddr
        mu.Text = dao_ad.fields.thamu
        ' txt_soi.Text = dao_ad.fields.thasoi
        road.Text = dao_ad.fields.tharoad
        tambol.Text = dao_ad.fields.thathmblnm
        ampher.Text = dao_ad.fields.thaamphrnm
        changwat.Text = dao_ad.fields.thachngwtnm
        zipcode.Text = dao_ad.fields.zipcode
        tel.Text = dao_ad.fields.tel
    End Sub
    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        dt = bao.SP_HERB_PRODUCT_NOTIFIED_DETAIL(_IDA)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao As New DAO_REPORT.TB_HERB_PRODUCT_NOTIFIED_DETAIL
        dao.fields.Trade_Name = sell_name.Text
        dao.fields.Scientific_Name = wit.Text
        dao.fields.Latin_Name = latin_name.Text
        dao.fields.Quantity = quantity.Text
        dao.fields.Thai_Name = thai_name.Text
        dao.fields.English_Name = eng_name.Text
        dao.fields.Extract = sakat.Text
        dao.fields.Producer = palid.Text
        dao.fields.Production_Version = run_palit.Text
        dao.fields.FK_IDA = _IDA
        dao.insert()

        RadGrid1.Rebind()
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        TR_ID = bao_tran.insert_transection(_PROCESS_ID)
        Dim dao As New DAO_REPORT.TB_HERB_PRODUCT_NOTIFIED
        dao.Getdataby_IDA(_IDA)
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.TR_ID = TR_ID
        dao.fields.PROCESS_ID = _PROCESS_ID
        dao.fields.FK_LCN = _IDA_LCN
        dao.fields.CREATE_BY = _CLS.THANM
        dao.fields.DATE_CONFIRM = Date.Now
        dao.fields.FK_LCN = _IDA_LCN
        dao.fields.ACTIVEFACT = 1
        dao.fields.STATUS_ID = 1
        dao.fields.THANM = dao_lcn.fields.thanm
        dao.fields.LCNNO_NEW = dao_lcn.fields.LCNNO_DISPLAY_NEW
        dao.fields.LCNNO = dao_lcn.fields.lcnno
        dao.Update()

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        dao_up_mas.GetdatabyID_TYPE(306)
        For Each dao_up_mas.fields In dao_up_mas.datas
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
            dao_up.fields.TR_ID = TR_ID
            dao_up.fields.PROCESS_ID = _PROCESS_ID
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.FK_IDA = dao.fields.IDA
            dao_up.fields.TYPE = 1
            dao_up.insert()
        Next
        ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        Response.Redirect("POPUP_HERB_PRODUCT_NOTIFIED_UPLOAD.aspx?IDA=" & dao.fields.IDA & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN & "&staff=" & Request.QueryString("staff"))
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
End Class