<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Auto_Menu.Master" CodeBehind="FRM_PHR_HERB.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_PHR_HERB" %>


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
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <div class="row">
        <div class="col-lg-12" style="text-align: center;">
            <h3>คำรับรองของผู้มีหน้าที่ปฏิบัติการ</h3>
        </div>
    </div>
    <%--  <div style="text-align: left; width: 100%">
    </div>--%>
    <div class="row" id="T1" runat="server">
        <div style="height: 10px"></div>
        <div class="row">
            <div class="col-lg-2">
                <p class="h4">ข้อมูล</p>
            </div>
            <div class="col-lg-8">
            </div>
            <div class="col-lg-1">
                <asp:Button ID="btn_add" runat="server" Text="เพิ่มคำรับรอง" CssClass="auto-style1" Height="45px" Width="200px" />
            </div>

        </div>
        <div class="row">
            <div class="col-lg-12">
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
                            <telerik:GridBoundColumn DataField="PHR_IDA" DataType="System.Int32" FilterControlAltText="Filter PHR_IDA column"
                                HeaderText="PHR_IDA" ReadOnly="True" SortExpression="PHR_IDA" UniqueName="PHR_IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                                HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="phr_status" FilterControlAltText="Filter phr_status column"
                                HeaderText="phr_status" ReadOnly="True" SortExpression="phr_status" UniqueName="phr_status" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PHR_NAME" FilterControlAltText="Filter PHR_NAME column"
                                HeaderText="ชื่อผู้มีหน้าที่ปฏิบัติการ" ReadOnly="True" SortExpression="PHR_NAME" UniqueName="PHR_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PHR_TEXT_NUM" FilterControlAltText="Filter PHR_TEXT_NUM column"
                                HeaderText="เลขใบอนุญาต" ReadOnly="True" SortExpression="PHR_TEXT_NUM" UniqueName="PHR_TEXT_NUM">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="STUDY_LEVEL" FilterControlAltText="Filter STUDY_LEVEL column"
                                HeaderText="สาขา" ReadOnly="True" SortExpression="STUDY_LEVEL" UniqueName="STUDY_LEVEL">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BUSINESS_NAME" FilterControlAltText="Filter BUSINESS_NAME column"
                                HeaderText="ชื่อสถานที่ประกอบธุรกิจ" ReadOnly="True" SortExpression="BUSINESS_NAME" UniqueName="BUSINESS_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BSN_OPENTIME" FilterControlAltText="Filter BSN_OPENTIME column"
                                HeaderText="เวลาทำการ" ReadOnly="True" SortExpression="BSN_OPENTIME" UniqueName="BSN_OPENTIME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                                HeaderText="สถานะ" ReadOnly="True" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                            </telerik:GridBoundColumn>
                            <%--   <telerik:GridBoundColumn DataField="" FilterControlAltText="Filter STATUS_NAME column"
                        HeaderText="สถานนะ" SortExpression="" UniqueName="">
                    </telerik:GridBoundColumn>--%>
                            <telerik:GridButtonColumn ButtonType="LinkButton" Text="ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
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
        </div>
    </div>

    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด คำรับรอง
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">
                    <iframe id="f1" style="width: 100%; height: 800px;"></iframe>
                </div>
            </div>
        </div>
    </div>

    <div class=" modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_head1" runat="server" Text="รายละเอียด คำรับรอง"></asp:Label></h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f2" style="width: 100%; height: 800px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />

</asp:Content>
