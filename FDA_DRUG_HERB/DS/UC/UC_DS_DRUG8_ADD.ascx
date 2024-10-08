﻿<%@ Control  Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_DRUG8_ADD.ascx.vb" Inherits="FDA_DRUG_HERB.UC_DS_DRUG8_ADD" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


    <style type="text/css">

    .auto-style11 {
        font-size: 18px;
    }
    .RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
    .auto-style12 {
        width: 1243px;
    }
    </style>
<div class="box">
        <div class="panel-heading panel-title">
                <h1 class="auto-style12">
                    <asp:Label ID="lbl_head" runat="server" Text="-"></asp:Label></h1> 
    <table class="table" style="width: 100%;">
            <tr >
   <%--             <td align="right" class="auto-style18">--%>
                <%--<asp:CheckBox ID="chk_unit" runat="server" Text="ขนาดบรรจุ :" AutoPostBack="True"></asp:CheckBox>--%>
                <%-- <tr id="package2" runat="server" style="display:none;">--%>
<%--                    <asp:Label ID="lb_unit" runat="server" Text="ขนาดบรรจุ :"></asp:Label>
                </td>--%>
                
                <td>
                    ชื่อขนาดบรรจุ 
                <asp:TextBox ID="txt_packagename" runat="server"></asp:TextBox><br />
                    Primary package จำนวน&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_sunit" runat="server" Height="22px"></asp:TextBox>
                    <asp:Label ID="lbl_sunit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                    &nbsp;ต่อ
                <%--<asp:TextBox ID="txt_size2" runat="server"></asp:TextBox>--%>
            <asp:Label ID="lbl_small_unit" runat="server"></asp:Label>
                    <telerik:RadComboBox ID="ddl_munit" runat="server" filter="Contains"  AutoPostBack="True"></telerik:RadComboBox>
                   <%-- <asp:DropDownList ID="ddl_munit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm" AutoPostBack="True"></asp:DropDownList>
              --%>  <br />
                    Secondary package จำนวน
                <asp:TextBox ID="txt_mamount" runat="server"></asp:TextBox>
                    <asp:Label ID="lbl_munit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                    &nbsp;ต่อ
                    <telerik:RadComboBox ID="ddl_bunit" runat="server" filter="Contains"></telerik:RadComboBox>
                <%--<asp:DropDownList ID="ddl_bunit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm"></asp:DropDownList>
                 --%>   <br />
                    GTIN (กรณีไม่มีให้ใส่0) <asp:TextBox ID="txt_barcode" runat="server" Width="128px"></asp:TextBox>
                    <asp:label ID="lbl_sunit_ida" runat="server" DataTextField="lbl_sunit_ida" DataValueField="lbl_sunit_ida" AutoPostBack="True" Visible="False"></asp:label><br />
                <asp:Button ID="btn_add" runat="server" Text="บันทึกขนาดบรรจุ" CssClass="auto-style11" Height="53px" Width="180px"></asp:Button>
                <asp:Button ID="btn_eddt" runat="server" Text="แก้ไขขนาดบรรจุ" CssClass="auto-style11" Height="53px" Width="180px"></asp:Button>
                <asp:Button ID="btn_edre" runat="server" Text="ยกเลิกการแก้ไข" CssClass="auto-style11" Height="53px" Width="180px"></asp:Button>
                    <br />
                </td>
            </tr>
            </table>
        </div>

                   <telerik:RadGrid ID="RadGrid80" runat="server" GridLines="None" width="100%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                           <%-- <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate>
                                   <asp:CheckBox ID="checkColumn" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="PACKAGE_NAME" HeaderText="ชื่อขนาดบรรจุ" DataField="PACKAGE_NAME" >
                                  <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="SMALL_AMOUNT" HeaderText="จำนวน" DataField="SMALL_AMOUNT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>  
                            <telerik:GridBoundColumn UniqueName="SMALL_UNIT" HeaderText="หน่วย" DataField="SMALL_UNIT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="x" HeaderText="ต่อ" DataField="x" >
                            </telerik:GridBoundColumn>  
                            <telerik:GridBoundColumn UniqueName="MEDIUM_AMOUNT" HeaderText="จำนวน" DataField="MEDIUM_AMOUNT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="MEDIUM_UNIT" HeaderText="หน่วย" DataField="MEDIUM_UNIT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                                                      <telerik:GridBoundColumn UniqueName="x" HeaderText="ต่อ" DataField="x" >
                            </telerik:GridBoundColumn>  
                             <telerik:GridBoundColumn UniqueName="BIG_AMOUNT" HeaderText="จำนวน" DataField="BIG_AMOUNT" >
                                  <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BIG_UNIT" HeaderText="หน่วย" DataField="BIG_UNIT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BARCODE" HeaderText="หมายเลขบาร์โค้ด" DataField="BARCODE" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                                         <telerik:GridButtonColumn UniqueName="eddt" ButtonType="LinkButton" Text="แก้ไขข้อมูล" CommandName="eddt">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>


                 <center>
                     <br />
                     <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="auto-style11" Height="53px" Width="180px"></asp:Button> </center>
                    </p>
    </div>