<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_AUDIT_IN_DETAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_AUDIT_IN_DETAIL" %>

<style type="text/css">
</style>
<script type="text/javascript">
    //$(document).ready(function () {
    //    showdate($("#ContentPlaceHolder1_UC_PHR_DETAIL_txt_Write_Date"));
    //    $("#ContentPlaceHolder1_UC_PHR_DETAIL_txt_Write_Date").searchable();
    //});
    //$(document).ready(function () {
    //    showdate($("ContentPlaceHolder1_UC_PHR_DETAIL_phr_date_num"));
    //    $("ContentPlaceHolder1_UC_PHR_DETAIL_Siminar_Date").searchable();
    //});

    function spin_space() { // คำสั่งสั่งปิด PopUp
        $('#spinner').toggle('slow');
    }

    function closespinner() {
        $('#spinner').fadeOut('slow');
        alert('Download Success');
        $('#ContentPlaceHolder1_Button1').click();
    }
</script>
<div>
    <form name="form" method="post" align="center;">
        <div class="row">
            <div class="col-lg-12" style="text-align: center;">
                <h3>แบบคำขอให้ตรวจประเมินสถานที่ผลิตผลิตภัณฑ์สมุนไพร</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12" style="text-align: center;">
                <h4>เพื่อขอให้ตรวจประเมินสถานที่ผลิตผลิตภัณฑ์สมุนไพรเพื่อขอหนังสือรับรองมาตรฐานการผลิต</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9"></div>
            <div class="col-lg-1" style="text-align: right;">
                เขียนที่              
            </div>
            <div class="col-lg-1">
                <asp:TextBox ID="Txt_Write_At" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-9"></div>
            <div class="col-lg-1" style="text-align: right;">
                วันที่
            </div>
            <div class="col-lg-1">
                <asp:TextBox ID="txt_Write_Date" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div style="padding-top: 15px"></div>
        <div class="row">
            <div class="col-lg-1"></div>

            <div class="col-lg-1">
                <h4>เรื่อง</h4>
            </div>
            <div class="col-lg-10">
                ขอให้ตรวจประเมินสถานที่ผลิตยาเพื่อหนังสือรับรองมาตรฐานการผลิต
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                <h4>เรียน</h4>
            </div>
            <div class="col-lg-10">
                ผู้อำนวยการกองผลิตภัณฑ์สมุนไพร
            </div>
        </div>


        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ข้าพเจ้า</div>
            <div class="col-lg-8">
                <asp:TextBox ID="txt_Name" runat="server" Width="70%"></asp:TextBox>
                &nbsp; ผู้ดำเนินกิจการ
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-3">ของสถานที่รับอนุญาตผลิตผลิตภัณฑ์สมุนไพร ชื่อสถานที่</div>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_location_name" runat="server" Width="90%"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">เลขที่ใบอนุญาต</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_lcnno_dispaly" runat="server"></asp:TextBox>
            </div>


        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ตั้งอยู่ที่</div>
            <div class="col-lg-8">
                <asp:TextBox ID="txt_location_addr" runat="server" TextMode="MultiLine" Width="70%" Height="60px"></asp:TextBox>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">โทรศัพท์</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_tel" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">โทรสาร</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_fax" runat="server"></asp:TextBox>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">มีความประสงค์จะขอให้เจ้าหน้าที่ตรวจประเมินสถานที่ผลิตผลิตภัณฑ์สมุนไพรเพื่อ</div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="padding-left: 2em">
                <asp:RadioButtonList ID="RDB_CER_PRO" runat="server" RepeatDirection="Vertical" AutoPostBack="true">
                    <asp:ListItem Value="1">&ensp;ขอหนังสือรับรองมาตรฐานการผลิต&ensp;</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;ขอเพิ่มหมวดการผลิตในหนังสือรับรองมาตรฐานการผลิต&ensp;</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="padding-left: 4em">
                <asp:RadioButtonList ID="RDB_SUB_CER_PRO" runat="server" RepeatDirection="Vertical" Enabled="false">
                    <asp:ListItem Value="1">&ensp;ประกาศกระทรวงสาธารณสุข เรื่อง การกำหนดรายละเอียดเกี่ยวกับหลักเกณฑ์และวิธีการในการผลิตยาแผนปัจจุบันและแก้ไขเพิ่มเติมหลักเกณฑ์
                        และวิธีการในการผลิตยาแผนโบราณตามกฎหมายว่าด้วยยา พ.ศ. 2559&ensp;</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;ประกาศกระทรวงสาธารณสุข เรื่อง หลักเกณฑ์ วิธีการ และเงื่อนไขเกี่ยวกับการผลิตผลิตภัณฑ์สมุนไพรตามพระราชบัญญัติผลิตภัณฑ์สมุนไพร พ.ศ. 2562 พ.ศ. 2564&ensp;</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <%--<div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                รายละเอียดตามหมวดการผลิตที่ขอรับรองในแบบคำขอดังกล่าว พร้อมได้แนบหลักฐานประกอบคำขอฯ มาพร้อม
                กับแบบคำขอฉบับนี้แล้ว ได้แก่ <p style="color:red">(*กรรุณาเลือกรายการด้านล่างแล้วกดบันทึก เพื่อแนบไฟล์ในในหน้าถัดไป)</p>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="padding-left: 2em">
                <asp:CheckBoxList ID="CBL_FILE_UP" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="1">&ensp;สำเนาใบอนุญาตผลิตผลิตภัณฑ์สมุนไพร &ensp;</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;ข้อมูลแม่บทสถานที่ผลิตผลิตภัณฑ์สมุนไพร (Site Master File (SMF) &ensp;</asp:ListItem>
                    <asp:ListItem Value="3">&ensp;คู่มือคุณภาพ (Quality Manual) &ensp;</asp:ListItem>
                    <asp:ListItem Value="4">&ensp;บัญชีรายชื่อเอกสารมาตรฐานสำหรับวิธีการปฏิบัติ (List of SOPs) &ensp;</asp:ListItem>
                    <asp:ListItem Value="5">&ensp;ข้อควรระวังในการเข้าสถานที่ผลิต (ถ้ามี) &ensp;</asp:ListItem>
                    <asp:ListItem Value="6">&ensp;อื่นๆ&ensp;</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" visible="false" runat="server" id="orther_up" style="padding-left: 4em">
                ได้แก่ &ensp; 
                 <asp:TextBox ID="txt_orther_up" runat="server" Width="85%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>--%>
    </form>
</div>
