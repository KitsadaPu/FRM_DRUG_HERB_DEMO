﻿Public Class FRFM_ATTACH_PREVIEW_LCN
    Inherits System.Web.UI.Page

    Private _id As Integer
    Private _Path As String

    Private Sub get_querystring()
        _id = Request.QueryString("ida")
        _Path = Request.QueryString("Path")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_querystring()
        If Not IsPostBack Then
            bind_file()
        End If

    End Sub

    Private Sub bind_file()
        Dim dao As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao.GetDataby_IDA(_id)

        Dim FILENAME_XML As String = dao.fields.NAME_FAKE
        Dim bao As New BAO.AppSettings

        'Dim paths As String = bao._PATH_XML_PDF_TABEAN_JJ
        Dim paths As String = _Path

        Dim PATH_XML As String
        PATH_XML = paths & "FILE_UPLOAD\" & FILENAME_XML

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