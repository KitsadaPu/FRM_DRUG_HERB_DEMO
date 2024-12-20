﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_CONSIDER.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_STAFF_LCN_CONSIDER" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.blockUI.js"></script>
 <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript" >
 
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
                        <asp:TextBox ID="Txt_Remark" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td></tr>

                    <tr ><td>ชื่อผู้ลงนาม </td><td>
                        <telerik:RadComboBox ID="rcb_staff_offer" Runat="server" Filter="Contains" DataTextField="STAFF_OFFER_NAME" DataValueField="IDA">
                        </telerik:RadComboBox>
                        </td></tr>

                    <tr ><td>วันที่เสนอลงนาม</td><td>
                        <asp:TextBox ID="TextBox1" runat="server" class="input-lg"></asp:TextBox></td></tr>

                    <%--<tr ><td>วันที่คาดว่าจะอนุมัติ</td><td>
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
