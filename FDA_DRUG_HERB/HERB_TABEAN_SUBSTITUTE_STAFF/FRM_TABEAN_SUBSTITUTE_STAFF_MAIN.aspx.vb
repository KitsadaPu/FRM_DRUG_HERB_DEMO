﻿Imports Telerik.Web.UI

Public Class FRM_TABEAN_SUBSTITUTE_STAFF_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _rgt_ida As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            '_rgt_ida = Request.QueryString("rgt_ida")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            '_process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            '_lct_ida = Request.QueryString("lct_ida")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Dim PROCESS_ID As Integer = 0
            Dim IDA_DR As Integer = 0
            Dim IDA_LCN As Integer = 0
            Dim STATUS_ID As Integer = 0
            Dim TR_ID As Integer = 0
            Try
                IDA = item("IDA").Text
                PROCESS_ID = item("PROCESS_ID").Text
                IDA_DR = item("IDA_DR").Text
                IDA_LCN = item("FK_LCN").Text
                STATUS_ID = item("STATUS_ID").Text
                TR_ID = item("TR_ID").Text
            Catch ex As Exception

            End Try
            'Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
            'dao.GetDatabyIDA(IDA)
            'Dim tr_id As String = 0
            'Try
            '    tr_id = dao.fields.TR_ID
            'Catch ex As Exception

            'End Try
            'Dim tebean_ida As Integer = 0
            'Try
            '    tebean_ida = dao.fields.FK_IDA
            'Catch ex As Exception

            'End Try
            'Dim _process_id As Integer = 0

            'Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            'Try
            '    dao_tr.GetDataby_IDA(tr_id)
            '    _process_id = dao_tr.fields.PROCESS_ID
            'Catch ex As Exception

            'End Try
            If e.CommandName = "sel" Then
                If STATUS_ID = 11 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_SUBSTITUTE_STAFF_EDIT.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&IDA_DR=" & IDA_DR & "&IDA_LCN=" & IDA_LCN & "&TR_ID=" & TR_ID & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_SUBSTITUTE_STAFF_CONFIRM.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&IDA_DR=" & IDA_DR & "&IDA_LCN=" & IDA_LCN & "');", True)
                End If
                'lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_SUBSTITUTE_STAFF_CONFIRM.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&IDA_DR=" & IDA_DR & "&IDA_LCN=" & IDA_LCN & "');", True)
                'ElseIf e.CommandName = "print" Then
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_SUBSTITUTE_STAFF_PREVIEW.aspx?IDA=" & IDA & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_TABEAN_HERB_SUBNEW_STAFF()
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
End Class