<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThemMoiTaiKhoan.ascx.cs " Inherits="BookStore.CODE.QuanTriVien.TaiKhoan.ucThemMoiTaiKhoan" ClientIDMode="Static" %>
<div class="FormThemMoi FormThemTaiKhoan divflex">
  
  <div class="col80">

         <div class="formTaiKhoan">
            <p class="title">
                <asp:Label ID="lbThem" Text="THÊM MỚI TÀI KHOẢN" runat="server" /></p>
            <div class="row">
                <p>Email</p>
                <div>
                    <asp:TextBox runat="server" ID="tbEmail" />
                    <div>
                        <asp:RequiredFieldValidator CssClass="validate" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email không được để trống" Display="Dynamic" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="validate" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không hợp lệ" ControlToValidate="tbEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <p>Số điện thoại</p>
                <div>
                    <asp:TextBox runat="server" ID="tbSDT" />
                    <div>
                        <asp:RequiredFieldValidator CssClass="validate" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Số điện thoại không được để trống" ControlToValidate="tbSDT" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="validate" Display="Dynamic" ID="RegularExpressionValidator2" ControlToValidate="tbSDT" runat="server" ErrorMessage="Số điện thoại không hợp lệ" ValidationExpression="(84|0[3|5|7|8|9])+([0-9]{8})"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <p>Mật khẩu</p>
                <div>
                    <asp:TextBox runat="server" ID="tbMatKhau" TextMode="Password" />
                    <div>
                        <asp:RequiredFieldValidator CssClass="validate" ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbMatKhau" ErrorMessage="Mật khẩu không được để trống" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <p>Họ và tên</p>
                <div>
                    <asp:TextBox runat="server" ID="tbHoTen" />
                    <div>
                        <asp:RequiredFieldValidator CssClass="validate" ID="RequiredFieldValidator4" ControlToValidate="tbHoTen" runat="server" ErrorMessage="Họ tên không được để trống " Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                Giới Tính
           
                    <asp:RadioButtonList OnSelectedIndexChanged="rdGioiTinh_SelectedIndexChanged" AutoPostBack="true" ID="rdGioiTinh" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="true" ID="rbNam" Value="0" Text="Nam" />
                        <asp:ListItem ID="rbNu" Value="1" Text="Nữ" />
                    </asp:RadioButtonList>

            </div>
            <div class="row">
                <p>Địa Chỉ</p>
                <div>
                    <asp:TextBox runat="server" ID="tbDiaChi" TextMode="MultiLine" Rows="4" Columns="59" />
                    <div>
                        <asp:RequiredFieldValidator CssClass="validate" ID="RequiredFieldValidator5" ControlToValidate="tbDiaChi" runat="server" ErrorMessage="Địa chỉ không được để trống" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <p>Quyền</p>
                <div>
                    <asp:DropDownList ID="ddlQuyen" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row" id="divNgayTao" runat="server">
                <p>Ngày tạo</p>
                <div>
                    <asp:TextBox ReadOnly="true" runat="server" ID="tbNgayTao" /></div>

            </div>
            <div class="row" id="divCapNhat" runat="server">
                <p>Ngày cập nhật</p>
                <div>
                    <asp:TextBox ReadOnly="true" ID="tbNgayCapNhat" runat="server" />
                </div>
            </div>
            <asp:Label ID="lbAnhDaiDienCu" Visible="false" runat="server" />
            <asp:Label ID="lbID" Visible="false" Text="" runat="server" />
            <div class="row TextCenter  ">
                <asp:CheckBox ID="cbCheck" Text="Tạo tài khoản mới sau khi tạo tài khoản này." runat="server" />
            </div>
            <div class="TextCenter ">
                <asp:Button type="submit" CssClass="btnThem" OnClick="btnThem_Click" ID="btnThem" Text="Thêm mới" runat="server" />
                <asp:LinkButton CssClass="btnThem" OnClick="btnHuy_Click" ID="btnHuy" Text="Hủy" runat="server" />
            </div>
        </div>
    </div>
    <div class="divHinhAnh col20 TextCenter ">
        <asp:Image Width="180" Height="220" ID="imgAnhDaiDien" ImageUrl="../../../Image/anhdaidiennam.jpg" runat="server" />
        <asp:FileUpload CssClass="upLoadFile" runat="server" name="file" ID="flAnhDaiDien" onchange="onFileSelected(event)" />
        <label for="flAnhDaiDien" class="labelAnh">Chọn ảnh</label>

    </div>
</div>

<div class="ThongBao" id="ThongBao" runat="server" visible="false">
    <div class="divflex  flexThongBao">
        <div>
            <asp:Image ID="imgThongBao" Width="60" Height="60" ImageUrl="../../../Image/success.png" runat="server" />
        </div>
        <div class="content">
            <div>

                <p class="chuDeThongBao" id="chuDeThongBao" runat="server">Thành công</p>
                <p id="noiDungThongBao" runat="server">Bạn đã thêm danh mục thành công!</p>
            </div>
        </div>
    </div>
    <div class="btnOK">
        <asp:LinkButton Text="OK" OnClick="btnClick_Click" runat="server" CausesValidation="False" />

    </div>
</div>
<script>
    function onFileSelected(event) {
        var selectedFile = event.target.files[0];
        var reader = new FileReader();

        var imgtag = document.getElementById("imgAnhDaiDien");
        imgtag.title = selectedFile.name;

        reader.onload = function (event) {
            imgtag.src = event.target.result;
        };
        reader.readAsDataURL(selectedFile);
    }
</script>
