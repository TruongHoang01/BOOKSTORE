<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDatHang.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucDatHang" ClientIDMode="Static" %>
<div class="GioHang dathang">
    <div class="danhsach_sc width90">
        <div class="divflex divheader">
            <div class="checkbox">Sản phẩm</div>
            <div class="title">
                <span>Đơn Giá</span>
                <span>Số Lượng</span>
                <span>Thành Tiền</span>
            </div>
        </div>
        <div class="scroll">
            <asp:DataList runat="server" ID="dlCuaHang" Width="100%">
                <ItemTemplate>
                    <div class="ThongTin divThongTin">
                        <div class='center DivCuaHang'>
                            <h1 class="checkbox">
                                <asp:Label Text='<%#Eval("TenCuaHang") %>' runat="server" />
                            </h1>
                        </div>
                        <asp:DataList runat="server" ID="dlSanPham" Width="100%">
                            <ItemTemplate>
                                <div class='center DivChiTietDonHang'>
                                    <div class=" divflex divchitiet">
                                        <div class="center checkbox">
                                            <div>
                                                <img class="AnhSanPham" src='<%#"../../Image/product/"+Eval("HinhAnh") %>' />
                                            </div>
                                            <div>
                                                <p style="max-width: 300px">
                                                    <span class="TenSanPham"><%#Eval("TenSach") %></span>
                                                </p>
                                                <p>
                                                    <span class='chitiet'><%#Eval("TenTG") %></span>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="center right">
                                            <div class=" column Gia">
                                                <span class="giagoc"><%#Eval("GiaBia") %>đ</span>
                                                <span class="giakm"><%#Eval("GiaKM") %>đ</span>
                                            </div>
                                            <div class="column SoLuong">
                                                <asp:Label ID="tbsoluong" Text='<%#Eval("SoLuong")%>' runat="server" />
                                            </div>
                                            <div class=" column Gia giakm"><span><%#Eval("ThanhTien") %>đ</span></div>
                                        </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <div class="center">
                            <div class="width70">  <asp:TextBox ID="tbGhiChu" CssClass="textghichu" runat="server" PlaceHolder="Ghi chú cho người bán..." TextMode="MultiLine"/></div>
                            <div class="width30 TextRight">Tổng tiền đơn hàng: <asp:Label ForeColor="Red" ID="lbtongtien" Font-Size="14" Font-Bold="true"   Text="0" runat="server" /></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="footergh width40">
        <div class="thanhtoan">
            <p style="display:block">Thông tin người nhận</p>
            <div>
                <asp:TextBox ID="tbTenNguoiNhan" runat="server" PlaceHolder="Họ và tên người nhận" />
                <p class="pvalidate"> <asp:RequiredFieldValidator CssClass="validate" ID="RequiredFieldValidator1" ControlToValidate="tbTenNguoiNhan" Display="Dynamic" runat="server" ErrorMessage="Họ tên không được để trống!"></asp:RequiredFieldValidator></p>
            </div>
            <div>
                <asp:TextBox ID="tbSDT" runat="server" PlaceHolder="Số điện thoại người nhận" />
                <p  class="pvalidate"><asp:RequiredFieldValidator CssClass="validate" ID="RequiredFieldValidator2" ControlToValidate="tbSDT" Display="Dynamic" runat="server" ErrorMessage="Số điện thoại không được để trống!"></asp:RequiredFieldValidator></p> 
            </div>
            <div>
                <asp:TextBox ID="tbDiaChi" runat="server" PlaceHolder="Địa chỉ nhận hàng..." TextMode="MultiLine"/>
                <p  class="pvalidate">
                    <asp:RequiredFieldValidator CssClass="validate" ID="RequiredFieldValidator3" ControlToValidate="tbDiaChi" Display="Dynamic" runat="server" ErrorMessage="Địa chỉ không được để trống!"></asp:RequiredFieldValidator>
                </p>
            </div>
           
        </div>
         <div class="btn-mua">
             <asp:Label Text="" ID="lbThongBao" runat="server" />
                <asp:Button ID="btnDatHang" OnClick="btnDatHang_Click" Text="Đặt hàng" runat="server" />
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

