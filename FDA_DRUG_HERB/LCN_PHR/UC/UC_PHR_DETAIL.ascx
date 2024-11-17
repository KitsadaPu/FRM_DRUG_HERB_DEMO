<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_PHR_DETAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_PHR_DETAIL" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
</style>
<script type="text/javascript">
    $(document).ready(function () {
        showdate($("#ContentPlaceHolder1_UC_PHR_DETAIL_txt_Write_Date"));
        $("#ContentPlaceHolder1_UC_PHR_DETAIL_txt_Write_Date").searchable();

        showdate($("#ContentPlaceHolder1_UC_PHR_DETAIL_phr_date_num"));
        $("#ContentPlaceHolder1_UC_PHR_DETAIL_phr_date_num").searchable();

        showdate($("#ContentPlaceHolder1_UC_PHR_DETAIL_Siminar_Date"));
        $("#ContentPlaceHolder1_UC_PHR_DETAIL_Siminar_Date").searchable();
    });
    //$(document).ready(function () {
    //    showdate($("ContentPlaceHolder1_UC_PHR_DETAIL_phr_date_num"));
    //    $("ContentPlaceHolder1_UC_PHR_DETAIL_Siminar_Date").searchable();
    //});

    function spin_space() { // คำสั่งสั่งปิด PopUp
        $('#spinner').toggle('slow');
    }

    function closespinner() {
        $('#spinner').fadeOut('slow');
        alert('Download Success');
        $('#ContentPlaceHolder1_Button1').click();
    }
</script>
<div>
    <%--    <form name="form" method="post" align="center;">--%>
    <div class="row">
        <div class="col-lg-12" style="text-align: center;">
            <h1>คำรับรองของผู้มีหน้าที่ปฏิบัติการ</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-9"></div>
        <div class="col-lg-1" style="text-align: right;">
            เขียนที่              
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="Txt_Write_At" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-9"></div>
        <div class="col-lg-1" style="text-align: right;">
            วันที่
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_Write_Date" runat="server" Style="width: 80%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div style="padding-top: 30px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">บัตรประชาชน </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_PHR_CTZNO" Width="100%" runat="server"></asp:TextBox>
            <asp:Label ID="lbl_PHR_CTZNO" runat="server" Text="*กรุณากรอกเลขบัตรประชาชน" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-sm" Visible="false" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ข้าพเจ้า &ensp;</div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_phr_name" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1">อายุ</div>
        <div class="col-lg-3">
            <div>
                <%--   <div class="col-lg-2">อายุ</div>--%>
                <div class="col-lg-3">
                    <asp:TextBox ID="txt_age" runat="server" TextMode="Number" Width="100%" BorderStyle="None" Style="border-bottom: #999999 1px dotted"></asp:TextBox>
                    <asp:Label ID="lbl_age" runat="server" Text="*กรอกอายุ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                </div>
                <div class="col-lg-1" style="text-align: center">ปี</div>
                <div class="col-lg-2" style="text-align: center">สัญชาติ</div>
                <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_Nationality" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">อยู่เลขที่&ensp;</div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_phr_addr" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            หมู่บ้าน/อาคาร
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_phr_Building" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">หมู่ที่ &emsp;</div>
        <div class="col-lg-3">
            <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="txt_phr_mu" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-3">ตรอก/ซอย</div>
            <div class="col-lg-7" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="txt_phr_Soi" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-1">
            ถนน
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_phr_road" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ตำบล/แขวง &ensp;</div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_phr_tambol" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            อำเภอ/แขวง
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_phr_ampher" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">จังหวัด &ensp;</div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_phr_changwat" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            รหัสไปรษณีย์
        </div>
        <div class="col-lg-3">
            <div class="col-lg-4" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="txt_phr_zipcode" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-2">โทรสาร</div>
            <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="txt_phr_fax" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">โทรศัพท์ &ensp;</div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_phr_phone" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            E-mail
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_phr_email" runat="server" TextMode="Email" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
    </div>

    <div style="padding-top: 30px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-6">
            <p>ขอให้คำรับรองต่อพนักงานเจ้าหน้าที่ว่า</p>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            <p>๑. ข้าพเจ้า </p>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="ddl_phr_type" runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:Label ID="Label3" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาระบุคุณวุฒิ</p></asp:Label>
        </div>
    </div>
    <asp:Panel ID="P_Traning_Detail" runat="server" Style="display: none;">
        <div class="row" runat="server" visible="false" id="Div_Txt_num">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" style="padding-left: 4em">ใบอนุญาตประกอบการวิชาชีพ/โรคศิลปะเลขที่ :</div>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_PHR_TEXT_NUM" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" runat="server" visible="true" id="Div_Qualificate">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" style="padding-left: 4em">
                กรณีที่ไม่ไช้ผู้ประกอบวิชาชีพหรือผู้ประกอบโรคคิลปะ ให้ระบุคุณวุฒิ :
            </div>
            <div class="col-lg-4">
                <%--<asp:TextBox ID="txt_STUDY_LEVEL" runat="server" Width="100%"></asp:TextBox>--%>
                <asp:DropDownList ID="DDL_STUDY_LEVEL" runat="server" Width="100%"></asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาระบุคุณวุฒิ</p></asp:Label>
            </div>
            <div class="col-lg-2">&nbsp;</div>
        </div>
        <div class="row" runat="server" visible="true" id="Div_Major">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" style="padding-right: 6.2em; text-align: right">
                สาขา :
            </div>
            <div class="col-lg-4">
                <asp:DropDownList ID="ddl_phr_type_other" runat="server" Width="100%"></asp:DropDownList>
                <%--<asp:TextBox ID="txt_PHR_VETERINARY_FIELD" TextMode="MultiLine" runat="server" Width="100%"></asp:TextBox>--%>
            </div>
            <div class="col-lg-1">
                พ.ศ            
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_Study_Year" runat="server" Width="70%"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" style="padding-left: 4em">
                <asp:Label runat="server" ID="time_open" Text="ใบอนุญาตประกอบการวิชาชีพ/โรคศิลปะ ให้ไว้ ณ วันที่การ :"></asp:Label>
            </div>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_PHR_TEXT_WORK_TIME" runat="server" Width="100%"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณากรอกเวลาปฏิบัติการ</p> </asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" style="padding-right: 6.2em; text-align: right">
                &nbsp;&nbsp; ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุ
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" style="padding-left: 4em">
                ชื่อหลักสูตร :
            </div>
            <div class="col-lg-4">
                <asp:DropDownList ID="ddl_training_phr" runat="server" DataTextField="TRAINING_DATE" DataValueField="training_id" AutoPostBack="true"></asp:DropDownList>
                <%-- <asp:TextBox ID="txt_NAME_SIMINAR" runat="server" Width="100%"></asp:TextBox>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" style="padding-left: 4em">
                วันที่อบรม :
            </div>
            <div class="col-lg-4">
                <telerik:RadDatePicker ID="rdp_SIMINAR_DATE" runat="server" Width="95%" Enabled="False"></telerik:RadDatePicker>
                <%--  <asp:TextBox ID="SIMINAR_DATE" runat="server" Width="100%"></asp:TextBox>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" style="padding-left: 4em">
                ถึงวันที่ :
            </div>
            <div class="col-lg-4">
                <telerik:RadDatePicker ID="rdp_SIMINAR_DATE_END" runat="server" Width="95%" Enabled="False"></telerik:RadDatePicker>
                <%--  <asp:TextBox ID="SIMINAR_DATE" runat="server" Width="100%"></asp:TextBox>--%>
            </div>
        </div>
    </asp:Panel>


    <%--<div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            <p>๑. ข้าพเจ้า </p>
        </div>
        <div class="col-lg-3">
            <asp:RadioButtonList ID="rdl_chk_job" runat="server" RepeatDirection="Horizontal" Width="100%">
                <asp:ListItem Value="1">&ensp;ผู้ประกอบวิชาชีพหรือ&ensp;</asp:ListItem>
                <asp:ListItem Value="2">&ensp;ผู้ประกอบโรคศิลปะ&ensp;</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-1">
            สาขา &ensp;
            
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="ddl_phr_type" runat="server" Width="70%"></asp:DropDownList>
        </div>
        <div class="col-lg-1">
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-3">
            ใบอนุญาตที่ &ensp;
                <asp:TextBox ID="txt_phr_num" runat="server" Width="65%"></asp:TextBox>
            &ensp;
        </div>
        <div class="col-lg-1">
            ออกให้ ณ วันที่ &ensp;              
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="phr_date_num" runat="server" Width="70%"></asp:TextBox>
        </div>
    </div>

    <div style="padding-top: 30px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-8" style="padding-left:2em"> 
            กรณีไม่ใช่ผู้ประกอบวิชาชีพหรือผู้ประกอบโรคศิลปะ ข้าพเจ้าจบการศึกษาคุณวิฒิ &ensp;
                <asp:TextBox ID="txt_Study_Level" runat="server" Width="47%"></asp:TextBox>
        </div>
        <div class="col-lg-3">
        </div>
    </div>


    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            สาขา
        </div>
          <div class="col-lg-2">
             <asp:DropDownList ID="ddl_phr_type_other" runat="server" Width="100%"></asp:DropDownList>
          </div>
        <div class="col-lg-1">
            พ.ศ            
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_Study_Year" runat="server" Width="70%"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-6">
            &ensp; กรณีผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร  &ensp;
                   
        </div>
        <div class="col-lg-2">
            &ensp;
              
        </div>
        <div class="col-lg-2">
        </div>
    </div>--%>

    <%--    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            ชื่อหลักสูตร 
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_Name_Siminar" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1">วันที่อบรม</div>
        <div class="col-lg-2">
            <asp:TextBox ID="Siminar_Date" runat="server" Style="width: 70%"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btn_save_training" runat="server" Text="เพิ่มหลักสูตรการอบรม" Height="35px" Width="150px" />
        </div>
    </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Button ID="btn_save_training" runat="server" Text="เพิ่มหลักสูตรการอบรม" Height="35px" Width="150px" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <telerik:RadGrid ID="rgns" runat="server" Width="80%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                            HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_SIMINAR" FilterControlAltText="Filter NAME_SIMINAR column"
                            HeaderText="ชื่อหลักสูตร" SortExpression="NAME_SIMINAR" UniqueName="NAME_SIMINAR">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SIMINAR_DATE" FilterControlAltText="Filter SIMINAR_DATE column"
                            HeaderText="วันที่อบรม" SortExpression="SIMINAR_DATE" UniqueName="SIMINAR_DATE" DataFormatString="{0:dd/MM/yyyy}">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                            CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบหลักสูตรการอบรมหรือไม่">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
    <%--  <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            วันที่อบรม &ensp;
                
        </div>
    </div>--%>
    <br />
    <div style="padding-top: 30px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-4" style="padding-left: 2em">
            ปัจจุบัน ข้าพเจ้าเป็นผู้มีหน้าที่ปฏิบัติการตามพระราชบัญญัติผลิตภัณฑ์สมุนไพร พ.ศ. ๒๕๖๒
        </div>
        <div class="col-lg-2">
            <div>
                <asp:RadioButtonList ID="rdl_phr" AutoPostBack="true" runat="server">
                    <asp:ListItem Value="1">&ensp;มี</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;ไม่มี</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <%--  <div class="col-lg-4">
            จำนวน &ensp;
                 <asp:TextBox ID="txt_addr_num" runat="server" Width="20%" TextMode="Number"></asp:TextBox>
            &ensp; แห่ง &ensp; ได้แก่
        </div>--%>
    </div>
    <div id="chk_rad" runat="server" visible="false">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" runat="server">
                จำนวน &ensp;
                 <asp:TextBox ID="txt_addr_num" runat="server" Width="20%" TextMode="Number"></asp:TextBox>
                &ensp; แห่ง &ensp; ได้แก่
            </div>
        </div>
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-3">เลขนิติบุคคล/เลขบัตรประชาชน</div>
                <div class="col-lg-7">
                    <asp:TextBox ID="txt_CITIZEN_AUTHORIZE" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-3">เลขที่ใบอนุญาตสถานที่</div>
                <div class="col-lg-7">
                    <asp:TextBox ID="txt_lcnno_no" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                    &nbsp;(ตัวอย่าง นย1 กท 1/2555)
                    <asp:TextBox ID="txt_search_lcn_ida" runat="server" Width="100%" Visible="false"></asp:TextBox>
                </div>
            </div>
            <div style="text-align: center">
                <asp:Button ID="btn_search_lcn" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg" />
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-12">
                    <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>--%>
                    <telerik:RadGrid ID="RadGrid_lcn" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" PageSize="20">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                    HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="lcnno" FilterControlAltText="Filter lcnno column"
                                    HeaderText="lcnno" ReadOnly="True" SortExpression="lcnno" UniqueName="lcnno" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CITIZEN_ID_AUTHORIZE" FilterControlAltText="Filter CITIZEN_ID_AUTHORIZE column"
                                    HeaderText="CITIZEN_ID_AUTHORIZE" ReadOnly="True" SortExpression="CITIZEN_ID_AUTHORIZE" UniqueName="CITIZEN_ID_AUTHORIZE" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column"
                                    HeaderText="ประเภทคำขอ" SortExpression="lcntpcd" UniqueName="lcntpcd">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="LCNNO_DISPLAY_NEW" FilterControlAltText="Filter LCNNO_DISPLAY_NEW column"
                                    HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_DISPLAY_NEW" UniqueName="LCNNO_DISPLAY_NEW">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="thanm" FilterControlAltText="Filter thanm column"
                                    HeaderText="ชื่อสถานที่" SortExpression="thanm" UniqueName="thanm">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="thanm_addr" FilterControlAltText="Filter thanm_addr column"
                                    HeaderText="ที่อยู่" SortExpression="thanm_addr" UniqueName="thanm_addr" ItemStyle-Width="30%">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="grannm_lo" FilterControlAltText="Filter grannm_lo column"
                                    HeaderText="ชื่อผู้ดำเนินกิจการ" SortExpression="grannm_lo" UniqueName="grannm_lo">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="thachngwtnm" FilterControlAltText="Filter thachngwtnm column"
                                    HeaderText="จังหวัด" SortExpression="thachngwtnm" UniqueName="thachngwtnm">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                                    HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STAT_DA" FilterControlAltText="Filter STAT_DA column"
                                    HeaderText="สถานะใบอนุญาต" SortExpression="STAT_DA" UniqueName="STAT_DA">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                                    CommandName="sel" Text="เลือกข้อมูล">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridButtonColumn>
                                <%--   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_trid"
                            CommandName="_trid" Text="ขอเลขดำเนินการ" ConfirmText="คุณต้องการทำต่อหรือไม่?">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>--%>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
        </div>
        <div style="padding-top: 30px"></div>
        <br />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="col-lg-2">เป็นผู้มีหน้าที่ปฏิบัติการตามมาตรา </div>
                <div class="col-lg-9">
                    <div class="col-lg-2">
                        <asp:DropDownList ID="DDL_Matra" runat="server" BackColor="White" Height="25px" SkinID="bootstrap">
                            <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                            <asp:ListItem Value="31">31</asp:ListItem>
                            <asp:ListItem Value="32">32</asp:ListItem>
                            <asp:ListItem Value="33">33</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-5">แห่งพระราชบัญญัติผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๒ </div>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ของ</div>
            <div class="col-lg-9">
                <div class="col-lg-5">
                    <asp:TextBox ID="txt_Name_Bsn" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    (ชื่อสถานที่ประกอบธุรกิจ)
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">อยู่เลขที่</div>
            <div class="col-lg-2" style="padding-left: 1em">
                <asp:TextBox ID="txt_BSN_addr" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                หมู่บ้าน/อาคาร
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_BSN_Building" runat="server" Width="100%"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">หมู่ที่</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_BSN_mu" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ตรอก/ซอย</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_BSN_Soi" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1" style="text-align: center">
                ถนน
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_BSN_road" runat="server" Width="100%"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">จังหวัด</div>
            <div class="col-lg-2">
                <%--<asp:TextBox ID="txt_BSN_changwat" runat="server" Width="100%"></asp:TextBox>--%>
                <asp:DropDownList ID="ddl_Province" runat="server" Width="100%" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd"></asp:DropDownList>
                <asp:Label ID="lbl_Province" runat="server" Text="*กรุณาเลือกจังหวัด" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
            </div>
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                รหัสไปรษณีย์
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_BSN_zipcode" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1" style="text-align: center">โทรสาร</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_BSN_fax" runat="server" Width="100%"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                อำเภอ/แขวง
            </div>
            <div class="col-lg-2">
                <asp:DropDownList ID="ddl_amphor" runat="server" Width="100%" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
                </asp:DropDownList>
                <%--<asp:TextBox ID="txt_BSN_ampher" runat="server" Width="100%"></asp:TextBox>--%>
            </div>
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ตำบล/แขวง</div>
            <div class="col-lg-2">
                <%-- <asp:TextBox ID="txt_BSN_tambol" runat="server" Width="100%"></asp:TextBox>--%>
                <asp:DropDownList ID="ddl_tambol" runat="server" Width="100%" DataTextField="thathmblnm" DataValueField="thmblcd">
                </asp:DropDownList>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">โทรศัพท์</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_BSN_tel" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                เวลาทำการ
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_BSN_Opentime" runat="server" Width="100%"></asp:TextBox>
                <asp:Label ID="lbl_BSN_Opentime" runat="server" Text="*กรุณากรอกเวลาทำการ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Button ID="btn_save" runat="server" Text="เพิ่ม" Height="35px" Width="135px" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
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
                            <telerik:GridBoundColumn DataField="MATRA" FilterControlAltText="Filter MATRA column"
                                HeaderText="มาตรา" ReadOnly="True" SortExpression="MATRA" UniqueName="MATRA">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                                HeaderText="ชื่อสถานที่ประกอบธุรกิจ" ReadOnly="True" SortExpression="thanameplace" UniqueName="thanameplace">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FULL_ADDR" FilterControlAltText="Filter FULL_ADDR column"
                                HeaderText="ที่อยู่" ReadOnly="True" SortExpression="FULL_ADDR" UniqueName="FULL_ADDR">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OPEN_TIME" FilterControlAltText="Filter OPEN_TIME column"
                                HeaderText="เวลาทำการ" SortExpression="OPEN_TIME" UniqueName="OPEN_TIME">
                            </telerik:GridBoundColumn>
                            <%--     <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:HyperLink ID="HL_SELECT" runat="server">ดูรายละเอียด</asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>--%>
                            <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                            CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบข้อมูลหรือไม่">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>--%>
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
    </div>
    <div style="padding-top: 30px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <p>
                &ensp;๒. ข้าพเจ้าขอรับรองว่า ข้าพเจ้ามิได้เป็นผู้มีหน้าที่ปฏิบัติการของสถานที่ผลิต นำเข้า หรือขาย ผลิตภัณฑ์สมุนไพรหลายแห่งในเวลาเดียวกัน
            และไม่ได้เป็นผู้มีหน้าที่ปฏิบัติการตามกฎหมายอื่นในเวลาเดียวกันกับที่ยื่นคำขอเป็นผู้มีหน้าที่ปฏิบัติการตามพระราชบัญญัติผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๒
            </p>

        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            <p>๓. ขณะนี้ข้าพเจ้า</p>
        </div>
        <div class="col-lg-5">
            <asp:RadioButtonList ID="rdl_Phr_Service_Chk" runat="server" RepeatDirection="Horizontal" Width="100%" AutoPostBack="true">
                <asp:ListItem Value="1">&ensp;ไม่ได้รับราชการหรือทำงานประจำอยู่แห่งใด&ensp;</asp:ListItem>
                <asp:ListItem Value="2">&ensp;รับราชการหรือทำงานประจำอยู่ที่&ensp;</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_Phr_Service_Name" runat="server" Width="100%" Visible="false"></asp:TextBox>
        </div>
    </div>

    <div class="row" id="Service_Time" runat="server" visible="false">
        <div class="col-lg-6"></div>
        <div class="col-lg-1">
            เวลาทำการ &ensp;
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="Service_Time_Open" runat="server" TextMode="time" Width="100%" Height="30px"></asp:TextBox>
            <asp:Label ID="lbl_Service_Time_Open" runat="server" Text="*กรุณากรอกเวลาทำการ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
        </div>
        <div class="col-lg-2">
            ถึง &ensp;
                <asp:TextBox ID="Service_Time_Close" runat="server" TextMode="time" Width="38%" Height="30px"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="col-lg-4">
                <p>๔. ข้าพเจ้าจะเป็นผู้มีหน้าที่ปฏิบัติการประจำ </p>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="TXT_LCNNO_DIS" runat="server" Width="94%"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="BTN_SEARCH_LCNNO" runat="server" Text="ค้นหาใบอนุญาต" CssClass="btn-sm" />
            </div>
        </div>
    </div>
  <%--  <div class="row" style="text-align: center">
        <div class="col-lg-12">
            <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <telerik:RadGrid ID="RadGrid_lcn2" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" PageSize="20">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                            HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="lcnno" FilterControlAltText="Filter lcnno column"
                            HeaderText="lcnno" ReadOnly="True" SortExpression="lcnno" UniqueName="lcnno" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CITIZEN_ID_AUTHORIZE" FilterControlAltText="Filter CITIZEN_ID_AUTHORIZE column"
                            HeaderText="CITIZEN_ID_AUTHORIZE" ReadOnly="True" SortExpression="CITIZEN_ID_AUTHORIZE" UniqueName="CITIZEN_ID_AUTHORIZE" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column"
                            HeaderText="ประเภทคำขอ" SortExpression="lcntpcd" UniqueName="lcntpcd">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LCNNO_DISPLAY_NEW" FilterControlAltText="Filter LCNNO_DISPLAY_NEW column"
                            HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_DISPLAY_NEW" UniqueName="LCNNO_DISPLAY_NEW">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thanm" FilterControlAltText="Filter thanm column"
                            HeaderText="ชื่อสถานที่" SortExpression="thanm" UniqueName="thanm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thanm_addr" FilterControlAltText="Filter thanm_addr column"
                            HeaderText="ที่อยู่" SortExpression="thanm_addr" UniqueName="thanm_addr" ItemStyle-Width="30%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="grannm_lo" FilterControlAltText="Filter grannm_lo column"
                            HeaderText="ชื่อผู้ดำเนินกิจการ" SortExpression="grannm_lo" UniqueName="grannm_lo">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thachngwtnm" FilterControlAltText="Filter thachngwtnm column"
                            HeaderText="จังหวัด" SortExpression="thachngwtnm" UniqueName="thachngwtnm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                            HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STAT_DA" FilterControlAltText="Filter STAT_DA column"
                            HeaderText="สถานะใบอนุญาต" SortExpression="STAT_DA" UniqueName="STAT_DA">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                            CommandName="sel" Text="เลือกข้อมูล">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</div>--%>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">ณ สถานที่ประกอบธุรกิจชื่อ </div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_Business_Name" runat="server" Width="94%"></asp:TextBox>
        <%--   <asp:Label ID="Label_house_no" runat="server" Text="*กรุณากรอกรหัสประจำบ้าน" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>--%>
    </div>
    <%--        <div class="col-lg-2">
            <asp:Button ID="BTN_SEARCH_HOME_NO" runat="server" Text="ค้นหา" CssClass="btn-sm" />
        </div>--%>
    <div class="col-lg-1">รหัสประจำบ้าน </div>
    <div class="col-lg-2">
        <asp:TextBox ID="HOME_NO" Width="100%" runat="server"></asp:TextBox>
        <asp:Label ID="Label_house_no" runat="server" Text="*กรุณากรอกรหัสประจำบ้าน" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:Button ID="BTN_SEARCH_HOME_NO" runat="server" Text="ค้นหา" CssClass="btn-sm" />
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">อยู่เลขที่</div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_BN_addr" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        หมู่บ้าน/อาคาร
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_BN_Building" runat="server" Width="100%"></asp:TextBox>
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">หมู่ที่</div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_BN_mu" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
    <div class="col-lg-1">ตรอก/ซอย</div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_BN_Soi" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: center">
        ถนน
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_BN_road" runat="server" Width="100%"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">จังหวัด &ensp;</div>
    <div class="col-lg-2">
        <%--<asp:TextBox ID="txt_BN_changwat" runat="server" Width="100%"></asp:TextBox>--%>
        <asp:DropDownList ID="ddl_bn_changwat" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd" Width="100%"></asp:DropDownList>
        <asp:Label ID="lbl_bn_changwat" runat="server" Text="*กรุณาเลือกจังหวัด" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
    </div>
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        รหัสไปรษณีย์
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_BN_zipcode" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: center">โทรสาร</div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_BN_fax" runat="server" Width="100%"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">อำเภอ/แขวง</div>
    <div class="col-lg-2">
        <%--   <asp:TextBox ID="txt_BN_ampher" runat="server" Width="100%"></asp:TextBox>--%>
        <asp:DropDownList ID="ddl_bn_ampher" runat="server" Width="100%" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
        </asp:DropDownList>
        <asp:Label ID="lbl_bn_ampher" runat="server" Text="*กรุณาเลือกอำเภอ/แขวง" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
    </div>
    <div class="col-lg-1"></div>
    <div class="col-lg-1">ตำบล/แขวง</div>
    <div class="col-lg-2">
        <%--<asp:TextBox ID="txt_BN_tambol" runat="server" Width="100%"></asp:TextBox>--%>
        <asp:DropDownList ID="ddl_bn_tambol" runat="server" Width="100%" DataTextField="thathmblnm" DataValueField="thmblcd">
        </asp:DropDownList>
        <asp:Label ID="lbl_bn_tambol" runat="server" Text="*กรุณาเลือกตำบล/แขวง" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">โทรศัพท์</div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_BN_tel" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        เวลาทำการ
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_BN_Opentime" runat="server" Width="100%"></asp:TextBox>
        <asp:Label ID="lbl_BN_Opentime" runat="server" Text="*กรุณากรอกเวลาทำการ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
    </div>
</div>

<%--    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">เลขที่ใบอนุญาตสถานที่</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_lcnno_no" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
            &nbsp;(ตัวอย่าง นย1 กท 1/2555)
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btn_search_lcn" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg" />
        </div>
        <div class="col-lg-1"></div>
    </div>--%>
<%--    </form>--%>
</div>
