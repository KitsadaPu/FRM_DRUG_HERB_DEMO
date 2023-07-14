<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_INFORM_DEDAIL2.ascx.vb" Inherits="FDA_DRUG_HERB.UC_INFORM_DEDAIL2" %>

<asp:Panel ID="Panel1" runat="server" Style="display: block;">
            <div class="row">
                <div class="col-lg-3" style="text-align: left">
                    <h4>ชื่อของผลิตภัณฑ์สมุนไพร</h4>
                    <hr />
                </div>
            </div>
            <div class="row" style="height: 5px"></div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">
                    <h4>ข้อมูลเดิม</h4>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row" runat="server" id="DIV_NAME_THAI" visible="false">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาไทย:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="NAME_THAI" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาไทย:</label>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="NAME_THAI_NEW" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row" runat="server" id="DIV_NAME_ENG" visible="false">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาอังกฤษ:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="NAME_ENG" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาอังกฤษ:</label>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="NAME_ENG_NEW" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row" runat="server" id="DIV_NAME_OTHER" visible="false">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาต่างประเทศอื่น:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="NAME_OTHER" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาต่างประเทศอื่น:</label>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="NAME_OTHER_NEW" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <hr />
        </asp:Panel>