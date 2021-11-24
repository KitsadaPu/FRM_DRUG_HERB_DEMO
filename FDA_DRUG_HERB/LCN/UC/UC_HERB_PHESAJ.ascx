<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB_PHESAJ.ascx.vb" Inherits="FDA_DRUG_HERB.UC_HERB_PHESAJ" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .auto-style2 {
        width: 85px;
    }

    .auto-style3 {
        width: 116px;
    }

    .auto-style4 {
        width: 71px;
    }
</style>
<div>

    <div>
        <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
                ๔. &ensp;ข้อมูลผุ้มีหน้าที่ปฎิบัติการในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร
        </h4>

        <div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-1">บัตรประชาชน </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_PHR_CTZNO" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-sm" />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-1">คำนำหน้าชื่อ  </div>
                <div class="col-lg-2">
                    <asp:DropDownList ID="ddl_prefix" runat="server" DataTextField="thanm" DataValueField="prefixcd"></asp:DropDownList>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="Label1" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาเลือกคำนำหน้า</p></asp:Label>
                </div>

            </div>

            <div class="row">

                <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    &nbsp;&nbsp; ๔.๑ กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลปะ ชื่อ
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_PHR_NAME" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <asp:DropDownList ID="ddl_phr_type" runat="server"></asp:DropDownList>
                    <asp:Label ID="Label3" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาระบุคุณวุฒิ</p></asp:Label>
                </div>

            </div>
            <div class="row">

                <div class="col-lg-1"></div>
                <div class="col-lg-4">ใบอนุญาตประกอบการวิชาชีพ/โรคศิลปะเลขที่ </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_PHR_TEXT_NUM" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">หรือ </div>

            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    กรณีที่ไม่ไช้ผู้ประกอบวิชาชีพหรือผู้ปรกอบโรคคิลปะ ให้ระบุคุณวุฒิ
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_STUDY_LEVEL" runat="server"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาระบุคุณวุฒิ</p></asp:Label>
                </div>
                <div class="col-lg-2">&nbsp;</div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-1">
                    สาขา
                </div>
                <div class="col-lg-4">
                    <asp:TextBox ID="txt_PHR_VETERINARY_FIELD" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-2">&nbsp;</div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-6">
                    &nbsp;&nbsp;
                            ๔.๒  ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_NAME_SIMINAR" runat="server"></asp:TextBox>

                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-1">
                    วันที่อบรม
                </div>
                <div class="col-lg-2">
                    <telerik:RadDatePicker ID="rdp_SIMINAR_DATE" runat="server"></telerik:RadDatePicker>
                </div>
                <div class="col-lg-1">
                    เวลาทำการ
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_PHR_TEXT_WORK_TIME" runat="server"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณากรอกเวลาทำการ</p> </asp:Label>
                </div>
            </div>
        </div>
        <div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">เป็นผู้ที่มีหน้าที่ปฎิยบัติการตาม </div>
                <div class="col-lg-4" style="text-align: center">
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
    <br />
  
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_save" runat="server" Text="เพิ่มผุ้มีหน้าที่ปฎิบัติการ" Height="45px" Width="320px" />
        </div>
    </div>
    <br />
    <telerik:RadGrid ID="rgphr" runat="server" Width="90%">
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
                <telerik:GridBoundColumn DataField="STUDY_LEVEL" FilterControlAltText="Filter STUDY_LEVEL column"
                    HeaderText="คุณวุฒิ" SortExpression="STUDY_LEVEL" UniqueName="STUDY_LEVEL">
                </telerik:GridBoundColumn>
               <%-- <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt"
                    CommandName="edt" Text="แก้ไข">
                    <HeaderStyle Width="70px" />
                </telerik:GridButtonColumn>--%>
                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                    CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบผู้ปฏิบัติการหรือไม่">
                    <HeaderStyle Width="70px" />
                </telerik:GridButtonColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>
