<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_TABEAN_RENEW_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_HERB_TABEAN_RENEW_ADD" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
     <script type="text/javascript">
         //$(document).ready(function () {
         //    showdate($("#ContentPlaceHolder1_UC_LCN_DETAIL_txt_Write_Date"));
         //    $("#ContentPlaceHolder1_UC_LCN_DETAIL_txt_Write_Date").searchable();
         //});

         //function spin_space() { // คำสั่งสั่งปิด PopUp
         //    $('#spinner').toggle('slow');
         //}

         //function closespinner() {
         //    $('#spinner').fadeOut('slow');
         //    alert('Download Success');
         //    $('#ContentPlaceHolder1_Button1').click();
         //}
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       <div class="row">
        <div class="col-lg-8" style="width: 70%">
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_save" runat="server" Text="ยืนยัน" CssClass="btn-lg" Width="80%"/>
                    <div style="height: 5px"></div>
                    <asp:Button ID="btn_cancel" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>

        </div>
    </div>
</asp:Content>
