Public Class WebForm39
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ2\" & dao_pdftemplate.fields.PDF_TEMPLATE
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

    Public Function insert_LOG_XML(ByVal IDA As Integer, ByVal LCN_IDA As Integer, ByVal PROCESS_ID As Integer, ByVal TR_ID As Integer, ByVal DES As String, ByVal iden As String, ByVal btn_name As String, ByVal mg_error As String) As Integer
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        log.fields.FK_IDA = IDA
        log.fields.IDENTIFY = iden
        log.fields.LCN_IDA = LCN_IDA
        log.fields.TR_ID = TR_ID
        log.fields.PROCESS_ID = PROCESS_ID
        log.fields.DESCRIPTION = DES
        log.fields.SUBMIT_DATE = Date.Now
        log.fields.log_btn = btn_name
        log.fields.log_error = mg_error
        log.insert() 'ปรับเป็น update
        Return log.fields.IDA

    End Function

    Protected Sub BTN_GEN_XML_TBN1_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_TBN1.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_TBN.Text
        Dim iden As String = txt_iden_TBN.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_TBN.Text
        Dim IDA_DQ As Integer = txt_IDA_TBN.Text
        Dim TR_ID As Integer = txt_tr_id_TBN.Text
        Dim DES As String = txt_detail_TBN.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_TBN.Text
        Dim BTN_NAME As String = BTN_GEN_XML_TBN1.Text
        Dim ex_Message As String = ""
        Try
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
            dao_deeqt.GetDataby_IDA(IDA)

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
            TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, IDA_DQ, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(PROCESS_ID, dao_deeqt.fields.STATUS_ID, "ทบ1", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA, dao_deeqt.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA, dao_deeqt.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, btn_name, ex_Message)
        Catch ex As Exception
            ex_Message = ex.Message
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, ex_Message)
            alert("เกิดข้อผิดพลาด")
        End Try

    End Sub

    Protected Sub BTN_GEN_XML_TBN2_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_TBN2.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_TBN.Text
        Dim iden As String = txt_iden_TBN.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_TBN.Text
        Dim IDA_DQ As Integer = txt_IDA_TBN.Text
        Dim TR_ID As Integer = txt_tr_id_TBN.Text
        Dim DES As String = txt_detail_TBN.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_TBN.Text
        Dim BTN_NAME As String = BTN_GEN_XML_TBN2.Text
        Dim ex_Message As String = ""
        Try
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
            TB_JJ = XML.gen_xml_2(IDA, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(PROCESS_ID, dao.fields.STATUS_ID, "จจ2", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)

            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, ex_Message)
        Catch ex As Exception
            ex_Message = ex.Message
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, ex_Message)
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub

    Protected Sub BTN_GEN_XML_JJ2_L_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_JJ2_L.Click
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
            dao.GetdatabyID_IDA(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
            TB_JJ = XML.gen_xml_2(IDA, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(PROCESS_ID, dao.fields.STATUS_ID, "จจ2", 1)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)

            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ2_L.Text
            log.fields.log_error = "SUCCESS"
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

    Protected Sub BTN_GEN_XML_TBN2_L_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_TBN2_L.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_TBN.Text
        Dim iden As String = txt_iden_TBN.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_TBN.Text
        Dim IDA_DQ As Integer = txt_IDA_TBN.Text
        Dim TR_ID As Integer = txt_tr_id_TBN.Text
        Dim DES As String = txt_detail_TBN.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_TBN.Text
        Dim BTN_NAME As String = BTN_GEN_XML_TBN2_L.Text
        Dim ex_Message As String = ""
        Try
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
            dao_deeqt.GetDataby_IDA(IDA_DQ)

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(IDA_DQ)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
            TBN_NEW = XML.gen_xml_tbn_2(dao.fields.IDA, IDA_DQ, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(PROCESS_ID, dao_deeqt.fields.STATUS_ID, "ทบ2", 1)


            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA_DQ, dao_deeqt.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA_DQ, dao_deeqt.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, "SUCCESS")
        Catch ex As Exception
            ex_Message = ex.Message
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, ex_Message)
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub

    Protected Sub BTN_SWPM_CF_Click(sender As Object, e As EventArgs) Handles BTN_SWPM_CF.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = SWPM_IDA.Text
        Dim iden As String = SWPM_IDEN.Text
        Dim PROCESS_ID As Integer = SWPM_PROCESS.Text
        Dim REF01 As String = SWPM_REF01.Text
        Dim REF02 As String = SWPM_REF02.Text
        Dim BTN_NAME As String = BTN_SWPM_CF.Text
        Dim DETAIL As String = SWPM_DETAIL.Text
        Dim sw As New SW_HERB_PAYMENT.SW_LCN_EDIT_PAYMENT
        Dim ex_Message As String = ""
        Try
            sw.HERB_PAYMENT(IDA, PROCESS_ID, REF01, REF02)

            insert_LOG_XML(IDA, 0, PROCESS_ID, 0, DETAIL, iden, BTN_NAME, "SUCCESS")
        Catch ex As Exception
            ex_Message = ex.Message
            insert_LOG_XML(IDA, 0, PROCESS_ID, 0, DETAIL, iden, BTN_NAME, ex_Message)
            alert("เกิดข้อผิดพลาด")
        End Try




    End Sub
End Class