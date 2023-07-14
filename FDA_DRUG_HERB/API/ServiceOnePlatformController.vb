Imports System.Net
Imports System.Web.Http

Public Class ServiceOnePlatformController
    Inherits ApiController

    <HttpGet>
    <ActionName("GetDataRequest")>
    Public Function GetDataRequest(ByVal Code_Function As String, ByVal Value As String)
        Dim bao_herb As New BAO.ClsDBSqlcommand
        If Code_Function = "GET_REQUEST_LIST" Then

            Dim dtgetrequest As DataTable = bao_herb.SP_GET_REQUEST_ALL(Value)

            Return Json(dtgetrequest)
            'ElseIf Code_Function = "GET_REQUEST_DETAIL" Then
            '    Dim cls_traking As New CLS_TRACKING
            '    Dim dtgetdatarequest As DataTable = bao_herb.SP_GET_REQUEST_ALL()
            '    Dim dtgetdatahis As DataTable = bao_herb.SP_GET_HISTORY_ALL(Value)
            '    Dim dtstatusgroup As DataTable = bao_herb.SP_STATUS_ONE_PLATFORM(Value)
            '    For Each datarequest In dtgetdatarequest.Rows
            '        cls_traking.REQ_HEAD.TR_ID = datarequest("TRANSACTION_NO").ToString()
            '        cls_traking.REQ_HEAD.ENTREPRENEUR_IDENTIFY = datarequest("CITIZEN_ID").ToString()
            '        cls_traking.REQ_HEAD.ENTREPRENEUR_IDENTIFY_NAME = datarequest("COMPANY_NAME").ToString()
            '        cls_traking.REQ_HEAD.RCV_DATE = datarequest("RCVDATE").ToString()
            '        cls_traking.REQ_HEAD.FINISH_DATE = datarequest("COMPLETE_DATE").ToString()
            '        cls_traking.REQ_HEAD.STATUS_NAME = datarequest("STATUS_NAME").ToString()
            '        cls_traking.REQ_HEAD.REMARK_FINISH = datarequest("REMARK_FINISH").ToString()
            '        cls_traking.REQ_HEAD.REMARK_EDIT = datarequest("REMARK_EDIT").ToString()
            '        cls_traking.MILESTONE_DATA.MILE_STONE_STATUS_ID = datarequest("STATUS_ID").ToString()
            '        cls_traking.MILESTONE_DATA.MILE_STONE_STATUS_NAME = datarequest("STATUS_NAME").ToString()

            '    Next
            '    For Each his In dtgetdatahis.Rows
            '        Dim REQ_HISTORY As New REQ_HISTORY
            '        REQ_HISTORY.HISTORY_DATE = his("HISTORY_DATE").ToString()
            '        REQ_HISTORY.HISTORY_TIME = his("HISROTY_TIME").ToString()
            '        REQ_HISTORY.HISTORY_STATUS = his("HISTORY_STATUS_NAME").ToString()
            '        REQ_HISTORY.HISTORY_PERSON_CTZNO = his("HISTORY_PERSON_CTZNO").ToString()
            '        REQ_HISTORY.HISTORY_PERSON_NAME = his("HISTORY_PERSON_NAME").ToString()
            '        cls_traking.HISTORY_DATA.Add(REQ_HISTORY)
            '    Next

            '    Return Json(cls_traking)
        ElseIf Code_Function = "GET_REQUEST_CONSIDER" Then

        End If
        Return Nothing
    End Function

End Class
