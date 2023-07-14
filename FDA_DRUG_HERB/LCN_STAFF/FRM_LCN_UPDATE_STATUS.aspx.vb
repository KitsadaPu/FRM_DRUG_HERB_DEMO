Imports Telerik.Web.UI
Public Class FRM_LCN_UPDATE_STATUS
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
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
    End Sub
    Sub Run_Service(ByVal IDA As Integer)
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.HERB_UPDATE_LICEN(IDA, _CLS.CITIZEN_ID)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Try
            Shows(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        If Not IsPostBack Then
            rdp_cncdate.SelectedDate = Date.Now

            Dim dao As New DAO_DRUG.ClsDBdalcn
            Dim lcntpcd As String = ""
            Dim process_id As String = ""
            Dim ccc As String = ""
            Try
                dao.GetDataby_IDA(Request.QueryString("IDA"))
            Catch ex As Exception

            End Try
            Try
                lcntpcd = dao.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                process_id = dao.fields.PROCESS_ID
            Catch ex As Exception

            End Try
            'Try
            '    ddl_template.DropDownSelectData(dao.fields.TEMPLATE_ID)
            'Catch ex As Exception

            'End Try
            Try
                rdp_cncdate.SelectedDate = CDate(dao.fields.cncdate)
            Catch ex As Exception

            End Try
            'Try
            '    txt_CATEGORY_DRUG.Text = dao.fields.CATEGORY_DRUG
            'Catch ex As Exception

            'End Try
            'If process_id = "109" Or process_id = "110" Or process_id = "122" Or process_id = "127" Or process_id = "128" Then
            '    Panel1.Style.Add("display", "block")
            'End If
            Try
                ccc = dao.fields.cnccscd
                'dao.fields.cnccscd = Nothing
                'lbl_statname.Text = dao.fields.
            Catch ex As Exception
                ccc = ""
            End Try
            'Try
            '    txt_time.Text = dao.fields.opentime
            'Catch ex As Exception

            'End Try
            If ccc = "" Then
                lbl_statname.Text = "คงอยู่"
            Else
                Try
                    Dim dao_cnc As New DAO_DRUG.ClsDBdacscd
                    dao_cnc.GetData_by_cd(ccc)
                    lbl_statname.Text = dao_cnc.fields.csnm
                Catch ex As Exception

                End Try

            End If
            'Try
            '    txt_appdate.Text = CDate(dao.fields.appdate).ToShortDateString()
            'Catch ex As Exception

            'End Try
            Dim expyear As Integer = 0
            Try
                expyear = dao.fields.expyear
            Catch ex As Exception

            End Try
            'If expyear <> 0 Then
            '    If expyear < 2500 Then
            '        expyear = expyear + 543
            '        txt_expyear.Text = expyear
            '    Else
            '        expyear = expyear
            '        txt_expyear.Text = expyear
            '    End If
            'End If
            'Try
            '    txt_expdate.Text = CDate(dao.fields.expdate).ToShortDateString
            'Catch ex As Exception

            'End Try
            bind_ddl_stat()

            Try
                ddl_stat.DropDownSelectData(dao.fields.cnccscd)
            Catch ex As Exception

            End Try

            'rgphr.DataBind()

        End If
    End Sub
    Sub bind_ddl_stat()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
        Catch ex As Exception

        End Try
        Try
            Dim dao_stat As New DAO_DRUG.ClsDBdacscd
            dao_stat.GetDataAll()
            ddl_stat.DataSource = dao_stat.datas
            ddl_stat.DataTextField = "csnm"
            ddl_stat.DataValueField = "cscd"
            ddl_stat.DataBind()

            Dim item As New ListItem
            item.Text = "คงอยู่"
            item.Value = "0"
            ddl_stat.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub set_hide_show()
        'If hd_location.Value = "0" Then
        '    btn_location.Style.Add("display", "block")
        'Else
        '    btn_location.Style.Add("display", "none")
        'End If

        'If hdkeep.Value = "0" Then
        '    btn_add_keep.Style.Add("display", "block")
        'Else
        '    btn_add_keep.Style.Add("display", "none")
        'End If
    End Sub
    Public Sub Shows(ByVal IDA As Integer)
        Dim Tb As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS                               ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim TbNO As New DAO_DRUG.ClsDBdalcn                                     ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            TbNO.GetDataby_IDA(IDA)
            'การ where 
            Tb.GetDataby_IDA(TbNO.fields.FK_IDA)
        Catch ex As Exception

        End Try
        'การ where 
        Try
            tb_location.GetDataby_LCN_IDA(IDA)
        Catch ex As Exception

        End Try
        Dim lcnno As String = ""
        Dim rcvno As String = ""
        Try
            lcnno = TbNO.fields.lcntpcd & " " & CInt(Right(TbNO.fields.lcnno, 5)) & "/" & Left(TbNO.fields.lcnno, 2)
        Catch ex As Exception

        End Try

        Try
            If Right(Left(TbNO.fields.lcnno, 3), 1) = "5" Then
                lcnno = TbNO.fields.lcntpcd & " จ " & CInt(Right(TbNO.fields.lcnno, 4)) & "/" & Left(TbNO.fields.lcnno, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            rcvno = CInt(Right(TbNO.fields.rcvno, 5)) & "/" & Left(TbNO.fields.rcvno, 2)
        Catch ex As Exception

        End Try
        Try
            If TbNO.fields.lcnno IsNot Nothing Then
                Dim raw_lcn As String = TbNO.fields.lcnno
                lbl_lcnno.Text = lcnno 'CStr(CInt((Right(raw_lcn, 5))) & "/25" & Left(raw_lcn, 2))
            End If
        Catch ex As Exception

        End Try
        'Try
        '    lbl_lcnno.Text = TbNO.fields.LCNNO_DISPLAY
        'Catch ex As Exception
        '    lbl_lcnno.Text = "-"
        'End Try

        Try
            lbl_citizenid.Text = TbNO.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try

        Try
            lbl_thanameplace.Text = Tb.fields.thanameplace
        Catch ex As Exception

        End Try
        Try
            lbl_nameOperator.Text = tb_location.fields.BSN_THAIFULLNAME
        Catch ex As Exception

        End Try

    End Sub
End Class