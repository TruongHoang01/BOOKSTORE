<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKhuyenMai.ascx.cs" Inherits="BookStore.CODE.ChuCuaHang.KhuyenMai.ucKhuyenMai" %>


<div class="containerdonhang">
    <div class="divdonhangphai">
        <div class="divthanhden"></div>
        <div>
                
        </div>
         <div class="navbarsanpham">
             <a href="KenhBanHang.aspx?modul=KhuyenMai&thaotac=DanhSach&tinhTrang=0" class="linkdonhang" > Đang diễn ra</a>
            <a href="KenhBanHang.aspx?modul=KhuyenMai&thaotac=DanhSach&tinhTrang=1" class="linkdonhang" > Đã kết thúc</a>
            <a href="KenhBanHang.aspx?modul=KhuyenMai&thaotac=ThemMoi" class="btnthemmoikm">Thêm mới đợt khuyến mãi</a>
        </div>
       
        <div>
            <asp:GridView CssClass="kbhtable" ID="grKhuyenMai" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText ="Mã" DataField="ID" ItemStyle-CssClass="col5 TextCenter"/>
                    <asp:BoundField HeaderText ="Nội dung" DataField="NoiDung" ItemStyle-CssClass="col30 "/>
                      <asp:BoundField HeaderText ="Tỷ lệ" DataField="TiLe" ItemStyle-CssClass="col10 TextCenter "/>
                      <asp:BoundField HeaderText ="Ngày bắt đầu" DataField="NgayBatDau" ItemStyle-CssClass="col20 TextRight"/>
                      <asp:BoundField HeaderText ="Ngày kết thúc" DataField="NgayKetThuc" ItemStyle-CssClass="col20 TextRight"/>
                    <asp:TemplateField HeaderText ="Thao tác" ItemStyle-CssClass="col15 TextCenter">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnCapNhat" CommandArgument='<%#Eval("ID") %>' OnClick="btnCapNhat_Click" ImageUrl="../../../Image/edit.jpeg" runat="server" ToolTip="Cập nhật"/>
                            <asp:ImageButton CommandArgument='<%#Eval("ID") %>'  ID="btnXoa" OnClick="btnXoa_Click" ImageUrl="../../../Image/delete.png" runat="server" ToolTip="Kết thúc"/>
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