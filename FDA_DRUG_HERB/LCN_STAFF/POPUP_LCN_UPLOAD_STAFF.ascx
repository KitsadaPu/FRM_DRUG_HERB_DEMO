<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="POPUP_LCN_UPLOAD_STAFF.ascx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_UPLOAD_STAFF" %>
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
        <div>
            <div class="row">
                <div class="col-lg-3">
                   <h4> 1. ประเภทบุคคล</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-7" style="padding-left: 2em">
                    <asp:RadioButtonList ID="rdl_person_type" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="1">บุคคลธรรมดา</asp:ListItem>
                        <asp:ListItem Value="2">บุคคลธรรมดา(สัญชาติอื่นๆ) </asp:ListItem>
                        <asp:ListItem Value="3">นิติบุคคล(สัญชาติไทย)</asp:ListItem>
                        <asp:ListItem Value="4">นิติบุคคล(สัญชาติอื่นๆ) กรณีจดทะเบียนในไทย</asp:ListItem>
                        <asp:ListItem Value="5">นิติบุคคล(สัญชาติอื่นๆ) กรณีไม่จดทะเบียนในไทย</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <%-----------------------------------------------------------((_Panel_))-------------------------------------------------------------------%>
            <div>
                <asp:Panel ID="Panel1" runat="server" Style="display: none;">
                    <hr />
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-8">
                            1. สำเนาใบทะเบียนการค้าหรือใบทะเบียนพาณิชย์(ถ้ามี)
                
                        </div>
                        <div class="col-lg-3">
                            <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_1" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-8">
                            2. ใบรับรองแพทย์ตัวจริงของผู้รับอนุญาต(ต้องไม่เกิน 3 เดือน)
                <br />
                            <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: พร้อมระบุ 5 โรคต้องห้ามเป็น ของผู้รับอนุญาตเกี่ยวกับผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๓ ดังต่อไปนี้ (1) โรคเรื้อน (2) วัณโรคในระยะอันตราย (3) โรคเท้าช้าง (4) โรคติดยาเสพติดให้โทษ (5) โรคพิษสุราเรื้อรัง</p>
                        </div>
                        <div class="col-lg-3">
                            <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_2" />
                        </div>
                    </div>
                    <hr />
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Style="display: none;">
                    <hr />
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-8">1. ใบอนุญาตทำงาน(Work Permit) หรือใบอนุญาตประกอบธุรกิจตามบัญชีสาม (14) หรือ (15)</div>
                        <div class="col-lg-3">
                            <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_3" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-8">2. หนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</div>
                        <div class="col-lg-3">
                            <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_4" />
                        </div>
                    </div>
                    <hr />
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" Style="display: none;">
                    <hr />
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-8">
                            1. สำเนาหนังสือบัญชีรายชื่อผู้ถือหุ้น(บอจ.5)
                 <br />
                            <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: โดยต้องมีครบทุกหน้าและคัดลอกสำเนาจากกระทรวงพาณิชย์ไว้ไม่เกิน 6 เดือน(ยกเว้นห้างหุ้นส่วนจำกัด/ห้างหุ้นส่วนสามัญจะไม่มีเอกสารนี้)</p>
                        </div>
                        <div class="col-lg-3">
                            <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_5" />
                        </div>
                    </div>
                    <hr />
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" Style="display: none;">
                    <hr />
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-8">
                            1. สำเนาหนังสือบัญชีรายชื่อผู้ถือหุ้น(บอจ.5)
                <br />
                            <p style="font-size: 12px; padding-left: 2em">&nbsp;&nbsp;หมายเหตุ: โดยต้องมีครบทุกหน้าและคัดลอกสำเนาจากกระทรวงพาณิชย์ไว้ไม่เกิน 6 เดือน(ยกเว้นห้างหุ้นส่วนจำกัด/ห้างหุ้นส่วนสามัญจะไม่มีเอกสารนี้)</p>
                        </div>
                        <div class="col-lg-3">
                            <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_6" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-8">2. ใบอนุญาตประกอบธุรกิจตามบัญชีสาม (14) หรือ (15) หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</div>
                        <div class="col-lg-3">
                            <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_7" />
                        </div>
                    </div>
                    <hr />
                </asp:Panel>
                <asp:Panel ID="Panel5" runat="server" Style="display: none;">
                    <hr />
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-8">
                            1. แนบเอกสารหลักฐานอื่นๆที่เกี่ยวข้อง
                <br />
                            <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: เอกสารที่ยืนยันเกี่ยวข้องเกี่ยวกับการจัดทะเบียนที่ประเทศของตน(5) โรคพิษสุราเรื้อรัง</p>
                        </div>
                        <div class="col-lg-3">
                            <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_8" />
                        </div>
                    </div>
                    <hr />
                </asp:Panel>

                <div class="row">
                    <div class="col-lg-12" style="text-align: right">
                        <%--<asp:Button ID="BTN_UPLOAD_PART1" runat="server" Text="อัพโหลดเอกสารส่วนที่ 1" CssClass=" btn-lg" />--%>
                    </div>

                </div>
                <hr />

                <%--<asp:Button ID="BTN_UPLOAD_PART1" runat="server" Text="อัพโหลด" CssClass=" btn-lg" />--%>
            </div>
            <%-----------------------------------------------------------((_Panel_))-------------------------------------------------------------------%>
        </div>
        <div>
            <div class="row">
                <div class="col-lg-3">
                    <h4>2. ประเภทผู้ดำเนิน</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-7" style="padding-left: 2em">
                    <asp:RadioButtonList ID="rdl_bsn_type" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="1">ผู้ดำเนินกิจการยื่นเอง</asp:ListItem>
                        <asp:ListItem Value="2">ผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการเป็นบุคคลต่างด้าว</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>

            <%-----------------------------------------------------------((_Panel_6_))-------------------------------------------------------------------%>
            <asp:Panel ID="Panel6" runat="server" Style="display: none;">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-8">
                        1. ใบรับรองแพทย์ตัวจริงของผู้ดำเนินกิจการ(คนใหม่)(ต้องไม่เกิน 3 เดือน)
                <br />
                        <p style="font-size: 12px; padding-left: 2em">&nbsp;&nbsp;หมายเหตุ: พร้อมระบุ 5 โรคต้องห้ามเป็นของผู้รับอนุญาตเกี่ยวกับผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๓ ดังต่อไปนี้ (1)โรคเรื้อน (2)วัณโรคในระยะอันตราย (3)โรคเท้าช้าง (4)โรคติดยาเสพติดให้โทษ (5)โรคพิษสุราเรื้อรัง</p>
                    </div>
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_9" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel7" runat="server" Style="display: none;">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-8">
                        1. ใบสำคัญถิ่นที่อยู่/ใบอนุญาตทำงาน (Work Permit) หรือใบอนุญาตประกอบธุรกิจตามบัญชีสาม (14) หรือ (15) หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว
                    </div>
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_10" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-8">
                        2. ใบรับรองแพทย์ตัวจริงของผู้ดำเนินกิจการ(คนใหม่)(ต้องไม่เกิน 3 เดือน)
                <br />
                        <p style="font-size: 12px; padding-left: 2em">&nbsp;&nbsp;หมายเหตุ: พร้อมระบุ 5 โรคต้องห้ามเป็นของผู้รับอนุญาตเกี่ยวกับผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๓ ดังต่อไปนี้ (1)โรคเรื้อน (2)วัณโรคในระยะอันตราย (3)โรคเท้าช้าง (4)โรคติดยาเสพติดให้โทษ (5)โรคพิษสุราเรื้อรัง</p>
                    </div>
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_11" />
                    </div>
                </div>
            </asp:Panel>
            <%-----------------------------------------------------------((_Panel_2__))-------------------------------------------------------------------%>
            <div class="row">
                <div class="col-lg-12" style="text-align: right">
                    <%--<asp:Button ID="BTN_UPLOAD_PART2" runat="server" Text="อัพโหลดเอกสารส่วนที่ 2" CssClass=" btn-lg" />--%>
                </div>

            </div>
            <hr />


            <%--<asp:Button ID="BTN_UPLOAD_PART2" runat="server" Text="อัพโหลด" CssClass=" btn-lg" />--%>
        </div>

        <div>
            <div class="row">
                <div class="col-lg-10">
                    <h4>3. เอกสารที่เกี่ยวข้องของสถานที่ผลิต/นำเข้า/ขายผลิตภัณฑ์สมุนไพร และสถานที่เก็บ (ถ้ามี) ดังต่อไปนี้อย่างละ 1 ฉบับมุนไพร และสถานที่เก็บ (ถ้ามี) ดังต่อไปนี้อย่างละ 1 ฉบับ</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    1. ภาพถ่าย (ภาพสี) จำนวน 1 ฉบับ (ตามแบบฟอร์มรูปภาพที่กำหนด)
                <br />
                    <p style="font-size: 12px; padding-left: 2em">หมายเหตุ: แสดงให้เห็นภาพลักษณะของอาคารสถานที่ พื้นที่และเครื่องมือ/อุปกรณ์ต่าง ๆ ทั้งภายใน-ภายนอกอาคาร หมายเหตุ รูปถ่าย อัดจากร้านอัดรูป หรือใช้กระดาษโฟโต้ 4*6 นิ้ว เท่านั้น</p>
                </div>
                <div class="col-lg-2">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_12" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    2. แบบแปลนแผนผังสิ่งปลูกสร้างภายในบริเวณสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร
                 <p style="font-size: 12px; padding-left: 2em">โดยกำหนดรายละเอียดและอธิบายพื้นที่ของบริเวณที่จัดให้เป็นสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร ให้จัดเจน</p>
                </div>
                <div class="col-lg-2">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_13" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    3. แผนที่ที่ตั้งและพิกัดของสถานที่ผลิต นำเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร(ถ้ามี)
       และสิ่งปลูกสร้างบริเวณใกล้เคียง โดยแสดงชื่อถนนและจุดสังเกตของสถานที่ขออนุญาต เช่น หน่วยราชการ วัด โรงเรียน เป็นต้น
                </div>
                <div class="col-lg-2">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_14" />
                </div>
                <div class="row">
                    <div class="col-lg-12" style="text-align: right">
                        <%--<asp:Button ID="BTN_UPLOAD_PART3" runat="server" Text="อัพโหลดเอกสารส่วนที่ 3" CssClass=" btn-lg" />--%>
                    </div>

                </div>
                <hr />



                <%--<asp:Button ID="BTN_UPLOAD_PART3" runat="server" Text="อัพโหลด" CssClass=" btn-lg" />--%>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-10">
                <h4>4. เอกสารที่เกี่ยวข้องของสถานที่ ดังต่อไปนี้ อย่างละ 1 ฉบับ</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
                เอกสารแสดงกรรมสิทธิ์หรือสิทธิครอบครองของผู้ขออนุญาตในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร(สำเนาทะเบียนบ้านของสถานที่ตั้ง)</div>
        </div>
        <%-----------------------------------------------------------((_Panel_8_))-------------------------------------------------------------------%>
        <asp:Panel ID="Panel8" runat="server" Style="display: block;">
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                     <asp:CheckBox ID="CheckBox1" Text="เอกสารแสดงกรรมสิทธิ์หรือสิทธิครอบครองของผู้ขออนุญาตในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร(สำเนาทะเบียนบ้านของสถานที่ตั้ง)" runat="server" />
                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_15" />
                </div>
            </div>
        </asp:Panel>
        <%-----------------------------------------------------------((_Panel_8E_))-------------------------------------------------------------------%>
        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
               กรณีที่ผู้ขอรับอนุญาตไม่ได้เป็นเจ้าของกรรมสิทธิ์
            </div>
        </div>
        <%-----------------------------------------------------------((_Panel_9_))-------------------------------------------------------------------%>
        <asp:Panel ID="Panel9" runat="server" Style="display: block;">
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    <asp:CheckBox ID="CheckBox2" Text="สำเนาทะเบียนบ้านของสถานที่ผลิต/นำเข้า/ขายผลิตภัณฑ์สมุนไพร" runat="server" />
                </div>
                <asp:Panel ID="Panel12" runat="server" Style="display: none;">
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_16" />
                    </div>
                </asp:Panel>
            </div>
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    <asp:CheckBox ID="CheckBox2_2" Text="หนังสือยินยอมให้ใช้สถานที่(ฉบับจริง) หรือ สำเนาสัญญาเช่าสถานที่" runat="server" />
                </div>
                <asp:Panel ID="Panel13" runat="server" Style="display: block;">
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_17" />
                    </div>
                </asp:Panel>
            </div>
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    <asp:CheckBox ID="CheckBox2_3" Text="กรณีผู้ยินยอมให้ใช้สถานที่หรือผู้ให้เช่าเป็นบุคคลธรรมดา ให้แนบสำเนาบัตรประจำตัวประชาชนผู้ยินยอมให้ใช้สถานที่ และเซ็นต์รับรองสำเนาถูกต้อง" runat="server" />
                </div>
                <asp:Panel ID="Panel14" runat="server" Style="display: block;">
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_18" />
                    </div>
                </asp:Panel>
            </div>
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    <asp:CheckBox ID="CheckBox2_4" Text="กรณีผู้ยินยอมให้ใช้สถานที่หรือผู้ให้เช่าเป็นนิติบุคคล ให้แนบหนังสือรับรองการจดทะเบียนนิติบุคคล พร้อมสำเนาบัตรประชาชนกรรมการผู้มีอำนาจตามหนังสือรับรองบริษัทและเซ็นต์รับรองสำเนาถูกต้อง" runat="server" />
                </div>
                <asp:Panel ID="Panel15" runat="server" Style="display: block;">
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_19" />
                    </div>
                </asp:Panel>
            </div>

            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    <asp:CheckBox ID="CheckBox2_5" Text="กรณีนามสกุลเดียวกันหรือสามีภรรยาจดทะเบียนสมรส ถูกต้องตามกฎหมาย ต้องมีหนังสือยินยอมให้ใช้สถานที่(ฉบับจริง) พร้อมสำเนาบัตรประชาชนผู้ยินยอมให้ใช้สถานที่และเซ็นต์รับรองสำเนาถูกต้อง(กรณีสามีภรรยาเพิ่มเอกสารสำเนาทะเบียนสมรส)" runat="server" />
                </div>
                <asp:Panel ID="Panel16" runat="server" Style="display: block;">
                    <div class="col-lg-3">

                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_20" />
                    </div>
                </asp:Panel>
            </div>
        </asp:Panel>
        <%-----------------------------------------------------------((_Panel_9E_))-------------------------------------------------------------------%>

        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
                กรณีทะเบียนบ้านไม่มีผู้อยู่อาศัย(ทะเบียนบ้านลอย) ใช้เอกสารอย่างใดอย่างหนึ่ง ดังนี้
            </div>
        </div>
        <%-----------------------------------------------------------((_Panel_10_))-------------------------------------------------------------------%>
        <asp:Panel ID="Panel10" runat="server" Style="display: block;">
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    <asp:CheckBox ID="CheckBox3" Text="สำเนาสัญญาซื้อขาย สิ่งปลูกสร้าง หรือ สำเนาใบอนุญาตก่อสร้าง หรือ สำเนาเอกสารอ้างกรรมสิทธิ์ เช่น ใบเสร็จชำระค่าน้ำ ค่าไฟ" runat="server" />
                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_21" />
                </div>
            </div>
        </asp:Panel>
        <%-----------------------------------------------------------((_Panel_10E_))-------------------------------------------------------------------%>

        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
               กรณีขอใบอนุญาตผลิตฯ มีเอกสารเพิ่มเติม ดังต่อไปนี้
            </div>

        </div>
        <%-----------------------------------------------------------((_Panel_11_))-------------------------------------------------------------------%>
        <asp:Panel ID="Panel11" runat="server" Style="display: block;">
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    <asp:CheckBox ID="CheckBox4" Text="สำเนาแบบแปลนที่ได้รับการอนุมัติแล้วจาก อย." runat="server" AutoPostBack="True" />
                </div>
                <asp:Panel ID="Panel17" runat="server" Style="display: block;">
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_22" />
                    </div>
                </asp:Panel>
            </div>
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    <asp:CheckBox ID="CheckBox4_2" Text="บันทึกผลการตรวจสถานที่" runat="server" />
                </div>

                <asp:Panel ID="Panel18" runat="server" Style="display: block;">
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_23" />
                    </div>
                </asp:Panel>
            </div>
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    <asp:CheckBox ID="CheckBox4_3" Text="รายการเกี่ยวกับระบบการกำจัดน้ำเสีย การกำจัดสิ่งปฏิกูลและมูลฝอย ระบบควบคุมอากาศ ระบบน้ำที่ใช้ในการผลิต(เฉพาะกรณีขออนุญาตประกอบกิจการผลิตผลิตภัณฑ์สมุนไพร)" runat="server" />
                </div>

                <asp:Panel ID="Panel19" runat="server" Style="display: block;">
                    <div class="col-lg-3">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_24" />
                    </div>
                </asp:Panel>
            </div>
        </asp:Panel>
        <%-----------------------------------------------------------((_Panel_19E_))-------------------------------------------------------------------%>
        <div class="row">
            <div class="col-lg-12" style="text-align: right">
                <%--<asp:Button ID="BTN_UPLOAD_PART4" runat="server" Text="อัพโหลดเอกสารส่วนที่ 4" CssClass=" btn-lg" />--%>
            </div>

        </div>

        <hr />

        <div class="row">
            <div class="col-lg-10">
                <h4>5. เอกสารของผู้มีหน้าที่ปฏิบัติการ</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-5">คำรับรองผู้มีหน้าที่ปฏิบัติการ</div>
            <div class="col-lg-4"></div>
            <div class="col-lg-2">
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9" style="padding-left: 1em">
                <asp:CheckBox ID="CheckBox5" Text="ที่อยู่ปัจจุบันไม่ตรงตามทะเบียนบ้าน" runat="server" AutoPostBack="True" />
            </div>
        </div>
        <asp:Panel ID="Panel20" runat="server" Style="display: none;">
            <hr />
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    สัญญาเช่า
                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_31" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    รูปผู้มีหน้าที่ปฏิบัติการ 1 ชุด
                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_32" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-9" style="padding-left: 4em">
                    ถ่ายผู้มีหน้าที่ปฏิบัติการตัวจริง กับ ป้ายผู้มีหน้าที่ปฏิบัติการที่ซื่อตรงกัน ในสถานที่จริงที่ได้รับอนุญาต
                </div>
                <div class="col-lg-3">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_33" />
                </div>
            </div>
        </asp:Panel>

        <hr />
        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
                สัญญาระหว่างผู้ขออนุญาตและผู้มีหน้าที่ปฏิบัติการ จำนวน 3 ชุด
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_25" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
                ใบรับรองแพทย์ตัวจริงของผู้มีหน้าที่ปฏิบัติการ (ต้องไม่เกิน 3 เดือน) 
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_26" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
                สำเนาใบประกอบวิชาชีพ หรือสำเนาใบประกอบโรคศิลปะ หรือปริญญาบัตร
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_27" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
                สำเนาการผ่านอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา
                <br />
                <p style="font-size: 12px; padding-left: 2em">&nbsp;&nbsp;หมายเหตุ: พร้อมระบุ 5 โรคต้องห้ามเป็นของผู้รับอนุญาตเกี่ยวกับผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๓ ดังต่อไปนี้ (1)โรคเรื้อน (2)วัณโรคในระยะอันตราย (3)โรคเท้าช้าง (4)โรคติดยาเสพติดให้โทษ (5)โรคพิษสุราเรื้อรัง</p>
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_28" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
                สำเนาบัตรประชาชนของผู้มีหน้าที่ปฏิบัติการ
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_29" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9" style="padding-left: 2em">
                สำเนาทะเบียนบ้านของผู้มีหน้าที่ปฏิบัติการ
            </div>
            <div class="col-lg-3">
                <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN_30" />
            </div>
        </div>



        <div class="row">
            <div class="col-lg-12" style="text-align: right">
                <%--<asp:Button ID="BTN_UPLOAD_PART5" runat="server" Text="อัพโหลดเอกสารส่วนที่ 5" CssClass=" btn-lg" />--%>
            </div>

        </div>

        <hr />
    </div>