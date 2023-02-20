<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGioHang.ascx.cs" EnableViewState="true" Inherits="BookStore.CODE.KhachHang.ucGioHang" %>

    <div class="GioHang">
        <div class="danhsach_sc width70">
            <div class="divflex divheader">
                <div class="checkbox"><asp:CheckBox ID="cbkSelectAll" OnCheckedChanged="cbkSelectAll_CheckedChanged" Text="Sản phẩm" runat="server" AutoPostBack="true"/></div>
                <div class="title">
                    <span>Đơn Giá</span>
                    <span>Số Lượng</span>
                    <span>Thành Tiền</span>
                    <span>Thao Tác</span>
                </div>
            </div>
            <div class="scroll">
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
                                            <asp:HiddenField ID="hfID" Value='<%#Eval("ID") %>' runat="server" />
                                            <div class="center checkbox">
                                                 <asp:CheckBox ID="cbkSanPham" OnCheckedChanged="cbkSanPham_CheckedChanged" AutoPostBack="true" Text="" runat="server" />
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
                                                     <span class="giagoc"> <asp:Label ID="lbGiaGoc" Text=<%#Eval("GiaBia")%> runat="server" />đ</span>
                                                     <span class="giakm">  <asp:Label ID="lbGiaKM" Text='<%#Eval("GiaKM") %>' runat="server" /> đ</span>
                                                   
                                                 </div>
                                                 <div class="column SoLuong">
                                                        <asp:Button CssClass="btnsoluong btngiam button" OnClick="btnGiamSL_Click" ID="btnGiamSL" Text="-" runat="server" />
                                                        <asp:TextBox ID="tbsoluong" Text='<%#Eval("SoLuong") %>' runat="server" />
                                                        <asp:Button  CssClass="btnsoluong btntang button"  OnClick="btnTangSL_Click" ID="btnTangSL" Text="+" runat="server"/>
                                                </div>
                                                <div  class="column Gia giakm" style="min-width: 80px; text-align: right"><span><%#Eval("ThanhTien") %>đ</span></div>
                                                <div class="column ThaoTac"> <asp:ImageButton CommandArgument='<%#Eval("ID") %>' ID="imgDelete" OnClick="imgDelete_Click"  ImageUrl="../../Image/delete.png" Width="40" Height="40" runat="server" /></div>
                                            </div>
                                </ItemTemplate>
                            </asp:DataList>
                         </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div class="footergh width30">
             <div class="thanhtoan">
                <div class="divflex">
                    <p class="total-p">Tạm tính: </p>
                     <p class="tamtinh"> <asp:Label  ID="lbTamTinh" runat="server" />đ</p>
                </div>
                <div class="divflex">
                    <p class="total-p">Giảm giá: </p>
                     <p class="tamtinh"> <asp:Label  ID="lbKM" runat="server" />đ</p>
                </div>
                 <p style="text-align: left">(  <asp:Label Text="0" ID="lbCount" runat="server" /> sản phẩm được chọn)</p>
                <div class="divflex margin-tong">
                    <p class="total-p ">Thành tiền: </p>
                    <p class="thanhtien"><asp:Label ID="lbThanhTien" runat="server" />đ</p>
                </div>
            </div>
            <div class="btn-mua">
                <p>
                    <asp:Label Text="" ID="lbThongBao" style="color:red; text-align:center;display: block; margin-top: 4px" runat="server" /></p>
                <asp:Button ID="btnMuaHang" OnClick="btnMuaHang_Click" Text="Mua hàng" runat="server" />
            </div>
       
        </div>
    </div>

