﻿
Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
    Imports Telerik.Web.UI
    Public Class POPUP_TABEAN_NEW_EDIT_STAFF_INTAKE_EDIT
        Inherits System.Web.UI.Page

        Private _CLS As New CLS_SESSION
        Private _IDA As String
        Private _TR_ID As String
        Private _Process_ID As String
        Private _IDA_LCN As String
        Private _IDA_DR As String

        Sub RunSession()
            _Process_ID = Request.QueryString("process_id")
            _IDA = Request.QueryString("IDA")
            Try
                _CLS = Session("CLS")
            Catch ex As Exception
                Response.Redirect("http://privus.fda.moph.go.th/")
            End Try
        End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data()
            bind_dd()
            bind_mas_staff()
            bind_mas_cancel()
            BIND_PDF_TABEAN()

            UC_ATTACH1.NAME = "เอกสารแนบยกเลิกคำขอ"
            UC_ATTACH1.BindData("เอกสารแนบยกเลิกคำขอ", 1, "pdf", "0", "77")

            UC_ATTACH2.NAME = "เอกสาร ทบ.3"
            UC_ATTACH2.BindData("เอกสาร ทบ.3", 1, "pdf", "0", "14")
        End If
    End Sub
    Public Sub bind_data()
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
            dao.GetdatabyID_IDA(_IDA)
        'If dao.fields.STATUS_ID = 6 Then
        '    KEEP_PAY.Visible = False
        '    btn_sumit.Visible = False
        '    btn_keep_pay.Visible = True
        'Else
        If dao.fields.STATUS_ID = 3 Then
            KEEP_PAY.Visible = True
            btn_sumit.Visible = True
            btn_keep_pay.Visible = False
        Else
            KEEP_PAY.Visible = True
            btn_sumit.Visible = True
            btn_keep_pay.Visible = False
        End If
        If dao.fields.STATUS_UPLOAD_ID >= 2 Then
            AT_FILE_Edit.Visible = True
            txt_edit_staff.Text = dao.fields.NOTE_EDIT
            STAFF_NAME.Text = dao.fields.EDIT_RQ_NAME
            Try
                txt_edit_date.Text = date_to_thai(dao.fields.EDIT_RQ_DATE)
            Catch ex As Exception

            End Try
        End If
        DATE_REQ.Text = Date.Now.ToString("dd/MM/yyyy")
            lbl_create_by.Text = dao.fields.CREATE_BY
            Try
                lbl_create_date.Text = dao.fields.CREATE_DATE
            Catch ex As Exception

            End Try
        End Sub

        Public Sub bind_mas_cancel()
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
            dao.GetdatabyID_IDA(_IDA)
            Dim dt As DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_dd
            If dao.fields.STATUS_ID = 2 Then
                dt = bao.SP_MAS_DDL_STAFF_REMARK_CANCEL()
                DDL_CANCLE_REMARK.DataValueField = "remark_cancle_id"
                DDL_CANCLE_REMARK.DataTextField = "remark_cancle_name"
            Else
                dt = bao.SP_MAS_DDL_SECTION_CANCEL()
                DDL_CANCLE_REMARK.DataValueField = "DDL_ID"
                DDL_CANCLE_REMARK.DataTextField = "DDL_NAME"
            End If
            DDL_CANCLE_REMARK.DataSource = dt
            DDL_CANCLE_REMARK.DataBind()
            DDL_CANCLE_REMARK.Items.Insert(0, "-- กรุณาเลือก --")
        End Sub
        Sub BIND_PDF_TABEAN()
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
            dao.GetdatabyID_IDA(_IDA)
            _IDA_LCN = dao.fields.FK_LCN_IDA
            Dim XML As New CLASS_GEN_XML.TABEAN_NEW_EDIT
            TBN_NEW_EDIT = XML.GEN_XML_TABEAN_NEW_EDIT(_IDA, _IDA_LCN)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_Process_ID, dao.fields.STATUS_ID, "ทบ3", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EDIT") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", _Process_ID, Date.Now.Year, _IDA)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", _Process_ID, Date.Now.Year, _IDA)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _Process_ID, PATH_PDF_OUTPUT)

            _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
            _CLS.PDFNAME = PATH_PDF_OUTPUT
            _CLS.FILENAME_XML = Path_XML

            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        End Sub

        Public Sub bind_mas_staff()
            Dim dt As DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_dd
            dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataValueField = "IDA"
        DD_OFF_REQ.DataTextField = "STAFF_NAME"
        DD_OFF_REQ.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-- กรุณาเลือก --"
        item.Value = "0"
        DD_OFF_REQ.Items.Insert(0, item)
    End Sub

        Public Sub bind_dd()

            Dim dt As New DataTable
            Dim bao As New BAO.ClsDBSqlcommand
            Dim int_group_ddl1 As Integer = 0
            Dim int_group_ddl2 As Integer = 0
            Dim status_id1 As Integer = 0
            Dim dao_sub As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
            dao_sub.GetdatabyID_IDA(Request.QueryString("IDA"))

            status_id1 = dao_sub.fields.STATUS_ID
        If status_id1 = 19 Then
            int_group_ddl1 = 6
            int_group_ddl2 = 0
        ElseIf status_id1 = 20 Then
            int_group_ddl1 = 7
            int_group_ddl2 = 0
        End If
        dt = Get_DDL_DATA(204, int_group_ddl1, int_group_ddl2)

            DD_STATUS.DataSource = dt
            DD_STATUS.DataValueField = "STATUS_ID"
            DD_STATUS.DataTextField = "STATUS_NAME_STAFF"
            DD_STATUS.DataBind()

        End Sub
        Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
            'Dim dt As New DataTable
            Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
            Dim dta As New DataTable
            Dim bao As New BAO.ClsDBSqlcommand
            dta = bao.Queryds(sql)
            Return dta
        End Function
        Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
            dao.GetdatabyID_IDA(_IDA)
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue

            If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกสถานะ หรือเจ้าหน้าที่รับผิดชอบ');", True)
            Else
                If dao.fields.STATUS_ID = 12 Then

                '_Process_ID = DD_PROCESS_ID.SelectedValue
                dao.fields.rcv_StaffID = DD_OFF_REQ.SelectedValue
                        dao.fields.rcv_StaffName = DD_OFF_REQ.SelectedItem.Text
                        dao.fields.rcvdate = Date.Now

                If dao.fields.RCVNO_NEW = "" Then

                    Dim bao As New BAO.GenNumber
                    Dim RCVNO As String = ""
                    Dim RCVNO_HERB_NEW As String = ""
                    'Dim pvncd As String = dao.fields.pvncd
                    Dim pvncd As String = 10

                    RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), pvncd, _Process_ID, _IDA)
                    Dim TR_ID As String = dao.fields.TR_ID
                    Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
                    RCVNO_HERB_NEW = bao.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, _Process_ID, _IDA)
                    Dim RCVNO_FULL As String = "HB" & " " & pvncd & "-" & _Process_ID & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
                    dao.fields.RCVNO_NEW = RCVNO_FULL
                    dao.fields.rcvno = RCVNO
                End If
            ElseIf dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 10 Then
                    dao.fields.NOTE_CANCEL = NOTE_CANCLE.Text
                    Try
                        dao.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
                        dao.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
                    Catch ex As Exception

                    End Try
                    UC_ATTACH1.insert_TBN_EDIT(_TR_ID, _Process_ID, dao.fields.IDA, 77)
                End If
                dao.Update()
                AddLogStatus(dao.fields.STATUS_ID, _Process_ID, _CLS.CITIZEN_ID, _IDA)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            End If


        End Sub
        Sub alert_nature(ByVal text As String)
            Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
        End Sub
        Sub alert_summit(ByVal text As String)
            Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
        End Sub
        Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
            If DD_STATUS.SelectedValue = 9 Or DD_STATUS.SelectedValue = 7 Or DD_STATUS.SelectedValue = 10 Or DD_STATUS.SelectedValue = 5 Or DD_STATUS.SelectedValue = 78 Then
                p2.Visible = True
                P12.Visible = False
            Else
                p2.Visible = False
                P12.Visible = True
            End If
        End Sub

        Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
            RadGrid1.DataSource = bind_data_uploadfile()
        End Sub
        Function bind_data_uploadfile()
            Dim dt As DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_main
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
            dao.GetdatabyID_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, dao.fields.STATUS_UPLOAD_ID, _Process_ID, _IDA)

        Return dt
        End Function

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW_EDIT/FRM_HERB_TABEAN_NEW_EDIT_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub
    Public Function date_to_thai(ByVal _date As Date)
        Dim dateD_TH As String = ""
        Dim dateM_TH As String = ""
        Dim dateY_TH As String = ""
        Dim dateD As Date
        Dim dateM As Date
        Dim dateY As Date
        Dim date_FULL As String = ""
        Try
            _date = _date
            _date = CDate(_date).ToString("dd/MM/yyy")
            dateD = _date
            dateM = _date
            dateY = _date

            dateD_TH = dateD.Day.ToString()
            dateM_TH = dateM.ToString("MMMM")
            dateY_TH = con_year(dateY.Year)
            date_FULL = dateD_TH & " " & dateM_TH & " " & dateY_TH
        Catch ex As Exception

        End Try

        Return date_FULL
    End Function
    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile3()
    End Sub
    Function bind_data_uploadfile3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
        Catch ex As Exception
            STATUS_UPLOAD_ID = 1
        End Try

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, 22, dao.fields.PROCESS_ID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_NEW_EDIT_STAFF_PREVIEW.aspx?ida=" & IDA

        End If
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile2()
    End Sub
    Function bind_data_uploadfile2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
        Catch ex As Exception
            STATUS_UPLOAD_ID = 1
        End Try

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, 3, dao.fields.PROCESS_ID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_NEW_EDIT_STAFF_PREVIEW.aspx?ida=" & IDA

        End If
    End Sub
End Class