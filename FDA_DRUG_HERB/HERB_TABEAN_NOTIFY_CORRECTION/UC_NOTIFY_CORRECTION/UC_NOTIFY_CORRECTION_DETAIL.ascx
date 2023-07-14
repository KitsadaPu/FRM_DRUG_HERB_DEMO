<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_NOTIFY_CORRECTION_DETAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_NOTIFY_CORRECTION_DETAIL" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel1" runat="server" Style="display: block;">
    <div class="row" id="Div1" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h4>1. การแก้ไขที่ไม่เป็นสาระสำคัญบนฉลากและเอกสารกำกับผลิตภัณฑ์</h4>
            <hr />
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="40"
                PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="SelectColumn" />
                        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" HeaderText="ID"
                            SortExpression="ลำดับที่" UniqueName="ID" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDsub" DataType="System.Int32" FilterControlAltText="Filter IDsub column" HeaderText="IDsub"
                            SortExpression="IDsub" Display="false" UniqueName="IDsub" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EditingStyle" FilterControlAltText="Filter EditingStyle column"
                            HeaderText="ลักษณะการแก้ไข" SortExpression="EditingStyle" UniqueName="EditingStyle">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Panel>

<br />
<asp:Panel ID="Panel2" runat="server" Style="display: block;">
    <div class="row" id="Div2" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h4>2. การแก้ไขอื่นๆ นอกเหนือจากฉลากและเอกสารกำกับผลิตภัณฑ์สมุนไพร</h4>
            <hr />
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="40"
                PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="SelectColumn" />
                        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" HeaderText="ID"
                            SortExpression="ลำดับที่" UniqueName="ID" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDsub" DataType="System.Int32" FilterControlAltText="Filter IDsub column" HeaderText="IDsub"
                            SortExpression="IDsub" Display="false" UniqueName="IDsub" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EditingStyle" FilterControlAltText="Filter EditingStyle column"
                            HeaderText="ลักษณะการแก้ไข" SortExpression="EditingStyle" UniqueName="EditingStyle">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Panel>

<div style="padding-top: 15px"></div>
<br />
<div class="row" id="E1" runat="server">
    <div class="col-lg-12" style="text-align: center">
        <asp:Button ID="BTN_ADD2" runat="server" Text="เพิ่มข้อมูลส่วนที่2" Height="40px" Width="135px" />&ensp;
    </div>
</div>

<asp:Panel ID="Panel3" runat="server" Style="display: none;">
    <div style="padding-top: 15px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="text-align: left">
            <h4>รายละเอียดแนบท้ายหนังสือแจ้งการแก้ไขรายการในใบสำคัญการขึ้นทะเบียนตำรับใบรับแจ้งรายละเอียดหรือใบรับจดแจ้งผลิตภัณฑ์สมุนไพร</h4>
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />&nbsp;&nbsp;รายการที่แก้ไขจำนวน
            <asp:TextBox ID="txt_numb_edit" runat="server" BorderStyle="None" Style="border-bottom: #999999 1px dotted; text-align: center; width: 50px" ReadOnly="true"></asp:TextBox>
            รายการ ในใบสำคัญการขึ้นทะเบียนตำรับ ใบรับแจ้งรายละเอียด หรือใบรับจดแจ้ง ผลิตภัณฑ์สมุนไพรจำนวน
            <asp:TextBox ID="txt_numb_tabean" runat="server" BorderStyle="None" Style="border-bottom: #999999 1px dotted; text-align: center; width: 50px" ReadOnly="true" Enabled="false"></asp:TextBox>ใบ
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <asp:CheckBox ID="CheckBox2" runat="server" />&nbsp;&nbsp;รายการที่แก้ไขจำนวน
            <asp:TextBox ID="txt_numb_edit2" runat="server" BorderStyle="None" Style="border-bottom: #999999 1px dotted; text-align: center; width: 50px" ReadOnly="true"></asp:TextBox>
            ในใบสำคัญการขึ้นทะเบียนตำรับ ใบรับแจ้งรายละเอียด หรือใบรับจดแจ้ง ผลิตภัณฑ์สมุนไพรของผลิตภัณฑ์สมุนไพร
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div style="overflow-x: scroll; text-align: left">
                <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="90%"></asp:Table>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <telerik:RadGrid ID="RadGrid3" runat="server" AllowPaging="true" PageSize="15">
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
                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter F  K_IDA column"
                            HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column"
                            HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDsub" FilterControlAltText="Filter IDsub column"
                            HeaderText="ลำดับที่" ReadOnly="True" SortExpression="IDsub" UniqueName="IDsub">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EditingStyle_Name" FilterControlAltText="Filter EditingStyle_Name column"
                            HeaderText="รายการแก้ไข" ReadOnly="True" SortExpression="EditingStyle_Name" UniqueName="EditingStyle_Name">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CREATE_DATE" DataType="System.DateTime" FilterControlAltText="Filter CREATE_DATE column"
                            HeaderText="วันที่ดำเนินการ" SortExpression="CREATE_DATE" UniqueName="CREATE_DATE" DataFormatString="{0:dd/MM/yyyy}">
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
        <div class="col-lg-1"></div>
    </div>

      
     <div class="row">
         <div style="padding-top: 15px"></div>
 
        <div class="col-lg-1" style="text-align:right"></div>
        <div class="col-lg-10">
           <h4>ข้าพเจ้าได้แนบเอกสารหรือหลักฐานตามที่สำนักงานคณะกรรมการอาหารและยาประกาศกำหนดมาพร้อมนี้ ดังนี้</h4>
               <hr />
        </div>
        <div class="col-lg-1"></div>
    </div>
     <div class="row">
        <div class="col-lg-1" style="text-align:right">๑.</div>
        <div class="col-lg-10">
            <asp:Label ID="Label2" runat="server" Text=" (ฉลากพร้อมระบุวันที่ปรับปรุงเอกสารล่าสุดที่ฉลาก)"></asp:Label>
        </div>
        <div class="col-lg-1"></div>
    </div>
     <div class="row">
        <div class="col-lg-1" style="text-align:right">๒.</div>
        <div class="col-lg-10">
            <asp:Label ID="Label3" runat="server" Text=" (เอกสารกำกับผลิตภัณฑ์พร้อมระบุวันที่ปรับปรุงเอกสารล่าสุดที่เอกสารกำกับผลิตภัณฑ์)"></asp:Label>
        </div>
        <divclass="col-lg-1"></div>
     <div class="row">
        <div class="col-lg-1" style="text-align:right">๓.</div>
        <div class="col-lg-10">
            <asp:Label ID="Label4" runat="server" Text=" เอกสารแสดงว่าเป็นผู้มีอำนาจทำการแทน (กรณีมอบอำนาจ) หรือเป็นผู้แทนนิติบุคคลหรือผู้มีอำนาจทำการแทนนิติบุคคล (กรณีนิติบุคคลเป็นผู้ขออนุญาต)"></asp:Label>
        </div>
        <div class="col-lg-1"></div>
         </div>
     <div class="row">
        <div class="col-lg-1" style="text-align:right">๔.</div>
        <div class="col-lg-10" >
            <asp:TextBox ID="txt_upload_name" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Panel>

