<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_SOMORPO4_MAIN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_SOMORPO4_MAIN" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
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
                <h4>ผู้มีหน้าที่ปฏิบัติการ</h4>
            </div>

        </div>

    </div>

    <div class="panel panel-body" style="width: 100%; padding-left: 5%;">
        <telerik:RadGrid ID="rgphr" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True" Width="100%">
            <MasterTableView AutoGenerateColumns="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                        SortExpression="PHR_IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PHR_CTZNO" FilterControlAltText="Filter PHR_CTZNO column"
                        HeaderText="เลขบัตรปชช." SortExpression="PHR_CTZNO" UniqueName="PHR_CTZNO">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PHR_FULLNAME" FilterControlAltText="Filter PHR_FULLNAME column"
                        HeaderText="ชื่อผู้มีหน้าที่ปฏิบัติการ" SortExpression="PHR_FULLNAME" UniqueName="PHR_FULLNAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PHR_TEXT_WORK_TIME" FilterControlAltText="Filter PHR_TEXT_WORK_TIME column"
                        HeaderText="เวลาทำการ" SortExpression="PHR_TEXT_WORK_TIME" UniqueName="PHR_TEXT_WORK_TIME">
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridBoundColumn DataField="lcnsid" FilterControlAltText="Filter lcnsid column"
                           HeaderText="รหัสผู้ประกอบการ" SortExpression="lcnsid" UniqueName="lcnsid">
                       </telerik:GridBoundColumn>--%>
                    <%--<telerik:GridBoundColumn DataField="house_no" FilterControlAltText="Filter house_no column"
                           HeaderText="เลขสถานที่" SortExpression="house_no" UniqueName="house_no">
                       </telerik:GridBoundColumn>--%>
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                        HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PHR_TEXT_NUM" FilterControlAltText="Filter PHR_TEXT_NUM column"
                        HeaderText="เลขที่ใบอนุญาต" SortExpression="PHR_TEXT_NUM" UniqueName="PHR_TEXT_NUM" AllowFiltering="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                        CommandName="sel" Text="ดูข้อมูล">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_edit"
                        CommandName="_edit" Text="แก้ไขการเสนอลงนาม">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    <div class=" modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label>
                </h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f1" style="width: 100%; height: 550px;"></iframe>
            </div>
            <div class="panel-footer"></div>
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

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />

    &nbsp;
</asp:Content>
