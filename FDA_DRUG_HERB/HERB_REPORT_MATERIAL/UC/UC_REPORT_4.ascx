<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_REPORT_4.ascx.vb" Inherits="FDA_DRUG_HERB.UC_REPORT_4" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<link href="../css/css_rg_herb.css" rel="stylesheet" />
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10">
        <h3 style="text-align: center">รายงานการผลิตวัตถุดิบเพื่อขายที่ใช้เป็นส่วนผสมในการผลิตผลิตภัณฑ์สมุนไพร ประจำปี พ.ศ.</h3>
    </div>
    <div class="col-lg-1">
    </div>
</div>
<br />
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-2" style="text-align: center">
        ชื่อผู้รับอนุญาต
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TextBox1" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        เลขที่ใบอนุญาตผลิตผลิตภัณฑ์สมุนไพร
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TextBox2" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-2">
        สถานที่ผลิตผลิตภัณฑ์สมุนไพรชื่อ
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TextBox3" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        อยู่เลขที่
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TextBox4" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-2">
        ถนน
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TextBox5" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        หมู่ที่
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TextBox6" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        ตำบล/แขวง
    </div>
    <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TextBox7" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-2">
        อำเภอ/เขต
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TextBox8" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        จังหวัด
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TextBox9" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-2">
        ชื่อผลิตภัณฑ์สมุนไพร
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox10" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        ชื่อผู้ผลิตและประเทศผู้ผลิต
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox11" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-2">
        ชื่อผู้ผลิต
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox17" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        ประเทศผู้ผลิต
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox18" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-2">
        รายละเอียดขนาดบรรจุ
    </div>
    <div class="col-lg-8">
        <asp:TextBox ID="TextBox12" runat="server" Width="100%" TextMode="MultiLine" Height="70px"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-2">
        จำนวน
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox13" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        ปริมาณรวม
    </div>
    <div class="col-lg-1">
        <asp:TextBox ID="TextBox14" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-2">
        ราคาสั่งซื้อ
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox15" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        หมายเหตุ
    </div>
    <div class="col-lg-5">
        <asp:TextBox ID="TextBox16" runat="server" Width="100%" TextMode="MultiLine" Height="70px"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="text-align: center">
        <asp:Button ID="Button1" runat="server" Text="เพิ่มข้อมูล" Height="49px" Style="margin-left: 0px" Width="171px" />
    </div>
    <div class="col-lg-1">
    </div>
</div>
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10">
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="25">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>

                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>

                <Columns>
                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                        HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                        HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                        HeaderText="ชื่อผลิตภัณฑ์สมุนไพร" ReadOnly="True" SortExpression="Name" UniqueName="Name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Manufacturer_Name" FilterControlAltText="Filter Manufacturer_Name column"
                        HeaderText="ชื่อผู้ผลิตและประเทศผู้ผลิต" SortExpression="Manufacturer_Name" UniqueName="Manufacturer_Name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Voucher_Number" FilterControlAltText="Filter Voucher_Number column"
                        HeaderText="เลขที่ใบสำคัญการขึ้นทะเบียนตำรับ ใบรับแจ้งรายละเอียดหรือใบรับจดแจ้งผลิตภัณฑ์สมุนไพร" SortExpression="Voucher_Number" UniqueName="Voucher_Number">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Packing_Size_Details" FilterControlAltText="Filter Packing_Size_Details column"
                        HeaderText="รายละเอียดขนาดบรรจุ" SortExpression="Packing_Size_Details" UniqueName="Packing_Size_Details">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Quantity" FilterControlAltText="Filter Quantity column"
                        HeaderText="จำนวน" SortExpression="Quantity" UniqueName="Quantity">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Total_Quantity" FilterControlAltText="Filter Total_Quantity column"
                        HeaderText="ปริมาณรวม" SortExpression="Total_Quantity" UniqueName="Total_Quantity">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Sale_Unit" FilterControlAltText="Filter Sale_Unit column"
                        HeaderText="ราคาสั่งซื้อ" SortExpression="Sale_Unit" UniqueName="Sale_Unit">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Note" FilterControlAltText="Filter Note column"
                        HeaderText="หมายเหตุ" SortExpression="Note" UniqueName="Note">
                    </telerik:GridBoundColumn>
                </Columns>

                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                </EditFormSettings>

                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>

            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

            <FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
    </div>
    <div class="col-lg-1">
    </div>
</div>
