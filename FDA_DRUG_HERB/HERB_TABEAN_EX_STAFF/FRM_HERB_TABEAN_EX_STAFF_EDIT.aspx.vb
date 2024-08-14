Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_EX_STAFF_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String = ""

    Sub RunSession()

        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        _ProcessID = dao.fields.process_id
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
        End If
        BindTable()
    End Sub
    Public Sub bind_data()
        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        If dao.fields.STATUS_ID = 4 Then
            dao_up_mas.GetdatabyID_TYPE(18)
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
                    dao_up.fields.TYPE = 5
                    dao_up.fields.ACTIVE = 1
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.insert()
                End If
            Next
        ElseIf dao.fields.STATUS_ID = 23 Then
            dao_up_mas.GetdatabyID_TYPE_AND_PROCESS(21, _ProcessID)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_chk As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao_chk.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE(_IDA, _TR_ID, _ProcessID, 6)
                If dao_chk.fields.IDA = 0 Then
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DOCUMENT_NAME = dao_up_mas.fields.DOCUMENT_NAME
                    dao_up.fields.TR_ID = _TR_ID
                    dao_up.fields.PROCESS_ID = _ProcessID
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.FK_IDA = _IDA
                    dao_up.fields.TYPE = 6
                    dao_up.fields.ACTIVE = 1
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.insert()
                End If
            Next
        End If

        If dao.fields.STATUS_ID = 20 Then
            btn_add_upload.Enabled = False
            btn_sumit.Enabled = False
            'RadGrid4.Visible = False
            'RadGrid4.Visible = False
            If dao.fields.EX_EDIT = "3" Then
                CHK_EX1_EDIT.Checked = True
                CHK_UPLOAD_EDIT.Checked = True
                TXT_EDIT_NOTE_EX1.Text = dao.fields.EX_NOTE_EDIT
                DIV_EDIT_UPLOAD1.Visible = True
                DIV_EDIT_UPLOAD2.Visible = True
                DIV_SHOW_TXT_EDIT_EX1.Visible = True
            ElseIf dao.fields.EX_EDIT = "2" Then
                CHK_UPLOAD_EDIT.Checked = True
                TXT_EDIT_NOTE_EX1.Text = dao.fields.EX_NOTE_EDIT
                DIV_EDIT_UPLOAD1.Visible = True
            ElseIf dao.fields.EX_EDIT = "1" Then
                CHK_EX1_EDIT.Checked = True
                dao.fields.EX_NOTE_EDIT = TXT_EDIT_NOTE_EX1.Text
                TXT_EDIT_NOTE_EX1.Text = dao.fields.EX_NOTE_EDIT
                DIV_EDIT_UPLOAD2.Visible = True
                DIV_SHOW_TXT_EDIT_EX1.Visible = True
            End If
            RadGrid3.Rebind()
        ElseIf dao.fields.STATUS_ID = 24 Then
            btn_add_upload.Enabled = False
            btn_sumit.Enabled = False
            If dao.fields.EX_EDIT = "3" Then
                'CHK_EX1_EDIT.Checked = True
                'CHK_UPLOAD_EDIT.Checked = True
                'TXT_EDIT_NOTE_EX1.Text = dao.fields.EX_NOTE_EDIT
                DIV_EDIT_UPLOAD1.Visible = True
                DIV_EDIT_UPLOAD2.Visible = True
                DIV_SHOW_TXT_EDIT_EX1.Visible = True
            ElseIf dao.fields.EX_EDIT = "2" Then
                CHK_UPLOAD_EDIT.Checked = True
                TXT_EDIT_NOTE_EX1.Text = dao.fields.EX_NOTE_EDIT
                DIV_EDIT_UPLOAD1.Visible = True
            ElseIf dao.fields.EX_EDIT = "1" Then
                CHK_EX1_EDIT.Checked = True
                dao.fields.EX_NOTE_EDIT = TXT_EDIT_NOTE_EX1.Text
                TXT_EDIT_NOTE_EX1.Text = dao.fields.EX_NOTE_EDIT
                DIV_EDIT_UPLOAD2.Visible = True
                DIV_SHOW_TXT_EDIT_EX1.Visible = True
            End If
            RadGrid3.Rebind()
        End If
            NOTE_EDIT.Text = dao.fields.EX_NOTE_EDIT
        'If R_NATURE.SelectedValue <> "" Then
        '    R_NATURE.SelectedValue = dao.fields.NATURE_ID_EDIT
        'End If
    End Sub
    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim IDA_UPLOAD As Integer = 0
        Dim NAME_FILE As String = ""

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim status_id As String = dao.fields.STATUS_ID
        For Each item As GridDataItem In RadGrid1.SelectedItems
            IDA_UPLOAD = item("ID").Text
            NAME_FILE = item("DOCUMENT_NAME").Text

            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DOCUMENT_NAME = NAME_FILE
            dao_up.fields.TR_ID = _TR_ID
            dao_up.fields.PROCESS_ID = _ProcessID
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            If status_id = 4 Or status_id = 20 Then dao_up.fields.TYPE = 3 Else dao_up.fields.TYPE = 4
            'dao_up.fields.TYPE = 3
            dao_up.fields.ACTIVE = 1
            dao_up.fields.CREATE_DATE = Date.Now
            dao_up.insert()

        Next

        'dao.fields.EX_NOTE_EDIT = NOTE_EDIT.Text
        If CHK_EX1_EDIT.Checked = True And CHK_UPLOAD_EDIT.Checked = True Then
            dao.fields.EX_EDIT = "3"
            dao.fields.EX_NOTE_EDIT = TXT_EDIT_NOTE_EX1.Text
            dao.fields.EX_NOTE_EDIT_UPLOAD = NOTE_EDIT.Text
        ElseIf CHK_EX1_EDIT.Checked = True Then
            dao.fields.EX_EDIT = "1"
            dao.fields.EX_NOTE_EDIT_UPLOAD = NOTE_EDIT.Text
        ElseIf CHK_UPLOAD_EDIT.Checked = True Then
            dao.fields.EX_EDIT = "2"
            dao.fields.EX_NOTE_EDIT_UPLOAD = NOTE_EDIT.Text
        End If
        If status_id = 23 Then
            dao.fields.STATUS_ID = 24
            dao.fields.staff_edit_time = 2
            dao.fields.staff_edit_rq_date = DateTime.Now
        Else
            dao.fields.STATUS_ID = 20
            dao.fields.staff_edit_time = 1
            dao.fields.staff_edit_rq_date = DateTime.Now
        End If
        dao.update()

        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.insert_transection_jj(dao.fields.process_id, _IDA, dao.fields.STATUS_ID)

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub
    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim status_id As String = dao.fields.STATUS_ID
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
                    'If status_id = 20 Then dao_up.fields.TYPE = 18 Else dao_up.fields.TYPE = 2
                    'dao_up.fields.TYPE = 2
                    dao_up.fields.ACTIVE = 1
                    'Try
                    '    dao_up.fields.TR_ID = ""
                    'Catch ex As Exception

                    'End Try
                    dao_up.fields.PROCESS_ID = DD_HERB_PROCESS
                    dao_up.Update()
                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_EX
                    f.SaveAs(paths & "UPLOAD_PDF_TABEAN_EX\" & Name_fake)
                Else
                    'alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If
        Next
        If check_file() = False Then
            alert_normal("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            alert_normal("แนบไฟล์เรียบร้อยแล้ว กดบันทึก")
        End If

        'alert_normal("แนบไฟล์เรียบร้อยแล้ว")

    End Sub
    Public Sub BindTable()
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        If _TR_ID <> 0 Then

            'dao_up.GetdatabyID_IDA_TYPE(_IDA, 2)
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_IDA)
            Dim status_id As String = dao.fields.STATUS_ID
            Dim TYPE_ID As Integer = 0
            If status_id = 4 Or status_id = 20 Then
                TYPE_ID = 5
            ElseIf status_id = 23 Then
                TYPE_ID = 6
            End If

            dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(_TR_ID, _ProcessID, TYPE_ID)

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
                Try
                    tc.Text = Replace(dao_up.fields.DOCUMENT_NAME, "\n", "<br/>")
                Catch ex As Exception
                    tc.Text = dao_up.fields.DOCUMENT_NAME
                End Try
                tc.Width = 900
                tr.Cells.Add(tc)

                tc = New TableCell
                tc.Text = dao_up.fields.NAME_REAL
                tc.Width = 300
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
    Private Function check_file()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID, _ProcessID, 2)

        Dim ck_file As Boolean = True

        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
            End If
        Next

        Return ck_file
    End Function
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_EX_NO()

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub CHK_TB1_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_EX1_EDIT.CheckedChanged
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        If CHK_EX1_EDIT.Checked = True Then
            DIV_SHOW_TXT_EDIT_EX1.Visible = True
        Else
            DIV_SHOW_TXT_EDIT_EX1.Visible = False
        End If
    End Sub

    Protected Sub CHK_UPLOAD_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_UPLOAD_EDIT.CheckedChanged
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        If CHK_UPLOAD_EDIT.Checked = True Then
            DIV_EDIT_UPLOAD1.Visible = True
            DIV_EDIT_UPLOAD2.Visible = True
            RadGrid1.Rebind()
        Else
            DIV_EDIT_UPLOAD1.Visible = False
            DIV_EDIT_UPLOAD2.Visible = False
        End If
        RadGrid3.Rebind()
    End Sub
    Function bind_data_uploadfile2()
        Dim dt As DataTable
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_EX(_TR_ID, 1, dao.fields.process_id)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_uploadfile2()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_EX/FRM_HERB_TABEAN_EX_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub
End Class