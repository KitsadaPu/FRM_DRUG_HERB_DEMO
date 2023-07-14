<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_PRODUCT_NOTIFIED_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_HERB_PRODUCT_NOTIFIED_ADD" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row" id="E1" runat="server">
        <div class="col-lg-12">
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-10">
                    <h3 style="text-align: center">คำขอเลขรับแจ้งการผลิต /นำเข้าวัตถุดิบสมุนไพร</h3>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2" style="text-align: center">
                    ชื่อผู้รับอนุญาตผลิต / นำเข้า
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="thanm" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    เลขที่ใบอนุญาตผลิตผลิตภัณฑ์สมุนไพร
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="lcnno" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-10" style="text-align: left">
                    ที่อยู่ผู้รับอนุญาตผลิต / นำเข้า
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    สถานที่ผลิตผลิตภัณฑ์สมุนไพรชื่อ
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="name_addr" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    อยู่เลขที่
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="addr" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    ถนน
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="road" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    หมู่ที่
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="mu" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    ตำบล/แขวง
                </div>
                <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="tambol" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    อำเภอ/เขต
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="ampher" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    จังหวัด
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="changwat" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    รหัสไปรษณีย์
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="zipcode" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    โทรศัพท์
                </div>
                <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                    <asp:TextBox ID="tel" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-10">
                    <h4>มีความประสงค์จะยื่นคำขอเลขรับแจ้งวัตถุดิบสมุนไพร รายละเอียดดังต่อไปนี้</h4>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    ชื่อการค้า
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="sell_name" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    ชื่อวิทยาศาสตร์
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="wit" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    ชื่อภาษาละติน
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="latin_name" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    ชื่อภาษาไทย
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="thai_name" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    ชื่อภาษาอังกฤษ
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="eng_name" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    สารสกัด / ชิ้นสมุนไพร / ผงบด
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="sakat" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    ผู้ผลิต (กรณีต่างประเทศ)
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="palid" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    รุ่นการผลิต
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="run_palit" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    จำนวน
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="quantity" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <%-- <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    มูลค่าวัตถุดิบที่ขายจากโรงงานต่อหน่วย
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="TextBox15" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    หมายเหตุ
                </div>
                <div class="col-lg-5">
                    <asp:TextBox ID="TextBox16" runat="server" Width="100%" TextMode="MultiLine" Height="70px"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>--%>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="text-align: center">
                    <asp:Button ID="Button1" runat="server" Text="เพิ่มข้อมูล" Height="49px" Style="margin-left: 0px" Width="171px" />
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-10">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="25">
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
                                <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                                    HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Trade_Name" FilterControlAltText="Filter Trade_Name column"
                                    HeaderText="ชื่อการค้า" ReadOnly="True" SortExpression="Trade_Name" UniqueName="Trade_Name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Scientific_Name" FilterControlAltText="Filter Scientific_Name column"
                                    HeaderText="ชื่อทางวิทยาศาสตร์" SortExpression="Scientific_Name" UniqueName="Scientific_Name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Latin_Name" FilterControlAltText="Filter Latin_Name column"
                                    HeaderText="ชื่อภาษาละติน" SortExpression="Latin_Name" UniqueName="Latin_Name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Thai_Name" FilterControlAltText="Filter Thai_Name column"
                                    HeaderText="ชื่อภาษาไทย" SortExpression="Thai_Name" UniqueName="Thai_Name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="English_Name" FilterControlAltText="Filter English_Name column"
                                    HeaderText="ชื่อภาษาอังกฤษ" SortExpression="English_Name" UniqueName="English_Name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Extract" FilterControlAltText="Filter Extract column"
                                    HeaderText="สารสกัด / ชิ้นสมุนไพร / ผงบด" SortExpression="Extract" UniqueName="Extract">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Producer" FilterControlAltText="Filter Producer column"
                                    HeaderText="ผู้ผลิต (กรณีต่างประเทศ)" SortExpression="Producer" UniqueName="Producer">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Production_Version" FilterControlAltText="Filter Production_Version column"
                                    HeaderText="รุ่นการผลิต" SortExpression="Production_Version" UniqueName="Production_Version">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Quantity" FilterControlAltText="Filter Quantity column"
                                    HeaderText="จำนวน" SortExpression="Quantity" UniqueName="Quantity">
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
                <div class="col-lg-1">
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="E2" runat="server">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" />&ensp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
        </div>
    </div>
</asp:Content>

