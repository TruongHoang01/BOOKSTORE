<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDonHang.ascx.cs" Inherits="BookStore.CODE.ChuCuaHang.DonHang.ucDonHang" %>

<div class="containerdonhang">
    <div class="divdonhangphai">
        <div class="divthanhden"></div>
        <div class="titleloaidonhang">
            <asp:Label ID="lbloaidonhang" Text="Tất cả đơn hàng" runat="server" /></div>
         <div class="navbardonhang">
             <a class="linkdonhang" href="KenhBanHang.aspx?modul=DonHang&tinhtrang=0">Đơn hàng mới</a>
             <a class="linkdonhang" href="KenhBanHang.aspx?modul=DonHang&tinhtrang=1"> Chờ lấy hàng</a>
             <a class="linkdonhang" href="KenhBanHang.aspx?modul=DonHang&tinhtrang=2"> Đang giao</a>
             <a class="linkdonhang" href="KenhBanHang.aspx?modul=DonHang&tinhtrang=3"> Đã giao</a>
             <a class="linkdonhang" href="KenhBanHang.aspx?modul=DonHang&tinhtrang=4"> Đơn hủy</a>
        </div>
        <div>
            <div class="flex divtimkiemdonhang">
                <asp:dropdownlist runat="server" ID="ddlTimKiem">
                    <asp:listitem Value="1" text="Mã đơn hàng" />
                    <asp:listitem Value="2" text="Tên người mua" />
                    <asp:listitem Value="3" text="Số điện thoại" />
                </asp:dropdownlist>
                <asp:textbox runat="server" textmode="search" ID="tbTuKhoa" placeholder="Tìm kiếm..."/>
                <asp:linkbutton ID="btnTimKiem" OnClick="btnTimKiem_Click" text="Tìm kiếm" runat="server" />
            </div>
        </div>
        <div>
            <asp:Label Text="" ID="lbThongBao" style="color: red; text-align:center; font-size: 18px;" runat="server" /></div>
        <div>
            <asp:GridView ID="grDonHang" CssClass="kbhtable" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText ="Mã" DataField="ID" ItemStyle-CssClass="col5 TextCenter"/>
                    <asp:BoundField HeaderText ="Họ Tên" DataField="HoTen" ItemStyle-CssClass="col20"/>
                      <asp:BoundField HeaderText ="Số Điện Thoại" DataField="SDT" ItemStyle-CssClass="col15 TextRight"/>
                      <asp:BoundField HeaderText ="Địa Chỉ" DataField="DiaChi" ItemStyle-CssClass="col30"/>
                      <asp:BoundField HeaderText ="Ngày Tạo" DataField="NgayTao" ItemStyle-CssClass="col15 TextRight"/>
                    <asp:TemplateField HeaderText ="Thao tác" ItemStyle-CssClass="col15 TextCenter">
                        <ItemTemplate>
                            <asp:ImageButton CommandArgument='<%#Eval("ID") %>' ID="linkChiTietDonHang" OnClick="linkChiTietDonHang_Click" ImageUrl="../../../Image/edit.jpeg" runat="server" ToolTip="Chi tiết đơn hàng"/>
                            <asp:ImageButton  CommandArgument='<%#Eval("ID") %>'  OnClick="btnHuy_Click" Visible="false" ID="btnHuy" ImageUrl="../../../Image/delete.png" runat="server" ToolTip="Hủy đơn hàng"/>
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
