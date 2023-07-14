<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_AUDIT_OUT_DETAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_AUDIT_OUT_DETAIL" %>

<style type="text/css">
</style>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    //$(document).ready(function () {
    //    showdate($("#ContentPlaceHolder1_UC_PHR_DETAIL_txt_Write_Date"));
    //    $("#ContentPlaceHolder1_UC_PHR_DETAIL_txt_Write_Date").searchable();
    //});
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
    <%--<form name="form" method="post" align="center;">--%>
        <div class="row">
            <div class="col-lg-12" style="text-align: center;">
                <h3>แบบคำขอให้ตรวจประเมินสถานที่ผลิตผลิตภัณฑ์สมุนไพร (ต่างประเทศ)</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12" style="text-align: center;">
                <h4>เพื่อขอให้ตรวจประเมินสถานที่ผลิตผลิตภัณฑ์สมุนไพรเพื่อขอหนังสือรับรองมาตรฐานการผลิต</h4>
            </div>
        </div>
        <div style="padding-top: 15px"></div>

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
            <div class="col-lg-1">
                <asp:TextBox ID="txt_Write_Date" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>

            <div class="col-lg-1">
                <h4>เรื่อง</h4>
            </div>
            <div class="col-lg-10">
                ขอให้ตรวจประเมินสถานที่ผลิตยาเพื่อหนังสือรับรองมาตรฐานการผลิต (ต่างประเทศ)
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                <h4>เรียน</h4>
            </div>
            <div class="col-lg-10">
                ผู้อำนวยการกองผลิตภัณฑ์สมุนไพร
            </div>
        </div>



        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ข้าพเจ้า</div>
            <div class="col-lg-8">
                <asp:TextBox ID="txt_Name" runat="server" Width="70%"></asp:TextBox>
                &nbsp; ผู้ดำเนินกิจการ
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">เลขที่ใบอนุญาต</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_lcnno_dispaly" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">ตั้งอยู่ที่</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_loacation_name" runat="server"></asp:TextBox>
            </div>

        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">โทรศัพท์</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_tel" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">โทรสาร</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_fax" runat="server"></asp:TextBox>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">มีความประสงค์จะขอให้เจ้าหน้าที่ตรวจประเมินสถานที่ผลิตผลิตภัณฑ์สมุนไพรเพื่อ</div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="padding-left: 2em">
                <asp:RadioButtonList ID="RDB_CER_PRO" runat="server" RepeatDirection="Vertical" AutoPostBack="true">
                    <asp:ListItem Value="1">&ensp;ขอหนังสือรับรองมาตรฐานการผลิต&ensp;</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;ขอเพิ่มหมวดการผลิตในหนังสือรับรองมาตรฐานการผลิต&ensp;</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="padding-left: 4em">
                <asp:RadioButtonList ID="RDB_SUB_CER_PRO" runat="server" RepeatDirection="Vertical" Enabled="false">
                    <asp:ListItem Value="1">&ensp;ประกาศกระทรวงสาธารณสุข เรื่อง การกำหนดรายละเอียดเกี่ยวกับหลักเกณฑ์และวิธีการในการผลิตยาแผนปัจจุบันและแก้ไขเพิ่มเติมหลักเกณฑ์
                        และวิธีการในการผลิตยาแผนโบราณตามกฎหมายว่าด้วยยา พ.ศ. 2559&ensp;</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;ประกาศกระทรวงสาธารณสุข เรื่อง หลักเกณฑ์ วิธีการ และเงื่อนไขเกี่ยวกับการผลิตผลิตภัณฑ์สมุนไพรตามพระราชบัญญัติผลิตภัณฑ์สมุนไพร พ.ศ. 2562 พ.ศ. 2564&ensp;</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" id="foreign" runat="server" >
            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ผลิตผลิตภัณฑ์สมุนไพร (ต่างประเทศ) ชื่อสถานที่:</label>
                </div>
                <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_search" runat="server" Width="100%"></asp:TextBox>
                    <asp:TextBox ID="txt_search_ida" runat="server" Width="100%" Visible="false"></asp:TextBox>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row">
                <div class="col-lg-3"></div>
                <div class="col-lg-6" style="width: 60%">
                    <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
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
                                <%--<telerik:GridClientSelectColumn UniqueName="SelectColumn" />--%>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="frgncd" DataType="System.Int32" FilterControlAltText="Filter frgncd column" HeaderText="frgncd"
                                    SortExpression="frgncd" UniqueName="frgncd" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="engfrgnnm" FilterControlAltText="Filter engfrgnnm column"
                                    HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาอังกฤษ)" SortExpression="engfrgnnm" UniqueName="engfrgnnm">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="thafrgnnm" FilterControlAltText="Filter thafrgnnm column"
                                    HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาไทย)" SortExpression="thafrgnnm" UniqueName="thafrgnnm">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                                    CommandName="sel" Text="เลือก">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridButtonColumn>
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
                <div class="col-lg-3"></div>
                <div class="col-lg-6" style="width: 60%">
                    <telerik:RadGrid ID="RadGrid3" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
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
                                <%--<telerik:GridClientSelectColumn UniqueName="SelectColumn" />--%>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="fulladdr4" FilterControlAltText="Filter fulladdr4 column"
                                    HeaderText="ที่อยู่" SortExpression="fulladdr4" UniqueName="fulladdr4">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                                    CommandName="sel" Text="เลือก">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridButtonColumn>
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
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ตั้งอยู่ที่(ผู้ผลิตต่างประเทศ):</label>
                </div>
                <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                    <asp:TextBox ID="txt_address_ida" runat="server" TextMode="MultiLine" Height="60px" Width="100%" Visible="false"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
<%--    </form>--%>
</div>
