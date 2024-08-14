<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_JJ_EDIT_REQUEST2.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_JJ_EDIT_REQUEST2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/HERB_TABEAN_JJ_EDIT/UC/UC_PACKING_SIZE.ascx" TagPrefix="uc1" TagName="UC_PACKING_SIZE" %>
<%@ Register Src="~/HERB_TABEAN_JJ_EDIT/UC/UC_LABELS_AND DUCQUMENT.ascx" TagPrefix="uc1" TagName="UC_LABELS_ANDDUCQUMENT" %>
<%@ Register Src="~/HERB_TABEAN_JJ_EDIT/UC/UC_EDIT_NAME_PRODUCT.ascx" TagPrefix="uc1" TagName="UC_EDIT_NAME_PRODUCT" %>
<%@ Register Src="~/HERB_TABEAN_JJ_EDIT/UC/UC_ADDRESS_PRODUTION_SITE.ascx" TagPrefix="uc1" TagName="UC_ADDRESS_PRODUTION_SITE" %>
<%@ Register Src="~/HERB_TABEAN_JJ_EDIT/UC/UC_EDIT_FILE_UPLOAD_JJ.ascx" TagPrefix="uc1" TagName="UC_EDIT_FILE_UPLOAD_JJ" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--    <uc1:UC_PACKING_SIZE runat="server" ID="UC_PACKING_SIZE" />
    <uc1:UC_LABELS_ANDDUCQUMENT runat="server" ID="UC_LABELS_ANDDUCQUMENT" />
    <uc1:UC_EDIT_NAME_PRODUCT runat="server" ID="UC_EDIT_NAME_PRODUCT" />
    <uc1:UC_ADDRESS_PRODUTION_SITE runat="server" ID="UC_ADDRESS_PRODUTION_SITE" />--%>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
        <Tabs>
            <telerik:RadTab runat="server" Text="แก้ไขข้อมูลเอกสารแนบ" Value="1" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="แก้ไขข้อมูลคำขอ" Value="2">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>

    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="fa left" Width="100%">
        <telerik:RadPageView ID="RadPageView1" runat="server" TabIndex="1">
            <fieldset>
                <div style="padding-top: 10px"></div>
                <legend style="color: red; font-size: 28px">รายการเอกแนบที่ต้องแก้ไข
                </legend>
                <div class="panel panel-body" style="width: 100%; padding-left: 2%;">
                    <uc1:UC_EDIT_FILE_UPLOAD_JJ runat="server" ID="UC_EDIT_FILE_UPLOAD_JJ" />
                </div>
            </fieldset>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" TabIndex="2">
            <fieldset>
                <div style="padding-top: 10px"></div>
                <legend style="color: red; font-size: 28px">
                    <%--รายละเอียดคำขอที่ต้องแก้ไข--%>
                    <asp:Label ID="lbl_tabean" runat="server" Text="รายละเอียดคำขอที่ต้องแก้ไข"></asp:Label>
                </legend>
                <br />
                <div class="panel panel-body" style="width: 100%; padding-left: 2%;">
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-6" style="text-align: left; color: red;">
                            <h3>เอกสารแนบและหมายเหตุประกอบการแก้ไขคำขอ</h3>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10" style="text-align: left; padding-left: 2em;">
                            <div style="border-bottom: #999999 1px dotted;">
                                <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 60px; width: 100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-6" style="text-align: left; color: red;">
                            <h3>เอกสารแนบประกอบการแก้ไขคำขอ</h3>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10" style="text-align: left; padding-left: 2em">
                            <asp:Table ID="tb_UpLoadStaff" runat="server" CssClass="table" Width="100%"></asp:Table>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <%--  <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10">
                             <div style=" border-bottom: 3px solid gray;"></div>
                        </div>
                    </div>--%>

                    <div class="row" style="padding-top: 15px"></div>
                    <uc1:UC_PACKING_SIZE runat="server" ID="UC_PACKING_SIZE" />
                    <div style="padding-top: 10px"></div>
                    <uc1:UC_LABELS_ANDDUCQUMENT runat="server" ID="UC_LABELS_ANDDUCQUMENT" />
                    <div style="padding-top: 10px"></div>
                    <uc1:UC_EDIT_NAME_PRODUCT runat="server" ID="UC_EDIT_NAME_PRODUCT" />
                    <div style="padding-top: 10px"></div>
                    <uc1:UC_ADDRESS_PRODUTION_SITE runat="server" ID="UC_ADDRESS_PRODUTION_SITE" />
                    <div style="padding-top: 10px"></div>
                    <asp:Panel ID="Panel1" runat="server" Style="display: none;">
                    </asp:Panel>
                    <div class="row" id="E1" runat="server">
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Button ID="btn_cancel" runat="server" Text="ปิด" Height="40px" Width="135px" />&ensp;
                            <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
                        </div>
                    </div>
                </div>
            </fieldset>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>
