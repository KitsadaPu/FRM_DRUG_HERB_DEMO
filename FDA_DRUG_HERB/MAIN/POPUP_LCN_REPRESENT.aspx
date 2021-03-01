<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_REPRESENT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_REPRESENT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                 <h1>ขอใบแทนใบอนุญาติเลขที่ <asp:Label ID="Label3" runat="server" Text=""></asp:Label></h1>
            </div>
            <div class="col-lg-1"></div>

        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label1" runat="server" Text="เหตุผลที่ขอใบแทนใบสำคัญ" Height="48px" Width="143px"></asp:Label>
            </div>
            <div class="col-lg-3">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>

            <div class="col-lg-6"></div>
        </div>


    </div>
    <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg " Width="120px" OnClientClick="confirm('คุณต้องการบันทึกหรือไม่');" />
  
                
            <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
</asp:Content>
