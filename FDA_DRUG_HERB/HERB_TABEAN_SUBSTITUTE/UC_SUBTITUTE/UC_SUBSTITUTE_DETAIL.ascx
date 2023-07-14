<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_SUBSTITUTE_DETAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_SUBSTITUTE_DETAIL" %>
   <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>

<div>
   <%-- <form name="form" method="post" align="center;">--%>
        <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <h2>คำขอใบแทนสำหรับผลิตภัณฑ์สมุนไพร     
                </h2>
            </div>
        </div>
        <%--      <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <label>
                    คำขอใบแทนสำหรับผลิตภัณฑ์สมุนไพร             
                </label>
            </div>
        </div>--%>

        <div class="row">
            <div class="col-md-12" style="text-align: left">
                <center>
                    <asp:RadioButtonList ID="rdl_tbn_type" runat="server" Enabled="false">
                        <asp:ListItem Value="20610">คำขอใบแทนใบสำคัญกำรขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร</asp:ListItem>
                        <asp:ListItem Value="20620">คำขอใบแทนใบรับแจ้งรำยละเอียดผลิตภัณฑ์สมุนไพร</asp:ListItem>
                        <asp:ListItem Value="20630">คำขอใบแทนใบรับจดแจ้งผลิตภัณฑ์สมุนไพร</asp:ListItem>
                    </asp:RadioButtonList></center>
            </div>

        </div>
        <br />


        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                ชื่อผู้ขอรับใบแทน
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:CheckBox ID="cb_Personal_Type1" Text="บุคคลธรรมดา " runat="server" Enabled="false" />
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                ข้าพเจ้า
            </div>
            <div class="col-lg-9" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_thanm" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10"></div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                อายุ
            </div>
            <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_person_age" runat="server" TextMode="Number" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1" style="text-align: center">
                สัญชาติ
            </div>
            <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_Nation" runat="server" TextMode="Number" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-2" style="text-align: center">
                เลขประจำตัวประชำชน
            </div>
            <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_iden" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:CheckBox ID="cb_Personal_Type2" Text="นิติบุคคล " runat="server"  Enabled="false" />
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                ข้าพเจ้า (ชื่อนิติบุคคล)
            </div>
            <div class="col-lg-8" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_NitiName" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                เลขทะเบียนนิติบุคคล
            </div>
            <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_idenNiti" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1" style="text-align: center">
                โดยมี
            </div>
            <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_alternate" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-3">
                เป็นผู้แทนนิติบุคคล หรือผู้มีอำนำจทำกำรแทนนิติบุคคล 
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                อายุ
            </div>
            <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_alternate_Old" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                ปี &emsp;&emsp; สัญชาติ
            </div>
            <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_Nationnal_Niti" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-2" style="text-align: center">
                เลขประจำตัวประชำชน.
            </div>
            <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_idenAlternate" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

            <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
               ขอรับใบแทนผลิตภัณฑ์สมุนไพร
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                ชื่อ (ภาษาไทย)
            </div>
            <div class="col-lg-9" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_NameThai" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
        
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
                ชื่อ (ภาษาอังกฤษ)
            </div>
            <div class="col-lg-9" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_NameEng" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        
            <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
               ใบสำคัญการขึ้นทะเบียนตำรับ/ ใบรับแจ้งรายละเอียด/ ใบรับจดแจ้งผลิตภัณฑ์สมุนไพร
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">
               เลขที่
            </div>
            <div class="col-lg-9" style="border-bottom: #999999 1px dotted;">
                <asp:TextBox ID="txt_NumNo" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

          <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
               เหตุที่ขอใบแทนผลิตภัณฑ์สมุนไพร
            </div>
            <div class="col-lg-8">
              <%--  <asp:TextBox ID="txt_Remark" runat="server" Width="100%" TextMode="MultiLine" Height="100px"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddl_sub_purpose" runat="server" DataTextField="TYPE_NAME" DataValueField="TYPE_ID" BackColor="White" Height="25px" Width="400px" SkinID="bootstrap" ></asp:DropDownList>
            </div>
            <div class="col-lg-1"></div>
        </div>

       <div class="row" style="height: 100px"></div>
   <%-- </form>--%>
</div>
