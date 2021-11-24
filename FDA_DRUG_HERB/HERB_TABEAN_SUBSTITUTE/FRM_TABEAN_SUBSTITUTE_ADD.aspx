<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_TABEAN_SUBSTITUTE_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_SUBSTITUTE_ADD" MaintainScrollPositionOnPostback="true" %>
<%@ Register src="../UC/UC_ATTACH.ascx" tagname="UC_ATTACH" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="text-align:center">
        <div class="col-lg-12">รายการละเอียดคำขอใบแทนสำหรับผลิตภัณฑ์สมุนไพร</div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ประเภท</div>
        <div class="col-lg-8"><asp:label ID="lbl_type" runat="server"></asp:label></div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ชื่อ(ภาษาไทย)</div>
        <div class="col-lg-8"><asp:label ID="lbl_name_thai" runat="server"></asp:label></div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ชื่อ(ภาษาอังกฤษ)</div>
        <div class="col-lg-8"><asp:label ID="lbl_name_eng" runat="server"></asp:label></div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" style="text-align:center">
        <div class="col-lg-12">รายการเอกสารแนบ</div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">เหตุผลการขอ</div>
        <div class="col-lg-6">
            <asp:DropDownList ID="ddl_reason" runat="server" AutoPostBack="true">
                <asp:ListItem Value="0" Text="-- กรุณาเลือก --"></asp:ListItem>
                <asp:ListItem Value="4" Text="กรณีที่ใบอนุญาตถูกทำลาย หรือ ลบเลือนในสาระสำคัญ"></asp:ListItem>
                <asp:ListItem Value="5" Text="กรณีที่ใบอนุญาตสูญหาย"></asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" style="text-align:center">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">หมายเหตุ</div>
        <div class="col-lg-6">
            <asp:TextBox ID="txt_remark" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-8">
            <asp:Panel ID="pn_att1" runat="server">
                <div class="row col-lg-12">
                    <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
                </div>
                <div class="row col-lg-12">
                    <uc1:UC_ATTACH ID="UC_ATTACH2" runat="server" />
                </div>
            </asp:Panel>
            <asp:Panel ID="pn_att2" runat="server">
                <div class="row col-lg-12">
                    <uc1:UC_ATTACH ID="UC_ATTACH3" runat="server" />
                </div>
                <div class="row col-lg-12">
                    <uc1:UC_ATTACH ID="UC_ATTACH4" runat="server" />
                </div>
            </asp:Panel>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-8 text-center">
            <asp:Button ID="btn_save" runat="server" Text="บันทึกส่วนที่ 1"/>
            <asp:Button ID="btn_back" runat="server" Text="ยกเลิก"/>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
