<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_LCN_UPDATE_STATUS.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_UPDATE_STATUS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            function CloseSpin() {
                $('#spinner').toggle('slow');
            }
            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }
            $('#ContentPlaceHolder1_btn_download_2').click(function () {
                $('#spinner').fadeIn('slow');

            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');

            });

        });
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reset').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }

        function closespinner() {
            alert('Download เสร็จสิ้น');
            $('#spinner').fadeOut('slow');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <h2>รายละเอียดใบอนุญาต
    </h2>
    <asp:Button ID="btn_reset" runat="server" Text="reset" CssClass="btn-lg" Style="display: none;" />
    <table class="table">
        <tr>
            <td>เลขอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label></td>
            <td>เลขนิติฯ/เลขบัตรปชช.ผู้รับอนุญาต</td>
            <td>
                <asp:Label ID="lbl_citizenid" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>ชื่อสถานที่ :</td>
            <td>
                <asp:Label ID="lbl_thanameplace" runat="server"></asp:Label></td>
            <td>ชื่อผู้ดำเนินกิจการ :</td>
            <td>
                <asp:Label ID="lbl_nameOperator" runat="server"></asp:Label></td>
        </tr>
    </table>

    <br />
    <h2>สถานะใบอนุญาต
    </h2>
    <table class="table">
        <tr>
            <td>สถานะปัจจุบัน :</td>
            <td>
                <asp:Label ID="lbl_statname" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <h2>การขอเปลี่ยนแปลงสถานะ&nbsp;</h2>
            </td>
        </tr>
        <tr>
            <td>เลือกสถานะใหม่ :</td>
            <td>
                <asp:DropDownList ID="ddl_stat" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>วันที่มีผล :</td>
            <td>
                <telerik:RadDatePicker ID="rdp_cncdate" runat="server">
                </telerik:RadDatePicker>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btn_c_stat" runat="server" Text="เปลี่ยนสถานะ" CssClass="btn-lg" /></td>
        </tr>
    </table>

    <br />
    <h2>การขอเปลี่ยนแปลงสถานะผู้มีหน้าที่ปกิบัติการ&nbsp;</h2>
    <table class="table">
        <tr>
            <td align="right">
                <%--<asp:Button ID="btn_phr_add" runat="server" Text="เพิ่มผู้มีหน้าที่ปฏิบัติการ" CssClass="btn-lg"/>--%>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rgphr" runat="server">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="PHR_IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                        <Columns>

                            <telerik:GridBoundColumn DataField="PHR_IDA" FilterControlAltText="Filter PHR_IDA column"
                                HeaderText="PHR_IDA" SortExpression="PHR_IDA" UniqueName="PHR_IDA" Display="false">
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
                            <telerik:GridBoundColumn DataField="functnm" FilterControlAltText="Filter functnm column"
                                HeaderText="หน้าที่" SortExpression="functnm" UniqueName="functnm">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PHR_STATUS_NAME" FilterControlAltText="Filter PHR_STATUS_NAME column"
                                HeaderText="สถานะผู้มีหน้าที่ปกิบัติการ" SortExpression="PHR_STATUS_NAME" UniqueName="PHR_STATUS_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sel"
                                CommandName="sel" Text="ดูข้อมูล">
                                <HeaderStyle Width="70px" />
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="selp"
                                CommandName="selp" Text="เลือก">
                                <HeaderStyle Width="70px" />
                            </telerik:GridButtonColumn>
                            <%-- <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                                   CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบผู้ปฏิบัติการหรือไม่">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>--%>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table class="table">
        <%-- <tr>
            <td>สถานะปัจจุบัน :</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>--%>
        <%--  <tr>
            <td colspan="2">
                <h2>การขอเปลี่ยนแปลงสถานะผู้มีหน้าที่ปกิบัติการ&nbsp;</h2>
            </td>
        </tr>--%>
        <tr>
            <td>ชื่อผู้มีหน้าที่ปฏิบัติการ :</td>
            <td>
                <asp:Label ID="txt_phr_name" runat="server" Text=""></asp:Label>
                <asp:Label ID="txt_phr_ida" runat="server" Text="" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>เลือกสถานะ :</td>
            <td>
                <asp:DropDownList ID="ddl_phr_status" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>วันที่ :</td>
            <td>
                <telerik:RadDatePicker ID="rdk_date_phr" runat="server">
                </telerik:RadDatePicker>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btn_update_s_phr" runat="server" Text="เปลี่ยนสถานะ" CssClass="btn-lg" /></td>
        </tr>
    </table>
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
</asp:Content>
