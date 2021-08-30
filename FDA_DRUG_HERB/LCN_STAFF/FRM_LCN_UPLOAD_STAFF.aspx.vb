Public Class FRM_LCN_UPLOAD_STAFF
    Inherits System.Web.UI.Page


    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private _pvncd As Integer
    Private b64 As String
    Private _iden As String
    Private _lct_ida As String
    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _lct_ida = Request.QueryString("lct_ida")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _iden = Request.QueryString("identify")
            _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        set_data()
        If Not IsPostBack Then
            load_GV_lcnno()
        End If
    End Sub
    Sub set_data()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Try
            'rdl_person_type.SelectedValue = dao.fields.TYPE_PERSON
            lbl_type_person.Text = dao.fields.TYPE_PERSON_NAME
        Catch ex As Exception

        End Try

        Try

            lbl_type_bsn.Text = dao.fields.TYPE_BSN_NAME
        Catch ex As Exception

        End Try

        Try
            'If dao.fields.TYPE_LOCAL_NAME <> "" Then
            '    Panel_Type_Local.Style.Add("display", "block")
            'Else
            '    Panel_Type_Local.Style.Add("display", "none")
            'End If
            lbl_type_local.Text = dao.fields.TYPE_LOCAL_NAME

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()                             'เรียกฟังก์ชั่น  load_GV_lcnno   มาใช้งาน
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        'Dim bao_show As New BAO_SHOW
        'Dim _bao As New BAO.ClsDBSqlcommand
        'Dim dt_lcn As New DataTable
        'dt_lcn = _bao.SP_Lisense_Name_and_Addr(_iden)

        'If e.CommandName = "sel" Then
        '    dao.GetDataby_IDA(str_ID)
        '    Dim tr_id As String = 0
        '    Try
        '        tr_id = dao.fields.TR_ID
        '    Catch ex As Exception

        '    End Try
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&Process=" & _ProcessID & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "');", True)

        'End If
    End Sub
    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_Select As HyperLink = DirectCast(e.Row.FindControl("btn_Select"), HyperLink) 'สร้าง HyperLink จำลองแทน HyperLink ของแต่ละ row 
            Dim index As Integer = e.Row.RowIndex 'เลขที่ลำดับของแต่ละ row
            Dim str_ID As String = GV_lcnno.DataKeys.Item(index).Value.ToString() 'ดึง DataKeys ของแต่ละ row มาเก็บใน str_ID
            'Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH 'เรียกใช้classตารางไฟล์แนบ
            Dim dao As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao.GetDataby_IDA(str_ID) 'ดึงข้อมูลโดยการ where IDA ที่ใช้เป็น DataKeys ของแต่ละ row 
            btn_Select.NavigateUrl = "~\PDF\FRM_ATTACH_PREVIEW_ALL.aspx\" & dao.fields.NAME_FAKE 'ระบุ URL ของ HyperLink ในแต่ละ row โดยส่งชื่อไฟล์เพื่อเพื่อหาไฟล์PDFที่ต้องการแสดง
        End If
    End Sub
    Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_FK_IDA(_IDA)


        GV_lcnno.DataSource = dt               'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&Process=" & _ProcessID & "&lct_ida=" & _lct_ida & "&identify=" & _iden)
        ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&Process=" & _ProcessID & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "');", True)
    End Sub
End Class