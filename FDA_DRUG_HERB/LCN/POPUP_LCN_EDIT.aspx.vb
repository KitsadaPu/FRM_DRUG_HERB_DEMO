Public Class POPUP_LCN_EDIT
    Inherits System.Web.UI.Page
    Private _type_id As String = ""
    Private _IDA As Integer
    Private _ProcessID As Integer
    Private _pvncd As Integer
    Private _CLS As New CLS_SESSION
    Private _TR_ID As String
    Sub runQuery()
        _type_id = Request.QueryString("type_id")
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("ida")
        _TR_ID = Request.QueryString("TR_ID")

    End Sub
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
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
        BindTable()
        UC_GRID_ATTACH.load_gv(_TR_ID)
        If Not IsPostBack Then
            get_data(_IDA)
            get_label(_IDA)

        End If


    End Sub

    Protected Sub get_label(ByVal IDA As Integer)
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_up.GetDataby_FK_IDA(IDA)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(IDA)
        txt_edit_remark.Text = dao.fields.REMARK_EDIT
    End Sub
    Protected Sub get_data(ByVal IDA As Integer)
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_up.GetDataby_FK_IDA(IDA)

    End Sub

    Protected Sub BTN_CLOSE_Click(sender As Object, e As EventArgs) Handles BTN_CLOSE.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
    Private Sub BindTable()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim tr_id As Integer = 0
        Dim type_id As Integer = 0
        Try
            tr_id = dao.fields.TR_ID
            If dao.fields.STATUS_ID = 12 Then
                type_id = 3
            ElseIf dao.fields.STATUS_ID = 13 Then
                type_id = 5
            End If

        Catch ex As Exception

        End Try
        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        Dim dao_att As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        Dim group As Integer = 0

        dao_f.GetDataby_FK_IDA_AND_TR_ID_AND_TYPE(_IDA, tr_id, type_id)

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
            tc.Width = 700
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

            tc.Width = 50
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
    Protected Sub BTN_UPDATE_EDIT_Click(sender As Object, e As EventArgs) Handles BTN_UPDATE_EDIT.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE

        If dao.fields.STATUS_ID = 12 Then
            'dao_f.GetDataby_FK_IDA_AND_TR_ID_AND_TYPE(_IDA, _TR_ID, 3)
            'For Each dao_f.fields In dao_f.datas
            '    dao_f.fields.TYPE = 4
            '    dao_f.update()
            'Next

            'dao.fields.STATUS_ID = 3
            dao.fields.EDIT_UPLOAD_ID = 1
            dao.fields.STATUS_ID = 17
            dao.update()
        ElseIf dao.fields.STATUS_ID = 13 Then
            'dao_f.GetDataby_FK_IDA_AND_TR_ID_AND_TYPE(_IDA, _TR_ID, 5)
            'For Each dao_f.fields In dao_f.datas
            '    dao_f.fields.TYPE = 6
            '    dao_f.update()
            'Next

            dao.fields.EDIT_UPLOAD_ID = 2
            dao.fields.STATUS_ID = 18
            dao.update()
        End If
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยื่นคำขอแล้ว');parent.close_modal();", True)
    End Sub

    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click
        Dim tr_id As Integer = 0
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        tr_id = dao.fields.TR_ID
        Dim type_id As Integer = 0
        Try
            'tr_id = dao.fields.TR_ID
            If dao.fields.STATUS_ID = 12 Then
                type_id = 3
            ElseIf dao.fields.STATUS_ID = 13 Then
                type_id = 5
            End If

        Catch ex As Exception

        End Try

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
                    'dao_f.fields.TYPE = 4

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