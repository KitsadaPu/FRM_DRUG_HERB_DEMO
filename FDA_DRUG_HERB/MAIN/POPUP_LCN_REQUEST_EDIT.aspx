<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_REQUEST_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_REQUEST_EDIT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/LCN_STAFF/UC/UC_LCN_HERB.ascx" TagPrefix="uc1" TagName="UC_LCN_HERB" %>
<%@ Register Src="~/LCN_STAFF/UC/UC_LCN_HERB_PHESAJ.ascx" TagPrefix="uc1" TagName="UC_LCN_HERB_PHESAJ" %>









<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 100%; height: 500px;" >
        <tr>
            <td rowspan="2" class="container1">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>

                <style type="text/css">
                    .auto-style17 {
                        position: relative;
                        min-height: 1px;
                        float: left;
                        width: 25%;
                        left: 0px;
                        top: 0px;
                        padding-left: 7px;
                        padding-right: 7px;
                    }
                </style>

                <div style="border: groove; border-color: gainsboro;">
                    <asp:Panel ID="Panel1" runat="server">
                        <form name="form" method="post" align="center;" id="smp1">

                            <div class="row">
                                <div class="col-lg-12" style="text-align: center;">
                                    <h1>คำขอแก้ไขใบอนูญาต
                                    </h1>
                                </div>
                            </div>
                  <div style="display:none;">
                            <div class="row">
                                <div class="col-lg-12" style="text-align: center;">
                                    <label>
                                        ผลิต นำเข้า หรือขายผลิตภัณฆ์สมุนไพร                     
                                    </label>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-12" style="text-align: center;">
                                    <label>
                                        คำขอแก้ไขใบอนุญาต                    
                                    </label>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="text-align: left">
                                    <center>
                   <asp:RadioButtonList ID="rdl_lcn_type" runat="server" Enabled="False">
                    <asp:ListItem Value="1">ผลิตผลิตภัณฆ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="2">นำเข้าผลิตภัณฆ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="3">ขายผลิตภัณฆ์สมุนไพร</asp:ListItem>
                </asp:RadioButtonList></center>
                                </div>

                            </div>
                            </div>
                            <br />
                            <div>
                                <center>  
            <table>
                <tr>
                <td>
                    เลือก &ensp;&ensp;
                </td>
                <td>
                
               <asp:RadioButtonList ID="rdl_sanchaat" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Enabled="False" >
                        <asp:ListItem Value="1">&ensp;ไทย&ensp;</asp:ListItem>
                        <asp:ListItem Value="2">&ensp;ต่างด้าว&ensp;</asp:ListItem>
                    </asp:RadioButtonList> 
               
              
                </td>
             </tr>
            </table>                                       
            </center>

                            </div>
                            <br />
                            <div>
                                <div class="row">
                                    <div class="col-lg-1 col-mg-1"></div>
                                    <div class="col-lg-3 col-mg-3">
                                        ๑. &ensp;ข้อมูลผู้ขออนุญาต
                                    </div>
                                    <div class="col-lg-8 col-mg-8">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1">
                                    </div>
                                    <div class="col-lg-3" style="text-align: left">
                                        ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                                    </div>
                                    <div class="col-lg-6" style="text-align: left">
                                        <asp:Label ID="lbl_lcn_name" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2" style="text-align: left">
                                        อายุ 
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_ages" runat="server" Text=""></asp:Label>
                                        ปี
                                    </div>
                                    <div class="col-lg-2">สัญชาติ</div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcn_nation" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-3">
                                        เลขประจำตัวประชาชน หรือเลขทะเบียนนิติบุคคล
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lbl_lcn_iden" runat="server" EnableTheming="True" Width="80%"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        ที่อยู่เลขที่
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_addr" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        ชั้นที่
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_floor" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        ห้องเลขที่
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_room" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        หมู่บ้าน/อาคาร
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_building" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        หมู่ที่
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_mu" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        ตรอก/ซอย
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_soi" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        ถนน
                                    </div>
                                    <div class="col-lg-7" style="text-align: left">
                                        <asp:Label ID="lbl_lcn_road" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        ตำบล/แขวง
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_tambol" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        อำเภอ/เขต
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcn_amphor" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        จังหวัด
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_changwat" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        รหัสไปรษณีย์
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcn_zipcode" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        โทรสาร
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        โทรศัพท์
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcn_tel" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        E-mail
                                    </div>
                                    <div class="auto-style17">
                                        <asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        เวลาทำการรวมของร้าน
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:textbox ID="lbl_da_opentime" runat="server"></asp:textbox>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-3">
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div>

                            </div>
                            <div>
                                <asp:Panel id="TB_Personal" runat="server">
                                    <div class="row">
                                        <div class="col-lg-1" ></div>
                                        <div class="col-lg-10" colspan="8">
                                            
                                                <h4>กรณีผู้ขออนนุญาตเป็นบุคคลต่างด้าว ระบุ</h4>
                                            
                                        </div>
                                        <div class="col-lg-1" ></div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="TB_Personal_Type1" runat="server">
                                    <div runat="server">


                                        <div class="row">
                                            <div class="col-lg-1"  ></div>
                                            <div class="col-lg-10" >
                                                <asp:CheckBox ID="cb_Personal_Type1" Text="บุคคลธรรมดา " runat="server" Enabled="False" />
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1" ></div>
                                            <div class="col-lg-2" >หนังสือเดินทางเลขที่</div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="lbl_PASSPORT_NO" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">วันหมดอายุ</div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="lbl_PASSPORT_EXPDATE" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1" ></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1" ></div>
                                            <div class="col-lg-2" >ใบสำคัญที่อยู่เลขที่</div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="lbl_DOC_NO" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-lg-2" >ออกให้ ณ วันที่</div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="lbl_DOC_DATE" runat="server" Text=""></asp:Label>
                                            </div><div class="col-lg-1" ></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1" ></div>
                                            <div class="col-lg-2" >ใบอนุญาตทำงานเลขที่</div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="lbl_WORK_LICENSE_NO" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-lg-2" >วันหมดอายุ</div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="lbl_WORK_LICENSE_EXPDATE" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1" ></div>
                                            <div class="col-lg-10">หรือใบอนุญาาตประกอบธุรกิจตามบัญชีสาม(๑๖)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</div>
                                            <div class="col-lg-1" ></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1" ></div>
                                            <div class="col-lg-2" >เลขที่</div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="lbl_BS_NO" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-lg-2" >ออกให้ ณ วันที่</div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="lbl_BS_DATE" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1" ></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1" ></div>
                                            <div class="col-lg-5" colspan="2">หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</div>
                                            <div class="col-lg-3" >
                                                <asp:Label ID="lbl_FRGN_NO" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-lg-3" ></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1" ></div>
                                            <div class="col-lg-2" >ออกให้ ณ วันที่</div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="lbl_FRGN_DATE" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-6" >&nbsp;</div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="TB_Personal_Type2" runat="server">
                                    <div runat="server">
                                        <div class="row">
                                            <div class="col-lg-1" ></div>
                                            <div class="col-lg-10">
                                                <asp:CheckBox ID="cb_Personal_Type2" Text="นิติบุคคลต่างด้าว " runat="server" Enabled="False" />
                                            </div>
                                            <div class="col-lg-1" ></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"  ></div>
                                            <div class="col-lg-8"  >ใบอนุญาตประกอบธุรกิจตามบัญชีสาม(๑๔)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</div>
                                            <div class="col-lg-3" ></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"  ></div>
                                            <div class="col-lg-2" >เลขที่</div>
                                            <div class="col-lg-3" >
                                                <asp:Label ID="lbl_BS_NO1" runat="server" Style="margin-bottom: 0px"></asp:Label>
                                            </div>
                                            <div class="col-lg-2" >ออกให้ ณ วันที่</div>
                                            <div class="col-lg-3" >
                                                <asp:Label ID="lbl_BS_DATE1" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1" ></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"  ></div>
                                            <div class="col-lg-5"  colspan="2">หนังสือรับรองตาามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</div>
                                            <div class="col-lg-3" >
                                                <asp:Label ID="lbl_FRGN_NO1" runat="server"></asp:Label></div>
                                            <div class="col-lg-3" ></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"  ></div>
                                            <div class="col-lg-2" >ออกให้ ณ วันที่</div>
                                            <div class="col-lg-3" >
                                                <asp:Label ID="lbl_FRGN_DATE1" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-6" >&nbsp;</div>
                                        
                                        </div>
                                    </div>
                                </asp:Panel>


                            </div>
                            <div>
                                <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
               ๒. &ensp;ข้อมูลผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการหรือดำเนนินกิจการเกี่ยวกับใบอนุญาต</h4>
                                <div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">ชื่อผู้ดำเนินการ</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_BSN_THAIFULLNAME" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div class="col-lg-6"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1" class="auto-style3"></div>
                                        <div class="col-lg-2">อายุ</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_BSN_AGE" runat="server" Text=""></asp:Label>
                                            ปี </div>
                                        <div class="col-lg-2">สัญชาติ</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="Label20" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1" class="auto-style3"></div>
                                        <div class="col-lg-2">เลขประจำตัวประชาชน</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_BSN_IDENTIFY" runat="server" Text=""></asp:Label></div>
                                        <div class="col-lg-6">&nbsp;</div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1" class="auto-style3"></div>
                                        <div class="col-lg-2">ที่อยู่ตามทะเบียนบ้าน อยู่เลขที่</div>
                                        <div class="col-lg-3">
                                            <asp:Label ID="lbl_c_thaaddr" runat="server" AutoPostBack="True"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">ชั้นที่</div>
                                        <div class="col-lg-3">
                                            <asp:Label ID="lbl_c_floor" runat="server" AutoPostBack="True"></asp:Label>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">ห้องเลขที่</div>
                                        <div class="col-lg-3">
                                            <asp:Label ID="lbl_c_room" runat="server" AutoPostBack="True"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">หมู่บ้าน/อาคาร</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_c_thabuilding" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1" class="auto-style3"></div>

                                        <div class="col-lg-2">หมู่ที่</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_c_thamu" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">ตรอก/ซอย</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_c_thasoi" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1" class="auto-style3"></div>

                                        <div class="col-lg-2">ถนน</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_c_tharoad" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-6">&nbsp;</div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1" class="auto-style3"></div>
                                        <div class="col-lg-2">ตำบล/แขวง</div>
                                        <div class="col-lg-3">
                                            <asp:Label ID="lbl_tambol" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">อำเภอ/เขต</div>
                                        <div class="col-lg-3">
                                            <asp:Label ID="lbl_amphor" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1" class="auto-style3"></div>
                                        <div class="col-lg-2">จังหวัด</div>
                                        <div class="col-lg-3">
                                            <asp:Label ID="lbl_Province" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">รหัสไปรษณีย์</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_c_zipcode" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1" class="auto-style3"></div>
                                        <div class="col-lg-2">โทรสาร</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_c_fax" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">โทรศัพท์</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_c_tel" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1" class="auto-style3"></div>
                                        <div class="col-lg-2">E-mail</div>
                                        <div class="col-lg-3">

                                            <asp:Label ID="lbl_c_email" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-6">&nbsp;</div>
                                    </div>

                                </div>


                            </div>
                            <div>
                                <h4>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;
               กรณีผู้ได้รับมอบหมายหรือแต่งตั้งให้กำหนดกิจการเป็นบุคคลต่างด้าว ระบุ</h4>
                                &ensp;
           <div>
               <div >
                   <div class="row">
                       <div class="col-lg-1" class="auto-style12"></div>
                       <div class="col-lg-2" class="auto-style13">หนังสือเดินทางเลขที่ </div>
                       <div class="col-lg-3" class="auto-style13">
                           <asp:Label ID="lbl_GIVE_PASSPORT_NO" runat="server"></asp:Label>
                       </div>
                       <div class="col-lg-2" class="auto-style13">วันหมดอายุ </div>
                       <div class="col-lg-3" class="auto-style13"> 
                           <asp:Label ID="lbl_GIVE_PASSPORT_EXPDATE" runat="server"></asp:Label>
                       </div>
                       <div class="col-lg-1"></div>
                   </div>
               </div>
               <div >
                   <div class="row">
                       <div class="col-lg-1" class="auto-style12"></div>
                       <div class="col-lg-2" class="auto-style13">ใบอนุญาตทำงานเลขที่ </div>

                       <div class="col-lg-3" class="auto-style13">
                           <asp:Label ID="lbl_GIVE_WORK_LICENSE_NO" runat="server"></asp:Label>
                       </div>
                       <div class="col-lg-2" class="auto-style13">วันหมดอายุ </div>
                       <div class="col-lg-3" class="auto-style13">
                           <asp:Label ID="lbl_GIVE_WORK_LICENSE_EXPDATE" runat="server"></asp:Label>
                       </div>
                       <div class="col-lg-1"></div>
                   </div>
               </div>
           </div>


                                <br />
                                &ensp;
          
           
                            </div>
                            <div>
                                <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
               ๓. &ensp;ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฆ์สมุนไพร</h4>
                                &ensp;

           <div>
               <div class="row">
                   
                       <div class="col-lg-1" class="auto-style3"></div>
                       <div class="col-lg-2"><b>สถานที่ประกอบธุรกิจชื่อ</b></div>
                       <div class="col-lg-3">
                           <asp:textbox ID="lbl_lct_thanameplace" runat="server" Text=""></asp:textbox>
                       </div>
                       <div class="col-lg-6"></div>
                   
               </div>
               <div class="row">
                   
                       <div class="col-lg-1" class="auto-style3"></div>
                       <div class="col-lg-2">เลขรหัสประจำบ้าน</div>
                       <div class="col-lg-3">
                           <asp:textbox ID="lbl_lct_HOUSENO" runat="server" Text=""></asp:textbox>
                       </div>
                       <div class="col-lg-6"></div>
                   
               </div>
               <div class="row">
                   
                       <div class="col-lg-1" class="auto-style3"></div>
                       <div class="col-lg-2">อยู่เลขที่</div>
                       <div class="col-lg-3">
                           <asp:textbox ID="lbl_lct_thaaddr" runat="server" Text=""></asp:textbox>
                       </div>
                       <div class="col-lg-2">หมู่บ้าน/อาคาร</div>
                       <div class="col-lg-3">
                           <asp:textbox ID="lbl_lct_thabuilding" runat="server" Text=""></asp:textbox>
                       </div>
                   <div class="col-lg-1"></div>
                   
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">หมู่ที่</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="lbl_lct_thamu" runat="server" Text=""></asp:textbox>
                   </div>
                   <div class="col-lg-2">ตรอก/ซอย</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="lbl_lct_thasoi" runat="server" Text=""></asp:textbox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">&nbsp;ถนน</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="lbl_lct_tharoad" runat="server" Text=""></asp:textbox>
                   </div>
                   <div class="col-lg-6"d>&nbsp;</div>
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">ตำบล/แขวง</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="lbl_lct_thathmblnm" runat="server" Text=""></asp:textbox>
                   </div>
                   <div class="col-lg-2">&nbsp;อำเภอ/เขต</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="lbl_lct_thaamphrnm" runat="server" Text=""></asp:textbox></div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">จังหวัด</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="lbl_lct_thachngwtnm" runat="server" Text=""></asp:textbox>
                   </div>
                   <div class="col-lg-2">รหัสไปรษณีย์</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="lbl_lct_zipcode" runat="server" Text=""></asp:textbox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">โทรสาร</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="lbl_lct_fax" runat="server" Text=""></asp:textbox>
                   </div>
                   <div class="col-lg-2">โทรศัพท์</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="lbl_lct_tel" runat="server" Text=""></asp:textbox>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">E-mail</div>
                   <div class="col-lg-3">
                       <asp:textbox ID="Label59" runat="server" Text=""></asp:textbox>
                   </div>
                   <div class="col-lg-6">&nbsp;</div>
               </div>
           </div>
                                <div class="row"> 
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">

                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                    </div>
                            
                                <uc1:UC_LCN_HERB runat="server" ID="UC_LCN_HERB" />
                                <uc1:UC_LCN_HERB_PHESAJ runat="server" ID="UC_LCN_HERB_PHESAJ" />
                            
                        </form>

                    </asp:Panel>

                    <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
                </div>
            </td>

        </tr>
        <tr>
            <td style="width: 30%; height: 50%; padding-left: 10%">

                <%--<uc1:uc_grid_attach runat="server" ID="UC_GRID_ATTACH" />--%>

                <br />
                <%--<uc2:uc_grid_pharmacist ID="UC_GRID_PHARMACIST" runat="server" />--%>

            </td>
        </tr>
    </table>

    <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg " Width="120px" OnClientClick="confirm('คุณต้องการบันทึกหรือไม่');" />

            <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
</asp:Content>
