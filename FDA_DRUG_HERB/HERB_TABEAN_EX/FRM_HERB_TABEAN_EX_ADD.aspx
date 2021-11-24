<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_HERB_TABEAN_EX_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_EX_ADD" %>
<%@ Register src="../UC/UC_ATTACH.ascx" tagname="UC_ATTACH" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            border-collapse: collapse;
            width: 100%;
            max-width: 100%;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12" style="text-align: center">แบบแจ้งผลิตหรือนาเข้าผลิตภัณฑ์สมุนไพรเพื่อเป็นตัวอย่าง สาหรับการขึ้นทะเบียน การแจ้งรายละเอียด หรือการจดแจ้ง</div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="Label1" runat="server" Text="ข้าพเจ้า"></asp:Label>
        </div>
        <div class="col-lg-3">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <asp:Label ID="Label2" runat="server" Text="ซึ่งมีผู้ดำเนินกิจการชื่อ"></asp:Label>
        </div>
        <div class="col-lg-3">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="Label3" runat="server" Text="ชื่อผู้ได้รับอนุญาต"></asp:Label>
        </div>
        <div class="col-lg-6">
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="Label4" runat="server" Text="ได้รับอนุญาตให้"></asp:Label>
        </div>
        <div class="col-lg-3">
            <asp:DropDownList ID="DD_CATEGORY_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="122">ผลิต ผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="121">นำเข้า ผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <%--<asp:ListItem Value="120">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <asp:Label ID="Label5" runat="server" Text="ตามใบอนุญาตที่"></asp:Label>
        </div>
        <div class="col-lg-3">
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="Label6" runat="server" Text="ณ สถานที่"></asp:Label></div>
        <div class="col-lg-3">
            <asp:DropDownList ID="DD_CATEGORY_ID_SUB" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="122">ผลิต </asp:ListItem>
                <asp:ListItem Value="121">นำเข้า ผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <%--<asp:ListItem Value="120">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div class="col-lg-2"><asp:Label ID="Label7" runat="server" Text="ชื่อบริษัท/ห้างหุ้นส่วนจำกัด"></asp:Label></div>
        <div class="col-lg-3"><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-2" style="text-align:right"><asp:Label ID="Label8" runat="server" Text="อยู่เลขที่"></asp:Label></div>
        <div class="col-lg-2"><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></div>
        <div class="col-lg-2"><asp:Label ID="Label9" runat="server" Text="หมู่ที่"></asp:Label></div>
        <div class="col-lg-2"><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></div>
        <div class="col-lg-2"><asp:Label ID="Label10" runat="server" Text="ตรอก/ซอย"></asp:Label></div>
        <div class="col-lg-2"><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div class="col-lg-2" style="text-align:right"><asp:Label ID="Label11" runat="server" Text="ถนน"></asp:Label></div>
        <div class="col-lg-2"><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></div>
        <div class="col-lg-2"><asp:Label ID="Label12" runat="server" Text="ตำบล/แขวง"></asp:Label></div>
        <div class="col-lg-2"><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></div>
        <div class="col-lg-2"><asp:Label ID="Label13" runat="server" Text="อำเภอ/เขต"></asp:Label></div>
        <div class="col-lg-2"><asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div class="col-lg-2" style="text-align:right"><asp:Label ID="Label14" runat="server" Text="จังหวัด"></asp:Label></div>
        <div class="col-lg-2"><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></div>
        <div class="col-lg-2"><asp:Label ID="Label15" runat="server" Text="โทรศัพท์"></asp:Label></div>
        <div class="col-lg-2"><asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align: center">รายการละเอียดของผลิตภัณฑ์สมุนไพร</div>
    </div>
    <div class="row">
        <div class="col-lg-3"><asp:Label ID="Label16" runat="server" Text="ชื่อผลิตภัณฑ์"></asp:Label></div>
        <div class="col-lg-9"><asp:TextBox ID="TextBox14" Width="80%" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div class="col-lg-3"><asp:Label ID="Label17" runat="server" Text="รูปแบบผลิตภัณฑ์"></asp:Label></div>
        <div class="col-lg-9"><asp:TextBox ID="TextBox15" TextMode="MultiLine" Width="80%" Height="150px" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div class="col-lg-3"><asp:Label ID="Label18" runat="server" Text="รูปแบบผลิตภัณฑ์"></asp:Label></div>
        <div class="col-lg-9"><asp:TextBox ID="TextBox16" TextMode="MultiLine" Width="80%" Height="150px" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div class="col-lg-3"><asp:Label ID="Label19" runat="server" Text="ลักษณะและสี"></asp:Label></div>
        <div class="col-lg-9"><asp:TextBox ID="TextBox17" TextMode="MultiLine" Width="80%" Height="150px" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align: left">จำนวนหรือปริมาณที่จะผลิต/นำเข้า</div>
    </div>
    <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-9"><asp:TextBox ID="TextBox18" TextMode="MultiLine" Width="80%" Height="150px" runat="server"></asp:TextBox></div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align: left">ขนาดบรรจุ (รายละเอียดภาชนะบรรจุ)</div>
    </div>
    <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-9"><asp:TextBox ID="TextBox19" TextMode="MultiLine" Width="80%" Height="150px" runat="server"></asp:TextBox></div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align: center">เอกสารแนบ</div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <uc1:UC_ATTACH ID="UC_ATTACH2" runat="server" />
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_save" runat="server" Text="บันทึกส่วนที่ 1" />
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" />
        </div>
    </div>
</asp:Content>
