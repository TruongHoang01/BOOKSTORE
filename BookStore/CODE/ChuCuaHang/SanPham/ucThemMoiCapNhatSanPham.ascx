<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThemMoiCapNhatSanPham.ascx.cs" Inherits="BookStore.CODE.ChuCuaHang.SanPham.ucThemMoiCapNhatSanPham" %>

<div class="containerdonhang">
    <div class="divdonhangphai">
        <div class="divthanhden"></div>
        <div class="divthemmoi">
            <div class="divtitle">
                <asp:Label ID="title" Text="THÊM MỚI SẢN PHẨM" runat="server" />
            </div>
            <div class="divflex">
                <div class="divflexcon">
                    <div class="rowthemmoi">
                        <span>Tên sách: </span>
                        <asp:TextBox ID="tbTenSach" runat="server" />
                    </div>
                           <div class="rowthemmoi">
                        <span>Danh mục: </span>
                        <asp:DropDownList ID="ddlDanhMuc" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="rowthemmoi">
                        <span>Tác giả: </span>
                        <asp:DropDownList ID="ddlTacGia" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="rowthemmoi">
                        <span>Nhà xuất bản: </span>
                        <asp:DropDownList ID="ddlNXB" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="rowthemmoi">
                        <span>Mã khuyến mãi: </span>
                        <asp:DropDownList ID="ddlKM" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="rowthemmoi">
                        <span>Kích thước: </span>
                        <asp:TextBox ID="tbKichThuoc" runat="server" />
                    </div>
                    <div class="rowthemmoi">
                        <span>Số lượng: </span>
                        <asp:TextBox ID="tbSoLuong" runat="server" />
                    </div>
                    <div class="rowthemmoi">
                        <span>Giá bìa: </span>
                        <asp:TextBox ID="tbGiaBia" runat="server" />
                    </div>
                    <div class="rowthemmoi" runat="server" id="ngaytao" visible="false">
                        <span>Ngày tạo: </span>
                        <asp:TextBox ID="tbNgayTao" runat="server" ReadOnly="true" />
                    </div>
                </div>
                <div class="divflexcon">
                    <div class="rowthemmoi" style="display: flex; align-items: center">
                        <span>Hình Ảnh: </span>

                        <image src="" id="imgSach" style="width: 128px; height: 128px; background-color: #ccc" runat="server"/>
                    </div>
                    <div class="rowthemmoi">
                         <span>&nbsp;</span>
                         <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                    <div class="rowthemmoi" style="margin-bottom: 10px;">
                        <span>Năm xuất bản: </span>
                        <asp:TextBox ID="tbNamXuatBan" runat="server" />
                    </div>
                    <div class="rowthemmoi">
                        <span>Số trang: </span>
                        <asp:TextBox ID="tbSoTrang" runat="server" />
                    </div>
                    <div class="rowthemmoi">
                        <span>Trọng lượng: </span>
                        <asp:TextBox ID="tbTrongLuong" runat="server" />
                    </div>
                    <div class="rowthemmoi">
                        <span>Đã bán: </span>
                        <asp:TextBox ReadOnly="true" ID="tbDaBan" runat="server" />
                    </div>
                    <div class="rowthemmoi"  runat="server" id="ngaycapnhat" visible="false">
                        <span>Ngày cập nhật: </span>
                        <asp:TextBox ID="tbNgayCapNhat" runat="server" ReadOnly="true" />
                    </div>
                </div>
            </div>
        
            <div class="linkbutton ">
                <asp:LinkButton ID="btnThemMoi" OnClick="btnThemMoi_Click" Text="Thêm mới" runat="server" />
                <asp:LinkButton ID="btnDatLai" OnClick="btnDatLai_Click" Text="Đặt lại" runat="server" />
            </div>
        </div>
    </div>
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
