<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_REMARK_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_STAFF_LCN_REMARK_EDIT" %>

<%@ Register Src="~/UC/UC_ATTACH_LCN.ascx" TagPrefix="uc1" TagName="UC_ATTACH_LCN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 25%;
            left: 0px;
            top: 0px;
            padding-left: 7px;
            padding-right: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width: 100%">
        <div class="panel-heading panel-title">
            <h1>หมายเหตุการแก้ไข</h1>
        </div>
        <div class="panel-body">
            <asp:TextBox ID="TextBox1" runat="server" Width="100%" TextMode="MultiLine" Height="311px"></asp:TextBox>

            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-1">
                    <p>แนบเอกสารเพิ่ม</p>
                </div>
                <div class="auto-style2">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN" />
                </div>
            </div>
        </div>
        <div class="panel-footer " style="text-align: center;">
            <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
            &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก" CssClass="btn-lg" />
        </div>
    </div>
</asp:Content>
