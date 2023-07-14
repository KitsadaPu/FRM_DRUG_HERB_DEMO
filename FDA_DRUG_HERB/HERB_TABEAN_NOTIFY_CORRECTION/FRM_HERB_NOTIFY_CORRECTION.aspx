<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_PPK.Master" CodeBehind="FRM_HERB_NOTIFY_CORRECTION.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_NOTIFY_CORRECTION" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_DD_HERB_1").searchable();
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
        function Popups2(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
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
    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 70px">

            <div class="col-lg-5">
                <h4>หนังสือแจ้งการแก้ไขรายการในใบสำคัญการขึ้นทะเบียน<asp:Label ID="lbl_name_2" runat="server" Text=""></asp:Label><asp:Label ID="lbl_name" runat="server" Text="">
                </asp:Label>
                </h4>
            </div>
            <div class="col-lg-2" style="margin-top: 10px">
                <p style="text-align: right; padding-right: 3%;">
                    <%--   เลขบัตรผู้ดำเนินฯ--%>
                </p>
            </div>
            <div class="col-lg-2" style="margin-top: 10px">
                <%-- <asp:TextBox ID="txt_bsn" runat="server"></asp:TextBox>--%>
            </div>
            <div class="col-lg-3 col-md-3">
                <asp:Button ID="btn_add" runat="server" Text="เพิ่มคำขอ" CssClass="auto-style1" Height="45px" Width="200px" />
                <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />
                <asp:Button ID="Button1" runat="server" Text="" Style="display: none;" />
            </div>
        </div>
    </div>

    <div style="width: 100%; padding-left: 1%;">
        <div class="row">
            <div class="col-lg-11">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15">
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
                            <telerik:GridBoundColumn DataField="IDA_LCN" DataType="System.Int32" FilterControlAltText="Filter IDA_LCN column"
                                HeaderText="IDA_LCN" ReadOnly="True" SortExpression="IDA_LCN" UniqueName="IDA_LCN" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IDA_LCT" DataType="System.Int32" FilterControlAltText="Filter IDA_LCT column"
                                HeaderText="IDA_LCT" ReadOnly="True" SortExpression="IDA_LCT" UniqueName="IDA_LCT" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter F  K_IDA column"
                                HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                                HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                                HeaderText="TR_ID" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column"
                                HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                            </telerik:GridBoundColumn>
                <%--            <telerik:GridBoundColumn DataField="LCNNO_NEW" FilterControlAltText="Filter LCNNO_NEW column"
                                HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_NEW" UniqueName="LCNNO_NEW">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                                HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RCVNO_FULL" FilterControlAltText="Filter RCVNO_FULL column"
                                HeaderText="เลขรับ" ReadOnly="True" SortExpression="RCVNO_FULL" UniqueName="RCVNO_FULL">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PROCESS_NAME" FilterControlAltText="Filter PROCESS_NAME column"
                                HeaderText="กระบวนงาน" ReadOnly="True" SortExpression="PROCESS_NAME" UniqueName="PROCESS_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DATE_CONFIRM" DataType="System.DateTime" FilterControlAltText="Filter DATE_CONFIRM column"
                                HeaderText="วันที่ยื่นคำขอ" SortExpression="DATE_CONFIRM" UniqueName="DATE_CONFIRM" DataFormatString="{0:dd/MM/yyyy}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LCN_NAME" FilterControlAltText="Filter LCN_NAME column"
                                HeaderText="ชื่อผู้รับ" ReadOnly="True" SortExpression="LCN_NAME" UniqueName="LCN_NAME">
                            </telerik:GridBoundColumn>
                          <%--  <telerik:GridBoundColumn DataField="NAME_THAI" FilterControlAltText="Filter fulladdr column"
                                HeaderText="ชื่อไทย" SortExpression="NAME_THAI" UniqueName="NAME_THAI">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                                HeaderText="สถานนะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                                CommandName="sel" Text="ดูข้อมูล">
                                <HeaderStyle Width="70px" />
                            </telerik:GridButtonColumn>
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


        <div class="h5" style="padding-left: 87%;">
            <asp:HyperLink ID="hl_pay" runat="server" Target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
        </div>
    </div>
    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียดคำขอ
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 800px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>


