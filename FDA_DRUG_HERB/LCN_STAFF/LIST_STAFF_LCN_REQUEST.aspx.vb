Imports Telerik.Web.UI
Public Class LIST_STAFF_LCN_REQUEST
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub Search_FN()

        'Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_STAFF_LIST_LCN_REQUEST()
        'Dim dt As New DataTable
        'Try
        '    dt = bao.dt
        'Catch ex As Exception

        'End Try
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_STAFF_LIST_LCN_REQUEST()
        Dim r_result As DataRow()
        Dim str_where As String = ""
        Dim dt2 As New DataTable
        If TextBox1.Text <> "" Or TextBox2.Text <> "" Then
            If TextBox1.Text <> "" Then
                If str_where <> "" Then
                    str_where &= " and IDENTIFY ='" & TextBox1.Text & "'"
                Else
                    str_where &= " IDENTIFY = '" & TextBox1.Text & "'"
                End If
            End If
            If TextBox2.Text <> "" Then
                If str_where <> "" Then
                    str_where &= " and LCNNO_DISPLAY ='" & TextBox2.Text & "'"
                Else
                    str_where &= " LCNNO_DISPLAY = '" & TextBox2.Text & "'"
                End If
            End If
            r_result = dt.Select(str_where)

            dt2 = dt.Clone
            For Each dr As DataRow In r_result
                dt2.Rows.Add(dr.ItemArray)
            Next
            rgns.DataSource = dt2
            rgns.Rebind()
        Else
            rgns.DataSource = dt
        End If

    End Sub
    Protected Sub rgns_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgns.NeedDataSource
        Search_FN()
    End Sub

    Protected Sub rgns_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgns.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim id As String = item("IDA").Text
            Dim id_dalcn As String = item("ID_DALCN_FIX").Text
            'Dim _process As String = item("PROCESS_ID").Text
            'Dim _lct_ida As String = item("LOCATION_ADDRESS_IDA").Text
            'Dim _TRANSECTION As String = item("TRANSECTION_ID_UPLOAD").Text

            If e.CommandName = "sele" Then
                'Response.Redirect("POPUP_CONFIRM_LCN_REQUEST.aspx?IDA=" & id & "&ID_LCN=" & id_lcn & "&identify=" & _iden & "&TR_ID=" & _TRANSECTION & " &Process=" & _process & " &lct_ida=" & _lct_ida & "")
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_CONFIRM_LCN_REQUEST.aspx?IDA=" & _IDA & "&ID_LCN=" & _id_lcn & "&identify=" & _iden & "&TR_ID=" & _TR_ID & " &Process=" & _ProcessID & " &lct_ida=" & _lct_ida & "');", True)

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_STAFF_LCN_REQUEST.aspx?&ID=" & id & "&ID_DAL_FIX=" & id_dalcn & "');", True)

            End If

        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        rgns.Rebind()
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Search_FN()
    End Sub
End Class