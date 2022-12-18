<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGioHang.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucGioHang" %>
<div>
    <div>
        <div>
            <div><asp:CheckBox Text="Sản phẩm" runat="server" /></div>
            <div>
                <span>Đơn Giá</span>
                <span>Số Lượng</span>
                <span>Số Tiền</span>
                <span>Thao Tác</span>
            </div>
        </div>
        <div>
             <asp:DataList runat="server" ID="dlCuaHang" Width="100%">
                <ItemTemplate>
                    <div class="ThongTin">
                        <div class='center DivCuaHang'>
                            <h1>
                                <asp:CheckBox Text='<%#Eval("TenCuaHang") %>' runat="server" />
                            </h1>
                        </div>
                        <asp:DataList runat="server" ID="dlSanPham">
                            <ItemTemplate>
                                <div class='center DivChiTietDonHang'>
                                    <div class="center">
                                        <asp:CheckBox Text="" runat="server" />
                                        <div>
                                            <img class="AnhSanPham" src='<%#"../../Image/product/"+Eval("HinhAnh") %>'/>
                                        </div>
                                        <div>
                                            <p> 
                                                <span class="TenSanPham"><%#Eval("TenSach") %></span>
                                            </p>   
                                            <p>
                                                <span class='chitiet'><%#Eval("TenTG") %></span>
                                             </p>
                                        </div>
                                        <div class="SoLuong">
                                                <input type="submit" runat="server" value="-" />
                                                <input type="text" name="text" value='<%#Eval("SoLuong") %>' />
                                                <input type="submit" runat="server" value="+" />
                                        </div>
                                         <p class='Gia'>
                                            <span><%#Eval("GiaBia") %>đ</span>
                                            <span><%#Eval("GiaKM") %>đ</span>
                                        </p>
                                        <asp:Button Text="Xóa" runat="server" />
                            </ItemTemplate>
                        </asp:DataList>
                     </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</div>
