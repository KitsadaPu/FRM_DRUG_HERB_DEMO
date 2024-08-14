<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_PPK.Master" CodeBehind="FRM_HERB_TABEAN_TRANSFER.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_TRANSFER" %>

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
    <div class="panel panel-body" style="width: 100%; height: 780px; padding-left: 1em">
        <div class="panel" style="text-align: left; width: 100%">
            <div style="height: 70px">
                <p class="h3" style="text-align: left; border-bottom: 3px solid gray;"><span style="color: rgb(102, 102, 102); font-family: SUKHUMVIT; font-size: 30px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 500; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">คำขออนุญาตผลิตภัณฑ์สมุนไพรแบบอ้างอิง (transfer)</span></p>
            </div>
            <div style="padding-top: 30px"></div>
        </div>
        <div class="row">
            <div class="col-lg-5">
                <p class="h4" style="text-align: left;padding-left:1em">รายการคำขอหนังสือแจ้งการแก้ไข</p>
            </div>
            
            <div class="col-lg-2" style="margin-top: 10px; text-align: right">
                <p style="text-align: right; padding-right: 3%;">
                    เลขทะเบียน
                </p>
            </div>
            <div class="col-lg-3" style="margin-top: 10px">
                <asp:DropDownList ID="DD_TABEAN_NO" runat="server" BackColor="White" Width="100%" SkinID="bootstrap"></asp:DropDownList>
            </div>
            <div class="col-lg-2 col-md-2" style="text-align: right">
                <asp:Button ID="btn_add" runat="server" Text="เพิ่มคำขอ transfer" CssClass="auto-style1" Height="45px" Width="200px" />
                <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />
                <asp:Button ID="Button1" runat="server" Text="" Style="display: none;" />
            </div>
        </div>
        <%--<div class="panel" style="text-align: left; width: 100%">
            <div class="panel-heading panel-title" style="height: 70px">
                <div class="row">
                    <div class="col-lg-10">
                        <h4>คำขออนุญาตผลิตภัณฑ์สมุนไพรแบบอ้างอิง (transfer)<asp:Label ID="lbl_name_2" runat="server" Text=""></asp:Label><asp:Label ID="lbl_name" runat="server" Text=""> </asp:Label>
                        </h4>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6" style="margin-top: 10px; text-align: right">
                        <p style="text-align: right; padding-right: 3%;">
                            เลขทะเบียน
                        </p>
                    </div>

                    <div class="col-lg-3">
                    </div>
                </div>

            </div>
        </div>--%>
        <div style="width: 100%; padding-left: 1%;">
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
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                                    HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_LCN" DataType="System.Int32" FilterControlAltText="Filter FK_LCN column"
                                    HeaderText="FK_LCN" ReadOnly="True" SortExpression="FK_LCN" UniqueName="FK_LCN" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_LCT" DataType="System.Int32" FilterControlAltText="Filter FK_LCT column"
                                    HeaderText="FK_LCT" ReadOnly="True" SortExpression="FK_LCT" UniqueName="FK_LCT" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                                    HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_DRRQT" DataType="System.Int32" FilterControlAltText="Filter FK_DRRQT column"
                                    HeaderText="FK_DRRQT" ReadOnly="True" SortExpression="FK_DRRQT" UniqueName="FK_DRRQT" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_TABEAN_HERB" DataType="System.Int32" FilterControlAltText="Filter FK_TABEAN_HERB column"
                                    HeaderText="FK_TABEAN_HERB" ReadOnly="True" SortExpression="FK_TABEAN_HERB" UniqueName="FK_TABEAN_HERB" Display="false">
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
                                <telerik:GridBoundColumn DataField="LCNNO_NEW" FilterControlAltText="Filter LCNNO_NEW column"
                                    HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_NEW" UniqueName="LCNNO_NEW">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                                    HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RCVNO_FULL" FilterControlAltText="Filter RCVNO_FULL column"
                                    HeaderText="เลขรับ" ReadOnly="True" SortExpression="RCVNO_FULL" UniqueName="RCVNO_FULL">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                                    HeaderText="เลขทะเบียน" ReadOnly="True" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DATE_CONFIRM" DataType="System.DateTime" FilterControlAltText="Filter DATE_CONFIRM column"
                                    HeaderText="วันที่ยื่นคำขอ" SortExpression="DATE_CONFIRM" UniqueName="DATE_CONFIRM" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="LCN_NAME" FilterControlAltText="Filter LCN_NAME column"
                                    HeaderText="ชื่อผู้รับ" ReadOnly="True" SortExpression="LCN_NAME" UniqueName="LCN_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NAME_THAI" FilterControlAltText="Filter fulladdr column"
                                    HeaderText="ชื่อไทย" SortExpression="NAME_THAI" UniqueName="NAME_THAI">
                                </telerik:GridBoundColumn>
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
            </div>
            <div class="h5" style="text-align:right">
                <asp:HyperLink ID="hl_pay" runat="server" Target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
            </div>
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

