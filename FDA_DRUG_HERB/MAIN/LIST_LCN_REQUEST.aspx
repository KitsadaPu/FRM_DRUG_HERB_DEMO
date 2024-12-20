﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="LIST_LCN_REQUEST.aspx.vb" Inherits="FDA_DRUG_HERB.LIST_LCN_REQUEST" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 83.33333333%;
            left: 7px;
            top: -411px;
            padding-left: 7px;
            padding-right: 7px;
        }
        .auto-style2 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 8.33333333%;
            left: 7px;
            top: -472px;
            padding-left: 7px;
            padding-right: 7px;
        }
        
        .panel {
            margin-bottom:0px;
            background: white;
        }
        .panel-body {
            background: white;
        }
    </style>
        <script type="text/javascript">

            function Popups1(url) { // สำหรับทำ Div Popup
                $('#myModal1').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }
            function Popups2(url) { // สำหรับทำ Div Popup
                $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f2'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }
            function close_modal1() { // คำสั่งสั่งปิด PopUp
                $('#myModal1').modal('hide');
                $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
            }
            function close_modal2() { // คำสั่งสั่งปิด PopUp
                $('#myModal2').modal('hide');
                $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
            }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="auto-style1">
            <h1>รายการคำขอจัดการสถานที่</h1>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-10"></div>
        <div class="col-lg-1">
            <asp:Button ID="Button1" runat="server" Text="เพิ่มคำขอ" CssClass="btn-lg" Width="80%" />
        </div>
        <div class="auto-style2"></div>
    </div>
    <telerik:RadGrid ID="rgns" runat="server" Width="90%" CellSpacing="0" GridLines="None">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
            <Columns>
                <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                    HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ID_DALCN_FIX" FilterControlAltText="Filter IDA column"
                    HeaderText="ID_DALCN_FIX" SortExpression="ID_DALCN_FIX" UniqueName="ID_DALCN_FIX" Display="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="rcbno" FilterControlAltText="Filter PROCESS_ID column"
                    HeaderText="เลขรับ" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter LOCATION_ADDRESS_IDA column"
                    HeaderText="เลขดำเนินการ" SortExpression="LOCATION_ADDRESS_IDA" UniqueName="LOCATION_ADDRESS_IDA">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="STATUS_NAME" HeaderText="สถานะ" FilterControlAltText="Filter SIMINAR_DATE column"
                    SortExpression="SIMINAR_DATE" UniqueName="LCNNO_MANUAL">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sele"
                    CommandName="sele" Text="เลือกข้อมูล">
                    <HeaderStyle Width="70px" />
                </telerik:GridButtonColumn>

            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none" />
    <div class="modal fade" id="myModal1">
        <div class="panel panel-info" style="width: 100%; height:100%">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label>
                </h1>
            </div>
            <%--<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>--%>
            <div class="panel-body">
                <iframe id="f1" style="width: 100%; height:100%"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>

    <div class="modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%; height:100%">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </h1>
            </div>
            <%--<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>--%>
            <div class="panel-body">
                <iframe id="f2" style="width: 100%; height:100%"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>


</asp:Content>
