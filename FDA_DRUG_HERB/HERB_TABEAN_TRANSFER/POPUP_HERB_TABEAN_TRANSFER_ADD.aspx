<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_TABEAN_TRANSFER_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_HERB_TABEAN_TRANSFER_ADD" %>

<%@ Register Src="~/HERB_TABEAN_TRANSFER/UC/UC_TRANSFER_DETAIL.ascx" TagPrefix="uc1" TagName="UC_TRANSFER_DETAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <uc1:UC_TRANSFER_DETAIL runat="server" ID="UC_TRANSFER_DETAIL" />

      <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" />&ensp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
            </div>
        </div>
</asp:Content>
