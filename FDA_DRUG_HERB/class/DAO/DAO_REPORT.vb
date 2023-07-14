Namespace DAO_REPORT

    Public MustInherit Class MAINCONTEXT        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_REPORTDataContext    'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        Public datas                            'ประกาศเ

    End Class

    Public Class TB_HERB_PRODUCT_REPORT
        Inherits MAINCONTEXT

        Public fields As New HERB_PRODUCT_REPORT

        Public Sub insert()
            db.HERB_PRODUCT_REPORTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.HERB_PRODUCT_REPORTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.HERB_PRODUCT_REPORTs Select p)
        End Sub

        Public Sub Getdataby_IDA(ByVal IDA As Integer)
            datas = From p In db.HERB_PRODUCT_REPORTs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_FK_IDA(ByVal FK_IDA As String)
            datas = From p In db.HERB_PRODUCT_REPORTs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_HERB_PRODUCT_REPORT_DETAIL
        Inherits MAINCONTEXT

        Public fields As New HERB_PRODUCT_REPORT_DETAIL

        Public Sub insert()
            db.HERB_PRODUCT_REPORT_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.HERB_PRODUCT_REPORT_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.HERB_PRODUCT_REPORT_DETAILs Select p)
        End Sub

        Public Sub Getdataby_IDA(ByVal IDA As Integer)
            datas = From p In db.HERB_PRODUCT_REPORT_DETAILs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_FK_IDA(ByVal FK_IDA As String)
            datas = From p In db.HERB_PRODUCT_REPORT_DETAILs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_HERB_PRODUCT_NOTIFIED
        Inherits MAINCONTEXT

        Public fields As New HERB_PRODUCT_NOTIFIED

        Public Sub insert()
            db.HERB_PRODUCT_NOTIFIEDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.HERB_PRODUCT_NOTIFIEDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.HERB_PRODUCT_NOTIFIEDs Select p)
        End Sub

        Public Sub Getdataby_IDA(ByVal IDA As Integer)
            datas = From p In db.HERB_PRODUCT_NOTIFIEDs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_FK_IDA(ByVal FK_IDA As String)
            datas = From p In db.HERB_PRODUCT_NOTIFIEDs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_HERB_PRODUCT_NOTIFIED_DETAIL
        Inherits MAINCONTEXT

        Public fields As New HERB_PRODUCT_NOTIFIED_DETAIL

        Public Sub insert()
            db.HERB_PRODUCT_NOTIFIED_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.HERB_PRODUCT_NOTIFIED_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.HERB_PRODUCT_NOTIFIED_DETAILs Select p)
        End Sub

        Public Sub Getdataby_IDA(ByVal IDA As Integer)
            datas = From p In db.HERB_PRODUCT_NOTIFIED_DETAILs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_FK_IDA(ByVal FK_IDA As String)
            datas = From p In db.HERB_PRODUCT_NOTIFIED_DETAILs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

    End Class

End Namespace

