﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_EDIT_FILE_UPLOAD_JJ.ascx.vb" Inherits="FDA_DRUG_HERB.UC_EDIT_FILE_UPLOAD_JJ" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<hr />
<%--<div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-6" style="text-align: left;color:red">
            <h3>เอกสารแนบและหมายเหตุประกอบการแก้ไขคำขอ</h3>
        </div>
        <div class="col-lg-4" style="text-align: left;color:red">
            <h3>รายละเอียดการแก้ไข</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div style="text-align: center">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">
                    <telerik:RadGrid ID="RadGrid1" runat="server">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                                    SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DOCUMENT_NAME" FilterControlAltText="Filter DOCUMENT_NAME column"
                                    HeaderText="รายการเอกสาร" SortExpression="DOCUMENT_NAME" UniqueName="DOCUMENT_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column"
                                    HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="PV_SELECT" runat="server">ดูเอกสาร</asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
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
                <div class="col-lg-1" style="text-align: left"></div>
                <div class="col-lg-4">
                    <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 90px; width: 100%" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
    </div>--%>
<div class="row" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-6" style="text-align: left; color: red;">
        <h3>เอกสารแนบและหมายเหตุประกอบการแก้ไขคำขอ</h3>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="text-align: left; padding-left: 2em;">
        <div style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 60px; width: 100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
        </div>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-6" style="text-align: left; color: red;">
        <h3>เอกสารแนบประกอบการแก้ไขคำขอ</h3>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="text-align: left; padding-left: 2em">
        <asp:Table ID="tb_UpLoadStaff" runat="server" CssClass="table" Width="100%"></asp:Table>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <hr />
    </div>
</div>
<div class="row" style="text-align: left">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <h3>แนบเอกสาร รายละเอียดข้อบกพร่อง ที่ท่านต้องแก้ไข</h3>
    </div>

</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <div style="text-align: left">
            <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
        </div>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="text-align: center">
        <asp:Button ID="btn_add_upload" runat="server" Text="อัพโหลดเอกสาร" Height="55px" Width="270px" />
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <hr />
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="text-align: left">
        <h3>รายละเอียดเอกสารแนบเดิม</h3>
    </div>
</div>
<div class="row" style="text-align: center">
    <div class="col-lg-12">
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="width: 80%">
        <telerik:RadGrid ID="RadGrid2" runat="server">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>

                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                        SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                        SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false" AllowFiltering="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DOCUMENT_NAME" FilterControlAltText="Filter DOCUMENT_NAME column"
                        HeaderText="รายการเอกสาร" SortExpression="DOCUMENT_NAME" UniqueName="DOCUMENT_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column"
                        HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:HyperLink ID="PV_SELECT" runat="server">ดูเอกสาร</asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
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
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="text-align: center">
        <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="10%" />
        <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="10%" />
    </div>
    <div class="col-lg-1"></div>
</div>


