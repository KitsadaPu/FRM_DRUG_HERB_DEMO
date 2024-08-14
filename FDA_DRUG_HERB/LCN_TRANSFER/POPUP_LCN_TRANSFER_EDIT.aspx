<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_TRANSFER_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_TRANSFER_EDIT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/LCN_PHR/UC/UC_PHR_DETAIL.ascx" TagPrefix="uc1" TagName="UC_PHR_DETAIL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row" style="background-color: whitesmoke">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="row" runat="server" id="Div1" style="border-block-color: slategray; border-style: initial; background-color: white">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10" style="text-align: center">
                            <h2>รายละเอียดที่ต้องแก้ไข</h2>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>

                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10">
                            <telerik:RadGrid ID="RG_StaffFile" runat="server">
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
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="row" runat="server" id="Check_Edit" visible="false" style="border-block-color: slategray; border-style: initial; background-color: white">
                    <div class="row">
                        <%--<div class="col-lg-1"></div>--%>
                        <div class="col-lg-10" style="text-align: left; padding-left: 5em">
                            <h2 style="color: red">รายละเอียดที่ต้องแก้ไข</h2>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server" id="DIV_SHOW_TXT_EDIT_TB1">
                        <div class="row" runat="server">
                            <div class="col-lg-2" style="text-align: left; padding-left: 5em; color: red">หมายเหตุการแก้ไขข้อมูล</div>
                            <div class="col-lg-1"></div>
                        </div>
                        <div class="row">
                            <%--<div class="col-lg-1"></div>--%>
                            <div class="col-lg-6" style="text-align: left; padding-left: 6em">
                                <asp:TextBox ID="TXT_EDIT_NOTE" TextMode="MultiLine" runat="server" Style="height: 120px; width: 1360px;" ReadOnly="true" ForeColor="Red"></asp:TextBox>
                            </div>
                            <div class="col-lg-1"></div>
                        </div>
                    </div>
                    <div class="row">
                        <%--<div class="col-lg-1"></div>--%>
                        <div class="col-lg-10">
                            <asp:Panel ID="Panel1" runat="server" >
                                <div class="row">
                                    <div class="col-lg-5"></div>
                                    <div class="col-lg-7">
                                        <h2>คำขอโอนใบอนุญาต</h2>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-5"></div>
                                    <div class="col-lg-7 ">
                                        <asp:RadioButtonList ID="rdl_lcn_type" runat="server" Enabled="true">
                                            <asp:ListItem Value="1">ผลิตผลิตภัณฑ์สมุนไพร</asp:ListItem>
                                            <asp:ListItem Value="2">นำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                                            <asp:ListItem Value="3">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-9"></div>
                                    <div class="col-lg-1" style="text-align: right;">
                                        เขียนที่              
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:TextBox ID="Txt_Write_At" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-9"></div>
                                    <div class="col-lg-1" style="text-align: right;">
                                        วันที่
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:TextBox ID="txt_Write_Date" runat="server" Width="80%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>

                                <div style="padding-top: 5px"></div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_name" runat="server" Text="ข้าพเจ้า"></asp:Label>
                                    </div>
                                    <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_name" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_name_lcn" runat="server" Text="(ชื่อผู้รับอนุญาต)"></asp:Label>
                                    </div>
                                    <div class="col-lg-2"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_bsn_name" runat="server" Text="ซึ่งมีผู้มีหน้าที่ปฏิบัติการชื่อ"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="text-align: left; border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_bsn_name" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_niti" runat="server" Text="(เฉพาะกรณีนิติบุคคล)"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcnno" runat="server" Text="ตามใบอนุญาตเลขที่"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_lcnno" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:Label ID="lbl_name_business" runat="server" Text="ณ สถานที่ประกอบธุรกิจชื่อ"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_name_business" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-4"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_location_trnf" runat="server" Text="อยู่เลขที่"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_location_trnf" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:Label ID="lbl_trnf_building" runat="server" Text="หมู่บ้าน/อาคาร"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_trnf_building" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_trnf_mu" runat="server" Text="หมู่ที่"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_trnf_mu" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:Label ID="lbl_trnf_soi" runat="server" Text="ตรอก/ซอย"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_trnf_soi" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-4"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_trnf_road" runat="server" Text="ถนน"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_trnf_road" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-8"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_trnf_tambol" runat="server" Text="ตำบลแขวง"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_trnf_tambol" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:Label ID="lbl_trnf_amphor" runat="server" Text="อำเภอเขต"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_trnf_amphor" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-4"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_trnf_changwat" runat="server" Text="จังหวัด"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_trnf_changwat" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:Label ID="lbl_trnf_zipcode" runat="server" Text="รหัสไปรษณีย์"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_trnf_zipcode" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-5"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcn_tel" runat="server" Text="โทรศัพท์"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_lcn_tel" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:Label ID="lbl_time_work" runat="server" Text="เวลาทำการ"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <%-- <telerik:RadTimePicker ID="RadTimePicker1" runat="server"></telerik:RadTimePicker>--%>
                                        <asp:TextBox ID="txt_time_work" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-5"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_trnf_iden" runat="server" Text="เลขประจำตัวประชาชน"></asp:Label>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:TextBox ID="txt_trnf_iden" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-7"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2" style="text-align: right">
                                        <h3>กรณีบุคคลต่างด่าว ระบุ</h3>
                                        <%--<asp:Label ID="lbl_personal_type" runat="server" Text="กรณีบุคคลต่างด่าว ระบุ"></asp:Label>--%>
                                    </div>
                                    <div class="col-lg-8"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_PASSPORT_NO" runat="server" Text="หนังสือเดินทางเลขที่"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:TextBox ID="txt_PASSPORT_NO" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:Label ID="lbl_PASSPORT_EXPDATE" runat="server" Text="วันหมดอายุ"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        <telerik:RadDatePicker ID="RDP_PASSPORT_EXPDATE" runat="server">
                                        </telerik:RadDatePicker>
                                    </div>
                                    <div class="col-lg-7"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_DOC_NO" runat="server" Text="ใบอนุญาตทำงานหรือใบสำคัญถิ่นที่อยู่เลขที่"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:TextBox ID="txt_DOC_NO" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:Label ID="lbl_DOC_NO_EXPDATE" runat="server" Text="วันหมดอายุ"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        <telerik:RadDatePicker ID="RDP_DOC_NO_EXPDATE" runat="server">
                                        </telerik:RadDatePicker>
                                    </div>
                                    <div class="col-lg-3"></div>
                                </div>

                                <div style="padding-top: 60px"></div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2" style="text-align: right">
                                        <asp:Label ID="lbl_transfer_to" runat="server" Text="มีความประสงค์ขอโอนใบอนุญาตฯ ให้แก่"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:TextBox ID="txt_ctzid_lcn" runat="server"></asp:TextBox>
                                        <asp:Button ID="btn_search_lcn" runat="server" Text="ค้นหา" />
                                        <asp:HiddenField ID="hf_lcn" runat="server" />
                                        <br />
                                        <%-- <asp:TextBox ID="txt_transfer_to" runat="server"></asp:TextBox>--%>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:Label ID="txt_transfer_to" runat="server" Text="-"></asp:Label>
                                    </div>
                                    <div class="col-lg-1" style="text-align: left">
                                        <asp:Label ID="lbl_trnf_name" runat="server" Text="(ผู้รับโอน)"></asp:Label>
                                    </div>
                                    <div class="col-lg-3"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_operator_name" runat="server" Text="โดยมีผู้ดำเนินกิจการชื่อ"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:TextBox ID="txt_ctzid" runat="server"></asp:TextBox>
                                        <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
                                        <asp:HiddenField ID="hf_bsn" runat="server" />
                                        <br />
                                        <%-- <asp:TextBox ID="txt_transfer_to" runat="server"></asp:TextBox>--%>
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                        <asp:Label ID="operator_name" runat="server" Text="-"></asp:Label>
                                    </div>
                                    <%--   <div class="col-lg-1" style="text-align: left">
            <asp:Label ID="Label2" runat="server" Text="(ผู้รับโอน)"></asp:Label>
        </div>--%>
                                    <%--  <div class="col-lg-4">
            <asp:TextBox ID="txt_operator_name" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-5"></div>--%>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_start_trnf" runat="server" Text="ตั้งแต่วันที่"></asp:Label>
                                    </div>
                                    <div class="col-lg-1">
                                        <telerik:RadDatePicker ID="RPD_start_trnf" runat="server">
                                        </telerik:RadDatePicker>
                                        <%--<asp:TextBox ID="txt_start_trnf" runat="server"></asp:TextBox>--%>
                                    </div>
                                    <div class="col-lg-8"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_trnf_remark" runat="server" Text="เนื่องจาก"></asp:Label>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="txt_trnf_remark" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-5"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <asp:Label ID="Label3" runat="server" Text="และข้าพเจ้า (ผู้โอน) ขอส่งคืนใบอนุญาตและขอยกเลิกใบอนุญาตฯ ของข้าพเจ้า นับตั้งแต่ผู้รับโอนได้รับอนุญาตจากผู้รับอนุญาต"></asp:Label>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label4" runat="server" Text="พร้อมนี้ผู้รับโอนได้แนบหลักฐานมาด้วยคือ"></asp:Label>
                                    </div>
                                    <div class="col-lg-5"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <asp:Label ID="Label5" runat="server" Text="๑. คำขอรับใบอนุญาตผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร (สมพ.๑) และเอกสารที่เกี่ยวข้องตามแบบ สมพ.๑"></asp:Label>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-5">
                                        <asp:Label ID="Label6" runat="server" Text="๒. เอกสารหลักฐานอื่น ๆ (ถ้ามี)"></asp:Label>
                                    </div>
                                    <div class="col-lg-6"></div>
                                </div>

                            </asp:Panel>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="row" runat="server" id="Check_Edit_Uplaod" visible="false" style="border-block-color: slategray; border-style: initial; background-color: white">
                    <div id="panel_edit_up" style="border-radius: 10px">
                        <div class="row">
                            <div class="col-lg-10">
                                <div class="row">
                                    <%--<div class="col-lg-1"></div>--%>
                                    <div class="col-lg-10" style="text-align: left; padding-left: 5em">
                                        <h2 style="color: red">เอกสารแนบที่ต้องแก้ไข</h2>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                            </div>
                            <div class="col-lg-1"></div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row" runat="server" id="DIV_EDIT_UPLOAD1">
                                    <div class="row" runat="server">
                                        <div class="col-lg-5" style="text-align: left; padding-left: 5em; color: red">หมายเหตุการแก้ไขเอกสาร</div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6" style="text-align: left; padding-left: 6em">
                                            <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 150px; width: 700px;" ReadOnly="true" ForeColor="Red"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="row" runat="server">
                                    <div class="col-lg-5" style="text-align: left; padding-left: 5em; color: red">เอกสารแนบเดิม</div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <telerik:RadGrid ID="RG_Edit" runat="server">
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
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10" style="text-align: left">
                                <h2>เอกสารที่ต้องแนบใหม่</h2>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div style="text-align: left; padding-left: 2em; padding-right: 2em">
                                    <asp:Table ID="tb_upload_file" runat="server" CssClass="table" Width="100%"></asp:Table>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div style="text-align: left; padding-left: 2em; padding-right: 2em">
                                    <asp:Button ID="btn_add_no" runat="server" Text="อัพโหลดเอกสารแนบ" Height="35px" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
            </div>
        </div>
    </footer>
</asp:Content>
