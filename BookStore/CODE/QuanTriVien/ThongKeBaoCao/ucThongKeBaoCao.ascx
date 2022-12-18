<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThongKeBaoCao.ascx.cs" Inherits="BookStore.CODE.QuanTriVien.ThongKeBaoCao.ucThongKeBaoCao" %>
<div class="divdate mt20">
        <span>Từ ngày: </span>
        <asp:Label CssClass="lbcalendar" ID="lbcalendar1" Text="12-12-2022" runat="server" />
        <asp:LinkButton ID="btnCalendar1" OnClick="btnCalendar1_Click" CssClass="btncalendar" Text="Chọn ngày bắt đầu" runat="server" />
        <div runat="server" class="divcalendar divcalendar1" id="divcaledar1" visible="false">
            <asp:Calendar ID="calendar1" runat="server" BackColor="#3399FF" ForeColor="White" Height="280px" TabIndex="10" Width="352px" OnSelectionChanged="calendar1_SelectionChanged"></asp:Calendar>
        </div>
                  
        <span>Đến ngày: </span>
        <asp:Label CssClass="lbcalendar" ID="lbcalendar2" Text="12-12-2022" runat="server" TabIndex="1" />
        <asp:LinkButton ID="btnCalendar2" OnClick="btnCalendar2_Click" CssClass="btncalendar" Text="Chọn ngày kết thúc" runat="server" />
        <div runat="server" class="divcalendar divcalendar2" id="divcaledar2" visible="false">
            <asp:Calendar ID="calendar2" runat="server" BackColor="#3399FF" ForeColor="White" Height="280px" TabIndex="10" Width="352px" OnSelectionChanged="calendar2_SelectionChanged" ></asp:Calendar>
         </div>
    <asp:LinkButton CssClass="btncalendar"  Text="Xem dữ liệu" runat="server" />
</div>
<div>
    <div class="divflex divbaocao">
        <div class="width20 col">
            <p><i class="fa-solid fa-user"></i></p>
            <p> <asp:Label Text="120" runat="server" /></p>
            <p class="danhmuc">TÀI KHOẢN</p>
        </div>
        <div  class="width20 col">
            <p><i class="fa-sharp fa-solid fa-user-plus"></i></p>
            <p>
                <asp:Label Text="52" runat="server" />
            </p>
            <p class="danhmuc">TÀI KHOẢN MỚI</p>
        </div>
        <div  class="width20 col">
            <p><i class="fa-solid fa-store"></i></p>
            <p>
                <asp:Label Text="52" runat="server" />
            </p>
            <p class="danhmuc">CỬA HÀNG</p>
        </div>
        <div  class="width20 col">
            <p><i class="fa-solid fa-magnifying-glass"></i></p>
            <p>
                <asp:Label Text="25.2k" runat="server" /></p>
            <p class="danhmuc">VIEW</p>
        </div>
    </div>
    <div  class="divflex divbaocao">
        <div class="width20 col">
            <p><i class="fa-solid fa-book"></i></p>
            <p><asp:Label Text="120" runat="server" /></p>
            <p class="danhmuc">BÀI ĐĂNG</p>
        </div>
        <div class="width20 col">
            <p><i class="fa-solid fa-cart-shopping"></i></p>
            <p><asp:Label Text="120" runat="server" /></p>
            <p class="danhmuc">ĐƠN HÀNG</p>
        </div>
        <div class="width20 col">
            <p><i class="fa-solid fa-dollar-sign"></i></p>
            <p><asp:Label Text="187M" runat="server" /></p>
            <p class="danhmuc">DOANH THU</p>
        </div>
        <div class="width20 col">
            <p><i class="fa-solid fa-money-bill-transfer"></i></p>
            <p>
                <asp:Label Text="18.7M" runat="server" />
            </p>
               <p class="danhmuc">THUẾ</p>
        </div>
    </div>
</div>
