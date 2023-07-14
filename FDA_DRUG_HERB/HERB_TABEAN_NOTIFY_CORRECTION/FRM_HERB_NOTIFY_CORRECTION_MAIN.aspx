<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_PPK.Master" CodeBehind="FRM_HERB_NOTIFY_CORRECTION_MAIN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_NOTIFY_CORRECTION_MAIN" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">รายการทะเบียน</div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="width: 20%; text-align: right">เลือกประเภท</div>
        <div class="col-lg-6" style="width: 40%; text-align: center">
            <asp:DropDownList ID="DD_DRRGT_PROCESS_ID" runat="server" AutoPostBack="true">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="20610">คำขอใบแทนใบสำคัญการขึ้นทะเบียนผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="20620">คำขอใบแทนใบรับแจ้งรายละเอียดผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="20630">คำขอใบแทนใบรับจดแจ้งผลิตภัณฑ์สมุนไพร</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" runat="server" id="TB1" visible="false">
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
                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                        HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                        HeaderText="TR_ID" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_LCN_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_LCN_IDA column"
                        HeaderText="FK_LCN_IDA" ReadOnly="True" SortExpression="FK_LCN_IDA" UniqueName="FK_LCN_IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                        HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                        HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                    </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column"
                        HeaderText="เลขที่รับคำขอ" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RGTNO_DISPLAY" FilterControlAltText="Filter RGTNO_DISPLAY column"
                        HeaderText="เลขที่ทะเบียน" SortExpression="RGTNO_DISPLAY" UniqueName="RGTNO_DISPLAY">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column" HeaderText="ชื่อยา" ReadOnly="True" SortExpression="thadrgnm" UniqueName="thadrgnm">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column" HeaderText="ชื่อยา อังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:HyperLink ID="HL_SELECT" runat="server">เลือกข้อมูล</asp:HyperLink>
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

    </div>

</asp:Content>