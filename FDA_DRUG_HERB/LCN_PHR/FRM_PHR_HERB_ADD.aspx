<%@ Page Title="" Language="vb" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_PHR_HERB_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_PHR_HERB_ADD" %>

<%@ Register Src="~/LCN_PHR/UC/UC_PHR_DETAIL.ascx" TagPrefix="uc1" TagName="UC_PHR_DETAIL" %>
<%@ Register Src="~/LCN_PHR/UC/UC_PHR_MATRA.ascx" TagPrefix="uc1" TagName="UC_PHR_MATRA" %>
<%@ Register Src="~/LCN_PHR/UC/UC_PHR_UPLOAD_FILE.ascx" TagPrefix="uc1" TagName="UC_PHR_UPLOAD_FILE" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_UC_LCN_DETAIL_txt_Write_Date"));
            $("#ContentPlaceHolder1_UC_LCN_DETAIL_txt_Write_Date").searchable();
        });

        function spin_space() { // คำสั่งสั่งปิด PopUp
            $('#spinner').toggle('slow');
        }

        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%; padding-left: 5%; padding-right: 5%; padding-top: 0.1%; background-color: gray;">
        <div class="panel panel-body" style="width: auto; padding-left: 5%; padding-right: 5%; background-color: white;">
            <uc1:UC_PHR_UPLOAD_FILE runat="server" ID="UC_PHR_UPLOAD_FILE" />
            <uc1:UC_PHR_MATRA runat="server" ID="UC_PHR_MATRA" />
            <uc1:UC_PHR_DETAIL runat="server" ID="UC_PHR_DETAIL" />
            <footer>
                <div class="row" id="E1" runat="server">
                    <div class="col-lg-12" style="text-align: center">
                        <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
                    </div>
                </div>
            </footer>
        </div>
    </div>
</asp:Content>
