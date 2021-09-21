Namespace DAO_TABEAN_HERB
    Public MustInherit Class MAINCONTEXT        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_TABEAN_HERB_JJDataContext 'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        Public datas                            'ประกาศเ

    End Class

    Public Class TB_TABEAN_JJ
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JJ

        Public Sub insert()
            db.TABEAN_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JJs Select p)

        End Sub

        Public Sub GetdatabyID_DD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer)
            datas = From p In db.TABEAN_JJs Where p.DD_HERB_NAME_ID = DD_HERB_NAME_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_LCN(ByVal IDA_LCN As Integer, ByVal DD_HERB_NAME As Integer)
            datas = From p In db.TABEAN_JJs Where p.LCN_ID = IDA_LCN And p.DD_HERB_NAME_ID = DD_HERB_NAME Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_PROCESS(ByVal IDA As Integer, ByVal DDHERB As Integer)
            datas = From p In db.TABEAN_JJs Where p.IDA = IDA And p.DDHERB = DDHERB Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_TABEAN_SUBPACKAGE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JJ_SUB_PACKSIZE

        Private _Details As New List(Of TABEAN_JJ_SUB_PACKSIZE)
        Public Property Details() As List(Of TABEAN_JJ_SUB_PACKSIZE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_JJ_SUB_PACKSIZE))
                _Details = value
            End Set
        End Property

        Public Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_JJ_SUB_PACKSIZE
        End Sub

        Public Sub insert()
            db.TABEAN_JJ_SUB_PACKSIZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JJ_SUB_PACKSIZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetData_ByIDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetData_ByDD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer)
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Where p.IDA = DD_HERB_NAME_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetData_ByFkIDA(ByVal fk_ida As Integer)
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Where p.FK_IDA = fk_ida Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class

    Public Class TB_TABEAN_HERB_UPLOAD_FILE_JJ
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_UPLOAD_FILE_JJ

        Public Sub insert()
            db.TABEAN_HERB_UPLOAD_FILE_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_UPLOAD_FILE_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TR_ID(ByVal TR_ID As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TR_ID_PROCESS_ID(ByVal TR_ID As Integer, ByVal PROCESS_ID As String)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.PROCESS_ID = PROCESS_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_TYPE(ByVal FK_IDA As Integer, ByVal TYPE As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.FK_IDA = FK_IDA And p.TYPE = TYPE Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TR_ID_PROCESS_ID_ALL(ByVal TR_ID As Integer, ByVal PROCESS_ID As String, ByVal type_id As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.PROCESS_ID = PROCESS_ID And p.TYPE = type_id Select p
        End Sub

    End Class

    Public Class TB_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_DD_HERB_NAME_PRODUCT_ID(ByVal DD_HERB_NAME_PRODUCT_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs Where p.DD_HERB_NAME_PRODUCT_ID = DD_HERB_NAME_PRODUCT_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_MAS_TABEAN_HERB_PRODUCT_AGE_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_PRODUCT_AGE_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_PRO_AGE(ByVal ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs Where p.PRO_AGE_ID = ID Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_MAS_TABEAN_HERB_NAME_DETAIL_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_NAME_DETAIL_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_NAME_DETAIL_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_NAME_DETAIL_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_NAME_DETAIL_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_NAME_DETAIL_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_DD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_NAME_DETAIL_JJs Where p.DD_HERB_NAME_ID = DD_HERB_NAME_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_UPLOADFILE_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_UPLOADFILE_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_UPLOADFILE_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_UPLOADFILE_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_UPLOADFILE_JJs Where p.ID = IDA And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TYPE(ByVal TYPE_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_UPLOADFILE_JJs Where p.TYPE_ID = TYPE_ID And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub

        '    Public Sub Getdataby_TR_ID(ByVal TR_ID As Integer)
        '        datas = From p In db.MAS_TABEAN_HERB_UPLOADFILE_JJs Where p.ID = TR_ID Select p

        '        For Each Me.fields In datas

        '        Next
        '    End Sub

    End Class

    Public Class TB_MAS_TABEAN_HERB_STATUS_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_STATUS_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_STATUS_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_STATUS_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_STATUS_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_STATUS_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdataby_STATUS_ID(ByVal S_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_STATUS_JJs Where p.STATUS_ID = S_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_TABEAN_TRANSACTION_JJ
        Inherits MAINCONTEXT

        Public fields As New TABEAN_TRANSACTION_JJ

        Public Sub insert()
            db.TABEAN_TRANSACTION_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_TRANSACTION_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_TRANSACTION_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_JJ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_TRANSACTION_JJs Where p.FK_IDA_JJ = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_GEN_NO_JJ
        Inherits MAINCONTEXT

        Public fields As New GEN_NO_JJ

        Public Sub insert()
            db.GEN_NO_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.GEN_NO_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.GEN_NO_JJs Select p)

        End Sub

        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal REF_IDA As String, ByVal IDA_LCNNO As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_JJs Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
End Namespace
