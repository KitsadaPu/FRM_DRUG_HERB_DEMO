Imports Telerik.Web.UI
Public Class UC_REPORT_1
    Inherits System.Web.UI.UserControl
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
        TextBox2.Text = dao.fields.LCNNO_DISPLAY_NEW
        TextBox1.Text = dao.fields.thanm
        TextBox3.Text = dao_ad.fields.thanameplace
        TextBox4.Text = dao_ad.fields.thaaddr
        TextBox6.Text = dao_ad.fields.thamu
        ' txt_soi.Text = dao_ad.fields.thasoi
        TextBox8.Text = dao_ad.fields.tharoad
        TextBox7.Text = dao_ad.fields.thathmblnm
        TextBox5.Text = dao_ad.fields.thaamphrnm
        TextBox9.Text = dao_ad.fields.thachngwtnm
    End Sub
    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        dt = bao.SP_HERB_REPORT_DETAIL_BY_FK_IDA_LCN(_IDA)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao As New DAO_REPORT.TB_HERB_PRODUCT_REPORT_DETAIL
        dao.fields.Name = TextBox10.Text
        dao.fields.Scientific_Name = TextBox11.Text
        dao.fields.Packing_Size_Details = TextBox12.Text
        dao.fields.Quantity = TextBox13.Text
        dao.fields.Total_Quantity = TextBox14.Text
        dao.fields.Sale_Unit = TextBox15.Text
        dao.fields.Note = TextBox16.Text
        dao.fields.IS_USE = 1
        dao.fields.FK_IDA = _IDA
        dao.insert()

        RadGrid1.Rebind()
    End Sub
End Class