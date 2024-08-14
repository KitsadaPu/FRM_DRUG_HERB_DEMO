<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_LCT_INSERT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_LCT_INSERT" %>

<%@ Register Src="~/UC/UC_ATTACH_LCN.ascx" TagPrefix="uc1" TagName="UC_ATTACH_LCN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <style>
        input[type=text] {
            padding: 5px 10px;
            margin: 10px 0 2px 5px;
            box-sizing: border-box;
        }

        .auto-style1 {
            width: 30%;
            height: 30px;
        }

        .auto-style2 {
            width: 70%;
            height: 45px;
        }

        .auto-style3 {
            width: 20%;
            height: 20px;
        }
    </style>
    <asp:Panel ID="Panel1" runat="server">

        <div style="width: 100%">
            <table style="width: 100%">

                <tr>
                    <td style="width: 30%; padding-left: 15%; text-align: left">

                        <h2>
                            <asp:Label ID="Label1" runat="server" Text="ประเภทสถานที่"></asp:Label></h2>
                    </td>
                    <td style="width: 70%; text-align: left">

                        <asp:RadioButtonList ID="rdl_place_type" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Height="61px" Width="324px" Font-Size="18px">
                            <asp:ListItem Value="1" Selected="True">ที่ตั้ง</asp:ListItem>
                            <asp:ListItem Value="2">สถานที่เก็บ</asp:ListItem>
                        </asp:RadioButtonList>

                    </td>
                </tr>
            </table>

        </div>

        <div style="width: 100%">
            <table style="width: 100%">
                <tr>
                    <td style="width: 30%; padding-left: 15%; text-align: left" colspan="2">

                        <h2>
                            <asp:Label ID="Label21" runat="server" Text="ชื่อสถานที่"></asp:Label></h2>

                    </td>
                    <td style="width: 70%; text-align: right" colspan="2"></td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_thanameplace_lo" runat="server" Text="ชื่อสถานที่ (ภาษาไทย)"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_thanameplace_lo" runat="server" Width="70%" AutoPostBack="true"> </asp:TextBox>
                        <asp:Label ID="lbl_word_thai" runat="server" Text="*กรุณากรอกข้อมูล" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_engnameplace_lo" runat="server" Text="ชื่อสถานที่ (ภาษาอังกฤษ) ถ้ามี"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_engnameplace_lo" runat="server" Width="70%" AutoPostBack="true"></asp:TextBox>
                        <asp:Label ID="lbl_word_eng" runat="server" Text="*กรุณากรอกข้อมูล" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding-left: 15%; text-align: left" colspan="2">

                        <h2>
                            <asp:Label ID="Label24" runat="server" Text="ที่ตั้งสถานที่"></asp:Label></h2>

                    </td>
                    <td style="width: 70%; text-align: right" colspan="2"></td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_thacode_id_lo" runat="server" Text="รหัสประจำบ้าน"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_thacode_id_lo" runat="server" Width="70%"></asp:TextBox>
                        <asp:Button ID="btn_hno" runat="server" Text="ดึงข้อมูล" />
                        (หมายเหตุ สามารถดึงได้ทีละเลข)
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_thaaddr_lo" runat="server" Text="เลขที่"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_thaaddr_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_thabuilding_lo" runat="server" Text="อาคาร/ตึก"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_thabuilding_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_thafloor_lo" runat="server" Text="ชั้น"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_thafloor_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_tharoom_lo" runat="server" Text="ห้อง"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_tharoom_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_thamu_lo" runat="server" Text="หมู่"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_thamu_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_thasoi_lo" runat="server" Text="ซอย"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_thasoi_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_tharoad_lo" runat="server" Text="ถนน"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_tharoad_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_thachngwtnm_lo" runat="server" Text="จังหวัด"></asp:Label>


                    </td>
                    <td style="width: 70%; text-align: left" colspan="2" class="auto-style1">


                        <asp:DropDownList CssClass="dropdown" ID="ddl_chngwt" Width="70%" runat="server" AutoPostBack="True">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2" class="auto-style1">

                        <asp:Label ID="Lb_thaamphrnm_lo" runat="server" Text="เขต/อำเภอ"></asp:Label>

                    </td>
                    <td style="text-align: left" colspan="2" class="auto-style2">

                        <asp:DropDownList CssClass="dropdown" ID="ddl_amphr" Width="70%" runat="server" AutoPostBack="True">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2" class="auto-style1">
                        <asp:Label ID="Lb_thathmblnm_lo" runat="server" Text="แขวง/ตำบล"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:DropDownList CssClass="dropdown" ID="ddl_thumbol" Width="70%" runat="server" AutoPostBack="True">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_zipcode_lo" runat="server" Text="รหัสไปรษณีย์"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_zipcode_lo" runat="server" Width="70%" MaxLength="5"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_tel_lo" runat="server" Text="โทรศัพท์"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_tel_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_mobile_lo" runat="server" Text="โทรศัพท์มือถือ"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_mobile_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_fax_lo" runat="server" Text="โทรสาร"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_fax_lo" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_latitude" runat="server" Text="latitude(ถ้าไม่มีใส่ 0)"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_latitude" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right" colspan="2">

                        <asp:Label ID="Lb_longitude" runat="server" Text="longitude(ถ้าไม่มีใส่ 0)"></asp:Label>

                    </td>
                    <td style="width: 70%; text-align: left" colspan="2">

                        <asp:TextBox ID="txt_longitude" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>

            </table>
        </div>
    </asp:Panel>
    <br />
    <div class="row" runat="server" id="div_set_show1">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบ</h3>
        </div>
    </div>
    <div class="row" runat="server" id="div_set_show2">
        <div style="text-align: center">
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-2">
                    สำเนาทะเบียนบ้าน/สัญญาเช่าสถานที่   
                </div>              
                <div class="col-lg-2">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN" />
                </div>
                <div class="col-lg-1" style="text-align: right">
                    <div runat="server" id="img_not">
                        <img class="auto-style3"
                            src="../Images/cancel.png"
                            alt=""
                            runat="server">
                    </div>
                    <div runat="server" id="img_cf" visible="False">
                        <img class="auto-style3"
                            src="../Images/correct.png"
                            runat="server">
                    </div>
                </div>
                <div class="col-lg-3" style="text-align: left">
                    <asp:Label ID="lbl_upload_file" runat="server" Text="ไม่มีไฟล์อัพโหลด"></asp:Label>
                </div>

                <div class="col-lg-1" style="text-align: right">
                    <asp:Button CssClass="btn btn-primary" Height="34px" ID="btn_upload" runat="server" Text="อัพโหลดเอกสารแนบ" />
                </div>
            </div>

        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-5"></div>
        <div class="col-lg-1" style="text-align: right">
            <asp:Button CssClass="btn btn-primary" Height="34px" ID="bnt_submit" runat="server" Text="บันทึกข้อมูล" />
        </div>
        <div class="col-lg-5">
            <asp:Button CssClass="btn btn-primary" Height="34px" ID="btn_send" runat="server" Text="ส่งเรื่อง" OnClientClick="return confirm('ต้องการส่งเรื่องหรือไม่');" />
        </div>
    </div>
    <%--  <div style="width:100%;text-align:center">
        <%--<asp:Button  CssClass ="btn-primary" ID="btn_back" runat="server" Text="ย้อนกลับ" style="height: 29px"  />
        &nbsp;&nbsp;
       
    </div>--%>
    <br />
</asp:Content>
