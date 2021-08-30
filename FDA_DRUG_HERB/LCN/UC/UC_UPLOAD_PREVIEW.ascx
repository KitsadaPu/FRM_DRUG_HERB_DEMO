<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_UPLOAD_PREVIEW.ascx.vb" Inherits="FDA_DRUG_HERB.UC_UPLOAD_PREVIEW" %>




<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>
<style type="text/css">
    .myDiv {
        display: none;
    }

    .myDiv2 {
        display: none;
    }

    .myDiv3 {
        display: none;
    }

    .myDiv4 {
        display: none;
    }

    .sub_mydiv {
        display: none;
    }

    .sub_mydiv2 {
        display: none;
    }

    label {
        margin-right: 20px;
    }
</style>
<%--</asp:Content>--%>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">--%>
<script type="text/javascript">



    $(document).ready(function () {
        //$(window).load(function () {
        //    $.ajax({
        //        type: 'POST',
        //        data: { submit: true },
        //        success: function (result) {
        //            $('#spinner').fadeOut(1);

        //        }
        //    });
        //});

        function CloseSpin() {
            $('#spinner').toggle('slow');
        }

        //$('#ContentPlaceHolder1_btn_upload').click(function () {
        //    var IDA = getQuerystring("IDA");
        //    var process = getQuerystring("process");
        //    Popups('POPUP_LCN_UPLOAD_ATTACH.aspx?IDA=' & IDA  & '&process=' & process & '');
        //    return false;
        //});

        //$('#ContentPlaceHolder1_btn_download').click(function () {
        //    Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
        //    return false;
        //});

        function Popups(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }




        $('#ContentPlaceHolder1_btn_download').click(function () {
            $('#spinner').fadeIn('slow');

        });

    });
    function close_modal() { // คำสั่งสั่งปิด PopUp
        $('#myModal').modal('hide');
        $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
    }

    function Popups2(url) { // สำหรับทำ Div Popup

        $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
        var i = $('#f1'); // ID ของ iframe   
        i.attr("src", url); //  url ของ form ที่จะเปิด
    }
    function Popups3(url) { // สำหรับทำ Div Popup

        $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
        var i = $('#f3'); // ID ของ iframe   
        i.attr("src", url); //  url ของ form ที่จะเปิด
    }
    function Popups4(url) { // สำหรับทำ Div Popup

        $('#myModal4').modal('toggle'); // เป็นคำสั่งเปิดปิด
        var i = $('#f4'); // ID ของ iframe   
        i.attr("src", url); //  url ของ form ที่จะเปิด
    }
    function spin_space() { // คำสั่งสั่งปิด PopUp
        //    alert('123456');
        $('#spinner').toggle('slow');
        //$('#myModal').modal('hide');
        //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

    }
    function closespinner() {
        alert('Download เสร็จสิ้น');
        $('#spinner').fadeOut('slow');
        $('#ContentPlaceHolder1_Button1').click();
    }
</script>
<div id="spinner" style="background-color: transparent; display: none;">
    <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
<div style="width: 100%; text-align: left">
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-7">
        <h3>อัพโหลดเอกสาร</h3>
    </div>
</div>

<div id="test">
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-11">
            <asp:Label ID="lbl_type_person" runat="server" Text="-" Font-Size="Large"></asp:Label>
            <asp:Label ID="lbl_type_local" runat="server" Text="" Font-Size="Large"></asp:Label>
            <asp:Label ID="lbl_type_bsn" runat="server" Text="" Font-Size="Large"></asp:Label>
        </div>
    </div>

   <%-- <asp:Panel ID="Panel_Type_Local" runat="server" Style="display: none;">
        <div class="row">
            <div class="col-lg-1" style="padding-left: 2em"></div>
            <div class="col-lg-8">
                <asp:Label ID="lbl_type_local" runat="server" Text="type_local"></asp:Label>
            </div>
        </div>
    </asp:Panel>--%>

<%--    <asp:Panel ID="Panel_Type_BSN" runat="server" Style="display: none;">
        <div class="row">
            <div class="col-lg-1" style="padding-left: 2em"></div>
            <div class="col-lg-8">
                <asp:Label ID="lbl_type_bsn" runat="server" Text="type_bsn"></asp:Label>
            </div>
        </div>
    </asp:Panel>--%>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <asp:GridView ID="GV_lcnno" runat="server" Width="100%" DataKeyNames="IDA" CellPadding="4" CssClass="table"
                ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <%--<asp:BoundField DataField="pay_stat" HeaderText="การชำระเงิน" ItemStyle-Width ="10%" />--%>
                    <%--<asp:BoundField DataField="rcvno" HeaderText="เลขที่รับ" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" />
      
         <asp:BoundField DataField="rcvdate"  DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width ="20%" >
<ItemStyle Width="20%"></ItemStyle>
         </asp:BoundField>
         <asp:BoundField HeaderText="วันที่รับพิจารณา" DataFormatString="{0:d}" />
         <asp:BoundField HeaderText="วันที่แล้วเสร็จ" DataFormatString="{0:d}" />--%>
                    <%--<asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                     <ItemTemplate>
                          <asp:Label ID="lbl_status" runat="server" ></asp:Label>
                     </ItemTemplate>
                </asp:TemplateField>--%>

                    <asp:BoundField DataField="DUCUMENT_NAME" HeaderText="เอการที่แนบ" ItemStyle-Width="80%" ItemStyle-HorizontalAlign="Left">
                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="NAME_REAL" HeaderText="ชื่อไฟล์" ItemStyle-Width="20%">
                        <ItemStyle Width="20%" />
                    </asp:BoundField>

                    <%-- <asp:CheckBoxField DataField="pay_stat_chk" HeaderText="การชำระเงิน" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                       <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                   </asp:CheckBoxField>--%>

                    <asp:TemplateField ItemStyle-Width="15%">
                        <ItemTemplate>

                            <%-- <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="15%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />--%>
                           &nbsp; &nbsp; &nbsp;
                        <asp:HyperLink ID="btn_Select" runat="server" Target="_blank" CssClass="btn-control" CommandName="sel" Width="100%" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>ดูข้อมูล</asp:HyperLink>
                        </ItemTemplate>

                        <ItemStyle Width="15%"></ItemStyle>
                    </asp:TemplateField>




                </Columns>
                <EmptyDataTemplate>
                    <center>ไม่พบข้อมูล</center>
                </EmptyDataTemplate>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#AEB6BF  " Font-Bold="True" ForeColor="#17202A" CssClass="row" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EBF5FB  " CssClass="row" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </div>
   
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Height="40px" />

        </div>
    </div>




    <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />
</div>
