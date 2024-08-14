<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_LCN_CONFIRM.aspx.vb" Inherits="FDA_DRUG_HERB.WebForm35" %>

<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

<%@ Register Src="../UC/UC_GRID_PHARMACIST.ascx" TagName="UC_GRID_PHARMACIST" TagPrefix="uc2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_TXT_APP_DATE"));
            $("#ContentPlaceHolder1_TXT_APP_DATE").searchable();
        });

    </script>
    <style type="text/css">
        .auto-style1 {
            width: 126px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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

    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control">
                 <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" />
        </asp:HyperLink>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
    </div>
    <div class="row">
        <div class="col-lg-8" style="width: 70%;">
            <asp:Panel ID="Panel1" runat="server">
                <div style="overflow-x: scroll; height: 800px">

                    <div class="row">
                        <div class="col-lg-12" style="text-align: center;">
                            <h1>คำขอรับใบอนุญาต
                            </h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: center;">
                            <label>
                                ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร                     
                            </label>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-lg-12" style="text-align: center;">
                            <label>
                                คำขอใบอนุญาต                    
                            </label>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: left">
                            <center>
                                <asp:RadioButtonList ID="rdl_lcn_type" runat="server" Enabled="False">
                                    <asp:ListItem Value="1">ผลิตผลิตภัณฑ์สมุนไพร</asp:ListItem>
                                    <asp:ListItem Value="2">นำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                                    <asp:ListItem Value="3">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>
                                </asp:RadioButtonList>
                            </center>
                        </div>

                    </div>
                    <br />
                    <div>
                        <center>
                            <table>
                                <tr>
                                    <td>เลือก &ensp;&ensp;
                                    </td>
                                    <td>

                                        <asp:RadioButtonList ID="rdl_sanchaat" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Enabled="False">
                                            <asp:ListItem Value="1">&ensp;ไทย&ensp;</asp:ListItem>
                                            <asp:ListItem Value="2">&ensp;ต่างด้าว&ensp;</asp:ListItem>
                                        </asp:RadioButtonList>


                                    </td>
                                </tr>
                            </table>
                        </center>

                    </div>
                    <br />
                    <div>
                        <div class="row">
                            <div class="col-lg-1 col-mg-1"></div>
                            <div class="col-lg-3 col-mg-3">
                                ๑. &ensp;ข้อมูลผู้ขออนุญาต
                            </div>
                            <div class="col-lg-8 col-mg-8">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1">
                            </div>
                            <div class="col-lg-2" style="text-align: left">
                                ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                            </div>
                            <div class="col-lg-8" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_name" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2" style="text-align: left">
                                อายุ 
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_lcn_ages" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="padding-left: 2em">สัญชาติ</div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_lcn_nation" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2"></div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-3">
                                เลขประจำตัวประชาชน หรือเลขทะเบียนนิติบุคคล
                            </div>
                            <div class="col-lg-7" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_iden" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2">
                                ที่อยู่เลขที่
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_addr" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="padding-left: 2em">
                                ชั้นที่
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_floor" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-1">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2">
                                ห้องเลขที่
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_room" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="padding-left: 2em">
                                หมู่บ้าน/อาคาร
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_building" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-1">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2">
                                หมู่ที่
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_mu" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="padding-left: 2em">
                                ตรอก/ซอย
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_soi" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-1">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2">
                                ถนน
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_road" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2">
                                ตำบล/แขวง
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_tambol" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="padding-left: 2em">
                                อำเภอ/เขต
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_amphor" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2" style="padding-left: 2em">
                                จังหวัด
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_changwat" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="padding-left: 2em">
                                รหัสไปรษณีย์
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_zipcode" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2">
                                โทรสาร
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <%--<asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>--%>
                                <asp:TextBox ID="lbl_lcn_fax" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="padding-left: 2em">
                                โทรศัพท์
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_tel" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2">
                                E-mail
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_lcn_email" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-2" style="padding-left: 2em">
                                เวลาทำการรวมของร้าน
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                <asp:TextBox ID="lbl_da_opentime" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div>
                    </div>
                    <div>
                        <asp:Panel ID="TB_Personal" runat="server">
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-10">

                                    <h4>กรณีผู้ขออนุญาตเป็นบุคคลต่างด้าว ระบุ</h4>

                                </div>
                                <div class="col-lg-1"></div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="TB_Personal_Type1" runat="server">
                            <div runat="server">


                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <asp:CheckBox ID="cb_Personal_Type1" Text="บุคคลธรรมดา " runat="server" Enabled="False" />
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">หนังสือเดินทางเลขที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <asp:TextBox ID="lbl_PASSPORT_NO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2" style="padding-left: 2em">วันหมดอายุ</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <asp:TextBox ID="lbl_PASSPORT_EXPDATE" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">ใบสำคัญที่อยู่เลขที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <asp:TextBox ID="lbl_DOC_NO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2" style="padding-left: 2em">ออกให้ ณ วันที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <asp:TextBox ID="lbl_DOC_DATE" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">ใบอนุญาตทำงานเลขที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <asp:TextBox ID="lbl_WORK_LICENSE_NO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2" style="padding-left: 2em">วันหมดอายุ</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <asp:TextBox ID="lbl_WORK_LICENSE_EXPDATE" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">หรือใบอนุญาาตประกอบธุรกิจตามบัญชีสาม(๑๖)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">เลขที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <asp:TextBox ID="lbl_BS_NO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2" style="padding-left: 2em">ออกให้ ณ วันที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <asp:TextBox ID="lbl_BS_DATE" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-5">หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <%--<asp:Label ID="lbl_FRGN_NO" runat="server"></asp:Label>--%>
                                        <asp:TextBox ID="lbl_FRGN_NO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">ออกให้ ณ วันที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <%--<asp:Label ID="lbl_FRGN_DATE" runat="server" Text=""></asp:Label>--%>
                                        <asp:TextBox ID="lbl_FRGN_DATE" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6">&nbsp;</div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="TB_Personal_Type2" runat="server">
                            <div runat="server">
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <asp:CheckBox ID="cb_Personal_Type2" Text="นิติบุคคลต่างด้าว " runat="server" Enabled="False" />
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-8">ใบอนุญาตประกอบธุรกิจตามบัญชีสาม(๑๔)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</div>
                                    <div class="col-lg-3"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">เลขที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <%--<asp:Label ID="lbl_BS_NO1" runat="server" Style="margin-bottom: 0px"></asp:Label>--%>
                                        <asp:TextBox ID="lbl_BS_NO1" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">ออกให้ ณ วันที่</div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                        <%--<asp:Label ID="lbl_BS_DATE1" runat="server" Text=""></asp:Label>--%>
                                        <asp:TextBox ID="lbl_BS_DATE1" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-5">หนังสือรับรองตาามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</div>
                                    <div class="col-lg-3">
                                        <%--<asp:Label ID="lbl_FRGN_NO1" runat="server"></asp:Label></div>--%>
                                        <asp:TextBox ID="lbl_FRGN_NO1" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                        <div class="col-lg-3"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">ออกให้ ณ วันที่</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                            <%--<asp:Label ID="lbl_FRGN_DATE1" runat="server" Text=""></asp:Label>--%>
                                            <asp:TextBox ID="lbl_FRGN_DATE1" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">&nbsp;</div>

                                    </div>
                                </div>
                            </div>
                        </asp:Panel>


                    </div>
                    <div>
                        <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
               ๒. &ensp;ข้อมูลผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการหรือดำเนนินกิจการเกี่ยวกับใบอนุญาต</h4>
                        <div style="padding-top: 30px"></div>
                        <div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">ชื่อผู้ดำเนินการ</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_BSN_THAIFULLNAME" runat="server" Text=""></asp:Label>--%>
                                    <asp:TextBox ID="lbl_BSN_THAIFULLNAME" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-6"></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">อายุ</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_BSN_AGE" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    <%--<asp:Label ID="lbl_BSN_AGE" runat="server" Text=""></asp:Label>--%>
                                </div>
                                <div class="col-lg-2" style="padding-left: 2em">สัญชาติ</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="Label20" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    <%--<asp:Label ID="Label20" runat="server" Text=""></asp:Label>--%>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">เลขประจำตัวประชาชน</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_BSN_IDENTIFY" runat="server" Text=""></asp:Label></div>--%>
                                    <asp:TextBox ID="lbl_BSN_IDENTIFY" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">&nbsp;</div>

                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">ที่อยู่ตามทะเบียนบ้าน อยู่เลขที่</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_thaaddr" runat="server" AutoPostBack="True"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_thaaddr" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-2" style="padding-left: 2em">ชั้นที่</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_floor" runat="server" AutoPostBack="True"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_floor" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">ห้องเลขที่</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_room" runat="server" AutoPostBack="True"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_room" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-2" style="padding-left: 2em">หมู่บ้าน/อาคาร</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_c_thabuilding" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                    <%--<asp:Label ID="lbl_c_thabuilding" runat="server"></asp:Label>--%>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>

                                <div class="col-lg-2">หมู่ที่</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_thamu" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_thamu" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-2" style="padding-left: 2em">ตรอก/ซอย</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_thasoi" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_thasoi" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>

                                <div class="col-lg-2">ถนน</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_tharoad" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_tharoad" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">&nbsp;</div>

                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">ตำบล/แขวง</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_tambol" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_tambol" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-2" style="padding-left: 2em">อำเภอ/เขต</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_amphor" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_amphor" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">จังหวัด</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_Province" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_Province" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-2" style="padding-left: 2em">รหัสไปรษณีย์</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_zipcode" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_zipcode" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">โทรสาร</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_fax" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_fax" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-2" style="padding-left: 2em">โทรศัพท์</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_tel" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_tel" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">E-mail</div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <%--<asp:Label ID="lbl_c_email" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="lbl_c_email" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">&nbsp;</div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <h4>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;
               กรณีผู้ได้รับมอบหมายหรือแต่งตั้งให้กำหนดกิจการเป็นบุคคลต่างด้าว ระบุ</h4>
                        &ensp;
           <div>
               <div>
                   <div class="row">
                       <div class="col-lg-1"></div>
                       <div class="col-lg-2">หนังสือเดินทางเลขที่ </div>
                       <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                           <%--<asp:Label ID="lbl_GIVE_PASSPORT_NO" runat="server"></asp:Label>--%>
                           <asp:TextBox ID="lbl_GIVE_PASSPORT_NO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                       </div>
                       <div class="col-lg-2" style="padding-left: 2em">วันหมดอายุ </div>
                       <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                           <%--<asp:Label ID="lbl_GIVE_PASSPORT_EXPDATE" runat="server"></asp:Label>--%>
                           <asp:TextBox ID="lbl_GIVE_PASSPORT_EXPDATE" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                       </div>
                       <div class="col-lg-1"></div>
                   </div>
               </div>
               <div>
                   <div class="row">
                       <div class="col-lg-1"></div>
                       <div class="col-lg-2">ใบอนุญาตทำงานเลขที่ </div>
                       <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                           <asp:TextBox ID="lbl_GIVE_WORK_LICENSE_NO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                           <%--<asp:Label ID="lbl_GIVE_WORK_LICENSE_NO" runat="server"></asp:Label>--%>
                       </div>
                       <div class="col-lg-2" style="padding-left: 2em">วันหมดอายุ </div>
                       <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                           <%--<asp:Label ID="lbl_GIVE_WORK_LICENSE_EXPDATE" runat="server"></asp:Label>--%>
                           <asp:TextBox ID="lbl_GIVE_WORK_LICENSE_EXPDATE" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                       </div>
                       <div class="col-lg-1"></div>
                   </div>
               </div>

               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-10">
                       <telerik:RadGrid ID="rg_bsn" runat="server" Width="100%">
                           <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                               <Columns>
                                   <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                       HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                                   </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="BSN_IDENTIFY" FilterControlAltText="Filter BSN_IDENTIFY column"
                                       HeaderText="เลขบัตรปชช." SortExpression="BSN_IDENTIFY" UniqueName="BSN_IDENTIFY">
                                   </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="BSN_THAIFULLNAME" FilterControlAltText="Filter BSN_THAIFULLNAME column"
                                       HeaderText="ชื่อผู้ดำเนินนกิจการ" SortExpression="BSN_THAIFULLNAME" UniqueName="BSN_THAIFULLNAME">
                                   </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="BSN_TEL" FilterControlAltText="Filter BSN_TEL column"
                                       HeaderText="โทรศัพท์" SortExpression="BSN_TEL" UniqueName="BSN_TEL">
                                   </telerik:GridBoundColumn>
                                   <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                                        CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบผู้ดำเนินการหรือไม่">
                                        <HeaderStyle Width="70px" />
                                    </telerik:GridButtonColumn>--%>
                               </Columns>
                           </MasterTableView>
                       </telerik:RadGrid>
                   </div>
               </div>
           </div>
                    </div>

                    <br />
                    <h4>&ensp;&ensp;&ensp;&ensp;&ensp;๓. &ensp;ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h4>
                    &ensp;
           <div>
               <div class="row">

                   <div class="col-lg-1"></div>
                   <div class="col-lg-2"><b>สถานที่ประกอบธุรกิจชื่อ</b></div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_thanameplace" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-6"></div>

               </div>
               <div class="row">

                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">เลขรหัสประจำบ้าน</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_HOUSENO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-6"></div>

               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">อยู่เลขที่</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_thaaddr" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-2" style="padding-left: 2em">หมู่บ้าน/อาคาร</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_thabuilding" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>

               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">หมู่ที่</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_thamu" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-2" style="padding-left: 2em">ตรอก/ซอย</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_thasoi" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">&nbsp;ถนน</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_tharoad" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-6">&nbsp;</div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">ตำบล/แขวง</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_thathmblnm" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-2" style="padding-left: 2em">&nbsp;อำเภอ/เขต</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_thaamphrnm" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">จังหวัด</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_thachngwtnm" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-2" style="padding-left: 2em">รหัสไปรษณีย์</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_zipcode" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">โทรสาร</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_fax" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-2" style="padding-left: 2em">โทรศัพท์</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="lbl_lct_tel" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">E-mail</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                       <asp:TextBox ID="Label59" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                   </div>
                   <div class="col-lg-6">&nbsp;</div>
               </div>
           </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10">
                            <telerik:RadGrid ID="RadGrid2" runat="server">
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>

                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid"
                                            SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="rcvno" DataType="System.Int32" FilterControlAltText="Filter rcvno column"
                                            HeaderText="เลขรับ" SortExpression="rcvno" UniqueName="rcvno">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="rcvdate" DataFormatString="{0:d}" DataType="System.DateTime" FilterControlAltText="Filter rcvdate column" HeaderText="วันที่รับ" SortExpression="rcvdate" UniqueName="rcvdate">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                                            HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="TranscestionID" SortExpression="XMLNAME" UniqueName="XMLNAME">
                                        </telerik:GridBoundColumn>


                                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                                            HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                                            HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                                            HeaderText="TR_ID" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column"
                                            HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CITIZEN_ID" FilterControlAltText="Filter CITIZEN_ID column" HeaderText="CITIZEN_ID"
                                            SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CITIZEN_ID_UPLOAD" FilterControlAltText="Filter CITIZEN_ID_UPLOAD column"
                                            HeaderText="CITIZEN_ID_UPLOAD" SortExpression="CITIZEN_ID_UPLOAD" UniqueName="CITIZEN_ID_UPLOAD" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                                            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="lctcd" DataType="System.Int32" FilterControlAltText="Filter lctcd column" HeaderText="lctcd"
                                            SortExpression="lctcd" UniqueName="lctcd" Display="false">
                                        </telerik:GridBoundColumn>
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
                        <div class="col-lg-1"></div>
                    </div>
                    <div>
                        <h4>&ensp;&ensp;&ensp;&ensp;&ensp;๔. &ensp;ข้อมูลผู้มีหน้าที่ปฎิบัติการในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร  </h4>
                        <div style="padding-top: 30px"></div>
                        <div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-3">&nbsp; ๔.๑ กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลปะ ชื่อ </div>
                                <div class="col-lg-1" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_PHR_prefix" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_PHR_NAME" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_phr_type" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-3">ใบอนุญาตประกอบการวิชาชีพ/โรคศิลปะเลขที่ </div>
                                <div class="col-lg-7" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_PHR_TEXT_NUM" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-5">
                                    หรือกรณีที่ไม่ไช่ผู้ประกอบวิชาชีพหรือผู้ปรกอบโรคคิลปะ ให้ระบุคุณวุฒิ
                                </div>
                                <div class="col-lg-5" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_STUDY_LEVEL" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-1">
                                    สาขา
                                </div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_PHR_VETERINARY_FIELD" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">&nbsp;</div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-6">
                                    &nbsp;
                            ๔.๒  ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร
                                </div>
                                <div class="col-lg-4" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_NAME_SIMINAR" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-1">
                                    วันที่อบรม
                                </div>
                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_SIMINAR_DATE" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-2" style="padding-left: 2em">
                                    เวลาทำการ
                                </div>
                                <div class="col-lg-4" style="border-bottom: #999999 1px dotted; text-align: left">
                                    <asp:TextBox ID="lbl_PHR_TEXT_WORK_TIME" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1"></div>

                                <div class="col-lg-3"></div>
                            </div>
                        </div>
                        <div>
                            <div class="row">

                                <div class="col-lg-1"></div>
                                <div class="col-lg-3">เป็นผู้ที่มีหน้าที่ปฏิบัติการตาม </div>
                                <div class="col-lg-4">
                                    <asp:RadioButtonList ID="rdl_mastra" runat="server" Enabled="False" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">มาตรา ๓๑</asp:ListItem>
                                        <asp:ListItem Value="2">มาตรา ๓๒</asp:ListItem>
                                        <asp:ListItem Value="3">มาตรา ๓๓</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-lg-4">แห่ง พ.ร.บ.ผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๒ </div>

                            </div>
                        </div>
                    </div>

                </div>
            </asp:Panel>
            <div>
                <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div class="row" runat="server" style="height: 30px">
                <div class="col-lg-4" style="padding-left: 2em">
                    <asp:Label ID="Label1" runat="server" Text="สถานะปัจจุบัน :"></asp:Label>
                </div>
                <div class="col-lg-6">
                    <asp:Label ID="lbl_Status" runat="server" Text="-"></asp:Label>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" runat="server" style="height: 20px">
                <div class="col-lg-4" style="padding-left: 2em">
                    <asp:Label ID="Label2" runat="server" Text="ชื่อผู้ลงนาม :"></asp:Label>
                </div>
                <div class="col-lg-6">
                    <asp:Label ID="lbl_staff_consider" runat="server" Text="-"></asp:Label>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" runat="server" style="height: 20px">
                <div class="col-lg-4" style="padding-left: 2em">
                    <asp:Label ID="Label3" runat="server" Text="วันที่เสนอลงนาม :"></asp:Label>
                </div>
                <div class="col-lg-6">
                    <asp:Label ID="lbl_consider_date" runat="server" Text="-"></asp:Label>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" runat="server" style="height: 20px" id="show2">
                <div class="col-lg-4" style="padding-left: 2em">
                    <asp:Label ID="Label5" runat="server" Text=" สถานะ :"></asp:Label>
                </div>
                <div class="col-lg-6">
                    <asp:DropDownList ID="ddl_cnsdcd" runat="server" AutoPostBack="True" Width="95%" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" runat="server" id="show02" visible="false">
                <div class="row" runat="server" style="height: 20px">
                    <div class="col-lg-4" style="padding-left: 2em">
                        <asp:Label ID="Label6" runat="server" Text="หมายเหตุ :"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="Txt_Remark" runat="server" TextMode="MultiLine" Style="margin: 0px; width: 213px; height: 73px;"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
            <div class="row" runat="server" id="show01" visible="false">
                <div class="row" runat="server" style="height: 20px">
                    <div class="col-lg-4" style="padding-left: 2em">
                        <asp:Label ID="Label4" runat="server" Text=" รูปแบบเอกสาร :"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="ddl_template" runat="server" Width="95%" AutoPostBack="True">
                            <asp:ListItem Value="0">---เลือกแบบ pdf---</asp:ListItem>
                            <asp:ListItem Value="1">pdf แบบปกติ</asp:ListItem>
                            <asp:ListItem Value="2">pdf แบบบ้านเลขที่ยาว</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
            <div class="row" runat="server" style="height: 40px">
                <div class="col-lg-4" style="padding-left: 2em">
                    <asp:Label ID="Label7" runat="server" Text="เจ้าหน้าที่รับผิดชอบ :"></asp:Label>
                </div>
                <div class="col-lg-6">
                    <telerik:RadComboBox ID="rcb_staff_offer" runat="server" Filter="Contains" Width="95%" DataTextField="STAFF_OFFER_NAME" DataValueField="IDA">
                    </telerik:RadComboBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" runat="server" style="height: 20px">
                <div class="col-lg-4" style="padding-left: 2em">
                    <asp:Label ID="lbl_update_date" runat="server" Text="-"></asp:Label>
                </div>
                <div class="col-lg-6">
                    <asp:TextBox ID="TXT_APP_DATE" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" runat="server" id="SHOW03" visible="false">
                <div class="row" runat="server" style="height: 20px">
                    <div class="col-lg-4" style="padding-left: 2em">
                        <asp:Label ID="lbl_ref_no" runat="server" Text="เลขอ้างอิง :"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txt_ref_no" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
            <div class="row" runat="server" id="SHOW04_NOTE" visible="false">
                <div class="row" runat="server" style="height: 20px">
                    <div class="col-lg-4" style="padding-left: 2em">
                        <asp:Label ID="Label8" runat="server" Text="หมายเหตุทบทวน :"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txt_remark_review" runat="server" TextMode="MultiLine" Style="margin: 0px; width: 213px; height: 73px;" ReadOnly="True" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
            <br />
            <%--</div>--%>
            <%-- </div>
            <div class="row" runat="server" id="Div1" visible="false">
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-3">รูปแบบ PDF</div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="ddl_template" runat="server" Width="80%" AutoPostBack="True" Style="display: none;">
                            <asp:ListItem Value="0">---เลือกแบบ pdf---</asp:ListItem>
                            <asp:ListItem Value="1">pdf แบบปกติ</asp:ListItem>
                            <asp:ListItem Value="2">pdf แบบบ้านเลขที่ยาว</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
            <div class="row" runat="server" id="Div2">
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-3">เลือกสถานะ</div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="ddl_cnsdcd" runat="server" AutoPostBack="True" Width="80%" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
            <div class="row" runat="server" id="Div3" >
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-3">
                        <asp:Label ID="lbl_ref_no" runat="server" Text="เลขอ้างอิง :"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txt_ref_no" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>--%>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" />
                </div>
                <div class="col-lg-1"></div>
            </div>
              <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_DBD" runat="server" Text="ข้อมูล DBD" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการยกเลิกข้อคำขอหรือไม่');" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_preview" runat="server" Text="Preview ใบอนุญาต" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-2"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_sormorpo1" runat="server" Text="PDF สมพ๑" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_up" runat="server" Text="ตรวจสอบไฟล์อัพโหลด" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_drug_group" runat="server" Text="หมวดยา" CssClass="btn-lg" Style="display: none;" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="width: 100%">
                    <%--<uc2:UC_GRID_PHARMACIST ID="UC_GRID_PHARMACIST" runat="server" />--%>
                </div>
            </div>
        </div>
    </div>
    <div class=" modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center"></div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f1" style="width: 100%; height: 550px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
</asp:Content>
