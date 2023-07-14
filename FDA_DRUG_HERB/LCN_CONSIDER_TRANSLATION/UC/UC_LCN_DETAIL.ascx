<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_DETAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_DETAIL" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
</style>
<div>
    <form name="form" method="post" align="center;">
        <div class="row">
            <div class="col-lg-12" style="text-align: center;">
                <h3>คำขอพิจารณาแบบแปลนอาคาร สถานที่ สำหรับสถานประกอบการผลิตภัณฑ์สมุนไพร</h3>
            </div>
        </div>

          <div class="row">
                 <div class="col-lg-4"></div>
            <div class="col-lg-4" style="text-align:center">
                <asp:RadioButtonList ID="RBL_Translation_TYPE" runat="server" RepeatDirection="Horizontal" Width="100%">
                    <asp:ListItem Value="1">&ensp;ผลิตภัณฑ์สมุนไพร&ensp;</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;สารสกัดสมุนไพร&ensp;</asp:ListItem>
                </asp:RadioButtonList>
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
                <asp:TextBox ID="txt_Write_Date" runat="server" Style="width:80%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div style="padding-top: 30px"></div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ข้าพเจ้า</div>
            <div class="col-lg-8">
                <asp:TextBox ID="txt_Name" runat="server" Width="100%"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">อายุ</div>
            <div class="col-lg-1">
                <asp:TextBox ID="Txt_age" runat="server" Width="40%" TextMode="Number"></asp:TextBox>
                &nbsp;&nbsp;ปี
            </div>
            <div class="col-lg-3">
                สัญชาติ &ensp;
                <asp:TextBox ID="txt_Nationality" runat="server" Width="65%"></asp:TextBox>
            </div>
            <div class="col-lg-5">
                เลขประจำตัวประชาชน/เลขทะเบียนนิติบุคคล &ensp;
                <asp:TextBox ID="txt_Citizen" runat="server" Width="35%"></asp:TextBox>
            </div>
            <div class="col-lg-1">
            </div>
        </div>


        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">อยู่เลขที่</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_addr" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                หมู่บ้าน/อาคาร
            </div>
            <div class="col-lg-1">
                <asp:TextBox ID="txt_Building" runat="server"></asp:TextBox>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">หมู่ที่</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_mu" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">ตรอก/ซอย </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_Soi" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3">
                ถนน &emsp;&emsp;
                 <asp:TextBox ID="txt_road" runat="server" Width="80%"></asp:TextBox>
            </div>
            <div class="col-lg-2">
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ตำบล/แขวง</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_tambol" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                อำเภอ/แขวง
            </div>
            <div class="col-lg-1">
                <asp:TextBox ID="txt_ampher" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">จังหวัด</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_changwat" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                รหัสไปรณษณีย์
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_zipcode" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3">
                โทรสาร &ensp;
                <asp:TextBox ID="txt_fax" runat="server" Width="80%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">โทรศัพท์</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_Tel" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                E-mail
            </div>
            <div class="col-lg-1">
                <asp:TextBox ID="txt_email" runat="server" TextMode="Email"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                มีความประสงค์จะขอให้พิจารณาแบบแปลนสถานที่ผลิตผลิตภัณฑ์สมุนไพร
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                ชื่อ &ensp;
                <asp:TextBox ID="Txt_CSTF_NAME" runat="server" Width="79%"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                เลขที่ใบอนุญาตผลิต/นำเข้า/ขาย (เฉพาะกรณีสถานที่ได้รับใบอนุญาตแล้ว) &ensp;
                <asp:TextBox ID="Txt_LCNNO" runat="server" Width="30%"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                ซึ่งมีสถานที่ตั้งอยู่ในเขตจังหวัด (หากยังไม่ก่อสร้างให้ระบุจังหวัดที่คาดว่าจะก่อสร้าง) &ensp;
            <%--    <asp:TextBox ID="Txt_LOCATION_ADDR" runat="server" Width="30%"></asp:TextBox>--%>
             <asp:DropDownList ID="ddl_Province" runat="server"   Width="30%" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd"></asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="padding-left: 2em">
                <h4>กรณีมีการสกัดดอกและช่อดอกกัญชง/กัญชา มีวัตถุประสงค์เพื่อให้ได้สารสกัดที่เป็น (ถ้ามี) &ensp;</h4>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-3">
                <asp:RadioButtonList ID="RDL_EXTRACTION" runat="server" RepeatDirection="Horizontal" Width="100%">
                    <asp:ListItem Value="1">&ensp;ผลิตภัณฑ์สมุนไพร&ensp;</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;อาหาร&ensp;</asp:ListItem>
                    <asp:ListItem Value="3">&ensp;เครื่องสำอาง&ensp;</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                ทั้งนี้กระบวนการสกัดผลิตภัณฑ์ข้างต้นไม่ได้มีวัตถุประสงค์เพื่อเป็นยาแผนปัจจุบัน หรือใช้ผสมเป็นยาแผนปัจจุบัน &ensp;
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="padding-left: 2em">
                <h4>ประเภทคำขอพิจารณา &ensp;</h4>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-5">
                <asp:RadioButtonList ID="RDL_REQ" runat="server" RepeatDirection="Horizontal" Width="100%">
                    <asp:ListItem Value="1">&ensp;ขอใหม่&ensp;</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;ขอแก้ไขเปลี่ยนแปลง&ensp;</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;ขอยกเลิกแบบแปลนเดิมและขอพิจารณาใหม่&ensp;</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                *กรณีขอแก้ไขปรับปรุงโปรดระบุรายละเอียดการขอพิจารณา&ensp;
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="padding-left: 2em">
                <asp:TextBox ID="Txt_Detail_Edit_REQ" runat="server" TextMode="MultiLine" Width="100%" Height="137px"></asp:TextBox>
            </div>
        </div>
    </form>
    <footer>
    </footer>
</div>
