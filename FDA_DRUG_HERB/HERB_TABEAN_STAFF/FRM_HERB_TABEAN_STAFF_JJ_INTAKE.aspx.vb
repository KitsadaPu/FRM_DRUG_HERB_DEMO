Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_STAFF_JJ_INTAKE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String

    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src=''></iframe>"

            Run_Pdf_Tabean_Herb()
            bind_data()
            bind_dd()
            bind_mas_staff()
            'bind_tabean_group()
            'bind_ddl_rgttpcd()
        End If
    End Sub

    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        'Dim XML As New CLS_TABEAN_HERB_JJ
        'XML.JJ_1 = 1

        'Dim dt As DataTable
        'Dim bao_xml As New BAO_TABEAN_HERB.tb_xml
        'dt = bao_xml.SP_XML_TABEAN_JJ()
        'dt.TableName = "XML_TABEAN_JJ"
        'XML.DT_SHOW.DT1 = dt

        'TB_JJ = XML

        'Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ1", 0)

        'Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_DEFALUT") 'path
        'Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA)
        'Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA)

        '_CLS.PATH_PDF_TEMPLATE = PATH_PDF_TEMPLATE
        '_CLS.PATH_XML = Path_XML

        ''Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_DEFALUT") 'path
        ''Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "pdf_jj1\" & "Jor_Jor_1.pdf"
        ''Dim PATH_PDF_OUTPUT As String = _PATH_FILE & "output_pdf_jj1\" & NAME_UPLOAD_XML_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA)
        ''Dim Path_XML As String = _PATH_FILE & "xml_jj1\" & NAME_UPLOAD_XML_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA)

        'LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        ''Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
        ''    Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"

        ''        Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
        ''            stamper.AcroFields.Xfa.FillXfaForm(Path_XML)
        ''        End Using

        ''    End Using
        ''End Using

        'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        '_CLS.FILENAME_PDF = NAME_PDF_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, _TR_ID, _IDA)
        '_CLS.PDFNAME = PATH_PDF_OUTPUT
        '_CLS.FILENAME_XML = NAME_XML_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, _TR_ID, _IDA)

    End Sub

    'Private Sub load_pdf(ByVal FilePath As String)

    '    Dim bb As Byte() = UpLoadImageByte(FilePath)

    '    Dim ws As New WS_FLATTEN.WS_FLATTEN

    '    Dim b_o As Byte() = ws.FlattenPDF_DIGITAL(bb)

    '    Response.ContentType = "application/pdf"
    '    Response.AddHeader("content-length", b_o.Length.ToString())
    '    Response.BinaryWrite(b_o)
    '    Response.Flush()
    '    Response.End()

    'End Sub
    'Public Function UpLoadImageByte(ByVal info As String) As Byte()
    '    Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
    '    Dim reader As New BinaryReader(stream)
    '    Dim imgBin() As Byte
    '    Try
    '        imgBin = reader.ReadBytes(stream.Length)
    '    Catch ex As Exception
    '    Finally
    '        stream.Close()
    '        reader.Close()
    '    End Try
    '    Return imgBin
    'End Function

    Public Sub bind_data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        If dao.fields.RCVNO_FULL <> "" Then
            P12.Visible = True
            ROVNO_FULL.Text = dao.fields.RCVNO_FULL
        End If
        DD_OFF_REQ.Text = _CLS.NAME

        DATE_REQ.Text = Date.Now.ToString("dd/MM/yyyy")
    End Sub

    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_STATUS_JJ(1)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    'Public Sub bind_tabean_group()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_TABEAN_DRUGGROUPTYPE_JJ()
    '    ddl_tabean_group.DataSource = dt
    '    ddl_tabean_group.DataTextField = "thadrgtpnm"
    '    ddl_tabean_group.DataValueField = "drgtpcd"
    '    ddl_tabean_group.DataBind()

    '    Dim item As New ListItem
    '    item.Text = "--กรุณาเลือก--"
    '    item.Value = ""
    '    ddl_tabean_group.Items.Insert(0, item)
    'End Sub

    'Public Sub bind_ddl_rgttpcd()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_TABEAN_DRUGGROUP_JJ()

    '    ddl_rgttpcd.DataSource = dt
    '    ddl_rgttpcd.DataTextField = "rgttpcd"
    '    ddl_rgttpcd.DataValueField = "IDA"
    '    ddl_rgttpcd.DataBind()

    '    Dim item As New ListItem
    '    item.Text = "--กรุณาเลือก--"
    '    item.Value = ""
    '    ddl_rgttpcd.Items.Insert(0, item)
    'End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 1)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 3)

        Return dt
    End Function

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile_edit()
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)


        dao.fields.STATUS_ID = DD_STATUS.SelectedValue

        If DD_STATUS.SelectedValue = 12 Or DD_STATUS.SelectedValue = 11 Then

            If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ หรือ เลือกเจ้าหน้าที่');", True)
            Else
                'dao.fields.RGTTPCD_ID = ddl_rgttpcd.SelectedItem.Value
                dao.fields.RGTTPCD = "G"
                'dao.fields.RGTNO_JJ = RGTNO_JJ.Text
                'dao.fields.RGTTPCD_GROUP_ID = ddl_tabean_group.SelectedItem.Value
                'dao.fields.RGTTPCD_GROUP = ddl_tabean_group.SelectedItem.Text

                'Dim dao_druggroup As New DAO_DRUG.ClsDBdrdrgtype
                'dao_druggroup.GetDataby_drgtpcd(dao.fields.RGTTPCD_GROUP_ID)
                'dao.fields.RGTTPCD_GROUP_ENG = dao_druggroup.fields.engdrgtpnm

                'dao.fields.RGTNO_FULL = ddl_rgttpcd.SelectedItem.Text & " " & RGTNO_JJ.Text & " " & dao.fields.RGTTPCD_GROUP_ENG

                Try
                    dao.fields.DATE_REQ = DateTime.ParseExact(DATE_REQ.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                Catch ex As Exception
                    dao.fields.DATE_REQ = Date.Now
                End Try

                'dao.fields.OFF_REQ = OFF_REQ.Text
                dao.fields.OFF_REQ_ID = DD_OFF_REQ.SelectedValue
                dao.fields.OFF_REQ = DD_OFF_REQ.SelectedItem.Text

                Dim TR_ID As String = dao.fields.TR_ID_JJ
                Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
                Dim RCVNO_FULL As String = "HB" & " " & dao.fields.PVNCD & "-" & _ProcessID & "-" & DATE_YEAR & "-" & TR_ID

                dao.fields.RCVNO_FULL = RCVNO_FULL

                dao.Update()

                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)

                Run_Pdf_Tabean_Herb_12_11()
            End If

        ElseIf DD_STATUS.SelectedValue = 4 Then

            Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
            dao_up_mas.GetdatabyID_TYPE(2)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.TR_ID = _TR_ID
                dao_up.fields.PROCESS_ID = _ProcessID
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.FK_IDA_LCN = _IDA_LCN
                dao_up.fields.TYPE = 2
                dao_up.insert()
            Next

            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)

            dao.Update()
        ElseIf DD_STATUS.SelectedValue = 9 Then
            dao.Update()
        End If

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Public Sub Run_Pdf_Tabean_Herb_12_11()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
        TB_JJ = XML.gen_xml(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ');", True)
        ElseIf DD_STATUS.SelectedValue = 12 Or DD_STATUS.SelectedValue = 11 Then
            P12.Visible = True
        Else
            P12.Visible = False
        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Function bind_data_file_recipe_production()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        Dim HERB_ID As Integer = dao.fields.DD_HERB_NAME_ID

        dt = bao.SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ(HERB_ID)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_file_recipe_production()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            'Dim DD_HERB_NAME_PRODUCT_ID As Integer = item("DD_HERB_NAME_PRODUCT_ID").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_RECIPE_PRODUCT_PREVIEW_FILE.aspx?IDA=" & IDA

        End If
    End Sub

    Private Sub DD_OFF_REQ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_OFF_REQ.SelectedIndexChanged
        If DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกเจ้าหน้าที่');", True)
        End If
    End Sub

End Class