<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDonHang.ascx.cs" Inherits="BookStore.CODE.KhachHang.ucDonHang" %>
<div class="DonHang">
    <div class="divlink">
        <asp:LinkButton Text="Chờ duyệt" runat="server" />
        <asp:LinkButton Text="Đang vận chuyển" runat="server" />
        <asp:LinkButton Text="Đã giao" runat="server" />
        <asp:LinkButton Text="Đã hủy" runat="server" />
    </div>
    <asp:DataList runat="server" ID="dlDonHang" Width="100%">
        <ItemTemplate>
            <div class="ThongTin">
                <div class='center DivCuaHang'>
                    <h1><%#Eval("TenCuaHang") %></h1>
                    <p> ĐÃ HỦY </p>
                </div>
                <asp:Literal ID="ltrDonHang" runat="server" />
                 <div class="flex-end">
                    <p class="thanhtien">Thành tiền: <asp:Label id="lbThanhTien" runat="server" /></p>
                </div>
                <div class="flex-end">
                    <asp:Button CssClass="btnHuy" Text="Hủy đơn hàng" runat="server" />
                </div>
             </div>
        </ItemTemplate>
    </asp:DataList>
   
</div>
