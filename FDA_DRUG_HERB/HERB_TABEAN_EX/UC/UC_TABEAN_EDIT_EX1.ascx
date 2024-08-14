<%@ Control Language="vb" AutoEventWireup="false"  CodeBehind="UC_TABEAN_EDIT_EX1.ascx.vb" Inherits="FDA_DRUG_HERB.UC_TABEAN_EDIT_EX1" %>


<%@ Register Src="../../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="row">
    <div class="col-lg-12" style="text-align: center">แบบแจ้งผลิตหรือนำเข้าผลิตภัณฑ์สมุนไพรเพื่อเป็นตัวอย่าง สำหรับการขึ้นทะเบียน การแจ้งรายละเอียด หรือการจดแจ้ง</div>
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
        <asp:TextBox ID="txt_bsn_name" runat="server"></asp:TextBox>
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
        <asp:Label ID="Label6" runat="server" Text="ณ สถานที่"></asp:Label>
    </div>
    <div class="col-lg-3">
        <asp:DropDownList ID="DD_CATEGORY_ID_SUB" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="false">
            <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
            <asp:ListItem Value="122">ผลิต </asp:ListItem>
            <asp:ListItem Value="121">นำเข้า ผลิตภัณฑ์สมุนไพร</asp:ListItem>
            <%--<asp:ListItem Value="120">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>--%>
        </asp:DropDownList>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label7" runat="server" Text="ชื่อสถานที่ผลิต/นำเข้า"></asp:Label>
    </div>
    <div class="col-lg-3">
        <asp:TextBox ID="TextBox5" runat="server" readonly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>
<hr />
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        <asp:Label ID="Label8" runat="server" Text="อยู่เลขที่"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox6" runat="server" readonly="true"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label9" runat="server" Text="หมู่ที่"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox7" runat="server" readonly="true"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label10" runat="server" Text="ตรอก/ซอย"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox8" runat="server" readonly="true"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        <asp:Label ID="Label11" runat="server" Text="ถนน"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox9" runat="server" readonly="true"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label12" runat="server" Text="ตำบล/แขวง"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox10" runat="server" readonly="true"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label13" runat="server" Text="อำเภอ/เขต"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox11" runat="server" readonly="true"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        <asp:Label ID="Label14" runat="server" Text="จังหวัด"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox12" runat="server" readonly="true"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label15" runat="server" Text="โทรศัพท์"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox13" runat="server" readonly="true"></asp:TextBox>
    </div>
</div>
<hr />
<div class="row">
    <div class="col-lg-12" style="text-align: center">รายการละเอียดของผลิตภัณฑ์สมุนไพร</div>
</div>
<div class="row">
    <div class="col-lg-3">
        <asp:Label ID="Label16" runat="server" Text="ชื่อผลิตภัณฑ์"></asp:Label>
    </div>
    <div class="col-lg-9">
        <asp:TextBox ID="EX_NAME_PRODUCT" Width="80%" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validate1" ControlToValidate="EX_NAME_PRODUCT" ValidationGroup="valGroup1" ErrorMessage="*กรุณากรอกชื่อผลิตภัณฑ์" runat="server" ForeColor="Red" />
    </div>
</div>
<div class="row">
    <div class="col-lg-3">
        <asp:Label ID="Label17" runat="server" Text="รูปแบบผลิตภัณฑ์"></asp:Label>
    </div>
    <div class="col-lg-9">
          <asp:DropDownList ID="DD_TYPE_PRODUCK" runat="server" DataValueField="STYPE_ID" DataTextField="STYPE_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
            <asp:Label ID="label_TYPE_PRODUCK" runat="server" Text="*กรุณากรอกรูปแบบผลิตภัณฑ์" ForeColor="Red" Visible="false"></asp:Label>
        <%--            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="DD_TYPE_PRODUCK" ValidationGroup="valGroup1" ErrorMessage="*กรุณากรอกรูปแบบผลิตภัณฑ์" runat="server" ForeColor="Red" />--%>
    </div>
</div>
<div class="row">
    <div class="col-lg-3">
        <asp:Label ID="Label19" runat="server" Text="ลักษณะและสี"></asp:Label>
    </div>
    <div class="col-lg-9">
        <asp:TextBox ID="style_color" TextMode="MultiLine" Width="80%" Height="60px" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="style_color" ValidationGroup="valGroup1" ErrorMessage="*กรุณากรอกลักษณะและสี" runat="server" ForeColor="Red" />
    </div>
</div>
<hr />
<div class="row">
    <div class="col-lg-12">
        <asp:Panel ID="Panel_cheng_Location3" runat="server" Style="display: none;">
            <div>
                <div class="row">
                    <div class="col-lg-12" style="text-align: left">
                        <h4>ข้อมูลผู้ผลิตต่างประเทศ</h4>
                    </div>
                    <div class="col-lg-9">
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ผู้ผลิตต่างประเทศ:</label>
                    </div>
                    <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
                        <asp:TextBox ID="txt_search" runat="server" Width="100%"></asp:TextBox>
                        <asp:TextBox ID="txt_search_ida" runat="server" Width="100%" BorderStyle="None" Visible="false"></asp:TextBox>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <asp:Panel ID="Panel_FRGN" runat="server" Style="display: none;">
                    <div class="row">
                        <div class="col-lg-3"></div>
                        <div class="col-lg-6" style="width: 60%">
                            <telerik:RadGrid ID="RG_FRGN" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
                                PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <%--<telerik:GridClientSelectColumn UniqueName="SelectColumn" />--%>
                                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="frgncd" DataType="System.Int32" FilterControlAltText="Filter frgncd column" HeaderText="frgncd"
                                            SortExpression="frgncd" UniqueName="frgncd" Display="false" AllowFiltering="true">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="engfrgnnm" FilterControlAltText="Filter engfrgnnm column"
                                            HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาอังกฤษ)" SortExpression="engfrgnnm" UniqueName="engfrgnnm">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="thafrgnnm" FilterControlAltText="Filter thafrgnnm column"
                                            HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาไทย)" SortExpression="thafrgnnm" UniqueName="thafrgnnm">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                                            CommandName="sel" Text="เลือก">
                                            <HeaderStyle Width="70px" />
                                        </telerik:GridButtonColumn>
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

                <asp:Panel ID="Panel_FRGN_ADDR" runat="server" Style="display: none;">
                    <div class="row">
                        <div class="col-lg-3"></div>
                        <div class="col-lg-6" style="width: 60%">
                            <telerik:RadGrid ID="RG_FRGN_ADDR" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
                                PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <%--<telerik:GridClientSelectColumn UniqueName="SelectColumn" />--%>
                                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fulladdr2" FilterControlAltText="Filter fulladdr2 column"
                                            HeaderText="ที่อยู่" SortExpression="fulladdr2" UniqueName="fulladdr2">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                                            CommandName="sel" Text="เลือก">
                                            <HeaderStyle Width="70px" />
                                        </telerik:GridButtonColumn>
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
                        <div class="col-lg-3"></div>
                    </div>
                </asp:Panel>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ที่อยู่ ผู้ผลิตต่างประเทศ:</label>
                    </div>
                    <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                        <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                        <asp:TextBox ID="txt_address_ida" runat="server" TextMode="MultiLine" Height="60px" Width="100%" Visible="false"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
        </asp:Panel>
    </div>
</div>
<hr />

<div class="row">
    <div class="col-lg-12" style="text-align: left">
        <h4>รายละเอียดขนาดบรรจุ</h4>
    </div>
    <div class="col-lg-9">
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <div class="col-lg-2">Primary Packaging:</div>
    <div class="col-lg-2">
        <asp:DropDownList ID="DD_PCAK_1" runat="server" DataValueField="PACK_PRIMARY_ID" DataTextField="PACK_PRIMARY_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div class="col-lg-2" style="text-align: right">จำนวน:</div>
    <div class="col-lg-2" style="text-align: right">
        <asp:TextBox ID="NO_1" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-2" style="text-align: right">หน่วย:</div>
    <div class="col-lg-2">
        <asp:DropDownList ID="DD_UNIT_1" runat="server" DataValueField="UNIT_PRIMARY_ID" DataTextField="UNIT_PRIMARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col-lg-2">Secondary Packaging:</div>
    <div class="col-lg-2">
        <asp:DropDownList ID="DD_PCAK_2" runat="server" DataValueField="PACK_SEC_ID" DataTextField="PACK_SEC_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div class="col-lg-2" style="text-align: right">จำนวน:</div>
    <div class="col-lg-2">
        <asp:TextBox ID="NO_2" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-2" style="text-align: right">หน่วย:</div>
    <div class="col-lg-2">
        <asp:DropDownList ID="DD_UNIT_2" runat="server" DataValueField="UNIT_SECONDARY_ID" DataTextField="UNIT_SECONDARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col-lg-2">Tertiary Packaging:</div>
    <div class="col-lg-2">
        <asp:DropDownList ID="DD_PCAK_3" runat="server" DataValueField="PACK_TER_ID" DataTextField="PACK_TER_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div class="col-lg-2" style="text-align: right">จำนวน:</div>
    <div class="col-lg-2">
        <asp:TextBox ID="NO_3" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-2" style="text-align: right">หน่วย:</div>
    <div class="col-lg-2">
        <asp:DropDownList ID="DD_UNIT_3" runat="server" DataValueField="UNIT_TERTIARY_ID" DataTextField="UNIT_TERTIARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col-lg-2">จำนวนการผลิต:</div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_Production_Amount" runat="server" TextMode="Number" Height="25px" Width="180px"></asp:TextBox>
        <br />
        <asp:Label ID="lbl_Production_Amount" runat="server" Text="*กรุณากรอกจำนวนการผลิต" ForeColor="Red" Visible="false"></asp:Label>
    </div>
    <div class="col-lg-4">
        &emsp;<asp:Label ID="lbl_Production_Amount_Unit" runat="server" Text=""></asp:Label>
    </div>
    <%--<div class="col-lg-1" style="text-align: right">
        </div>--%>
    <div class="col-lg-2">
    </div>
</div>
<div class="row">
    <div class="col-lg-12" style="text-align: center">
        <asp:Button ID="btn_size_pack" runat="server" Text="เพิ่ม" />
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <telerik:RadGrid ID="RadGrid4" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
            PagerStyle-Mode="NextPrevNumericAndAdvanced" Skin="Hay">
            <MasterTableView DataKeyNames="IDA">
                <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA" HeaderText="IDA" DataType="System.Int32" Display="false"
                        FilterControlAltText="Filter IDA column" ReadOnly="True" SortExpression="IDA">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_IDA_DQ" UniqueName="FK_IDA_DQ" HeaderText="FK_IDA_DQ" FilterControlAltText="Filter FK_IDA_DQ column"
                        SortExpression="FK_IDA_DQ" Display="false">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PACK_F_NAME " UniqueName="PACK_F_NAME" HeaderText="Primary Packaging:" FilterControlAltText="Filter PACK_F_NAME column"
                        SortExpression="PACK_F_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NO_1" UniqueName="NO_1" HeaderText="ขนาด" FilterControlAltText="Filter NO_1 column"
                        SortExpression="NO_1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UNIT_F_NAME " UniqueName="UNIT_F_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_F_NAME column"
                        SortExpression="UNIT_F_NAME">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PACK_S_NAME " UniqueName="PACK_S_NAME" HeaderText="Secondary Packaging:" FilterControlAltText="Filter PACK_S_NAME column"
                        SortExpression="PACK_S_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NO_2" UniqueName="NO_2" HeaderText="ขนาด" FilterControlAltText="Filter NO_2 column"
                        SortExpression="NO_2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UNIT_S_NAME " UniqueName="UNIT_S_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_S_NAME column"
                        SortExpression="UNIT_S_NAME">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="PACK_T_NAME " UniqueName="PACK_T_NAME" HeaderText="Tertiary Packaging:" FilterControlAltText="Filter PACK_T_NAME column"
                        SortExpression="PACK_T_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NO_3" UniqueName="NO_3" HeaderText="ขนาด" FilterControlAltText="Filter NO_3 column"
                        SortExpression="NO_3">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UNIT_T_NAME " UniqueName="UNIT_T_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_T_NAME column"
                        SortExpression="UNIT_T_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PACKAGE_FULL" UniqueName="PACKAGE_FULL" HeaderText="" FilterControlAltText="Filter PACKAGE_FULL column"
                        SortExpression="PACKAGE_FULL">
                    </telerik:GridBoundColumn>

                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                        CommandName="result_delete" UniqueName="result_delete">
                    </telerik:GridButtonColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <div class="col-lg-3" style="text-align: left">ขนาดบรรจุ (รายละเอียดภาชนะบรรจุ)</div>
    <div class="col-lg-9">
        <%--<asp:TextBox ID="txt_packing_size"  Width="80%"  runat="server" Height="30px"></asp:TextBox>--%>
        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_packing_size" ValidationGroup="valGroup1" ErrorMessage="*กรุณากรอกขนาดบรรจุ" runat="server" ForeColor="Red" />--%>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row">
    <div class="col-lg-12"></div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
            PagerStyle-Mode="NextPrevNumericAndAdvanced" Skin="Hay">
            <MasterTableView DataKeyNames="IDA">
                <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA" HeaderText="IDA" DataType="System.Int32" Display="false"
                        FilterControlAltText="Filter IDA column" ReadOnly="True" SortExpression="IDA">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_IDA_DQ" UniqueName="FK_IDA_DQ" HeaderText="FK_IDA_DQ" FilterControlAltText="Filter FK_IDA_DQ column"
                        SortExpression="FK_IDA_DQ" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PACKAGE_FULL" UniqueName="PACKAGE_FULL" HeaderText="ขนาดบรรจุ (รายละเอียดภาชนะบรรจุ)" FilterControlAltText="Filter PACKAGE_FULL column"
                        SortExpression="PACKAGE_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sum_Production" UniqueName="sum_Production" HeaderText="จำนวนการผลิต" FilterControlAltText="Filter sum_Production column"
                        SortExpression="sum_Production">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SUM_PACKAGE" UniqueName="SUM_PACKAGE" HeaderText="ปริมาณ" FilterControlAltText="Filter SUM_PACKAGE column"
                        SortExpression="SUM_PACKAGE">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row">
    <div class="col-lg-3" style="text-align: left">จำนวนหรือปริมาณที่จะผลิต/นำเข้า</div>
    <div class="col-lg-9"></div>
</div>
<div class="row">
    <div class="col-lg-3" style="text-align: left"></div>
    <div class="col-lg-9" style="border-bottom: #999999 1px dotted">
        <asp:TextBox ID="txt_quantity_produced" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_quantity_produced" ValidationGroup="valGroup1" ErrorMessage="*กรุณากรอกขนาดบรรจุ" runat="server" ForeColor="Red" />
    </div>
</div>
<div class="row">
    <div class="col-lg-12" style="text-align: center">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="style_color" ValidationGroup="valGroup1" ErrorMessage="*กรุณากรอกข้อมูลให้ครบถ้วนก่อนบันทึก" runat="server" ForeColor="Red" Font-Size="X-Large" />
    </div>
</div>
<hr />
<div class="row">
    <div class="col-lg-12" style="text-align: center">
        <asp:Button ID="btn_save" CausesValidation="true" ValidationGroup="valGroup1" runat="server" Text="บันทึกส่วนที่ 1" Height="38px" Width="185px" style="border-radius:3px"/>
        <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="38px" Width="150px" style="border-radius:3px"/>
    </div>
</div>
