﻿Imports Telerik.Web.UI
Public Class POPUP_STAFF_LCN_SUBTITUTE_CONSIDER
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            ' _type = "1"
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            TextBox1.Text = Date.Now.ToShortDateString()
            'txt_app_date.Text = Date.Now.ToShortDateString()
            default_Remark()
            Bind_ddl_staff_offer()
            Bind_ddl_staff_position()
        End If
    End Sub
    Private Sub default_Remark()
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD

        'dao.GetDataby_IDA(_IDA)
        'dao_up.GetDataby_IDA(dao.fields.TR_ID)

        'Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
        'Dim GROUP_TYPE As String = dao.fields.GROUP_TYPE
        'If PROCESS_ID = 14200053 And GROUP_TYPE = "2" Then
        '    Txt_Remark.Text = ""
        'End If



    End Sub
    Public Sub Bind_ddl_staff_offer()
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim dt As New DataTable
        'bao.SP_STAFF_OFFER_DDL()

        ''ddl_staff_offer.DataSource = bao.dt
        ''ddl_staff_offer.DataBind()
        'rcb_staff_offer.DataSource = bao.dt
        'rcb_staff_offer.DataBind()


        Dim dao As New DAO_DRUG.TB_MAS_STAFF_NAME_HERB
        dao.GetDataby_All()
        'Dim item As New ListItem("---กรุณาเลือก---", "0")

        rcb_staff_offer.DataSource = dao.datas 'dao.datas
        rcb_staff_offer.DataTextField = "STAFF_NAME"
        rcb_staff_offer.DataValueField = "IDA"
        rcb_staff_offer.DataBind()
        Dim item As New RadComboBoxItem
        item.Text = "---กรุณาเลือก---"
        item.Value = "0"
        rcb_staff_offer.Items.Insert(0, item)
    End Sub
    Public Sub Bind_ddl_staff_position()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao.SP_STAFF_POSITION_NAME()

        ddl_staff_position.DataSource = bao.dt
        ddl_staff_position.DataBind()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Dim bao As New BAO.GenNumber

            dao.Getdata_by_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)

            AddLogStatus(6, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)

            Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID

            'Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
            'dao_p.GetDataby_PROCESS_ID(PROCESS_ID)
            'Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

            Dim CONSIDER_DATE As Date = CDate(TextBox1.Text)

            '--------------------------------
            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                'dao_cpn.GetData_by_chngwtcd(dao.fields.pvncd)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try

            dao.fields.REMARK = Txt_Remark.Text
            'dao.fields.STATUS_ID = 11  'ข้ามจ่ายเงิน
            dao.fields.STATUS_ID = 5
            dao.fields.CONSIDER_DATE = CONSIDER_DATE
            dao.fields.POSITION_NAME1 = txt_position1.Text
            dao.fields.STAFF_SIGN_IDA = rcb_staff_offer.SelectedValue
            Dim dao_mas As New DAO_DRUG.TB_MAS_STAFF_OFFER
            Try
                dao_mas.GetDataby_IDA(rcb_staff_offer.SelectedValue)
                dao.fields.STAFF_SIGN_IDEN = dao_mas.fields.INSERT_CITIZEN
            Catch ex As Exception

            End Try
            dao.fields.POSITION_NAME2 = ddl_staff_position.SelectedValue
            Try
                'dao.fields.appdate = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.update()
            alert("บันทึกข้อมูลเรียบร้อย")
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_STAFF_LCN_SUBSTITUTE_CONFIRM.aspx.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_STAFF_LCN_SUBSTITUTE_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub
End Class