Imports System.IO
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



            XML.DT_SHOW.DT1 = dt1
            XML.DT_SHOW.DT2 = dt2

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
            Dim dt_lcn_location As New DataTable
            Dim dt_jj As New DataTable

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
                        dr("TYPE_PERSON_CPN") = TYPE_PERSON
                    Catch ex As Exception

                    End Try
                    Try
                        dr("CITIZEN_ID") = CITIZEN_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dr("NAME_JJ") = NAME_JJ
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
                dt_lcn.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_PERSON_1"
                XML.DT_SHOW.DT3 = dt_lcn
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
                        dr("NAME_JJ") = NAME_JJ
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
                        dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
                    ElseIf dao.fields.TREATMENT_AGE_MONTH Is Nothing Or dao.fields.TREATMENT_AGE_MONTH = 0 Then
                        dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE & " " & "ปี"
                    Else
                        dr("TREATMENT_AGE_FULL") = dao.fields.STORAGE_NAME & " " & dao.fields.TREATMENT_AGE & " " & "ปี" & " " & dao.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
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
                        dr("THANM_HPI") = THANM_HPI
                    Catch ex As Exception

                    End Try
                    Try
                        dr("BSN_THAIFULLNAME_HPI") = BSN_THAIFULLNAME_HPI
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
                        dr("THANM_HPM") = THANM_HPM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("BSN_THAIFULLNAME_HPM") = BSN_THAIFULLNAME_HPM
                    Catch ex As Exception

                    End Try

                Next

                dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_HPM"
                XML.DT_SHOW.DT2 = dt_lcn_location
            End If

            'dt_lcn_location = bao_lcn_location.SP_DALCN_FRGN_DATA(IDA_LCN)
            'dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_NATIONALITY"
            'XML.DT_SHOW.DT2 = dt_lcn_location

            Return XML
        End Function

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

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            Dim THANM As String = dao_lcn.fields.thanm

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
            ElseIf dao.fields.STATUS_ID = 6 Or dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 12 Then
                date_req_day = dao.fields.DATE_REQ
                date_req_month = dao.fields.DATE_REQ
                date_req_year = dao.fields.DATE_REQ

                XML.date_req_day = date_req_day.Day.ToString()
                XML.date_req_month = date_req_month.ToString("MMMM")
                XML.date_req_year = con_year(date_req_year.Year)

                XML.date_req_full = date_req_day.Day.ToString() & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
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
                        dr("NAME_JJ") = NAME_JJ
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
                        dr("NAME_JJ") = NAME_JJ
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
            dt_lcn.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS"
            XML.DT_SHOW.DT1 = dt_lcn
            Return Xml
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

            Return Xml
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

            Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
            dao_cpn.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)

            Dim DALCN_DISPLAY As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = dao_lcn.fields.NATION
            Dim THANM As String = dao_lcn.fields.thanm

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
                dt_lcn = BAO_LCN.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

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
                dt_lcn = BAO_LCN.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

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

            Dim TYPE_PERSON As Integer = dao_cpn.fields.type
            Dim NATION As String = DAO_LCN.fields.NATION
            Dim THANM As String = DAO_LCN.fields.thanm

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

            dt = BAO.SP_XML_DRUG_DRRQT(_IDA_DQ)
            dt.Columns.Add("TYPE_SUB_NAME_CHANGE")
            dt.Columns.Add("TREATMENT_AGE_FULL")
            For Each dr As DataRow In dt.Rows

                'If dr("TYPE_SUB_ID") = 1 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนไทย"
                'ElseIf dr("TYPE_SUB_ID") = 2 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                'ElseIf dr("TYPE_SUB_ID") = 3 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาพัฒนาจากสมุนไพร"
                'End If

                Try
                    dr("TREATMENT_AGE_FULL") = dao_tabean_herb.fields.STORAGE_NAME & " " & dao_tabean_herb.fields.TREATMENT_AGE & " " & dao_tabean_herb.fields.TREATMENT_AGE_NAME
                Catch ex As Exception

                End Try

                'If dr("TYPE_SUB_ID") = 2 Then
                '    dr("TYPE_SUB_NAME_CHANGE") = "ยาแผนจีน"
                'End If
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
                dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_PERSON_1"
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
                dt_lcn.TableName = "XML_TABEAN_TBN_LOCATION_ADDRESS_NITI_99"
                XML.DT_SHOW.DT3 = dt_lcn
            End If

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
                        dr("THANM_HPI") = THANM_HPI
                    Catch ex As Exception

                    End Try
                    Try
                        dr("BSN_THAIFULLNAME_HPI") = BSN_THAIFULLNAME_HPI
                    Catch ex As Exception

                    End Try

                Next
                dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_HPI"
                XML.DT_SHOW.DT4 = dt_lcn_location
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
                dt_lcn_location.Columns.Add("TREATMENT_AGE_FULL")

                For Each dr As DataRow In dt_lcn_location.Rows
                    Try
                        dr("LCNNO_DISPLAY_NEW_HPM") = LCNNO_DISPLAY_NEW_HPM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("THANM_HPM") = THANM_HPM
                    Catch ex As Exception

                    End Try
                    Try
                        dr("BSN_THAIFULLNAME_HPM") = BSN_THAIFULLNAME_HPM
                    Catch ex As Exception

                    End Try

                Next

                dt_lcn_location.TableName = "XML_TABEAN_JJ_LOCATION_ADDRESS_HPM"
                XML.DT_SHOW.DT5 = dt_lcn_location
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

        Private _thanm As String
        Public Property thanm() As String
            Get
                Return _thanm
            End Get
            Set(ByVal value As String)
                _thanm = value
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

        Private _group_assign As String
        Public Property group_assign() As String
            Get
                Return _group_assign
            End Get
            Set(ByVal value As String)
                _group_assign = value
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
            cls.appointment_date = appointment_date

            cls.name_req = thanm
            cls.tel_req = obj.TEL
            cls.name_contact = NAME_CONTACT
            cls.tel_callback = tel_callback
            cls.email = obj.EMAIL
            cls.group_assign = group_assign

            Return cls
        End Function
    End Class

End Namespace
