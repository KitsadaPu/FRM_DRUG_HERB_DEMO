<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_TYPE_PRODUCK.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_TYPE_PRODUCK" %>


<div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center;">
            <h4>รายการรูปแบบผลิตภัณฑ์สมุนไพรที่ผลิตในแบบแปลนสถานที่ที่ขอพิจารณา</h4>
        </div>
    </div>
         <%-- <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ชื่อสถานที่ผลิต</div>
            <div class="col-lg-8">
                <asp:TextBox ID="txt_Name_Production_site" runat="server" Width="70%"></asp:TextBox>
            </div>
        </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-11" style="text-align: left;">
            <h4>กลุ่มยาปราศจากเชื้อ</h4>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="text-align: center">
            <asp:Table ID="tb_type_menu" runat="server" CssClass="table table-bordered table-striped" Width="100%"></asp:Table>
        </div>
    </div>

        <div class="row">
        <div class="col-lg-1"></div>
            <div class="col-lg-11" style="text-align: left;">
                <h4>กลุ่มยาทั่วไป</h4>
            </div>
        </div>
     <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="text-align: center">
                <asp:Table ID="tb_type_menu2" runat="server" CssClass="table table-bordered table-striped" Width="100%"></asp:Table>
            </div>
        </div>

<div class="row">
        <div class="col-lg-1"></div>
            <div class="col-lg-11" style="text-align: left;">
                <h4>แบ่งบรรจุผลิตภัณฑ์เท่านั้น Packaging only</h4>
            </div>
        </div>
     <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="text-align: center">
                <asp:Table ID="tb_type_menu3" runat="server" CssClass="table table-bordered table-striped" Width="100%"></asp:Table>
            </div>
        </div>

<div class="row">
        <div class="col-lg-1"></div>
            <div class="col-lg-11" style="text-align: left;">
                <h4>วัตถุที่มุ่งหมายเป็นส่วนผสมในการผลิตผลิตภัณฑ์สมุนไพร</h4>
            </div>
        </div>
     <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="text-align: center">
                <asp:Table ID="tb_type_menu4" runat="server" CssClass="table table-bordered table-striped" Width="100%"></asp:Table>
            </div>
        </div>
</div>
