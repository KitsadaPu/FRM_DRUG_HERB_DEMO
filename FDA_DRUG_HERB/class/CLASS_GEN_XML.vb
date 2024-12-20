﻿Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER

Namespace CLASS_GEN_XML

    Public Class Center
        Protected Friend _CITIEZEN_ID As String
        Protected Friend _lcnsid_customer As Integer
        Protected Friend _lcnno As String
        Protected Friend _fdtypecd As String
        Protected Friend _fdtypenm As String
        Protected Friend _FATYPE As String
        Protected Friend _PVNCD As String
        Protected Friend _lcntpcd As String
        Protected Friend _lctcd As Integer
        Protected Friend _IDA As Integer
        Protected Friend _LCN_IDA As Integer
        Protected Friend _AUTO_ID As String
        Protected Friend _PRODUCT_ID As String

#Region "WS"
        Protected Friend WS_CENTER_CLC_NAMES As New WS_CENTER.CLC_NAMES
        Protected Friend WS_CENTER As New WS_CENTER.WS_CENTER
        Protected Friend WS_CENTER_systhmbl As New WS_CENTER.CLC_THMBLCD
        Protected Friend WS_CENTER_sysamphr As New WS_CENTER.CLC_AMPHRCD
        Protected Friend WS_CENTER_syschngwt As New WS_CENTER.CLC_CHAWTCD
#End Region



        Public Sub ADD_CHEMICAL()
            Dim bao_master As New BAO_MASTER
            Dim class_xml_cer As New CLASS_CER
            class_xml_cer.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL() 'สาร
        End Sub

        Public Function AddValue(ByVal ob As Object) As Object
            Dim props As System.Reflection.PropertyInfo
            For Each props In ob.GetType.GetProperties()

                '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
                Dim p_type As String = props.PropertyType.ToString()
                If props.CanWrite = True Then
                    If p_type.ToUpper = "System.String".ToUpper Then
                        props.SetValue(ob, " ", Nothing)
                    ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                        props.SetValue(ob, 0, Nothing)
                    ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                        props.SetValue(ob, Date.Now, Nothing)
                    Else
                        props.SetValue(ob, Nothing, Nothing)
                    End If
                End If

                'prop.SetValue(cls1, "")
                'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
            Next props

            Return ob
        End Function
        Protected Friend Function AddValue2(ByVal ob As Object) As Object
            Dim props As System.Reflection.PropertyInfo
            For Each props In ob.GetType.GetProperties()

                '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
                Dim p_type As String = props.PropertyType.ToString()
                If props.CanWrite = True Then
                    If p_type.ToUpper = "System.String".ToUpper Then
                        props.SetValue(ob, " ", Nothing)
                    ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                        props.SetValue(ob, 0, Nothing)
                    ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                        props.SetValue(ob, Date.Now, Nothing)
                    Else

                        props.SetValue(ob, Nothing, Nothing)


                    End If
                End If

                'prop.SetValue(cls1, "")
                'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
            Next props

            Return ob
        End Function

        Public Sub GEN_XML_CER(ByVal PATH As String, ByVal p2 As CLASS_CER)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DALCN(ByVal PATH As String, ByVal p2 As CLASS_DALCN)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DALCN_EDT(ByVal PATH As String, ByVal p2 As CLASS_DALCN_EDIT_REQUEST)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DALCN_SUB(ByVal PATH As String, ByVal p2 As CLASS_DALCN_NCT_SUBSTITUTE)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DALCN_SUBTITUTE(ByVal PATH As String, ByVal p2 As CLASS_DALCN_SUBSTITUTE)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_SMP3(ByVal PATH As String, ByVal p2 As CLS_LCN_EDIT_SMP3)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DH(ByVal PATH As String, ByVal p2 As CLASS_DH)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DI(ByVal PATH As String, ByVal p2 As CLASS_DI)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DP(ByVal PATH As String, ByVal p2 As CLASS_DP)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DR(ByVal PATH As String, ByVal p2 As CLASS_DR)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DS(ByVal PATH As String, ByVal p2 As CLASS_DS)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_REGISTRATION(ByVal PATH As String, ByVal p2 As CLASS_REGISTRATION)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_LOCATION(ByVal PATH As String, ByVal p2 As CLS_LOCATION)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DRUG_CONSIDER_REQUESTS(ByVal PATH As String, ByVal p2 As XML_CONSIDER_REQUESTS)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DRSAMP(ByVal PATH As String, ByVal p2 As CLASS_DRSAMP)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_CER_FOREIGN(ByVal PATH As String, ByVal p2 As CLASS_CER_FOREIGN)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_LCNREQUEST(ByVal PATH As String, ByVal p2 As CLASS_LCNREQUEST)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_EXTEND(ByVal PATH As String, ByVal p2 As CLASS_EXTEND)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_EDT_DRRGT(ByVal PATH As String, ByVal p2 As CLASS_EDIT_DRRGT)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_NORYORMOR1(ByVal PATH As String, ByVal p2 As CLASS_PROJECT_SUM)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_DRRGT_SUBSTITUTE(ByVal PATH As String, ByVal p2 As CLASS_DRRGT_SUB)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_DRRGT_SUBSTITUTE_TB(ByVal PATH As String, ByVal p2 As CLASS_DRRGT_SUB)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_DRRGT_SPC(ByVal PATH As String, ByVal p2 As CLASS_DRRGT_SPC)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_DRRGT_PI(ByVal PATH As String, ByVal p2 As CLASS_DRRGT_PI)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_DRRGT_PIL(ByVal PATH As String, ByVal p2 As CLASS_DRRGT_PIL)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_TEMP_NCT_DALCN(ByVal PATH As String, ByVal p2 As CLASS_TEMP_NCT_DALCN)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_TABEAN_JJ(ByVal PATH As String, ByVal p2 As CLS_TABEAN_HERB_JJ)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_TABEAN_EDIT(ByVal PATH As String, ByVal p2 As CLASS_DR_EDIT)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_JJ_EDIT(ByVal PATH As String, ByVal p2 As CLASS_TABEAN_JJ_EDIT)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_RENEW(ByVal PATH As String, ByVal p2 As CLASS_DR_RENEW)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_SUB(ByVal PATH As String, ByVal p2 As CLASS_DR_SUB)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_ANALYZE(ByVal PATH As String, ByVal p2 As CLASS_DR_ANALYZE)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_NOTIFY(ByVal PATH As String, ByVal p2 As CLASS_DR_NOTIFY)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_DONATE(ByVal PATH As String, ByVal p2 As CLASS_DR_DONATE)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_EXHIBITION(ByVal PATH As String, ByVal p2 As CLASS_DR_EXHIBITION)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_AP(ByVal PATH As String, ByVal p2 As CLASS_APPOINTMENT)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_TABEAN_TBN(ByVal PATH As String, ByVal p2 As CLASS_DRRQT)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_INFORM(ByVal PATH As String, ByVal p2 As CLASS_DR_INFORM)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_INFORM_EDIT(ByVal PATH As String, ByVal p2 As CLASS_DR_INFORM_EDIT)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_TABEAN_EX(ByVal PATH As String, ByVal p2 As CLASS_TABEAN_EX)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DALCN_PHR(ByVal PATH As String, ByVal p2 As CLASS_DALCN_PHR)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DALCN_PLAN(ByVal PATH As String, ByVal p2 As CLASS_DALCN_PLAN)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DALCN_AUDIT(ByVal PATH As String, ByVal p2 As CLASS_DALCN_AUDIT)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DALCN_RENEW(ByVal PATH As String, ByVal p2 As CLASS_DALCN_RENEW)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DALCN_TRANSFER(ByVal PATH As String, ByVal p2 As CLASS_DALCN_TRANSFER)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

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

            End Try

            Return NAME
        End Function
    End Class

    Public Class DALCN
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DALCN
            Dim class_xml As New CLASS_DALCN
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.dalcns = AddValue(class_xml.dalcns)
            class_xml.dalcns.pvncd = _PVNCD
            class_xml.dalcns.lcnsid = _lcnsid_customer
            class_xml.dalcns.rcvno = 0
            class_xml.dalcns.CHK_SELL_TYPE = _CHK_SELL_TYPE
            'class_xml.dalcns.CHK_SELL_TYPE1 = _CHK_SELL_TYPE1
            For i As Integer = 0 To rows
                Dim cls_sysplace As New sysplace

                cls_sysplace = AddValue(cls_sysplace)

                class_xml.sysplaces.Add(cls_sysplace)
            Next

            For i As Integer = 0 To rows
                Dim cls_dakeplctnm As New dakeplctnm
                cls_dakeplctnm = AddValue(cls_dakeplctnm)
                class_xml.dakeplctnms.Add(cls_dakeplctnm)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnctg As New dalcnctg
                cls_dalcnctg = AddValue(cls_dalcnctg)
                class_xml.dalcnctgs.Add(cls_dalcnctg)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnphr As New dalcnphr
                cls_dalcnphr = AddValue(cls_dalcnphr)
                class_xml.dalcnphrs.Add(cls_dalcnphr)
            Next

            For i As Integer = 0 To rows
                Dim cls_dacnphdtl As New dacnphdtl
                cls_dacnphdtl = AddValue(cls_dacnphdtl)
                class_xml.dacnphdtls.Add(cls_dacnphdtl)
            Next

            For i As Integer = 0 To rows
                Dim cls_dacncphr As New dacncphr
                cls_dacncphr = AddValue(cls_dacncphr)
                class_xml.dacncphrs.Add(cls_dacncphr)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnkep As New dalcnkep
                cls_dalcnkep = AddValue(cls_dalcnkep)
                class_xml.dalcnkeps.Add(cls_dalcnkep)
            Next

            For i As Integer = 0 To rows
                Dim cls_darqt As New darqt
                cls_darqt = AddValue(cls_darqt)
                class_xml.darqts.Add(cls_darqt)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_KEPs As New DALCN_KEP
                cls_DALCN_KEPs = AddValue(cls_DALCN_KEPs)
                class_xml.DALCN_KEPs.Add(cls_DALCN_KEPs)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_PHR As New DALCN_PHR
                cls_DALCN_PHR = AddValue(cls_DALCN_PHR)
                class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_PHR_2 As New DALCN_PHR
                cls_DALCN_PHR_2 = AddValue(cls_DALCN_PHR_2)
                class_xml.DALCN_PHR_2s.Add(cls_DALCN_PHR_2)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnaddr As New dalcnaddr
                cls_dalcnaddr = AddValue(cls_dalcnaddr)
                class_xml.dalcnaddrs.Add(cls_dalcnaddr)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
                cls_DALCN_DETAIL_LOCATION_KEEP = AddValue(cls_DALCN_DETAIL_LOCATION_KEEP)
                class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
            Next
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            class_xml.phr_medical_type = ""
            class_xml.dalcns.opentime = _opentime
            Return class_xml


        End Function

        Public Function gen_xml_103(Optional rows As Integer = 0) As CLASS_DALCN
            Dim class_xml As New CLASS_DALCN
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.dalcns = AddValue(class_xml.dalcns)
            class_xml.dalcns.pvncd = _PVNCD
            class_xml.dalcns.lcnsid = _lcnsid_customer
            class_xml.dalcns.rcvno = 0
            class_xml.dalcns.CHK_SELL_TYPE = _CHK_SELL_TYPE
            For i As Integer = 0 To rows
                Dim cls_sysplace As New sysplace

                cls_sysplace = AddValue(cls_sysplace)

                class_xml.sysplaces.Add(cls_sysplace)
            Next

            For i As Integer = 0 To rows
                Dim cls_dakeplctnm As New dakeplctnm
                cls_dakeplctnm = AddValue(cls_dakeplctnm)
                class_xml.dakeplctnms.Add(cls_dakeplctnm)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnctg As New dalcnctg
                cls_dalcnctg = AddValue(cls_dalcnctg)
                class_xml.dalcnctgs.Add(cls_dalcnctg)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnphr As New dalcnphr
                cls_dalcnphr = AddValue(cls_dalcnphr)
                class_xml.dalcnphrs.Add(cls_dalcnphr)
            Next

            For i As Integer = 0 To rows
                Dim cls_dacnphdtl As New dacnphdtl
                cls_dacnphdtl = AddValue(cls_dacnphdtl)
                class_xml.dacnphdtls.Add(cls_dacnphdtl)
            Next

            For i As Integer = 0 To rows
                Dim cls_dacncphr As New dacncphr
                cls_dacncphr = AddValue(cls_dacncphr)
                class_xml.dacncphrs.Add(cls_dacncphr)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnkep As New dalcnkep
                cls_dalcnkep = AddValue(cls_dalcnkep)
                class_xml.dalcnkeps.Add(cls_dalcnkep)
            Next

            For i As Integer = 0 To rows
                Dim cls_darqt As New darqt
                cls_darqt = AddValue(cls_darqt)
                class_xml.darqts.Add(cls_darqt)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_KEPs As New DALCN_KEP
                cls_DALCN_KEPs = AddValue(cls_DALCN_KEPs)
                class_xml.DALCN_KEPs.Add(cls_DALCN_KEPs)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_PHR As New DALCN_PHR
                cls_DALCN_PHR = AddValue(cls_DALCN_PHR)
                class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_PHR_2 As New DALCN_PHR
                cls_DALCN_PHR_2 = AddValue(cls_DALCN_PHR_2)
                class_xml.DALCN_PHR_2s.Add(cls_DALCN_PHR_2)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnaddr As New dalcnaddr
                cls_dalcnaddr = AddValue(cls_dalcnaddr)
                class_xml.dalcnaddrs.Add(cls_dalcnaddr)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
                cls_DALCN_DETAIL_LOCATION_KEEP = AddValue(cls_DALCN_DETAIL_LOCATION_KEEP)
                class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
            Next
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            Return class_xml
        End Function
    End Class
    Public Class DALCN_EDIT_REQUEST
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DALCN_EDIT_REQUEST
            Dim class_xml As New CLASS_DALCN_EDIT_REQUEST
            Dim dao_dalcn_edit As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
            class_xml.DALCN_EDIT_REQUESTs = AddValue(class_xml.DALCN_EDIT_REQUESTs)
            class_xml.DALCN_EDIT_REQUESTs.rcvno = 0


            For i As Integer = 0 To rows
                Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
                cls_DALCN_DETAIL_LOCATION_KEEP = AddValue(cls_DALCN_DETAIL_LOCATION_KEEP)
                class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
            Next
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            class_xml.phr_medical_type = ""
            Return class_xml


        End Function
    End Class
    Public Class DH
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _lctcd = ""
            _lcntpcd = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _lcntpcd = lcntpcd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DH
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DH

            Dim class_xml As New CLASS_DH


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.dh15rqts = AddValue(class_xml.dh15rqts)
            class_xml.dh15rqts.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_dh15tdgt As New dh15tdgt
                cls_dh15tdgt = AddValue(cls_dh15tdgt)
                class_xml.dh15tdgts.Add(cls_dh15tdgt)
            Next

            For i As Integer = 0 To rows
                Dim cls_dh15tpdcfrgn As New dh15tpdcfrgn
                cls_dh15tpdcfrgn = AddValue(cls_dh15tpdcfrgn)
                class_xml.dh15tpdcfrgns.Add(cls_dh15tpdcfrgn)
            Next

            For i As Integer = 0 To rows
                Dim cls_dh15frgn As New dh15frgn
                cls_dh15frgn = AddValue(cls_dh15frgn)
                class_xml.dh15frgns.Add(cls_dh15frgn)
            Next

            For i As Integer = 0 To rows
                Dim cls_dh15rqtdt As New dh15rqtdt
                cls_dh15rqtdt = AddValue(cls_dh15rqtdt)
                class_xml.dh15rqtdts.Add(cls_dh15rqtdt)
            Next

            For i As Integer = 0 To rows
                Dim cls_DH15_DETAIL_CER As New DH15_DETAIL_CER
                cls_DH15_DETAIL_CER = AddValue(cls_DH15_DETAIL_CER)
                'cls_DH15_DETAIL_CER.DOCUMENT_DATE = Date.Now
                'cls_DH15_DETAIL_CER.EXP_DOCUMENT_DATE = Date.Now
                class_xml.DH15_DETAIL_CERs.Add(cls_DH15_DETAIL_CER)
            Next

            For i As Integer = 0 To rows
                Dim cls_DH15_DETAIL_CASCHEMICAL As New DH15_DETAIL_CASCHEMICAL
                cls_DH15_DETAIL_CASCHEMICAL = AddValue(cls_DH15_DETAIL_CASCHEMICAL)
                class_xml.DH15_DETAIL_CASCHEMICALs.Add(cls_DH15_DETAIL_CASCHEMICAL)
            Next

            For i As Integer = 0 To rows
                Dim cls_DH15_DETAIL_MANUFACTURE As New DH15_DETAIL_MANUFACTURE
                cls_DH15_DETAIL_MANUFACTURE = AddValue(cls_DH15_DETAIL_MANUFACTURE)
                class_xml.DH15_DETAIL_MANUFACTUREs.Add(cls_DH15_DETAIL_MANUFACTURE)
            Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ''หน่วยปริมาณ
            'class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_drsunit()

            ''เลขที่ใบอนุญาต
            'class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)

            '' ประเภทใบอนุญาต
            'class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            'ที่อยู่บริษัท
            class_xml.DT_MASTER.DT15 = bao_master.SP_DALCNADDR_BY_FK_IDA(_LCN_IDA)

            Return class_xml


        End Function


    End Class

    Public Class DI
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                      Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            '_lctcd = lctcd
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DI
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DI

            Dim class_xml As New CLASS_DI


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.drimpfors = AddValue(class_xml.drimpfors)
            class_xml.drimpfors.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_drimpdrg As New drimpdrg
                cls_drimpdrg = AddValue(cls_drimpdrg)
                class_xml.drimpdrgs.Add(cls_drimpdrg)
            Next

            For i As Integer = 0 To rows
                Dim cls_drimpfrgn As New drimpfrgn
                cls_drimpfrgn = AddValue(cls_drimpfrgn)
                class_xml.drimpfrgns.Add(cls_drimpfrgn)
            Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)



            Return class_xml


        End Function


    End Class

    Public Class DP
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _lctcd = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                        Optional lctcd As Integer = 1, Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lctcd = lctcd
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DP
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DP

            Dim class_xml As New CLASS_DP


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.drpcbs = AddValue(class_xml.drpcbs)
            class_xml.drpcbs.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_drpcbdrg As New drpcbdrg
                cls_drpcbdrg = AddValue(cls_drpcbdrg)
                class_xml.drpcbdrgs.Add(cls_drpcbdrg)
            Next

            For i As Integer = 0 To rows
                Dim cls_drfrgn As New drfrgn
                cls_drfrgn = AddValue(cls_drfrgn)
                class_xml.drfrgns.Add(cls_drfrgn)
            Next

            For i As Integer = 0 To rows
                Dim cls_drfrgnaddr As New drfrgnaddr
                cls_drfrgnaddr = AddValue(cls_drfrgnaddr)
                class_xml.drfrgnaddrs.Add(cls_drfrgnaddr)
            Next

            For i As Integer = 0 To rows
                Dim cls_syspdcfrgn As New syspdcfrgn
                cls_syspdcfrgn = AddValue(cls_syspdcfrgn)
                class_xml.syspdcfrgns.Add(cls_syspdcfrgn)
            Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)


            Return class_xml


        End Function


    End Class

    Public Class DR
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _PVNCD = "10"
            _LCN_IDA = 0
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DR
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DR

            Dim class_xml As New CLASS_DR


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_IDA(_LCN_IDA)


            'Intial Default Value
            class_xml.drrgts = AddValue(class_xml.drrgts)
            class_xml.drrgts.lcnno = _lcnno


            'For i As Integer = 0 To rows
            '    Dim cls_drpcksize As New drpcksize
            '    cls_drpcksize = AddValue(cls_drpcksize)
            '    class_xml.drpcksizes.Add(cls_drpcksize)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drusedrg As New drusedrg
            '    cls_drusedrg = AddValue(cls_drusedrg)
            '    class_xml.drusedrgs.Add(cls_drusedrg)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drfrgn As New drfrgn
            '    cls_drfrgn = AddValue(cls_drfrgn)
            '    class_xml.drfrgns.Add(cls_drfrgn)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_dramldrg As New dramldrg
            '    cls_dramldrg = AddValue(cls_dramldrg)
            '    class_xml.dramldrgs.Add(cls_dramldrg)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_dramluse As New dramluse
            '    cls_dramluse = AddValue(cls_dramluse)
            '    class_xml.dramluses.Add(cls_dramluse)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drdrgchr As New drdrgchr
            '    cls_drdrgchr = AddValue(cls_drdrgchr)
            '    class_xml.drdrgchrs.Add(cls_drdrgchr)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drrgtnewdg As New drrgtnewdg
            '    cls_drrgtnewdg = AddValue(cls_drrgtnewdg)
            '    class_xml.drrgtnewdgs.Add(cls_drrgtnewdg)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drspec As New drspec
            '    cls_drspec = AddValue(cls_drspec)
            '    class_xml.drspecs.Add(cls_drspec)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_dreqto As New dreqto
            '    cls_dreqto = AddValue(cls_dreqto)
            '    class_xml.dreqtos.Add(cls_dreqto)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drfmlno As New drfmlno
            '    cls_drfmlno = AddValue(cls_drfmlno)
            '    class_xml.drfmlnos.Add(cls_drfmlno)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drfml As New drfml
            '    cls_drfml = AddValue(cls_drfml)
            '    class_xml.drfmls.Add(cls_drfml)
            'Next

            For i As Integer = 0 To rows
                Dim cls_DRRGT_DETAIL_ROLE As New DRRGT_DETAIL_ROLE
                cls_DRRGT_DETAIL_ROLE = AddValue(cls_DRRGT_DETAIL_ROLE)
                class_xml.DRRGT_DETAIL_ROLEs.Add(cls_DRRGT_DETAIL_ROLE)
            Next

            For i As Integer = 0 To rows
                Dim cls_atc As New DRRGT_ATC_DETAIL
                cls_atc = AddValue(cls_atc)
                class_xml.DRRGT_ATC_DETAIL.Add(cls_atc)
            Next
            'For i As Integer = 0 To rows
            '    Dim cls_cas As New DRRGT_DETAIL_CA
            '    cls_cas = AddValue(cls_cas)
            '    class_xml.DRRGT_DETAIL_CA.Add(cls_cas)
            'Next
            For i As Integer = 0 To rows
                Dim cls_pack As New DRRGT_PACKAGE_DETAIL
                cls_pack = AddValue(cls_pack)
                class_xml.DRRGT_PACKAGE_DETAIL.Add(cls_pack)
            Next
            '---------------------------------------------------------
            'For i As Integer = 0 To rows
            '    Dim cls_pro As New DRRGT_PRODUCER
            '    cls_pro = AddValue(cls_pro)
            '    class_xml.DRRGT_PRODUCER.Add(cls_pro)
            'Next

            For i As Integer = 0 To rows
                Dim cls_prop As New DRRGT_PROPERTy
                cls_prop = AddValue(cls_prop)
                class_xml.DRRGT_PROPERTy.Add(cls_prop)
            Next
            For i As Integer = 0 To rows
                Dim cls_prop As New DRRGT_PRODUCER_OTHER
                cls_prop = AddValue(cls_prop)
                class_xml.DRRGT_PRODUCER_OTHER.Add(cls_prop)
            Next

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_dalcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            '



            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)



            Return class_xml


        End Function

        Public Function gen_xml_ori(Optional rows As Integer = 0) As CLASS_DR

            Dim class_xml As New CLASS_DR


            Dim dao_dalcn As New DAO_DRUG.ClsDBdrrgt
            dao_dalcn.GetDataby_IDA(_IDA)


            'Intial Default Value
            class_xml.drrgts = AddValue(class_xml.drrgts)
            class_xml.drrgts.lcnno = _lcnno


            For i As Integer = 0 To rows
                Dim cls_DRRGT_DETAIL_ROLE As New DRRGT_DETAIL_ROLE
                cls_DRRGT_DETAIL_ROLE = AddValue(cls_DRRGT_DETAIL_ROLE)
                class_xml.DRRGT_DETAIL_ROLEs.Add(cls_DRRGT_DETAIL_ROLE)
            Next

            For i As Integer = 0 To rows
                Dim cls_atc As New DRRGT_ATC_DETAIL
                cls_atc = AddValue(cls_atc)
                class_xml.DRRGT_ATC_DETAIL.Add(cls_atc)
            Next
            'For i As Integer = 0 To rows
            '    Dim cls_cas As New DRRGT_DETAIL_CA
            '    cls_cas = AddValue(cls_cas)
            '    class_xml.DRRGT_DETAIL_CA.Add(cls_cas)
            'Next
            For i As Integer = 0 To rows
                Dim cls_pack As New DRRGT_PACKAGE_DETAIL
                cls_pack = AddValue(cls_pack)
                class_xml.DRRGT_PACKAGE_DETAIL.Add(cls_pack)
            Next
            '---------------------------------------------------------
            'For i As Integer = 0 To rows
            '    Dim cls_pro As New DRRGT_PRODUCER
            '    cls_pro = AddValue(cls_pro)
            '    class_xml.DRRGT_PRODUCER.Add(cls_pro)
            'Next

            For i As Integer = 0 To rows
                Dim cls_prop As New DRRGT_PROPERTy
                cls_prop = AddValue(cls_prop)
                class_xml.DRRGT_PROPERTy.Add(cls_prop)
            Next
            For i As Integer = 0 To rows
                Dim cls_prop As New DRRGT_PRODUCER_OTHER
                cls_prop = AddValue(cls_prop)
                class_xml.DRRGT_PRODUCER_OTHER.Add(cls_prop)
            Next

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_dalcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            '



            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)



            Return class_xml


        End Function
    End Class
    Public Class DR_ORI
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _PVNCD = "10"
            _LCN_IDA = 0
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0, Optional IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub


        Public Function gen_xml_ori(Optional rows As Integer = 0) As CLASS_DRRTG_ORIGINAL

            Dim class_xml As New CLASS_DRRTG_ORIGINAL


            Dim dao_dr As New DAO_DRUG.ClsDBdrrgt
            dao_dr.GetDataby_IDA(_IDA)

            Dim dao_atc As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
            dao_atc.GetDataby_FKIDA(_IDA)

            Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
            dao_color.GetDataby_FK_IDA(_IDA)

            Dim dao_cond As New DAO_DRUG.TB_DRRGT_CONDITION
            dao_cond.GetDataby_FK_IDA(_IDA)

            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)

            Dim dao_dbt As New DAO_DRUG.TB_DRRGT_DTB
            dao_dbt.GetDataby_FKIDA(_IDA)

            Dim dao_dtl As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            dao_dtl.GetDataby_FKIDA(_IDA)

            Dim dao_ea As New DAO_DRUG.TB_DRRGT_EACH
            dao_ea.GetDataby_FK_IDA(_IDA)

            Dim dao_eq As New DAO_DRUG.TB_DRRGT_EQTO
            dao_eq.GetDataby_FK_DRRQT_IDA(_IDA)

            Dim dao_keep As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
            dao_keep.GetDataby_FKIDA(_IDA)

            Dim dao_nu As New DAO_DRUG.TB_DRRGT_NO_USE
            dao_nu.GetDataby_FK_IDA(_IDA)

            Dim dao_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_nu.GetDataby_FK_IDA(_IDA)

            Dim dao_proin As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
            dao_proin.GetDataby_FK_IDA(_IDA)

            Dim dao_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
            dao_pro.GetDataby_FK_IDA(_IDA)

            Dim dao_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
            dao_prop.GetDataby_FK_IDA(_IDA)

            Dim dao_prop_det As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            dao_prop_det.GetDataby_FK_IDA(_IDA)

            class_xml.drrgts = dao_dr.fields
            class_xml.DRRGT_ATC_DETAILs.Add(dao_atc.fields)
            class_xml.DRRGT_COLORs.Add(dao_color.fields)
            class_xml.DRRGT_CONDITIONs.Add(dao_cond.fields)
            class_xml.DRRGT_DETAIL_CAs.Add(dao_cas.fields)
            class_xml.DRRGT_DTBs.Add(dao_dbt.fields)
            class_xml.DRRGT_DTL_TEXTs.Add(dao_dtl.fields)
            class_xml.DRRGT_EACHes.Add(dao_ea.fields)
            class_xml.DRRGT_EQTOs.Add(dao_eq.fields)
            class_xml.DRRGT_KEEP_DRUGs.Add(dao_keep.fields)
            class_xml.DRRGT_NO_USEs.Add(dao_nu.fields)
            class_xml.DRRGT_PACKAGE_DETAILs.Add(dao_pack.fields)
            class_xml.DRRGT_PRODUCER_INs.Add(dao_proin.fields)
            class_xml.DRRGT_PRODUCERs.Add(dao_pro.fields)
            class_xml.DRRGT_PROPERTies.Add(dao_prop.fields)
            class_xml.DRRGT_PROPERTIES_AND_DETAILs.Add(dao_prop_det.fields)


            Return class_xml
        End Function
    End Class
    Public Class DS
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _lcntpcd = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DS
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DS

            Dim class_xml As New CLASS_DS


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.drsamps = AddValue(class_xml.drsamps)
            class_xml.drsamps.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_drsampfmlno As New drsampfmlno
                cls_drsampfmlno = AddValue(cls_drsampfmlno)
                class_xml.drsampfmlnos.Add(cls_drsampfmlno)
            Next



            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            Return class_xml


        End Function


    End Class

    Public Class DS_NEW
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _lcntpcd = ""
            _PVNCD = "10"
            _PRODUCT_ID = 0
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0, Optional PRODUCT_ID As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
            _PRODUCT_ID = PRODUCT_ID
        End Sub

        ''' <summary>
        ''' DS
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DS

            Dim class_xml As New CLASS_DS

            'Intial Default Value
            class_xml.drsamps = AddValue(class_xml.drsamps)
            class_xml.drsamps.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_drsampfmlno As New drsampfmlno
                cls_drsampfmlno = AddValue(cls_drsampfmlno)
                class_xml.drsampfmlnos.Add(cls_drsampfmlno)
            Next
            For i As Integer = 0 To rows
                Dim cls_DRSAMP_DETAIL_CA As New DRSAMP_DETAIL_CA
                cls_DRSAMP_DETAIL_CA = AddValue(cls_DRSAMP_DETAIL_CA)
                class_xml.DRSAMP_DETAIL_CAS.Add(cls_DRSAMP_DETAIL_CA)
            Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            Return class_xml


        End Function


    End Class

    Public Class DRUG_REGISTRATION
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_REGISTRATION

            Dim class_xml As New CLASS_REGISTRATION


            Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_regis.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRUG_REGISTRATIONs = AddValue(class_xml.DRUG_REGISTRATIONs)
            class_xml.DRUG_REGISTRATIONs.PVNCD = _PVNCD
            class_xml.DRUG_REGISTRATIONs.LCNNO = _lcnno
            class_xml.DRUG_REGISTRATIONs.LCNSID = _lcnsid_customer

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            'หมวดยา
            class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_drkdofdrg()

            'ชนิดของยา
            class_xml.DT_MASTER.DT2 = bao_master.SP_MASTER_drdosage()

            'ขนาดบรรจุ
            class_xml.DT_MASTER.DT3 = bao_master.SP_MASTER_drsunit()

            'รูปแบบของยา
            class_xml.DT_MASTER.DT4 = bao_master.SP_MASTER_dactg()

            'ประเภทของยา
            class_xml.DT_MASTER.DT5 = bao_master.SP_MASTER_drclass()

            'สรรพคุณ
            class_xml.DT_MASTER.DT6 = bao_master.SP_MASTER_drkdofdrg()

            'กลุ่มตำรับ
            class_xml.DT_MASTER.DT7 = bao_master.SP_MASTER_dramlusetp()

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_ATC_DETAIL As New DRUG_REGISTRATION_ATC_DETAIL
                cls_DRUG_REGISTRATION_ATC_DETAIL = AddValue(cls_DRUG_REGISTRATION_ATC_DETAIL)
                class_xml.DRUG_REGISTRATION_ATC_DETAILs.Add(cls_DRUG_REGISTRATION_ATC_DETAIL)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_DETAIL_CAS As New DRUG_REGISTRATION_DETAIL_CA
                cls_DRUG_REGISTRATION_DETAIL_CAS = AddValue(cls_DRUG_REGISTRATION_DETAIL_CAS)
                class_xml.DRUG_REGISTRATION_DETAIL_CA.Add(cls_DRUG_REGISTRATION_DETAIL_CAS)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_PACKAGE_DETAIL As New DRUG_REGISTRATION_PACKAGE_DETAIL
                cls_DRUG_REGISTRATION_PACKAGE_DETAIL = AddValue(cls_DRUG_REGISTRATION_PACKAGE_DETAIL)
                class_xml.DRUG_REGISTRATION_PACKAGE_DETAILs.Add(cls_DRUG_REGISTRATION_PACKAGE_DETAIL)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_PRODUCER As New DRUG_REGISTRATION_PRODUCER
                cls_DRUG_REGISTRATION_PRODUCER = AddValue(cls_DRUG_REGISTRATION_PRODUCER)
                class_xml.DRUG_REGISTRATION_PRODUCER.Add(cls_DRUG_REGISTRATION_PRODUCER)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_PROPERTIES As New DRUG_REGISTRATION_PROPERTy
                cls_DRUG_REGISTRATION_PROPERTIES = AddValue(cls_DRUG_REGISTRATION_PROPERTIES)
                class_xml.DRUG_REGISTRATION_PROPERTy.Add(cls_DRUG_REGISTRATION_PROPERTIES)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_COLOR As New DRUG_REGISTRATION_COLOR
                cls_DRUG_REGISTRATION_COLOR = AddValue(cls_DRUG_REGISTRATION_COLOR)
                cls_DRUG_REGISTRATION_COLOR.COLOR1 = "0"
                cls_DRUG_REGISTRATION_COLOR.COLOR2 = "0"
                cls_DRUG_REGISTRATION_COLOR.COLOR3 = "0"
                cls_DRUG_REGISTRATION_COLOR.COLOR4 = "0"
                class_xml.DRUG_REGISTRATION_COLOR.Add(cls_DRUG_REGISTRATION_COLOR)
            Next
            Return class_xml


        End Function


    End Class


    Public Class Cer
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _IDA = 0
            _fdtypecd = ""
            _fdtypenm = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional ByVal lctcd As Integer = 1, Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lctcd = lctcd
            _LCN_IDA = LCN_IDA

        End Sub

        Public Shadows Function gen_xml_CER(Optional rows As Integer = 0) As CLASS_CER
            Dim class_xml_cer As New CLASS_CER


            'คนที่login

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Dim dao_customer_addr As New DAO_CPN.clsDBsyslctaddr

            Dim dao_ID As New DAO_CPN.clsDBsyslcnsid
            'dao_falcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao_customer.GetDataby_lcnsid(_lcnsid_customer)
            dao_ID.GetDataby_lcnsid(_lcnsid_customer)



            'Intial Default Value
            class_xml_cer.CERs = AddValue(class_xml_cer.CERs)
            class_xml_cer.CERs.IDENTIFY = dao_ID.fields.identify
            class_xml_cer.CERs.LCNSID = dao_ID.fields.lcnsid
            'class_xml_cer.CERs.lmdfdate = Date.Now()


            For i As Integer = 0 To rows
                Dim cls_CER_DRTYPE As New CER_DRTYPE

                cls_CER_DRTYPE = AddValue2(cls_CER_DRTYPE)
                class_xml_cer.CER_FDTYPE.Add(cls_CER_DRTYPE)
            Next

            For i As Integer = 0 To rows
                Dim cls_CER_REF As New CER_REF

                cls_CER_REF = AddValue2(cls_CER_REF)

                class_xml_cer.CER_REF.Add(cls_CER_REF)
            Next
            For i As Integer = 0 To rows
                Dim cls_lgt_impcerref As New lgt_impcerref

                cls_lgt_impcerref = AddValue2(cls_lgt_impcerref)

                class_xml_cer.lgt_impcerref.Add(cls_lgt_impcerref)
            Next

            For i As Integer = 0 To 0
                Dim cls_CER_DETAIL_CASCHEMICAL As New CER_DETAIL_CASCHEMICAL

                cls_CER_DETAIL_CASCHEMICAL = AddValue2(cls_CER_DETAIL_CASCHEMICAL)

                class_xml_cer.CER_DETAIL_CASCHEMICALs.Add(cls_CER_DETAIL_CASCHEMICAL)
            Next

            For i As Integer = 0 To rows
                Dim cls_CER_DETAIL_MANUFACTURE As New CER_DETAIL_MANUFACTURE

                cls_CER_DETAIL_MANUFACTURE = AddValue2(cls_CER_DETAIL_MANUFACTURE)

                class_xml_cer.CER_DETAIL_MANUFACTUREs.Add(cls_CER_DETAIL_MANUFACTURE)
            Next



            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml_cer.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml_cer.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)


            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            class_xml_cer.LCNNO_SHOW = ""
            class_xml_cer.TYPE_IMPORT = ""

            Return class_xml_cer


        End Function

    End Class

    Public Class EDIT_REQUEST
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _AUTO_ID = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional ByVal lctcd As Integer = 1, Optional ByVal LCN_IDA As Integer = 0, Optional ByVal AUTO_ID As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lctcd = lctcd
            _LCN_IDA = LCN_IDA
            _AUTO_ID = AUTO_ID
        End Sub

        Public Shadows Function gen_xml_EDIT_REQUEST(Optional rows As Integer = 0) As CLASS_EDIT_REQUEST

            Dim class_xml As New CLASS_EDIT_REQUEST

            'คนที่login

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Dim dao_customer_addr As New DAO_CPN.clsDBsyslctaddr

            Dim dao_ID As New DAO_CPN.clsDBsyslcnsid
            'dao_falcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao_customer.GetDataby_lcnsid(_lcnsid_customer)
            dao_ID.GetDataby_lcnsid(_lcnsid_customer)


            'Intial Default Value
            class_xml.EDIT_REQUESTs = AddValue(class_xml.EDIT_REQUESTs)
            class_xml.AUTO_ID = _AUTO_ID
            '   AddValue(class_xml.lgt_impcer)
            'class_xml.EDIT_REQUESTs.lcnsid = _lcnsid_customer
            'class_xml.EDIT_REQUESTs.appvdate = Date.Now()
            'class_xml.EDIT_REQUESTs.certpcd = 0
            'class_xml.EDIT_REQUESTs.expdate = Date.Now
            'class_xml.EDIT_REQUESTs.lcnscd = 1
            'class_xml.EDIT_REQUESTs.lctcd = _lctcd
            'class_xml.EDIT_REQUESTs.lctnmcd = 1
            'class_xml.EDIT_REQUESTs.lmdfdate = Date.Now()
            'class_xml.EDIT_REQUESTs.rcvdate = Date.Now()


            'For i As Integer = 0 To rows
            '    Dim cls_CER_DRTYPE As New CER_DRTYPE

            '    cls_CER_DRTYPE = AddValue2(cls_CER_DRTYPE)
            '    class_xml.CER_FDTYPE.Add(cls_CER_DRTYPE)
            'Next





            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' bao_master.SP_MASTER_dactg.TableName = "ชื่อประเภทยา"
            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_dactg()

            'bao_master.SP_MASTER_fafdtype.TableName = "ประเทศ"
            ' class_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt()


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)

            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            ' ข้อมูลยา
            class_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_drrgt_BY_IDA(_LCN_IDA)

            'bao_master.SP_MASTER_fafdtype.TableName = "ประเภท Cer"
            ' class_xml.DT_MASTER.DT13 = bao_master.SP_MASTER_lgt_impcertp()



            Return class_xml


        End Function

    End Class

    Public Class DRUG_PROJECT
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRUG_PROJECT

            Dim class_xml As New CLASS_DRUG_PROJECT


            Dim dao_regis As New DAO_DRUG.ClsDBDRUG_PROJECT
            'dao_regis.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRUG_PROJECTs = AddValue(class_xml.DRUG_PROJECTs)
            'class_xml.DRUG_REGISTRATIONs.PVNCD = _PVNCD
            class_xml.DRUG_PROJECTs.LCNNO = _lcnno
            'class_xml.DRUG_PROJECTs.LCNSI = _lcnsid_customer

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)

            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)


            Return class_xml

        End Function


    End Class

    Public Class PHARMACIST
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional LCN_IDA As Integer = 0
                       )
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_PHARMACIST

            Dim class_xml As New CLASS_PHARMACIST


            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            'dao_regis.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DALCN_PHRs = AddValue(class_xml.DALCN_PHRs)
            'class_xml.DRUG_REGISTRATIONs.PVNCD = _PVNCD
            'class_xml.DALCN_PHRs.LCNNO = _lcnno
            'class_xml.DRUG_REGISTRATIONs.LCNSID = _lcnsid_customer

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)

            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)


            Return class_xml


        End Function


    End Class

    Public Class CHEMICAL_REQUEST
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional LCN_IDA As Integer = 0
                       )
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' เพิ่มสาร
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_CHEMICAL_REQUEST

            Dim class_xml As New CLASS_CHEMICAL_REQUEST

            'Intial Default Value
            class_xml.CHEMICAL_REQUESTs = AddValue(class_xml.CHEMICAL_REQUESTs)

            Return class_xml
        End Function
    End Class


    Public Class DRUG_CONSIDER_REQUEST
        Inherits Center




        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As XML_CONSIDER_REQUESTS

            Dim class_xml As New XML_CONSIDER_REQUESTS




            'Intial Default Value
            class_xml.DRUG_CONSIDER_REQUESTs = AddValue(class_xml.DRUG_CONSIDER_REQUESTs)


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""

            Return class_xml


        End Function


    End Class

    Public Class drsamp
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String

        Private product_id_ida As String
        Private product_id_LCN_IDA As String
        Private product_id_FK_IDA As String
        Private TR_ID As String
        Private CITIEZEN_SUBMIT As String
        Private _staff_identify As String
        Private _staff_consider_iden As String

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""

            product_id_ida = ""
            product_id_LCN_IDA = ""
            product_id_FK_IDA = ""
            TR_ID = ""
            CITIEZEN_SUBMIT = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "", Optional product_ida As String = "", Optional product_lcnno As String = "", Optional product_fkida As String = "", Optional rcvr_id As String = "", Optional staff_offer_iden As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type

            product_id_ida = phr_medical_type
            product_id_LCN_IDA = opentime
            product_id_FK_IDA = product_ida
            TR_ID = product_lcnno
            CITIEZEN_SUBMIT = product_fkida
            _staff_identify = rcvr_id
            _staff_consider_iden = staff_offer_iden

        End Sub


        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRSAMP

            Dim class_xml As New CLASS_DRSAMP
            Dim bao As New BAO.ClsDBSqlcommand

            'Intial Default Value
            'class_xml.drsamps = AddValue(class_xml.drsamps)


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT1 = bao.SP_DRUG_PRODUCT_ID(product_id_ida) 'ดึงบัญชีรายการยา
            class_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(product_id_LCN_IDA)    'ข้อมูลที่อยู่สถาณที่
            class_xml.DT_SHOW.DT3 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(product_id_ida) 'ดึงตัวยาสำคัญ
            class_xml.DT_SHOW.DT3.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(product_id_ida)    'ขนาดบรรจุ
            'class_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(product_id_ida) 'ใบนยม
            'class_xml.DT_SHOW.DT6 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM2(product_id_ida) 'เก็บตกหล่น
            class_xml.DT_SHOW.DT7 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(product_id_ida) 'ดึงตัวยาสำคัญ
            class_xml.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml.DT_SHOW.DT8 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(product_id_ida)    'ขนาดบรรจุ
            class_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(CITIEZEN_SUBMIT)
            Try
                class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(product_id_FK_IDA) 'ผู้ดำเนิน
            Catch ex As Exception

            End Try

            Try
                class_xml.DT_SHOW.DT15 = bao_show.SP_MAINPERSON_CTZNO(_staff_identify)
            Catch ex As Exception

            End Try

            'Try
            '    class_xml.DT_SHOW.DT16 = bao_show.SP_MAINPERSON_CTZNO(_staff_consider_iden)
            'Catch ex As Exception

            'End Try


            '_______________MASTER_________________
            'Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            'class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = "" 
            'class_xml.RCVDAY = ""
            'class_xml.RCVMONTH = ""
            'class_xml.RCVYEAR = ""

            Return class_xml


        End Function


    End Class
    Public Class drsamp2
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String

        Private product_id_ida As String
        Private product_id_LCN_IDA As String
        Private product_id_FK_IDA As String
        Private _phr_fkida As Integer
        Private product_id_TR_ID As String
        Private _citizen_submit As String
        Private _phesaj_ida As String
        Private _staff_app As String
        Private _staff_rcv As String

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""

            product_id_ida = ""
            product_id_LCN_IDA = ""
            product_id_FK_IDA = ""
            product_id_TR_ID = ""
            _staff_app = ""
            _staff_rcv = ""
            _phesaj_ida = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "", Optional product_ida As String = "", Optional product_lcnno As String = "", Optional product_fkida As String = "", Optional staff_app As String = "", Optional staff_rcv As String = "", Optional phesaj_ida As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type

            product_id_ida = phr_medical_type
            product_id_LCN_IDA = opentime
            product_id_FK_IDA = product_ida
            '_phr_fkida = product_lcnno
            _phr_fkida = Convert.ToInt32(product_lcnno)
            product_id_TR_ID = product_fkida
            _staff_app = staff_app
            _phesaj_ida = phesaj_ida
            _staff_rcv = staff_rcv

        End Sub


        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRSAMP

            Dim class_xml As New CLASS_DRSAMP
            Dim bao As New BAO.ClsDBSqlcommand

            'Intial Default Value
            'class_xml.drsamps = AddValue(class_xml.drsamps)


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT1 = bao.SP_DRUG_PRODUCT_ID(product_id_ida) 'บัญชีรายการยา
            class_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(product_id_LCN_IDA) 'เลขที่ใบอนุญาต
            'class_xml.DT_SHOW.DT3 = bao.SP_PRODUCT_ID_CHEMICAL_FK_IDA(product_id_ida) 'ตัวยาสำคัญ
            class_xml.DT_SHOW.DT3 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(product_id_ida) 'ตัวยาสำคัญ
            class_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(product_id_ida) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(product_id_ida) 'ขนาดบรรจุ

            class_xml.DT_SHOW.DT7 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(product_id_ida) 'ดึงตัวยาสำคัญ multi
            class_xml.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml.DT_SHOW.DT8 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(product_id_ida)    'ขนาดบรรจุ multi
            class_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(_citizen_submit) 'ผู้ยื่น
            Try
                class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(product_id_FK_IDA) 'ผู้ดำเนิน
            Catch ex As Exception

            End Try
            Try
                class_xml.DT_SHOW.DT15 = bao_show.SP_MAINPERSON_CTZNO(_staff_rcv) 'ผู้รับคำขอ
            Catch ex As Exception

            End Try
            Try
                class_xml.DT_SHOW.DT16 = bao_show.SP_MAINPERSON_CTZNO(_staff_app) 'ผู้อนุมัติ
            Catch ex As Exception

            End Try

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            Try
                'class_xml.DT_MASTER.DT18 = bao_master.SP_DALCN_PHR_BY_FK_IDA(product_id_LCN_IDA) 'ผู้มีหน้าที่ปฏิบัติการ
                For Each dr As DataRow In bao_master.SP_DALCN_PHR_BY_FK_IDA(product_id_LCN_IDA).Rows
                    If dr("IDA") = _phesaj_ida Then
                        class_xml.phr_fullname = dr("PHR_FULLNAME")
                        class_xml.phr_nm = dr("FULLNAME")
                    End If
                Next
            Catch ex As Exception

            End Try
            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            'class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = "" 
            'class_xml.RCVDAY = ""
            'class_xml.RCVMONTH = ""
            'class_xml.RCVYEAR = ""

            Return class_xml


        End Function


    End Class

    Public Class Cer_foreign
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _IDA = 0
            _fdtypecd = ""
            _fdtypenm = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional ByVal lctcd As Integer = 1, Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lctcd = lctcd
            _LCN_IDA = LCN_IDA

        End Sub

        Public Shadows Function gen_xml_CER_FOR(Optional rows As Integer = 0) As CLASS_CER_FOREIGN
            Dim class_xml_cer As New CLASS_CER_FOREIGN


            'คนที่login

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Dim dao_customer_addr As New DAO_CPN.clsDBsyslctaddr

            Dim dao_ID As New DAO_CPN.clsDBsyslcnsid
            'dao_falcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao_customer.GetDataby_lcnsid(_lcnsid_customer)
            dao_ID.GetDataby_lcnsid(_lcnsid_customer)



            'Intial Default Value
            class_xml_cer.CER_FOREIGNs = AddValue(class_xml_cer.CER_FOREIGNs)
            class_xml_cer.CER_FOREIGNs.IDENTIFY = dao_ID.fields.identify
            class_xml_cer.CER_FOREIGNs.LCNSID = dao_ID.fields.lcnsid
            class_xml_cer.CER_FOREIGNs.lmdfdate = Date.Now()


            'For i As Integer = 0 To rows
            '    Dim cls_CER_FOREIGN_MANUFACTURE As New CER_FOREIGN_MANUFACTURE

            '    cls_CER_FOREIGN_MANUFACTURE = AddValue2(cls_CER_FOREIGN_MANUFACTURE)

            '    class_xml_cer.CER_FOREIGN_MANUFACTUREs.Add(cls_CER_FOREIGN_MANUFACTURE)
            'Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml_cer.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml_cer.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)


            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml_cer.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml_cer.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            Return class_xml_cer


        End Function

    End Class

    Public Class Cerf
        Inherits Center

        Private _cerf_ida As String

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _IDA = 0
            _fdtypecd = ""
            _fdtypenm = ""
            _cerf_ida = 0
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                   Optional ByVal lctcd As Integer = 1, Optional LCN_IDA As Integer = 0, Optional cerf_ida As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lctcd = lctcd
            _LCN_IDA = LCN_IDA
            _cerf_ida = cerf_ida

        End Sub

        Public Shadows Function gen_xml_CER(Optional rows As Integer = 0) As CLASS_CER_FOREIGN
            Dim class_xml_cer As New CLASS_CER_FOREIGN


            'คนที่login

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Dim dao_customer_addr As New DAO_CPN.clsDBsyslctaddr

            Dim dao_ID As New DAO_CPN.clsDBsyslcnsid
            'dao_falcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao_customer.GetDataby_lcnsid(_lcnsid_customer)
            dao_ID.GetDataby_lcnsid(_lcnsid_customer)

            'Dim dao_cerf As New DAO_DRUG.TB_CER_FOREIGN
            'dao_cerf.GetDataby_IDA(_cerf_ida)

            'Intial Default Value
            class_xml_cer.CER_FOREIGNs = AddValue(class_xml_cer.CER_FOREIGNs)
            'class_xml_cer.CER_FOREIGNs = dao_cerf.fields
            class_xml_cer.CER_FOREIGNs.IDENTIFY = dao_ID.fields.identify
            class_xml_cer.CER_FOREIGNs.LCNSID = dao_ID.fields.lcnsid
            class_xml_cer.CER_FOREIGNs.lmdfdate = Date.Now()


            For i As Integer = 0 To rows
                Dim cls_CER_DRTYPE As New CER_DRTYPE

                cls_CER_DRTYPE = AddValue2(cls_CER_DRTYPE)
                class_xml_cer.CER_FDTYPE.Add(cls_CER_DRTYPE)
            Next

            For i As Integer = 0 To rows
                Dim cls_CER_REF As New CER_REF

                cls_CER_REF = AddValue2(cls_CER_REF)

                class_xml_cer.CER_REF.Add(cls_CER_REF)
            Next
            For i As Integer = 0 To rows
                Dim cls_lgt_impcerref As New lgt_impcerref

                cls_lgt_impcerref = AddValue2(cls_lgt_impcerref)

                class_xml_cer.lgt_impcerref.Add(cls_lgt_impcerref)
            Next

            For i As Integer = 0 To 0
                Dim cls_CER_DETAIL_CASCHEMICAL As New CER_DETAIL_CASCHEMICAL

                cls_CER_DETAIL_CASCHEMICAL = AddValue2(cls_CER_DETAIL_CASCHEMICAL)

                class_xml_cer.CER_DETAIL_CASCHEMICALs.Add(cls_CER_DETAIL_CASCHEMICAL)
            Next

            For i As Integer = 0 To rows
                Dim cls_CER_DETAIL_MANUFACTURE As New CER_DETAIL_MANUFACTURE

                cls_CER_DETAIL_MANUFACTURE = AddValue2(cls_CER_DETAIL_MANUFACTURE)

                class_xml_cer.CER_DETAIL_MANUFACTUREs.Add(cls_CER_DETAIL_MANUFACTURE)
            Next



            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml_cer.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml_cer.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)


            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            class_xml_cer.LCNNO_SHOW = ""
            class_xml_cer.TYPE_IMPORT = ""

            Return class_xml_cer


        End Function

    End Class

    Public Class lcnrequest
        Inherits Center

        Private _CITIZEN_ID_AUTHORIZE As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        'Private _lcn_ida As String
        Private _lct_ida As String
        Private _FK_IDA As String
        Private _IDA As String
        Public Sub New()
            _CITIZEN_ID_AUTHORIZE = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            '_lctcd = ""
            _lcntpcd = ""
            _lct_ida = ""
        End Sub

        Public Sub New(Optional citizen_id_authorize As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0, Optional Fk_ida As Integer = 0, Optional ida As Integer = 0)
            _CITIZEN_ID_AUTHORIZE = citizen_id_authorize
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _lcntpcd = lcntpcd
            _LCN_IDA = LCN_IDA
            '_lct_ida = lct_ida
            _FK_IDA = Fk_ida
            _IDA = ida
        End Sub

        ''' <summary>
        ''' ต่ออายุใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_LCNREQUEST
            Dim class_xml As New CLASS_LCNREQUEST
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            Dim dao_lcnrequest As New DAO_DRUG.TB_lcnrequest
            'dao_lcnrequest.GetDataby_IDA(dao_dalcn.fields.IDA)
            'dao_dalcn.fields.IDA = dao_lcnrequest.fields.FK_IDA
            'dao_lcnrequest.fields.IDA = 


            'Intial Default Value
            class_xml.dalcns = AddValue(class_xml.dalcns)
            'class_xml.dalcns.pvncd = _PVNC
            class_xml.dalcns.lcnsid = _lcnsid_customer
            class_xml.dalcns.rcvno = 0
            class_xml.dalcns.CHK_SELL_TYPE = _CHK_SELL_TYPE
            'class_xml.dalcns.CHK_SELL_TYPE1 = _CHK_SELL_TYPE1

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(_FK_IDA) 'ข้อมูลสถานที่จำลอง
            class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, _lcnsid_customer) 'ข้อมูลที่ตั้งหลัก
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CITIZEN_ID_AUTHORIZE, _lcnsid_customer) 'ข้อมูลบริษัท
            class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, _lcnsid_customer) 'ที่เก็บ
            class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
            class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(_FK_IDA) 'ผู้ดำเนิน

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(_LCN_IDA) 'ใบอนุญาตสถานที่
            Try
                'class_xml.DT_MASTER.DT29 = bao_master.SP_MASTER_DALCN_LCNREQUEST_by_IDA(_IDA) 'ใบอนุญาตต่ออายุสถานที่
            Catch ex As Exception

            End Try

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.CHK_TYPE = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            'class_xml.SHOW_LCNNO = ""
            'class_xml.phr_medical_type = ""
            class_xml.dalcns.opentime = _opentime
            Return class_xml

        End Function
    End Class
    Public Class EXTEND
        Inherits Center

        Private _CITIZEN_ID_AUTHORIZE As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        'Private _lcn_ida As String
        Private _lct_ida As String
        Private _FK_IDA As String
        Private _IDA As String
        Public Sub New()
            _CITIZEN_ID_AUTHORIZE = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            '_lctcd = ""
            _lcntpcd = ""
            _lct_ida = ""
        End Sub

        Public Sub New(Optional citizen_id_authorize As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0, Optional Fk_ida As Integer = 0, Optional ida As Integer = 0)
            _CITIZEN_ID_AUTHORIZE = citizen_id_authorize
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _lcntpcd = lcntpcd
            _LCN_IDA = LCN_IDA
            '_lct_ida = lct_ida
            _FK_IDA = Fk_ida
            _IDA = ida
        End Sub

        ''' <summary>
        ''' ต่ออายุใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_EXTEND
            Dim class_xml As New CLASS_EXTEND
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            Dim dao_lcnrequest As New DAO_DRUG.TB_LCN_EXTEND_LITE
            'dao_lcnrequest.GetDataby_IDA(dao_dalcn.fields.IDA)
            'dao_dalcn.fields.IDA = dao_lcnrequest.fields.FK_IDA
            'dao_lcnrequest.fields.IDA = 


            'Intial Default Value
            class_xml.dalcns = AddValue(class_xml.dalcns)
            'class_xml.dalcns.pvncd = _PVNC
            class_xml.dalcns.lcnsid = _lcnsid_customer
            class_xml.dalcns.rcvno = 0
            class_xml.dalcns.CHK_SELL_TYPE = _CHK_SELL_TYPE
            'class_xml.dalcns.CHK_SELL_TYPE1 = _CHK_SELL_TYPE1

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(_FK_IDA) 'ข้อมูลสถานที่จำลอง
            class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, _lcnsid_customer) 'ข้อมูลที่ตั้งหลัก
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CITIZEN_ID_AUTHORIZE, _lcnsid_customer) 'ข้อมูลบริษัท
            class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, _lcnsid_customer) 'ที่เก็บ
            class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
            'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(_FK_IDA) 'ผู้ดำเนิน

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            'class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(_LCN_IDA) 'ใบอนุญาตสถานที่
            Try
                'class_xml.DT_MASTER.DT29 = bao_master.SP_MASTER_DALCN_LCNREQUEST_by_IDA(_IDA) 'ใบอนุญาตต่ออายุสถานที่
            Catch ex As Exception

            End Try

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.CHK_TYPE = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            'class_xml.SHOW_LCNNO = ""
            'class_xml.phr_medical_type = ""
            class_xml.dalcns.opentime = _opentime
            Return class_xml

        End Function
    End Class
    Public Class NYM1
        Inherits Center

        Private _drs_ida As Integer
        Private _pjsum_ida As Integer
        Private _citizen As String
        Private _citizen_autho As String

        Public Sub New()

        End Sub

        Public Sub New(Optional drs_ida As Integer = 0, Optional lcnno As String = "",
                   Optional ByVal pjsum_ida As Integer = 0, Optional citizen As String = "", Optional citizen_autho As String = "")
            _drs_ida = drs_ida
            _lcnno = lcnno
            _pjsum_ida = pjsum_ida
            _citizen = citizen
            _citizen_autho = citizen_autho


        End Sub

        Public Shadows Function gen_xml_NYM1(Optional rows As Integer = 0) As CLASS_PROJECT_SUM
            Dim class_xml As New CLASS_PROJECT_SUM

            Dim bao As New BAO.ClsDBSqlcommand

            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_drs_ida)
            Dim dao2 As New DAO_DRUG.ClsDBdalcn
            dao2.GetDataby_IDA(_lcnno)
            Dim dao_pjsum As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao_pjsum.GetDataby_IDA(_pjsum_ida)
            class_xml.DRUG_PROJECT_SUMMARY = dao_pjsum.fields

            Dim dao_fac As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
            dao_fac.GetDataby_PROJECT(_pjsum_ida)
            For Each dao_fac.datas In dao_fac.datas
                class_xml.DRUG_PROJECT_RESEARCH_FACILITYS.Add(dao_fac.datas)
            Next

            Dim dao_lab As New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
            dao_lab.GetDataby_PROJECT(_pjsum_ida)
            For Each dao_lab.datas In dao_lab.datas
                class_xml.DRUG_PROJECT_CLINICAL_LABORATORYS.Add(dao_lab.datas)
            Next

            Dim dao_dl As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
            dao_dl.GetDataby_PROJECT(_pjsum_ida)
            For Each dao_dl.datas In dao_dl.datas
                class_xml.DRUG_PROJECT_DRUG_LISTS.Add(dao_dl.datas)
            Next

            class_xml.dalcns = dao2.fields
            class_xml.LCNNO_SHOWS = dao2.fields.LCNNO_DISPLAY
            class_xml.drsamp = dao.fields
            class_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM(_pjsum_ida, 3)
            class_xml.DT_SHOW.DT6 = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM(_pjsum_ida, 4)

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'ชื่อผู้ใช้ระบบ
            class_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(_citizen)
            'ชื่อบริษัท
            class_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(_citizen_autho)

            class_xml.DT_SHOW.DT20 = bao.SP_DRSAMP_RCV(dao_pjsum.fields.TR_ID)

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            Return class_xml

        End Function

    End Class
    Public Class EDIT_LCN
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_EDIT_LCN
            Dim class_xml As New CLASS_EDIT_LCN
            Dim dao As New DAO_DRUG.TB_EDT_HISTORY
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.EDT_HISTORIES = AddValue(class_xml.EDT_HISTORIES)

            Return class_xml


        End Function
    End Class

    Public Class OTHER_XML
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_OTHER_XML
            Dim class_xml As New CLASS_OTHER_XML
            Dim dao As New DAO_DRUG.TB_drsunit
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao.GetDataALL()

            'Intial Default Value
            'class_xml.drsunits = AddValue(dao.datas)
            For Each dao.datas In dao.datas
                class_xml.drsunit.Add(dao.datas)
            Next





            Return class_xml

        End Function
    End Class
    Public Class PHR_CANCEL
        Inherits Center
        Private _PHR_CTZNO As String
        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
            _PHR_CTZNO = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "", Optional _PHR_CTZNO As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
            _PHR_CTZNO = _PHR_CTZNO
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_PHARMACIST_CANCEL
            Dim class_xml As New CLASS_PHARMACIST_CANCEL
            Dim dao As New DAO_DRUG.TB_DALCN_PHR_CANCEL_DETAIL
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao.GetDataAll()

            'Intial Default Value
            'class_xml.drsunits = AddValue(dao.datas)
            For Each dao.datas In dao.datas
                ' class_xml.drsunit.Add(dao.datas)
                class_xml.DALCN_PHR_CANCEL_DETAIL.Add(dao.datas)
            Next

            '_______________SHOW___________________


            '_______________MASTER___________________
            Return class_xml

        End Function
    End Class
    Public Class EDIT_DRRGT
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_EDIT_DRRGT
            Dim class_xml As New CLASS_EDIT_DRRGT
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_EDIT_REQUESTs = AddValue(class_xml.DRRGT_EDIT_REQUESTs)
            class_xml.DRRGT_EDIT_REQUESTs.pvncd = _PVNCD
            class_xml.DRRGT_EDIT_REQUESTs.lcnsid = _lcnsid_customer
            class_xml.DRRGT_EDIT_REQUESTs.rcvno = 0
            class_xml.DRRGT_EDIT_REQUESTs.FK_IDA = 0
            class_xml.DRRGT_EDIT_REQUESTs.TR_ID = 0
            class_xml.DRRGT_EDIT_REQUESTs.STATUS_ID = 0
            class_xml.DRRGT_EDIT_REQUESTs.cnccd = 0
            class_xml.DRRGT_EDIT_REQUESTs.cnccscd = 0


            'class_xml.DRRGT_COLORs.FK_IDA = "0"
            'class_xml.DRRGT_COLORs.IDA = 0
            'class_xml.DRRGT_COLORs = AddValue(class_xml.DRRGT_COLORs)


            'class_xml.DRRGT_COLORs = AddValue(class_xml.DRRGT_COLORs)

            For i As Integer = 0 To rows
                Dim cls_DRRGT_COLOR As New DRRGT_COLOR
                cls_DRRGT_COLOR = AddValue(cls_DRRGT_COLOR)
                cls_DRRGT_COLOR.COLOR1 = "0"
                cls_DRRGT_COLOR.COLOR2 = "0"
                cls_DRRGT_COLOR.COLOR3 = "0"
                cls_DRRGT_COLOR.COLOR4 = "0"
                class_xml.DRRGT_COLORs.Add(cls_DRRGT_COLOR)
            Next


            For i As Integer = 0 To rows
                Dim cls_DRRGT_PACKAGE_DETAIL As New DRRGT_PACKAGE_DETAIL
                cls_DRRGT_PACKAGE_DETAIL = AddValue(cls_DRRGT_PACKAGE_DETAIL)
                class_xml.DRRGT_PACKAGE_DETAILs.Add(cls_DRRGT_PACKAGE_DETAIL)
            Next
            '---------------------------เอาออกชั่วคราว
            'For i As Integer = 0 To rows
            '    Dim cls_DRRGT_DETAIL_CA As New DRRGT_DETAIL_CA
            '    cls_DRRGT_DETAIL_CA = AddValue(cls_DRRGT_DETAIL_CA)
            '    class_xml.DRRGT_DETAIL_CASes.Add(cls_DRRGT_DETAIL_CA)
            'Next
            'For i As Integer = 0 To rows
            '    Dim cls_DRRGT_DETAIL_CA As New DRRGT_EDIT_REQUEST_CA
            '    cls_DRRGT_DETAIL_CA = AddValue(cls_DRRGT_DETAIL_CA)
            '    class_xml.DRRGT_EDIT_REQUEST_CASes.Add(cls_DRRGT_DETAIL_CA)
            'Next
            '-----------------------------------------

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class

    Public Class DRRGT_SUB
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRRGT_SUB
            Dim class_xml As New CLASS_DRRGT_SUB
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_SUBSTITUTEs = AddValue(class_xml.DRRGT_SUBSTITUTEs)
            class_xml.DRRGT_SUBSTITUTEs.pvncd = _PVNCD
            class_xml.DRRGT_SUBSTITUTEs.lcnsid = _lcnsid_customer
            class_xml.DRRGT_SUBSTITUTEs.rcvno = 0
            class_xml.DRRGT_SUBSTITUTEs.FK_IDA = 0
            class_xml.DRRGT_SUBSTITUTEs.TR_ID = 0
            class_xml.DRRGT_SUBSTITUTEs.STATUS_ID = 0



            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function



    End Class
    Public Class DRRGT_SPC_GEN
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As String
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As String = "0",
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRRGT_SPC
            Dim class_xml As New CLASS_DRRGT_SPC
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_SPC
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_SPCs = AddValue(class_xml.DRRGT_SPCs)
            class_xml.DRRGT_SPCs.pvncd = _PVNCD
            class_xml.DRRGT_SPCs.FK_IDA = 0
            class_xml.DRRGT_SPCs.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class
    Public Class DRRGT_PI_GEN
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As String
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As String = "0",
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRRGT_PI
            Dim class_xml As New CLASS_DRRGT_PI
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_PI
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_PIs = AddValue(class_xml.DRRGT_PIs)
            class_xml.DRRGT_PIs.pvncd = _PVNCD
            class_xml.DRRGT_PIs.FK_IDA = 0
            class_xml.DRRGT_PIs.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class
    Public Class DRRGT_PIL_GEN
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As String
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As String = "0",
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRRGT_PIL
            Dim class_xml As New CLASS_DRRGT_PIL
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_PIL
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_PILs = AddValue(class_xml.DRRGT_PILs)
            class_xml.DRRGT_PILs.pvncd = _PVNCD
            class_xml.DRRGT_PILs.FK_IDA = 0
            class_xml.DRRGT_PILs.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class

    Public Class T_NCT_DALCN_TEMP
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As String
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As String = "0",
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_TEMP_NCT_DALCN
            Dim class_xml As New CLASS_TEMP_NCT_DALCN
            Dim dao_edt As New DAO_DRUG.TB_TEMP_NCT_DALCN
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.TEMP_NCT_DALCNs = AddValue(class_xml.TEMP_NCT_DALCNs)
            class_xml.TEMP_NCT_DALCNs.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class

    Public Class DALCN_NCT_SUB
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DALCN_NCT_SUBSTITUTE
            Dim class_xml As New CLASS_DALCN_NCT_SUBSTITUTE
            Dim dao_dalcn_edit As New DAO_DRUG.TB_DALCN_NCT_SUBSTITUTE
            class_xml.DALCN_NCT_SUBSTITUTEs = AddValue(class_xml.DALCN_NCT_SUBSTITUTEs)
            class_xml.DALCN_NCT_SUBSTITUTEs.rcvno = 0
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            class_xml.phr_medical_type = ""
            Return class_xml


        End Function
    End Class
    Public Class DALCN_SUB
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DALCN_SUBSTITUTE
            Dim class_xml As New CLASS_DALCN_SUBSTITUTE
            Dim dao_dalcn_edit As New DAO_DRUG.TB_DALCN_SUBSTITUTE
            class_xml.DALCN_SUBSTITUTEs = AddValue(class_xml.DALCN_SUBSTITUTEs)
            class_xml.DALCN_SUBSTITUTEs.rcvno = 0
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            class_xml.phr_medical_type = ""
            Return class_xml


        End Function
    End Class

    Public Class LCN_EDIT_SMP3
        Inherits Center

        Public Function gen_xml(ByVal IDA As Integer, ByVal IDA_LCN As Integer, ByVal _YEAR As String)
            Dim XML As New CLS_LCN_EDIT_SMP3

            'Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
            'dao.GetDataby_IDA_YEAR(IDA, _YEAR, True)
            'XML.LCN_APPROVE_EDIT = dao.fields

            Dim dt1, dt2 As New DataTable
            Dim bao As New BAO_LCN.BIND_DT_XML
            dt1 = bao.SP_LCN_APPROVE_EDIT_GET_DATA_XML1(IDA, _YEAR)

            dt1.Columns.Add("CREATE_DATE_FULL")
            dt1.Columns.Add("STAFF_RQ_DATE_FULL")

            For Each dr As DataRow In dt1.Rows
                Dim status As Integer = 0
                Dim create_date_full As Date
                Dim rq_date_full As Date


                Dim create_date_Show As String = ""
                Dim rq_date_Show As String = ""

                Try
                    status = dr("STATUS_ID")
                Catch ex As Exception

                End Try

                Try
                    create_date_full = dr("CREATE_DATE")
                Catch ex As Exception

                End Try

                Try
                    rq_date_full = dr("STAFF_RQ_DATE")
                Catch ex As Exception

                End Try

                Try
                    If status = 2 Then
                        rq_date_Show = ""
                    Else
                        rq_date_Show = rq_date_full.Day.ToString() & " " & rq_date_full.ToString("MMMM") & " " & con_year(rq_date_full.Year)
                    End If


                Catch ex As Exception

                End Try
                create_date_Show = create_date_full.Day.ToString() & " " & create_date_full.ToString("MMMM") & " " & con_year(create_date_full.Year)

                dr("STAFF_RQ_DATE_FULL") = rq_date_Show
                dr("CREATE_DATE_FULL") = create_date_Show

            Next

            dt1.TableName = "XML_LCN_APPROVE_EDIT"

            dt2 = bao.SP_LCN_APPROVE_EDIT_GET_DATA_XML2(IDA_LCN, _YEAR)
            dt2.TableName = "XML_LCN_APPROVE_EDIT_FILE_UPLOAD"


            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(IDA_LCN)
            Dim dt_lcn As New DataTable
            Dim bao_lcn As New BAO_SHOW

            dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            dt_lcn.TableName = "XML_LCN_EDIT_LOCATION_ADDRESS"

            XML.DT_SHOW.DT1 = dt1
            XML.DT_SHOW.DT2 = dt2
            XML.DT_SHOW.DT3 = dt_lcn

            Return XML
        End Function

    End Class

    Public Class TABEAN_HERB_JJ
        Inherits Center

        Public Function gen_xml(ByVal IDA As Integer, ByVal IDA_LCN As Integer)
            Dim XML As New CLS_TABEAN_HERB_JJ
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER

            'Dim dt As New DataTable
            Dim dt_lcn As New DataTable
            Dim dt_lcn2 As New DataTable
            Dim dt_lcn_location As New DataTable
            Dim dt_jj As New DataTable

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(IDA)
            Dim Drug_name_jj As String = ""
            If dao.fields.NAME_THAIFULL Is Nothing Then
                Drug_name_jj = dao.fields.NAME_THAI
            Else
                Drug_name_jj = dao.fields.NAME_THAIFULL
            End If
            dao.fields.NAME_THAI = Drug_name_jj

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(IDA_LCN)

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

            Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Dim dao_pfx2 As New DAO_CPN.TB_sysprefix
            Try
                dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
                dao_pfx2.Getdata_byid(dao_customer.fields.prefixcd)
            Catch ex As Exception

            End Try
            Try
                dao_esub.GetDataby_LCN_IDA(IDA_LCN)
            Catch ex As Exception

            End Try
            Dim dao_who As New DAO_WHO.TB_WHO_DALCN
            dao_who.GetdatabyID_FK_LCN_IDEN(IDA_LCN, dao.fields.CITIZEN_ID_AUTHORIZE)
            Dim THANM As String = dao_lcn.fields.thanm
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_pfx2.fields.thanm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(IDA_LCN)
            Catch ex As Exception

            End Try
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Try
                dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
                Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
                Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
                BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            Catch ex As Exception

            End Try
            Dim citizen_bsn As String = tb_location.fields.BSN_IDENTIFY
            Dim person_age As String = ""
            Dim NATIONALITY_PERSON As String = ""
            Try
                person_age = dao.fields.PERSON_AGE
                If dao.fields.NATIONALITY_PERSON_ID = 1 Then
                    NATIONALITY_PERSON = dao.fields.NATIONALITY_PERSON
                Else
                    NATIONALITY_PERSON = dao.fields.NATIONALITY_PERSON_OTHER
                End If
            Catch ex As Exception

            End Try

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            'Dim THANM As String = dao_lcn.fields.thanm

            Dim CITIZEN_ID As String = dao.fields.CITIZEN_ID
            Dim CITIZEN_ID_AUTHORIZE As String = dao.fields.CITIZEN_ID_AUTHORIZE
            Dim NAME_JJ As String = dao.fields.NAME_JJ
            Dim THANAMEPLACE As String = dao.fields.LCN_THANAMEPLACE
            Dim bao_com As New BAO.ClsDBSqlcommand
            'ข้อ 2 
            If TYPE_PERSON = 1 Then
                XML.TYPE_PERSON_1 = TYPE_PERSON
                If dao.fields.WHO_ID = True Then
                    '        dt_lcn2 = BAO_SP.SP_XML_WHO_DALCN(dao_drrqt.fields.IDA)
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                    dt_lcn2 = bao_com.SP_Lisense_Name_and_Addr(dao.fields.CITIZEN_ID_AUTHORIZE) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")
                    For Each dr As DataRow In dt_lcn.Rows
                        For Each dr2 As DataRow In dt_lcn2.Rows
                            Try
                                dr("THANM") = dr2("tha_fullname")
                                XML.BSN_THAINAME = dr2("tha_fullname")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaaddr") = dr2("thaaddr")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaaddr_NO") = dr2("thaaddr")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID") = dr2("identify")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thamu") = dr2("mu")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tharoad") = dr2("tharoad")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thabuilding") = dr2("thabuilding")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thasoi") = dr2("thasoi")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thathmblnm") = dr2("thathmblnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaamphrnm") = dr2("thaamphrnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thachngwtnm") = dr2("thachngwtnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("zipcode") = dr2("zipcode")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NAME") = THANM
                            Catch ex As Exception

                            End Try
                            Try
                                'dr("NAME_JJ") = NAME_JJ
                                dr("NAME_JJ") = dr2("tha_fullname")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tel") = dr2("tel")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("fax") = dr2("fax")
                            Catch ex As Exception

                            End Try
                        Next
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next

                Else
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") <> "" And dr("tel") <> "" Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            'dr("NAME_JJ") = NAME_JJ
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next
                End If
                dt_lcn.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_PERSON_1"
                XML.DT_SHOW.DT3 = dt_lcn
                'ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Or TYPE_PERSON = 11 Then
            Else
                Dim TYPE_PERSONNITI_99 As Integer = 99
                XML.TYPE_PERSON_99 = TYPE_PERSONNITI_99
                If TYPE_PERSON = 1 Then
                    XML.BSN_THAIFULLNAME = THANM
                    'ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Or TYPE_PERSON = 11 Then
                Else
                    XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
                End If
                If dao.fields.WHO_ID = True Then
                    XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                    dt_lcn2 = bao_com.SP_Lisense_Name_and_Addr(dao.fields.CITIZEN_ID_AUTHORIZE)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")

                    For Each dr As DataRow In dt_lcn.Rows
                        For Each dr2 As DataRow In dt_lcn2.Rows
                            Try
                                dr("thanm") = dr2("tha_fullname")
                                XML.BSN_THAINAME = dao.fields.AGENT_99
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaaddr") = dr2("thaaddr")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaaddr_NO") = dr2("thaaddr")
                            Catch ex As Exception

                            End Try
                            Try
                                'dr("CITIZEN_ID") = dao.fields.AGENT_99
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thamu") = dr2("mu")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tharoad") = dr2("tharoad")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thabuilding") = dr2("thabuilding")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thasoi") = dr2("thasoi")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thathmblnm") = dr2("thathmblnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaamphrnm") = dr2("thaamphrnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("zipcode") = dr2("zipcode")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NAME") = dr2("tha_fullname")
                            Catch ex As Exception

                            End Try
                            Try
                                'dr("NAME_JJ") = NAME_JJ
                                dr("NAME_JJ") = dr2("tha_fullname")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tel") = dr2("tel")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("fax") = dr2("fax")
                            Catch ex As Exception

                            End Try
                        Next
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next
                Else
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") <> "" And dr("tel") <> "" Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = 99
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                        Catch ex As Exception

                        End Try
                        Try
                            'dr("NAME_JJ") = NAME_JJ
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try

                    Next
                End If
                dt_lcn.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_NITI_99"
                XML.DT_SHOW.DT4 = dt_lcn
            End If

            'HEAD
            Dim bao_xml As New BAO_TABEAN_HERB.tb_xml
            dt_jj = bao_xml.SP_XML_TABEAN_JJ(IDA)
            dt_jj.Columns.Add("TYPE_SUB_NAME_CHANGE")
            dt_jj.Columns.Add("PP_JJ")
            dt_jj.Columns.Add("TREATMENT_AGE_FULL")
            For Each dr As DataRow In dt_jj.Rows

                'If dr("TYPE_SUB_ID") = 1 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนไทย"
                'ElseIf dr("TYPE_SUB_ID") = 2 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                'ElseIf dr("TYPE_SUB_ID") = 3 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาพัฒนาจากสมุนไพร"
                'End If
                Try
                    If dao.fields.TREATMENT_AGE Is Nothing Or dao.fields.TREATMENT_AGE = 0 Then
                        dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    ElseIf dao.fields.TREATMENT_AGE_MONTH Is Nothing Or dao.fields.TREATMENT_AGE_MONTH = 0 Then
                        dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao.fields.TREATMENT_AGE & " " & "ปี"
                    Else
                        dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao.fields.TREATMENT_AGE & " " & "ปี" & " " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    End If
                    'dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE & " " & dao.fields.TREATMENT_AGE_NAME

                Catch ex As Exception
                    dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                End Try


                dr("PP_JJ") = "ตามเอกสารแนบ"

                'If dr("TYPE_SUB_ID") = 2 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                'End If

            Next
            dt_jj.TableName = "XML_TABEAN_JJ"
            XML.DT_SHOW.DT5 = dt_jj

            XML.TABEAN_JJ = dao.fields

            Dim date_approve_day As Date
            Dim date_approve_month As Date
            Dim date_approve_year As Date
            Dim date_req_day As Date
            Dim date_req_month As Date
            Dim date_req_year As Date

            'วันที่รับคำขอ และ วันที่อนุมัติ
            If dao.fields.STATUS_ID = 8 Then
                date_approve_day = dao.fields.DATE_APP
                date_approve_month = dao.fields.DATE_APP
                date_approve_year = dao.fields.DATE_APP

                XML.date_approve_day = date_approve_day.Day.ToString()
                XML.date_approve_month = date_approve_month.ToString("MMMM")
                XML.date_approve_year = con_year(date_approve_year.Year)

                date_req_day = dao.fields.DATE_REQ
                date_req_month = dao.fields.DATE_REQ
                date_req_year = dao.fields.DATE_REQ

                XML.date_req_day = date_req_day.Day.ToString()
                XML.date_req_month = date_req_month.Month.ToString("MMMM")
                XML.date_req_year = con_year(date_req_year.Year)

                XML.date_req_full = date_req_day.Day.ToString() & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
            ElseIf dao.fields.STATUS_ID = 12 Or dao.fields.STATUS_ID = 6 Or dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 13 Or dao.fields.STATUS_ID = 16 Then
                date_req_day = dao.fields.DATE_REQ
                date_req_month = dao.fields.DATE_REQ
                date_req_year = dao.fields.DATE_REQ

                XML.date_req_day = date_req_day.Day.ToString()
                XML.date_req_month = date_req_month.Month.ToString("MMMM")
                XML.date_req_year = con_year(date_req_year.Year)

                XML.date_req_full = date_req_day.Day.ToString() & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
            End If

            Dim dao_detail As New DAO_TABEAN_HERB.TB_TABEAN_SUBPACKAGE
            dao_detail.GetData_ByFkIDA(IDA)

            For Each dao_detail.fields In dao_detail.Details
                XML.TABEAN_SUBPACKAGE.Add(dao_detail.fields)

                Dim pk As String = ""
                pk = " primary packaging " & dao_detail.fields.PACK_FSIZE_NAME & " " & dao_detail.fields.PACK_FSIZE_VOLUME & " " & dao_detail.fields.PACK_FSIZE_UNIT_NAME & " secondary packaging " &
                    dao_detail.fields.PACK_SECSIZE_NAME & " " & dao_detail.fields.PACK_SECSIZE_VOLUME & " " & dao_detail.fields.PACK_SECSIZE_UNIT_NAME & " tertiary packaging " &
                    dao_detail.fields.PACK_THSIZE_NAME & " " & dao_detail.fields.PACK_THSSIZE_VOLUME & " " & dao_detail.fields.PACK_THSIZE_UNIT_NAME

                XML.list_subpackage.Add(pk)
            Next

            If dao_lcn.fields.PROCESS_ID = 121 Then
                Dim dao_lcn_HPI As New DAO_DRUG.ClsDBdalcn
                dao_lcn_HPI.GetDataby_IDA_and_PROCESS_ID(IDA_LCN, 121)

                Dim dao_lcn_bsn_HPI As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_lcn_bsn_HPI.GetDataby_LCN_IDA(IDA_LCN)

                Dim LCNNO_DISPLAY_NEW_HPI As String = dao_lcn_HPI.fields.LCNNO_DISPLAY_NEW
                Dim THANM_HPI As String = dao_lcn_HPI.fields.thanm
                Dim BSN_THAIFULLNAME_HPI As String = dao_lcn_bsn_HPI.fields.BSN_THAIFULLNAME

                dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPI.fields.FK_IDA)

                dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPI")
                dt_lcn_location.Columns.Add("THANM_HPI")
                dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPI")

                For Each dr As DataRow In dt_lcn_location.Rows
                    Try
                        dr("LCNNO_DISPLAY_NEW_HPI") = LCNNO_DISPLAY_NEW_HPI
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_HPI") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("BSN_THAIFULLNAME_HPI") = BSN_THAIFULLNAME
                    Catch ex As Exception

                    End Try

                Next
                dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_HPI"
                XML.DT_SHOW.DT1 = dt_lcn_location
            ElseIf dao_lcn.fields.PROCESS_ID = 122 Then
                Dim dao_lcn_HPM As New DAO_DRUG.ClsDBdalcn
                dao_lcn_HPM.GetDataby_IDA_and_PROCESS_ID(IDA_LCN, 122)

                Dim dao_lcn_bsn_HPM As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_lcn_bsn_HPM.GetDataby_LCN_IDA(IDA_LCN)

                Dim LCNNO_DISPLAY_NEW_HPM As String = dao_lcn_HPM.fields.LCNNO_DISPLAY_NEW
                Dim THANM_HPM As String = dao_lcn_HPM.fields.thanm
                Dim BSN_THAIFULLNAME_HPM As String = dao_lcn_bsn_HPM.fields.BSN_THAIFULLNAME

                dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPM.fields.FK_IDA)

                dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPM")
                dt_lcn_location.Columns.Add("THANM_HPM")
                dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPM")

                For Each dr As DataRow In dt_lcn_location.Rows
                    Try
                        dr("LCNNO_DISPLAY_NEW_HPM") = LCNNO_DISPLAY_NEW_HPM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_HPM") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("BSN_THAIFULLNAME_HPM") = BSN_THAIFULLNAME
                    Catch ex As Exception

                    End Try

                Next

                dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_HPM"
                XML.DT_SHOW.DT2 = dt_lcn_location
            End If

            XML.THANM_THAIFULLNAME = THANM

            'dt_lcn_location = bao_lcn_location.SP_DALCN_FRGN_DATA(IDA_LCN)
            'dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_NATIONALITY"
            'XML.DT_SHOW.DT2 = dt_lcn_location

            Return XML
        End Function
        'Public Function gen_xml(ByVal IDA As Integer, ByVal IDA_LCN As Integer)
        '    Dim XML As New CLS_TABEAN_HERB_JJ
        '    Dim bao_lcn As New BAO_SHOW
        '    Dim bao_lcn_location As New BAO_MASTER

        '    'Dim dt As New DataTable
        '    Dim dt_lcn As New DataTable
        '    Dim dt_lcn_location As New DataTable
        '    Dim dt_jj As New DataTable

        '    Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        '    dao.GetdatabyID_IDA(IDA)

        '    Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        '    dao_lcn.GetDataby_IDA(IDA_LCN)

        '    Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        '    Dim dao_cpn2 As New DAO_CPN.clsDBsyslcnsid
        '    dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)
        '    dao_cpn2.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

        '    Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        '    dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

        '    Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        '    Try
        '        dao_esub.GetDataby_LCN_IDA(IDA_LCN)
        '    Catch ex As Exception

        '    End Try
        '    Dim THANM As String = dao_lcn.fields.thanm
        '    If THANM = "" Or THANM Is Nothing Then
        '        THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
        '    Else
        '        THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        '    End If
        '    Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        '    Try
        '        tb_location.GetDataby_LCN_IDA(IDA_LCN)
        '    Catch ex As Exception

        '    End Try

        '    Dim citizen_bsn As String = tb_location.fields.BSN_IDENTIFY
        '    Dim dao_pfx As New DAO_CPN.TB_sysprefix
        '    Dim BSN_THAIFULLNAME As String = ""
        '    Dim dao_who As New DAO_WHO.TB_WHO_DALCN
        '    dao_who.GetdatabyID_FK_LCN(IDA_LCN)
        '    Dim WHO_NAME As String = ""
        '    WHO_NAME = dao_who.fields.THANM_NAME
        '    Try
        '        dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
        '        Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
        '        Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
        '        Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
        '        'If dao.fields.WHO_ID = True Then
        '        '    BSN_THAIFULLNAME = WHO_NAME
        '        'Else
        '        '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME
        '        'End If
        '        BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

        '    Catch ex As Exception

        '    End Try

        '    Dim person_age As String = ""
        '    Dim NATIONALITY_PERSON As String = ""
        '    Try
        '        person_age = dao.fields.PERSON_AGE
        '        If dao.fields.NATIONALITY_PERSON_ID = 1 Then
        '            NATIONALITY_PERSON = dao.fields.NATIONALITY_PERSON
        '        Else
        '            NATIONALITY_PERSON = dao.fields.NATIONALITY_PERSON_OTHER
        '        End If
        '    Catch ex As Exception

        '    End Try

        '    Dim TYPE_PERSON As Integer = dao_cpn.fields.type
        '    Dim TYPE_PERSON_WHO As Integer = dao_cpn2.fields.type
        '    Dim NATION As String = dao_lcn.fields.NATION
        '    'Dim THANM As String = dao_lcn.fields.thanm

        '    Dim CITIZEN_ID As String = dao.fields.CITIZEN_ID
        '    Dim CITIZEN_ID_AUTHORIZE As String = dao.fields.CITIZEN_ID_AUTHORIZE
        '    Dim NAME_JJ As String = dao.fields.NAME_JJ
        '    Dim THANAMEPLACE As String = dao.fields.LCN_THANAMEPLACE

        '    Dim bao As New BAO.ClsDBSqlcommand
        '    Dim dt_lcn2 As New DataTable


        '    Dim DT_WHO As New DataTable
        '    Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
        '    DT_WHO = BAO_SP.SP_XML_WHO_DALCN(IDA)
        '    'ข้อ 2 
        '    If TYPE_PERSON = 1 Then
        '        XML.TYPE_PERSON_1 = TYPE_PERSON
        '        If dao.fields.WHO_ID = True Then
        '            dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)

        '            dt_lcn.Columns.Add("NATION")
        '            dt_lcn.Columns.Add("TYPE_PERSON_CPN")
        '            'dt_lcn.Columns.Add("CITIZEN_ID")
        '            'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
        '            dt_lcn.Columns.Add("NAME_JJ")
        '            dt_lcn.Columns.Add("THANM")
        '            dt_lcn.Columns.Add("THANAMEPLACE")
        '            dt_lcn.Columns.Add("PERSON_AGE")
        '            dt_lcn.Columns.Add("NATIONALITY_PERSON")

        '            For Each dr As DataRow In dt_lcn.Rows
        '                Try
        '                    dr("NATION") = NATION
        '                Catch ex As Exception

        '                End Try
        '                'Try
        '                '    If dr("tel") = Nothing Or dr("tel") = "-" Then
        '                '        If dr("Mobile") = Nothing Then
        '                '            dr("tel") = "-"
        '                '        Else
        '                '            dr("tel") = dr("Mobile")
        '                '        End If
        '                '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
        '                '        dr("tel") = dr("tel") & ", " & dr("Mobile")
        '                '    End If
        '                'Catch ex As Exception

        '                'End Try
        '                Try
        '                    dr("PERSON_AGE") = person_age
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("TYPE_PERSON_CPN") = TYPE_PERSON
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("CITIZEN_ID") = citizen_bsn
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("NAME_JJ") = BSN_THAIFULLNAME
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("THANM") = THANM
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("THANAMEPLACE") = THANAMEPLACE
        '                Catch ex As Exception

        '                End Try
        '            Next

        '        Else
        '            dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

        '            dt_lcn.Columns.Add("NATION")
        '            dt_lcn.Columns.Add("TYPE_PERSON_CPN")
        '            dt_lcn.Columns.Add("CITIZEN_ID")
        '            dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
        '            dt_lcn.Columns.Add("NAME_JJ")
        '            dt_lcn.Columns.Add("THANM")
        '            dt_lcn.Columns.Add("THANAMEPLACE")
        '            dt_lcn.Columns.Add("PERSON_AGE")
        '            dt_lcn.Columns.Add("NATIONALITY_PERSON")

        '            For Each dr As DataRow In dt_lcn.Rows
        '                Try
        '                    dr("NATION") = NATION
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    If dr("tel") = Nothing Or dr("tel") = "-" Then
        '                        If dr("Mobile") = Nothing Then
        '                            dr("tel") = "-"
        '                        Else
        '                            dr("tel") = dr("Mobile")
        '                        End If
        '                    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
        '                        dr("tel") = dr("tel") & ", " & dr("Mobile")
        '                    End If
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("PERSON_AGE") = person_age
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("TYPE_PERSON_CPN") = TYPE_PERSON
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("CITIZEN_ID") = citizen_bsn
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("NAME_JJ") = BSN_THAIFULLNAME
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("THANM") = THANM
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("THANAMEPLACE") = THANAMEPLACE
        '                Catch ex As Exception

        '                End Try
        '            Next
        '        End If

        '        dt_lcn.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_PERSON_1"
        '        XML.DT_SHOW.DT3 = dt_lcn
        '    ElseIf TYPE_PERSON = 99 Then
        '        XML.TYPE_PERSON_99 = TYPE_PERSON
        '        If dao.fields.WHO_ID = True Then
        '            If TYPE_PERSON_WHO = 1 Then
        '                'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
        '                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_who.fields.FK_LCT)

        '                dt_lcn.Columns.Add("NATION")
        '                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
        '                'dt_lcn.Columns.Add("CITIZEN_ID")
        '                'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
        '                dt_lcn.Columns.Add("NAME_JJ")
        '                dt_lcn.Columns.Add("THANM")
        '                dt_lcn.Columns.Add("THANAMEPLACE")
        '                dt_lcn.Columns.Add("PERSON_AGE")
        '                dt_lcn.Columns.Add("NATIONALITY_PERSON")

        '                For Each dr As DataRow In dt_lcn.Rows
        '                    Try
        '                        dr("NATION") = NATION
        '                    Catch ex As Exception

        '                    End Try
        '                    'Try
        '                    '    If dr("tel") = Nothing Or dr("tel") = "-" Then
        '                    '        If dr("Mobile") = Nothing Then
        '                    '            dr("tel") = "-"
        '                    '        Else
        '                    '            dr("tel") = dr("Mobile")
        '                    '        End If
        '                    '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
        '                    '        dr("tel") = dr("tel") & ", " & dr("Mobile")
        '                    '    End If
        '                    'Catch ex As Exception

        '                    'End Try
        '                    Try
        '                        dr("PERSON_AGE") = person_age
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        dr("CITIZEN_ID") = citizen_bsn
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        dr("NAME_JJ") = BSN_THAIFULLNAME
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        dr("THANM") = THANM
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        dr("THANAMEPLACE") = THANAMEPLACE
        '                    Catch ex As Exception

        '                    End Try
        '                Next
        '            ElseIf TYPE_PERSON = 99 Then
        '                'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
        '                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.IDA_LCT)
        '                dt_lcn2 = bao.SP_Lisense_Name_and_Addr(dao.fields.CITIZEN_ID_AUTHORIZE)

        '                dt_lcn.Columns.Add("NATION")
        '                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
        '                dt_lcn.Columns.Add("NAME_JJ")
        '                dt_lcn.Columns.Add("THANM")
        '                dt_lcn.Columns.Add("THANAMEPLACE")
        '                dt_lcn.Columns.Add("PERSON_AGE")
        '                dt_lcn.Columns.Add("NATIONALITY_PERSON")
        '                dt_lcn.Columns.Add("CITIZEN_ID")
        '                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")

        '                For Each dr As DataRow In dt_lcn.Rows
        '                    For Each dr2 As DataRow In dt_lcn2.Rows
        '                        Try
        '                            dr("thanm") = dr2("tha_fullname")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("thaaddr") = dr2("thaaddr")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("CITIZEN_ID") = CITIZEN_ID
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("thamu") = dr2("mu")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("tharoad") = dr2("tharoad")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("thabuilding") = dr2("thabuilding")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("thasoi") = dr2("thasoi")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("thathmblnm") = dr2("thathmblnm")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("thaamphrnm") = dr2("thaamphrnm")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("thachngwtnm_nozip") = dr2("thachngwtnm")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("zipcode") = dr2("zipcode")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("NAME_JJ") = NAME_JJ
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("tel") = dr2("tel")
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            dr("fax") = dr2("fax")
        '                        Catch ex As Exception

        '                        End Try
        '                    Next
        '                    Try
        '                        dr("NATION") = NATION
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        dr("PERSON_AGE") = person_age
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
        '                    Catch ex As Exception

        '                    End Try

        '                    'Try
        '                    '    dr("THANM") = THANM
        '                    'Catch ex As Exception

        '                    'End Try
        '                    Try
        '                        dr("THANAMEPLACE") = THANAMEPLACE
        '                    Catch ex As Exception

        '                    End Try
        '                Next
        '            End If
        '        Else
        '            dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

        '            dt_lcn.Columns.Add("NATION")
        '            dt_lcn.Columns.Add("TYPE_PERSON_CPN")
        '            dt_lcn.Columns.Add("CITIZEN_ID")
        '            dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
        '            dt_lcn.Columns.Add("NAME_JJ")
        '            dt_lcn.Columns.Add("THANM")
        '            dt_lcn.Columns.Add("THANAMEPLACE")
        '            dt_lcn.Columns.Add("PERSON_AGE")
        '            dt_lcn.Columns.Add("NATIONALITY_PERSON")

        '            For Each dr As DataRow In dt_lcn.Rows
        '                Try
        '                    dr("NATION") = NATION
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    If dr("tel") = Nothing Or dr("tel") = "-" Then
        '                        If dr("Mobile") = Nothing Then
        '                            dr("tel") = "-"
        '                        Else
        '                            dr("tel") = dr("Mobile")
        '                        End If
        '                    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
        '                        dr("tel") = dr("tel") & ", " & dr("Mobile")
        '                    End If
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("PERSON_AGE") = person_age
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("TYPE_PERSON_CPN") = TYPE_PERSON
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("CITIZEN_ID") = citizen_bsn
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("NAME_JJ") = BSN_THAIFULLNAME
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("THANM") = THANM
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    dr("THANAMEPLACE") = THANAMEPLACE
        '                Catch ex As Exception

        '                End Try

        '            Next
        '        End If

        '        dt_lcn.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_NITI_99"
        '        XML.DT_SHOW.DT4 = dt_lcn
        '    End If

        '    If TYPE_PERSON = 1 Then
        '        XML.BSN_THAIFULLNAME = THANM
        '    ElseIf TYPE_PERSON = 99 Then
        '        XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
        '    End If

        '    'HEAD
        '    Dim bao_xml As New BAO_TABEAN_HERB.tb_xml
        '    dt_jj = bao_xml.SP_XML_TABEAN_JJ(IDA)

        '    dt_jj.Columns.Add("TYPE_SUB_NAME_CHANGE")
        '    dt_jj.Columns.Add("PP_JJ")
        '    dt_jj.Columns.Add("TREATMENT_AGE_FULL")
        '    For Each dr As DataRow In dt_jj.Rows

        '        'If dr("TYPE_SUB_ID") = 1 Then
        '        '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนไทย"
        '        'ElseIf dr("TYPE_SUB_ID") = 2 Then
        '        '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
        '        'ElseIf dr("TYPE_SUB_ID") = 3 Then
        '        '    dr("TYPE_SUB_NAME_CHANGE") = "ยาพัฒนาจากสมุนไพร"
        '        'End If
        '        Try
        '            If dao.fields.TREATMENT_AGE Is Nothing Or dao.fields.TREATMENT_AGE = 0 Then
        '                dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
        '            ElseIf dao.fields.TREATMENT_AGE_MONTH Is Nothing Or dao.fields.TREATMENT_AGE_MONTH = 0 Then
        '                dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao.fields.TREATMENT_AGE & " " & "ปี"
        '            Else
        '                dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao.fields.TREATMENT_AGE & " " & "ปี" & " " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
        '            End If
        '            'dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE & " " & dao.fields.TREATMENT_AGE_NAME

        '        Catch ex As Exception
        '            dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
        '        End Try

        '        dr("PP_JJ") = "ตามเอกสารแนบ"

        '        'If dr("TYPE_SUB_ID") = 2 Then
        '        '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
        '        'End If

        '    Next
        '    dt_jj.TableName = "XML_TABEAN_JJ"
        '    XML.DT_SHOW.DT5 = dt_jj

        '    XML.TABEAN_JJ = dao.fields

        '    Dim date_approve_day As Date
        '    Dim date_approve_month As Date
        '    Dim date_approve_year As Date
        '    Dim date_req_day As Date
        '    Dim date_req_month As Date
        '    Dim date_req_year As Date

        '    'วันที่รับคำขอ และ วันที่อนุมัติ
        '    If dao.fields.STATUS_ID = 8 Then
        '        date_approve_day = dao.fields.DATE_APP
        '        date_approve_month = dao.fields.DATE_APP
        '        date_approve_year = dao.fields.DATE_APP

        '        XML.date_approve_day = date_approve_day.Day.ToString()
        '        XML.date_approve_month = date_approve_month.ToString("MMMM")
        '        XML.date_approve_year = con_year(date_approve_year.Year)

        '        date_req_day = dao.fields.DATE_REQ
        '        date_req_month = dao.fields.DATE_REQ
        '        date_req_year = dao.fields.DATE_REQ

        '        XML.date_req_day = date_req_day.Day.ToString()
        '        XML.date_req_month = date_req_month.Month.ToString("MMMM")
        '        XML.date_req_year = con_year(date_req_year.Year)

        '        XML.date_req_full = date_req_day.Day.ToString() & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
        '        If dao.fields.PVNCD = 10 Then
        '            XML.SIGN_APP = "สำนักงานคณะกรรมการอาหารและยา"
        '        Else
        '            Try
        '                Dim dao_pvn As New DAO_CPN.clsDBsyschngwt
        '                dao_pvn.GetData_by_chngwtcd(dao.fields.PVNCD)
        '                XML.SIGN_APP = "สำนักงานสาธารณสุขจังหวัด" & dao_pvn.fields.thachngwtnm
        '            Catch ex As Exception

        '            End Try

        '        End If

        '        'Dim url As String = "https://excercitium.fda.moph.go.th/FDA_TXC/TXC_SEARCH/FRM_TXC_SEARCH_QRCODE.aspx?lcnno=" & b64encode(dao.fields.LCNNO) & "&wotype=" & b64encode("3") & "&pvncd=" & b64encode(dao.fields.PVNCD) & "&lcntpcd=" & b64encode(dao.fields.lcntpcd)
        '        Dim url As String = "www.google.com"
        '        Dim cls_qr As New QR_CODE.GEN_QR_CODE
        '        XML.QR_JJ = cls_qr.GenerateQR_TO_BASE64(20, 20, url)


        '    ElseIf dao.fields.STATUS_ID = 12 Or dao.fields.STATUS_ID = 6 Or dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 13 Or dao.fields.STATUS_ID = 16 Then
        '        date_req_day = dao.fields.DATE_REQ
        '        date_req_month = dao.fields.DATE_REQ
        '        date_req_year = dao.fields.DATE_REQ

        '        XML.date_req_day = date_req_day.Day.ToString()
        '        XML.date_req_month = date_req_month.Month.ToString("MMMM")
        '        XML.date_req_year = con_year(date_req_year.Year)

        '        XML.date_req_full = date_req_day.Day.ToString() & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)

        '        If dao.fields.PVNCD = 10 Then
        '            XML.SIGN_APP = "สำนักงานคณะกรรมการอาหารและยา"
        '        Else
        '            Try
        '                Dim dao_pvn As New DAO_CPN.clsDBsyschngwt
        '                dao_pvn.GetData_by_chngwtcd(dao.fields.PVNCD)
        '                XML.SIGN_APP = "สำนักงานสาธารณสุขจังหวัด" & dao_pvn.fields.thachngwtnm
        '            Catch ex As Exception

        '            End Try

        '        End If

        '        'Dim url As String = "https://excercitium.fda.moph.go.th/FDA_TXC/TXC_SEARCH/FRM_TXC_SEARCH_QRCODE.aspx?lcnno=" & b64encode(dao.fields.LCNNO) & "&wotype=" & b64encode("3") & "&pvncd=" & b64encode(dao.fields.PVNCD) & "&lcntpcd=" & b64encode(dao.fields.lcntpcd)
        '        Dim url As String = "www.google.com"
        '        Dim cls_qr As New QR_CODE.GEN_QR_CODE
        '        XML.QR_JJ = cls_qr.GenerateQR_TO_BASE64(20, 20, url)

        '    End If

        '    Dim dao_detail As New DAO_TABEAN_HERB.TB_TABEAN_SUBPACKAGE
        '    dao_detail.GetData_ByFkIDA(IDA)

        '    For Each dao_detail.fields In dao_detail.Details
        '        XML.TABEAN_SUBPACKAGE.Add(dao_detail.fields)

        '        Dim pk As String = ""
        '        pk = " primary packaging " & dao_detail.fields.PACK_FSIZE_NAME & " " & dao_detail.fields.PACK_FSIZE_VOLUME & " " & dao_detail.fields.PACK_FSIZE_UNIT_NAME & " secondary packaging " &
        '            dao_detail.fields.PACK_SECSIZE_NAME & " " & dao_detail.fields.PACK_SECSIZE_VOLUME & " " & dao_detail.fields.PACK_SECSIZE_UNIT_NAME & " tertiary packaging " &
        '            dao_detail.fields.PACK_THSIZE_NAME & " " & dao_detail.fields.PACK_THSSIZE_VOLUME & " " & dao_detail.fields.PACK_THSIZE_UNIT_NAME

        '        XML.list_subpackage.Add(pk)
        '    Next

        '    If dao_lcn.fields.PROCESS_ID = 121 Then
        '        Dim dao_lcn_HPI As New DAO_DRUG.ClsDBdalcn
        '        dao_lcn_HPI.GetDataby_IDA_and_PROCESS_ID(IDA_LCN, 121)

        '        Dim dao_lcn_bsn_HPI As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        '        dao_lcn_bsn_HPI.GetDataby_LCN_IDA(IDA_LCN)

        '        Dim LCNNO_DISPLAY_NEW_HPI As String = dao_lcn_HPI.fields.LCNNO_DISPLAY_NEW
        '        Dim THANM_HPI As String = dao_lcn_HPI.fields.thanm
        '        Dim BSN_THAIFULLNAME_HPI As String = dao_lcn_bsn_HPI.fields.BSN_THAIFULLNAME

        '        dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPI.fields.FK_IDA)

        '        dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPI")
        '        dt_lcn_location.Columns.Add("THANM_HPI")
        '        dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPI")

        '        For Each dr As DataRow In dt_lcn_location.Rows
        '            Try
        '                dr("LCNNO_DISPLAY_NEW_HPI") = LCNNO_DISPLAY_NEW_HPI
        '            Catch ex As Exception

        '            End Try
        '            Try
        '                dr("THANM_HPI") = THANM
        '            Catch ex As Exception

        '            End Try
        '            Try
        '                dr("BSN_THAIFULLNAME_HPI") = BSN_THAIFULLNAME
        '            Catch ex As Exception

        '            End Try

        '        Next
        '        dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_HPI"
        '        XML.DT_SHOW.DT1 = dt_lcn_location
        '    ElseIf dao_lcn.fields.PROCESS_ID = 122 Then
        '        Dim dao_lcn_HPM As New DAO_DRUG.ClsDBdalcn
        '        dao_lcn_HPM.GetDataby_IDA_and_PROCESS_ID(IDA_LCN, 122)

        '        Dim dao_lcn_bsn_HPM As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        '        dao_lcn_bsn_HPM.GetDataby_LCN_IDA(IDA_LCN)

        '        Dim LCNNO_DISPLAY_NEW_HPM As String = dao_lcn_HPM.fields.LCNNO_DISPLAY_NEW
        '        Dim THANM_HPM As String = dao_lcn_HPM.fields.thanm
        '        Dim BSN_THAIFULLNAME_HPM As String = dao_lcn_bsn_HPM.fields.BSN_THAIFULLNAME

        '        dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPM.fields.FK_IDA)

        '        dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPM")
        '        dt_lcn_location.Columns.Add("THANM_HPM")
        '        dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPM")

        '        For Each dr As DataRow In dt_lcn_location.Rows
        '            Try
        '                dr("LCNNO_DISPLAY_NEW_HPM") = LCNNO_DISPLAY_NEW_HPM
        '            Catch ex As Exception

        '            End Try
        '            Try
        '                dr("THANM_HPM") = THANM
        '            Catch ex As Exception

        '            End Try
        '            Try
        '                dr("BSN_THAIFULLNAME_HPM") = BSN_THAIFULLNAME
        '            Catch ex As Exception

        '            End Try

        '        Next

        '        dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_HPM"
        '        XML.DT_SHOW.DT2 = dt_lcn_location
        '    End If

        '    Dim dt_formula As DataTable
        '    Dim bao_master_2 As New BAO.ClsDBSqlcommand
        '    dt_formula = bao_master_2.SP_drug_formula_JJ(IDA)
        '    dt_formula.TableName = "XML_TABEAN_FORMULA_JJ"
        '    XML.DT_SHOW.DT6 = dt_formula

        '    If TYPE_PERSON = 1 Then
        '        XML.THANM_THAIFULLNAME = THANM
        '    ElseIf TYPE_PERSON = 99 Then
        '        XML.THANM_THAIFULLNAME = BSN_THAIFULLNAME
        '    End If
        '    'dt_lcn_location = bao_lcn_location.SP_DALCN_FRGN_DATA(IDA_LCN)
        '    'dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_NATIONALITY"
        '    'XML.DT_SHOW.DT2 = dt_lcn_location

        '    Return XML
        'End Function

        Public Function gen_xml_2(ByVal IDA As Integer, ByVal IDA_LCN As Integer)
            Dim XML As New CLS_TABEAN_HERB_JJ
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER

            'Dim dt As New DataTable
            Dim dt_lcn As New DataTable
            Dim dt_lcn_location As New DataTable
            Dim dt_jj As New DataTable
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(IDA)
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(IDA_LCN)

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

            'Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            'dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

            Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Try
                dao_esub.GetDataby_LCN_IDA(IDA_LCN)
            Catch ex As Exception

            End Try
            Dim THANM As String = dao_lcn.fields.thanm
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(IDA_LCN)
            Catch ex As Exception

            End Try
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Dim dao_who As New DAO_WHO.TB_WHO_DALCN
            dao_who.GetdatabyID_FK_LCN_IDEN(IDA_LCN, dao.fields.CITIZEN_ID_AUTHORIZE)
            Dim WHO_NAME As String = ""
            WHO_NAME = dao_who.fields.THANM_NAME
            Try
                dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
                Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
                Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
                'If dao.fields.WHO_ID = True Then
                '    BSN_THAIFULLNAME = WHO_NAME
                'Else
                '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME
                'End If
                BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            Catch ex As Exception

            End Try
            'Try
            '    dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
            '    Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
            '    Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
            '    Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
            '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            'Catch ex As Exception

            'End Try

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            ' Dim THANM As String = dao_lcn.fields.thanm

            Dim CITIZEN_ID As String = dao.fields.CITIZEN_ID
            Dim CITIZEN_ID_AUTHORIZE As String = dao.fields.CITIZEN_ID_AUTHORIZE
            Dim NAME_JJ As String = dao.fields.NAME_JJ
            Dim THANAMEPLACE As String = dao.fields.LCN_THANAMEPLACE
            'HEAD
            Dim bao_xml As New BAO_TABEAN_HERB.tb_xml
            dt_jj = bao_xml.SP_XML_TABEAN_JJ(IDA)
            dt_jj.Columns.Add("TYPE_SUB_NAME_CHANGE")
            For Each dr As DataRow In dt_jj.Rows

                If dr("TYPE_SUB_ID") = 1 Then
                    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนไทย"
                ElseIf dr("TYPE_SUB_ID") = 2 Then
                    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                ElseIf dr("TYPE_SUB_ID") = 3 Then
                    dr("TYPE_SUB_NAME_CHANGE") = "ยาพัฒนาจากสมุนไพร"
                End If

                Try
                    If dao.fields.FOREIGN_NAME = "" Then
                        dr("FOREIGN_NAME") = "-"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao.fields.FOREIGN_NAME_PLACE = "" Then
                        dr("FOREIGN_NAME_PLACE") = "-"
                    End If
                Catch ex As Exception

                End Try

            Next
            dt_jj.TableName = "XML_TABEAN_JJ"
            XML.DT_SHOW.DT5 = dt_jj

            Try
                If dao.fields.FOREIGN_NAME_PLACE = "" Then
                    dao.fields.FOREIGN_NAME_PLACE = "-"
                End If
                If dao.fields.FOREIGN_NAME = "" Then
                    dao.fields.FOREIGN_NAME = "-"
                End If
            Catch ex As Exception

            End Try
            If dao.fields.WHO_ID = True Then dao.fields.LCN_NAME = dao.fields.WHO_NAME
            XML.TABEAN_JJ = dao.fields

            Dim date_approve_day As Date
            Dim date_approve_month As Date
            Dim date_approve_year As Date
            Dim date_req_day As Date
            Dim date_req_month As Date
            Dim date_req_year As Date

            'วันที่รับคำขอ และ วันที่อนุมัติ
            If dao.fields.STATUS_ID = 8 Then
                date_approve_day = dao.fields.DATE_APP
                date_approve_month = dao.fields.DATE_APP
                date_approve_year = dao.fields.DATE_APP

                XML.date_approve_day = date_approve_day.Day.ToString()
                XML.date_approve_month = date_approve_month.ToString("MMMM")
                XML.date_approve_year = con_year(date_approve_year.Year)

                date_req_day = dao.fields.DATE_REQ
                date_req_month = dao.fields.DATE_REQ
                date_req_year = dao.fields.DATE_REQ

                XML.date_req_day = date_req_day.Day.ToString()
                XML.date_req_month = date_req_month.ToString("MMMM")
                XML.date_req_year = con_year(date_req_year.Year)

                Try
                    Dim a As String = date_approve_day.Day.ToString() - 1
                    Dim b As String = date_approve_month.ToString("MMMM")
                    Dim c As String = con_year(date_approve_year.Year) + 5

                    XML.date_approve_day_end = a
                    XML.date_approve_month_end = b
                    XML.date_approve_year_end = c

                Catch ex As Exception

                End Try

                XML.date_req_full = date_req_day.Day.ToString() & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
                If dao.fields.PVNCD = 10 Then
                    XML.SIGN_APP = "สำนักงานคณะกรรมการอาหารและยา"
                Else
                    Try
                        Dim dao_pvn As New DAO_CPN.clsDBsyschngwt
                        dao_pvn.GetData_by_chngwtcd(dao.fields.PVNCD)
                        XML.SIGN_APP = "สำนักงานสาธารณสุขจังหวัด" & dao_pvn.fields.thachngwtnm
                    Catch ex As Exception

                    End Try

                End If

                'Dim url As String = "https://excercitium.fda.moph.go.th/FDA_TXC/TXC_SEARCH/FRM_TXC_SEARCH_QRCODE.aspx?lcnno=" & b64encode(dao.fields.LCNNO) & "&wotype=" & b64encode("3") & "&pvncd=" & b64encode(dao.fields.PVNCD) & "&lcntpcd=" & b64encode(dao.fields.lcntpcd)
                Dim url As String = "www.google.com"
                Dim cls_qr As New QR_CODE.GEN_QR_CODE
                XML.QR_JJ = cls_qr.GenerateQR_TO_BASE64(20, 20, url)

            ElseIf dao.fields.STATUS_ID = 6 Or dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 12 Then
                date_req_day = dao.fields.DATE_REQ
                date_req_month = dao.fields.DATE_REQ
                date_req_year = dao.fields.DATE_REQ

                XML.date_req_day = date_req_day.Day.ToString()
                XML.date_req_month = date_req_month.ToString("MMMM")
                XML.date_req_year = con_year(date_req_year.Year)

                XML.date_req_full = date_req_day.Day.ToString() & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
                If dao.fields.PVNCD = 10 Then
                    XML.SIGN_APP = "สำนักงานคณะกรรมการอาหารและยา"
                Else
                    Try
                        Dim dao_pvn As New DAO_CPN.clsDBsyschngwt
                        dao_pvn.GetData_by_chngwtcd(dao.fields.PVNCD)
                        XML.SIGN_APP = "สำนักงานสาธารณสุขจังหวัด" & dao_pvn.fields.thachngwtnm
                    Catch ex As Exception

                    End Try

                End If

                'Dim url As String = "https://excercitium.fda.moph.go.th/FDA_TXC/TXC_SEARCH/FRM_TXC_SEARCH_QRCODE.aspx?lcnno=" & b64encode(dao.fields.LCNNO) & "&wotype=" & b64encode("3") & "&pvncd=" & b64encode(dao.fields.PVNCD) & "&lcntpcd=" & b64encode(dao.fields.lcntpcd)
                Dim url As String = "www.google.com"
                Dim cls_qr As New QR_CODE.GEN_QR_CODE
                XML.QR_JJ = cls_qr.GenerateQR_TO_BASE64(20, 20, url)

            End If

            'ข้อ 2 
            If TYPE_PERSON = 1 Then
                XML.TYPE_PERSON_1 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME_JJ")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANAMEPLACE")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        If dr("tel") = Nothing Or dr("tel") = "-" Then
                            If dr("Mobile") = Nothing Then
                                dr("tel") = "-"
                            Else
                                dr("tel") = dr("Mobile")
                            End If
                        ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                            dr("tel") = dr("tel") & ", " & dr("Mobile")
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                    Catch ex As Exception

                    End Try

                    Try
                        If dao.fields.WHO_ID = 1 Then
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Else
                            dr("NAME_JJ") = dao_who.fields.THANM_NAME
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM") = THANM
                        If dao.fields.WHO_ID = 1 Then
                            dr("THANM") = THANM
                        Else
                            dr("THANM") = dao_who.fields.THANM_NAME
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try
                Next

            ElseIf TYPE_PERSON = 99 Then
                XML.TYPE_PERSON_99 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME_JJ")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANAMEPLACE")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                    Catch ex As Exception

                    End Try
                    Try
                        'dr("NAME_JJ") = BSN_THAIFULLNAME
                        If dao.fields.WHO_ID = 1 Then
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Else
                            dr("NAME_JJ") = dao_who.fields.THANM_NAME
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'dr("THANM") = THANM
                        If dao.fields.WHO_ID = 1 Then
                            dr("THANM") = THANM
                        Else
                            dr("THANM") = dao_who.fields.THANM_NAME
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try

                Next
            End If
            dt_lcn.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS"
            XML.DT_SHOW.DT1 = dt_lcn
            Return XML
        End Function

        Public Function gen_xml_approve(ByVal IDA As Integer, ByVal IDA_LCN As Integer)
            Dim XML As New CLS_TABEAN_HERB_JJ
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER

            'Dim dt As New DataTable
            Dim dt_lcn As New DataTable
            Dim dt_lcn_location As New DataTable

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(IDA)

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(IDA_LCN)

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            Dim THANM As String = dao_lcn.fields.thanm

            Dim CITIZEN_ID As String = dao.fields.CITIZEN_ID
            Dim CITIZEN_ID_AUTHORIZE As String = dao.fields.CITIZEN_ID_AUTHORIZE
            Dim NAME_JJ As String = dao.fields.NAME_JJ
            Dim THANAMEPLACE As String = dao.fields.LCN_THANAMEPLACE
            Dim LCNNO_DISPLAY_NEW As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
            Dim RCVNO_FULL As String = dao.fields.RCVNO_FULL
            Dim NAME_THAI_NAME_PLACE As String = dao.fields.NAME_THAI & " / " & dao.fields.NAME_PLACE_JJ

            Dim PROCESS_NAME As String = ""
            Dim date_req_day As Date
            Dim date_req_month As Date
            Dim date_req_year As Date

            If dao.fields.DDHERB = 20301 Then
                PROCESS_NAME = "การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาแผนไทย"
            ElseIf dao.fields.DDHERB = 20302 Then
                PROCESS_NAME = "การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาตามองค์ความรู้การแพทย์ทางเลือก"
            ElseIf dao.fields.DDHERB = 20303 Then
                PROCESS_NAME = "การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาพัฒนาจากสมุนไพร"
            ElseIf dao.fields.DDHERB = 20304 Then
                PROCESS_NAME = "การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ"
            End If

            If dao.fields.STATUS_ID = 12 Or dao.fields.STATUS_ID = 11 Then
                date_req_day = dao.fields.DATE_REQ
                date_req_month = dao.fields.DATE_REQ
                date_req_year = dao.fields.DATE_REQ

                XML.date_req_day = date_req_day.Day.ToString()
                XML.date_req_month = date_req_month.ToString("MMMM")
                XML.date_req_year = con_year(date_req_year.Year)

                XML.date_req_full = date_req_day.Day.ToString() & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
            End If

            XML.TABEAN_JJ = dao.fields
            XML.PROCESS_NAME = PROCESS_NAME
            XML.NAME_THAI_NAME_PLACE = NAME_THAI_NAME_PLACE
            XML.LCNNO_DISPLAY_NEW = LCNNO_DISPLAY_NEW
            XML.RCVNO_FULL = RCVNO_FULL

            Return XML
        End Function

    End Class
    Public Class TABEAN_HERB_JJ_EDIT_V2
        Inherits Center
        Public Function gen_xml_tb(ByVal _IDA As Integer, ByVal _IDA_DR As Integer)
            Dim XML As New CLS_TABEAN_HERB_JJ
            Dim dt_lcn As New DataTable
            Dim bao_lcn As New BAO_SHOW
            Dim dt_lcn_location As New DataTable
            Dim dt_jj As New DataTable
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
            dao.GetdatabyID_IDA(_IDA)

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao.fields.IDA_LCN)

            Dim bao_xml As New BAO_TABEAN_HERB.tb_xml
            dt_jj = bao_xml.SP_XML_TABEAN_JJ(_IDA)

            dt_jj.TableName = "XML_TABEAN_JJ"
            XML.DT_SHOW.DT5 = dt_jj

            Return XML
        End Function
    End Class
    Public Class TABEAN_HERB_TB
        Inherits Center
        Public Function gen_xml_tb(ByVal _IDA As Integer, ByVal _IDA_DR As Integer)
            Dim XML As New CLASS_DRRGT_SUB
            Dim dt_lcn As New DataTable
            Dim bao_lcn As New BAO_SHOW

            Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
            dao_sub.GetDatabyIDA(_IDA)

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_sub.fields.FK_LCN_IDA)

            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(dao_sub.fields.FK_LCN_IDA)
            Catch ex As Exception

            End Try

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)

            Dim DALCN_DISPLAY As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            Dim THANM As String = dao_lcn.fields.thanm
            Dim BSN_THAIFULLNAME As String = tb_location.fields.BSN_THAIFULLNAME

            Dim rcvdate As Date
            Dim rcvdate2 As String = ""
            If dao_sub.fields.rcvdate IsNot Nothing Then
                rcvdate = dao_sub.fields.rcvdate
                rcvdate2 = CDate(rcvdate).ToString("dd MMMM yyy")
            End If
            Dim dt As New DataTable
            Dim bao_drrgt_sub As New BAO.ClsDBSqlcommand
            dt = bao_drrgt_sub.SP_DRRGT_SUBSTITUTE_BY_IDA(_IDA)

            dt.Columns.Add("RCVDATE_FORMAT")
            dt.Columns.Add("LCNNO_DISPLAY")
            For Each dr As DataRow In dt.Rows
                Try
                    dr("RCVDATE_FORMAT") = rcvdate2
                    dr("LCNNO_DISPLAY") = DALCN_DISPLAY

                Catch ex As Exception

                End Try
            Next
            dt.TableName = "XML_TABEAN_TB_DRRGT_SUBSTITUTE"
            XML.DT_SHOW.DT1 = dt

            Dim CITIZEN_ID As String = dao_sub.fields.CTZNO
            Dim CITIZEN_ID_AUTHORIZE As String = dao_sub.fields.IDENTIFY
            Dim NAME As String = dao_sub.fields.CREATE_BY
            Dim THANAMEPLACE As String = dao_lcn.fields.thanameplace

            If TYPE_PERSON = 1 Then
                'XML.TYPE_PERSON_1 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANAMEPLACE")
                dt_lcn.Columns.Add("PERSON_AGE")
                dt_lcn.Columns.Add("NATIONALITY_PERSON")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("PERSON_AGE") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NATIONALITY_PERSON") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NAME") = NAME
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try
                Next
                dt_lcn.TableName = "XML_TABEAN_TB_LOCATION_ADDRESS_PERSON_1"
                XML.DT_SHOW.DT2 = dt_lcn
            ElseIf TYPE_PERSON = 99 Then
                'XML.TYPE_PERSON_99 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANAMEPLACE")
                dt_lcn.Columns.Add("PERSON_AGE")
                dt_lcn.Columns.Add("NATIONALITY_PERSON")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("PERSON_AGE") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NATIONALITY_PERSON") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NAME") = NAME
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try

                Next
                dt_lcn.TableName = "XML_TABEAN_TB_LOCATION_ADDRESS_NITI_99"
                XML.DT_SHOW.DT3 = dt_lcn
            End If

            'Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
            'dao.GetDataby_FK_IDA(_IDA_DR)

            'XML.DRRGT_SUB = dao.datas

            Return XML
        End Function
    End Class

    Public Class TABEAN_HERB_TBN
        Inherits Center

        Public Function gen_xml_tbn(ByVal _IDA As Integer, ByVal _IDA_DQ As Integer, ByVal _IDA_LCN As Integer)
            Dim XML As New CLASS_DRRQT
            Dim bao_lcn As New BAO_SHOW

            Dim dt_lcn As New DataTable
            Dim dt_lcn_location As New DataTable

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)

            Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
            dao_drrqt.GetDataby_IDA(_IDA_DQ)

            Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao_tabean_herb.GetdatabyID_IDA(_IDA)

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao_drrqt.fields.CITIZEN_ID_AUTHORIZE)

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

            Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Try
                dao_esub.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try

            Dim CITIZEN_ID As String = dao_drrqt.fields.IDENTIFY
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(CITIZEN_ID, CITIZEN_ID, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Dim THANM_CENTER As String = ""
            Dim TYPE_PERSON_CENTER As Integer = obj.SYSLCNSIDs.type
            If TYPE_PERSON_CENTER = 1 Then
                THANM_CENTER = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            ElseIf TYPE_PERSON_CENTER = 99 Or TYPE_PERSON_CENTER = 3 Then
                THANM_CENTER = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    THANM_CENTER = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    THANM_CENTER = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                End If
            End If

            Dim THANM As String = dao_lcn.fields.thanm
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Dim citizen_bsn As String = tb_location.fields.BSN_IDENTIFY
            Dim dao_cpn2 As New DAO_CPN.clsDBsyslcnsid
            ' dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)
            dao_cpn2.GetDataby_identify(dao_drrqt.fields.CITIZEN_ID_AUTHORIZE)
            Dim dao_who As New DAO_WHO.TB_WHO_DALCN
            dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
            Dim WHO_NAME As String = ""
            WHO_NAME = dao_who.fields.THANM_NAME
            Try
                dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
                Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
                Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
                If dao_drrqt.fields.WHO_ID = True Then
                    BSN_THAIFULLNAME = THANM_CENTER
                    'BSN_THAIFULLNAME = WHO_NAME
                Else
                    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME
                End If
                'BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            Catch ex As Exception

            End Try
            'Try
            '    dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
            '    Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
            '    Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
            '    Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
            '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            'Catch ex As Exception

            'End Try




            Dim bao As New BAO.ClsDBSqlcommand
            Dim person_age As String = ""
            Dim NATIONALITY_PERSON As String = ""
            Try
                person_age = dao_tabean_herb.fields.PERSON_AGE
                If dao_tabean_herb.fields.NATIONALITY_PERSON_ID = 1 Then
                    NATIONALITY_PERSON = dao_tabean_herb.fields.NATIONALITY_PERSON
                Else
                    NATIONALITY_PERSON = dao_tabean_herb.fields.NATIONALITY_PERSON_OTHER
                End If
            Catch ex As Exception

            End Try

            'Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim TYPE_PERSON_WHO As Integer = dao_cpn2.fields.type
            '  Dim NATION As String = dao_lcn.fields.NATION
            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION


            Dim CITIZEN_ID_AUTHORIZE As String = dao_drrqt.fields.CITIZEN_ID_AUTHORIZE
            Dim NAME As String = dao_drrqt.fields.CREATE_BY
            Dim THANAMEPLACE As String = dao_lcn.fields.thanameplace
            'Dim BSN_THAIFULLNAME As String = dao_lcn.fields.BSN_THAIFULLNAME

            Dim dt As New DataTable
            Dim BAO2 As New BAO_TABEAN_HERB.tb_main

            Dim date_rcv_day As Date
            Dim date_rcv_month As Date
            Dim date_rcv_year As Date

            Dim date_rgt_day As Date
            Dim date_rgt_month As Date
            Dim date_rgt_year As Date

            If dao_drrqt.fields.rcvdate IsNot Nothing Then
                date_rcv_day = dao_drrqt.fields.rcvdate
                date_rcv_month = dao_drrqt.fields.rcvdate
                date_rcv_year = dao_drrqt.fields.rcvdate

                XML.RCVNO_DATE = date_rcv_day.Day.ToString() & " " & date_rcv_month.ToString("MMMM") & " " & con_year(date_rcv_year.Year)
            End If
            'If dao_drrqt.fields.STATUS_ID = 6 Or dao_drrqt.fields.STATUS_ID = 11 Or dao_drrqt.fields.STATUS_ID = 12 Or dao_drrqt.fields.STATUS_ID = 13 Or dao_drrqt.fields.STATUS_ID = 23 Then
            '    date_rcv_day = dao_drrqt.fields.rcvdate
            '    date_rcv_month = dao_drrqt.fields.rcvdate
            '    date_rcv_year = dao_drrqt.fields.rcvdate

            '    XML.RCVNO_DATE = date_rcv_day.Day.ToString() & " " & date_rcv_month.ToString("MMMM") & " " & con_year(date_rcv_year.Year)
            'End If
            If dao_drrqt.fields.STATUS_ID = 8 Then

                date_rcv_day = dao_drrqt.fields.rcvdate
                date_rcv_month = dao_drrqt.fields.rcvdate
                date_rcv_year = dao_drrqt.fields.rcvdate

                date_rgt_day = dao_drrqt.fields.appdate
                date_rgt_month = dao_drrqt.fields.appdate
                date_rgt_year = dao_drrqt.fields.appdate

                XML.RGTNO_DATE = date_rgt_day.Day.ToString() & " " & date_rgt_month.ToString("MMMM") & " " & con_year(date_rgt_year.Year)
                XML.RCVNO_DATE = date_rcv_day.Day.ToString() & " " & date_rcv_month.ToString("MMMM") & " " & con_year(date_rcv_year.Year)
            End If

            dt = BAO2.SP_XML_DRUG_DRRQT(_IDA_DQ)
            dt.Columns.Add("TYPE_SUB_NAME_CHANGE")
            dt.Columns.Add("TREATMENT_AGE_FULL")
            dt.Columns.Add("WARNIG_DETIAL")
            For Each dr As DataRow In dt.Rows

                'If dr("TYPE_SUB_ID") = 1 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนไทย"
                'ElseIf dr("TYPE_SUB_ID") = 2 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                'ElseIf dr("TYPE_SUB_ID") = 3 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาพัฒนาจากสมุนไพร"
                'End If  
                Try
                    dr("RECIPE_NAME") = dao_tabean_herb.fields.RECIPE_NAME & " " & dao_tabean_herb.fields.RECIPE_UNIT_NAME

                Catch ex As Exception

                End Try
                Try
                    If dao_drrqt.fields.RCVNO_OLD <> Nothing Then
                        dr("RCVNO_NEW") = dao_drrqt.fields.RCVNO_OLD
                        dr("RCVNO_DATE") = dao_drrqt.fields.DATE_CONFIRM
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dr("WARNING_TYPE_ID") = 1 And dr("WARNING_ID") = 2 Then
                        dr("WARNIG_DETIAL") = dao_tabean_herb.fields.WARNING_NAME
                    Else
                        dr("WARNIG_DETIAL") = dao_tabean_herb.fields.WARNING_SUB_NAME
                    End If
                Catch ex As Exception

                End Try

                Dim TEXT_UP As String = ""
                Try
                    TEXT_UP = dr("FOREIGN_NAME_PLACE")
                    dr("FOREIGN_NAME_PLACE") = TEXT_UP.ToUpper()
                Catch ex As Exception

                End Try

                Try
                    If dr("TYPE_ID") = 20102 Then
                        dr("TYPE_ID") = 20101
                    ElseIf dr("TYPE_ID") = 20103 Then
                        dr("TYPE_ID") = 20101
                    ElseIf dr("TYPE_ID") = 20191 Then
                        dr("TYPE_ID") = 20101
                    ElseIf dr("TYPE_ID") = 20192 Then
                        dr("TYPE_ID") = 20101
                    ElseIf dr("TYPE_ID") = 20193 Then
                        dr("TYPE_ID") = 20101
                    ElseIf dr("TYPE_ID") = 20194 Then
                        dr("TYPE_ID") = 20104
                    End If

                Catch ex As Exception

                End Try

                Try
                    If dr("CATEGORY_ID") = 1220 Then
                        dr("CATEGORY_ID") = 122
                    ElseIf dr("CATEGORY_ID") = 1221 Then
                        dr("CATEGORY_ID") = 121
                    End If
                Catch ex As Exception

                End Try

                'Try
                '    dr("TREATMENT_AGE_FULL") = dao_tabean_herb.fields.STORAGE_NAME & " " & dao_tabean_herb.fields.TREATMENT_AGE & " " & dao_tabean_herb.fields.TREATMENT_AGE_NAME
                'Catch ex As Exception

                'End Try
                Try
                    If dao_tabean_herb.fields.TREATMENT_AGE Is Nothing Or dao_tabean_herb.fields.TREATMENT_AGE = 0 Then
                        dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao_tabean_herb.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao_tabean_herb.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    ElseIf dao_tabean_herb.fields.TREATMENT_AGE_MONTH Is Nothing Or dao_tabean_herb.fields.TREATMENT_AGE_MONTH = 0 Then
                        dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao_tabean_herb.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao_tabean_herb.fields.TREATMENT_AGE & " " & "ปี"
                    Else
                        dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao_tabean_herb.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao_tabean_herb.fields.TREATMENT_AGE & " " & "ปี" & " " & dao_tabean_herb.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    End If
                    'dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE & " " & dao.fields.TREATMENT_AGE_NAME

                Catch ex As Exception
                    dr("TREATMENT_AGE_FULL") = dao_tabean_herb.fields.STORAGE_NAME & " " & dao_tabean_herb.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                End Try
                'If dr("TYPE_SUB_ID") = 2 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                'End If
            Next
            dt.TableName = "XML_TABEAN_TBN_DRRQT_HERB"
            XML.DT_SHOW.DT1 = dt

            'Dim bao As New BAO.ClsDBSqlcommand
            Dim dt_lcn2 As New DataTable


            Dim DT_WHO As New DataTable
            Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            DT_WHO = BAO_SP.SP_XML_WHO_DALCN(_IDA)

            If TYPE_PERSON = 1 Then
                'XML.TYPE_PERSON_1 = TYPE_PERSON
                '    XML.BSN_THAINAME = THANM
                'XML.TYPE_PERSON_1 = TYPE_PERSON
                If dao_drrqt.fields.WHO_ID = True Then
                    '        dt_lcn2 = BAO_SP.SP_XML_WHO_DALCN(dao_drrqt.fields.IDA)
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                    dt_lcn2 = bao.SP_Lisense_Name_and_Addr(dao_drrqt.fields.CITIZEN_ID_AUTHORIZE) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")


                    For Each dr As DataRow In dt_lcn.Rows
                        For Each dr2 As DataRow In dt_lcn2.Rows
                            Try
                                dr("thanm") = dr2("tha_fullname")
                                XML.BSN_THAINAME = dr2("tha_fullname")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaaddr") = dr2("thaaddr")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID") = dr2("identify")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thamu") = dr2("mu")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tharoad") = dr2("tharoad")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thabuilding") = dr2("thabuilding")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thasoi") = dr2("thasoi")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thathmblnm") = dr2("thathmblnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaamphrnm") = dr2("thaamphrnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thachngwtnm") = dr2("thachngwtnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("zipcode") = dr2("zipcode")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NAME") = NAME
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tel") = dr2("tel")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("fax") = dr2("fax")
                            Catch ex As Exception

                            End Try
                        Next
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        'Try
                        '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                        '        If dr("Mobile") = Nothing Then
                        '            dr("tel") = "-"
                        '        Else
                        '            dr("tel") = dr("Mobile")
                        '        End If
                        '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                        '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                        '    End If
                        'Catch ex As Exception

                        'End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        'Try
                        '    dr("CITIZEN_ID") = citizen_bsn
                        'Catch ex As Exception

                        'End Try
                        'Try
                        '    dr("NAME_JJ") = BSN_THAIFULLNAME
                        'Catch ex As Exception

                        'End Try
                        'Try
                        '    dr("THANM") = THANM
                        'Catch ex As Exception

                        'End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next

                Else
                    'XML.TYPE_PERSON_1 = TYPE_PERSON
                    '    XML.BSN_THAINAME = THANM
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_PERSON_1"
                XML.DT_SHOW.DT2 = dt_lcn
            ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                'XML.TYPE_PERSON_99 = TYPE_PERSON
                If dao_drrqt.fields.WHO_ID = True Then
                    If TYPE_PERSON_WHO = 1 Then
                        'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
                        'XML.TYPE_PERSON_99 = TYPE_PERSON
                        XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
                        dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                        dt_lcn2 = bao.SP_Lisense_Name_and_Addr(dao_drrqt.fields.CITIZEN_ID_AUTHORIZE) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

                        dt_lcn.Columns.Add("NATION")
                        dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                        dt_lcn.Columns.Add("CITIZEN_ID")
                        'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                        dt_lcn.Columns.Add("NAME")
                        dt_lcn.Columns.Add("THANM")
                        dt_lcn.Columns.Add("THANAMEPLACE")
                        dt_lcn.Columns.Add("PERSON_AGE")
                        dt_lcn.Columns.Add("NATIONALITY_PERSON")


                        For Each dr As DataRow In dt_lcn.Rows
                            For Each dr2 As DataRow In dt_lcn2.Rows
                                Try
                                    dr("thanm") = dr2("tha_fullname")
                                    XML.BSN_THAINAME = dr2("tha_fullname")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaaddr") = dr2("thaaddr")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID") = dr2("identify")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thamu") = dr2("mu")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tharoad") = dr2("tharoad")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thabuilding") = dr2("thabuilding")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thasoi") = dr2("thasoi")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thathmblnm") = dr2("thathmblnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaamphrnm") = dr2("thaamphrnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thachngwtnm") = dr2("thachngwtnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("zipcode") = dr2("zipcode")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("NAME") = NAME
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tel") = dr2("tel")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("fax") = dr2("fax")
                                Catch ex As Exception

                                End Try
                            Next
                            Try
                                dr("NATION") = NATION
                            Catch ex As Exception

                            End Try
                            'Try
                            '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                            '        If dr("Mobile") = Nothing Then
                            '            dr("tel") = "-"
                            '        Else
                            '            dr("tel") = dr("Mobile")
                            '        End If
                            '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                            '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                            '    End If
                            'Catch ex As Exception

                            'End Try
                            Try
                                dr("PERSON_AGE") = person_age
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("TYPE_PERSON_CPN") = TYPE_PERSON
                            Catch ex As Exception

                            End Try
                            'Try
                            '    dr("CITIZEN_ID") = citizen_bsn
                            'Catch ex As Exception

                            'End Try
                            'Try
                            '    dr("NAME_JJ") = BSN_THAIFULLNAME
                            'Catch ex As Exception

                            'End Try
                            'Try
                            '    dr("THANM") = THANM
                            'Catch ex As Exception

                            'End Try
                            Try
                                dr("THANAMEPLACE") = THANAMEPLACE
                            Catch ex As Exception

                            End Try
                        Next
                    ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                        'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
                        'XML.TYPE_PERSON_99 = TYPE_PERSON
                        XML.BSN_THAIFULLNAME = dao_tabean_herb.fields.AGENT_99
                        dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                        dt_lcn2 = bao.SP_Lisense_Name_and_Addr(dao_drrqt.fields.CITIZEN_ID_AUTHORIZE)

                        dt_lcn.Columns.Add("NATION")
                        dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                        dt_lcn.Columns.Add("NAME")
                        dt_lcn.Columns.Add("THANM")
                        dt_lcn.Columns.Add("THANAMEPLACE")
                        dt_lcn.Columns.Add("PERSON_AGE")
                        dt_lcn.Columns.Add("NATIONALITY_PERSON")
                        dt_lcn.Columns.Add("CITIZEN_ID")
                        dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")

                        For Each dr As DataRow In dt_lcn.Rows
                            For Each dr2 As DataRow In dt_lcn2.Rows
                                Try
                                    dr("thanm") = dr2("tha_fullname")
                                    XML.BSN_THAINAME = dao_tabean_herb.fields.AGENT_99
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaaddr") = dr2("thaaddr")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID") = dao_tabean_herb.fields.IDEN_AGENT_99
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thamu") = dr2("mu")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tharoad") = dr2("tharoad")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thabuilding") = dr2("thabuilding")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thasoi") = dr2("thasoi")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thathmblnm") = dr2("thathmblnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaamphrnm") = dr2("thaamphrnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("zipcode") = dr2("zipcode")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("NAME") = NAME
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tel") = dr2("tel")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("fax") = dr2("fax")
                                Catch ex As Exception

                                End Try
                            Next
                            Try
                                dr("NATION") = NATION
                            Catch ex As Exception

                            End Try
                            Try
                                dr("PERSON_AGE") = person_age
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("TYPE_PERSON_CPN") = TYPE_PERSON
                            Catch ex As Exception

                            End Try

                            'Try
                            '    dr("THANM") = THANM
                            'Catch ex As Exception

                            'End Try
                            Try
                                dr("THANAMEPLACE") = THANAMEPLACE
                            Catch ex As Exception

                            End Try
                        Next
                    End If
                Else
                    'XML.TYPE_PERSON_99 = TYPE_PERSON
                    XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try

                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_NITI_99"
                XML.DT_SHOW.DT3 = dt_lcn
            End If

            'If TYPE_PERSON = 1 Then
            '    'XML.TYPE_PERSON_1 = TYPE_PERSON
            '    XML.BSN_THAINAME = THANM
            '    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

            '    dt_lcn.Columns.Add("NATION")
            '    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
            '    dt_lcn.Columns.Add("CITIZEN_ID")
            '    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
            '    dt_lcn.Columns.Add("NAME")
            '    dt_lcn.Columns.Add("THANM")
            '    dt_lcn.Columns.Add("THANAMEPLACE")
            '    dt_lcn.Columns.Add("PERSON_AGE")
            '    dt_lcn.Columns.Add("NATIONALITY_PERSON")

            '    For Each dr As DataRow In dt_lcn.Rows
            '        Try
            '            dr("NATION") = NATION
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            If dr("tel") = Nothing Or dr("tel") = "-" Then
            '                If dr("Mobile") = Nothing Then
            '                    dr("tel") = "-"
            '                Else
            '                    dr("tel") = dr("Mobile")
            '                End If
            '            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
            '                dr("tel") = dr("tel") & ", " & dr("Mobile")
            '            End If
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("PERSON_AGE") = NATION
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("NATIONALITY_PERSON") = NATION
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("TYPE_PERSON_CPN") = TYPE_PERSON
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("CITIZEN_ID") = citizen_bsn
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("NAME") = NAME
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("THANM") = THANM
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("THANAMEPLACE") = dr("thanameplace")
            '        Catch ex As Exception

            '        End Try
            '    Next
            '    dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_PERSON_1"
            '    XML.DT_SHOW.DT2 = dt_lcn
            'ElseIf TYPE_PERSON = 99 Then
            '    'XML.TYPE_PERSON_99 = TYPE_PERSON
            '    XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
            '    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

            '    dt_lcn.Columns.Add("NATION")
            '    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
            '    dt_lcn.Columns.Add("CITIZEN_ID")
            '    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
            '    dt_lcn.Columns.Add("NAME")
            '    dt_lcn.Columns.Add("THANM")
            '    dt_lcn.Columns.Add("THANAMEPLACE")

            '    For Each dr As DataRow In dt_lcn.Rows
            '        Try
            '            dr("NATION") = NATION
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            If dr("tel") = Nothing Or dr("tel") = "-" Then
            '                If dr("Mobile") = Nothing Then
            '                    dr("tel") = "-"
            '                Else
            '                    dr("tel") = dr("Mobile")
            '                End If
            '            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
            '                dr("tel") = dr("tel") & ", " & dr("Mobile")
            '            End If
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("TYPE_PERSON_CPN") = TYPE_PERSON
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("CITIZEN_ID") = citizen_bsn
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("NAME") = NAME
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("THANM") = THANM
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            dr("THANAMEPLACE") = dr("thanameplace")
            '        Catch ex As Exception

            '        End Try

            '    Next
            '    dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_NITI_99"
            '    XML.DT_SHOW.DT3 = dt_lcn
            'End If
            If dao_drrqt.fields.WHO_ID = False Then
                If TYPE_PERSON = 1 Then
                    XML.BSN_THAINAME = THANM
                ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                    XML.BSN_THAINAME = BSN_THAIFULLNAME
                End If
            End If

            If dao_lcn.fields.PROCESS_ID = 121 Then
                Dim dao_lcn_HPI As New DAO_DRUG.ClsDBdalcn
                dao_lcn_HPI.GetDataby_IDA_and_PROCESS_ID(_IDA_LCN, 121)

                Dim dao_lcn_bsn_HPI As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_lcn_bsn_HPI.GetDataby_LCN_IDA(_IDA_LCN)

                Dim dao_cpn_HPI As New DAO_CPN.clsDBsyslcnsid
                Try

                    dao_cpn_HPI.GetDataby_identify(dao_lcn_HPI.fields.CITIZEN_ID_AUTHORIZE)

                Catch ex As Exception

                End Try

                Dim TYPE_PERSON_HPI As Integer = dao_cpn_HPI.fields.type
                Dim LCNNO_DISPLAY_NEW_HPI As String = dao_lcn_HPI.fields.LCNNO_DISPLAY_NEW
                Dim THANM_HPI As String = dao_lcn_HPI.fields.thanm
                Dim BSN_THAIFULLNAME_HPI As String = dao_lcn_bsn_HPI.fields.BSN_THAIFULLNAME

                dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPI.fields.FK_IDA)

                dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPI")
                dt_lcn_location.Columns.Add("THANM_HPI")
                dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPI")

                For Each dr As DataRow In dt_lcn_location.Rows
                    Try
                        dr("LCNNO_DISPLAY_NEW_HPI") = LCNNO_DISPLAY_NEW_HPI
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_HPI") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        If TYPE_PERSON_HPI = 1 Then
                            dr("BSN_THAIFULLNAME_HPI") = "-"
                        Else
                            dr("BSN_THAIFULLNAME_HPI") = BSN_THAIFULLNAME_HPI

                        End If
                    Catch ex As Exception

                    End Try

                Next
                dt_lcn_location.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_HPI"
                XML.DT_SHOW.DT4 = dt_lcn_location
            ElseIf dao_lcn.fields.PROCESS_ID = 122 Then
                Dim dao_lcn_HPM As New DAO_DRUG.ClsDBdalcn
                dao_lcn_HPM.GetDataby_IDA_and_PROCESS_ID(_IDA_LCN, 122)

                Dim dao_lcn_bsn_HPM As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_lcn_bsn_HPM.GetDataby_LCN_IDA(_IDA_LCN)

                Dim dao_cpn_HPM As New DAO_CPN.clsDBsyslcnsid
                Try

                    dao_cpn_HPM.GetDataby_identify(dao_lcn_HPM.fields.CITIZEN_ID_AUTHORIZE)

                Catch ex As Exception

                End Try
                Dim TYPE_PERSON_HPM As Integer = dao_cpn_HPM.fields.type
                Dim LCNNO_DISPLAY_NEW_HPM As String = dao_lcn_HPM.fields.LCNNO_DISPLAY_NEW
                Dim THANM_HPM As String = dao_lcn_HPM.fields.thanm
                Dim BSN_THAIFULLNAME_HPM As String = dao_lcn_bsn_HPM.fields.BSN_THAIFULLNAME

                dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPM.fields.FK_IDA)

                dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPM")
                dt_lcn_location.Columns.Add("THANM_HPM")
                dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPM")
                dt_lcn_location.Columns.Add("TREATMENT_AGE_FULL")

                For Each dr As DataRow In dt_lcn_location.Rows
                    Try
                        dr("LCNNO_DISPLAY_NEW_HPM") = LCNNO_DISPLAY_NEW_HPM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_HPM") = THANM
                    Catch ex As Exception

                    End Try
                    If TYPE_PERSON_HPM = 1 Then
                        dr("BSN_THAIFULLNAME_HPM") = "-"
                    Else
                        dr("BSN_THAIFULLNAME_HPM") = BSN_THAIFULLNAME_HPM

                    End If
                Next

                dt_lcn_location.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_HPM"
                XML.DT_SHOW.DT5 = dt_lcn_location
            End If

            Dim bao_sp2 As New BAO.ClsDBSqlcommand
            XML.DT_SHOW.DT6 = bao_sp2.SP_DRRQT_PRODUCER_IN_BY_FK_IDA_V2(_IDA_DQ)
            XML.DT_SHOW.DT6.TableName = "SP_DRRQT_PRODUCER_IN_BY_FK_IDA_V2"
            Try
                If dao_tabean_herb.fields.NATIONALITY_PERSON_ID = 1 Then
                    XML.NATIONALITY_PERSON = dao_tabean_herb.fields.NATIONALITY_PERSON
                Else
                    XML.NATIONALITY_PERSON = dao_tabean_herb.fields.NATIONALITY_PERSON_OTHER
                End If
            Catch ex As Exception

            End Try

            If TYPE_PERSON = 1 Then
                XML.THANM_THAIFULLNAME = THANM
            ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                XML.THANM_THAIFULLNAME = BSN_THAIFULLNAME
            End If

            Return XML
        End Function

        Public Function gen_xml_tbn_2(ByVal _IDA As Integer, ByVal _IDA_DQ As Integer, ByVal _IDA_LCN As Integer)
            Dim XML As New CLASS_DRRQT

            Dim bao_lcn As New BAO_SHOW

            Dim dt_lcn As New DataTable
            Dim dt_lcn_location As New DataTable

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
            dao_drrqt.GetDataby_IDA(_IDA_DQ)
            Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao_tabean_herb.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
            dao_drrqt.GetDataby_IDA(_IDA_DQ)
            XML.DRRQT = dao_drrqt.fields
            Dim IDENTIFY As String = ""
            If dao_drrqt.fields.CITIZEN_ID_AUTHORIZE = "" Then
                IDENTIFY = dao_drrqt.fields.IDENTIFY
            Else
                IDENTIFY = dao_drrqt.fields.CITIZEN_ID_AUTHORIZE
            End If
            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(IDENTIFY)

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

            Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Try
                dao_esub.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try
            Dim THANM As String = dao_lcn.fields.thanm
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            ' Dim THANM As String = dao_lcn.fields.thanm

            Dim CITIZEN_ID As String = IDENTIFY
            Dim CITIZEN_ID_AUTHORIZE As String = IDENTIFY
            Dim NAME As String = dao_drrqt.fields.CREATE_BY
            Dim THANAMEPLACE As String = dao_lcn.fields.thanameplace

            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Dim dao_who As New DAO_WHO.TB_WHO_DALCN
            dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
            Dim WHO_NAME As String = ""
            WHO_NAME = dao_who.fields.THANM_NAME
            Try
                dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
                Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
                Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
                'If dao_drrqt.fields.WHO_ID = True Then
                '    BSN_THAIFULLNAME = WHO_NAME
                'Else
                '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME
                'End If
                BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            Catch ex As Exception

            End Try
            'Try
            '    dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
            '    Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
            '    Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
            '    Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
            '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            'Catch ex As Exception

            'End Try

            Dim dt As New DataTable
            Dim BAO As New BAO_TABEAN_HERB.tb_main

            Dim date_rcv_day As Date
            Dim date_rcv_month As Date
            Dim date_rcv_year As Date

            Dim date_rgt_day As Date
            Dim date_rgt_month As Date
            Dim date_rgt_year As Date

            If dao_drrqt.fields.STATUS_ID = 6 Or dao_drrqt.fields.STATUS_ID = 11 Or dao_drrqt.fields.STATUS_ID = 12 Or dao_drrqt.fields.STATUS_ID = 13 Then
                date_rcv_day = dao_drrqt.fields.rcvdate
                date_rcv_month = dao_drrqt.fields.rcvdate
                date_rcv_year = dao_drrqt.fields.rcvdate

                XML.RCVNO_DATE = date_rcv_day.Day.ToString() & " " & date_rcv_month.ToString("MMMM") & " " & con_year(date_rcv_year.Year)
            ElseIf dao_drrqt.fields.STATUS_ID = 8 Then

                date_rcv_day = dao_drrqt.fields.rcvdate
                date_rcv_month = dao_drrqt.fields.rcvdate
                date_rcv_year = dao_drrqt.fields.rcvdate

                date_rgt_day = dao_drrqt.fields.appdate
                date_rgt_month = dao_drrqt.fields.appdate
                date_rgt_year = dao_drrqt.fields.appdate

                XML.date_rgt_day = date_rgt_day.Day.ToString()
                XML.date_rgt_month = date_rgt_month.ToString("MMMM")
                XML.date_rgt_year = con_year(date_rgt_year.Year)

                Try
                    Dim a As String = date_rgt_day.Day.ToString() - 1
                    Dim b As String = date_rgt_month.ToString("MMMM")
                    Dim c As String = con_year(date_rgt_year.Year) + 5

                    XML.date_rgt_exdate_day = a
                    XML.date_rgt_exdate_month = b
                    XML.date_rgt_exdate_year = c

                    XML.RGTNO_DATE_END = a & " " & b & " " & c
                Catch ex As Exception

                End Try

                XML.RGTNO_DATE = date_rgt_day.Day.ToString() & " " & date_rgt_month.ToString("MMMM") & " " & con_year(date_rgt_year.Year)
                XML.RCVNO_DATE = date_rcv_day.Day.ToString() & " " & date_rcv_month.ToString("MMMM") & " " & con_year(date_rcv_year.Year)
            End If

            dt = BAO.SP_XML_DRUG_DRRQT(_IDA_DQ)
            dt.Columns.Add("TYPE_SUB_NAME_CHANGE")
            For Each dr As DataRow In dt.Rows

                If dr("TYPE_SUB_ID") = 1 Then
                    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนไทย"
                ElseIf dr("TYPE_SUB_ID") = 2 Then
                    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                ElseIf dr("TYPE_SUB_ID") = 3 Then
                    dr("TYPE_SUB_NAME_CHANGE") = "ยาพัฒนาจากสมุนไพร"
                End If

                If dr("LCN_NAME") = Nothing Then
                    dr("LCN_NAME") = THANM
                End If

                Try
                    If dao_tabean_herb.fields.FOREIGN_NAME = "" Then
                        dr("FOREIGN_NAME") = "-"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_tabean_herb.fields.FOREIGN_NAME = "" Then
                        dr("FOREIGN_NAME") = "-"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_tabean_herb.fields.FOREIGN_NAME_PLACE = "" Then
                        dr("FOREIGN_NAME_PLACE") = "-"
                    End If
                Catch ex As Exception

                End Try
            Next
            dt.TableName = "XML_TABEAN_TBN_DRRQT_HERB"
            XML.DT_SHOW.DT1 = dt

            If TYPE_PERSON = 1 Then
                'XML.TYPE_PERSON_1 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANAMEPLACE")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NAME") = NAME
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try
                Next
            ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                'XML.TYPE_PERSON_99 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANAMEPLACE")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NAME") = NAME
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try

                Next

            End If
            dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS"
            XML.DT_SHOW.DT2 = dt_lcn

            'Dim dt_formula As DataTable
            'Dim bao_master_2 As New BAO.ClsDBSqlcommand
            'dt_formula = bao_master_2.SP_drug_formula_JJ(_IDA)
            'dt_formula.TableName = "XML_TABEAN_FORMULA_JJ"
            'XML.DT_SHOW.DT3 = dt_formula

            If dao_drrqt.fields.WHO_ID = True Then
                If TYPE_PERSON = 1 Then
                    XML.THANM_THAIFULLNAME = THANM
                ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                    XML.THANM_THAIFULLNAME = THANM
                End If
            Else
                XML.THANM_THAIFULLNAME = THANM
            End If

            If TYPE_PERSON = 1 Then
                XML.BSN_THAINAME = THANM
            ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                XML.BSN_THAINAME = BSN_THAIFULLNAME
            End If
            Return XML
        End Function
        Public Function gen_xml_tbn_2_renew(ByVal _IDA As Integer, ByVal _IDA_DQ As Integer, ByVal _IDA_LCN As Integer)
            Dim XML As New CLASS_DRRQT

            Dim bao_lcn As New BAO_SHOW

            Dim dt_lcn As New DataTable
            Dim dt_lcn_location As New DataTable

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
            dao_drrgt.GetDataby_IDA(_IDA_DQ)
            Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt

            Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            Try
                dao_drrqt.GetDataby_IDA(dao_drrgt.fields.FK_DRRQT)
                dao_tabean_herb.GetdatabyID_FK_IDA_DQ(dao_drrgt.fields.FK_DRRQT)
            Catch ex As Exception

            End Try
            dao_drrqt.GetDataby_IDA(_IDA_DQ)

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao_drrgt.fields.IDENTIFY)

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

            Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Try
                dao_esub.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try
            Dim THANM As String = dao_lcn.fields.thanm
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            ' Dim THANM As String = dao_lcn.fields.thanm

            Dim CITIZEN_ID As String = dao_drrqt.fields.IDENTIFY
            Dim CITIZEN_ID_AUTHORIZE As String = dao_drrqt.fields.CITIZEN_ID_AUTHORIZE
            Dim NAME As String = dao_drrqt.fields.CREATE_BY
            Dim THANAMEPLACE As String = dao_lcn.fields.thanameplace

            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Dim dao_who As New DAO_WHO.TB_WHO_DALCN
            dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
            Dim WHO_NAME As String = ""
            WHO_NAME = dao_who.fields.THANM_NAME
            Try
                dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
                Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
                Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
                'If dao_drrqt.fields.WHO_ID = True Then
                '    BSN_THAIFULLNAME = WHO_NAME
                'Else
                '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME
                'End If
                BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            Catch ex As Exception

            End Try
            'Try
            '    dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
            '    Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
            '    Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
            '    Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
            '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            'Catch ex As Exception

            'End Try

            Dim dt As New DataTable
            Dim BAO As New BAO_TABEAN_HERB.tb_main

            Dim date_rcv_day As Date
            Dim date_rcv_month As Date
            Dim date_rcv_year As Date

            Dim date_rgt_day As Date
            Dim date_rgt_month As Date
            Dim date_rgt_year As Date

            If dao_drrqt.fields.STATUS_ID = 6 Or dao_drrqt.fields.STATUS_ID = 11 Or dao_drrqt.fields.STATUS_ID = 12 Or dao_drrqt.fields.STATUS_ID = 13 Then
                date_rcv_day = dao_drrqt.fields.rcvdate
                date_rcv_month = dao_drrqt.fields.rcvdate
                date_rcv_year = dao_drrqt.fields.rcvdate

                XML.RCVNO_DATE = date_rcv_day.Day.ToString() & " " & date_rcv_month.ToString("MMMM") & " " & con_year(date_rcv_year.Year)
            ElseIf dao_drrqt.fields.STATUS_ID = 8 Then

                date_rcv_day = dao_drrqt.fields.rcvdate
                date_rcv_month = dao_drrqt.fields.rcvdate
                date_rcv_year = dao_drrqt.fields.rcvdate

                date_rgt_day = dao_drrqt.fields.appdate
                date_rgt_month = dao_drrqt.fields.appdate
                date_rgt_year = dao_drrqt.fields.appdate

                XML.date_rgt_day = date_rgt_day.Day.ToString()
                XML.date_rgt_month = date_rgt_month.ToString("MMMM")
                XML.date_rgt_year = con_year(date_rgt_year.Year)

                Try
                    Dim a As String = date_rgt_day.Day.ToString() - 1
                    Dim b As String = date_rgt_month.ToString("MMMM")
                    Dim c As String = con_year(date_rgt_year.Year) + 5

                    XML.date_rgt_exdate_day = a
                    XML.date_rgt_exdate_month = b
                    XML.date_rgt_exdate_year = c

                    XML.RGTNO_DATE_END = a & " " & b & " " & c
                Catch ex As Exception

                End Try

                XML.RGTNO_DATE = date_rgt_day.Day.ToString() & " " & date_rgt_month.ToString("MMMM") & " " & con_year(date_rgt_year.Year)
                XML.RCVNO_DATE = date_rcv_day.Day.ToString() & " " & date_rcv_month.ToString("MMMM") & " " & con_year(date_rcv_year.Year)
            End If

            dt = BAO.SP_XML_DRUG_DRRQT(_IDA_DQ)
            dt.Columns.Add("TYPE_SUB_NAME_CHANGE")
            For Each dr As DataRow In dt.Rows

                If dr("TYPE_SUB_ID") = 1 Then
                    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนไทย"
                ElseIf dr("TYPE_SUB_ID") = 2 Then
                    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                ElseIf dr("TYPE_SUB_ID") = 3 Then
                    dr("TYPE_SUB_NAME_CHANGE") = "ยาพัฒนาจากสมุนไพร"
                End If

                If dr("LCN_NAME") = Nothing Then
                    dr("LCN_NAME") = THANM
                End If

                Try
                    If dao_tabean_herb.fields.FOREIGN_NAME = "" Then
                        dr("FOREIGN_NAME") = "-"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_tabean_herb.fields.FOREIGN_NAME = "" Then
                        dr("FOREIGN_NAME") = "-"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_tabean_herb.fields.FOREIGN_NAME_PLACE = "" Then
                        dr("FOREIGN_NAME_PLACE") = "-"
                    End If
                Catch ex As Exception

                End Try
            Next
            dt.TableName = "XML_TABEAN_TBN_DRRQT_HERB"
            XML.DT_SHOW.DT1 = dt

            If TYPE_PERSON = 1 Then
                'XML.TYPE_PERSON_1 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANAMEPLACE")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NAME") = NAME
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try
                Next
            ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                'XML.TYPE_PERSON_99 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANAMEPLACE")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NAME") = NAME
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try

                Next

            End If
            dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS"
            XML.DT_SHOW.DT2 = dt_lcn

            'Dim dt_formula As DataTable
            'Dim bao_master_2 As New BAO.ClsDBSqlcommand
            'dt_formula = bao_master_2.SP_drug_formula_JJ(_IDA)
            'dt_formula.TableName = "XML_TABEAN_FORMULA_JJ"
            'XML.DT_SHOW.DT3 = dt_formula

            If dao_drrqt.fields.WHO_ID = True Then
                If TYPE_PERSON = 1 Then
                    XML.THANM_THAIFULLNAME = THANM
                ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                    XML.THANM_THAIFULLNAME = THANM
                End If
            Else
                XML.THANM_THAIFULLNAME = THANM
            End If

            If TYPE_PERSON = 1 Then
                XML.BSN_THAINAME = THANM
            ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                XML.BSN_THAINAME = BSN_THAIFULLNAME
            End If
            Return XML
        End Function
        Public Function gen_xml_approve(ByVal _IDA As Integer, ByVal _IDA_DQ As Integer, ByVal _IDA_LCN As Integer)
            Dim XML As New CLASS_DRRQT

            Dim bao_lcn As New BAO_SHOW

            Dim dt_lcn As New DataTable
            Dim dt_lcn_location As New DataTable

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)

            Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
            dao_drrqt.GetDataby_IDA(_IDA_DQ)

            Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao_tabean_herb.GetdatabyID_IDA(_IDA)

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao_drrqt.fields.CITIZEN_ID_AUTHORIZE)

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            Dim THANM As String = dao_lcn.fields.thanm

            Dim CITIZEN_ID As String = dao_drrqt.fields.IDENTIFY
            Dim CITIZEN_ID_AUTHORIZE As String = dao_drrqt.fields.CITIZEN_ID_AUTHORIZE
            Dim NAME As String = dao_drrqt.fields.CREATE_BY
            Dim THANAMEPLACE As String = dao_lcn.fields.thanameplace

            Dim dt As New DataTable
            Dim BAO As New BAO_TABEAN_HERB.tb_main

            Dim date_rcv_day As Date
            Dim date_rcv_month As Date
            Dim date_rcv_year As Date

            Dim date_rgt_day As Date
            Dim date_rgt_month As Date
            Dim date_rgt_year As Date

            If dao_drrqt.fields.STATUS_ID = 6 Or dao_drrqt.fields.STATUS_ID = 11 Or dao_drrqt.fields.STATUS_ID = 12 Or dao_drrqt.fields.STATUS_ID = 13 Then
                date_rcv_day = dao_drrqt.fields.rcvdate
                date_rgt_month = dao_drrqt.fields.rcvdate
                date_rgt_year = dao_drrqt.fields.rcvdate

                XML.RCVNO_DATE = date_rcv_day.Day.ToString() & " " & date_rcv_month.Month.ToString("MMMM") & " " & con_year(date_rcv_year.Year)
            End If
            If dao_drrqt.fields.STATUS_ID = 8 Then
                date_rgt_day = dao_drrqt.fields.appdate
                date_rgt_month = dao_drrqt.fields.appdate
                date_rgt_year = dao_drrqt.fields.appdate

                XML.date_rgt_day = date_rgt_day.Day.ToString()
                XML.date_rgt_month = date_rgt_month.ToString("MMMM")
                XML.date_rgt_year = con_year(date_rgt_year.Year)

                Try
                    Dim a As String = date_rgt_day.Day.ToString() - 1
                    Dim b As String = date_rgt_month.ToString("MMMM")
                    Dim c As String = con_year(date_rgt_year.Year) + 1

                    XML.date_rgt_exdate_day = a
                    XML.date_rgt_exdate_month = b
                    XML.date_rgt_exdate_year = c
                Catch ex As Exception

                End Try

                XML.RGTNO_DATE = date_rgt_day.Day.ToString() & " " & date_rgt_month.ToString("MMMM") & " " & con_year(date_rgt_year.Year)
                XML.RCVNO_DATE = date_rcv_day.Day.ToString() & " " & date_rcv_month.ToString("MMMM") & " " & con_year(date_rcv_year.Year)
            End If

            Dim PROCESS_NAME As String = ""

            If dao_drrqt.fields.PROCESS_ID = 20101 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาแผนไทย"
            ElseIf dao_drrqt.fields.PROCESS_ID = 20102 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาตามองค์ความรู้การแพทย์ทางเลือก"
            ElseIf dao_drrqt.fields.PROCESS_ID = 20103 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาพัฒนาจากสมุนไพร"
            ElseIf dao_drrqt.fields.PROCESS_ID = 20104 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ"
            End If

            XML.PROCESS_NAME = PROCESS_NAME

            dt = BAO.SP_XML_DRUG_DRRQT(_IDA_DQ)

            dt.TableName = "XML_TABEAN_TBN_DRRQT_HERB"
            XML.DT_SHOW.DT1 = dt

            Return XML
        End Function

    End Class

    Public Class APPOINTMAENT
        Inherits Center
#Region "property"
        Private _process_id As String
        Public Property process_id() As String
            Get
                Return _process_id
            End Get
            Set(ByVal value As String)
                _process_id = value
            End Set
        End Property

        Private _lcnno_display_name As String
        Public Property lcnno_display_new() As String
            Get
                Return _lcnno_display_name
            End Get
            Set(ByVal value As String)
                _lcnno_display_name = value
            End Set
        End Property

        Private _rcvno_full As String
        Public Property rcvno_full() As String
            Get
                Return _rcvno_full
            End Get
            Set(ByVal value As String)
                _rcvno_full = value
            End Set
        End Property

        Private _name_thai_name_place As String
        Public Property name_thai_name_place() As String
            Get
                Return _name_thai_name_place
            End Get
            Set(ByVal value As String)
                _name_thai_name_place = value
            End Set
        End Property

        Private _date_req_full As String
        Public Property date_req_full() As String
            Get
                Return _date_req_full
            End Get
            Set(ByVal value As String)
                _date_req_full = value
            End Set
        End Property
        Private _date_estimate_full As String
        Public Property date_estimate_full() As String
            Get
                Return _date_estimate_full
            End Get
            Set(ByVal value As String)
                _date_estimate_full = value
            End Set
        End Property
        Private _date_period_estimate_full As String
        Public Property date_period_estimate_full() As String
            Get
                Return _date_period_estimate_full
            End Get
            Set(ByVal value As String)
                _date_period_estimate_full = value
            End Set
        End Property

        Private _thanm As String
        Public Property thanm() As String
            Get
                Return _thanm
            End Get
            Set(ByVal value As String)
                _thanm = value
            End Set
        End Property
        Private _COMPLICATE_NAME As String
        Public Property COMPLICATE_NAME() As String
            Get
                Return _COMPLICATE_NAME
            End Get
            Set(ByVal value As String)
                _COMPLICATE_NAME = value
            End Set
        End Property
        Private _NAME_CONTACT As String
        Public Property NAME_CONTACT() As String
            Get
                Return _NAME_CONTACT
            End Get
            Set(ByVal value As String)
                _NAME_CONTACT = value
            End Set
        End Property

        Private _citizen_id As String
        Public Property citizen_id() As String
            Get
                Return _citizen_id
            End Get
            Set(ByVal value As String)
                _citizen_id = value
            End Set
        End Property

        Private _IDA As String
        Public Property IDA() As String
            Get
                Return _IDA
            End Get
            Set(ByVal value As String)
                _IDA = value
            End Set
        End Property
        Private _TR_ID As String
        Public Property TR_ID() As String
            Get
                Return _TR_ID
            End Get
            Set(ByVal value As String)
                _TR_ID = value
            End Set
        End Property
        Private _appointment_date As String
        Public Property appointment_date() As String
            Get
                Return _appointment_date
            End Get
            Set(ByVal value As String)
                _appointment_date = value
            End Set
        End Property

        Private _tel_callback As String
        Public Property tel_callback() As String
            Get
                Return _tel_callback
            End Get
            Set(ByVal value As String)
                _tel_callback = value
            End Set
        End Property

        Private _E_MAIL As String
        Public Property E_MAIL() As String
            Get
                Return _E_MAIL
            End Get
            Set(ByVal value As String)
                _E_MAIL = value
            End Set
        End Property

        Private _group_assign As String
        Public Property group_assign() As String
            Get
                Return _group_assign
            End Get
            Set(ByVal value As String)
                _group_assign = value
            End Set
        End Property

        Private _PROCESS_NAME As String
        Public Property PROCESS_NAME() As String
            Get
                Return _PROCESS_NAME
            End Get
            Set(ByVal value As String)
                _PROCESS_NAME = value
            End Set
        End Property

        Private _DISCOUNT_DETAIL As String
        Public Property DISCOUNT_DETAIL() As String
            Get
                Return _DISCOUNT_DETAIL
            End Get
            Set(ByVal value As String)
                _DISCOUNT_DETAIL = value
            End Set
        End Property
#End Region
        Public Function XML_APOINTMENT() As CLASS_APPOINTMENT

            Dim cls As New CLASS_APPOINTMENT

            Dim PROCESS_NAME As String = ""

            If process_id = 20101 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาแผนไทย"
            ElseIf process_id = 20102 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาตามองค์ความรู้การแพทย์ทางเลือก"
            ElseIf process_id = 20103 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาพัฒนาจากสมุนไพร"
            ElseIf process_id = 20104 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ"
            ElseIf process_id = 20301 Then
                PROCESS_NAME = "การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาแผนไทย"
            ElseIf process_id = 20302 Then
                PROCESS_NAME = "การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาตามองค์ความรู้การแพทย์ทางเลือก"
            ElseIf process_id = 20303 Then
                PROCESS_NAME = "การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาพัฒนาจากสมุนไพร"
            ElseIf process_id = 20304 Then
                PROCESS_NAME = "การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ"
            ElseIf process_id = 20901 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาแผนไทย เพื่อส่งออก"
            ElseIf process_id = 20902 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาตามองค์ความรู้การแพทย์ทางเลือก เพื่อส่งออก"
            ElseIf process_id = 20903 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาพัฒนาจากสมุนไพร เพื่อส่งออก"
            ElseIf process_id = 20904 Then
                PROCESS_NAME = "การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ เพื่อส่งออก"
            ElseIf process_id = 20410 Then
                PROCESS_NAME = "การขออนุญาตแก้ไขเปลี่ยนแปลงใบสำคัญการขึ้นทะเบียนผลิตภัณฑ์สมุนไพร"
            ElseIf process_id = 20430 Then
                PROCESS_NAME = "การขออนุญาตแก้ไขเปลี่ยนแปลงใบรับจดแจ้งผลิตภัณฑ์สมุนไพร "
            ElseIf process_id = 20411 Then
                PROCESS_NAME = "การขออนุญาตแก้ไขเปลี่ยนแปลงใบสำคัญการขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ระดับหลัก "
            ElseIf process_id = 20412 Then
                PROCESS_NAME = "การขออนุญาตแก้ไขเปลี่ยนแปลงใบสำคัญการขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ระดับรอง"
            ElseIf process_id = 20810 Then
                PROCESS_NAME = "การขออนุญาตผลิตภัณฑ์ เพื่อเป็นตัวอย่างสำหรับการขึ้นทะเบียน การแจ้งรายละเอียด หรือการจดแจ้ง"
            ElseIf process_id = 120 Then
                PROCESS_NAME = "การขออนุญาตสถานที่ขายผลิตภัณฑ์สมุนไพร"
            ElseIf process_id = 121 Then
                PROCESS_NAME = "การขออนุญาตสถานที่นำเข้าผลิตภัณฑ์สมุนไพร"
            ElseIf process_id = 122 Then
                PROCESS_NAME = "การขออนุญาตสถานที่ผลิตผลิตภัณฑ์สมุนไพร"
            ElseIf process_id = 10201 Then
                PROCESS_NAME = "การขอแก้ไขใบอนุญาตสถานที่เดิม"
            ElseIf process_id = 10301 Then
                PROCESS_NAME = "การขอโอนใบอนุญาตสถานที่"
            ElseIf process_id = 10401 Then
                PROCESS_NAME = "การขอใบแทนใบอนุญาตสถานที่"
            ElseIf process_id = 20419 Then
                PROCESS_NAME = "การขออนุญาตแก้ไขเปลี่ยนแปลงใบสำคัญการขึ้นทะเบียนผลิตภัณฑ์สมุนไพร เฉพาะกิจ"
            ElseIf process_id = 21010 Then
                PROCESS_NAME = "การขออนุญาตผลิตหรือนำเข้าผลิตภัณฑ์สมุนไพรเพื่อการแสดงนิทรรศการ"
            End If

            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)

            cls.process_id = process_id
            cls.process_name = PROCESS_NAME
            cls.product_name = name_thai_name_place
            cls.dalcnno = lcnno_display_new
            cls.rcvno = rcvno_full
            cls.rcvdate = date_req_full
            cls.appointment_date = appointment_date 'วันนัด
            cls.estimate_date = _date_estimate_full  'วันที่เริ่มประเมินเอกสารวิชาการ
            cls.estimate_date_max = _date_period_estimate_full ''ระยะเวลาในการดำเนินการจนแล้วเสร็จ
            'cls.name_req = cls.thanm
            cls.name_req = thanm
            cls.tel_req = tel_callback
            'cls.tel_req = obj.TEL
            'cls.name_contact = NAME_CONTACT
            cls.name_contact = NAME_CONTACT
            cls.tel_callback = tel_callback
            cls.email = E_MAIL
            'cls.email = obj.EMAIL
            cls.group_assign = group_assign
            cls.TR_ID = TR_ID
            cls.DISCOUNT_DETAIL = DISCOUNT_DETAIL
            cls.COMPLICATE_NAME = _COMPLICATE_NAME

            Return cls
        End Function

    End Class

    Public Class TABEAN_HERB_EX
        Inherits Center

        Public Function gen_xml_TB_EX(ByVal _IDA_EX As Integer, ByVal _IDA_LCN As Integer)
            Dim XML As New CLASS_TABEAN_EX
            Dim bao_lcn As New BAO_SHOW

            Dim dt_lcn As New DataTable
            Dim dt_ex As New DataTable
            Dim dt_lcn_location As New DataTable

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)

            Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr.GetDataby_FK_IDA(_IDA_LCN)

            Dim dao_package As New DAO_TABEAN_HERB.TB_DRSAMP_PACKAGE_SIZE
            dao_package.GetdatabyID_FK_IDA_EX2(_IDA_EX)

            Dim dao_ex As New DAO_DRUG.ClsDBdrsamp
            dao_ex.GetDataby_IDA(_IDA_EX)

            Dim FRGN_NAME As String = dao_ex.fields.FOREIGN_NAME
            Try
                If dao_ex.fields.FOREIGN_NAME IsNot Nothing Then
                    FRGN_NAME.Replace("&nbsp;", "")
                    dao_ex.fields.FOREIGN_NAME = FRGN_NAME
                End If
            Catch ex As Exception

            End Try
            XML.TABEAN_EX = dao_ex.fields

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao_ex.fields.CUSTOMER_CITIZEN_AUTHORIZE)

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            'Dim THANM As String = dao_lcn.fields.thanm
            Dim THANM As String = ""
            THANM = FULLNAME_CPN(dao_ex.fields.CUSTOMER_CITIZEN_AUTHORIZE)
            Dim THANM_FULLNAME As String = dao_lcn.fields.thanm

            Dim CITIZEN_ID As String = dao_ex.fields.CITIZEN_SUBMIT
            Dim CITIZEN_ID_AUTHORIZE As String = dao_ex.fields.CUSTOMER_CITIZEN_AUTHORIZE
            Dim NAME As String = dao_ex.fields.EX_CREATE_BY
            Dim THANAMEPLACE As String = dao_lcn.fields.thanameplace

            Dim dt As New DataTable
            Dim BAO As New BAO_TABEAN_HERB.tb_main

            Dim date_confirm As Date
            Dim date_cf_show As String = ""
            Dim date_app As String = ""
            Dim WRITE_DATE As Date
            Dim RCV_DATE As Date


            dt = BAO.SP_XML_DRUG_DRSMR(_IDA_EX)

            dt.TableName = "XML_TABEAN_EX_HERB"
            XML.DT_SHOW.DT1 = dt

            XML.PHR_NAME_FULL = dao_phr.fields.PHR_PREFIX_NAME & " " & dao_phr.fields.PHR_NAME

            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn.GetDataby_LCN_IDA(dao_ex.fields.LCN_IDA)
            XML.BSN_NAME_FULL = dao_bsn.fields.BSN_THAIFULLNAME
            Try
                WRITE_DATE = dao_ex.fields.WRITE_DATE
                date_confirm = dao_ex.fields.EX_DATE_CONFIRM
                RCV_DATE = dao_ex.fields.rcvdate
                XML.date_confirm_full = date_confirm.Day.ToString() & " " & date_confirm.ToString("MMMM") & " " & con_year(date_confirm.Year)
                XML.date_write_full = WRITE_DATE.Day.ToString() & " " & WRITE_DATE.ToString("MMMM") & " " & con_year(WRITE_DATE.Year)

                XML.date_write_day = WRITE_DATE.Day.ToString()
                XML.date_write_month = WRITE_DATE.ToString("MMMM")
                XML.date_write_year = con_year(WRITE_DATE.Year)
                XML.date_rcv_full = RCV_DATE.Day.ToString() & " " & RCV_DATE.ToString("MMMM") & " " & con_year(RCV_DATE.Year)
            Catch ex As Exception

            End Try

            If TYPE_PERSON = 1 Then
                'XML.TYPE_PERSON_1 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANM_FULLNAME")
                dt_lcn.Columns.Add("THANAMEPLACE")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NAME") = NAME
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_FULLNAME") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try
                Next
            ElseIf TYPE_PERSON = 99 Then
                'XML.TYPE_PERSON_99 = TYPE_PERSON
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                dt_lcn.Columns.Add("NATION")
                dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                dt_lcn.Columns.Add("CITIZEN_ID")
                dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                dt_lcn.Columns.Add("NAME")
                dt_lcn.Columns.Add("THANM")
                dt_lcn.Columns.Add("THANM_FULLNAME")
                dt_lcn.Columns.Add("THANAMEPLACE")

                For Each dr As DataRow In dt_lcn.Rows
                    Try
                        dr("NATION") = NATION
                    Catch ex As Exception

                    End Try
                    Try
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NAME") = NAME
                    Catch ex As Exception

                    End Try
                    Try
                        'dr("THANM") = THANM
                        dr("THANM") = dao_lcn.fields.syslcnsnm_prefixnm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_FULLNAME") = dao_bsn.fields.BSN_THAIFULLNAME
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANAMEPLACE") = THANAMEPLACE
                    Catch ex As Exception

                    End Try

                Next

            End If
            dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS"
            XML.DT_SHOW.DT2 = dt_lcn


            dt = BAO.SP_XML_DRUG_DRSMR_PACKAGE_SIZE(_IDA_EX)

            dt.TableName = "XML_TABEAN_EX_HERB_PACKAGE_SIZE"
            XML.DT_SHOW.DT3 = dt

            dt_ex = BAO.SP_XML_DRUG_DRSMR_PACKAGE_SIZE_BY_FK(_IDA_EX)

            dt_ex.Columns.Add("PACKAGE_NAME_FULL")
            dt_ex.Columns.Add("APPDATE_FULL")
            Dim test As String = ""
            For Each dr As DataRow In dt_ex.Rows
                Try
                    dr("APPDATE_FULL") = date_to_thai(dao_ex.fields.appdate)
                Catch ex As Exception

                End Try

                If test = "" Then
                    test = dr("PACKAGE_FULL")
                Else
                    test += dr("PACKAGE_FULL") & vbCrLf
                End If

                dr("PACKAGE_NAME_FULL") = test

                Try
                    'dr("PACKAGE_NAME_FULL") = dao_package.fields.NO_1 & vbCrLf & dao_package.fields.UNIT_F_NAME & "x" & dao_package.fields.NO_2 & vbCrLf & dao_package.fields.UNIT_S_NAME & "x " & dao_package.fields.NO_3 & vbCrLf & dao_package.fields.UNIT_T_NAME & "(" & dao_package.fields.SUM_PACKAGE_UNIT & vbCrLf & dao_package.fields.UNIT_F_NAME & ")"
                Catch ex As Exception

                End Try
            Next
            dt_ex.TableName = "SP_XML_DRUG_DRSMR_PACKAGE_SIZE"
            XML.DT_SHOW.DT4 = dt_ex

            Return XML
        End Function
    End Class

    Public Class TABEAN_HERB_JJ_EDIT
        Inherits Center

        Public Function Gen_XML_JJ3_Edit(ByVal IDA As Integer, ByVal IDA_LCN As Integer)
            Dim XML As New CLASS_TABEAN_JJ_EDIT
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER

            'Dim dt As New DataTable
            Dim dt_lcn As New DataTable
            Dim dt_lcn_location As New DataTable
            Dim dt_jj As New DataTable
            Dim dt_jj_EDIT As New DataTable

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
            dao.GetdatabyID_IDA(IDA)

            Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao_jj.GetdatabyID_IDA(dao.fields.FK_IDA)

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(IDA_LCN)

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Try
                dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
            Catch ex As Exception
                dao_customer.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)
            End Try

            Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Try
                dao_esub.GetDataby_LCN_IDA(IDA_LCN)
            Catch ex As Exception

            End Try
            Dim THANM As String = dao_lcn.fields.thanm
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(IDA_LCN)
            Catch ex As Exception

            End Try

            Dim citizen_bsn As String = tb_location.fields.BSN_IDENTIFY
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Dim dao_who As New DAO_WHO.TB_WHO_DALCN
            dao_who.GetdatabyID_FK_LCN(IDA_LCN)
            Dim WHO_NAME As String = ""
            WHO_NAME = dao_who.fields.THANM_NAME
            Try
                dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
                Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
                Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
                'If dao.fields.WHO_ID = True Then
                '    BSN_THAIFULLNAME = WHO_NAME
                'Else
                '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME
                'End If
                BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            Catch ex As Exception

            End Try
            Dim date_FULL As String = ""
            Dim person_age As String = ""
            Dim NATIONALITY_PERSON As String = ""
            Try
                person_age = dao.fields.PERSON_AGE
                If dao.fields.NATIONALITY_PERSON_ID = 1 Then
                    NATIONALITY_PERSON = dao.fields.NATIONALITY_PERSON
                Else
                    NATIONALITY_PERSON = dao.fields.NATIONALITY_PERSON_OTHER
                End If
            Catch ex As Exception

            End Try

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            'Dim THANM As String = dao_lcn.fields.thanm
            Dim log As New DAO_TABEAN_HERB.TB_LOG_EDIT_JJ
            Try
                log.Getdataby_FK_IDA(IDA)
            Catch ex As Exception

            End Try


            Dim addr_edit As String = ""
            Dim bao As New BAO_MASTER
            Dim dt As New DataTable
            Try
                dt = bao.SP_ADDR_BY_IDA(IDA_LCN)
            Catch ex As Exception

            End Try
            Dim addr As String = ""
            If dt.Rows.Count > 0 Then
                addr = dt(0)("fulladdr")
            End If

            XML.TABEAN_JJ_EDIT_REQUEST = dao.fields


            ''''''''''''''''''''''DT1''''''''''''''''''''''''''''''''''''''''
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.GetdatabyID_TR_ID(dao.fields.TR_ID_JJ)
            Dim CITIZEN_ID As String = dao.fields.CITIZEN_ID
            Dim CITIZEN_ID_AUTHORIZE As String = dao.fields.CITIZEN_ID_AUTHORIZE
            Dim NAME_JJ As String = dao.fields.NAME_JJ
            Dim THANAMEPLACE As String = dao.fields.LCN_THANAMEPLACE
            Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
            dao_cb.GetdatabyID_FK_IDA(IDA)
            Dim bao_xml As New BAO_TABEAN_HERB.tb_xml
            dt_jj_EDIT = bao_xml.SP_XML_TABEAN_JJ_EDIT_REQUES_V2(IDA)
            dt_jj_EDIT.Columns.Add("NAME_PRODUCK_NEW")
            dt_jj_EDIT.Columns.Add("NAME_PRODUCK_NEW2")
            dt_jj_EDIT.Columns.Add("NAME_PRODUCK_OLD")
            dt_jj_EDIT.Columns.Add("NAME_PRODUCK_OLD2")
            dt_jj_EDIT.Columns.Add("ADDR_NEW")
            dt_jj_EDIT.Columns.Add("PACKING_SIZE_NEW")
            dt_jj_EDIT.Columns.Add("PACKING_SIZE_OLD")
            dt_jj_EDIT.Columns.Add("RCVNO_DATE")
            dt_jj_EDIT.Columns.Add("OTHER_REQUEST_FULL")
            dt_jj_EDIT.Columns.Add("ANOTHER_OTHER_ID")
            dt_jj_EDIT.Columns.Add("ANOTHER_LICENSE_ID")
            dt_jj_EDIT.Columns.Add("DOCUMENT_NAME_OLD")
            dt_jj_EDIT.Columns.Add("DOCUMENT_NAME_NEW")
            dt_jj_EDIT.Columns.Add("THANM")
            dt_jj_EDIT.Columns.Add("BSN_THAIFULLNAME")
            'dt_jj_EDIT.Columns.Add("SUPPORT_EDIT_ID")
            Dim NAME_ENG As String = ""
            Dim NAME_OTHER As String = ""
            For Each dr As DataRow In dt_jj_EDIT.Rows

                Try
                    If dao.fields.STATUS_ID = 10 Or dao.fields.STATUS_ID = 7 Then
                        dr("APP_REQ") = dao.fields.CANCEL_STAFF_NM
                    End If
                    If dao_cb.fields.Label_And_Ducumant = 1 Then
                        dr("DOCUMENT_NAME_OLD") = "เอกสารกำกับเดิม"
                        dr("DOCUMENT_NAME_NEW") = "เอกสารกำกับใหม่"
                    End If
                Catch ex As Exception

                End Try
                'Try
                '    For Each dao_up.fields In dao_up.datas
                '        If dao_up.fields.DOCUMENT_NAME.Contains("หนังสือให้การยินยอมตามที่") Then
                '            dao_up.fields.
                '        End If
                '    Next

                'Catch ex As Exception

                'End Try
                Try
                    dr("BSN_THAIFULLNAME") = dao_jj.fields.AGENT_99
                    dr("THANM") = THANM
                    If dao.fields.STATUS_ID = 8 Then
                        dr("ANOTHER_LICENSE_ID") = 1

                    ElseIf dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 10 Then
                        dr("ANOTHER_LICENSE_ID") = 2
                    End If
                    If IsNothing(dao.fields.OTHER_REQUEST_ID) = True Then
                        dr("ANOTHER_OTHER_ID") = 0
                    Else
                        dr("ANOTHER_OTHER_ID") = 1
                        dr("OTHER_REQUEST_FULL") = dao.fields.OTHER_REQUEST_NAME & " " & dao.fields.OTHER_REQUEST_DAY & " วัน"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_jj.fields.NAME_OTHER = "" Then
                        NAME_OTHER = "-"
                    Else
                        NAME_OTHER = dao_jj.fields.NAME_OTHER
                    End If
                    If dao_jj.fields.NAME_ENG = "" Then
                        NAME_ENG = "-"
                    Else
                        NAME_ENG = dao_jj.fields.NAME_ENG
                    End If
                    'Dim NAME_PRODUCT As String = ""
                    'Dim NAME_PRODUCT2 As String = ""
                    If dao_cb.fields.NAME_PRODUCK_1 = 1 And dao_cb.fields.NAME_PRODUCK_2 = 1 Then
                        dr("NAME_PRODUCK_NEW") = "ชื่อภาษาอังกฤษ: " & dr("NAME_ENG")
                        dr("NAME_PRODUCK_NEW2") = "ชื่อภาษาต่างประเทศอื่น: " & dr("NAME_OTHER")
                        dr("NAME_PRODUCK_OLD") = "ชื่อภาษาอังกฤษ:" & NAME_ENG
                        dr("NAME_PRODUCK_OLD2") = "ชื่อภาษาต่างประเทศอื่น:" & NAME_OTHER
                    ElseIf dao_cb.fields.NAME_PRODUCK_3 = 1 And dao_cb.fields.NAME_PRODUCK_4 = 1 Then
                        dr("NAME_PRODUCK_NEW") = "ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอังกฤษ: " & dr("EXPORTNAME_ENG")
                        dr("NAME_PRODUCK_NEW2") = "ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอื่น: " & dr("EXPORTNAME_OTHER")
                        dr("NAME_PRODUCK_OLD") = "ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอังกฤษ:" & NAME_ENG
                        dr("NAME_PRODUCK_OLD2") = "ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอื่น: " & NAME_OTHER
                    ElseIf dao_cb.fields.NAME_PRODUCK_1 = 1 Then
                        dr("NAME_PRODUCK_NEW") = "ชื่อภาษาอังกฤษ: " & dr("NAME_ENG")
                        dr("NAME_PRODUCK_OLD") = "ชื่อภาษาอังกฤษ: " & NAME_ENG
                    ElseIf dao_cb.fields.NAME_PRODUCK_2 = 1 Then
                        dr("NAME_PRODUCK_NEW") = "ชื่อภาษาต่างประเทศอื่น: " & dr("NAME_OTHER")
                        dr("NAME_PRODUCK_OLD") = "ชื่อภาษาต่างประเทศอื่น: " & NAME_OTHER
                    ElseIf dao_cb.fields.NAME_PRODUCK_3 = 1 Then
                        dr("NAME_PRODUCK_NEW") = "ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอังกฤษ: " & dr("EXPORTNAME_ENG")
                        dr("NAME_PRODUCK_OLD") = "ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอังกฤษ: " & NAME_ENG
                    ElseIf dao_cb.fields.NAME_PRODUCK_4 = 1 Then
                        dr("NAME_PRODUCK_NEW") = "ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอื่น: " & dr("EXPORTNAME_OTHER")
                        dr("NAME_PRODUCK_OLD") = "ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอื่น: " & NAME_OTHER
                    End If
                    'dr("NAME_PRODUCK_NEW") = NAME_PRODUCT
                    'dr("NAME_PRODUCK_NEW2") = NAME_PRODUCT2

                Catch ex As Exception

                End Try
                Try
                    If dao_cb.fields.NAME_ADDR1 = 1 Or dao_cb.fields.NAME_ADDR1 = 2 Then
                        addr_edit = log.fields.ADDR_NM_NEW & "/ " & log.fields.ADDR_FULL_NEW
                    ElseIf dao_cb.fields.NAME_ADDR1 = 3 Then
                        addr_edit = log.fields.FOREIGN_NAME_PLACE_NEW
                    End If
                    dr("ADDR_NEW") = addr_edit
                Catch ex As Exception

                End Try
                Try
                    If dao_cb.fields.Size_Packet = 1 Then
                        dr("PACKING_SIZE_NEW") = "ขนาดบรรจุใหม่"
                        dr("PACKING_SIZE_OLD") = "ขนาดบรรจุเดิม"
                    End If
                    'dr("PACKAGE_NAME_FULL") = dao_package.fields.NO_1 & vbCrLf & dao_package.fields.UNIT_F_NAME & "x" & dao_package.fields.NO_2 & vbCrLf & dao_package.fields.UNIT_S_NAME & "x " & dao_package.fields.NO_3 & vbCrLf & dao_package.fields.UNIT_T_NAME & "(" & dao_package.fields.SUM_PACKAGE_UNIT & vbCrLf & dao_package.fields.UNIT_F_NAME & ")"
                Catch ex As Exception

                End Try

                Try
                    date_FULL = date_to_thai(dao.fields.DATE_REQ)
                    dr("RCVNO_DATE") = date_FULL

                Catch ex As Exception

                End Try
            Next
            dt_jj_EDIT.TableName = "XML_TABEAN_JJ_EDIT"
            XML.DT_SHOW.DT1 = dt_jj_EDIT

            ''''''''''''''''''''''DT2''''''''''''''''''''''''''''''''''''''''''''''''''''
            dt_jj = bao_xml.SP_XML_TABEAN_JJ(dao.fields.FK_IDA)
            dt_jj.Columns.Add("NAME_PRODUCK")
            dt_jj.Columns.Add("ADDR")
            dt_jj.Columns.Add("PACKING_SIZE")
            For Each dr As DataRow In dt_jj.Rows
                Dim NAME_PRODUCT As String = ""
                Try
                    If dao_cb.fields.NAME_PRODUCK_3 = 1 And dao_cb.fields.NAME_PRODUCK_4 = 1 Then
                        NAME_PRODUCT = dr("NAME_ENG") & ", " & dr("NAME_OTHER")
                    ElseIf dao_cb.fields.NAME_PRODUCK_3 = 1 Then
                        NAME_PRODUCT = dr("NAME_ENG")
                    ElseIf dao_cb.fields.NAME_PRODUCK_4 = 1 Then
                        NAME_PRODUCT += dr("NAME_OTHER")
                    End If
                    dr("NAME_PRODUCK") = NAME_PRODUCT

                Catch ex As Exception

                End Try
                Try
                    If dao_cb.fields.NAME_ADDR1 = 1 Or dao_cb.fields.NAME_ADDR1 = 2 Then
                        addr_edit = log.fields.ADDR_NM & "/ " & log.fields.ADDR_FULL
                    ElseIf dao_cb.fields.NAME_ADDR1 = 3 Then
                        addr_edit = log.fields.FOREIGN_NAME_PLACE
                    End If
                    dr("ADDR") = addr_edit
                Catch ex As Exception

                End Try
                Try
                    If dao_cb.fields.Size_Packet = 1 Then
                        dr("PACKING_SIZE") = dao_jj.fields.SIZE_PACK
                    End If
                Catch ex As Exception

                End Try
            Next
            dt_jj.TableName = "XML_TABEAN_JJ"
            XML.DT_SHOW.DT2 = dt_jj



            Dim DT_WHO As New DataTable
            Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            DT_WHO = BAO_SP.SP_XML_WHO_DALCN(IDA)
            'ข้อ 2 
            If TYPE_PERSON = 1 Then
                XML.TYPE_PERSON_1 = TYPE_PERSON
                If dao.fields.WHO_ID = True Then
                    dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    'dt_lcn.Columns.Add("CITIZEN_ID")
                    'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        'Try
                        '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                        '        If dr("Mobile") = Nothing Then
                        '            dr("tel") = "-"
                        '        Else
                        '            dr("tel") = dr("Mobile")
                        '        End If
                        '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                        '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                        '    End If
                        'Catch ex As Exception

                        'End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next

                Else
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_JJ_EDIT_LOCATION_ADDRESS_PERSON_1"
                XML.DT_SHOW.DT3 = dt_lcn
            ElseIf TYPE_PERSON = 99 Then
                XML.TYPE_PERSON_99 = TYPE_PERSON
                If dao.fields.WHO_ID = True Then
                    dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    'dt_lcn.Columns.Add("CITIZEN_ID")
                    'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        'Try
                        '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                        '        If dr("Mobile") = Nothing Then
                        '            dr("tel") = "-"
                        '        Else
                        '            dr("tel") = dr("Mobile")
                        '        End If
                        '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                        '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                        '    End If
                        'Catch ex As Exception

                        'End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next

                Else
                    If dao_lcn.fields.FK_IDA <> 0 Then
                        dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                    End If


                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try

                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_JJ_EDIT_LOCATION_ADDRESS_NITI_99"
                XML.DT_SHOW.DT4 = dt_lcn
            End If

            If TYPE_PERSON = 1 Then
                XML.BSN_THAIFULLNAME = THANM
            ElseIf TYPE_PERSON = 99 Then
                XML.BSN_THAIFULLNAME = dao_jj.fields.AGENT_99
            End If

            Dim DT_SUBPACKAGE As New DataTable
            Dim dao_sp As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_SUBPACKAGE
            dao_sp.GetData_ByFkIDA(IDA)
            Dim ID_SUBPACK As Integer = 0

            Try
                DT_SUBPACKAGE.Columns.Add("IDA")
                DT_SUBPACKAGE.Columns.Add("NAME_PACKAGE")

                For Each dao_sp.fields In dao_sp.datas
                    Dim RW_SUB As DataRow = DT_SUBPACKAGE.NewRow
                    ID_SUBPACK += 1
                    RW_SUB("IDA") = ID_SUBPACK
                    RW_SUB("NAME_PACKAGE") = dao_sp.fields.PACK_FSIZE_NAME & " " & dao_sp.fields.PACK_FSIZE_VOLUME & " " & dao_sp.fields.PACK_FSIZE_NAME & " " &
                            dao_sp.fields.PACK_SECSIZE_NAME & " " & dao_sp.fields.PACK_SECSIZE_VOLUME & " " & dao_sp.fields.PACK_SECSIZE_UNIT_NAME & " " &
                            dao_sp.fields.PACK_THSIZE_NAME & " " & dao_sp.fields.PACK_THSSIZE_VOLUME & " " & dao_sp.fields.PACK_THSIZE_UNIT_NAME
                    DT_SUBPACKAGE.Rows.Add(RW_SUB)
                Next

            Catch ex As Exception

            End Try

            DT_SUBPACKAGE.TableName = "XML_TABEAN_JJ_EDIT_SUBPACKAGE"
            XML.DT_SHOW.DT6 = DT_SUBPACKAGE

            XML.TABEAN_JJ_EDIT_REQUEST = dao.fields
            'Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
            dao_cb.GetdatabyID_FK_IDA(_IDA)
            If dao_cb.fields.IDA <> 0 Then
                'dao_cb.fields.FK_IDA = IDA
                If dao_cb.fields.NAME_PRODUCK_1 = 1 Or dao_cb.fields.NAME_PRODUCK_2 = 1 Or dao_cb.fields.NAME_PRODUCK_3 = 1 Or dao_cb.fields.NAME_PRODUCK_4 = 1 Then
                    XML.CHK_MENU_1 = 1
                End If
                If dao_cb.fields.NAME_ADDR1 = 1 Or dao_cb.fields.NAME_ADDR2 = 1 Or dao_cb.fields.NAME_ADDR3 = 1 Then
                    XML.CHK_MENU_2 = 1
                End If
                If dao_cb.fields.Size_Packet = 1 Then
                    XML.CHK_MENU_3 = 1
                End If
                If dao_cb.fields.Label_And_Ducumant = 1 Then
                    XML.CHK_MENU_4 = 1
                End If
            End If

            Try
                XML.appdate_full_thai = date_to_thai(dao.fields.DATE_APP)

            Catch ex As Exception
                If dao.fields.STATUS_ID = 10 Or dao.fields.STATUS_ID = 7 Then
                    XML.appdate_full_thai = date_to_thai(dao.fields.cncdate)
                End If
            End Try

            Return XML
        End Function
    End Class
    Public Class DALCN_PHR_NEW
        Inherits Center
        Public Function Gen_XML_PHR(ByVal IDA As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim class_xml As New CLASS_DALCN_PHR
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR

            Dim cls_DALCN_PHR As New DALCN_PHR
            dao.GetDataby_IDA(IDA)
            class_xml.DALCN_PHR = dao.fields

            Dim DT_PHR As New DataTable
            Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            DT_PHR = BAO_SP.SP_DALCN_PHR_CUSTOMER_ADDR(IDA)
            DT_PHR.TableName = "XML_DALCN_PHR_ADDR_BSN"
            class_xml.DT_SHOW.DT1 = DT_PHR


            Dim DT_TRAINING As New DataTable
            Dim BAO As New BAO_MASTER
            DT_TRAINING = BAO.SP_DALCN_PHR_TRAINING(IDA)
            DT_TRAINING.Columns.Add("SIMINAR_DATE_FULL")
            For Each dr As DataRow In DT_TRAINING.Rows
                Try
                    dr("SIMINAR_DATE_FULL") = date_to_thai(dr("SIMINAR_DATE"))
                Catch ex As Exception

                End Try
            Next
            DT_TRAINING.TableName = "XML_DALCN_PHR_TRAINING"
            class_xml.DT_SHOW.DT2 = DT_TRAINING

            Dim date_FULL As String = ""
            Try
                date_FULL = date_to_thai(dao.fields.WRITE_DATE)
                class_xml.WRITEDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.rcvdate)
                class_xml.RCVDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.appdate)
                class_xml.APPDATE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try
            Dim VETERINARY_ID As Integer
            Try
                VETERINARY_ID = dao.fields.PERSONAL_TYPE_OTHER_ID
                If VETERINARY_ID = 32 Then
                    class_xml.PHR_TYPE = 3
                    class_xml.qualification = dao.fields.STUDY_LEVEL
                    class_xml.qualification_branch = dao.fields.PHR_VETERINARY_FIELD
                    class_xml.qualification_year = dao.fields.STUDY_YEAR
                ElseIf VETERINARY_ID = 27 Or VETERINARY_ID = 28 Or VETERINARY_ID = 30 Or VETERINARY_ID = 31 Then
                    class_xml.PHR_TYPE = 1
                    class_xml.Pharmacy_license_date = dao.fields.PHR_Operating_time
                    class_xml.Pharmacy_license_number = dao.fields.PHR_TEXT_NUM
                    class_xml.Pharmacy_license_branch = dao.fields.PHR_JOB_TYPE
                    class_xml.qualification_v = dao.fields.STUDY_LEVEL
                ElseIf VETERINARY_ID = 8 Or VETERINARY_ID = 9 Or VETERINARY_ID = 29 Then
                    class_xml.PHR_TYPE = 2
                    class_xml.Pharmacy_license_date = dao.fields.PHR_Operating_time
                    class_xml.Pharmacy_license_number = dao.fields.PHR_TEXT_NUM
                    class_xml.Pharmacy_license_branch = dao.fields.PHR_JOB_TYPE
                    class_xml.qualification_v = dao.fields.STUDY_LEVEL
                End If
            Catch ex As Exception

            End Try
            Return class_xml
        End Function
    End Class

    Public Class DALCN_PLAN
        Inherits Center
        Public Function Gen_XML_LCN_PLAN(ByVal IDA As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim class_xml As New CLASS_DALCN_PLAN
            Dim dao As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION

            dao.GET_DATA_BY_IDA(IDA)
            class_xml.DALCN_PLAN = dao.fields

            Dim date_FULL As String = ""
            Try
                date_FULL = date_to_thai(dao.fields.WRITE_DATE)
                class_xml.WRITEDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.rcvdate)
                class_xml.RCVDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.cnsdate)
                class_xml.CNSDATE_FULL_TH = date_FULL

                date_FULL = date_to_thai(dao.fields.appdate)
                class_xml.APPDATE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try

            Dim dao_A As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
            dao_A.GET_DATA_BY_FK_IDA_AND_HEAD_ID(IDA, 1)
            Dim DT As New DataTable
            Dim R As DataRow = DT.NewRow
            For Each dao_A.fields In dao_A.datas
                DT.Columns.Add("CHK_HEAD_NMAE_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("CHK_1_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("CHK_2_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("CHK_3_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("HEAD_ID_" & dao_A.fields.ID.Replace(".", "_"))

                'Dim R As DataRow = DT.NewRow
                R("CHK_HEAD_NMAE_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.ID
                R("CHK_1_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.CHK_MENU_1
                R("CHK_2_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.CHK_MENU_2
                R("CHK_3_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.CHK_MENU_3
                R("HEAD_ID_" & dao_A.fields.ID.Replace(".", "_")) = 1

            Next
            DT.Rows.Add(R)
            DT.TableName = "XML_DETAIL_GROUP_DRUG"
            class_xml.DT1_1 = DT

            Dim dao_A2 As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
            dao_A2.GET_DATA_BY_FK_IDA_AND_HEAD_ID(IDA, 2)
            Dim DT2 As New DataTable
            Dim R2 As DataRow = DT2.NewRow
            For Each dao_A2.fields In dao_A2.datas
                DT2.Columns.Add("CHK_HEAD_NMAE_" & dao_A2.fields.ID.Replace(".", "_"))
                DT2.Columns.Add("CHK_1_" & dao_A2.fields.ID.Replace(".", "_"))
                DT2.Columns.Add("CHK_2_" & dao_A2.fields.ID.Replace(".", "_"))
                DT2.Columns.Add("CHK_3_" & dao_A2.fields.ID.Replace(".", "_"))
                DT2.Columns.Add("HEAD_ID_" & dao_A2.fields.ID.Replace(".", "_"))

                'Dim R As DataRow = DT.NewRow
                R2("CHK_HEAD_NMAE_" & dao_A2.fields.ID.Replace(".", "_")) = dao_A2.fields.ID
                R2("CHK_1_" & dao_A2.fields.ID.Replace(".", "_")) = dao_A2.fields.CHK_MENU_1
                R2("CHK_2_" & dao_A2.fields.ID.Replace(".", "_")) = dao_A2.fields.CHK_MENU_2
                R2("CHK_3_" & dao_A2.fields.ID.Replace(".", "_")) = dao_A2.fields.CHK_MENU_3
                R2("HEAD_ID_" & dao_A2.fields.ID.Replace(".", "_")) = 2

            Next
            DT2.Rows.Add(R2)
            DT2.TableName = "XML_DETAIL_GROUP_DRUG2"
            class_xml.DT1_2 = DT2

            Dim dao_A3 As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
            dao_A3.GET_DATA_BY_FK_IDA_AND_HEAD_ID(IDA, 3)
            Dim DT3 As New DataTable
            Dim R3 As DataRow = DT3.NewRow
            For Each dao_A3.fields In dao_A3.datas
                DT3.Columns.Add("CHK_HEAD_NMAE_" & dao_A3.fields.ID.Replace(".", "_"))
                DT3.Columns.Add("CHK_1_" & dao_A3.fields.ID.Replace(".", "_"))
                DT3.Columns.Add("CHK_2_" & dao_A3.fields.ID.Replace(".", "_"))
                DT3.Columns.Add("CHK_3_" & dao_A3.fields.ID.Replace(".", "_"))
                DT3.Columns.Add("HEAD_ID_" & dao_A3.fields.ID.Replace(".", "_"))

                'Dim R As DataRow = DT.NewRow
                R3("CHK_HEAD_NMAE_" & dao_A3.fields.ID.Replace(".", "_")) = dao_A3.fields.ID
                R3("CHK_1_" & dao_A3.fields.ID.Replace(".", "_")) = dao_A3.fields.CHK_MENU_1
                R3("CHK_2_" & dao_A3.fields.ID.Replace(".", "_")) = dao_A3.fields.CHK_MENU_2
                R3("CHK_3_" & dao_A3.fields.ID.Replace(".", "_")) = dao_A3.fields.CHK_MENU_3
                R3("HEAD_ID_" & dao_A3.fields.ID.Replace(".", "_")) = 3


            Next
            DT3.Rows.Add(R3)
            DT3.TableName = "XML_DETAIL_GROUP_DRUG2"
            class_xml.DT1_3 = DT3

            Dim dao_A4 As New DAO_LCN.TB_DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
            dao_A4.GET_DATA_BY_FK_IDA_AND_HEAD_ID(IDA, 4)
            Dim DT4 As New DataTable
            Dim R4 As DataRow = DT4.NewRow
            For Each dao_A4.fields In dao_A4.datas
                DT4.Columns.Add("CHK_HEAD_NMAE_" & dao_A4.fields.ID.Replace(".", "_"))
                DT4.Columns.Add("CHK_1_" & dao_A4.fields.ID.Replace(".", "_"))
                DT4.Columns.Add("CHK_2_" & dao_A4.fields.ID.Replace(".", "_"))
                DT4.Columns.Add("CHK_3_" & dao_A4.fields.ID.Replace(".", "_"))
                DT4.Columns.Add("HEAD_ID_" & dao_A4.fields.ID.Replace(".", "_"))

                'Dim R As DataRow = DT.NewRow
                R4("CHK_HEAD_NMAE_" & dao_A4.fields.ID.Replace(".", "_")) = dao_A4.fields.ID
                R4("CHK_1_" & dao_A4.fields.ID.Replace(".", "_")) = dao_A4.fields.CHK_MENU_1
                R4("CHK_2_" & dao_A4.fields.ID.Replace(".", "_")) = dao_A4.fields.CHK_MENU_2
                R4("CHK_3_" & dao_A4.fields.ID.Replace(".", "_")) = dao_A4.fields.CHK_MENU_3
                R4("HEAD_ID_" & dao_A4.fields.ID.Replace(".", "_")) = 4

            Next
            DT4.Rows.Add(R4)
            DT4.TableName = "XML_DETAIL_GROUP_DRUG4"
            class_xml.DT1_4 = DT4

            Return class_xml
        End Function
    End Class

    Public Class DALCN_RENEW
        Inherits Center
        Public Function Gen_XML_LCN_RENEW(ByVal IDA As Integer, ByVal LCN_IDA As String)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim class_xml As New CLASS_DALCN_RENEW
            Dim dao As New DAO_LCN.TB_DALCN_RENEW
            Dim _date As Date
            Dim dateD_TH As String = ""
            Dim dateM_TH As String = ""
            Dim dateY_TH As String = ""
            Dim dateD As Date
            Dim dateM As Date
            Dim dateY As Date
            Dim date_FULL As String = ""

            dao.GET_DATA_BY_IDA(IDA)
            class_xml.DALCN_RENEW = dao.fields

            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn.GetDataby_LCN_IDA(LCN_IDA)
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Dim dao_cpn2 As New DAO_CPN.clsDBsyslcnsid
            dao_cpn2.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)
            Dim THANM As String = ""
            Dim TYPE_PERSON As String = ""
            Try
                TYPE_PERSON = dao_cpn2.fields.type
                If TYPE_PERSON = 1 Then
                    THANM = dao.fields.RENREW_NAME
                Else
                    dao_pfx.Getdata_byid(dao_bsn.fields.BSN_PREFIXTHAICD)
                    Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                    Dim BSN_THAINAME As String = dao_bsn.fields.BSN_THAINAME
                    Dim BSN_THAILASTNAME As String = dao_bsn.fields.BSN_THAILASTNAME
                    BSN_THAIFULLNAME = dao_bsn.fields.BSN_THAIFULLNAME
                    'BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & BSN_THAILASTNAME
                End If
                BSN_THAIFULLNAME = dao_bsn.fields.BSN_THAIFULLNAME
                'Try
                If TYPE_PERSON = 1 Then
                    class_xml.THANM_THAIFULLNAME = THANM
                Else
                    class_xml.THANM_THAIFULLNAME = BSN_THAIFULLNAME
                End If
                class_xml.BSN_THAIFULLNAME = BSN_THAIFULLNAME
            Catch ex As Exception

            End Try

            Try
                _date = dao.fields.WRITE_DATE
                _date = CDate(_date).ToString("dd/MM/yyy")
                dateD = dao.fields.WRITE_DATE
                dateM = dao.fields.WRITE_DATE
                dateY = dao.fields.WRITE_DATE

                dateD_TH = dateD.Day.ToString()
                dateM_TH = dateM.ToString("MMMM")
                dateY_TH = con_year(dateY.Year)
                date_FULL = dateD_TH & " " & dateM_TH & " " & dateY_TH
                class_xml.WRITEDATE_FULL_THAI = date_FULL

                _date = dao.fields.rcvdate
                _date = CDate(_date).ToString("dd/MM/yyy")
                dateD = dao.fields.rcvdate
                dateM = dao.fields.rcvdate
                dateY = dao.fields.rcvdate

                dateD_TH = dateD.Day.ToString()
                dateM_TH = dateM.ToString("MMMM")
                dateY_TH = con_year(dateY.Year)
                date_FULL = dateD_TH & " " & dateM_TH & " " & dateY_TH
                class_xml.RCVDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.appdate)
                class_xml.APPDATE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try

            Return class_xml
        End Function
    End Class

    Public Class DALCN_TRANSFER
        Inherits Center
        Public Function Gen_XML_LCN_TRANSFER(ByVal IDA As Integer, ByVal LCN_IDA As String)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim class_xml As New CLASS_DALCN_TRANSFER
            Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
            'Dim _date As Date
            Dim date_FULL As String = ""
            dao.GET_DATA_BY_IDA(IDA)
            class_xml.DALCN_TRANSFER = dao.fields
            Try
                date_FULL = date_to_thai(dao.fields.rcvdate)
                class_xml.RCVDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.cnsdate)
                class_xml.CNSDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.appdate)
                class_xml.APPDATE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try
            Try
                date_FULL = date_to_thai(dao.fields.WRITE_DATE)
                class_xml.WRITEDATE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try
            Try
                date_FULL = date_to_thai(dao.fields.WORK_PERMIT_EXPIRE)
                class_xml.WORK_PERMIT_EXPIRE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try
            Try
                date_FULL = date_to_thai(dao.fields.TRANSFER_DATE)
                class_xml.TRANSFER_DATE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try
            Try
                date_FULL = date_to_thai(dao.fields.OPENTIME)
                class_xml.OPENTIME_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try
            Try
                date_FULL = date_to_thai(dao.fields.PASSPORT_EXPIRE)
                class_xml.PASSPORT_EXPIRE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try
            Return class_xml
        End Function
    End Class
    Public Class DALCN_AUDIT
        Inherits Center
        Public Function Gen_XML_LCN_AUDIT_IN(ByVal IDA As Integer, ByVal LCN_IDA As String)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim class_xml As New CLASS_DALCN_AUDIT
            Dim dao As New DAO_LCN.TB_DALCN_AUDIT_IN
            Dim dao_A As New DAO_LCN.TB_DALCN_AUDIT_DETAIL_GROUP_DRUG
            'Dim _date As Date
            Dim date_FULL As String = ""

            dao.GET_DATA_BY_IDA(IDA)
            dao_A.GET_DATA_BY_FK_IDA(IDA)
            class_xml.DALCN_AUDIT_IN = dao.fields
            Try
                date_FULL = date_to_thai(dao.fields.rcvdate)
                class_xml.RCVDATE_FULL_THAI = date_FULL

                'date_FULL = date_to_thai(dao.fields.cnsdate)
                'class_xml.CNSDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.appdate)
                class_xml.APPDATE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try

            'Dim DT_AUDIT_GROUP As New DataTable
            'Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            'DT_AUDIT_GROUP = BAO_SP.SP_DALCN_AUDIT_DETAIL_GROUP_DRUG(IDA, dao.fields.PROCESS_ID)
            'DT_AUDIT_GROUP.TableName = "XML_DALCN_AUDIT_DETAIL_GROUP_DRUG"
            'class_xml.DT_SHOW.DT1 = DT_AUDIT_GROUP

            Dim DT As New DataTable
            Dim R As DataRow = DT.NewRow
            For Each dao_A.fields In dao_A.datas
                DT.Columns.Add("CHK_HEAD_NMAE_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("CHK_1_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("CHK_2_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("CHK_3_" & dao_A.fields.ID.Replace(".", "_"))

                'Dim R As DataRow = DT.NewRow
                R("CHK_HEAD_NMAE_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.ID
                R("CHK_1_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.CHK_MENU_1
                R("CHK_2_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.CHK_MENU_2
                R("CHK_3_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.CHK_MENU_3


            Next
            DT.Rows.Add(R)
            DT.TableName = "XML_DETAIL_GROUP_DRUG"
            class_xml.DT1_1 = DT

            Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_up.GetDataby_FK_IDA_AND_TR_ID_AND_TYPE(dao.fields.IDA, dao.fields.TR_ID, 1)
            Dim DT_UP As New DataTable
            DT_UP.Columns.Add("FILE_UPLOAD_NAME")
            DT_UP.Columns.Add("FILE_UPLOAD_NAME_FAKE")
            DT_UP.Columns.Add("FILE_UPLOAD_NAME_REAL")
            DT_UP.Columns.Add("STATUS_ID")
            DT_UP.Columns.Add("PROCESS_ID")
            DT_UP.Columns.Add("STATUS_FILE")

            For Each dao_up.fields In dao_up.datas
                Dim R2 As DataRow = DT_UP.NewRow
                R2("FILE_UPLOAD_NAME") = dao_up.fields.DOCUMENT_NAME
                R2("FILE_UPLOAD_NAME_FAKE") = dao_up.fields.NAME_FAKE
                R2("FILE_UPLOAD_NAME_REAL") = dao_up.fields.NAME_REAL
                R2("STATUS_ID") = dao_up.fields.TYPE
                R2("PROCESS_ID") = dao_up.fields.PROCESS_ID
                R2("STATUS_FILE") = dao_up.fields.Status_file
                DT_UP.Rows.Add(R2)
            Next
            DT_UP.TableName = "XML_FILE_UPLOAD_STATUS"
            class_xml.DT_SHOW.DT1 = DT_UP

            Dim DT_CH As New DataTable
            Dim R3 As DataRow = DT_CH.NewRow
            Dim ID As Integer = 0
            For Each dao_up.fields In dao_up.datas
                ID = ID + 1
                DT_CH.Columns.Add("CHK_FILE_NMAE_" & ID)

                'Dim R As DataRow = DT.NewRow
                R3("CHK_FILE_NMAE_" & ID) = dao_up.fields.Status_file
            Next
            DT_CH.Rows.Add(R3)
            DT_CH.TableName = "XML_STATUS_FILE_UPLOAD_CHK"
            class_xml.DT_SHOW.DT2 = DT_CH


            Return class_xml
        End Function

        Public Function Gen_XML_LCN_AUDIT_OUT(ByVal IDA As Integer, ByVal LCN_IDA As String)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim class_xml As New CLASS_DALCN_AUDIT
            Dim dao As New DAO_LCN.TB_DALCN_AUDIT_OUT
            Dim dao_A As New DAO_LCN.TB_DALCN_AUDIT_DETAIL_GROUP_DRUG
            'Dim _date As Date
            Dim date_FULL As String = ""

            dao.GET_DATA_BY_IDA(IDA)
            dao_A.GET_DATA_BY_FK_IDA_AND_PROCESS(IDA, dao.fields.PROCESS_ID)
            class_xml.DALCN_AUDIT_OUT = dao.fields
            Try
                date_FULL = date_to_thai(dao.fields.rcvdate)
                class_xml.RCVDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.cnsddate)
                class_xml.CNSDATE_FULL_TH = date_FULL

                date_FULL = date_to_thai(dao.fields.appdate)
                class_xml.APPDATE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try



            Dim DT As New DataTable
            Dim R As DataRow = DT.NewRow
            For Each dao_A.fields In dao_A.datas
                DT.Columns.Add("CHK_HEAD_NMAE_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("CHK_1_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("CHK_2_" & dao_A.fields.ID.Replace(".", "_"))
                DT.Columns.Add("CHK_3_" & dao_A.fields.ID.Replace(".", "_"))

                'Dim R As DataRow = DT.NewRow
                R("CHK_HEAD_NMAE_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.ID
                R("CHK_1_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.CHK_MENU_1
                R("CHK_2_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.CHK_MENU_2
                R("CHK_3_" & dao_A.fields.ID.Replace(".", "_")) = dao_A.fields.CHK_MENU_3


            Next
            DT.Rows.Add(R)
            DT.TableName = "XML_DETAIL_GROUP_DRUG"
            class_xml.DT1_1 = DT

            Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_up.GetDataby_FK_IDA_AND_TR_ID_AND_TYPE(dao.fields.IDA, dao.fields.TR_ID, 1)
            Dim DT_UP As New DataTable
            DT_UP.Columns.Add("FILE_UPLOAD_NAME")
            DT_UP.Columns.Add("FILE_UPLOAD_NAME_FAKE")
            DT_UP.Columns.Add("FILE_UPLOAD_NAME_REAL")
            DT_UP.Columns.Add("STATUS_ID")
            DT_UP.Columns.Add("PROCESS_ID")
            DT_UP.Columns.Add("STATUS_FILE")

            For Each dao_up.fields In dao_up.datas
                Dim R2 As DataRow = DT_UP.NewRow
                R2("FILE_UPLOAD_NAME") = dao_up.fields.DOCUMENT_NAME
                R2("FILE_UPLOAD_NAME_FAKE") = dao_up.fields.NAME_FAKE
                R2("FILE_UPLOAD_NAME_REAL") = dao_up.fields.NAME_REAL
                R2("STATUS_ID") = dao_up.fields.TYPE
                R2("PROCESS_ID") = dao_up.fields.PROCESS_ID
                R2("STATUS_FILE") = dao_up.fields.Status_file
                DT_UP.Rows.Add(R2)
            Next
            DT_UP.TableName = "XML_FILE_UPLOAD_STATUS"
            class_xml.DT_SHOW.DT1 = DT_UP

            Dim DT_CH As New DataTable
            Dim R3 As DataRow = DT_CH.NewRow
            Dim ID As Integer = 0
            For Each dao_up.fields In dao_up.datas
                ID = ID + 1
                DT_CH.Columns.Add("CHK_FILE_NMAE_" & ID)

                'Dim R As DataRow = DT.NewRow
                R3("CHK_FILE_NMAE_" & ID) = dao_up.fields.Status_file
            Next
            DT_CH.Rows.Add(R3)
            DT_CH.TableName = "XML_STATUS_FILE_UPLOAD_CHK"
            class_xml.DT_SHOW.DT2 = DT_CH



            Return class_xml
        End Function
    End Class
    Public Class TABEAN_SUBSTITUTE
        Inherits Center
        Public Function Gen_XML_SUBSTITUTE_TBN(ByVal IDA As Integer, ByVal FK_IDA As Integer, ByVal _IDA_LCN As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_SUB
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SUBSTITUTE
            dao.GetdatabyID_IDA(IDA)
            XML.TABEAN_SUB = dao.fields

            Dim DT As New DataTable
            Dim BAO_SP_RN As New BAO_TABEAN_HERB.tb_main
            DT = BAO_SP_RN.SP_XML_TABEAN_HERB_SUBSTITUTE(IDA)
            DT.TableName = "SP_XML_TABEAN_HERB_SUBSTITUTE"
            If dao.fields.TYPE_PERSON = 2 Then
                XML.DT_SHOW.DT1 = DT
            Else
                XML.DT_SHOW.DT2 = DT
            End If


            Return XML
        End Function

    End Class
    Public Class TABEAN_NOTIFY_EDIT
        Inherits Center
        Public Function GEN_XML_NOTIFY_EDIT(ByVal IDA As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_NOTIFY
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_NOTIFY
            dao.GetdatabyID_IDA(IDA)
            XML.TABEAN_NOTIFY_EDIT = dao.fields
            Dim dao_list As New DAO_TABEAN_HERB.TB_TABEAN_NOTIFY_LIST
            dao_list.GetdatabyID_FK_IDA(IDA)
            Dim THANM_THAIFULLNAME As String = ""
            Dim CITIZEN_ID As String = dao.fields.CITIZEN_ID_AUTHORIZE
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            Dim result As String = ""
            Try
                result = ws_center.GET_DATA_IDENTIFY(CITIZEN_ID, CITIZEN_ID, "FUSION", "P@ssw0rdfusion440")
                obj = ConvertFromXml(Of XML_DATA)(result)
                Dim TYPE_PERSON_CENTER As Integer = obj.SYSLCNSIDs.type
                If TYPE_PERSON_CENTER = 1 Then
                    THANM_THAIFULLNAME = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                ElseIf TYPE_PERSON_CENTER = 99 Then
                    THANM_THAIFULLNAME = obj.SYSLCNSNMs.prefixnm2 & obj.SYSLCNSNMs.thanm
                Else
                    If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                        THANM_THAIFULLNAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    Else
                        THANM_THAIFULLNAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    End If
                End If
            Catch ex As Exception

            End Try

            Dim DT As New DataTable
            Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            DT = BAO_SP.SP_XML_TABEAN_HERB_NOTIFY_EDIT(IDA)
            DT.TableName = "SP_XML_TABEAN_HERB_NOTIFY_EDIT"
            XML.DT_SHOW.DT1 = DT

            Dim dt_list As DataTable
            dt_list = BAO_SP.SP_XML_TABEAN_NOTIFY_LIST(IDA)
            dt_list.TableName = "SP_XML_TABEAN_NOTIFY_LIST"
            XML.DT_SHOW.DT2 = dt_list
            XML.THANM_THAIFULLNAME = THANM_THAIFULLNAME
            Try
                XML.DATE_CREATE_TH = date_to_thai(dao.fields.CREATE_DATE)
            Catch ex As Exception

            End Try
            Return XML
        End Function

    End Class
    Public Class TABEAN_RENEW
        Inherits Center
        Public Function Gen_XML_RENREW_TBN(ByVal IDA As Integer, ByVal FK_IDA As Integer, ByVal _IDA_LCN As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_RENEW
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_RENEW
            Dim Process_id As String = ""
            Dim CLS_TABEAN_RENEW As New TABEAN_RENEW
            dao.GetdatabyID_IDA(IDA)
            XML.TABEAN_RENEW = dao.fields
            Process_id = dao.fields.PROCESS_ID

            'Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
            'dao_drrgt.GetDataby_IDA(FK_IDA)
            Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
            Try
                ' dao_drrqt.GetDataby_IDA(dao_drrqt.fields.FK_DRRQT)
                dao_drrqt.GetDataby_IDA(FK_IDA)
            Catch ex As Exception

            End Try
            Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)

            Dim DT As New DataTable
            Dim BAO_SP_RN As New BAO_TABEAN_HERB.tb_main
            DT = BAO_SP_RN.SP_XML_TABEAN_RENEW_TBN(FK_IDA)
            DT.TableName = "SP_XML_TABEAN_RENEW_TBN"
            XML.DT_SHOW.DT1 = DT

            If dao.fields.STATUS_ID = 0 Then
                XML.WRITEDATE_FULL_THAI = date_to_thai(Date.Now)

            ElseIf dao.fields.STATUS_ID > 1 Then
                XML.WRITEDATE_FULL_THAI = date_to_thai(dao.fields.CREATE_DATE)
            Else
                XML.WRITEDATE_FULL_THAI = date_to_thai(Date.Now)
            End If

            Dim dt_lcn As New DataTable
            Dim dt_lcn_location As New DataTable

            dao_tabean_herb.GetdatabyID_FK_IDA_DQ(FK_IDA)
            Dim IDENTIFY As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            If dao_drrqt.fields.CITIZEN_ID_AUTHORIZE = "" Then
                IDENTIFY = dao_drrqt.fields.IDENTIFY
            Else
                IDENTIFY = dao_drrqt.fields.CITIZEN_ID_AUTHORIZE
            End If

            dao_cpn.GetDataby_identify(IDENTIFY)
            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

            Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Try
                dao_esub.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try

            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(IDENTIFY, IDENTIFY, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Dim THANM_CENTER As String = ""
            Dim TYPE_PERSON_CENTER As Integer = obj.SYSLCNSIDs.type
            If TYPE_PERSON_CENTER = 1 Then
                THANM_CENTER = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            ElseIf TYPE_PERSON_CENTER = 99 Then
                THANM_CENTER = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    THANM_CENTER = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    THANM_CENTER = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                End If
            End If

            Dim THANM As String = dao_lcn.fields.thanm
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Dim citizen_bsn As String = tb_location.fields.BSN_IDENTIFY
            Dim dao_cpn2 As New DAO_CPN.clsDBsyslcnsid
            ' dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)
            dao_cpn2.GetDataby_identify(IDENTIFY)
            Dim dao_who As New DAO_WHO.TB_WHO_DALCN
            dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
            Dim WHO_NAME As String = ""
            WHO_NAME = dao_who.fields.THANM_NAME
            Try
                dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
                Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
                Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
                If dao_drrqt.fields.WHO_ID = True Then
                    BSN_THAIFULLNAME = THANM_CENTER
                Else
                    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME
                End If
            Catch ex As Exception

            End Try

            Dim bao As New BAO.ClsDBSqlcommand
            Dim person_age As String = ""
            Dim NATIONALITY_PERSON As String = ""
            Try
                person_age = dao_tabean_herb.fields.PERSON_AGE
                If dao_tabean_herb.fields.NATIONALITY_PERSON_ID = 1 Then
                    NATIONALITY_PERSON = dao_tabean_herb.fields.NATIONALITY_PERSON
                Else
                    NATIONALITY_PERSON = dao_tabean_herb.fields.NATIONALITY_PERSON_OTHER
                End If
            Catch ex As Exception

            End Try
            Dim TYPE_PERSON_WHO As Integer = dao_cpn2.fields.type
            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION


            Dim CITIZEN_ID_AUTHORIZE As String = IDENTIFY
            Dim NAME As String = dao_drrqt.fields.CREATE_BY
            Dim THANAMEPLACE As String = dao_lcn.fields.thanameplace
            Dim dt_lcn2 As New DataTable


            Dim DT_WHO As New DataTable
            Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            DT_WHO = BAO_SP.SP_XML_WHO_DALCN(_IDA)

            If TYPE_PERSON = 1 Then
                If dao_drrqt.fields.WHO_ID = True Then
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                    dt_lcn2 = bao.SP_Lisense_Name_and_Addr(IDENTIFY) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")


                    For Each dr As DataRow In dt_lcn.Rows
                        For Each dr2 As DataRow In dt_lcn2.Rows
                            Try
                                dr("thanm") = dr2("tha_fullname")
                                XML.BSN_THAINAME = dr2("tha_fullname")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaaddr") = dr2("thaaddr")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID") = dr2("identify")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thamu") = dr2("mu")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tharoad") = dr2("tharoad")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thabuilding") = dr2("thabuilding")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thasoi") = dr2("thasoi")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thathmblnm") = dr2("thathmblnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaamphrnm") = dr2("thaamphrnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thachngwtnm") = dr2("thachngwtnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("zipcode") = dr2("zipcode")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NAME") = NAME
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tel") = dr2("tel")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("fax") = dr2("fax")
                            Catch ex As Exception

                            End Try
                        Next
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        'Try
                        '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                        '        If dr("Mobile") = Nothing Then
                        '            dr("tel") = "-"
                        '        Else
                        '            dr("tel") = dr("Mobile")
                        '        End If
                        '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                        '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                        '    End If
                        'Catch ex As Exception

                        'End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        'Try
                        '    dr("CITIZEN_ID") = citizen_bsn
                        'Catch ex As Exception

                        'End Try
                        'Try
                        '    dr("NAME_JJ") = BSN_THAIFULLNAME
                        'Catch ex As Exception

                        'End Try
                        'Try
                        '    dr("THANM") = THANM
                        'Catch ex As Exception

                        'End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next

                Else
                    'XML.TYPE_PERSON_1 = TYPE_PERSON
                    '    XML.BSN_THAINAME = THANM
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_PERSON_1"
                XML.DT_SHOW.DT2 = dt_lcn
            ElseIf TYPE_PERSON = 99 Then
                'XML.TYPE_PERSON_99 = TYPE_PERSON
                If dao_drrqt.fields.WHO_ID = True Then
                    If TYPE_PERSON_WHO = 1 Then
                        'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
                        'XML.TYPE_PERSON_99 = TYPE_PERSON
                        XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
                        dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_who.fields.FK_LCT)

                        dt_lcn.Columns.Add("NATION")
                        dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                        'dt_lcn.Columns.Add("CITIZEN_ID")
                        'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                        dt_lcn.Columns.Add("NAME")
                        dt_lcn.Columns.Add("THANM")
                        dt_lcn.Columns.Add("THANAMEPLACE")
                        dt_lcn.Columns.Add("PERSON_AGE")
                        dt_lcn.Columns.Add("NATIONALITY_PERSON")

                        For Each dr As DataRow In dt_lcn.Rows
                            Try
                                dr("NATION") = NATION
                            Catch ex As Exception

                            End Try
                            'Try
                            '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                            '        If dr("Mobile") = Nothing Then
                            '            dr("tel") = "-"
                            '        Else
                            '            dr("tel") = dr("Mobile")
                            '        End If
                            '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                            '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                            '    End If
                            'Catch ex As Exception

                            'End Try
                            Try
                                dr("PERSON_AGE") = dao_tabean_herb.fields.PERSON_AGE
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NATIONALITY_PERSON") = dao_tabean_herb.fields.NATIONALITY_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("TYPE_PERSON_CPN") = TYPE_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID") = citizen_bsn
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NAME") = BSN_THAIFULLNAME
                            Catch ex As Exception

                            End Try
                            Try
                                dr("THANM") = THANM
                            Catch ex As Exception

                            End Try
                            Try
                                dr("THANAMEPLACE") = THANAMEPLACE
                            Catch ex As Exception

                            End Try
                        Next
                    ElseIf TYPE_PERSON = 99 Then
                        'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
                        'XML.TYPE_PERSON_99 = TYPE_PERSON
                        XML.BSN_THAIFULLNAME = dao_tabean_herb.fields.AGENT_99
                        dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                        dt_lcn2 = bao.SP_Lisense_Name_and_Addr(IDENTIFY)

                        dt_lcn.Columns.Add("NATION")
                        dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                        dt_lcn.Columns.Add("NAME")
                        dt_lcn.Columns.Add("THANM")
                        dt_lcn.Columns.Add("THANAMEPLACE")
                        dt_lcn.Columns.Add("PERSON_AGE")
                        dt_lcn.Columns.Add("NATIONALITY_PERSON")
                        dt_lcn.Columns.Add("CITIZEN_ID")
                        dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")

                        For Each dr As DataRow In dt_lcn.Rows
                            For Each dr2 As DataRow In dt_lcn2.Rows
                                Try
                                    dr("thanm") = dr2("tha_fullname")
                                    XML.BSN_THAINAME = dao_tabean_herb.fields.AGENT_99
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaaddr") = dr2("thaaddr")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID") = dao_tabean_herb.fields.IDEN_AGENT_99
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thamu") = dr2("mu")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tharoad") = dr2("tharoad")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thabuilding") = dr2("thabuilding")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thasoi") = dr2("thasoi")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thathmblnm") = dr2("thathmblnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaamphrnm") = dr2("thaamphrnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("zipcode") = dr2("zipcode")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("NAME") = NAME
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tel") = dr2("tel")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("fax") = dr2("fax")
                                Catch ex As Exception

                                End Try
                            Next
                            Try
                                dr("NATION") = NATION
                            Catch ex As Exception

                            End Try
                            Try
                                dr("PERSON_AGE") = person_age
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("TYPE_PERSON_CPN") = TYPE_PERSON
                            Catch ex As Exception

                            End Try

                            'Try
                            '    dr("THANM") = THANM
                            'Catch ex As Exception

                            'End Try
                            Try
                                dr("THANAMEPLACE") = THANAMEPLACE
                            Catch ex As Exception

                            End Try
                        Next
                    End If
                Else
                    'XML.TYPE_PERSON_99 = TYPE_PERSON
                    XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try

                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_NITI_99"
                XML.DT_SHOW.DT3 = dt_lcn

                If dao_drrqt.fields.WHO_ID = False Then
                    If TYPE_PERSON = 1 Then
                        XML.BSN_THAINAME = THANM
                    ElseIf TYPE_PERSON = 99 Then
                        XML.BSN_THAINAME = BSN_THAIFULLNAME
                    End If
                End If

                If dao_lcn.fields.PROCESS_ID = 121 Then
                    Dim dao_lcn_HPI As New DAO_DRUG.ClsDBdalcn
                    dao_lcn_HPI.GetDataby_IDA_and_PROCESS_ID(_IDA_LCN, 121)

                    Dim dao_lcn_bsn_HPI As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                    dao_lcn_bsn_HPI.GetDataby_LCN_IDA(_IDA_LCN)

                    Dim dao_cpn_HPI As New DAO_CPN.clsDBsyslcnsid
                    Try

                        dao_cpn_HPI.GetDataby_identify(dao_lcn_HPI.fields.CITIZEN_ID_AUTHORIZE)

                    Catch ex As Exception

                    End Try

                    Dim TYPE_PERSON_HPI As Integer = dao_cpn_HPI.fields.type
                    Dim LCNNO_DISPLAY_NEW_HPI As String = dao_lcn_HPI.fields.LCNNO_DISPLAY_NEW
                    Dim THANM_HPI As String = dao_lcn_HPI.fields.thanm
                    Dim BSN_THAIFULLNAME_HPI As String = dao_lcn_bsn_HPI.fields.BSN_THAIFULLNAME

                    dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPI.fields.FK_IDA)

                    dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPI")
                    dt_lcn_location.Columns.Add("THANM_HPI")
                    dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPI")

                    For Each dr As DataRow In dt_lcn_location.Rows
                        Try
                            dr("LCNNO_DISPLAY_NEW_HPI") = LCNNO_DISPLAY_NEW_HPI
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM_HPI") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            If TYPE_PERSON_HPI = 1 Then
                                dr("BSN_THAIFULLNAME_HPI") = "-"
                            Else
                                dr("BSN_THAIFULLNAME_HPI") = BSN_THAIFULLNAME_HPI

                            End If
                        Catch ex As Exception

                        End Try

                    Next
                    dt_lcn_location.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_HPI"
                    XML.DT_SHOW.DT4 = dt_lcn_location
                ElseIf dao_lcn.fields.PROCESS_ID = 122 Then
                    Dim dao_lcn_HPM As New DAO_DRUG.ClsDBdalcn
                    dao_lcn_HPM.GetDataby_IDA_and_PROCESS_ID(_IDA_LCN, 122)

                    Dim dao_lcn_bsn_HPM As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                    dao_lcn_bsn_HPM.GetDataby_LCN_IDA(_IDA_LCN)

                    Dim dao_cpn_HPM As New DAO_CPN.clsDBsyslcnsid
                    Try

                        dao_cpn_HPM.GetDataby_identify(dao_lcn_HPM.fields.CITIZEN_ID_AUTHORIZE)

                    Catch ex As Exception

                    End Try
                    Dim TYPE_PERSON_HPM As Integer = dao_cpn_HPM.fields.type
                    Dim LCNNO_DISPLAY_NEW_HPM As String = dao_lcn_HPM.fields.LCNNO_DISPLAY_NEW
                    Dim THANM_HPM As String = dao_lcn_HPM.fields.thanm
                    Dim BSN_THAIFULLNAME_HPM As String = dao_lcn_bsn_HPM.fields.BSN_THAIFULLNAME

                    dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPM.fields.FK_IDA)

                    dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPM")
                    dt_lcn_location.Columns.Add("THANM_HPM")
                    dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPM")
                    dt_lcn_location.Columns.Add("TREATMENT_AGE_FULL")

                    For Each dr As DataRow In dt_lcn_location.Rows
                        Try
                            dr("LCNNO_DISPLAY_NEW_HPM") = LCNNO_DISPLAY_NEW_HPM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM_HPM") = THANM
                        Catch ex As Exception

                        End Try
                        If TYPE_PERSON_HPM = 1 Then
                            dr("BSN_THAIFULLNAME_HPM") = "-"
                        Else
                            dr("BSN_THAIFULLNAME_HPM") = BSN_THAIFULLNAME_HPM

                        End If
                    Next

                    dt_lcn_location.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_HPM"
                    XML.DT_SHOW.DT5 = dt_lcn_location
                End If

                Dim bao_sp2 As New BAO.ClsDBSqlcommand
                XML.DT_SHOW.DT6 = bao_sp2.SP_DRRQT_PRODUCER_IN_BY_FK_IDA_V2(FK_IDA)
                XML.DT_SHOW.DT6.TableName = "SP_DRRQT_PRODUCER_IN_BY_FK_IDA_V2"
                Try
                    If dao_tabean_herb.fields.NATIONALITY_PERSON_ID = 1 Then
                        XML.NATIONALITY_PERSON = dao_tabean_herb.fields.NATIONALITY_PERSON
                    Else
                        XML.NATIONALITY_PERSON = dao_tabean_herb.fields.NATIONALITY_PERSON_OTHER
                    End If
                Catch ex As Exception

                End Try

                If TYPE_PERSON = 1 Then
                    XML.THANM_THAIFULLNAME = THANM
                ElseIf TYPE_PERSON = 99 Then
                    XML.THANM_THAIFULLNAME = BSN_THAIFULLNAME
                End If
            End If
            Return XML
        End Function

        Public Function Gen_XML_RENREW_JJ(ByVal IDA As Integer, ByVal FK_IDA As Integer, ByVal _IDA_LCN As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_RENEW
            Dim dao_RN As New DAO_TABEAN_HERB.TB_TABEAN_RENEW
            Dim Process_id As String = ""
            Dim CLS_TABEAN_RENEW As New TABEAN_RENEW
            dao_RN.GetdatabyID_IDA(IDA)
            XML.TABEAN_RENEW = dao_RN.fields
            Process_id = dao_RN.fields.PROCESS_ID

            Dim DT As New DataTable
            Dim BAO_SP_RN As New BAO_TABEAN_HERB.tb_main
            DT = BAO_SP_RN.SP_XML_TABEAN_RENEW_TBN(FK_IDA)
            DT.TableName = "SP_XML_TABEAN_RENEW_TBN"
            XML.DT_SHOW.DT1 = DT

            If dao_RN.fields.STATUS_ID = 0 Then
                XML.WRITEDATE_FULL_THAI = date_to_thai(Date.Now)

            ElseIf dao_RN.fields.STATUS_ID > 1 Then
                XML.WRITEDATE_FULL_THAI = date_to_thai(dao_RN.fields.CREATE_DATE)
            Else
                XML.WRITEDATE_FULL_THAI = date_to_thai(Date.Now)
            End If

            Dim dt_lcn As New DataTable
            Dim dt_lcn_location As New DataTable
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(FK_IDA)

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            Dim dao_cpn2 As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)
            dao_cpn2.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

            Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Try
                dao_esub.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try
            Dim THANM As String = dao_lcn.fields.thanm
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try

            Dim citizen_bsn As String = tb_location.fields.BSN_IDENTIFY
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Dim dao_who As New DAO_WHO.TB_WHO_DALCN
            dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
            Dim WHO_NAME As String = ""
            WHO_NAME = dao_who.fields.THANM_NAME
            Try
                dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
                Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
                Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
                'If dao.fields.WHO_ID = True Then
                '    BSN_THAIFULLNAME = WHO_NAME
                'Else
                '    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME
                'End If
                BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            Catch ex As Exception

            End Try

            Dim person_age As String = ""
            Dim NATIONALITY_PERSON As String = ""
            Try
                person_age = dao.fields.PERSON_AGE
                If dao.fields.NATIONALITY_PERSON_ID = 1 Then
                    NATIONALITY_PERSON = dao.fields.NATIONALITY_PERSON
                Else
                    NATIONALITY_PERSON = dao.fields.NATIONALITY_PERSON_OTHER
                End If
            Catch ex As Exception

            End Try

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim TYPE_PERSON_WHO As Integer = dao_cpn2.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            'Dim THANM As String = dao_lcn.fields.thanm

            Dim CITIZEN_ID As String = dao.fields.CITIZEN_ID
            Dim CITIZEN_ID_AUTHORIZE As String = dao.fields.CITIZEN_ID_AUTHORIZE
            Dim NAME_JJ As String = dao.fields.NAME_JJ
            Dim THANAMEPLACE As String = dao.fields.LCN_THANAMEPLACE

            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt_lcn2 As New DataTable


            Dim DT_WHO As New DataTable
            Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            DT_WHO = BAO_SP.SP_XML_WHO_DALCN(FK_IDA)
            'ข้อ 2 
            If TYPE_PERSON = 1 Then
                'XML.TYPE_PERSON_1 = TYPE_PERSON
                If dao.fields.WHO_ID = True Then
                    dt_lcn = BAO_SP.SP_XML_WHO_DALCN(FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    'dt_lcn.Columns.Add("CITIZEN_ID")
                    'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        'Try
                        '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                        '        If dr("Mobile") = Nothing Then
                        '            dr("tel") = "-"
                        '        Else
                        '            dr("tel") = dr("Mobile")
                        '        End If
                        '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                        '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                        '    End If
                        'Catch ex As Exception

                        'End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next

                Else
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_PERSON_1"
                XML.DT_SHOW.DT3 = dt_lcn
            ElseIf TYPE_PERSON = 99 Then
                'XML.TYPE_PERSON_99 = TYPE_PERSON
                If dao.fields.WHO_ID = True Then
                    If TYPE_PERSON_WHO = 1 Then
                        'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
                        dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_who.fields.FK_LCT)

                        dt_lcn.Columns.Add("NATION")
                        dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                        'dt_lcn.Columns.Add("CITIZEN_ID")
                        'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                        dt_lcn.Columns.Add("NAME_JJ")
                        dt_lcn.Columns.Add("THANM")
                        dt_lcn.Columns.Add("THANAMEPLACE")
                        dt_lcn.Columns.Add("PERSON_AGE")
                        dt_lcn.Columns.Add("NATIONALITY_PERSON")

                        For Each dr As DataRow In dt_lcn.Rows
                            Try
                                dr("NATION") = NATION
                            Catch ex As Exception

                            End Try
                            'Try
                            '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                            '        If dr("Mobile") = Nothing Then
                            '            dr("tel") = "-"
                            '        Else
                            '            dr("tel") = dr("Mobile")
                            '        End If
                            '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                            '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                            '    End If
                            'Catch ex As Exception

                            'End Try
                            Try
                                dr("PERSON_AGE") = person_age
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("TYPE_PERSON_CPN") = TYPE_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID") = citizen_bsn
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NAME_JJ") = BSN_THAIFULLNAME
                            Catch ex As Exception

                            End Try
                            Try
                                dr("THANM") = THANM
                            Catch ex As Exception

                            End Try
                            Try
                                dr("THANAMEPLACE") = THANAMEPLACE
                            Catch ex As Exception

                            End Try
                        Next
                    ElseIf TYPE_PERSON = 99 Then
                        'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
                        dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.IDA_LCT)
                        dt_lcn2 = bao.SP_Lisense_Name_and_Addr(dao.fields.CITIZEN_ID_AUTHORIZE)

                        dt_lcn.Columns.Add("NATION")
                        dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                        dt_lcn.Columns.Add("NAME_JJ")
                        dt_lcn.Columns.Add("THANM")
                        dt_lcn.Columns.Add("THANAMEPLACE")
                        dt_lcn.Columns.Add("PERSON_AGE")
                        dt_lcn.Columns.Add("NATIONALITY_PERSON")
                        dt_lcn.Columns.Add("CITIZEN_ID")
                        dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")

                        For Each dr As DataRow In dt_lcn.Rows
                            For Each dr2 As DataRow In dt_lcn2.Rows
                                Try
                                    dr("thanm") = dr2("tha_fullname")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaaddr") = dr2("thaaddr")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID") = CITIZEN_ID
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thamu") = dr2("mu")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tharoad") = dr2("tharoad")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thabuilding") = dr2("thabuilding")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thasoi") = dr2("thasoi")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thathmblnm") = dr2("thathmblnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaamphrnm") = dr2("thaamphrnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("zipcode") = dr2("zipcode")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("NAME_JJ") = NAME_JJ
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tel") = dr2("tel")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("fax") = dr2("fax")
                                Catch ex As Exception

                                End Try
                            Next
                            Try
                                dr("NATION") = NATION
                            Catch ex As Exception

                            End Try
                            Try
                                dr("PERSON_AGE") = person_age
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("TYPE_PERSON_CPN") = TYPE_PERSON
                            Catch ex As Exception

                            End Try

                            'Try
                            '    dr("THANM") = THANM
                            'Catch ex As Exception

                            'End Try
                            Try
                                dr("THANAMEPLACE") = THANAMEPLACE
                            Catch ex As Exception

                            End Try
                        Next
                    End If
                Else
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME_JJ")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME_JJ") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try

                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_NITI_99"
                XML.DT_SHOW.DT4 = dt_lcn
            End If

            If TYPE_PERSON = 1 Then
                XML.BSN_THAIFULLNAME = THANM
            ElseIf TYPE_PERSON = 99 Then
                XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
            End If
            Dim dt_jj As New DataTable
            'HEAD
            Dim bao_xml As New BAO_TABEAN_HERB.tb_xml
            dt_jj = bao_xml.SP_XML_TABEAN_JJ(FK_IDA)

            dt_jj.Columns.Add("TYPE_SUB_NAME_CHANGE")
            dt_jj.Columns.Add("PP_JJ")
            dt_jj.Columns.Add("TREATMENT_AGE_FULL")
            For Each dr As DataRow In dt_jj.Rows

                'If dr("TYPE_SUB_ID") = 1 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนไทย"
                'ElseIf dr("TYPE_SUB_ID") = 2 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                'ElseIf dr("TYPE_SUB_ID") = 3 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาพัฒนาจากสมุนไพร"
                'End If
                Try
                    If dao.fields.TREATMENT_AGE Is Nothing Or dao.fields.TREATMENT_AGE = 0 Then
                        dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    ElseIf dao.fields.TREATMENT_AGE_MONTH Is Nothing Or dao.fields.TREATMENT_AGE_MONTH = 0 Then
                        dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao.fields.TREATMENT_AGE & " " & "ปี"
                    Else
                        dr("TREATMENT_AGE_FULL") = "การเก็บรักษา " & dao.fields.STORAGE_NAME & " / อายุการเก็บรักษา " & dao.fields.TREATMENT_AGE & " " & "ปี" & " " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    End If
                    'dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE & " " & dao.fields.TREATMENT_AGE_NAME

                Catch ex As Exception
                    dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                End Try

                dr("PP_JJ") = "ตามเอกสารแนบ"

                'If dr("TYPE_SUB_ID") = 2 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                'End If

            Next
            dt_jj.TableName = "XML_TABEAN_JJ"
            XML.DT_SHOW.DT5 = dt_jj

            'XML.TABEAN_JJ = dao.fields

            Dim date_approve_day As Date
            Dim date_approve_month As Date
            Dim date_approve_year As Date
            Dim date_req_day As Date
            Dim date_req_month As Date
            Dim date_req_year As Date


            Dim dao_detail As New DAO_TABEAN_HERB.TB_TABEAN_SUBPACKAGE
            dao_detail.GetData_ByFkIDA(FK_IDA)

            For Each dao_detail.fields In dao_detail.Details
                'XML.TABEAN_SUBPACKAGE.Add(dao_detail.fields)

                Dim pk As String = ""
                pk = " primary packaging " & dao_detail.fields.PACK_FSIZE_NAME & " " & dao_detail.fields.PACK_FSIZE_VOLUME & " " & dao_detail.fields.PACK_FSIZE_UNIT_NAME & " secondary packaging " &
                    dao_detail.fields.PACK_SECSIZE_NAME & " " & dao_detail.fields.PACK_SECSIZE_VOLUME & " " & dao_detail.fields.PACK_SECSIZE_UNIT_NAME & " tertiary packaging " &
                    dao_detail.fields.PACK_THSIZE_NAME & " " & dao_detail.fields.PACK_THSSIZE_VOLUME & " " & dao_detail.fields.PACK_THSIZE_UNIT_NAME

                'XML.list_subpackage.Add(pk)
            Next

            If dao_lcn.fields.PROCESS_ID = 121 Then
                Dim dao_lcn_HPI As New DAO_DRUG.ClsDBdalcn
                dao_lcn_HPI.GetDataby_IDA_and_PROCESS_ID(_IDA_LCN, 121)

                Dim dao_lcn_bsn_HPI As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_lcn_bsn_HPI.GetDataby_LCN_IDA(_IDA_LCN)

                Dim LCNNO_DISPLAY_NEW_HPI As String = dao_lcn_HPI.fields.LCNNO_DISPLAY_NEW
                Dim THANM_HPI As String = dao_lcn_HPI.fields.thanm
                Dim BSN_THAIFULLNAME_HPI As String = dao_lcn_bsn_HPI.fields.BSN_THAIFULLNAME

                dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPI.fields.FK_IDA)

                dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPI")
                dt_lcn_location.Columns.Add("THANM_HPI")
                dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPI")

                For Each dr As DataRow In dt_lcn_location.Rows
                    Try
                        dr("LCNNO_DISPLAY_NEW_HPI") = LCNNO_DISPLAY_NEW_HPI
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_HPI") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("BSN_THAIFULLNAME_HPI") = BSN_THAIFULLNAME
                    Catch ex As Exception

                    End Try

                Next
                dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_HPI"
                XML.DT_SHOW.DT1 = dt_lcn_location
            ElseIf dao_lcn.fields.PROCESS_ID = 122 Then
                Dim dao_lcn_HPM As New DAO_DRUG.ClsDBdalcn
                dao_lcn_HPM.GetDataby_IDA_and_PROCESS_ID(_IDA_LCN, 122)

                Dim dao_lcn_bsn_HPM As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_lcn_bsn_HPM.GetDataby_LCN_IDA(_IDA_LCN)

                Dim LCNNO_DISPLAY_NEW_HPM As String = dao_lcn_HPM.fields.LCNNO_DISPLAY_NEW
                Dim THANM_HPM As String = dao_lcn_HPM.fields.thanm
                Dim BSN_THAIFULLNAME_HPM As String = dao_lcn_bsn_HPM.fields.BSN_THAIFULLNAME

                dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPM.fields.FK_IDA)

                dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPM")
                dt_lcn_location.Columns.Add("THANM_HPM")
                dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPM")

                For Each dr As DataRow In dt_lcn_location.Rows
                    Try
                        dr("LCNNO_DISPLAY_NEW_HPM") = LCNNO_DISPLAY_NEW_HPM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_HPM") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("BSN_THAIFULLNAME_HPM") = BSN_THAIFULLNAME
                    Catch ex As Exception

                    End Try

                Next

                dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_HPM"
                XML.DT_SHOW.DT2 = dt_lcn_location
            End If

            If TYPE_PERSON = 1 Then
                XML.THANM_THAIFULLNAME = THANM
            ElseIf TYPE_PERSON = 99 Then
                XML.THANM_THAIFULLNAME = BSN_THAIFULLNAME
            End If


            Return XML
        End Function
    End Class

    Public Class TABEAN_NEW_EDIT
        Inherits Center
        Public Function GEN_XML_TABEAN_NEW_EDIT(ByVal IDA As Integer, ByVal _IDA_LCN As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_EDIT
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
            Dim CLS_TABEAN_EDIT As New TABEAN_HERB_EDIT_REQUEST
            dao.GetdatabyID_IDA(IDA)
            If dao.fields.Other_commands_ID IsNot Nothing Then
                dao.fields.Other_commands_ID = 1
                If dao.fields.Other_commands_Day IsNot Nothing Then
                    dao.fields.Other_commands = dao.fields.Other_commands & " " & dao.fields.Other_commands_Day & " วัน"
                Else
                    dao.fields.Other_commands = dao.fields.Other_commands
                End If
            Else
                dao.fields.Other_commands_ID = 0
            End If
            If dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 10 Or dao.fields.STATUS_ID = 5 Or dao.fields.STATUS_ID = 15 Then
                dao.fields.STATUS_ID = 7
            End If
            'If dao.fields.Other_commands_ID IsNot Nothing Then dao.fields.Other_commands_ID = 1
            XML.TABEAN_HERB_EDIT_REQUEST = dao.fields

            Dim IDA_DQ As String = ""
            Dim dao_Q As New DAO_DRUG.ClsDBdrrqt
            Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            Dim dao_g As New DAO_DRUG.ClsDBdrrgt
            dao_g.GetDataby_IDA(dao.fields.FK_IDA)
            Try
                dao_g.GetDataby_IDA(dao.fields.FK_IDA)
                IDA_DQ = dao_g.fields.FK_DRRQT

                dao_Q.GetDataby_IDA(dao.fields.FK_DRRQT)
                dao_tn.GetdatabyID_FK_IDA_DQ(IDA_DQ)
            Catch ex As Exception

            End Try
            Dim NEWCODE As String = ""
            Dim NEWCODE_U As String = ""
            Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
            dao_d.GetdatabyID_FK_IDA(IDA)
            Dim dao_h As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
            Try
                If dao_g.fields.rgtno IsNot Nothing Then
                    dao_h.GetDataby_4Key(dao_g.fields.rgtno, dao_g.fields.rgttpcd, dao_g.fields.drgtpcd, dao_g.fields.pvncd)
                Else
                    dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
                End If
                NEWCODE = dao_h.fields.Newcode
                NEWCODE_U = dao_h.fields.Newcode_U
            Catch ex As Exception
                dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
            End Try

            Dim full_rgtno As String = ""
            If dao_Q.fields.RGTNO_NEW = "" Then
                Try
                    full_rgtno = dao_g.fields.rgttpcd & " " & Integer.Parse(Right(dao_g.fields.rgtno, 5)).ToString() & "/" & Left(dao_g.fields.rgtno, 2)
                Catch ex As Exception

                End Try

                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
                Try
                    dao_ty.GetDataby_drgtpcd(dao_g.fields.drgtpcd)
                    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
                Catch ex As Exception

                End Try
            Else
                full_rgtno = dao_Q.fields.RGTNO_NEW
            End If

            Dim citizen_id As String = ""
            If dao.fields.IDENTIFY = "" Then
                citizen_id = dao.fields.IDENTIFY
            Else
                citizen_id = dao.fields.IDENTIFY
            End If
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

            End Try
            Dim dao_c As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
            dao_c.GetdatabyID_FK_IDA(IDA)

            Dim PRODUCT_NAME_NEW As String = ""
            Dim PRODUCT_NAME_OLD As String = ""
            If dao_c.fields.NAME_PRODUCT_ID = True Then
                If dao_c.fields.SUB_NAME_ENG = True Then
                    If dao_h.fields.engdrgnm = "" Then PRODUCT_NAME_OLD = dao_g.fields.engdrgnm Else PRODUCT_NAME_OLD = dao_h.fields.engdrgnm
                    PRODUCT_NAME_OLD = "ชื่อภาษาอังกฤษ: " & PRODUCT_NAME_OLD
                End If

                If dao_c.fields.SUB_NAME_OTHER = True Then
                    If dao_tn.fields.NAME_OTHER = "" Then
                        PRODUCT_NAME_OLD = PRODUCT_NAME_OLD & vbCrLf & "ชื่อผลิตภัณฑ์ภาษาอื่น: -"
                    Else
                        PRODUCT_NAME_OLD = PRODUCT_NAME_OLD & vbCrLf & "ชื่อผลิตภัณฑ์ภาษาอื่น: " & dao_tn.fields.NAME_OTHER
                    End If
                End If
                If dao_c.fields.SUB_NAME_EXPORT = True Then
                    If dao_tn.fields.NAME_EXPORT = "" Then
                        PRODUCT_NAME_OLD = PRODUCT_NAME_OLD & vbCrLf & "ชื่อผลิตภัณฑ์เพื่อการส่งออก: -"
                    Else
                        PRODUCT_NAME_OLD = PRODUCT_NAME_OLD & vbCrLf & "ชื่อผลิตภัณฑ์เพื่อการส่งออก: " & dao_tn.fields.NAME_EXPORT
                    End If
                End If

                If dao_c.fields.SUB_NAME_ENG = True Then PRODUCT_NAME_NEW = "ชื่อภาษาอังกฤษ: " & dao_d.fields.NAME_ENG
                If dao_c.fields.SUB_NAME_OTHER = True Then PRODUCT_NAME_NEW = PRODUCT_NAME_NEW & vbCrLf & "ชื่อผลิตภัณฑ์ภาษาอื่น: " & dao_d.fields.NAME_OTHER
                If dao_c.fields.SUB_NAME_EXPORT = True Then PRODUCT_NAME_NEW = PRODUCT_NAME_NEW & vbCrLf & "ชื่อผลิตภัณฑ์เพื่อการส่งออก: " & dao_d.fields.NAME_EXPORT
                'PRODUCT_NAME_OLD = dao_g.fields.engdrgnm & ", " & dao_tn.fields.NAME_OTHER
                'PRODUCT_NAME_NEW = dao_d.fields.NAME_ENG & ", " & dao_d.fields.NAME_OTHER
            End If

            Dim NAME_LOCATION_OLD As String = ""
            Dim NAME_LOCATION_NEW As String = ""
            Dim bao_dal As New BAO_SHOW
            Dim dt_lcn2 As New DataTable
            dt_lcn2 = bao_dal.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.IDA)
            If dao_c.fields.NAME_LOCATION_ID = True Then
                For Each dr As DataRow In dt_lcn2.Rows
                    Try
                        NAME_LOCATION_NEW = dr("thanm")
                        NAME_LOCATION_OLD = dao_h.fields.thanm_locaion
                    Catch ex As Exception

                    End Try
                Next
            End If

            Dim PRODUCT_RECIPE_OLD As String = ""
            Dim PRODUCT_RECIPE_NEW As String = ""
            Dim dao_recipe As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_IOWA

            If dao_c.fields.PRODUCT_RECIPE_ID = True Then
                PRODUCT_RECIPE_NEW = "ตามเอกสารแนบท้าย"
                PRODUCT_RECIPE_OLD = "ตามเอกสารแนบท้าย"
            End If

            Dim PRODUCTION_PROCESS_OLD As String = ""
            Dim PRODUCTION_PROCESS_NEW As String = ""
            If dao_c.fields.PRODUCTION_PROCESS_ID = True Then
                If dao_tn.fields.PRODUCT_PROCESS = "" Then
                    PRODUCTION_PROCESS_OLD = "ไม่มีข้อมูล"
                Else
                    PRODUCTION_PROCESS_OLD = dao_tn.fields.PRODUCT_PROCESS
                End If

                PRODUCTION_PROCESS_NEW = dao_d.fields.PRODUCT_PROCESS
                Dim dt_process As New DataTable
                Dim dao_process As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_MANUFACTRUE
                dao_process.GetdatabyID_FK_IDA_BY_MENUFAC(IDA)
                For Each dao_process.fields In dao_process.datas
                    PRODUCTION_PROCESS_NEW = PRODUCTION_PROCESS_NEW & " " & dao_process.fields.NO_ID & ". " & dao_process.fields.MENUFAC_NAME
                Next

            End If

            Dim PROPERTIES_OLD As String = ""
            Dim PROPERTIES_NEW As String = ""
            If dao_c.fields.PROPERTIES_ID = True Then
                If dao_h.fields.indication = "" Then
                    PROPERTIES_OLD = "ไม่มีข้อมูล"
                Else
                    PROPERTIES_OLD = dao_h.fields.indication
                End If

                PROPERTIES_NEW = dao_d.fields.PROPERTIES
            End If

            Dim SIZE_USE_OLD As String = ""
            Dim SIZE_USE_NEW As String = ""
            Dim dao_c124 As New DAO_XML_DRUG_HERB.TB_XML_DRUG_CONTAIN_HERB
            Try
                dao_c124.GetDataby_Newcode(dao_h.fields.Newcode)
                NEWCODE = dao_h.fields.Newcode
                NEWCODE_U = dao_h.fields.Newcode_U
            Catch ex As Exception

            End Try
            If dao_c.fields.SIZE_USE_ID = True Then
                'If dao_tn.fields.SIZE_USE = "" Then
                '    SIZE_USE_NEW = "ไม่มีข้อมูล"
                'Else
                SIZE_USE_NEW = dao_d.fields.SIZE_USE
                'End If
                If dao_tn.fields.SIZE_USE = "" Then
                    SIZE_USE_OLD = "ไม่มีข้อมูล"
                Else
                    SIZE_USE_OLD = dao_tn.fields.SIZE_USE
                End If
                'SIZE_USE_OLD = dao_tn.fields.SIZE_USE
            End If

            Dim PREPARE_EAT_OLD As String = ""
            Dim PREPARE_EAT_NEW As String = ""
            If dao_c.fields.PREPARE_EAT_ID = True Then
                If dao_d.fields.EATTING_NAME = "" Then
                    PREPARE_EAT_OLD = "ไม่มีข้อมูล"
                Else
                    PREPARE_EAT_OLD = dao_tn.fields.EATTING_NAME
                End If
                PREPARE_EAT_NEW = dao_d.fields.EATTING_NAME
            End If

            Dim EAT_CONDITION_OLD As String = ""
            Dim EAT_CONDITION_NEW As String = ""
            If dao_c.fields.EAT_CONDITION_ID = True Then
                If dao_tn.fields.EATING_CONDITION_NAME = "" Then
                    EAT_CONDITION_OLD = "ไม่มีข้อมูล"
                Else
                    EAT_CONDITION_OLD = dao_tn.fields.EATTING_NAME
                End If
                EAT_CONDITION_NEW = dao_d.fields.EATTING_NAME
            End If

            Dim STORAGE_OLD As String = ""
            Dim STORAGE_NEW As String = ""
            If dao_c.fields.STORAGE_ID = True Then
                Try
                    If (dao_tn.fields.TREATMENT_AGE Is Nothing Or dao_tn.fields.TREATMENT_AGE = 0) And dao_tn.fields.TREATMENT_AGE_MONTH IsNot Nothing Then
                        STORAGE_OLD = dao_tn.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    ElseIf (dao_tn.fields.TREATMENT_AGE_MONTH Is Nothing Or dao_tn.fields.TREATMENT_AGE_MONTH = 0) And dao_tn.fields.TREATMENT_AGE IsNot Nothing Then
                        STORAGE_OLD = dao_tn.fields.TREATMENT_AGE & " " & "ปี"
                    ElseIf (dao_tn.fields.TREATMENT_AGE Is Nothing Or dao_tn.fields.TREATMENT_AGE = 0) And dao_tn.fields.TREATMENT_AGE_MONTH Is Nothing Then
                        STORAGE_OLD = "ไม่มีข้อมูล"
                    Else
                        STORAGE_OLD = dao_tn.fields.TREATMENT_AGE & " " & "ปี" & " " & dao_tn.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    End If

                    If (dao_d.fields.TREATMENT_AGE Is Nothing Or dao_d.fields.TREATMENT_AGE = 0) And dao_d.fields.TREATMENT_AGE_MONTH IsNot Nothing Then
                        STORAGE_NEW = dao_d.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    ElseIf (dao_d.fields.TREATMENT_AGE_MONTH Is Nothing Or dao_d.fields.TREATMENT_AGE_MONTH = 0) And dao_d.fields.TREATMENT_AGE IsNot Nothing Then
                        STORAGE_NEW = dao_d.fields.TREATMENT_AGE & " " & "ปี"
                    ElseIf (dao_d.fields.TREATMENT_AGE Is Nothing Or dao_d.fields.TREATMENT_AGE = 0) And dao_d.fields.TREATMENT_AGE_MONTH Is Nothing Then
                        STORAGE_NEW = "ไม่มีข้อมูล"
                    Else
                        STORAGE_NEW = dao_d.fields.TREATMENT_AGE & " " & "ปี" & " " & dao_d.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    End If
                    If dao_tn.fields.STORAGE_NAME = "" Then
                        STORAGE_OLD = "การเก็บรักษา: -" & vbCrLf & "อายุการเก็บรักษา: " & STORAGE_NEW
                    Else
                        STORAGE_OLD = "การเก็บรักษา: " & dao_tn.fields.STORAGE_NAME & vbCrLf & "อายุการเก็บรักษา: " & STORAGE_NEW
                    End If
                    STORAGE_NEW = "การเก็บรักษา: " & dao_d.fields.STORAGE_NAME & vbCrLf & "อายุการเก็บรักษา: " & STORAGE_NEW
                Catch ex As Exception

                End Try

            End If

            Dim CONTAINER_PACKING_OLD As String = ""
            Dim CONTAINER_PACKING_NEW As String = ""
            If dao_c.fields.CONTAINER_PACKING_ID = True Then
                CONTAINER_PACKING_NEW = dao_d.fields.SIZE_PACK
                If dao_c124.fields.SUBTITLE_SIZE_DRUG = "" Then
                    If dao_g.fields.PACKAGE_DETAIL = "" Then
                        CONTAINER_PACKING_OLD = "ไม่มีข้อมูล"
                    Else
                        CONTAINER_PACKING_OLD = dao_g.fields.PACKAGE_DETAIL
                    End If
                Else
                    CONTAINER_PACKING_OLD = dao_c124.fields.SUBTITLE_SIZE_DRUG
                End If
            End If

            Dim QUALITY_CONTROL_OLD As String = ""
            Dim QUALITY_CONTROL_NEW As String = ""
            If dao_c.fields.QUALITY_CONTROL_ID = True Then

            End If

            Dim CER_LCN_OLD As String = ""
            Dim CER_LCN_NEW As String = ""
            If dao_c.fields.CER_LCN_ID = True Then

            End If

            Dim ETIQUETQ_OLD As String = ""
            Dim ETIQUETQ_NEW As String = ""
            If dao_c.fields.ETIQUETQ_ID = True Then
                ETIQUETQ_OLD = "ฉลาก และเอกสารกำกับเดิม"
                ETIQUETQ_NEW = "ฉลาก และเอกสารกำกับกำกับใหม่"
            End If

            Dim PRODUCT_DOCUMENT_OLD As String = ""
            Dim PRODUCT_DOCUMENT_NEW As String = ""
            If dao_c.fields.PRODUCT_DOCUMENT_ID = True Then

            End If

            Dim CHANNEL_SALE_OLD As String = ""
            Dim CHANNEL_SALE_NEW As String = ""
            If dao_c.fields.CHANNEL_SALE_ID = True Then
                If dao_tn.fields.SALE_CHANNEL_NAME = "" Then
                    CHANNEL_SALE_OLD = "ไม่มีข้อมูล"
                Else
                    CHANNEL_SALE_OLD = dao_tn.fields.SALE_CHANNEL_NAME
                End If
                CHANNEL_SALE_NEW = dao_d.fields.SALE_CHANNEL_NAME
            End If
            Dim DT As New DataTable
            Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            DT = BAO_SP.SP_XML_TABEAN_EDIT_REQUEST_BY_IDA(IDA)

            DT.Columns.Add("RGTNO_DISPLAY")
            DT.Columns.Add("THANM")
            DT.Columns.Add("THANM_THAIFULLNAME")
            DT.Columns.Add("BSN_THAIFULLNAME")

            DT.Columns.Add("DOCUMENT_NAME_OLD")  'เอกสารกำกับ
            DT.Columns.Add("DOCUMENT_NAME_NEW")

            DT.Columns.Add("PRODUCT_NAME_OLD")  'ชื่อของผลิตภัณฑ์สมุนไพร
            DT.Columns.Add("PRODUCT_NAME_NEW")

            DT.Columns.Add("NAME_LOCATION_OLD")   'ชื่อหรือที่อยู่ของสถานที่ผลิต/ นำเข้ำ
            DT.Columns.Add("NAME_LOCATION_NEW")

            DT.Columns.Add("PRODUCT_RECIPE_OLD")  'ตำรับผลิตภัณฑ์สมุนไพร 
            DT.Columns.Add("PRODUCT_RECIPE_NEW")

            DT.Columns.Add("PRODUCTION_PROCESS_OLD")  'กรรมวิธีการผลิต 
            DT.Columns.Add("PRODUCTION_PROCESS_NEW")

            DT.Columns.Add("PROPERTIES_OLD")   'ตำรับผลิตภัณฑ์สมุนไพร 
            DT.Columns.Add("PROPERTIES_NEW")

            DT.Columns.Add("SIZE_USE_OLD")   'ขนาดและวิธีการใช้
            DT.Columns.Add("SIZE_USE_NEW")

            DT.Columns.Add("PREPARE_EAT_OLD")   'วิธีเตรียมก่อนรับประทาน
            DT.Columns.Add("PREPARE_EAT_NEW")

            DT.Columns.Add("EAT_CONDITION_OLD")   'เงื่อนไขการรับประทาน
            DT.Columns.Add("EAT_CONDITION_NEW")

            DT.Columns.Add("STORAGE_OLD")  'การเก็บรักษา
            DT.Columns.Add("STORAGE_NEW")

            DT.Columns.Add("CONTAINER_PACKING_OLD")  'ภาชนะและขนาดบรรจุ 
            DT.Columns.Add("CONTAINER_PACKING_NEW")

            DT.Columns.Add("QUALITY_CONTROL_OLD")  'วิธีควบคุมคุณภาพ
            DT.Columns.Add("QUALITY_CONTROL_NEW")

            DT.Columns.Add("ETIQUETQ_OLD")  'ฉลาก
            DT.Columns.Add("ETIQUETQ_NEW")

            'DT.Columns.Add("PRODUCT_DOCUMENT_OLD")   'ฉลาก
            'DT.Columns.Add("PRODUCT_DOCUMENT_NEW")

            DT.Columns.Add("CHANNEL_SALE_OLD")  'ช่องทางการขาย
            DT.Columns.Add("CHANNEL_SALE_NEW")

            For Each dr As DataRow In DT.Rows
                Try
                    dr("RGTNO_DISPLAY") = full_rgtno
                Catch ex As Exception

                End Try
                Try
                    dr("THANM_THAIFULLNAME") = FULLNAME_CPN(dao.fields.CITIZEN_ID_AUTHORIZE)
                Catch ex As Exception

                End Try
                Try
                    dr("BSN_THAIFULLNAME") = FULLNAME_CPN(dao_g.fields.IDENTIFY)
                Catch ex As Exception

                End Try
                Try
                    dr("PRODUCT_NAME_OLD") = PRODUCT_NAME_OLD  'ชื่อของผลิตภัณฑ์สมุนไพร
                    dr("PRODUCT_NAME_NEW") = PRODUCT_NAME_NEW

                    dr("NAME_LOCATION_OLD") = NAME_LOCATION_OLD  'ชื่อหรือที่อยู่ของสถานที่ผลิต/ นำเข้ำ
                    dr("NAME_LOCATION_NEW") = NAME_LOCATION_NEW

                    dr("PRODUCT_RECIPE_OLD") = PRODUCT_RECIPE_OLD  'ตำรับผลิตภัณฑ์สมุนไพร 
                    dr("PRODUCT_RECIPE_NEW") = PRODUCT_RECIPE_NEW

                    dr("PRODUCTION_PROCESS_OLD") = PRODUCTION_PROCESS_OLD  'กรรมวิธีการผลิต 
                    dr("PRODUCTION_PROCESS_NEW") = PRODUCTION_PROCESS_NEW

                    dr("PROPERTIES_OLD") = PROPERTIES_OLD 'ตำรับผลิตภัณฑ์สมุนไพร 
                    dr("PROPERTIES_NEW") = PROPERTIES_NEW

                    dr("SIZE_USE_OLD") = SIZE_USE_OLD  'ขนาดและวิธีการใช้
                    dr("SIZE_USE_NEW") = SIZE_USE_NEW

                    dr("PREPARE_EAT_OLD") = PREPARE_EAT_OLD 'วิธีเตรียมก่อนรับประทาน
                    dr("PREPARE_EAT_NEW") = PREPARE_EAT_NEW

                    dr("EAT_CONDITION_OLD") = EAT_CONDITION_OLD 'เงื่อนไขการรับประทาน
                    dr("EAT_CONDITION_NEW") = EAT_CONDITION_NEW

                    dr("STORAGE_OLD") = STORAGE_OLD 'การเก็บรักษา
                    dr("STORAGE_NEW") = STORAGE_NEW

                    dr("CONTAINER_PACKING_OLD") = CONTAINER_PACKING_OLD 'ภาชนะและขนาดบรรจุ 
                    dr("CONTAINER_PACKING_NEW") = CONTAINER_PACKING_NEW

                    dr("QUALITY_CONTROL_OLD") = QUALITY_CONTROL_OLD 'วิธีควบคุมคุณภาพ
                    dr("QUALITY_CONTROL_NEW") = QUALITY_CONTROL_NEW

                    dr("ETIQUETQ_OLD") = ETIQUETQ_OLD 'ฉลาก
                    dr("ETIQUETQ_NEW") = ETIQUETQ_NEW

                    dr("CHANNEL_SALE_OLD") = CHANNEL_SALE_OLD 'ช่องทางการขาย
                    dr("CHANNEL_SALE_NEW") = CHANNEL_SALE_NEW
                Catch ex As Exception

                End Try


            Next

            DT.TableName = "XML_TABEAN_EDIT_REQUEST"
            XML.DT_SHOW.DT2 = DT
            Dim space_1 As String = " "
            Dim dt_formula As DataTable
            Dim bao_master_2 As New BAO.ClsDBSqlcommand
            dt_formula = bao_master_2.SP_XML_TABEAN_EDIT_FORMULA(dao.fields.IDA)
            dt_formula.Columns.Add("qtytxt_all2")
            For Each dr As DataRow In dt_formula.Rows
                If IsDBNull(dr("qtytxt_all")) = True Then
                    dr("qtytxt_all") = "-"
                End If
                'If dr("qtytxt_all2") = "" Then dr("qtytxt_all2") = " " Else dr("qtytxt_all2") = dr("qtytxt_all")
                If IsDBNull(dr("aori")) = True Then
                    dr("aori") = "-"
                End If
                If IsDBNull(dr("REMARK")) = True Then
                    dr("REMARK") = "-"
                End If
            Next
            dt_formula.TableName = "XML_TABEAN_EDIT_FORMULA"
            If dao_c.fields.PRODUCT_RECIPE_ID = True Then
                XML.DT_SHOW.DT6 = dt_formula
            End If


            Dim DT_CHK As New DataTable
            DT_CHK = BAO_SP.SP_XML_TABEAN_EDIT_REQUEST_CHK_LIST(IDA)
            DT_CHK.TableName = "XML_TABEAN_EDIT_CHK_LIST"
            XML.DT_SHOW.DT3 = DT_CHK

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim dt_lcn As New DataTable

            dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            dt_lcn.TableName = "XML_TABEAN_EDIT_LOCATION_ADDRESS"
            XML.DT_SHOW.DT1 = dt_lcn

            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn.GetDataby_LCN_IDA(dao_lcn.fields.IDA)
            Try
                XML.BSN_THAINAME = dao_bsn.fields.BSN_THAIFULLNAME
                'XML.WRITEDATE_FULL_THAI = date_to_thai(dao.fields.WRITE_DATE)
                'If dao.fields.DATE_PAY Is Nothing Then
                XML.RCVDATE_FULL_THAI = date_to_thai(dao.fields.DATE_CONFIRM)
                'Else
                '    XML.RCVDATE_FULL_THAI = date_to_thai(dao.fields.DATE_PAY)
                'End If
                XML.APPDATE_FULL_THAI = date_to_thai(dao.fields.appdate)
            Catch ex As Exception

            End Try
            Return XML
        End Function
        Public Function GEN_XML_TABEAN_NEW_EDIT2(ByVal IDA As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_EDIT
            Dim rcvno_format As String = ""
            Dim LCNNO_FORMAT As String = ""
            Dim TABEAN_FORMAT As String = ""
            Dim drug_name As String = ""
            Dim rgtno_format As String = ""
            Dim rcvno_auto As String = ""
            Dim rgtno As String = ""
            Dim rgtno_auto As String = ""
            Dim rgttpcd As String = ""
            Dim aa As String = ""
            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            Dim CLS_TABEAN_EDIT As New DRRGT_EDIT_REQUEST
            dao.GetDatabyIDA(IDA)
            XML.DRRGT_EDIT_REQUESTs = dao.fields
            Dim dao_gt As New DAO_DRUG.ClsDBdrrgt
            dao_gt.GetDataby_IDA(dao.fields.FK_IDA)
            Dim dao_sc As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
            dao_sc.GetDataby_4Key(dao_gt.fields.rgtno, dao_gt.fields.rgttpcd, dao_gt.fields.drgtpcd, dao_gt.fields.pvncd)
            Dim dao_lcn_e As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao_gt.fields.drgtpcd)
            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            Try
                dao_lcn_e.GetDataby_u1(dao_sc.fields.Newcode_not)
            Catch ex As Exception

            End Try
            Try
                rcvno_auto = dao.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                rgttpcd = dao_sc.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                rgtno = dao_sc.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                rgtno_auto = rgtno
            Catch ex As Exception

            End Try
            Try
                drug_name = dao_sc.fields.thadrgnm & " / " & dao_sc.fields.engdrgnm
            Catch ex As Exception

            End Try
            Try
                If Len(rcvno_auto) > 0 Then
                    rcvno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
                End If
            Catch ex As Exception

            End Try
            Try
                LCNNO_FORMAT = dao_lcn_e.fields.lcntpcd & " " & CStr(CInt(Right(dao_lcn_e.fields.lcnno, 5))) & "/" & Left(dao_lcn_e.fields.lcnno, 2)
            Catch ex As Exception

            End Try
            Try
                If Len(rgtno_auto) > 0 Then
                    rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
                End If
            Catch ex As Exception

            End Try
            XML.DRUG_NAME = drug_name
            XML.RCVNO_FORMAT = rcvno_format
            XML.RGTNO_FORMAT = rgtno_format

            Return XML
        End Function
    End Class
    Public Class TABEAN_ANALYZE
        Inherits Center
        Public Function Gen_XML_ANALYZE(ByVal IDA As Integer, ByVal _IDA_LCN As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_ANALYZE
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_ANALYZE
            Dim CLS_TABEAN_ANALYZE As New TABEAN_ANALYZE
            dao.GetdatabyID_IDA(IDA)
            XML.TABEAN_ANALYZE = dao.fields

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim dt_lcn As New DataTable

            dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            dt_lcn.TableName = "XML_TABEAN_ANALYZE_LOCATION_ADDRESS"
            XML.DT_SHOW.DT1 = dt_lcn

            Try
                XML.WRITEDATE_FULL_THAI = date_to_thai(dao.fields.WRITE_DATE)
                XML.RCVDATE_FULL_THAI = date_to_thai(dao.fields.rcvdate)
                XML.APPDATE_FULL_THAI = date_to_thai(dao.fields.appdate)
            Catch ex As Exception

            End Try
            Return XML
        End Function
    End Class
    Public Class TABEAN_DONATE
        Inherits Center
        Public Function Gen_XML_DONATE(ByVal IDA As Integer, ByVal _IDA_LCN As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_DONATE
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_DONATE
            Dim CLS_TABEAN_DONATE As New TABEAN_DONATE
            dao.GetdatabyID_IDA(IDA)
            XML.TABEAN_DONATE = dao.fields

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim dt_lcn As New DataTable

            dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            dt_lcn.TableName = "XML_TABEAN_DONATE_LOCATION_ADDRESS"
            XML.DT_SHOW.DT1 = dt_lcn

            Try
                XML.WRITEDATE_FULL_THAI = date_to_thai(dao.fields.WRITE_DATE)
                XML.DONATEDATE_FULL_THAI = date_to_thai(dao.fields.DONATE_DATE_START) & " - " & date_to_thai(dao.fields.DONATE_DATE_END)
                XML.RCVDATE_FULL_THAI = date_to_thai(dao.fields.rcvdate)
                XML.APPDATE_FULL_THAI = date_to_thai(dao.fields.appdate)

            Catch ex As Exception

            End Try
            Return XML
        End Function
    End Class
    Public Class TABEAN_EXHIBITION
        Inherits Center
        Public Function Gen_XML_EXHIBITION(ByVal IDA As Integer, ByVal _IDA_LCN As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_EXHIBITION
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION
            Dim CLS_TABEAN_EXHIBITION As New TABEAN_EXHIBITION
            dao.GetdatabyID_IDA(IDA)
            If dao.fields.LCN_THANAMEPLACE Is Nothing Or dao.fields.LCN_THANAMEPLACE = "" Then
                dao.fields.LCN_THANAMEPLACE = "-"
            End If
            Dim dao_s As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION_PACKING_SIZE
            dao_s.GetdatabyID_FK_IDA(IDA)
            'dao.fields.appdate_StaffName = dao.fields.Position_Name_App & " " & dao.fields.appdate_StaffName
            XML.TABEAN_EXHIBITION = dao.fields
            XML.TABEAN_EXHIBITION_SIZEPACK = dao_s.fields

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim dt_lcn As New DataTable
            Dim dt_cpn As New DataTable
            Dim bao_show As New BAO_SHOW
            Dim bao As New BAO.ClsDBSqlcommand
            If dao_lcn.fields.IDA <> 0 Then
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                dt_lcn.TableName = "XML_TABEAN_EXHIBITION_LOCATION_ADDRESS"
                XML.DT_SHOW.DT1 = dt_lcn
            Else
                dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(0)
                dt_cpn = bao.SP_Lisense_Name_and_Addr(dao.fields.CITIZEN_ID_AUTHORIZE)
                'dt_lcn.Columns.Add("thaaddr")
                'dt_lcn.Columns.Add("thamu")
                'dt_lcn.Columns.Add("thasoi")
                'dt_lcn.Columns.Add("tharoad")
                'dt_lcn.Columns.Add("zipcode")
                'dt_lcn.Columns.Add("tel")
                'dt_lcn.Columns.Add("HOUSENO")
                'dt_lcn.Columns.Add("thanameplace")
                'dt_lcn.Columns.Add("thaamphrnm")
                'dt_lcn.Columns.Add("thathmblnm")
                'dt_lcn.Columns.Add("thachngwtnm")
                'dt_lcn.Columns.Add("thanm")
                For Each dr As DataRow In dt_lcn.Rows
                    For Each dr2 As DataRow In dt_cpn.Rows
                        Try
                            If dr2("mu") IsNot Nothing Then
                                dr("thamu") = "-"
                            Else
                                dr("thamu") = dr2("mu")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("thaamphrnm") = dr2("amphrnm")
                        Catch ex As Exception

                        End Try
                        Try
                            dr("thathmblnm") = dr2("thmblnm")
                        Catch ex As Exception

                        End Try
                        Try
                            dr("thachngwtnm") = dr2("chngwtnm")
                        Catch ex As Exception

                        End Try
                        Try
                            If dr2("tel") IsNot Nothing Then
                                dr("tel") = dr2("tel")
                            Else
                                dr("tel") = "-"
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            If dr2("zipcode") IsNot Nothing Then
                                dr("zipcode") = dr2("zipcode")
                            Else
                                dr("zipcode") = "-"
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            'dr("HOUSENO") = dr2("HOUSENO")
                        Catch ex As Exception

                        End Try
                        Try
                            If dr2("thaaddr") Is Nothing Then
                                dr("thaaddr") = "-"
                            Else
                                dr("thaaddr") = dr2("thaaddr")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            If dr2("thasoi") Is Nothing Then
                                dr("thasoi") = "-"
                            Else
                                dr("thasoi") = dr2("thasoi")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            If dr2("tharoad") = Nothing Then
                                dr("tharoad") = "-"
                            Else
                                dr("tharoad") = dr2("tharoad")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            If dr2("thanm") = Nothing Then
                                dr("thanm") = "-"
                            Else
                                dr("thanm") = dr2("thanm")
                            End If
                        Catch ex As Exception

                        End Try
                    Next
                Next

                dt_lcn.TableName = "XML_TABEAN_EXHIBITION_LOCATION_ADDRESS"
                XML.DT_SHOW.DT1 = dt_lcn
            End If

            If dao.fields.EXHIBITION_NOUN_ID = 4 Then
                XML.Name_Association = dao.fields.EXHIBITION_NOUN_OTHER
            ElseIf dao.fields.EXHIBITION_NOUN_ID = 5 Then
                XML.Name_Foundation = dao.fields.EXHIBITION_NOUN_OTHER
            ElseIf dao.fields.EXHIBITION_NOUN_ID = 6 Then
                XML.Name_Country_Trade_Representative = dao.fields.EXHIBITION_NOUN_OTHER
            End If
            Try
                XML.WRITEDATE_FULL_THAI = date_to_thai(dao.fields.WRITE_DATE)
                XML.RCVDATE_FULL_THAI = date_to_thai(dao.fields.rcvdate)
                XML.APPDATE_FULL_THAI = date_to_thai(dao.fields.appdate)
            Catch ex As Exception

            End Try
            Dim dt_s As New DataTable
            Dim bao_new As New BAO_TABEAN_HERB.tb_dd
            dt_s = bao_new.SP_TABEAN_EXHIBITION_PACKING_SIZE_BY_FK_IDA(IDA)
            If dt_s.Rows.Count = 1 Then
                dt_s.TableName = "SP_TABEAN_EXHIBITION_PACKING_SIZE_BY_FK_IDA"
                XML.DT_SHOW.DT2 = dt_s
            Else
                dt_s.TableName = "SP_TABEAN_EXHIBITION_PACKING_SIZE_BY_FK_IDA"
                XML.DT_SHOW.DT3 = dt_s
            End If
            Try
                Dim start_date As String = date_to_thai(dao.fields.START_DATE)
                Dim end_date As String = date_to_thai(dao.fields.END_DATE)
                XML.EXH_DATE = start_date & " - " & end_date
            Catch ex As Exception

            End Try
            Return XML
        End Function
    End Class
    Public Class TABEAN_INFORM
        Inherits Center
        Public Function GEN_XML_INFORM(ByVal IDA As Integer, ByVal _IDA_LCN As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_INFORM
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
            Dim CLS_TABEAN_INFORM As New TABEAN_INFORM
            dao.GetdatabyID_IDA(IDA)
            XML.TABEAN_INFORM = dao.fields

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim dt_lcn As New DataTable
            Dim dt_lcn2 As New DataTable
            Dim dt_lcn_location As New DataTable

            dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            dt_lcn.TableName = "XML_TABEAN_INFROM_LOCATION_ADDRESS"
            XML.DT_SHOW.DT1 = dt_lcn

            Try
                'XML.WRITEDATE_FULL_THAI = date_to_thai(dao.fields.WRITE_DATE)
                XML.RCVDATE_FULL_THAI = date_to_thai(dao.fields.rcvdate)
                XML.APPDATE_FULL_THAI = date_to_thai(dao.fields.appdate)
            Catch ex As Exception

            End Try

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

            Dim SP_Tabean As New BAO_TABEAN_HERB.tb_main
            Dim dt_cas As New DataTable
            dt_cas = SP_Tabean.SP_TABEAN_JR_CAS(IDA)
            dt_cas.TableName = "XML_TABEAN_JR_DETAIL_CAS"
            XML.DT_SHOW.DT2 = dt_cas

            Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
            dao_d.GetdatabyID_FK_IDA(IDA)
            Dim dt_detail As New DataTable
            dt_detail = SP_Tabean.SP_XML_TABEAN_JR_DETAIL(IDA)
            dt_detail.TableName = "XML_TABEAN_JR_DETAIL"
            XML.DT_SHOW.DT3 = dt_detail

            Dim DT_WHO As New DataTable
            Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            DT_WHO = BAO_SP.SP_XML_WHO_DALCN(_IDA)

            Dim CITIZEN_ID As String = dao.fields.CITIZEN_ID_AUTHORIZE
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(CITIZEN_ID, CITIZEN_ID, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Dim THANM_CENTER As String = ""
            Dim TYPE_PERSON_CENTER As Integer = obj.SYSLCNSIDs.type
            If TYPE_PERSON_CENTER = 1 Then
                THANM_CENTER = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            ElseIf TYPE_PERSON_CENTER = 99 Or TYPE_PERSON_CENTER = 3 Then
                THANM_CENTER = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    THANM_CENTER = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    THANM_CENTER = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                End If
            End If

            Dim THANM As String = dao_lcn.fields.thanm
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                tb_location.GetDataby_LCN_IDA(_IDA_LCN)
            Catch ex As Exception

            End Try
            Dim dao_pfx As New DAO_CPN.TB_sysprefix
            Dim BSN_THAIFULLNAME As String = ""
            Dim citizen_bsn As String = tb_location.fields.BSN_IDENTIFY
            Dim dao_cpn2 As New DAO_CPN.clsDBsyslcnsid
            ' dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)
            dao_cpn2.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)
            Dim dao_who As New DAO_WHO.TB_WHO_DALCN
            dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
            Dim WHO_NAME As String = ""
            WHO_NAME = dao_who.fields.THANM_NAME
            Try
                dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
                Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
                Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
                Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
                If dao.fields.WHO_ID = True Then
                    BSN_THAIFULLNAME = THANM_CENTER
                    'BSN_THAIFULLNAME = WHO_NAME
                Else
                    BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME
                End If
                'BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

            Catch ex As Exception

            End Try

            Dim bao As New BAO.ClsDBSqlcommand
            Dim person_age As String = ""
            Dim NATIONALITY_PERSON As String = ""
            Try
                person_age = dao_d.fields.PERSON_AGE
                If dao_d.fields.NATIONALITY_PERSON_ID = 1 Then
                    NATIONALITY_PERSON = dao_d.fields.NATIONALITY_PERSON
                Else
                    NATIONALITY_PERSON = dao_d.fields.NATIONALITY_PERSON_OTHER
                End If
            Catch ex As Exception

            End Try

            'Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim TYPE_PERSON_WHO As Integer = dao_cpn2.fields.type
            '  Dim NATION As String = dao_lcn.fields.NATION
            Dim TYPE_PERSON As Integer = DAO_CPN.fields.type
            Dim NATION As String = dao_lcn.fields.NATION


            Dim CITIZEN_ID_AUTHORIZE As String = dao.fields.CITIZEN_ID_AUTHORIZE
            Dim NAME As String = dao.fields.CREATE_BY
            Dim THANAMEPLACE As String = dao_lcn.fields.thanameplace

            If TYPE_PERSON = 1 Then
                'XML.TYPE_PERSON_1 = TYPE_PERSON
                '    XML.BSN_THAINAME = THANM
                'XML.TYPE_PERSON_1 = TYPE_PERSON
                If dao.fields.WHO_ID = True Then
                    '        dt_lcn2 = BAO_SP.SP_XML_WHO_DALCN(dao_drrqt.fields.IDA)
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                    dt_lcn2 = bao.SP_Lisense_Name_and_Addr(dao.fields.CITIZEN_ID_AUTHORIZE) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")


                    For Each dr As DataRow In dt_lcn.Rows
                        For Each dr2 As DataRow In dt_lcn2.Rows
                            Try
                                dr("thanm") = dr2("tha_fullname")
                                XML.BSN_THAINAME = dr2("tha_fullname")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaaddr") = dr2("thaaddr")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID") = dr2("identify")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thamu") = dr2("mu")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tharoad") = dr2("tharoad")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thabuilding") = dr2("thabuilding")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thasoi") = dr2("thasoi")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thathmblnm") = dr2("thathmblnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thaamphrnm") = dr2("thaamphrnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("thachngwtnm") = dr2("thachngwtnm")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("zipcode") = dr2("zipcode")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NAME") = NAME
                            Catch ex As Exception

                            End Try
                            Try
                                dr("tel") = dr2("tel")
                            Catch ex As Exception

                            End Try
                            Try
                                dr("fax") = dr2("fax")
                            Catch ex As Exception

                            End Try
                        Next
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        'Try
                        '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                        '        If dr("Mobile") = Nothing Then
                        '            dr("tel") = "-"
                        '        Else
                        '            dr("tel") = dr("Mobile")
                        '        End If
                        '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                        '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                        '    End If
                        'Catch ex As Exception

                        'End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        'Try
                        '    dr("CITIZEN_ID") = citizen_bsn
                        'Catch ex As Exception

                        'End Try
                        'Try
                        '    dr("NAME_JJ") = BSN_THAIFULLNAME
                        'Catch ex As Exception

                        'End Try
                        'Try
                        '    dr("THANM") = THANM
                        'Catch ex As Exception

                        'End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next

                Else
                    'XML.TYPE_PERSON_1 = TYPE_PERSON
                    '    XML.BSN_THAINAME = THANM
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try
                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_PERSON_1"
                XML.DT_SHOW.DT2 = dt_lcn
            ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                'XML.TYPE_PERSON_99 = TYPE_PERSON
                If dao.fields.WHO_ID = True Then
                    If TYPE_PERSON_WHO = 1 Then
                        'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
                        'XML.TYPE_PERSON_99 = TYPE_PERSON
                        XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
                        dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_who.fields.FK_LCT)

                        dt_lcn.Columns.Add("NATION")
                        dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                        'dt_lcn.Columns.Add("CITIZEN_ID")
                        'dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                        dt_lcn.Columns.Add("NAME")
                        dt_lcn.Columns.Add("THANM")
                        dt_lcn.Columns.Add("THANAMEPLACE")
                        dt_lcn.Columns.Add("PERSON_AGE")
                        dt_lcn.Columns.Add("NATIONALITY_PERSON")

                        For Each dr As DataRow In dt_lcn.Rows
                            Try
                                dr("NATION") = NATION
                            Catch ex As Exception

                            End Try
                            'Try
                            '    If dr("tel") = Nothing Or dr("tel") = "-" Then
                            '        If dr("Mobile") = Nothing Then
                            '            dr("tel") = "-"
                            '        Else
                            '            dr("tel") = dr("Mobile")
                            '        End If
                            '    ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                            '        dr("tel") = dr("tel") & ", " & dr("Mobile")
                            '    End If
                            'Catch ex As Exception

                            'End Try
                            Try
                                dr("PERSON_AGE") = dao_d.fields.PERSON_AGE
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NATIONALITY_PERSON") = dao_d.fields.NATIONALITY_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("TYPE_PERSON_CPN") = TYPE_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("CITIZEN_ID") = citizen_bsn
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NAME") = BSN_THAIFULLNAME
                            Catch ex As Exception

                            End Try
                            Try
                                dr("THANM") = THANM
                            Catch ex As Exception

                            End Try
                            Try
                                dr("THANAMEPLACE") = THANAMEPLACE
                            Catch ex As Exception

                            End Try
                        Next
                    ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                        'dt_lcn = BAO_SP.SP_XML_WHO_DALCN(IDA)
                        'XML.TYPE_PERSON_99 = TYPE_PERSON
                        XML.BSN_THAIFULLNAME = dao_d.fields.AGENT_99
                        dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                        dt_lcn2 = bao.SP_Lisense_Name_and_Addr(dao.fields.CITIZEN_ID_AUTHORIZE)

                        dt_lcn.Columns.Add("NATION")
                        dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                        dt_lcn.Columns.Add("NAME")
                        dt_lcn.Columns.Add("THANM")
                        dt_lcn.Columns.Add("THANAMEPLACE")
                        dt_lcn.Columns.Add("PERSON_AGE")
                        dt_lcn.Columns.Add("NATIONALITY_PERSON")
                        dt_lcn.Columns.Add("CITIZEN_ID")
                        dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")

                        For Each dr As DataRow In dt_lcn.Rows
                            For Each dr2 As DataRow In dt_lcn2.Rows
                                Try
                                    dr("thanm") = dr2("tha_fullname")
                                    XML.BSN_THAINAME = dao_d.fields.AGENT_99
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaaddr") = dr2("thaaddr")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID") = dao_d.fields.IDEN_AGENT_99
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("CITIZEN_ID_AUTHORIZE") = dr2("identify")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thamu") = dr2("mu")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tharoad") = dr2("tharoad")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thabuilding") = dr2("thabuilding")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thasoi") = dr2("thasoi")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thathmblnm") = dr2("thathmblnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thaamphrnm") = dr2("thaamphrnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("thachngwtnm_nozip") = dr2("thachngwtnm")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("zipcode") = dr2("zipcode")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("NAME") = NAME
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("tel") = dr2("tel")
                                Catch ex As Exception

                                End Try
                                Try
                                    dr("fax") = dr2("fax")
                                Catch ex As Exception

                                End Try
                            Next
                            Try
                                dr("NATION") = NATION
                            Catch ex As Exception

                            End Try
                            Try
                                dr("PERSON_AGE") = person_age
                            Catch ex As Exception

                            End Try
                            Try
                                dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                            Catch ex As Exception

                            End Try
                            Try
                                dr("TYPE_PERSON_CPN") = TYPE_PERSON
                            Catch ex As Exception

                            End Try

                            'Try
                            '    dr("THANM") = THANM
                            'Catch ex As Exception

                            'End Try
                            Try
                                dr("THANAMEPLACE") = THANAMEPLACE
                            Catch ex As Exception

                            End Try
                        Next
                    End If
                Else
                    'XML.TYPE_PERSON_99 = TYPE_PERSON
                    XML.BSN_THAIFULLNAME = BSN_THAIFULLNAME
                    dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

                    dt_lcn.Columns.Add("NATION")
                    dt_lcn.Columns.Add("TYPE_PERSON_CPN")
                    dt_lcn.Columns.Add("CITIZEN_ID")
                    dt_lcn.Columns.Add("CITIZEN_ID_AUTHORIZE")
                    dt_lcn.Columns.Add("NAME")
                    dt_lcn.Columns.Add("THANM")
                    dt_lcn.Columns.Add("THANAMEPLACE")
                    dt_lcn.Columns.Add("PERSON_AGE")
                    dt_lcn.Columns.Add("NATIONALITY_PERSON")

                    For Each dr As DataRow In dt_lcn.Rows
                        Try
                            dr("NATION") = NATION
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("tel") = Nothing Or dr("tel") = "-" Then
                                If dr("Mobile") = Nothing Then
                                    dr("tel") = "-"
                                Else
                                    dr("tel") = dr("Mobile")
                                End If
                            ElseIf dr("Mobile") IsNot Nothing And dr("tel") IsNot Nothing Or dr("tel") = "-" Then
                                dr("tel") = dr("tel") & ", " & dr("Mobile")
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            dr("PERSON_AGE") = person_age
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NATIONALITY_PERSON") = NATIONALITY_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("TYPE_PERSON_CPN") = TYPE_PERSON
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID") = citizen_bsn
                        Catch ex As Exception

                        End Try
                        Try
                            dr("CITIZEN_ID_AUTHORIZE") = CITIZEN_ID_AUTHORIZE
                        Catch ex As Exception

                        End Try
                        Try
                            dr("NAME") = BSN_THAIFULLNAME
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANM") = THANM
                        Catch ex As Exception

                        End Try
                        Try
                            dr("THANAMEPLACE") = THANAMEPLACE
                        Catch ex As Exception

                        End Try

                    Next
                End If

                dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_NITI_99"
                XML.DT_SHOW.DT5 = dt_lcn
            End If

            If dao_lcn.fields.PROCESS_ID = 121 Then
                Dim dao_lcn_HPI As New DAO_DRUG.ClsDBdalcn
                dao_lcn_HPI.GetDataby_IDA_and_PROCESS_ID(_IDA_LCN, 121)

                Dim dao_lcn_bsn_HPI As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_lcn_bsn_HPI.GetDataby_LCN_IDA(_IDA_LCN)

                Dim dao_cpn_HPI As New DAO_CPN.clsDBsyslcnsid
                Try

                    dao_cpn_HPI.GetDataby_identify(dao_lcn_HPI.fields.CITIZEN_ID_AUTHORIZE)

                Catch ex As Exception

                End Try

                Dim TYPE_PERSON_HPI As Integer = dao_cpn_HPI.fields.type
                Dim LCNNO_DISPLAY_NEW_HPI As String = dao_lcn_HPI.fields.LCNNO_DISPLAY_NEW
                Dim THANM_HPI As String = dao_lcn_HPI.fields.thanm
                Dim BSN_THAIFULLNAME_HPI As String = dao_lcn_bsn_HPI.fields.BSN_THAIFULLNAME

                dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPI.fields.FK_IDA)

                dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPI")
                dt_lcn_location.Columns.Add("THANM_HPI")
                dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPI")

                For Each dr As DataRow In dt_lcn_location.Rows
                    Try
                        dr("LCNNO_DISPLAY_NEW_HPI") = LCNNO_DISPLAY_NEW_HPI
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_HPI") = THANM
                    Catch ex As Exception

                    End Try
                    Try
                        If TYPE_PERSON_HPI = 1 Then
                            dr("BSN_THAIFULLNAME_HPI") = "-"
                        Else
                            dr("BSN_THAIFULLNAME_HPI") = BSN_THAIFULLNAME_HPI

                        End If
                    Catch ex As Exception

                    End Try

                Next
                dt_lcn_location.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_HPI"
                XML.DT_SHOW.DT7 = dt_lcn_location
            ElseIf dao_lcn.fields.PROCESS_ID = 122 Then
                Dim dao_lcn_HPM As New DAO_DRUG.ClsDBdalcn
                dao_lcn_HPM.GetDataby_IDA_and_PROCESS_ID(_IDA_LCN, 122)

                Dim dao_lcn_bsn_HPM As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_lcn_bsn_HPM.GetDataby_LCN_IDA(_IDA_LCN)

                Dim dao_cpn_HPM As New DAO_CPN.clsDBsyslcnsid
                Try

                    dao_cpn_HPM.GetDataby_identify(dao_lcn_HPM.fields.CITIZEN_ID_AUTHORIZE)

                Catch ex As Exception

                End Try
                Dim TYPE_PERSON_HPM As Integer = dao_cpn_HPM.fields.type
                Dim LCNNO_DISPLAY_NEW_HPM As String = dao_lcn_HPM.fields.LCNNO_DISPLAY_NEW
                Dim THANM_HPM As String = dao_lcn_HPM.fields.thanm
                Dim BSN_THAIFULLNAME_HPM As String = dao_lcn_bsn_HPM.fields.BSN_THAIFULLNAME

                dt_lcn_location = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn_HPM.fields.FK_IDA)

                dt_lcn_location.Columns.Add("LCNNO_DISPLAY_NEW_HPM")
                dt_lcn_location.Columns.Add("THANM_HPM")
                dt_lcn_location.Columns.Add("BSN_THAIFULLNAME_HPM")
                dt_lcn_location.Columns.Add("TREATMENT_AGE_FULL")

                For Each dr As DataRow In dt_lcn_location.Rows
                    Try
                        dr("LCNNO_DISPLAY_NEW_HPM") = LCNNO_DISPLAY_NEW_HPM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_HPM") = THANM
                    Catch ex As Exception

                    End Try
                    If TYPE_PERSON_HPM = 1 Then
                        dr("BSN_THAIFULLNAME_HPM") = "-"
                    Else
                        dr("BSN_THAIFULLNAME_HPM") = BSN_THAIFULLNAME_HPM

                    End If
                Next

                dt_lcn_location.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_HPM"
                XML.DT_SHOW.DT8 = dt_lcn_location
            End If

            If TYPE_PERSON = 1 Then
                XML.THANM_THAIFULLNAME = THANM
            ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
                XML.THANM_THAIFULLNAME = BSN_THAIFULLNAME
            End If

            Dim date_FULL As String = ""
            Try
                'date_FULL = date_to_thai(dao.fields.WRITE_DATE)
                'XML.WRITEDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.rcvdate)
                XML.RCVDATE_FULL_THAI = date_FULL

                date_FULL = date_to_thai(dao.fields.appdate)
                XML.APPDATE_FULL_THAI = date_FULL
            Catch ex As Exception

            End Try
            Dim date_rcv_day As New Date
            Dim date_rcv_month As New Date
            Dim date_rcv_year As New Date

            Dim date_app_day As Date
            Dim date_app_month As Date
            Dim date_app_year As Date

            Dim date_exp_day As Date
            Dim date_exp_month As Date
            Dim date_exp_year As Date

            Try
                date_app_day = dao.fields.appdate
                date_app_month = dao.fields.appdate
                date_app_year = dao.fields.appdate

                XML.DATE_APP_DAY = date_app_day.Day.ToString()
                XML.DATE_APP_MONTH = date_app_month.ToString("MMMM")
                XML.DATE_APP_YEAR = con_year(date_app_year.Year)

                Try
                    date_exp_day = dao.fields.expdate
                    date_exp_month = dao.fields.expdate
                    date_exp_year = dao.fields.expdate

                    Dim a As String = date_exp_day.Day.ToString() - 1
                    Dim b As String = date_exp_month.ToString("MMMM")
                    Dim c As String = con_year(date_exp_year.Year) + 5

                    XML.date_exdate_day = a
                    XML.date_exdate_month = b
                    XML.date_exdate_year = c

                    'XML.RGTNO_DATE_END = a & " " & b & " " & c
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Return XML
        End Function


    End Class
    Public Class TABEAN_INFORM_EDIT
        Inherits Center
        Public Function GEN_XML_INFORM_EDIT(ByVal IDA As Integer, ByVal _IDA_LCN As Integer)
            Dim bao_lcn As New BAO_SHOW
            Dim bao_lcn_location As New BAO_MASTER
            Dim XML As New CLASS_DR_INFORM_EDIT
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_EDIT
            dao.GetdatabyID_IDA(IDA)
            XML.TABEAN_INFORM_EDIT = dao.fields

            Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_EDIT_DETAIL
            dao_d.Getdataby_FK_IDA(IDA)
            Dim dao_c As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_EDIT_CHECK_LIST
            dao_c.Getdataby_FK_IDA(IDA)
            XML.TABEAN_INFORM_EDIT_CHECK = dao_c.fields

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim dt_lcn As New DataTable

            dt_lcn = bao_lcn.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            dt_lcn.TableName = "XML_TABEAN_EXHIBITION_LOCATION_ADDRESS"
            XML.DT_SHOW.DT1 = dt_lcn


            Dim dt_c As New DataTable
            Dim BAO_SP As New BAO_TABEAN_HERB.tb_main
            dt_c = BAO_SP.SP_XML_TABEAN_INFORM_EDIT(IDA)
            dt_c.Columns.Add("NAME_THAI_OLD")
            dt_c.Columns.Add("NAME_THAI_NEW")
            dt_c.Columns.Add("NAME_ENG_OLD")
            dt_c.Columns.Add("NAME_ENG_NEW")
            dt_c.Columns.Add("LOCATION_OLD")
            dt_c.Columns.Add("LOCATION_NEW")
            dt_c.Columns.Add("PACKING_OLD")
            dt_c.Columns.Add("PACKING_NEW")
            dt_c.Columns.Add("LABEL_OLD")
            dt_c.Columns.Add("LABEL_NEW")
            dt_c.Columns.Add("DOCUMENT_OLD")
            dt_c.Columns.Add("DOCUMENT_NEW")
            dt_c.Columns.Add("SIZEUSE_OLD")
            dt_c.Columns.Add("SIZEUSE_NEW")
            dt_c.Columns.Add("EATTING_OLD")
            dt_c.Columns.Add("EATTING_NEW")

            dt_c.Columns.Add("UPLOAD_ID1")
            dt_c.Columns.Add("UPLOAD_ID2")
            dt_c.Columns.Add("UPLOAD_ID3")
            dt_c.Columns.Add("UPLOAD_ID4")
            dt_c.Columns.Add("UPLOAD_ID5")
            dt_c.Columns.Add("UPLOAD_ID6")
            dt_c.Columns.Add("UPLOAD_ID7")
            dt_c.Columns.Add("UPLOAD7_NAME")

            Dim dao_i As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
            Dim dao_id As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            Try
                dao_i.GetdatabyID_IDA(dao.fields.FK_IDA)
                dao_id.GetdatabyID_FK_IDA(dao.fields.FK_IDA)
                dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 1)
            Catch ex As Exception

            End Try
            Try
                For Each dr As DataRow In dt_c.Rows
                    If dao_c.fields.NAME_ID = True Then
                        dr("NAME_THAI_OLD") = dao.fields.NAME_THAI
                        dr("NAME_THAI_NEW") = dao_d.fields.NAME_THAI
                        dr("NAME_ENG_OLD") = dao.fields.NAME_ENG
                        dr("NAME_ENG_NEW") = dao_d.fields.NAME_ENG
                    End If
                    If dao_c.fields.LOCATION_ID = True Then

                    End If
                    If dao_c.fields.PACKING_SIZE_ID = True Then
                        dr("PACKING_OLD") = dao_id.fields.SIZE_PACK
                        dr("PACKING_NEW") = dao_d.fields.SIZE_PACK
                    End If
                    If dao_c.fields.LABEL_ID = True Then
                        dr("LABEL_OLD") = "ฉลากเดิม"
                        dr("LABEL_NEW") = "ฉลากใหม่"
                    End If
                    If dao_c.fields.Document_ID = True Then
                        dr("DOCUMENT_OLD") = "เอกสารแนบเดิม"
                        dr("DOCUMENT_NEW") = "เอกสารแนบใหม่"
                    End If
                    If dao_c.fields.HOW_USE_ID = True Then
                        dr("HOWUSE_OLD") = dao_id.fields.SIZE_USE
                        dr("HOWUSE_NEW") = dao_d.fields.SIZE_USE
                    End If
                    If dao_c.fields.EATTING_ID = True Then
                        dr("EATTING_OLD") = dao_id.fields.EATTING_NAME
                        dr("EATTING_NEW") = dao_d.fields.EATTING_NAME
                    End If
                    Try
                        For Each dao_up.fields In dao_up.datas
                            If dao_up.fields.DOCUMENT_NAME.ToString.Contains("สาเนาใบรับแจ้งรายละเอียดผลิตภัณฑ์สมุนไพร หรือใบแทน") Then
                                If dao_up.fields.NAME_FAKE <> "" Then
                                    dr("UPLOAD_ID1") = 1
                                End If
                            End If
                            If dao_up.fields.DOCUMENT_NAME.ToString.Contains("สาเนาหนังสือเดินทาง สาเนาใบอนุญาตทางาน สาเนาถิ่นที่อยู่ในราชอาณาจักร สาเนาใบอนุญาต
ประกอบธุรกิจคนต่างด้าวของผู้ขอขึ้นทะเบียนตารับ สาหรับคนต่างด้าว (เฉพาะกรณีที่ไม่ได้แสดงตนด้วยตนเอง)") Then
                                If dao_up.fields.NAME_FAKE <> "" Then
                                    dr("UPLOAD_ID2") = 1
                                End If
                            End If
                            If dao_up.fields.DOCUMENT_NAME.ToString.Contains("เอกสารแสดงว่าเป็นผู้มีอานาจทาการแทน (กรณีมอบอานาจ) หรือเป็นผู้แทนนิติบุคคลหรือผู้มี
อานาจทาการแทนนิติบุคคล (กรณีนิติบุคคลเป็นผู้ขออนุญาต)") Then
                                If dao_up.fields.NAME_FAKE <> "" Then
                                    dr("UPLOAD_ID3") = 1
                                End If
                            End If
                            If dao_up.fields.DOCUMENT_NAME.ToString.Contains("เอกสารสนับสนุนการขอแก้ไขเปลี่ยนแปลง แล้วแต่กรณี") Then
                                If dao_up.fields.NAME_FAKE <> "" Then
                                    dr("UPLOAD_ID4") = 1
                                End If
                            End If
                            If dao_up.fields.DOCUMENT_NAME.ToString.Contains("รายละเอียดการแก้ไขเปลี่ยนแปลง") Then
                                If dao_up.fields.NAME_FAKE <> "" Then
                                    dr("UPLOAD_ID5") = 1
                                End If
                            End If
                            If dao_up.fields.DOCUMENT_NAME.ToString.Contains("หนังสือให้ความยินยอมตามที่สานักงานคณะกรรมการอาหารและยากาหนด") Then
                                If dao_up.fields.NAME_FAKE <> "" Then
                                    dr("UPLOAD_ID6") = 1
                                End If
                            End If
                            If dao_up.fields.DOCUMENT_NAME.ToString.Contains("อื่น ๆ") Then
                                If dao_up.fields.NAME_FAKE <> "" Then
                                    dr("UPLOAD_ID7") = 1
                                    dr("UPLOAD7_NAME") = dao_up.fields.NAME_REAL
                                End If
                            End If
                        Next
                    Catch ex As Exception

                    End Try
                Next

            Catch ex As Exception

            End Try
            dt_c.TableName = "XML_TABEAN_INFORM_EDIT_DETAIL"
            XML.DT_SHOW.DT2 = dt_c
            Try
                'XML.WRITEDATE_FULL_THAI = date_to_thai(dao.fields.WRITE_DATE)
                XML.RCVDATE_FULL_THAI = date_to_thai(dao.fields.RCVDATE)
                XML.APPDATE_FULL_THAI = date_to_thai(dao.fields.appdate)
            Catch ex As Exception

            End Try
            Return XML
        End Function
    End Class
End Namespace
