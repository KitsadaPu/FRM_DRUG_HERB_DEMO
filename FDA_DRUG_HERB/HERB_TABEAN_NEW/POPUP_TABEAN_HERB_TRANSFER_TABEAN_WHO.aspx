<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_OLD_TO_TABEAN_WHO.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_OLD_TO_TABEAN_WHO" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_txt_date_confirm"));
            $("#ContentPlaceHolder1_txt_date_confirm").searchable();
        });
        function Popups(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }

        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function spin_space() { // คำสั่งสั่งปิด PopUp
            $('#spinner').toggle('slow');
        }

        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12" style="text-align: center;">
            <h3>การแก้ไขข้อมูลทะเบียนเป็นผู้ใด</h3>
        </div>
    </div>

    <div style="padding-top: 15px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            เลขทะเบียนที่
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_RGTNO_NEW" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="padding-top: 15px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            ชื่อผลิตภัณฑ์สมุนไพร (ภาษาไทย)
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_NAME_THAI" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="padding-top: 15px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            ชื่อผลิตภัณฑ์สมุนไพร (ภาษาอังกฤษ)
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_NAME_ENG" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            ผู้รับใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร 
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_name_request" runat="server" Width="100%"></asp:TextBox>
            <asp:Label ID="lbl_name_request" runat="server" Text="*กรุณากรอกชื่อผู้ยื่นคำขอ " ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="TXT_SEARCH_TN" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Button ID="BTN_SEARCH_TN" runat="server" Text="ค้นหา" />
        </div>
        <div class="col-lg-1"></div>
    </div>

    <%--    <div style="padding-top: 15px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            ผู้รับใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร  
        </div>
    </div>--%>

    <div style="padding-top: 15px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            ผลิตภัณฑ์สมุนไพรนี้
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_type_lcn" runat="server"></asp:TextBox>
        </div>
    </div>

    <div style="padding-top: 15px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            โดย
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_THANM" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            ใบอนุาตเลขที่
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_LCNNO_DISPAY" runat="server"></asp:TextBox>
        </div>
    </div>

    <div style="padding-top: 250px"></div>
    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" Height="40px" Width="175px" />
            </div>
        </div>
    </footer>
</asp:Content>
