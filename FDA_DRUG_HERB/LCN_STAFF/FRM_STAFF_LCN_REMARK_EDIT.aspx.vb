﻿Public Class FRM_STAFF_LCN_REMARK_EDIT
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _STATUS_ID As String
    Private _CLS As New CLS_SESSION
    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            _STATUS_ID = Request.QueryString("STATUS_ID")

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
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = _STATUS_ID
        dao.fields.REMARK_EDIT = TextBox1.Text
        dao.update()

        Dim Year As String
        Year = con_year(Date.Now.Year)
        UC_ATTACH_LCN.ATTACH1(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "1")
        Dim cls_sop As New CLS_SOP
        ' cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", dao.fields.PROCESS_ID, _CLS.PVCODE, 8, "คืนคำขอ", "SOP-DRUG-10-" & dao.fields.PROCESS_ID & "-3", "คืนคำขอ", "เจ้าหน้าที่คืนคำขอ", "STAFF", _TR_ID, SOP_STATUS:="คืนคำขอ")

        alert("ดำเนินการเรียบร้อยแล้ว")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub
End Class