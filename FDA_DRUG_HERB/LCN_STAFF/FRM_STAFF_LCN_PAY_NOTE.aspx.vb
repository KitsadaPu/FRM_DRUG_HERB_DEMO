﻿Public Class FRM_STAFF_LCN_PAY_NOTE
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private STATUS_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            STATUS_ID = Request.QueryString("STATUS_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            ' _type = "1"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub


    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        'Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer

        dao.GetDataby_IDA(_IDA)
        dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Dim LCNNO_V2 As Integer
        Dim bao2 As New BAO.GenNumber
        Dim RCVNO_HERB_NEW As Integer
        dao.fields.STATUS_ID = STATUS_ID
        RCVNO = BAO.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
        dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

        RCVNO_HERB_NEW = bao2.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)

        Dim _year As Integer = con_year(Date.Now.Year)
        If _year < 2500 Then
            _year += 543
        End If

        dao.fields.RCVNO_DISPLAY = BAO.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
        Try
            dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        LCNNO_V2 = con_year(Date.Now.Year).Substring(2, 2) & RCVNO_HERB_NEW

        dao.fields.RCVNO_NEW = "HB " & _CLS.PVCODE & "-" & PROCESS_ID & "-" & con_year(Date.Now.Year).Substring(2, 2) & "-" & RCVNO_HERB_NEW

        dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
        'dao.fields.frtappdate = Date.Now
        AddLogStatus(3, PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
        dao.update()


        If Len(TextBox1.Text) >= 10 Then
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = STATUS_ID
            dao.fields.comment = TextBox1.Text
            dao.fields.frtappdate = Date.Now
            dao.update()

            Dim cls_sop As New CLS_SOP
            cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", dao.fields.PROCESS_ID, _CLS.PVCODE, 8, "บันทึกการชำระเงินค่าคำขอ", "SOP-DRUG-10-" & dao.fields.PROCESS_ID & "-11", "บันทึกการชำระเงินค่าคำขอ", "เจ้าหน้าที่บันทึกการชำระเงินค่าคำขอ", "STAFF", _TR_ID, SOP_STATUS:="บันทึกการชำระเงินค่าคำขอ")

            alert("บันทึกข้อมูบเรียบร้อยแล้ว")
        Else
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูล');</script> ")
        End If

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub
End Class