<%@ Page Title="" Language="vb" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_NOTIFY_CORRECTION_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_HERB_NOTIFY_CORRECTION_ADD" %>

<%@ Register Src="~/HERB_TABEAN_NOTIFY_CORRECTION/UC_NOTIFY_CORRECTION/UC_SELECT_TABEAN.ascx" TagPrefix="uc1" TagName="UC_SELECT_TABEAN" %>
<%@ Register Src="~/HERB_TABEAN_NOTIFY_CORRECTION/UC_NOTIFY_CORRECTION/UC_NOTIFY_CORRECTION_DETAIL.ascx" TagPrefix="uc1" TagName="UC_NOTIFY_CORRECTION_DETAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_UC_TABEAN_EDIT_txt_Write_Date"));
            $("#ContentPlaceHolder1_UC_TABEAN_EDIT_txt_Write_Date").searchable();

            showdate($("ContentPlaceHolder1_UC_EXHIBITION_DETAIL_txt_date_exh"));
            $("ContentPlaceHolder1_UC_EXHIBITION_DETAIL_txt_date_exh").searchable();
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="width: 100%; height: 100%; padding-left: 5%; padding-right: 5%; padding-top: 0.1%; background-color: gray;">
        <div class="panel panel-body" style="width: auto; height: 100%; padding-left: 5%; padding-right: 5%; background-color: white;">
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="Panel1" runat="server" Style="display: block;">
                        <uc1:UC_SELECT_TABEAN runat="server" ID="UC_SELECT_TABEAN" />
                        <div class="row" id="Div1" runat="server">
                            <div class="col-lg-12" style="text-align: center">
                                <asp:Button ID="BTN_ADD" runat="server" Text="เพิ่ม" Height="40px" Width="135px" />&ensp;
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Style="display: none;">
                        <uc1:UC_NOTIFY_CORRECTION_DETAIL runat="server" ID="UC_NOTIFY_CORRECTION_DETAIL" />
                        <%--   <div class="row" id="Div2" runat="server">
                    <div class="col-lg-12" style="text-align: center">
                        <asp:Button ID="BTN_ADD2" runat="server" Text="เพิ่มข้อมูลส่วนที่2" Height="40px" Width="135px" />&ensp;
                    </div>
                </div>--%>
                    </asp:Panel>
                </div>
            </div>
            <asp:Panel ID="Panel3" runat="server" Style="display: none;">
                <div class="row" id="E1" runat="server">
                    <div class="col-lg-12" style="text-align: center">
                        <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" />&ensp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
