<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_CONFIRM_REQUEST.ascx.vb" Inherits="FDA_DRUG_HERB.UC_CONFIRM_REQUEST" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table>
<td rowspan="2" class="container1">
<%--                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>--%>
                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>

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
                                        ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร                     
                                    </label>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-12" style="text-align: center;">
                                    <label>
                                        คำขอใบอนุญาต                    
                                    </label>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="text-align: left">
                                    <center>
                   <asp:RadioButtonList ID="rdl_lcn_type" runat="server" Enabled="False">
                    <asp:ListItem Value="1">ผลิตผลิตภัณฑ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="2">นำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="3">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>
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
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        เวลาทำการรวมของร้าน
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_da_opentime" runat="server"></asp:Label>
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
                                <%-- <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
                 ๑. &ensp;ข้อมูลผู้ขออนุญาต</h4>
                                <table>
                                    <tr>
                                        <td class="auto-style6"></td>
                                        <td class="auto-style7">ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                                        </td>
                                        <td class="auto-style18">
                                            <asp:Label ID="lbl_lcn_name" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style9"></td>
                                        <td class="auto-style18">
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">อายุ </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_ages" runat="server" Text=""></asp:Label>
                                            ปี
                                        </td>
                                        <td class="auto-style5">สัญชาติ&ensp;</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_nation" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">เลขประจำตัวประชาชน </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_iden" runat="server" EnableTheming="True" Width="80%"></asp:Label>
                                        </td>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style19">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">หรือเลขทะเบียนนิติบุคคล</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_iden2" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style19">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">ที่อยู่เลขที่</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_addr" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">ชั้นที่</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_floor" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style14"></td>
                                        <td class="auto-style16">ห้องเลขที่
                                        </td>
                                        <td class="auto-style20">
                                            <asp:Label ID="lbl_lcn_room" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style16">หมู่บ้าน/อาคาร</td>
                                        <td class="auto-style20">
                                            <asp:Label ID="lbl_lcn_building" runat="server" Text=""></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td class="auto-style16">หมู่ที่</td>
                                        <td class="auto-style20">
                                            <asp:Label ID="lbl_lcn_mu" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style4">ตรอก/ซอย</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_soi" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">ถนน </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_road" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">ตำบล/แขวง </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_tambol" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">อำเภอ/เขต</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_amphor" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">จังหวัด</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_changwat" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">รหัสไปรษณีย์</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_zipcode" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">โทรสาร</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">&nbsp;โทรศัพท์ </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_tel" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">E-mail </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">เวลาทำการรวมของร้าน&nbsp;</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_da_opentime" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                &ensp;&ensp;--%>
                            </div>
                            <div>
                                <asp:Panel id="TB_Personal" runat="server">
                                    <div class="row">
                                        <div class="col-lg-1" ></div>
                                        <div class="col-lg-10" colspan="8">
                                            
                                                <h4>กรณีผู้ขออนุญาตเป็นบุคคลต่างด้าว ระบุ</h4>
                                            
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
                                    <%-- <tr>
                   <td class="auto-style3"></td>
                   <td>

                       &nbsp;ที่อยู่ที่สามารถติดต่อได้ &nbsp;<asp:CheckBox ID="cb_addr" runat="server" AutoPostBack="True" />
           <label for="vehicle1"> </label></td>
                   <td>

                       (ใช้ที่อยู่เดียวกันกับที่อยู่ตามทะเบียนบ้าน)</td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td colspan="4">

                       (เฉพาะที่อยู่ไม่ใช้ที่อยู่เดียวกันกับทะเบียนบ้าน)</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       อยู่เลขที่</td>
                   <td>
                       <asp:TextBox ID="txt_c_thaaddr" runat="server" AutoPostBack="True"></asp:TextBox>
                   </td>
                   <td>ชั้นที่</td>
                   <td>
                       <asp:TextBox ID="txt_c_floor" runat="server" AutoPostBack="True"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td></td>
                   <td>ห้องเลขที่</td>
                    <td>
                       <asp:TextBox ID="txt_c_room" runat="server" AutoPostBack="True"></asp:TextBox>
                   </td>
                   <td>

           หมู่บ้าน/อาคาร</td>
                   <td>

                       <asp:TextBox ID="txt_c_thabuilding" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   
                   <td>

                       หมู่ที่</td>
                   <td>

                       <asp:TextBox ID="txt_c_thamu" runat="server"></asp:TextBox>
                   </td>
                    <td>

           ตรอก/ซอย</td>
                   <td>

                       <asp:TextBox ID="txt_c_thasoi" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   
                   <td>

           ถนน</td>
                   <td>

                       <asp:TextBox ID="txt_c_tharoad" runat="server"></asp:TextBox>
                   </td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       ตำบล/แขวง</td>
                   <td>

            <asp:DropDownList ID="ddl_tambol" runat="server" AutoPostBack="True" DataTextField="thathmblnm" DataValueField="thmblcd">
            </asp:DropDownList>
                   </td>
                    <td>

           อำเภอ/เขต</td>
                   <td>

            <asp:DropDownList ID="ddl_amphor" runat="server" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
            </asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       จังหวัด</td>
                   <td>

            <asp:DropDownList ID="ddl_Province" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd"></asp:DropDownList>
                   </td>
                    <td>

           รหัสไปรษณีย์</td>
                   <td>

                       <asp:TextBox ID="txt_c_zipcode" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

           โทรสาร</td>
                   <td>

                       <asp:TextBox ID="txt_c_fax" runat="server"></asp:TextBox>
                   </td>
                    <td>

                        โทรศัพท์</td>
                   <td>

                       <asp:TextBox ID="txt_c_tel" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

           E-mail</td>
                   <td>

                       <asp:TextBox ID="txt_c_email" runat="server"></asp:TextBox>
                   </td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>--%>
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
               ๓. &ensp;ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h4>
                                &ensp;

           <div>
               <div class="row">
                   
                       <div class="col-lg-1" class="auto-style3"></div>
                       <div class="col-lg-2"><b>สถานที่ประกอบธุรกิจชื่อ</b></div>
                       <div class="col-lg-3">
                           <asp:Label ID="lbl_lct_thanameplace" runat="server" Text=""></asp:Label>
                       </div>
                       <div class="col-lg-6"></div>
                   
               </div>
               <div class="row">
                   
                       <div class="col-lg-1" class="auto-style3"></div>
                       <div class="col-lg-2">เลขรหัสประจำบ้าน</div>
                       <div class="col-lg-3">
                           <asp:Label ID="lbl_lct_HOUSENO" runat="server" Text=""></asp:Label>
                       </div>
                       <div class="col-lg-6"></div>
                   
               </div>
               <div class="row">
                   
                       <div class="col-lg-1" class="auto-style3"></div>
                       <div class="col-lg-2">อยู่เลขที่</div>
                       <div class="col-lg-3">
                           <asp:Label ID="lbl_lct_thaaddr" runat="server" Text=""></asp:Label>
                       </div>
                       <div class="col-lg-2">หมู่บ้าน/อาคาร</div>
                       <div class="col-lg-3">
                           <asp:Label ID="lbl_lct_thabuilding" runat="server" Text=""></asp:Label>
                       </div>
                   <div class="col-lg-1"></div>
                   
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">หมู่ที่</div>
                   <div class="col-lg-3">
                       <asp:Label ID="lbl_lct_thamu" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="col-lg-2">ตรอก/ซอย</div>
                   <div class="col-lg-3">
                       <asp:Label ID="lbl_lct_thasoi" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">&nbsp;ถนน</div>
                   <div class="col-lg-3">
                       <asp:Label ID="lbl_lct_tharoad" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="col-lg-6"d>&nbsp;</div>
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">ตำบล/แขวง</div>
                   <div class="col-lg-3">
                       <asp:Label ID="lbl_lct_thathmblnm" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="col-lg-2">&nbsp;อำเภอ/เขต</div>
                   <div class="col-lg-3">
                       <asp:Label ID="lbl_lct_thaamphrnm" runat="server" Text=""></asp:Label></div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">จังหวัด</div>
                   <div class="col-lg-3">
                       <asp:Label ID="lbl_lct_thachngwtnm" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="col-lg-2">รหัสไปรษณีย์</div>
                   <div class="col-lg-3">
                       <asp:Label ID="lbl_lct_zipcode" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">โทรสาร</div>
                   <div class="col-lg-3">
                       <asp:Label ID="lbl_lct_fax" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="col-lg-2">โทรศัพท์</div>
                   <div class="col-lg-3">
                       <asp:Label ID="lbl_lct_tel" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1" class="auto-style3"></div>
                   <div class="col-lg-2">E-mail</div>
                   <div class="col-lg-3">
                       <asp:Label ID="Label59" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="col-lg-6">&nbsp;</div>
               </div>
           </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10"> 
                                        <h3>สถานที่เก็บ</h3>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row"> 
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                <telerik:RadGrid ID="RadGrid2" runat="server">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>

                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>

                    <Columns>
                        <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid"
                            SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="rcvno" DataType="System.Int32" FilterControlAltText="Filter rcvno column"
                            HeaderText="เลขรับ" SortExpression="rcvno" UniqueName="rcvno">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="rcvdate" DataFormatString="{0:d}" DataType="System.DateTime" FilterControlAltText="Filter rcvdate column" HeaderText="วันที่รับ" SortExpression="rcvdate" UniqueName="rcvdate">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                            HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="TranscestionID" SortExpression="XMLNAME" UniqueName="XMLNAME">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                            HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                            HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                            HeaderText="TR_ID" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column"
                            HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CITIZEN_ID" FilterControlAltText="Filter CITIZEN_ID column" HeaderText="CITIZEN_ID"
                            SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CITIZEN_ID_UPLOAD" FilterControlAltText="Filter CITIZEN_ID_UPLOAD column"
                            HeaderText="CITIZEN_ID_UPLOAD" SortExpression="CITIZEN_ID_UPLOAD" UniqueName="CITIZEN_ID_UPLOAD" Display="false">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="lctcd" DataType="System.Int32" FilterControlAltText="Filter lctcd column" HeaderText="lctcd"
                            SortExpression="lctcd" UniqueName="lctcd" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_del"
                            CommandName="_del" Text="ลบ" ConfirmText="ยืนยันการลบข้อมูล">

                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>

                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>

                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10"> 
                                        <h3>รายชื่อผู้ปฏิบัติหน้าที่</h3>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                                
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <telerik:RadGrid ID="rgphr" runat="server" Width="90%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="PHR_IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>

                        <telerik:GridBoundColumn DataField="PHR_IDA" FilterControlAltText="Filter PHR_IDA column"
                            HeaderText="PHR_IDA" SortExpression="PHR_IDA" UniqueName="PHR_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PHR_CTZNO" FilterControlAltText="Filter PHR_CTZNO column"
                            HeaderText="เลขบัตรปชช." SortExpression="PHR_CTZNO" UniqueName="PHR_CTZNO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PHR_FULLNAME" FilterControlAltText="Filter PHR_FULLNAME column"
                            HeaderText="ชื่อผู้มีหน้าที่ปฏิบัติการ" SortExpression="PHR_FULLNAME" UniqueName="PHR_FULLNAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PHR_TEXT_WORK_TIME" FilterControlAltText="Filter PHR_TEXT_WORK_TIME column"
                            HeaderText="เวลาทำการ" SortExpression="PHR_TEXT_WORK_TIME" UniqueName="PHR_TEXT_WORK_TIME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STUDY_LEVEL" FilterControlAltText="Filter STUDY_LEVEL column"
                            HeaderText="คุณวุฒิ" SortExpression="STUDY_LEVEL" UniqueName="STUDY_LEVEL">
                        </telerik:GridBoundColumn>
<%--                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt"
                            CommandName="edt" Text="แก้ไข">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>--%>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                            CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="ยืนยันการลบ">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
                                    </div>
                                    <div class="col-lg-1">
                                </div>
                               
                            </div>
                        </form>
                    </asp:Panel>

                </div>
            </td>

</table>