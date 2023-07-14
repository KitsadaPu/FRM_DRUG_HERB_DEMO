Public Class POP_UP_LCN_CONSIDER_TRANSLATION_ADD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As String
    Private _IDEN As String
    Sub RunSession()
        '_ProcessID = 10701
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
        UC_LCN_TYPE_PRODUCK.bind_head()
        UC_LCN_TYPE_PRODUCK.bind_head2()
        UC_LCN_TYPE_PRODUCK.bind_head3()
        UC_LCN_TYPE_PRODUCK.bind_head4()
        UC_LCN_TYPE_PRODUCK.BindTable()
        UC_LCN_TYPE_PRODUCK.BindTable2()
        UC_LCN_TYPE_PRODUCK.BindTable3()
        UC_LCN_TYPE_PRODUCK.BindTable4()

        If Not IsPostBack Then
            UC_LCN_DETAIL.get_data(_IDA_LCN)
            UC_LCN_DETAIL.load_ddl_chwt()


            If Request.QueryString("ida") <> "" Then
                Panel1.Style.Add("display", "none")
                Panel2.Style.Add("display", "block")
                'btn_save.Style.Add("display", "none")
                'btn_save2.Style.Add("display", "block")
                btn_save.Visible = False
                btn_save2.Visible = True
            Else
                Panel1.Style.Add("display", "block")
                Panel2.Style.Add("display", "none")
                'btn_save.Style.Add("display", "block")
                btn_save.Visible = True
                'btn_save2.Style.Add("display", "none")
                btn_save2.Visible = False
            End If

        End If
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        With dao.fields
            UC_LCN_DETAIL.save_data(dao)
            .CITIZEN_ID = _CLS.CITIZEN_ID
            .CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            .CREATE_BY = _CLS.THANM
            .CREATE_DATE = Date.Now
            .STATUS_ID = 1
            .ACTIVEFACT = 1
            .PROCESS_ID = _ProcessID
            .YEAR = con_year(Date.Now().Year())
        End With
        dao.fields.FK_LCN = dao_lcn.fields.IDA
        dao.fields.FK_IDA = dao_lcn.fields.IDA
        dao.fields.FK_LCT = dao_lcn.fields.FK_IDA
        dao.fields.lcnsid = dao_lcn.fields.lcnsid
        dao.fields.LCNNO = dao_lcn.fields.lcnno
        dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
        Try
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection(_ProcessID)
        Catch ex As Exception

        End Try
        dao.fields.TR_ID = TR_ID
        dao.insert()
        Dim IDA As Integer = dao.fields.IDA
        'Panel1.Style.Add("display", "block")
        'Panel2.Style.Add("display", "none")
        'btn_save.Style.Add("display", "block")
        'btn_save2.Style.Add("display", "none")
        alert_return("บันทึกข้อมูลส่วนที่หนึ่งแล้ว")
        Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri & "&ida=" & IDA)

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

    Protected Sub btn_save2_Click(sender As Object, e As EventArgs) Handles btn_save2.Click
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        UC_LCN_TYPE_PRODUCK.save_data_tb(Request.QueryString("IDA"))
        Blind_PDF()
        alert("บันทึกข้อมูลส่วนที่สองแล้ว")
    End Sub
    Sub Blind_PDF()
        Dim _IDA As Integer = Request.QueryString("IDA")
        Dim dao As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION
        dao.GET_DATA_BY_IDA(_IDA)
        'Dim _ProcessID As String = 10701

        Dim XML As New CLASS_GEN_XML.DALCN_PLAN
        LCN_PLAN = XML.Gen_XML_LCN_PLAN(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "บปอ", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_PLAN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF2("PDF", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML2("XML", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
End Class