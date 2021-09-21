Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Namespace BAO_TABEAN_HERB
    Public Class connection_db
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class

    Public Class tb_dd
        Inherits connection_db

        Public Function SP_DD_MAS_TABEAN_HERB_NAME_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_NAME_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_MAS_STAFF_NAME_HERB() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_STAFF_NAME_HERB"
            dt = Queryds(qstr)

            Return dt
        End Function

        'Public Function SP_DD_STATUS_JJ() As DataTable
        '    Dim dt As New DataTable
        '    Dim qstr As String = ""

        '    qstr = "exec SP_DD_STATUS_JJ"
        '    dt = Queryds(qstr)

        '    Return dt
        'End Function

        Public Function SP_DD_STATUS_JJ(ByVal s_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_STATUS_JJ @s_id=" & s_id
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_PRODUCT_AGE_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_PRODUCT_AGE_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_STYPE_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_STYPE_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_EATTING_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_EATTING_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_DRUGGROUP_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_DRUGGROUP_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_DRUGGROUPTYPE_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_DRUGGROUPTYPE_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

    End Class

    Public Class tb_main
        Inherits connection_db

        Public Function SP_TABEAN_HERB_GET_MAX_RGTNO_JJ(ByVal rgttpcd As String, ByVal _YEAR As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_GET_MAX_RGTNO_JJ @rgttpcd=" & rgttpcd & ",@year= '" & _YEAR & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_OFFICER_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_OFFICER_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_JJ(ByVal IDA_LCN As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_JJ @IDA_LCN= '" & IDA_LCN & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_JJ_SUB_PACKSIZE(ByVal fk_ida As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_JJ_SUB_PACKSIZE @fk_ida= '" & fk_ida & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ(ByVal DD_HERB_NAME_PRODUCT_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ @DD_HERB_NAME_PRODUCT_ID=" & DD_HERB_NAME_PRODUCT_ID
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ(ByVal TR_ID_JJ As Integer, ByVal TYPE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_JJ @TR_ID_JJ=" & TR_ID_JJ & ",@TYPE_ID= '" & TYPE_ID & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO"
            dt = Queryds(qstr)

            Return dt
        End Function

    End Class

    Public Class tb_xml
        Inherits connection_db

        Public Function SP_XML_TABEAN_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_TABEAN_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function
    End Class

End Namespace

