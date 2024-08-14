Public Class POPUP_TABEAN_JJ_EDIT_REQUEST2
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As String = ""
    Private _IDA_JJ As String = ""
    Private _PROCESS_ID As String = ""
    Private _IDA As String = ""
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

        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_JJ = Request.QueryString("IDA_JJ")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then
            Get_Data()
            UC_PACKING_SIZE.bind_dd_pack_1()
            UC_PACKING_SIZE.bind_dd_pack_2()
            UC_PACKING_SIZE.bind_dd_pack_3()
            UC_PACKING_SIZE.bind_dd_unit_1()
            UC_PACKING_SIZE.bind_dd_unit_2()
            UC_PACKING_SIZE.bind_dd_unit_3()
        End If
    End Sub
    Sub Get_Data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        NOTE_EDIT.Text = dao.fields.NOTE_EDIT
        If dao.fields.EDIT_RQ_ID = 1 Then
            UC_EDIT_NAME_PRODUCT.SET_SHOW()
        ElseIf dao.fields.EDIT_RQ_ID = 2 Then
            'UC_ADDRESS_PRODUTION_SITE.SET_SHOW()
        ElseIf dao.fields.EDIT_RQ_ID = 3 Then
            UC_PACKING_SIZE.SET_SHOW()
        ElseIf dao.fields.EDIT_RQ_ID = 4 Then
            'UC_LABELS_ANDDUCQUMENT.SET_SHOW()
        End If

        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(_IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If dao_cb.fields.NAME_PRODUCK_1 = 1 Or dao_cb.fields.NAME_PRODUCK_2 = 1 Or dao_cb.fields.NAME_PRODUCK_3 = 1 Or dao_cb.fields.NAME_PRODUCK_4 = 1 Then
                UC_EDIT_NAME_PRODUCT.SET_SHOW()
            End If
            If dao_cb.fields.NAME_ADDR1 = 1 Or dao_cb.fields.NAME_ADDR2 = 1 Or dao_cb.fields.NAME_ADDR3 = 1 Then
                UC_ADDRESS_PRODUTION_SITE.SET_SHOW()
            End If
            If dao_cb.fields.Size_Packet = 1 Then
                UC_PACKING_SIZE.SET_SHOW()
            End If
            If dao_cb.fields.Label_And_Ducumant = 1 Then
                'UC_LABELS_ANDDUCQUMENT.SET_SHOW()
            End If
        End If
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(_IDA_JJ)
        Try
            Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
            dao_cb.GetdatabyID_FK_IDA(_IDA)
            If dao_cb.fields.IDA <> 0 Then
                'dao_cb.fields.FK_IDA = IDA
                If dao_cb.fields.NAME_PRODUCK_1 = 1 Or dao_cb.fields.NAME_PRODUCK_2 = 1 Or dao_cb.fields.NAME_PRODUCK_3 = 1 Or dao_cb.fields.NAME_PRODUCK_4 = 1 Then
                    UC_EDIT_NAME_PRODUCT.Update_data(dao.fields.IDA)
                End If
                If dao_cb.fields.NAME_ADDR1 = 1 Or dao_cb.fields.NAME_ADDR2 = 1 Or dao_cb.fields.NAME_ADDR3 = 1 Then
                    UC_ADDRESS_PRODUTION_SITE.Update_data(dao.fields.IDA)
                End If
                If dao_cb.fields.Size_Packet = 1 Then
                    UC_PACKING_SIZE.Update_data(dao.fields.IDA)
                End If
                If dao_cb.fields.Label_And_Ducumant = 1 Then
                    'UC_LABELS_ANDDUCQUMENT.Update_Data(dao.fields.IDA)
                End If
            End If

            Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Public Sub BindTable()
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        If _TR_ID <> 0 Then
            dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(_TR_ID, _PROCESS_ID, 2)

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
                tc.Width = 100
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim f As New HyperLink
                f.Text = "ดูข้อมูลเอกสารแนบ"
                f.Target = "_blank"
                f.Style.Add("color", "#0033CC")
                f.NavigateUrl = "FRM_HERB_TABEAN_JJ_EDIT_PREVIEW.aspx?ida=" & dao_up.fields.IDA
                tc.Controls.Add(f)
                tr.Cells.Add(tc)

                tb_UpLoadStaff.Rows.Add(tr)
                rows = rows + 1
            Next

        End If

    End Sub
End Class