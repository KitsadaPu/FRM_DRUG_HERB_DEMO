<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="LIST_STAFF_LCN_REPRESENT.aspx.vb" Inherits="FDA_DRUG_HERB.LIST_STAFF_LCN_REPRESENT" %>
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
                        $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
                    }

                        </script>
    <style>
        .panel {
            margin-bottom:0px;
        }
    </style>
    <div class="row">
        <div class="col-lg-6"></div>
        <div class="col-lg-5">                    
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             <asp:Button ID="Button1" runat="server" Text="ค้นหา" />
        </div>
        <div class="col-lg-1"></div>
    </div><br />

                <telerik:radgrid ID="rgns" runat="server" Width ="90%" >
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                           <Columns>
                               <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="ID_DALCN" FilterControlAltText="Filter IDA column"
                                   HeaderText="ID_DALCN" SortExpression="ID_DALCN" UniqueName="ID_DALCN" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="rcbno" HeaderText="เลขรับ" FilterControlAltText="Filter SIMINAR_DATE column"
                                    SortExpression="rcbno" UniqueName="rcbno" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="TR_ID" HeaderText="เลขดำเนินการ" FilterControlAltText="Filter TR_ID column"
                                   SortExpression="TR_ID" UniqueName="NAME_SIMINAR" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="NOTE" HeaderText="หมายเหตุ" FilterControlAltText="Filter thanameplace column"
                                    SortExpression="NOTE" UniqueName="NOTE" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn  DataField="STATUS_NAME" HeaderText="สถานะ" FilterControlAltText="Filter fulladdr column"
                                    SortExpression="STATUS_NAME" UniqueName="SIMINAR_DATE" >
                               </telerik:GridBoundColumn>
                              <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sele"
                                   CommandName="sele" Text="เลือกข้อมูล">
                                   <HeaderStyle Width="70px"/>
                               </telerik:GridButtonColumn>

                           </Columns>
                       </MasterTableView>
 </telerik:radgrid>
                    <asp:Button ID="btn_reload" runat="server" Text="" style="display:none" />
                  <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>
                       <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label> </h1>
                   </div>
                  <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>--%>
                   <div class="panel-body" >
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
       </div>
</asp:Content>
