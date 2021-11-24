<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_LCN_CONFIRM_DRUG.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_CONFIRM_DRUG" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

<%@ Register Src="../UC/UC_GRID_PHARMACIST.ascx" TagName="UC_GRID_PHARMACIST" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        <asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control"> <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" /></asp:HyperLink>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    <table style="width: 100%; height: 800px;" >
        <tr>
            <td rowspan="2">
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
                                        ผลิต นำเข้า หรือขายผลิตภัณฆ์สมุนไพร                     
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
                    <asp:ListItem Value="1">ผลิตผลิตภัณฆ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="2">นำเข้าผลิตภัณฆ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="3">ขายผลิตภัณฆ์สมุนไพร</asp:ListItem>
                </asp:RadioButtonList></center>
                                </div>

                            </div>
                            <br />
                            <div>
                                <center>                  
            <table>
                <tr>
                <td>
                    เลือก &ensp;&ensp;
                </td>
                <td>
                
               <asp:RadioButtonList ID="rdl_sanchaat" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Enabled="False" >
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
                                    <div class="col-lg-3" style="text-align: left">
                                        ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                                    </div>
                                    <div class="col-lg-6" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_name" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2" style="text-align: left">
                                        อายุ 
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_ages" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        ปี
                                    </div>
                                    <div class="col-lg-2">สัญชาติ</div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_nation" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-3">
                                        เลขประจำตัวประชาชน หรือเลขทะเบียนนิติบุคคล
                                    </div>
                                    <div class="col-lg-6" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_iden" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        ที่อยู่เลขที่
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_addr" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        ชั้นที่
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_floor" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        ห้องเลขที่
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_room" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        หมู่บ้าน/อาคาร
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_building" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        หมู่ที่
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_mu" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        ตรอก/ซอย
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_soi" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        ถนน
                                    </div>
                                    <div class="col-lg-7" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_road" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        ตำบล/แขวง
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_tambol" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        อำเภอ/เขต
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_amphor" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        จังหวัด
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_changwat" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        รหัสไปรษณีย์
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_zipcode" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        โทรสาร
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">                                       <%--<asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>--%>
                                        <asp:TextBox ID="lbl_lcn_fax" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        โทรศัพท์
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_tel" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        E-mail
                                    </div>
                                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_lcn_email" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        เวลาทำการรวมของร้าน
                                    </div>
                                    <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
                                        <asp:TextBox ID="lbl_da_opentime" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-3">
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-2">
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

                                            <h4>กรณีผู้ขออนนุญาตเป็นบุคคลต่างด้าว ระบุ</h4>

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
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <asp:TextBox ID="lbl_PASSPORT_NO" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">วันหมดอายุ</div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <asp:TextBox ID="lbl_PASSPORT_EXPDATE" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">ใบสำคัญที่อยู่เลขที่</div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <asp:TextBox ID="lbl_DOC_NO" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">ออกให้ ณ วันที่</div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <asp:TextBox ID="lbl_DOC_DATE" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">ใบอนุญาตทำงานเลขที่</div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <asp:TextBox ID="lbl_WORK_LICENSE_NO" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">วันหมดอายุ</div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <asp:TextBox ID="lbl_WORK_LICENSE_EXPDATE" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
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
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <asp:TextBox ID="lbl_BS_NO" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">ออกให้ ณ วันที่</div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <asp:TextBox ID="lbl_BS_DATE" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-5">หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <%--<asp:Label ID="lbl_FRGN_NO" runat="server"></asp:Label>--%>
                                                <asp:TextBox ID="lbl_FRGN_NO" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">ออกให้ ณ วันที่</div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <%--<asp:Label ID="lbl_FRGN_DATE" runat="server" Text=""></asp:Label>--%>
                                                <asp:TextBox ID="lbl_FRGN_DATE" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
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
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <%--<asp:Label ID="lbl_BS_NO1" runat="server" Style="margin-bottom: 0px"></asp:Label>--%>
                                                <asp:TextBox ID="lbl_BS_NO1" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">ออกให้ ณ วันที่</div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                <%--<asp:Label ID="lbl_BS_DATE1" runat="server" Text=""></asp:Label>--%>
                                                <asp:TextBox ID="lbl_BS_DATE1" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-5">หนังสือรับรองตาามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</div>
                                            <div class="col-lg-3">
                                                <%--<asp:Label ID="lbl_FRGN_NO1" runat="server"></asp:Label></div>--%>
                                                <asp:TextBox ID="lbl_FRGN_NO1" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                                <div class="col-lg-3"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">ออกให้ ณ วันที่</div>
                                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                                    <%--<asp:Label ID="lbl_FRGN_DATE1" runat="server" Text=""></asp:Label>--%>
                                                    <asp:TextBox ID="lbl_FRGN_DATE1" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
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
                                <div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">ชื่อผู้ดำเนินการ</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_BSN_THAIFULLNAME" runat="server" Text=""></asp:Label>--%>
                                            <asp:TextBox ID="lbl_BSN_THAIFULLNAME" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">อายุ</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <asp:TextBox ID="lbl_BSN_AGE" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            <%--<asp:Label ID="lbl_BSN_AGE" runat="server" Text=""></asp:Label>--%>
                                            ปี
                                        </div>
                                        <div class="col-lg-2">สัญชาติ</div>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="Label20" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            <%--<asp:Label ID="Label20" runat="server" Text=""></asp:Label>--%>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">เลขประจำตัวประชาชน</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_BSN_IDENTIFY" runat="server" Text=""></asp:Label></div>--%>
                                            <asp:TextBox ID="lbl_BSN_IDENTIFY" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">&nbsp;</div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">ที่อยู่ตามทะเบียนบ้าน อยู่เลขที่</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_thaaddr" runat="server" AutoPostBack="True"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_thaaddr" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">ชั้นที่</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_floor" runat="server" AutoPostBack="True"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_floor" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">ห้องเลขที่</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_room" runat="server" AutoPostBack="True"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_room" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">หมู่บ้าน/อาคาร</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <asp:TextBox ID="lbl_c_thabuilding" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                            <%--<asp:Label ID="lbl_c_thabuilding" runat="server"></asp:Label>--%>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>

                                        <div class="col-lg-2">หมู่ที่</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_thamu" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_thamu" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">ตรอก/ซอย</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_thasoi" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_thasoi" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>

                                        <div class="col-lg-2">ถนน</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_tharoad" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_tharoad" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">&nbsp;</div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">ตำบล/แขวง</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_tambol" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_tambol" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">อำเภอ/เขต</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_amphor" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_amphor" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">จังหวัด</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_Province" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_Province" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">รหัสไปรษณีย์</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_zipcode" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_zipcode" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">โทรสาร</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_fax" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_fax" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">โทรศัพท์</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_tel" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_tel" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">E-mail</div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                            <%--<asp:Label ID="lbl_c_email" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="lbl_c_email" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
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
                       <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                           <%--<asp:Label ID="lbl_GIVE_PASSPORT_NO" runat="server"></asp:Label>--%>
                           <asp:TextBox ID="lbl_GIVE_PASSPORT_NO" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                       </div>
                       <div class="col-lg-2">วันหมดอายุ </div>
                       <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                           <%--<asp:Label ID="lbl_GIVE_PASSPORT_EXPDATE" runat="server"></asp:Label>--%>
                           <asp:TextBox ID="lbl_GIVE_PASSPORT_EXPDATE" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                       </div>
                       <div class="col-lg-1"></div>
                   </div>
               </div>
               <div>
                   <div class="row">
                       <div class="col-lg-1"></div>
                       <div class="col-lg-2">ใบอนุญาตทำงานเลขที่ </div>
                       <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                           <asp:TextBox ID="lbl_GIVE_WORK_LICENSE_NO" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                           <%--<asp:Label ID="lbl_GIVE_WORK_LICENSE_NO" runat="server"></asp:Label>--%>
                       </div>
                       <div class="col-lg-2">วันหมดอายุ </div>
                       <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                           <%--<asp:Label ID="lbl_GIVE_WORK_LICENSE_EXPDATE" runat="server"></asp:Label>--%>
                           <asp:TextBox ID="lbl_GIVE_WORK_LICENSE_EXPDATE" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                       </div>
                       <div class="col-lg-1"></div>
                   </div>
               </div>
           </div>
                            </div>

                            <br />
                    &ensp;
          
           
               

                <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
               ๓. &ensp;ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฆ์สมุนไพร</h4>
                &ensp;

           <div>
               <div class="row">

                   <div class="col-lg-1"></div>
                   <div class="col-lg-2"><b>สถานที่ประกอบธุรกิจชื่อ</b></div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_thanameplace" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_thanameplace" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-6"></div>

               </div>
               <div class="row">

                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">เลขรหัสประจำบ้าน</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_HOUSENO" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_HOUSENO" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-6"></div>

               </div>
               <div class="row">

                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">อยู่เลขที่</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_thaaddr" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_thaaddr" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-2">หมู่บ้าน/อาคาร</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_thabuilding" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_thabuilding" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>

               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">หมู่ที่</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_thamu" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_thamu" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-2">ตรอก/ซอย</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_thasoi" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_thasoi" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">&nbsp;ถนน</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_tharoad" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_tharoad" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-6" d>&nbsp;</div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">ตำบล/แขวง</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_thathmblnm" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_thathmblnm" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-2">&nbsp;อำเภอ/เขต</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_thaamphrnm" runat="server" Text=""></asp:Label></div>--%>
                       <asp:TextBox ID="lbl_lct_thaamphrnm" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">จังหวัด</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_thachngwtnm" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_thachngwtnm" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-2">รหัสไปรษณีย์</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_zipcode" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_zipcode" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">โทรสาร</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_fax" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_fax" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-2">โทรศัพท์</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="lbl_lct_tel" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_tel" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">E-mail</div>
                   <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                       <%--<asp:Label ID="Label59" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="Label59" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
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
                    <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
                ๔. &ensp;ข้อมูลผุ้มีหน้าที่ปฎิบัติการในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร
                    </h4>

                    <div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-3">&nbsp; ๔.๑ กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลปะ ชื่อ </div>
                            <div class="col-lg-1" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_PHR_prefix" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_PHR_NAME" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <%--<asp:Label ID="lbl_phr_type" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="lbl_phr_type" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-3">ใบอนุญาตประกอบการวิชาชีพ/โรคศิลปะเลขที่ </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_PHR_TEXT_NUM" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                <%--<asp:Label ID="lbl_PHR_TEXT_NUM" runat="server"></asp:Label>--%>
                            </div>
                            <div class="col-lg-1">หรือ </div>
                            <div class="col-lg-1"></div>

                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-5">
                                กรณีที่ไม่ไช้ผู้ประกอบวิชาชีพหรือผู้ปรกอบโรคคิลปะ ให้ระบุคุณวุฒิ
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_STUDY_LEVEL" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                <%--<asp:Label ID="lbl_STUDY_LEVEL" runat="server"></asp:Label>--%>
                            </div>
                            <div class="col-lg-2">&nbsp;</div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-1">
                                สาขา
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_PHR_VETERINARY_FIELD" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">&nbsp;</div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-6">
                                &nbsp;
                            ๔.๒  ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_NAME_SIMINAR" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-lg-1"></div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-1">
                                วันที่อบรม
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_SIMINAR_DATE" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-lg-1">
                                เวลาทำการ
                            </div>
                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
                                <asp:TextBox ID="lbl_PHR_TEXT_WORK_TIME" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-lg-1"></div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>

                            <div class="col-lg-3"></div>
                        </div>
                    </div>
                    <div>
                        <div class="row">

                            <div class="col-lg-1"></div>
                            <div class="col-lg-3">เป็นผู้ที่มีหน้าที่ปฎิยบัติการตาม </div>
                            <div class="col-lg-4">
                                <asp:RadioButtonList ID="rdl_mastra" runat="server" Enabled="False" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">มาตรา ๓๑</asp:ListItem>
                                    <asp:ListItem Value="2">มาตรา ๓๒</asp:ListItem>
                                    <asp:ListItem Value="3">มาตรา ๓๓</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-lg-4">แห่ง พ.ร.บ.ผลิตภัณฆ์สมุนไพร พ.ศ.๒๕๖๒ </div>

                        </div>
                    </div>
                </div>

               </div>
                    </asp:Panel>               
                    <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
               
            </td>
            <td style="padding-left: 10%; height: 20%;" padding-top: 1%; padding-bottom:70%">

                <table class="table" style="width: 90%">

                    <tr>
                        <td>
                            <asp:Button ID="btn_confirm" runat="server" Text="ยื่นคำขอ" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการยกเลิกข้อคำขอหรือไม่');"/></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_load" runat="server" Text="Download สพม.๒" CssClass="btn-lg" Width="80%" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_previewUp" runat="server" Text="ตรวจสอบไฟล์อัพโหลด" CssClass="btn-lg" Width="80%" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="80%" /></td>
                    </tr>

                </table>



            </td>
        </tr>
        <tr>
            <td style="width: 30%; height: 50%; padding-left: 10%">

              <%--  <uc1:UC_GRID_ATTACH runat="server" ID="UC_GRID_ATTACH" />

                <br />
                <uc2:UC_GRID_PHARMACIST ID="UC_GRID_PHARMACIST" runat="server" />--%>

            </td>
        </tr>
    </table>

</asp:Content>

