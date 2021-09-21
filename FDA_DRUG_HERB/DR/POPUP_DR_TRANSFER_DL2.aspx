<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DR_TRANSFER_DL2.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_DR_TRANSFER_DL2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript" >



          $(document).ready(function () {
              //$(window).load(function () {
              //    $.ajax({
              //        type: 'POST',
              //        data: { submit: true },
              //        success: function (result) {
              //            $('#spinner').fadeOut(1);

              //        }
              //    });
              //});

              function CloseSpin() {
                  $('#spinner').toggle('slow');
              }

              $('#ContentPlaceHolder1_btn_upload').click(function () {
                  Popups('POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx');
                  return false;
              });

              $('#ContentPlaceHolder1_btn_download').click(function () {
                  Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
                  return false;
              });

              function Popups(url) { // สำหรับทำ Div Popup

                  $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                  var i = $('#f1'); // ID ของ iframe   
                  i.attr("src", url); //  url ของ form ที่จะเปิด
              }


            



          });

          function Popups2(url) { // สำหรับทำ Div Popup

              $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f1'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function Popups3(url) { // สำหรับทำ Div Popup

              $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f2'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function spin_space() { // คำสั่งสั่งปิด PopUp
              //    alert('123456');
              $('#spinner').toggle('slow');
              //$('#myModal').modal('hide');
              //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

          }
          function close_modal() { // คำสั่งสั่งปิด PopUp
              $('#myModal').modal('hide');
              $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }

          function close_modal2() { // คำสั่งสั่งปิด PopUp
              $('#myModal2').modal('hide');
              $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }
     </script> 
    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 70px">

            <div class="col-lg-4 col-md-4">
                <h4>ดาวน์โหลดคำขอขึ้นทะเบียน (Transfer)</h4>
            </div>
            <div class="col-lg-8 col-md-8">
                <p style="text-align: right; padding-right: 5%;"></p>
            </div>

        </div>
    </div>
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <table width="100%">
            <tr>
                <td>
                    <table style="width: 100%;" class=" table">

                        <%-- <tr>
                <td>เลขนิติบุคคล/เลขบัตรประชาชน</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_CITIZEN_AUTHORIZE" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>--%>
                        <tr>
                            <td>ประเภท</td>
                            <td width="70%">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Referred</asp:ListItem>
                                    <asp:ListItem Value="2">Transferred</asp:ListItem>
                                    <asp:ListItem Value="3">Copy</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>

                        <tr>
                            <td>เลขทะเบียน</td>
                            <td width="70%">
                                <asp:TextBox ID="txt_lcnno_no" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                                &nbsp;( ตัวอย่าง 1C 1/26 (N) )</td>
                        </tr>

                        <tr>
                            <td>&nbsp;</td>
                            <td width="70%">
                                <asp:Button ID="btn_search" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg" />
                            </td>
                        </tr>
                    </table>


                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <br />

        </table>
        <table width="100%">
            <tr>
                <td>

                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
                        <MasterTableView AutoGenerateColumns="False">
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="rcvno_display" FilterControlAltText="Filter rcvno_display column"
                                    HeaderText="เลขรับ" SortExpression="rcvno_display" UniqueName="rcvno_display">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column"
                                    HeaderText="ชื่อการค้า(ภาษาไทย)" SortExpression="thadrgnm" UniqueName="thadrgnm">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column"
                                    HeaderText="ชื่อการค้า(อื่นๆ)" SortExpression="engdrgnm" UniqueName="engdrgnm">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_download"
                                    CommandName="dow" Text="ดาวน์โหลดคำขอ Transfer">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_tranfer"
                                    CommandName="tranfer" Text="Transfer คำขอนี้">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridButtonColumn>
                                <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_add"
                           CommandName="add" Text="เพิ่มข้อมูลส่วนที่ 2">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>--%>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>


                </td>
            </tr>

        </table>
         <asp:Panel ID="Panel1" runat="server" Style="display: none;">

        </asp:Panel>
    </div>
</asp:Content>
