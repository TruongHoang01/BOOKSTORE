<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTaiKhoan.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucTaiKhoan" %>
<div class="TaiKhoan">
    <div class="flex">
         <div class="width30 CotTrai">
            <div class="divflex">
                <div>
                    <asp:Image ImageUrl="../../Image/anhdaidien.png" runat="server" />
                </div>
                <div> 
                    <div><asp:Label Text="Cao Hữu Hiếu" runat="server" /></div>
                    <div class="divChinhSua">
                        <asp:LinkButton runat="server" ><i class="fa-regular fa-pen-to-square"></i>  Sửa hồ sơ </asp:LinkButton>
                    </div>
                </div>

            </div>
            <asp:LinkButton ID="linkTaiKhoan" OnClick="linkTaiKhoan_Click" CssClass="link" runat="server"><i class="fa-solid fa-user"></i>Tài khoản của tôi</asp:LinkButton>
            <asp:LinkButton ID="linkDonHang" OnClick="linkDonHang_Click" CssClass="link" runat="server" ><i class="fa-solid fa-list"></i>Đơn mua</asp:LinkButton>
        </div>
        <div class="width70 CotPhai">
            <asp:PlaceHolder runat="server" ID="plTaiKhoan" />
        </div>
    </div>
</div>

