<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_UPLOAD_FILE.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_UPLOAD_FILE" %>
<%@ Register Src="~/UC/UC_ATTACH_LCN.ascx" TagPrefix="uc1" TagName="UC_ATTACH_LCN" %>


<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>
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

    $(document).ready(function () {
        $('input[type="radio"]').click(function () {
            var inputValue = $(this).attr("value");
            var targetBox = $("." + inputValue);
            var targetBox6 = $("." + inputValue);
            var targetBox2 = $("." + 9);
            var targetBox3 = $("." + 8);
            var targetBox4 = $("." + 111);
            if (inputValue < 10) {
                $(".myDiv").not(targetBox).hide();
                $(targetBox).show();
                $(".myDiv2").not(targetBox2).hide();
                $(targetBox2).show();
                $(".myDiv4").not(targetBox4).hide();
                $(targetBox4).show();
                if (inputValue > 2 && inputValue < 6) {
                    $(".myDiv3").not(targetBox3).hide();
                    $(targetBox3).show();
                }
                if (inputValue < 3) {
                    document.getElementById('sub_menu2').style.display = "none";           
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

            //alert("Radio button " + inputValue + " is selected");myDiv2
        });

    });

    //$(function () {
    //    $("#chk1_1").click(function () {
    //        if ($(this).is(":checked")) {
    //            $("#dvup1").show();
    //        } else {
    //            $("#dvup1").hide();
    //        }
    //    });
    //});
</script>
<div id="spinner" style="background-color: transparent; display: none;">
    <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
<div style="width: 100%; text-align: left">
</div>
<h3>อัพโหลดเอกสาร</h3>
<div id="body">
    <div id="chk_type_person">
        <div class="row">
            <div class="col-lg-11" style="padding-left: 2em">

                <label id="lbl_person_type1" runat="server">
                <input type="radio" name="colorCheckbox"  id="rdl_person_type1" runat="server"
                       value="1"> บุคคลธรรมดา</label>
                <label id="lbl_person_type2" runat="server">
                <input type="radio" name="colorCheckbox"  id="rdl_person_type2" runat="server"
                       value="2"> บุคคลธรรมดา(สัญชาติอื่นๆ)</label>
                <label id="lbl_person_type3" runat="server">
                <input type="radio" name="colorCheckbox"  id="rdl_person_type3" runat="server"
                       value="3"> นิติบุคคล(สัญชาติไทย)</label>
                <label id="lbl_person_type4" runat="server">
                <input type="radio" name="colorCheckbox"  id="rdl_person_type4" runat="server"
                       value="4"> นิติบุคคล(สัญชาติอื่นๆ) กรณีจดทะเบียนในไทย</label>
                <label id="lbl_person_type5" runat="server">
                 <input type="radio" name="colorCheckbox"  id="rdl_person_type5" runat="server"
                       value="5"> นิติบุคคล(สัญชาติอื่นๆ) กรณีไม่จดทะเบียนในไทย</label>

                <br />

                <%--<asp:RadioButtonList ID="rdl_person_type" name='lom' runat="server" BackColor="White" BorderColor="White" BorderStyle="None" CssClass="auto-style1" ForeColor="Black" Height="209px" Width="431px" onclick="ShowHideDiv_1()">
                    <asp:ListItem Value="1">บุคคลธรรมดา</asp:ListItem>
                    <asp:ListItem Value="2">บุคคลธรรมดา(สัญชาติอื่นๆ) </asp:ListItem>
                    <asp:ListItem Value="3">นิติบุคคล(สัญชาติไทย)</asp:ListItem>
                    <asp:ListItem Value="4">นิติบุคคล(สัญชาติอื่นๆ) กรณีจดทะเบียนในไทย</asp:ListItem>
                    <asp:ListItem Value="5">นิติบุคคล(สัญชาติอื่นๆ) กรณีไม่จดทะเบียนในไทย</asp:ListItem>
                </asp:RadioButtonList>--%>
            </div>
        </div>
    </div>
    <hr />
    <%-----------------------------------------------------------((_Panel_))-------------------------------------------------------------------%>





    <div>
        <div id="show_1_1" class="9 myDiv2">
            <div class="row">
                <div class="col-lg-10" style="padding-left: 4em">
                    <asp:RadioButtonList ID="rdl_chk_local" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="Black">
                        <asp:ListItem Value="11">กรณีที่ผู้ขอรับอนุญาตไม่ได้เป็นเจ้าของกรรมสิทธิ์</asp:ListItem>
                        <asp:ListItem Value="12">กรณีทะเบียนบ้านไม่มีผู้อยู่อาศัย (ทะเบียนบ้านลอย) ใช้เอกสารอย่างใดอย่างหนึ่ง ดังนี้ </asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="11 sub_mydiv" id="testdv">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    สำเนาทะเบียนบ้านของสถานที่ผลิต/นำเข้า/ขายผลิตภัณฑ์สมุนไพร
                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_NO1" />
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    หนังสือยินยอมให้ใช้สถานที่ (ฉบับจริง) หรือ สำเนาสัญญาเช่าสถานที่

                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_NO1_1" />
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    กรณีผู้ยินยอมให้ใช้สถานที่หรือผู้ให้เช่าเป็นบุคคลธรรมดา ให้แนบสำเนาบัตรประจำตัวประชาชนผู้ยินยอมให้ใช้สถานที่ และเซ็นต์รับรองสำเนาถูกต้อง

                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_NO1_2" />
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    กรณีผู้ยินยอมให้ใช้สถานที่หรือผู้ให้เช่าเป็นนิติบุคคล ให้แนบหนังสือรับรองการจดทะเบียนนิติบุคคล พร้อมสำเนาบัตรประชาชนกรรมการผู้มีอำนาจตามหนังสือรับรองบริษัทและเซ็นต์รับรองสำเนาถูกต้อง

                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_NO1_3" />
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    กรณีนามสกุลเดียวกันหรือสามีภรรยาจดทะเบียนสมรส ถูกต้องตามกฎหมาย ต้องมีหนังสือยินยอมให้ใช้สถานที่ (ฉบับจริง) พร้อมสำเนาบัตรประชาชนผู้ยินยอมให้ใช้สถานที่และเซ็นต์รับรองสำเนาถูกต้อง (กรณีสามีภรรยาเพิ่มเอกสารสำเนาทะเบียนสมรส)

                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_NO1_4" />
                </div>
            </div>
            <hr />
        </div>

        <div class="12 sub_mydiv">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    สำเนาสัญญาซื้อขาย สิ่งปลูกสร้าง หรือ สำเนาใบอนุญาตก่อสร้าง หรือ สำเนาเอกสารอ้างกรรมสิทธิ์ เช่น ใบเสร็จชำระค่าน้ำ ค่าไฟ
                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_NO2" />
                </div>
            </div>
        </div>
    </div>



    <div>
        <div class="8 myDiv3" id="sub_menu2">
            <asp:Panel ID="Panel2" runat="server">
                <div class="row">
                    <div class="col-lg-8" style="padding-left: 4em">
                        <asp:RadioButtonList ID="rdl_chk_bsn" runat="server">
                            <asp:ListItem Value="66">ผู้ดำเนินกิจการยื่นเอง</asp:ListItem>
                            <asp:ListItem Value="77">ผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการเป็นบุคคลต่างด้าว</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </asp:Panel>

            <div id="show_bsnDiv" class="66 sub_mydiv2">
                <hr />
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-8">
                        ใบรับรองแพทย์ตัวจริงของผู้ดำเนินกิจการ (คนใหม่) (ต้องไม่เกิน 3 เดือน)
                    </div>
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_BSN1" />
                    </div>
                </div>
                <hr />
            </div>
            <div id="show_bsnDiv2" class="77 sub_mydiv2">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-8">
                        ใบสำคัญถิ่นที่อยู่/ใบอนุญาตทำงาน (Work Permit) หรือ ใบอนุญาตประกอบธุรกิจตามบัญชีสาม (14) หรือ (15) หรือ  หนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว
                    </div>
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_BSN2" />
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-8">
                        ใบรับรองแพทย์ตัวจริงของผู้ดำเนินกิจการ (คนใหม่) (ต้องไม่เกิน 3 เดือน)
                    </div>
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_BSN2_2" />
                    </div>
                </div>
                <hr />
            </div>
        </div>
    </div>

    <asp:Panel ID="Panel1" runat="server" Style="display: none;">
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                สำเนาใบทะเบียนการค้าหรือใบทะเบียนพาณิชย์(ถ้ามี)
                
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN7" />
            </div>
        </div>


        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                ใบรับรองแพทย์ตัวจริงของผู้รับอนุญาต(ต้องไม่เกิน 3 เดือน)
                <br />
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: พร้อมระบุ 5 โรคต้องห้ามเป็น ของผู้รับอนุญาตเกี่ยวกับผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๓ ดังต่อไปนี้ (1) โรคเรื้อน (2) วัณโรคในระยะอันตราย (3) โรคเท้าช้าง (4) โรคติดยาเสพติดให้โทษ (5) โรคพิษสุราเรื้อรัง</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN8" />
            </div>
        </div>
        <hr />

    </asp:Panel>

    <div id="show_1" class="1 myDiv">
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                สำเนาใบทะเบียนการค้าหรือใบทะเบียนพาณิชย์(ถ้ามี)
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_1_1" />
            </div>
        </div>


        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                ใบรับรองแพทย์ตัวจริงของผู้รับอนุญาต(ต้องไม่เกิน 3 เดือน)
                <br />
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: พร้อมระบุ 5 โรคต้องห้ามเป็น ของผู้รับอนุญาตเกี่ยวกับผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๓ ดังต่อไปนี้ (1) โรคเรื้อน (2) วัณโรคในระยะอันตราย (3) โรคเท้าช้าง (4) โรคติดยาเสพติดให้โทษ (5) โรคพิษสุราเรื้อรัง</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_1_2" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                ภาพถ่าย (ภาพสี) จำนวน 1 ฉบับ (ตามแบบฟอร์มรูปภาพที่กำหนด)
                <br />
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: แสดงให้เห็นภาพลักษณะของอาคารสถานที่ พื้นที่และเครื่องมือ/อุปกรณ์ต่าง ๆ ทั้งภายใน-ภายนอกอาคาร หมายเหตุ รูปถ่าย อัดจากร้านอัดรูป หรือใช้กระดาษโฟโต้ 4*6 นิ้ว เท่านั้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_1_3" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แบบแปลนแผนผังสิ่งปลูกสร้างภายในบริเวณสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร
                <br />
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: โดยกำหนดรายละเอียดและอธิบายพื้นที่ของบริเวณที่จัดให้เป็นสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร ให้จัดเจน</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_1_4" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แผนที่ที่ตั้งและพิกัดของสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร(ถ้ามี)
                <br />
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: และสิ่งปลูกสร้างบริเวณใกล้เคียง โดยแสดงชื่อถนนและจุดสังเกตของสถานที่ขออนุญาต เช่น หน่วยราชการ วัด โรงเรียน เป็นต้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_1_5" />
            </div>
        </div>

        <hr />
    </div>




    <div id="show_2" class="2 myDiv">
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">ใบอนุญาตทำงาน (Work Permit) หรือ ใบอนุญาตประกอบธุรกิจตามบัญชีสาม (14) หรือ (15) หรือ </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_2_1" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">หนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_2_2" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                ภาพถ่าย (ภาพสี) จำนวน 1 ฉบับ (ตามแบบฟอร์มรูปภาพที่กำหนด)
             <br />
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: แสดงให้เห็นภาพลักษณะของอาคารสถานที่ พื้นที่และเครื่องมือ/อุปกรณ์ต่าง ๆ ทั้งภายใน-ภายนอกอาคาร หมายเหตุ รูปถ่าย อัดจากร้านอัดรูป หรือใช้กระดาษโฟโต้ 4*6 นิ้ว เท่านั้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_2_3" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แบบแปลนแผนผังสิ่งปลูกสร้างภายในบริเวณสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร
            <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: โดยกำหนดรายละเอียดและอธิบายพื้นที่ของบริเวณที่จัดให้เป็นสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร ให้จัดเจน</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_2_4" />
            </div>
        </div>

        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แผนที่ที่ตั้งและพิกัดของสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร(ถ้ามี)
            <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: และสิ่งปลูกสร้างบริเวณใกล้เคียง โดยแสดงชื่อถนนและจุดสังเกตของสถานที่ขออนุญาต เช่น หน่วยราชการ วัด โรงเรียน เป็นต้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_2_5" />
            </div>
        </div>
        <hr />

    </div>

    <div id="show_3" class="3 myDiv">
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                สำเนาหนังสือบัญชีรายชื่อผู้ถือหุ้น (บอจ.5)
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: โดยต้องมีครบทุกหน้าและคัดลอกสำเนาจากกระทรวงพาณิชย์ไว้ไม่เกิน 6 เดือน (ยกเว้นห้างหุ้นส่วนจำกัด/ห้างหุ้นส่วนสามัญจะไม่มีเอกสารนี้)</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_3_1" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                ภาพถ่าย (ภาพสี) จำนวน 1 ฉบับ (ตามแบบฟอร์มรูปภาพที่กำหนด)
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: แสดงให้เห็นภาพลักษณะของอาคารสถานที่ พื้นที่และเครื่องมือ/อุปกรณ์ต่าง ๆ ทั้งภายใน-ภายนอกอาคาร หมายเหตุ รูปถ่าย อัดจากร้านอัดรูป หรือใช้กระดาษโฟโต้ 4*6 นิ้ว เท่านั้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_3_2" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แบบแปลนแผนผังสิ่งปลูกสร้างภายในบริเวณสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: โดยกำหนดรายละเอียดและอธิบายพื้นที่ของบริเวณที่จัดให้เป็นสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร ให้จัดเจน</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_3_3" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แผนที่ที่ตั้งและพิกัดของสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร(ถ้ามี)
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: และสิ่งปลูกสร้างบริเวณใกล้เคียง โดยแสดงชื่อถนนและจุดสังเกตของสถานที่ขออนุญาต เช่น หน่วยราชการ วัด โรงเรียน เป็นต้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_3_4" />
            </div>
        </div>
        <hr />
    </div>



    <div id="show_4" class="4 myDiv">
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                สำเนาหนังสือบัญชีรายชื่อผู้ถือหุ้น (บอจ.5)
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: โดยต้องมีครบทุกหน้าและคัดลอกสำเนาจากกระทรวงพาณิชย์ไว้ไม่เกิน 6 เดือน (ยกเว้นห้างหุ้นส่วนจำกัด/ห้างหุ้นส่วนสามัญจะไม่มีเอกสารนี้)</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_4_1" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                ใบอนุญาตประกอบธุรกิจตามบัญชีสาม (14) หรือ (15) หรือ  หนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว 
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_4_2" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                ภาพถ่าย (ภาพสี) จำนวน 1 ฉบับ (ตามแบบฟอร์มรูปภาพที่กำหนด)
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: แสดงให้เห็นภาพลักษณะของอาคารสถานที่ พื้นที่และเครื่องมือ/อุปกรณ์ต่าง ๆ ทั้งภายใน-ภายนอกอาคาร หมายเหตุ รูปถ่าย อัดจากร้านอัดรูป หรือใช้กระดาษโฟโต้ 4*6 นิ้ว เท่านั้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_4_3" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แบบแปลนแผนผังสิ่งปลูกสร้างภายในบริเวณสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: โดยกำหนดรายละเอียดและอธิบายพื้นที่ของบริเวณที่จัดให้เป็นสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร ให้จัดเจน</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_4_4" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แผนที่ที่ตั้งและพิกัดของสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร(ถ้ามี)
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: และสิ่งปลูกสร้างบริเวณใกล้เคียง โดยแสดงชื่อถนนและจุดสังเกตของสถานที่ขออนุญาต เช่น หน่วยราชการ วัด โรงเรียน เป็นต้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_4_5" />
            </div>
        </div>
        <hr />
    </div>

    <div id="show_5" class="5 myDiv">
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แนบเอกสารหลักฐานอื่น ๆ ที่เกี่ยวข้อง
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: เอกสารที่ยืนยันเกี่ยวข้องเกี่ยวกับการจัดทะเบียนที่ประเทศของตน</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_5_1" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                ภาพถ่าย (ภาพสี) จำนวน 1 ฉบับ (ตามแบบฟอร์มรูปภาพที่กำหนด)
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: แสดงให้เห็นภาพลักษณะของอาคารสถานที่ พื้นที่และเครื่องมือ/อุปกรณ์ต่าง ๆ ทั้งภายใน-ภายนอกอาคาร หมายเหตุ รูปถ่าย อัดจากร้านอัดรูป หรือใช้กระดาษโฟโต้ 4*6 นิ้ว เท่านั้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_5_2" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แบบแปลนแผนผังสิ่งปลูกสร้างภายในบริเวณสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: โดยกำหนดรายละเอียดและอธิบายพื้นที่ของบริเวณที่จัดให้เป็นสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร ให้จัดเจน</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_5_3" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                แผนที่ที่ตั้งและพิกัดของสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร(ถ้ามี)
                <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: และสิ่งปลูกสร้างบริเวณใกล้เคียง โดยแสดงชื่อถนนและจุดสังเกตของสถานที่ขออนุญาต เช่น หน่วยราชการ วัด โรงเรียน เป็นต้น</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_5_4" />
            </div>
        </div>
        <hr />
    </div>




    <%--<asp:Button ID="BTN_UPLOAD_PART1" runat="server" Text="อัพโหลด" CssClass=" btn-lg" />--%>

    <div class="111 myDiv4">
        <asp:Panel ID="Panel_posormo" runat="server" Style="display: none;">
            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">สำเนาแบบแปลนที่ได้รับการอนุมัติแล้วจาก อย.</div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_PSM1" />
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">บันทึกผลการตรวจสถานที่</div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_PSM2" />
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">รายการเกี่ยวกับระบบการกำจัดน้ำเสีย การกำจัดสิ่งปฏิกูลและมูลฝอย ระบบควบคุมอากาศ ระบบน้ำที่ใช้ในการผลิต (เฉพาะกรณีขออนุญาตประกอบกิจการผลิตผลิตภัณฑ์สมุนไพร)</div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_PSM3" />
                </div>
            </div>
            <hr />
        </asp:Panel>
    </div>

    <div class="row">
        <div class="col-lg-12" style="text-align: right">
            <asp:Button ID="BTN_UPLOAD" runat="server" Text="อัพโหลดเอกสาร" CssClass=" btn-lg" OnClientClick="return confirm('กรุณาตรวจสอบความถูกต้องของเอกสารก่อนกด ยืนยัน');" />
        </div>

    </div>
</div>
