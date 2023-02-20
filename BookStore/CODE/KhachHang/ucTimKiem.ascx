<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTimKiem.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucTimKiem" %>
<div class="giaodiensanpham">
        <div>
            <asp:Label CssClass="lbtitletimkiem" ID="lbtitle" Text="" runat="server" /></div>
        <asp:DataList CssClass="tbsanpham" ID="dlSanPham" runat="server" RepeatColumns="4">
            <ItemTemplate>
                 <div class="itemsp">
                    <div class="itemsp-img">
                        <asp:ImageButton  CommandArgument='<%#Eval("ID") %>' ID="imgButton" OnClick="imgButton_Click" ImageUrl='<%#"../../Image/product/"+Eval("HinhAnh") %>' runat="server" />
                    </div>
                     <asp:LinkButton Text='<%#Eval("TenSach") %>' CommandArgument='<%#Eval("ID") %>' ID="linkTenSP" OnClick="linkTenSP_Click" runat="server" />
                     <asp:Label CssClass="itemsp-tacgia"  Text='<%#Eval("TenTG") %>' runat="server" />
                    <div class="TextCenter">
                        <asp:Label CssClass="itemsp-gia itemsp-giakm" Text='<%#Eval("GiaBan") +"đ" %>' runat="server" />
                        <asp:Label ID="lbGiaBia" CssClass="itemsp-gia itemsp-gianiemyet" Text='<%#Eval("GiaBia") +"đ" %>' runat="server" />
                    </div>
                    <div class="TextCenter">
                        <asp:LinkButton ID="themVaoGioHang" OnClick="themVaoGioHang_Click" CommandArgument='<%#Eval("ID") %>' CssClass="itemsp-btngiohang"  Text="THÊM VÀO GIỎ HÀNG" runat="server" />
                    </div>
                     <asp:Label  ID="lbkm" CssClass="itemsp-khuyenmai" Text='<%#"-"+Eval("TiLe")+"%" %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:DataList>
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