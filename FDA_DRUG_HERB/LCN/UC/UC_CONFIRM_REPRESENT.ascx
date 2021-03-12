<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_CONFIRM_REPRESENT.ascx.vb" Inherits="FDA_DRUG_HERB.UC_CONFIRM_REPRESENT" %>
 <div class="container">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10"><h1 >คำขอใบแทนใบอนุญาต </h1></div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">ข้าพเจ้า</div>
            <div class="col-lg-6" style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lcn_name" runat="server"></asp:Label></div>
            <div class="col-lg-2">(ชื่อผู้รับอนุญาต)</div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">ซึ่งมีผู้มีหน้าที่ปฏิบัติการชื่อ</div>
            <div class="col-lg-6" style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_BSN_THAIFULLNAME" runat="server"></asp:Label></div>
            <div class="col-lg-2">(เฉพาะกรณีนิติบุคคล)</div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2" >เลขประจำตัวประชาชน/ใบอนุญาตทำงานเลขที่</div>
            <div class="col-lg-3" style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_BSN_IDENTIFY" runat="server"></asp:Label></div>
            <div class="col-lg-6"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">ตามใบอนุญาตเลขที่</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="label4" runat="server"></asp:Label></div>
            <div class="col-lg-2">ณ สถานที่ประกอบธุรกิจชื่อ</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_thanameplace" runat="server"></asp:Label></div>
            <div class="col-lg-1"></div> 
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">อยู่เลขที่</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_thaaddr" runat="server"></asp:Label></div>
            <div class="col-lg-2">หมู่บ้าน/อาคาร</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_thabuilding" runat="server"></asp:Label></div>
            <div class="col-lg-1"></div> 
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">หมู่ที่</div>
            <div class="col-lg-1"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_thamu" runat="server"> </asp:Label></div>
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ตรอก/ซอย</div>
            <div class="col-lg-1"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_thasoi" runat="server"></asp:Label></div>
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ถนน</div>            
            <div class="col-lg-1"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_tharoad" runat="server"></asp:Label></div>
            <div class="col-lg-1"></div> 
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">ตำบล/แขวง</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_thathmblnm" runat="server"></asp:Label> </div>
            <div class="col-lg-2">อำเภอ/เขต</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_thaamphrnm" runat="server"></asp:Label> </div>
            <div class="col-lg-1"></div> 
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">จังหวัด</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_thachngwtnm" runat="server"></asp:Label> </div>
            <div class="col-lg-2">รหัสไปรษณีย์</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_zipcode" runat="server"></asp:Label> </div>
            <div class="col-lg-1"></div> 
        </div>
         <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">โทรศัพท์</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="lbl_lct_tel" runat="server"></asp:Label></div>
            <div class="col-lg-2">เวลาทำการ</div>
            <div class="col-lg-3"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:Label ID="label16" runat="server"></asp:Label> </div>
            <div class="col-lg-1"></div> 
         </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4">มีความประสงค์ขอใบแทนใบอนุญาตฯ เนื่องจาก</div>
            <div class="col-lg-4"style="BORDER-BOTTOM: #999999 1px dotted">&nbsp;<asp:label ID="label17" runat="server" Width="72px"></asp:label></div>
            <div class="col-lg-2">(เหตุที่ขอรับใบแทน)</div>
            <div class="col-lg-1"></div>
        </div>
            
            <div class="row">
                  <div class="col-lg-1" ></div> 
                <div class="col-lg-10">ข้าพเจ้าได้แนบหลักฐานมาด้วยคือ</div>
                <div class="col-lg-1" ></div>
            </div>
            <div class="row">
                <div class="col-lg-1" ></div>
                <div class="col-lg-10" >๑. ใบอนุญาตตามพระราชบัญญัติผลิตภัณฑ์สมุนไพร พ.ศ. ๒๕๖๒ (กรณีใบอนุญาตถูกทำลาย หรือ ลบเลือนในสาระสำคัญ)</div>
                <div class="col-lg-1" ></div>

            </div>
            <div class="row">
                <div class="col-lg-1" ></div>
                <div class="col-lg-10" >๒. เอกสารหลักฐานอื่น ๆ (ถ้ามี)</div>
                <div class="col-lg-1" ></div>
            </div>
    </div>