﻿Imports Telerik.Web.UI

Public Class POPUP_HERB_TABEAN_TRANSER_STAFF_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String = ""
    Private _STATUS_ID As String = ""

    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _STATUS_ID = Request.QueryString("STATUS_ID")

        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data()
            Run_Pdf_Tabean_Herb()
        End If
        BindTable()
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
        dao_dq.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_dq.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub
    Public Sub bind_data()
        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        dao_up_mas.GetdatabyID_TYPE(7)
        For Each dao_up_mas.fields In dao_up_mas.datas
            Dim dao_chk As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_chk.GetdatabyID_TR_ID_PROCESS_ID(_TR_ID, _ProcessID)
            If dao_chk.fields.IDA = 0 Then
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao_up.fields.DOCUMENT_NAME = dao_up_mas.fields.DOCUMENT_NAME
                dao_up.fields.TR_ID = _TR_ID
                dao_up.fields.PROCESS_ID = _ProcessID
                dao_up.fields.FK_IDA_LCN = _IDA_LCN
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE = 10
                dao_up.fields.ACTIVE = 1
                dao_up.fields.CREATE_DATE = Date.Now
                dao_up.insert()
            End If
        Next

        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        Try
            If dao.fields.CHK_EDIT_TB1 = "1" Then
                CHK_TB1_EDIT.Checked = True
                DIV_SHOW_TXT_EDIT_TB1.Visible = True
            Else
                DIV_SHOW_TXT_EDIT_TB1.Visible = False
            End If
            NOTE_EDIT.Text = dao.fields.NOTE_EDIT
            TXT_EDIT_NOTE_TB1.Text = dao.fields.NOTE_EDIT_TB1
            If dao.fields.CHK_UPLOAD_TB = "1" Then
                CHK_UPLOAD_EDIT.Checked = True
                DIV_EDIT_UPLOAD1.Visible = True
                DIV_EDIT_UPLOAD2.Visible = True
                RadGrid1.Rebind()
                RadGrid3.Rebind()
            Else
                DIV_EDIT_UPLOAD1.Visible = False
                DIV_EDIT_UPLOAD2.Visible = False
            End If
            If dao.fields.CHK_EDIT_TB1 = "1" Or dao.fields.CHK_UPLOAD_TB = "1" Then
                RadGrid1.Visible = False
                'RadGrid4.Visible = True

                btn_sumit.Enabled = False
                btn_sumit.CssClass = "btn-danger btn-lg"
                btn_add_upload.Enabled = False
                set_show.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim Type_ID As Integer = 0
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(_IDA, _TR_ID, _ProcessID)
        Type_ID = dao_up.fields.TYPE
        If Type_ID = 1 Or Type_ID = 9 Then
            'RadGrid1.Visible = False
            RadGrid4.Visible = False

            ' dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO()
        Else
            RadGrid1.Visible = False
            'RadGrid4.Visible = True

            btn_sumit.Enabled = False
            btn_sumit.CssClass = "btn-danger btn-lg"
            btn_add_upload.Enabled = False
            set_show.Visible = False
        End If

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_TBN_NO()

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim IDA_UPLOAD As Integer = 0
        Dim NAME_FILE As String = ""

        For Each item As GridDataItem In RadGrid1.SelectedItems
            IDA_UPLOAD = item("ID").Text
            NAME_FILE = item("DOCUMENT_NAME").Text

            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DOCUMENT_NAME = NAME_FILE
            dao_up.fields.TR_ID = _TR_ID
            dao_up.fields.PROCESS_ID = _ProcessID
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.TYPE = 10
            dao_up.fields.ACTIVE = 1
            dao_up.fields.CREATE_DATE = Date.Now
            dao_up.insert()

        Next

        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        dao.fields.NOTE_EDIT = NOTE_EDIT.Text
        If CHK_TB1_EDIT.Checked = True Then
            dao.fields.CHK_EDIT_TB1 = "1"
            dao.fields.NOTE_EDIT_TB1 = TXT_EDIT_NOTE_TB1.Text
        Else
            dao.fields.CHK_EDIT_TB1 = "0"
        End If
        If CHK_UPLOAD_EDIT.Checked = True Then
            dao.fields.CHK_UPLOAD_TB = "1"
        Else
            dao.fields.CHK_UPLOAD_TB = "0"
        End If
        Try
            dao.fields.EDIT_RQ_ID = _CLS.CITIZEN_ID
            dao.fields.EDIT_RQ_NAME = _CLS.NAME
            dao.fields.EDIT_RQ_DATE = Date.Now
        Catch ex As Exception

        End Try
        dao.update()

        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.insert_transection_jj(_ProcessID, _IDA, _STATUS_ID)

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub

    Public Sub BindTable()
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        If _TR_ID <> 0 Then

            dao_up.GetdatabyID_IDA_TYPE(_IDA, 9)

            Dim rows As Integer = 1
            For Each dao_up.fields In dao_up.datas
                Dim tr As New TableRow
                tr.CssClass = "rows"
                Dim tc As New TableCell

                tc = New TableCell
                tc.Text = rows
                tr.Cells.Add(tc)

                tc = New TableCell
                tc.Text = dao_up.fields.IDA
                tc.Style.Add("display", "none")
                tr.Cells.Add(tc)

                tc = New TableCell
                tc.Width = 50
                Try
                    tc.Text = Replace(dao_up.fields.DOCUMENT_NAME, "\n", "<br/>")
                Catch ex As Exception
                    tc.Text = dao_up.fields.DOCUMENT_NAME
                End Try
                tc.Width = 900
                tr.Cells.Add(tc)

                tc = New TableCell
                tc.Text = dao_up.fields.NAME_REAL
                tc.Width = 100
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim img As New Image
                If dao_up.fields.NAME_REAL Is Nothing OrElse dao_up.fields.NAME_REAL = "" Then
                    Dim AA As String = "../Images/cancel.png"
                    img.ImageUrl = AA
                    img.Width = 20
                    img.Height = 20
                Else
                    Dim AA As String = "../Images/correct.png"
                    img.ImageUrl = AA
                    img.Width = 20
                    img.Height = 20
                End If
                tc.Controls.Add(img)
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim f As New FileUpload
                f.ID = "F" & dao_up.fields.IDA
                tc.Controls.Add(f)
                tr.Cells.Add(tc)

                tb_type_menu.Rows.Add(tr)
                rows = rows + 1
            Next

        End If

    End Sub

    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click

        Dim TR_ID As Integer = _TR_ID
        Dim DD_HERB_PROCESS As String = _ProcessID

        For Each tr As TableRow In tb_type_menu.Rows
            Dim IDA As Integer = tr.Cells(1).Text

            Dim f As New FileUpload
            f = tr.FindControl("F" & IDA)
            If f.HasFile Then
                Dim name_real As String = f.FileName
                Dim Array_NAME_REAL() As String = Split(name_real, ".")
                Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                If exten.ToUpper = "PDF" Then
                    Dim bao As New BAO.AppSettings
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    Dim Name_fake As String = "HB-" & DD_HERB_PROCESS & "-" & Date.Now.Year & "-" & TR_ID & "-" & IDA & ".pdf"

                    dao_up.GetdatabyID_IDA(IDA)

                    dao_up.fields.NAME_FAKE = Name_fake
                    dao_up.fields.NAME_REAL = f.FileName
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.FK_IDA = _IDA
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.ACTIVE = 1

                    Try
                        dao_up.fields.TR_ID = ""
                    Catch ex As Exception

                    End Try

                    dao_up.fields.PROCESS_ID = DD_HERB_PROCESS

                    dao_up.Update()

                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_TBN
                    f.SaveAs(paths & "UPLOAD_PDF_TABEAN_TBN\" & Name_fake)
                Else
                    'alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If

            End If

        Next

        If check_file() = False Then
            'alert_normal("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            alert_normal("แนบไฟล์เรียบร้อยแล้ว กดบันทึก")
        End If

        'alert_normal("แนบไฟล์เรียบร้อยแล้ว")

    End Sub

    Private Function check_file()

        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        'dao.GetdatabyID_IDA_PROCESS(_IDA, _ProcessID)
        'Dim TR_ID_JJ As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(_TR_ID, _ProcessID, 9)

        Dim ck_file As Boolean = True

        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
            End If
        Next

        Return ck_file
    End Function

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub CHK_TB1_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_TB1_EDIT.CheckedChanged
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        If CHK_TB1_EDIT.Checked = True Then
            DIV_SHOW_TXT_EDIT_TB1.Visible = True
        Else
            DIV_SHOW_TXT_EDIT_TB1.Visible = False
        End If
    End Sub

    Protected Sub CHK_UPLOAD_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_UPLOAD_EDIT.CheckedChanged
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        If CHK_UPLOAD_EDIT.Checked = True Then
            DIV_EDIT_UPLOAD1.Visible = True
            DIV_EDIT_UPLOAD2.Visible = True
            RadGrid1.Rebind()
            RadGrid3.Rebind()
        Else
            DIV_EDIT_UPLOAD1.Visible = False
            DIV_EDIT_UPLOAD2.Visible = False
        End If
    End Sub
    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 9, _ProcessID, _IDA)

        Return dt
    End Function
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile_edit()
    End Sub
    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_ST")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub
    Function bind_data_uploadfile_7()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_deeqt.fields.TR_ID, 7, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_uploadfile_7()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub
    Function bind_data_uploadfile_4()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim Type_ID As Integer = 0

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim dao_tbn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tbn.GetdatabyID_FK_IDA_DQ(_IDA)
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(_IDA, _TR_ID, _ProcessID)
        Type_ID = dao_up.fields.TYPE
        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA_LCN(_TR_ID, 10, _ProcessID, dao_tbn.fields.LCN_ID)
        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_4()
    End Sub

End Class