<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCapNhatTaiKhoan.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucCapNhatTaiKhoan" %>
<div class="CapNhatTaiKhoan">
    <div class="DivHoSoCuaToi">
        <h1>Hồ Sơ Của Tôi</h1>
        <p>Quản lý thông tin hồ sơ để bảo mật tài khoản</p>
    </div>
<div>
    <div class="flex">
        <div class ="width60">
             <div class="row">
                <span>Tên</span>
                <asp:TextBox runat="server" />
            </div>
            <div  class="row">
                <span>Email</span>
                <asp:TextBox runat="server" ReadOnly="true"/>
            </div>
            <div  class="row">
                <span>Số điện thoại</span>
                <asp:TextBox runat="server" />
            </div>
            <div  class="row">
                <span>Giới tính</span>
                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem  Text="Nam" />
                    <asp:ListItem Text="Nữ" />
                      <asp:ListItem Text="Không xác định" />
                </asp:RadioButtonList>
            </div>
            <div  class="row"> 
                <span>Địa chỉ</span>
                <asp:TextBox runat="server" />
            </div>
            <div class="divbutton">
                <asp:Button OnClick="btnCapNhat_Click" ID="btnCapNhat" Text="Cập nhật" runat="server" />
                <asp:Button OnClick="btnHuy_Click" ID="btnHuy" Text="Hủy" runat="server" />
            </div>
        </div>
            <div class="divAnhDaiDien  width40">
                <asp:Image CssClass="AnhDaiDien" ImageUrl="../../Image/anhdaidiennam.jpg" runat="server" />
                <div>
                    <asp:FileUpload Text="Chọn ảnh" ID="imgUpLoad" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>

