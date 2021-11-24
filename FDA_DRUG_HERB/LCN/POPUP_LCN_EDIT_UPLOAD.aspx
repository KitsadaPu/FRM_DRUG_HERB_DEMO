<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_EDIT_UPLOAD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_EDIT_UPLOAD" %>

<%@ Register Src="~/LCN/UC/UC_LCN_UPLOAD_FILE.ascx" TagPrefix="uc1" TagName="UC_LCN_UPLOAD_FILE" %>

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




        $('#ContentPlaceHolder1_btn_download').click(function () {
            $('#spinner').fadeIn('slow');

        });

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
    function Popups3(url) { // สำหรับทำ Div Popup

        $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
        var i = $('#f3'); // ID ของ iframe   
        i.attr("src", url); //  url ของ form ที่จะเปิด
    }
    function Popups4(url) { // สำหรับทำ Div Popup

        $('#myModal4').modal('toggle'); // เป็นคำสั่งเปิดปิด
        var i = $('#f4'); // ID ของ iframe   
        i.attr("src", url); //  url ของ form ที่จะเปิด
    }
    function spin_space() { // คำสั่งสั่งปิด PopUp
        //    alert('123456');
        $('#spinner').toggle('slow');
        //$('#myModal').modal('hide');
        //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

    }
    function closespinner() {
        alert('Download เสร็จสิ้น');
        $('#spinner').fadeOut('slow');
        $('#ContentPlaceHolder1_Button1').click();
    }
    </script>
    <uc1:UC_LCN_UPLOAD_FILE runat="server" ID="UC_LCN_UPLOAD_FILE" />
    <br />
      <div class="row">
                <div class="col-lg-12" style="text-align:center">
                    <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-sm" OnClientClick="confirm('ต้องการบันทึกหรือไม่');"  Height="45px" Width="320px"/>
                    <asp:Button ID="btn_close" runat="server" Text="ปิด" CssClass="btn-sm"  Height="45px" Width="320px"/>

                </div>
            </div>
</asp:Content>
