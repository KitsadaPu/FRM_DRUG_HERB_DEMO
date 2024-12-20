﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_GRID_ATTACH_LCN.ascx.vb" Inherits="FDA_DRUG_HERB.UC_GRID_ATTACH_LCN" %>
<asp:GridView ID="gv" runat="server" Width="100%" DataKeyNames="IDA" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="16px">
                      <AlternatingRowStyle BackColor="White" />
                      <Columns>
                          <asp:BoundField  HeaderText="ชื่อไฟล์แนบ" ItemStyle-Width="70%" DataField="NAME_REAL"/>

                           <asp:TemplateField ItemStyle-Width="30%">
                     <ItemTemplate>
                          
                        <asp:HyperLink ID="btn_Select" runat="server"  Target="_blank" CssClass="btn-control" CommandName="sel" Width="100%"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  >ดูข้อมูล</asp:HyperLink>
                           </ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
                </asp:TemplateField>
                      </Columns>
                        <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White"  />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                 </asp:GridView>
 <%--<table><tr><td class="auto-style1"><asp:Button ID="Button1" runat="server" Text="ดูข้อมูล" BackColor="#CCCCCC" BorderStyle="None" Height="23px" />

                                         </td><td class="btn-default">
     <asp:Label ID="fileName" runat="server" Text="fileName"></asp:Label>

                                         </td></tr></table>--%>