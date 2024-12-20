﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_RESEARCH_SUM.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_RESEARCH_SUM" %>

<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc1" TagName="UC_ATTACH_DRUG" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            border-collapse: collapse;
            width: 79%;
            max-width: 100%;
            margin-bottom: 20px;
        }
        .auto-style3 {
            height: 20px;
        }

        #pj_sum {
            /*font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;*/
            border-collapse: collapse;
            width: 100%;
        }

        #pj_sum td, #pj_sum th {
            border: 1px solid #ddd;
            padding: 8px;
        }

        #pj_sum tr:nth-child(even){background-color: #f2f2f2;}

        #pj_sum th {
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: left;
            /*background-color: #4CAF50;*/
            /*color: white;*/
        }
        b{
            color:#0000a7;
        }
    </style>
    <link href="../../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../../Jsdate/ui.datepicker.js"></script>
    <script src="../../../Jsdate/ui.datepicker-th.js"></script>
    <script type="text/javascript">
        //function showdate(targetobject) {
        //    $(targetobject).datepicker({
        //        showOn: "button",
        //        buttonImage: "../../../jsdate/calendar.gif",
        //        buttonImageOnly: true
        //    });

        //}
        //$(document).ready(function () {
        //    showdate($("#ContentPlaceHolder1_txt_start_date"));
        //    showdate($("#ContentPlaceHolder1_txt_end_date"));
        //});
        $(function () {
            $("#ContentPlaceHolder1_txt_start_date").datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
        $(function () {
            $("#ContentPlaceHolder1_txt_end_date").datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <script type="text/javascript" >
              $(document).ready(function () {
                  $(window).load(function () {
                      $.ajax({
                          type: 'POST',
                          data: { submit: true },
                          success: function (result) {
                              // $('#spinner').fadeOut('slow');
                          }
                      });
                  });

                  function CloseSpin() {
                      $('#spinner').toggle('slow');
                  }

                  $('#ContentPlaceHolder1_btn_upload').click(function () {

                      $('#spinner').toggle('slow');
                      Popups('POPUP_LCN_UPLOAD.aspx');
                      return false;
                  });

                  $('#ContentPlaceHolder1_btn_download').click(function () {
                      $('#spinner').fadeIn('slow');
                      Popups('POPUP_LCN_DOWNLOAD.aspx');
                      return false;
                  });

                  function Popups(url) { // สำหรับทำ Div Popup
                      $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                      var i = $('#f1'); // ID ของ iframe   
                      i.attr("src", url); //  url ของ form ที่จะเปิด
                  }

                  function close_modal() { // คำสั่งสั่งปิด PopUp
                      $('#myModal').modal('hide');
                      $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
                  }
              });

              function spin_space() { // คำสั่งสั่งปิด PopUp
                  //    alert('123456');
                  $('#spinner').toggle('slow');
                  //$('#myModal').modal('hide');
                  //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

              }
        </script> 
         <script type="text/javascript" >
              function closespinner() {
                  $('#spinner').fadeOut('slow');
                  alert('Download Success');
                  $('#ContentPlaceHolder1_Button1').click();
              }
         </script>
  <div id="spinner" style=" background-color:transparent;display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
     <div style="width:100% ; text-align:left"  >
          <div style="width:auto ; float:left ;text-align:center;display:none">
              <h4>
         ยื่นข้อมูลที่&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="rbtn_bangkok" runat="server" Checked="True" GroupName="pvn" text="ศูนย์ อย."/>  &nbsp;&nbsp;&nbsp;&nbsp;  <asp:RadioButton ID="rbtn_other" runat="server" GroupName="pvn" Text="ต่างจังหวัด" />
      </h4>
    </div>

          <h3>
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
          </h3>
          <center>
              <h3>รายละเอียดโครงการวิจัย</h3></center>
                 <asp:Label ID="Label1" runat="server"></asp:Label>
                 <br />
          <b>1.ชื่อโครงการวิจัย ภาษาไทย :</b>
                     <asp:Label ID="Label2" runat="server"></asp:Label>
                 <br />
          <b>2.ชื่อโครงการวิจัย ภาษาอังกฤษ :</b>
                     <asp:Label ID="Label3" runat="server"></asp:Label>
                 <br />
          <b>3.รหัสโครงการ ได้แก่ รหัสที่ตั้งโดยผู้สนับสนุนการวิจัย (sponsor) :</b>
                     <asp:Label ID="Label4" runat="server"></asp:Label>
                 <br />
          <b>4.ชื่อย่อของโครงการ หรือ ชื่อเรียกอื่น :</b>
                     <asp:Label ID="Label5" runat="server"></asp:Label>
                 <br />
          <b>5.IND number ของ US FDA :</b>
                     <asp:Label ID="Label6" runat="server"></asp:Label>
                 <br />
          <b>6.การลงทะเบียนงานวิจัย (Clinical Trials Registry) :</b>
                     <asp:Label ID="Label7" runat="server"></asp:Label>
                 <br />
          <b>7.ประเภทของโครงการวิจัย
                     :</b>
                     <asp:Label ID="Label8" runat="server"></asp:Label>
&nbsp;
                     <asp:Label ID="Label9" runat="server"></asp:Label>
                 <br />
          <b>8.ประเภทของการสนับสนุนการวิจัย :</b>
                     <asp:Label ID="Label10" runat="server"></asp:Label>
                 <br />
          <b>9.ประเทศที่ทำการวิจัย :</b>
                     <asp:Label ID="Label11" runat="server"></asp:Label>
                 <br />
          <b>10.จำนวนสถาบันที่ร่วมวิจัยทั้งหมดทั่วโลก :</b>
                     <asp:Label ID="Label12" runat="server"></asp:Label>
                 <br />
          <b>11.จำนวนอาสาสมัครทั้งหมดทั่วโลกตามแผน :</b>
                     <asp:Label ID="Label13" runat="server"></asp:Label>
                 <br />
          <b>12.จำนวนสถาบันที่ร่วมวิจัยในประเทศไทยตามแผน :</b>
                     <asp:Label ID="Label14" runat="server"></asp:Label>
                 <br />
          <b>13.ข้อมูลของแต่ละสถานที่วิจัยในประเทศไทย :</b>

                     <asp:Label ID="Label15" runat="server"></asp:Label>
                 <br />
          <b>14.ผู้สนับสนุนการวิจัยในประเทศไทย (Thai Sponsor) :   </b>
                     <asp:Label ID="Label16" runat="server"></asp:Label>
                 <br />
          <b>15.ผู้สนับสนุนการวิจัยในต่างประเทศ (Foreign Sponsor) :   </b>
                     <asp:Label ID="Label17" runat="server"></asp:Label>
                 <br />
          <b>16.บริษัทหรือหน่วยงานที่กำกับดูแล การวิจัย (Monitor) :   </b>
                     <asp:Label ID="Label18" runat="server"></asp:Label>
                 <br />
          <b>17.บริษัทหรือหน่วยงานที่บริหาร จัดการโครงการวิจัย (Project Management) :   </b>
                     <asp:Label ID="Label19" runat="server"></asp:Label>
                 <br />
          <b>18.บริษัทหรือหน่วยงานที่บริหาร จัดการข้อมูล (Data Management) :   </b>
                     <asp:Label ID="Label20" runat="server"></asp:Label>
                 <br />
          <b>19.ห้องปฏิบัติการคลินิก (Clinical Laboratory) :</b>
                     <asp:Label ID="Label21" runat="server"></asp:Label>
                 <br />
          <b>20.รายการยาที่ใช้ในโครงการ :                 </b>
         <asp:Label ID="Label27" runat="server"></asp:Label>

                   &nbsp;<b><br />
          21.วันที่เริ่มการวิจัยในประเทศไทย (โดยประมาณ) :</b>
                     <asp:Label ID="Label23" runat="server"></asp:Label>
                 <br />
          <b>22.วันที่สิ้นสุดการวิจัยในประเทศไทย (โดยประมาณ) :</b>
                     <asp:Label ID="Label24" runat="server"></asp:Label>
                 <br />
          <b>23.วิธีการหาอาสาสมัคร :</b>
                     <asp:Label ID="Label25" runat="server"></asp:Label>
                 <br />
          <b>24.การสนับสนุนทางการเงินและ การประกัน (Financing and Insurance) :</b>
                     <asp:Label ID="Label26" runat="server"></asp:Label>
                     &nbsp;
                     <asp:HyperLink ID="HyperLink1" runat="server" Visible="False" Target="_blank">[HyperLink1]</asp:HyperLink>
                 <br />
          <br />
         <br>
         <table class="auto-style2" id="pj_sum" style="display:none"> 
             <%--<tr><td class="auto-style1">   เลขบัญชีรายการยาที่ใช้ในโครงการ</td><td>   
                 <asp:TextBox ID="txt_drug" runat="server" Width="150px"></asp:TextBox>
&nbsp;
                 <asp:Button ID="Button7" runat="server" Text="เพิ่ม" />
                 <asp:Label ID="lbl_drug_id1" runat="server" Visible="False"></asp:Label>
                 <br />
                 <asp:Label ID="lbl_error" runat="server" ForeColor="#CC0000" Text="ไม่พบบัญชีรายการยา" Visible="False"></asp:Label>
                 <br />
                 <asp:Label ID="lbl_drug" runat="server"></asp:Label>
                 <br />
                 </td></tr>--%>
             <tr><td class="auto-style1">   &nbsp;</td><td>   
                 <br />
                 </td></tr>
             <tr>
                 <td>1.ชื่อโครงการวิจัย ภาษาไทย</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>2.ชื่อโครงการวิจัย ภาษาอังกฤษ</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>3.รหัสโครงการ ได้แก่ รหัสที่ตั้งโดยผู้สนับสนุนการวิจัย (sponsor) ควรเป็นรหัสที่ใช้เหมือนกันในทุกสถานที่วิจัยของโครงร่างการวิจัย เดียวกันนี้</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>4.ชื่อย่อของโครงการ หรือ ชื่อเรียกอื่น</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>5.IND number ของ US FDA</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>6.การลงทะเบียนงานวิจัย (Clinical Trials Registry) (อาจลงทะเบียนกับ Registry ของไทยหรือต่างประเทศก็ได้ มากกว่าหนึ่งแห่งก็ได้)</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>7.ประเภทของโครงการวิจัย
                     <br />
                     (1-4 นิยามตาม ICH-E8 `General Consideration for Clinical Trials&#39;)</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>8.ประเภทของการสนับสนุนการวิจัย</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>9.ประเทศที่ทำการวิจัย</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>10.จำนวนสถาบันที่ร่วมวิจัยทั้งหมดทั่วโลก</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style3">11.จำนวนอาสาสมัครทั้งหมดทั่วโลกตามแผน</td>
                 <td class="auto-style3">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>12.จำนวนสถาบันที่ร่วมวิจัยในประเทศไทยตามแผน</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>13.ข้อมูลของแต่ละสถานที่วิจัยในประเทศไทย</td>
                 <td>

                     &nbsp;</td>
             </tr>
             <tr>
                 <td>14.ผู้สนับสนุนการวิจัยในประเทศไทย (Thai Sponsor)</td>
                 <td>   
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>15.ผู้สนับสนุนการวิจัยในต่างประเทศ (Foreign Sponsor)</td>
                 <td>   
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>16.บริษัทหรือหน่วยงานที่กำกับดูแล การวิจัย (Monitor)</td>
                 <td>   
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>17.บริษัทหรือหน่วยงานที่บริหาร จัดการโครงการวิจัย (Project Management)</td>
                 <td>   
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>18.บริษัทหรือหน่วยงานที่บริหาร จัดการข้อมูล (Data Management)</td>
                 <td>   
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>19.ห้องปฏิบัติการคลินิก (Clinical Laboratory)</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>20.รายการยาที่ใช้ในโครงการ (ให้ระบุยาทุกตัวที่ใช้ในโครงการ รวมทั้ง ยาวิจัย ยาเปรียบเทียบ/ยาหลอก และยาที่ใช้ร่วม โดยไม่คำนึงว่าจะขออนุญาตในคำขอนี้หรือไม่)</td>
                 <td>

                     &nbsp;</td>
             </tr>
             <tr>
                 <td>21.วันที่เริ่มการวิจัยในประเทศไทย (โดยประมาณ)</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>22.วันที่สิ้นสุดการวิจัยในประเทศไทย (โดยประมาณ)</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>23.วิธีการหาอาสาสมัคร</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>24.การสนับสนุนทางการเงินและ การประกัน (Financing and Insurance)</td>
                 <td>
                     &nbsp;</td>
             </tr>

             <tr><td colspan="2"> &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
                 <asp:Button ID="btn_save" CssClass="btn-lg" runat="server" Text="ทำเรื่องยื่น นยม1" Visible="False" />
                 </td></tr>
         </table>

    </div>
</asp:Content>
