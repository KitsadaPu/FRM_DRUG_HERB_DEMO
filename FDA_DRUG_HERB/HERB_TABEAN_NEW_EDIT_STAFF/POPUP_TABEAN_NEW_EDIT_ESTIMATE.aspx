﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_NEW_EDIT_ESTIMATE.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_NEW_EDIT_ESTIMATE" %>


<%@ Register Src="../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_DATE_REQ"));
            $("#ContentPlaceHolder1_DD_OFF_REQ").searchable();
        });
        function Popups(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }

        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function spin_space() { // คำสั่งสั่งปิด PopUp
            $('#spinner').toggle('slow');
        }

        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-8" style="width: 70%">
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-6">
                    <asp:Label ID="Label3" runat="server" Text="สร้างคำขอโดย:" Font-Size="Large"></asp:Label>
                    <asp:Label ID="lbl_create_by" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label2" runat="server" Text="สร้างคำขอเมื่อ:" Font-Size="Large"></asp:Label>
                    <asp:Label ID="lbl_create_date" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div class="row" runat="server" id="KEEP_PAY" visible="true">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">เลือกสถานะ</div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="DD_STATUS" runat="server" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" AutoPostBack="true" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server" id="P12" visible="true">
                    <div class="row" runat="server" id="P14" visible="false">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เลขรับ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="ROVNO_FULL" runat="server" Style="width: 100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>

                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">วันที่ตรวจรับคำขอ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="DATE_REQ" runat="server" Style="width: 90%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">จนท. ที่รับผิดชอบ</div>
                        <div class="col-lg-6">
                            <%--<asp:TextBox ID="OFF_REQ" runat="server" Style="width: 100%"></asp:TextBox>--%>
                            <%--<asp:DropDownList ID="DD_OFF_REQ" runat="server" DataValueField="IDA" DataTextField="STAFF_NAME" Width="100%"></asp:DropDownList>--%>
                            <telerik:RadComboBox ID="DD_OFF_REQ" runat="server" Filter="Contains" Width="100%" AutoPostBack="true"></telerik:RadComboBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <hr />
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">หมายเหตุ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txt_remark_edit" TextMode="MultiLine" ReadOnly="true" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>

                <div class="row" runat="server" id="uc_upload1" visible="false">
                    <div class="col-lg-1"></div>
                    <%--<div class="col-lg-2">
                       <h3>อัพโหลดเอกสาร ทบ.3 ที่อนุมัติแล้ว</h3>
                    </div>--%>
                    <div class="col-lg-8" style="text-align: left">
                        <uc1:UC_ATTACH ID="UC_ATTACH2" runat="server" />
                    </div>
                </div>
            </div>

            <div class="row" runat="server" id="p2" visible="false">
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">เนื่องจาก</div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="DDL_CANCLE_REMARK" runat="server" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">รายละเอียดการยกเลิก</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="NOTE_CANCLE" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
                        <%--<asp:Label ID="chk_file2" runat="server" Text="lbl_2"></asp:Label>--%>
                    </div>
                </div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="80%" />
                    <%--<asp:Button ID="btn_keep_pay" runat="server" Text="ข้ามสถานะ" CssClass="btn-lg" Width="80%" Visible="false" />--%>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" runat="server" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_upload_file" runat="server" Text="แนบเอกสารเพิ่ม" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <%--<asp:Button ID="BTN_PREVIEW" runat="server" Text="PREVIEW" CssClass="btn-lg" Width="80%" Visible="false" />--%>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />

            <div class="row" id="ADDR_FOREIGN_CHK" runat="server" visible="false">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:TextBox ID="Txt_Txt_Addr_to_Staff" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div runat="server" id="AT_FILE">
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารแนบคำขอ</h3>
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
            <div runat="server" id="AT_FILE_Edit" visible="false">
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารแนบคำขอ(แก้ไขตามบันทึกข้อบกพร่อง)</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" style="width: 100%; padding-left: 2em; padding-right: 2em">
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
                <hr />
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารแนบเจ้าหน้าที่สั่งแก้ไข</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" style="width: 100%; padding-left: 2em; padding-right: 2em">
                        <telerik:RadGrid ID="RadGrid4" runat="server">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn AllowFiltering="true" DataField="IDA" DataType="System.Int32" Display="false" FilterControlAltText="Filter IDA column" HeaderText="IDA" SortExpression="IDA" UniqueName="IDA">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn AllowFiltering="true" DataField="FK_IDA" DataType="System.Int32" Display="false" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DOCUMENT_NAME" FilterControlAltText="Filter DOCUMENT_NAME column" HeaderText="รายการเอกสาร" SortExpression="DOCUMENT_NAME" UniqueName="DOCUMENT_NAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column" HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="PV_SELECT" runat="server">ดูเอกสาร</asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                            </MasterTableView>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">
                        <asp:Label ID="Label1" runat="server" Text="เจ้าหน้าที่ส่งเรื่องแก้ไข:" Font-Size="small"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="STAFF_NAME" Text="-" TextMode="SingleLine" runat="server" Style="height: 20%; width: 100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">
                        <asp:Label ID="Label6" runat="server" Text="วันที่ส่งเรื่องแก้ไข:" Font-Size="small"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txt_edit_date" Text="-" TextMode="SingleLine" runat="server" Style="height: 20%; width: 100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server" id="div_cm_staff">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">รายละเอียดการแก้ไข</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txt_edit_staff" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <hr />
            </div>
        </div>
    </div>
</asp:Content>