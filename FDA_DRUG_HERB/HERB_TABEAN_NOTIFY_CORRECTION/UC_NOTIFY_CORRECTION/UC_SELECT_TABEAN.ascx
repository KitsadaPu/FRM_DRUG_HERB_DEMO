<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_SELECT_TABEAN.ascx.vb" Inherits="FDA_DRUG_HERB.UC_SELECT_TABEAN" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="row">
    <div class="col-lg-12" style="padding-left: 2em; padding-right: 2em">
        <asp:Panel ID="Panel1" runat="server" Style="display: block;">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="text-align: left">
                    <h2>หนังสือแจ้งการแก้ไขรายการในใบสำคัญการขึ้นทะเบียน</h2>
                    <hr />
                </div>
            </div>
            <div style="padding-top:30px"></div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-3" style="text-align: left">
                    <h4>กรุณาเลือกประเภททะเบียน</h4>
                    <hr />
                </div>
            </div>

            <div class="row">
                <%-- <div class="col-lg-1"></div>--%>
                <div class="col-lg-1" style="width: 20%; text-align: right">เลือกประเภท</div>
                <div class="col-lg-6">
                    <asp:DropDownList ID="DD_TYPE_TABEAN" runat="server" AutoPostBack="true">
                        <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                        <asp:ListItem Value="21410">คำขอการขึ้นทะเบียนผลิตภัณฑ์สมุนไพร</asp:ListItem>
                        <asp:ListItem Value="21420">คำขอรับแจ้งรายละเอียดผลิตภัณฑ์สมุนไพร</asp:ListItem>
                        <asp:ListItem Value="21430">คำขอรับจดแจ้งผลิตภัณฑ์สมุนไพร</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" Style="display: block;">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="text-align: left">
                    <h4>กรุณาเลือกทะเบียน</h4>
                    <hr />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="25"
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
                                    SortExpression="ID" UniqueName="ID" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn DataField="FK_LCT" DataType="System.Int32" FilterControlAltText="Filter FK_LCT column" HeaderText="FK_LCT"
                                    SortExpression="FK_LCT" UniqueName="FK_LCT" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="NAME_THAI" FilterControlAltText="Filter NAME_THAI column" HeaderText="NAME_THAI"
                                    SortExpression="ชื่อยา" UniqueName="NAME_THAI"  AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NAME_ENG"  FilterControlAltText="Filter NAME_ENG column" HeaderText="NAME_ENG"
                                    SortExpression="ชื่อยาภาษาอังกฤษ" UniqueName="NAME_ENG" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                  <telerik:GridBoundColumn DataField="FK_LCN" DataType="System.Int32" FilterControlAltText="Filter FK_LCN column" HeaderText="FK_LCN"
                                    SortExpression="FK_LCN" UniqueName="FK_LCN" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column" HeaderText="PROCESS_ID"
                                    SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                                    HeaderText="เลขทะเบียน" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                                    HeaderText="เลขทะดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="LCNNO_DISPLAY_NEW" FilterControlAltText="Filter LCNNO_DISPLAY_NEW column"
                                    HeaderText="เลขใบอนุญาต" SortExpression="LCNNO_DISPLAY_NEW" UniqueName="LCNNO_DISPLAY_NEW">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RCVNO_FULL" FilterControlAltText="Filter RCVNO_FULL column"
                                    HeaderText="เลขรับที่" SortExpression="RCVNO_FULL" UniqueName="RCVNO_FULL">
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
<%--            <div class="row" id="E1" runat="server">
                <div class="col-lg-12" style="text-align: center">
                    <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" />&ensp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
                </div>
            </div>--%>
        </asp:Panel>
    </div>
</div>
