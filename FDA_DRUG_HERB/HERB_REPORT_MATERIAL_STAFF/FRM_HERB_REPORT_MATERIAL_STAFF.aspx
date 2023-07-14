<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_NOTIFIED_STAFF.Master" CodeBehind="FRM_HERB_REPORT_MATERIAL_STAFF.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_REPORT_MATERIAL_STAFF" %>

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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row" id="T1" runat="server">
        <p class="h3">ข้อมูลการรายงานในส่วนที่เกี่ยวข้องกับกำรผลิต / นำเข้า /ขาย ผลิตภัณฑ์สมุนไพร หรือวัตถุดิบสมุนไพร</p>
        <hr />
<%--        <div class="row" runat="server" id="TH1">
            <div class="col-lg-10" >
            </div>
            <div class="col-lg-1" style=" text-align: left; height: 44px;">
                <asp:Button ID="btn_tb_herb" runat="server" Text="เพิ่มรายงาน" Height="39px" Width="191px" />
            </div>
        </div>--%>
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="25" AllowFilteringByColumn="True">
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
  <%--                  <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                        HeaderText="TR_ID" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                    </telerik:GridBoundColumn>--%>
                    <telerik:GridBoundColumn DataField="FK_LCN" DataType="System.Int32" FilterControlAltText="Filter FK_LCN column"
                        HeaderText="FK_LCN" ReadOnly="True" SortExpression="FK_LCN" UniqueName="FK_LCN" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column"
                        HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                        HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                        HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DATE_CONFIRM" DataType="System.DateTime" FilterControlAltText="Filter DATE_CONFIRM column"
                        HeaderText="วันที่ส่งเรื่อง" SortExpression="DATE_CONFIRM" UniqueName="DATE_CONFIRM" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="CREATE_DATE" DataType="System.DateTime" FilterControlAltText="Filter CREATE_DATE column"
                        HeaderText="วันที่สร้างคำขอ" SortExpression="CREATE_DATE" UniqueName="CREATE_DATE" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RCVNO_NEW" FilterControlAltText="Filter RCVNO_NEW column"
                        HeaderText="เลขรับ" ReadOnly="True" SortExpression="RCVNO_NEW" UniqueName="RCVNO_NEW">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCNNO_DISPLAY_NEW" FilterControlAltText="Filter LCNNO_DISPLAY_NEW column"
                        HeaderText="เลขใบอนุญาต" ReadOnly="True" SortExpression="LCNNO_DISPLAY_NEW" UniqueName="LCNNO_DISPLAY_NEW">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                        HeaderText="ชื่อวัตถุดิบ/ชื่อผลิตภัณฑ์สมุนไพร" SortExpression="Name" UniqueName="Name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="thanm" FilterControlAltText="Filter thanm column"
                        HeaderText="ชื่อผู้รับอนุญาต" SortExpression="thanm" UniqueName="thanm">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                        HeaderText="สถานนะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ดูรายละเอียด"
                        CommandName="HL_SELECT" UniqueName="HL_SELECT">
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

    <div class=" modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_head1" runat="server" Text="รายละเอียดทะเบียน"></asp:Label></h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f1" style="width: 100%; height: 800px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />

</asp:Content>

