﻿Public Class FRM_HERB_TABEAN_MASTER_PREVIEW_FILE
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
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ
        dao.GetdatabyID_IDA(_id)

        Dim FILENAME_XML As String = dao.fields.NAME_FAKE
        Dim bao As New BAO.AppSettings

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_MASTER")
        path_XML = "D:\path_demo\XML_PDF_TABEAN_JJ_DEMO\FILE_JJ_RECIPE_PRODUCT\" & FILENAME_XML

        Dim clsds As New ClassDataset
        Dim output As Byte()
        output = clsds.UpLoadImageByte(PATH_XML)

        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(output)
        Response.Flush()
        Response.End()

    End Sub
End Class