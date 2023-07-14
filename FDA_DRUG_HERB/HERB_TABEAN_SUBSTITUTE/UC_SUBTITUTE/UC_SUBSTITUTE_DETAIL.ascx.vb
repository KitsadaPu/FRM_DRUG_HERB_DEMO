Public Class UC_SUBSTITUTE_DETAIL
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
    Private _TR_ID_DR As String = ""
    Private _PROCESS_ID_DR As String = ""
    Private _PROCESS_ID As String = ""
    Private _PROCESS_TYPE_ID As String = ""
    Private _TR_ID As String = ""

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _IDA_DR = Request.QueryString("IDA_DR")
        _TR_ID_DR = Request.QueryString("TR_ID_DR")
        _PROCESS_ID_DR = Request.QueryString("PROCESS_ID_DR")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _PROCESS_TYPE_ID = Request.QueryString("PROCESS_TYPE_ID")
        _TR_ID = Request.QueryString("TR_ID")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data_dr()
            load_ddl_sub_purpose()
        End If
    End Sub
    Public Sub bind_data_dr()
        ' _PROCESS_ID = Request.QueryString("PROCESS_ID")

        If _PROCESS_ID = "20610" Then
            'Dim dao As New DAO_DRUG.ClsDBdrrgt
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA_DR)
            'Dim dao_Q As New DAO_DRUG.ClsDBdrrqt
            Dim dao_tbn As New DAO_TABEAN_HERB.TB_TABEAN_HERB

            Try
                'dao_Q.GetDataby_IDA(dao.fields.FK_DRRQT)
                dao_tbn.GetdatabyID_FK_IDA_DQ(dao.fields.IDA)
            Catch ex As Exception

            End Try

            Dim citizen_id As String = dao.fields.IDENTIFY
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            Dim result As String = ""
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)

            Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
            If TYPE_PERSON = 1 Then
                cb_Personal_Type1.Checked = True
                txt_iden.Text = dao.fields.IDENTIFY
                txt_alternate_Old.Enabled = False
                Try
                    txt_person_age.Text = dao_tbn.fields.PERSON_AGE
                Catch ex As Exception

                End Try
                If dao_tbn.fields.NATIONALITY_PERSON_ID = 1 Then
                    txt_Nation.Text = dao_tbn.fields.NATIONALITY_PERSON
                Else
                    txt_Nation.Text = dao_tbn.fields.NATIONALITY_PERSON_OTHER
                End If
                txt_thanm.Text = dao_tbn.fields.LCN_NAME
                Try
                    txt_person_age.Text = dao_tbn.fields.PERSON_AGE
                Catch ex As Exception

                End Try
            ElseIf TYPE_PERSON = 99 Then
                txt_person_age.Enabled = False
                cb_Personal_Type2.Checked = True
                txt_alternate.Text = dao_tbn.fields.AGENT_99
                If IsNothing(dao_tbn.fields.PERSON_AGE) = False Then
                    txt_alternate_Old.Text = dao_tbn.fields.PERSON_AGE
                End If
                txt_idenAlternate.Text = dao_tbn.fields.IDEN_AGENT_99
                txt_idenNiti.Text = dao.fields.IDENTIFY
                txt_NitiName.Text = dao_tbn.fields.LCN_NAME
                    If dao_tbn.fields.NATIONALITY_PERSON_ID = 1 Then
                        txt_Nationnal_Niti.Text = dao_tbn.fields.NATIONALITY_PERSON
                    Else
                        txt_Nationnal_Niti.Text = dao_tbn.fields.NATIONALITY_PERSON_OTHER
                    End If
                Else
                    txt_person_age.Enabled = False
                cb_Personal_Type2.Checked = True
                txt_alternate.Text = dao_tbn.fields.AGENT_99
                If IsNothing(dao_tbn.fields.PERSON_AGE) = False Then
                    txt_alternate_Old.Text = dao_tbn.fields.PERSON_AGE
                End If
                txt_idenAlternate.Text = dao_tbn.fields.IDEN_AGENT_99
                txt_idenNiti.Text = dao.fields.IDENTIFY
                txt_NitiName.Text = dao_tbn.fields.LCN_NAME
                If dao_tbn.fields.NATIONALITY_PERSON_ID = 1 Then
                    txt_Nationnal_Niti.Text = dao_tbn.fields.NATIONALITY_PERSON
                Else
                    txt_Nationnal_Niti.Text = dao_tbn.fields.NATIONALITY_PERSON_OTHER
                End If
            End If
            'If dao_tbn.fields.AGENT_99 = "" Then
            'Else
            'End If
            txt_NameThai.Text = dao_tbn.fields.NAME_THAI
            txt_NameEng.Text = dao_tbn.fields.NAME_ENG
            Dim full_rgtno As String = ""
            full_rgtno = dao.fields.rgttpcd & " " & Integer.Parse(Right(dao.fields.rgtno, 5)).ToString() & "/" & Left(dao.fields.rgtno, 2)

                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
            Try
                dao_ty.GetDataby_drgtpcd(dao.fields.drgtpcd)
                full_rgtno &= " " & dao_ty.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            txt_NumNo.Text = full_rgtno
        ElseIf _PROCESS_ID = "20620" Then
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA_DR)
        ElseIf _PROCESS_ID = "20630" Then
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(_IDA_DR)
            If dao.fields.AGENT_99 = "" Then
                cb_Personal_Type1.Checked = True
                txt_iden.Text = dao.fields.CITIZEN_ID_AUTHORIZE
                Try
                    txt_person_age.Text = dao.fields.PERSON_AGE
                Catch ex As Exception

                End Try

                If dao.fields.NATIONALITY_PERSON_ID = 1 Then
                    txt_Nation.Text = dao.fields.NATIONALITY_PERSON
                Else
                    txt_Nation.Text = dao.fields.NATIONALITY_PERSON_OTHER
                End If
            Else

                cb_Personal_Type2.Checked = True
                txt_alternate.Text = dao.fields.AGENT_99
                txt_alternate_Old.Text = dao.fields.PERSON_AGE
                txt_idenAlternate.Text = dao.fields.CUSTOMER_IDENTIFY
                txt_idenNiti.Text = dao.fields.CITIZEN_ID_AUTHORIZE
                txt_NitiName.Text = dao.fields.LCN_NAME
                If dao.fields.NATIONALITY_PERSON_ID = 1 Then
                    txt_Nationnal_Niti.Text = dao.fields.NATIONALITY_PERSON
                Else
                    txt_Nationnal_Niti.Text = dao.fields.NATIONALITY_PERSON_OTHER
                End If
            End If
            txt_NameThai.Text = dao.fields.NAME_THAI
            txt_NameEng.Text = dao.fields.NAME_ENG
            txt_NumNo.Text = dao.fields.RGTNO_FULL

        End If


        If _PROCESS_ID = "20610" Then
            rdl_tbn_type.SelectedValue = _PROCESS_ID
        ElseIf _PROCESS_ID = "20620" Then
            rdl_tbn_type.SelectedValue = _PROCESS_ID
        Else
            rdl_tbn_type.SelectedValue = _PROCESS_ID
        End If

        'lbl_name_thai.Text = dao.fields.thadrgnm
        'lbl_name_eng.Text = dao.fields.engdrgnm

    End Sub
    Public Sub load_ddl_sub_purpose()
        Try
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_UPLOAD_SUBTITU
            dao.GetDataAll()
            ddl_sub_purpose.DataSource = dao.datas
            ddl_sub_purpose.DataValueField = "TYPE_ID"
            ddl_sub_purpose.DataTextField = "TYPE_NAME"
            ddl_sub_purpose.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_sub_purpose.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub Save_Data(ByVal dao As DAO_TABEAN_HERB.TB_TABEAN_HERB_SUBSTITUTE)
        With dao.fields
            Try
                .PROCESS_NAME = rdl_tbn_type.SelectedItem.Text
            Catch ex As Exception

            End Try
            '.REMARK = txt_Remark.Text

            Try
                .PURPOSE_ID = ddl_sub_purpose.SelectedValue
                .PURPOSE = ddl_sub_purpose.SelectedItem.Text
            Catch ex As Exception

            End Try
            .FK_IDA = _IDA_DR
            .NAME_THAI = txt_NameThai.Text
            .NAME_ENG = txt_NameEng.Text
            .RGTNO_FULL = txt_NumNo.Text
            If cb_Personal_Type1.Checked = True Then
                .TYPE_PERSON = 1
                .THANM = txt_thanm.Text
                .IDENTIFY = txt_iden.Text
                .NATIONAL_NAME = txt_Nation.Text
                .PERSON_AGE = txt_person_age.Text
                .TypePersonName = cb_Personal_Type1.Text
            ElseIf cb_Personal_Type2.Checked = True Then
                .TYPE_PERSON = 2
                .AGENT99 = txt_alternate.Text
                .AGENT99_ID = txt_idenAlternate.Text
                .THANM = txt_NitiName.Text
                .IDENTIFY = txt_idenNiti.Text
                .NATIONAL_NAME = txt_Nationnal_Niti.Text
                .TypePersonName = cb_Personal_Type2.Text
                Try
                    .PERSON_AGE = txt_alternate_Old.Text
                Catch ex As Exception

                End Try

            End If

        End With
    End Sub

End Class