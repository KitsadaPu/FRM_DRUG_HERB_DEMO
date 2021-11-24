<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_TABEAN_SUBSTITUTE_SUB_DR.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_SUBSTITUTE_SUB_DR" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12" style="text-align: center">รายการทะเบียน</div>
    </div>

    <div class="row">
         <div class="col-lg-12" style="text-align:center">
             <asp:Button ID="btn_add_tabean" runat="server" Text="เพิ่มคำขอใบแทนใบสำคัญ" />
         </div>
    </div>

    <div class="row">
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
                    <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column"
                        HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                    </telerik:GridBoundColumn> 
                    <telerik:GridBoundColumn DataField="DRRGT_REASON_ID" DataType="System.Int32" FilterControlAltText="Filter DRRGT_REASON_ID column"
                        HeaderText="DRRGT_REASON_ID" ReadOnly="True" SortExpression="DRRGT_REASON_ID" UniqueName="DRRGT_REASON_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="rgtno_display" FilterControlAltText="Filter rgtno_display column"
                        HeaderText="เลขที่ทะเบียน" SortExpression="rgtno_display" UniqueName="rgtno_display">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column" HeaderText="ชื่อยา" ReadOnly="True" SortExpression="thadrgnm" UniqueName="thadrgnm">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column" HeaderText="ชื่อยา อังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
                    </telerik:GridBoundColumn> 
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column" HeaderText="สะถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
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
