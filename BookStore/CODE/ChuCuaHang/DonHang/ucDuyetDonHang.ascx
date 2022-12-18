<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDuyetDonHang.ascx.cs" Inherits="BookStore.CODE.ChuCuaHang.DonHang.ucDuyetDonHang" %>

<div class="containerdonhang">
    <div class="divdonhangphai">
        <div class="divthanhden"></div>
        <div>
            <div class="titlechitiet">THÔNG TIN CHI TIẾT ĐƠN HÀNG</div>
            <div>
                <asp:GridView ID="grThongTinDonHang" CssClass="kbhtable" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText ="Họ Tên" DataField="HoTen" ItemStyle-CssClass="col15"/>
                          <asp:BoundField HeaderText ="Số Điện Thoại" DataField="SDT" ItemStyle-CssClass="col10 TextRight"/>
                          <asp:BoundField HeaderText ="Địa Chỉ" DataField="DiaChi" ItemStyle-CssClass="col30"/>
                          <asp:BoundField HeaderText ="Ngày Tạo" DataField="NgayTao" ItemStyle-CssClass="col10 TextRight"/>
                         <asp:BoundField HeaderText ="Ghi chú" DataField="GhiChu" ItemStyle-CssClass="col30 TextRight"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div  class="mt20">
                <asp:GridView ID="grChiTietDonHang" CssClass="kbhtable" runat="server" AutoGenerateColumns="false" ShowFooter="true">
                    <Columns>
                        <asp:BoundField HeaderText ="Tên sách" DataField="TenSach" ItemStyle-CssClass="col30"/>
                        <asp:TemplateField HeaderText ="Hình ảnh" ItemStyle-CssClass="col15 TextCenter">
                            <ItemTemplate>
                                <asp:Image Width="70" Height="70" ImageUrl='<%#"../../../Image/"+Eval("HinhAnh") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:BoundField HeaderText ="Giá bán" DataField="GiaBan" ItemStyle-CssClass="col10 TextRight"/>
                          <asp:BoundField HeaderText ="Số lượng" DataField="SoLuong" ItemStyle-CssClass="col10 TextCenter"/>
                          <asp:BoundField HeaderText ="Thành tiền" DataField="ThanhTien" ItemStyle-CssClass="col10 TextRight"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="btnchitiethoadon">
                <asp:LinkButton ID="btnDuyet" OnClick="btnDuyet_Click" Text="Duyệt" runat="server" />
                <asp:LinkButton ID="btnHuy" OnClick="btnHuy_Click"  Text="Hủy" runat="server" />
                <asp:LinkButton ID="btnQuayLai" OnClick="btnQuayLai_Click" Text="Quay lại" runat="server" />
                <div>
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
