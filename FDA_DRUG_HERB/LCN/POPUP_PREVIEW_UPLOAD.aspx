<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_PREVIEW_UPLOAD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_PREVIEW_UPLOAD" %>

<%@ Register Src="~/LCN/UC/UC_UPLOAD_PREVIEW.ascx" TagPrefix="uc1" TagName="UC_UPLOAD_PREVIEW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_UPLOAD_PREVIEW runat="server" ID="UC_UPLOAD_PREVIEW" />
</asp:Content>
