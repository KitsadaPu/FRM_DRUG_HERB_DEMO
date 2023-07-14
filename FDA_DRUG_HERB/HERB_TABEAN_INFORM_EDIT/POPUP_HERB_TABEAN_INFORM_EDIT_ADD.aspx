<%@ Page Title="" Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_TABEAN_INFORM_EDIT_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_HERB_TABEAN_INFORM_EDIT_ADD" %>

<%@ Register Src="~/HERB_TABEAN_INFORM_EDIT/UC/UC_INFORM_DEDAIL.ascx" TagPrefix="uc1" TagName="UC_INFORM_DEDAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_UC_UC_INFORM_DEDAIL_txt_Write_Date"));
            $("#ContentPlaceHolder1_UC_UC_INFORM_DEDAIL_txt_Write_Date").searchable();
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
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <uc1:UC_INFORM_DEDAIL runat="server" ID="UC_INFORM_DEDAIL" />
            <hr />
            <br />
            <br />
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="E1" runat="server">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" />&ensp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
        </div>
    </div>
</asp:Content>
