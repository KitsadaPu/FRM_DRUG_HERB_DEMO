<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_TRANSFER.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_TRANSFER" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            font-size: 18px;
            line-height: 1.33;
            border-radius: 6px;
            padding: 10px 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="row">
        <div class="col-lg-5"></div>
        <div class="col-lg-7">
            <h2>คำขอโอนใบอนุญาต</h2>
        </div>

    </div>
    <div class="row">
        <div class="col-lg-5"></div>
        <div class="col-lg-7 ">
            <asp:RadioButtonList ID="rdl_lcn_type" runat="server">
                <asp:ListItem Value="1">ผลิตผลิตภัณฆ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="2">นำเข้าผลิตภัณฆ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="3">ขายผลิตภัณฆ์สมุนไพร</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_name" runat="server" Text="ข้าพเจ้า"></asp:Label>
        </div>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_name" runat="server" Width="100%"></asp:TextBox>
        </div>
    <div class="col-lg-2">
        <asp:Label ID="lbl_name_lcn" runat="server" Text="(ชื่อผู้รับอนุญาต)"></asp:Label>
    </div>
    <div class="col-lg-2"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_phr_name" runat="server" Text="ซึ่งมีผู้มีหน้าที่ปฏิบัติการชื่อ"></asp:Label>
        </div>
        <div class="col-lg-2" style="text-align: left">
            <asp:TextBox ID="txt_phr_name" runat="server" ></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_niti" runat="server" Text="(เฉพาะกรณีนิติบุคคล)"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_lcnno" runat="server" Text="ตามใบอนุญาตเลขที่"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_lcnno" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_name_business" runat="server" Text="ณ สถานที่ประกอบธุรกิจชื่อ"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_name_business" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-4"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_location_trnf" runat="server" Text="อยู่เลขที่"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_location_trnf" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_trnf_building" runat="server" Text="หมู่บ้าน/อาคาร"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_trnf_building" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-6"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_mu" runat="server" Text="หมู่ที่"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_trnf_mu" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_trnf_soi" runat="server" Text="ตรอก/ซอย"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_trnf_soi" runat="server"></asp:TextBox>
        </div>    
        <div class="col-lg-4"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
          <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_road" runat="server" Text="ถนน"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_trnf_road" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-8"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_tambol" runat="server" Text="ตำบลแขวง"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_trnf_tambol" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_trnf_amphor" runat="server" Text="อำเภอเขต"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_trnf_amphor" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-4"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_changwat" runat="server" Text="จังหวัด"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_trnf_changwat" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_trnf_zipcode" runat="server" Text="รหัสไปรษณีย์"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_trnf_zipcode" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_lcn_tel" runat="server" Text="โทรศัพท์"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_lcn_tel" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_time_work" runat="server" Text="เวลาทำการ"></asp:Label>
        </div>
        <div class="col-lg-2">
            <telerik:RadTimePicker ID="RadTimePicker1" runat="server"></telerik:RadTimePicker>
            <%--<asp:TextBox ID="txt_time_work" runat="server"></asp:TextBox>--%>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_iden" runat="server" Text="เลขประจำตัวประชาชน"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_trnf_iden" runat="server" ></asp:TextBox>
        </div>
        <div class="col-lg-7"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="text-align: right">
            <h3>กรณีบุคคลต่างด่าว ระบุ</h3>
            <%--<asp:Label ID="lbl_personal_type" runat="server" Text="กรณีบุคคลต่างด่าว ระบุ"></asp:Label>--%>
        </div>
        <div class="col-lg-8"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_PASSPORT_NO" runat="server" Text="หนังสือเดินทางเลขที่"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_PASSPORT_NO" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_PASSPORT_EXPDATE" runat="server" Text="วันหมดอายุ"></asp:Label>
        </div>
        <div class="col-lg-2">
            <telerik:RadDatePicker ID="RDP_PASSPORT_EXPDATE" runat="server">
            </telerik:RadDatePicker>
        </div>
        <div class="col-lg-7"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_DOC_NO" runat="server" Text="ใบอนุญาตทำงานหรือใบสำคัญถิ่นที่อยู่เลขที่"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_DOC_NO" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_DOC_NO_EXPDATE" runat="server" Text="วันหมดอายุ"></asp:Label>
        </div>
        <div class="col-lg-2">
            <telerik:RadDatePicker ID="RDP_DOC_NO_EXPDATE" runat="server">
            </telerik:RadDatePicker>
        </div>
        <div class="col-lg-3"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="text-align: right">
            <asp:Label ID="lbl_transfer_to" runat="server" Text="มีความประสงค์ขอโอนใบอนุญาตฯ ให้แก่"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_transfer_to" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="text-align: left">
            <asp:Label ID="lbl_trnf_name" runat="server" Text="(ผู้รับโอน)"></asp:Label>
        </div>
        <div class="col-lg-3"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_operator_name" runat="server" Text="โดยมีผู้ดำเนินกิจการชื่อ"></asp:Label>
        </div>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_operator_name" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_start_trnf" runat="server" Text="ตั้งแต่วันที่"></asp:Label>
        </div>
        <div class="col-lg-1">
            <telerik:RadDatePicker ID="RPD_start_trnf" runat="server" >
            </telerik:RadDatePicker>
            <%--<asp:TextBox ID="txt_start_trnf" runat="server"></asp:TextBox>--%>
        </div>
        <div class="col-lg-8"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_remark" runat="server" Text="เนื่องจาก"></asp:Label>
        </div>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_trnf_remark" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <asp:Label ID="Label3" runat="server" Text="และข้าพเจ้า (ผู้โอน) ขอส่งคืนใบอนุญาตและขอยกเลิกใบอนุญาตฯ ของข้าพเจ้า นับตั้งแต่ผู้รับโอนได้รับอนุญาตจากผู้รับอนุญาต"></asp:Label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-3">
            <asp:Label ID="Label4" runat="server" Text="พร้อมนี้ผู้รับโอนได้แนบหลักฐานมาด้วยคือ"></asp:Label>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <asp:Label ID="Label5" runat="server" Text="๑. คำขอรับใบอนุญาตผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร (สมพ.๑) และเอกสารที่เกี่ยวข้องตามแบบ สมพ.๑"></asp:Label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-5">
            <asp:Label ID="Label6" runat="server" Text="๒. เอกสารหลักฐานอื่น ๆ (ถ้ามี)"></asp:Label>
        </div>
        <div class="col-lg-6"></div>
    </div>

    <%--<div class="row">
     <div class="col-lg-1"></div>
        <div class="col-lg-1">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>--%>
    <br />
    <br />

    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-2">
            <asp:Button ID="Confirm" runat="server" Text="ยืนยัน" CssClass="auto-style2" Width="165px" />
        </div>
        <div class="col-lg-1">
            <asp:Button ID="Cancel" runat="server" Text="ยกเลิก" CssClass="auto-style2" Width="165px" />
        </div>
        <div class="col-lg-1"></div>
    </div>

</asp:Content>
