﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_PPK.Master" CodeBehind="FRM_TABEAN_SUBSTITUTE_SUB_DR.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_SUBSTITUTE_SUB_DR" %>


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
    <div class="row">
        <div class="col-lg-12" style="text-align: center">คำขอใบแทนใบสำคัญ</div>
    </div>

    <div class="row">
         <div class="col-lg-12" style="text-align:right">
             <asp:Button ID="btn_add_tabean" runat="server" Text="เพิ่มคำขอใบแทนใบสำคัญ" />
                 <asp:Button ID="Button1" runat="server" Text="reload" Style="display: none" />
         </div>
    </div>

    <div class="row">
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
                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                        HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                        HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID" >
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column"
                        HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                    </telerik:GridBoundColumn> 
                    <telerik:GridBoundColumn DataField="RCVNO" DataType="System.Int32" FilterControlAltText="Filter RCVNO column"
                        HeaderText="เลขที่รับคำขอ" ReadOnly="True" SortExpression="RCVNO" UniqueName="RCVNO">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                        HeaderText="เลขที่ทะเบียน" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NAME_THAI" FilterControlAltText="Filter NAME_THAI column" HeaderText="ชื่อยา" ReadOnly="True" SortExpression="NAME_THAI" UniqueName="NAME_THAI">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NAME_ENG" FilterControlAltText="Filter NAME_ENG column" HeaderText="ชื่อยา อังกฤษ" SortExpression="NAME_ENG" UniqueName="NAME_ENG">
                    </telerik:GridBoundColumn> 
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column" HeaderText="สะถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                    </telerik:GridBoundColumn>
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

    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด คำขอ
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
                    <asp:Label ID="lbl_head1" runat="server" Text="รายละเอียด คำขอ"></asp:Label></h1>
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
