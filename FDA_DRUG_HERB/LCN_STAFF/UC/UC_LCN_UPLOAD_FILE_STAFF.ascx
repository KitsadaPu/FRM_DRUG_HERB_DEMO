<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_UPLOAD_FILE_STAFF.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_UPLOAD_FILE_STAFF" %>
<%@ Register Src="~/UC/UC_ATTACH_LCN.ascx" TagPrefix="uc1" TagName="UC_ATTACH_LCN" %>


<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>
<style type="text/css">
    .auto-style1 {
        width: 20%;
    }

    .auto-style2 {
        height: 26px;
    }
</style>
<%--</asp:Content>--%>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">--%>
<script type="text/javascript">
    $(document).ready(function () {
        $(window).load(function () {
            $.ajax({
                type: 'POST',
                data: { submit: true },
                success: function (result) {
                    // $('#spinner').fadeOut('slow');
                }
            });
        });

        function CloseSpin() {
            $('#spinner').toggle('slow');
        }

        $('#ContentPlaceHolder1_btn_upload').click(function () {

            $('#spinner').toggle('slow');
            Popups('POPUP_LCN_UPLOAD.aspx');
            return false;
        });

        $('#ContentPlaceHolder1_btn_download').click(function () {
            $('#spinner').fadeIn('slow');
            Popups('POPUP_LCN_DOWNLOAD.aspx');
            return false;
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
    });

    function spin_space() { // คำสั่งสั่งปิด PopUp
        //    alert('123456');
        $('#spinner').toggle('slow');
        //$('#myModal').modal('hide');
        //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

    }
</script>
<div id="spinner" style="background-color: transparent; display: none;">
    <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
<div style="width: 100%; text-align: left">
</div>
    <h3>อัพโหลดเอกสาร</h3>
   
<div>
    <table style="width:100%">
        <tr>
            <td>
                กรุณาเลือกประเภท Checklist
            </td>
            <td>
                <asp:DropDownList ID="dd_typeatt" runat="server"></asp:DropDownList>
                <asp:Button ID="btn_select_typeatt" runat="server" Text="เลือก" CssClass="btn-sm" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lb_attgroup" runat="server" Font-Size="13pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <h5>
                    รายการเอกสารแนบ
                </h5>
                <span style="font-size:20px;color:red;">
                    ในขั้นตอนการแนบไฟล์นี้ ท่านสามารถแนบไฟล์และยืนยันไฟล์แนบไปทีละหัวข้อได้โดยไม่จำเป็นต้องแนบไฟล์ทั้งหมด แล้วกดยืนยันไฟล์แนบทีเดียว ทั้งนี้ หากทั้งไม่สามารถแนบไฟล์ทั้งหมดให้ครบในครั้งเดียวได้ ท่านสามารถยืนยันไฟล์แนบเฉพาะหัวข้อที่ท่านแนบไฟล์แล้ว และสามารถมาแนบไฟล์เพิ่มต่อในภายหลัง
                </span>
                <asp:Button ID="btn_att" runat="server" Text="ยืนยันไฟล์แนบ" Width="150px" CssClass="btn-sm" />&nbsp;
                <asp:Button ID="btn_save" runat="server" Text="ยืนยันข้อมูล" Width="150px" CssClass="btn-sm" />&nbsp;
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิกคำขอ" Width="150px" CssClass="btn-sm" OnClientClick="if (!confirm('ต้องการยกเลิกคำขอหรือไม่')) return false;"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="overflow-x:scroll;height:550px">
                    <asp:Table ID="Table1" runat="server" CssClass="table" Width="100%"></asp:Table>
                </div>
            </td>
        </tr>
    </table>
</div>