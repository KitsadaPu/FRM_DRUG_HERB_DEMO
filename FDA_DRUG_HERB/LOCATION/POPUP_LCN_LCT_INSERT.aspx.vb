﻿Public Class POPUP_LCN_LCT_INSERT
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _iden As String
    Private _CLS As New CLS_SESSION
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
        RunSession()

        _IDA = Request.QueryString("IDA")
        _iden = Request.QueryString("iden")
        If Not IsPostBack Then
            Dim dao_loca_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            dao_loca_addr.GetDataby_IDA(_IDA)
            chngwtcd()
            If _IDA <> "" Then
                btn_send.Style.Add("display", "block")
                bnt_submit.Style.Add("display", "none")
                loadData_by_Identify()

                If dao_loca_addr.fields.STATUS_ID > 1 Then
                    btn_send.Style.Add("display", "none")
                    bnt_submit.Style.Add("display", "none")
                    btn_upload.Style.Add("display", "none")
                    'UC_ATTACH_LCN.EnableViewState = False
                ElseIf dao_loca_addr.fields.STATUS_ID = 1 Then
                    btn_send.Style.Add("display", "block")
                    bnt_submit.Style.Add("display", "block")
                End If
            Else
                div_set_show1.Style.Add("display", "none")
                btn_upload.Style.Add("display", "none")
                lbl_upload_file.Style.Add("display", "none")
                btn_send.Style.Add("display", "none")
                bnt_submit.Style.Add("display", "block")
            End If

            Try
                Dim up_edit As String = ""
                Dim dao_a As New DAO_DRUG.TB_FILE_ATTACH_LOCATION
                dao_a.GetDataby_TR_ID(dao_loca_addr.fields.TR_ID)
                If dao_a.fields.IDA <> 0 Then
                    img_cf.Visible = True
                    img_not.Visible = False
                    lbl_upload_file.Text = dao_a.fields.NAME_REAL
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Sub loadData_by_Identify()
        Dim dao_loca_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_loca_addr.GetDataby_IDA(_IDA)
        chngwtcd()
        txt_thabuilding_lo.Text = dao_loca_addr.fields.thabuilding
        txt_thafloor_lo.Text = dao_loca_addr.fields.thafloor
        txt_tharoom_lo.Text = dao_loca_addr.fields.tharoom
        txt_thanameplace_lo.Text = dao_loca_addr.fields.thanameplace
        txt_engnameplace_lo.Text = dao_loca_addr.fields.engnameplace
        txt_thacode_id_lo.Text = dao_loca_addr.fields.HOUSENO
        txt_thaaddr_lo.Text = dao_loca_addr.fields.thaaddr
        txt_thamu_lo.Text = dao_loca_addr.fields.thamu
        txt_thasoi_lo.Text = dao_loca_addr.fields.thasoi
        txt_tharoad_lo.Text = dao_loca_addr.fields.tharoad
        txt_zipcode_lo.Text = dao_loca_addr.fields.zipcode
        txt_tel_lo.Text = dao_loca_addr.fields.tel
        txt_mobile_lo.Text = dao_loca_addr.fields.Mobile
        txt_fax_lo.Text = dao_loca_addr.fields.fax
        Try
            ddl_chngwt.DropDownSelectData(dao_loca_addr.fields.chngwtcd)
            amphrcd()
            ddl_amphr.DropDownSelectData(dao_loca_addr.fields.amphrcd)
            thmblcd()
            ddl_thumbol.DropDownSelectData(dao_loca_addr.fields.thmblcd)
        Catch ex As Exception

        End Try

        Try
            rdl_place_type.SelectedValue = dao_loca_addr.fields.LOCATION_TYPE_ID
        Catch ex As Exception

        End Try
        Try
            txt_latitude.Text = dao_loca_addr.fields.latitude
            txt_longitude.Text = dao_loca_addr.fields.longitude
        Catch ex As Exception

        End Try



    End Sub
    Sub chngwtcd()
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim chn As New DAO_CPN.ClsDBsyschngwt
        Dim item As New ListItem("-----รายชื่อจังหวัด-----", "0")
        chn.GetDataAll()
        ddl_chngwt.DataSource = chn.datas
        ddl_chngwt.DataTextField = "thachngwtnm"
        ddl_chngwt.DataValueField = "chngwtcd"
        ddl_chngwt.DataBind()
        ddl_chngwt.Items.Insert(0, item)
    End Sub

    Sub amphrcd()   'เป็นการนำข้อมูลในตารางใส่ DropDown  ข้อมูลอำเภอ
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim amp As New DAO_CPN.ClsDBsysamphr
        amp.GetDataby_chngwtcd(ddl_chngwt.SelectedValue)
        ddl_amphr.DataSource = amp.datas
        ddl_amphr.DataTextField = "thaamphrnm"
        ddl_amphr.DataValueField = "amphrcd"
        ddl_amphr.DataBind()
        DropDownInsertDataFirstRow2(ddl_amphr, "-----รายชื่ออำเภอ-----", "0")
    End Sub
    Sub thmblcd()      'เป็นการนำข้อมูลในตารางใส่ DropDown  ข้อมูลตำบล
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim thm As New DAO_CPN.ClsDBsysthmbl
        thm.GetDataby_thmbl(ddl_chngwt.SelectedValue, ddl_amphr.SelectedValue)
        ddl_thumbol.DataSource = thm.datas
        ddl_thumbol.DataTextField = "thathmblnm"
        ddl_thumbol.DataValueField = "thmblcd"
        ddl_thumbol.DataBind()
        DropDownInsertDataFirstRow2(ddl_thumbol, "-----รายชื่อตำบล-----", "0")
    End Sub
    Protected Sub ddl_chngwt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_chngwt.SelectedIndexChanged

        ddl_amphr.Items.Clear()
        ddl_thumbol.Items.Clear()
        amphrcd()

    End Sub

    Protected Sub ddl_amphr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_amphr.SelectedIndexChanged

        thmblcd()


    End Sub
    Public Sub save(ByVal TR_ID As Integer)
        Dim dao_location_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS

        Dim dao_syschngwt As New DAO_CPN.clsDBsyschngwt
        Dim dao_sysamphr As New DAO_CPN.clsDBsysamphr
        Dim dao_systhmbl As New DAO_CPN.clsDBsysthmbl

        Dim chngwtcd As Integer = ddl_chngwt.SelectedValue
        Dim amphrcd As Integer = ddl_amphr.SelectedValue
        Dim thmblcd As Integer = ddl_thumbol.SelectedValue

        dao_location_addr.fields.TR_ID = TR_ID
        dao_location_addr.fields.thanameplace = txt_thanameplace_lo.Text
        dao_location_addr.fields.engnameplace = txt_engnameplace_lo.Text
        dao_location_addr.fields.HOUSENO = txt_thacode_id_lo.Text
        dao_location_addr.fields.thabuilding = txt_thabuilding_lo.Text
        dao_location_addr.fields.thafloor = txt_thafloor_lo.Text
        dao_location_addr.fields.tharoom = txt_tharoom_lo.Text
        dao_location_addr.fields.thaaddr = txt_thaaddr_lo.Text
        dao_location_addr.fields.thamu = txt_thamu_lo.Text
        dao_location_addr.fields.thasoi = txt_thasoi_lo.Text
        dao_location_addr.fields.tharoad = txt_tharoad_lo.Text
        dao_location_addr.fields.zipcode = txt_zipcode_lo.Text
        If txt_tel_lo.Text = "" Then
            dao_location_addr.fields.tel = "-"
        Else
            dao_location_addr.fields.tel = txt_tel_lo.Text
        End If

        If txt_mobile_lo.Text = "" Then
            dao_location_addr.fields.Mobile = "-"
        Else
            dao_location_addr.fields.Mobile = txt_mobile_lo.Text
        End If
        If txt_fax_lo.Text = "" Then
            dao_location_addr.fields.fax = "-"
        Else
            dao_location_addr.fields.fax = txt_fax_lo.Text
        End If

        dao_location_addr.fields.chngwtcd = chngwtcd
        dao_location_addr.fields.amphrcd = amphrcd
        dao_location_addr.fields.thmblcd = thmblcd
        dao_location_addr.fields.thachngwtnm = ddl_chngwt.SelectedItem.Text
        dao_location_addr.fields.thaamphrnm = ddl_amphr.SelectedItem.Text
        dao_location_addr.fields.thathmblnm = ddl_thumbol.SelectedItem.Text
        dao_location_addr.fields.STATUS_ID = 1
        dao_syschngwt.GetData_by_chngwtcd(chngwtcd)
        dao_sysamphr.GetData_by_chngwtcd_amphrcd(chngwtcd, amphrcd)
        dao_systhmbl.GetData_by_chngwtcd_amphrcd_thmblcd(chngwtcd, amphrcd, thmblcd)

        dao_location_addr.fields.engchngwtnm = dao_syschngwt.fields.engchngwtnm
        dao_location_addr.fields.engamphrnm = dao_sysamphr.fields.engamphrnm
        dao_location_addr.fields.engthmblnm = dao_systhmbl.fields.engthmblnm

        dao_location_addr.fields.LOCATION_TYPE_ID = rdl_place_type.SelectedValue
        dao_location_addr.fields.IDENTIFY = _iden
        dao_location_addr.fields.SYSTEM_NAME = "DRUG"
        Try
            dao_location_addr.fields.pvncd = _CLS.PVCODE
        Catch ex As Exception

        End Try

        Try
            If txt_latitude.Text = "" Then
                dao_location_addr.fields.longitude = 0
            Else
                dao_location_addr.fields.latitude = txt_latitude.Text
            End If
            If txt_longitude.Text = "" Then
                dao_location_addr.fields.longitude = 0
            Else
                dao_location_addr.fields.longitude = txt_longitude.Text
            End If
            dao_location_addr.fields.CREATE_DATE = Date.Now
        Catch ex As Exception

        End Try


        dao_location_addr.insert()
        Response.Write("<script type='text/javascript'>alert('บันทึกข้อมูลเรียบร้อยแล้ว'); parent.close_modal();</script> ")
        Response.Write("</script type >")
    End Sub
    Public Sub edit()

        Dim dao_location_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_location_addr.GetDataby_IDA(_IDA)
        Dim dao_syschngwt As New DAO_CPN.clsDBsyschngwt
        Dim dao_sysamphr As New DAO_CPN.clsDBsysamphr
        Dim dao_systhmbl As New DAO_CPN.clsDBsysthmbl

        Dim chngwtcd As Integer = ddl_chngwt.SelectedValue
        Dim amphrcd As Integer = ddl_amphr.SelectedValue
        Dim thmblcd As Integer = ddl_thumbol.SelectedValue


        dao_location_addr.fields.thanameplace = txt_thanameplace_lo.Text
        dao_location_addr.fields.engnameplace = txt_engnameplace_lo.Text
        dao_location_addr.fields.HOUSENO = txt_thacode_id_lo.Text
        dao_location_addr.fields.thabuilding = txt_thabuilding_lo.Text
        dao_location_addr.fields.thafloor = txt_thafloor_lo.Text
        dao_location_addr.fields.tharoom = txt_tharoom_lo.Text
        dao_location_addr.fields.thaaddr = txt_thaaddr_lo.Text
        dao_location_addr.fields.thamu = txt_thamu_lo.Text
        dao_location_addr.fields.thasoi = txt_thasoi_lo.Text
        dao_location_addr.fields.tharoad = txt_tharoad_lo.Text
        dao_location_addr.fields.zipcode = txt_zipcode_lo.Text
        If txt_tel_lo.Text = "" Then
            dao_location_addr.fields.tel = "-"
        Else
            dao_location_addr.fields.tel = txt_tel_lo.Text
        End If

        If txt_mobile_lo.Text = "" Then
            dao_location_addr.fields.Mobile = "-"
        Else
            dao_location_addr.fields.Mobile = txt_mobile_lo.Text
        End If
        If txt_fax_lo.Text = "" Then
            dao_location_addr.fields.fax = "-"
        Else
            dao_location_addr.fields.fax = txt_fax_lo.Text
        End If


        dao_location_addr.fields.chngwtcd = chngwtcd
        dao_location_addr.fields.amphrcd = amphrcd
        dao_location_addr.fields.thmblcd = thmblcd
        dao_location_addr.fields.thachngwtnm = ddl_chngwt.SelectedItem.Text
        dao_location_addr.fields.thaamphrnm = ddl_amphr.SelectedItem.Text
        dao_location_addr.fields.thathmblnm = ddl_thumbol.SelectedItem.Text

        dao_syschngwt.GetData_by_chngwtcd(chngwtcd)
        dao_sysamphr.GetData_by_chngwtcd_amphrcd(chngwtcd, amphrcd)
        dao_systhmbl.GetData_by_chngwtcd_amphrcd_thmblcd(chngwtcd, amphrcd, thmblcd)

        dao_location_addr.fields.engchngwtnm = dao_syschngwt.fields.engchngwtnm
        dao_location_addr.fields.engamphrnm = dao_sysamphr.fields.engamphrnm
        dao_location_addr.fields.engthmblnm = dao_systhmbl.fields.engthmblnm

        dao_location_addr.fields.LOCATION_TYPE_ID = rdl_place_type.SelectedValue
        Try
            If txt_latitude.Text = "" Then
                dao_location_addr.fields.longitude = 0
            Else
                dao_location_addr.fields.latitude = txt_latitude.Text
            End If
            If txt_longitude.Text = "" Then
                dao_location_addr.fields.longitude = 0
            Else
                dao_location_addr.fields.longitude = txt_longitude.Text
            End If


        Catch ex As Exception

        End Try


        dao_location_addr.update()
        Response.Write("<script type='text/javascript'>alert('แก้ไขข้อมูลเรียบร้อยแล้ว');</script> ")
        Response.Write("</script type >")
    End Sub

    Protected Sub bnt_submit_Click(sender As Object, e As EventArgs) Handles bnt_submit.Click
        Dim Bit As Integer
        Bit = Forbidden_Word()
        If Bit <> 1 Then
            If _IDA <> "" Then
                edit()
            Else
                Dim dao_location_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                Dim Process_TB As String = "10100"
                Dim TR_ID As String = ""
                Dim bao_tran As New BAO_TRANSECTION

                TR_ID = bao_tran.insert_transection(Process_TB)
                If UC_ATTACH_LCN.CHK_Extension = 0 Then
                    If UC_ATTACH_LCN.CHK_upload_file = 1 Then
                        save(TR_ID)
                        dao_location_addr.GetDataby_TR_ID(TR_ID)
                        Dim Year As String
                        Year = con_year(Date.Now.Year)
                        UC_ATTACH_LCN.ATTACH_LCT(dao_location_addr.fields.IDA, dao_location_addr.fields.TR_ID, Process_TB, Year, "1")

                    Else
                        Response.Write("<script type='text/javascript'>alert('กรุแนบไฟล์ PDF');</script> ")
                    End If
                Else
                    Response.Write("<script type='text/javascript'>alert('กรุแนบไฟล์ PDF');</script> ")
                End If
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกตรวจสอบชื่อสถานที่ ');", True)
        End If
    End Sub

    Private Sub btn_send_Click(sender As Object, e As EventArgs) Handles btn_send.Click
        Try
            Dim dao_location_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            dao_location_addr.GetDataby_IDA(_IDA)
            Dim up_edit As String = ""
            Dim dao_a As New DAO_DRUG.TB_FILE_ATTACH_LOCATION
            dao_a.GetDataby_TR_ID(dao_location_addr.fields.TR_ID)
            Dim IDA_UP As Integer = 0
            IDA_UP = dao_a.fields.IDA
            If IDA_UP = 0 Then
                Response.Write("<script type='text/javascript'>alert('กรุณาอัพโหลดเอกสารแนบก่อนส่งเรื่อง');</script> ")
                Response.Write("</script type >")
            Else
                dao_location_addr.fields.STATUS_ID = 2
                dao_location_addr.fields.SENT_DATE = Date.Now
                dao_location_addr.update()
                Response.Write("<script type='text/javascript'>alert('ส่งเรื่องเรียบร้อยแล้ว'); parent.close_modal();</script> ")
                Response.Write("</script type >")
            End If
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('กรุณาอัพโหลดเอกสารแนบก่อนส่งเรื่อง');</script> ")
            Response.Write("</script type >")
        End Try


    End Sub

    Protected Sub btn_hno_Click(sender As Object, e As EventArgs) Handles btn_hno.Click
        Dim houseno As String = ""
        houseno = txt_thacode_id_lo.Text

        If houseno = "" Then
            'alert_normal("กรุณาระบุรหัสประจำบ้าน")
            Response.Write("<script type='text/javascript'>alert('กรุณาระบุรหัสประจำบ้าน');</script> ")
            Response.Write("</script type >")
        Else
            Try
                Dim ws As New WS_Taxno_TaxnoAuthorize.WebService1
                Dim obj As New WS_Taxno_TaxnoAuthorize.HOUSENO
                obj = ws.getDetail_Houseno_by_addressID(houseno)

                'txt_houseno.Text = obj.AddressID
                txt_thaaddr_lo.Text = obj.Address_No
                'txt_thabuild.Text = ""
                'txt_thafloor.Text = ""
                txt_thamu_lo.Text = obj.Address_Moo
                txt_thasoi_lo.Text = obj.Address_Soi
                txt_tharoad_lo.Text = obj.Address_Road
                txt_zipcode_lo.Text = obj.PostCode
                Lb_tel_lo.Text = obj.Tel01
                txt_fax_lo.Text = ""

                ddl_chngwt.DropDownSelectText(obj.Address_Province)
                amphrcd()
                ddl_amphr.DropDownSelectText(obj.Address_Amphur)
                thmblcd()
                ddl_thumbol.DropDownSelectText(obj.Address_Tumbol)
            Catch ex As Exception
                Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
                Response.Write("</script type >")
            End Try

            'lb_ampr_ws.Text = obj.Address_Amphur
            'lb_thmbl_ws.Text = obj.Address_Tumbol
            'lb_chngwt_ws.Text = obj.Address_Province
        End If
    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        Dim dao_location_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim Process_TB As String = "10100"
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim Year As String
        Dim up_edit As String = ""

        Dim dao_a As New DAO_DRUG.TB_FILE_ATTACH_LOCATION
            dao_location_addr.GetDataby_IDA(_IDA)
            Dim get_tr As Integer = 0
            Try
                get_tr = dao_location_addr.fields.TR_ID
            Catch ex As Exception
                get_tr = 0
            End Try

            If get_tr <> 0 Then
                Year = con_year(Date.Now.Year)
                UC_ATTACH_LCN.ATTACH_LCT_UPDATE(_IDA, get_tr, Process_TB, Year, "1")

                dao_a.GetDataby_TR_ID(TR_ID)
                If dao_a.fields.IDA <> 0 Then
                    img_cf.Visible = True
                    img_not.Visible = False
                    lbl_upload_file.Text = dao_a.fields.NAME_REAL
                End If
            Else
                TR_ID = bao_tran.insert_transection(Process_TB)
                dao_location_addr.fields.TR_ID = TR_ID
                dao_location_addr.update()

                dao_location_addr.GetDataby_TR_ID(TR_ID)
                Year = con_year(Date.Now.Year)
                UC_ATTACH_LCN.ATTACH_LCT(_IDA, TR_ID, Process_TB, Year, "1")

                dao_a.GetDataby_TR_ID(TR_ID)
                If dao_a.fields.IDA <> 0 Then
                    img_cf.Visible = True
                    img_not.Visible = False
                    lbl_upload_file.Text = dao_a.fields.NAME_REAL
                End If
            End If
            'TR_ID = bao_tran.insert_transection(Process_TB)
            'dao_location_addr.fields.TR_ID = get_tr
            'dao_location_addr.update()
            'dao_location_addr.GetDataby_TR_ID(TR_ID)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แนบไฟล์เรียบร้อยแล้ว');", True)
        '    Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri & "&IDA=" & dao_location_addr.fields.IDA)

    End Sub
    Public Function Forbidden_Word()
        Dim Bit As Integer
        Dim Word As String = ""
        Word = txt_thanameplace_lo.Text
        Dim dt As DataTable
        Dim dt_eng As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        dt = bao.SP_MAS_FORBIDDEN_WORD_THAI(Word)
        For Each dr As DataRow In dt.Rows
            If txt_thanameplace_lo.Text.ToString.Contains(dr("WORD_THAI")) Then
                lbl_word_thai.Visible = True
                lbl_word_thai.Text = dr("WORD_THAI_CONDITION")
                Bit = 1
            End If
        Next
        dt_eng = bao.SP_MAS_FORBIDDEN_WORD_ENG(Word)
        For Each dr As DataRow In dt_eng.Rows
            If txt_engnameplace_lo.Text.ToString.Contains(dr("WORD_ENG")) Then
                lbl_word_eng.Visible = True
                lbl_word_eng.Text = dr("WORD_ENG_CONDITION")
                Bit = 1
            End If
        Next
        Return Bit
    End Function
    Protected Sub txt_thanameplace_lo_TextChanged(sender As Object, e As EventArgs) Handles txt_thanameplace_lo.TextChanged
        Dim Bit As Integer = 0
        Dim Word As String = ""
        Word = txt_thanameplace_lo.Text
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        dt = bao.SP_MAS_FORBIDDEN_WORD_THAI(Word)
        For Each dr As DataRow In dt.Rows
            If txt_thanameplace_lo.Text.ToString.Contains(dr("WORD_THAI")) Then
                lbl_word_thai.Visible = True
                lbl_word_thai.Text = dr("WORD_THAI_CONDITION")
                Bit = 1
            End If
        Next
        If Bit <> 1 Then
            lbl_word_thai.Visible = False
        End If
    End Sub

    Protected Sub txt_engnameplace_lo_TextChanged(sender As Object, e As EventArgs) Handles txt_engnameplace_lo.TextChanged
        Dim Bit As Integer = 0
        Dim Word As String = ""
        Word = txt_engnameplace_lo.Text
        Dim dt_eng As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        dt_eng = bao.SP_MAS_FORBIDDEN_WORD_ENG(Word)
        For Each dr As DataRow In dt_eng.Rows
            If txt_engnameplace_lo.Text.ToString.Contains(dr("WORD_ENG")) Then
                lbl_word_eng.Visible = True
                lbl_word_eng.Text = dr("WORD_ENG_CONDITION")
                Bit = 1
            End If
        Next
        If Bit <> 1 Then
            lbl_word_eng.Visible = False
        End If
    End Sub
End Class