Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class POPUP_HERB_TABEAN_TRANSFER_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_Q As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String
    Private _TR_ID_LCN As String
    Private _IDA_LCT As String
    Private _IDA_TABEAN_HERB As String
    Private _PROCESS_ID_LCN As String
    Private _MENU_GROUP As String
    Private _STAFF_ID As String

    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID_DQ")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_Q = Request.QueryString("IDA_DR")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _IDA_TABEAN_HERB = Request.QueryString("IDA_TABEAN_HERB")
        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _STAFF_ID = Request.QueryString("staff")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

            GEN_Pdf_Tabean_Herb_new()
            set_btn()
            set_txt()
            set_show_data()
            'Run_Pdf_Tabean_Herb()
        End If
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_Q)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_Q, dao_deeqt.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Public Sub GEN_Pdf_Tabean_Herb_new()
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_Q)
        _ProcessID = dao_deeqt.fields.PROCESS_ID
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA_Q)
        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA_Q, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_Q, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_Q, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Public Sub set_txt()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA_Q)
        Try
            txt_date_confirm.Text = Date.Now.ToString("dd/MM/yyyy")
            txt_ref_no.Text = dao.fields.REF_NO
            If dao.fields.STATUS_ID <> 1 Then
                txt_ref_no.ReadOnly = True
            Else
                txt_ref_no.ReadOnly = False
            End If
        Catch ex As Exception

        End Try


    End Sub
    Public Sub set_show_data()
        Try
            If _STAFF_ID = "1" Then
                set_show.Visible = True
            Else
                set_show.Visible = False
            End If

            If _STAFF_ID = 1 Then
                'Dim message As String = "หากมีเลขรับเก่า กรุณากรอกเลขรับก่อนกดยืนยัน"
                'ClientScript.RegisterOnSubmitStatement(Me.GetType(), "confirm", "return confirm('" & message & "');")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub set_btn()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA_Q)
        If dao.fields.STATUS_ID = 1 Then
            btn_cancle_request.Visible = True
            btn_cancel.Visible = False
        Else
            btn_cancle_request.Visible = False
            btn_cancel.Visible = True
        End If

        If dao.fields.STATUS_ID = 77 Or dao.fields.STATUS_ID = 78 Or dao.fields.STATUS_ID = 79 Or dao.fields.STATUS_ID = 7 _
            Or dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 10 Or dao.fields.STATUS_ID = 14 Or dao.fields.STATUS_ID = 17 _
            Or dao.fields.STATUS_ID = 75 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
            btn_cancle_request.Enabled = False
            btn_cancle_request.CssClass = "btn-danger btn-lg"
        End If

        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_edit.Enabled = False
            btn_edit.CssClass = "btn-danger btn-lg"
        ElseIf dao.fields.STATUS_ID = 8 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
            'btn_load.CssClass = "btn-danger btn-lg"
        End If
    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        If _STAFF_ID = "1" Then
            Dim message As String = "หากมีเลขรับเก่า กรุณากรอกเลขรับก่อนกดยืนยัน"
            ClientScript.RegisterOnSubmitStatement(Me.GetType(), "confirm", "return confirm('" & message & "');")
        End If
        If txt_ref_no.Text <> "" Then
            Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
            dao_deeqt.GetDataby_IDA(_IDA_Q)
            Dim dao_t As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao_t.GetdatabyID_FK_IDA_DQ(_IDA_Q)
            Dim dao_ts As New DAO_TABEAN_HERB.TB_TABEAN_TRANSFER
            dao_ts.GetdatabyID_IDA(_IDA)
            dao_t.fields.REF_NO = txt_ref_no.Text
            dao_t.fields.DATE_CONFIRM = Date.Now

            Dim RCVNO As Integer
            Dim bao_gen As New BAO.GenNumber
            If txt_rcvno_old.Text = "" Then
                RCVNO = bao_gen.GEN_NO_TBN(con_year(Date.Now.Year), dao_deeqt.fields.pvncd, 1, _IDA_Q, dao_deeqt.fields.FK_LCN_IDA)
                Dim DATE_YEAR As String = con_year(Date.Now.Year).Substring(2, 2)
                'Dim RCVNO_FULL As String = "HB" & " " & dao_deeqt.fields.pvncd & "-" & dao_deeqt.fields.PROCESS_ID & "-" & DATE_YEAR & "-" & RCVNO
                Dim RCVNO_FULL As String = "HB" & " " & 10 & "-" & dao_deeqt.fields.PROCESS_ID & "-" & DATE_YEAR & "-" & RCVNO
                dao_deeqt.fields.RCVNO_NEW = RCVNO_FULL
                dao_ts.fields.RCVNO_NEW = RCVNO_FULL
            End If

            Try
                If _STAFF_ID = 1 Then
                    dao_deeqt.fields.RCVNO_OLD = txt_rcvno_old.Text
                    dao_deeqt.fields.DATE_CONFIRM = txt_date_confirm.Text
                    dao_t.fields.DATE_CONFIRM = txt_date_confirm.Text

                    'Dim message As String = "Do you want to submit?"
                    'ClientScript.RegisterOnSubmitStatement(Me.GetType(), "confirm", "return confirm('" & message & "');")
                End If
            Catch ex As Exception

            End Try

            dao_t.fields.STATUS_ID = 3
            ''dao.fields.STATUS_ID = 2
            dao_t.Update()

            dao_deeqt.fields.STATUS_ID = 3
            ''dao_q.fields.STATUS_ID = 2
            dao_deeqt.update()

            dao_ts.fields.STATUS_ID = 3
            dao_ts.Update()

            GEN_Pdf_Tabean_Herb_new()
            'Response.Redirect("POPUP_CONFIRM_CLICK.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA=" & _IDA)
            alert("ยื่นคำขอแล้ว")
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขหนังสือมอบอำนาจ');", True)
        End If
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_Q)
        dao_deeqt.fields.STATUS_ID = 78
        dao_deeqt.update()

        Dim dao_t As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_t.GetdatabyID_FK_IDA_DQ(_IDA_Q)
        dao_t.fields.STATUS_ID = 78
        dao_t.Update()

        Dim dao_ts As New DAO_TABEAN_HERB.TB_TABEAN_TRANSFER
        dao_ts.GetdatabyID_IDA(_IDA)
        dao_ts.fields.STATUS_ID = 78
        dao_ts.Update()

        GEN_Pdf_Tabean_Herb_new()
        alert("ยกเลิกคำขอแล้ว")
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Response.Redirect("FRM_HERB_TABEAN_EDIT_REQUEST.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_DQ=" & _ProcessID & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA)
    End Sub

    Protected Sub btn_cancle_request_Click(sender As Object, e As EventArgs) Handles btn_cancle_request.Click
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_Q)
        dao_deeqt.fields.STATUS_ID = 75
        dao_deeqt.update()

        Dim dao_t As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_t.GetdatabyID_FK_IDA_DQ(_IDA_Q)
        dao_t.fields.STATUS_ID = 75
        dao_t.Update()

        Dim dao_ts As New DAO_TABEAN_HERB.TB_TABEAN_TRANSFER
        dao_ts.GetdatabyID_IDA(_IDA)
        dao_ts.fields.STATUS_ID = 75
        dao_ts.Update()

        GEN_Pdf_Tabean_Herb_new()
        alert("ยกเลิกคำขอแล้ว")
    End Sub
End Class