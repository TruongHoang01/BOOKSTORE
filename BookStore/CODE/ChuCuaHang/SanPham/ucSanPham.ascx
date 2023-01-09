<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSanPham.ascx.cs" Inherits="BookStore.CODE.ChuCuaHang.ucSanPham" %>

<div class="containerdonhang">
    <div class="divdonhangphai">
        <div class="divthanhden"></div>
        <div>
            <div class="divflex divtimkiemsanpham">
                <div class="flex" style="width: 80%;">
                    <asp:dropdownlist runat="server">
                    <asp:listitem text="Mã sản phẩm" />
                    <asp:listitem text="Tên sản phẩm" />
                    </asp:dropdownlist>
                    <asp:textbox runat="server" textmode="search" placeholder="Tìm kiếm..."/>
                    <asp:linkbutton text="Tìm kiếm" runat="server" />
                </div>
                <a href="KenhBanHang.aspx?modul=SanPham&thaotac=ThemMoi" class="themmoisanpham">Thêm mới sản phẩm</a>
            </div>
        </div>
     
         <div class="navbarsanpham">
              <a href="KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach&tinhtrang=3" class="linkdonhang">Tất cả</a>
              <a href="KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach&tinhtrang=0" class="linkdonhang">Còn hàng</a>
              <a href="KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach&tinhtrang=1" class="linkdonhang">Hết hàng</a>
             <a href="KenhBanHang.aspx?modul=SanPham&thaotac=DanhSach&tinhtrang=2" class="linkdonhang">Đã xóa</a>
           
        </div>
        <div>
            <asp:GridView CssClass="kbhtable" ID="grSanPham" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="grSanPham_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText ="Tên sách" DataField="TenSach" ItemStyle-CssClass="col25 "/>
                  <asp:TemplateField HeaderText ="Hình ảnh" ItemStyle-CssClass="col20 TextCenter">
                            <ItemTemplate>
                                <asp:Image Width="70" Height="70" ImageUrl='<%#"../../../Image/product/"+Eval("HinhAnh") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                      <asp:BoundField HeaderText ="Số lượng" DataField="SoLuong" ItemStyle-CssClass="col10  TextRight"/>
                      <asp:BoundField HeaderText ="Giá bìa" DataField="GiaBia" ItemStyle-CssClass="col15 TextRight"/>
                      <asp:BoundField HeaderText ="Đã bán" DataField="DaBan" ItemStyle-CssClass="col15 TextRight"/>
                    <asp:TemplateField HeaderText ="Thao tác" ItemStyle-CssClass="col15 TextCenter">
                        <ItemTemplate>
                            <asp:ImageButton CommandArgument='<%#Eval("ID") %>' ID="btnCapNhat" OnClick="btnCapNhat_Click" ImageUrl="../../../Image/edit.jpeg" runat="server" ToolTip="Cập nhật"/>
                            <asp:ImageButton CommandArgument='<%#Eval("ID") %>' ID="btnXoa" OnClick="btnXoa_Click" ImageUrl="../../../Image/delete.png" runat="server" ToolTip="Xóa sách"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                </Columns>
            </asp:GridView>
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
             <asp:LinkButton OnClick="btnCancel_Click" ID="btnCancel" Text="Hủy" runat="server" Visible="false"/>
        </div>
</div>
