Public Class UC_INFORM_DEDAIL
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA_IF As String = ""
    Private _LCNNO_DISPLAY As String = ""
    Private _PROCESS_ID As String = ""
    Private _SID As String = ""
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception

        End Try
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_IF = Request.QueryString("IDA_IF")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _SID = Request.QueryString("SID")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_dd_eatting()
            BILD_DATA()
        End If
    End Sub
    Public Sub bind_dd_eatting()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_JJ()

        DD_EATTING_ID.DataSource = dt
        DD_EATTING_ID.DataBind()
        DD_EATTING_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Sub BILD_DATA()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(_IDA_IF)
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA_IF)
        With dao_d.fields
            txt_name_thai_inform.Text = dao_d.fields.NAME_THAI
            If .NAME_ENG = "" Then
                txt_name_eng_inform.Text = "-"
            Else
                txt_name_eng_inform.Text = .NAME_ENG
            End If
            NAME_INFORM.Text = .LCN_NAME
            txt_IDEN.Text = .CITIZEN_ID_AUTHORIZE
            txt_Write_Date.Text = Date.Now
            Txt_INFORM_NO.Text = dao.fields.INFORM_NO
        End With
    End Sub
    Sub SET_DATA(ByVal dao As DAO_TABEAN_HERB.TB_TABEAN_INFORM_EDIT)
        With dao.fields
            dao.fields.WRITE_AT = Txt_Write_At.Text
            dao.fields.WRITE_DATE = txt_Write_Date.Text
            dao.fields.INFORM_NO = Txt_INFORM_NO.Text
            dao.fields.NAME_THAI = txt_name_thai_inform.Text
            dao.fields.NAME_ENG = txt_name_eng_inform.Text
            dao.fields.IDEN_INFORM = txt_IDEN.Text
        End With
    End Sub
    Sub SET_SUB_DATA(ByVal dao As DAO_TABEAN_HERB.TB_TABEAN_INFORM_EDIT_DETAIL, ByVal IDA As String)
        With dao.fields
            .FK_IDA = IDA
            .FK_LCN = _IDA_LCN
            .FK_LCT = _IDA_LCT
            .PROCESS_ID = _PROCESS_ID
            .CITIZEN_ID = _CLS.CITIZEN_ID
            .CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            .WRITE_AT = Txt_Write_At.Text
            .WRITE_DATE = txt_Write_Date.Text
            .NAME_THAI = TXT_NAME_THAI.Text
            .NAME_ENG = TXT_NAME_ENG.Text
            .INFORM_NO = Txt_INFORM_NO.Text
            .SIZE_PACK = txt_size_pack.Text
            Try
                .EATTING_ID = DD_EATTING_ID.SelectedValue
                .EATTING_NAME = DD_EATTING_ID.SelectedItem.Text
            Catch ex As Exception

            End Try
            .SIZE_USE = txt_SIZE_USE.Text
            .ACTIVEFACT = 1
        End With
    End Sub
    Sub SET_DATA_LIST(ByVal dao As DAO_TABEAN_HERB.TB_TABEAN_INFORM_EDIT_CHECK_LIST, ByVal IDA As String)
        With dao.fields
            dao.fields.FK_IDA = IDA
            dao.fields.PROCESS_ID = _PROCESS_ID
            dao.fields.NAME_ID = CB_1.Checked
            dao.fields.LOCATION_ID = CB_2.Checked
            dao.fields.PACKING_SIZE_ID = CB_3.Checked
            dao.fields.LABEL_ID = CB_4.Checked
            dao.fields.Document_ID = CB_5.Checked
            dao.fields.HOW_USE_ID = CB_6.Checked
            dao.fields.EATTING_ID = CB_7.Checked
            dao.fields.Active = 1
        End With
    End Sub
    Protected Sub CB_1_CheckedChanged(sender As Object, e As EventArgs) Handles CB_1.CheckedChanged
        If CB_1.Checked = True Then
            SUB_CB_1.Visible = True
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
            dao.GetdatabyID_IDA(_IDA_IF)
            Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
            dao_d.GetdatabyID_FK_IDA(_IDA_IF)
            With dao_d.fields
                If .NAME_THAI = "" Then
                    LABEL_NAME_THAI.Text = "-"
                Else
                    LABEL_NAME_THAI.Text = .NAME_THAI
                End If
                If .NAME_ENG = "" Then
                    LABEL_NAME_ENG.Text = "-"
                Else
                    LABEL_NAME_ENG.Text = .NAME_ENG
                End If
            End With
        Else
            SUB_CB_1.Visible = False
        End If
    End Sub
    Protected Sub CB_2_CheckedChanged(sender As Object, e As EventArgs) Handles CB_2.CheckedChanged
        If CB_2.Checked = True Then
            SUB_CB_2.Visible = True
        Else
            SUB_CB_2.Visible = False
        End If
    End Sub
    Protected Sub CB_3_CheckedChanged(sender As Object, e As EventArgs) Handles CB_3.CheckedChanged
        If CB_3.Checked = True Then
            SUB_CB_3.Visible = True
        Else
            SUB_CB_3.Visible = False
        End If
    End Sub
    Protected Sub CB_4_CheckedChanged(sender As Object, e As EventArgs) Handles CB_4.CheckedChanged
        If CB_4.Checked = True Then
            SUB_CB_4.Visible = True
        Else
            SUB_CB_4.Visible = False
        End If
    End Sub
    Protected Sub CB_5_CheckedChanged(sender As Object, e As EventArgs) Handles CB_5.CheckedChanged
        If CB_5.Checked = True Then
            SUB_CB_5.Visible = True
        Else
            SUB_CB_5.Visible = False
        End If
    End Sub
    Protected Sub CB_6_CheckedChanged(sender As Object, e As EventArgs) Handles CB_6.CheckedChanged
        If CB_6.Checked = True Then
            SUB_CB_6.Visible = True
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
            dao.GetdatabyID_IDA(_IDA_IF)
            Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
            dao_d.GetdatabyID_FK_IDA(_IDA_IF)
            With dao_d.fields
                If .SIZE_USE = "" Then
                    label_SIZE_USE.Text = "-"
                Else
                    label_SIZE_USE.Text = .SIZE_USE
                End If
            End With
        Else
            SUB_CB_6.Visible = False
        End If
    End Sub
    Protected Sub CB_7_CheckedChanged(sender As Object, e As EventArgs) Handles CB_7.CheckedChanged
        If CB_7.Checked = True Then
            SUB_CB_7.Visible = True
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
            dao.GetdatabyID_IDA(_IDA_IF)
            Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
            dao_d.GetdatabyID_FK_IDA(_IDA_IF)
            With dao_d.fields
                If .EATTING_NAME_DETAIL = "" Then
                    LABEL_EATTING.Text = "-"
                Else
                    LABEL_EATTING.Text = .EATTING_NAME_DETAIL
                End If
            End With
        Else
            SUB_CB_7.Visible = False
        End If
    End Sub
End Class