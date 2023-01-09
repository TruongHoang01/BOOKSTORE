<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDatHang.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucDatHang" %>
<div class="GioHang dathang">
    <div class="danhsach_sc width90">
        <div class="divflex divheader">
            <div class="checkbox">Sản phẩm</div>
            <div class="title">
                <span>Đơn Giá</span>
                <span>Số Lượng</span>
                <span>Thành Tiền</span>
            </div>
        </div>
        <div>
            <asp:DataList runat="server" ID="dlCuaHang" Width="100%">
                <ItemTemplate>
                    <div class="ThongTin divThongTin">
                        <div class='center DivCuaHang'>
                            <h1 class="checkbox">
                                <asp:Label Text='<%#Eval("TenCuaHang") %>' runat="server" />
                            </h1>
                        </div>
                        <asp:DataList runat="server" ID="dlSanPham" Width="100%">
                            <ItemTemplate>
                                <div class='center DivChiTietDonHang'>
                                    <div class=" divflex divchitiet">
                                        <div class="center checkbox">
                                            <div>
                                                <img class="AnhSanPham" src='<%#"../../Image/product/"+Eval("HinhAnh") %>' />
                                            </div>
                                            <div>
                                                <p style="max-width: 300px">
                                                    <span class="TenSanPham"><%#Eval("TenSach") %></span>
                                                </p>
                                                <p>
                                                    <span class='chitiet'><%#Eval("TenTG") %></span>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="center right">
                                            <div class=" column Gia">
                                                <span class="giagoc"><%#Eval("GiaBia") %>đ</span>
                                                <span class="giakm"><%#Eval("GiaKM") %>đ</span>
                                            </div>
                                            <div class="column SoLuong">
                                                <asp:Label ID="tbsoluong" Text='<%#Eval("SoLuong")%>' runat="server" />
                                            </div>
                                            <div class=" column Gia giakm"><span><%#Eval("ThanhTien") %>đ</span></div>
                                        </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <div class="center">
                            <div class="width50">  <asp:TextBox CssClass="textghichu" runat="server" PlaceHolder="Ghi chú cho người bán..." TextMode="MultiLine"/></div>
                            <div class="width50 TextRight ">Tổng tiền đơn hàng: <asp:Label ForeColor="Red" Font-Size="14" Font-Bold="true"   Text="120000đ" runat="server" /></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="footergh width40">
        <div class="thanhtoan">
            <p style="display:block">Thông tin người nhận</p>
            <div>
                <asp:TextBox runat="server" PlaceHolder="Họ và tên người nhận" />
            </div>
            <div>
                <asp:TextBox runat="server" PlaceHolder="Số điện thoại người nhận" />
            </div>
            <div>
                <asp:TextBox runat="server" PlaceHolder="Địa chỉ nhận hàng..." TextMode="MultiLine"/>
            </div>
           
        </div>
         <div class="btn-mua">
             <asp:Label Text="" ID="lbThongBao" runat="server" />
                <asp:Button Text="Đặt hàng" runat="server" />
            </div>
    </div>
</div>
