<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_MAIN_PRODUCK_MENU.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_MAIN_PRODUCK_MENU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 66%;
            height: 161px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <p class="h3" style="text-align: center;">เลือกกระบวนงานที่ท่านต้องการดำเนินการ</p>
    <hr />
    <div class="col-md-10 col-md-offset-1">
        <table id="ContentPlaceHolder1_Table1" class="auto-style1" align="Center">
            <tr class="row">
                <td align="Center" style="padding-top: 10px;">
                    <asp:Button ID="BTN_ON" runat="server" Text="ขอโอนใบอนุญาต" class="btn btn-green" Style="color: DarkBlue; border-radius: 12px; border: thin solid lightgreen;" BackColor="White" Height="150px" Width="275px" />
                </td>
                <td align="Center" style="padding-top: 10px;">
                    <asp:Button ID="BTN_SUBTITUTE" runat="server" Text="ขอใบแทน" class="btn btn-green" Style="color: DarkBlue; width: 275px; height: 150px; border-radius: 12px; border: solid; border-width: thin; border-color: lightgreen;" BackColor="White" />
                </td>

            </tr>
           <tr class="row">
                <td align="Center" style="padding-top: 10px;">
                    <asp:Button ID="BTN_EDIT" runat="server" Text="แก้ไขใบอนุญาต" class="btn btn-green" Style="color: DarkBlue; width: 275px; height: 150px; border-radius: 12px; border: solid; border-width: thin; border-color: lightgreen;" BackColor="White" />
                </td>
                <td align="Center" style="padding-top: 10px;">
                    <asp:Button ID="BTN_TOR" runat="server" Text="ต่ออายุใบอนุญาต" class="btn btn-green" Style="color: DarkBlue; width: 275px; height: 150px; border-radius: 12px; border: solid; border-width: thin; border-color: lightgreen;" BackColor="White" />
                </td>
            </tr>

        </table>
    </div>
</asp:Content>
