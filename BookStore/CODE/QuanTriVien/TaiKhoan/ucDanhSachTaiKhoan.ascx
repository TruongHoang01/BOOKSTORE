<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDanhSachTaiKhoan.ascx.cs" Inherits="BookStore.CODE.QuanTriVien.QuanLyThue.ucDanhSachTaiKhoan" %>



        <div class="divTop divflex mt20">
    <div class="divTimKiem divflex">
        <asp:TextBox ID="tbTimKiem" CssClass="inputTimKiem" runat="server" PlaceHolder="Nhập email hoặc sdt"/>
        <asp:Button ID="btnTiemKiem" OnClick="btnTiemKiem_Click" CssClass="btnTimKiem btnThem" Text="Tìm kiếm" runat="server" />
    </div>
    <div>
        <asp:LinkButton ID="btnThemMoi" OnClick="btnThemMoi_Click" CssClass="btnThem" Text="Thêm mới" runat="server" />
    </div>
</div>
<div class="divTable">
    <div class="HeaderText">DANH SÁCH TÀI KHOẢN</div>
    <div class="scroll">
         <asp:GridView ID="grTaiKhoan"  CssClass="tableAdmin" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-CssClass="col20" HeaderText="Email" DataField="Email" runat="server" /> 
            <asp:BoundField ItemStyle-CssClass="col10 TextCenter" HeaderText="SDT" DataField="SDT" runat="server" />
            <asp:BoundField ItemStyle-CssClass="col15" HeaderText="Họ và Tên" DataField="HoTen" runat="server" />
            <asp:BoundField ItemStyle-CssClass="col5" HeaderText="Giới Tính" DataField="GioiTinh" runat="server" />
            <asp:BoundField ItemStyle-CssClass="col25" HeaderText="Địa Chỉ" DataField="DiaChi" runat="server" />
            <asp:BoundField ItemStyle-CssClass="col10 TextCenter" HeaderText="Quyền" DataField="TenQuyen" runat="server" />
            <asp:TemplateField HeaderText="Thao tác" ItemStyle-CssClass="TextCenter col10">
                <ItemTemplate>
                     <asp:ImageButton  ID="btnKhoa" CommandArgument='<%#Eval("ID") %>' OnClick="btnKhoa_Click" ImageUrl="../../../Image/iconbikhoa.png" runat="server" title="Khóa tài khoản"/>
                     <asp:ImageButton Visible="false" ID="btnMoKHoa" CommandArgument='<%#Eval("ID") %>' OnClick="btnMoKHoa_Click" ImageUrl="../../../Image/iconmokhoa.jpg" runat="server" title="Mở khóa"/>
                    <asp:ImageButton ID="imgEdit" CommandArgument='<%#Eval("ID") %>' Onclick="imgEdit_Click" ImageUrl="../../../Image/edit.jpeg" runat="server" title ="Cập nhật"/>
                    <asp:ImageButton ID="imgDelete" CommandArgument='<%#Eval("ID") %>' OnClick="imgDelete_Click" ImageUrl="../../../Image/delete.png" runat="server" title="Xóa"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
   
</div>
<div class="ThongBao"  id="ThongBao" runat="server">
        <div class="divflex  flexThongBao">
            <div>
                <asp:Image ID="imgThongBao" Width="60" Height="60"  runat="server" />
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
            <asp:LinkButton Visible="false" OnClick="btnCancel_Click" ID="btnCancel" Text="Hủy" runat="server" />
        </div>
</div>

