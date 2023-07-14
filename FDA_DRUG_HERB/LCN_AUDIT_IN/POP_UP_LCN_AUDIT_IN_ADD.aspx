<%@ Page Title="" Language="vb" MaintainScrollPositionOnPostback="true"  AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POP_UP_LCN_AUDIT_IN_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POP_UP_LCN_AUDIT_IN_ADD" %>

<%@ Register Src="~/LCN_AUDIT_IN/UC/UC_LCN_AUDIT_IN_DETAIL.ascx" TagPrefix="uc1" TagName="UC_LCN_AUDIT_IN_DETAIL" %>
<%@ Register Src="~/LCN_AUDIT_IN/UC/UC_LCN_AUDIT_IN_DETAIL_GROUP_DRUG.ascx" TagPrefix="uc1" TagName="UC_LCN_AUDIT_IN_DETAIL_GROUP_DRUG" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:UC_LCN_AUDIT_IN_DETAIL runat="server" id="UC_LCN_AUDIT_IN_DETAIL" />
    <uc1:UC_LCN_AUDIT_IN_DETAIL_GROUP_DRUG runat="server" ID="UC_LCN_AUDIT_IN_DETAIL_GROUP_DRUG" />
       <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูลส่วนที่หนึ่ง" Height="40px" Width="148px" />
            </div>
        </div>
    </footer>
</asp:Content>
