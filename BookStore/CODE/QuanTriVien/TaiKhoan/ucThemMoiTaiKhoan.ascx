<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThemMoiTaiKhoan.ascx.cs" Inherits="BookStore.CODE.QuanTriVien.TaiKhoan.ucThemMoiTaiKhoan" %>
<div class="FormThemMoi FormThemTaiKhoan divflex">
    <div class="col80">
        <table class="tableThemMoi ">
            <tr>
                <th colspan="2">
                    <asp:Label ID="lbThem" Text="THÊM MỚI TÀI KHOẢN" runat="server" />
                </th>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox runat="server" ID="tbEmail" />
                </td>
            </tr>
            <tr>
                <td>SDT</td>
                <td>
                    <asp:TextBox runat="server" ID="tbSDT" />
                </td>
            </tr>
              <tr>
                <td>Mật khẩu</td>
                <td>
                    <asp:TextBox runat="server" ID="tbMatKhau" />
                </td>
            </tr>
            <tr>
                <td>Họ và Tên</td>
                <td>
                    <asp:TextBox runat="server" ID="tbHoTen" />
                </td>
            </tr>
            <tr>
                <td>Giới Tính</td>
                <td>
                    <asp:RadioButtonList OnSelectedIndexChanged="rdGioiTinh_SelectedIndexChanged" AutoPostBack="true" ID="rdGioiTinh" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="true" ID="rbNam" Value="0" Text="Nam" />
                        <asp:ListItem ID="rbNu" Value="1" Text="Nữ" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Địa Chỉ</td>
                <td>
                    <asp:TextBox runat="server" ID="tbDiaChi" TextMode="MultiLine" Rows="4" Columns="59" />
                </td>
            </tr>
            <tr>
                <td>Quyền</td>
                <td>
                    <asp:DropDownList ID="ddlQuyen" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="rowNgayTao" runat="server">
                <td>Ngày tạo</td>
                <td>
                    <asp:TextBox ReadOnly="true" runat="server" ID="tbNgayTao" />
                </td>
            </tr>
            <tr id="rowCapNhat" runat="server">
                <td>Ngày cập nhật</td>
                <td>
                    <asp:TextBox ReadOnly="true"  ID="tbNgayCapNhat" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbAnhDaiDienCu" Visible="false" runat="server" />
                    <asp:Label ID="lbID" Visible="false" Text="" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp</td>
                <td>
                    <asp:CheckBox ID="cbCheck" Text="Tạo tài khoản mới sau khi tạo tài khoản này." runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="TextCenter ">
                    <asp:LinkButton CssClass="btnThem" OnClick="btnThem_Click" ID="btnThem" Text="Thêm mới" runat="server" />
                    <asp:LinkButton CssClass="btnThem" OnClick="btnHuy_Click" ID="btnHuy" Text="Hủy" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div class="divHinhAnh col20">
        <asp:Image Width="180" Height="220" ID="imgAnhDaiDien" ImageUrl="../../../Image/anhdaidiennam.jpg" runat="server" />
        <asp:FileUpload runat="server" ID="flAnhDaiDien" />
    </div>
</div>

<div class="ThongBao" visible="false"  id="ThongBao" runat="server">
        <div class="divflex  flexThongBao">
            <div>
                <asp:Image ID="imgThongBao" Width="60" Height="60" imageurl="../../../Image/success.png" runat="server" />
            </div>
            <div class="content">
                <div>
                    <p class="chuDeThongBao" id="chuDeThongBao" runat="server">Thành công</p>
                    <p id="noiDungThongBao" runat="server">Bạn đã thêm danh mục thành công!</p>
                </div>
            </div>
        </div>
        <div class="btnOK">
            <asp:LinkButton OnClick="btnOK_Click" ID="btnOK" Text="OK" runat="server" />
        </div>
</div>
