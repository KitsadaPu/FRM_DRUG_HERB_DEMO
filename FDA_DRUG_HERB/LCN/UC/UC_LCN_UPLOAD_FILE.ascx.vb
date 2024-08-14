Imports System.Globalization
Public Class UC_LCN_UPLOAD_FILE
    Inherits System.Web.UI.UserControl
    Private _ProcessID As Integer
    Private _IDA As String
    Private _lcn_ida As String = ""
    Private _staff As String
    Sub runQuery()
        _lcn_ida = Request.QueryString("lcn_ida")
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("ida")
        _staff = Request.QueryString("staff")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        BindTable()
        If Not IsPostBack Then
            set_hide()
        End If
    End Sub

    Sub set_hide()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(_IDA)
        If dao_frgn.fields.PERSONAL_TYPE_MENU = 1 Then
            lbl_person_type2.Style.Add("display", "none")
            lbl_person_type4.Style.Add("display", "none")
            lbl_person_type5.Style.Add("display", "none")

            rdl_person_type2.Style.Add("display", "none")
            rdl_person_type4.Style.Add("display", "none")
            rdl_person_type5.Style.Add("display", "none")
        Else
            lbl_person_type1.Style.Add("display", "none")
            lbl_person_type3.Style.Add("display", "none")

            rdl_person_type1.Style.Add("display", "none")
            rdl_person_type3.Style.Add("display", "none")
        End If

        If dao.fields.TYPE_BSN IsNot Nothing Then
            If dao.fields.TYPE_BSN = 1 Then
                rdl_chk_bsn.SelectedValue = 66
            ElseIf dao.fields.TYPE_BSN = 2 Then
                rdl_chk_bsn.SelectedValue = 77
            End If
        End If

        If dao.fields.TYPE_LOCAL IsNot Nothing Then
            If dao.fields.TYPE_LOCAL = 1 Then
                rdl_chk_local.SelectedValue = 11
            ElseIf dao.fields.TYPE_LOCAL = 2 Then
                rdl_chk_local.SelectedValue = 12
            ElseIf dao.fields.TYPE_LOCAL = 3 Then
                rdl_chk_local.SelectedValue = 10
            End If
        End If
        If dao.fields.TYPE_PERSON IsNot Nothing Then
            show_local_div.Style.Add("display", "block")

            If dao.fields.TYPE_PERSON = 1 Then
                rdl_person_type1.Checked = True
            ElseIf dao.fields.TYPE_PERSON = 2 Then
                rdl_person_type2.Checked = True
            ElseIf dao.fields.TYPE_PERSON = 3 Then
                rdl_person_type3.Checked = True
            ElseIf dao.fields.TYPE_PERSON = 4 Then
                rdl_person_type4.Checked = True
            ElseIf dao.fields.TYPE_PERSON = 5 Then
                rdl_person_type5.Checked = True
            End If
        End If
        If dao.fields.TYPE_PERSON = 3 Or dao.fields.TYPE_PERSON = 4 Or dao.fields.TYPE_PERSON = 5 Then
            show_bsn_div.Style.Add("display", "block")
        End If

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    Sub alert_close(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub BindTable()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim tr_id As Integer = 0
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try

        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        Dim dao_att As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        Dim group As Integer = 0

        dao_f.GetDataby_TR_ID(tr_id)

        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas


            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.DOCUMENT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.DOCUMENT_NAME
            End Try
            tc.Width = 900
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.NAME_REAL
            tc.Width = 100
            tr.Cells.Add(tc)

            tc = New TableCell
            Dim img As New Image
            If dao_f.fields.NAME_REAL Is Nothing OrElse dao_f.fields.NAME_REAL = "" Then
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
            f.ID = "F" & dao_f.fields.IDA
            tc.Controls.Add(f)
            tr.Cells.Add(tc)

            tb_type_menu.Rows.Add(tr)
            rows = rows + 1
        Next
    End Sub

    Protected Sub btn_select_typeatt_Click(sender As Object, e As EventArgs) Handles btn_select_typeatt.Click
        Dim head_id As Integer = 0
        Dim id As Integer = 0
        Dim id2 As Integer = 0
        Dim tr_id As Integer = 0
        Dim type_p As String = ""
        Dim type_b As String = ""
        Dim type_l As String = ""
        Dim process As Integer = 0
        'Dim dao_attgroup As New DAO.tb_attachgroup
        Dim dao_attgroup As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        Dim dao_attgroup2 As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        tr_id = dao.fields.TR_ID

        If rdl_person_type1.Checked = True Then
            head_id = 1
            type_p = "บุคคลธรรมดา"
        ElseIf rdl_person_type2.Checked = True Then
            head_id = 2
            type_p = "บุคคลธรรมดา(สัญชาติอื่นๆ)"
        ElseIf rdl_person_type3.Checked = True Then
            head_id = 3
            type_p = "นิติบุคคล(สัญชาติไทย)"
        ElseIf rdl_person_type4.Checked = True Then
            head_id = 4
            type_p = "นิติบุคคล(สัญชาติอื่นๆ) กรณีจดทะเบียนในไทย"
        ElseIf rdl_person_type5.Checked = True Then
            head_id = 5
            type_p = "นิติบุคคล(สัญชาติอื่นๆ) กรณีไม่จดทะเบียนในไทย"
        End If

        If rdl_chk_local.SelectedValue = "" Then
            id = 0
        ElseIf rdl_chk_local.SelectedValue = 11 Then
            id = 1
            type_l = "กรณีที่ผู้ขอรับอนุญาตไม่ได้เป็นเจ้าของกรรมสิทธิ์"
        ElseIf rdl_chk_local.SelectedValue = 12 Then
            id = 2
            type_l = "กรณีทะเบียนบ้านไม่มีผู้อยู่อาศัย(ทะเบียนบ้านลอย)"
        ElseIf rdl_chk_local.SelectedValue = 10 Then
            id = 3
            type_l = "กรณีที่ผู้ขอรับอนุญาตเป็นเจ้าของกรรมสิทธิ์"
        End If

        If rdl_chk_bsn.SelectedValue = "" Then
            id2 = 0
        ElseIf rdl_chk_bsn.SelectedValue = 66 Then
            id2 = 1
            type_b = "ผู้รับมอบอำนาจ ยื่นเรื่องแทนผู้ดำเนินกิจการสัญชาติไทย"
        ElseIf rdl_chk_bsn.SelectedValue = 77 Then
            id2 = 2
            type_b = "ผู้ได้รับมอบอำนาจ ยื่นเรื่องแทนผู้ดำเนินกิจการที่เป็นบุคคลต่างด้าว"
        End If

        process = dao.fields.PROCESS_ID
        Dim TYPE_ID As Integer
        If process = 122 Then
            TYPE_ID = 2
        Else
            TYPE_ID = 1
        End If

        dao_attgroup.GetDataby_HEAD_ID_AND_TITLE_ID_AND_PROCESS(head_id, id, id2, TYPE_ID)


        'If process = 122 Then
        '    dao_attgroup2.GetDataby_HEAD_ID_AND_TYPE(head_id, process)
        'End If


        ClearTemplate()

        Dim btn As Button = CType(sender, Button)

        For Each dao_attgroup.fields In dao_attgroup.datas
            Dim dao_att As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            Dim dao_mas As New DAO_DRUG.TB_MAS_DOCUMENT_NAME_UPLOAD_DALCN
            dao_mas.GetDataby_ID(dao_attgroup.fields.MAIN_MENU)
            dao_att.fields.DOCUMENT_NAME = dao_mas.fields.DOCUMENT_NAME
            'dao_att.fields.DOCUMENT_NAME = dao_attgroup.fields.DOCUMENT_NAME
            dao_att.fields.TYPE_PERSON = head_id
            dao_att.fields.TYPE_LOCAL = id
            dao_att.fields.TYPE_BSN = id2
            dao_att.fields.TYPE = 1
            dao_att.fields.FK_IDA = _IDA
            dao_att.fields.TR_ID = tr_id
            dao_att.fields.PROCESS_ID = dao.fields.PROCESS_ID
            dao_att.fields.TYPE_PERSON_NAME = type_p
            dao_att.fields.TYPE_LOCAL_NAME = type_l
            dao_att.fields.TYPE_BSN_NAME = type_b
            dao_att.insert()

        Next
        'Try
        '    For Each dao_attgroup2.fields In dao_attgroup2.datas
        '        Dim dao_att As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        '        dao_att.fields.DOCUMENT_NAME = dao_attgroup2.fields.DOCUMENT_NAME
        '        dao_att.fields.TYPE_PERSON = head_id
        '        dao_att.fields.TYPE_LOCAL = id
        '        dao_att.fields.TYPE_BSN = id2
        '        dao_att.fields.TYPE = 1
        '        dao_att.fields.FK_IDA = _IDA
        '        dao_att.fields.TR_ID = tr_id
        '        dao_att.fields.PROCESS_ID = dao.fields.PROCESS_ID
        '        dao_att.fields.TYPE_PERSON_NAME = type_p
        '        dao_att.fields.TYPE_LOCAL_NAME = type_l
        '        dao_att.fields.TYPE_BSN_NAME = type_b
        '        dao_att.insert()

        '    Next
        'Catch ex As Exception

        'End Try


        dao.fields.TYPE_PERSON = head_id
        dao.fields.TYPE_PERSON_NAME = type_p
        dao.fields.TYPE_LOCAL = id
        dao.fields.TYPE_LOCAL_NAME = type_l
        dao.fields.TYPE_BSN = id2
        dao.fields.TYPE_BSN_NAME = type_b
        dao.update()

        Response.Redirect(Request.Url.AbsoluteUri)
        'BindTable()
    End Sub

    Private Sub ClearTemplate()

        Dim dao_att As New DAO_DRUG.TB_DALCN_UPLOAD_FILE


        dao_att.GetDataby_FK_IDA(_IDA)
        For Each dao_att.fields In dao_att.datas
            dao_att.delete()
        Next
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim tr_id As Integer = 0
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        tr_id = dao.fields.TR_ID
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
                    Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    dao_f.GetDataby_IDA(IDA)

                    Dim Name_fake As String = "DA-" & dao.fields.PROCESS_ID & "-" & Date.Now.Year & "-" & tr_id & "-" & dao_f.fields.IDA & ".pdf"
                    dao_f.fields.NAME_FAKE = Name_fake
                    dao_f.fields.NAME_REAL = f.FileName
                    dao_f.fields.CREATE_DATE = Date.Now
                    dao_f.update()

                    Dim paths As String = bao._PATH_DEFAULT
                    f.SaveAs(paths & "upload\" & Name_fake)
                Else
                    alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If

            End If


        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
End Class