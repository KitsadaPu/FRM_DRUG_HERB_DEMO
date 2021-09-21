<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_EDIT.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_EDIT" %>

<style type="text/css">
    .auto-style3 {
        width: 1099px;
        height: 124px;
    }
</style>

<div>
    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-3">
            <h2>คำขอแก้ไขรายการในใบอนุญาตฯ</h2>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-3">
            <asp:RadioButtonList ID="rdl_lcn_type" runat="server" BorderStyle="None" Enabled="False">
                <asp:ListItem Value="1">ผลิตผลิตภัณฆ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="2">นำเข้าผลิตภัณฆ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="3">ขายผลิตภัณฆ์สมุนไพร</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-5"></div>
    </div>
    <div>
        <br />
    </div>
    <div>
        <br />
    </div>
    <div></div>

    <div class="row">
        <div class="col-lg-1" style="text-align: right;"></div>
        <div class="col-lg-2">ข้าพเจ้า :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_name" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">(ชื่อผู้รับอนุญาต)</div>
        <div class="col-lg-5"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ซึ้งมีผู้มีหน้าที่ปฏิบัติการชื่อ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_phr_name" runat="server" BorderColor="Lime" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">(เฉพาะกรณีนิติบุคคล)</div>
        <div class="col-lg-5"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">เลขประจำตัวประชาชน/ใบอนุญาตทำงานเลขที่ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_iden" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-7"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ตามใบอนุญาตเลขที่ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_lcnno" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">ณ สถานที่ประกอบธุรกิจชื่อ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_location" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">อยู่เลขที่ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_addr" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">หมู่บ้าน/อาคาร :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_building" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">หมู่ที่ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_mu" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">ตรอก/ซอย :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_soi" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ถนน :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_road" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">ตำบลแขวง :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_tambol" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">อำเภอเขต :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_amphor" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">จังหวัด :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_changwat" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">รหัสไปรษณีย์ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_zipcode" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">โทรศัพท์ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_tel" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">เวลาทำการ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_opentime" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-7"></div>
    </div>
    <div id="edit1" runat="server">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                <h4>ขอเปลี่ยนแปลงรายการในใบอนุญาตดังต่อไปนี้
                    <span style="font-size: 16px; color: red;">*กรุณาเลือกรายการ</span>
                </h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-3">

                <asp:DropDownList ID="DDL_EDIT_REASON" runat="server" DataValueField="LCN_REASON_TYPE" DataTextField="LCN_REASON_NAME" BackColor="White" Height="25px" Width="400px" SkinID="bootstrap" AutoPostBack="True">
                </asp:DropDownList>


            </div>

        </div>
        <div class="row" id="lb1" runat="server" visible="false">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                <h4>
                    <asp:Label ID="lb_select_reason" runat="server"></asp:Label>
                    <span style="font-size: 16px; color: red;">*กรุณาเลือกรายการ
                    </span>
                </h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" runat="server">
                <asp:DropDownList ID="DDL_EDIT_REASON_SUB" runat="server" DataValueField="SUB_REASON_TYPE" DataTextField="SUB_REASON_NAME" BackColor="White" Height="25px" Width="400px" SkinID="bootstrap" AutoPostBack="True" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div>
        <asp:Panel ID="p1" runat="server" Visible="false">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <h3>รายการเอกสารแนบ</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <span style="font-size: 16px; color: red;">
                        <asp:Label ID="cm1" runat="server">*ในขั้นตอนการแนบไฟล์นี้ ท่านสามารถแนบไฟล์และอัพโหลดไฟล์แนบไปทีละหัวข้อได้โดยไม่จำเป็นต้องแนบไฟล์ทั้งหมด แล้วกดยืนยันไฟล์แนบทีเดียว ทั้งนี้ หากทั้งไม่สามารถแนบไฟล์ทั้งหมดให้ครบในครั้งเดียวได้ ท่านสามารถยืนยันไฟล์แนบเฉพาะหัวข้อที่ท่านแนบไฟล์แล้ว และสามารถมาแนบไฟล์เพิ่มต่อในภายหลัง</asp:Label>
                    </span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-log4">
                    <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดเอกสาร" CssClass="btn-sm" OnClientClick="return confirm('กรุณาตรวจสอบความถูกต้องของเอกสารก่อนกด ยืนยัน');" />&nbsp;&nbsp;
                </div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div>
                    <div style="overflow-x: scroll; height: 300px">

                        <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>

                    </div>
                </div>

            </div>
        </asp:Panel>
    </div>
    <div id="edit2" runat="server">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-11">
                <h4>เหตุผลการขอแก้ไขใบอนุญาต :</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                <asp:TextBox ID="txt_reason_name" runat="server" TextMode="MultiLine" BackColor="White" Height="100px" Width="600px" SkinID="bootstrap"></asp:TextBox>
            </div>

        </div>
    </div>



    
   
</div>
