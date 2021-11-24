<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_TABEAN_SUBSTITUTE_STAFF_CONFIRM.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_SUBSTITUTE_STAFF_CONFIRM" %>

<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UC/UC_GRID_PHARMACIST.ascx" TagName="UC_GRID_PHARMACIST" TagPrefix="uc2" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 500px;
        }

        .auto-style2 {
            width: 70%;
        }

        .auto-style3 {
            height: 50%;
            width: 70%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.blockUI.js"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_txt_appdate"));
            $("#ContentPlaceHolder1_DD_OFF_REQ").searchable();
        });
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
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />

    </div>

    <div>

        <asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control">
                 <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" />
        </asp:HyperLink>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>
                <div>
                    <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
                </div>
            </td>
            <td style="padding-left: 1%; height: 50%; padding-bottom: 5em;">
                <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>--%>
                <center>
                <table class="table" style="width: 80%; padding-right: 2%;padding-left: 5%;">
                    <%--<tr>
                         <td>
                             <asp:Label ID="lbl_rqt" runat="server" Text="โปรดเลือกกระบวนงานที่ท่านต้องการยื่น"></asp:Label>
                             <telerik:radcombobox ID="ddl_req_type" Runat="server" Width="80%" Filter="Contains">
                             </telerik:radcombobox>
                         </td>
                     </tr>--%>
                    
                    <tr><td style="width: 80%">
                         <asp:Panel ID="Panel1" runat="server" style="display:none;">
                        <p>รูปแแบ PDF:</p>
                         <asp:DropDownList ID="ddl_template" runat="server" Width="70%"  AutoPostBack="True" DataTextField="NAME_TEMPLATE" DataValueField="ROWS">
                         </asp:DropDownList>
                          </asp:Panel>
                         </td></tr>
                        
                    <tr>
                        <td style="width: 80%">
                            <p>สถานะ:</p>
                            &ensp;&ensp;<asp:DropDownList ID="ddl_cnsdcd" runat="server" Width="70%" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80%">
                             <p>วันที่ตรวจรับคำขอ:</p>
                            &ensp;&ensp; <asp:TextBox ID="txt_appdate" runat="server" Width="70%"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80%">
                             <p>จนท. ที่รับผิดชอบ:</p>
                               <asp:DropDownList ID="DD_OFF_REQ" runat="server"  Width="80%"  DataValueField="IDA" DataTextField="STAFF_NAME" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" /></td>
                    </tr>
                    <%--<tr>
                        <td>
                            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="80%" /></td>
                    </tr>--%>
                   <%-- <tr>
                        <td>
                            <asp:Button ID="btn_load" runat="server" Text="Download PDF" CssClass="btn-lg" Width="80%" /></td>
                    </tr>--%>
                     <tr>
                        <td>
                            <asp:Button ID="btn_preview" runat="server" Text="Preview PDF" CssClass="btn-lg" Width="80%" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="80%" style="height: 53px" /></td>
                    </tr>
                     </table>
                    </center>
                <table class="table" style="width: 100%; padding-right: 2%;">
                    <tr>
                        <td>

                            <br />
                            <br />
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
                                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                                            SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false" AllowFiltering="true">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                                            HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column"
                                            HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="PV_SELECT" runat="server">ดูเอกสาร</asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                    </EditFormSettings>

                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                </MasterTableView>

                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                            </telerik:RadGrid>
                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <br />

                            <uc1:UC_GRID_ATTACH runat="server" ID="UC_GRID_ATTACH" />

                            <br />

                        </td>
                    </tr>
                </table>





            </td>
        </tr>

    </table>

</asp:Content>
