﻿Public Class FRM_STAFF_LOCATION_MOCK_MANUAL_INSERT
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
                _IDA = Request.QueryString("IDA")
                _iden = Request.QueryString("iden")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        If Not IsPostBack Then

            chngwtcd()
            If _IDA <> "" Then
                'btn_send.Style.Add("display", "block")
                bnt_submit.Style.Add("display", "none")
                loadData_by_Identify()
                Dim dao_loca_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                dao_loca_addr.GetDataby_IDA(_IDA)
                If dao_loca_addr.fields.STATUS_ID > 1 Then
                    'btn_send.Style.Add("display", "none")
                    bnt_submit.Style.Add("display", "none")
                End If
            Else
                'btn_send.Style.Add("display", "none")
                bnt_submit.Style.Add("display", "block")
            End If
        End If
    End Sub
    Function Chk_laitude(ByVal val As Double) As Integer
        Dim result As Integer = 0
        If (val >= 5.6166667 And val <= 20.4666667) Or val = 0 Then
            result = 0
        Else
            result = 1
        End If

        Return result
    End Function
    Function Chk_longitude(ByVal val As Double) As Integer
        Dim result As Integer = 0
        If (val >= 97.35 And val <= 105.6166667) Or val = 0 Then
            result = 0
        Else
            result = 1
        End If

        Return result
    End Function
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
        Dim chn As New DAO_CPN.clsDBsyschngwt
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
        Dim amp As New DAO_CPN.clsDBsysamphr
        amp.GetDataby_chngwtcd(ddl_chngwt.SelectedValue)
        ddl_amphr.DataSource = amp.datas
        ddl_amphr.DataTextField = "thaamphrnm"
        ddl_amphr.DataValueField = "amphrcd"
        ddl_amphr.DataBind()
        DropDownInsertDataFirstRow2(ddl_amphr, "-----รายชื่ออำเภอ-----", "0")
    End Sub
    Sub thmblcd()      'เป็นการนำข้อมูลในตารางใส่ DropDown  ข้อมูลตำบล
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim thm As New DAO_CPN.clsDBsysthmbl
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
    Public Sub save()

        Dim dao_location_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim dao_location_addr2 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim dao_syschngwt As New DAO_CPN.clsDBsyschngwt
        Dim dao_sysamphr As New DAO_CPN.clsDBsysamphr
        Dim dao_systhmbl As New DAO_CPN.clsDBsysthmbl

        Dim dao_syschngwt_v2 As New DAO_CPN.clsDBsyschngwt
        Dim dao_sysamphr_v2 As New DAO_CPN.clsDBsysamphr
        Dim dao_systhmbl_v2 As New DAO_CPN.clsDBsysthmbl

        Dim chngwtcd As Integer = ddl_chngwt.SelectedValue
        Dim amphrcd As Integer = ddl_amphr.SelectedValue
        Dim thmblcd As Integer = ddl_thumbol.SelectedValue

        Dim chngwtcd_v2 As Integer = ddl_chngwt.SelectedValue
        Dim amphrcd_v2 As Integer = ddl_amphr.SelectedValue
        Dim thmblcd_v2 As Integer = ddl_thumbol.SelectedValue


        If rdl_place_type.SelectedValue = "3" Then
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
            dao_location_addr.fields.tel = txt_tel_lo.Text
            dao_location_addr.fields.Mobile = txt_mobile_lo.Text
            dao_location_addr.fields.fax = txt_fax_lo.Text

            dao_location_addr.fields.chngwtcd = chngwtcd
            dao_location_addr.fields.amphrcd = amphrcd
            dao_location_addr.fields.thmblcd = thmblcd
            dao_location_addr.fields.thachngwtnm = ddl_chngwt.SelectedItem.Text
            dao_location_addr.fields.thaamphrnm = ddl_amphr.SelectedItem.Text
            dao_location_addr.fields.thathmblnm = ddl_thumbol.SelectedItem.Text
            dao_location_addr.fields.STATUS_ID = 8
            dao_syschngwt.GetData_by_chngwtcd(chngwtcd)
            dao_sysamphr.GetData_by_chngwtcd_amphrcd(chngwtcd, amphrcd)
            dao_systhmbl.GetData_by_chngwtcd_amphrcd_thmblcd(chngwtcd, amphrcd, thmblcd)

            dao_location_addr.fields.engchngwtnm = dao_syschngwt.fields.engchngwtnm
            dao_location_addr.fields.engamphrnm = dao_sysamphr.fields.engamphrnm
            dao_location_addr.fields.engthmblnm = dao_systhmbl.fields.engthmblnm

            dao_location_addr.fields.LOCATION_TYPE_ID = "1"
            dao_location_addr.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE '_iden
            dao_location_addr.fields.SYSTEM_NAME = "DRUG"
            Try
                dao_location_addr.fields.pvncd = _CLS.PVCODE
            Catch ex As Exception

            End Try
            Try
                dao_location_addr.fields.latitude = txt_latitude.Text
                dao_location_addr.fields.longitude = txt_longitude.Text
            Catch ex As Exception

            End Try
            dao_location_addr.fields.MOCK_ID = 1
            dao_location_addr.insert()
            dao_location_addr2.fields.thanameplace = txt_thanameplace_lo.Text
            dao_location_addr2.fields.engnameplace = txt_engnameplace_lo.Text
            dao_location_addr2.fields.HOUSENO = txt_thacode_id_lo.Text
            dao_location_addr2.fields.thabuilding = txt_thabuilding_lo.Text
            dao_location_addr2.fields.thafloor = txt_thafloor_lo.Text
            dao_location_addr2.fields.tharoom = txt_tharoom_lo.Text
            dao_location_addr2.fields.thaaddr = txt_thaaddr_lo.Text
            dao_location_addr2.fields.thamu = txt_thamu_lo.Text
            dao_location_addr2.fields.thasoi = txt_thasoi_lo.Text
            dao_location_addr2.fields.tharoad = txt_tharoad_lo.Text
            dao_location_addr2.fields.zipcode = txt_zipcode_lo.Text
            dao_location_addr2.fields.tel = txt_tel_lo.Text
            dao_location_addr2.fields.Mobile = txt_mobile_lo.Text
            dao_location_addr2.fields.fax = txt_fax_lo.Text

            dao_location_addr2.fields.chngwtcd = chngwtcd
            dao_location_addr2.fields.amphrcd = amphrcd
            dao_location_addr2.fields.thmblcd = thmblcd
            dao_location_addr2.fields.thachngwtnm = ddl_chngwt.SelectedItem.Text
            dao_location_addr2.fields.thaamphrnm = ddl_amphr.SelectedItem.Text
            dao_location_addr2.fields.thathmblnm = ddl_thumbol.SelectedItem.Text
            dao_location_addr2.fields.STATUS_ID = 8
            dao_syschngwt_v2.GetData_by_chngwtcd(chngwtcd)
            dao_sysamphr_v2.GetData_by_chngwtcd_amphrcd(chngwtcd, amphrcd)
            dao_systhmbl_v2.GetData_by_chngwtcd_amphrcd_thmblcd(chngwtcd, amphrcd, thmblcd)

            dao_location_addr2.fields.engchngwtnm = dao_syschngwt.fields.engchngwtnm
            dao_location_addr2.fields.engamphrnm = dao_sysamphr.fields.engamphrnm
            dao_location_addr2.fields.engthmblnm = dao_systhmbl.fields.engthmblnm

            dao_location_addr2.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE '_iden
            dao_location_addr2.fields.SYSTEM_NAME = "DRUG"
            Try
                dao_location_addr2.fields.pvncd = _CLS.PVCODE
            Catch ex As Exception

            End Try
            Try
                dao_location_addr2.fields.latitude = txt_latitude.Text
                dao_location_addr2.fields.longitude = txt_longitude.Text
            Catch ex As Exception

            End Try
            dao_location_addr2.fields.MOCK_ID = 1
            dao_location_addr2.fields.LOCATION_TYPE_ID = "2"
            dao_location_addr2.insert()
        Else
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
            dao_location_addr.fields.tel = txt_tel_lo.Text
            dao_location_addr.fields.Mobile = txt_mobile_lo.Text
            dao_location_addr.fields.fax = txt_fax_lo.Text

            dao_location_addr.fields.chngwtcd = chngwtcd
            dao_location_addr.fields.amphrcd = amphrcd
            dao_location_addr.fields.thmblcd = thmblcd
            dao_location_addr.fields.thachngwtnm = ddl_chngwt.SelectedItem.Text
            dao_location_addr.fields.thaamphrnm = ddl_amphr.SelectedItem.Text
            dao_location_addr.fields.thathmblnm = ddl_thumbol.SelectedItem.Text
            dao_location_addr.fields.STATUS_ID = 8
            dao_syschngwt_v2.GetData_by_chngwtcd(chngwtcd)
            dao_sysamphr_v2.GetData_by_chngwtcd_amphrcd(chngwtcd, amphrcd)
            dao_systhmbl_v2.GetData_by_chngwtcd_amphrcd_thmblcd(chngwtcd, amphrcd, thmblcd)

            dao_location_addr.fields.engchngwtnm = dao_syschngwt.fields.engchngwtnm
            dao_location_addr.fields.engamphrnm = dao_sysamphr.fields.engamphrnm
            dao_location_addr.fields.engthmblnm = dao_systhmbl.fields.engthmblnm

            dao_location_addr.fields.LOCATION_TYPE_ID = rdl_place_type.SelectedValue
            dao_location_addr.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE '_iden
            dao_location_addr.fields.SYSTEM_NAME = "DRUG"
            Try
                dao_location_addr.fields.pvncd = _CLS.PVCODE
            Catch ex As Exception

            End Try
            Try
                dao_location_addr.fields.latitude = txt_latitude.Text
                dao_location_addr.fields.longitude = txt_longitude.Text
            Catch ex As Exception

            End Try
            dao_location_addr.fields.MOCK_ID = 1
            dao_location_addr.insert()
        End If

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
        dao_location_addr.fields.tel = txt_tel_lo.Text
        dao_location_addr.fields.Mobile = txt_mobile_lo.Text
        dao_location_addr.fields.fax = txt_fax_lo.Text

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
            dao_location_addr.fields.latitude = txt_latitude.Text
            dao_location_addr.fields.longitude = txt_longitude.Text
        Catch ex As Exception

        End Try
        dao_location_addr.fields.MOCK_ID = 1

        dao_location_addr.update()
        Response.Write("<script type='text/javascript'>alert('แก้ไขข้อมูลเรียบร้อยแล้ว'); parent.close_modal();</script> ")
        Response.Write("</script type >")
    End Sub

    Protected Sub bnt_submit_Click(sender As Object, e As EventArgs) Handles bnt_submit.Click
        Dim val As Integer = 0
        Dim chk_val As Integer = 0
        Try
            If txt_latitude.Text = "" Then
                chk_val += 1
            End If
        Catch ex As Exception

        End Try
        Try
            If txt_longitude.Text = "" Then
                chk_val += 1
            End If
        Catch ex As Exception

        End Try
        Try
            val += Chk_laitude(txt_latitude.Text)
        Catch ex As Exception

        End Try
        Try
            val += Chk_longitude(txt_longitude.Text)
        Catch ex As Exception

        End Try

        If _IDA <> "" Then
            If chk_val = 0 Then
                If val = 0 Then
                    edit()
                Else
                    Response.Write("<script type='text/javascript'>alert('กรุณาระบุพิกัดให้ตรงตามเงื่อนไข');</script> ")
                    Response.Write("</script type >")
                End If

            Else
                Response.Write("<script type='text/javascript'>alert('กรุณาระบุพิกัดให้ตรงตามเงื่อนไข');</script> ")
                Response.Write("</script type >")
            End If

        Else
            If chk_val = 0 Then
                If val = 0 Then
                    save()
                Else
                    Response.Write("<script type='text/javascript'>alert('กรุณาระบุพิกัดให้ตรงตามเงื่อนไข');</script> ")
                    Response.Write("</script type >")
                End If
            Else
                Response.Write("<script type='text/javascript'>alert('กรุณาระบุพิกัดให้ตรงตามเงื่อนไข');</script> ")
                Response.Write("</script type >")
            End If

        End If
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
End Class