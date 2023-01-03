<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGioHang.ascx.cs" EnableViewState="true" Inherits="BookStore.CODE.KhachHang.ucGioHang" %>

    <div  class="GioHang">
        <div class="divflex divheader">
            <div class="checkbox"><asp:CheckBox ID="cbkSelectAll" OnCheckedChanged="cbkSelectAll_CheckedChanged" Text="Sản phẩm" runat="server" AutoPostBack="true"/></div>
            <div class="title">
                <span>Đơn Giá</span>
                <span>Số Lượng</span>
                <span>Thành Tiền</span>
                <span>Thao Tác</span>
            </div>
        </div>
        <div>
             <asp:DataList runat="server" ID="dlCuaHang" Width="100%">
                <ItemTemplate>
                    <div class="ThongTin divThongTin">
                        <div class='center DivCuaHang'>
                            <h1 class="checkbox">
                                <asp:CheckBox ID="cbkSelectAllStore" AutoPostBack="true" OnCheckedChanged="cbkSelectAllStore_CheckedChanged" Text='<%#Eval("TenCuaHang") %>' runat="server" />
                            </h1>
                        </div>
                        <asp:DataList runat="server" ID="dlSanPham" Width="100%">
                            <ItemTemplate>
                                <div class='center DivChiTietDonHang'>
                                    <div class=" divflex divchitiet">
                                        <div class="center checkbox">
                                             <asp:CheckBox ID="cbkSanPham" AutoPostBack="true" Text="" runat="server" />
                                            <div>
                                                <img class="AnhSanPham" src='<%#"../../Image/product/"+Eval("HinhAnh") %>'/>
                                            </div>
                                            <div>
                                                <p style="max-width:300px"> 
                                                    <span class="TenSanPham"><%#Eval("TenSach") %></span>
                                                </p>   
                                                <p>
                                                    <span class='chitiet'><%#Eval("TenTG") %></span>
                                                    </p>
                                            </div>
                                        </div>
                                        <div class="center right">
                                             <div class=" column Gia">
                                                 <span><%#Eval("GiaBia") %>đ</span>
                                                 <span><%#Eval("GiaKM") %>đ</span>
                                             </div>
                                             <div class="column SoLuong">
                                                 <asp:Button Text="-" ID="btnTruSL" OnClick="btnTruSL_Click" runat="server" />
                                                 <asp:TextBox runat="server" ID="textSL" Text='<%#Eval("SoLuong") %>'></asp:TextBox>
                                                 <asp:Button Text="+" OnClick="btnCongSL_Click" ID="btnCongSL" runat="server" />
                                            </div>
                                            <div  class=" column Gia"><span><%#Eval("ThanhTien") %>đ</span></div>
                                            <div class="column ThaoTac"> <asp:Button Text="Xóa" runat="server" /></div>
                                           
                                        </div>
                            </ItemTemplate>
                        </asp:DataList>
                     </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>