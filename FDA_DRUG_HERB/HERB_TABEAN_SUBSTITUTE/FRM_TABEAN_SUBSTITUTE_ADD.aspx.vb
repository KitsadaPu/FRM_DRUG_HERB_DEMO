Public Class FRM_TABEAN_SUBSTITUTE_ADD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_DR As String = ""
    Private _TR_ID_DR As String = ""
    Private _PROCESS_ID_DR As String = ""
    Private _PROCESS_ID As String = ""
    Private _PROCESS_TYPE_ID As String = ""
    Private _TR_ID As String = ""

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
        _IDA_DR = Request.QueryString("IDA_DR")
        _TR_ID_DR = Request.QueryString("TR_ID_DR")
        _PROCESS_ID_DR = Request.QueryString("PROCESS_ID_DR")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _PROCESS_TYPE_ID = Request.QueryString("PROCESS_TYPE_ID")
        _TR_ID = Request.QueryString("TR_ID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data_dr()

            UC_ATTACH1.NAME = "1.สำเนาใบรับแจ้งความ"
            UC_ATTACH1.BindData("1.สำเนาใบรับแจ้งความ", 1, "pdf", "0", "4")
            UC_ATTACH2.NAME = "3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร"
            UC_ATTACH2.BindData("3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร", 1, "pdf", "0", "4")
            UC_ATTACH3.NAME = "2.ใบสำคัญการขึ้นทะเบียนตำรับยาที่ถูกทำลาย"
            UC_ATTACH3.BindData("2.ใบสำคัญการขึ้นทะเบียนตำรับยาที่ถูกทำลาย", 1, "pdf", "0", "5")
            UC_ATTACH4.NAME = "3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร"
            UC_ATTACH4.BindData("3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร", 1, "pdf", "0", "5")

            set_pn(0)

        End If
    End Sub

    Private Sub set_pn(ByVal pn_status As Integer)
        pn_att1.Visible = False
        pn_att2.Visible = False

        If pn_status = 4 Then
            pn_att1.Visible = True
        ElseIf pn_status = 5 Then
            pn_att2.Visible = True
        End If
    End Sub

    Public Sub bind_data_dr()
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_IDA_DR)

        If _PROCESS_TYPE_ID = 20810 Then
            lbl_type.Text = "คำขอใบแทนใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร"
        ElseIf _PROCESS_TYPE_ID = 20820 Then
            lbl_type.Text = "คำขอใบแทนใบรับแจ้งรายละเอียดผลิตภัณฑ์สมุนไพร"
        ElseIf _PROCESS_TYPE_ID = 20830 Then
            lbl_type.Text = "คำขอใบแทนใบรับจดแจ้งผลิตภัณฑ์สมุนไพร"
        Else
            lbl_type.Text = ""
        End If

        lbl_name_thai.Text = dao.fields.thadrgnm
        lbl_name_eng.Text = dao.fields.engdrgnm

    End Sub

    Private Sub ddl_reason_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_reason.SelectedIndexChanged

        If ddl_reason.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เหตุผลการขอ');", True)
        Else
            Dim sl As Integer = ddl_reason.SelectedValue

            set_pn(sl)
        End If
    End Sub

    'Public Sub set_txt_label()
    '    UC_ATTACH1.get_label("1.สำเนาใบรับแจ้งความ")
    '    UC_ATTACH1.get_label("3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร")
    '    UC_ATTACH3.get_label("2.ใบสำคัญการขึ้นทะเบียนตำรับยาที่ถูกทำลาย")
    '    UC_ATTACH4.get_label("3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร")
    'End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim sl As Integer = ddl_reason.SelectedValue

        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_IDA_DR)

        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE

        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        TR_ID = bao_tran.insert_transection(_PROCESS_TYPE_ID)

        dao_sub.fields.TR_ID = TR_ID
        dao_sub.fields.FK_IDA = _IDA_DR
        dao_sub.fields.STATUS_ID = 1
        dao_sub.fields.IDENTIFY = dao.fields.IDENTIFY '_CLS.CITIZEN_ID_AUTHORIZE
        dao_sub.fields.CTZNO = _CLS.CITIZEN_ID
        dao_sub.fields.PROCESS_ID = _PROCESS_TYPE_ID
        dao_sub.fields.pvncd = dao.fields.pvncd
        dao_sub.fields.rgttpcd = dao.fields.rgttpcd
        dao_sub.fields.drgtpcd = dao.fields.drgtpcd
        dao_sub.fields.pvnabbr = dao.fields.pvnabbr
        dao_sub.fields.lcntpcd = dao.fields.lcntpcd
        dao_sub.fields.lcnsid = dao.fields.lcnsid
        dao_sub.fields.FK_LCN_IDA = dao.fields.FK_LCN_IDA

        dao_sub.fields.DRRDT_SUB_NOTE = txt_remark.Text
        dao_sub.fields.DRRGT_REASON_ID = ddl_reason.SelectedValue
        dao_sub.fields.DRRGT_REASON_NAME = ddl_reason.SelectedItem.Text
        dao_sub.fields.PROCESS_TYPE_ID = _PROCESS_TYPE_ID
        dao_sub.fields.DATE_YEAR = con_year(Date.Now.Year)
        dao_sub.fields.CREATE_DATE = Date.Now
        dao_sub.fields.CREATE_BY = _CLS.THANM

        dao_sub.insert()

        If sl = 4 Then
            UC_ATTACH1.insert_TB(TR_ID, _PROCESS_TYPE_ID, _IDA_DR, 1)
            UC_ATTACH2.insert_TB(TR_ID, _PROCESS_TYPE_ID, _IDA_DR, 2)
        ElseIf sl = 5 Then
            UC_ATTACH3.insert_TB(TR_ID, _PROCESS_TYPE_ID, _IDA_DR, 3)
            UC_ATTACH4.insert_TB(TR_ID, _PROCESS_TYPE_ID, _IDA_DR, 4)
        End If

        alert_nature("บันทึกข้อมูล และ อัพโหลดเอกสารเรียบร้อย", dao_sub.fields.TR_ID, dao_sub.fields.DRRGT_REASON_ID)
        Run_Pdf_Tabean_Herb_1()
    End Sub

    Public Sub Run_Pdf_Tabean_Herb_1()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDataby_FK_IDA(_IDA_DR)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TB
        TB_DRRGT_SUBSTITUTE = XML.gen_xml_tb(dao.fields.IDA, _IDA_DR)

        Dim lcntype As String = "บท"

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TB_TEMPLAETE1(_PROCESS_TYPE_ID, dao.fields.STATUS_ID, lcntype, 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TB") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TB_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TB("HB_PDF", _PROCESS_TYPE_ID, con_year(Date.Now.Year), dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TB("HB_XML", _PROCESS_TYPE_ID, con_year(Date.Now.Year), dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_TYPE_ID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("FRM_TABEAN_SUBSTITUTE_SUB_DR.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_DR=" & _IDA_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID)
    End Sub

    Sub alert_nature(ByVal text As String, ByVal _TR_ID As Integer, ByVal _DRRGT_REASON_ID As Integer)
        Dim url As String = ""
        url = "FRM_TABEAN_SUBSTITUTE_CONFIRM.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_DR=" & _IDA_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&TR_ID=" & _TR_ID & "&DRRGT_REASON_ID=" & _DRRGT_REASON_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
End Class