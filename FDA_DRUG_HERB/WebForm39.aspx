<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm39.aspx.vb" Inherits="FDA_DRUG_HERB.WebForm39" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                &nbsp;
            </p>
            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">เจน XML จดแจ้ง(DEMO)</h3>
            <p>
                <asp:TextBox ID="txt_iden_jj" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
            <span style="color: rgb(0, 0, 0); font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">เลขบัตรคนกด&nbsp;
            <span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none">

                <br />
                <asp:TextBox ID="txt_tr_id_jj" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label1" runat="server" Text="เลขดำเนินการ"></asp:Label>
                <br />

                <asp:TextBox ID="txt_IDA_jj" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="เลข IDA ทะเบียน"></asp:Label>
                <br />

                <asp:TextBox ID="txt_IDA_LCN_JJ" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label3" runat="server" Text="เลข IDA ใบอนูญาต"></asp:Label>
                <br />
                <asp:TextBox ID="txt_PROCESS_ID_JJ" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:Label ID="Label4" runat="server" Text="เลข PROCESS_ID ทะเบียน"></asp:Label>
                <br />
                <asp:TextBox ID="txt_detail_jj" runat="server" Height="50px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:Label ID="lbl_jj_des" runat="server" Text="รายละเอียด"></asp:Label>
            </span></span>
            </p>
            <asp:Button ID="BTN_GEN_XML_JJ1" runat="server" Text="สร้าง xml จจ1" Height="45px" Width="170px" />
            <asp:Button ID="BTN_GEN_XML_JJ2" runat="server" Text="สร้าง xml จจ2(สั้น)" Height="45px" Width="170px" />
            <asp:Button ID="BTN_GEN_XML_JJ2_L" runat="server" Text="สร้าง xml จจ2(ยาว)" Height="45px" Width="170px" />

            <p>
                &nbsp;
            </p>
            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">เจน XML ทะเบียน(DEMO)</h3>
            <p>
                <asp:TextBox ID="txt_iden_TBN" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
            <span style="color: rgb(0, 0, 0); font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">เลขบัตรคนกด&nbsp;
            <span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none">

                <br />
                <asp:TextBox ID="txt_tr_id_TBN" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label5" runat="server" Text="เลขดำเนินการ"></asp:Label>
                <br />

                <asp:TextBox ID="txt_IDA_TBN" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Text="เลข IDA ทะเบียน(drrqt)"></asp:Label>
                <br />

                <asp:TextBox ID="txt_IDA_LCN_TBN" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label7" runat="server" Text="เลข IDA ใบอนูญาต"></asp:Label>
                <br />
                <asp:TextBox ID="txt_PROCESS_ID_TBN" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:Label ID="Label8" runat="server" Text="เลข PROCESS_ID ทะเบียน"></asp:Label>
                <br />
                <asp:TextBox ID="txt_detail_TBN" runat="server" Height="50px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:Label ID="Label9" runat="server" Text="รายละเอียด"></asp:Label>
            </span></span>
            </p>
            <asp:Button ID="BTN_GEN_XML_TBN1" runat="server" Text="สร้าง xml ทบ1" Height="45px" Width="170px" />
            <asp:Button ID="BTN_GEN_XML_TBN2" runat="server" Text="สร้าง xml ทบ2(สั้น)" Height="45px" Width="170px" />
            <asp:Button ID="BTN_GEN_XML_TBN2_L" runat="server" Text="สร้าง xml ทบ2(ยาว)" Height="45px" Width="170px" />



            <p>
                &nbsp;
            </p>
            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">ย้ำสถานะจ่ายเงิน(ระบบใหม่)</h3>

            <asp:TextBox ID="SWPM_IDEN" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <span style="color: rgb(0, 0, 0); font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">เลขบัตรคนกด&nbsp;
            <span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none">
                <br />

                <br />
                <asp:TextBox ID="SWPM_IDA" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label10" runat="server" Text="เลข IDA"></asp:Label>
                <br />


                <br />
                <asp:TextBox ID="SWPM_PROCESS" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label11" runat="server" Text="เลข PROCESS"></asp:Label>
                <br />

                <br />
                <asp:TextBox ID="SWPM_REF01" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label12" runat="server" Text="เลข REF01"></asp:Label>
                <br />

                <br />
                <asp:TextBox ID="SWPM_REF02" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label13" runat="server" Text="เลข REF02"></asp:Label>
                <br />

                <br />
                <asp:TextBox ID="SWPM_DETAIL" runat="server" Height="50px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:Label ID="Label14" runat="server" Text="รายละเอียด"></asp:Label>
                <br />

            </span></span>
            <asp:Button ID="BTN_SWPM_CF" runat="server" Text="ยืนยัน" Height="45px" Width="170px" />
        </div>
    </form>
</body>
</html>
