<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_UPLOAD_FILE.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_UPLOAD_FILE" %>
<%@ Register Src="~/UC/UC_ATTACH_LCN.ascx" TagPrefix="uc1" TagName="UC_ATTACH_LCN" %>

<style type="text/css">
    .auto-style1 {
        width: 20%;
    }

    .myDiv {
        display: none;
    }

    .myDiv2 {
        display: none;
    }

    .myDiv3 {
        display: none;
    }

    .myDiv4 {
        display: none;
    }

    .sub_mydiv {
        display: none;
    }

    .sub_mydiv2 {
        display: none;
    }

    label {
        margin-right: 20px;
    }

    img {
        max-width: none !important;
    }
</style>

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

    $(document).ready(function () {
        $('input[type="radio"]').click(function () {
            var inputValue = $(this).attr("value");
            var targetBox = $("." + inputValue);
            var targetBox6 = $("." + inputValue);
            var targetBox2 = $("." + 9);
            var targetBox3 = $("." + 8);
            var targetBox4 = $("." + 111);
            if (inputValue < 9) {
                $(".myDiv").not(targetBox).hide();
                $(targetBox).show();
                $(".myDiv2").not(targetBox2).hide();
                $(targetBox2).show();
                $(".myDiv4").not(targetBox4).hide();
                $(targetBox4).show();
                if (inputValue > 2 && inputValue < 6) {
                    $(".myDiv3").not(targetBox3).hide();
                    $(targetBox3).show();
                } else {
                    $(".myDiv3").not(targetBox).hide();
                    $(targetBox).show();
                }
                
            } else {
                if (inputValue < 50) {
                    $(".sub_mydiv").not(targetBox).hide();
                    $(targetBox).show();
                } else {
                    $(".sub_mydiv2").not(targetBox6).hide();
                    $(targetBox6).show();
                }
            }
            if (inputValue < 3) {
                $('input[id=ContentPlaceHolder1_UC_LCN_UPLOAD_FILE_rdl_chk_bsn_0]').attr('checked', false);
                $('input[id=ContentPlaceHolder1_UC_LCN_UPLOAD_FILE_rdl_chk_bsn_1]').attr('checked', false);
            }
            //alert("Radio button " + inputValue + " is selected");
        });

    });
</script>
<div id="spinner" style="background-color: transparent; display: none;">
    <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
<div style="width: 100%; text-align: left">
</div>
<h3>อัพโหลดเอกสาร</h3>
<div>
    <div id="chk_type_person">
        <div class="row">
            <div class="col-lg-11" style="padding-left: 2em">
                <label id="lbl_person_type1" runat="server">
                    <input type="radio" name="colorCheckbox" id="rdl_person_type1" runat="server"
                        value="1">
                    บุคคลธรรมดา</label>
                <label id="lbl_person_type2" runat="server">
                    <input type="radio" name="colorCheckbox" id="rdl_person_type2" runat="server"
                        value="2">
                    บุคคลธรรมดา(สัญชาติอื่นๆ)</label>
                <label id="lbl_person_type3" runat="server">
                    <input type="radio" name="colorCheckbox" id="rdl_person_type3" runat="server"
                        value="3">
                    นิติบุคคล(สัญชาติไทย)</label>
                <label id="lbl_person_type4" runat="server">
                    <input type="radio" name="colorCheckbox" id="rdl_person_type4" runat="server"
                        value="4">
                    นิติบุคคล(สัญชาติอื่นๆ) กรณีจดทะเบียนในไทย</label>
                <label id="lbl_person_type5" runat="server">
                    <input type="radio" name="colorCheckbox" id="rdl_person_type5" runat="server"
                        value="5">
                    นิติบุคคล(สัญชาติอื่นๆ) กรณีไม่จดทะเบียนในไทย</label>

                <br />
            </div>
        </div>
    </div>
    <hr />
    <div id="show_local_div" class="9 myDiv2" runat="server">
        <div class="row">
            <div class="col-lg-10" style="padding-left: 4em">
                <asp:RadioButtonList ID="rdl_chk_local" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="Black">
                    <asp:ListItem Value="10">กรณีที่ผู้ขอรับอนุญาตเป็นเจ้าของกรรมสิทธิ์</asp:ListItem>
                    <asp:ListItem Value="11">กรณีที่ผู้ขอรับอนุญาตไม่ได้เป็นเจ้าของกรรมสิทธิ์</asp:ListItem>
                    <asp:ListItem Value="12">กรณีทะเบียนบ้านไม่มีผู้อยู่อาศัย (ทะเบียนบ้านลอย) </asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
    </div>

    <div class="8 myDiv3" id="show_bsn_div" runat="server">
        <asp:Panel ID="Panel2" runat="server">
            <div class="row">
                <div class="col-lg-8" style="padding-left: 4em">
                    <asp:RadioButtonList ID="rdl_chk_bsn" runat="server">

                        <asp:ListItem Value="66">ผู้รับมอบอำนาจ ยื่นเรื่องแทนผู้ดำเนินกิจการสัญชาติไทย</asp:ListItem>
                        <%-- ผู้ดำเนินกิจการยื่นเอง --%>
                        <asp:ListItem Value="77">ผู้ได้รับมอบอำนาจ ยื่นเรื่องแทนผู้ดำเนินกิจการที่เป็นบุคคลต่างด้าว</asp:ListItem>
                        <%-- ผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการเป็นบุคคลต่างด้าว --%>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:Panel>
    </div>

    <div class="row">
        <div class="col-lg-8" style="padding-left: 2em">
            <asp:Button ID="btn_select_typeatt" runat="server" Text="เลือก" CssClass="btn-sm" />
        </div>

    </div>
    <div class="row">
        <div class="col-lg-8" style="padding-left: 2em">
            <h3>รายการเอกสารแนบ
            </h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-10" style="padding-left: 4em">
            <span style="font-size: 16px; color: red;">ในขั้นตอนการแนบไฟล์นี้ ท่านสามารถแนบไฟล์และอัพโหลดไฟล์แนบไปทีละหัวข้อได้โดยไม่จำเป็นต้องแนบไฟล์ทั้งหมด แล้วกดยืนยันไฟล์แนบทีเดียว ทั้งนี้ หากทั้งไม่สามารถแนบไฟล์ทั้งหมดให้ครบในครั้งเดียวได้ ท่านสามารถยืนยันไฟล์แนบเฉพาะหัวข้อที่ท่านแนบไฟล์แล้ว และสามารถมาแนบไฟล์เพิ่มต่อในภายหลัง
            </span>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12" style="text-align: right">
            <asp:Button ID="btn_save" runat="server" Text="อัพโหลดเอกสาร" CssClass="btn-sm" OnClientClick="return confirm('กรุณาตรวจสอบความถูกต้องของเอกสารก่อนกด ยืนยัน');" />
        </div>

    </div>

    <div>
        <div style="overflow-x: scroll; height: 550px">
            <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
        </div>
    </div>

</div>

