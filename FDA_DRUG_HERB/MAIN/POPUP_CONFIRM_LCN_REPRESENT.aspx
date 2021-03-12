<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_CONFIRM_LCN_REPRESENT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_CONFIRM_LCN_REPRESENT" %>

<%@ Register Src="~/LCN/UC/UC_CONFIRM_REPRESENT.ascx" TagPrefix="uc1" TagName="UC_CONFIRM_REPRESENT" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
            <td width="70%">
                <uc1:UC_CONFIRM_REPRESENT runat="server" id="UC_CONFIRM_REPRESENT" />
            </td>
            <td style="padding-left: 10%; height: 50%;">
                <table class="table" style="width: 90%">
                    <tr><td><asp:Button ID="btn_confirm" runat="server" Text="ยื่นคำขอ" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" /></td></tr>
                    <tr><td><asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="80%" /></td></tr>
                </table>
            </td>
        </table>
</asp:Content>

    
