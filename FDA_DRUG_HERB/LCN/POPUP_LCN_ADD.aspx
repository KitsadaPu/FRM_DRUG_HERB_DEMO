<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_ADD" %>

<%@ Register Src="~/LCN/UC/UC_HERB.ascx" TagPrefix="uc1" TagName="UC_HERB" %>
<%@ Register Src="~/LCN/UC/UC_HERB_KEEP.ascx" TagPrefix="uc1" TagName="UC_HERB_KEEP" %>
<%@ Register Src="~/LCN/UC/UC_HERB_PHESAJ.ascx" TagPrefix="uc1" TagName="UC_HERB_PHESAJ" %>
<%@ Register Src="~/LCN/UC/UC_LCN_UPLOAD_FILE.ascx" TagPrefix="uc1" TagName="UC_LCN_UPLOAD_FILE" %>






<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%; padding-left: 5%; padding-right: 5%; padding-top: 0.1%; background-color: gray;">
        <div class="panel panel-body" style="width: auto; padding-left: 5%; padding-right: 5%; background-color: white;">
            <asp:Panel ID="Panel4" runat="server" Style="display: none;">
                <uc1:UC_HERB runat="server" ID="UC_HERB" />
            </asp:Panel>
            <div class="row">
                <div class="col-lg-1" style="text-align: right"></div>
                <div class="col-lg-3">
                     <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูลส่วนที่ 1" CssClass="btn-lg" OnClientClick="confirm('ต้องการบันทึกหรือไม่');" />
                </div>
            </div>

            <br />
            <br />
            <br />

            <asp:Panel ID="Panel1" runat="server" Style="display: none;">
                <uc1:UC_HERB_KEEP runat="server" ID="UC_HERB_KEEP" />
            </asp:Panel>

            <asp:Panel ID="Panel2" runat="server" Style="display: none;">
                <uc1:UC_HERB_PHESAJ runat="server" ID="UC_HERB_PHESAJ" />
                <hr />
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" Style="display: none;">
                <uc1:UC_LCN_UPLOAD_FILE runat="server" ID="UC_LCN_UPLOAD_FILE" />
                <hr />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
