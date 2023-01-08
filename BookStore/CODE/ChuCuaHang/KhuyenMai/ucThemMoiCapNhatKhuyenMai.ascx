<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThemMoiCapNhatKhuyenMai.ascx.cs" Inherits="BookStore.CODE.ChuCuaHang.KhuyenMai.ucThemMoiCapNhatKhuyenMai" %>


<div class="containerdonhang">
    <div class="divdonhangphai">
        <div class="divthanhden"></div>
        <div class="divthemmoi">
            <div class="divtitle">
                <asp:Label ID="lbtitle" Text="THÊM MỚI KHUYẾN MÃI" runat="server" />
            </div>
            <div class="divflex">
                <div class="divflexcon">
                    <div class="rowthemmoi">
                        <span>Nội dung: </span>
                        <asp:TextBox ID="tbNoiDung" runat="server" />
                    </div>
                    <div class="rowthemmoi">
                        <span>Tỷ lệ KM: </span>
                        <asp:TextBox ID="tbTiLe" runat="server" />
                    </div>
                    <div class="rowthemmoi">
                        <span>Từ ngày: </span>
                        <asp:TextBox ID="from_date" runat="server" Enabled="false" />
                        <asp:ImageButton ID="btn_fromdate" ImageUrl="../../../Image/calendar.png" runat="server"/>
                        <asp:ScriptManager runat="server" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                            TargetControlID="from_date" PopupButtonID="btn_fromdate" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                    <div class="rowthemmoi">
                        <span>Đến ngày ngày: </span>
                        <asp:TextBox ID="end_date" runat="server" Enabled="false" />
                        <asp:ImageButton ID="end_datebtn" ImageUrl="../../../Image/calendar.png" runat="server"/>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
                            TargetControlID="end_date" PopupButtonID="end_datebtn" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </div>                   
                    <div class="linkbutton ">
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server"></asp:CheckBoxList>
                    </div>
                    <div class="linkbutton">
                        <asp:LinkButton ID="btnThemMoi" OnClick="btnThemMoi_Click" Text="Thêm mới" runat="server" />
                        <asp:LinkButton ID="btnDatLai" OnClick="btnDatLai_Click" Text="Đặt lại" runat="server" />
                    </div>
                </div>
                <div class="divflexcon">
                    <div class="divsanphamkhuyenmai">Chọn sản phẩm khuyến mãi</div>
                    <asp:CheckBoxList ID="cblSanPham" runat="server"></asp:CheckBoxList>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="ThongBao" visible="false"  id="ThongBao" runat="server">
        <div class="divflex  flexThongBao">
            <div>
                <asp:Image ID="imgThongBao" Width="60" Height="60" runat="server" />
            </div>
            <div class="content">
                <div>
                    <p class="chuDeThongBao" id="chuDeThongBao" runat="server"></p>
                    <p id="noiDungThongBao" runat="server"></p>
                </div>
            </div>
        </div>
        <div class="btnOK">
            <asp:LinkButton OnClick="btnOK_Click" ID="btnOK" Text="OK" runat="server" />
        </div>
</div>

