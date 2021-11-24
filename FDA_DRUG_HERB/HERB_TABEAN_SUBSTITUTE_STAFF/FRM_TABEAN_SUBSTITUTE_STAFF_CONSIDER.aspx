<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_TABEAN_SUBSTITUTE_STAFF_CONSIDER.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_SUBSTITUTE_CONSIDER" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.blockUI.js"></script>
 <link href="../css/css_main.css" rel="stylesheet" /> 
           <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
             $(document).ready(function () {
                 showdate($("#ContentPlaceHolder1_TextBox1"));
            $("#ContentPlaceHolder1_DD_OFF_REQ").searchable();
        });
        $(function () {
            $('#<%= Button1.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });

    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เสนอลงนาม</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>หมายเหตุ</td><td>
                        <asp:TextBox ID="Txt_Remark" runat="server" TextMode="MultiLine" style="width: 1054px;height: 53px"></asp:TextBox>
                        </td></tr>

                    <tr ><td>ชื่อผู้ลงนาม</td><td>
                        <%--<asp:DropDownList ID="ddl_staff_offer" runat="server" DataTextField="STAFF_OFFER_NAME" DataValueField="IDA" CssClass="input-lg" Width="200px">
                        </asp:DropDownList>--%>
                        <telerik:RadComboBox ID="rcb_staff_offer" Runat="server" Filter="Contains" DataTextField="STAFF_OFFER_NAME" DataValueField="IDA">
                        </telerik:RadComboBox>


                        </td></tr>
                 <%--   <tr ><td>ตำแหน่ง (บรรทัดที่ 1)</td><td>
                        <asp:TextBox ID="txt_position1" runat="server" class="input-lg" Width="80%"></asp:TextBox>
                        </td></tr>--%>
                    <%--<tr ><td>ตำแหน่ง (บรรทัดที่ 2)</td><td>
                        <asp:DropDownList ID="ddl_staff_position" runat="server" DataTextField="POSITION_NAME" DataValueField="IDA" CssClass="input-lg" Width="200px">
                        </asp:DropDownList>
                        </td></tr>--%>
                    <tr ><td>วันที่เสนอลงนาม</td><td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
          <%--          <tr ><td>วันที่คาดว่าจะอนุมัติ</td><td>
                        <asp:TextBox ID="txt_app_date" runat="server" class="input-lg"></asp:TextBox></td></tr>--%>
                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>