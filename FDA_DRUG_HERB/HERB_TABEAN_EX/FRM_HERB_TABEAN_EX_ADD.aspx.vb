Public Class FRM_HERB_TABEAN_EX_ADD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
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

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data()

            UC_ATTACH1.NAME = "1.ฉลากทุกขนาดบรรจุ"
            UC_ATTACH1.BindData("1.ฉลากทุกขนาดบรรจุ", 1, "pdf", "0", "15")
            UC_ATTACH2.NAME = "2.เอกสารกำกับผลิตภัณฑ์ (ถ้ามี)"
            UC_ATTACH2.BindData("2.เอกสารกำกับผลิตภัณฑ์ (ถ้ามี)", 1, "pdf", "0", "16")

        End If
    End Sub

    Public Sub bind_data()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim PROCESS_ID_LCN As String = dao_lcn.fields.PROCESS_ID
        Dim sys_p As String = dao_lcn.fields.syslcnsnm_prefixnm
        Dim sys_n As String = dao_lcn.fields.syslcnsnm_thanm
        Dim sys_l As String = dao_lcn.fields.syslcnsnm_thalnm

        'Dim dao_lcnaddr As New DAO_DRUG.ClsDBdalcnaddr
        'dao_lcnaddr.GetDataby_FK_IDA(_IDA_LCN)

        'Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        'dao_cpn.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)

        Dim dao_cpnaddr As New DAO_CPN.clsDBsyslctaddr
        dao_cpnaddr.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)
        Dim cpnaddr_th As String = dao_cpnaddr.fields.thmblnm
        Dim cpnaddr_am As String = dao_cpnaddr.fields.amphrnm
        Dim cpnaddr_ch As String = dao_cpnaddr.fields.chngwtnm
        Dim cpnaddr_zi As String = dao_cpnaddr.fields.zipcode

        TextBox1.Text = _CLS.THANM
        TextBox2.Text = dao_lcn.fields.BSN_THAIFULLNAME
        TextBox3.Text = sys_p + " " + sys_l + " " + sys_l
        DD_CATEGORY_ID.SelectedValue = PROCESS_ID_LCN
        DD_CATEGORY_ID_SUB.SelectedValue = PROCESS_ID_LCN
        TextBox4.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
        TextBox5.Text = dao_lcn.fields.thanm

        'TextBox6.Text = dao_lcnaddr.fields.number_addr
        'TextBox7.Text = dao_lcnaddr.fields.moo
        'TextBox8.Text = dao_lcnaddr.fields.soi
        'TextBox9.Text = dao_lcnaddr.fields.road
        TextBox10.Text = cpnaddr_th
        TextBox11.Text = cpnaddr_am
        TextBox12.Text = cpnaddr_ch + " " + cpnaddr_zi
        TextBox13.Text = dao_lcn.fields.tel

    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        'UC_ATTACH1.insert_TB(TR_ID, _PROCESS_TYPE_ID, _IDA_DR, 1)
        'UC_ATTACH2.insert_TB(TR_ID, _PROCESS_TYPE_ID, _IDA_DR, 2)
        'alert_nature("บันทึกข้อมูล และ อัพโหลดเอกสารเรียบร้อย", dao_sub.fields.TR_ID, dao_sub.fields.DRRGT_REASON_ID)

        ''เก็บสะถานนะทั้ง ระบบไว้
        'Dim TR_ID As String = ""
        'Dim bao_tran As New BAO_TRANSECTION
        'bao_tran.insert_transection_jj(_PROCESS_JJ, dao.fields.IDA, dao.fields.STATUS_ID)
        ''เลขดำเนินการ รันใหม่
        'Dim bao_gen As New BAO.GenNumber
        'TR_ID = bao_gen.GEN_NO_JJ(con_year(Date.Now.Year), dao.fields.PVNCD, _PROCESS_JJ, _IDA, _IDA_LCN)
        'dao.fields.TR_ID_JJ = TR_ID
        'dao.Update()

        'Dim TR_ID As String = dao.fields.TR_ID_JJ
        'Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
        'Dim RCVNO_FULL As String = "HB" & " " & dao.fields.PVNCD & "-" & _PROCESS_JJ & "-" & DATE_YEAR & "-" & TR_ID

        'dao.fields.RCVNO_FULL = RCVNO_FULL

        Run_Pdf_Tabean_Ex_Herb_1()
    End Sub

    Public Sub Run_Pdf_Tabean_Ex_Herb_1()
        'Dim bao_app As New BAO.AppSettings
        'bao_app.RunAppSettings()

        'Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        'dao.GetDataby_FK_IDA(_IDA_DR)

        'Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TB
        'TB_DRRGT_SUBSTITUTE = XML.gen_xml_tb(dao.fields.IDA, _IDA_DR)

        'Dim lcntype As String = "บท"

        'Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GETDATA_TABEAN_HERB_TB_TEMPLAETE1(_PROCESS_TYPE_ID, dao.fields.STATUS_ID, lcntype, 0)

        'Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TB") 'path
        'Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TB_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TB("HB_PDF", _PROCESS_TYPE_ID, con_year(Date.Now.Year), dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)
        'Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TB("HB_XML", _PROCESS_TYPE_ID, con_year(Date.Now.Year), dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)

        'LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_TYPE_ID, PATH_PDF_OUTPUT)

        '_CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        '_CLS.PDFNAME = PATH_PDF_OUTPUT
        '_CLS.FILENAME_XML = Path_XML
        Response.Redirect("FRM_HERB_TABEAN_EX_CONFIRM.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
    End Sub

    Sub alert_nature(ByVal text As String, ByVal _TR_ID As Integer, ByVal _DRRGT_REASON_ID As Integer)
        Dim url As String = ""
        'url = "FRM_TABEAN_SUBSTITUTE_CONFIRM.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_DR=" & _IDA_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&TR_ID=" & _TR_ID & "&DRRGT_REASON_ID=" & _DRRGT_REASON_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("FRM_HERB_TABEAN_EX.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
    End Sub

End Class