﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_CER_EXP_REMARK.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_STAFF_CER_EXP_REMARK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เหตุผลการคืนคำขอ</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>เหตุผลการคืนคำขอ</td><td>
                        <asp:TextBox ID="Txt_Remark" runat="server" CssClass="input-sm" Width="500px" Height="200px"></asp:TextBox>
                        </td></tr>
                    <tr ><td>วันที่</td><td>
                        <asp:TextBox ID="txt_app_date" runat="server" class="input-sm" Width="120px"></asp:TextBox></td></tr>
                    </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="btn_save" runat="server" Text="บันทึก"  CssClass="btn-lg"/>
                  <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>