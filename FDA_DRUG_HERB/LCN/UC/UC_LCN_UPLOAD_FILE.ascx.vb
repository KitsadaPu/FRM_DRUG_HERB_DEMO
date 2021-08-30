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
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(_IDA)
        If Not IsPostBack Then
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

            If _ProcessID = 122 Then
                Panel_posormo.Style.Add("display", "block")
            Else
                Panel_posormo.Style.Add("display", "none")
            End If
        End If
    End Sub


    Public Sub CHK_upload()
        UC_ATTACH_LCN_1_1.CHK_upload_file()
        UC_ATTACH_LCN_1_2.CHK_upload_file()
        UC_ATTACH_LCN_1_3.CHK_upload_file()
        UC_ATTACH_LCN_1_4.CHK_upload_file()
        UC_ATTACH_LCN_1_5.CHK_upload_file()

        UC_ATTACH_LCN_NO1.CHK_upload_file()
        UC_ATTACH_LCN_NO1_1.CHK_upload_file()
        UC_ATTACH_LCN_NO1_2.CHK_upload_file()
        UC_ATTACH_LCN_NO1_3.CHK_upload_file()
        UC_ATTACH_LCN_NO1_4.CHK_upload_file()


        UC_ATTACH_LCN_BSN1.CHK_upload_file()
        UC_ATTACH_LCN_BSN2.CHK_upload_file()
        UC_ATTACH_LCN_BSN2_2.CHK_upload_file()
        ' UC_ATTACH_LCN_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5", IDA)
        'UC_ATTACH_LCN_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6", IDA)
        'UC_ATTACH_LCN_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7", IDA)
        'UC_ATTACH_LCN_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8", IDA)
    End Sub
    Function CHK_ATTACH_PDF() As Integer
        Dim i As Integer = 0
        i += UC_ATTACH_LCN_1_1.CHK_Extension()
        i += UC_ATTACH_LCN_1_2.CHK_Extension()
        i += UC_ATTACH_LCN_1_3.CHK_Extension()
        i += UC_ATTACH_LCN_1_4.CHK_Extension()

        Return i
    End Function
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    Protected Sub BTN_UPLOAD_Click(sender As Object, e As EventArgs) Handles BTN_UPLOAD.Click
        Dim Year As String
        Year = con_year(Date.Now.Year)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        If rdl_person_type1.Checked = True Or rdl_person_type2.Checked = True Or rdl_person_type3.Checked = True Or rdl_person_type4.Checked = True Or rdl_person_type5.Checked = True Then
            If rdl_person_type1.Checked = True Then

                UC_ATTACH_LCN_1_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "1", _IDA)
                UC_ATTACH_LCN_1_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "2", _IDA)
                UC_ATTACH_LCN_1_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "3", _IDA)
                UC_ATTACH_LCN_1_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "4", _IDA)
                UC_ATTACH_LCN_1_5.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "5", _IDA)

                If _ProcessID = 122 Then
                    UC_ATTACH_LCN_PSM1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "11", _IDA)
                    UC_ATTACH_LCN_PSM2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "12", _IDA)
                    UC_ATTACH_LCN_PSM3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "13", _IDA)
                End If

                If rdl_chk_local.SelectedValue <> "" Then
                    If rdl_chk_local.SelectedValue = 11 Then
                        UC_ATTACH_LCN_NO1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "14", _IDA)
                        UC_ATTACH_LCN_NO1_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "15", _IDA)
                        UC_ATTACH_LCN_NO1_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "16", _IDA)
                        UC_ATTACH_LCN_NO1_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "17", _IDA)
                        UC_ATTACH_LCN_NO1_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "18", _IDA)
                    ElseIf rdl_chk_local.SelectedValue = 12 Then
                        UC_ATTACH_LCN_NO2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "19", _IDA)
                    End If
                End If


                'If rdl_chk_bsn.SelectedValue <> "" Then
                '    If rdl_chk_bsn.SelectedValue = 66 Then
                '        UC_ATTACH_LCN_BSN1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "20", _IDA)
                '    ElseIf rdl_chk_bsn.SelectedValue = 77 Then
                '        UC_ATTACH_LCN_BSN2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "21", _IDA)
                '        UC_ATTACH_LCN_BSN2_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "22", _IDA)
                '    End If
                'End If



            ElseIf rdl_person_type2.Checked = True Then
                UC_ATTACH_LCN_2_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "6", _IDA)
                UC_ATTACH_LCN_2_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "7", _IDA)
                UC_ATTACH_LCN_2_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "3", _IDA)
                UC_ATTACH_LCN_2_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "4", _IDA)
                UC_ATTACH_LCN_2_5.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "5", _IDA)


                If _ProcessID = 122 Then
                    UC_ATTACH_LCN_PSM1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "11", _IDA)
                    UC_ATTACH_LCN_PSM2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "12", _IDA)
                    UC_ATTACH_LCN_PSM3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "13", _IDA)
                End If

                If rdl_chk_local.SelectedValue <> "" Then
                    If rdl_chk_local.SelectedValue = 11 Then
                        UC_ATTACH_LCN_NO1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "14", _IDA)
                        UC_ATTACH_LCN_NO1_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "15", _IDA)
                        UC_ATTACH_LCN_NO1_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "16", _IDA)
                        UC_ATTACH_LCN_NO1_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "17", _IDA)
                        UC_ATTACH_LCN_NO1_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "18", _IDA)
                    ElseIf rdl_chk_local.SelectedValue = 12 Then
                        UC_ATTACH_LCN_NO2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "19", _IDA)
                    End If
                End If


                'If rdl_chk_bsn.SelectedValue <> "" Then
                '    If rdl_chk_bsn.SelectedValue = 66 Then
                '        UC_ATTACH_LCN_BSN1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "20", _IDA)
                '    ElseIf rdl_chk_bsn.SelectedValue = 77 Then
                '        UC_ATTACH_LCN_BSN2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "21", _IDA)
                '        UC_ATTACH_LCN_BSN2_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "22", _IDA)
                '    End If
                'End If

            ElseIf rdl_person_type3.Checked = True Then
                UC_ATTACH_LCN_3_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "8", _IDA)
                UC_ATTACH_LCN_3_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "3", _IDA)
                UC_ATTACH_LCN_3_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "4", _IDA)
                UC_ATTACH_LCN_3_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "5", _IDA)


                If _ProcessID = 122 Then
                    UC_ATTACH_LCN_PSM1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "11", _IDA)
                    UC_ATTACH_LCN_PSM2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "12", _IDA)
                    UC_ATTACH_LCN_PSM3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "13", _IDA)
                End If

                If rdl_chk_local.SelectedValue <> "" Then
                    If rdl_chk_local.SelectedValue = 11 Then
                        UC_ATTACH_LCN_NO1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "14", _IDA)
                        UC_ATTACH_LCN_NO1_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "15", _IDA)
                        UC_ATTACH_LCN_NO1_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "16", _IDA)
                        UC_ATTACH_LCN_NO1_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "17", _IDA)
                        UC_ATTACH_LCN_NO1_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "18", _IDA)
                    ElseIf rdl_chk_local.SelectedValue = 12 Then
                        UC_ATTACH_LCN_NO2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "19", _IDA)
                    End If
                End If


                If rdl_chk_bsn.SelectedValue <> "" Then
                    If rdl_chk_bsn.SelectedValue = 66 Then
                        UC_ATTACH_LCN_BSN1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "20", _IDA)
                    ElseIf rdl_chk_bsn.SelectedValue = 77 Then
                        UC_ATTACH_LCN_BSN2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "21", _IDA)
                        UC_ATTACH_LCN_BSN2_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "22", _IDA)
                    End If
                End If

            ElseIf rdl_person_type4.Checked = True Then
                UC_ATTACH_LCN_4_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "8", _IDA)
                UC_ATTACH_LCN_4_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "9", _IDA)
                UC_ATTACH_LCN_4_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "3", _IDA)
                UC_ATTACH_LCN_4_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "4", _IDA)
                UC_ATTACH_LCN_4_5.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "5", _IDA)


                If _ProcessID = 122 Then
                    UC_ATTACH_LCN_PSM1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "11", _IDA)
                    UC_ATTACH_LCN_PSM2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "12", _IDA)
                    UC_ATTACH_LCN_PSM3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "13", _IDA)
                End If

                If rdl_chk_local.SelectedValue <> "" Then
                    If rdl_chk_local.SelectedValue = 11 Then
                        UC_ATTACH_LCN_NO1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "14", _IDA)
                        UC_ATTACH_LCN_NO1_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "15", _IDA)
                        UC_ATTACH_LCN_NO1_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "16", _IDA)
                        UC_ATTACH_LCN_NO1_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "17", _IDA)
                        UC_ATTACH_LCN_NO1_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "18", _IDA)
                    ElseIf rdl_chk_local.SelectedValue = 12 Then
                        UC_ATTACH_LCN_NO2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "19", _IDA)
                    End If
                End If


                If rdl_chk_bsn.SelectedValue <> "" Then
                    If rdl_chk_bsn.SelectedValue = 66 Then
                        UC_ATTACH_LCN_BSN1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "20", _IDA)
                    ElseIf rdl_chk_bsn.SelectedValue = 77 Then
                        UC_ATTACH_LCN_BSN2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "21", _IDA)
                        UC_ATTACH_LCN_BSN2_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "22", _IDA)
                    End If
                End If

            ElseIf rdl_person_type5.Checked = True Then
                UC_ATTACH_LCN_5_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "10", _IDA)

                UC_ATTACH_LCN_5_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "3", _IDA)
                UC_ATTACH_LCN_5_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "4", _IDA)
                UC_ATTACH_LCN_5_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "5", _IDA)


                If _ProcessID = 122 Then
                    UC_ATTACH_LCN_PSM1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "11", _IDA)
                    UC_ATTACH_LCN_PSM2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "12", _IDA)
                    UC_ATTACH_LCN_PSM3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "13", _IDA)
                End If

                If rdl_chk_local.SelectedValue <> "" Then
                    If rdl_chk_local.SelectedValue = 11 Then
                        UC_ATTACH_LCN_NO1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "14", _IDA)
                        UC_ATTACH_LCN_NO1_1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "15", _IDA)
                        UC_ATTACH_LCN_NO1_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "16", _IDA)
                        UC_ATTACH_LCN_NO1_3.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "17", _IDA)
                        UC_ATTACH_LCN_NO1_4.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "18", _IDA)
                    ElseIf rdl_chk_local.SelectedValue = 12 Then
                        UC_ATTACH_LCN_NO2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "19", _IDA)
                    End If
                End If


                If rdl_chk_bsn.SelectedValue <> "" Then
                    If rdl_chk_bsn.SelectedValue = 66 Then
                        UC_ATTACH_LCN_BSN1.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "20", _IDA)
                    ElseIf rdl_chk_bsn.SelectedValue = 77 Then
                        UC_ATTACH_LCN_BSN2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "21", _IDA)
                        UC_ATTACH_LCN_BSN2_2.ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "22", _IDA)
                    End If
                End If

            End If
            dao_up.GetDataby_FK_IDA(_IDA)
            If rdl_chk_bsn.SelectedValue = "" Then
                dao_up.fields.TYPE_BSN = 0
            Else
                dao_up.fields.TYPE_BSN = rdl_chk_bsn.SelectedValue
            End If
            Try
                'dao_up.fields.TYPE_BSN_NAME = rdl_chk_bsn.SelectedItem.Text
            Catch ex As Exception

            End Try

            If rdl_chk_local.SelectedValue = "" Then
                dao_up.fields.TYPE_LOCAL = 0
            Else
                dao_up.fields.TYPE_LOCAL = rdl_chk_local.SelectedValue
            End If
            Try
                dao_up.fields.TYPE_LOCAL_NAME = rdl_chk_local.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao_up.update()


            dao.GetDataby_IDA(_IDA)
            If rdl_person_type1.Checked = True Then
                dao.fields.TYPE_PERSON = 1
                dao.fields.TYPE_PERSON_NAME = "บุคคลธรรมดา"
            ElseIf rdl_person_type2.Checked = True Then
                dao.fields.TYPE_PERSON = 2
                dao.fields.TYPE_PERSON_NAME = "บุคคลธรรมดา(สัญชาติอื่นๆ)"
            ElseIf rdl_person_type3.Checked = True Then
                dao.fields.TYPE_PERSON = 3
                dao.fields.TYPE_PERSON_NAME = "นิติบุคคล(สัญชาติไทย)"
            ElseIf rdl_person_type3.Checked = True Then
                dao.fields.TYPE_PERSON = 4
                dao.fields.TYPE_PERSON_NAME = "นิติบุคคล(สัญชาติอื่นๆ) กรณีจดทะเบียนในไทย"
            ElseIf rdl_person_type3.Checked = True Then
                dao.fields.TYPE_PERSON = 5
                dao.fields.TYPE_PERSON_NAME = "นิติบุคคล(สัญชาติอื่นๆ) กรณีไม่จดทะเบียนในไทย"
            End If
            If rdl_chk_bsn.SelectedValue = "" Then
                dao.fields.TYPE_BSN = 0
            Else
                dao.fields.TYPE_BSN = rdl_chk_bsn.SelectedValue
            End If
            Try
                dao.fields.TYPE_BSN = rdl_chk_bsn.SelectedItem.Text
            Catch ex As Exception

            End Try

            'dao.fields.TYPE_LOCAL = rdl_chk_local.SelectedValue
            If rdl_chk_local.SelectedValue = "" Then
                dao.fields.TYPE_LOCAL = 0
            Else
                dao.fields.TYPE_LOCAL = rdl_chk_local.SelectedValue
            End If
            Try
                dao.fields.TYPE_LOCAL = rdl_chk_local.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao.update()

            alert_close("อัพโหลดเอกสารแล้ว")
        Else
            alert("กรุณาเลือกประเภทบุคคล")
        End If
    End Sub

    Sub alert_close(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class