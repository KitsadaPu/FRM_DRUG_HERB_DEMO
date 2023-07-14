Imports Telerik.Web.UI
Public Class UC_TABEAN_EDIT
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA_DQ As String = ""
    Private _Process_ID As String = ""
    Private _Newcode As String = ""

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
        _IDA = Request.QueryString("IDA")
        _IDA_DR = Request.QueryString("IDA_DR")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _Process_ID = Request.QueryString("PROCESS_ID")
        _Newcode = Request.QueryString("Newcode")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            get_data_tabean()
        End If
    End Sub

    Public Sub get_data_tabean()
        'Dim dao As New DAO_DRUG.ClsDBdrrqt
        'dao.GetDataby_IDA(_IDA_DR)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Dim dao_Q As New DAO_DRUG.ClsDBdrrqt
        Dim dao_h As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
        dao_h.GetDataby_NEWCODE(_Newcode)
        Dim dao_licen As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        dao_licen.GetDataby_u1(dao_h.fields.Newcode_not)
        Try
            dao.GetDataby_IDA(_IDA_DR)
            _IDA_DQ = dao.fields.FK_DRRQT

            dao_Q.GetDataby_IDA(dao.fields.FK_DRRQT)
            dao_tn.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        Catch ex As Exception

        End Try
        Dim citizen_id As String = ""
        citizen_id = dao_h.fields.CITIZEN_AUTHORIZE
        Txt_Name_Thai.Text = dao_h.fields.thadrgnm
        txt_Name_Eng.Text = dao_h.fields.engdrgnm
        txt_IDEN.Text = citizen_id
        If dao_h.fields.licen_loca Is Nothing Then
            NAME_JJ.Text = dao_tn.fields.NAME_JJ
        Else
            NAME_JJ.Text = dao_h.fields.licen_loca
        End If
        Txt_thanm_JJ.Text = dao_h.fields.thanm_locaion
        Txt_Write_At.Text = "อย"
        txt_Write_Date.SelectedDate = CDate(Date.Now).ToString("dd/MM/yyy")

        Dim NAME As String = ""
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
                NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                End If
            End If
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End Try
        NAME_JJ.Text = NAME
        Txt_thanm_JJ.Text = NAME
        Dim NAME_BSN As String = ""
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            dao_lcn.GetDataby_IDA(dao.fields.FK_LCN_IDA)
            dao_bsn.GetDataby_LCN_IDA(_IDA_LCN)
            NAME_JJ.Text = dao_bsn.fields.BSN_THAIFULLNAME
            Txt_thanm_JJ.Text = dao_bsn.fields.BSN_THAIFULLNAME
        Catch ex As Exception

        End Try
        Dim full_rgtno As String = ""
        If dao_Q.fields.RGTNO_NEW = "" Then
            full_rgtno = dao.fields.rgttpcd & " " & Integer.Parse(Right(dao.fields.rgtno, 5)).ToString() & "/" & Left(dao.fields.rgtno, 2)

            Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
            Try
                dao_ty.GetDataby_drgtpcd(dao.fields.drgtpcd)
                full_rgtno &= " " & dao_ty.fields.engdrgtpnm
            Catch ex As Exception

            End Try

            NAME_JJ.Text = FULLNAME_CPN(_CLS.CITIZEN_ID_AUTHORIZE)
            Txt_RgtNO_JJ.Text = full_rgtno
        Else
            NAME_JJ.Text = FULLNAME_CPN(_CLS.CITIZEN_ID_AUTHORIZE)
            Txt_RgtNO_JJ.Text = dao_Q.fields.RGTNO_NEW
        End If
    End Sub
    Public Function FULLNAME_CPN(ByVal citizen_id As String)
        Dim NAME As String = ""
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
                NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                End If
            End If
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End Try

        Return NAME
    End Function
End Class