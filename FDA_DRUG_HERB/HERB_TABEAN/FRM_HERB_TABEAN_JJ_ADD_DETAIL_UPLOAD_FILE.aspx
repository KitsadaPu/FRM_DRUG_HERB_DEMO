<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบคำขอจดแจ้ง</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"> **โปรดศึกษาคำแนะนำในการแนบเอกสาร >>> </asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../PDF/คำแนะนำการอัพโลหดเอกสารหลักฐานและฉลาก.pdf" Target="_Blank"  ForeColor="Red"> DOWNLOAD</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div style="overflow-x: scroll; height: 600px; text-align: center">
            <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
            <asp:Button ID="btn_add_upload" runat="server" Text="อัพโหลดเอกสาร ยืนยันการยื่นคำขอ" />
        </div>
    </div>

</asp:Content>
