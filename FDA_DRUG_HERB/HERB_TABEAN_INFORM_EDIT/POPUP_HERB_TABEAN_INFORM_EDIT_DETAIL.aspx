<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_TABEAN_INFORM_EDIT_DETAIL.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_HERB_TABEAN_INFORM_EDIT_DETAIL" %>

<%@ Register Src="~/HERB_TABEAN_INFORM_EDIT/UC/UC_INFORM_DEDAIL2.ascx" TagPrefix="uc1" TagName="UC_INFORM_DEDAIL2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_INFORM_DEDAIL2 runat="server" ID="UC_INFORM_DEDAIL2" />
</asp:Content>
