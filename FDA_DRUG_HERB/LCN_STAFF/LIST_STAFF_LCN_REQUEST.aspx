<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="LIST_STAFF_LCN_REQUEST.aspx.vb" Inherits="FDA_DRUG_HERB.LIST_STAFF_LCN_REQUEST" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <telerik:radgrid ID="rgns" runat="server" Width ="90%" >
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                           <Columns>
                               <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="rcbno" FilterControlAltText="Filter PROCESS_ID column"
                                   HeaderText="เลขรับ" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter LOCATION_ADDRESS_IDA column"
                                   HeaderText="เลขดำเนินการ" SortExpression="LOCATION_ADDRESS_IDA" UniqueName="LOCATION_ADDRESS_IDA" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="STATUS_NAME" HeaderText="สถานะ" FilterControlAltText="Filter SIMINAR_DATE column"
                                    SortExpression="SIMINAR_DATE" UniqueName="LCNNO_MANUAL" >
                               </telerik:GridBoundColumn>
                              <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sele"
                                   CommandName="sele" Text="เลือกข้อมูล">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>

                           </Columns>
                       </MasterTableView>
 </telerik:radgrid>
                  <div class=" modal fade" id="myModal">              
              <%-- <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>
                       <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label> </h1>
                   </div>
                  <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>--%>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <%--<div class="panel-footer"></div>
               </div>       --%>
       </div>
</asp:Content>
