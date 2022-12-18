<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTimKiem.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucTimKiem" %>
<div class="giaodiensanpham">
        <div>
            <asp:Label CssClass="lbtitletimkiem" ID="lbtitle" Text="" runat="server" /></div>
        <asp:DataList CssClass="tbsanpham" ID="dlSanPham" runat="server" RepeatColumns="4">
            <ItemTemplate>
                 <div class="itemsp">
                    <div class="itemsp-img">
                        <asp:ImageButton ImageUrl='<%#"../../Image/product/"+Eval("HinhAnh") %>' runat="server" />
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
                     <asp:Label ID="lbkm" CssClass="itemsp-khuyenmai" Text='<%#"-"+Eval("TiLe")+"%" %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>