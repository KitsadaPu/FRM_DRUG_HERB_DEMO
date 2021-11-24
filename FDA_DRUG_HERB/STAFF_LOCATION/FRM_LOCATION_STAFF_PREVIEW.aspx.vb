Public Class FRM_LOCATION_STAFF_PREVIEW
    Inherits System.Web.UI.Page
    Private _id As Integer

    Private Sub get_querystring()
        _id = Request.QueryString("ida")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_querystring()
        If Not IsPostBack Then
            bind_file()
        End If
    End Sub

    Private Sub bind_file()
        Dim dao As New DAO_DRUG.TB_FILE_ATTACH_LOCATION
        dao.GetDataby_TR_ID(_id)

        Dim FILENAME_XML As String = dao.fields.NAME_FAKE
        Dim bao As New BAO.AppSettings

        'Dim paths As String = bao._PATH_XML_PDF_TABEAN_TB

        'Dim PATH_XML As String
        Dim saveLocation As String = _PATH_DEFALUT & "/upload/" & FILENAME_XML

        Dim clsds As New ClassDataset
        Dim output As Byte()
        output = clsds.UpLoadImageByte(saveLocation)

        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(output)
        Response.Flush()
        Response.End()

    End Sub
End Class