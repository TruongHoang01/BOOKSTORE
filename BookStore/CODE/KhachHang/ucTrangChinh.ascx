<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTrangChinh.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucTranhChinh" %>
<section class="section-hero">
    <div class="container">
        <div class="hero-data-carousel swiper">
            <ul class="hero-data-slides swiper-wrapper">
                <li class="hero-slide swiper-slide">
                <img
                    src="https://bookbuy.vn/Res/Images/Album/38149fbe-50de-4ad6-99c8-6fdb31ea0cc7.jpg?w=880&scale=both&h=320&mode=crop"
                    alt="slide-1"
                />
                </li>
                <li class="hero-slide swiper-slide">
                <img
                    src="https://bookbuy.vn/Res/Images/Album/c0acff21-9904-4b75-8795-11af133aed4e.jpg?w=880&scale=both&h=320&mode=crop"
                    alt="slide-2"
                />
                </li>

                <li class="hero-slide swiper-slide">
                <img
                    src="https://bookbuy.vn/Res/Images/Album/56bfc3d9-179f-4c91-9c7a-1b2aa9c00d2d.jpg?w=880&scale=both&h=320&mode=crop"
                    alt="slide-3"
                />
                </li>
            </ul>
            <button class="swiper-button-prev"></button>
            <button class="swiper-button-next"></button>
            <div class="swiper-pagination"></div>
        </div>
    </div>
</section>
<div class="giaodiensanpham">
    <div>
        <div class="tendanhmuc">SÁCH GIẢM GIÁ</div>
        <asp:DataList CssClass="tbsanpham" ID="dlGiamGia" runat="server" RepeatColumns="4">
            <ItemTemplate>
                 <div class="itemsp">
                    <div class="itemsp-img">
                        <asp:ImageButton CommandArgument='<%#Eval("IDSP") %>' ID="imgHinhAnhSP" OnClick="imgHinhAnhSP_Click" ImageUrl='<%#"../../Image/product/"+Eval("HinhAnh") %>' runat="server" />
                    </div>
                     <asp:Label  CssClass="itemsp-ten" Text='<%#Eval("TenSach") %>' runat="server" />
                     <asp:Label CssClass="itemsp-tacgia"  Text='<%#Eval("TenTG") %>' runat="server" />
                    <div class="TextCenter">
                        <asp:Label CssClass="itemsp-gia itemsp-giakm" Text='<%#Eval("GiaBan") +"đ" %>' runat="server" />
                        <asp:Label ID="lbGiaBia" CssClass="itemsp-gia itemsp-gianiemyet" Text='<%#Eval("GiaBia") +"đ" %>' runat="server" />
                    </div>
                    <div class="TextCenter">
                        <asp:LinkButton CommandArgument='<%#Eval("IDSP") %>' ID="linkTenSP" OnClick="linkTenSP_Click" CssClass="itemsp-btngiohang" Text="THÊM VÀO GIỎ HÀNG" runat="server" />
                    </div>
                     <asp:Label CssClass="itemsp-khuyenmai" Text='<%#"-"+Eval("TiLe")+"%" %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div class="divxemtatca">
            <a class="btnxemtatca" href="#">Xem tất cả</a>
        </div>
        <div class="relative">
              <hr class="hr"/>
        </div>
    </div>

      <div>
        <div class="tendanhmuc">SÁCH BÁN CHẠY</div>
        <asp:DataList ID="dlBanChay" runat="server" RepeatColumns="4">
            <ItemTemplate>
                 <div class="itemsp">
                    <div class="itemsp-img">
                        <asp:ImageButton CommandArgument='<%#Eval("IDSP") %>' OnClick="imgHinhAnhSP_Click" ImageUrl='<%#"../../Image/product/"+Eval("HinhAnh") %>' runat="server" />
                    </div>
                     <asp:Label  CssClass="itemsp-ten" Text='<%#Eval("TenSach") %>' runat="server" />
                     <asp:Label CssClass="itemsp-tacgia"  Text='<%#Eval("TenTG") %>' runat="server" />
                    <div class="TextCenter">
                        <asp:Label CssClass="itemsp-gia itemsp-giakm" Text='<%#Eval("GiaBan") +"đ" %>' runat="server" />
                        <asp:Label ID="lbGiaBia" CssClass="itemsp-gia itemsp-gianiemyet" Text='<%#Eval("GiaBia") +"đ" %>' runat="server" />
                    </div>
                    <div class="TextCenter">
                        <asp:LinkButton CssClass="itemsp-btngiohang" Text="THÊM VÀO GIỎ HÀNG" runat="server" />
                    </div>
                     <asp:Label ID="lbkm1" CssClass="itemsp-khuyenmai" Text='<%#"-"+Eval("TiLe")+"%" %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div class="divxemtatca">
            <a class="btnxemtatca" href="#">Xem tất cả</a>
        </div>
        <div class="relative">
              <hr class="hr"/>
        </div>
      
    </div>

      <div>
        <div class="tendanhmuc">DÀNH CHO BẠN</div>
        <asp:DataList ID="dlDanhChoBan" runat="server" RepeatColumns="4">
            <ItemTemplate>
                 <div class="itemsp">
                    <div class="itemsp-img">
                        <asp:ImageButton CommandArgument='<%#Eval("IDSP") %>' OnClick="imgHinhAnhSP_Click"  ImageUrl='<%#"../../Image/product/"+Eval("HinhAnh") %>' runat="server" />
                    </div>
                     <asp:Label  CssClass="itemsp-ten" Text='<%#Eval("TenSach") %>' runat="server" />
                     <asp:Label CssClass="itemsp-tacgia"  Text='<%#Eval("TenTG") %>' runat="server" />
                    <div class="TextCenter">
                        <asp:Label CssClass="itemsp-gia itemsp-giakm" Text='<%#Eval("GiaBan") +"đ" %>' runat="server" />
                        <asp:Label ID="lbGiaBia1" CssClass="itemsp-gia itemsp-gianiemyet" Text='<%#Eval("GiaBia") +"đ" %>' runat="server" />
                    </div>
                    <div class="TextCenter">
                        <asp:LinkButton CssClass="itemsp-btngiohang" Text="THÊM VÀO GIỎ HÀNG" runat="server" />
                    </div>
                     <asp:Label ID="lbkm" CssClass="itemsp-khuyenmai" Text='<%#"-"+Eval("TiLe")+"%" %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div class="divxemtatca">
            <a class="btnxemtatca" href="#">Xem tất cả</a>
        </div>
        <div class="relative">
              <hr class="hr"/>
        </div>
      
    </div>
</div>
