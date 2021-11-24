<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_TABEAN_SUBSTITUTE_DETAIL.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_SUBSTITUTE_DETAIL" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="text-align:center">
        <div class="col-lg-12">รายการละเอียดคำขอใบแทนสำหรับผลิตภัณฑ์สมุนไพร</div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ประเภท</div>
        <div class="col-lg-8"><asp:label ID="lbl_type" runat="server"></asp:label></div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ชื่อ(ภาษาไทย)</div>
        <div class="col-lg-8"><asp:label ID="lbl_name_thai" runat="server"></asp:label></div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ชื่อ(ภาษาอังกฤษ)</div>
        <div class="col-lg-8"><asp:label ID="lbl_name_eng" runat="server"></asp:label></div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" style="text-align:center">
        <div class="col-lg-12">รายการเอกสารแนบ</div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">เหตุผลการขอ</div>
        <div class="col-lg-6">
            <asp:DropDownList ID="ddl_reason" runat="server" AutoPostBack="true">
                <asp:ListItem Value="0" Text="-- กรุณาเลือก --"></asp:ListItem>
                <asp:ListItem Value="4" Text="กรณีที่ใบอนุญาตถูกทำลาย หรือ ลบเลือนในสาระสำคัญ"></asp:ListItem>
                <asp:ListItem Value="5" Text="กรณีที่ใบอนุญาตสูญหาย"></asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" style="text-align:center">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">หมายเหตุ</div>
        <div class="col-lg-6">
            <asp:TextBox ID="txt_remark" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแนบคำขอใบสำคัญ</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="width: 100%">
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
                                <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                                    HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
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
        <div class="col-lg-8 text-center">
            <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ"/>
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
