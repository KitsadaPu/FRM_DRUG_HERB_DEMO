Namespace DAO_LCN
    Public MustInherit Class MAINCONTEXT        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_LCNDataContext 'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        'Public db As New 'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        Public datas                            'ประกาศเ

    End Class

    Public Class TB_LCN_APPROVE_EDIT_UPLOAD_FILE
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_UPLOAD_FILE

        Private _Details As New List(Of LCN_APPROVE_EDIT_UPLOAD_FILE)
        Public Property Details() As List(Of LCN_APPROVE_EDIT_UPLOAD_FILE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of LCN_APPROVE_EDIT_UPLOAD_FILE))
                _Details = value
            End Set
        End Property
        Public Sub insert()
            db.LCN_APPROVE_EDIT_UPLOAD_FILEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_UPLOAD_FILEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID(ByVal PROCESS_ID As Integer, ByVal HEAD_ID As Integer, ByVal TITEL_ID1 As Integer, ByVal TITEL_ID2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.PROCESS_ID = PROCESS_ID And p.HEAD_ID = HEAD_ID And p.FK_TITEL_ID = TITEL_ID1 And p.FK_TITEL_ID2 = TITEL_ID2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_AND_TYPE_EDIT(ByVal process As Integer, ByVal TITEL_ID1 As Integer, ByVal TITEL_ID2 As Integer, ByVal type_edit As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.PROCESS_ID = process And p.FK_TITEL_ID = TITEL_ID1 And p.FK_TITEL_ID2 = TITEL_ID2 And p.TYPE = type_edit And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GET_DATA_BY_FILE_NUMBER(ByVal file_id As Integer, ByVal LCN_IDA As Integer)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.FILE_NUMBER_NAME = file_id And p.FK_IDA = LCN_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class



    Public Class TB_LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBER
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBER

        Public Sub insert()
            db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_JJ(ByVal FK_IDA As Integer)
            datas = From p In db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs Where p.FK_IDA_LCN = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_LCN_APPROVE_EDIT
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT

        Public Sub insert()
            db.LCN_APPROVE_EDITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDITs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_YEAR(ByVal IDA As Integer, ByVal year As String, ByVal active As Integer)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.IDA = IDA And p.DATE_YEAR = year And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_LCN_IDA_AND_YEAR_AND_ACTIVE(ByVal IDA As Integer, ByVal year As String, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.FK_LCN_IDA = IDA And p.DATE_YEAR = year And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataBY_LCN_IDA(ByVal lcn As Integer)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.FK_LCN_IDA = lcn Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE
        Inherits MAINCONTEXT

        Public fields As New MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE

        'Private _Details As New List(Of LCN_APPROVE_EDIT_UPLOAD_FILE)
        'Public Property Details() As List(Of MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of LCN_APPROVE_EDIT_UPLOAD_FILE))
        '        _Details = value
        '    End Set
        'End Property
        Public Sub insert()
            db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ID(ByVal id As Integer)

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs Where p.ID = id Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_DDL(ByVal TITEL_ID As Integer, ByVal TITLE_ID2 As Integer, ByVal active As Boolean)

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs Where p.TITEL_ID = TITEL_ID And p.TITLE_ID2 = TITLE_ID2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub


    End Class
    Public Class TB_MAS_LCN_APPROVE_EDIT_REASON
        Inherits MAINCONTEXT

        Public fields As New MAS_LCN_APPROVE_EDIT_REASON


        Public Sub insert()
            db.MAS_LCN_APPROVE_EDIT_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_LCN_APPROVE_EDIT_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_DDL1(ByVal ddl1 As Integer, ByVal active As Boolean)

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASONs Where p.LCN_REASON_TYPE = ddl1 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_MAS_LCN_APPROVE_EDIT_REASON_SUB
        Inherits MAINCONTEXT

        Public fields As New MAS_LCN_APPROVE_EDIT_REASON_SUB


        Public Sub insert()
            db.MAS_LCN_APPROVE_EDIT_REASON_SUBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_LCN_APPROVE_EDIT_REASON_SUBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_SUBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_DDL2(ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_SUBs Where p.SUB_REASON_TYPE = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

End Namespace
