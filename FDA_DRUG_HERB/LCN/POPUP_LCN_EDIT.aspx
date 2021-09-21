<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_EDIT" %>

<%@ Register Src="~/LCN/UC/UC_LCN_UPLOAD_FILE.ascx" TagPrefix="uc1" TagName="UC_LCN_UPLOAD_FILE" %>
<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%; padding-left: 10%; padding-right: 10%; background-color: gray;">
        <div class="panel panel-body" style="width: auto; padding-left: 5%; padding-right: 5%; background-color: white;">
            <asp:Panel ID="Panel1" runat="server">
              
                  <div class="row" style="text-align: center">
        <h3>รายการเอกสารที่แก้ไข</h3>
    </div>
            <div class="row">

                <div class="col-lg-10">
                    <uc1:UC_GRID_ATTACH runat="server" ID="UC_GRID_ATTACH" />
                </div>
            </div>
                   <hr />
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3 font-size: 20px">หมายเหตุการแก้ไข</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2">
                      <%--  <p style="color: red; font-size: 20px">รายละเอียดแก้ไข :</p>--%>
                    </div>
                    <div class="col-lg-8">
                        <%-- <asp:Label ID="txt_edit_remark" runat="server" Text="-" ForeColor="Red"></asp:Label>--%>
                        <%--<asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 50%; width: 100%"></asp:TextBox>--%>
                        <asp:TextBox ID="txt_edit_remark" runat="server" ForeColor="Red" Height="50%" ReadOnly="True" TextMode="MultiLine" Width="90%" BorderColor="Silver">-</asp:TextBox>
                    </div>
                </div>
                <hr style="background-color: #000000" />
            </asp:Panel>
           
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแนบแก้ไขคำขอใบอนุญาต</h3>
                </div>
            </div>
            <div class="row">
                <div style="overflow-x: scroll; height: 200px; text-align: center">
                    <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
                    <asp:Button ID="btn_add_upload" runat="server" Text="อัพโหลดเอกสาร" />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <asp:Button ID="BTN_UPDATE_EDIT" runat="server" Text="ยื่นคำขอ" CssClass=" btn-lg" Width="167px" OnClientClick="return confirm('กรุณาตรวจสอบความถูกต้องก่อนยื่นคำขอ หากถูกต้องแล้วให้กด ตกลง ');" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BTN_CLOSE" runat="server" Text="ปิด" CssClass=" btn-lg" Width="167px" />
                </div>

            </div>
        </div>


    </div>
</asp:Content>
