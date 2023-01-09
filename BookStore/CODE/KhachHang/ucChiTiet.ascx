<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChiTiet.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucChiTiet" ClientIDMode="Static" %>


<div class="DuongDan">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</div>
<div class="ChiTietSanPham">
    <div class="flex">
        <asp:Literal Text="" ID="ltChiTiet" runat="server" />
        <div class="bottom">
       <%--     <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server">--%>
         <%--       <ContentTemplate>--%>
                    <div class="SoLuong">
                        Số lượng:   
                        <asp:LinkButton CssClass="btnsoluong btngiam button" OnClick="btnGiamSL_Click" ID="btnGiamSL1" Text="-" runat="server" />
                        <asp:TextBox ID="tbsoluong" Text="1" runat="server" ReadOnly="true"/>
                        <asp:LinkButton CssClass="btnsoluong btntang button" OnClick="btnTangSL_Click" ID="btnTangSL1" Text="+" runat="server" />
                    </div>
               

                    <div class="button">
                        <asp:LinkButton CssClass="button1" ID="btnThemVaoGioHang1" OnClick="btnThemVaoGioHang_Click" Text="Thêm vào giỏ hàng" runat="server" />
                        <asp:LinkButton CssClass="button" Text="Mua ngay" runat="server" />
                    </div>
              <%--       </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
    <div class="CuaHang">
        <div class="divflex">
            <div class="divHinhAnh">
                <asp:Image ImageUrl="../../Image/anhdaidien/anhdaidien.png" runat="server" />
            </div>
            <div class="divTenCuaHang">
                <asp:Label Text="Ope Store" runat="server" />
            </div>
        </div>
        <div class="flex divThongKe">
            <div class="TextCenter">
                <asp:Label Text="4.4" runat="server" />/5 <i class="star fa-solid fa-star"></i>
                <div>
                    <asp:Label Text="337" runat="server" />
                    đánh giá
                </div>
            </div>
            <div>
                <div class="TextCenter">
                    <asp:Label Text="357" runat="server" />
                    <div>Theo dõi</div>
                </div>
            </div>

        </div>
        <div class="Button">
            <asp:LinkButton runat="server"><i class="fa-solid fa-store"></i> Xem Shop</asp:LinkButton>
            <asp:LinkButton runat="server"><i class="fa-solid fa-plus"></i> Theo dõi</asp:LinkButton>
        </div>
        <div class="divUuDai divflex TextCenter">
            <div>
                <div><i class="fa-solid fa-shield"></i></div>
                <div>Hoàn tiền 100% nếu sản phẩm bị lỗi</div>
            </div>
            <div>
                <div><i class="fa-solid fa-thumbs-up"></i></div>
                <div>Mở hộp kiểm tra nhận hàng</div>
            </div>
            <div>
                <div><i class="fa-solid fa-rotate-left"></i></div>
                <div>Đổi trả trong 7 không thích sản phẩm</div>
            </div>
        </div>

    </div>
</div>
<div class="divThongTinChiTiet">
    <h1>Thông tin chi tiết</h1>
    <asp:Literal Text="" ID="ltrChiTiet2" runat="server" />
</div>
<div class="divSanPhamCungLoai">
    <h1>Sản phẩm cùng loại</h1>
    <asp:DataList runat="server" ID="dlSanPhamCungLoai" RepeatColumns="5">
        <ItemTemplate>
            <div class="itemsp">
                <div class="itemsp-img">
                    <asp:ImageButton ImageUrl='<%#"../../Image/product/"+Eval("HinhAnh") %>' runat="server" />
                </div>
                <asp:Label CssClass="itemsp-ten" Text='<%#Eval("TenSach") %>' runat="server" />
                <asp:Label CssClass="itemsp-tacgia" Text='<%#Eval("TenTG") %>' runat="server" />
                <div class="TextCenter">
                    <asp:Label CssClass="itemsp-gia itemsp-giakm" Text='<%#Eval("GiaBan") +"đ" %>' runat="server" />
                    <asp:Label AssociatedControlID="lbGiaBia" ID="lbGiaBia" CssClass="itemsp-gia itemsp-gianiemyet" Text='<%#Eval("GiaBia") +"đ" %>' runat="server" />
                </div>
                <div class="TextCenter">
                    <asp:LinkButton CssClass="itemsp-btngiohang" Text="THÊM VÀO GIỎ HÀNG" runat="server" />
                </div>
                <asp:Label ID="lbkm1" CssClass="itemsp-khuyenmai" Text='<%#"-"+Eval("TiLe")+"%" %>' runat="server" />
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>
<div  class="thongbaochitiet" id="divthongbao">
    <div class="thongbaodiv divflex" >
        <img src="../../Image/success.png" />
        <p>Đã thêm vào thành công</p>
    </div>
</div>

<script>
    const btnThem = document.getElementById("btnThemVaoGioHang1");
    const eleThongBao = document.querySelector('.thongbaochitiet')
    
    btnThem.addEventListener("click", (e) => {
        e.preventDefault()
        eleThongBao.style.display = "block"
        setTimeout(() => {
            eleThongBao.style.display = "none"
        }, 700)
        
    })
</script>