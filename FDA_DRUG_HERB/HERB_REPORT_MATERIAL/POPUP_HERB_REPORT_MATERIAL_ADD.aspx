<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_REPORT_MATERIAL_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_HERB_REPORT_MATERIAL_ADD" %>

<%@ Register Src="~/HERB_REPORT_MATERIAL/UC/UC_REPORT_4.ascx" TagPrefix="uc1" TagName="UC_REPORT_4" %>
<%@ Register Src="~/HERB_REPORT_MATERIAL/UC/UC_REPORT_1.ascx" TagPrefix="uc1" TagName="UC_REPORT_1" %>
<%@ Register Src="~/HERB_REPORT_MATERIAL/UC/UC_REPORT_2.ascx" TagPrefix="uc1" TagName="UC_REPORT_2" %>
<%@ Register Src="~/HERB_REPORT_MATERIAL/UC/UC_REPORT_3.ascx" TagPrefix="uc1" TagName="UC_REPORT_3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" Style="display: none;">
        <uc1:UC_REPORT_1 runat="server" id="UC_REPORT_1" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Style="display: none;">
        <uc1:UC_REPORT_2 runat="server" id="UC_REPORT_2" />
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Style="display: none;">
        <uc1:UC_REPORT_3 runat="server" id="UC_REPORT_3" />
    </asp:Panel>
     <asp:Panel ID="Panel4" runat="server" Style="display: none;">
         <uc1:UC_REPORT_4 runat="server" id="UC_REPORT_4" />
    </asp:Panel>

    <div class="row" id="E1" runat="server">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" />&ensp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
        </div>
    </div>
</asp:Content>
