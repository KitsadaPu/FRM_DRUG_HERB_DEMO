﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_SUB.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_SUB" %>
<div>

    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-3"><H2>คำขอใบแทนใบอนุญาต</H2></div>
        <div class="col-lg-5"></div>
    </div>

        <div class="row">
            <div class="col-lg-4"></div>
            <div class="col-lg-3">
                <asp:RadioButtonList ID="rdl_lcn_type" runat="server" BorderStyle="None" Enabled="False">
                    <asp:ListItem Value="1">ผลิตผลิตภัณฆ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="2">นำเข้าผลิตภัณฆ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="3">ขายผลิตภัณฆ์สมุนไพร</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-lg-5"></div>
    </div>
    <div><br /></div>
    <div><br /></div>
    <div></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">  ข้าพเจ้า :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_name" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">(ชื่อผู้รับอนุญาต)</div>
        <div class="col-lg-5"></div>
    </div>
     <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ซึ้งมีผู้มีหน้าที่ปฏิบัติการชื่อ :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_phr_name" runat="server" BorderColor="Lime" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">(เฉพาะกรณีนิติบุคคล)</div>
        <div class="col-lg-5"></div>
    </div>
     <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">เลขประจำตัวประชาชน/ใบอนุญาตทำงานเลขที่ :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_iden" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-7"></div>
    </div>
        <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ตามใบอนุญาตเลขที่ :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_lcnno" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
             <div class="col-lg-2">ณ สถานที่ประกอบธุรกิจชื่อ :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_location" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
      <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">อยู่เลขที่ :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_addr" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
             <div class="col-lg-2">หมู่บ้าน/อาคาร :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_building" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
     <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">หมู่ที่ :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_mu" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
             <div class="col-lg-2">ตรอก/ซอย :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_soi" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
     <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ถนน :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_road" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
             <div class="col-lg-2">ตำบลแขวง :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_tambol" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">อำเภอเขต :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_amphor" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
             <div class="col-lg-2">จังหวัด :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_changwat" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
     <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">รหัสไปรษณีย์ :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_zipcode" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
             <div class="col-lg-2">โทรศัพท์ :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_tel" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
     <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">เวลาทำการ :</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_sub_opentime" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-7"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-3"><H4>มีความประสงค์ขอใบแทนใบอนุญาตฯ</H4></div>
        <div class="col-lg-8"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1"><H4>เนื่องจาก</H4></div>
         <div class="col-lg-4">
        <asp:TextBox ID="txt_sub_PURPOSE" runat="server" Width="100%"></asp:TextBox>
             </div>
        <div class="col-lg-2">(เหตุที่ขอรับใบแทน)</div>
        <div class="col-lg-2"></div>
    </div>
     <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-3">
            <%--<asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />--%>
        </div>
        <div class="col-lg-5"></div>
    </div>
                     
                  
</div>