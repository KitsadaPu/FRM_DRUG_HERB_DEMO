﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_SELECT_PROCESS_LCN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_SELECT_PROCESS_LCN" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4>กรุณาเลือกใบอนุญาตของท่าน</h4> </div>
                          <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;"></p>
                          </div>

         </div>
    </div>
     <br />
                 <%--<p class="h3">ใบอนุญาต</p>--%>
                <hr />
                <telerik:RadGrid ID="RadGrid1" runat="server">
<MasterTableView autogeneratecolumns="False" datakeynames="IDA">
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
        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
             HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
        </telerik:GridBoundColumn>
        
                 <telerik:GridBoundColumn DataField="LCNNO_DISPLAY" FilterControlAltText="Filter LCNNO_DISPLAY column"
                      HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_DISPLAY" UniqueName="LCNNO_DISPLAY">
        
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column" HeaderText="ชื่อสถานที่" ReadOnly="True" SortExpression="thanameplace" UniqueName="thanameplace">
        
        </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" SortExpression="fulladdr" UniqueName="fulladdr">
          
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn>
            <ItemTemplate>
                <asp:HyperLink ID="HL_SELECT"  runat="server">เลือกข้อมูล</asp:HyperLink>
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

         
</asp:Content>
