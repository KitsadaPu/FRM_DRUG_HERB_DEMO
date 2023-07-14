<%@ Page Title="" Language="vb" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_PHR_HERB_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_PHR_HERB_EDIT" %>



<%@ Register Src="~/LCN_PHR/UC/UC_PHR_DETAIL.ascx" TagPrefix="uc1" TagName="UC_PHR_DETAIL" %>
<%@ Register Src="~/LCN_PHR/UC/UC_PHR_MATRA.ascx" TagPrefix="uc1" TagName="UC_PHR_MATRA" %>
<%@ Register Src="~/LCN_PHR/UC/UC_PHR_UPLOAD_FILE.ascx" TagPrefix="uc1" TagName="UC_PHR_UPLOAD_FILE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:UC_PHR_UPLOAD_FILE runat="server" ID="UC_PHR_UPLOAD_FILE" />
    <uc1:UC_PHR_MATRA runat="server" ID="UC_PHR_MATRA" />
    <uc1:UC_PHR_DETAIL runat="server" ID="UC_PHR_DETAIL" />

    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
            </div>
        </div>
    </footer>
</asp:Content>
