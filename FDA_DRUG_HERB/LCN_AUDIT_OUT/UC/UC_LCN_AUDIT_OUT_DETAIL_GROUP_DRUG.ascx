<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_AUDIT_OUT_DETAIL_GROUP_DRUG.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_AUDIT_OUT_DETAIL_GROUP_DRUG" %>

<%--<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>--%>

<div>
    <%--<form name="form" method="post" align="center;">--%>
        <div class="row">
            <div class="col-lg-12" style="text-align: center;">
                <h4>รายละเอียดหมวดการผลิตยาที่ขอรับรอง</h4>
            </div>
        </div>
           <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ชื่อสถานที่ผลิต</div>
            <div class="col-lg-8">
                <asp:TextBox ID="txt_Name_Production_site" runat="server" Width="70%"></asp:TextBox>
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
            <div class="col-lg-3">ชื่อผู้สามารถติดต่อในกรณีต้องการข้อมูลเพิ่มเติม</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_name_more" runat="server" Width="100%"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">เบอร์โทรศัพท์</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_tel_more" runat="server" Width="70%"></asp:TextBox>
            </div>
            <div class="col-lg-1">เบอร์มือถือ.</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_mobile_more" runat="server" Width="70%"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">E-mail Address</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_email_more" runat="server" Width="70%"></asp:TextBox>
            </div>
        </div>
    <%--</form>--%>
</div>
