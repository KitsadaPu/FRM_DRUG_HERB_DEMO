<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_HERB_TABEAN_RENEW_STAFF.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_RENEW_STAFF" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link href="../css/css_radgrid.css" rel="stylesheet" />--%>
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">



        $(document).ready(function () {
            //$(window).load(function () {
            //    $.ajax({
            //        type: 'POST',
            //        data: { submit: true },
            //        success: function (result) {
            //            $('#spinner').fadeOut(1);

            //        }
            //    });
            //});

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ContentPlaceHolder1_btn_upload').click(function () {
                Popups('POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx');
                return false;
            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
                return false;
            });

            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }






        });

        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function Popups3(url) { // สำหรับทำ Div Popup

            $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f2'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function close_modal2() { // คำสั่งสั่งปิด PopUp
            $('#myModal2').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }
    </script>

    <%--  <div style="text-align:center;" >  เลขที่ใบอนุญาตสถานที่&nbsp;&nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="ddl_lcnno" runat="server" CssClass="input-lg"  Width="20%"></asp:DropDownList> &nbsp;
       <asp:Button ID="Btn_ok" runat="server" Text="ยืนยัน" CssClass="btn-info" Width="67px"/>
       <br />
    </div>--%>
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>


    <div class="h3" style="padding-left: 5%;">
        <asp:Label ID="lbl_name" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 70px">

            <div class="col-lg-4 col-md-4">
                <h4>คำขอต่ออายุทะเบียน</h4>
            </div>

        </div>

    </div>

    <div class="panel panel-body" style="width: 100%; padding-left: 5%;">
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
                    <telerik:GridBoundColumn DataField="FK_LCN" DataType="System.Int32" FilterControlAltText="Filter FK_LCN column"
                        HeaderText="FK_LCN" ReadOnly="True" SortExpression="FK_LCN" UniqueName="FK_LCN" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID_LCN" DataType="System.Int32" FilterControlAltText="Filter TR_ID_LCN column"
                        HeaderText="TR_ID_LCN" ReadOnly="True" SortExpression="TR_ID_LCN" UniqueName="TR_ID_LCN" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="IDA_LCT" DataType="System.Int32" FilterControlAltText="Filter IDA_LCT column"
                        HeaderText="IDA_LCT" ReadOnly="True" SortExpression="IDA_LCT" UniqueName="IDA_LCT" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter F  K_IDA column"
                        HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DD_HERB_NAME_ID" DataType="System.Int32" FilterControlAltText="Filter DD_HERB_NAME_ID column"
                        HeaderText="DD_HERB_NAME_ID" ReadOnly="True" SortExpression="DD_HERB_NAME_ID" UniqueName="DD_HERB_NAME_ID" Display="false">
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
                    <telerik:GridBoundColumn DataField="LCNNO_DISPLAY_NEW" FilterControlAltText="Filter LCNNO_DISPLAY_NEW column"
                        HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_DISPLAY_NEW" UniqueName="LCNNO_DISPLAY_NEW">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                        HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID">
                    </telerik:GridBoundColumn>                   
                    <telerik:GridBoundColumn DataField="DATE_CONFIRM" DataType="System.DateTime" FilterControlAltText="Filter DATE_CONFIRM column"
                        HeaderText="วันที่ยื่นคำขอ" SortExpression="DATE_CONFIRM" UniqueName="DATE_CONFIRM" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="rcvdate" FilterControlAltText="Filter rcvdate column"
                        HeaderText="วันที่รับคำขอ" ReadOnly="True" SortExpression="rcvdate" UniqueName="rcvdate" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RCVNO_NEW" FilterControlAltText="Filter RCVNO_NEW column"
                        HeaderText="เลขรับ" ReadOnly="True" SortExpression="RCVNO_NEW" UniqueName="RCVNO_NEW">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                        HeaderText="เลขทะเบียน" ReadOnly="True" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCN_NAME" FilterControlAltText="Filter LCN_NAME column"
                        HeaderText="ชื่อผู้รับอนุญาต" ReadOnly="True" SortExpression="LCN_NAME" UniqueName="LCN_NAME">
                    </telerik:GridBoundColumn>
          <%--          <telerik:GridBoundColumn DataField="NAME_THAI" FilterControlAltText="Filter fulladdr column"
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
    <div class="modal fade " id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    เสนอลงนาม
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 800px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />

    &nbsp;
</asp:Content>
