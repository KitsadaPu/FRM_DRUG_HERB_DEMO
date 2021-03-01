<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="LIST_LCN_REPRESENT.aspx.vb" Inherits="FDA_DRUG_HERB.LIST_LCN_REPRESENT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10"><h1>รายการคำขอจัดการสถานที่</h1></div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row">
                <div class="col-lg-10"></div>
                <div class="col-lg-1">
                 <asp:Button ID="Button1" runat="server" Text="เพิ่มคำขอ" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <telerik:radgrid ID="rgns" runat="server" Width ="90%" >
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                           <Columns>
                               <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="LCNNO_MANUAL" HeaderText="เลขที่ใบอนุญาต" FilterControlAltText="Filter SIMINAR_DATE column"
                                    SortExpression="SIMINAR_DATE" UniqueName="LCNNO_MANUAL" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PROCESS_NAME" HeaderText="ประเภท" FilterControlAltText="Filter PROCESS_NAME column"
                                   SortExpression="NAME_SIMINAR" UniqueName="NAME_SIMINAR" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="thanameplace" HeaderText="ชื่อสถานที่" FilterControlAltText="Filter thanameplace column"
                                    SortExpression="SIMINAR_DATE" UniqueName="SIMINAR_DATE" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn  DataField="fulladdr" HeaderText="ที่อยู่" FilterControlAltText="Filter fulladdr column"
                                    SortExpression="SIMINAR_DATE" UniqueName="SIMINAR_DATE" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" FilterControlAltText="Filter lcnsid column"
                                  SortExpression="SIMINAR_DATE" UniqueName="SIMINAR_DATE" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="HOUSENO" HeaderText="เลขสถานที่" FilterControlAltText="Filter HOUSENO column"
                                    SortExpression="SIMINAR_DATE" UniqueName="SIMINAR_DATE" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="TRANSECTION_ID_UPLOAD" HeaderText="เลขดำเนินการ" FilterControlAltText="Filter TRANSECTION_ID_UPLOAD column"
                                    SortExpression="SIMINAR_DATE" UniqueName="SIMINAR_DATE" >
                               </telerik:GridBoundColumn>

                           </Columns>
                       </MasterTableView>
 </telerik:radgrid>

</asp:Content>
