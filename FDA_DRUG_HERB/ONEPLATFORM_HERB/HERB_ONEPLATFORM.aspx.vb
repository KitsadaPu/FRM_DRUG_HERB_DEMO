Imports RestSharp
Imports Newtonsoft.Json.Linq
Imports System.Globalization
Public Class HERB_ONEPLATFORM
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _token As String = ""
    Private _usefor As String = "1"
    Private _TR_ID As String = ""
    Private _process_id As String = ""
    Private _API_KEY As String = ""
    Private _IDA_LCN As String = ""
    Sub RunSession()
        Try
            '_CLS = Session("CLS")                            'นำค่า Session ใส่ ในตัวแปร _CLS
            _usefor = Request.QueryString("usefor")           'เรียก Process ที่เราเรียก
            _process_id = Request.QueryString("process_id")           'เรียก Process ที่เราเรียก
            '_TR_ID = Request.QueryString("TR_ID").ToString()
        Catch ex As Exception
            'Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            '_usefor = 3
            '_process_id = "20301"
            If _usefor = 1 Then
                _API_KEY = Request.QueryString("API_KEY")
                '_API_KEY = "ZSnVlqVij1k8t9WwT52k8g11"
                redirect_function(_API_KEY)
            ElseIf _usefor = 3 Then
                If _process_id = "20301" Or _process_id = "20302" Or _process_id = "20303" Or _process_id = "20304" Then
                    redirect_detail_tabean_jj_Edit(_process_id)
                End If
            Else

                '_process_id = "20301"
                If _process_id = "120" Or _process_id = "121" Or _process_id = "122" Then
                    redirect_detail_lcn(_process_id)
                ElseIf _process_id = "20301" Or _process_id = "20302" Or _process_id = "20303" Or _process_id = "20304" Then
                    redirect_detail_tabean_jj(_process_id)
                End If

            End If
        End If
    End Sub
    Private Sub redirect_function(ByVal API_KEY As String)
        Dim client = New RestClient("http://10.111.155.70")
        client.ClearHandlers()
        Dim restRequest = New RestRequest("API_ONE_PLATFORM/GATEWAY_EXCHANGE/API_SERVICE_CALLDATA", Method.GET)
        restRequest.AddParameter("API_KEY", API_KEY)
        Dim response1 As IRestResponse = client.Execute(restRequest)

        Dim json_str As String = response1.Content
        Dim parsejson As JObject = JObject.Parse(json_str)
        Dim SUDSUD As JArray = parsejson("DATA_TEMPs") 'ดึงออกมาเป็น array

        Dim class_oneplat As New CLASS_ONEPLATFORM
        For Each parsedObject As JObject In SUDSUD.Children(Of JObject)()

            Dim T As String = parsedObject("KEY_TEXT")
            Dim V As String = parsedObject("VALUE")

            If T = "ENTREPRENEUR_ID" Then
                class_oneplat.ENTREPRENEUR_ID = V
            ElseIf T = "SYSTEM_ID" Then
                class_oneplat.SYSTEM_ID = V
            ElseIf T = "PROCESS_ID" Then
                class_oneplat.PROCESS_ID = V
            ElseIf T = "LCNNO" Then
                class_oneplat.LCNNO = V
            ElseIf T = "PRODUCT_ID" Then
                class_oneplat.PRODUCT_ID = V
            End If
        Next

        _token = parsejson.SelectToken("HEAD_RESPONSEs.TOKEN").ToString()

        authen()
        If _usefor = 1 Then 'เพิ่มข้อมูล
            'redirect_add(class_oneplat.ENTREPRENEUR_ID, class_oneplat.PROCESS_ID)
            redirect_add_tabean_jj(class_oneplat.ENTREPRENEUR_ID, class_oneplat.PROCESS_ID, class_oneplat.LCNNO, class_oneplat.PRODUCT_ID)
            'Else 'กดดูข้อมูล
            '    redirect_detail(class_oneplat.PROCESS_ID)
        End If


    End Sub
    Private Sub redirect_add(ByVal ENTREPRENEUR_ID As String, ByVal PROCESS_ID As String) 'หน้าเพิ่มข้อมูลผปก
        If PROCESS_ID = "120" Or PROCESS_ID = "121" Or PROCESS_ID = "122" Then
            '_TR_ID = Request.QueryString("TR_ID").ToString()
            Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_TR_ID(_TR_ID)
            'dao.GetDataby_TR_ID(230999)
            'Response.Redirect("../LCN/POPUP_LCN_ADD.aspx?type_id=" & PROCESS_ID & "&process=" & PROCESS_ID & "&lct_ida=" & dao.fields.FK_IDA & "&bsn=" & dao.fields.BSN_IDENTIFY)
            Response.Redirect("../LCN/POPUP_LCN_ADD.aspx?type_id=" & PROCESS_ID & "&process=" & PROCESS_ID)
        End If
    End Sub
    Private Sub redirect_add_tabean_jj(ByVal ENTREPRENEUR_ID As String, ByVal PROCESS_ID As String, ByVal LCNNO As String, ByVal PRODUCT_ID As String) 'หน้าเพิ่มข้อมูลผปก
        If PROCESS_ID = "20301" Or PROCESS_ID = "20302" Or PROCESS_ID = "20303" Or PROCESS_ID = "20304" Then
            '_IDA_LCN = Request.QueryString("LCNNO").ToString()
            Dim PROCESS_LCN As String = ""
            Dim TR_ID_LCN As String = ""
            Dim IDA_LCT As String = ""
            Dim MENU_GROUP As String = 1
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(LCNNO)
            PROCESS_LCN = dao.fields.PROCESS_ID
            TR_ID_LCN = dao.fields.TR_ID
            IDA_LCT = dao.fields.FK_IDA
            Response.Redirect("../HERB_TABEAN/FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?type_id=" & PROCESS_ID & "&PROCESS_JJ=" & PROCESS_ID & "&IDA_LCN=" & LCNNO & "&IDA_LCT=" & IDA_LCT & "&MENU_GROUP= " & MENU_GROUP & "&OPF=1" _
                              & "&PROCESS_ID_LCN=" & dao.fields.PROCESS_ID & "&DD_HERB_NAME_ID=" & PRODUCT_ID)
        End If
    End Sub

    Private Sub redirect_detail_lcn(ByVal PROCESS_ID As String) 'กดดูข้อมูล
        _TR_ID = Request.QueryString("TR_ID").ToString()
        '_TR_ID = 230999
        _token = Request.QueryString("Token").ToString()
        '_token = "DEMO"

        Dim process_tr As String() = _TR_ID.Split("-")
        _TR_ID = process_tr(process_tr.Length - 1)

        authen()

        If _process_id = "120" Or _process_id = "121" Or _process_id = "122" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_TR_ID(230999)
            dao.GetDataby_TR_ID(_TR_ID)
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & _TR_ID & "&Process=" & dao.fields.PROCESS_ID & "&lct_ida=" & dao.fields.FK_IDA & "&identify=" & _CLS.CITIZEN_ID & "');", True)
            Response.Redirect("../LCN/FRM_LCN_DRUG.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & _TR_ID & "&lct_ida=" & dao.fields.FK_IDA & "&Process=" & _process_id & "&OPF=1")
            'Response.Redirect("../LCN/FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & _TR_ID & "&identify=" & dao.fields.CITIZEN_ID_AUTHORIZE & "&lct_ida=" & dao.fields.FK_IDA & "&Process=" & _process_id & "&OPF=" & "1")
        End If
    End Sub
    Private Sub redirect_detail_tabean_jj(ByVal PROCESS_ID As String) 'กดดูข้อมูล
        _TR_ID = Request.QueryString("TR_ID").ToString()
        _token = Request.QueryString("Token").ToString()
        '_TR_ID = 45
        '_token = "BJmEF1hm1K1NLqrHMKluJgUU"
        'Dim process_tr As String() = _TR_ID.Split("-")
        '_TR_ID = process_tr(process_tr.Length - 1)
        authen()
        If _process_id = "20301" Or _process_id = "20302" Or _process_id = "20303" Or _process_id = "20304" Then
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_TR_ID(_TR_ID)
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao.fields.IDA_LCN)
            Response.Redirect("../HERB_TABEAN/FRM_HERB_TABEAN_JJ.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & _TR_ID & "&IDA_LCT=" & dao_lcn.fields.FK_IDA & "&IDA_LCN=" _
                              & dao_lcn.fields.IDA & "&Process=" & _process_id & "&PROCESS_ID_LCN=" & dao_lcn.fields.PROCESS_ID & "&OPF=1" & "&MENU_GROUP=1")
        End If
    End Sub
    Private Sub redirect_detail_tabean_jj_Edit(ByVal PROCESS_ID As String) 'กดดูข้อมูล
        _TR_ID = Request.QueryString("TR_ID").ToString()
        _token = Request.QueryString("Token").ToString()
        '_TR_ID = 147
        '_token = "BJmEF1hm1K1NLqrHMKluJgUU"
        'Dim process_tr As String() = _TR_ID.Split("-")
        '_TR_ID = process_tr(process_tr.Length - 1)
        authen()
        If _process_id = "20301" Or _process_id = "20302" Or _process_id = "20303" Or _process_id = "20304" Then
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_TR_ID(_TR_ID)
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao.fields.IDA_LCN)
            Response.Redirect("../HERB_TABEAN/FRM_HERB_TABEAN_JJ_EDIT.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & _TR_ID & "&IDA_LCT=" & dao_lcn.fields.FK_IDA & "&IDA_LCN=" _
                              & dao_lcn.fields.IDA & "&PROCESS_JJ=" & _process_id & "&PROCESS_ID_LCN=" & dao_lcn.fields.PROCESS_ID & "&OPF=1" & "&MENU_GROUP=1")
        End If
    End Sub
    Sub authen()
        Dim token As String = _token
        If token = "DEMO" Then
            _CLS.CITIZEN_ID = "0000000000000"
            _CLS.CITIZEN_ID_AUTHORIZE = "0000000000000"
            '_CLS.CITIZEN_ID = "1100400181875"
            ''_CLS.CITIZEN_ID_AUTHORIZE = "3102000896182"
            _CLS.THANM_CUSTOMER = "บริษัท เทสออนลี่ จำกัด มหาขน"
            _CLS.THANM = "นายทดสอบ ระบบ"
            _CLS.TOKEN = token
            '_CLS. = "900"
            Session("CLS") = _CLS
        Else

            If token = "" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token');window.location.href = 'http://privus.fda.moph.go.th';", True)
                Response.Redirect("http://privus.fda.moph.go.th")
            End If
            'xml = ws.Authen_Login(token)

            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Dim xml As String = ""
            Try
                ws_118.Timeout = 10000
                xml = ws_118.Authen_Login(_token)

                If xml = "" Then
                    ws_66.Timeout = 10000
                    xml = ws_66.Authen_Login(_token)
                    If xml = "" Then
                        ws_104.Timeout = 10000
                        xml = ws_104.Authen_Login(_token)
                        If xml = "" Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                        End If
                    End If
                End If
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    xml = ws_66.Authen_Login(_token)
                    If xml = "" Then
                        ws_104.Timeout = 10000
                        xml = ws_104.Authen_Login(_token)
                        If xml = "" Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                        End If
                    End If
                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        xml = ws_104.Authen_Login(_token)
                        If xml = "" Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                        End If
                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try

            Dim clsxml As New Cls_XML
            clsxml.ReadData(xml)
            _CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
            _CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
            '_CLS.CITIZEN_ID = "0000000000000"
            '_CLS.CITIZEN_ID_AUTHORIZE = "0000000000000"
            _CLS.TOKEN = _token
            _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
            _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
            _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")
            '_CLS.ID_MENU = 1200

            Dim bao As New BAO.information
            _CLS = bao.load_lcnsid_customer(_CLS)
            _CLS = bao.load_name(_CLS)

            Dim bao_a As New BAO.ClsDBSqlcommand
            Dim i As Integer = 0
            i = bao_a.Count_Permission_Menu(clsxml.Get_Value_XML("System_ID"), clsxml.Get_Value_XML("Groups"), "8734004", clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE"))
            If i > 0 Then
                _CLS.ID_MENU = 8734004
                'Session("CLS") = _CLS
            End If

            Session("CLS") = _CLS
            Dim description As String = ""
        End If

    End Sub
End Class