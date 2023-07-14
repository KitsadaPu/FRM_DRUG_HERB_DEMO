Public Class POPUP_TABEAN_OLD_TO_TABEAN_WHO
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As Integer
    Private _IDEN As String
    Private _IDA As String
    Private _RGTNO_DISPAY As String
    Private _STATUS_ID As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")
        _IDA = Request.QueryString("IDA") 'IDA ตาาราง drrgt
        _RGTNO_DISPAY = Request.QueryString("RGTNO_DISPAY") 'IDA ตาาราง drrgt
        _STATUS_ID = Request.QueryString("STATUS_ID")
        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
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
        If Not IsPostBack Then
            bind_data()
        End If
    End Sub
    Sub bind_data()
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_g.GetDataby_IDA(_IDA)
        dao_lcn.GetDataby_IDA(dao_g.fields.FK_LCN_IDA)
        txt_name_request.Text = Get_FullName(dao_g.fields.IDENTIFY)
        txt_THANM.Text = Get_FullName(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)
        txt_RGTNO_NEW.Text = _RGTNO_DISPAY
        txt_NAME_THAI.Text = dao_g.fields.thadrgnm
        txt_NAME_ENG.Text = dao_g.fields.engdrgnm
        dao_pro.GetDataby_Process_ID(dao_lcn.fields.PROCESS_ID)
        txt_type_lcn.Text = dao_pro.fields.PROCESS_NAME
    End Sub
    Function Get_FullName(ByVal citizen_id As String)
        'Dim citizen_id As String = dao_g.fields.IDENTIFY
        Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
        Dim obj As New XML_DATA
        Dim result As String = ""
        Dim FullName As String = ""
        result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
        obj = ConvertFromXml(Of XML_DATA)(result)
        Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
        If TYPE_PERSON = 1 Then
            FullName = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
        ElseIf TYPE_PERSON = 99 Then
            FullName = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
        Else
            If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                FullName = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            Else
                FullName = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
            End If
        End If
        Return FullName
    End Function
    Protected Sub BTN_SEARCH_TN_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_TN.Click
        Dim dao As New DAO_CPN.TB_syslcnsnm
        If TXT_SEARCH_TN.Text IsNot Nothing Then
            Dim citizen_id As String = TXT_SEARCH_TN.Text
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Try
                Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
                If TYPE_PERSON = 1 Then
                    txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                ElseIf TYPE_PERSON = 99 Then
                    txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                Else
                    If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                        txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    Else
                        txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    End If
                End If
                lbl_name_request.Visible = False
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End Try
        Else
            lbl_name_request.Visible = True
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขบัตรประชาชน หรือเลขนิติ');", True)
        End If
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If _STATUS_ID = 8 Then
            Dim dao_g As New DAO_DRUG.ClsDBdrrgt
            dao_g.GetDataby_IDA(_IDA)
            Dim dao_q As New DAO_DRUG.ClsDBdrrqt
            dao_q.GetDataby_IDA(dao_g.fields.FK_DRRQT)
            Dim dt As New DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_main
            dt = bao.SP_TRANSFER_DRR_TO_TABEAN_HERB(_IDA)
            For Each dr As DataRow In dt.Rows
                With dao_q.fields
                    .PROCESS_ID = dr("PROCESS_ID")
                    .RGTNO_NEW = _RGTNO_DISPAY
                    .WHO_ID = 1
                    .CITIZEN_ID_AUTHORIZE = TXT_SEARCH_TN.Text
                    .IDENTIFY = TXT_SEARCH_TN.Text
                    .CTZNO = _CLS.CITIZEN_ID
                End With
                With dao_g.fields
                    .PROCESS_ID = dr("PROCESS_ID")
                    '.RGTNO_NEW = _RGTNO_DISPAY
                    '.WHO_ID = 1
                    .IDENTIFY = TXT_SEARCH_TN.Text
                End With
            Next
            dao_q.update()
            bind_data()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลแล้ว');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ทะเบียนยังไม่ได้รับการอนุมัติ');", True)
        End If

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class