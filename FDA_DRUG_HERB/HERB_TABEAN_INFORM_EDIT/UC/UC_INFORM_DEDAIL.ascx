<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_INFORM_DEDAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_INFORM_DEDAIL" %>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <h3 style="text-align: center">คำขอแก้ไขเปลี่ยนแปลงรายการในใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร</h3>
    </div>
    <div class="col-lg-1"></div>
</div>
<br />
<div class="row">
    <%--<div class="col-lg-1"></div>--%>
    <div class="col-lg-1" style="text-align: right;">
        เขียนที่              
    </div>
    <div class="col-lg-1">
        <asp:TextBox ID="Txt_Write_At" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <%-- <div class="col-lg-1"></div>--%>
    <div class="col-lg-1" style="text-align: right;">
        วันที่
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_Write_Date" runat="server" Width="87%"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row" style="height: 30px"></div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        <label>ข้าพเจ้า:</label>
    </div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted">
        <asp:TextBox ID="NAME_INFORM" runat="server" BorderStyle="None" ReadOnly="true" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-3">
        <label>ผู้รับใบสำคัญกำรขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร</label>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="T1" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-4">
        <label>เลขประจำตัวประชาชน/เลขทะเบียนนิติบุคคล/หนังสือเดินทางเลขที่:</label>
    </div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted; text-align: center">
        <asp:TextBox ID="txt_IDEN" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" style="height: 5px"></div>
<div class="row" id="T2" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-5">
        <label>ขอแก้ไขเปลี่ยนแปลงรายการในใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร</label>
    </div>
    <%-- <div class="col-lg-4" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="TextBox1" runat="server" Width="90%" BorderStyle="None"  ReadOnly="true"></asp:TextBox>
        </div>--%>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="T3" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-7">
        <label>ชื่อ (ภาษาไทย) </label>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="T4" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="border-bottom: #999999 1px dotted; text-align: center">
        <asp:TextBox ID="txt_name_thai_inform" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="T5" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-7">
        <label>ชื่อ (ภาษาอังกฤษ) </label>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="T6" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="border-bottom: #999999 1px dotted; text-align: center">
        <asp:TextBox ID="txt_name_eng_inform" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="T7" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-2">
        <label>ทะเบียนตำรับผลิตภัณฑ์สมุนไพร เลขที่ </label>
    </div>
    <div class="col-lg-7" style="border-bottom: #999999 1px dotted; text-align: center">
        <asp:TextBox ID="Txt_INFORM_NO" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="Div1" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-2">
        <label>รายการที่ขอแก้ไขเปลี่ยนแปลง</label>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10" style="padding-left: 2em">
        <asp:CheckBox ID="CB_1" Text="&nbsp;ชื่อของผลิตภัณฑ์สมุนไพร" runat="server" AutoPostBack="True" /><br />    
        <div class="row" runat="server" id="SUB_CB_1" visible="false">
              <div style="padding-top: 20px"></div>
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลเดิม</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ชื่อภาษาไทย:</label>
                        </div>
                        <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="LABEL_NAME_THAI" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ชื่อภาษาอังกฤษ:</label>
                        </div>
                        <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="LABEL_NAME_ENG" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ชื่อภาษาไทย:</label>
                        </div>
                        <div class="col-lg-5">
                            <asp:TextBox ID="TXT_NAME_THAI" runat="server" Width="100%" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ชื่อภาษาอังกฤษ:</label>
                        </div>
                        <div class="col-lg-5">
                            <asp:TextBox ID="TXT_NAME_ENG" runat="server" Width="100%" ></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:CheckBox ID="CB_2" Text="&nbsp;ชื่อหรือที่อยู่ของสถานที่ผลิต/ นำเข้า" runat="server" AutoPostBack="True" /><br />   
        <div class="row" runat="server" id="SUB_CB_2" visible="false">
            <div style="padding-top: 20px"></div>
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลเดิม</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ชื่อสถานที่เดิม:</label>
                        </div>
                        <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="TextBox1" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ชื่ชื่อสถานที่ใหม่:</label>
                        </div>
                        <div class="col-lg-5">
                            <asp:TextBox ID="TextBox3" runat="server" Width="100%" ></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:CheckBox ID="CB_3" Text="&nbsp;ขนาดบรรจุ(กรณีที่เป็นผลิตภัณฑ์สมุนไพรขายทั่วไปจะไม่อนุญาตให้แก้ไข)" runat="server" AutoPostBack="True" /><br />     
        <div class="row" runat="server" id="SUB_CB_3" visible="false">
              <div style="padding-top: 20px"></div>
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลเดิม</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ขนาดบรรจุเดิม:</label>
                        </div>
                        <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_size_pack" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ขนาดบรรจุใหม่:</label>
                        </div>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_size_pack" runat="server" Width="90%" ></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:CheckBox ID="CB_4" Text="&nbsp;ฉลาก " runat="server" AutoPostBack="True" /><br />
        <div class="row" runat="server" id="SUB_CB_4" visible="false">
                   <div style="padding-top: 20px"></div>
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลเดิม</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <%--            <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ขนาดบรรจุเดิม:</label>
                        </div>
                        <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="TextBox5" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>--%>
                </div>
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <%--                     <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>ขนาดบรรจุใหม่:</label>
                        </div>
                        <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="TextBox6" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>  --%>
                </div>
            </div>
        </div>
        <asp:CheckBox ID="CB_5" Text="&nbsp;เอกสารกำกับผลิตภัณฑ์สมุนไพร" runat="server" AutoPostBack="True" /><br />
        <div class="row" runat="server" id="SUB_CB_5" visible="false">
                    <div style="padding-top: 20px"></div>
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลเดิม</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
            </div>
        </div>
        <asp:CheckBox ID="CB_6" Text="&nbsp;ขนาดและวิธีการใช้ " runat="server" AutoPostBack="True" /><br />
        <div class="row" runat="server" id="SUB_CB_6" visible="false">
                    <div style="padding-top: 20px"></div>
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลเดิม</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-3">
                            ขนาดและวิธีการใช้:
                        </div>
                        <div class="col-lg-5">
                            <asp:TextBox ID="label_SIZE_USE" runat="server" TextMode="MultiLine" Height="65px" Width="450"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-3">
                            ขนาดและวิธีการใช้:
                        </div>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_SIZE_USE" runat="server" TextMode="MultiLine" Height="65px" Width="510"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:CheckBox ID="CB_7" Text="&nbsp;วิธีเตรียมก่อนรับประทาน " runat="server" AutoPostBack="True" /><br />      
        <div class="row" runat="server" id="SUB_CB_7" visible="false">
             <div style="padding-top: 20px"></div>
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลเดิม</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>วิธีเตรียมก่อนรับประทาน:</label>
                        </div>
                        <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="LABEL_EATTING" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-5">
                            <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">
                            <label>วิธีเตรียมก่อนรับประทาน:</label>
                        </div>
                        <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                            <asp:DropDownList ID="DD_EATTING_ID" runat="server" DataValueField="EATTING_ID" DataTextField="EATTING_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
