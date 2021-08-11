<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_REQUEST_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_REQUEST_EDIT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/MAIN/UC/UC_HERB_EDIT.ascx" TagPrefix="uc1" TagName="UC_HERB_EDIT" %>
<%@ Register Src="~/MAIN/UC/UC_LCN_HERB_EDIT.ascx" TagPrefix="uc1" TagName="UC_LCN_HERB_EDIT" %>
<%@ Register Src="~/MAIN/UC/UC_LCN_HERB_PHESAJ_EDIT.ascx" TagPrefix="uc1" TagName="UC_LCN_HERB_PHESAJ_EDIT" %>









<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <uc1:UC_HERB_EDIT runat="server" ID="UC_HERB_EDIT" />
    </div>
    <div class="row">
        <uc1:UC_LCN_HERB_EDIT runat="server" ID="UC_LCN_HERB_EDIT" />
    </div>
    <div class="row">
        <uc1:UC_LCN_HERB_PHESAJ_EDIT runat="server" ID="UC_LCN_HERB_PHESAJ_EDIT" />
    </div>
<asp:Label ID="Label1" runat="server" Text="" style="display:none"></asp:Label>
    <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg " Width="120px" OnClientClick="confirm('คุณต้องการบันทึกหรือไม่');" />

            <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
</asp:Content>
