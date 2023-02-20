<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCapNhatTaiKhoan.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucCapNhatTaiKhoan" ClientIDMode="Static" %>
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
                <asp:TextBox ID="tbTen" runat="server" />
            </div>
            <div  class="row">
                <span>Email</span>
                <asp:TextBox ID="tbEmail" runat="server" ReadOnly="true"/>
            </div>
            <div  class="row">
                <span>Số điện thoại</span>
                <asp:TextBox ID="tbSDT" runat="server" />
            </div>
            <div  class="row">
                <span>Giới tính</span>
                <asp:RadioButtonList ID="rdGioiTinh" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem  Text="Nam"  Value="0"/>
                    <asp:ListItem Text="Nữ" Value="1"/>
                      <asp:ListItem Text="Không xác định" />
                </asp:RadioButtonList>
            </div>
            <div  class="row"> 
                <span>Địa chỉ</span>
                <asp:TextBox ID="tbDiaChi" runat="server" />
            </div>
              <div  class="row"> 
                <span id="lbthongbao" class="validate"></span>
            </div>
          
            <asp:Label Text="" ID="lbAnhDaiDienCu" Visible="false" runat="server" />
            <div class="divbutton">
              
                <asp:Button OnClick="btnCapNhat_Click" OnClientClick="return validateAll()" ID="btnCapNhat" Text="Cập nhật" runat="server" />
                <asp:Button OnClick="btnHuy_Click" ID="btnHuy" Text="Hủy" runat="server" />
            </div>
          
        </div>
            <div class="divAnhDaiDien  width40">
                <div style="width: 50%">
                    <asp:Image Width="180" Height="220" ID="imgAnhDaiDien" runat="server" />
                    <asp:FileUpload CssClass="upLoadFile" runat="server" name="file" ID="flAnhDaiDien" onchange="onFileSelected(event)" />
                    <label for="flAnhDaiDien" class="labelAnh">Chọn ảnh</label>
                </div>
               
            </div>
        </div>
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
        <asp:LinkButton Text="OK" OnClick="btnClick_Click" runat="server" />
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
    function validateAll() {
        var check = true;
        var mess = "";
        if ($("#tbTen")[0].value == "") {
            mess += "Tên không được để trống </br>";
            check = false;
        }
        if ($("#tbSDT")[0].value == "") {
            mess += "Số điện thoại không được để trống  </br>";
            check = false;
        }
        if ($("#tbDiaChi")[0].value == "") {
            mess += "Địa chỉ không được để trống";
            check = false;
        }
        $("#lbthongbao")[0].innerHTML = mess;
        return check;
      }
</script>
