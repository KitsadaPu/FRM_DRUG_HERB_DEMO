Public Class POPUP_LCN_REQUEST_EDIT
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    ' Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _IDA_FK As String
    Private _id_lcn As String
    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _lct_ida = Request.QueryString("lct_ida")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _iden = Request.QueryString("identify")
            _id_lcn = Request.QueryString("ID_LCN")
            ' _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub Clone_db()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao_tbadress As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS
        Dim dao_tbadress_fix As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS_FIX
        Dim dao_tbfrgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        Dim dao_tbfrgn_fix As New DAO_DRUG.TB_DALCN_FRGN_DATA_FIX
        Dim dt As New DataTable 'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Dim IDA_integer As New Integer
        IDA_integer = Convert.ToInt32(_IDA)
        Try
            'clone main table
            bao.SP_CLONE_DALCN_FIX(_IDA)
            dt = bao.SP_MAX_DALCN_FIX()
            For Each dr As DataRow In dt.Rows
                _IDA_FK = dr("maxid")
            Next
            Label1.Text = _IDA_FK
            Session("IDA_FK_DLCN_FIx") = _IDA_FK
            'clone frgn
            dao_tbfrgn.GetDataby_FK_IDA(IDA_integer)
            If (dao_tbfrgn.fields.IDA = 0) Then
                dao_tbfrgn_fix.fields.ID_DALCN = _IDA
                dao_tbfrgn_fix.fields.FK_IDA = _IDA_FK
                dao_tbfrgn_fix.fields.ACTIVE = 0
                dao_tbfrgn_fix.insert()
            Else
                bao.SP_CLONE_DALCN_FRGN_DATA_FIX(_IDA, _IDA_FK)
            End If
            'clone address
            dao_tbadress.GetData_By_FK_IDA(IDA_integer)
            If (dao_tbadress.fields.IDA = 0) Then
                dao_tbadress_fix.fields.ID_DALCN = _IDA
                dao_tbadress_fix.fields.FK_IDA = _IDA_FK
                dao_tbadress_fix.fields.ACTIVE = 0
                dao_tbadress_fix.insert()
            Else
                bao.SP_CLONE_DALCN_CURRENT_ADDRESS_FIX(_IDA, _IDA_FK)
            End If
            Dim dao_keep As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            dao_keep.GetDataby_FK(_IDA)
            For Each item In dao_keep.Details
                bao.SP_CLONE_DALCN_DETAIL_LOCATION_KEEP_FIX(item.IDA, _IDA_FK)
            Next
            Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr.GetDataby_FK_IDA(_IDA)

            For Each item In dao_phr.Details
                bao.SP_CLONE_DALCN_PHR_FIX(item.PHR_IDA, _IDA_FK)
            Next
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('มีข้อผิดพลาด');", True)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunQuery()


        If Not IsPostBack Then
            Clone_db()
            UC_HERB_EDIT.Set_Label(_iden)
            UC_HERB_EDIT.load_ddl_chwt()
            UC_HERB_EDIT.load_ddl_amp()
            UC_HERB_EDIT.load_ddl_thambol()
            'UC_LCN_HERB_PHESAJ_EDIT.bind_ddl_prefix()
            UC_LCN_HERB_PHESAJ_EDIT.bind_ddl_phr_type()

            'If Request.QueryString("ida") <> "" Then
            '    Panel1.Style.Add("display", "block")
            '    Panel2.Style.Add("display", "block")
            '    btn_save.Style.Add("display", "none")
            'Else
            '    Panel1.Style.Add("display", "none")
            '    Panel2.Style.Add("display", "none")
            '    btn_save.Style.Add("display", "block")
            'End If

        End If

    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn_fix
        Dim a As Integer = CType(Session("IDA_FK_DLCN_FIx").ToString(), Integer)
        dao_dalcn.GetDataby_IDA(a)
        dao_dalcn.fields.ACTIVE = 0
        dao_dalcn.update()
        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA_FIX
        dao_frgn.GetDataby_FK_IDA(a)
        dao_frgn.fields.ACTIVE = 0
        dao_frgn.update()
        Dim dao_address As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS_FIX
        dao_address.GetData_By_FK_IDA(a)
        dao_address.fields.ACTIVE = 0
        dao_address.update()
        Dim dao_keep As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP_FIX
        dao_keep.GetDataby_BY_FK(Session("IDA_FK_DLCN_FIx").ToString())
        For Each item In dao_keep.Details
            Dim dao_row As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP_FIX
            dao_row.GetDataby_id(item.IDA)
            dao_row.fields.ACTIVE = 0
            dao_row.update()
        Next
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR_FIX
        dao_phr.GetDataby_BY_FK(Session("IDA_FK_DLCN_FIx").ToString())
        For Each item In dao_phr.Details
            Dim dao_row As New DAO_DRUG.ClsDBDALCN_PHR_FIX
            dao_row.GetDataby_id(item.PHR_IDA)
            dao_row.fields.ACTIVE = 0
            dao_row.update()
        Next
        Response.Write("<script type='text/javascript'>alert('บกเลิกเรียบร้อย');parent.close_modal();</script> ")
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');", True)
    End Sub


    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Not UC_HERB_EDIT.check_infor() Then
            UC_HERB_EDIT.Chek_information()
        Else
            Dim IDA As Integer = 0
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = 5 '_CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = 5 '_CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection(_ProcessID)
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn_fix
            dao_dal.GetDataby_IDA(Label1.Text)
            UC_HERB_EDIT.setdata(dao_dal, TR_ID)
            ' dao_dal.fields.STATUS_ID = 1
            'dao_dal.fields.PROCESS_ID = Request.QueryString("process")
            'dao_dal.fields.REVOCATION = "999"
            'dao_dal.fields.lcnno = 0
            'dao_dal.fields.rcvno = 0
            Try
                ' dao_dal.fields.lcnsid = 5 '_CLS.LCNSID_CUSTOMER
            Catch ex As Exception
                'dao_dal.fields.lcnsid = 0
            End Try

            dao_dal.update()
            'IDA = dao_dal.fields.IDA

            Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA_FIX 'ข้อมูลต่างด้าว
            dao_frgn.GetDataby_FK_IDA(Label1.Text)
            UC_HERB_EDIT.setdata_frgn_data(dao_frgn)
            ' dao_frgn.fields.FK_IDA = dao_dal.fields.IDA
            dao_frgn.update()

            Dim dao_curent As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS_FIX 'ที่อยู่ที่ติดต่อ
            dao_curent.GetData_By_FK_IDA(Label1.Text)
            UC_HERB_EDIT.set_date_current_addr(dao_curent)
            'dao_curent.fields.FK_IDA = dao_dal.fields.IDA
            dao_curent.update()


            'UC_HERB_EDIT.insert_bsn(IDA)

            Dim dao As New DAO_DRUG.ClsDBlcn_request
            With dao
                '.fields.IDA = 2
                .fields.ID_DALCN = CType(_IDA, Integer)
                .fields.ID_DALCN_FIX = Label1.Text
                .fields.IDENTIFY = _iden
                .fields.NOTE = "ลอง"
                .fields.TR_ID = 1
                .fields.STATUS = 1
                .fields.rcbno = 1
                .fields.LCNNO_DISPLAY = _id_lcn
                .insert()
                .fields.TR_ID = .fields.IDA
                .update()
            End With
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        End If
        Session.Remove("IDA_FK_DLCN_FIx")
    End Sub
End Class