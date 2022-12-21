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
<div class="dialog overlay " id="DivXacNhanEmail" runat="server" visible="true">
            <div class="dialog-body dialog-body_danhgia ">
                <h1>Đánh giá sản phẩm</h1>
                <div>
                    <asp:Image runat="server" />
                    <div>
                        <span>Ngày buồn rười rượi là ngày mà em xa tôi. Dợi hoài chờ hoài mà đâu ai tới.</span>
                        <span>Cao Hữu Hiếu</span>
                    </div>
                </div>
                <div class="star-widget">
                    <input type="radio" onclick="setStar()" name="rate" id="rate-5">
                    <label for="rate-5"  class="fas fa-star"></label>
                    <input type="radio" onclick="setStar()" name="rate" id="rate-4">
                    <label for="rate-4" class="fas fa-star"></label>
                    <input type="radio" onclick="setStar()" name="rate" id="rate-3">
                    <label for="rate-3" class="fas fa-star"></label>
                    <input type="radio" onclick="setStar()" name="rate" id="rate-2">
                    <label for="rate-2" class="fas fa-star"></label>
                    <input type="radio" onclick="setStar()" name="rate" id="rate-1">
                    <label for="rate-1" class="fas fa-star"></label>
                    <asp:Label ID="lbStar" runat="server">Đánh giá</asp:Label>
                    <div class="textarea">
                        <asp:TextBox ID="txtDanhGia" runat="server" TextMode="MultiLine" Rows="5" Columns="50"/>
                    </div>
                    <div class="btn">
                        <asp:Button ID="btnGui" OnClick="btnGui_Click" Text="GỬI" runat="server" />
                    </div>
            </div>
    </div>
</div>
<script>
    function setStar() {
        const radioList = document.querySelectorAll("input[type='radio']");
        const lbStar = document.getElementById("UserControl_ctl00_ctl03_lbStar");
        for (let i = 0; i < radioList.length; i++) {
            if (radioList[i].checked == true)
                lbStar.innerText = (5-i)+" ";
        }
    }
</script>
