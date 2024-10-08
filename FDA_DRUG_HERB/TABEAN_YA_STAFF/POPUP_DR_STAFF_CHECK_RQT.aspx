﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DR_STAFF_CHECK_RQT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_DR_STAFF_CHECK_RQT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 209px;
        }
        .auto-style2 {
            height: 93px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel" style="width:100%">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="panel-heading panel-title">
                <h1>ตรวจสอบคำขอขึ้นทะเบียนฯ</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    
                    <tr ><td>ชื่อกระบวนงาน</td><td>
                        <telerik:RadComboBox ID="ddl_req_type" Runat="server" Filter="Contains" Width="80%" AutoPostBack="true">
                        </telerik:RadComboBox>
                        </td></tr>
                    <tr ><td>เลขตรวจคำขอ (A) (ถ้ามี)</td><td>
                        <asp:TextBox ID="Txt_rcvno_temp" runat="server" CssClass="input-lg"></asp:TextBox>
                        <asp:Button ID="btn_search_C" runat="server" Text="ดึงข้อมูล" CssClass="btn-lg" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        </td></tr>
                    <tr ><td>จำนวนเงิน</td><td>
                        <asp:DropDownList ID="ddl_amount" runat="server">
                        </asp:DropDownList>
                        </td></tr>

                    <tr ><td>ส่วนลด (%)</td><td>
                        <telerik:RadTextBox ID="rtb_decrease" Runat="server" AutoPostBack="True" LabelWidth="64px" Resize="None" Width="160px" InputType="Number">
                        </telerik:RadTextBox>
                        </td></tr>

                    <tr ><td>จำนวนสุทธิ</td><td>
                        <telerik:RadTextBox ID="rtb_summary" Runat="server" InputType="Number">
                        </telerik:RadTextBox>
                        </td></tr>
                    <tr ><td>ประเภททะเบียน</td><td>
                        <asp:DropDownList ID="ddl_rgttpcd" runat="server">
                        </asp:DropDownList>
                        </td></tr>

                    <tr ><td>วงเล็บ(ถ้ามี)</td><td>
                        <asp:DropDownList ID="ddl_tabean_group" runat="server">
                        </asp:DropDownList>
                        </td></tr>
                    <%--<tr ><td>สถานะ</td><td>
                        <asp:DropDownList ID="ddl_receive" runat="server">
                            <asp:ListItem Value="6">ตรวจคำขอ</asp:ListItem>
                            <asp:ListItem Value="7">คืนคำขอ</asp:ListItem>
                        </asp:DropDownList>
                        </td></tr>--%>

                    <tr ><td>การแสดงรหัสจังหวัดที่เลขใบอนุญาต</td><td>
                        <asp:RadioButtonList ID="rdl_show_pvnabbr" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">แสดงรหัสจังหวัด</asp:ListItem>
                            <asp:ListItem Value="2">แสดงเป็น จ.</asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;</td></tr>
                    <tr ><td>เลขรับ</td><td>
                        <asp:TextBox ID="Txt_rcvno_no" runat="server" CssClass="input-lg"></asp:TextBox>
                        (เช่น 1/62)</td></tr>
                   <tr ><td class="auto-style2">วันที่ตรวจคำขอ</td><td class="auto-style2">
                        <asp:TextBox ID="txt_rcvdate" runat="server" CssClass="input-lg">
                        </asp:TextBox>(วัน/เดือน/ปี พ.ศ. =&gt; 1/10/2563)</td></tr>
                    <%--<p style="color:red;" class="auto-style1">(วัน/เดือน/ปี พ.ศ. =&gt; 1/10/2563)</p>--%>
                 <%--  <tr ><td>ผู้รับคำขอ</td><td>
                        <asp:DropDownList ID="ddl_receiver" runat="server"  Width="70%">
                        </asp:DropDownList>
                        </td>

                   </tr>--%>

                   <tr ><td>จนท.ผู้รับผิดชอบคำขอ (กรอกเลขบัตรประชาชน)</td><td>
                        <asp:TextBox ID="txt_iden_staff" runat="server" CssClass="input-lg"></asp:TextBox>
                        <asp:Button ID="btn_search" runat="server" Text="ค้นหาจนท." CssClass="btn-lg" />
                        <br />
                        <asp:Label ID="lbl_staff_name" runat="server" Text="-"></asp:Label>
                        </td></tr>

                   <tr ><td><asp:Label ID="Label1" runat="server" Text="รูปแบบเอกสาร" style="display:none;"></asp:Label>
                       </td><td>
                        <asp:DropDownList ID="ddl_template" runat="server" Width="80%" style="display:none;">
                            <asp:ListItem Value="1">แบบปกติ</asp:ListItem>
                            <asp:ListItem Value="2">แบบที่ 1</asp:ListItem>
                        </asp:DropDownList>
                        </td></tr>
                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" OnClientClick="return confirm('ต้องการบันทึกหรือไม่?');" />
                  &nbsp;&nbsp;
                  <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>