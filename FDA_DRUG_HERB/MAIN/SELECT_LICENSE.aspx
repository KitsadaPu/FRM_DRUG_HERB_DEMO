<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="SELECT_LICENSE.aspx.vb" Inherits="FDA_DRUG_HERB.LCN_REQUEST" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left: -1px;
            top: -344px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript">

            function Popups2(url) { // สำหรับทำ Div Popup
                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }
            function close_modal() { // คำสั่งสั่งปิด PopUp
                $('#myModal').modal('hide');
                //$('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
            }

        </script>
        <div class="panel" style="text-align:center ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
             <div  class="auto-style1" ><h3> เลือกรายการใบอนุญาตที่ต้องการแก้ไข</h3> </div>

         </div>
    
    </div>

        <telerik:radgrid ID="rgns" runat="server" Width ="90%" >
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                           <Columns>
                               <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PROCESS_ID" FilterControlAltText="Filter PROCESS_ID column"
                                   HeaderText="PROCESS_ID" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="syslcnsnm_identify" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="_identify" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="LOCATION_ADDRESS_IDA" FilterControlAltText="Filter LOCATION_ADDRESS_IDA column"
                                   HeaderText="LOCATION_ADDRESS_IDA" SortExpression="LOCATION_ADDRESS_IDA" UniqueName="LOCATION_ADDRESS_IDA" Display="false">
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
                                    SortExpression="SIMINAR_DATE" UniqueName="TRANSECTION_ID_UPLOAD" >
                               </telerik:GridBoundColumn>
                              <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sele"
                                   CommandName="req" Text="ขอแก้ไข">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                               <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sele"
                                   CommandName="rep" Text="ขอใบแทน">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>--%>
                           </Columns>
                       </MasterTableView>
 </telerik:radgrid>


</asp:Content>
