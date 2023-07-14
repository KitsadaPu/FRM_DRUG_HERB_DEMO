<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE_EDIT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {


            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }
        });
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }

        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');

        }
        function closespinner() {
            alert('Download เสร็จสิ้น');
            $('#spinner').fadeOut('slow');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>

    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบคำขอจดแจ้ง</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"> **โปรดศึกษาคำแนะนำในการแนบเอกสาร >>> </asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../PDF/คำแนะนำการอัพโลหดเอกสารหลักฐานและฉลาก.pdf" Target="_Blank" ForeColor="Red"> DOWNLOAD</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4" style="text-align: right"></div>
        <div class="col-lg-4" style="text-align: center">
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label"> ***การแนบกรุณาแนบครั้งละ 2-3 ไฟล์ และ ขนาดไฟล์ต้องไม่เกิน 8 Mb >>> </asp:Label>

        </div>
        <div class="col-lg-2" style="text-align: left">
            <%--<asp:Button ID="btn_add_no" runat="server" Text="แนบเอกสาร" />--%>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div style="height: 300px; text-align: center">
                <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
            </div>
        </div>
    </div>
    <div class="row" style="height: 15px"></div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <%--<asp:Button ID="btn_add_upload" runat="server" Text="ยืนยันการอัพโหลดเอกสารแนบ" Height="45px" />--%>
        </div>
    </div>
    <footer>
        <div class="row">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_add_no" runat="server" Text="อัพโหลดเอกสารแนบ" Height="35px" />&ensp;
            <asp:Button ID="btn_add_upload" runat="server" Text="บันทึกข้อมูลส่วนที่3" Height="35px" />
            </div>
        </div>
    </footer>

</asp:Content>
