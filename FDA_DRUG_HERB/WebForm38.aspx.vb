Public Class WebForm38
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub insert_dr_Click(sender As Object, e As EventArgs) Handles insert_dr.Click
        Dim pvncd As String = txt_pvncd.Text
        Dim rgttpcd As String = txt_rgttpcd.Text
        Dim drgtpcd As String = txt_drgtpcd.Text
        Dim rgtno As String = txt_rgtno.Text
        Dim remark As String = txt_why.Text
        Dim iden_edit As String = txt_iden_edit.Text
        Dim system As String = "HERB"

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_INSERT_DR(pvncd, rgttpcd, drgtpcd, rgtno, remark, iden_edit, system)
    End Sub

    Protected Sub update_dr_Click(sender As Object, e As EventArgs) Handles update_dr.Click
        Dim pvncd As String = txt_pvncd.Text
        Dim rgttpcd As String = txt_rgttpcd.Text
        Dim drgtpcd As String = txt_drgtpcd.Text
        Dim rgtno As String = txt_rgtno.Text
        Dim remark As String = txt_why.Text
        Dim iden_edit As String = txt_iden_edit.Text
        Dim system As String = "HERB"

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_UPDATE_DR(pvncd, rgttpcd, drgtpcd, rgtno, remark, iden_edit, system)
    End Sub

    Protected Sub delete_dr_Click(sender As Object, e As EventArgs) Handles delete_dr.Click
        Dim pvncd As String = txt_pvncd.Text
        Dim rgttpcd As String = txt_rgttpcd.Text
        Dim drgtpcd As String = txt_drgtpcd.Text
        Dim rgtno As String = txt_rgtno.Text
        Dim remark As String = txt_why.Text
        Dim iden_edit As String = txt_iden_edit.Text
        Dim system As String = "HERB"

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_DELETE_DR(pvncd, rgttpcd, drgtpcd, rgtno, remark, iden_edit, system)
    End Sub

    Protected Sub insert0_Click(sender As Object, e As EventArgs) Handles insert0.Click
        Dim IDA_DH15 As String = txt_dr15.Text
        Dim iden_edit As String = iden_dh15.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_INSERT_DR15(IDA_DH15, iden_edit)
    End Sub

    Protected Sub update_dh15_Click(sender As Object, e As EventArgs) Handles update_dh15.Click
        Dim IDA_DH15 As String = txt_dr15.Text
        Dim iden_edit As String = iden_dh15.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_UPDATE_DH15(IDA_DH15, iden_edit)
    End Sub

    Protected Sub update_xml_Click(sender As Object, e As EventArgs) Handles update_xml.Click
        Dim newcode As String = txt_newcode_xml_update.Text
        Dim iden_edit As String = txt_iden_update_xml.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.XML_DRUG_BC_UPDATE_TB(newcode, iden_edit)
    End Sub

    Protected Sub insert_xml_BC_Click(sender As Object, e As EventArgs) Handles insert_xml_BC.Click
        Dim newcode As String = txt_insert_xml.Text
        Dim iden_edit As String = txt_iden_insert_xml.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.XML_DRUG_FORMULA(newcode, iden_edit)
    End Sub

    Protected Sub insert_LCN_Click(sender As Object, e As EventArgs) Handles insert_LCN.Click
        Dim IDA As String = txt_IDA_LCN.Text
        Dim iden_edit As String = txt_iden_licen.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_INSERT_LICEN(IDA, iden_edit)
    End Sub

    Protected Sub update_LCN_Click(sender As Object, e As EventArgs) Handles update_LCN.Click
        Dim IDA As String = txt_IDA_LCN.Text
        Dim iden_edit As String = txt_iden_licen.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_UPDATE_LICEN(IDA, iden_edit)
    End Sub

    Protected Sub btn_gen_xml_Click(sender As Object, e As EventArgs) Handles btn_gen_xml.Click
        Dim iden_edit As String = txt_iden_licen.Text

        Dim ws_drug As New WS_HERB.WS_DRUG
        ws_drug.HERB_INSERT_XML_LICEN_ALL(iden_edit)
    End Sub

    Protected Sub BTN_GEN_XML_JJ1_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_JJ1.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_jj.Text
        Dim iden As String = txt_iden_jj.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_JJ.Text
        Dim TR_ID As Integer = txt_tr_id_jj.Text
        Dim DES As String = txt_detail_jj.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_JJ.Text
        Try

            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            Try
                dao.GetdatabyID_IDA_LCN_ID_AND_TR_ID(IDA, TR_ID, LCN_IDA)
            Catch ex As Exception
                dao.GetdatabyID_IDA(IDA)
            End Try
            'dao.GetdatabyID_IDA(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
            TB_JJ = XML.gen_xml(IDA, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(dao.fields.DDHERB, dao.fields.STATUS_ID, "จจ1", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ1\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", dao.fields.DDHERB, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", dao.fields.DDHERB, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, dao.fields.DDHERB, PATH_PDF_OUTPUT)


            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ1.Text
            log.insert()
            alert("SUCCESS")
        Catch ex As Exception
            Dim ex_txt As String = ""
            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ1.Text
            log.fields.log_error = ex_txt
            log.insert()
            ex_txt = ex.Message
            alert("เกิดข้อผิดพลาด")
        End Try

    End Sub

    Protected Sub BTN_GEN_XML_JJ2_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_JJ2.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_jj.Text
        Dim iden As String = txt_iden_jj.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_JJ.Text
        Dim TR_ID As Integer = txt_tr_id_jj.Text
        Dim DES As String = txt_detail_jj.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_JJ.Text
        Try

            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            Try
                dao.GetdatabyID_IDA_LCN_ID_AND_TR_ID(IDA, TR_ID, LCN_IDA)
            Catch ex As Exception
                dao.GetdatabyID_IDA(IDA)
            End Try
            'dao.GetdatabyID_IDA(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
            TB_JJ = XML.gen_xml(IDA, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(dao.fields.DDHERB, dao.fields.STATUS_ID, "จจ2", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ1\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", dao.fields.DDHERB, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", dao.fields.DDHERB, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, dao.fields.DDHERB, PATH_PDF_OUTPUT)


            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ2.Text
            log.insert()
            alert("SUCCESS")
        Catch ex As Exception
            Dim ex_txt As String = ""
            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ2.Text
            log.fields.log_error = ex_txt
            log.insert()
            ex_txt = ex.Message
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Protected Sub btn_gen_xml_pro_Click(sender As Object, e As EventArgs) Handles btn_gen_xml_pro.Click
        Dim iden_edit As String = TXT_IDEN.Text

        Dim ws_drug As New WS_HERB.WS_DRUG
        'Dim ws_drug2 As New WS_HER
        ws_drug.HERB_INSERT_XML_PRODUCT_ALL(iden_edit)
        'ws_drug.
    End Sub

    Protected Sub insert_dr107_Click(sender As Object, e As EventArgs) Handles insert_dr107.Click
        Dim pvncd As String = txt_pvncd.Text
        Dim rgttpcd As String = txt_rgttpcd.Text
        Dim drgtpcd As String = txt_drgtpcd.Text
        Dim rgtno As String = txt_rgtno.Text
        Dim remark As String = txt_why.Text
        Dim iden_edit As String = txt_iden_edit.Text
        Dim system As String = "HERB"

        Dim ws_drug As New WS_HERB.WS_DRUG
        ws_drug.HERB_INSERT_DR(pvncd, rgttpcd, drgtpcd, rgtno, remark, iden_edit, system)
    End Sub
End Class