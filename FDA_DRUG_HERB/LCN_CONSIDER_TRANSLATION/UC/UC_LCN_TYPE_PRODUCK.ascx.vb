Public Class UC_LCN_TYPE_PRODUCK
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub bind_head()
        Dim dc1 As New TableCell
        Dim dc2 As New TableCell
        Dim dc3 As New TableCell
        Dim dc4 As New TableCell
        Dim dc5 As New TableCell
        Dim dc6 As New TableCell
        Dim dr As New TableRow
        dc1.BorderStyle = BorderStyle.Solid
        dc1.BorderWidth = 1
        dc1.Width = 20
        dc2.BorderStyle = BorderStyle.Solid
        dc2.BorderWidth = 1
        dc2.Width = 300
        dc3.BorderStyle = BorderStyle.Solid
        dc3.BorderWidth = 1
        dc3.HorizontalAlign = HorizontalAlign.Center
        dc4.BorderStyle = BorderStyle.Solid
        dc4.BorderWidth = 1
        dc4.HorizontalAlign = HorizontalAlign.Center
        dc5.BorderStyle = BorderStyle.Solid
        dc5.BorderWidth = 1
        dc5.HorizontalAlign = HorizontalAlign.Center
        dc6.BorderStyle = BorderStyle.Solid
        dc6.BorderWidth = 1
        dc6.HorizontalAlign = HorizontalAlign.Center
        dc1.Text = "ลำดับ"
        dc2.Text = "รูปแบบ"
        dc3.Text = "dosage form"
        dc4.Text = "ยาแผนไทย/ ยาตามองค์ความรู้การแพทย์ทางเลือก"
        dc5.Text = "ยาพัฒนาจากสมุนไพร"
        dc6.Text = "ผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ"
        dc2.Style.Add("font-weight", "bold")
        dc3.Style.Add("font-weight", "bold")
        dc4.Style.Add("font-weight", "bold")
        dc5.Style.Add("font-weight", "bold")
        dc6.Style.Add("font-weight", "bold")
        dr.Cells.Add(dc1)
        dr.Cells.Add(dc2)
        dr.Cells.Add(dc3)
        dr.Cells.Add(dc4)
        dr.Cells.Add(dc5)
        dr.Cells.Add(dc6)
        tb_type_menu.Rows.Add(dr)
    End Sub
    Sub bind_head2()
        Dim dc1 As New TableCell
        Dim dc2 As New TableCell
        Dim dc3 As New TableCell
        Dim dc4 As New TableCell
        Dim dc5 As New TableCell
        Dim dc6 As New TableCell
        Dim dr As New TableRow
        dc1.BorderStyle = BorderStyle.Solid
        dc1.BorderWidth = 1
        dc1.Width = 20
        dc2.BorderStyle = BorderStyle.Solid
        dc2.BorderWidth = 1
        dc2.Width = 300
        dc3.BorderStyle = BorderStyle.Solid
        dc3.BorderWidth = 1
        dc3.HorizontalAlign = HorizontalAlign.Center
        dc4.BorderStyle = BorderStyle.Solid
        dc4.BorderWidth = 1
        dc4.HorizontalAlign = HorizontalAlign.Center
        dc5.BorderStyle = BorderStyle.Solid
        dc5.BorderWidth = 1
        dc5.HorizontalAlign = HorizontalAlign.Center
        dc6.BorderStyle = BorderStyle.Solid
        dc6.BorderWidth = 1
        dc6.HorizontalAlign = HorizontalAlign.Center
        dc1.Text = "ลำดับ"
        dc2.Text = "รูปแบบ"
        dc3.Text = "dosage form"
        dc4.Text = "ยาแผนไทย/ ยาตามองค์ความรู้การแพทย์ทางเลือก"
        dc5.Text = "ยาพัฒนาจากสมุนไพร"
        dc6.Text = "ผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ"
        dc2.Style.Add("font-weight", "bold")
        dc3.Style.Add("font-weight", "bold")
        dc4.Style.Add("font-weight", "bold")
        dc5.Style.Add("font-weight", "bold")
        dc6.Style.Add("font-weight", "bold")
        dr.Cells.Add(dc1)
        dr.Cells.Add(dc2)
        dr.Cells.Add(dc3)
        dr.Cells.Add(dc4)
        dr.Cells.Add(dc5)
        dr.Cells.Add(dc6)
        tb_type_menu2.Rows.Add(dr)
    End Sub
    Sub bind_head3()
        Dim dc1 As New TableCell
        Dim dc2 As New TableCell
        Dim dc3 As New TableCell
        Dim dc4 As New TableCell
        Dim dc5 As New TableCell
        Dim dc6 As New TableCell
        Dim dr As New TableRow
        dc1.BorderStyle = BorderStyle.Solid
        dc1.BorderWidth = 1
        dc1.Width = 20
        dc2.BorderStyle = BorderStyle.Solid
        dc2.BorderWidth = 1
        dc2.Width = 300
        dc3.BorderStyle = BorderStyle.Solid
        dc3.BorderWidth = 1
        dc3.HorizontalAlign = HorizontalAlign.Center
        dc4.BorderStyle = BorderStyle.Solid
        dc4.BorderWidth = 1
        dc4.HorizontalAlign = HorizontalAlign.Center
        dc5.BorderStyle = BorderStyle.Solid
        dc5.BorderWidth = 1
        dc5.HorizontalAlign = HorizontalAlign.Center
        dc6.BorderStyle = BorderStyle.Solid
        dc6.BorderWidth = 1
        dc6.HorizontalAlign = HorizontalAlign.Center
        dc1.Text = "ลำดับ"
        dc2.Text = "รูปแบบ"
        dc3.Text = "dosage form"
        dc4.Text = "ยาแผนไทย/ ยาตามองค์ความรู้การแพทย์ทางเลือก"
        dc5.Text = "ยาพัฒนาจากสมุนไพร"
        dc6.Text = "ผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ"
        dc2.Style.Add("font-weight", "bold")
        dc3.Style.Add("font-weight", "bold")
        dc4.Style.Add("font-weight", "bold")
        dc5.Style.Add("font-weight", "bold")
        dc6.Style.Add("font-weight", "bold")
        dr.Cells.Add(dc1)
        dr.Cells.Add(dc2)
        dr.Cells.Add(dc3)
        dr.Cells.Add(dc4)
        dr.Cells.Add(dc5)
        dr.Cells.Add(dc6)
        tb_type_menu3.Rows.Add(dr)
    End Sub
    Sub bind_head4()
        Dim dc1 As New TableCell
        Dim dc2 As New TableCell
        Dim dc3 As New TableCell
        Dim dc4 As New TableCell
        Dim dc5 As New TableCell
        Dim dc6 As New TableCell
        Dim dr As New TableRow
        dc1.BorderStyle = BorderStyle.Solid
        dc1.BorderWidth = 1
        dc1.Width = 20
        dc2.BorderStyle = BorderStyle.Solid
        dc2.BorderWidth = 1
        dc2.Width = 300
        dc3.BorderStyle = BorderStyle.Solid
        dc3.BorderWidth = 1
        dc3.HorizontalAlign = HorizontalAlign.Center
        dc4.BorderStyle = BorderStyle.Solid
        dc4.BorderWidth = 1
        dc4.HorizontalAlign = HorizontalAlign.Center
        dc5.BorderStyle = BorderStyle.Solid
        dc5.BorderWidth = 1
        dc5.HorizontalAlign = HorizontalAlign.Center
        dc6.BorderStyle = BorderStyle.Solid
        dc6.BorderWidth = 1
        dc6.HorizontalAlign = HorizontalAlign.Center
        dc1.Text = "ลำดับ"
        dc2.Text = "รูปแบบ"
        dc3.Text = "dosage form"
        dc4.Text = "ยาแผนไทย/ ยาตามองค์ความรู้การแพทย์ทางเลือก"
        dc5.Text = "ยาพัฒนาจากสมุนไพร"
        dc6.Text = "ผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ"
        dc2.Style.Add("font-weight", "bold")
        dc3.Style.Add("font-weight", "bold")
        dc4.Style.Add("font-weight", "bold")
        dc5.Style.Add("font-weight", "bold")
        dc6.Style.Add("font-weight", "bold")
        dr.Cells.Add(dc1)
        dr.Cells.Add(dc2)
        dr.Cells.Add(dc3)
        dr.Cells.Add(dc4)
        dr.Cells.Add(dc5)
        dr.Cells.Add(dc6)
        tb_type_menu4.Rows.Add(dr)
    End Sub
    Public Sub BindTable()
        'Dim dao As New DAO_LCN.TB_DALCN_AUDIT_IN
        'dao.GET_DATA_BY_IDA(IDA)
        'Dim tr_id As Integer = 0
        'Try
        '    tr_id = dao.fields.TR_ID
        'Catch ex As Exception

        'End Try

        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_LCN.TB_MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG

        ' dao_f.GetDataAll()
        dao_f.GET_DATA_BY_HEAD_ID(1)

        'tb_type_menu.Columns.Add("Dosage", GetType(Integer))
        'tb_type_menu.Columns.Add("Drug", GetType(String))
        'tb_type_menu.Columns.Add("PatientID", GetType(String))
        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas

            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.PRODUCT_ID
            'tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            If dao_f.fields.PRODUCT_ID IsNot Nothing Then
                tc = New TableCell
                tc.Text = dao_f.fields.PRODUCT_ID
                tc.ID = "P_" & dao_f.fields.PRODUCT_ID
                tc.Style.Add("display", "none")
                tr.Cells.Add(tc)
            End If


            'If dao_f.fields.HEAD_ID IsNot Nothing Then
            '    tc = New TableCell
            '    tc.Text = dao_f.fields.HEAD_ID
            '    tc.ID = "H_" & dao_f.fields.IDA
            '    tc.Style.Add("display", "none")
            '    tr.Cells.Add(tc)
            'End If

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.PRODUCT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.PRODUCT_NAME
            End Try
            tc.Width = 300
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.DOSAGE_FORM
            tc.Width = 300
            tr.Cells.Add(tc)

            If dao_f.fields.CHK_MENU_1 = 1 Then
                tc = New TableCell
                Dim C As New CheckBox
                C.ID = "C1_" & dao_f.fields.IDA
                tc.Controls.Add(C)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            If dao_f.fields.CHK_MENU_2 = 1 Then
                tc = New TableCell
                Dim C2 As New CheckBox
                C2.ID = "C2_" & dao_f.fields.IDA
                tc.Controls.Add(C2)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            If dao_f.fields.CHK_MENU_3 = 1 Then
                tc = New TableCell
                Dim C3 As New CheckBox
                C3.ID = "C3_" & dao_f.fields.IDA
                tc.Controls.Add(C3)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            'tc = New TableCell
            'Dim f As New FileUpload
            'f.ID = "F" & dao_f.fields.IDA
            'tc.Controls.Add(f)
            'tr.Cells.Add(tc)

            tb_type_menu.Rows.Add(tr)
            rows = rows + 1

        Next
    End Sub
    Public Sub BindTable2()
        'Dim dao As New DAO_LCN.TB_DALCN_AUDIT_IN
        'dao.GET_DATA_BY_IDA(IDA)
        'Dim tr_id As Integer = 0
        'Try
        '    tr_id = dao.fields.TR_ID
        'Catch ex As Exception

        'End Try

        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_LCN.TB_MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG

        ' dao_f.GetDataAll()
        dao_f.GET_DATA_BY_HEAD_ID(2)

        'tb_type_menu.Columns.Add("Dosage", GetType(Integer))
        'tb_type_menu.Columns.Add("Drug", GetType(String))
        'tb_type_menu.Columns.Add("PatientID", GetType(String))
        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas

            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.PRODUCT_ID
            'tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            If dao_f.fields.PRODUCT_ID IsNot Nothing Then
                tc = New TableCell
                tc.Text = dao_f.fields.PRODUCT_ID
                tc.ID = "P2_" & dao_f.fields.PRODUCT_ID
                tc.Style.Add("display", "none")
                tr.Cells.Add(tc)
            End If

            'If dao_f.fields.HEAD_ID IsNot Nothing Then
            '    tc = New TableCell
            '    tc.Text = dao_f.fields.HEAD_ID
            '    tc.ID = "H2_" & dao_f.fields.IDA
            '    tc.Style.Add("display", "none")
            '    tr.Cells.Add(tc)
            'End If

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.PRODUCT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.PRODUCT_NAME
            End Try
            tc.Width = 300
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.DOSAGE_FORM
            tc.Width = 300
            tr.Cells.Add(tc)

            If dao_f.fields.CHK_MENU_1 = 1 Then
                tc = New TableCell
                Dim C As New CheckBox
                C.ID = "C1_" & dao_f.fields.IDA
                tc.Controls.Add(C)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            If dao_f.fields.CHK_MENU_2 = 1 Then
                tc = New TableCell
                Dim C2 As New CheckBox
                C2.ID = "C2_" & dao_f.fields.IDA
                tc.Controls.Add(C2)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            If dao_f.fields.CHK_MENU_3 = 1 Then
                tc = New TableCell
                Dim C3 As New CheckBox
                C3.ID = "C3_" & dao_f.fields.IDA
                tc.Controls.Add(C3)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            'tc = New TableCell
            'Dim f As New FileUpload
            'f.ID = "F" & dao_f.fields.IDA
            'tc.Controls.Add(f)
            'tr.Cells.Add(tc)

            tb_type_menu2.Rows.Add(tr)
            rows = rows + 1

        Next
    End Sub
    Public Sub BindTable3()
        'Dim dao As New DAO_LCN.TB_DALCN_AUDIT_IN
        'dao.GET_DATA_BY_IDA(IDA)
        'Dim tr_id As Integer = 0
        'Try
        '    tr_id = dao.fields.TR_ID
        'Catch ex As Exception

        'End Try

        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_LCN.TB_MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG

        ' dao_f.GetDataAll()
        dao_f.GET_DATA_BY_HEAD_ID(3)

        'tb_type_menu.Columns.Add("Dosage", GetType(Integer))
        'tb_type_menu.Columns.Add("Drug", GetType(String))
        'tb_type_menu.Columns.Add("PatientID", GetType(String))
        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas

            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.PRODUCT_ID
            'tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            If dao_f.fields.PRODUCT_ID IsNot Nothing Then
                tc = New TableCell
                tc.Text = dao_f.fields.PRODUCT_ID
                tc.ID = "P3_" & dao_f.fields.PRODUCT_ID
                tc.Style.Add("display", "none")
                tr.Cells.Add(tc)
            End If

            'If dao_f.fields.HEAD_ID IsNot Nothing Then
            '    tc = New TableCell
            '    tc.Text = dao_f.fields.HEAD_ID
            '    tc.ID = "H3_" & dao_f.fields.IDA
            '    tc.Style.Add("display", "none")
            '    tr.Cells.Add(tc)
            'End If

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.PRODUCT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.PRODUCT_NAME
            End Try
            tc.Width = 300
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.DOSAGE_FORM
            tc.Width = 300
            tr.Cells.Add(tc)

            If dao_f.fields.CHK_MENU_1 = 1 Then
                tc = New TableCell
                Dim C As New CheckBox
                C.ID = "C1_" & dao_f.fields.IDA
                tc.Controls.Add(C)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            If dao_f.fields.CHK_MENU_2 = 1 Then
                tc = New TableCell
                Dim C2 As New CheckBox
                C2.ID = "C2_" & dao_f.fields.IDA
                tc.Controls.Add(C2)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            If dao_f.fields.CHK_MENU_3 = 1 Then
                tc = New TableCell
                Dim C3 As New CheckBox
                C3.ID = "C3_" & dao_f.fields.IDA
                tc.Controls.Add(C3)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            'tc = New TableCell
            'Dim f As New FileUpload
            'f.ID = "F" & dao_f.fields.IDA
            'tc.Controls.Add(f)
            'tr.Cells.Add(tc)

            tb_type_menu3.Rows.Add(tr)
            rows = rows + 1

        Next
    End Sub
    Public Sub BindTable4()
        'Dim dao As New DAO_LCN.TB_DALCN_AUDIT_IN
        'dao.GET_DATA_BY_IDA(IDA)
        'Dim tr_id As Integer = 0
        'Try
        '    tr_id = dao.fields.TR_ID
        'Catch ex As Exception

        'End Try

        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_LCN.TB_MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG

        ' dao_f.GetDataAll()
        dao_f.GET_DATA_BY_HEAD_ID(4)

        'tb_type_menu.Columns.Add("Dosage", GetType(Integer))
        'tb_type_menu.Columns.Add("Drug", GetType(String))
        'tb_type_menu.Columns.Add("PatientID", GetType(String))
        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas

            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.PRODUCT_ID
            'tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            If dao_f.fields.PRODUCT_ID IsNot Nothing Then
                tc = New TableCell
                tc.Text = dao_f.fields.PRODUCT_ID
                tc.ID = "P4_" & dao_f.fields.PRODUCT_ID
                tc.Style.Add("display", "none")
                tr.Cells.Add(tc)
            End If

            'If dao_f.fields.HEAD_ID IsNot Nothing Then
            '    tc = New TableCell
            '    tc.Text = dao_f.fields.HEAD_ID
            '    tc.ID = "H4_" & dao_f.fields.IDA
            '    tc.Style.Add("display", "none")
            '    tr.Cells.Add(tc)
            'End If

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.PRODUCT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.PRODUCT_NAME
            End Try
            tc.Width = 300
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.DOSAGE_FORM
            tc.Width = 300
            tr.Cells.Add(tc)

            If dao_f.fields.CHK_MENU_1 = 1 Then
                tc = New TableCell
                Dim C As New CheckBox
                C.ID = "C1_" & dao_f.fields.IDA
                tc.Controls.Add(C)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            If dao_f.fields.CHK_MENU_2 = 1 Then
                tc = New TableCell
                Dim C2 As New CheckBox
                C2.ID = "C2_" & dao_f.fields.IDA
                tc.Controls.Add(C2)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            If dao_f.fields.CHK_MENU_3 = 1 Then
                tc = New TableCell
                Dim C3 As New CheckBox
                C3.ID = "C3_" & dao_f.fields.IDA
                tc.Controls.Add(C3)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                tr.Cells.Add(tc)
            End If

            'tc = New TableCell
            'Dim f As New FileUpload
            'f.ID = "F" & dao_f.fields.IDA
            'tc.Controls.Add(f)
            'tr.Cells.Add(tc)

            tb_type_menu4.Rows.Add(tr)
            rows = rows + 1

        Next
    End Sub
    Sub get_data(ByVal IDA_LCN As Integer)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(IDA_LCN)
        Dim dao_A As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_A.GetDataby_IDA(dao.fields.FK_IDA)
        'txt_Name_Production_site.Text = dao_A.fields.thanameplace

    End Sub
    Sub save_data(ByVal IDA As Integer)
        'Dim dao As New DAO_LCN.TB_DALCN_AUDIT_IN
        'dao.GET_DATA_BY_IDA(IDA)
        'dao.fields.Name_Production_site = txt_Name_Production_site.Text
        'dao.update()
    End Sub
    Sub save_data_tb(ByVal _IDA As Integer)
        Dim dao As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION
        dao.GET_DATA_BY_IDA(_IDA)
        For Each tr As TableRow In tb_type_menu.Rows
            Dim dao_A As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
            If tr.Cells(1).Text <> "รูปแบบ" Then
                Dim IDA As Integer = tr.Cells(1).Text

                dao_A.fields.ID = tr.Cells(2).Text
                dao_A.fields.SEQ = IDA
                Try
                    Dim C1 As New CheckBox
                    C1 = tr.FindControl("C1_" & IDA)
                    dao_A.fields.CHK_MENU_1 = C1.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_1 = 0
                End Try

                'Try
                '    Dim H1 As New TextBox
                '    H1 = tr.FindControl("H_" & IDA)
                '    dao_A.fields.HEAD_ID = H1.Text
                'Catch ex As Exception
                '    dao_A.fields.HEAD_ID = 1
                'End Try

                Try
                    Dim C2 As New CheckBox
                    C2 = tr.FindControl("C2_" & IDA)
                    dao_A.fields.CHK_MENU_2 = C2.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_2 = 0
                End Try

                Try
                    Dim C3 As New CheckBox
                    C3 = tr.FindControl("C3_" & IDA)
                    dao_A.fields.CHK_MENU_3 = C3.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_3 = 0
                End Try

                dao_A.fields.HEAD_ID = 1
                dao_A.fields.FK_IDA = _IDA
                dao_A.fields.LCN_IDA = Request.QueryString("IDA_LCN")
                dao_A.fields.PROCESS_ID = Request.QueryString("PROCESS_ID")
                dao_A.insert()

            End If
        Next

        For Each tr As TableRow In tb_type_menu2.Rows
            Dim dao_A As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
            If tr.Cells(1).Text <> "รูปแบบ" Then
                Dim IDA As Integer = tr.Cells(1).Text

                dao_A.fields.ID = tr.Cells(2).Text
                dao_A.fields.SEQ = IDA
                Try
                    Dim C1 As New CheckBox
                    C1 = tr.FindControl("C1_" & IDA)
                    dao_A.fields.CHK_MENU_1 = C1.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_1 = 0
                End Try

                Try
                    Dim C2 As New CheckBox
                    C2 = tr.FindControl("C2_" & IDA)
                    dao_A.fields.CHK_MENU_2 = C2.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_2 = 0
                End Try

                Try
                    Dim C3 As New CheckBox
                    C3 = tr.FindControl("C3_" & IDA)
                    dao_A.fields.CHK_MENU_3 = C3.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_3 = 0
                End Try

                dao_A.fields.HEAD_ID = 2
                dao_A.fields.FK_IDA = _IDA
                dao_A.fields.LCN_IDA = Request.QueryString("IDA_LCN")
                dao_A.fields.PROCESS_ID = Request.QueryString("PROCESS_ID")
                dao_A.insert()

            End If
        Next

        For Each tr As TableRow In tb_type_menu3.Rows
            Dim dao_A As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
            If tr.Cells(1).Text <> "รูปแบบ" Then
                Dim IDA As Integer = tr.Cells(1).Text

                dao_A.fields.ID = tr.Cells(2).Text
                dao_A.fields.SEQ = IDA
                Try
                    Dim C1 As New CheckBox
                    C1 = tr.FindControl("C1_" & IDA)
                    dao_A.fields.CHK_MENU_1 = C1.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_1 = 0
                End Try

                Try
                    Dim C2 As New CheckBox
                    C2 = tr.FindControl("C2_" & IDA)
                    dao_A.fields.CHK_MENU_2 = C2.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_2 = 0
                End Try

                Try
                    Dim C3 As New CheckBox
                    C3 = tr.FindControl("C3_" & IDA)
                    dao_A.fields.CHK_MENU_3 = C3.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_3 = 0
                End Try

                dao_A.fields.HEAD_ID = 3
                dao_A.fields.FK_IDA = _IDA
                dao_A.fields.LCN_IDA = Request.QueryString("IDA_LCN")
                dao_A.fields.PROCESS_ID = Request.QueryString("PROCESS_ID")
                dao_A.insert()

            End If
        Next

        For Each tr As TableRow In tb_type_menu4.Rows
            Dim dao_A As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
            If tr.Cells(1).Text <> "รูปแบบ" Then
                Dim IDA As Integer = tr.Cells(1).Text

                dao_A.fields.ID = tr.Cells(2).Text
                dao_A.fields.SEQ = IDA
                Try
                    Dim C1 As New CheckBox
                    C1 = tr.FindControl("C1_" & IDA)
                    dao_A.fields.CHK_MENU_1 = C1.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_1 = 0
                End Try

                Try
                    Dim C2 As New CheckBox
                    C2 = tr.FindControl("C2_" & IDA)
                    dao_A.fields.CHK_MENU_2 = C2.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_2 = 0
                End Try

                Try
                    Dim C3 As New CheckBox
                    C3 = tr.FindControl("C3_" & IDA)
                    dao_A.fields.CHK_MENU_3 = C3.Checked
                Catch ex As Exception
                    dao_A.fields.CHK_MENU_3 = 0
                End Try

                dao_A.fields.HEAD_ID = 4
                dao_A.fields.FK_IDA = _IDA
                dao_A.fields.LCN_IDA = Request.QueryString("IDA_LCN")
                dao_A.fields.PROCESS_ID = Request.QueryString("PROCESS_ID")
                dao_A.insert()

            End If
        Next
    End Sub
End Class