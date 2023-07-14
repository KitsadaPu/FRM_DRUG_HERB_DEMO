<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FDA_STAFF_LCN_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FDA_STAFF_LCN_EDIT" %>

<%@ Register Src="~/UC/UC_ATTACH_LCN.ascx" TagPrefix="uc1" TagName="UC_ATTACH_LCN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(window).load(function () {
                $.ajax({
                    type: 'POST',
                    data: { submit: true },
                    success: function (result) {
                        //    $('#spinner').fadeOut('slow');
                    }
                });
            });

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ContentPlaceHolder1_btn_upload').click(function () {

                $('#spinner').toggle('slow');
                Popups('POPUP_LCN_UPLOAD.aspx');
                return false;
            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');
                Popups('POPUP_LCN_DOWNLOAD.aspx');
                return false;
            });

            function Popups(url) { // สำหรับทำ Div Popup
                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }
            function Popups2(url) { // สำหรับทำ Div Popup
                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }
            function close_modal() { // คำสั่งสั่งปิด PopUp
                $('#myModal').modal('hide');
                $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
            }
        });

        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }
        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            Loaddata();
        }
    </script>
    <style type="text/css">
        .fit-picture {
            width: 250px;
        }

        .auto-style3 {
            width: 20px;
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row" style="text-align: center">
        <h3>รายการเอกสารที่แก้ไข</h3>
    </div>
    <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-6" style="width: 60%">
            <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="40"
                PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="SelectColumn" />
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                            HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>หมายเหตุการแก้ไข</h3>
        </div>
    </div>
    <div class="row" runat="server">
        <div class="col-lg-12" style="text-align: center">
            <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 50%; width: 60%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบแก้ไข</h3>
        </div>
    </div>
    <div class="row">
        <div style="text-align: center">
            <hr />
            <div class="row">
                <div class="col-lg-3"></div>
                <div class="col-lg-1">
                    <p>แนบเอกสารเพิ่ม</p>
                </div>
                <div class="col-lg-1" style="text-align: right">
                    <asp:Label ID="lbl_upload_file" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-1" style="text-align: right">
                    <div runat="server" id="img_not">
                        <img class="auto-style3"
                            src="../Images/cancel.png"
                            alt=""
                            runat="server" />
                    </div>
                    <div runat="server" id="img_cf" visible="False">
                        <img class="auto-style3"
                            src="../Images/correct.png"
                            alt=""
                            runat="server" />
                    </div>
                </div>
                <div class="col-lg-2">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN" />
                </div>
            </div>
            <asp:Button ID="btn_add_upload" runat="server" Text="อัพโหลดเอกสาร" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="text-align: center">
            <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="10%" />
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="10%" />
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
